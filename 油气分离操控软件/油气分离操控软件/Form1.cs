using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace 油气分离操控软件
{
    public partial class Form1 : Form
    { 
        private SerialPort comm = new SerialPort();
        private List<int> strGet = new List<int>();
        //private long received_count = 0;//接收计数  
        //private long send_count = 0;//发送计数  
        private bool Listening = false;//是否没有执行完invoke相关操作  
        private bool Closing = false;//是否正在关闭串口，执行Application.DoEvents，并阻止再次invoke 
        private bool error = false;//加热开关及六通阀错误控制
        private StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。  

        public Form1()
        {
            InitializeComponent();

            //初始化下拉串口名称列表框  
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            cbbCom.Items.AddRange(ports);
            cbbCom.SelectedIndex = cbbCom.Items.Count > 0 ? 0 : -1;
            cbbRate.SelectedIndex = cbbRate.Items.IndexOf("9600");
            //初始化SerialPort对象  
            comm.NewLine = "/r/n"; 
            //comm.RtsEnable = true; //看情况需要
            //添加事件注册  
            comm.DataReceived += comm_DataReceived;
        }

        //串口开启关闭
        private void btLinkOrBreak_Click(object sender, EventArgs e)
        {
            try
            {
                if (btLinkOrBreak.Text == "连接")
                {
                    comm.PortName = cbbCom.Text;
                    comm.BaudRate = int.Parse(cbbRate.Text);
                    comm.Open();
                }
                else if (btLinkOrBreak.Text == "中断")
                {
                    if (comm.IsOpen)
                    {
                        Closing = true;
                        while (Listening) Application.DoEvents();
                        //打开时点击，则关闭串口  
                        comm.Close();
                        Closing = false;
                    }
                }
                MessageBox.Show(comm.IsOpen.ToString());
                btLinkOrBreak.Text = comm.IsOpen ? "中断" : "连接";
            }
            catch
            {
                MessageBox.Show(btLinkOrBreak.Text+"出错"+e.ToString());
            }
        }

        //接收
        private void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (Closing) return;//如果正在关闭，忽略操作，直接返回，尽快的完成串口监听线程的一次循环  
            try
            {
                Listening = true;//设置标记，说明我已经开始处理数据，一会儿要使用系统UI的。 
                int n = comm.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致  
                byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据  
                //received_count += n;//增加接收计数  
                comm.Read(buf, 0, n);//读取缓冲数据  
                builder.Clear();//清除字符串构造器的内容  
                foreach (byte b in buf)
                {
                    builder.Append(b.ToString("X2") + " ");
                }
                builder.Append(Encoding.ASCII.GetString(buf));
                MessageBox.Show(builder.ToString());

                /*/received_count += n;//增加接收计数 
                strGet.Clear();
                int strBuffer = 255;

                //控制首尾字节分别为“02”“03”，且长度为16字节（除去首尾字节）
                while (strBuffer.ToString("X") != "02")
                {
                    if (comm.BytesToRead > 0)
                    {
                        strBuffer = comm.ReadByte();
                    }
                    else break;
                }
                while (comm.BytesToRead > 0)
                {
                    strBuffer = comm.ReadByte();
                    if (strBuffer.ToString("X") != "03")
                    {
                        strGet.Add(strBuffer);
                    }
                    else break;
                }
                if (strGet.Count != 16) return;
                for(int i=0;i<strGet.Count;i++)
                    MessageBox.Show(strGet[0].ToString());*/

                //因为要访问ui资源，所以需要使用invoke方式同步ui。  
                this.Invoke((EventHandler)(delegate
                {
                    //判断是否是显示为16禁止  
                    // if (checkBoxHexView.Checked)
                    // {
                    // }
                    // else
                    // {
                    //直接按ASCII规则转换成字符串  
                    //    builder.Append(Encoding.ASCII.GetString(buf));
                    //}                        
                   // invokeUi();
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据接收失败"+ex.ToString());
            }
            finally
            {
                Listening = false;//我用完了，ui可以关闭串口了。  
            }
        }
        
        private void invokeUi()
        {
            string s,strFault="";
            int[] statusString=new int[18];
            for (int i = 0; i < 8; i++)
            {
                statusString[i] = strGet[2 * i] + strGet[2 * i + 1];
            }

            //压力
            lblPressureValue.Text=(statusString[0]/10).ToString()+"KPa";
            //温度
            lblTemperatureValue.Text = (statusString[1] / 10).ToString() + "℃";
            //油气分离流程状态
            switch (statusString[2].ToString("X4"))
            {
                case "0010":
                    lblProcessStatus.Text = "正在对油路清洗....";
                    break;
                case "0011":
                    lblProcessStatus.Text = "正在采集试油....";
                    break;
                case "0020":
                    lblProcessStatus.Text = "正在装置残留油脱气和回油....";
                    break;
                case "0021":
                    lblProcessStatus.Text = "正在采样油路死油置换....";
                    break;
                case "0022":
                    lblProcessStatus.Text = "正在采样油路死路回油....";
                    break;
                case "0023":
                    lblProcessStatus.Text = "正在采集试油及回油....";
                    break;
                case "0001":
                    lblProcessStatus.Text = "试油净化....";
                    break;
                case "0002":
                    lblProcessStatus.Text = "油循环&系统清洗....";
                    break;
                case "0003":
                    lblProcessStatus.Text = "系统气路清洗....";
                    break;
                case "0004":
                    lblProcessStatus.Text = "系统气路载气冲洗....";
                    break;
                case "0005":
                    lblProcessStatus.Text = "系统抽真空....";
                    break;
                case "0006":
                    lblProcessStatus.Text = "试油脱气....";
                    break;
                case "0007":
                    lblProcessStatus.Text = "油气平衡....";
                    break;
                case "0008":
                    lblProcessStatus.Text = "洋气收集...";
                    break;
                case "0009":
                    lblProcessStatus.Text = "洋气进样....";
                    break;
                case "0030":
                    lblProcessStatus.Text = "油气分离流程成功执行";
                    break;
                default:
                    break;
            }
            //采样流程状态
            switch (statusString[3].ToString("X4"))
            {
                case "0001":
                    lblSamplingStatus.Text = "正在对集气回路及定量管充标气....";
                    break;
                case "0002":
                    lblSamplingStatus.Text = "正在对集气回路及定量管标气排空....";
                    break;
                case "0003":
                    lblSamplingStatus.Text = "正在对联机色谱仪进行标定....";
                    break;
                case "0030":
                    lblSamplingStatus.Text = "气体采样流程成功执行";
                    break;
            }
            //故障类型
            s = Convert.ToString(statusString[4], 2);
            if(s[15]=='1')
            {
                strFault += "油循环前油定量室可能存在气穴   ";
            }
            if (s[14] == '1')
            {
                strFault += "油路可能存在泄漏   ";
            }
            if (s[13] == '1')
            {
                strFault += "气路可能存在泄漏   ";
            }
            if (s[12] == '1')
            {
                strFault += "压缩机可能存在异常";
            }
            if (strFault != "")
            {
                lblFaultStatus.Text = strFault;
            }
            strFault = "";
            //装置开关量
            s = Convert.ToString(statusString[5], 2);
            if (s[15] == '1') label0.Text = "开";
            else label0.Text = "关";
            if (s[14] == '1') label1.Text = "是";
            else label0.Text = "否";
            if (s[13] == '1') label2.Text = "是";
            else label0.Text = "否";
            if (s[12] == '1') label3.Text = "是";
            else label0.Text = "否";
            if (s[11] == '1') label4.Text = "是";
            else label0.Text = "否";
            if (s[10] == '1') label5.Text = "是";
            else label0.Text = "否";
            if (s[9] == '1') label6.Text = "是";
            else label0.Text = "否";
            if (s[8] == '1') label7.Text = "开";
            else label0.Text = "关";
            if (s[7] == '1') label8.Text = "是";
            else label0.Text = "否";
            if (s[6] == '1') label9.Text = "是";
            else label0.Text = "否";
            if (s[5] == '1') label10.Text = "是";
            else label0.Text = "否";
            if (s[4] == '1') label11.Text = "是";
            else label0.Text = "否";
            if (s[3] == '1') label12.Text = "是";
            else label0.Text = "否";
            if (s[2] == '1') label13.Text = "是";
            else label0.Text = "否";
            if (s[1] == '1') label14.Text = "是";
            else label0.Text = "否";
            //启动计数
            //启动成功计数
            lblCount.Text = statusString[6].ToString() + "/" + statusString[7].ToString();
        }
        
        //发送
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
                comm.Write(buffer.ToArray(), 0, buffer.Count);
            }
            catch(Exception e)
            {
                error = true;
                MessageBox.Show("指令发送失败"+e.ToString());
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

        #region 功能控制按钮

        private void btInspect0_Click(object sender, EventArgs e)
        {
            send("02 00 10 03");
        }

        private void btInspect1_Click(object sender, EventArgs e)
        {
            send("02 00 11 03");
        }

        private void btInspect2_Click(object sender, EventArgs e)
        {
            send("02 00 12 03");
        }

        private void btInspect3_Click(object sender, EventArgs e)
        {
            send("02 00 13 03");
        }

        private void btInspect4_Click(object sender, EventArgs e)
        {
            send("02 00 14 03");
        }

        private void btInspect5_Click(object sender, EventArgs e)
        {
            send("02 00 15 03");
        }

        private void btInspect6_Click(object sender, EventArgs e)
        {
            send("02 00 16 03");
        }

        private void btInspect7_Click(object sender, EventArgs e)
        {
            send("02 00 17 03");
        }

        private void btInspect8_Click(object sender, EventArgs e)
        {
            send("02 00 18 03");
        }

        private void btTest0_Click(object sender, EventArgs e)
        {
            send("02 00 20 03");
        }

        private void btTest1_Click(object sender, EventArgs e)
        {
            send("02 00 21 03");
        }

        private void btTest2_Click(object sender, EventArgs e)
        {
            send("02 00 22 03");
        }

        private void btTest3_Click(object sender, EventArgs e)
        {
            send("02 00 23 03");
        }

        private void btTest4_Click(object sender, EventArgs e)
        {
            send("02 00 24 03");
        }

        private void btOption0_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入温度值");
            }
            else
            {
                send("02 "+int.Parse(textBox1.Text).ToString("X2")+" 30 03");
            }
        }

        private void btOption1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "当前状态：关")
            {
                send("02 01 31 03");
                if (error == false) textBox2.Text = "当前状态：开";
                else error = false;
            }
            else if (textBox2.Text == "当前状态：开")
            {
                send("02 00 31 03");
                if (error == false) textBox2.Text = "当前状态：关";
                else error = false;
            }
        }

        private void btOption2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "当前方式：主控单元控制")
            {
                send("02 00 32 03");
                if (error == false) textBox3.Text = "当前方式：流程控制";
                else error = false;
            }
            else if (textBox3.Text == "当前方式：流程控制")
            {
                send("02 01 32 03");
                if (error == false) textBox3.Text = "当前方式：主控单元控制";
                else error = false;
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            send("02 00 40 03");
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            send("01 01 00 00 00 01 FD CA");
            readbyte();
           // MessageBox.Show(comm.ReadLine().ToString());
            send("01 03 13 9B 00 05 F0 A2");
            readbyte();
            //MessageBox.Show(comm.ReadLine().ToString());
            send("01 01 00 CB 00 01 8C 34");
            readbyte();
            send("01 05 00 CB FF 00 FD C4");
            readbyte();
        }

        private void readbyte()
        {
            List<byte> data = new List<byte>();
            byte bit;
            int read = 0;
            int num = comm.BytesToRead;
            for (int i = 0; i < num; i++)
            {
                read = comm.ReadByte();
                bit = byte.Parse(read.ToString("X"),
                                  System.Globalization.NumberStyles.AllowHexSpecifier);
                data.Add(bit);
            }

           //Byte[] receivedData = new Byte[num];        //创建接收字节数组  
          //  comm.Read(receivedData, 0, receivedData.Length);         //读取数据      

            MessageBox.Show(data.ToString());
        }
    }
}
