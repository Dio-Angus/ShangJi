namespace TestGas
{
    partial class RegUser
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
            this.grpBoxInfo = new System.Windows.Forms.GroupBox();
            this.lblInnerPercentRange = new System.Windows.Forms.Label();
            this.numUDInnerPercent = new System.Windows.Forms.NumericUpDown();
            this.lblSamPercentRange = new System.Windows.Forms.Label();
            this.numUDSamPercent = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbSamType = new System.Windows.Forms.GroupBox();
            this.rbUnknown = new System.Windows.Forms.RadioButton();
            this.rbStandardSam = new System.Windows.Forms.RadioButton();
            this.gbChooseChannel = new System.Windows.Forms.GroupBox();
            this.cbxD = new System.Windows.Forms.CheckBox();
            this.cbxC = new System.Windows.Forms.CheckBox();
            this.cbxB = new System.Windows.Forms.CheckBox();
            this.cbxA = new System.Windows.Forms.CheckBox();
            this.cmbSolution = new System.Windows.Forms.ComboBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtSampleName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnReg = new System.Windows.Forms.Button();
            this.grpBoxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDInnerPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDSamPercent)).BeginInit();
            this.gbSamType.SuspendLayout();
            this.gbChooseChannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxInfo
            // 
            this.grpBoxInfo.BackColor = System.Drawing.SystemColors.Info;
            this.grpBoxInfo.Controls.Add(this.lblInnerPercentRange);
            this.grpBoxInfo.Controls.Add(this.numUDInnerPercent);
            this.grpBoxInfo.Controls.Add(this.lblSamPercentRange);
            this.grpBoxInfo.Controls.Add(this.numUDSamPercent);
            this.grpBoxInfo.Controls.Add(this.label3);
            this.grpBoxInfo.Controls.Add(this.label1);
            this.grpBoxInfo.Controls.Add(this.gbSamType);
            this.grpBoxInfo.Controls.Add(this.gbChooseChannel);
            this.grpBoxInfo.Controls.Add(this.cmbSolution);
            this.grpBoxInfo.Controls.Add(this.txtStatus);
            this.grpBoxInfo.Controls.Add(this.txtSampleName);
            this.grpBoxInfo.Controls.Add(this.label2);
            this.grpBoxInfo.Controls.Add(this.label7);
            this.grpBoxInfo.Controls.Add(this.label8);
            this.grpBoxInfo.Location = new System.Drawing.Point(4, 9);
            this.grpBoxInfo.Name = "grpBoxInfo";
            this.grpBoxInfo.Size = new System.Drawing.Size(395, 202);
            this.grpBoxInfo.TabIndex = 43;
            this.grpBoxInfo.TabStop = false;
            this.grpBoxInfo.Text = "详细信息";
            // 
            // lblInnerPercentRange
            // 
            this.lblInnerPercentRange.AutoSize = true;
            this.lblInnerPercentRange.Location = new System.Drawing.Point(174, 121);
            this.lblInnerPercentRange.Name = "lblInnerPercentRange";
            this.lblInnerPercentRange.Size = new System.Drawing.Size(87, 12);
            this.lblInnerPercentRange.TabIndex = 55;
            this.lblInnerPercentRange.Text = "(0,10000000000)";
            // 
            // numUDInnerPercent
            // 
            this.numUDInnerPercent.Location = new System.Drawing.Point(89, 117);
            this.numUDInnerPercent.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numUDInnerPercent.Name = "numUDInnerPercent";
            this.numUDInnerPercent.Size = new System.Drawing.Size(79, 19);
            this.numUDInnerPercent.TabIndex = 54;
            this.numUDInnerPercent.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSamPercentRange
            // 
            this.lblSamPercentRange.AutoSize = true;
            this.lblSamPercentRange.Location = new System.Drawing.Point(174, 99);
            this.lblSamPercentRange.Name = "lblSamPercentRange";
            this.lblSamPercentRange.Size = new System.Drawing.Size(87, 12);
            this.lblSamPercentRange.TabIndex = 53;
            this.lblSamPercentRange.Text = "(0,10000000000)";
            // 
            // numUDSamPercent
            // 
            this.numUDSamPercent.Location = new System.Drawing.Point(89, 93);
            this.numUDSamPercent.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numUDSamPercent.Name = "numUDSamPercent";
            this.numUDSamPercent.Size = new System.Drawing.Size(79, 19);
            this.numUDSamPercent.TabIndex = 52;
            this.numUDSamPercent.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 51;
            this.label3.Text = "内标量：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 50;
            this.label1.Text = "样品量：";
            // 
            // gbSamType
            // 
            this.gbSamType.Controls.Add(this.rbUnknown);
            this.gbSamType.Controls.Add(this.rbStandardSam);
            this.gbSamType.Location = new System.Drawing.Point(19, 143);
            this.gbSamType.Name = "gbSamType";
            this.gbSamType.Size = new System.Drawing.Size(144, 42);
            this.gbSamType.TabIndex = 49;
            this.gbSamType.TabStop = false;
            this.gbSamType.Text = "样品类型";
            // 
            // rbUnknown
            // 
            this.rbUnknown.AutoSize = true;
            this.rbUnknown.Location = new System.Drawing.Point(70, 18);
            this.rbUnknown.Name = "rbUnknown";
            this.rbUnknown.Size = new System.Drawing.Size(47, 16);
            this.rbUnknown.TabIndex = 1;
            this.rbUnknown.TabStop = true;
            this.rbUnknown.Text = "未知";
            this.rbUnknown.UseVisualStyleBackColor = true;
            // 
            // rbStandardSam
            // 
            this.rbStandardSam.AutoSize = true;
            this.rbStandardSam.Location = new System.Drawing.Point(9, 18);
            this.rbStandardSam.Name = "rbStandardSam";
            this.rbStandardSam.Size = new System.Drawing.Size(47, 16);
            this.rbStandardSam.TabIndex = 0;
            this.rbStandardSam.TabStop = true;
            this.rbStandardSam.Text = "标样";
            this.rbStandardSam.UseVisualStyleBackColor = true;
            // 
            // gbChooseChannel
            // 
            this.gbChooseChannel.Controls.Add(this.cbxD);
            this.gbChooseChannel.Controls.Add(this.cbxC);
            this.gbChooseChannel.Controls.Add(this.cbxB);
            this.gbChooseChannel.Controls.Add(this.cbxA);
            this.gbChooseChannel.Location = new System.Drawing.Point(169, 144);
            this.gbChooseChannel.Name = "gbChooseChannel";
            this.gbChooseChannel.Size = new System.Drawing.Size(216, 41);
            this.gbChooseChannel.TabIndex = 48;
            this.gbChooseChannel.TabStop = false;
            this.gbChooseChannel.Text = "通道";
            // 
            // cbxD
            // 
            this.cbxD.AutoSize = true;
            this.cbxD.Location = new System.Drawing.Point(178, 17);
            this.cbxD.Name = "cbxD";
            this.cbxD.Size = new System.Drawing.Size(32, 16);
            this.cbxD.TabIndex = 3;
            this.cbxD.Text = "D";
            this.cbxD.UseVisualStyleBackColor = true;
            // 
            // cbxC
            // 
            this.cbxC.AutoSize = true;
            this.cbxC.Location = new System.Drawing.Point(120, 17);
            this.cbxC.Name = "cbxC";
            this.cbxC.Size = new System.Drawing.Size(32, 16);
            this.cbxC.TabIndex = 2;
            this.cbxC.Text = "C";
            this.cbxC.UseVisualStyleBackColor = true;
            // 
            // cbxB
            // 
            this.cbxB.AutoSize = true;
            this.cbxB.Location = new System.Drawing.Point(63, 17);
            this.cbxB.Name = "cbxB";
            this.cbxB.Size = new System.Drawing.Size(32, 16);
            this.cbxB.TabIndex = 1;
            this.cbxB.Text = "B";
            this.cbxB.UseVisualStyleBackColor = true;
            // 
            // cbxA
            // 
            this.cbxA.AutoSize = true;
            this.cbxA.Location = new System.Drawing.Point(12, 17);
            this.cbxA.Name = "cbxA";
            this.cbxA.Size = new System.Drawing.Size(32, 16);
            this.cbxA.TabIndex = 0;
            this.cbxA.Text = "A";
            this.cbxA.UseVisualStyleBackColor = true;
            // 
            // cmbSolution
            // 
            this.cmbSolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSolution.FormattingEnabled = true;
            this.cmbSolution.Location = new System.Drawing.Point(89, 46);
            this.cmbSolution.Name = "cmbSolution";
            this.cmbSolution.Size = new System.Drawing.Size(296, 20);
            this.cmbSolution.TabIndex = 36;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Info;
            this.txtStatus.Location = new System.Drawing.Point(89, 69);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(296, 19);
            this.txtStatus.TabIndex = 3;
            // 
            // txtSampleName
            // 
            this.txtSampleName.BackColor = System.Drawing.SystemColors.Info;
            this.txtSampleName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSampleName.Location = new System.Drawing.Point(89, 22);
            this.txtSampleName.MaxLength = 100;
            this.txtSampleName.Name = "txtSampleName";
            this.txtSampleName.ReadOnly = true;
            this.txtSampleName.Size = new System.Drawing.Size(296, 19);
            this.txtSampleName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "样品名：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "状  态：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 35;
            this.label8.Text = "方案名：";
            // 
            // btnReg
            // 
            this.btnReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReg.Location = new System.Drawing.Point(324, 217);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(75, 26);
            this.btnReg.TabIndex = 44;
            this.btnReg.Text = "注    册";
            this.btnReg.UseVisualStyleBackColor = true;
            // 
            // RegUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.grpBoxInfo);
            this.DoubleBuffered = true;
            this.Name = "RegUser";
            this.Size = new System.Drawing.Size(405, 253);
            this.grpBoxInfo.ResumeLayout(false);
            this.grpBoxInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDInnerPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDSamPercent)).EndInit();
            this.gbSamType.ResumeLayout(false);
            this.gbSamType.PerformLayout();
            this.gbChooseChannel.ResumeLayout(false);
            this.gbChooseChannel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxInfo;
        private System.Windows.Forms.Label lblInnerPercentRange;
        private System.Windows.Forms.NumericUpDown numUDInnerPercent;
        private System.Windows.Forms.Label lblSamPercentRange;
        private System.Windows.Forms.NumericUpDown numUDSamPercent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbSamType;
        private System.Windows.Forms.RadioButton rbUnknown;
        private System.Windows.Forms.RadioButton rbStandardSam;
        private System.Windows.Forms.GroupBox gbChooseChannel;
        private System.Windows.Forms.CheckBox cbxD;
        private System.Windows.Forms.CheckBox cbxC;
        private System.Windows.Forms.CheckBox cbxB;
        private System.Windows.Forms.CheckBox cbxA;
        private System.Windows.Forms.ComboBox cmbSolution;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtSampleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnReg;
    }
}
