namespace Protolumz
{
    partial class P3DForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P3DForm));
            this.TreeViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.extractDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractCheckedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractCombinedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MainTreeView = new System.Windows.Forms.TreeView();
            this.MainImageList = new System.Windows.Forms.ImageList(this.components);
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.DetailsTab = new System.Windows.Forms.TabPage();
            this.MainPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.ViewTab = new System.Windows.Forms.TabPage();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOBJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oBJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TreeViewContextMenu.SuspendLayout();
            this.MainMenuStrip.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.DetailsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeViewContextMenu
            // 
            this.TreeViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractDataToolStripMenuItem,
            this.extractCheckedToolStripMenuItem,
            this.extractCombinedToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveTextureToolStripMenuItem,
            this.saveOBJToolStripMenuItem});
            this.TreeViewContextMenu.Name = "TreeViewContextMenu";
            this.TreeViewContextMenu.Size = new System.Drawing.Size(170, 120);
            // 
            // extractDataToolStripMenuItem
            // 
            this.extractDataToolStripMenuItem.Name = "extractDataToolStripMenuItem";
            this.extractDataToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.extractDataToolStripMenuItem.Text = "Extract";
            this.extractDataToolStripMenuItem.Click += new System.EventHandler(this.extractDataToolStripMenuItem_Click);
            // 
            // extractCheckedToolStripMenuItem
            // 
            this.extractCheckedToolStripMenuItem.Name = "extractCheckedToolStripMenuItem";
            this.extractCheckedToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.extractCheckedToolStripMenuItem.Text = "Extract Checked";
            this.extractCheckedToolStripMenuItem.Click += new System.EventHandler(this.extractCheckedToolStripMenuItem_Click_1);
            // 
            // extractCombinedToolStripMenuItem
            // 
            this.extractCombinedToolStripMenuItem.Name = "extractCombinedToolStripMenuItem";
            this.extractCombinedToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.extractCombinedToolStripMenuItem.Text = "Extract Combined";
            this.extractCombinedToolStripMenuItem.Click += new System.EventHandler(this.combinedToolStripMenuItem_Click);
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.MainMenuStrip.TabIndex = 1;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 428);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(800, 22);
            this.MainStatusStrip.TabIndex = 2;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 24);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.SearchTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.MainTreeView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.MainTabControl);
            this.splitContainer2.Size = new System.Drawing.Size(800, 404);
            this.splitContainer2.SplitterDistance = 259;
            this.splitContainer2.TabIndex = 3;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTextBox.Location = new System.Drawing.Point(60, 9);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(183, 20);
            this.SearchTextBox.TabIndex = 5;
            this.SearchTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search:";
            // 
            // MainTreeView
            // 
            this.MainTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainTreeView.CheckBoxes = true;
            this.MainTreeView.ContextMenuStrip = this.TreeViewContextMenu;
            this.MainTreeView.HideSelection = false;
            this.MainTreeView.ImageIndex = 0;
            this.MainTreeView.ImageList = this.MainImageList;
            this.MainTreeView.Location = new System.Drawing.Point(13, 35);
            this.MainTreeView.Name = "MainTreeView";
            this.MainTreeView.SelectedImageIndex = 0;
            this.MainTreeView.ShowLines = false;
            this.MainTreeView.ShowRootLines = false;
            this.MainTreeView.Size = new System.Drawing.Size(230, 359);
            this.MainTreeView.TabIndex = 3;
            this.MainTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MainTreeView_AfterSelect);
            // 
            // MainImageList
            // 
            this.MainImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MainImageList.ImageStream")));
            this.MainImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.MainImageList.Images.SetKeyName(0, "Package_16x.png");
            this.MainImageList.Images.SetKeyName(1, "ImagePixel_16x.png");
            this.MainImageList.Images.SetKeyName(2, "Model3D_outline_16x.png");
            this.MainImageList.Images.SetKeyName(3, "ShaderSpot_16x.png");
            this.MainImageList.Images.SetKeyName(4, "DataMining_16x.png");
            this.MainImageList.Images.SetKeyName(5, "TextFile_16x.png");
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.DetailsTab);
            this.MainTabControl.Controls.Add(this.ViewTab);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(537, 404);
            this.MainTabControl.TabIndex = 2;
            // 
            // DetailsTab
            // 
            this.DetailsTab.Controls.Add(this.MainPropertyGrid);
            this.DetailsTab.Location = new System.Drawing.Point(4, 22);
            this.DetailsTab.Name = "DetailsTab";
            this.DetailsTab.Padding = new System.Windows.Forms.Padding(3);
            this.DetailsTab.Size = new System.Drawing.Size(529, 378);
            this.DetailsTab.TabIndex = 1;
            this.DetailsTab.Text = "Details";
            this.DetailsTab.UseVisualStyleBackColor = true;
            // 
            // MainPropertyGrid
            // 
            this.MainPropertyGrid.DisabledItemForeColor = System.Drawing.SystemColors.WindowText;
            this.MainPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPropertyGrid.HelpVisible = false;
            this.MainPropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.MainPropertyGrid.Name = "MainPropertyGrid";
            this.MainPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.MainPropertyGrid.Size = new System.Drawing.Size(523, 372);
            this.MainPropertyGrid.TabIndex = 0;
            this.MainPropertyGrid.ToolbarVisible = false;
            // 
            // ViewTab
            // 
            this.ViewTab.Location = new System.Drawing.Point(4, 22);
            this.ViewTab.Name = "ViewTab";
            this.ViewTab.Padding = new System.Windows.Forms.Padding(3);
            this.ViewTab.Size = new System.Drawing.Size(529, 378);
            this.ViewTab.TabIndex = 2;
            this.ViewTab.Text = "View";
            this.ViewTab.UseVisualStyleBackColor = true;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // saveTextureToolStripMenuItem
            // 
            this.saveTextureToolStripMenuItem.Name = "saveTextureToolStripMenuItem";
            this.saveTextureToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveTextureToolStripMenuItem.Text = "Save Texture";
            // 
            // saveOBJToolStripMenuItem
            // 
            this.saveOBJToolStripMenuItem.Name = "saveOBJToolStripMenuItem";
            this.saveOBJToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveOBJToolStripMenuItem.Text = "Save OBJ";
            this.saveOBJToolStripMenuItem.Click += new System.EventHandler(this.saveOBJToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oBJToolStripMenuItem});
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // oBJToolStripMenuItem
            // 
            this.oBJToolStripMenuItem.Name = "oBJToolStripMenuItem";
            this.oBJToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.oBJToolStripMenuItem.Text = "OBJ";
            this.oBJToolStripMenuItem.Click += new System.EventHandler(this.oBJToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // P3DForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.MainMenuStrip);
            this.Name = "P3DForm";
            this.Text = "P3D Viewer - by Skylumz";
            this.TreeViewContextMenu.ResumeLayout(false);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.MainTabControl.ResumeLayout(false);
            this.DetailsTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem extractDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView MainTreeView;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage DetailsTab;
        private System.Windows.Forms.PropertyGrid MainPropertyGrid;
        private System.Windows.Forms.ToolStripMenuItem extractCheckedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ImageList MainImageList;
        private System.Windows.Forms.TabPage ViewTab;
        private System.Windows.Forms.ToolStripMenuItem extractCombinedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveTextureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveOBJToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oBJToolStripMenuItem;
    }
}