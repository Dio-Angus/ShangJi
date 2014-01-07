using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO.Ports;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort1 = new SerialPort();
        private StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            serialPort1.PortName = textBox3.Text;

            serialPort1.BaudRate = 9600;

            serialPort1.Open();

            byte[] data = Encoding.Unicode.GetBytes(textBox1.Text);

            string str = Convert.ToBase64String(data);

            serialPort1.WriteLine(str);

            MessageBox.Show("数据发送成功！", "系统提示");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            byte[] data = Convert.FromBase64String(serialPort1.ReadLine());

            textBox2.Text = Encoding.Unicode.GetString(data);

            serialPort1.Close();

            MessageBox.Show("数据接收成功！", "系统提示");

        }
    }
}
