using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.Timers;

namespace tcp
{
    public partial class Form1 : Form
    {
        private string IP;
        private int portNum;
        private TcpClient client;  
        private NetworkStream ns; 
        /// <summary>
        /// 连接方式控制,0代表以太网，1代表RS-232
        /// </summary>
        private int a = 0;
        /// <summary>
        /// 0代表未连接，1代表已连接
        /// </summary>
        private int b = 0;
        private SerialPort comm = new SerialPort();  
        private StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。 
        /// <summary>
        /// 存放数据的二维泛型数组
        /// </summary>
        private List<List<byte>> Data = new List<List<byte>>();
        private System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();

            //初始化下拉串口名称列表框  
            string[] ports = SerialPort.GetPortNames();  
            Array.Sort(ports);  
            comboPortName.Items.AddRange(ports);  
            comboPortName.SelectedIndex = comboPortName.Items.Count > 0 ? 0 : -1;  
            comboBaudrate.SelectedIndex = comboBaudrate.Items.IndexOf("9600");  
            //初始化SerialPort对象  
            comm.NewLine = "/r/n";  
            comm.RtsEnable = true;
            //初始化timer
            aTimer.Tick += new EventHandler(TimeEvent);
            aTimer.Interval = 500;

            comboBox5.SelectedIndex = 0;
            btGetData.Enabled = false;
            btSetData.Enabled = false;
            btMemory.Enabled = false;
            btOther.Enabled = false;
            btOtherWrite.Enabled = false;
            btSocket0.Enabled = false;
            btSocket0Write.Enabled = false;
            btSocket1.Enabled = false;
            btSocket1Write.Enabled = false;
            btSocket2.Enabled = false;
            btSocket2Write.Enabled = false;
            btSocket3.Enabled = false;
            btSocket3Write.Enabled = false;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {  
            if (comboBox5.SelectedIndex == 0)
            {
                a = 0;
                label1.Text = "IP地址";
                label2.Text = "端口";
                textBox1.Show() ;
                textBox2.Show();
                comboPortName.Hide();
                comboBaudrate.Hide();
            }
            if (comboBox5.SelectedIndex == 1)
            {
                label1.Text = "串口";
                label2.Text = "波特率";
                a = 1;
                textBox1.Hide();
                textBox2.Hide();
                comboPortName.Show();
                comboBaudrate.Show();               
            }
        }

        private void btLink_Click(object sender, EventArgs e)
        {
            try
            {
                if (b == 0)
                {
                    if (a == 0)
                    {
                        IP = textBox1.Text;
                        portNum = int.Parse(textBox2.Text);
                        client = new TcpClient(IP, portNum);
                        ns = client.GetStream();
                        btGetData.Enabled = true;
                        btSetData.Enabled = true;
                        btMemory.Enabled = true;
                        btOther.Enabled = true;
                        btOtherWrite.Enabled = true;
                        btSocket0.Enabled = true;
                        btSocket0Write.Enabled = true;
                        btSocket1.Enabled = true;
                        btSocket1Write.Enabled = true;
                        btSocket2.Enabled = true;
                        btSocket2Write.Enabled = true;
                        btSocket3.Enabled = true;
                        btSocket3Write.Enabled = true;
                        btLink.Enabled = false;
                        label3.Text = "已连接上" + IP;
                        b = 1;
                    }
                    if (a == 1)
                    {
                        comm.PortName = comboPortName.Text;
                        comm.BaudRate = int.Parse(comboBaudrate.Text);
                        comm.Open();
                        btGetData.Enabled = true;
                        btSetData.Enabled = true;
                        btMemory.Enabled = true;
                        btOther.Enabled = true;
                        btOtherWrite.Enabled = true;
                        btSocket0.Enabled = true;
                        btSocket0Write.Enabled = true;
                        btSocket1.Enabled = true;
                        btSocket1Write.Enabled = true;
                        btSocket2.Enabled = true;
                        btSocket2Write.Enabled = true;
                        btSocket3.Enabled = true;
                        btSocket3Write.Enabled = true;
                        btLink.Enabled = false;
                        label3.Text = "已连接上" + IP;
                        b = 1;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btRestart_Click(object sender, EventArgs e)
        {
            if (b == 1)
            {
                send("aa 55 02 01 a0");
                if (a == 1)
                {
                    comm.Close();
                }
                btGetData.Enabled = false;
                btSetData.Enabled = false;
                btMemory.Enabled = false;
                btOther.Enabled = false;
                btOtherWrite.Enabled = false;
                btSocket0.Enabled = false;
                btSocket0Write.Enabled = false;
                btSocket1.Enabled = false;
                btSocket1Write.Enabled = false;
                btSocket2.Enabled = false;
                btSocket2Write.Enabled = false;
                btSocket3.Enabled = false;
                btSocket3Write.Enabled = false;
                btLink.Enabled = true;
                aTimer.Enabled = false;
                label3.Text = "请重新连接";
                b = 0;
            }
        }

        #region 读控制
        private void btGetData_Click(object sender, EventArgs e)
        {
            try
            {
                send("aa 55 02 00 90");
                readAll();
                setMessage(this.Data[0], textBox23, 0);
                setMessage(this.Data[1], textBox20, 0);
                setMessage(this.Data[2], textBox22, 1);

                setMessage(this.Data[4], textBox4, 2);
                setMessage(this.Data[5], textBox6, 0);
                setMessage(this.Data[6], textBox5, 2);
                setMessage(this.Data[7], comboBox1);

                setMessage(this.Data[8], textBox16, 2);
                setMessage(this.Data[9], textBox18, 0);
                setMessage(this.Data[10], textBox15, 2);
                setMessage(this.Data[11], comboBox4);

                setMessage(this.Data[12], textBox8, 2);
                setMessage(this.Data[13], textBox10, 0);
                setMessage(this.Data[14], textBox9, 2);
                setMessage(this.Data[15], comboBox2);

                setMessage(this.Data[16], textBox11, 2);
                setMessage(this.Data[17], textBox14, 0);
                setMessage(this.Data[18], textBox12, 2);
                setMessage(this.Data[19], comboBox3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                b = 0;
                label3.Text = "未连接";
                btGetData.Enabled = false;
                btSetData.Enabled = false;
                btMemory.Enabled = false;
                btOther.Enabled = false;
                btOtherWrite.Enabled = false;
                btSocket0.Enabled = false;
                btSocket0Write.Enabled = false;
                btSocket1.Enabled = false;
                btSocket1Write.Enabled = false;
                btSocket2.Enabled = false;
                btSocket2Write.Enabled = false;
                btSocket3.Enabled = false;
                btSocket3Write.Enabled = false;
            }
        }

        private void btMemory_Click(object sender, EventArgs e)
        {
            send("aa 55 02 00 91");

            aTimer.Enabled = true;
            
        }

        private void TimeEvent(object Sender,EventArgs e)
        {
            try
            {
                Data.Clear();
                List<byte> data = new List<byte>();
                byte bit;
                int read = 0;
                for (int i = 0; i < 100; i++)
                {
                    if (a == 0)
                    {
                        read = ns.ReadByte();
                    }
                    if (a == 1)
                    {
                        read = comm.ReadByte();
                    }
                    bit = byte.Parse(read.ToString("X"),
                                System.Globalization.NumberStyles.AllowHexSpecifier);
                    data.Add(bit);
                }
                Data.Add(data);
                listView1.Items.Add(new ListViewItem(setMessage(this.Data[0])));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                b = 0;
                label3.Text = "请重启Demo板";
                btGetData.Enabled = false;
                btSetData.Enabled = false;
                btMemory.Enabled = false;
                btOther.Enabled = false;
                btOtherWrite.Enabled = false;
                btSocket0.Enabled = false;
                btSocket0Write.Enabled = false;
                btSocket1.Enabled = false;
                btSocket1Write.Enabled = false;
                btSocket2.Enabled = false;
                btSocket2Write.Enabled = false;
                btSocket3.Enabled = false;
                btSocket3Write.Enabled = false;                
            }
        }

        private void btOther_Click(object sender, EventArgs e)
        {
            try
            {
                send("aa 55 02 03 14");
                string a = ns.ReadByte().ToString();
                MessageBox.Show(a);
                //网关IP地址
                send("aa 55 02 00 00");
                get(1);
                setMessage(this.Data[0], textBox23, 0);

                //评估板MAC地址
                send("aa 55 02 00 02");
                get(1);
                setMessage(this.Data[0], textBox22, 1);

                //子网掩码
                send("aa 55 02 00 01");
                get(1);
                setMessage(this.Data[0], textBox20, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                b = 0;
                label3.Text = "请重启Demo板";
                btGetData.Enabled = false;
                btSetData.Enabled = false;
                btMemory.Enabled = false;
                btOther.Enabled = false;
                btOtherWrite.Enabled = false;
                btSocket0.Enabled = false;
                btSocket0Write.Enabled = false;
                btSocket1.Enabled = false;
                btSocket1Write.Enabled = false;
                btSocket2.Enabled = false;
                btSocket2Write.Enabled = false;
                btSocket3.Enabled = false;
                btSocket3Write.Enabled = false;
            }
        }

        private void btSocket0_Click(object sender, EventArgs e)
        {
            try
            {
                //端口工作模式
                send("aa 55 02 00 13");
                get(1);
                setMessage(this.Data[0], comboBox1);

                //端口号
                send("aa 55 02 00 10");
                get(1);
                setMessage(this.Data[0], textBox4,2);

                //目的IP地址
                send("aa 55 02 00 11");
                get(1);
                setMessage(this.Data[0], textBox6,0);

                //目的端口号
                send("aa 55 02 00 12");
                get(1);
                setMessage(this.Data[0], textBox5,2);
            }
            catch (Exception ex)
            {
                b = 0;
                MessageBox.Show(ex.ToString());
                label3.Text = "请重启Demo板";
                btGetData.Enabled = false;
                btSetData.Enabled = false;
                btMemory.Enabled = false;
                btOther.Enabled = false;
                btOtherWrite.Enabled = false;
                btSocket0.Enabled = false;
                btSocket0Write.Enabled = false;
                btSocket1.Enabled = false;
                btSocket1Write.Enabled = false;
                btSocket2.Enabled = false;
                btSocket2Write.Enabled = false;
                btSocket3.Enabled = false;
                btSocket3Write.Enabled = false;
            }
        }

        private void btSocket1_Click(object sender, EventArgs e)
        {
            try
            {
                //端口工作模式
                send("aa 55 02 00 23");
                get(1);
                setMessage(this.Data[0], comboBox4);

                //端口号
                send("aa 55 02 00 20");
                get(1);
                setMessage(this.Data[0], textBox16,2);

                //目的IP地址
                send("aa 55 02 00 21");
                get(1);
                setMessage(this.Data[0], textBox18,0);

                //目的端口号
                send("aa 55 02 00 22");
                get(1);
                setMessage(this.Data[0], textBox15,2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                b = 0;
                label3.Text = "请重启Demo板";
                btGetData.Enabled = false;
                btSetData.Enabled = false;
                btMemory.Enabled = false;
                btOther.Enabled = false;
                btOtherWrite.Enabled = false;
                btSocket0.Enabled = false;
                btSocket0Write.Enabled = false;
                btSocket1.Enabled = false;
                btSocket1Write.Enabled = false;
                btSocket2.Enabled = false;
                btSocket2Write.Enabled = false;
                btSocket3.Enabled = false;
                btSocket3Write.Enabled = false;
            }
        }

        private void btSocket2_Click(object sender, EventArgs e)
        {
            try
            {
                //端口工作模式
                send("aa 55 02 00 33");
                get(1);
                setMessage(this.Data[0], comboBox2);

                //端口号
                send("aa 55 02 00 30");
                get(1);
                setMessage(this.Data[0], textBox8,2);

                //目的IP地址
                send("aa 55 02 00 31");
                get(1);
                setMessage(this.Data[0], textBox10,0);

                //目的端口号
                send("aa 55 02 00 32");
                get(1);
                setMessage(this.Data[0], textBox9,2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                b = 0;
                label3.Text = "请重启Demo板";
                btGetData.Enabled = false;
                btSetData.Enabled = false;
                btMemory.Enabled = false;
                btOther.Enabled = false;
                btOtherWrite.Enabled = false;
                btSocket0.Enabled = false;
                btSocket0Write.Enabled = false;
                btSocket1.Enabled = false;
                btSocket1Write.Enabled = false;
                btSocket2.Enabled = false;
                btSocket2Write.Enabled = false;
                btSocket3.Enabled = false;
                btSocket3Write.Enabled = false;
            }
        }

        private void btSocket3_Click(object sender, EventArgs e)
        {
            try
            {
                //端口工作模式
                send("aa 55 02 00 43");
                get(1);
                setMessage(this.Data[0], comboBox3);

                //端口号
                send("aa 55 02 00 40");
                get(1);
                setMessage(this.Data[0], textBox11,2);

                //目的IP地址
                send("aa 55 02 00 41");
                get(1);
                setMessage(this.Data[0], textBox14,0);

                //目的端口号
                send("aa 55 02 00 42");
                get(1);
                setMessage(this.Data[0], textBox12,2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                b = 0;
                label3.Text = "请重启Demo板";
                btGetData.Enabled = false;
                btSetData.Enabled = false;
                btMemory.Enabled = false;
                btOther.Enabled = false;
                btOtherWrite.Enabled = false;
                btSocket0.Enabled = false;
                btSocket0Write.Enabled = false;
                btSocket1.Enabled = false;
                btSocket1Write.Enabled = false;
                btSocket2.Enabled = false;
                btSocket2Write.Enabled = false;
                btSocket3.Enabled = false;
                btSocket3Write.Enabled = false;
            }
        }
        #endregion

        #region 写控制
        private void btSetData_Click(object sender, EventArgs e)
        {
            try
            {
                if (getMessage(textBox23, 0) == "0" || getMessage(textBox20, 0) == "0" || getMessage(textBox22, 1) == "0" ||
                    getMessage(textBox4, 2) == "0" || getMessage(textBox6, 0) == "0" || getMessage(textBox5, 2) == "0" || getMessage(comboBox1) == "0" ||
                    getMessage(textBox16, 2) == "0" || getMessage(textBox18, 0) == "0" || getMessage(textBox15, 2) == "0" || getMessage(comboBox4) == "0" ||
                    getMessage(textBox8, 2) == "0" || getMessage(textBox10, 0) == "0" || getMessage(textBox9, 2) == "0" || getMessage(comboBox2) == "0" ||
                    getMessage(textBox11, 2) == "0" || getMessage(textBox14, 0) == "0" || getMessage(textBox12, 2) == "0" || getMessage(comboBox3) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                send("aa 55 38 01 90" + getMessage(textBox23, 0) + getMessage(textBox20, 0) + getMessage(textBox22, 1) + getMessage(textBox1, 0)
                    + getMessage(textBox4, 2) + getMessage(textBox6, 0) + getMessage(textBox5, 2) + getMessage(comboBox1)
                    + getMessage(textBox16, 2) + getMessage(textBox18, 0) + getMessage(textBox15, 2) + getMessage(comboBox4)
                    + getMessage(textBox8, 2) + getMessage(textBox10, 0) + getMessage(textBox9, 2) + getMessage(comboBox2)
                    + getMessage(textBox11, 2) + getMessage(textBox14, 0) + getMessage(textBox12, 2) + getMessage(comboBox3));
                if (a == 0)
                {
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            finally 
            {
                MessageBox.Show("设置成功");
            }
        }

        private void btOtherWrite_Click(object sender, EventArgs e)
        {
            try
            {
                //设置网关IP地址
                if (getMessage(textBox23, 0) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 00" + getMessage(textBox23, 0));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }  
                
                //设置子网掩码
                if (getMessage(textBox20, 0) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 01" + getMessage(textBox20, 0));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }

                //设置评估板MAC地址
                if (getMessage(textBox22, 1) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 02" + getMessage(textBox22, 1));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                MessageBox.Show("设置成功");
            }
        }

        private void btSocket0Write_Click(object sender, EventArgs e)
        {
            try
            {
                //设置端口工作模式
                if (getMessage(comboBox1) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 13" + getMessage(comboBox1));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }

                //设置端口号
                if (getMessage(textBox4, 2) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 10" + getMessage(textBox4, 2));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }

                //设置目的IP地址
                if (getMessage(textBox6, 0) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 11" + getMessage(textBox6, 0));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }

                //设置目的端口号
                if (getMessage(textBox5, 2) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 12" + getMessage(textBox5, 2));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                MessageBox.Show("设置成功");
            }
        }

        private void btSocket1Write_Click(object sender, EventArgs e)
        {
            try
            {
                //设置端口工作模式
                if (getMessage(comboBox4) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 23" + getMessage(comboBox4));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }

                //设置端口号
                if (getMessage(textBox16, 2) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 20" + getMessage(textBox16, 2));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }

                //设置目的IP地址
                if (getMessage(textBox18, 0) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 21" + getMessage(textBox18, 0));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }

                //设置目的端口号
                if (getMessage(textBox15, 2) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 22" + getMessage(textBox15, 2));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                MessageBox.Show("设置成功");
            }
        }

        private void btSocket2Write_Click(object sender, EventArgs e)
        {
            try
            {
                //设置端口工作模式
                if (getMessage(comboBox2) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 33" + getMessage(comboBox2));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }

                //设置端口号
                if (getMessage(textBox8, 2) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 30" + getMessage(textBox8, 2));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }

                //设置目的IP地址
                if (getMessage(textBox10, 0) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 31" + getMessage(textBox10, 0));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }

                //设置目的端口号
                if (getMessage(textBox9, 2) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 32" + getMessage(textBox9, 2));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                MessageBox.Show("设置成功");
            }
        }

        private void btSocket3Write_Click(object sender, EventArgs e)
        {
            try
            {
                //设置端口工作模式
                if (getMessage(comboBox3) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 43" + getMessage(comboBox3));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }

                //设置端口号
                if (getMessage(textBox11, 2) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 40" + getMessage(textBox11, 2));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }

                //设置目的IP地址
                if (getMessage(textBox14, 0) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 41" + getMessage(textBox14, 0));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }

                //设置目的端口号
                if (getMessage(textBox12, 2) == "0")
                {
                    MessageBox.Show("输入出错");
                    return;
                }
                else
                {
                    send("aa 55 06 01 42" + getMessage(textBox12, 2));
                    get(1);
                    if (Data[0][3].ToString() == "81")
                    {
                        MessageBox.Show("输入出错");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                MessageBox.Show("设置成功");
            }
        }
        #endregion

        #region 方法

        private void send(string s)
        {
            try
            {
                string[] sArr = s.Trim().Split(' ');
                List<byte> buffer = new List<byte>();
                for (int i = 0; i < sArr.Length; i++)
                {
                    Byte bit;
                    if (this.IsByte(sArr[i], out bit))
                    {
                        buffer.Add(bit);
                    }
                }
                if (a == 0)//以太网方式
                {
                    ns.Write(buffer.ToArray(), 0, buffer.Count);
                }
                if (a == 1)//RS-232方式
                {
                    comm.Write(buffer.ToArray(),0,buffer.Count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                label3.Text = "请重启Demo板";
                btGetData.Enabled = false;
                btSetData.Enabled = false;
                btMemory.Enabled = false;
                btOther.Enabled = false;
                btOtherWrite.Enabled = false;
                btSocket0.Enabled = false;
                btSocket0Write.Enabled = false;
                btSocket1.Enabled = false;
                btSocket1Write.Enabled = false;
                btSocket2.Enabled = false;
                btSocket2Write.Enabled = false;
                btSocket3.Enabled = false;
                btSocket3Write.Enabled = false;
            }
        }

        private void get(int count)
        {
            Data.Clear();
            for (int i = 0; i < count; i++)
            {
                read();
            }
        }

        private void read()
        {
            try
            {
                List<byte> data = new List<byte>();
                byte bit;
                int read = 0;
                int r = 0, s = 0, t = 0, num = 200;
                for (int i = 0; i < num; i++)
                {
                    if (t == 0)
                    {
                        if (s == 0)
                        {
                            if (r == 0)
                            {
                                if (a == 0)
                                {
                                    read = ns.ReadByte();
                                }
                                if (a == 1)
                                {
                                    read = comm.ReadByte();
                                }
                                bit = byte.Parse(read.ToString("X"),                                         
                                    System.Globalization.NumberStyles.AllowHexSpecifier);
                                if (Convert.ToInt32(bit) == 170)
                                {
                                    r = 1;
                                    data.Add(bit);
                                }
                            }
                            else
                            {
                                if (a == 0)
                                {
                                    read = ns.ReadByte();
                                }
                                if (a == 1)
                                {
                                    read = comm.ReadByte();
                                }
                                bit = byte.Parse(read.ToString("X"),
                                            System.Globalization.NumberStyles.AllowHexSpecifier);
                                if (Convert.ToInt32(bit) == 85)
                                {
                                    s = 1;
                                    data.Add(bit);
                                }
                                else if (Convert.ToInt32(bit) == 170)
                                {
                                    data.Clear();
                                    data.Add(bit);
                                }
                                else
                                {
                                    r = 0;
                                }
                            }
                        }
                        else
                        {
                            if (a == 0)
                            {
                                read = ns.ReadByte();
                            }
                            if (a == 1)
                            {
                                read = comm.ReadByte();
                            }
                            bit = byte.Parse(read.ToString("X"),
                                        System.Globalization.NumberStyles.AllowHexSpecifier);
                            num = read;
                            i = -1;
                            t = 1;
                            data.Add(bit);
                        }
                    }
                    else
                    {
                        if (a == 0)
                        {
                            read = ns.ReadByte();
                        }
                        if (a == 1)
                        {
                            read = comm.ReadByte();
                        }
                        bit = byte.Parse(read.ToString("X"),
                                    System.Globalization.NumberStyles.AllowHexSpecifier);
                        data.Add(bit);
                    }
                }
                Data.Add(data);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                label3.Text = "请重启Demo板";
                btGetData.Enabled = false;
                btSetData.Enabled = false;
                btMemory.Enabled = false;
                btOther.Enabled = false;
                btOtherWrite.Enabled = false;
                btSocket0.Enabled = false;
                btSocket0Write.Enabled = false;
                btSocket1.Enabled = false;
                btSocket1Write.Enabled = false;
                btSocket2.Enabled = false;
                btSocket2Write.Enabled = false;
                btSocket3.Enabled = false;
                btSocket3Write.Enabled = false;
                b = 0;
            }
        }

        private void readAll()
        {
            try
            {
                Data.Clear();
                List<byte> data = new List<byte>();
                byte bit;
                int read = 0;
                int r = 0, s = 0, t = 0, num = 200;
                for (int i = 0; i < num; i++)
                {
                    if (t == 0)
                    {
                        if (s == 0)
                        {
                            if (r == 0)
                            {
                                if (a == 0)
                                {
                                    read = ns.ReadByte();
                                }
                                if (a == 1)
                                {
                                    read = comm.ReadByte();
                                }
                                bit = byte.Parse(read.ToString("X"),
                                            System.Globalization.NumberStyles.AllowHexSpecifier);
                                if (Convert.ToInt32(bit) == 170)
                                {
                                    r = 1;
                                    data.Add(bit);
                                }
                            }
                            else
                            {
                                if (a == 0)
                                {
                                    read = ns.ReadByte();
                                }
                                if (a == 1)
                                {
                                    read = comm.ReadByte();
                                }
                                bit = byte.Parse(read.ToString("X"),
                                            System.Globalization.NumberStyles.AllowHexSpecifier);
                                if (Convert.ToInt32(bit) == 85)
                                {
                                    s = 1;
                                    data.Add(bit);
                                }
                                else if (Convert.ToInt32(bit) == 170)
                                {
                                    data.Clear();
                                    data.Add(bit);
                                }
                                else
                                {
                                    r = 0;
                                }
                            }
                        }
                        else
                        {
                            if (a == 0)
                            {
                                read = ns.ReadByte();
                            }
                            if (a == 1)
                            {
                                read = comm.ReadByte();
                            }
                            bit = byte.Parse(read.ToString("X"),
                                        System.Globalization.NumberStyles.AllowHexSpecifier);
                            num = 6;
                            i = -1;
                            t = 1;
                            data.Add(bit);
                        }
                    }
                    else
                    {
                        if (a == 0)
                        {
                            read = ns.ReadByte();
                        }
                        if (a == 1)
                        {
                            read = comm.ReadByte();
                        }
                        bit = byte.Parse(read.ToString("X"),
                                    System.Globalization.NumberStyles.AllowHexSpecifier);
                        data.Add(bit);
                    }
                }
                Data.Add(data);//网关IP地址；

                getData(4);//子网掩码
                getData(6);//评估板MAC地址
                getData(4);//源IP地址

                //Socket0
                getData(2);//端口号
                getData(4);//目的IP地址
                getData(2);//目的端口号
                getData(1);//端口工作模式

                //Socket1
                getData(2);//端口号
                getData(4);//目的IP地址
                getData(2);//目的端口号
                getData(1);//端口工作模式

                //Socket2
                getData(2);//端口号
                getData(4);//目的IP地址
                getData(2);//目的端口号
                getData(1);//端口工作模式

                //Socket3
                getData(2);//端口号
                getData(4);//目的IP地址
                getData(2);//目的端口号
                getData(1);//端口工作模式
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void getData(int n)
        {
            List<byte> data = new List<byte>();
            byte bit;
            int read = 0;
            for (int i = 0; i < 5; i++)
            {
                bit = byte.Parse("00");
                data.Add(bit);
            }
            for (int i = 0; i < n; i++)
            {
                if (a == 0)
                {
                    read = ns.ReadByte();
                }
                if (a == 1)
                {
                    read = comm.ReadByte();
                }
                bit = byte.Parse(read.ToString("X"),
                            System.Globalization.NumberStyles.AllowHexSpecifier);
                data.Add(bit);
            }
            Data.Add(data); 
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
        
        private void setMessage(List<byte> bytes, TextBox textBox, int controlNum)
        {
            try
            {
                if (bytes[3].ToString() == "80")
                {
                    MessageBox.Show("读取出错");
                }
                else
                {
                    if (controlNum == 0)//IP地址模式
                    {
                        textBox.Text = "";
                        for (int i = 5; i < bytes.Count - 1; i++)
                        {
                            string value = bytes[i].ToString();
                            textBox.Text += value + ".";
                        }
                        string value0 = bytes[bytes.Count - 1].ToString();
                        textBox.Text += value0;
                    }
                    else if (controlNum == 1)//MAC地址模式
                    {
                        textBox.Text = "";
                        for (int i = 5; i < bytes.Count - 1; i++)
                        {
                            string value = bytes[i].ToString("X");
                            if (value.Length == 1) value = "0" + value;
                            textBox.Text += value + "-";
                        }
                        string value0 = bytes[bytes.Count - 1].ToString("X");
                        if (value0.Length == 1) value0 = "0" + value0;
                        textBox.Text += value0;
                    }
                    else if (controlNum == 2)//端口地址模式
                    {
                        textBox.Text = "";
                        int j = 1, sum = 0;
                        for (int i = bytes.Count - 1; i > 4; i--)
                        {
                            int value = Convert.ToInt32(bytes[i]);
                            sum += value * j;
                            j *= 256;
                        }
                        textBox.Text = sum.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void setMessage(List<byte> bytes, ComboBox comboBox)
        {
            try
            {
                if (bytes[3].ToString() == "80")
                {
                    MessageBox.Show("读取出错");
                }
                else
                {
                    comboBox.Text = "";
                    for (int i = 5; i < bytes.Count; i++)
                    {
                        string value = bytes[i].ToString("X");
                        if (value.Length == 1) value = "0" + value;
                        if (value == "00")
                            comboBox.Text = "TCP服务器";
                        else if (value == "01")
                            comboBox.Text = "TCP客户端";
                        else if (value == "02")
                            comboBox.Text = "UDP模式";
                        else
                            comboBox.Text = "模式参数错误";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string setMessage(List<byte> bytes)
        {
            try
            {
                if (bytes[3].ToString() == "80")
                {
                    MessageBox.Show("读取出错");
                    return "0";
                }
                else
                {
                    string s = "";
                    for (int i = 0; i < bytes.Count - 1; i++)
                    {
                        string value = bytes[i].ToString();
                        s += value + " ";
                    }
                    string value0 = bytes[bytes.Count - 1].ToString();
                    s += value0;
                    return s;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return "0";
            }
        }

        private string getMessage(TextBox textBox, int controlNum)
        {
            if (controlNum == 0)//IP地址模式
            {
                if (textBox.Text == "")
                {
                    MessageBox.Show("尚未输入IP地址");
                    return "0";
                }
                else
                {
                    string[] sArr = textBox.Text.Trim().Split('.');
                    string s = "";
                    for (int i = 0; i < 4; i++)
                    {
                        string value = Convert.ToInt32(sArr[i]).ToString("X");
                        if (value.Length == 1) value = "0" + value;
                        s += " " + value;
                    }
                    return s;
                }
            }
            else if (controlNum == 1)//MAC地址模式
            {
                if (textBox.Text == "")
                {
                    MessageBox.Show("尚未输入MAC地址");
                    return "0";
                }
                else
                {
                    string[] sArr = textBox.Text.Trim().Split('-');
                    string s = "";
                    for (int i = 0; i < 6; i++)
                    {
                        s += " " + sArr[i];
                    }
                    return s;
                }
            }
            else if (controlNum == 2)//端口地址模式
            {
                if (textBox.Text == "")
                {
                    MessageBox.Show("尚未选择工作模式");
                    return "0";
                }
                else
                {
                    string r = Convert.ToInt32(textBox.Text).ToString("X");
                    if (r.Length == 1) r = "000" + r;
                    else if (r.Length == 2) r = "00" + r;
                    else if (r.Length == 3) r = "0" + r;
                    string s = " " + r.Insert(2, " ");
                    return s;
                }
            }
            else return "0";      
        }

        private string getMessage(ComboBox comboBox)
        {
            if (comboBox.Text == "TCP服务器")
            {
                return " 00";
            }
            else if (comboBox.Text == "TCP客户端")
            {
                return " 01";
            }

            else if (comboBox.Text == "UDP模式")
            {
                return " 02";
            }
            else return "0";  
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            textBox20.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox16.Text = "";
            textBox18.Text = "";
            textBox15.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox14.Text = "";
        }
    }
}
