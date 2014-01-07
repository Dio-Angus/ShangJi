namespace ChromatoCore.solu.sUi
{
    partial class ArithmaticUi
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
            this.gbArithmatic = new System.Windows.Forms.GroupBox();
            this.rbExponent = new System.Windows.Forms.RadioButton();
            this.rbInner = new System.Windows.Forms.RadioButton();
            this.rbOuter = new System.Windows.Forms.RadioButton();
            this.rbFixNormalizeWithRate = new System.Windows.Forms.RadioButton();
            this.rbFixNormalize = new System.Windows.Forms.RadioButton();
            this.rbNormalize = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbArithmatic.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbArithmatic
            // 
            this.gbArithmatic.Controls.Add(this.rbExponent);
            this.gbArithmatic.Controls.Add(this.rbInner);
            this.gbArithmatic.Controls.Add(this.rbOuter);
            this.gbArithmatic.Controls.Add(this.rbFixNormalizeWithRate);
            this.gbArithmatic.Controls.Add(this.rbFixNormalize);
            this.gbArithmatic.Controls.Add(this.rbNormalize);
            this.gbArithmatic.Location = new System.Drawing.Point(12, 12);
            this.gbArithmatic.Name = "gbArithmatic";
            this.gbArithmatic.Size = new System.Drawing.Size(214, 85);
            this.gbArithmatic.TabIndex = 32;
            this.gbArithmatic.TabStop = false;
            this.gbArithmatic.Text = "定量计算方法";
            // 
            // rbExponent
            // 
            this.rbExponent.AutoSize = true;
            this.rbExponent.Location = new System.Drawing.Point(144, 63);
            this.rbExponent.Name = "rbExponent";
            this.rbExponent.Size = new System.Drawing.Size(59, 16);
            this.rbExponent.TabIndex = 5;
            this.rbExponent.TabStop = true;
            this.rbExponent.Text = "指数法";
            this.rbExponent.UseVisualStyleBackColor = true;
            // 
            // rbInner
            // 
            this.rbInner.AutoSize = true;
            this.rbInner.Location = new System.Drawing.Point(144, 41);
            this.rbInner.Name = "rbInner";
            this.rbInner.Size = new System.Drawing.Size(59, 16);
            this.rbInner.TabIndex = 4;
            this.rbInner.TabStop = true;
            this.rbInner.Text = "内标法";
            this.rbInner.UseVisualStyleBackColor = true;
            // 
            // rbOuter
            // 
            this.rbOuter.AutoSize = true;
            this.rbOuter.Location = new System.Drawing.Point(144, 20);
            this.rbOuter.Name = "rbOuter";
            this.rbOuter.Size = new System.Drawing.Size(59, 16);
            this.rbOuter.TabIndex = 3;
            this.rbOuter.TabStop = true;
            this.rbOuter.Text = "外标法";
            this.rbOuter.UseVisualStyleBackColor = true;
            // 
            // rbFixNormalizeWithRate
            // 
            this.rbFixNormalizeWithRate.AutoSize = true;
            this.rbFixNormalizeWithRate.Location = new System.Drawing.Point(9, 63);
            this.rbFixNormalizeWithRate.Name = "rbFixNormalizeWithRate";
            this.rbFixNormalizeWithRate.Size = new System.Drawing.Size(119, 16);
            this.rbFixNormalizeWithRate.TabIndex = 2;
            this.rbFixNormalizeWithRate.TabStop = true;
            this.rbFixNormalizeWithRate.Text = "带比例修正归一法";
            this.rbFixNormalizeWithRate.UseVisualStyleBackColor = true;
            // 
            // rbFixNormalize
            // 
            this.rbFixNormalize.AutoSize = true;
            this.rbFixNormalize.Location = new System.Drawing.Point(9, 41);
            this.rbFixNormalize.Name = "rbFixNormalize";
            this.rbFixNormalize.Size = new System.Drawing.Size(83, 16);
            this.rbFixNormalize.TabIndex = 1;
            this.rbFixNormalize.TabStop = true;
            this.rbFixNormalize.Text = "修正归一法";
            this.rbFixNormalize.UseVisualStyleBackColor = true;
            // 
            // rbNormalize
            // 
            this.rbNormalize.AutoSize = true;
            this.rbNormalize.Location = new System.Drawing.Point(9, 18);
            this.rbNormalize.Name = "rbNormalize";
            this.rbNormalize.Size = new System.Drawing.Size(59, 16);
            this.rbNormalize.TabIndex = 0;
            this.rbNormalize.TabStop = true;
            this.rbNormalize.Text = "归一法";
            this.rbNormalize.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(241, 21);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 25);
            this.btnOK.TabIndex = 33;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ArithmaticUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 111);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbArithmatic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArithmaticUi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更改计算方法";
            this.gbArithmatic.ResumeLayout(false);
            this.gbArithmatic.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbArithmatic;
        private System.Windows.Forms.RadioButton rbExponent;
        private System.Windows.Forms.RadioButton rbInner;
        private System.Windows.Forms.RadioButton rbOuter;
        private System.Windows.Forms.RadioButton rbFixNormalizeWithRate;
        private System.Windows.Forms.RadioButton rbFixNormalize;
        private System.Windows.Forms.RadioButton rbNormalize;
        private System.Windows.Forms.Button btnOK;
    }
}