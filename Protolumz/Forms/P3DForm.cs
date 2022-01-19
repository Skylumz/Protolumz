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
        private string FilePath { get; set; }
        private string FileName { get { return Path.GetFileName(FilePath); } }
        private P3DFile ActiveFile { get; set; }

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

        private void BuildTree()
        {
            if (ActiveFile == null) return;

            MainPropertyGrid.SelectedObject = ActiveFile;

            MainTreeView.BeginUpdate();
            MainTreeView.Nodes.Clear();

            var root = new TreeNode(ActiveFile.Name);
            root.Tag = ActiveFile;

            foreach (var node in ActiveFile.Nodes)
            {
                this.UpdateNode(node, root.Nodes);
            }

            MainTreeView.Nodes.Add(root);
            root.Expand();
            MainTreeView.EndUpdate();
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

        private void MainTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Tag == null) return;

            var tag = e.Node.Tag;
            if (tag is P3DNode)
            {
                MainPropertyGrid.SelectedObject = (P3DNode)e.Node.Tag;
            }
            else if (tag is P3DFile)
            {
                MainPropertyGrid.SelectedObject = (P3DFile)e.Node.Tag;
            }
        }

        private void openHexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = MainTreeView.SelectedNode;

            if(node == null || node.Tag == null) return;
            if(node.Tag is P3DNode)
            {
                var pn = (P3DNode)node.Tag;
                HexEditorForm form = new HexEditorForm(this, node.Text, pn.Data);
                form.Show();
            }
        }

        private List<TreeNode> GetAllNodes(TreeNode parent=null)
        {
            var nodes = new List<TreeNode>();
            nodes.Add(parent);
            foreach(TreeNode node in parent.Nodes)
            {
                nodes.AddRange(GetAllNodes(node));
            }
            return nodes;
        }

        private void extractCheckedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nodes = GetAllNodes(MainTreeView.Nodes[0]);
            using(var fbd = new FolderBrowserDialog())
            {
                if(fbd.ShowDialog() == DialogResult.OK)
                {
                    var pnodes = new List<P3DNode>();

                    foreach (TreeNode node in nodes)
                    {
                        if (node.Checked && node.Tag is P3DNode)
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

            //using (var sfd = new SaveFileDialog())
            //{
            //    sfd.FileName = FileName + ".data";
                
            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        var nodes = GetAllNodes(MainTreeView.Nodes[0]);
            //        var data = new List<byte>();
                    
            //        foreach(TreeNode node in nodes)
            //        {
            //            if (node.Checked && node.Tag is P3DNode)
            //            {
            //                data.AddRange((node.Tag as P3DNode).Data);
            //            }
            //        }

            //        var path = sfd.FileName;
            //        File.WriteAllBytes(path, data.ToArray());
            //    }
            //}
        }

        private void extractDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = MainTreeView.SelectedNode;
            if (node == null) return;
            if (node.Tag == null) return;

            var tag = node.Tag;
            if (tag is P3DNode)
            {
                using (var sfd = new SaveFileDialog())
                {
                    var pnode = tag as P3DNode;
                    sfd.FileName = pnode.ToString() + ".data";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(sfd.FileName, pnode.Data);
                    }
                }
            }
        }
    }
}
