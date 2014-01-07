namespace ChromatoCore.solu.Remark
{
    partial class SoluRemarkViewer
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
            this.gbRemark = new System.Windows.Forms.GroupBox();
            this.rtbRemark = new System.Windows.Forms.RichTextBox();
            this.gbRemark.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRemark
            // 
            this.gbRemark.Controls.Add(this.rtbRemark);
            this.gbRemark.Location = new System.Drawing.Point(3, 4);
            this.gbRemark.Name = "gbRemark";
            this.gbRemark.Size = new System.Drawing.Size(476, 233);
            this.gbRemark.TabIndex = 3;
            this.gbRemark.TabStop = false;
            this.gbRemark.Text = "备注详细";
            // 
            // rtbRemark
            // 
            this.rtbRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbRemark.Location = new System.Drawing.Point(3, 17);
            this.rtbRemark.Name = "rtbRemark";
            this.rtbRemark.Size = new System.Drawing.Size(470, 213);
            this.rtbRemark.TabIndex = 0;
            this.rtbRemark.Text = "";
            this.rtbRemark.TextChanged += new System.EventHandler(this.rtbRemark_TextChanged);
            // 
            // SoluRemarkViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.gbRemark);
            this.Name = "SoluRemarkViewer";
            this.Size = new System.Drawing.Size(481, 240);
            this.gbRemark.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRemark;
        private System.Windows.Forms.RichTextBox rtbRemark;
    }
}
