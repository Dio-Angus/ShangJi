using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;

namespace test
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// tcp通讯客户端
        /// </summary>
        private TcpClient client;

        /// <summary>
        /// tcp数据流
        /// </summary>
        private NetworkStream ns;

        /// <summary>
        /// 监听线程
        /// </summary>
        private Thread _thread;

        /// <summary>
        /// 主线程控件更新
        /// </summary>
        /// <param name="s"></param>
        private delegate void UpdateText(string s);

        public Form1()
        {
            InitializeComponent();

            //test bit储存顺序
            bool[] b = new bool[5] { true, true, false, false, true };
            BitArray ba = new BitArray(b);
            for (int i = 0; i < 5; i++)
            {
                // MessageBox.Show(ba[i].ToString());
            }

            //test List长度确定
            List<byte> buffer = new List<byte>();
            for (int i = 0; i < 22;i++ )
                buffer.Add(123);
            buffer.Add(22);
            if (2 >= buffer.Count)
            {
                // MessageBox.Show("List到达边界");
            }

            //test byte数组0转化成bit数组
            byte[] bt = new byte[1]{0};
            BitArray ba2 = new BitArray(bt);
            for (int i = 0; i < 8; i++)
            {
                 //MessageBox.Show(ba2[i].ToString());
            }

            int n = buffer[22];
            //MessageBox.Show(buffer[n].ToString());

        }

        //连接
        public void Link()
        {
            try
            {
                string ip = textBox3.Text;
                int port = Convert.ToInt32(textBox4.Text);
                //ip连接
                client = new TcpClient(ip, port);
                ns = client.GetStream();

                //button1.PerformClick();

                startThread();
            }
            catch
            {
                MessageBox.Show("连接出错");
                return;
            }
            finally
            {
                button2.Text = "已连接";
                button2.Enabled = false;
            }
        }

        private void startThread()
        {        
            //监听线程启动
                _thread = new Thread(ReceiveThread);
                _thread.IsBackground = true;
                _thread.Start();
        }

        //发送
        public void Send(string s)
        {
            try
            {
                List<string> sArr = new List<string>();
                for (int i = 0; i < s.Length / 2; i++)
                {
                    sArr.Add(s.Substring(2 * i, 2));
                }
                List<byte> buffer = new List<byte>();
                for (int i = 0; i < sArr.Count; i++)
                {
                    Byte bit;
                    if (this.IsByte(sArr[i], out bit))
                    {
                        buffer.Add(bit);
                    }
                }
                ns.Write(buffer.ToArray(), 0, buffer.Count);
            }
            catch
            {
                MessageBox.Show("发送出错");
            }
        }

        private bool IsByte(string s, out byte bit)
        {
            try
            {
                bit = byte.Parse(s, System.Globalization.NumberStyles.AllowHexSpecifier);
                return true;
            }
            catch
            {
                bit = default(byte);
                return false;
            }
        }

        //接收
        private void ReceiveThread()
        {
            string s = null;
            while (true)
            {
                byte[] readBuffer = new byte[this.client.ReceiveBufferSize];
                this.ns.Read(readBuffer, 0, this.client.ReceiveBufferSize);
                s=circulation(readBuffer);
                //Invoke修改listview
                UpdateText ut = new UpdateText(UpdateTextBox1);
                this.Invoke(ut, s);
            }
        }

        private string circulation(byte[] buffer)
        {
            string s = null;
            for (int i = 0; i < buffer[2] + 3; i++)
            {
                s += buffer[i].ToString("X2") + " ";
            }
            return s;
        }

        private void UpdateTextBox1(string s)
        {
            this.textBox2.Text += s + "\r\n";
            this.textBox2.SelectionStart = this.textBox2.Text.Length;
            this.textBox2.ScrollToCaret();
        }

        //发送按钮
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != null)
                {
                    Send(textBox1.Text);
                }
            }
            catch
            {
                MessageBox.Show("请确认是否正确的指令格式\n实例：aa55020380");
            }
        }

        //连接按钮
        private void button2_Click(object sender, EventArgs e)
        {
            Link();
        }

        //接收按钮
        private void button3_Click(object sender, EventArgs e)
        {
            byte[] readBuffer = new byte[this.client.ReceiveBufferSize];
            this.ns.Read(readBuffer, 0, this.client.ReceiveBufferSize);
            string s = circulation(readBuffer);
                        this.textBox2.Text += s + "\r\n";
            this.textBox2.SelectionStart = this.textBox2.Text.Length;
            this.textBox2.ScrollToCaret();
        }

    }
}
