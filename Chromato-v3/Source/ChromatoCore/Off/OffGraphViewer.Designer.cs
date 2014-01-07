namespace ChromatoCore.Off
{
    partial class OffGraphViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OffGraphViewer));
            this.menuContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemFullScale = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemShape = new System.Windows.Forms.ToolStripMenuItem();
            this.tsGraphMain = new System.Windows.Forms.ToolStrip();
            this.tsBtnAnaly = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnManulBaseLine = new System.Windows.Forms.ToolStripButton();
            this.tsBtnVerticalDivide = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDealTail = new System.Windows.Forms.ToolStripButton();
            this.tsButtonDeletePeak = new System.Windows.Forms.ToolStripButton();
            this.tsBtnReserveNegetivePeak = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnRestore = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHrizontal = new System.Windows.Forms.ToolStripButton();
            this.tsBtnVertical = new System.Windows.Forms.ToolStripButton();
            this.tsBtnShape = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnExport = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSum = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMoveUp = new System.Windows.Forms.ToolStripButton();
            this.tsMoveDown = new System.Windows.Forms.ToolStripButton();
            this.tsMoveLeft = new System.Windows.Forms.ToolStripButton();
            this.tsMoveRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tsArrow = new System.Windows.Forms.ToolStrip();
            this.tsBtnMaxMoveUp = new System.Windows.Forms.ToolStripButton();
            this.tsBtnMaxMoveDown = new System.Windows.Forms.ToolStripButton();
            this.tsBtnMinMoveDown = new System.Windows.Forms.ToolStripButton();
            this.tsBtnMinMoveUp = new System.Windows.Forms.ToolStripButton();
            this.axGraphOcx = new AxGRAPHOCXLib.AxGraphOcx();
            this.menuContext.SuspendLayout();
            this.tsGraphMain.SuspendLayout();
            this.tsArrow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGraphOcx)).BeginInit();
            this.SuspendLayout();
            // 
            // menuContext
            // 
            this.menuContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFullScale,
            this.MenuItemHorizontal,
            this.MenuItemVertical,
            this.MenuItemShape});
            this.menuContext.Name = "contextMenu";
            this.menuContext.Size = new System.Drawing.Size(95, 92);
            // 
            // MenuItemFullScale
            // 
            this.MenuItemFullScale.Name = "MenuItemFullScale";
            this.MenuItemFullScale.Size = new System.Drawing.Size(94, 22);
            this.MenuItemFullScale.Text = "全景";
            this.MenuItemFullScale.Click += new System.EventHandler(this.MenuItemFullScale_Click);
            // 
            // MenuItemHorizontal
            // 
            this.MenuItemHorizontal.Name = "MenuItemHorizontal";
            this.MenuItemHorizontal.Size = new System.Drawing.Size(94, 22);
            this.MenuItemHorizontal.Text = "水平";
            this.MenuItemHorizontal.Click += new System.EventHandler(this.MenuItemHorizontal_Click);
            // 
            // MenuItemVertical
            // 
            this.MenuItemVertical.Name = "MenuItemVertical";
            this.MenuItemVertical.Size = new System.Drawing.Size(94, 22);
            this.MenuItemVertical.Text = "垂直";
            this.MenuItemVertical.Click += new System.EventHandler(this.MenuItemVertical_Click);
            // 
            // MenuItemShape
            // 
            this.MenuItemShape.Name = "MenuItemShape";
            this.MenuItemShape.Size = new System.Drawing.Size(94, 22);
            this.MenuItemShape.Text = "矩形";
            this.MenuItemShape.Click += new System.EventHandler(this.MenuItemShape_Click);
            // 
            // tsGraphMain
            // 
            this.tsGraphMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsGraphMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAnaly,
            this.tsBtnSeparator1,
            this.tsBtnManulBaseLine,
            this.tsBtnVerticalDivide,
            this.tsBtnDealTail,
            this.tsButtonDeletePeak,
            this.tsBtnReserveNegetivePeak,
            this.tsBtnSeparator2,
            this.tsBtnRestore,
            this.tsBtnHrizontal,
            this.tsBtnVertical,
            this.tsBtnShape,
            this.toolStripSeparator1,
            this.tsBtnExport,
            this.tsBtnSum,
            this.toolStripSeparator2,
            this.tsBtnUpdate,
            this.toolStripSeparator3,
            this.tsMoveUp,
            this.tsMoveDown,
            this.tsMoveLeft,
            this.tsMoveRight});
            this.tsGraphMain.Location = new System.Drawing.Point(0, 0);
            this.tsGraphMain.Name = "tsGraphMain";
            this.tsGraphMain.Size = new System.Drawing.Size(634, 39);
            this.tsGraphMain.TabIndex = 34;
            this.tsGraphMain.Text = "toolStrip1";
            // 
            // tsBtnAnaly
            // 
            this.tsBtnAnaly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAnaly.Image = global::ChromatoCore.Properties.Resources.analysis;
            this.tsBtnAnaly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAnaly.Name = "tsBtnAnaly";
            this.tsBtnAnaly.Size = new System.Drawing.Size(36, 36);
            this.tsBtnAnaly.Text = "toolStripButton3";
            // 
            // tsBtnSeparator1
            // 
            this.tsBtnSeparator1.Name = "tsBtnSeparator1";
            this.tsBtnSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsBtnManulBaseLine
            // 
            this.tsBtnManulBaseLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnManulBaseLine.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnManulBaseLine.Image")));
            this.tsBtnManulBaseLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnManulBaseLine.Name = "tsBtnManulBaseLine";
            this.tsBtnManulBaseLine.Size = new System.Drawing.Size(36, 36);
            this.tsBtnManulBaseLine.Text = "toolStripButton4";
            this.tsBtnManulBaseLine.Click += new System.EventHandler(this.tsBtnManulBaseLine_Click);
            // 
            // tsBtnVerticalDivide
            // 
            this.tsBtnVerticalDivide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnVerticalDivide.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnVerticalDivide.Image")));
            this.tsBtnVerticalDivide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnVerticalDivide.Name = "tsBtnVerticalDivide";
            this.tsBtnVerticalDivide.Size = new System.Drawing.Size(36, 36);
            this.tsBtnVerticalDivide.Text = "toolStripButton3";
            this.tsBtnVerticalDivide.Click += new System.EventHandler(this.tsBtnVerticalDivide_Click);
            // 
            // tsBtnDealTail
            // 
            this.tsBtnDealTail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDealTail.Image = global::ChromatoCore.Properties.Resources.tail;
            this.tsBtnDealTail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDealTail.Name = "tsBtnDealTail";
            this.tsBtnDealTail.Size = new System.Drawing.Size(36, 36);
            this.tsBtnDealTail.Text = "toolStripButton4";
            this.tsBtnDealTail.Click += new System.EventHandler(this.tsBtnDealTail_Click);
            // 
            // tsButtonDeletePeak
            // 
            this.tsButtonDeletePeak.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonDeletePeak.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonDeletePeak.Image")));
            this.tsButtonDeletePeak.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonDeletePeak.Name = "tsButtonDeletePeak";
            this.tsButtonDeletePeak.Size = new System.Drawing.Size(36, 36);
            this.tsButtonDeletePeak.Text = "toolStripButton5";
            this.tsButtonDeletePeak.Click += new System.EventHandler(this.tsButtonDeletePeak_Click);
            // 
            // tsBtnReserveNegetivePeak
            // 
            this.tsBtnReserveNegetivePeak.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnReserveNegetivePeak.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnReserveNegetivePeak.Image")));
            this.tsBtnReserveNegetivePeak.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnReserveNegetivePeak.Name = "tsBtnReserveNegetivePeak";
            this.tsBtnReserveNegetivePeak.Size = new System.Drawing.Size(36, 36);
            this.tsBtnReserveNegetivePeak.Text = "toolStripButton6";
            this.tsBtnReserveNegetivePeak.Click += new System.EventHandler(this.tsBtnReserveNegetivePeak_Click);
            // 
            // tsBtnSeparator2
            // 
            this.tsBtnSeparator2.Name = "tsBtnSeparator2";
            this.tsBtnSeparator2.Size = new System.Drawing.Size(6, 39);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsBtnExport
            // 
            this.tsBtnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnExport.Image = global::ChromatoCore.Properties.Resources.ExportCsv;
            this.tsBtnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExport.Name = "tsBtnExport";
            this.tsBtnExport.Size = new System.Drawing.Size(36, 36);
            this.tsBtnExport.Text = "导出";
            // 
            // tsBtnSum
            // 
            this.tsBtnSum.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSum.Image = global::ChromatoCore.Properties.Resources.gather;
            this.tsBtnSum.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSum.Name = "tsBtnSum";
            this.tsBtnSum.Size = new System.Drawing.Size(36, 36);
            this.tsBtnSum.Text = "汇总";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsBtnUpdate
            // 
            this.tsBtnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnUpdate.Image = global::ChromatoCore.Properties.Resources.refresh;
            this.tsBtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnUpdate.Name = "tsBtnUpdate";
            this.tsBtnUpdate.Size = new System.Drawing.Size(36, 36);
            this.tsBtnUpdate.Text = "设置更新";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // tsMoveUp
            // 
            this.tsMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsMoveUp.Image = global::ChromatoCore.Properties.Resources.ARW03UP;
            this.tsMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMoveUp.Name = "tsMoveUp";
            this.tsMoveUp.Size = new System.Drawing.Size(36, 36);
            this.tsMoveUp.Text = "向上移动";
            // 
            // tsMoveDown
            // 
            this.tsMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsMoveDown.Image = global::ChromatoCore.Properties.Resources.ARW03DN;
            this.tsMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMoveDown.Name = "tsMoveDown";
            this.tsMoveDown.Size = new System.Drawing.Size(36, 36);
            this.tsMoveDown.Text = "向下移动";
            // 
            // tsMoveLeft
            // 
            this.tsMoveLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsMoveLeft.Image = global::ChromatoCore.Properties.Resources.ARW03LT;
            this.tsMoveLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMoveLeft.Name = "tsMoveLeft";
            this.tsMoveLeft.Size = new System.Drawing.Size(36, 36);
            this.tsMoveLeft.Text = "向左移动";
            // 
            // tsMoveRight
            // 
            this.tsMoveRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsMoveRight.Image = global::ChromatoCore.Properties.Resources.ARW03RT;
            this.tsMoveRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMoveRight.Name = "tsMoveRight";
            this.tsMoveRight.Size = new System.Drawing.Size(36, 36);
            this.tsMoveRight.Text = "向右移动";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // tsArrow
            // 
            this.tsArrow.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsArrow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnMaxMoveUp,
            this.tsBtnMaxMoveDown,
            this.tsBtnMinMoveDown,
            this.tsBtnMinMoveUp});
            this.tsArrow.Location = new System.Drawing.Point(0, 39);
            this.tsArrow.Name = "tsArrow";
            this.tsArrow.Size = new System.Drawing.Size(24, 314);
            this.tsArrow.TabIndex = 37;
            this.tsArrow.Text = "toolStrip1";
            // 
            // tsBtnMaxMoveUp
            // 
            this.tsBtnMaxMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnMaxMoveUp.Image = global::ChromatoCore.Properties.Resources.ARW03UP;
            this.tsBtnMaxMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnMaxMoveUp.Name = "tsBtnMaxMoveUp";
            this.tsBtnMaxMoveUp.Size = new System.Drawing.Size(21, 20);
            this.tsBtnMaxMoveUp.Text = "最大值增加";
            // 
            // tsBtnMaxMoveDown
            // 
            this.tsBtnMaxMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnMaxMoveDown.Image = global::ChromatoCore.Properties.Resources.ARW03DN;
            this.tsBtnMaxMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnMaxMoveDown.Name = "tsBtnMaxMoveDown";
            this.tsBtnMaxMoveDown.Size = new System.Drawing.Size(21, 20);
            this.tsBtnMaxMoveDown.Text = "最大值减少";
            // 
            // tsBtnMinMoveDown
            // 
            this.tsBtnMinMoveDown.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnMinMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnMinMoveDown.Image = global::ChromatoCore.Properties.Resources.ARW03DNred;
            this.tsBtnMinMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnMinMoveDown.Name = "tsBtnMinMoveDown";
            this.tsBtnMinMoveDown.Size = new System.Drawing.Size(21, 20);
            this.tsBtnMinMoveDown.Text = "最小值减少";
            // 
            // tsBtnMinMoveUp
            // 
            this.tsBtnMinMoveUp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnMinMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnMinMoveUp.Image = global::ChromatoCore.Properties.Resources.ARW03UPred;
            this.tsBtnMinMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnMinMoveUp.Name = "tsBtnMinMoveUp";
            this.tsBtnMinMoveUp.Size = new System.Drawing.Size(21, 20);
            this.tsBtnMinMoveUp.Text = "最小值增加";
            // 
            // axGraphOcx
            // 
            this.axGraphOcx.Location = new System.Drawing.Point(24, 39);
            this.axGraphOcx.Name = "axGraphOcx";
            this.axGraphOcx.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGraphOcx.OcxState")));
            this.axGraphOcx.Size = new System.Drawing.Size(527, 253);
            this.axGraphOcx.TabIndex = 38;
            // 
            // OffGraphViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axGraphOcx);
            this.Controls.Add(this.tsArrow);
            this.Controls.Add(this.tsGraphMain);
            this.Name = "OffGraphViewer";
            this.Size = new System.Drawing.Size(634, 353);
            this.menuContext.ResumeLayout(false);
            this.tsGraphMain.ResumeLayout(false);
            this.tsGraphMain.PerformLayout();
            this.tsArrow.ResumeLayout(false);
            this.tsArrow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGraphOcx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip menuContext;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFullScale;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHorizontal;
        private System.Windows.Forms.ToolStripMenuItem MenuItemVertical;
        private System.Windows.Forms.ToolStripMenuItem MenuItemShape;

        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStrip tsGraphMain;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton tsBtnAnaly;
        private System.Windows.Forms.ToolStripButton tsBtnManulBaseLine;
        private System.Windows.Forms.ToolStripSeparator tsBtnSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnVerticalDivide;
        private System.Windows.Forms.ToolStripButton tsBtnDealTail;
        private System.Windows.Forms.ToolStripButton tsButtonDeletePeak;
        private System.Windows.Forms.ToolStripButton tsBtnReserveNegetivePeak;
        private System.Windows.Forms.ToolStripSeparator tsBtnSeparator2;
        private System.Windows.Forms.ToolStripButton tsBtnRestore;
        private System.Windows.Forms.ToolStripButton tsBtnHrizontal;
        private System.Windows.Forms.ToolStripButton tsBtnVertical;
        private System.Windows.Forms.ToolStripButton tsBtnShape;
        private System.Windows.Forms.ToolStripButton tsBtnUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnSum;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsMoveUp;
        private System.Windows.Forms.ToolStripButton tsMoveDown;
        private System.Windows.Forms.ToolStripButton tsMoveLeft;
        private System.Windows.Forms.ToolStripButton tsMoveRight;
        private System.Windows.Forms.ToolStrip tsArrow;
        private System.Windows.Forms.ToolStripButton tsBtnMaxMoveUp;
        private System.Windows.Forms.ToolStripButton tsBtnMaxMoveDown;
        private System.Windows.Forms.ToolStripButton tsBtnMinMoveUp;
        private System.Windows.Forms.ToolStripButton tsBtnMinMoveDown;
        private AxGRAPHOCXLib.AxGraphOcx axGraphOcx;
        private System.Windows.Forms.ToolStripButton tsBtnExport;
    }
}
