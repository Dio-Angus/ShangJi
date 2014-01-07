namespace SerialportSample
{
    partial class SerialportSampleForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboPortName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBaudrate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOpenClose = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txGet = new System.Windows.Forms.TextBox();
            this.checkBoxNewlineGet = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txSend = new System.Windows.Forms.TextBox();
            this.labelSendCount = new System.Windows.Forms.Label();
            this.checkBoxHexSend = new System.Windows.Forms.CheckBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.checkBoxHexView = new System.Windows.Forms.CheckBox();
            this.labelGetCount = new System.Windows.Forms.Label();
            this.checkBoxNewlineSend = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboPortName
            // 
            this.comboPortName.FormattingEnabled = true;
            this.comboPortName.Location = new System.Drawing.Point(74, 11);
            this.comboPortName.Name = "comboPortName";
            this.comboPortName.Size = new System.Drawing.Size(121, 20);
            this.comboPortName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port name";
            // 
            // comboBaudrate
            // 
            this.comboBaudrate.FormattingEnabled = true;
            this.comboBaudrate.Items.AddRange(new object[] {
            "2400 ",
            "4800",
            "9600",
            "1920",
            "38400",
            "57600",
            "115200",
            ""});
            this.comboBaudrate.Location = new System.Drawing.Point(257, 11);
            this.comboBaudrate.Name = "comboBaudrate";
            this.comboBaudrate.Size = new System.Drawing.Size(121, 20);
            this.comboBaudrate.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baudrate";
            // 
            // buttonOpenClose
            // 
            this.buttonOpenClose.Location = new System.Drawing.Point(389, 8);
            this.buttonOpenClose.Name = "buttonOpenClose";
            this.buttonOpenClose.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenClose.TabIndex = 2;
            this.buttonOpenClose.Text = "Open";
            this.buttonOpenClose.UseVisualStyleBackColor = true;
            this.buttonOpenClose.Click += new System.EventHandler(this.buttonOpenClose_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(475, 8);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txGet);
            this.groupBox1.Controls.Add(this.checkBoxNewlineGet);
            this.groupBox1.Location = new System.Drawing.Point(26, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 330);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data received";
            // 
            // txGet
            // 
            this.txGet.Location = new System.Drawing.Point(13, 25);
            this.txGet.Multiline = true;
            this.txGet.Name = "txGet";
            this.txGet.Size = new System.Drawing.Size(505, 297);
            this.txGet.TabIndex = 1;
            // 
            // checkBoxNewlineGet
            // 
            this.checkBoxNewlineGet.AutoSize = true;
            this.checkBoxNewlineGet.Location = new System.Drawing.Point(185, 0);
            this.checkBoxNewlineGet.Name = "checkBoxNewlineGet";
            this.checkBoxNewlineGet.Size = new System.Drawing.Size(97, 16);
            this.checkBoxNewlineGet.TabIndex = 0;
            this.checkBoxNewlineGet.Text = "Auto newline";
            this.checkBoxNewlineGet.UseVisualStyleBackColor = true;
            this.checkBoxNewlineGet.CheckedChanged += new System.EventHandler(this.checkBoxNewlineGet_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txSend);
            this.groupBox2.Controls.Add(this.labelSendCount);
            this.groupBox2.Controls.Add(this.checkBoxHexSend);
            this.groupBox2.Controls.Add(this.buttonSend);
            this.groupBox2.Location = new System.Drawing.Point(26, 392);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(523, 60);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data send";
            // 
            // txSend
            // 
            this.txSend.Location = new System.Drawing.Point(13, 22);
            this.txSend.Name = "txSend";
            this.txSend.Size = new System.Drawing.Size(401, 21);
            this.txSend.TabIndex = 3;
            // 
            // labelSendCount
            // 
            this.labelSendCount.AutoSize = true;
            this.labelSendCount.Location = new System.Drawing.Point(447, 1);
            this.labelSendCount.Name = "labelSendCount";
            this.labelSendCount.Size = new System.Drawing.Size(41, 12);
            this.labelSendCount.TabIndex = 1;
            this.labelSendCount.Text = "Send:0";
            // 
            // checkBoxHexSend
            // 
            this.checkBoxHexSend.AutoSize = true;
            this.checkBoxHexSend.Location = new System.Drawing.Point(90, 0);
            this.checkBoxHexSend.Name = "checkBoxHexSend";
            this.checkBoxHexSend.Size = new System.Drawing.Size(43, 16);
            this.checkBoxHexSend.TabIndex = 0;
            this.checkBoxHexSend.Text = "Hex";
            this.checkBoxHexSend.UseVisualStyleBackColor = true;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(432, 20);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // checkBoxHexView
            // 
            this.checkBoxHexView.AutoSize = true;
            this.checkBoxHexView.Location = new System.Drawing.Point(126, 50);
            this.checkBoxHexView.Name = "checkBoxHexView";
            this.checkBoxHexView.Size = new System.Drawing.Size(73, 16);
            this.checkBoxHexView.TabIndex = 0;
            this.checkBoxHexView.Text = "Hex view";
            this.checkBoxHexView.UseVisualStyleBackColor = true;
            // 
            // labelGetCount
            // 
            this.labelGetCount.AutoSize = true;
            this.labelGetCount.Location = new System.Drawing.Point(473, 51);
            this.labelGetCount.Name = "labelGetCount";
            this.labelGetCount.Size = new System.Drawing.Size(35, 12);
            this.labelGetCount.TabIndex = 1;
            this.labelGetCount.Text = "Get:0";
            // 
            // checkBoxNewlineSend
            // 
            this.checkBoxNewlineSend.AutoSize = true;
            this.checkBoxNewlineSend.Location = new System.Drawing.Point(201, 392);
            this.checkBoxNewlineSend.Name = "checkBoxNewlineSend";
            this.checkBoxNewlineSend.Size = new System.Drawing.Size(73, 16);
            this.checkBoxNewlineSend.TabIndex = 0;
            this.checkBoxNewlineSend.Text = "New line";
            this.checkBoxNewlineSend.UseVisualStyleBackColor = true;
            // 
            // SerialportSampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 460);
            this.Controls.Add(this.checkBoxNewlineSend);
            this.Controls.Add(this.labelGetCount);
            this.Controls.Add(this.checkBoxHexView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonOpenClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBaudrate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboPortName);
            this.Name = "SerialportSampleForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SerialportSampleForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboPortName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBaudrate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOpenClose;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxNewlineGet;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txSend;
        private System.Windows.Forms.Label labelSendCount;
        private System.Windows.Forms.CheckBox checkBoxHexSend;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.CheckBox checkBoxHexView;
        private System.Windows.Forms.Label labelGetCount;
        private System.Windows.Forms.CheckBox checkBoxNewlineSend;
        private System.Windows.Forms.TextBox txGet;
    }
}

