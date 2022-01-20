using RadicalCore.Gamefiles;
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

namespace Protolumz
{
    public partial class P3DForm : Form
    {
        private string FilePath = null;
        private string FileName { get { return Path.GetFileName(FilePath); } }
        private P3DFile ActiveFile = null;

        private TreeNode RootNode = null;

        private TreeNode SelectedNode = null;

        public P3DForm(ExplorerForm ef, string fp, byte[] data)
        {
            InitializeComponent();

            Owner = ef;
            FilePath = fp;
            ActiveFile = new P3DFile(fp);
            ActiveFile.Load(data);

            InitForm();
            BuildTree();
        }

        private void InitForm()
        {
            Icon = Owner.Icon;
            Text = "P3D Viewer - Skylumz - " + FileName;
        }

        private void UpdateUI()
        {
            if (SelectedNode == null) return;

            var tag = SelectedNode.Tag;
            if (tag is P3DNode)
            {
                MainPropertyGrid.SelectedObject = (P3DNode)SelectedNode.Tag;
            }
            else if (tag is P3DFile)
            {
                MainPropertyGrid.SelectedObject = (P3DFile)SelectedNode.Tag;
            }
        }



        private List<TreeNode> GetAllNodes(TreeNode parent = null)
        {
            var nodes = new List<TreeNode>();
            nodes.Add(parent);
            foreach (TreeNode node in parent.Nodes)
            {
                nodes.AddRange(GetAllNodes(node));
            }
            return nodes;
        }
        private List<TreeNode> GetAllNodesChecked()
        {
            var nodes = new List<TreeNode>();
            foreach (TreeNode node in MainTreeView.Nodes)
            {
                var cnodes = GetAllNodes(node);
                foreach(var cnode in cnodes)
                {
                    if (cnode.Checked)
                    {
                        nodes.Add(cnode);
                    }
                }
            }
            return nodes;
        }

        private void UpdateNode(P3DNode node, TreeNodeCollection parent)
        {
            var tnode = new TreeNode(node.ToString());
            tnode.Tag = node;

            foreach (var child in node.Children)
            {
                UpdateNode(child, tnode.Nodes);
            }

            parent.Add(tnode);
        }
        private void BuildTree()
        {
            if (ActiveFile == null) return;

            MainPropertyGrid.SelectedObject = ActiveFile;

            MainTreeView.BeginUpdate();
            MainTreeView.Nodes.Clear();

            var root = new TreeNode(ActiveFile.Name);
            root.Tag = ActiveFile;

            RootNode = root;

            foreach (var node in ActiveFile.Nodes)
            {
                UpdateNode(node, root.Nodes);
            }

            MainTreeView.Nodes.Add(root);
            root.Expand();
            MainTreeView.EndUpdate();
        }

        private void Search(string term)
        {
            var nodes = GetAllNodes(RootNode);
            var foundnodes = new List<TreeNode>();

            MainTreeView.Nodes.Clear();

            if (string.IsNullOrEmpty(term))
            {
                MainTreeView.Nodes.Add(RootNode);
                return;
            }

            foreach (var node in nodes)
            {
                if (node.Text.ToLower().Contains(term.ToLower()))
                {
                    foundnodes.Add(node.Clone() as TreeNode);
                }
            }

            foreach (var node in foundnodes)
            {
                MainTreeView.Nodes.Add(node);
            }
        }

        private void OpenHexForm()
        {
            if(SelectedNode == null) return;

            if (SelectedNode.Tag is P3DNode)
            {
                var pn = (P3DNode)SelectedNode.Tag;
                HexEditorForm form = new HexEditorForm(this, SelectedNode.Text, pn.Data);
                form.Show();
            }
        }

        private void ExtractNodeData()
        {
            var tag = SelectedNode.Tag;
            if (tag is P3DNode)
            {
                using (var sfd = new SaveFileDialog())
                {
                    var pnode = tag as P3DNode;
                    sfd.FileName = pnode.ToString();
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(sfd.FileName + ".data", pnode.Data);
                    }
                }
            }
        }
        private void ExtractNodesChecked()
        {
            var nodes = GetAllNodesChecked();
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    var pnodes = new List<P3DNode>();

                    foreach (TreeNode node in nodes)
                    {
                        if (node.Tag is P3DNode)
                        {
                            pnodes.Add((node.Tag as P3DNode));
                        }
                    }

                    if (nodes.Count == 0) return;

                    foreach (var node in pnodes)
                    {
                        var filepath = Path.Combine(fbd.SelectedPath, node.ToString() + ".data");
                        File.WriteAllBytes(filepath, node.Data);
                    }
                }
            }
        }
        private void ExtractNodesCheckedCombined()
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.FileName = FileName + ".data";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var nodes = GetAllNodesChecked();
                    var data = new List<byte>();

                    foreach (TreeNode node in nodes)
                    {
                        if (node.Tag is P3DNode)
                        {
                            data.AddRange((node.Tag as P3DNode).Data);
                        }
                    }

                    var path = sfd.FileName;
                    File.WriteAllBytes(path, data.ToArray());
                }
            }
        }

        private void ExtractOBJ()
        {
            if (!(SelectedNode.Tag is ModelNode)) return;

            var modelnode = SelectedNode.Tag as ModelNode;
        }


        private void MainTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedNode = e.Node;
            UpdateUI();
        }

        private void openHexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHexForm();
        }
        
        private void extractCheckedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractNodesChecked();
        }

        private void extractDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractNodeData();
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            Search(SearchTextBox.Text);
        }

        private void extractOBJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractOBJ();
        }
    }
}
