namespace ChromatoCore.uiConf
{
    partial class LineUser
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
            this.txtValue_Line = new System.Windows.Forms.TextBox();
            this.btnChangeLine = new System.Windows.Forms.Button();
            this.cmbItemID_Line = new System.Windows.Forms.ComboBox();
            this.lsbLine = new System.Windows.Forms.ListBox();
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
            // txtValue_Line
            // 
            this.txtValue_Line.Location = new System.Drawing.Point(178, 56);
            this.txtValue_Line.Name = "txtValue_Line";
            this.txtValue_Line.Size = new System.Drawing.Size(81, 21);
            this.txtValue_Line.TabIndex = 56;
            // 
            // btnChangeLine
            // 
            this.btnChangeLine.Location = new System.Drawing.Point(178, 81);
            this.btnChangeLine.Name = "btnChangeLine";
            this.btnChangeLine.Size = new System.Drawing.Size(81, 55);
            this.btnChangeLine.TabIndex = 55;
            this.btnChangeLine.Text = "Change";
            this.btnChangeLine.UseVisualStyleBackColor = true;
            this.btnChangeLine.Click += new System.EventHandler(this.btnChangeLine_Click);
            // 
            // cmbItemID_Line
            // 
            this.cmbItemID_Line.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemID_Line.FormattingEnabled = true;
            this.cmbItemID_Line.Location = new System.Drawing.Point(72, 13);
            this.cmbItemID_Line.Name = "cmbItemID_Line";
            this.cmbItemID_Line.Size = new System.Drawing.Size(104, 20);
            this.cmbItemID_Line.TabIndex = 53;
            // 
            // lsbLine
            // 
            this.lsbLine.FormattingEnabled = true;
            this.lsbLine.ItemHeight = 12;
            this.lsbLine.Location = new System.Drawing.Point(12, 56);
            this.lsbLine.Name = "lsbLine";
            this.lsbLine.Size = new System.Drawing.Size(162, 196);
            this.lsbLine.TabIndex = 60;
            this.lsbLine.SelectedIndexChanged += new System.EventHandler(this.lsbLine_SelectedIndexChanged);
            // 
            // PanelLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lsbLine);
            this.Controls.Add(this.txtValue_Line);
            this.Controls.Add(this.btnChangeLine);
            this.Controls.Add(this.cmbItemID_Line);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblProperty);
            this.Controls.Add(this.lblID);
            this.Name = "PanelLine";
            this.Size = new System.Drawing.Size(281, 267);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtValue_Line;
        private System.Windows.Forms.Button btnChangeLine;
        private System.Windows.Forms.ComboBox cmbItemID_Line;
        private System.Windows.Forms.ListBox lsbLine;
    }
}
