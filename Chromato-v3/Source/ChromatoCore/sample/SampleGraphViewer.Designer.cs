namespace ChromatoCore.sample
{
    partial class SampleGraphViewer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SampleGraphViewer));
            this.menuContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miFullScale = new System.Windows.Forms.ToolStripMenuItem();
            this.miHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.miVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.miShape = new System.Windows.Forms.ToolStripMenuItem();
            this.miExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsGraphMain = new System.Windows.Forms.ToolStrip();
            this.tsBtnRestore = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHrizontal = new System.Windows.Forms.ToolStripButton();
            this.tsBtnVertical = new System.Windows.Forms.ToolStripButton();
            this.tsBtnShape = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsExportBmp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.axGraphOcx = new AxGRAPHOCXLib.AxGraphOcx();
            this.menuContext.SuspendLayout();
            this.tsGraphMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGraphOcx)).BeginInit();
            this.SuspendLayout();
            // 
            // menuContext
            // 
            this.menuContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFullScale,
            this.miHorizontal,
            this.miVertical,
            this.miShape,
            this.miExport});
            this.menuContext.Name = "contextMenu";
            this.menuContext.Size = new System.Drawing.Size(155, 114);
            // 
            // miFullScale
            // 
            this.miFullScale.Name = "miFullScale";
            this.miFullScale.Size = new System.Drawing.Size(154, 22);
            this.miFullScale.Text = "全景";
            // 
            // miHorizontal
            // 
            this.miHorizontal.Name = "miHorizontal";
            this.miHorizontal.Size = new System.Drawing.Size(154, 22);
            this.miHorizontal.Text = "水平";
            // 
            // miVertical
            // 
            this.miVertical.Name = "miVertical";
            this.miVertical.Size = new System.Drawing.Size(154, 22);
            this.miVertical.Text = "垂直";
            // 
            // miShape
            // 
            this.miShape.Name = "miShape";
            this.miShape.Size = new System.Drawing.Size(154, 22);
            this.miShape.Text = "矩形";
            // 
            // miExport
            // 
            this.miExport.Name = "miExport";
            this.miExport.Size = new System.Drawing.Size(154, 22);
            this.miExport.Text = "导出为打印图形";
            // 
            // tsGraphMain
            // 
            this.tsGraphMain.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tsGraphMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsGraphMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnRestore,
            this.tsBtnHrizontal,
            this.tsBtnVertical,
            this.tsBtnShape,
            this.toolStripSeparator2,
            this.tsExportBmp,
            this.toolStripSeparator1});
            this.tsGraphMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsGraphMain.Location = new System.Drawing.Point(0, 0);
            this.tsGraphMain.Name = "tsGraphMain";
            this.tsGraphMain.Size = new System.Drawing.Size(631, 39);
            this.tsGraphMain.TabIndex = 37;
            this.tsGraphMain.Text = "toolStrip1";
            // 
            // tsBtnRestore
            // 
            this.tsBtnRestore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnRestore.Image = global::ChromatoCore.Properties.Resources.zoomFit;
            this.tsBtnRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRestore.Name = "tsBtnRestore";
            this.tsBtnRestore.Size = new System.Drawing.Size(36, 36);
            this.tsBtnRestore.Text = "复原";
            // 
            // tsBtnHrizontal
            // 
            this.tsBtnHrizontal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnHrizontal.Image = global::ChromatoCore.Properties.Resources.zoomInHori;
            this.tsBtnHrizontal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnHrizontal.Name = "tsBtnHrizontal";
            this.tsBtnHrizontal.Size = new System.Drawing.Size(36, 36);
            this.tsBtnHrizontal.Text = "水平放大";
            // 
            // tsBtnVertical
            // 
            this.tsBtnVertical.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnVertical.Image = global::ChromatoCore.Properties.Resources.zoomInVerti;
            this.tsBtnVertical.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnVertical.Name = "tsBtnVertical";
            this.tsBtnVertical.Size = new System.Drawing.Size(36, 36);
            this.tsBtnVertical.Text = "竖直放大";
            // 
            // tsBtnShape
            // 
            this.tsBtnShape.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnShape.Image = global::ChromatoCore.Properties.Resources.zoomInShape;
            this.tsBtnShape.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnShape.Name = "tsBtnShape";
            this.tsBtnShape.Size = new System.Drawing.Size(36, 36);
            this.tsBtnShape.Text = "矩形放大";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsExportBmp
            // 
            this.tsExportBmp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsExportBmp.Image = global::ChromatoCore.Properties.Resources.saveas;
            this.tsExportBmp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExportBmp.Name = "tsExportBmp";
            this.tsExportBmp.Size = new System.Drawing.Size(36, 36);
            this.tsExportBmp.Text = "导出当前图形为打印图形";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // axGraphOcx
            // 
            this.axGraphOcx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axGraphOcx.Location = new System.Drawing.Point(0, 39);
            this.axGraphOcx.Name = "axGraphOcx";
            this.axGraphOcx.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGraphOcx.OcxState")));
            this.axGraphOcx.Size = new System.Drawing.Size(631, 264);
            this.axGraphOcx.TabIndex = 38;
            // 
            // SampleGraphViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axGraphOcx);
            this.Controls.Add(this.tsGraphMain);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Name = "SampleGraphViewer";
            this.Size = new System.Drawing.Size(631, 303);
            this.menuContext.ResumeLayout(false);
            this.tsGraphMain.ResumeLayout(false);
            this.tsGraphMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGraphOcx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip menuContext;
        private System.Windows.Forms.ToolStripMenuItem miFullScale;
        private System.Windows.Forms.ToolStripMenuItem miHorizontal;
        private System.Windows.Forms.ToolStripMenuItem miVertical;
        private System.Windows.Forms.ToolStripMenuItem miShape;
        private System.Windows.Forms.ToolStripMenuItem miExport;
        private System.Windows.Forms.ToolStrip tsGraphMain;
        private System.Windows.Forms.ToolStripButton tsBtnRestore;
        private System.Windows.Forms.ToolStripButton tsBtnHrizontal;
        private System.Windows.Forms.ToolStripButton tsBtnVertical;
        private System.Windows.Forms.ToolStripButton tsBtnShape;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsExportBmp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private AxGRAPHOCXLib.AxGraphOcx axGraphOcx;
    }
}
