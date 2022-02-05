using RadicalCore.Gamefiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protolumz
{
    public partial class AssetExplorerForm : Form
    {
        private RcfManager RcfMan = null;

        private string gameFolder
        {
            get
            {
                return Properties.Settings.Default.GameFolder;
            }
        }

        bool extracting = false;
        bool abort = false;

        public AssetExplorerForm(Form owner, RcfManager man)
        {
            InitializeComponent();

            this.Icon = owner.Icon;
            RcfMan = man;

            if (RcfMan == null)
            {
                Task.Run(() =>
                {
                    RcfMan.Init(gameFolder, Log);
                });
            }

            InitComboBoxes();
        }

        private void InitComboBoxes()
        {
            Log("Building asset type dictionary...");
            foreach (var type in Enum.GetNames(typeof(P3DNodeType)))
            {
                AssetTypeComboBox.Items.Add(type.ToString());
            }
            Log("Building rcf dictionary...");
            RcfComboBox.Items.Add("All");
            foreach (var rcf in RcfMan.AllRcfs)
            {
                RcfComboBox.Items.Add(rcf.Name);
            }
            AssetTypeComboBox.SelectedIndex = 0;
            RcfComboBox.SelectedIndex = 0;
            SearchTypeComboBox.SelectedIndex = 0;
        }

        private void Log(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Log(text)));
            }
            else
            {
                LogBox.AppendText(text);
                LogBox.AppendText(Environment.NewLine);
            }
        }

        

        private string GetFolder()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    return fbd.SelectedPath;
                }
            }
            return "";
        }

        private void Extract()
        {
            string folder = GetFolder();
            if (folder == "") return;

            extracting = true;
            int extractcount = 0;
            string rcfname = RcfComboBox.Text;
            string typetext = AssetTypeComboBox.Text.ToLower();
            var type = (P3DNodeType)Enum.Parse(typeof(P3DNodeType), AssetTypeComboBox.Text);

            Task.Run(() =>
            {
                Log(string.Format("Extracting {0} assets to {1}", typetext, folder));
                foreach (var rcf in RcfMan.AllRcfs)
                {
                    if (rcf.Name == rcfname || rcfname == "All")
                    {
                        foreach (var entry in rcf.Entries)
                        {
                            if (abort)
                            {
                                EndExtract(extractcount, typetext);
                                return;
                            }

                            if (entry.FullName.EndsWith(".p3d") || entry.FullName.EndsWith(".rz"))
                            {
                                Log(string.Format("Scanning {0}\\{1}...", rcf.Name.ToLower(), entry.FullName.ToLower()));
                                P3DFile p3d = new P3DFile(entry.FullName);
                                p3d.Load(rcf.GetData(entry));

                                foreach (var node in p3d.GetAllNodes())
                                {
                                    if (node.Type == type)
                                    {
                                        Log(string.Format("Extracting {0} from {1} in {2}...", node.ToString().ToLower(), p3d.Name.ToLower(), rcf.Name.ToLower()));
                                        string name = node.ToString().Trim(Path.GetInvalidFileNameChars());
                                        string path = Path.Combine(folder, name);
                                        File.WriteAllBytes(path, node.Data);
                                        extractcount++;
                                    }
                                }
                            }
                        }
                    }
                }

                EndExtract(extractcount, typetext);
            });
        }
        private void EndExtract(int count, string type)
        {
            extracting = false;
            Log(string.Format("Extracted {0} {1} assets", count, type));
            if (abort)
            {
                abort = false;
                Log("Extraction aborted");
            }
        }

        private void Search()
        {
            string rcfname = RcfComboBox.Text;
            string searchtype = SearchTypeComboBox.Text;
            string term = SearchTextBox.Text;
            string typetext = AssetTypeComboBox.Text;
            bool contains = ContainsCheckBox.Checked;
            Task.Run(() =>
            {
                switch (searchtype)
                {
                    case "Filename":
                        SearchForFileName(rcfname, term, contains);
                        break;
                    case "P3D":
                        SearchP3DForAsset(rcfname, term, typetext);
                        break;
                    default:
                        SearchForAsset(rcfname, typetext);
                        break;
                }
            });
        }
        private void SearchForFileName(string rcfname, string term, bool contains)
        {
            if (term == "") return;
            Dictionary<string, int> occurences = new Dictionary<string, int>();

            string log = string.Format("Searching for filenames that have {0} in them", term);
            if (rcfname != "All")
            {
                log += " in " + rcfname;
            }
            Log(log + "...");
            foreach (var rcf in RcfMan.AllRcfs)
            {
                if (rcf.Name == rcfname || rcfname == "All")
                {
                    int count = 0;
                    foreach (var entry in rcf.Entries)
                    {
                        if (abort)
                        {
                            Log("Search aborted");
                            abort = false;
                            return;
                        }

                        if (entry.FullName.Contains(term) == contains)
                        {
                            Log(string.Format("Found {0} in {1}", entry.FullName.ToLower(), rcf.Name.ToLower()));
                            count++;
                        }
                    }
                    occurences.Add(rcf.Name, count);
                }
            }

            foreach(var occurence in occurences)
            {
                if (contains)
                {
                    Log(string.Format("Found {0} occurence{1} of {2} in {3}", occurence.Value, occurences.Count == 1 ? "" : "s", term, occurence.Key));
                }
                else
                {
                    Log(string.Format("Found {0} files that do not contain {1} in {2}", occurence.Value, term, occurence.Key));
                }
            }
        }
        private void SearchForAsset(string rcfname, string typetext)
        {
            var type = (P3DNodeType)Enum.Parse(typeof(P3DNodeType), typetext);
            string log = string.Format("Searching p3d files for {0} assets", typetext.ToLower());
            if (rcfname != "All")
            {
                log += " in " + rcfname;
            }
            Log(log + "...");
            foreach (var rcf in RcfMan.AllRcfs)
            {
                if (rcf.Name == rcfname || rcfname == "All")
                {
                    if (rcf.Name == rcfname || rcfname == "All")
                    {
                        foreach (var entry in rcf.Entries)
                        {
                            if (abort)
                            {
                                Log("Search aborted");
                                abort = false;
                                return;
                            }

                            if (entry.FullName.EndsWith(".p3d") || entry.FullName.EndsWith(".rz"))
                            {
                                P3DFile p3d = new P3DFile(entry.FullName);
                                p3d.Load(rcf.GetData(entry));
                                int count = 0;
                                foreach (var node in p3d.GetAllNodes())
                                {
                                    if (node.Type == type)
                                    {
                                        count++;
                                    }
                                }

                                Log(string.Format("Found {0} {1} assets in {2}\\{3}", count, typetext.ToLower(), rcf.Name.ToLower(), entry.FullName.ToLower()));
                            }
                        }
                    }
                }
            }
        }
        private void SearchP3DForAsset(string rcfname, string term, string typetext)
        {
            if (term == "" || !term.EndsWith(".p3d")) return;
            var type = (P3DNodeType)Enum.Parse(typeof(P3DNodeType), typetext);
            string log = string.Format("Searching for files named {0} with {1} assets", term, typetext.ToLower());
            if(rcfname != "All")
            {
                log += " in " + rcfname;
            }
            Log(log + "...");
            int filecount = 0;
            foreach (var rcf in RcfMan.AllRcfs)
            {
                if (rcf.Name == rcfname || rcfname == "All")
                {
                    foreach (var entry in rcf.Entries)
                    {
                        if (abort)
                        {
                            Log("Search aborted");
                            abort = false;
                            return;
                        }

                        if (entry.Name == term)
                        {
                            P3DFile p3d = new P3DFile(entry.FullName);
                            p3d.Load(rcf.GetData(entry));
                            int count = 0;
                            foreach (var node in p3d.GetAllNodes())
                            {
                                if (node.Type == type)
                                {
                                    count++;
                                }
                            }
                            filecount++;
                            Log(string.Format("Found {0} {1} assets in {2}\\{3}", count, typetext.ToLower(), rcf.Name.ToLower(), entry.FullName.ToLower()));
                        }
                    }
                }
            }

            if (filecount == 0)
            {
                log = string.Format("Found 0 {0} files", term);
                if (rcfname != "All") log += " in " + rcfname;
                Log(log);
            }
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            Extract();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            abort = true;
        }

        private void ClearLogButton_Click(object sender, EventArgs e)
        {
            LogBox.Clear();
        }
    }
}

