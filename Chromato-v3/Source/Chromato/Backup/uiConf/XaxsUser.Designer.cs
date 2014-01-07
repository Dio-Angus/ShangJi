namespace ChromatoCore.uiConf
{
    partial class XaxsUser
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
            this.lblValue = new System.Windows.Forms.Label();
            this.lblProperty = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtValue_XAxis = new System.Windows.Forms.TextBox();
            this.btnChangeXAxis = new System.Windows.Forms.Button();
            this.cmbItemID_XAxis = new System.Windows.Forms.ComboBox();
            this.lsbAxsX = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(176, 41);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(35, 12);
            this.lblValue.TabIndex = 8;
            this.lblValue.Text = "Value";
            // 
            // lblProperty
            // 
            this.lblProperty.AutoSize = true;
            this.lblProperty.Location = new System.Drawing.Point(12, 39);
            this.lblProperty.Name = "lblProperty";
            this.lblProperty.Size = new System.Drawing.Size(53, 12);
            this.lblProperty.TabIndex = 7;
            this.lblProperty.Text = "Property";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 16);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(41, 12);
            this.lblID.TabIndex = 6;
            this.lblID.Text = "ItemID";
            // 
            // txtValue_XAxis
            // 
            this.txtValue_XAxis.Location = new System.Drawing.Point(178, 56);
            this.txtValue_XAxis.Name = "txtValue_XAxis";
            this.txtValue_XAxis.Size = new System.Drawing.Size(81, 21);
            this.txtValue_XAxis.TabIndex = 52;
            // 
            // btnChangeXAxis
            // 
            this.btnChangeXAxis.Location = new System.Drawing.Point(178, 81);
            this.btnChangeXAxis.Name = "btnChangeXAxis";
            this.btnChangeXAxis.Size = new System.Drawing.Size(81, 47);
            this.btnChangeXAxis.TabIndex = 51;
            this.btnChangeXAxis.Text = "Change";
            this.btnChangeXAxis.UseVisualStyleBackColor = true;
            this.btnChangeXAxis.Click += new System.EventHandler(this.btnChangeXAxis_Click);
            // 
            // cmbItemID_XAxis
            // 
            this.cmbItemID_XAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemID_XAxis.FormattingEnabled = true;
            this.cmbItemID_XAxis.Location = new System.Drawing.Point(72, 13);
            this.cmbItemID_XAxis.Name = "cmbItemID_XAxis";
            this.cmbItemID_XAxis.Size = new System.Drawing.Size(104, 20);
            this.cmbItemID_XAxis.TabIndex = 49;
            // 
            // lsbAxsX
            // 
            this.lsbAxsX.FormattingEnabled = true;
            this.lsbAxsX.ItemHeight = 12;
            this.lsbAxsX.Location = new System.Drawing.Point(12, 56);
            this.lsbAxsX.Name = "lsbAxsX";
            this.lsbAxsX.Size = new System.Drawing.Size(162, 196);
            this.lsbAxsX.TabIndex = 60;
            this.lsbAxsX.SelectedIndexChanged += new System.EventHandler(this.lsbAxsX_SelectedIndexChanged);
            // 
            // PanelXaxs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lsbAxsX);
            this.Controls.Add(this.txtValue_XAxis);
            this.Controls.Add(this.btnChangeXAxis);
            this.Controls.Add(this.cmbItemID_XAxis);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblProperty);
            this.Controls.Add(this.lblID);
            this.Name = "PanelXaxs";
            this.Size = new System.Drawing.Size(290, 262);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtValue_XAxis;
        private System.Windows.Forms.Button btnChangeXAxis;
        private System.Windows.Forms.ComboBox cmbItemID_XAxis;
        private System.Windows.Forms.ListBox lsbAxsX;
    }
}
