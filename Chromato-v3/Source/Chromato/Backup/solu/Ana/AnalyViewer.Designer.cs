namespace ChromatoCore.solu.Ana
{
    partial class AnalyViewer
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
            this.txtAnalyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbArithmeticPara = new System.Windows.Forms.GroupBox();
            this.rbHeight = new System.Windows.Forms.RadioButton();
            this.rbArea = new System.Windows.Forms.RadioButton();
            this.gbArithmatic = new System.Windows.Forms.GroupBox();
            this.rbExponent = new System.Windows.Forms.RadioButton();
            this.rbInner = new System.Windows.Forms.RadioButton();
            this.rbOuter = new System.Windows.Forms.RadioButton();
            this.rbFixNormalizeWithRate = new System.Windows.Forms.RadioButton();
            this.rbFixNormalize = new System.Windows.Forms.RadioButton();
            this.rbNormalize = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtColumnModel = new System.Windows.Forms.TextBox();
            this.gbAimPara = new System.Windows.Forms.GroupBox();
            this.numUDTimeWindow = new System.Windows.Forms.NumericUpDown();
            this.rbTimeBand = new System.Windows.Forms.RadioButton();
            this.lblTimeWindow = new System.Windows.Forms.Label();
            this.rbTimeWindow = new System.Windows.Forms.RadioButton();
            this.gbAimWay = new System.Windows.Forms.GroupBox();
            this.rbRelative = new System.Windows.Forms.RadioButton();
            this.rbAbsolute = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.numUDPeakWide = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numUDSlope = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numUdDrift = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numUdMinArea = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.numUDParaChangeTime = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numUdRatio = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.gbAnaly = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFixCurve = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.gbArithmeticPara.SuspendLayout();
            this.gbArithmatic.SuspendLayout();
            this.gbAimPara.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDTimeWindow)).BeginInit();
            this.gbAimWay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDPeakWide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDSlope)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUdDrift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUdMinArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDParaChangeTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUdRatio)).BeginInit();
            this.gbAnaly.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAnalyName
            // 
            this.txtAnalyName.BackColor = System.Drawing.SystemColors.Info;
            this.txtAnalyName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAnalyName.Location = new System.Drawing.Point(328, 194);
            this.txtAnalyName.MaxLength = 100;
            this.txtAnalyName.Name = "txtAnalyName";
            this.txtAnalyName.Size = new System.Drawing.Size(217, 19);
            this.txtAnalyName.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 60;
            this.label1.Text = "分析方法名：";
            // 
            // gbArithmeticPara
            // 
            this.gbArithmeticPara.Controls.Add(this.rbHeight);
            this.gbArithmeticPara.Controls.Add(this.rbArea);
            this.gbArithmeticPara.Location = new System.Drawing.Point(10, 115);
            this.gbArithmeticPara.Name = "gbArithmeticPara";
            this.gbArithmeticPara.Size = new System.Drawing.Size(214, 43);
            this.gbArithmeticPara.TabIndex = 7;
            this.gbArithmeticPara.TabStop = false;
            this.gbArithmeticPara.Text = "定量参数";
            // 
            // rbHeight
            // 
            this.rbHeight.AutoSize = true;
            this.rbHeight.Location = new System.Drawing.Point(144, 19);
            this.rbHeight.Name = "rbHeight";
            this.rbHeight.Size = new System.Drawing.Size(47, 16);
            this.rbHeight.TabIndex = 8;
            this.rbHeight.TabStop = true;
            this.rbHeight.Text = "高度";
            this.rbHeight.UseVisualStyleBackColor = true;
            // 
            // rbArea
            // 
            this.rbArea.AutoSize = true;
            this.rbArea.Location = new System.Drawing.Point(8, 19);
            this.rbArea.Name = "rbArea";
            this.rbArea.Size = new System.Drawing.Size(47, 16);
            this.rbArea.TabIndex = 7;
            this.rbArea.TabStop = true;
            this.rbArea.Text = "面积";
            this.rbArea.UseVisualStyleBackColor = true;
            // 
            // gbArithmatic
            // 
            this.gbArithmatic.Controls.Add(this.rbExponent);
            this.gbArithmatic.Controls.Add(this.rbInner);
            this.gbArithmatic.Controls.Add(this.rbOuter);
            this.gbArithmatic.Controls.Add(this.rbFixNormalizeWithRate);
            this.gbArithmatic.Controls.Add(this.rbFixNormalize);
            this.gbArithmatic.Controls.Add(this.rbNormalize);
            this.gbArithmatic.Location = new System.Drawing.Point(10, 22);
            this.gbArithmatic.Name = "gbArithmatic";
            this.gbArithmatic.Size = new System.Drawing.Size(214, 85);
            this.gbArithmatic.TabIndex = 1;
            this.gbArithmatic.TabStop = false;
            this.gbArithmatic.Text = "定量计算方法";
            // 
            // rbExponent
            // 
            this.rbExponent.AutoSize = true;
            this.rbExponent.Location = new System.Drawing.Point(144, 63);
            this.rbExponent.Name = "rbExponent";
            this.rbExponent.Size = new System.Drawing.Size(59, 16);
            this.rbExponent.TabIndex = 6;
            this.rbExponent.TabStop = true;
            this.rbExponent.Text = "指数法";
            this.rbExponent.UseVisualStyleBackColor = true;
            // 
            // rbInner
            // 
            this.rbInner.AutoSize = true;
            this.rbInner.Location = new System.Drawing.Point(144, 41);
            this.rbInner.Name = "rbInner";
            this.rbInner.Size = new System.Drawing.Size(59, 16);
            this.rbInner.TabIndex = 4;
            this.rbInner.TabStop = true;
            this.rbInner.Text = "内标法";
            this.rbInner.UseVisualStyleBackColor = true;
            // 
            // rbOuter
            // 
            this.rbOuter.AutoSize = true;
            this.rbOuter.Location = new System.Drawing.Point(144, 20);
            this.rbOuter.Name = "rbOuter";
            this.rbOuter.Size = new System.Drawing.Size(59, 16);
            this.rbOuter.TabIndex = 2;
            this.rbOuter.TabStop = true;
            this.rbOuter.Text = "外标法";
            this.rbOuter.UseVisualStyleBackColor = true;
            // 
            // rbFixNormalizeWithRate
            // 
            this.rbFixNormalizeWithRate.AutoSize = true;
            this.rbFixNormalizeWithRate.Location = new System.Drawing.Point(9, 63);
            this.rbFixNormalizeWithRate.Name = "rbFixNormalizeWithRate";
            this.rbFixNormalizeWithRate.Size = new System.Drawing.Size(119, 16);
            this.rbFixNormalizeWithRate.TabIndex = 5;
            this.rbFixNormalizeWithRate.TabStop = true;
            this.rbFixNormalizeWithRate.Text = "带比例修正归一法";
            this.rbFixNormalizeWithRate.UseVisualStyleBackColor = true;
            // 
            // rbFixNormalize
            // 
            this.rbFixNormalize.AutoSize = true;
            this.rbFixNormalize.Location = new System.Drawing.Point(9, 41);
            this.rbFixNormalize.Name = "rbFixNormalize";
            this.rbFixNormalize.Size = new System.Drawing.Size(83, 16);
            this.rbFixNormalize.TabIndex = 3;
            this.rbFixNormalize.TabStop = true;
            this.rbFixNormalize.Text = "修正归一法";
            this.rbFixNormalize.UseVisualStyleBackColor = true;
            // 
            // rbNormalize
            // 
            this.rbNormalize.AutoSize = true;
            this.rbNormalize.Location = new System.Drawing.Point(9, 18);
            this.rbNormalize.Name = "rbNormalize";
            this.rbNormalize.Size = new System.Drawing.Size(59, 16);
            this.rbNormalize.TabIndex = 0;
            this.rbNormalize.TabStop = true;
            this.rbNormalize.Text = "归一法";
            this.rbNormalize.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 66;
            this.label6.Text = "色谱柱型号：";
            // 
            // txtColumnModel
            // 
            this.txtColumnModel.BackColor = System.Drawing.SystemColors.Info;
            this.txtColumnModel.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtColumnModel.Location = new System.Drawing.Point(328, 218);
            this.txtColumnModel.MaxLength = 100;
            this.txtColumnModel.Name = "txtColumnModel";
            this.txtColumnModel.Size = new System.Drawing.Size(217, 19);
            this.txtColumnModel.TabIndex = 22;
            // 
            // gbAimPara
            // 
            this.gbAimPara.Controls.Add(this.numUDTimeWindow);
            this.gbAimPara.Controls.Add(this.rbTimeBand);
            this.gbAimPara.Controls.Add(this.lblTimeWindow);
            this.gbAimPara.Controls.Add(this.rbTimeWindow);
            this.gbAimPara.Location = new System.Drawing.Point(10, 212);
            this.gbAimPara.Name = "gbAimPara";
            this.gbAimPara.Size = new System.Drawing.Size(214, 66);
            this.gbAimPara.TabIndex = 11;
            this.gbAimPara.TabStop = false;
            this.gbAimPara.Text = "对准参数";
            // 
            // numUDTimeWindow
            // 
            this.numUDTimeWindow.Location = new System.Drawing.Point(9, 39);
            this.numUDTimeWindow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDTimeWindow.Name = "numUDTimeWindow";
            this.numUDTimeWindow.Size = new System.Drawing.Size(46, 19);
            this.numUDTimeWindow.TabIndex = 13;
            this.numUDTimeWindow.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // rbTimeBand
            // 
            this.rbTimeBand.AutoSize = true;
            this.rbTimeBand.Location = new System.Drawing.Point(144, 20);
            this.rbTimeBand.Name = "rbTimeBand";
            this.rbTimeBand.Size = new System.Drawing.Size(59, 16);
            this.rbTimeBand.TabIndex = 12;
            this.rbTimeBand.TabStop = true;
            this.rbTimeBand.Text = "时间带";
            this.rbTimeBand.UseVisualStyleBackColor = true;
            // 
            // lblTimeWindow
            // 
            this.lblTimeWindow.AutoSize = true;
            this.lblTimeWindow.Location = new System.Drawing.Point(60, 43);
            this.lblTimeWindow.Name = "lblTimeWindow";
            this.lblTimeWindow.Size = new System.Drawing.Size(143, 12);
            this.lblTimeWindow.TabIndex = 5;
            this.lblTimeWindow.Text = "% (相对于保留时间百分比)";
            // 
            // rbTimeWindow
            // 
            this.rbTimeWindow.AutoSize = true;
            this.rbTimeWindow.Location = new System.Drawing.Point(9, 20);
            this.rbTimeWindow.Name = "rbTimeWindow";
            this.rbTimeWindow.Size = new System.Drawing.Size(59, 16);
            this.rbTimeWindow.TabIndex = 11;
            this.rbTimeWindow.TabStop = true;
            this.rbTimeWindow.Text = "时间窗";
            this.rbTimeWindow.UseVisualStyleBackColor = true;
            // 
            // gbAimWay
            // 
            this.gbAimWay.Controls.Add(this.rbRelative);
            this.gbAimWay.Controls.Add(this.rbAbsolute);
            this.gbAimWay.Location = new System.Drawing.Point(10, 164);
            this.gbAimWay.Name = "gbAimWay";
            this.gbAimWay.Size = new System.Drawing.Size(214, 42);
            this.gbAimWay.TabIndex = 9;
            this.gbAimWay.TabStop = false;
            this.gbAimWay.Text = "对准方法";
            // 
            // rbRelative
            // 
            this.rbRelative.AutoSize = true;
            this.rbRelative.Location = new System.Drawing.Point(144, 16);
            this.rbRelative.Name = "rbRelative";
            this.rbRelative.Size = new System.Drawing.Size(47, 16);
            this.rbRelative.TabIndex = 10;
            this.rbRelative.TabStop = true;
            this.rbRelative.Text = "相对";
            this.rbRelative.UseVisualStyleBackColor = true;
            // 
            // rbAbsolute
            // 
            this.rbAbsolute.AutoSize = true;
            this.rbAbsolute.Location = new System.Drawing.Point(8, 18);
            this.rbAbsolute.Name = "rbAbsolute";
            this.rbAbsolute.Size = new System.Drawing.Size(47, 16);
            this.rbAbsolute.TabIndex = 9;
            this.rbAbsolute.TabStop = true;
            this.rbAbsolute.Text = "绝对";
            this.rbAbsolute.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(274, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 69;
            this.label7.Text = "描述：";
            // 
            // rtbDescription
            // 
            this.rtbDescription.ImeMode = System.Windows.Forms.ImeMode.On;
            this.rtbDescription.Location = new System.Drawing.Point(327, 243);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(217, 26);
            this.rtbDescription.TabIndex = 23;
            this.rtbDescription.Text = "";
            // 
            // numUDPeakWide
            // 
            this.numUDPeakWide.Location = new System.Drawing.Point(327, 26);
            this.numUDPeakWide.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDPeakWide.Name = "numUDPeakWide";
            this.numUDPeakWide.Size = new System.Drawing.Size(79, 19);
            this.numUDPeakWide.TabIndex = 14;
            this.numUDPeakWide.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(266, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 12);
            this.label14.TabIndex = 70;
            this.label14.Text = "峰 宽：";
            // 
            // numUDSlope
            // 
            this.numUDSlope.Location = new System.Drawing.Point(327, 51);
            this.numUDSlope.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUDSlope.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDSlope.Name = "numUDSlope";
            this.numUDSlope.Size = new System.Drawing.Size(79, 19);
            this.numUDSlope.TabIndex = 15;
            this.numUDSlope.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(418, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 12);
            this.label8.TabIndex = 74;
            this.label8.Text = "微伏/分钟 (1,10000)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(266, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 12);
            this.label9.TabIndex = 73;
            this.label9.Text = "斜 率：";
            // 
            // numUdDrift
            // 
            this.numUdDrift.Location = new System.Drawing.Point(327, 76);
            this.numUdDrift.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUdDrift.Name = "numUdDrift";
            this.numUdDrift.Size = new System.Drawing.Size(79, 19);
            this.numUdDrift.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(418, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 12);
            this.label3.TabIndex = 77;
            this.label3.Text = "微伏/分钟 (0,10000)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 12);
            this.label4.TabIndex = 76;
            this.label4.Text = "漂 移：";
            // 
            // numUdMinArea
            // 
            this.numUdMinArea.Location = new System.Drawing.Point(327, 101);
            this.numUdMinArea.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUdMinArea.Name = "numUdMinArea";
            this.numUdMinArea.Size = new System.Drawing.Size(79, 19);
            this.numUdMinArea.TabIndex = 17;
            this.numUdMinArea.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(418, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 12);
            this.label5.TabIndex = 80;
            this.label5.Text = "微伏*秒 (0,10000)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(248, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 79;
            this.label10.Text = "最小面积：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(421, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 12);
            this.label13.TabIndex = 84;
            this.label13.Text = "分钟 (1,10000)";
            // 
            // numUDParaChangeTime
            // 
            this.numUDParaChangeTime.Location = new System.Drawing.Point(327, 125);
            this.numUDParaChangeTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUDParaChangeTime.Name = "numUDParaChangeTime";
            this.numUDParaChangeTime.Size = new System.Drawing.Size(79, 19);
            this.numUDParaChangeTime.TabIndex = 18;
            this.numUDParaChangeTime.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(248, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 82;
            this.label12.Text = "变参时间：";
            // 
            // numUdRatio
            // 
            this.numUdRatio.Location = new System.Drawing.Point(327, 148);
            this.numUdRatio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUdRatio.Name = "numUdRatio";
            this.numUdRatio.Size = new System.Drawing.Size(79, 19);
            this.numUdRatio.TabIndex = 19;
            this.numUdRatio.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(421, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 12);
            this.label11.TabIndex = 86;
            this.label11.Text = "(1,100)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(248, 154);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 85;
            this.label15.Text = "比例系数：";
            // 
            // gbAnaly
            // 
            this.gbAnaly.Controls.Add(this.label2);
            this.gbAnaly.Controls.Add(this.cmbFixCurve);
            this.gbAnaly.Controls.Add(this.label16);
            this.gbAnaly.Controls.Add(this.txtColumnModel);
            this.gbAnaly.Controls.Add(this.label1);
            this.gbAnaly.Controls.Add(this.txtAnalyName);
            this.gbAnaly.Controls.Add(this.label6);
            this.gbAnaly.Controls.Add(this.rtbDescription);
            this.gbAnaly.Controls.Add(this.label7);
            this.gbAnaly.Location = new System.Drawing.Point(-1, 3);
            this.gbAnaly.Name = "gbAnaly";
            this.gbAnaly.Size = new System.Drawing.Size(555, 281);
            this.gbAnaly.TabIndex = 88;
            this.gbAnaly.TabStop = false;
            this.gbAnaly.Text = "分析方法";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 71;
            this.label2.Text = "校正方法：";
            // 
            // cmbFixCurve
            // 
            this.cmbFixCurve.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFixCurve.FormattingEnabled = true;
            this.cmbFixCurve.Location = new System.Drawing.Point(328, 171);
            this.cmbFixCurve.Name = "cmbFixCurve";
            this.cmbFixCurve.Size = new System.Drawing.Size(138, 20);
            this.cmbFixCurve.TabIndex = 20;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(419, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "(1,100)";
            // 
            // AnalyViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.numUdRatio);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numUDParaChangeTime);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numUdMinArea);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numUdDrift);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numUDSlope);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numUDPeakWide);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.gbAimWay);
            this.Controls.Add(this.gbAimPara);
            this.Controls.Add(this.gbArithmatic);
            this.Controls.Add(this.gbArithmeticPara);
            this.Controls.Add(this.gbAnaly);
            this.Name = "AnalyViewer";
            this.Size = new System.Drawing.Size(553, 283);
            this.gbArithmeticPara.ResumeLayout(false);
            this.gbArithmeticPara.PerformLayout();
            this.gbArithmatic.ResumeLayout(false);
            this.gbArithmatic.PerformLayout();
            this.gbAimPara.ResumeLayout(false);
            this.gbAimPara.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDTimeWindow)).EndInit();
            this.gbAimWay.ResumeLayout(false);
            this.gbAimWay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDPeakWide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDSlope)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUdDrift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUdMinArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDParaChangeTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUdRatio)).EndInit();
            this.gbAnaly.ResumeLayout(false);
            this.gbAnaly.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAnalyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbArithmeticPara;
        private System.Windows.Forms.RadioButton rbHeight;
        private System.Windows.Forms.RadioButton rbArea;
        private System.Windows.Forms.GroupBox gbArithmatic;
        private System.Windows.Forms.RadioButton rbExponent;
        private System.Windows.Forms.RadioButton rbInner;
        private System.Windows.Forms.RadioButton rbOuter;
        private System.Windows.Forms.RadioButton rbFixNormalizeWithRate;
        private System.Windows.Forms.RadioButton rbFixNormalize;
        private System.Windows.Forms.RadioButton rbNormalize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtColumnModel;
        private System.Windows.Forms.GroupBox gbAimPara;
        private System.Windows.Forms.GroupBox gbAimWay;
        private System.Windows.Forms.RadioButton rbRelative;
        private System.Windows.Forms.RadioButton rbAbsolute;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.NumericUpDown numUDPeakWide;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numUDSlope;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numUdDrift;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numUdMinArea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numUDParaChangeTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numUdRatio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbAnaly;
        private System.Windows.Forms.RadioButton rbTimeBand;
        private System.Windows.Forms.RadioButton rbTimeWindow;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblTimeWindow;
        private System.Windows.Forms.NumericUpDown numUDTimeWindow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFixCurve;
    }
}
