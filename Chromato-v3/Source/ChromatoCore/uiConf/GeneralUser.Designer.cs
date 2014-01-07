namespace ChromatoCore.uiConf
{
    partial class GeneralUser
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBkColor = new System.Windows.Forms.Label();
            this.colorDlgBK = new System.Windows.Forms.ColorDialog();
            this.numUDSampleRate = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numUDMoveUnit = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblArrowColor = new System.Windows.Forms.Label();
            this.cbxLog = new System.Windows.Forms.CheckBox();
            this.gbCursorStyle = new System.Windows.Forms.GroupBox();
            this.rbBig = new System.Windows.Forms.RadioButton();
            this.rbSmall = new System.Windows.Forms.RadioButton();
            this.cbxOpenArrow = new System.Windows.Forms.CheckBox();
            this.gbArrow = new System.Windows.Forms.GroupBox();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbScanPeriod = new System.Windows.Forms.ComboBox();
            this.lblScanPeriod = new System.Windows.Forms.Label();
            this.cbxAutoName = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDgvBackColor = new System.Windows.Forms.Label();
            this.cmbPeakSolution = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbLinkObject = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbShowChannel = new System.Windows.Forms.GroupBox();
            this.cbxSyn = new System.Windows.Forms.CheckBox();
            this.cbxFid2 = new System.Windows.Forms.CheckBox();
            this.cbxFid1 = new System.Windows.Forms.CheckBox();
            this.cbxTcd2 = new System.Windows.Forms.CheckBox();
            this.cbxTcd1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUDSampleRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDMoveUnit)).BeginInit();
            this.gbCursorStyle.SuspendLayout();
            this.gbArrow.SuspendLayout();
            this.gbGeneral.SuspendLayout();
            this.gbShowChannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBkColor
            // 
            this.lblBkColor.AutoSize = true;
            this.lblBkColor.Location = new System.Drawing.Point(87, 19);
            this.lblBkColor.Name = "lblBkColor";
            this.lblBkColor.Size = new System.Drawing.Size(11, 12);
            this.lblBkColor.TabIndex = 56;
            this.lblBkColor.Text = "...";
            this.lblBkColor.Click += new System.EventHandler(this.lblBkColor_Click);
            // 
            // numUDSampleRate
            // 
            this.numUDSampleRate.Location = new System.Drawing.Point(252, 17);
            this.numUDSampleRate.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUDSampleRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDSampleRate.Name = "numUDSampleRate";
            this.numUDSampleRate.Size = new System.Drawing.Size(58, 19);
            this.numUDSampleRate.TabIndex = 67;
            this.numUDSampleRate.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUDSampleRate.ValueChanged += new System.EventHandler(this.numUDSampleRate_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 12);
            this.label6.TabIndex = 66;
            this.label6.Text = "采样频率:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 68;
            this.label1.Text = "图形背景色:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 69;
            this.label2.Text = "(1,50)赫兹";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 72;
            this.label3.Text = "(1,20)像素";
            // 
            // numUDMoveUnit
            // 
            this.numUDMoveUnit.Location = new System.Drawing.Point(252, 39);
            this.numUDMoveUnit.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUDMoveUnit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDMoveUnit.Name = "numUDMoveUnit";
            this.numUDMoveUnit.Size = new System.Drawing.Size(58, 19);
            this.numUDMoveUnit.TabIndex = 71;
            this.numUDMoveUnit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUDMoveUnit.ValueChanged += new System.EventHandler(this.numUDMoveUnit_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 12);
            this.label4.TabIndex = 70;
            this.label4.Text = "移动单位:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 12);
            this.label5.TabIndex = 74;
            this.label5.Text = "颜色:";
            // 
            // lblArrowColor
            // 
            this.lblArrowColor.AutoSize = true;
            this.lblArrowColor.Location = new System.Drawing.Point(67, 22);
            this.lblArrowColor.Name = "lblArrowColor";
            this.lblArrowColor.Size = new System.Drawing.Size(64, 12);
            this.lblArrowColor.TabIndex = 73;
            this.lblArrowColor.Text = "ArrowColor:";
            this.lblArrowColor.Click += new System.EventHandler(this.lblArrowColor_Click);
            // 
            // cbxLog
            // 
            this.cbxLog.AutoSize = true;
            this.cbxLog.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxLog.Location = new System.Drawing.Point(191, 64);
            this.cbxLog.Name = "cbxLog";
            this.cbxLog.Size = new System.Drawing.Size(86, 16);
            this.cbxLog.TabIndex = 76;
            this.cbxLog.Text = "写入日志:   ";
            this.cbxLog.UseVisualStyleBackColor = true;
            // 
            // gbCursorStyle
            // 
            this.gbCursorStyle.Controls.Add(this.rbBig);
            this.gbCursorStyle.Controls.Add(this.rbSmall);
            this.gbCursorStyle.Location = new System.Drawing.Point(14, 65);
            this.gbCursorStyle.Name = "gbCursorStyle";
            this.gbCursorStyle.Size = new System.Drawing.Size(111, 41);
            this.gbCursorStyle.TabIndex = 78;
            this.gbCursorStyle.TabStop = false;
            this.gbCursorStyle.Text = "大小";
            // 
            // rbBig
            // 
            this.rbBig.AutoSize = true;
            this.rbBig.Location = new System.Drawing.Point(63, 20);
            this.rbBig.Name = "rbBig";
            this.rbBig.Size = new System.Drawing.Size(35, 16);
            this.rbBig.TabIndex = 1;
            this.rbBig.TabStop = true;
            this.rbBig.Text = "大";
            this.rbBig.UseVisualStyleBackColor = true;
            this.rbBig.CheckedChanged += new System.EventHandler(this.rbBig_CheckedChanged);
            // 
            // rbSmall
            // 
            this.rbSmall.AutoSize = true;
            this.rbSmall.Location = new System.Drawing.Point(8, 20);
            this.rbSmall.Name = "rbSmall";
            this.rbSmall.Size = new System.Drawing.Size(35, 16);
            this.rbSmall.TabIndex = 0;
            this.rbSmall.TabStop = true;
            this.rbSmall.Text = "小";
            this.rbSmall.UseVisualStyleBackColor = true;
            this.rbSmall.CheckedChanged += new System.EventHandler(this.rbSmall_CheckedChanged);
            // 
            // cbxOpenArrow
            // 
            this.cbxOpenArrow.AutoSize = true;
            this.cbxOpenArrow.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxOpenArrow.Location = new System.Drawing.Point(18, 41);
            this.cbxOpenArrow.Name = "cbxOpenArrow";
            this.cbxOpenArrow.Size = new System.Drawing.Size(60, 16);
            this.cbxOpenArrow.TabIndex = 79;
            this.cbxOpenArrow.Text = "显示   ";
            this.cbxOpenArrow.UseVisualStyleBackColor = true;
            this.cbxOpenArrow.CheckedChanged += new System.EventHandler(this.cbxOpenArrow_CheckedChanged);
            // 
            // gbArrow
            // 
            this.gbArrow.Controls.Add(this.gbCursorStyle);
            this.gbArrow.Controls.Add(this.cbxOpenArrow);
            this.gbArrow.Controls.Add(this.label5);
            this.gbArrow.Controls.Add(this.lblArrowColor);
            this.gbArrow.Location = new System.Drawing.Point(11, 183);
            this.gbArrow.Name = "gbArrow";
            this.gbArrow.Size = new System.Drawing.Size(169, 112);
            this.gbArrow.TabIndex = 80;
            this.gbArrow.TabStop = false;
            this.gbArrow.Text = "十字光标";
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.label12);
            this.gbGeneral.Controls.Add(this.label11);
            this.gbGeneral.Controls.Add(this.label10);
            this.gbGeneral.Controls.Add(this.cmbScanPeriod);
            this.gbGeneral.Controls.Add(this.label3);
            this.gbGeneral.Controls.Add(this.lblScanPeriod);
            this.gbGeneral.Controls.Add(this.label2);
            this.gbGeneral.Controls.Add(this.cbxAutoName);
            this.gbGeneral.Controls.Add(this.label9);
            this.gbGeneral.Controls.Add(this.lblDgvBackColor);
            this.gbGeneral.Controls.Add(this.cmbPeakSolution);
            this.gbGeneral.Controls.Add(this.label8);
            this.gbGeneral.Controls.Add(this.cmbLinkObject);
            this.gbGeneral.Controls.Add(this.label7);
            this.gbGeneral.Controls.Add(this.numUDMoveUnit);
            this.gbGeneral.Controls.Add(this.label1);
            this.gbGeneral.Controls.Add(this.cbxLog);
            this.gbGeneral.Controls.Add(this.lblBkColor);
            this.gbGeneral.Controls.Add(this.numUDSampleRate);
            this.gbGeneral.Controls.Add(this.label6);
            this.gbGeneral.Controls.Add(this.label4);
            this.gbGeneral.Location = new System.Drawing.Point(9, 14);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(390, 163);
            this.gbGeneral.TabIndex = 81;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "常规";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(11, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(149, 12);
            this.label12.TabIndex = 95;
            this.label12.Text = "意为每秒的周期性震动次数";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(12, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(286, 12);
            this.label11.TabIndex = 94;
            this.label11.Text = "赫兹（英文：Hertz）是计算频率的单位，属于公制的一种";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(189, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 12);
            this.label10.TabIndex = 93;
            this.label10.Text = "ms";
            // 
            // cmbScanPeriod
            // 
            this.cmbScanPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScanPeriod.FormattingEnabled = true;
            this.cmbScanPeriod.Location = new System.Drawing.Point(80, 104);
            this.cmbScanPeriod.Name = "cmbScanPeriod";
            this.cmbScanPeriod.Size = new System.Drawing.Size(98, 20);
            this.cmbScanPeriod.TabIndex = 92;
            // 
            // lblScanPeriod
            // 
            this.lblScanPeriod.AutoSize = true;
            this.lblScanPeriod.Location = new System.Drawing.Point(14, 107);
            this.lblScanPeriod.Name = "lblScanPeriod";
            this.lblScanPeriod.Size = new System.Drawing.Size(55, 12);
            this.lblScanPeriod.TabIndex = 91;
            this.lblScanPeriod.Text = "扫描周期:";
            // 
            // cbxAutoName
            // 
            this.cbxAutoName.AutoSize = true;
            this.cbxAutoName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxAutoName.Enabled = false;
            this.cbxAutoName.Location = new System.Drawing.Point(191, 86);
            this.cbxAutoName.Name = "cbxAutoName";
            this.cbxAutoName.Size = new System.Drawing.Size(86, 16);
            this.cbxAutoName.TabIndex = 90;
            this.cbxAutoName.Text = "自动命名:   ";
            this.cbxAutoName.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 12);
            this.label9.TabIndex = 89;
            this.label9.Text = "DGV背景色:";
            // 
            // lblDgvBackColor
            // 
            this.lblDgvBackColor.AutoSize = true;
            this.lblDgvBackColor.Location = new System.Drawing.Point(87, 39);
            this.lblDgvBackColor.Name = "lblDgvBackColor";
            this.lblDgvBackColor.Size = new System.Drawing.Size(11, 12);
            this.lblDgvBackColor.TabIndex = 88;
            this.lblDgvBackColor.Text = "...";
            this.lblDgvBackColor.Click += new System.EventHandler(this.lblDgvBackColor_Click);
            // 
            // cmbPeakSolution
            // 
            this.cmbPeakSolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeakSolution.FormattingEnabled = true;
            this.cmbPeakSolution.Location = new System.Drawing.Point(80, 81);
            this.cmbPeakSolution.Name = "cmbPeakSolution";
            this.cmbPeakSolution.Size = new System.Drawing.Size(98, 20);
            this.cmbPeakSolution.TabIndex = 87;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 12);
            this.label8.TabIndex = 86;
            this.label8.Text = "找峰方法:";
            // 
            // cmbLinkObject
            // 
            this.cmbLinkObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLinkObject.FormattingEnabled = true;
            this.cmbLinkObject.Items.AddRange(new object[] {
            "模拟数据",
            "小板卡",
            "大板卡",
            "通道气板卡",
            "自动通道"});
            this.cmbLinkObject.Location = new System.Drawing.Point(80, 59);
            this.cmbLinkObject.Name = "cmbLinkObject";
            this.cmbLinkObject.Size = new System.Drawing.Size(98, 20);
            this.cmbLinkObject.TabIndex = 84;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 12);
            this.label7.TabIndex = 83;
            this.label7.Text = "连接对象:";
            // 
            // gbShowChannel
            // 
            this.gbShowChannel.Controls.Add(this.cbxSyn);
            this.gbShowChannel.Controls.Add(this.cbxFid2);
            this.gbShowChannel.Controls.Add(this.cbxFid1);
            this.gbShowChannel.Controls.Add(this.cbxTcd2);
            this.gbShowChannel.Controls.Add(this.cbxTcd1);
            this.gbShowChannel.Location = new System.Drawing.Point(183, 183);
            this.gbShowChannel.Name = "gbShowChannel";
            this.gbShowChannel.Size = new System.Drawing.Size(215, 110);
            this.gbShowChannel.TabIndex = 82;
            this.gbShowChannel.TabStop = false;
            this.gbShowChannel.Text = "显示通道";
            // 
            // cbxSyn
            // 
            this.cbxSyn.AutoSize = true;
            this.cbxSyn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxSyn.Location = new System.Drawing.Point(14, 79);
            this.cbxSyn.Name = "cbxSyn";
            this.cbxSyn.Size = new System.Drawing.Size(78, 16);
            this.cbxSyn.TabIndex = 85;
            this.cbxSyn.Text = "4通道同步";
            this.cbxSyn.UseVisualStyleBackColor = true;
            // 
            // cbxFid2
            // 
            this.cbxFid2.AutoSize = true;
            this.cbxFid2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxFid2.Location = new System.Drawing.Point(90, 49);
            this.cbxFid2.Name = "cbxFid2";
            this.cbxFid2.Size = new System.Drawing.Size(48, 16);
            this.cbxFid2.TabIndex = 83;
            this.cbxFid2.Text = "FID2";
            this.cbxFid2.UseVisualStyleBackColor = true;
            // 
            // cbxFid1
            // 
            this.cbxFid1.AutoSize = true;
            this.cbxFid1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxFid1.Location = new System.Drawing.Point(90, 27);
            this.cbxFid1.Name = "cbxFid1";
            this.cbxFid1.Size = new System.Drawing.Size(48, 16);
            this.cbxFid1.TabIndex = 82;
            this.cbxFid1.Text = "FID1";
            this.cbxFid1.UseVisualStyleBackColor = true;
            // 
            // cbxTcd2
            // 
            this.cbxTcd2.AutoSize = true;
            this.cbxTcd2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxTcd2.Location = new System.Drawing.Point(9, 49);
            this.cbxTcd2.Name = "cbxTcd2";
            this.cbxTcd2.Size = new System.Drawing.Size(53, 16);
            this.cbxTcd2.TabIndex = 81;
            this.cbxTcd2.Text = "TCD2";
            this.cbxTcd2.UseVisualStyleBackColor = true;
            // 
            // cbxTcd1
            // 
            this.cbxTcd1.AutoSize = true;
            this.cbxTcd1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxTcd1.Location = new System.Drawing.Point(9, 27);
            this.cbxTcd1.Name = "cbxTcd1";
            this.cbxTcd1.Size = new System.Drawing.Size(53, 16);
            this.cbxTcd1.TabIndex = 80;
            this.cbxTcd1.Text = "TCD1";
            this.cbxTcd1.UseVisualStyleBackColor = true;
            // 
            // GeneralUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbShowChannel);
            this.Controls.Add(this.gbArrow);
            this.Controls.Add(this.gbGeneral);
            this.Name = "GeneralUser";
            this.Size = new System.Drawing.Size(407, 309);
            ((System.ComponentModel.ISupportInitialize)(this.numUDSampleRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDMoveUnit)).EndInit();
            this.gbCursorStyle.ResumeLayout(false);
            this.gbCursorStyle.PerformLayout();
            this.gbArrow.ResumeLayout(false);
            this.gbArrow.PerformLayout();
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            this.gbShowChannel.ResumeLayout(false);
            this.gbShowChannel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBkColor;
        private System.Windows.Forms.ColorDialog colorDlgBK;
        private System.Windows.Forms.NumericUpDown numUDSampleRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numUDMoveUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblArrowColor;
        private System.Windows.Forms.CheckBox cbxLog;
        private System.Windows.Forms.GroupBox gbCursorStyle;
        private System.Windows.Forms.RadioButton rbBig;
        private System.Windows.Forms.RadioButton rbSmall;
        private System.Windows.Forms.CheckBox cbxOpenArrow;
        private System.Windows.Forms.GroupBox gbArrow;
        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbLinkObject;
        private System.Windows.Forms.ComboBox cmbPeakSolution;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDgvBackColor;
        private System.Windows.Forms.CheckBox cbxAutoName;
        private System.Windows.Forms.GroupBox gbShowChannel;
        private System.Windows.Forms.CheckBox cbxTcd1;
        private System.Windows.Forms.CheckBox cbxTcd2;
        private System.Windows.Forms.CheckBox cbxFid2;
        private System.Windows.Forms.CheckBox cbxFid1;
        private System.Windows.Forms.CheckBox cbxSyn;
        private System.Windows.Forms.ComboBox cmbScanPeriod;
        private System.Windows.Forms.Label lblScanPeriod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}
