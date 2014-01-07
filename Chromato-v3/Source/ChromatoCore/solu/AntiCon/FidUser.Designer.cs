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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAlertTemp = new System.Windows.Forms.TextBox();
            this.txtInitTemp = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxPolarityFid2 = new System.Windows.Forms.CheckBox();
            this.cbxPolarityFid1 = new System.Windows.Forms.CheckBox();
            this.cmbMagnifyFactorFid1 = new System.Windows.Forms.ComboBox();
            this.cmbMagnifyFactorFid2 = new System.Windows.Forms.ComboBox();
            this.gbFID1 = new System.Windows.Forms.GroupBox();
            this.gbFID2 = new System.Windows.Forms.GroupBox();
            this.gbFID1.SuspendLayout();
            this.gbFID2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 84;
            this.label4.Text = "极性：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 83;
            this.label5.Text = "放大倍数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 80;
            this.label1.Text = "极性：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 79;
            this.label2.Text = "放大倍数：";
            // 
            // txtAlertTemp
            // 
            this.txtAlertTemp.Location = new System.Drawing.Point(255, 31);
            this.txtAlertTemp.Name = "txtAlertTemp";
            this.txtAlertTemp.Size = new System.Drawing.Size(78, 19);
            this.txtAlertTemp.TabIndex = 2;
            // 
            // txtInitTemp
            // 
            this.txtInitTemp.Location = new System.Drawing.Point(99, 31);
            this.txtInitTemp.Name = "txtInitTemp";
            this.txtInitTemp.Size = new System.Drawing.Size(78, 19);
            this.txtInitTemp.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(184, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 76;
            this.label14.Text = "报警温度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 75;
            this.label3.Text = "初   温：";
            // 
            // cbxPolarityFid2
            // 
            this.cbxPolarityFid2.AutoSize = true;
            this.cbxPolarityFid2.Location = new System.Drawing.Point(87, 44);
            this.cbxPolarityFid2.Name = "cbxPolarityFid2";
            this.cbxPolarityFid2.Size = new System.Drawing.Size(36, 16);
            this.cbxPolarityFid2.TabIndex = 6;
            this.cbxPolarityFid2.Text = "负";
            this.cbxPolarityFid2.UseVisualStyleBackColor = true;
            this.cbxPolarityFid2.CheckedChanged += new System.EventHandler(this.cbxPolarityFid2_CheckedChanged);
            // 
            // cbxPolarityFid1
            // 
            this.cbxPolarityFid1.AutoSize = true;
            this.cbxPolarityFid1.Location = new System.Drawing.Point(87, 41);
            this.cbxPolarityFid1.Name = "cbxPolarityFid1";
            this.cbxPolarityFid1.Size = new System.Drawing.Size(36, 16);
            this.cbxPolarityFid1.TabIndex = 4;
            this.cbxPolarityFid1.Text = "负";
            this.cbxPolarityFid1.UseVisualStyleBackColor = true;
            this.cbxPolarityFid1.CheckedChanged += new System.EventHandler(this.cbxPolarityFid1_CheckedChanged);
            // 
            // cmbMagnifyFactorFid1
            // 
            this.cmbMagnifyFactorFid1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMagnifyFactorFid1.FormattingEnabled = true;
            this.cmbMagnifyFactorFid1.Location = new System.Drawing.Point(87, 18);
            this.cmbMagnifyFactorFid1.Name = "cmbMagnifyFactorFid1";
            this.cmbMagnifyFactorFid1.Size = new System.Drawing.Size(234, 20);
            this.cmbMagnifyFactorFid1.TabIndex = 3;
            this.cmbMagnifyFactorFid1.SelectedIndexChanged += new System.EventHandler(this.cmbMagnifyFactorFid1_SelectedIndexChanged);
            // 
            // cmbMagnifyFactorFid2
            // 
            this.cmbMagnifyFactorFid2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMagnifyFactorFid2.FormattingEnabled = true;
            this.cmbMagnifyFactorFid2.Location = new System.Drawing.Point(87, 20);
            this.cmbMagnifyFactorFid2.Name = "cmbMagnifyFactorFid2";
            this.cmbMagnifyFactorFid2.Size = new System.Drawing.Size(234, 20);
            this.cmbMagnifyFactorFid2.TabIndex = 5;
            this.cmbMagnifyFactorFid2.SelectedIndexChanged += new System.EventHandler(this.cmbMagnifyFactorFid2_SelectedIndexChanged);
            // 
            // gbFID1
            // 
            this.gbFID1.Controls.Add(this.cmbMagnifyFactorFid1);
            this.gbFID1.Controls.Add(this.label2);
            this.gbFID1.Controls.Add(this.cbxPolarityFid1);
            this.gbFID1.Controls.Add(this.label1);
            this.gbFID1.Location = new System.Drawing.Point(12, 70);
            this.gbFID1.Name = "gbFID1";
            this.gbFID1.Size = new System.Drawing.Size(369, 65);
            this.gbFID1.TabIndex = 3;
            this.gbFID1.TabStop = false;
            this.gbFID1.Text = "FID1";
            // 
            // gbFID2
            // 
            this.gbFID2.Controls.Add(this.label5);
            this.gbFID2.Controls.Add(this.cmbMagnifyFactorFid2);
            this.gbFID2.Controls.Add(this.label4);
            this.gbFID2.Controls.Add(this.cbxPolarityFid2);
            this.gbFID2.Location = new System.Drawing.Point(12, 151);
            this.gbFID2.Name = "gbFID2";
            this.gbFID2.Size = new System.Drawing.Size(369, 65);
            this.gbFID2.TabIndex = 5;
            this.gbFID2.TabStop = false;
            this.gbFID2.Text = "FID2";
            // 
            // FidUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFID2);
            this.Controls.Add(this.txtAlertTemp);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.gbFID1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInitTemp);
            this.Name = "FidUser";
            this.Size = new System.Drawing.Size(401, 248);
            this.gbFID1.ResumeLayout(false);
            this.gbFID1.PerformLayout();
            this.gbFID2.ResumeLayout(false);
            this.gbFID2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAlertTemp;
        private System.Windows.Forms.TextBox txtInitTemp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbxPolarityFid2;
        private System.Windows.Forms.CheckBox cbxPolarityFid1;
        private System.Windows.Forms.ComboBox cmbMagnifyFactorFid1;
        private System.Windows.Forms.ComboBox cmbMagnifyFactorFid2;
        private System.Windows.Forms.GroupBox gbFID1;
        private System.Windows.Forms.GroupBox gbFID2;

    }
}
