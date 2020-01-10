namespace SC2.Win.UI
{
    partial class BuildListItemControl
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
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.lblBuildName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(3, 3);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(75, 75);
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // lblBuildName
            // 
            this.lblBuildName.Location = new System.Drawing.Point(84, 3);
            this.lblBuildName.Name = "lblBuildName";
            this.lblBuildName.Size = new System.Drawing.Size(263, 18);
            this.lblBuildName.TabIndex = 1;
            this.lblBuildName.Text = "Build Name";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(84, 21);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(197, 53);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Build Description";
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(287, 21);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(60, 53);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Version";
            // 
            // BuildListItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblBuildName);
            this.Controls.Add(this.pbImage);
            this.Name = "BuildListItemControl";
            this.Size = new System.Drawing.Size(350, 80);
            this.Click += new System.EventHandler(this.BuildListItemControlClick);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lblBuildName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblVersion;
    }
}
