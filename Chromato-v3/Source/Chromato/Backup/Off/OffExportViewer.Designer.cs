namespace ChromatoCore.Off
{
    partial class OffExportViewer
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
            this.gbItem = new System.Windows.Forms.GroupBox();
            this.cbx = new System.Windows.Forms.CheckBox();
            this.cbxResult = new System.Windows.Forms.CheckBox();
            this.cbxPlot = new System.Windows.Forms.CheckBox();
            this.gbChoice = new System.Windows.Forms.GroupBox();
            this.rbAia = new System.Windows.Forms.RadioButton();
            this.rbCsv = new System.Windows.Forms.RadioButton();
            this.rbExcel = new System.Windows.Forms.RadioButton();
            this.cbxSolution = new System.Windows.Forms.CheckBox();
            this.gbItem.SuspendLayout();
            this.gbChoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbItem
            // 
            this.gbItem.Controls.Add(this.cbxSolution);
            this.gbItem.Controls.Add(this.cbx);
            this.gbItem.Controls.Add(this.cbxResult);
            this.gbItem.Controls.Add(this.cbxPlot);
            this.gbItem.Location = new System.Drawing.Point(14, 14);
            this.gbItem.Name = "gbItem";
            this.gbItem.Size = new System.Drawing.Size(108, 129);
            this.gbItem.TabIndex = 0;
            this.gbItem.TabStop = false;
            this.gbItem.Text = "导出项目";
            // 
            // cbx
            // 
            this.cbx.AutoSize = true;
            this.cbx.Enabled = false;
            this.cbx.Location = new System.Drawing.Point(17, 97);
            this.cbx.Name = "cbx";
            this.cbx.Size = new System.Drawing.Size(72, 16);
            this.cbx.TabIndex = 2;
            this.cbx.Text = "标准方差";
            this.cbx.UseVisualStyleBackColor = true;
            // 
            // cbxResult
            // 
            this.cbxResult.AutoSize = true;
            this.cbxResult.Location = new System.Drawing.Point(17, 51);
            this.cbxResult.Name = "cbxResult";
            this.cbxResult.Size = new System.Drawing.Size(72, 16);
            this.cbxResult.TabIndex = 1;
            this.cbxResult.Text = "分析结果";
            this.cbxResult.UseVisualStyleBackColor = true;
            // 
            // cbxPlot
            // 
            this.cbxPlot.AutoSize = true;
            this.cbxPlot.Location = new System.Drawing.Point(17, 74);
            this.cbxPlot.Name = "cbxPlot";
            this.cbxPlot.Size = new System.Drawing.Size(72, 16);
            this.cbxPlot.TabIndex = 0;
            this.cbxPlot.Text = "谱图数据";
            this.cbxPlot.UseVisualStyleBackColor = true;
            // 
            // gbChoice
            // 
            this.gbChoice.Controls.Add(this.rbAia);
            this.gbChoice.Controls.Add(this.rbCsv);
            this.gbChoice.Controls.Add(this.rbExcel);
            this.gbChoice.Location = new System.Drawing.Point(137, 14);
            this.gbChoice.Name = "gbChoice";
            this.gbChoice.Size = new System.Drawing.Size(151, 129);
            this.gbChoice.TabIndex = 1;
            this.gbChoice.TabStop = false;
            this.gbChoice.Text = "导出方式";
            // 
            // rbAia
            // 
            this.rbAia.AutoSize = true;
            this.rbAia.Location = new System.Drawing.Point(17, 76);
            this.rbAia.Name = "rbAia";
            this.rbAia.Size = new System.Drawing.Size(102, 16);
            this.rbAia.TabIndex = 2;
            this.rbAia.TabStop = true;
            this.rbAia.Text = "保存为AIA格式";
            this.rbAia.UseVisualStyleBackColor = true;
            this.rbAia.CheckedChanged += new System.EventHandler(this.rbAia_CheckedChanged);
            // 
            // rbCsv
            // 
            this.rbCsv.AutoSize = true;
            this.rbCsv.Location = new System.Drawing.Point(17, 52);
            this.rbCsv.Name = "rbCsv";
            this.rbCsv.Size = new System.Drawing.Size(103, 16);
            this.rbCsv.TabIndex = 1;
            this.rbCsv.TabStop = true;
            this.rbCsv.Text = "保存为Csv格式";
            this.rbCsv.UseVisualStyleBackColor = true;
            this.rbCsv.CheckedChanged += new System.EventHandler(this.rbCsv_CheckedChanged);
            // 
            // rbExcel
            // 
            this.rbExcel.AutoSize = true;
            this.rbExcel.Location = new System.Drawing.Point(17, 29);
            this.rbExcel.Name = "rbExcel";
            this.rbExcel.Size = new System.Drawing.Size(111, 16);
            this.rbExcel.TabIndex = 0;
            this.rbExcel.TabStop = true;
            this.rbExcel.Text = "保存到Excel格式";
            this.rbExcel.UseVisualStyleBackColor = true;
            this.rbExcel.CheckedChanged += new System.EventHandler(this.rbExcel_CheckedChanged);
            // 
            // cbxSolution
            // 
            this.cbxSolution.AutoSize = true;
            this.cbxSolution.Location = new System.Drawing.Point(17, 29);
            this.cbxSolution.Name = "cbxSolution";
            this.cbxSolution.Size = new System.Drawing.Size(72, 16);
            this.cbxSolution.TabIndex = 3;
            this.cbxSolution.Text = "分析方案";
            this.cbxSolution.UseVisualStyleBackColor = true;
            // 
            // OffExportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.gbChoice);
            this.Controls.Add(this.gbItem);
            this.Name = "OffExportViewer";
            this.Size = new System.Drawing.Size(477, 308);
            this.gbItem.ResumeLayout(false);
            this.gbItem.PerformLayout();
            this.gbChoice.ResumeLayout(false);
            this.gbChoice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbItem;
        private System.Windows.Forms.CheckBox cbxResult;
        private System.Windows.Forms.CheckBox cbxPlot;
        private System.Windows.Forms.GroupBox gbChoice;
        private System.Windows.Forms.RadioButton rbAia;
        private System.Windows.Forms.RadioButton rbCsv;
        private System.Windows.Forms.RadioButton rbExcel;
        private System.Windows.Forms.CheckBox cbx;
        private System.Windows.Forms.CheckBox cbxSolution;
    }
}
