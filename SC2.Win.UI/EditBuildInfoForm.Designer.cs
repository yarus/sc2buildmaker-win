namespace SC2.Win.UI
{
    partial class EditBuildInfoForm
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
            this.tbBuildName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbTerran = new System.Windows.Forms.RadioButton();
            this.rbZerg = new System.Windows.Forms.RadioButton();
            this.rbProtoss = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbVersionID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Build Name:";
            // 
            // tbBuildName
            // 
            this.tbBuildName.Location = new System.Drawing.Point(13, 75);
            this.tbBuildName.Name = "tbBuildName";
            this.tbBuildName.Size = new System.Drawing.Size(359, 20);
            this.tbBuildName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "VS Race:";
            // 
            // rbTerran
            // 
            this.rbTerran.AutoSize = true;
            this.rbTerran.Location = new System.Drawing.Point(27, 126);
            this.rbTerran.Name = "rbTerran";
            this.rbTerran.Size = new System.Drawing.Size(56, 17);
            this.rbTerran.TabIndex = 3;
            this.rbTerran.TabStop = true;
            this.rbTerran.Text = "Terran";
            this.rbTerran.UseVisualStyleBackColor = true;
            // 
            // rbZerg
            // 
            this.rbZerg.AutoSize = true;
            this.rbZerg.Location = new System.Drawing.Point(89, 126);
            this.rbZerg.Name = "rbZerg";
            this.rbZerg.Size = new System.Drawing.Size(47, 17);
            this.rbZerg.TabIndex = 3;
            this.rbZerg.TabStop = true;
            this.rbZerg.Text = "Zerg";
            this.rbZerg.UseVisualStyleBackColor = true;
            // 
            // rbProtoss
            // 
            this.rbProtoss.AutoSize = true;
            this.rbProtoss.Location = new System.Drawing.Point(151, 126);
            this.rbProtoss.Name = "rbProtoss";
            this.rbProtoss.Size = new System.Drawing.Size(60, 17);
            this.rbProtoss.TabIndex = 3;
            this.rbProtoss.TabStop = true;
            this.rbProtoss.Text = "Protoss";
            this.rbProtoss.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description:";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(13, 168);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(359, 378);
            this.tbDescription.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 552);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(297, 552);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "SC2 Version:";
            // 
            // tbVersionID
            // 
            this.tbVersionID.Location = new System.Drawing.Point(13, 28);
            this.tbVersionID.Name = "tbVersionID";
            this.tbVersionID.ReadOnly = true;
            this.tbVersionID.Size = new System.Drawing.Size(359, 20);
            this.tbVersionID.TabIndex = 9;
            // 
            // EditBuildInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 587);
            this.Controls.Add(this.tbVersionID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbProtoss);
            this.Controls.Add(this.rbZerg);
            this.Controls.Add(this.rbTerran);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbBuildName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditBuildInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditBuildInfoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBuildName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbTerran;
        private System.Windows.Forms.RadioButton rbZerg;
        private System.Windows.Forms.RadioButton rbProtoss;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbVersionID;
    }
}