namespace ChromatoCore.uiConf
{
    partial class YaxsUser
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
            this.txtValue_YAxis = new System.Windows.Forms.TextBox();
            this.btnChangeYAxis = new System.Windows.Forms.Button();
            this.cmbItemID_YAxis = new System.Windows.Forms.ComboBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblProperty = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lsbAxsY = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtValue_YAxis
            // 
            this.txtValue_YAxis.Location = new System.Drawing.Point(178, 56);
            this.txtValue_YAxis.Name = "txtValue_YAxis";
            this.txtValue_YAxis.Size = new System.Drawing.Size(81, 21);
            this.txtValue_YAxis.TabIndex = 56;
            // 
            // btnChangeYAxis
            // 
            this.btnChangeYAxis.Location = new System.Drawing.Point(178, 81);
            this.btnChangeYAxis.Name = "btnChangeYAxis";
            this.btnChangeYAxis.Size = new System.Drawing.Size(81, 47);
            this.btnChangeYAxis.TabIndex = 55;
            this.btnChangeYAxis.Text = "Change";
            this.btnChangeYAxis.UseVisualStyleBackColor = true;
            this.btnChangeYAxis.Click += new System.EventHandler(this.btnChangeYAxis_Click);
            // 
            // cmbItemID_YAxis
            // 
            this.cmbItemID_YAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemID_YAxis.FormattingEnabled = true;
            this.cmbItemID_YAxis.Location = new System.Drawing.Point(72, 13);
            this.cmbItemID_YAxis.Name = "cmbItemID_YAxis";
            this.cmbItemID_YAxis.Size = new System.Drawing.Size(104, 20);
            this.cmbItemID_YAxis.TabIndex = 53;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(176, 41);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(35, 12);
            this.lblValue.TabIndex = 52;
            this.lblValue.Text = "Value";
            // 
            // lblProperty
            // 
            this.lblProperty.AutoSize = true;
            this.lblProperty.Location = new System.Drawing.Point(12, 39);
            this.lblProperty.Name = "lblProperty";
            this.lblProperty.Size = new System.Drawing.Size(53, 12);
            this.lblProperty.TabIndex = 51;
            this.lblProperty.Text = "Property";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 16);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(41, 12);
            this.lblID.TabIndex = 50;
            this.lblID.Text = "ItemID";
            // 
            // lsbAxsY
            // 
            this.lsbAxsY.FormattingEnabled = true;
            this.lsbAxsY.ItemHeight = 12;
            this.lsbAxsY.Location = new System.Drawing.Point(12, 56);
            this.lsbAxsY.Name = "lsbAxsY";
            this.lsbAxsY.Size = new System.Drawing.Size(162, 196);
            this.lsbAxsY.TabIndex = 60;
            this.lsbAxsY.SelectedIndexChanged += new System.EventHandler(this.lsbAxsY_SelectedIndexChanged);
            // 
            // PanelYaxs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lsbAxsY);
            this.Controls.Add(this.txtValue_YAxis);
            this.Controls.Add(this.btnChangeYAxis);
            this.Controls.Add(this.cmbItemID_YAxis);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblProperty);
            this.Controls.Add(this.lblID);
            this.Name = "PanelYaxs";
            this.Size = new System.Drawing.Size(284, 260);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValue_YAxis;
        private System.Windows.Forms.Button btnChangeYAxis;
        private System.Windows.Forms.ComboBox cmbItemID_YAxis;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ListBox lsbAxsY;
    }
}
