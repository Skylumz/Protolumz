using RadicalCore.Gamefiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protolumz.Forms.Views
{
    public partial class PropsView : UserControl
    {
        private PropRestoreArray PropRestoreArray = null;

        private TreeNode RootNode = null;
        private TreeNode SelectedNode = null;

        public PropsView(PropRestoreArray pra)
        {
            InitializeComponent();

            Task.Run(() =>
            {
                PropRestoreArray = pra;
                BuildTree();
            });
        }

        private void BuildTree()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => BuildTree()));
            }
            else
            {
                if (PropRestoreArray == null) return;

                MainPropertyGrid.SelectedObject = PropRestoreArray;

                MainTreeView.BeginUpdate();
                MainTreeView.Nodes.Clear();

                var name = "Prop Restore Array";
                var root = new TreeNode(name);
                root.ImageIndex = 0;
                root.SelectedImageIndex = 0;
                root.Tag = PropRestoreArray;

                RootNode = root;

                foreach (var prop in PropRestoreArray.Props)
                {
                    var tnode = new TreeNode(prop.Name);
                    tnode.Tag = prop;
                    root.Nodes.Add(tnode);
                }

                MainTreeView.Nodes.Add(root);
                root.Expand();
                MainTreeView.EndUpdate();
            }
        }
        private void UpdateUI()
        {
            if (SelectedNode == null) return;

            var tag = SelectedNode.Tag;
            MainPropertyGrid.SelectedObject = tag;
        }

        private void MainTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedNode = e.Node;
            UpdateUI();
        }
    }
}
