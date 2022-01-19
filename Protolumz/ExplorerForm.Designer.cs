namespace Protolumz
{
    partial class ExplorerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerForm));
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ListViewCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ListViewSelectedCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainImageList = new System.Windows.Forms.ImageList(this.components);
            this.MainToolStrip = new System.Windows.Forms.ToolStrip();
            this.GoBackButton = new System.Windows.Forms.ToolStripButton();
            this.GoForwardButton = new System.Windows.Forms.ToolStripButton();
            this.PathTextBox = new Protolumz.Forms.Winforms.ToolStripAutoSizeTextBox();
            this.PathButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.SearchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.SearchButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MainTreeView = new System.Windows.Forms.TreeView();
            this.MainTreeNodeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainListView = new System.Windows.Forms.ListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TypeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SizeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttributesColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PathColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MainListViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.extractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractUncompressedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuStrip.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.MainToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.MainTreeNodeContextMenu.SuspendLayout();
            this.MainListViewContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.openFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem1_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.ListViewCountLabel,
            this.ListViewSelectedCountLabel});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 499);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(800, 22);
            this.MainStatusStrip.TabIndex = 2;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(67, 17);
            this.StatusLabel.Text = "StatusLabel";
            // 
            // ListViewCountLabel
            // 
            this.ListViewCountLabel.Name = "ListViewCountLabel";
            this.ListViewCountLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // ListViewSelectedCountLabel
            // 
            this.ListViewSelectedCountLabel.Name = "ListViewSelectedCountLabel";
            this.ListViewSelectedCountLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainImageList
            // 
            this.MainImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MainImageList.ImageStream")));
            this.MainImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.MainImageList.Images.SetKeyName(0, "temp");
            this.MainImageList.Images.SetKeyName(1, "default");
            this.MainImageList.Images.SetKeyName(2, "folder");
            this.MainImageList.Images.SetKeyName(3, "archive");
            this.MainImageList.Images.SetKeyName(4, "xml");
            this.MainImageList.Images.SetKeyName(5, "application");
            this.MainImageList.Images.SetKeyName(6, "web");
            this.MainImageList.Images.SetKeyName(7, "text");
            this.MainImageList.Images.SetKeyName(8, "image");
            this.MainImageList.Images.SetKeyName(9, "video");
            this.MainImageList.Images.SetKeyName(10, "img628.png");
            this.MainImageList.Images.SetKeyName(11, "img625.png");
            this.MainImageList.Images.SetKeyName(12, "img624.png");
            this.MainImageList.Images.SetKeyName(13, "unk");
            this.MainImageList.Images.SetKeyName(14, "img622.png");
            this.MainImageList.Images.SetKeyName(15, "img620.png");
            this.MainImageList.Images.SetKeyName(16, "img646.png");
            this.MainImageList.Images.SetKeyName(17, "img645.png");
            this.MainImageList.Images.SetKeyName(18, "img643.png");
            this.MainImageList.Images.SetKeyName(19, "img659.png");
            this.MainImageList.Images.SetKeyName(20, "unk");
            this.MainImageList.Images.SetKeyName(21, "p3d");
            this.MainImageList.Images.SetKeyName(22, "img657.png");
            this.MainImageList.Images.SetKeyName(23, "img656.png");
            this.MainImageList.Images.SetKeyName(24, "img654.png");
            this.MainImageList.Images.SetKeyName(25, "img653.png");
            this.MainImageList.Images.SetKeyName(26, "img652.png");
            // 
            // MainToolStrip
            // 
            this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GoBackButton,
            this.GoForwardButton,
            this.PathTextBox,
            this.PathButton,
            this.RefreshButton,
            this.SearchTextBox,
            this.SearchButton});
            this.MainToolStrip.Location = new System.Drawing.Point(0, 24);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.Size = new System.Drawing.Size(800, 25);
            this.MainToolStrip.TabIndex = 4;
            this.MainToolStrip.Text = "toolStrip1";
            // 
            // GoBackButton
            // 
            this.GoBackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GoBackButton.Image = ((System.Drawing.Image)(resources.GetObject("GoBackButton.Image")));
            this.GoBackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GoBackButton.Name = "GoBackButton";
            this.GoBackButton.Size = new System.Drawing.Size(23, 22);
            this.GoBackButton.Text = "toolStripButton1";
            this.GoBackButton.Click += new System.EventHandler(this.GoBackButton_Click);
            // 
            // GoForwardButton
            // 
            this.GoForwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GoForwardButton.Image = ((System.Drawing.Image)(resources.GetObject("GoForwardButton.Image")));
            this.GoForwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GoForwardButton.Name = "GoForwardButton";
            this.GoForwardButton.Size = new System.Drawing.Size(23, 22);
            this.GoForwardButton.Text = "toolStripButton2";
            this.GoForwardButton.Click += new System.EventHandler(this.GoForwardButton_Click);
            // 
            // PathTextBox
            // 
            this.PathTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.PathTextBox.Size = new System.Drawing.Size(490, 25);
            // 
            // PathButton
            // 
            this.PathButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PathButton.Image = ((System.Drawing.Image)(resources.GetObject("PathButton.Image")));
            this.PathButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PathButton.Name = "PathButton";
            this.PathButton.Size = new System.Drawing.Size(23, 22);
            this.PathButton.Text = "toolStripButton4";
            this.PathButton.Click += new System.EventHandler(this.PathButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshButton.Image")));
            this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshButton.Text = "toolStripButton5";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(150, 25);
            // 
            // SearchButton
            // 
            this.SearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SearchButton.Image = ((System.Drawing.Image)(resources.GetObject("SearchButton.Image")));
            this.SearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(23, 22);
            this.SearchButton.Text = "toolStripButton1";
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MainTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.MainListView);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 214;
            this.splitContainer1.TabIndex = 5;
            // 
            // MainTreeView
            // 
            this.MainTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainTreeView.ContextMenuStrip = this.MainTreeNodeContextMenu;
            this.MainTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTreeView.FullRowSelect = true;
            this.MainTreeView.ImageIndex = 0;
            this.MainTreeView.ImageList = this.MainImageList;
            this.MainTreeView.Location = new System.Drawing.Point(0, 0);
            this.MainTreeView.Name = "MainTreeView";
            this.MainTreeView.SelectedImageIndex = 0;
            this.MainTreeView.ShowLines = false;
            this.MainTreeView.Size = new System.Drawing.Size(214, 450);
            this.MainTreeView.TabIndex = 0;
            this.MainTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.MainTreeView_BeforeSelect);
            this.MainTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MainTreeView_AfterSelect);
            this.MainTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainTreeView_MouseUp);
            // 
            // MainTreeNodeContextMenu
            // 
            this.MainTreeNodeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeFolderToolStripMenuItem});
            this.MainTreeNodeContextMenu.Name = "MainTreeNodeContextMenu";
            this.MainTreeNodeContextMenu.Size = new System.Drawing.Size(140, 26);
            // 
            // closeFolderToolStripMenuItem
            // 
            this.closeFolderToolStripMenuItem.Name = "closeFolderToolStripMenuItem";
            this.closeFolderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.closeFolderToolStripMenuItem.Text = "Close Folder";
            this.closeFolderToolStripMenuItem.Click += new System.EventHandler(this.closeFolderToolStripMenuItem_Click);
            // 
            // MainListView
            // 
            this.MainListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.TypeColumn,
            this.SizeColumn,
            this.AttributesColumn,
            this.PathColumn});
            this.MainListView.ContextMenuStrip = this.MainListViewContextMenu;
            this.MainListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainListView.HideSelection = false;
            this.MainListView.Location = new System.Drawing.Point(0, 0);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(582, 450);
            this.MainListView.SmallImageList = this.MainImageList;
            this.MainListView.TabIndex = 0;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            this.MainListView.ItemActivate += new System.EventHandler(this.MainListView_ItemActivate);
            this.MainListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainListView_MouseUp);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 40;
            // 
            // TypeColumn
            // 
            this.TypeColumn.Text = "Type";
            this.TypeColumn.Width = 36;
            // 
            // SizeColumn
            // 
            this.SizeColumn.Text = "Size";
            this.SizeColumn.Width = 32;
            // 
            // AttributesColumn
            // 
            this.AttributesColumn.Text = "Attributes";
            this.AttributesColumn.Width = 56;
            // 
            // PathColumn
            // 
            this.PathColumn.Text = "Path";
            this.PathColumn.Width = 392;
            // 
            // MainListViewContextMenu
            // 
            this.MainListViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.toolStripSeparator1,
            this.openFileLocationToolStripMenuItem,
            this.toolStripSeparator2,
            this.extractToolStripMenuItem,
            this.extractUncompressedToolStripMenuItem});
            this.MainListViewContextMenu.Name = "MainListViewContextMenu";
            this.MainListViewContextMenu.Size = new System.Drawing.Size(193, 104);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            this.openFileLocationToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.openFileLocationToolStripMenuItem.Text = "Open File Location";
            this.openFileLocationToolStripMenuItem.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // extractToolStripMenuItem
            // 
            this.extractToolStripMenuItem.Name = "extractToolStripMenuItem";
            this.extractToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.extractToolStripMenuItem.Text = "Extract Raw";
            this.extractToolStripMenuItem.Click += new System.EventHandler(this.extractToolStripMenuItem_Click);
            // 
            // extractUncompressedToolStripMenuItem
            // 
            this.extractUncompressedToolStripMenuItem.Name = "extractUncompressedToolStripMenuItem";
            this.extractUncompressedToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.extractUncompressedToolStripMenuItem.Text = "Extract Uncompressed";
            this.extractUncompressedToolStripMenuItem.Click += new System.EventHandler(this.extractUncompressedToolStripMenuItem_Click);
            // 
            // ExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 521);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.MainToolStrip);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.MainMenuStrip);
            this.Name = "ExplorerForm";
            this.Text = "Rcf Explorer - Protolumz by Skylumz";
            this.ResizeEnd += new System.EventHandler(this.ExplorerForm_ResizeEnd);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.MainTreeNodeContextMenu.ResumeLayout(false);
            this.MainListViewContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ImageList MainImageList;
        private System.Windows.Forms.ToolStrip MainToolStrip;
        private System.Windows.Forms.ToolStripButton GoBackButton;
        private System.Windows.Forms.ToolStripButton GoForwardButton;
        private System.Windows.Forms.ToolStripButton PathButton;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView MainTreeView;
        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader SizeColumn;
        private System.Windows.Forms.ColumnHeader TypeColumn;
        private System.Windows.Forms.ToolStripStatusLabel ListViewCountLabel;
        private System.Windows.Forms.ToolStripStatusLabel ListViewSelectedCountLabel;
        private System.Windows.Forms.ColumnHeader AttributesColumn;
        private System.Windows.Forms.ContextMenuStrip MainListViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem extractToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem extractUncompressedToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton SearchButton;
        private System.Windows.Forms.ContextMenuStrip MainTreeNodeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem closeFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader PathColumn;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private Forms.Winforms.ToolStripAutoSizeTextBox PathTextBox;
        private System.Windows.Forms.ToolStripTextBox SearchTextBox;
    }
}

