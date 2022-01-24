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
            this.TreeViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.extractDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MainTreeView = new System.Windows.Forms.TreeView();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.DetailsTab = new System.Windows.Forms.TabPage();
            this.MainPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.TextureTab = new System.Windows.Forms.TabPage();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.extractCheckedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combinedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewContextMenu.SuspendLayout();
            this.MainMenuStrip.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.DetailsTab.SuspendLayout();
            this.TextureTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TreeViewContextMenu
            // 
            this.TreeViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openHexToolStripMenuItem,
            this.toolStripSeparator1,
            this.extractDataToolStripMenuItem,
            this.extractCheckedToolStripMenuItem});
            this.TreeViewContextMenu.Name = "TreeViewContextMenu";
            this.TreeViewContextMenu.Size = new System.Drawing.Size(160, 76);
            // 
            // openHexToolStripMenuItem
            // 
            this.openHexToolStripMenuItem.Name = "openHexToolStripMenuItem";
            this.openHexToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openHexToolStripMenuItem.Text = "View Hex";
            this.openHexToolStripMenuItem.Click += new System.EventHandler(this.openHexToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // extractDataToolStripMenuItem
            // 
            this.extractDataToolStripMenuItem.Name = "extractDataToolStripMenuItem";
            this.extractDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.extractDataToolStripMenuItem.Text = "Extract";
            this.extractDataToolStripMenuItem.Click += new System.EventHandler(this.extractDataToolStripMenuItem_Click);
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.MainMenuStrip.TabIndex = 1;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
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
            this.splitContainer2.SplitterDistance = 238;
            this.splitContainer2.TabIndex = 3;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTextBox.Location = new System.Drawing.Point(60, 9);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(167, 20);
            this.SearchTextBox.TabIndex = 5;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
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
            this.MainTreeView.Location = new System.Drawing.Point(13, 35);
            this.MainTreeView.Name = "MainTreeView";
            this.MainTreeView.ShowLines = false;
            this.MainTreeView.ShowRootLines = false;
            this.MainTreeView.Size = new System.Drawing.Size(214, 362);
            this.MainTreeView.TabIndex = 3;
            this.MainTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MainTreeView_AfterSelect);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.DetailsTab);
            this.MainTabControl.Controls.Add(this.TextureTab);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(558, 404);
            this.MainTabControl.TabIndex = 2;
            // 
            // DetailsTab
            // 
            this.DetailsTab.Controls.Add(this.MainPropertyGrid);
            this.DetailsTab.Location = new System.Drawing.Point(4, 22);
            this.DetailsTab.Name = "DetailsTab";
            this.DetailsTab.Padding = new System.Windows.Forms.Padding(3);
            this.DetailsTab.Size = new System.Drawing.Size(550, 378);
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
            this.MainPropertyGrid.Size = new System.Drawing.Size(544, 372);
            this.MainPropertyGrid.TabIndex = 0;
            this.MainPropertyGrid.ToolbarVisible = false;
            // 
            // TextureTab
            // 
            this.TextureTab.Controls.Add(this.PictureBox);
            this.TextureTab.Location = new System.Drawing.Point(4, 22);
            this.TextureTab.Name = "TextureTab";
            this.TextureTab.Padding = new System.Windows.Forms.Padding(3);
            this.TextureTab.Size = new System.Drawing.Size(550, 378);
            this.TextureTab.TabIndex = 2;
            this.TextureTab.Text = "Texture";
            this.TextureTab.UseVisualStyleBackColor = true;
            // 
            // PictureBox
            // 
            this.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox.Location = new System.Drawing.Point(3, 3);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(544, 372);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // extractCheckedToolStripMenuItem
            // 
            this.extractCheckedToolStripMenuItem.Name = "extractCheckedToolStripMenuItem";
            this.extractCheckedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.extractCheckedToolStripMenuItem.Text = "Extract Checked";
            this.extractCheckedToolStripMenuItem.Click += new System.EventHandler(this.extractCheckedToolStripMenuItem_Click_1);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.combinedToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // combinedToolStripMenuItem
            // 
            this.combinedToolStripMenuItem.Name = "combinedToolStripMenuItem";
            this.combinedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.combinedToolStripMenuItem.Text = "Extract Combined";
            this.combinedToolStripMenuItem.Click += new System.EventHandler(this.combinedToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
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
            this.TextureTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openHexToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
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
        private System.Windows.Forms.TabPage TextureTab;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.ToolStripMenuItem extractCheckedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combinedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
    }
}