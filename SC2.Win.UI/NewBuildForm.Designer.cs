namespace SC2.Win.UI
{
    partial class NewBuildForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbVersions = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTerran = new System.Windows.Forms.Button();
            this.btnZerg = new System.Windows.Forms.Button();
            this.btnProtoss = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose SC2 Version:";
            // 
            // cbVersions
            // 
            this.cbVersions.FormattingEnabled = true;
            this.cbVersions.Location = new System.Drawing.Point(16, 30);
            this.cbVersions.Name = "cbVersions";
            this.cbVersions.Size = new System.Drawing.Size(356, 21);
            this.cbVersions.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Choose Race:";
            // 
            // btnTerran
            // 
            this.btnTerran.Location = new System.Drawing.Point(5, 100);
            this.btnTerran.Name = "btnTerran";
            this.btnTerran.Size = new System.Drawing.Size(110, 350);
            this.btnTerran.TabIndex = 3;
            this.btnTerran.Text = "TERRAN";
            this.btnTerran.UseVisualStyleBackColor = true;
            this.btnTerran.Click += new System.EventHandler(this.btnTerran_Click);
            // 
            // btnZerg
            // 
            this.btnZerg.Location = new System.Drawing.Point(137, 100);
            this.btnZerg.Name = "btnZerg";
            this.btnZerg.Size = new System.Drawing.Size(110, 350);
            this.btnZerg.TabIndex = 3;
            this.btnZerg.Text = "ZERG";
            this.btnZerg.UseVisualStyleBackColor = true;
            this.btnZerg.Click += new System.EventHandler(this.btnZerg_Click);
            // 
            // btnProtoss
            // 
            this.btnProtoss.Location = new System.Drawing.Point(267, 100);
            this.btnProtoss.Name = "btnProtoss";
            this.btnProtoss.Size = new System.Drawing.Size(110, 350);
            this.btnProtoss.TabIndex = 3;
            this.btnProtoss.Text = "PROTOSS";
            this.btnProtoss.UseVisualStyleBackColor = true;
            this.btnProtoss.Click += new System.EventHandler(this.btnProtoss_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(158, 527);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(43, 48);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // NewBuildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 587);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnProtoss);
            this.Controls.Add(this.btnZerg);
            this.Controls.Add(this.btnTerran);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbVersions);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewBuildForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewBuildForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbVersions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTerran;
        private System.Windows.Forms.Button btnZerg;
        private System.Windows.Forms.Button btnProtoss;
        private System.Windows.Forms.Button btnBack;
    }
}