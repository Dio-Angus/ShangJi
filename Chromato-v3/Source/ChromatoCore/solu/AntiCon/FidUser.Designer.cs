namespace ChromatoCore.solu.AntiCon
{
    partial class FidUser
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAlertTemp1 = new System.Windows.Forms.TextBox();
            this.txtInitTemp1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxPolarityFid1 = new System.Windows.Forms.CheckBox();
            this.cmbMagnifyFactorFid1 = new System.Windows.Forms.ComboBox();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.gbECD = new System.Windows.Forms.GroupBox();
            this.cmbMagnifyFactorECD = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxPolarityECD = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbFPD = new System.Windows.Forms.GroupBox();
            this.cmbMagnifyFactorFPD = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxPolarityFPD = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gb1.SuspendLayout();
            this.gbECD.SuspendLayout();
            this.gbFPD.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 80;
            this.label1.Text = "极性：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 79;
            this.label2.Text = "放大倍数：";
            // 
            // txtAlertTemp1
            // 
            this.txtAlertTemp1.Location = new System.Drawing.Point(275, 12);
            this.txtAlertTemp1.Name = "txtAlertTemp1";
            this.txtAlertTemp1.Size = new System.Drawing.Size(78, 21);
            this.txtAlertTemp1.TabIndex = 2;
            // 
            // txtInitTemp1
            // 
            this.txtInitTemp1.Location = new System.Drawing.Point(119, 12);
            this.txtInitTemp1.Name = "txtInitTemp1";
            this.txtInitTemp1.Size = new System.Drawing.Size(78, 21);
            this.txtInitTemp1.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(204, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 76;
            this.label14.Text = "报警温度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 75;
            this.label3.Text = "初   温：";
            // 
            // cbxPolarityFid1
            // 
            this.cbxPolarityFid1.AutoSize = true;
            this.cbxPolarityFid1.Location = new System.Drawing.Point(99, 35);
            this.cbxPolarityFid1.Name = "cbxPolarityFid1";
            this.cbxPolarityFid1.Size = new System.Drawing.Size(37, 16);
            this.cbxPolarityFid1.TabIndex = 4;
            this.cbxPolarityFid1.Text = "负";
            this.cbxPolarityFid1.UseVisualStyleBackColor = true;
            this.cbxPolarityFid1.CheckedChanged += new System.EventHandler(this.cbxPolarityFid1_CheckedChanged);
            // 
            // cmbMagnifyFactorFid1
            // 
            this.cmbMagnifyFactorFid1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMagnifyFactorFid1.FormattingEnabled = true;
            this.cmbMagnifyFactorFid1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cmbMagnifyFactorFid1.Location = new System.Drawing.Point(99, 12);
            this.cmbMagnifyFactorFid1.Name = "cmbMagnifyFactorFid1";
            this.cmbMagnifyFactorFid1.Size = new System.Drawing.Size(234, 20);
            this.cmbMagnifyFactorFid1.TabIndex = 3;
            this.cmbMagnifyFactorFid1.SelectedIndexChanged += new System.EventHandler(this.cmbMagnifyFactorFid1_SelectedIndexChanged);
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.cmbMagnifyFactorFid1);
            this.gb1.Controls.Add(this.label2);
            this.gb1.Controls.Add(this.cbxPolarityFid1);
            this.gb1.Controls.Add(this.label1);
            this.gb1.Location = new System.Drawing.Point(19, 39);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(357, 53);
            this.gb1.TabIndex = 3;
            this.gb1.TabStop = false;
            this.gb1.Text = "FID1";
            // 
            // gbECD
            // 
            this.gbECD.Controls.Add(this.cmbMagnifyFactorECD);
            this.gbECD.Controls.Add(this.label4);
            this.gbECD.Controls.Add(this.cbxPolarityECD);
            this.gbECD.Controls.Add(this.label5);
            this.gbECD.Location = new System.Drawing.Point(19, 98);
            this.gbECD.Name = "gbECD";
            this.gbECD.Size = new System.Drawing.Size(357, 53);
            this.gbECD.TabIndex = 3;
            this.gbECD.TabStop = false;
            this.gbECD.Text = "ECD";
            // 
            // cmbMagnifyFactorECD
            // 
            this.cmbMagnifyFactorECD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMagnifyFactorECD.FormattingEnabled = true;
            this.cmbMagnifyFactorECD.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cmbMagnifyFactorECD.Location = new System.Drawing.Point(99, 12);
            this.cmbMagnifyFactorECD.Name = "cmbMagnifyFactorECD";
            this.cmbMagnifyFactorECD.Size = new System.Drawing.Size(234, 20);
            this.cmbMagnifyFactorECD.TabIndex = 3;
            this.cmbMagnifyFactorECD.SelectedIndexChanged += new System.EventHandler(this.cmbMagnifyFactorFid1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 79;
            this.label4.Text = "放大倍数：";
            // 
            // cbxPolarityECD
            // 
            this.cbxPolarityECD.AutoSize = true;
            this.cbxPolarityECD.Location = new System.Drawing.Point(99, 35);
            this.cbxPolarityECD.Name = "cbxPolarityECD";
            this.cbxPolarityECD.Size = new System.Drawing.Size(37, 16);
            this.cbxPolarityECD.TabIndex = 4;
            this.cbxPolarityECD.Text = "负";
            this.cbxPolarityECD.UseVisualStyleBackColor = true;
            this.cbxPolarityECD.CheckedChanged += new System.EventHandler(this.cbxPolarityFid1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 80;
            this.label5.Text = "极性：";
            // 
            // gbFPD
            // 
            this.gbFPD.Controls.Add(this.cmbMagnifyFactorFPD);
            this.gbFPD.Controls.Add(this.label6);
            this.gbFPD.Controls.Add(this.cbxPolarityFPD);
            this.gbFPD.Controls.Add(this.label7);
            this.gbFPD.Location = new System.Drawing.Point(19, 157);
            this.gbFPD.Name = "gbFPD";
            this.gbFPD.Size = new System.Drawing.Size(357, 53);
            this.gbFPD.TabIndex = 3;
            this.gbFPD.TabStop = false;
            this.gbFPD.Text = "FPD";
            // 
            // cmbMagnifyFactorFPD
            // 
            this.cmbMagnifyFactorFPD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMagnifyFactorFPD.FormattingEnabled = true;
            this.cmbMagnifyFactorFPD.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cmbMagnifyFactorFPD.Location = new System.Drawing.Point(99, 12);
            this.cmbMagnifyFactorFPD.Name = "cmbMagnifyFactorFPD";
            this.cmbMagnifyFactorFPD.Size = new System.Drawing.Size(234, 20);
            this.cmbMagnifyFactorFPD.TabIndex = 3;
            this.cmbMagnifyFactorFPD.SelectedIndexChanged += new System.EventHandler(this.cmbMagnifyFactorFid1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 79;
            this.label6.Text = "放大倍数：";
            // 
            // cbxPolarityFPD
            // 
            this.cbxPolarityFPD.AutoSize = true;
            this.cbxPolarityFPD.Location = new System.Drawing.Point(99, 35);
            this.cbxPolarityFPD.Name = "cbxPolarityFPD";
            this.cbxPolarityFPD.Size = new System.Drawing.Size(37, 16);
            this.cbxPolarityFPD.TabIndex = 4;
            this.cbxPolarityFPD.Text = "负";
            this.cbxPolarityFPD.UseVisualStyleBackColor = true;
            this.cbxPolarityFPD.CheckedChanged += new System.EventHandler(this.cbxPolarityFid1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 80;
            this.label7.Text = "极性：";
            // 
            // FidUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFPD);
            this.Controls.Add(this.gbECD);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.txtAlertTemp1);
            this.Controls.Add(this.txtInitTemp1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label14);
            this.Name = "FidUser";
            this.Size = new System.Drawing.Size(397, 220);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.gbECD.ResumeLayout(false);
            this.gbECD.PerformLayout();
            this.gbFPD.ResumeLayout(false);
            this.gbFPD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAlertTemp1;
        private System.Windows.Forms.TextBox txtInitTemp1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbxPolarityFid1;
        private System.Windows.Forms.ComboBox cmbMagnifyFactorFid1;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.GroupBox gbECD;
        private System.Windows.Forms.ComboBox cmbMagnifyFactorECD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbxPolarityECD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbFPD;
        private System.Windows.Forms.ComboBox cmbMagnifyFactorFPD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbxPolarityFPD;
        private System.Windows.Forms.Label label7;

    }
}
