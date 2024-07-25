namespace Protolumz.Forms.Views
{
    partial class PropsView
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
            this.MainTreeView = new System.Windows.Forms.TreeView();
            this.MainPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // MainTreeView
            // 
            this.MainTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainTreeView.Location = new System.Drawing.Point(0, 0);
            this.MainTreeView.Name = "MainTreeView";
            this.MainTreeView.Size = new System.Drawing.Size(237, 371);
            this.MainTreeView.TabIndex = 1;
            this.MainTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MainTreeView_AfterSelect);
            // 
            // MainPropertyGrid
            // 
            this.MainPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPropertyGrid.Location = new System.Drawing.Point(243, 0);
            this.MainPropertyGrid.Name = "MainPropertyGrid";
            this.MainPropertyGrid.Size = new System.Drawing.Size(433, 334);
            this.MainPropertyGrid.TabIndex = 10;
            // 
            // PropsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainPropertyGrid);
            this.Controls.Add(this.MainTreeView);
            this.MinimumSize = new System.Drawing.Size(641, 334);
            this.Name = "PropsView";
            this.Size = new System.Drawing.Size(676, 371);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView MainTreeView;
        private System.Windows.Forms.PropertyGrid MainPropertyGrid;
    }
}
