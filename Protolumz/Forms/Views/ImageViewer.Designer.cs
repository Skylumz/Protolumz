namespace Protolumz
{
    partial class ImageViewer
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
            this.MipLevelTrackBar = new System.Windows.Forms.TrackBar();
            this.MipValueLabel = new System.Windows.Forms.Label();
            this.MipLevelLabel = new System.Windows.Forms.Label();
            this.PictureBoxPanel = new System.Windows.Forms.Panel();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MipLevelTrackBar)).BeginInit();
            this.PictureBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MipLevelTrackBar
            // 
            this.MipLevelTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MipLevelTrackBar.AutoSize = false;
            this.MipLevelTrackBar.BackColor = System.Drawing.SystemColors.Control;
            this.MipLevelTrackBar.Location = new System.Drawing.Point(87, 341);
            this.MipLevelTrackBar.Name = "MipLevelTrackBar";
            this.MipLevelTrackBar.Size = new System.Drawing.Size(182, 31);
            this.MipLevelTrackBar.TabIndex = 8;
            this.MipLevelTrackBar.Scroll += new System.EventHandler(this.MipLevelTrackBar_Scroll);
            // 
            // MipValueLabel
            // 
            this.MipValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MipValueLabel.AutoSize = true;
            this.MipValueLabel.Location = new System.Drawing.Point(68, 350);
            this.MipValueLabel.Name = "MipValueLabel";
            this.MipValueLabel.Size = new System.Drawing.Size(13, 13);
            this.MipValueLabel.TabIndex = 7;
            this.MipValueLabel.Text = "0";
            // 
            // MipLevelLabel
            // 
            this.MipLevelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MipLevelLabel.AutoSize = true;
            this.MipLevelLabel.Location = new System.Drawing.Point(6, 350);
            this.MipLevelLabel.Name = "MipLevelLabel";
            this.MipLevelLabel.Size = new System.Drawing.Size(56, 13);
            this.MipLevelLabel.TabIndex = 6;
            this.MipLevelLabel.Text = "Mip Level:";
            // 
            // PictureBoxPanel
            // 
            this.PictureBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBoxPanel.AutoScroll = true;
            this.PictureBoxPanel.Controls.Add(this.PictureBox);
            this.PictureBoxPanel.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxPanel.Name = "PictureBoxPanel";
            this.PictureBoxPanel.Size = new System.Drawing.Size(544, 332);
            this.PictureBoxPanel.TabIndex = 5;
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(0, 0);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(266, 193);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(472, 345);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.MipLevelTrackBar);
            this.Controls.Add(this.MipValueLabel);
            this.Controls.Add(this.MipLevelLabel);
            this.Controls.Add(this.PictureBoxPanel);
            this.Name = "ImageViewer";
            this.Size = new System.Drawing.Size(550, 376);
            ((System.ComponentModel.ISupportInitialize)(this.MipLevelTrackBar)).EndInit();
            this.PictureBoxPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar MipLevelTrackBar;
        private System.Windows.Forms.Label MipValueLabel;
        private System.Windows.Forms.Label MipLevelLabel;
        private System.Windows.Forms.Panel PictureBoxPanel;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Button SaveButton;
    }
}
