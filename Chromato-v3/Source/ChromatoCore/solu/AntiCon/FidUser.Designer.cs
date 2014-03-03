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
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.cmbMagnifyFactorFid2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxPolarityFid2 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gb3 = new System.Windows.Forms.GroupBox();
            this.cmbMagnifyFactorFid3 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxPolarityFid3 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gb1.SuspendLayout();
            this.gb2.SuspendLayout();
            this.gb3.SuspendLayout();
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
            // gb2
            // 
            this.gb2.Controls.Add(this.cmbMagnifyFactorFid2);
            this.gb2.Controls.Add(this.label4);
            this.gb2.Controls.Add(this.cbxPolarityFid2);
            this.gb2.Controls.Add(this.label5);
            this.gb2.Location = new System.Drawing.Point(19, 98);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(357, 53);
            this.gb2.TabIndex = 3;
            this.gb2.TabStop = false;
            this.gb2.Text = "ECD";
            // 
            // cmbMagnifyFactorFid2
            // 
            this.cmbMagnifyFactorFid2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMagnifyFactorFid2.FormattingEnabled = true;
            this.cmbMagnifyFactorFid2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cmbMagnifyFactorFid2.Location = new System.Drawing.Point(99, 12);
            this.cmbMagnifyFactorFid2.Name = "cmbMagnifyFactorFid2";
            this.cmbMagnifyFactorFid2.Size = new System.Drawing.Size(234, 20);
            this.cmbMagnifyFactorFid2.TabIndex = 3;
            this.cmbMagnifyFactorFid2.SelectedIndexChanged += new System.EventHandler(this.cmbMagnifyFactorFid1_SelectedIndexChanged);
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
            // cbxPolarityFid2
            // 
            this.cbxPolarityFid2.AutoSize = true;
            this.cbxPolarityFid2.Location = new System.Drawing.Point(99, 35);
            this.cbxPolarityFid2.Name = "cbxPolarityFid2";
            this.cbxPolarityFid2.Size = new System.Drawing.Size(37, 16);
            this.cbxPolarityFid2.TabIndex = 4;
            this.cbxPolarityFid2.Text = "负";
            this.cbxPolarityFid2.UseVisualStyleBackColor = true;
            this.cbxPolarityFid2.CheckedChanged += new System.EventHandler(this.cbxPolarityFid1_CheckedChanged);
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
            // gb3
            // 
            this.gb3.Controls.Add(this.cmbMagnifyFactorFid3);
            this.gb3.Controls.Add(this.label6);
            this.gb3.Controls.Add(this.cbxPolarityFid3);
            this.gb3.Controls.Add(this.label7);
            this.gb3.Location = new System.Drawing.Point(19, 157);
            this.gb3.Name = "gb3";
            this.gb3.Size = new System.Drawing.Size(357, 53);
            this.gb3.TabIndex = 3;
            this.gb3.TabStop = false;
            this.gb3.Text = "FPD";
            // 
            // cmbMagnifyFactorFid3
            // 
            this.cmbMagnifyFactorFid3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMagnifyFactorFid3.FormattingEnabled = true;
            this.cmbMagnifyFactorFid3.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cmbMagnifyFactorFid3.Location = new System.Drawing.Point(99, 12);
            this.cmbMagnifyFactorFid3.Name = "cmbMagnifyFactorFid3";
            this.cmbMagnifyFactorFid3.Size = new System.Drawing.Size(234, 20);
            this.cmbMagnifyFactorFid3.TabIndex = 3;
            this.cmbMagnifyFactorFid3.SelectedIndexChanged += new System.EventHandler(this.cmbMagnifyFactorFid1_SelectedIndexChanged);
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
            // cbxPolarityFid3
            // 
            this.cbxPolarityFid3.AutoSize = true;
            this.cbxPolarityFid3.Location = new System.Drawing.Point(99, 35);
            this.cbxPolarityFid3.Name = "cbxPolarityFid3";
            this.cbxPolarityFid3.Size = new System.Drawing.Size(37, 16);
            this.cbxPolarityFid3.TabIndex = 4;
            this.cbxPolarityFid3.Text = "负";
            this.cbxPolarityFid3.UseVisualStyleBackColor = true;
            this.cbxPolarityFid3.CheckedChanged += new System.EventHandler(this.cbxPolarityFid1_CheckedChanged);
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
            this.Controls.Add(this.gb3);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.txtAlertTemp1);
            this.Controls.Add(this.txtInitTemp1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label14);
            this.Name = "FidUser";
            this.Size = new System.Drawing.Size(397, 220);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            this.gb3.ResumeLayout(false);
            this.gb3.PerformLayout();
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
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.ComboBox cmbMagnifyFactorFid2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbxPolarityFid2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gb3;
        private System.Windows.Forms.ComboBox cmbMagnifyFactorFid3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbxPolarityFid3;
        private System.Windows.Forms.Label label7;

    }
}
