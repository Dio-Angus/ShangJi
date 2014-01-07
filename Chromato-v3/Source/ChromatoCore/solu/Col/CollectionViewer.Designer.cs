namespace ChromatoCore.solu.Col
{
    partial class CollectionViewer
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
            this.gbCollection = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblForeColor = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblBkColor = new System.Windows.Forms.Label();
            this.cbxAutoSlope = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numUDFullScreenTime = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCollectionName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.numUDSlope = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numUDStopTime = new System.Windows.Forms.NumericUpDown();
            this.txtShowMinY = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numUDPeakWide = new System.Windows.Forms.NumericUpDown();
            this.txtShowMaxY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDlg = new System.Windows.Forms.ColorDialog();
            this.gbCollection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDFullScreenTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDSlope)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDStopTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDPeakWide)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCollection
            // 
            this.gbCollection.Controls.Add(this.label15);
            this.gbCollection.Controls.Add(this.lblForeColor);
            this.gbCollection.Controls.Add(this.label11);
            this.gbCollection.Controls.Add(this.lblBkColor);
            this.gbCollection.Controls.Add(this.cbxAutoSlope);
            this.gbCollection.Controls.Add(this.label6);
            this.gbCollection.Controls.Add(this.numUDFullScreenTime);
            this.gbCollection.Controls.Add(this.label12);
            this.gbCollection.Controls.Add(this.txtCollectionName);
            this.gbCollection.Controls.Add(this.label5);
            this.gbCollection.Controls.Add(this.label10);
            this.gbCollection.Controls.Add(this.label9);
            this.gbCollection.Controls.Add(this.label13);
            this.gbCollection.Controls.Add(this.numUDSlope);
            this.gbCollection.Controls.Add(this.label7);
            this.gbCollection.Controls.Add(this.numUDStopTime);
            this.gbCollection.Controls.Add(this.txtShowMinY);
            this.gbCollection.Controls.Add(this.label14);
            this.gbCollection.Controls.Add(this.label8);
            this.gbCollection.Controls.Add(this.numUDPeakWide);
            this.gbCollection.Controls.Add(this.txtShowMaxY);
            this.gbCollection.Controls.Add(this.label4);
            this.gbCollection.Controls.Add(this.label2);
            this.gbCollection.Controls.Add(this.label3);
            this.gbCollection.Controls.Add(this.label1);
            this.gbCollection.Location = new System.Drawing.Point(3, 3);
            this.gbCollection.Name = "gbCollection";
            this.gbCollection.Size = new System.Drawing.Size(402, 226);
            this.gbCollection.TabIndex = 0;
            this.gbCollection.TabStop = false;
            this.gbCollection.Text = "采集方法";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 165);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 87;
            this.label15.Text = "曲线颜色：";
            // 
            // lblForeColor
            // 
            this.lblForeColor.AutoSize = true;
            this.lblForeColor.Location = new System.Drawing.Point(83, 164);
            this.lblForeColor.Name = "lblForeColor";
            this.lblForeColor.Size = new System.Drawing.Size(29, 12);
            this.lblForeColor.TabIndex = 9;
            this.lblForeColor.Text = "....";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 85;
            this.label11.Text = "背景颜色：";
            // 
            // lblBkColor
            // 
            this.lblBkColor.AutoSize = true;
            this.lblBkColor.Location = new System.Drawing.Point(83, 143);
            this.lblBkColor.Name = "lblBkColor";
            this.lblBkColor.Size = new System.Drawing.Size(29, 12);
            this.lblBkColor.TabIndex = 8;
            this.lblBkColor.Text = "....";
            // 
            // cbxAutoSlope
            // 
            this.cbxAutoSlope.AutoSize = true;
            this.cbxAutoSlope.Location = new System.Drawing.Point(311, 50);
            this.cbxAutoSlope.Name = "cbxAutoSlope";
            this.cbxAutoSlope.Size = new System.Drawing.Size(72, 16);
            this.cbxAutoSlope.TabIndex = 3;
            this.cbxAutoSlope.Text = "自动斜率";
            this.cbxAutoSlope.UseVisualStyleBackColor = true;
            this.cbxAutoSlope.CheckedChanged += new System.EventHandler(this.cbxAutoSlope_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 80;
            this.label6.Text = "分钟 (1,10000)";
            // 
            // numUDFullScreenTime
            // 
            this.numUDFullScreenTime.Location = new System.Drawing.Point(84, 114);
            this.numUDFullScreenTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUDFullScreenTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDFullScreenTime.Name = "numUDFullScreenTime";
            this.numUDFullScreenTime.Size = new System.Drawing.Size(79, 21);
            this.numUDFullScreenTime.TabIndex = 7;
            this.numUDFullScreenTime.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "满屏时间：";
            // 
            // txtCollectionName
            // 
            this.txtCollectionName.BackColor = System.Drawing.SystemColors.Info;
            this.txtCollectionName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCollectionName.Location = new System.Drawing.Point(83, 185);
            this.txtCollectionName.MaxLength = 100;
            this.txtCollectionName.Name = "txtCollectionName";
            this.txtCollectionName.Size = new System.Drawing.Size(217, 21);
            this.txtCollectionName.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 77;
            this.label5.Text = "方法名：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(210, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "显示下限：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(364, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "毫伏";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(168, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 44;
            this.label13.Text = "分钟 (1,10000)";
            // 
            // numUDSlope
            // 
            this.numUDSlope.Location = new System.Drawing.Point(84, 44);
            this.numUDSlope.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUDSlope.Name = "numUDSlope";
            this.numUDSlope.Size = new System.Drawing.Size(78, 21);
            this.numUDSlope.TabIndex = 2;
            this.numUDSlope.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "显示上限：";
            // 
            // numUDStopTime
            // 
            this.numUDStopTime.Location = new System.Drawing.Point(84, 67);
            this.numUDStopTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUDStopTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDStopTime.Name = "numUDStopTime";
            this.numUDStopTime.Size = new System.Drawing.Size(79, 21);
            this.numUDStopTime.TabIndex = 4;
            this.numUDStopTime.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // txtShowMinY
            // 
            this.txtShowMinY.Location = new System.Drawing.Point(280, 91);
            this.txtShowMinY.Name = "txtShowMinY";
            this.txtShowMinY.Size = new System.Drawing.Size(78, 21);
            this.txtShowMinY.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 42;
            this.label14.Text = "停止时间：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(168, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "毫伏";
            // 
            // numUDPeakWide
            // 
            this.numUDPeakWide.Location = new System.Drawing.Point(84, 21);
            this.numUDPeakWide.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDPeakWide.Name = "numUDPeakWide";
            this.numUDPeakWide.Size = new System.Drawing.Size(78, 21);
            this.numUDPeakWide.TabIndex = 1;
            this.numUDPeakWide.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // txtShowMaxY
            // 
            this.txtShowMaxY.Location = new System.Drawing.Point(84, 91);
            this.txtShowMaxY.Name = "txtShowMaxY";
            this.txtShowMaxY.Size = new System.Drawing.Size(78, 21);
            this.txtShowMaxY.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "微伏/分钟 (0,100000)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "(1,100)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "斜    率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "峰    宽：";
            // 
            // CollectionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.gbCollection);
            this.Name = "CollectionViewer";
            this.Size = new System.Drawing.Size(408, 236);
            this.gbCollection.ResumeLayout(false);
            this.gbCollection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDFullScreenTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDSlope)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDStopTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDPeakWide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCollection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtShowMinY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtShowMaxY;
        private System.Windows.Forms.NumericUpDown numUDPeakWide;
        private System.Windows.Forms.NumericUpDown numUDSlope;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numUDStopTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCollectionName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numUDFullScreenTime;
        private System.Windows.Forms.CheckBox cbxAutoSlope;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblBkColor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblForeColor;
        private System.Windows.Forms.ColorDialog colorDlg;
    }
}
