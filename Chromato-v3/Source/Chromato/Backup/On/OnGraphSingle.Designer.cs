namespace ChromatoCore.On
{
    partial class OnGraphSingle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnGraphSingle));
            this.tsGraphMain = new System.Windows.Forms.ToolStrip();
            this.tsChannelName = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnMaxMoveUp = new System.Windows.Forms.ToolStripButton();
            this.tsBtnMaxMoveDown = new System.Windows.Forms.ToolStripButton();
            this.tsBtnMinMoveDown = new System.Windows.Forms.ToolStripButton();
            this.tsBtnMinMoveUp = new System.Windows.Forms.ToolStripButton();
            this.tsToolBar = new System.Windows.Forms.ToolStrip();
            this.tsDetector = new System.Windows.Forms.ToolStripLabel();
            this.tsLabel = new System.Windows.Forms.ToolStripLabel();
            this.tsVoltage = new System.Windows.Forms.ToolStripTextBox();
            this.tsLabelAutoSlope = new System.Windows.Forms.ToolStripLabel();
            this.tsMoment = new System.Windows.Forms.ToolStripLabel();
            this.axGraphOcx = new AxGRAPHOCXLib.AxGraphOcx();
            this.tsGraphMain.SuspendLayout();
            this.tsToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGraphOcx)).BeginInit();
            this.SuspendLayout();
            // 
            // tsGraphMain
            // 
            this.tsGraphMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsGraphMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsChannelName,
            this.tsBtnMaxMoveUp,
            this.tsBtnMaxMoveDown,
            this.tsBtnMinMoveDown,
            this.tsBtnMinMoveUp});
            this.tsGraphMain.Location = new System.Drawing.Point(0, 0);
            this.tsGraphMain.Name = "tsGraphMain";
            this.tsGraphMain.Size = new System.Drawing.Size(24, 188);
            this.tsGraphMain.TabIndex = 36;
            this.tsGraphMain.Text = "toolStrip1";
            // 
            // tsChannelName
            // 
            this.tsChannelName.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tsChannelName.ForeColor = System.Drawing.Color.Fuchsia;
            this.tsChannelName.Name = "tsChannelName";
            this.tsChannelName.Size = new System.Drawing.Size(21, 27);
            this.tsChannelName.Text = "Tcd";
            this.tsChannelName.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
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
            // tsToolBar
            // 
            this.tsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDetector,
            this.tsLabel,
            this.tsVoltage,
            this.tsLabelAutoSlope,
            this.tsMoment});
            this.tsToolBar.Location = new System.Drawing.Point(24, 0);
            this.tsToolBar.Name = "tsToolBar";
            this.tsToolBar.Size = new System.Drawing.Size(525, 25);
            this.tsToolBar.TabIndex = 38;
            this.tsToolBar.Text = "toolStrip1";
            // 
            // tsDetector1
            // 
            this.tsDetector.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsDetector.ForeColor = System.Drawing.Color.DarkGreen;
            this.tsDetector.Name = "tsDetector1";
            this.tsDetector.Size = new System.Drawing.Size(44, 22);
            this.tsDetector.Text = "已安装";
            // 
            // tsLabel
            // 
            this.tsLabel.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsLabel.ForeColor = System.Drawing.Color.DarkViolet;
            this.tsLabel.Name = "tsLabel";
            this.tsLabel.Size = new System.Drawing.Size(45, 22);
            this.tsLabel.Text = "状态1:";
            // 
            // tsVoltage
            // 
            this.tsVoltage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsVoltage.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.tsVoltage.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tsVoltage.ForeColor = System.Drawing.Color.Lime;
            this.tsVoltage.Name = "tsVoltage";
            this.tsVoltage.ReadOnly = true;
            this.tsVoltage.Size = new System.Drawing.Size(140, 25);
            this.tsVoltage.Text = "123";
            this.tsVoltage.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tsLabelAutoSlope
            // 
            this.tsLabelAutoSlope.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsLabelAutoSlope.ForeColor = System.Drawing.Color.Green;
            this.tsLabelAutoSlope.Name = "tsLabelAutoSlope";
            this.tsLabelAutoSlope.Size = new System.Drawing.Size(35, 22);
            this.tsLabelAutoSlope.Text = "斜率1";
            this.tsLabelAutoSlope.Visible = false;
            // 
            // tsMoment
            // 
            this.tsMoment.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsMoment.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tsMoment.ForeColor = System.Drawing.Color.Red;
            this.tsMoment.Name = "tsMoment";
            this.tsMoment.Size = new System.Drawing.Size(26, 22);
            this.tsMoment.Text = "min";
            // 
            // axGraphOcx
            // 
            this.axGraphOcx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axGraphOcx.Location = new System.Drawing.Point(24, 25);
            this.axGraphOcx.Name = "axGraphOcx";
            this.axGraphOcx.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGraphOcx.OcxState")));
            this.axGraphOcx.Size = new System.Drawing.Size(525, 163);
            this.axGraphOcx.TabIndex = 39;
            // 
            // OnGraphSingle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axGraphOcx);
            this.Controls.Add(this.tsToolBar);
            this.Controls.Add(this.tsGraphMain);
            this.DoubleBuffered = true;
            this.Name = "OnGraphSingle";
            this.Size = new System.Drawing.Size(549, 188);
            this.tsGraphMain.ResumeLayout(false);
            this.tsGraphMain.PerformLayout();
            this.tsToolBar.ResumeLayout(false);
            this.tsToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGraphOcx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsGraphMain;
        private System.Windows.Forms.ToolStripButton tsBtnMaxMoveUp;
        private System.Windows.Forms.ToolStripButton tsBtnMaxMoveDown;
        private System.Windows.Forms.ToolStripButton tsBtnMinMoveUp;
        private System.Windows.Forms.ToolStripButton tsBtnMinMoveDown;
        private System.Windows.Forms.ToolStripLabel tsChannelName;
        private System.Windows.Forms.ToolStrip tsToolBar;
        private AxGRAPHOCXLib.AxGraphOcx axGraphOcx;
        private System.Windows.Forms.ToolStripLabel tsDetector;
        private System.Windows.Forms.ToolStripLabel tsLabel;
        private System.Windows.Forms.ToolStripLabel tsLabelAutoSlope;
        private System.Windows.Forms.ToolStripTextBox tsVoltage;
        private System.Windows.Forms.ToolStripLabel tsMoment;
    }
}
