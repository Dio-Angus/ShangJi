namespace ChromatoCore.On
{
    partial class OnGraphFour
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
            this.onGraphDouble1 = new ChromatoCore.On.OnGraphDouble();
            this.splitterGraph = new System.Windows.Forms.Splitter();
            this.onGraphDouble2 = new ChromatoCore.On.OnGraphDouble();
            this.SuspendLayout();
            // 
            // onGraphDouble1
            // 
            this.onGraphDouble1.Dock = System.Windows.Forms.DockStyle.Top;
            this.onGraphDouble1.Location = new System.Drawing.Point(0, 0);
            this.onGraphDouble1.Name = "onGraphDouble1";
            this.onGraphDouble1.Size = new System.Drawing.Size(412, 320);
            this.onGraphDouble1.TabIndex = 0;
            // 
            // splitterGraph
            // 
            this.splitterGraph.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitterGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterGraph.Location = new System.Drawing.Point(0, 320);
            this.splitterGraph.Name = "splitterGraph";
            this.splitterGraph.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitterGraph.Size = new System.Drawing.Size(412, 3);
            this.splitterGraph.TabIndex = 30;
            this.splitterGraph.TabStop = false;
            // 
            // onGraphDouble2
            // 
            this.onGraphDouble2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.onGraphDouble2.Location = new System.Drawing.Point(0, 323);
            this.onGraphDouble2.Name = "onGraphDouble2";
            this.onGraphDouble2.Size = new System.Drawing.Size(412, 327);
            this.onGraphDouble2.TabIndex = 31;
            // 
            // OnGraphFour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.onGraphDouble2);
            this.Controls.Add(this.splitterGraph);
            this.Controls.Add(this.onGraphDouble1);
            this.DoubleBuffered = true;
            this.Name = "OnGraphFour";
            this.Size = new System.Drawing.Size(412, 650);
            this.ResumeLayout(false);

        }

        #endregion

        private OnGraphDouble onGraphDouble1;
        private System.Windows.Forms.Splitter splitterGraph;
        private OnGraphDouble onGraphDouble2;

    }
}
