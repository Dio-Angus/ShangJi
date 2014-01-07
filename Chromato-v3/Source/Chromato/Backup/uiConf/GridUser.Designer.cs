namespace ChromatoCore.uiConf
{
    partial class GridUser
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
            this.txtValue_Grid = new System.Windows.Forms.TextBox();
            this.cmbItemID_Grid = new System.Windows.Forms.ComboBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblProperty = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lsbGrid = new System.Windows.Forms.ListBox();
            this.btnChangeGrid = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtValue_Grid
            // 
            this.txtValue_Grid.Location = new System.Drawing.Point(178, 56);
            this.txtValue_Grid.Name = "txtValue_Grid";
            this.txtValue_Grid.Size = new System.Drawing.Size(81, 21);
            this.txtValue_Grid.TabIndex = 58;
            // 
            // cmbItemID_Grid
            // 
            this.cmbItemID_Grid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemID_Grid.FormattingEnabled = true;
            this.cmbItemID_Grid.Location = new System.Drawing.Point(72, 13);
            this.cmbItemID_Grid.Name = "cmbItemID_Grid";
            this.cmbItemID_Grid.Size = new System.Drawing.Size(102, 20);
            this.cmbItemID_Grid.TabIndex = 55;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(176, 41);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(35, 12);
            this.lblValue.TabIndex = 54;
            this.lblValue.Text = "Value";
            // 
            // lblProperty
            // 
            this.lblProperty.AutoSize = true;
            this.lblProperty.Location = new System.Drawing.Point(12, 39);
            this.lblProperty.Name = "lblProperty";
            this.lblProperty.Size = new System.Drawing.Size(53, 12);
            this.lblProperty.TabIndex = 53;
            this.lblProperty.Text = "Property";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 16);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(41, 12);
            this.lblID.TabIndex = 52;
            this.lblID.Text = "ItemID";
            // 
            // lsbGrid
            // 
            this.lsbGrid.FormattingEnabled = true;
            this.lsbGrid.ItemHeight = 12;
            this.lsbGrid.Location = new System.Drawing.Point(12, 56);
            this.lsbGrid.Name = "lsbGrid";
            this.lsbGrid.Size = new System.Drawing.Size(162, 196);
            this.lsbGrid.TabIndex = 59;
            this.lsbGrid.SelectedIndexChanged += new System.EventHandler(this.lsbGrid_SelectedIndexChanged);
            // 
            // btnChangeGrid
            // 
            this.btnChangeGrid.Location = new System.Drawing.Point(178, 81);
            this.btnChangeGrid.Name = "btnChangeGrid";
            this.btnChangeGrid.Size = new System.Drawing.Size(81, 47);
            this.btnChangeGrid.TabIndex = 57;
            this.btnChangeGrid.Text = "Change";
            this.btnChangeGrid.UseVisualStyleBackColor = true;
            this.btnChangeGrid.Click += new System.EventHandler(this.btnChangeGrid_Click);
            // 
            // PanelGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lsbGrid);
            this.Controls.Add(this.txtValue_Grid);
            this.Controls.Add(this.btnChangeGrid);
            this.Controls.Add(this.cmbItemID_Grid);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblProperty);
            this.Controls.Add(this.lblID);
            this.Name = "GridUser";
            this.Size = new System.Drawing.Size(282, 262);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValue_Grid;
        private System.Windows.Forms.ComboBox cmbItemID_Grid;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ListBox lsbGrid;
        private System.Windows.Forms.Button btnChangeGrid;
    }
}
