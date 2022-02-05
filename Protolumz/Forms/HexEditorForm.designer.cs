namespace Protolumz
{
    partial class HexEditorForm
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
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.LengthStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.OffsetStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classParserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainToolStrip = new System.Windows.Forms.ToolStrip();
            this.NumberTypeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.BytePerLineComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.HexViewer = new Protolumz.HexViewer();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.DetailsTabPage = new System.Windows.Forms.TabPage();
            this.SelectionPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.ToolsTabPage = new System.Windows.Forms.TabPage();
            this.SearchToolPanel = new System.Windows.Forms.Panel();
            this.SearchResultsPanel = new System.Windows.Forms.Panel();
            this.SearchResultsLabel = new System.Windows.Forms.Label();
            this.SearchToolsPanel = new System.Windows.Forms.Panel();
            this.SearchModeComboBox = new System.Windows.Forms.ComboBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.MainStatusStrip.SuspendLayout();
            this.MainMenuStrip.SuspendLayout();
            this.MainToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.DetailsTabPage.SuspendLayout();
            this.ToolsTabPage.SuspendLayout();
            this.SearchToolPanel.SuspendLayout();
            this.SearchResultsPanel.SuspendLayout();
            this.SearchToolsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LengthStatusLabel,
            this.OffsetStatusLabel});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 428);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(764, 22);
            this.MainStatusStrip.TabIndex = 0;
            this.MainStatusStrip.Text = "MainStatusStrip";
            // 
            // LengthStatusLabel
            // 
            this.LengthStatusLabel.Name = "LengthStatusLabel";
            this.LengthStatusLabel.Size = new System.Drawing.Size(44, 17);
            this.LengthStatusLabel.Text = "Length";
            // 
            // OffsetStatusLabel
            // 
            this.OffsetStatusLabel.Name = "OffsetStatusLabel";
            this.OffsetStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.OffsetStatusLabel.Text = "Offset";
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(764, 24);
            this.MainMenuStrip.TabIndex = 3;
            this.MainMenuStrip.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classParserToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // classParserToolStripMenuItem
            // 
            this.classParserToolStripMenuItem.Name = "classParserToolStripMenuItem";
            this.classParserToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.classParserToolStripMenuItem.Text = "Class Parser";
            this.classParserToolStripMenuItem.Click += new System.EventHandler(this.classParserToolStripMenuItem_Click);
            // 
            // MainToolStrip
            // 
            this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NumberTypeComboBox,
            this.BytePerLineComboBox});
            this.MainToolStrip.Location = new System.Drawing.Point(0, 24);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.Size = new System.Drawing.Size(764, 25);
            this.MainToolStrip.TabIndex = 4;
            this.MainToolStrip.Text = "toolStrip1";
            // 
            // NumberTypeComboBox
            // 
            this.NumberTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NumberTypeComboBox.Items.AddRange(new object[] {
            "Decimal",
            "Hex",
            "Octal"});
            this.NumberTypeComboBox.Name = "NumberTypeComboBox";
            this.NumberTypeComboBox.Size = new System.Drawing.Size(75, 25);
            this.NumberTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.NumberTypeComboBox_SelectedIndexChanged);
            // 
            // BytePerLineComboBox
            // 
            this.BytePerLineComboBox.Items.AddRange(new object[] {
            "16",
            "32",
            "64"});
            this.BytePerLineComboBox.Name = "BytePerLineComboBox";
            this.BytePerLineComboBox.Size = new System.Drawing.Size(75, 25);
            this.BytePerLineComboBox.Text = "16";
            this.BytePerLineComboBox.SelectedIndexChanged += new System.EventHandler(this.BytePerLineComboBox_SelectedIndexChanged);
            this.BytePerLineComboBox.TextUpdate += new System.EventHandler(this.BytePerLineComboBox_TextUpdate);
            this.BytePerLineComboBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BytePerLineComboBox_MouseUp);
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 49);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.HexViewer);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.MainTabControl);
            this.MainSplitContainer.Size = new System.Drawing.Size(764, 379);
            this.MainSplitContainer.SplitterDistance = 531;
            this.MainSplitContainer.TabIndex = 5;
            // 
            // HexViewer
            // 
            this.HexViewer.BytesPerLine = 16;
            this.HexViewer.Location = new System.Drawing.Point(0, 0);
            this.HexViewer.Name = "HexViewer";
            this.HexViewer.NumberType = Protolumz.NumberType.Decimal;
            this.HexViewer.Size = new System.Drawing.Size(246, 158);
            this.HexViewer.TabIndex = 0;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.DetailsTabPage);
            this.MainTabControl.Controls.Add(this.ToolsTabPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(229, 379);
            this.MainTabControl.TabIndex = 1;
            // 
            // DetailsTabPage
            // 
            this.DetailsTabPage.Controls.Add(this.SelectionPropertyGrid);
            this.DetailsTabPage.Location = new System.Drawing.Point(4, 22);
            this.DetailsTabPage.Name = "DetailsTabPage";
            this.DetailsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DetailsTabPage.Size = new System.Drawing.Size(221, 353);
            this.DetailsTabPage.TabIndex = 0;
            this.DetailsTabPage.Text = "Details";
            this.DetailsTabPage.UseVisualStyleBackColor = true;
            // 
            // SelectionPropertyGrid
            // 
            this.SelectionPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectionPropertyGrid.HelpVisible = false;
            this.SelectionPropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.SelectionPropertyGrid.Name = "SelectionPropertyGrid";
            this.SelectionPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.SelectionPropertyGrid.Size = new System.Drawing.Size(215, 347);
            this.SelectionPropertyGrid.TabIndex = 0;
            this.SelectionPropertyGrid.ToolbarVisible = false;
            // 
            // ToolsTabPage
            // 
            this.ToolsTabPage.Controls.Add(this.SearchToolPanel);
            this.ToolsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ToolsTabPage.Name = "ToolsTabPage";
            this.ToolsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ToolsTabPage.Size = new System.Drawing.Size(221, 353);
            this.ToolsTabPage.TabIndex = 1;
            this.ToolsTabPage.Text = "Tools";
            this.ToolsTabPage.UseVisualStyleBackColor = true;
            // 
            // SearchToolPanel
            // 
            this.SearchToolPanel.Controls.Add(this.SearchResultsPanel);
            this.SearchToolPanel.Controls.Add(this.SearchToolsPanel);
            this.SearchToolPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchToolPanel.Location = new System.Drawing.Point(3, 3);
            this.SearchToolPanel.Name = "SearchToolPanel";
            this.SearchToolPanel.Size = new System.Drawing.Size(215, 95);
            this.SearchToolPanel.TabIndex = 4;
            // 
            // SearchResultsPanel
            // 
            this.SearchResultsPanel.Controls.Add(this.SearchResultsLabel);
            this.SearchResultsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchResultsPanel.Location = new System.Drawing.Point(0, 76);
            this.SearchResultsPanel.Name = "SearchResultsPanel";
            this.SearchResultsPanel.Size = new System.Drawing.Size(215, 19);
            this.SearchResultsPanel.TabIndex = 7;
            // 
            // SearchResultsLabel
            // 
            this.SearchResultsLabel.AutoSize = true;
            this.SearchResultsLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SearchResultsLabel.Location = new System.Drawing.Point(0, 0);
            this.SearchResultsLabel.Name = "SearchResultsLabel";
            this.SearchResultsLabel.Size = new System.Drawing.Size(84, 13);
            this.SearchResultsLabel.TabIndex = 4;
            this.SearchResultsLabel.Text = "Results: 0 found";
            // 
            // SearchToolsPanel
            // 
            this.SearchToolsPanel.Controls.Add(this.SearchModeComboBox);
            this.SearchToolsPanel.Controls.Add(this.SearchButton);
            this.SearchToolsPanel.Controls.Add(this.SearchLabel);
            this.SearchToolsPanel.Controls.Add(this.SearchTextBox);
            this.SearchToolsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchToolsPanel.Location = new System.Drawing.Point(0, 0);
            this.SearchToolsPanel.Name = "SearchToolsPanel";
            this.SearchToolsPanel.Size = new System.Drawing.Size(215, 76);
            this.SearchToolsPanel.TabIndex = 6;
            // 
            // SearchModeComboBox
            // 
            this.SearchModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchModeComboBox.FormattingEnabled = true;
            this.SearchModeComboBox.Items.AddRange(new object[] {
            "byte",
            "int16",
            "uint16",
            "int32",
            "uint32",
            "int64",
            "uint64",
            "float"});
            this.SearchModeComboBox.Location = new System.Drawing.Point(7, 20);
            this.SearchModeComboBox.Name = "SearchModeComboBox";
            this.SearchModeComboBox.Size = new System.Drawing.Size(203, 21);
            this.SearchModeComboBox.TabIndex = 1;
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.Location = new System.Drawing.Point(135, 47);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(4, 4);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(41, 13);
            this.SearchLabel.TabIndex = 0;
            this.SearchLabel.Text = "Search";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(7, 49);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(198, 20);
            this.SearchTextBox.TabIndex = 2;
            // 
            // HexEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 450);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.MainToolStrip);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.MainMenuStrip);
            this.Name = "HexEditorForm";
            this.Text = "Hex Editor - by Skylumz";
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.MainTabControl.ResumeLayout(false);
            this.DetailsTabPage.ResumeLayout(false);
            this.ToolsTabPage.ResumeLayout(false);
            this.SearchToolPanel.ResumeLayout(false);
            this.SearchResultsPanel.ResumeLayout(false);
            this.SearchResultsPanel.PerformLayout();
            this.SearchToolsPanel.ResumeLayout(false);
            this.SearchToolsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel LengthStatusLabel;
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip MainToolStrip;
        private System.Windows.Forms.ToolStripComboBox BytePerLineComboBox;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.PropertyGrid SelectionPropertyGrid;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel OffsetStatusLabel;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage DetailsTabPage;
        private System.Windows.Forms.TabPage ToolsTabPage;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.ToolStripComboBox NumberTypeComboBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.ComboBox SearchModeComboBox;
        private System.Windows.Forms.Panel SearchToolPanel;
        private System.Windows.Forms.Panel SearchResultsPanel;
        private System.Windows.Forms.Panel SearchToolsPanel;
        private System.Windows.Forms.Label SearchResultsLabel;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classParserToolStripMenuItem;
        private HexViewer HexViewer;
    }
}