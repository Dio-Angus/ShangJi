namespace ChromatoCore.solu.AntiCon
{
    partial class AntiControlViewer
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
            this.gbAntiControl = new System.Windows.Forms.GroupBox();
            this.txtAntiControlName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tvAntiControl = new System.Windows.Forms.TreeView();
            this.gbAntiControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAntiControl
            // 
            this.gbAntiControl.Controls.Add(this.txtAntiControlName);
            this.gbAntiControl.Controls.Add(this.label1);
            this.gbAntiControl.Controls.Add(this.tvAntiControl);
            this.gbAntiControl.Location = new System.Drawing.Point(3, 2);
            this.gbAntiControl.Name = "gbAntiControl";
            this.gbAntiControl.Size = new System.Drawing.Size(565, 277);
            this.gbAntiControl.TabIndex = 0;
            this.gbAntiControl.TabStop = false;
            this.gbAntiControl.Text = "反控方法";
            // 
            // txtAntiControlName
            // 
            this.txtAntiControlName.Location = new System.Drawing.Point(186, 251);
            this.txtAntiControlName.Name = "txtAntiControlName";
            this.txtAntiControlName.Size = new System.Drawing.Size(291, 19);
            this.txtAntiControlName.TabIndex = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 71;
            this.label1.Text = "反控方法名：";
            // 
            // tvAntiControl
            // 
            this.tvAntiControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvAntiControl.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvAntiControl.Location = new System.Drawing.Point(6, 16);
            this.tvAntiControl.Name = "tvAntiControl";
            this.tvAntiControl.Size = new System.Drawing.Size(87, 251);
            this.tvAntiControl.TabIndex = 1;
            // 
            // AntiControlViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.gbAntiControl);
            this.Name = "AntiControlViewer";
            this.Size = new System.Drawing.Size(572, 284);
            this.gbAntiControl.ResumeLayout(false);
            this.gbAntiControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAntiControl;
        private System.Windows.Forms.TreeView tvAntiControl;
        private System.Windows.Forms.TextBox txtAntiControlName;
        private System.Windows.Forms.Label label1;
    }
}
