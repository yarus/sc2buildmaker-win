namespace SC2.Win.UI
{
    partial class BuildMaker
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.gvResult = new System.Windows.Forms.DataGridView();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuildTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Minerals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbResources = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddUnit = new System.Windows.Forms.Button();
            this.btnAddBuilding = new System.Windows.Forms.Button();
            this.btnAddUpgrade = new System.Windows.Forms.Button();
            this.btnAddSpecial = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblBuildName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(93, 48);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.Red;
            this.btnUndo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUndo.Location = new System.Drawing.Point(305, 532);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(78, 50);
            this.btnUndo.TabIndex = 8;
            this.btnUndo.Text = "UNDO";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.BtnUndoClick);
            // 
            // gvResult
            // 
            this.gvResult.AllowUserToAddRows = false;
            this.gvResult.AllowUserToDeleteRows = false;
            this.gvResult.AllowUserToResizeColumns = false;
            this.gvResult.AllowUserToResizeRows = false;
            this.gvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.BuildTime,
            this.Minerals,
            this.Gas,
            this.Supply});
            this.gvResult.Location = new System.Drawing.Point(1, 130);
            this.gvResult.Name = "gvResult";
            this.gvResult.ReadOnly = true;
            this.gvResult.RowHeadersVisible = false;
            this.gvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvResult.ShowCellErrors = false;
            this.gvResult.ShowEditingIcon = false;
            this.gvResult.ShowRowErrors = false;
            this.gvResult.Size = new System.Drawing.Size(382, 396);
            this.gvResult.TabIndex = 10;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "Item";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 130;
            // 
            // BuildTime
            // 
            this.BuildTime.DataPropertyName = "BuildTime";
            this.BuildTime.HeaderText = "BuildTime";
            this.BuildTime.Name = "BuildTime";
            this.BuildTime.ReadOnly = true;
            this.BuildTime.Width = 70;
            // 
            // Minerals
            // 
            this.Minerals.DataPropertyName = "Minerals";
            this.Minerals.HeaderText = "Minerals";
            this.Minerals.Name = "Minerals";
            this.Minerals.ReadOnly = true;
            this.Minerals.Width = 50;
            // 
            // Gas
            // 
            this.Gas.DataPropertyName = "Gas";
            this.Gas.HeaderText = "Gas";
            this.Gas.Name = "Gas";
            this.Gas.ReadOnly = true;
            this.Gas.Width = 50;
            // 
            // Supply
            // 
            this.Supply.DataPropertyName = "Supply";
            this.Supply.HeaderText = "Supply";
            this.Supply.Name = "Supply";
            this.Supply.ReadOnly = true;
            this.Supply.Width = 50;
            // 
            // tbResources
            // 
            this.tbResources.Location = new System.Drawing.Point(1, 77);
            this.tbResources.Multiline = true;
            this.tbResources.Name = "tbResources";
            this.tbResources.ReadOnly = true;
            this.tbResources.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResources.Size = new System.Drawing.Size(382, 47);
            this.tbResources.TabIndex = 3;
            this.tbResources.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 48);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // btnAddUnit
            // 
            this.btnAddUnit.Location = new System.Drawing.Point(1, 531);
            this.btnAddUnit.Name = "btnAddUnit";
            this.btnAddUnit.Size = new System.Drawing.Size(70, 50);
            this.btnAddUnit.TabIndex = 12;
            this.btnAddUnit.Text = "UNIT";
            this.btnAddUnit.UseVisualStyleBackColor = true;
            this.btnAddUnit.Click += new System.EventHandler(this.BtnAddUnitClick);
            // 
            // btnAddBuilding
            // 
            this.btnAddBuilding.Location = new System.Drawing.Point(77, 531);
            this.btnAddBuilding.Name = "btnAddBuilding";
            this.btnAddBuilding.Size = new System.Drawing.Size(70, 50);
            this.btnAddBuilding.TabIndex = 12;
            this.btnAddBuilding.Text = "BUILDING";
            this.btnAddBuilding.UseVisualStyleBackColor = true;
            this.btnAddBuilding.Click += new System.EventHandler(this.BtnAddBuildingClick);
            // 
            // btnAddUpgrade
            // 
            this.btnAddUpgrade.Location = new System.Drawing.Point(153, 532);
            this.btnAddUpgrade.Name = "btnAddUpgrade";
            this.btnAddUpgrade.Size = new System.Drawing.Size(70, 50);
            this.btnAddUpgrade.TabIndex = 12;
            this.btnAddUpgrade.Text = "UPGRADE";
            this.btnAddUpgrade.UseVisualStyleBackColor = true;
            this.btnAddUpgrade.Click += new System.EventHandler(this.BtnAddUpgradeClick);
            // 
            // btnAddSpecial
            // 
            this.btnAddSpecial.Location = new System.Drawing.Point(229, 531);
            this.btnAddSpecial.Name = "btnAddSpecial";
            this.btnAddSpecial.Size = new System.Drawing.Size(70, 50);
            this.btnAddSpecial.TabIndex = 12;
            this.btnAddSpecial.Text = "SPECIAL";
            this.btnAddSpecial.UseVisualStyleBackColor = true;
            this.btnAddSpecial.Click += new System.EventHandler(this.BtnAddSpecialClick);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(297, 48);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBackClick);
            // 
            // lblBuildName
            // 
            this.lblBuildName.AutoSize = true;
            this.lblBuildName.Location = new System.Drawing.Point(13, 13);
            this.lblBuildName.Name = "lblBuildName";
            this.lblBuildName.Size = new System.Drawing.Size(68, 13);
            this.lblBuildName.TabIndex = 14;
            this.lblBuildName.Text = "NEW BUILD";
            // 
            // BuildMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 587);
            this.Controls.Add(this.lblBuildName);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAddSpecial);
            this.Controls.Add(this.btnAddUpgrade);
            this.Controls.Add(this.btnAddBuilding);
            this.Controls.Add(this.btnAddUnit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gvResult);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tbResources);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BuildMaker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Build Maker";
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.DataGridView gvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuildTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Minerals;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supply;
        private System.Windows.Forms.TextBox tbResources;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddUnit;
        private System.Windows.Forms.Button btnAddBuilding;
        private System.Windows.Forms.Button btnAddUpgrade;
        private System.Windows.Forms.Button btnAddSpecial;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblBuildName;
    }
}

