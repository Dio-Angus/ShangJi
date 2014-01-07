namespace ChromatoCore.Compare
{
    partial class CompareGraphViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareGraphViewer));
            this.tsGraphMain = new System.Windows.Forms.ToolStrip();
            this.tsBtnRestore = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHrizontal = new System.Windows.Forms.ToolStripButton();
            this.tsBtnVertical = new System.Windows.Forms.ToolStripButton();
            this.tsBtnShape = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMoveUp = new System.Windows.Forms.ToolStripButton();
            this.tsMoveDown = new System.Windows.Forms.ToolStripButton();
            this.tsMoveLeft = new System.Windows.Forms.ToolStripButton();
            this.tsMoveRight = new System.Windows.Forms.ToolStripButton();
            this.tsLeft = new System.Windows.Forms.ToolStrip();
            this.tsVolMaxUp = new System.Windows.Forms.ToolStripButton();
            this.tsVolMaxDown = new System.Windows.Forms.ToolStripButton();
            this.tsVolMinDown = new System.Windows.Forms.ToolStripButton();
            this.tsVolMinUp = new System.Windows.Forms.ToolStripButton();
            this.tsBottom = new System.Windows.Forms.ToolStrip();
            this.tsTimeMinDown = new System.Windows.Forms.ToolStripButton();
            this.tsTimeMinUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsTimeMaxUp = new System.Windows.Forms.ToolStripButton();
            this.tsTimeMaxDown = new System.Windows.Forms.ToolStripButton();
            this.axGraphOcx = new AxGRAPHOCXLib.AxGraphOcx();
            this.tsGraphMain.SuspendLayout();
            this.tsLeft.SuspendLayout();
            this.tsBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGraphOcx)).BeginInit();
            this.SuspendLayout();
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
            this.tsConfig,
            this.toolStripSeparator1,
            this.tsMoveUp,
            this.tsMoveDown,
            this.tsMoveLeft,
            this.tsMoveRight});
            this.tsGraphMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsGraphMain.Location = new System.Drawing.Point(0, 0);
            this.tsGraphMain.Name = "tsGraphMain";
            this.tsGraphMain.Size = new System.Drawing.Size(688, 39);
            this.tsGraphMain.TabIndex = 36;
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
            // tsConfig
            // 
            this.tsConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsConfig.Image = global::ChromatoCore.Properties.Resources.edit;
            this.tsConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsConfig.Name = "tsConfig";
            this.tsConfig.Size = new System.Drawing.Size(36, 36);
            this.tsConfig.Text = "配置";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
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
            // tsLeft
            // 
            this.tsLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVolMaxUp,
            this.tsVolMaxDown,
            this.tsVolMinDown,
            this.tsVolMinUp});
            this.tsLeft.Location = new System.Drawing.Point(0, 39);
            this.tsLeft.Name = "tsLeft";
            this.tsLeft.Size = new System.Drawing.Size(24, 207);
            this.tsLeft.TabIndex = 37;
            this.tsLeft.Text = "toolStrip1";
            // 
            // tsVolMaxUp
            // 
            this.tsVolMaxUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsVolMaxUp.Image = global::ChromatoCore.Properties.Resources.ARW03UP;
            this.tsVolMaxUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVolMaxUp.Name = "tsVolMaxUp";
            this.tsVolMaxUp.Size = new System.Drawing.Size(21, 20);
            this.tsVolMaxUp.Text = "最大值增加";
            // 
            // tsVolMaxDown
            // 
            this.tsVolMaxDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsVolMaxDown.Image = global::ChromatoCore.Properties.Resources.ARW03DN;
            this.tsVolMaxDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVolMaxDown.Name = "tsVolMaxDown";
            this.tsVolMaxDown.Size = new System.Drawing.Size(21, 20);
            this.tsVolMaxDown.Text = "最大值减少";
            // 
            // tsVolMinDown
            // 
            this.tsVolMinDown.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsVolMinDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsVolMinDown.Image = global::ChromatoCore.Properties.Resources.ARW03DNred;
            this.tsVolMinDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVolMinDown.Name = "tsVolMinDown";
            this.tsVolMinDown.Size = new System.Drawing.Size(21, 20);
            this.tsVolMinDown.Text = "最小值减少";
            // 
            // tsVolMinUp
            // 
            this.tsVolMinUp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsVolMinUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsVolMinUp.Image = global::ChromatoCore.Properties.Resources.ARW03UPred;
            this.tsVolMinUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVolMinUp.Name = "tsVolMinUp";
            this.tsVolMinUp.Size = new System.Drawing.Size(21, 20);
            this.tsVolMinUp.Text = "最小值增加";
            // 
            // tsBottom
            // 
            this.tsBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTimeMinDown,
            this.tsTimeMinUp,
            this.toolStripSeparator4,
            this.tsTimeMaxUp,
            this.tsTimeMaxDown});
            this.tsBottom.Location = new System.Drawing.Point(24, 221);
            this.tsBottom.Name = "tsBottom";
            this.tsBottom.Size = new System.Drawing.Size(664, 25);
            this.tsBottom.TabIndex = 38;
            this.tsBottom.Text = "toolStrip1";
            // 
            // tsTimeMinDown
            // 
            this.tsTimeMinDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsTimeMinDown.Image = global::ChromatoCore.Properties.Resources.ARW03LTred;
            this.tsTimeMinDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsTimeMinDown.Name = "tsTimeMinDown";
            this.tsTimeMinDown.Size = new System.Drawing.Size(23, 22);
            this.tsTimeMinDown.Text = "最小值减少";
            // 
            // tsTimeMinUp
            // 
            this.tsTimeMinUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsTimeMinUp.Image = global::ChromatoCore.Properties.Resources.ARW03RTred;
            this.tsTimeMinUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsTimeMinUp.Name = "tsTimeMinUp";
            this.tsTimeMinUp.Size = new System.Drawing.Size(23, 22);
            this.tsTimeMinUp.Text = "最小值增加";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsTimeMaxUp
            // 
            this.tsTimeMaxUp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsTimeMaxUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsTimeMaxUp.Image = global::ChromatoCore.Properties.Resources.ARW03RT;
            this.tsTimeMaxUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsTimeMaxUp.Name = "tsTimeMaxUp";
            this.tsTimeMaxUp.Size = new System.Drawing.Size(23, 22);
            this.tsTimeMaxUp.Text = "最大值增加";
            // 
            // tsTimeMaxDown
            // 
            this.tsTimeMaxDown.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsTimeMaxDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsTimeMaxDown.Image = global::ChromatoCore.Properties.Resources.ARW03LT;
            this.tsTimeMaxDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsTimeMaxDown.Name = "tsTimeMaxDown";
            this.tsTimeMaxDown.Size = new System.Drawing.Size(23, 22);
            this.tsTimeMaxDown.Text = "最大值减少";
            // 
            // axGraphOcx
            // 
            this.axGraphOcx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axGraphOcx.Location = new System.Drawing.Point(24, 39);
            this.axGraphOcx.Name = "axGraphOcx";
            this.axGraphOcx.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGraphOcx.OcxState")));
            this.axGraphOcx.Size = new System.Drawing.Size(664, 182);
            this.axGraphOcx.TabIndex = 39;
            // 
            // CompareGraphViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axGraphOcx);
            this.Controls.Add(this.tsBottom);
            this.Controls.Add(this.tsLeft);
            this.Controls.Add(this.tsGraphMain);
            this.Name = "CompareGraphViewer";
            this.Size = new System.Drawing.Size(688, 246);
            this.tsGraphMain.ResumeLayout(false);
            this.tsGraphMain.PerformLayout();
            this.tsLeft.ResumeLayout(false);
            this.tsLeft.PerformLayout();
            this.tsBottom.ResumeLayout(false);
            this.tsBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGraphOcx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsGraphMain;
        private System.Windows.Forms.ToolStripButton tsBtnRestore;
        private System.Windows.Forms.ToolStripButton tsBtnHrizontal;
        private System.Windows.Forms.ToolStripButton tsBtnVertical;
        private System.Windows.Forms.ToolStripButton tsBtnShape;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip tsLeft;
        private System.Windows.Forms.ToolStripButton tsVolMaxUp;
        private System.Windows.Forms.ToolStripButton tsVolMaxDown;
        private System.Windows.Forms.ToolStripButton tsVolMinUp;
        private System.Windows.Forms.ToolStripButton tsVolMinDown;
        private System.Windows.Forms.ToolStrip tsBottom;
        private System.Windows.Forms.ToolStripButton tsTimeMaxDown;
        private System.Windows.Forms.ToolStripButton tsTimeMaxUp;
        private System.Windows.Forms.ToolStripButton tsTimeMinDown;
        private System.Windows.Forms.ToolStripButton tsTimeMinUp;
        private AxGRAPHOCXLib.AxGraphOcx axGraphOcx;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsMoveUp;
        private System.Windows.Forms.ToolStripButton tsMoveDown;
        private System.Windows.Forms.ToolStripButton tsMoveLeft;
        private System.Windows.Forms.ToolStripButton tsMoveRight;
    }
}
