using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RadicalCore.Gamefiles;
using System.IO;
using RadicalCore;

namespace Protolumz
{
    public partial class ExplorerForm : Form
    {
        private string gameFolder = @"D:\Games\SteamLibrary\steamapps\common\Prototype 2\prototype2.exe";
        private const string exename = "prototype2.exe";

        private RcfManager RcfMan;

        public Dictionary<string, int> FileTypeImageIndexDict = new Dictionary<string, int>()
        {
            { "default", 1 },
            { "folder", 2 },
            { "xml", 4 },
            { "dll", 5 },
            { "exe", 5 },
            { "asi", 5 },
            { "html", 6 },
            { "url", 6 },
            { "txt", 7 },
            { "dat", 7 },
            { "cfg", 7 },
            { "ini", 7 },
            { "json", 7 },
            { "bmp", 8 },
            { "ico", 8 },
            { "png", 8 },
            { "jpg", 8 },
            { "jpeg", 8 },
            { "bik", 9 },
            { "exeicon", 0 },
            

            { "rcf", 3 },
            { "p3d", 21 },
        };
        private TreeNode SelectedNode = null;
        
        public ExplorerForm()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            bool isOk = EnsureGameFolder();
            if (!isOk)
            {
                Environment.Exit(1);
            }
            BringToFront();

            this.Icon = Icon.ExtractAssociatedIcon(gameFolder);
            MainImageList.Images[0] = this.Icon.ToBitmap();

            RcfMan = new RcfManager();
            Task.Run(() =>
            {
                RcfMan.Init(Path.GetDirectoryName(gameFolder), UpdateStatus, LogError);
                RefreshMainTreeView();
            });
        }




        private bool EnsureGameFolder()
        {
            if (!gameFolder.Contains(exename))
            {
                bool isOk = false;
                bool cancel = false;
                while ((!isOk & !cancel) == true)
                {
                    cancel = YesNoMessageBox("Please select a folder that contains "  + exename, "Select Folder");
                    if (cancel) continue;
                    var fld = GetFolder();
                    if (string.IsNullOrEmpty(fld)) continue;
                    var info = new DirectoryInfo(fld);
                    foreach (var file in info.GetFiles())
                    {
                        if (file.Name.Contains(exename))
                        {
                            isOk = true;
                            gameFolder = file.FullName;
                            return true;
                        }
                    }
                }
            }
            else return true;
            return false;
        }
        private bool YesNoMessageBox(string caption, string title)
        {
            var diag = MessageBox.Show(caption, title, MessageBoxButtons.OKCancel);
            switch (diag)
            {
                case DialogResult.Cancel:
                    return true;
                default:
                    return false;
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
        private string GetFile()
        {
            using (var fbd = new OpenFileDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    return fbd.FileName;
                }
            }
            return "";
        }



        private void UpdateUI()
        {
            if (SelectedNode == null) return;
            if (SelectedNode.Tag is DirectoryInfo)
            {
                PathTextBox.Text = (SelectedNode.Tag as DirectoryInfo).FullName;
            }
            else if (SelectedNode.Tag is RcfDirectory)
            {
                PathTextBox.Text = (SelectedNode.Tag as RcfDirectory).FullNameWithOwner;
            }
            else //for search nodes...
            {
                PathTextBox.Text = SelectedNode.Text;
            }

            ListViewCountLabel.Text = MainListView.Items.Count.ToString() + " items";
            if (MainListView.SelectedItems.Count > 0)
            {
                var selectedcount = MainListView.SelectedItems.Count.ToString();
                ListViewSelectedCountLabel.Text = MainListView.SelectedItems.Count > 1 ? selectedcount + " items selected" : selectedcount + " item selected";
            }
            else { ListViewSelectedCountLabel.Text = ""; }

            for (int i = 0; i < MainListView.Columns.Count; i++)
            {
                var wth = -1;
                var col = MainListView.Columns[i];
                if (col.Text == "Attributes") wth = -2;
                if (col.Text == "Path") wth = 0;
                col.Width = wth;
            }
        }
        private void UpdateStatus(string text)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdateStatus(text)));
            }
            else
            {
                StatusLabel.Text = text;
                
            }
        }
        private void LogError(string text) 
        { }


        public int GetImageIndex(string ext)
        {
            foreach (var key in FileTypeImageIndexDict.Keys)
            {
                if (key == ext)
                {
                    return FileTypeImageIndexDict[key];
                }
            }
            return FileTypeImageIndexDict["default"];
        }
        private object[] CacheDetails(DirectoryInfo info)
        {
            //img index, type
            return new object[] { FileTypeImageIndexDict["folder"], "File Folder", "", "", info.FullName };
        }
        private object[] CacheDetails(FileInfo file)
        {
            //img index, type, size, attributes, path
            var ext = file.Extension.ToLowerInvariant().Substring(1);
            var name = ext;
            switch (name)
            {
                case "rcf":
                    name = "Archive";
                    break;
                default:
                    name = name.ToUpper();
                    break;
            }
            return new object[] { GetImageIndex(ext), name + " File",
                string.Format("{0:n0}", Math.Round((double)file.Length / 1024)) + " KB", "", file.FullName };
        }
        private object[] CacheDetails(RcfEntry entry)
        {
            var ext = Path.GetExtension(entry.Name);
            if (!string.IsNullOrEmpty(ext)) ext = ext.Substring(1);
            else ext = "UNKNOWN";

            string attr = "";
            switch (ext)
            {
                case "rz":
                    attr = "Compresssed";
                    break;
            }
            var details = new List<object>() { GetImageIndex(ext), ext.ToUpper() + " File",
                string.Format("{0:n0}", Math.Round((double)entry.Size / 1024)) + " KB", attr, entry.FullName};
            
            return details.ToArray();
        }
        private object[] CacheDetails(RcfDirectory dir)
        {
            //img index, type
            return new object[] { FileTypeImageIndexDict["folder"], "Archive Folder", "", "", dir.FullName };
        }
        private ListViewItem GetListViewItem(DirectoryInfo folder)
        {
            ListViewItem item = new ListViewItem(folder.Name);
            item.Tag = folder;
            var details = CacheDetails(folder);
            item.ImageIndex = (int)details[0];
            for (int i = 1; i < details.Length; i++)
            {
                item.SubItems.Add(details[i].ToString());
            }
            return item;
        }
        private ListViewItem GetListViewItem(FileInfo file)
        {
            ListViewItem item = new ListViewItem(file.Name);
            item.Tag = file;
            var details = CacheDetails(file);
            item.ImageIndex = (int)details[0];
            for (int i = 1; i < details.Length; i++)
            {
                item.SubItems.Add(details[i].ToString());
            }
            return item;
        }
        private ListViewItem GetListViewItem(RcfEntry entry)
        {
            ListViewItem item = new ListViewItem(entry.Name);
            item.Tag = entry;
            var details = CacheDetails(entry);
            item.ImageIndex = (int)details[0];
            for (int i = 1; i < details.Length; i++)
            {
                item.SubItems.Add(details[i].ToString());
            }
            return item;
        }
        private ListViewItem GetListViewItem(RcfDirectory dir)
        {
            ListViewItem item = new ListViewItem(dir.Name);
            item.Tag = dir;
            var details = CacheDetails(dir);
            item.ImageIndex = (int)details[0];
            for (int i = 1; i < details.Length; i++)
            {
                item.SubItems.Add(details[i].ToString());
            }
            return item;
        }
        private List<ListViewItem> GetListViewItems(TreeNode node)
        {
            if (node == null) return null;
            
            var items = new List<ListViewItem>();
            if (node.Tag is DirectoryInfo)
            {
                var dir = node.Tag as DirectoryInfo;
                foreach (var file in dir.GetFiles())
                {
                    items.Add(GetListViewItem(file));
                }
                foreach (var cdir in dir.GetDirectories())
                {
                    items.Add(GetListViewItem(cdir));
                }
            }
            else if(node.Tag is RcfDirectory)
            {
                var dir = node.Tag as RcfDirectory;
                foreach(var file in dir.Files)
                {
                    items.Add(GetListViewItem(file));
                }
                foreach(var cdir in dir.Directories)
                {
                    items.Add(GetListViewItem(cdir));
                }
            }
            //for search nodes
            else if (node.Tag is List<ListViewItem>)
            {
                items = node.Tag as List<ListViewItem>;
            }
            else { } //...??
            return items;
        }
        private void UpdateMainListView(List<ListViewItem> items)
        {
            MainListView.Items.Clear();
            foreach (var item in items)
            {
                MainListView.Items.Add(item);
            }
            UpdateUI();
        }

        private void RemoveMainTreeViewNode(TreeNode node)
        {
            MainTreeView.Nodes.Remove(node);
        }
        private TreeNode GetTreeNode(RcfDirectory dir)
        {
            TreeNode node = new TreeNode(dir.Name);
            node.Tag = dir;
            var imgkey = dir.Name.Contains("rcf") ? "rcf" : "folder"; 
            node.ImageIndex = FileTypeImageIndexDict[imgkey];
            node.SelectedImageIndex = node.ImageIndex;

            foreach(var cdir in dir.Directories)
            {
                node.Nodes.Add(GetTreeNode(cdir));
            }

            return node;
        }
        private TreeNode GetTreeNode(DirectoryInfo folder)
        {
            TreeNode node = new TreeNode(folder.Name);
            node.Tag = folder;
            node.ImageIndex = FileTypeImageIndexDict["folder"];
            node.SelectedImageIndex = node.ImageIndex;

            if (folder.GetDirectories().Length > 0)
            {
                foreach (var dir in folder.GetDirectories())
                {
                    node.Nodes.Add(GetTreeNode(dir));
                }
            }
            if (folder.GetFiles().Length > 0)
            {
                foreach (var file in folder.GetFiles())
                {
                    if (file.Extension.ToLowerInvariant().Contains("rcf"))
                    {
                        RcfFile rcf = RcfMan.GetRcfFile(file.Name);
                        if (rcf == null) continue;
                        node.Nodes.Add(GetTreeNode(rcf.RootDirectory));
                    }
                }
            }
            return node;
        }
        private TreeNode AddMainTreeViewNode(string path, string idxkey = "folder", TreeNode parent = null)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => AddMainTreeViewNode(path, idxkey, parent)));
            }
            else
            {
                if (string.IsNullOrEmpty(path)) return null;
                TreeNode node = null;
                if (File.Exists(path)) //is a archive file
                {
                    if (!path.EndsWith("rcf")) return null; //should never happen

                    var rcf = RcfMan.GetRcfFile(Path.GetFileName(path));
                    if (rcf == null)
                    {
                        rcf = new RcfFile(path);
                        rcf.Load(UpdateStatus, LogError);
                        RcfMan.AddRcfFile(rcf);
                    }
                    node = GetTreeNode(rcf.RootDirectory);
                }
                else
                {
                    node = GetTreeNode(new DirectoryInfo(path));
                }
                node.ImageIndex = FileTypeImageIndexDict[idxkey];
                node.SelectedImageIndex = FileTypeImageIndexDict[idxkey];
                node.Expand();
                if (parent == null)
                {
                    MainTreeView.Nodes.Add(node);
                }
                else
                {
                    parent.Nodes.Add(node);
                }
                return node;
            }
            return null;
        }
        private void RefreshMainTreeView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => RefreshMainTreeView()));
            }
            else
            {
                MainTreeView.Nodes.Clear();
                AddMainTreeViewNode(Path.GetDirectoryName(gameFolder), "exeicon");
                MainTreeView.SelectedNode = MainTreeView.Nodes[0];
            }
        }




        private TreeNode SelectNode(string name, TreeNode parent=null)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => SelectNode(name, parent)));
            }
            else
            {
                //if (SelectedNode.Text == name) return SelectedNode;

                var nodes = (parent == null) ? GetAllNodes(MainTreeView.Nodes[0]) : GetAllNodes(parent);
                foreach (TreeNode node in nodes)
                {
                    if (node.Text == name)
                    {
                        MainTreeView.SelectedNode = node;
                        return node;
                    }
                }
                return null;
            }
            return null;
        }
        private TreeNode SelectNode(string path)
        {
            var hierarchy = path.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var n = MainTreeView.Nodes[0];
            if (!string.IsNullOrEmpty(path))
            {
                for (int i = 0; i < hierarchy.Length; i++)
                {
                    n = SelectNode(hierarchy[i], n);
                }
            }

            if (n != null) { } //what to do...
            else { } //what to do...

            return n;
        }
        private void SelectNode(int index)
        {
            var nodes = new List<TreeNode>();
            foreach(TreeNode node in MainTreeView.Nodes)
            {
                nodes.AddRange(GetAllNodes(node));
            }
            MainTreeView.SelectedNode = nodes[index];
        }
        private List<TreeNode> GetAllNodes(TreeNode parent)
        {
            List<TreeNode> result = new List<TreeNode>();
            result.Add(parent);
            foreach (TreeNode node in parent.Nodes)
            {
                result.AddRange(GetAllNodes(node));
            }
            return result;
        }

        

        private void Search(string term)
        {
            UpdateStatus("Searching...");
            Cursor = Cursors.WaitCursor;

            TreeNode node = new TreeNode("Search Results: " + term);
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;

            var items = new List<ListViewItem>();
            foreach (TreeNode mnode in MainTreeView.Nodes)
            {
                var nodes = GetAllNodes(mnode);
                foreach (TreeNode cnode in nodes)
                {
                    if (cnode.Tag is DirectoryInfo)
                    {
                        var dir = cnode.Tag as DirectoryInfo;
                        var files = dir.GetFiles("*" + term + "*", SearchOption.TopDirectoryOnly);
                        foreach (var file in files)
                        {
                            items.Add(GetListViewItem(file));
                        }
                    }
                    else if (cnode.Tag is RcfDirectory)
                    {
                        var dir = cnode.Tag as RcfDirectory;
                        foreach (var file in dir.Files)
                        {
                            if (file.Name.Contains(term))
                            {
                                items.Add(GetListViewItem(file));
                            }
                        }
                    }
                }
            }
            

            node.Tag = items;
            MainTreeView.Nodes.Add(node);
            MainTreeView.SelectedNode = node;

            Cursor = Cursors.Default;
            UpdateStatus("Search Complete");
        }
        private void Filter(string term)
        {
            if (string.IsNullOrEmpty(term) && SelectedNode != null)
            {
                // reset list view by re-selecting the active node
                var text = SelectedNode.Text;
                MainTreeView.SelectedNode = null;
                SelectNode(text, null);
            }

            var searchitems = GetListViewItems(SelectedNode);
            if (searchitems == null) return;
            var items = new List<ListViewItem>();
            foreach(ListViewItem item in searchitems)
            {
                if (item.Text.ToLowerInvariant().Contains(term.ToLowerInvariant()))
                {
                    items.Add(item);
                }
            }
            UpdateMainListView(items);
        }
        private void GoForward()
        {
            MessageBox.Show("TODO");
        }
        private void GoBack()
        {
            MessageBox.Show("TODO");
        }


        private void OpenFileLocation()
        {
            if (MainListView.SelectedIndices.Count == 1)
            {
                var idx = MainListView.SelectedIndices[0];
                var item = MainListView.Items[idx];

                TreeNode node = null;

                if (item.Tag is DirectoryInfo)
                {
                    node = SelectNode(item.Text, null);
                }
                else if (item.Tag is FileInfo)
                {
                    var file = item.Tag as FileInfo;
                    node = SelectNode(file.DirectoryName);
                }
                else if (item.Tag is RcfEntry)
                {
                    var entry = item.Tag as RcfEntry;
                    node = SelectNode(entry.Directory.FullNameWithOwner);
                }
                else if (item.Tag is RcfDirectory) { } //should never be used..
                else { }
                
                if (node == null)
                {
                    MessageBox.Show("File location not found..."); //? should never happen
                }
            }
            else { } //multiple items...?
        }

        private void ViewFile()
        {
            if (MainListView.SelectedIndices.Count == 1)
            {
                var idx = MainListView.SelectedIndices[0];
                var item = MainListView.Items[idx];
                
                string filepath = "";
                byte[] data = null;

                if (item.Tag is DirectoryInfo)
                {
                    var dir = item.Tag as DirectoryInfo;
                    var t = SelectNode(dir.FullName);
                    return;
                }
                else if (item.Tag is FileInfo)
                {
                    var file = item.Tag as FileInfo;
                    if (file.Extension.ToLowerInvariant().Contains("rcf"))
                    {
                        var n = SelectNode(item.Text, SelectedNode);
                        if (n == null)
                        {
                            //var rcf = RcfMan.GetRcfFile(file.Name);
                            //n = AddMainTreeViewNode(file.FullName, "rcf", SelectedNode);
                            //SelectNode(item.Text, SelectedNode);
                        }
                        return;
                    }
                    else
                    {
                        filepath = file.FullName;
                        data = File.ReadAllBytes(filepath);
                    }
                }
                else if (item.Tag is RcfEntry)
                {
                    var entry = item.Tag as RcfEntry;
                    filepath = entry.FullName;
                    data = entry.Owner.GetData(entry);
                }
                else if (item.Tag is RcfDirectory)
                {
                    SelectNode(item.Text, SelectedNode);
                    return;
                }
                else { }

                ViewFile(filepath, data);
            }
            else { } //multiple items...?
        }
        private void ViewFile(string filepath, byte[] data)
        {
            var ext = Path.GetExtension(filepath).Substring(1);

            switch (ext)
            {
                case "rcf":
                    AddMainTreeViewNode(filepath, ext);
                    break;
                case "p3d":
                case "rz":
                    OpenP3DForm(filepath, data);
                    break;
                case "txt":
                case "xml":
                case "ini":
                case "htm":
                case "html":
                case "url":
                case "json":
                case "dat":
                case "cfg":
                    OpenTextForm(filepath, data);
                    break;
                default:
                    OpenHexForm(filepath, data);
                    break;
            }
        }
        private void OpenP3DForm(string filepath, byte[] data)
        {
            P3DForm form = new P3DForm(this, filepath, data);
            form.Show(this);
        }
        private void OpenTextForm(string filepath, byte[] data)
        {
            TextEditorForm form = new TextEditorForm(this, filepath, data);
            form.Show(this);
        }
        private void OpenHexForm(string filepath, byte[] data)
        {
            HexEditorForm form = new HexEditorForm(this, filepath, data);
            form.Show(this);
        }
        

        private void ExtractFile(bool uncompressed = false)
        {
            if (MainListView.SelectedIndices.Count == 1)
            {
                var idx = MainListView.SelectedIndices[0];
                var item = MainListView.Items[idx];
                var name = "";
                var data = new byte[0];
                var folder = GetFolder();

                try
                {
                    if (item.Tag is FileInfo)
                    {
                        var file = item.Tag as FileInfo;
                        name = file.Name;
                        data = File.ReadAllBytes(file.FullName);
                    }
                    else if (item.Tag is RcfEntry)
                    {
                        var entry = item.Tag as RcfEntry;
                        name = (uncompressed == true && entry.Name.EndsWith("rz")) ? Path.ChangeExtension(entry.Name, null) : entry.Name;
                        data = entry.Owner.GetData(entry, uncompressed);
                    }

                    File.WriteAllBytes(Path.Combine(folder, name), data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Failure to extract: {0} because {1}", item.Text, ex));
                }
            }
            else { } //multiple items...?
        }


        //windows
        private void ExplorerForm_ResizeEnd(object sender, EventArgs e)
        {
            //for updating list view columns
            UpdateUI();
        }

        private void MainTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
        }
        private void MainTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedNode = e.Node;
            UpdateMainListView(GetListViewItems(SelectedNode));
        }
        private void MainTreeView_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void MainListView_ItemActivate(object sender, EventArgs e)
        {
            ViewFile();
        }
        private void MainListView_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateUI();
        }
    
        //form buttons
        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMainTreeViewNode(GetFolder());
        }
        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fp = GetFile();
            if (string.IsNullOrEmpty(fp)) return;
            var file = new FileInfo(fp);
            ViewFile(file.FullName, File.ReadAllBytes(file.FullName));
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                RefreshMainTreeView();
            });
        }
        private void PathButton_Click(object sender, EventArgs e)
        {
            SelectNode(PathTextBox.Text);
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            Search(SearchTextBox.Text);
        }
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            Filter(SearchTextBox.Text);
        }
        private void GoBackButton_Click(object sender, EventArgs e)
        {
            GoBack();
        }
        private void GoForwardButton_Click(object sender, EventArgs e)
        {
            GoForward();
        }

        //list view context menu
        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractFile();
        }
        private void extractUncompressedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractFile(true);
        }
        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewFile();
        }
        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileLocation();
        }
        private void copyFileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            foreach(ListViewItem lvi in MainListView.Items)
            {
                sb.AppendLine(lvi.Text);
            }
            Clipboard.SetText(sb.ToString());
        }

        //tree node context menu
        private void closeFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedNode.Parent == null && MainTreeView.Nodes.Count == 1) return;
            RemoveMainTreeViewNode(SelectedNode);
            SelectNode(0);
        }
    }
}
