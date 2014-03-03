namespace tcp
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btSocket0Write = new System.Windows.Forms.Button();
            this.btSocket0 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btSocket2Write = new System.Windows.Forms.Button();
            this.btSocket2 = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.btSocket3Write = new System.Windows.Forms.Button();
            this.btSocket3 = new System.Windows.Forms.Button();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.btSocket1Write = new System.Windows.Forms.Button();
            this.btSocket1 = new System.Windows.Forms.Button();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btGetData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.btOtherWrite = new System.Windows.Forms.Button();
            this.btOther = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btMemory = new System.Windows.Forms.Button();
            this.btSetData = new System.Windows.Forms.Button();
            this.btRestart = new System.Windows.Forms.Button();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.comboPortName = new System.Windows.Forms.ComboBox();
            this.comboBaudrate = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.column0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.btLink = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.btSocket0Write);
            this.groupBox1.Controls.Add(this.btSocket0);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(28, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 145);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "评估板Socket0参数";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "TCP服务器",
            "TCP客户端",
            "UDP模式"});
            this.comboBox1.Location = new System.Drawing.Point(108, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(148, 20);
            this.comboBox1.TabIndex = 5;
            // 
            // btSocket0Write
            // 
            this.btSocket0Write.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btSocket0Write.Location = new System.Drawing.Point(287, 90);
            this.btSocket0Write.Name = "btSocket0Write";
            this.btSocket0Write.Size = new System.Drawing.Size(75, 25);
            this.btSocket0Write.TabIndex = 4;
            this.btSocket0Write.Text = "设置";
            this.btSocket0Write.UseVisualStyleBackColor = true;
            this.btSocket0Write.Click += new System.EventHandler(this.btSocket0Write_Click);
            // 
            // btSocket0
            // 
            this.btSocket0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btSocket0.Location = new System.Drawing.Point(287, 47);
            this.btSocket0.Name = "btSocket0";
            this.btSocket0.Size = new System.Drawing.Size(75, 25);
            this.btSocket0.TabIndex = 4;
            this.btSocket0.Text = "读取";
            this.btSocket0.UseVisualStyleBackColor = true;
            this.btSocket0.Click += new System.EventHandler(this.btSocket0_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(108, 84);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(148, 21);
            this.textBox6.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(28, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "目的IP地址";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(108, 111);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(148, 21);
            this.textBox5.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(28, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "目的端口号";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(108, 57);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(148, 21);
            this.textBox4.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(28, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "端口号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(28, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "端口工作模式";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.btSocket2Write);
            this.groupBox2.Controls.Add(this.btSocket2);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox2.Location = new System.Drawing.Point(28, 379);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 145);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "评估板Socket2参数";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "TCP服务器",
            "TCP客户端",
            "UDP模式"});
            this.comboBox2.Location = new System.Drawing.Point(108, 33);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(148, 20);
            this.comboBox2.TabIndex = 5;
            // 
            // btSocket2Write
            // 
            this.btSocket2Write.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btSocket2Write.Location = new System.Drawing.Point(287, 90);
            this.btSocket2Write.Name = "btSocket2Write";
            this.btSocket2Write.Size = new System.Drawing.Size(75, 25);
            this.btSocket2Write.TabIndex = 4;
            this.btSocket2Write.Text = "设置";
            this.btSocket2Write.UseVisualStyleBackColor = true;
            this.btSocket2Write.Click += new System.EventHandler(this.btSocket2Write_Click);
            // 
            // btSocket2
            // 
            this.btSocket2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btSocket2.Location = new System.Drawing.Point(287, 50);
            this.btSocket2.Name = "btSocket2";
            this.btSocket2.Size = new System.Drawing.Size(75, 25);
            this.btSocket2.TabIndex = 4;
            this.btSocket2.Text = "读取";
            this.btSocket2.UseVisualStyleBackColor = true;
            this.btSocket2.Click += new System.EventHandler(this.btSocket2_Click);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(108, 87);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(148, 21);
            this.textBox10.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label11.Location = new System.Drawing.Point(30, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "目的IP地址";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(30, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "端口工作模式";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(108, 114);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(148, 21);
            this.textBox9.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Location = new System.Drawing.Point(30, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "端口号";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label10.Location = new System.Drawing.Point(29, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "目的端口号";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(108, 60);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(148, 21);
            this.textBox8.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox3);
            this.groupBox3.Controls.Add(this.btSocket3Write);
            this.groupBox3.Controls.Add(this.btSocket3);
            this.groupBox3.Controls.Add(this.textBox14);
            this.groupBox3.Controls.Add(this.textBox11);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.textBox12);
            this.groupBox3.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox3.Location = new System.Drawing.Point(494, 379);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 145);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "评估板Socket3参数";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "TCP服务器",
            "TCP客户端",
            "UDP模式"});
            this.comboBox3.Location = new System.Drawing.Point(112, 36);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(148, 20);
            this.comboBox3.TabIndex = 5;
            // 
            // btSocket3Write
            // 
            this.btSocket3Write.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btSocket3Write.Location = new System.Drawing.Point(287, 90);
            this.btSocket3Write.Name = "btSocket3Write";
            this.btSocket3Write.Size = new System.Drawing.Size(75, 25);
            this.btSocket3Write.TabIndex = 4;
            this.btSocket3Write.Text = "设置";
            this.btSocket3Write.UseVisualStyleBackColor = true;
            this.btSocket3Write.Click += new System.EventHandler(this.btSocket3Write_Click);
            // 
            // btSocket3
            // 
            this.btSocket3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btSocket3.Location = new System.Drawing.Point(287, 50);
            this.btSocket3.Name = "btSocket3";
            this.btSocket3.Size = new System.Drawing.Size(75, 25);
            this.btSocket3.TabIndex = 4;
            this.btSocket3.Text = "读取";
            this.btSocket3.UseVisualStyleBackColor = true;
            this.btSocket3.Click += new System.EventHandler(this.btSocket3_Click);
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(112, 90);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(148, 21);
            this.textBox14.TabIndex = 3;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(112, 63);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(148, 21);
            this.textBox11.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label15.Location = new System.Drawing.Point(26, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 2;
            this.label15.Text = "目的IP地址";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label12.Location = new System.Drawing.Point(26, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "目的端口号";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label14.Location = new System.Drawing.Point(26, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "端口工作模式";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label13.Location = new System.Drawing.Point(26, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "端口号";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(112, 117);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(148, 21);
            this.textBox12.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox4);
            this.groupBox4.Controls.Add(this.btSocket1Write);
            this.groupBox4.Controls.Add(this.btSocket1);
            this.groupBox4.Controls.Add(this.textBox18);
            this.groupBox4.Controls.Add(this.textBox15);
            this.groupBox4.Controls.Add(this.textBox16);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox4.Location = new System.Drawing.Point(494, 224);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(392, 145);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "评估板Socket1参数";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "TCP服务器",
            "TCP客户端",
            "UDP模式"});
            this.comboBox4.Location = new System.Drawing.Point(112, 33);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(148, 20);
            this.comboBox4.TabIndex = 5;
            // 
            // btSocket1Write
            // 
            this.btSocket1Write.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btSocket1Write.Location = new System.Drawing.Point(287, 90);
            this.btSocket1Write.Name = "btSocket1Write";
            this.btSocket1Write.Size = new System.Drawing.Size(75, 25);
            this.btSocket1Write.TabIndex = 4;
            this.btSocket1Write.Text = "设置";
            this.btSocket1Write.UseVisualStyleBackColor = true;
            this.btSocket1Write.Click += new System.EventHandler(this.btSocket1Write_Click);
            // 
            // btSocket1
            // 
            this.btSocket1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btSocket1.Location = new System.Drawing.Point(287, 47);
            this.btSocket1.Name = "btSocket1";
            this.btSocket1.Size = new System.Drawing.Size(75, 25);
            this.btSocket1.TabIndex = 4;
            this.btSocket1.Text = "读取";
            this.btSocket1.UseVisualStyleBackColor = true;
            this.btSocket1.Click += new System.EventHandler(this.btSocket1_Click);
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(112, 87);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(148, 21);
            this.textBox18.TabIndex = 3;
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(112, 114);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(148, 21);
            this.textBox15.TabIndex = 3;
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(112, 60);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(148, 21);
            this.textBox16.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label16.Location = new System.Drawing.Point(26, 63);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 2;
            this.label16.Text = "端口号";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label19.Location = new System.Drawing.Point(26, 90);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 2;
            this.label19.Text = "目的IP地址";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label17.Location = new System.Drawing.Point(26, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 2;
            this.label17.Text = "端口工作模式";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label18.Location = new System.Drawing.Point(26, 117);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 2;
            this.label18.Text = "目的端口号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(75, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP地址";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(136, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "192.168.1.80";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(75, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(136, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 21);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "5000";
            // 
            // btGetData
            // 
            this.btGetData.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btGetData.Location = new System.Drawing.Point(35, 117);
            this.btGetData.Name = "btGetData";
            this.btGetData.Size = new System.Drawing.Size(100, 30);
            this.btGetData.TabIndex = 4;
            this.btGetData.Text = "读取所有数据";
            this.btGetData.UseVisualStyleBackColor = true;
            this.btGetData.Click += new System.EventHandler(this.btGetData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(13, 535);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "未连接";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox20);
            this.groupBox5.Controls.Add(this.btOtherWrite);
            this.groupBox5.Controls.Add(this.btOther);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.textBox22);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.textBox23);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox5.Location = new System.Drawing.Point(494, 93);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(392, 116);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "评估板其它参数";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(112, 84);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(148, 21);
            this.textBox20.TabIndex = 3;
            // 
            // btOtherWrite
            // 
            this.btOtherWrite.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btOtherWrite.Location = new System.Drawing.Point(287, 74);
            this.btOtherWrite.Name = "btOtherWrite";
            this.btOtherWrite.Size = new System.Drawing.Size(75, 25);
            this.btOtherWrite.TabIndex = 4;
            this.btOtherWrite.Text = "设置";
            this.btOtherWrite.UseVisualStyleBackColor = true;
            this.btOtherWrite.Click += new System.EventHandler(this.btOtherWrite_Click);
            // 
            // btOther
            // 
            this.btOther.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btOther.Location = new System.Drawing.Point(287, 33);
            this.btOther.Name = "btOther";
            this.btOther.Size = new System.Drawing.Size(75, 25);
            this.btOther.TabIndex = 4;
            this.btOther.Text = "读取";
            this.btOther.UseVisualStyleBackColor = true;
            this.btOther.Click += new System.EventHandler(this.btOther_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label21.Location = new System.Drawing.Point(26, 87);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 2;
            this.label21.Text = "子网掩码";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(112, 57);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(148, 21);
            this.textBox22.TabIndex = 3;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label23.Location = new System.Drawing.Point(26, 59);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(83, 12);
            this.label23.TabIndex = 2;
            this.label23.Text = "评估板MAC地址";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(112, 30);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(148, 21);
            this.textBox23.TabIndex = 3;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label24.Location = new System.Drawing.Point(26, 33);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 12);
            this.label24.TabIndex = 2;
            this.label24.Text = "网关IP地址";
            // 
            // btMemory
            // 
            this.btMemory.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btMemory.Location = new System.Drawing.Point(141, 117);
            this.btMemory.Name = "btMemory";
            this.btMemory.Size = new System.Drawing.Size(100, 30);
            this.btMemory.TabIndex = 4;
            this.btMemory.Text = "读取内存数据";
            this.btMemory.UseVisualStyleBackColor = true;
            this.btMemory.Click += new System.EventHandler(this.btMemory_Click);
            // 
            // btSetData
            // 
            this.btSetData.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btSetData.Location = new System.Drawing.Point(35, 161);
            this.btSetData.Name = "btSetData";
            this.btSetData.Size = new System.Drawing.Size(100, 30);
            this.btSetData.TabIndex = 4;
            this.btSetData.Text = "设置所有数据";
            this.btSetData.UseVisualStyleBackColor = true;
            this.btSetData.Click += new System.EventHandler(this.btSetData_Click);
            // 
            // btRestart
            // 
            this.btRestart.FlatAppearance.BorderSize = 0;
            this.btRestart.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btRestart.Location = new System.Drawing.Point(494, 29);
            this.btRestart.Name = "btRestart";
            this.btRestart.Size = new System.Drawing.Size(115, 38);
            this.btRestart.TabIndex = 4;
            this.btRestart.Text = "重启Demo板";
            this.btRestart.UseVisualStyleBackColor = true;
            this.btRestart.Click += new System.EventHandler(this.btRestart_Click);
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "以太网通信",
            "RS-232端口通信"});
            this.comboBox5.Location = new System.Drawing.Point(679, 44);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 20);
            this.comboBox5.TabIndex = 6;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label20.Location = new System.Drawing.Point(677, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 12);
            this.label20.TabIndex = 7;
            this.label20.Text = "通信模式选择";
            // 
            // comboPortName
            // 
            this.comboPortName.FormattingEnabled = true;
            this.comboPortName.Location = new System.Drawing.Point(136, 23);
            this.comboPortName.Name = "comboPortName";
            this.comboPortName.Size = new System.Drawing.Size(148, 20);
            this.comboPortName.TabIndex = 8;
            // 
            // comboBaudrate
            // 
            this.comboBaudrate.FormattingEnabled = true;
            this.comboBaudrate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBaudrate.Location = new System.Drawing.Point(136, 59);
            this.comboBaudrate.Name = "comboBaudrate";
            this.comboBaudrate.Size = new System.Drawing.Size(148, 20);
            this.comboBaudrate.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button1.Location = new System.Drawing.Point(141, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "清空数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // column0
            // 
            this.column0.Text = "接收";
            this.column0.Width = 221;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column0});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(247, 86);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(241, 162);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // btLink
            // 
            this.btLink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btLink.FlatAppearance.BorderSize = 0;
            this.btLink.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btLink.Location = new System.Drawing.Point(336, 29);
            this.btLink.Name = "btLink";
            this.btLink.Size = new System.Drawing.Size(115, 38);
            this.btLink.TabIndex = 4;
            this.btLink.Text = "连接";
            this.btLink.UseVisualStyleBackColor = true;
            this.btLink.Click += new System.EventHandler(this.btLink_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(784, 21);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 10;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(786, 62);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 21);
            this.textBox7.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 558);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btMemory);
            this.Controls.Add(this.btSetData);
            this.Controls.Add(this.btGetData);
            this.Controls.Add(this.btRestart);
            this.Controls.Add(this.btLink);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboPortName);
            this.Controls.Add(this.comboBaudrate);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "数据通信";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btLink;
        private System.Windows.Forms.Button btGetData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btSocket0;
        private System.Windows.Forms.Button btSocket2;
        private System.Windows.Forms.Button btSocket3;
        private System.Windows.Forms.Button btSocket1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button btOther;
        private System.Windows.Forms.Button btMemory;
        private System.Windows.Forms.Button btSocket0Write;
        private System.Windows.Forms.Button btSocket2Write;
        private System.Windows.Forms.Button btSocket3Write;
        private System.Windows.Forms.Button btSocket1Write;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Button btOtherWrite;
        private System.Windows.Forms.Button btSetData;
        private System.Windows.Forms.Button btRestart;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox comboPortName;
        private System.Windows.Forms.ComboBox comboBaudrate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader column0;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox7;
    }
}

