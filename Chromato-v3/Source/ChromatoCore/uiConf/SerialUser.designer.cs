namespace ChromatoCore.uiConf
{
    partial class SerialUser
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
            this.gbOption = new System.Windows.Forms.GroupBox();
            this.rbAppendCRLF = new System.Windows.Forms.RadioButton();
            this.rbAppendLF = new System.Windows.Forms.RadioButton();
            this.rbAppendCR = new System.Windows.Forms.RadioButton();
            this.rbAppendNothing = new System.Windows.Forms.RadioButton();
            this.cbHexSend = new System.Windows.Forms.CheckBox();
            this.cbHexReceive = new System.Windows.Forms.CheckBox();
            this.cbFilterCase = new System.Windows.Forms.CheckBox();
            this.cbStayOnTop = new System.Windows.Forms.CheckBox();
            this.cbLocalEcho = new System.Windows.Forms.CheckBox();
            this.cbMonospacedFont = new System.Windows.Forms.CheckBox();
            this.gbConfig = new System.Windows.Forms.GroupBox();
            this.cmbTimerInterval = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboHandshaking = new System.Windows.Forms.ComboBox();
            this.cmbStopbits = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbDatabits = new System.Windows.Forms.ComboBox();
            this.cmbRate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSictPort = new System.Windows.Forms.ComboBox();
            this.ｇｂＯｔｈｅｒ = new System.Windows.Forms.GroupBox();
            this.gbOption.SuspendLayout();
            this.gbConfig.SuspendLayout();
            this.ｇｂＯｔｈｅｒ.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOption
            // 
            this.gbOption.Controls.Add(this.rbAppendCRLF);
            this.gbOption.Controls.Add(this.rbAppendLF);
            this.gbOption.Controls.Add(this.rbAppendCR);
            this.gbOption.Controls.Add(this.rbAppendNothing);
            this.gbOption.Location = new System.Drawing.Point(202, 21);
            this.gbOption.Name = "gbOption";
            this.gbOption.Size = new System.Drawing.Size(165, 93);
            this.gbOption.TabIndex = 9;
            this.gbOption.TabStop = false;
            this.gbOption.Text = "发送数据追加";
            // 
            // rbAppendCRLF
            // 
            this.rbAppendCRLF.AutoSize = true;
            this.rbAppendCRLF.Location = new System.Drawing.Point(15, 67);
            this.rbAppendCRLF.Name = "rbAppendCRLF";
            this.rbAppendCRLF.Size = new System.Drawing.Size(53, 16);
            this.rbAppendCRLF.TabIndex = 11;
            this.rbAppendCRLF.TabStop = true;
            this.rbAppendCRLF.Text = "CR-LF";
            this.rbAppendCRLF.UseVisualStyleBackColor = true;
            // 
            // rbAppendLF
            // 
            this.rbAppendLF.AutoSize = true;
            this.rbAppendLF.Location = new System.Drawing.Point(15, 51);
            this.rbAppendLF.Name = "rbAppendLF";
            this.rbAppendLF.Size = new System.Drawing.Size(35, 16);
            this.rbAppendLF.TabIndex = 10;
            this.rbAppendLF.TabStop = true;
            this.rbAppendLF.Text = "LF";
            this.rbAppendLF.UseVisualStyleBackColor = true;
            // 
            // rbAppendCR
            // 
            this.rbAppendCR.AutoSize = true;
            this.rbAppendCR.Location = new System.Drawing.Point(15, 34);
            this.rbAppendCR.Name = "rbAppendCR";
            this.rbAppendCR.Size = new System.Drawing.Size(35, 16);
            this.rbAppendCR.TabIndex = 9;
            this.rbAppendCR.TabStop = true;
            this.rbAppendCR.Text = "CR";
            this.rbAppendCR.UseVisualStyleBackColor = true;
            // 
            // rbAppendNothing
            // 
            this.rbAppendNothing.AutoSize = true;
            this.rbAppendNothing.Location = new System.Drawing.Point(15, 18);
            this.rbAppendNothing.Name = "rbAppendNothing";
            this.rbAppendNothing.Size = new System.Drawing.Size(35, 16);
            this.rbAppendNothing.TabIndex = 8;
            this.rbAppendNothing.TabStop = true;
            this.rbAppendNothing.Text = "无";
            this.rbAppendNothing.UseVisualStyleBackColor = true;
            // 
            // cbHexSend
            // 
            this.cbHexSend.AutoSize = true;
            this.cbHexSend.Location = new System.Drawing.Point(14, 22);
            this.cbHexSend.Name = "cbHexSend";
            this.cbHexSend.Size = new System.Drawing.Size(97, 16);
            this.cbHexSend.TabIndex = 12;
            this.cbHexSend.Text = "十六进制发送";
            this.cbHexSend.UseVisualStyleBackColor = true;
            // 
            // cbHexReceive
            // 
            this.cbHexReceive.AutoSize = true;
            this.cbHexReceive.Location = new System.Drawing.Point(14, 39);
            this.cbHexReceive.Name = "cbHexReceive";
            this.cbHexReceive.Size = new System.Drawing.Size(97, 16);
            this.cbHexReceive.TabIndex = 13;
            this.cbHexReceive.Text = "十六进制接收";
            this.cbHexReceive.UseVisualStyleBackColor = true;
            // 
            // cbFilterCase
            // 
            this.cbFilterCase.AutoSize = true;
            this.cbFilterCase.Location = new System.Drawing.Point(14, 103);
            this.cbFilterCase.Name = "cbFilterCase";
            this.cbFilterCase.Size = new System.Drawing.Size(85, 16);
            this.cbFilterCase.TabIndex = 17;
            this.cbFilterCase.Text = "区分大小写";
            this.cbFilterCase.UseVisualStyleBackColor = true;
            // 
            // cbStayOnTop
            // 
            this.cbStayOnTop.AutoSize = true;
            this.cbStayOnTop.Location = new System.Drawing.Point(14, 87);
            this.cbStayOnTop.Name = "cbStayOnTop";
            this.cbStayOnTop.Size = new System.Drawing.Size(73, 16);
            this.cbStayOnTop.TabIndex = 16;
            this.cbStayOnTop.Text = "顶端停留";
            this.cbStayOnTop.UseVisualStyleBackColor = true;
            // 
            // cbLocalEcho
            // 
            this.cbLocalEcho.AutoSize = true;
            this.cbLocalEcho.Location = new System.Drawing.Point(14, 72);
            this.cbLocalEcho.Name = "cbLocalEcho";
            this.cbLocalEcho.Size = new System.Drawing.Size(73, 16);
            this.cbLocalEcho.TabIndex = 15;
            this.cbLocalEcho.Text = "本地回显";
            this.cbLocalEcho.UseVisualStyleBackColor = true;
            // 
            // cbMonospacedFont
            // 
            this.cbMonospacedFont.AutoSize = true;
            this.cbMonospacedFont.Location = new System.Drawing.Point(14, 56);
            this.cbMonospacedFont.Name = "cbMonospacedFont";
            this.cbMonospacedFont.Size = new System.Drawing.Size(85, 16);
            this.cbMonospacedFont.TabIndex = 14;
            this.cbMonospacedFont.Text = "单空格字体";
            this.cbMonospacedFont.UseVisualStyleBackColor = true;
            // 
            // gbConfig
            // 
            this.gbConfig.Controls.Add(this.cmbTimerInterval);
            this.gbConfig.Controls.Add(this.label7);
            this.gbConfig.Controls.Add(this.comboHandshaking);
            this.gbConfig.Controls.Add(this.cmbStopbits);
            this.gbConfig.Controls.Add(this.cmbParity);
            this.gbConfig.Controls.Add(this.cmbDatabits);
            this.gbConfig.Controls.Add(this.cmbRate);
            this.gbConfig.Controls.Add(this.label6);
            this.gbConfig.Controls.Add(this.label5);
            this.gbConfig.Controls.Add(this.label4);
            this.gbConfig.Controls.Add(this.label3);
            this.gbConfig.Controls.Add(this.label2);
            this.gbConfig.Controls.Add(this.label1);
            this.gbConfig.Controls.Add(this.cmbSictPort);
            this.gbConfig.Location = new System.Drawing.Point(14, 19);
            this.gbConfig.Name = "gbConfig";
            this.gbConfig.Size = new System.Drawing.Size(182, 205);
            this.gbConfig.TabIndex = 8;
            this.gbConfig.TabStop = false;
            this.gbConfig.Text = "设置";
            // 
            // cmbTimerInterval
            // 
            this.cmbTimerInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimerInterval.FormattingEnabled = true;
            this.cmbTimerInterval.Location = new System.Drawing.Point(99, 130);
            this.cmbTimerInterval.Name = "cmbTimerInterval";
            this.cmbTimerInterval.Size = new System.Drawing.Size(77, 20);
            this.cmbTimerInterval.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "定时器间隔";
            // 
            // comboHandshaking
            // 
            this.comboHandshaking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHandshaking.FormattingEnabled = true;
            this.comboHandshaking.Location = new System.Drawing.Point(40, 171);
            this.comboHandshaking.Name = "comboHandshaking";
            this.comboHandshaking.Size = new System.Drawing.Size(136, 20);
            this.comboHandshaking.TabIndex = 8;
            // 
            // cmbStopbits
            // 
            this.cmbStopbits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopbits.FormattingEnabled = true;
            this.cmbStopbits.Location = new System.Drawing.Point(99, 107);
            this.cmbStopbits.Name = "cmbStopbits";
            this.cmbStopbits.Size = new System.Drawing.Size(77, 20);
            this.cmbStopbits.TabIndex = 6;
            // 
            // cmbParity
            // 
            this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Location = new System.Drawing.Point(99, 86);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(77, 20);
            this.cmbParity.TabIndex = 5;
            // 
            // cmbDatabits
            // 
            this.cmbDatabits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatabits.FormattingEnabled = true;
            this.cmbDatabits.Location = new System.Drawing.Point(99, 63);
            this.cmbDatabits.Name = "cmbDatabits";
            this.cmbDatabits.Size = new System.Drawing.Size(77, 20);
            this.cmbDatabits.TabIndex = 4;
            // 
            // cmbRate
            // 
            this.cmbRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRate.FormattingEnabled = true;
            this.cmbRate.Location = new System.Drawing.Point(99, 41);
            this.cmbRate.Name = "cmbRate";
            this.cmbRate.Size = new System.Drawing.Size(77, 20);
            this.cmbRate.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "硬件握手";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "奇偶校验";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "停止位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "数据位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口号";
            // 
            // cmbSictPort
            // 
            this.cmbSictPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSictPort.FormattingEnabled = true;
            this.cmbSictPort.Location = new System.Drawing.Point(99, 18);
            this.cmbSictPort.Name = "cmbSictPort";
            this.cmbSictPort.Size = new System.Drawing.Size(77, 20);
            this.cmbSictPort.TabIndex = 1;
            // 
            // ｇｂＯｔｈｅｒ
            // 
            this.ｇｂＯｔｈｅｒ.Controls.Add(this.cbStayOnTop);
            this.ｇｂＯｔｈｅｒ.Controls.Add(this.cbHexSend);
            this.ｇｂＯｔｈｅｒ.Controls.Add(this.cbLocalEcho);
            this.ｇｂＯｔｈｅｒ.Controls.Add(this.cbMonospacedFont);
            this.ｇｂＯｔｈｅｒ.Controls.Add(this.cbHexReceive);
            this.ｇｂＯｔｈｅｒ.Controls.Add(this.cbFilterCase);
            this.ｇｂＯｔｈｅｒ.Location = new System.Drawing.Point(203, 121);
            this.ｇｂＯｔｈｅｒ.Name = "ｇｂＯｔｈｅｒ";
            this.ｇｂＯｔｈｅｒ.Size = new System.Drawing.Size(164, 136);
            this.ｇｂＯｔｈｅｒ.TabIndex = 18;
            this.ｇｂＯｔｈｅｒ.TabStop = false;
            this.ｇｂＯｔｈｅｒ.Text = "其它";
            // 
            // SerialUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ｇｂＯｔｈｅｒ);
            this.Controls.Add(this.gbOption);
            this.Controls.Add(this.gbConfig);
            this.Name = "SerialUser";
            this.Size = new System.Drawing.Size(387, 290);
            this.gbOption.ResumeLayout(false);
            this.gbOption.PerformLayout();
            this.gbConfig.ResumeLayout(false);
            this.gbConfig.PerformLayout();
            this.ｇｂＯｔｈｅｒ.ResumeLayout(false);
            this.ｇｂＯｔｈｅｒ.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOption;
        private System.Windows.Forms.CheckBox cbHexSend;
        private System.Windows.Forms.CheckBox cbHexReceive;
        private System.Windows.Forms.CheckBox cbFilterCase;
        private System.Windows.Forms.CheckBox cbStayOnTop;
        private System.Windows.Forms.CheckBox cbLocalEcho;
        private System.Windows.Forms.CheckBox cbMonospacedFont;
        private System.Windows.Forms.RadioButton rbAppendCRLF;
        private System.Windows.Forms.RadioButton rbAppendLF;
        private System.Windows.Forms.RadioButton rbAppendCR;
        private System.Windows.Forms.RadioButton rbAppendNothing;
        private System.Windows.Forms.GroupBox gbConfig;
        private System.Windows.Forms.ComboBox comboHandshaking;
        private System.Windows.Forms.ComboBox cmbStopbits;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.ComboBox cmbDatabits;
        private System.Windows.Forms.ComboBox cmbRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSictPort;
        private System.Windows.Forms.ComboBox cmbTimerInterval;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox ｇｂＯｔｈｅｒ;
    }
}
