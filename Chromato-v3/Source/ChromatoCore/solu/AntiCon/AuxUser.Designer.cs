namespace ChromatoCore.solu.AntiCon
{
    partial class AuxUser
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
            this.txtAlertTempAux2 = new System.Windows.Forms.TextBox();
            this.txtInitTempAux2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAlertTempAux1 = new System.Windows.Forms.TextBox();
            this.txtInitTempAux1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAux1 = new System.Windows.Forms.CheckBox();
            this.cbAux2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtAlertTempAux2
            // 
            this.txtAlertTempAux2.Location = new System.Drawing.Point(144, 156);
            this.txtAlertTempAux2.Name = "txtAlertTempAux2";
            this.txtAlertTempAux2.Size = new System.Drawing.Size(78, 21);
            this.txtAlertTempAux2.TabIndex = 4;
            // 
            // txtInitTempAux2
            // 
            this.txtInitTempAux2.Location = new System.Drawing.Point(144, 133);
            this.txtInitTempAux2.Name = "txtInitTempAux2";
            this.txtInitTempAux2.Size = new System.Drawing.Size(78, 21);
            this.txtInitTempAux2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 68;
            this.label1.Text = "Aux2 报警温度：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 67;
            this.label2.Text = "Aux2 初 温：";
            // 
            // txtAlertTempAux1
            // 
            this.txtAlertTempAux1.Location = new System.Drawing.Point(144, 95);
            this.txtAlertTempAux1.Name = "txtAlertTempAux1";
            this.txtAlertTempAux1.Size = new System.Drawing.Size(78, 21);
            this.txtAlertTempAux1.TabIndex = 2;
            // 
            // txtInitTempAux1
            // 
            this.txtInitTempAux1.Location = new System.Drawing.Point(144, 72);
            this.txtInitTempAux1.Name = "txtInitTempAux1";
            this.txtInitTempAux1.Size = new System.Drawing.Size(78, 21);
            this.txtInitTempAux1.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(43, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 12);
            this.label14.TabIndex = 64;
            this.label14.Text = "Aux1 报警温度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 63;
            this.label3.Text = "Aux1 初 温：";
            // 
            // cbAux1
            // 
            this.cbAux1.AutoSize = true;
            this.cbAux1.Enabled = false;
            this.cbAux1.Location = new System.Drawing.Point(45, 30);
            this.cbAux1.Name = "cbAux1";
            this.cbAux1.Size = new System.Drawing.Size(49, 16);
            this.cbAux1.TabIndex = 69;
            this.cbAux1.Text = "Aux1";
            this.cbAux1.UseVisualStyleBackColor = true;
            this.cbAux1.CheckedChanged += new System.EventHandler(this.cbAux1_Click);
            // 
            // cbAux2
            // 
            this.cbAux2.AutoSize = true;
            this.cbAux2.Enabled = false;
            this.cbAux2.Location = new System.Drawing.Point(100, 30);
            this.cbAux2.Name = "cbAux2";
            this.cbAux2.Size = new System.Drawing.Size(49, 16);
            this.cbAux2.TabIndex = 69;
            this.cbAux2.Text = "Aux2";
            this.cbAux2.UseVisualStyleBackColor = true;
            this.cbAux2.CheckedChanged += new System.EventHandler(this.cbAux2_Click);
            // 
            // AuxUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbAux2);
            this.Controls.Add(this.cbAux1);
            this.Controls.Add(this.txtAlertTempAux2);
            this.Controls.Add(this.txtInitTempAux2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAlertTempAux1);
            this.Controls.Add(this.txtInitTempAux1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label3);
            this.Name = "AuxUser";
            this.Size = new System.Drawing.Size(459, 247);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAlertTempAux2;
        private System.Windows.Forms.TextBox txtInitTempAux2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAlertTempAux1;
        private System.Windows.Forms.TextBox txtInitTempAux1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbAux1;
        private System.Windows.Forms.CheckBox cbAux2;

    }
}
