namespace ChromatoCore.On
{
    partial class OnGraphDouble
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
            this.onGraphSingle1 = new ChromatoCore.On.OnGraphSingle();
            this.splitterGraph = new System.Windows.Forms.Splitter();
            this.onGraphSingle2 = new ChromatoCore.On.OnGraphSingle();
            this.SuspendLayout();
            // 
            // onGraphSingle1
            // 
            this.onGraphSingle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.onGraphSingle1.Location = new System.Drawing.Point(0, 0);
            this.onGraphSingle1.Name = "onGraphSingle1";
            this.onGraphSingle1.Size = new System.Drawing.Size(280, 166);
            this.onGraphSingle1.TabIndex = 0;
            // 
            // splitterGraph
            // 
            this.splitterGraph.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitterGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterGraph.Location = new System.Drawing.Point(0, 166);
            this.splitterGraph.Name = "splitterGraph";
            this.splitterGraph.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitterGraph.Size = new System.Drawing.Size(280, 3);
            this.splitterGraph.TabIndex = 29;
            this.splitterGraph.TabStop = false;
            // 
            // onGraphSingle2
            // 
            this.onGraphSingle2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.onGraphSingle2.Location = new System.Drawing.Point(0, 169);
            this.onGraphSingle2.Name = "onGraphSingle2";
            this.onGraphSingle2.Size = new System.Drawing.Size(280, 151);
            this.onGraphSingle2.TabIndex = 30;
            // 
            // OnGraphDouble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.onGraphSingle2);
            this.Controls.Add(this.splitterGraph);
            this.Controls.Add(this.onGraphSingle1);
            this.DoubleBuffered = true;
            this.Name = "OnGraphDouble";
            this.Size = new System.Drawing.Size(280, 320);
            this.ResumeLayout(false);

        }
        
        private OnGraphSingle onGraphSingle1;
        private System.Windows.Forms.Splitter splitterGraph;
        private OnGraphSingle onGraphSingle2;

        #endregion


    }
}
