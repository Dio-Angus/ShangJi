namespace ChromatoCore.solu.AntiCon
{
    partial class TcdUser
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
            this.cbxPolarityTcd1 = new System.Windows.Forms.CheckBox();
            this.txtCurrentTcd1 = new System.Windows.Forms.TextBox();
            this.gbTCD1 = new System.Windows.Forms.GroupBox();
            this.gbTCD2 = new System.Windows.Forms.GroupBox();
            this.txtAlertTemp2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInitTemp2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxPolarityTcd2 = new System.Windows.Forms.CheckBox();
            this.txtCurrentTcd2 = new System.Windows.Forms.TextBox();
            this.cbTCD1 = new System.Windows.Forms.CheckBox();
            this.cbTCD2 = new System.Windows.Forms.CheckBox();
            this.gbTCD1.SuspendLayout();
            this.gbTCD2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 72;
            this.label1.Text = "极性：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 71;
            this.label2.Text = "电流值：";
            // 
            // txtAlertTemp1
            // 
            this.txtAlertTemp1.Location = new System.Drawing.Point(81, 46);
            this.txtAlertTemp1.Name = "txtAlertTemp1";
            this.txtAlertTemp1.Size = new System.Drawing.Size(78, 21);
            this.txtAlertTemp1.TabIndex = 2;
            // 
            // txtInitTemp1
            // 
            this.txtInitTemp1.Location = new System.Drawing.Point(81, 23);
            this.txtInitTemp1.Name = "txtInitTemp1";
            this.txtInitTemp1.Size = new System.Drawing.Size(78, 21);
            this.txtInitTemp1.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 68;
            this.label14.Text = "报警温度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 67;
            this.label3.Text = "初   温：";
            // 
            // cbxPolarityTcd1
            // 
            this.cbxPolarityTcd1.AutoSize = true;
            this.cbxPolarityTcd1.Location = new System.Drawing.Point(81, 72);
            this.cbxPolarityTcd1.Name = "cbxPolarityTcd1";
            this.cbxPolarityTcd1.Size = new System.Drawing.Size(37, 16);
            this.cbxPolarityTcd1.TabIndex = 3;
            this.cbxPolarityTcd1.Text = "负";
            this.cbxPolarityTcd1.UseVisualStyleBackColor = true;
            this.cbxPolarityTcd1.CheckedChanged += new System.EventHandler(this.cbxPolarityTcd1_CheckedChanged);
            // 
            // txtCurrentTcd1
            // 
            this.txtCurrentTcd1.Location = new System.Drawing.Point(81, 91);
            this.txtCurrentTcd1.Name = "txtCurrentTcd1";
            this.txtCurrentTcd1.Size = new System.Drawing.Size(78, 21);
            this.txtCurrentTcd1.TabIndex = 4;
            // 
            // gbTCD1
            // 
            this.gbTCD1.Controls.Add(this.txtAlertTemp1);
            this.gbTCD1.Controls.Add(this.label3);
            this.gbTCD1.Controls.Add(this.label14);
            this.gbTCD1.Controls.Add(this.txtInitTemp1);
            this.gbTCD1.Controls.Add(this.label1);
            this.gbTCD1.Controls.Add(this.label2);
            this.gbTCD1.Controls.Add(this.cbxPolarityTcd1);
            this.gbTCD1.Controls.Add(this.txtCurrentTcd1);
            this.gbTCD1.Location = new System.Drawing.Point(24, 44);
            this.gbTCD1.Name = "gbTCD1";
            this.gbTCD1.Size = new System.Drawing.Size(200, 136);
            this.gbTCD1.TabIndex = 1;
            this.gbTCD1.TabStop = false;
            this.gbTCD1.Text = "TCD1";
            // 
            // gbTCD2
            // 
            this.gbTCD2.Controls.Add(this.txtAlertTemp2);
            this.gbTCD2.Controls.Add(this.label4);
            this.gbTCD2.Controls.Add(this.label5);
            this.gbTCD2.Controls.Add(this.txtInitTemp2);
            this.gbTCD2.Controls.Add(this.label9);
            this.gbTCD2.Controls.Add(this.label11);
            this.gbTCD2.Controls.Add(this.cbxPolarityTcd2);
            this.gbTCD2.Controls.Add(this.txtCurrentTcd2);
            this.gbTCD2.Location = new System.Drawing.Point(230, 44);
            this.gbTCD2.Name = "gbTCD2";
            this.gbTCD2.Size = new System.Drawing.Size(200, 136);
            this.gbTCD2.TabIndex = 7;
            this.gbTCD2.TabStop = false;
            this.gbTCD2.Text = "TCD2";
            // 
            // txtAlertTemp2
            // 
            this.txtAlertTemp2.Location = new System.Drawing.Point(84, 43);
            this.txtAlertTemp2.Name = "txtAlertTemp2";
            this.txtAlertTemp2.Size = new System.Drawing.Size(78, 21);
            this.txtAlertTemp2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 101;
            this.label4.Text = "初   温：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 102;
            this.label5.Text = "报警温度：";
            // 
            // txtInitTemp2
            // 
            this.txtInitTemp2.Location = new System.Drawing.Point(84, 20);
            this.txtInitTemp2.Name = "txtInitTemp2";
            this.txtInitTemp2.Size = new System.Drawing.Size(78, 21);
            this.txtInitTemp2.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 72;
            this.label9.Text = "极性：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 71;
            this.label11.Text = "电流值：";
            // 
            // cbxPolarityTcd2
            // 
            this.cbxPolarityTcd2.AutoSize = true;
            this.cbxPolarityTcd2.Location = new System.Drawing.Point(106, 73);
            this.cbxPolarityTcd2.Name = "cbxPolarityTcd2";
            this.cbxPolarityTcd2.Size = new System.Drawing.Size(37, 16);
            this.cbxPolarityTcd2.TabIndex = 9;
            this.cbxPolarityTcd2.Text = "负";
            this.cbxPolarityTcd2.UseVisualStyleBackColor = true;
            this.cbxPolarityTcd2.CheckedChanged += new System.EventHandler(this.cbxPolarityTcd2_CheckedChanged);
            // 
            // txtCurrentTcd2
            // 
            this.txtCurrentTcd2.Location = new System.Drawing.Point(84, 91);
            this.txtCurrentTcd2.Name = "txtCurrentTcd2";
            this.txtCurrentTcd2.Size = new System.Drawing.Size(78, 21);
            this.txtCurrentTcd2.TabIndex = 10;
            // 
            // cbTCD1
            // 
            this.cbTCD1.AutoSize = true;
            this.cbTCD1.Enabled = false;
            this.cbTCD1.Location = new System.Drawing.Point(48, 13);
            this.cbTCD1.Name = "cbTCD1";
            this.cbTCD1.Size = new System.Drawing.Size(49, 16);
            this.cbTCD1.TabIndex = 8;
            this.cbTCD1.Text = "TCD1";
            this.cbTCD1.UseVisualStyleBackColor = true;
            this.cbTCD1.Click += new System.EventHandler(this.cbTCD1_Click);
            // 
            // cbTCD2
            // 
            this.cbTCD2.AutoSize = true;
            this.cbTCD2.Enabled = false;
            this.cbTCD2.Location = new System.Drawing.Point(133, 13);
            this.cbTCD2.Name = "cbTCD2";
            this.cbTCD2.Size = new System.Drawing.Size(49, 16);
            this.cbTCD2.TabIndex = 8;
            this.cbTCD2.Text = "TCD2";
            this.cbTCD2.UseVisualStyleBackColor = true;
            this.cbTCD2.Click += new System.EventHandler(this.cbTCD2_Click);
            // 
            // TcdUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbTCD2);
            this.Controls.Add(this.cbTCD1);
            this.Controls.Add(this.gbTCD2);
            this.Controls.Add(this.gbTCD1);
            this.Name = "TcdUser";
            this.Size = new System.Drawing.Size(454, 243);
            this.gbTCD1.ResumeLayout(false);
            this.gbTCD1.PerformLayout();
            this.gbTCD2.ResumeLayout(false);
            this.gbTCD2.PerformLayout();
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
        private System.Windows.Forms.CheckBox cbxPolarityTcd1;
        private System.Windows.Forms.TextBox txtCurrentTcd1;
        private System.Windows.Forms.GroupBox gbTCD1;
        private System.Windows.Forms.GroupBox gbTCD2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbxPolarityTcd2;
        private System.Windows.Forms.TextBox txtCurrentTcd2;
        private System.Windows.Forms.TextBox txtAlertTemp2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInitTemp2;
        private System.Windows.Forms.CheckBox cbTCD1;
        private System.Windows.Forms.CheckBox cbTCD2;

    }
}
