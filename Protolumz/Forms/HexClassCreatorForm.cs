using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

//TODO
//rework everything this was expermental 

namespace Protolumz
{
    public partial class HexClassCreatorForm : Form
    {
        private HexEditorForm HexForm { get; set; }

        TreeNode RootNode { get; set; }

        private HexClassContainer ClassContainer { get; set; } = new HexClassContainer("UnknownFile");

        private List<HexClass> Classes
        {
            get
            {
                return ClassContainer.Classes;
            }
        }
        public HexClass SelectedClass { get; set; }
        public HexClassMember SelectedMember { get; set; }
        public List<HexClassMember> CurrentMembers
        {
            get
            {
                if (SelectedClass == null) return null;
                return SelectedClass.Members;
            }
        }

        private Dictionary<string, int> TypeIndexDict { get; set; } 

        public HexClassCreatorForm(HexEditorForm hf)
        {
            InitializeComponent();

            HexForm = hf;
            Text = "Class Parser - by Skylumz";
            Icon = HexForm.Icon;

            UpdateMainTreeView();
        }

        private void UpdateUI()
        {
            if (MainTreeView.Nodes.Count == 0 || Classes.Count == 0) return;

            var node = MainTreeView.SelectedNode;
            SelectedClass = Classes[node.Index];
        
            ClassNameTextBox.Text = SelectedClass.Name;

            MemberTreeView.Nodes.Clear();
            foreach(var mem in CurrentMembers)
            {
                TreeNode mnode = new TreeNode();
                mnode.Text = mem.Name;
                MemberTreeView.Nodes.Add(mnode);
            }

            if(CurrentMembers.Count > 0)
            {
                MemberTreeView.SelectedNode = MemberTreeView.Nodes[0];
            }

            
        }
        private void UpdateMemberUI()
        {
            if(MemberTreeView.Nodes.Count == 0 || SelectedClass == null) return;

            var node = MemberTreeView.SelectedNode;
            SelectedMember = CurrentMembers[node.Index];

            MemberNameTextBox.Text = SelectedMember.Name;
            MemberTypeComboBox.SelectedIndex = TypeIndexDict[SelectedMember.Type];
            MemberValueTextBox.Text = SelectedMember.Value.ToString();
        }
        private void UpdateMainTreeView()
        {
            MainTreeView.Nodes.Clear();
            TypeIndexDict = new Dictionary<string, int>()
            {
                {"BYTE", 0},
                {"BYTEARRAY", 1 },
                {"STRING", 2 },
                {"INT16", 3 },
                {"UINT16", 4 },
                {"INT32", 5 },
                {"UINT32", 6 },
                {"INT64", 7 },
                {"UINT64", 8 },
            };

            RootNode = new TreeNode(ClassContainer.Name);
            foreach (var cls in Classes)
            {
                TreeNode node = new TreeNode();
                node.Text = cls.Name;
                RootNode.Nodes.Add(node);
                TypeIndexDict.Add(cls.Name, TypeIndexDict.Count);
            }
            MainTreeView.Nodes.Add(RootNode);

            MemberTypeComboBox.Items.Clear();
            foreach (var type in TypeIndexDict.Keys)
            {
                MemberTypeComboBox.Items.Add(type);
            }

            if (RootNode.Nodes.Count > 0)
            {
                MainTreeView.SelectedNode = RootNode.Nodes[0];
            }

            UpdateUI();
        }

        
        
        private void NewClass()
        {
            string name = "Unknown";
            InputBox.Show("Create New Class", "Please enter the class name", ref name);
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Invalid class name");
                return;
            }

            ClassContainer.AddClass(name);
            UpdateMainTreeView();
        }
        private void AddMember()
        {
            if (SelectedClass == null) return;

            string name = "Unknown";
            InputBox.Show("Create New Member", "Please enter the member name", ref name);
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Invalid member name");
                return;
            }

            SelectedClass.AddMember(name);
            UpdateUI();
        }



        private void ReadClass()
        {
            string sres = "";
            InputBox.Show("Read at", "Offset", ref sres);

            int offset = 0;
            if(!int.TryParse(sres, out offset))
            {
                MessageBox.Show("Invalid offset");
                return;
            }

            if (offset > HexForm.Data.Length)
            {
                MessageBox.Show("Invalid offset.");
                return;
            }

            var data = HexForm.Data.Skip(offset).Take(SelectedClass.GetSize()).ToArray();

            SelectedClass.Load(data);
            UpdateMemberUI();
        }



        private void newClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewClass();
        }

        private void MainTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateUI();
        }
        private void MemberTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateMemberUI();
        }

        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            AddMember();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(OFD.ShowDialog() == DialogResult.OK)
            {
                ClassContainer.Load(OFD.FileName);
                UpdateMainTreeView();
            }
        }

        private void ClassNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SelectedClass == null) return;
            SelectedClass.Name = ClassNameTextBox.Text;
        }
        private void MemberNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SelectedMember == null) return;
            SelectedMember.Name = MemberNameTextBox.Text;
        }
        private void MemberTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedMember == null) return;
            SelectedMember.Type = MemberTypeComboBox.Text;
        }

        private void readAtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadClass();
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.FileName = ClassContainer.Name + ".hex.xml";
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    ClassContainer.Save(sfd.FileName);
                }
            }
        }
    }

    public class HexClassContainer
    {
        public string Name { get; set; }
        public List<HexClass> Classes { get; set; } = new List<HexClass>();

        public HexClassContainer(string name)
        {
            Name = name;
        }

        public void Load(string filepath)
        {
            if (!filepath.EndsWith(".xml")) { return; }

            Name = Path.GetFileName(filepath).Replace(".hex.xml", "");

            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);

            Classes = new List<HexClass>();

            foreach(XmlNode node in doc.ChildNodes[0].ChildNodes)
            {
                Classes.Add(new HexClass(this, node));
            }
        }

        public void Save(string filepath)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Classes");
            foreach(var cls in Classes)
            {
                XmlElement clsnode = doc.CreateElement("Class");
                clsnode.SetAttribute("name", cls.Name);
                foreach(var mem in cls.Members)
                {
                    XmlElement memnode = doc.CreateElement("Member");
                    memnode.SetAttribute("name", mem.Name);
                    XmlElement typenode = doc.CreateElement("Type");
                    typenode.InnerText = mem.Type;
                    memnode.AppendChild(typenode);
                    clsnode.AppendChild(memnode);
                }
                root.AppendChild(clsnode);
            }
            doc.AppendChild(root);
            doc.Save(filepath);
        }

        public void AddClass(string name)
        {
            var namedict = Classes.ToDictionary(cls => cls.Name);

            if (namedict.ContainsKey(name))
            {
                var rnd = new Random();
                name += rnd.Next(name.Length);
            }

            Classes.Add(new HexClass(this, name));
        }
    }
    public class HexClass
    {
        public string Name { get; set; }
        public List<HexClassMember> Members { get; set; } = new List<HexClassMember>();
        public byte[] Data { get; set; } = new byte[0];

        public HexClassContainer Owner { get; set; }

        public HexClass(HexClassContainer owner, XmlNode node)
        {
            Owner = owner;
            Name = node.Attributes["name"].Value;
            foreach(XmlNode n in node.ChildNodes)
            {
                Members.Add(new HexClassMember(owner, n));
            }
        }

        public HexClass(HexClassContainer owner, string name)
        {
            Owner = owner;
            Name = name;
        }
        
        public void Load(byte[] data)
        {
            int position = 0;
            foreach(var mem in Members)
            {
                switch (mem.Type)
                {
                    case "BYTE":
                        mem.Value = data[position];
                        break;
                    case "INT16":
                        mem.Value = BitConverter.ToInt16(data, position);
                        break;
                    case "UINT16":
                        mem.Value = BitConverter.ToUInt16(data, position);
                        break;
                    case "INT32":
                        mem.Value = BitConverter.ToInt32(data, position);
                        break;
                    case "UINT32":
                        mem.Value = BitConverter.ToUInt32(data, position);
                        break;
                    case "INT64":
                        mem.Value = BitConverter.ToInt64(data, position);
                        break;
                    case "UINT64":
                        mem.Value = BitConverter.ToUInt64(data, position);
                        break;
                }
                position += mem.GetSize();
            }

            Data = data;
        }

        public void AddMember(string name)
        {
            //var memDict = Members.ToDictionary(mem => mem.Name, mem => mem);

            //string prefix = "";
            //if (memDict.ContainsKey(name))
            //{
            //    var mem = memDict[name].Name;
            //    var mprefix = mem.Last().ToString();
            //    int i;
            //    if(!int.TryParse(mprefix, out i))
            //    {
            //        prefix = "0";
            //    }
            //    else
            //    {
            //        prefix = (i + 1).ToString();
            //    }
            //}
            //name += prefix;

            Members.Add(new HexClassMember(Owner, name));
        }
    
        public int GetSize()
        {
            int size = 0;
            foreach(var mem in Members)
            {
                size += mem.GetSize();
            }
            return size;
        }
    }
    public class HexClassMember
    {
        public string Name { get; set; }
        public string Type { get; set; } = "BYTE";
        public object Value { get; set; } = 0;

        public HexClassContainer Owner { get; set; }

        public HexClassMember(HexClassContainer owner, XmlNode node)
        {
            Owner = owner;
            Name = node.Attributes["name"].Value;
            Type = node.LastChild.InnerText;
        }

        public HexClassMember(HexClassContainer owner, string name)
        {
            Owner = owner;
            Name = name;
        }

        public int GetSize()
        {
            if (Type.Contains("BYTE"))
            {
                return 1;
            }
            if (Type.Contains("16"))
            {
                return 2;
            }
            else if (Type.Contains("32") || Type.Contains("FLOAT"))
            {
                return 4;
            }
            else 
            {
                return 0;
            }
        }
    }
}
