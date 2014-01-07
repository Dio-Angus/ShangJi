namespace ChromatoCore.uiConf
{
    partial class LabelUser
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
            this.txtValue_Label = new System.Windows.Forms.TextBox();
            this.btnChangeLabel = new System.Windows.Forms.Button();
            this.cmbItemID_Label = new System.Windows.Forms.ComboBox();
            this.lsbLabel = new System.Windows.Forms.ListBox();
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
            // txtValue_Label
            // 
            this.txtValue_Label.Location = new System.Drawing.Point(178, 56);
            this.txtValue_Label.Name = "txtValue_Label";
            this.txtValue_Label.Size = new System.Drawing.Size(81, 21);
            this.txtValue_Label.TabIndex = 58;
            // 
            // btnChangeLabel
            // 
            this.btnChangeLabel.Location = new System.Drawing.Point(178, 81);
            this.btnChangeLabel.Name = "btnChangeLabel";
            this.btnChangeLabel.Size = new System.Drawing.Size(81, 47);
            this.btnChangeLabel.TabIndex = 57;
            this.btnChangeLabel.Text = "Change";
            this.btnChangeLabel.UseVisualStyleBackColor = true;
            this.btnChangeLabel.Click += new System.EventHandler(this.btnChangeLabel_Click);
            // 
            // cmbItemID_Label
            // 
            this.cmbItemID_Label.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemID_Label.FormattingEnabled = true;
            this.cmbItemID_Label.Location = new System.Drawing.Point(72, 13);
            this.cmbItemID_Label.Name = "cmbItemID_Label";
            this.cmbItemID_Label.Size = new System.Drawing.Size(104, 20);
            this.cmbItemID_Label.TabIndex = 55;
            // 
            // lsbLabel
            // 
            this.lsbLabel.FormattingEnabled = true;
            this.lsbLabel.ItemHeight = 12;
            this.lsbLabel.Location = new System.Drawing.Point(12, 56);
            this.lsbLabel.Name = "lsbLabel";
            this.lsbLabel.Size = new System.Drawing.Size(162, 196);
            this.lsbLabel.TabIndex = 60;
            this.lsbLabel.SelectedIndexChanged += new System.EventHandler(this.lsbLabel_SelectedIndexChanged);
            // 
            // PanelLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lsbLabel);
            this.Controls.Add(this.txtValue_Label);
            this.Controls.Add(this.btnChangeLabel);
            this.Controls.Add(this.cmbItemID_Label);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblProperty);
            this.Controls.Add(this.lblID);
            this.Name = "PanelLabel";
            this.Size = new System.Drawing.Size(276, 272);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtValue_Label;
        private System.Windows.Forms.Button btnChangeLabel;
        private System.Windows.Forms.ComboBox cmbItemID_Label;
        private System.Windows.Forms.ListBox lsbLabel;
    }
}
