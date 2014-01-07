namespace ChromatoCore.uiConf
{
    partial class AreaUser
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
            this.txtValue_Area = new System.Windows.Forms.TextBox();
            this.btnChangeArea = new System.Windows.Forms.Button();
            this.cmbItemID_Area = new System.Windows.Forms.ComboBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblProperty = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lsbArea = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtValue_Area
            // 
            this.txtValue_Area.Location = new System.Drawing.Point(178, 56);
            this.txtValue_Area.Name = "txtValue_Area";
            this.txtValue_Area.Size = new System.Drawing.Size(81, 21);
            this.txtValue_Area.TabIndex = 57;
            // 
            // btnChangeArea
            // 
            this.btnChangeArea.Location = new System.Drawing.Point(178, 81);
            this.btnChangeArea.Name = "btnChangeArea";
            this.btnChangeArea.Size = new System.Drawing.Size(81, 47);
            this.btnChangeArea.TabIndex = 56;
            this.btnChangeArea.Text = "Change";
            this.btnChangeArea.UseVisualStyleBackColor = true;
            this.btnChangeArea.Click += new System.EventHandler(this.btnChangeArea_Click);
            // 
            // cmbItemID_Area
            // 
            this.cmbItemID_Area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemID_Area.FormattingEnabled = true;
            this.cmbItemID_Area.Location = new System.Drawing.Point(72, 13);
            this.cmbItemID_Area.Name = "cmbItemID_Area";
            this.cmbItemID_Area.Size = new System.Drawing.Size(104, 20);
            this.cmbItemID_Area.TabIndex = 54;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(176, 41);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(35, 12);
            this.lblValue.TabIndex = 53;
            this.lblValue.Text = "Value";
            // 
            // lblProperty
            // 
            this.lblProperty.AutoSize = true;
            this.lblProperty.Location = new System.Drawing.Point(12, 39);
            this.lblProperty.Name = "lblProperty";
            this.lblProperty.Size = new System.Drawing.Size(53, 12);
            this.lblProperty.TabIndex = 52;
            this.lblProperty.Text = "Property";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 16);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(41, 12);
            this.lblID.TabIndex = 51;
            this.lblID.Text = "ItemID";
            // 
            // lsbArea
            // 
            this.lsbArea.FormattingEnabled = true;
            this.lsbArea.ItemHeight = 12;
            this.lsbArea.Location = new System.Drawing.Point(12, 56);
            this.lsbArea.Name = "lsbArea";
            this.lsbArea.Size = new System.Drawing.Size(162, 196);
            this.lsbArea.TabIndex = 58;
            this.lsbArea.SelectedIndexChanged += new System.EventHandler(this.lsbArea_SelectedIndexChanged);
            // 
            // AreaUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lsbArea);
            this.Controls.Add(this.txtValue_Area);
            this.Controls.Add(this.btnChangeArea);
            this.Controls.Add(this.cmbItemID_Area);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblProperty);
            this.Controls.Add(this.lblID);
            this.Name = "AreaUser";
            this.Size = new System.Drawing.Size(288, 264);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValue_Area;
        private System.Windows.Forms.Button btnChangeArea;
        private System.Windows.Forms.ComboBox cmbItemID_Area;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ListBox lsbArea;
    }
}
