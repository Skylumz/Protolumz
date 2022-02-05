namespace Protolumz
{
    partial class HexViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBoxesPanel = new System.Windows.Forms.Panel();
            this.DecodedTextBox = new SyncTextBox();
            this.HexTextBox = new SyncTextBox();
            this.OffsetTextBox = new SyncTextBox();
            this.LabelsPanel = new System.Windows.Forms.Panel();
            this.DecodedTextLabel = new SyncTextBox();
            this.OffsetsLabel = new SyncTextBox();
            this.OffsetLabel = new SyncTextBox();
            this.TextBoxesPanel.SuspendLayout();
            this.LabelsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxesPanel
            // 
            this.TextBoxesPanel.Controls.Add(this.DecodedTextBox);
            this.TextBoxesPanel.Controls.Add(this.HexTextBox);
            this.TextBoxesPanel.Controls.Add(this.OffsetTextBox);
            this.TextBoxesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxesPanel.Location = new System.Drawing.Point(0, 18);
            this.TextBoxesPanel.Name = "TextBoxesPanel";
            this.TextBoxesPanel.Size = new System.Drawing.Size(572, 506);
            this.TextBoxesPanel.TabIndex = 5;
            // 
            // DecodedTextBox
            // 
            this.DecodedTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DecodedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DecodedTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.DecodedTextBox.HideSelection = false;
            this.DecodedTextBox.LinkedTextBoxes = null;
            this.DecodedTextBox.Location = new System.Drawing.Point(200, 0);
            this.DecodedTextBox.Multiline = true;
            this.DecodedTextBox.Name = "DecodedTextBox";
            this.DecodedTextBox.ReadOnly = true;
            this.DecodedTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DecodedTextBox.Size = new System.Drawing.Size(100, 506);
            this.DecodedTextBox.TabIndex = 2;
            this.DecodedTextBox.Text = "................";
            // 
            // HexTextBox
            // 
            this.HexTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.HexTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HexTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.HexTextBox.HideSelection = false;
            this.HexTextBox.LinkedTextBoxes = null;
            this.HexTextBox.Location = new System.Drawing.Point(100, 0);
            this.HexTextBox.Multiline = true;
            this.HexTextBox.Name = "HexTextBox";
            this.HexTextBox.ReadOnly = true;
            this.HexTextBox.Size = new System.Drawing.Size(100, 506);
            this.HexTextBox.TabIndex = 1;
            // 
            // OffsetTextBox
            // 
            this.OffsetTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.OffsetTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OffsetTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.OffsetTextBox.Enabled = false;
            this.OffsetTextBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.OffsetTextBox.LinkedTextBoxes = new System.Windows.Forms.Control[0];
            this.OffsetTextBox.Location = new System.Drawing.Point(0, 0);
            this.OffsetTextBox.Multiline = true;
            this.OffsetTextBox.Name = "OffsetTextBox";
            this.OffsetTextBox.Size = new System.Drawing.Size(100, 506);
            this.OffsetTextBox.TabIndex = 0;
            this.OffsetTextBox.Text = "00000000";
            // 
            // LabelsPanel
            // 
            this.LabelsPanel.Controls.Add(this.DecodedTextLabel);
            this.LabelsPanel.Controls.Add(this.OffsetsLabel);
            this.LabelsPanel.Controls.Add(this.OffsetLabel);
            this.LabelsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelsPanel.Location = new System.Drawing.Point(0, 0);
            this.LabelsPanel.Name = "LabelsPanel";
            this.LabelsPanel.Size = new System.Drawing.Size(572, 18);
            this.LabelsPanel.TabIndex = 4;
            // 
            // DecodedTextLabel
            // 
            this.DecodedTextLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DecodedTextLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DecodedTextLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.DecodedTextLabel.Enabled = false;
            this.DecodedTextLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.DecodedTextLabel.LinkedTextBoxes = null;
            this.DecodedTextLabel.Location = new System.Drawing.Point(200, 0);
            this.DecodedTextLabel.Multiline = true;
            this.DecodedTextLabel.Name = "DecodedTextLabel";
            this.DecodedTextLabel.Size = new System.Drawing.Size(100, 18);
            this.DecodedTextLabel.TabIndex = 2;
            this.DecodedTextLabel.Text = "Decoded Text";
            // 
            // OffsetsLabel
            // 
            this.OffsetsLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.OffsetsLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OffsetsLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.OffsetsLabel.Enabled = false;
            this.OffsetsLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.OffsetsLabel.LinkedTextBoxes = null;
            this.OffsetsLabel.Location = new System.Drawing.Point(100, 0);
            this.OffsetsLabel.Multiline = true;
            this.OffsetsLabel.Name = "OffsetsLabel";
            this.OffsetsLabel.Size = new System.Drawing.Size(100, 18);
            this.OffsetsLabel.TabIndex = 1;
            // 
            // OffsetLabel
            // 
            this.OffsetLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.OffsetLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OffsetLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.OffsetLabel.Enabled = false;
            this.OffsetLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.OffsetLabel.LinkedTextBoxes = null;
            this.OffsetLabel.Location = new System.Drawing.Point(0, 0);
            this.OffsetLabel.Multiline = true;
            this.OffsetLabel.Name = "OffsetLabel";
            this.OffsetLabel.Size = new System.Drawing.Size(100, 18);
            this.OffsetLabel.TabIndex = 0;
            this.OffsetLabel.Text = "Offset";
            // 
            // HexViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxesPanel);
            this.Controls.Add(this.LabelsPanel);
            this.Name = "HexViewer";
            this.Size = new System.Drawing.Size(572, 524);
            this.TextBoxesPanel.ResumeLayout(false);
            this.TextBoxesPanel.PerformLayout();
            this.LabelsPanel.ResumeLayout(false);
            this.LabelsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TextBoxesPanel;
        private SyncTextBox DecodedTextBox;
        private SyncTextBox HexTextBox;
        private SyncTextBox OffsetTextBox;
        private System.Windows.Forms.Panel LabelsPanel;
        private SyncTextBox DecodedTextLabel;
        private SyncTextBox OffsetsLabel;
        private SyncTextBox OffsetLabel;
    }
}
