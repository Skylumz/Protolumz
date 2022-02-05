namespace Protolumz
{
    partial class HexClassCreatorForm
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
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.MainTreeView = new System.Windows.Forms.TreeView();
            this.MainTreeViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.readAtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MemberTreeView = new System.Windows.Forms.TreeView();
            this.MembersLabel = new System.Windows.Forms.Label();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.MemberValueTextBox = new System.Windows.Forms.TextBox();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.AddMemberButton = new System.Windows.Forms.Button();
            this.ClassNameTextBox = new System.Windows.Forms.TextBox();
            this.MemberNameTextBox = new System.Windows.Forms.TextBox();
            this.ClassNameLabel = new System.Windows.Forms.Label();
            this.MemberTypeLabel = new System.Windows.Forms.Label();
            this.MemberTypeComboBox = new System.Windows.Forms.ComboBox();
            this.MemberNameLabel = new System.Windows.Forms.Label();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.MainMenuStrip.SuspendLayout();
            this.MainTreeViewContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveFileToolStripMenuItem.Text = "Save File";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newClassToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // newClassToolStripMenuItem
            // 
            this.newClassToolStripMenuItem.Name = "newClassToolStripMenuItem";
            this.newClassToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.newClassToolStripMenuItem.Text = "New Class";
            this.newClassToolStripMenuItem.Click += new System.EventHandler(this.newClassToolStripMenuItem_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 428);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(800, 22);
            this.MainStatusStrip.TabIndex = 1;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // MainTreeView
            // 
            this.MainTreeView.ContextMenuStrip = this.MainTreeViewContextMenu;
            this.MainTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTreeView.Location = new System.Drawing.Point(0, 0);
            this.MainTreeView.Name = "MainTreeView";
            this.MainTreeView.Size = new System.Drawing.Size(144, 404);
            this.MainTreeView.TabIndex = 4;
            this.MainTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MainTreeView_AfterSelect);
            // 
            // MainTreeViewContextMenu
            // 
            this.MainTreeViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readAtToolStripMenuItem});
            this.MainTreeViewContextMenu.Name = "MainTreeViewContextMenu";
            this.MainTreeViewContextMenu.Size = new System.Drawing.Size(116, 26);
            // 
            // readAtToolStripMenuItem
            // 
            this.readAtToolStripMenuItem.Name = "readAtToolStripMenuItem";
            this.readAtToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.readAtToolStripMenuItem.Text = "Read At";
            this.readAtToolStripMenuItem.Click += new System.EventHandler(this.readAtToolStripMenuItem_Click);
            // 
            // MemberTreeView
            // 
            this.MemberTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MemberTreeView.Location = new System.Drawing.Point(0, 52);
            this.MemberTreeView.Name = "MemberTreeView";
            this.MemberTreeView.Size = new System.Drawing.Size(175, 323);
            this.MemberTreeView.TabIndex = 5;
            this.MemberTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MemberTreeView_AfterSelect);
            // 
            // MembersLabel
            // 
            this.MembersLabel.AutoSize = true;
            this.MembersLabel.Location = new System.Drawing.Point(11, 36);
            this.MembersLabel.Name = "MembersLabel";
            this.MembersLabel.Size = new System.Drawing.Size(50, 13);
            this.MembersLabel.TabIndex = 6;
            this.MembersLabel.Text = "Members";
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.MainTreeView);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.propertyGrid1);
            this.MainSplitContainer.Panel2.Controls.Add(this.MemberValueTextBox);
            this.MainSplitContainer.Panel2.Controls.Add(this.ValueLabel);
            this.MainSplitContainer.Panel2.Controls.Add(this.AddMemberButton);
            this.MainSplitContainer.Panel2.Controls.Add(this.ClassNameTextBox);
            this.MainSplitContainer.Panel2.Controls.Add(this.MemberNameTextBox);
            this.MainSplitContainer.Panel2.Controls.Add(this.ClassNameLabel);
            this.MainSplitContainer.Panel2.Controls.Add(this.MemberTypeLabel);
            this.MainSplitContainer.Panel2.Controls.Add(this.MemberTypeComboBox);
            this.MainSplitContainer.Panel2.Controls.Add(this.MemberNameLabel);
            this.MainSplitContainer.Panel2.Controls.Add(this.MemberTreeView);
            this.MainSplitContainer.Panel2.Controls.Add(this.MembersLabel);
            this.MainSplitContainer.Size = new System.Drawing.Size(800, 404);
            this.MainSplitContainer.SplitterDistance = 144;
            this.MainSplitContainer.TabIndex = 7;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(194, 156);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(421, 205);
            this.propertyGrid1.TabIndex = 17;
            // 
            // MemberValueTextBox
            // 
            this.MemberValueTextBox.Location = new System.Drawing.Point(266, 112);
            this.MemberValueTextBox.Name = "MemberValueTextBox";
            this.MemberValueTextBox.Size = new System.Drawing.Size(374, 20);
            this.MemberValueTextBox.TabIndex = 16;
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(223, 115);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(37, 13);
            this.ValueLabel.TabIndex = 15;
            this.ValueLabel.Text = "Value:";
            // 
            // AddMemberButton
            // 
            this.AddMemberButton.Location = new System.Drawing.Point(100, 378);
            this.AddMemberButton.Name = "AddMemberButton";
            this.AddMemberButton.Size = new System.Drawing.Size(75, 23);
            this.AddMemberButton.TabIndex = 14;
            this.AddMemberButton.Text = "Add Member";
            this.AddMemberButton.UseVisualStyleBackColor = true;
            this.AddMemberButton.Click += new System.EventHandler(this.AddMemberButton_Click);
            // 
            // ClassNameTextBox
            // 
            this.ClassNameTextBox.Location = new System.Drawing.Point(84, 5);
            this.ClassNameTextBox.Name = "ClassNameTextBox";
            this.ClassNameTextBox.Size = new System.Drawing.Size(556, 20);
            this.ClassNameTextBox.TabIndex = 13;
            this.ClassNameTextBox.TextChanged += new System.EventHandler(this.ClassNameTextBox_TextChanged);
            // 
            // MemberNameTextBox
            // 
            this.MemberNameTextBox.Location = new System.Drawing.Point(266, 52);
            this.MemberNameTextBox.Name = "MemberNameTextBox";
            this.MemberNameTextBox.Size = new System.Drawing.Size(374, 20);
            this.MemberNameTextBox.TabIndex = 12;
            this.MemberNameTextBox.TextChanged += new System.EventHandler(this.MemberNameTextBox_TextChanged);
            // 
            // ClassNameLabel
            // 
            this.ClassNameLabel.AutoSize = true;
            this.ClassNameLabel.Location = new System.Drawing.Point(12, 8);
            this.ClassNameLabel.Name = "ClassNameLabel";
            this.ClassNameLabel.Size = new System.Drawing.Size(66, 13);
            this.ClassNameLabel.TabIndex = 11;
            this.ClassNameLabel.Text = "Class Name:";
            // 
            // MemberTypeLabel
            // 
            this.MemberTypeLabel.AutoSize = true;
            this.MemberTypeLabel.Location = new System.Drawing.Point(226, 88);
            this.MemberTypeLabel.Name = "MemberTypeLabel";
            this.MemberTypeLabel.Size = new System.Drawing.Size(34, 13);
            this.MemberTypeLabel.TabIndex = 10;
            this.MemberTypeLabel.Text = "Type:";
            // 
            // MemberTypeComboBox
            // 
            this.MemberTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MemberTypeComboBox.FormattingEnabled = true;
            this.MemberTypeComboBox.Items.AddRange(new object[] {
            "BYTE",
            "BYTEARRAY",
            "STRING",
            "INT16",
            "UINT16",
            "INT32",
            "UINT32",
            "INT64",
            "UINT64"});
            this.MemberTypeComboBox.Location = new System.Drawing.Point(266, 85);
            this.MemberTypeComboBox.Name = "MemberTypeComboBox";
            this.MemberTypeComboBox.Size = new System.Drawing.Size(374, 21);
            this.MemberTypeComboBox.TabIndex = 9;
            this.MemberTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.MemberTypeComboBox_SelectedIndexChanged);
            // 
            // MemberNameLabel
            // 
            this.MemberNameLabel.AutoSize = true;
            this.MemberNameLabel.Location = new System.Drawing.Point(181, 55);
            this.MemberNameLabel.Name = "MemberNameLabel";
            this.MemberNameLabel.Size = new System.Drawing.Size(79, 13);
            this.MemberNameLabel.TabIndex = 8;
            this.MemberNameLabel.Text = "Member Name:";
            // 
            // OFD
            // 
            this.OFD.FileName = ".xml";
            this.OFD.Filter = "Hex files|*.hex.xml";
            // 
            // HexClassCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.MainMenuStrip);
            this.Name = "HexClassCreatorForm";
            this.Text = "Class Creator - by Skylumz";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.MainTreeViewContextMenu.ResumeLayout(false);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            this.MainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.TreeView MainTreeView;
        private System.Windows.Forms.TreeView MemberTreeView;
        private System.Windows.Forms.Label MembersLabel;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.ToolStripMenuItem newClassToolStripMenuItem;
        private System.Windows.Forms.ComboBox MemberTypeComboBox;
        private System.Windows.Forms.Label MemberNameLabel;
        private System.Windows.Forms.Label MemberTypeLabel;
        private System.Windows.Forms.Button AddMemberButton;
        private System.Windows.Forms.TextBox ClassNameTextBox;
        private System.Windows.Forms.TextBox MemberNameTextBox;
        private System.Windows.Forms.Label ClassNameLabel;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.TextBox MemberValueTextBox;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.ContextMenuStrip MainTreeViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem readAtToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}