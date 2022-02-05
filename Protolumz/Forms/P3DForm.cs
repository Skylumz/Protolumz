using OpenTK;
using Protolumz.Resources;
using RadicalCore.Gamefiles;
using RadicalCore.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
            Icon = Owner.Icon;

            OpenFile(fp, data);
        }

        private void OpenFile(string fp, byte[] data)
        {
            Task.Run(() =>
            {
                FilePath = fp;
                ActiveFile = new P3DFile(fp);
                ActiveFile.Load(data);
                UpdateTitle();
                BuildTree();
            });
        }

        private void UpdateTitle()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(()=> UpdateTitle()));
            }
            else
            {
                Text = "P3D Viewer - Skylumz - " + FileName;
            }
        }

        private int GetImageIndex(P3DNode node)
        {
            var parent = node.GetTopMostParent();
            if(parent is TextureNode)
            {
                return 1;
            }
            else if(parent is ModelNode)
            {
                return 2;
            }
            else if (parent is ShaderNode)
            {
                return 3;
            }
            else if(parent is MetaObjectDefinitionNode)
            {
                return 4;
            }
            else
            {
                return 5;
            }
        }
        private void UpdateNode(P3DNode node, TreeNodeCollection parent)
        {
            var tnode = new TreeNode(node.ToString());
            tnode.ImageIndex = GetImageIndex(node);
            tnode.SelectedImageIndex = GetImageIndex(node);
            tnode.Tag = node;

            foreach (var child in node.Children)
            {
                UpdateNode(child, tnode.Nodes);
            }

            parent.Add(tnode);
        }
        private void BuildTree()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => BuildTree()));
            }
            else
            {
                if (ActiveFile == null) return;

                MainPropertyGrid.SelectedObject = ActiveFile;

                MainTreeView.BeginUpdate();
                MainTreeView.Nodes.Clear();

                var root = new TreeNode(ActiveFile.Name);
                root.ImageIndex = 0;
                root.SelectedImageIndex = 0;
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

        private void UpdateUI()
        {
            if (SelectedNode == null) return;

            var tag = SelectedNode.Tag;
            if (tag is P3DNode)
            {
                MainPropertyGrid.SelectedObject = (P3DNode)SelectedNode.Tag;
                UpdateViewer(tag as P3DNode);
                UpdateContextMenu();
            }
            else if (tag is P3DFile)
            {
                MainPropertyGrid.SelectedObject = (P3DFile)SelectedNode.Tag;
            }

            
        }
        private void UpdateContextMenu()
        {
            saveOBJToolStripMenuItem.Enabled = (SelectedNode.Tag is MeshNode) || (SelectedNode.Tag is ModelNode);
            saveTextureToolStripMenuItem.Enabled = (SelectedNode.Tag is TextureNode);
        }
        private void UpdateViewer(P3DNode node)
        {
            var viewer = GetViewer(node);
            viewer.LoadNode(node);
            var c = (Control)viewer;
            c.Dock = DockStyle.Fill;
            ViewTab.Controls.Clear();
            ViewTab.Controls.Add(c);
        }
        private INodeView GetViewer(P3DNode node)
        {
            if (node is TextureNode)
            {
                var viewer = new ImageViewer();
                return viewer;
            }
            else if(node is MetaObjectDataNode)
            {
                var viewer = new MetaViewer();
                return viewer;
            }
            else
            {
                var viewer = new HexViewer();
                return viewer;
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
        private void ExtractNodesChecked(bool combined)
        {
            if (combined)
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
            else
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
        }

        private void SaveOBJ(bool saveall = false)
        {
            StringBuilder errors = new StringBuilder();
            OBJFile obj = new OBJFile();

            if (saveall)
            {
                obj.Name = Path.GetFileNameWithoutExtension(ActiveFile.Name);
                foreach(var node in ActiveFile.Nodes)
                {
                    if (node is ModelNode)
                    {
                        foreach(var childnode in node.Children)
                        {
                            if (childnode is MeshNode)
                            {
                                try
                                {
                                    obj.AddMesh(childnode as MeshNode);
                                }
                                catch (Exception ex)
                                {
                                    errors.AppendLine("Mesh: " + (childnode as MeshNode).Name + " unable to export because: " + ex.ToString());
                                }
                            }
                            
                        }
                    }
                }
            }
            else
            {
                if (SelectedNode.Tag is ModelNode)
                {
                    var modelnode = SelectedNode.Tag as ModelNode;
                    obj.Name = modelnode.Name;
                    foreach (var node in modelnode.Children)
                    {
                        if (node is MeshNode)
                        {
                            try
                            {
                                obj.AddMesh(node as MeshNode);
                            }
                            catch(Exception ex)
                            {
                                errors.AppendLine("Mesh: " + (node as MeshNode).Name + " unable to export because: " + ex.ToString());
                            }
                        }
                    }
                }
                else
                {
                    var meshnode = SelectedNode.Tag as MeshNode;
                    obj.Name = meshnode.Name;
                    try
                    {
                        obj.AddMesh(meshnode);
                    }
                    catch (Exception ex)
                    {
                        errors.AppendLine("Mesh: " + meshnode.Name + " unable to export because: " + ex.ToString());
                    }
                }

                if (errors.ToString().Length > 0)
                {
                    MessageBox.Show("Errors encountered", errors.ToString());
                }
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "OBJ File|*.obj";
                sfd.FileName = obj.Name;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    obj.Save(sfd.FileName);
                }
            }
        }
        //change to save actuall dds file
        private void SaveDDS()
        {
            if (!(SelectedNode.Tag is TextureNode)) return;

            var texturenode = SelectedNode.Tag as TextureNode;

            var data = DDSIO.GetDDSFile(texturenode);
            if (data == null)
            {
                MessageBox.Show("Failure to extract texture: " + texturenode.Name);
                return;
            }

            using(var sfd = new SaveFileDialog())
            {
                sfd.FileName = texturenode.Name;
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sfd.FileName, data);
                }
            }
        }

        private void MainTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedNode = e.Node;
            UpdateUI();
        }
        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Search(SearchTextBox.Text);
            }
        }
        private void combinedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            extractCombinedToolStripMenuItem.Checked = !extractCombinedToolStripMenuItem.Checked;
        }
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "P3D files|*.p3d";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    OpenFile(ofd.FileName, File.ReadAllBytes(ofd.FileName));
                }
            }
        }

        //main tree view context menu
        private void extractDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractNodeData();
        }
        private void extractTextureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDDS();
        }
        private void extractCheckedToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ExtractNodesChecked(extractCombinedToolStripMenuItem.Checked);
        }

        private void saveOBJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveOBJ();
        }
        private void oBJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveOBJ(true);
        }
    }
}
