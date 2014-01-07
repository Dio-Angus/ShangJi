namespace ChromatoCore.uiConf
{
    partial class ShapeUser
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
            this.txtValue_Shape = new System.Windows.Forms.TextBox();
            this.btnChangeShape = new System.Windows.Forms.Button();
            this.cmbItemID_Shape = new System.Windows.Forms.ComboBox();
            this.lsbShape = new System.Windows.Forms.ListBox();
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
            // txtValue_Shape
            // 
            this.txtValue_Shape.Location = new System.Drawing.Point(178, 56);
            this.txtValue_Shape.Name = "txtValue_Shape";
            this.txtValue_Shape.Size = new System.Drawing.Size(81, 21);
            this.txtValue_Shape.TabIndex = 57;
            // 
            // btnChangeShape
            // 
            this.btnChangeShape.Location = new System.Drawing.Point(178, 81);
            this.btnChangeShape.Name = "btnChangeShape";
            this.btnChangeShape.Size = new System.Drawing.Size(81, 47);
            this.btnChangeShape.TabIndex = 56;
            this.btnChangeShape.Text = "Change";
            this.btnChangeShape.UseVisualStyleBackColor = true;
            this.btnChangeShape.Click += new System.EventHandler(this.btnChangeShape_Click);
            // 
            // cmbItemID_Shape
            // 
            this.cmbItemID_Shape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemID_Shape.FormattingEnabled = true;
            this.cmbItemID_Shape.Location = new System.Drawing.Point(72, 13);
            this.cmbItemID_Shape.Name = "cmbItemID_Shape";
            this.cmbItemID_Shape.Size = new System.Drawing.Size(104, 20);
            this.cmbItemID_Shape.TabIndex = 54;
            // 
            // lsbShape
            // 
            this.lsbShape.FormattingEnabled = true;
            this.lsbShape.ItemHeight = 12;
            this.lsbShape.Location = new System.Drawing.Point(12, 56);
            this.lsbShape.Name = "lsbShape";
            this.lsbShape.Size = new System.Drawing.Size(162, 196);
            this.lsbShape.TabIndex = 60;
            this.lsbShape.SelectedIndexChanged += new System.EventHandler(this.lsbShape_SelectedIndexChanged);
            // 
            // PanelShape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lsbShape);
            this.Controls.Add(this.txtValue_Shape);
            this.Controls.Add(this.btnChangeShape);
            this.Controls.Add(this.cmbItemID_Shape);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblProperty);
            this.Controls.Add(this.lblID);
            this.Name = "PanelShape";
            this.Size = new System.Drawing.Size(278, 263);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtValue_Shape;
        private System.Windows.Forms.Button btnChangeShape;
        private System.Windows.Forms.ComboBox cmbItemID_Shape;
        private System.Windows.Forms.ListBox lsbShape;
    }
}
