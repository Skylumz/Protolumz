namespace Protolumz
{
    partial class AssetExplorerForm
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
            this.ExtractButton = new System.Windows.Forms.Button();
            this.RpfNameLabel = new System.Windows.Forms.Label();
            this.AssetTypelabel = new System.Windows.Forms.Label();
            this.AssetTypeComboBox = new System.Windows.Forms.ComboBox();
            this.AbortButton = new System.Windows.Forms.Button();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.RcfComboBox = new System.Windows.Forms.ComboBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.ClearLogButton = new System.Windows.Forms.Button();
            this.ContainsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ExtractButton
            // 
            this.ExtractButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExtractButton.Location = new System.Drawing.Point(541, 405);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(75, 23);
            this.ExtractButton.TabIndex = 1;
            this.ExtractButton.Text = "Extract";
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // RpfNameLabel
            // 
            this.RpfNameLabel.AutoSize = true;
            this.RpfNameLabel.Location = new System.Drawing.Point(12, 15);
            this.RpfNameLabel.Name = "RpfNameLabel";
            this.RpfNameLabel.Size = new System.Drawing.Size(27, 13);
            this.RpfNameLabel.TabIndex = 2;
            this.RpfNameLabel.Text = "Rcf:";
            // 
            // AssetTypelabel
            // 
            this.AssetTypelabel.AutoSize = true;
            this.AssetTypelabel.Location = new System.Drawing.Point(337, 15);
            this.AssetTypelabel.Name = "AssetTypelabel";
            this.AssetTypelabel.Size = new System.Drawing.Size(36, 13);
            this.AssetTypelabel.TabIndex = 5;
            this.AssetTypelabel.Text = "Asset:";
            // 
            // AssetTypeComboBox
            // 
            this.AssetTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AssetTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AssetTypeComboBox.FormattingEnabled = true;
            this.AssetTypeComboBox.Location = new System.Drawing.Point(379, 12);
            this.AssetTypeComboBox.Name = "AssetTypeComboBox";
            this.AssetTypeComboBox.Size = new System.Drawing.Size(237, 21);
            this.AssetTypeComboBox.TabIndex = 6;
            // 
            // AbortButton
            // 
            this.AbortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AbortButton.Location = new System.Drawing.Point(379, 405);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(75, 23);
            this.AbortButton.TabIndex = 7;
            this.AbortButton.Text = "Abort";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // LogBox
            // 
            this.LogBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogBox.Location = new System.Drawing.Point(15, 88);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogBox.Size = new System.Drawing.Size(601, 311);
            this.LogBox.TabIndex = 8;
            // 
            // RcfComboBox
            // 
            this.RcfComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RcfComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RcfComboBox.FormattingEnabled = true;
            this.RcfComboBox.Location = new System.Drawing.Point(62, 12);
            this.RcfComboBox.Name = "RcfComboBox";
            this.RcfComboBox.Size = new System.Drawing.Size(260, 21);
            this.RcfComboBox.TabIndex = 9;
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.Location = new System.Drawing.Point(460, 405);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 10;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchTypeComboBox
            // 
            this.SearchTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchTypeComboBox.FormattingEnabled = true;
            this.SearchTypeComboBox.Items.AddRange(new object[] {
            "Asset",
            "P3D",
            "Filename"});
            this.SearchTypeComboBox.Location = new System.Drawing.Point(405, 50);
            this.SearchTypeComboBox.Name = "SearchTypeComboBox";
            this.SearchTypeComboBox.Size = new System.Drawing.Size(211, 21);
            this.SearchTypeComboBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Search Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Search:";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTextBox.Location = new System.Drawing.Point(62, 50);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(187, 20);
            this.SearchTextBox.TabIndex = 14;
            // 
            // ClearLogButton
            // 
            this.ClearLogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearLogButton.Location = new System.Drawing.Point(298, 405);
            this.ClearLogButton.Name = "ClearLogButton";
            this.ClearLogButton.Size = new System.Drawing.Size(75, 23);
            this.ClearLogButton.TabIndex = 15;
            this.ClearLogButton.Text = "Clear Log";
            this.ClearLogButton.UseVisualStyleBackColor = true;
            this.ClearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
            // 
            // ContainsCheckBox
            // 
            this.ContainsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ContainsCheckBox.AutoSize = true;
            this.ContainsCheckBox.Checked = true;
            this.ContainsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ContainsCheckBox.Location = new System.Drawing.Point(255, 52);
            this.ContainsCheckBox.Name = "ContainsCheckBox";
            this.ContainsCheckBox.Size = new System.Drawing.Size(67, 17);
            this.ContainsCheckBox.TabIndex = 16;
            this.ContainsCheckBox.Text = "Contains";
            this.ContainsCheckBox.UseVisualStyleBackColor = true;
            // 
            // AssetExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 440);
            this.Controls.Add(this.ContainsCheckBox);
            this.Controls.Add(this.ClearLogButton);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SearchTypeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.RcfComboBox);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.AssetTypeComboBox);
            this.Controls.Add(this.AssetTypelabel);
            this.Controls.Add(this.RpfNameLabel);
            this.Controls.Add(this.ExtractButton);
            this.MinimumSize = new System.Drawing.Size(352, 256);
            this.Name = "AssetExplorerForm";
            this.Text = "Asset Explorer - by Skylumz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ExtractButton;
        private System.Windows.Forms.Label RpfNameLabel;
        private System.Windows.Forms.Label AssetTypelabel;
        private System.Windows.Forms.ComboBox AssetTypeComboBox;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.ComboBox RcfComboBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ComboBox SearchTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button ClearLogButton;
        private System.Windows.Forms.CheckBox ContainsCheckBox;
    }
}