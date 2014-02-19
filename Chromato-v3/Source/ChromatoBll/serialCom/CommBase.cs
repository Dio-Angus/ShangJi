/*-----------------------------------------------------------------------------
//  FILE NAME       : CommPort.cs
//  FUNCTION        : 串口基类
//  AUTHOR          : 李锋(2010/06/14)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.IO.Ports;
using System.Threading;
using ChromatoTool.log;
using ChromatoTool.ini;
using Microsoft.VisualBasic;
using ChromatoBll.ocx.biz;
using System.Text;
using System.Net.Sockets;
using ChromatoBll.serialCom;
using System.Windows.Forms;
using System.Collections.Generic;


namespace ChromatoBll.serialCom
{
    /// <summary>
    /// 串口封装类
    /// </summary>
    public class CommBase
    {

        #region 串口变量

        /// <summary>
        /// 串口对象
        /// </summary>
        private volatile SerialPort _sictPort = null;

        /// <summary>
        /// 接收到sict的数据
        /// </summary>
        protected volatile StringBuilder _sictRead = new StringBuilder();

        /// <summary>
        /// Sict读串口次数
        /// </summary>
        private volatile int _tSictCount = 0;



        /// <summary>
        /// tcp通讯客户端
        /// </summary>
        private TcpClient client;

        /// <summary>
        /// tcp数据流
        /// </summary>
        private NetworkStream ns;

        #endregion


        #region 逻辑变量

        /// <summary>
        /// 数据处理スレッド
        /// </summary>
        protected volatile Thread _processThread = null;

        /// <summary>
        /// 传输用管道1,2,3,4逻辑类
        /// </summary>
        protected volatile TransRealBiz[] _bizTrans = new TransRealBiz[CommConst.REAL_CHANNEL_COUNT];

        /// <summary>
        /// 管道1,2,3,4送数据运行标志
        /// </summary>
        protected volatile RealStatus[] _realStatus = new RealStatus[CommConst.REAL_CHANNEL_COUNT];

        /// <summary>
        /// 试验取值线程运行标志
        /// </summary>
        protected volatile bool _isRunLoop = false;


        #endregion


        #region 初期

        /// <summary>
        /// 构造
        /// </summary>
        public CommBase()
        {
            _sictPort = new SerialPort();
            _sictRead = new StringBuilder();

            for (int i = 0; i < CommConst.REAL_CHANNEL_COUNT; i++)
            {
                this._realStatus[i] = RealStatus.Ready;
            }
        }

        /// <summary>
        /// 取得通道的实时状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RealStatus GetRealStatus(String id)
        {
            RealStatus rs = RealStatus.Ready;

            switch (id)
            {
                case IdChannel.Tcd1:
                    rs = this._realStatus[(int)ChannelID.A];
                    break;
                case IdChannel.Fid1:
                    rs = this._realStatus[(int)ChannelID.B];
                    break;
                case IdChannel.Tcd2:
                    rs = this._realStatus[(int)ChannelID.C];
                    break;
                case IdChannel.Fid2:
                    rs = this._realStatus[(int)ChannelID.D];
                    break;
            }

            return rs;
        }

        /// <summary>
        /// 取得通道的实时状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RealStatus GetRealStatus(ChannelID id)
        {
            return this._realStatus[(int)id];
        }

        /// <summary>
        /// 设置通道的实时状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rs"></param>
        public void SetRealStatus(ChannelID id, RealStatus rs)
        {
            this._realStatus[(int)id] = rs;
        }

        /// <summary>
        /// 设置传输逻辑
        /// </summary>
        /// <param name="id"></param>
        /// <param name="biz"></param>
        public void SetTransBiz(ChannelID id, TransRealBiz biz)
        {
            this._bizTrans[(int)id] = biz;
        }

        /// <summary>
        /// 取得传输逻辑
        /// </summary>
        /// <returns></returns>
        public TransRealBiz GetTransBiz(String id)
        {
            TransRealBiz bizTrans = null;

            switch (id)
            {
                case IdChannel.Tcd1:
                    bizTrans = this._bizTrans[(int)ChannelID.A];
                    break;
                case IdChannel.Fid1:
                    bizTrans = this._bizTrans[(int)ChannelID.B];
                    break;
                case IdChannel.Tcd2:
                    bizTrans = this._bizTrans[(int)ChannelID.C];
                    break;
                case IdChannel.Fid2:
                    bizTrans = this._bizTrans[(int)ChannelID.D];
                    break;
            }
            return bizTrans;
        }

        #endregion


        #region 串口 开启和关闭

        /// <summary>
        /// Get a list of the available ports. Already opened ports are not returend
        /// </summary>
        /// <returns></returns>
        public string[] GetAvailablePorts()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>
        /// Open the serial port with current settings.
        /// </summary>
        public string Open()
        {
            this.Close();

            string ret = OpenSict();
            if (null != ret)
            {
                return ret;
            }

            return null;
        }

        /// <summary>
        /// open Sict com port
        /// </summary>
        private string OpenSict()
        {
            try
            {
                if (Port.tag == 0)
                {
                    _sictPort.PortName = Port.SictPort;
                    _sictPort.BaudRate = Port.BaudRate;
                    _sictPort.Parity = Port.Parity;
                    _sictPort.DataBits = Port.DataBits;
                    _sictPort.StopBits = Port.StopBits;
                    _sictPort.Handshake = Port.Handshake;

                    // Set the read/write timeouts
                    _sictPort.ReadTimeout = SerialOption.TimerInterval;
                    _sictPort.WriteTimeout = SerialOption.TimerInterval;

                    _sictPort.Open();
                }
                else if (Port.tag == 1)
                {
                    _sictPort.Parity = Port.Parity;
                    _sictPort.DataBits = Port.DataBits;
                    _sictPort.StopBits = Port.StopBits;
                    _sictPort.Handshake = Port.Handshake;
                    ns.ReadTimeout = SerialOption.TimerInterval;
                    ns.WriteTimeout = SerialOption.TimerInterval;

                    client = new TcpClient(Port.Ip, Port.PortNum);
                    ns = client.GetStream();
                }
            }
            catch (Exception ex)
            {
                CastLog.Logger("CommPort", "OpenSict", String.Format("{0}: open failed", ex.Message));
                return ex.Message;
            }

            return null;
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            if (Port.tag == 0)
                //关闭串口
                _sictPort.Close();


            CastLog.Logger("CommPort/Ip", "Close", "serial port closed");

            //清空缓存
            //this._sictRead.Remove(0, this._sictRead.Length);

        }

        /// <summary>
        /// Get the status of the serial port.
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return _sictPort.IsOpen || ns.DataAvailable;
            }
        }

        /// <summary>
        /// 关闭主循环
        /// </summary>
        public void CloseLoop()
        {
            if (RealStatus.RealCollecting == this._realStatus[(int)ChannelID.A]
                || RealStatus.RealCollecting == this._realStatus[(int)ChannelID.B]
                || RealStatus.RealCollecting == this._realStatus[(int)ChannelID.C]
                || RealStatus.RealCollecting == this._realStatus[(int)ChannelID.D])
            {
                return;
            }

            CastLog.bHasList = false;
            int count = 0;
            CastLog.Logger("CommPort/Ip", "CloseLoop", String.Format("count={0}", count++));

            switch (General.ObjectLink)
            {
                case General.LinkObject.SimuGc:
                    break;

                case General.LinkObject.SmallBoard:
                case General.LinkObject.BigBoard:
                case General.LinkObject.ChannelGas:
                case General.LinkObject.AutoChromatoGas:
                    //スレッドを閉じる

                    //关闭串口
                    this.Close();

                    while (this._isRunLoop)
                    {
                        this._isRunLoop = false;
                        Thread.Sleep(20);
                        CastLog.Logger("CommPort/Ip", "CloseLoop", String.Format("set _isRunLoop = false, time={0}", count++));
                    }

                    if (null != _processThread)
                    {
                        CastLog.Logger("CommPort/Ip", "CloseLoop", _processThread.Name + " Join");
                        _processThread.Join();	//block until exits
                        _processThread = null;
                    }

                    break;
            }
        }

        /// <summary>
        /// 打开主循环
        /// </summary>
        /// <returns></returns>
        public virtual bool OpenLoop()
        {
            return true;
        }
        #endregion


        #region 数据处理公共

        /// <summary>
        /// 接收データを変換
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        protected float PrepareData(String inString)
        {
            //取得中间的数据，除去开始结束，校验字符
            string temp = inString.Substring(2, inString.Length - 6);

            //组成电压字符串
            string value = "";

            for (int i = 0; i < temp.Length; i += 2)
            {
                value += temp[i + 1];
            }
            return (Convert.ToSingle(Convert.ToInt32(value, 16)) - Convert.ToSingle(5000)) / Convert.ToSingle(1000);
        }

        /// <summary>
        /// 保存成文件
        /// </summary>
        /// <param name="oneFrame"></param>
        protected void SaveToFile(string oneFrame)
        {
            CastLog.LoggerTemp(oneFrame);
        }
        #endregion


        #region 接收数据

        /// <summary>
        /// 清除串口数据
        /// </summary>
        public void ClearSict()
        {
            TimeSpan waitTime = new TimeSpan(0, 0, 0, 0, 50);
            byte[] readBuffer = new byte[this._sictPort.ReadBufferSize + 1];
            this._tSictCount = 0;


            while (CommConst.AI_CLEAN_COUNT > this._tSictCount)
            {
                try
                {
                    int count;
                    if (Port.tag == 0)
                        count = this._sictPort.Read(readBuffer, 0, this._sictPort.ReadBufferSize);
                    else if (Port.tag == 1)
                        count = this.ns.Read(readBuffer, 0, this._sictPort.ReadBufferSize);
                }
                catch (TimeoutException)
                {
                    Thread.Sleep(waitTime);
                }
                catch
                {
                    Thread.Sleep(waitTime);
                }
                this._tSictCount++;
            }
        }

        /// <summary>
        /// 从SICT串口读取数据
        /// </summary>
        public StringBuilder ReadSict()
        {
            TimeSpan waitTime = new TimeSpan(0, 0, 0, 0, 50);
            byte[] readBuffer = new byte[this._sictPort.ReadBufferSize + 1];
            String temp = "";
            this._tSictCount = 0;
            //Thread.Sleep(waitTime);
            try
            {
                int count = 0;
                if (Port.tag == 0)
                    count = this._sictPort.Read(readBuffer, 0, this._sictPort.ReadBufferSize);
                else if (Port.tag == 1)
                    count = this.ns.Read(readBuffer, 0, this._sictPort.ReadBufferSize);

                for (int i = 0; i < count; i++)
                {
                    //convert byte to Hex string, "35" -> "23" "173" -> "AD"
                    temp = Conversion.Hex(readBuffer[i]);
                    if (2 > temp.Length)
                    {
                        //校验码添0
                        temp = "0" + temp;
                    }
                    this._sictRead.Append(temp);
                }
                return _sictRead;

            }
            catch (TimeoutException)
            {
                Thread.Sleep(waitTime);
                return null;
            }
            catch
            {
                Thread.Sleep(waitTime);
                return null;
            }
        }
        #endregion


        #region 接收分析数据 by Dio
        /// <summary>
        /// 分析数据
        /// </summary>
        /// <param name="_antiControl"></param>
        public void AnalyseResult(ChromatoTool.dto.AntiControlDto _antiControl)
        {
            byte[] buffer = Receive();
            if (buffer[0].ToString("X2") != "AA" || buffer[1].ToString("X2") != "55")
            {
                return;
            }
            else
            {
                switch (buffer[3].ToString("X2"))
                {
                    case "03"://网络板
                        AnalyseNetwork(_antiControl, buffer);
                        break;
                    case "21"://加热源，进样口，AUX
                        AnalyseHeatingBoard(_antiControl, buffer);
                        break;
                    case "40":
                    case "41":
                    case "42":
                    case "43":
                    case "44"://FID(公共,1,2,K1,K2)
                        AnalyseFID(_antiControl, buffer);
                        break;
                    case "50":
                    case "51":
                    case "52"://TCD(公共,1,2)
                        AnalyseTCD(_antiControl, buffer);
                        break;
                    case "72"://ECD
                        AnalyseECD(_antiControl, buffer);
                        break;
                    case "71"://FPD
                        AnalyseFPD(_antiControl, buffer);
                        break;
                    case "FF"://错误
                        MessageBox.Show("读取失败");
                        return;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 接收串口数据
        /// </summary>
        /// <returns></returns>
        private byte[] Receive()
        {
            byte[] buffer = null;
            if (Port.tag == 0)
            {
                this._sictPort.Read(buffer, 0, 10000);
            }
            else if (Port.tag == 1)
                this.ns.Read(buffer, 0, 10000);
            return buffer;
        }

        /// <summary>
        /// 分析网络板
        /// </summary>
        /// <param name="_antiControl"></param>
        /// <param name="buffer"></param>
        private void AnalyseNetwork(ChromatoTool.dto.AntiControlDto _antiControl, Byte[] buffer)
        {
            switch (buffer[4].ToString("X2"))
            {
                case "14":
                    if (buffer[2].ToString("X2") == "38")
                    {
                        _antiControl.dtoNetworkBoard.GateIP = buffer[5].ToString("") + "." + buffer[6].ToString("")
                            + "." + buffer[7].ToString("") + "." + buffer[8].ToString("");
                        _antiControl.dtoNetworkBoard.Mask = buffer[9].ToString("") + "." + buffer[10].ToString("")
                            + "." + buffer[11].ToString("") + "." + buffer[12].ToString("");
                        _antiControl.dtoNetworkBoard.MAC = buffer[13].ToString("X2") + "-" + buffer[14].ToString("X2")
                            + "-" + buffer[15].ToString("X2") + "-" + buffer[16].ToString("X2")
                            + "-" + buffer[17].ToString("X2") + "-" + buffer[18].ToString("X2");
                        _antiControl.dtoNetworkBoard.SourceIP = buffer[19].ToString("") + "." + buffer[20].ToString("")
                            + "." + buffer[21].ToString("") + "." + buffer[22].ToString("");

                        _antiControl.dtoNetworkBoard.Socket0Address = (buffer[23] * 256 + buffer[24]).ToString();
                        _antiControl.dtoNetworkBoard.Socket0AimIP = buffer[25].ToString("") + "." + buffer[26].ToString("")
                            + "." + buffer[27].ToString("") + "." + buffer[28].ToString("");
                        _antiControl.dtoNetworkBoard.Socket0AimAddress = (buffer[29] * 256 + buffer[30]).ToString();
                        _antiControl.dtoNetworkBoard.Socket0WorkMode = buffer[31];

                        _antiControl.dtoNetworkBoard.Socket1Address = (buffer[32] * 256 + buffer[33]).ToString();
                        _antiControl.dtoNetworkBoard.Socket1AimIP = buffer[34].ToString("") + "." + buffer[35].ToString("")
                            + "." + buffer[36].ToString("") + "." + buffer[37].ToString("");
                        _antiControl.dtoNetworkBoard.Socket1AimAddress = (buffer[38] * 256 + buffer[39]).ToString();
                        _antiControl.dtoNetworkBoard.Socket1WorkMode = buffer[40];

                        _antiControl.dtoNetworkBoard.Socket2Address = (buffer[41] * 256 + buffer[42]).ToString();
                        _antiControl.dtoNetworkBoard.Socket2AimIP = buffer[43].ToString("") + "." + buffer[44].ToString("")
                            + "." + buffer[45].ToString("") + "." + buffer[46].ToString("");
                        _antiControl.dtoNetworkBoard.Socket2AimAddress = (buffer[47] * 256 + buffer[48]).ToString();
                        _antiControl.dtoNetworkBoard.Socket2WorkMode = buffer[49];

                        _antiControl.dtoNetworkBoard.Socket3Address = (buffer[50] * 256 + buffer[51]).ToString();
                        _antiControl.dtoNetworkBoard.Socket3AimIP = buffer[52].ToString("") + "." + buffer[53].ToString("")
                            + "." + buffer[54].ToString("") + "." + buffer[55].ToString("");
                        _antiControl.dtoNetworkBoard.Socket3AimAddress = (buffer[56] * 256 + buffer[57]).ToString();
                        _antiControl.dtoNetworkBoard.Socket3WorkMode = buffer[58];
                    }
                    break;
                case "00":
                    if (buffer[2].ToString("X2") == "06")
                    {
                        _antiControl.dtoNetworkBoard.GateIP = buffer[5].ToString("") + "." + buffer[6].ToString("")
                                                   + "." + buffer[7].ToString("") + "." + buffer[8].ToString("");
                    }
                    break;
                case "01":
                    if (buffer[2].ToString("X2") == "06")
                    {
                        _antiControl.dtoNetworkBoard.Mask = buffer[5].ToString("") + "." + buffer[6].ToString("")
                                                   + "." + buffer[7].ToString("") + "." + buffer[8].ToString("");
                    }
                    break;
                case "02":
                    if (buffer[2].ToString("X2") == "08")
                    {
                        _antiControl.dtoNetworkBoard.MAC = buffer[5].ToString("X2") + "-" + buffer[6].ToString("X2")
                            + "-" + buffer[7].ToString("X2") + "-" + buffer[8].ToString("X2")
                            + "-" + buffer[9].ToString("X2") + "-" + buffer[10].ToString("X2");
                    }
                    break;
                case "03":
                    if (buffer[2].ToString("X2") == "06")
                    {
                        _antiControl.dtoNetworkBoard.SourceIP = buffer[5].ToString("") + "." + buffer[6].ToString("")
                                                   + "." + buffer[7].ToString("") + "." + buffer[8].ToString("");
                    }
                    break;

                //socket0
                case "04":
                    if (buffer[2].ToString("X2") == "04")
                    {
                        _antiControl.dtoNetworkBoard.Socket0Address = (buffer[5] * 256 + buffer[6]).ToString();
                    }
                    break;
                case "05":
                    if (buffer[2].ToString("X2") == "06")
                    {
                        _antiControl.dtoNetworkBoard.Socket0AimIP = buffer[5].ToString("") + "." + buffer[6].ToString("")
                                                   + "." + buffer[7].ToString("") + "." + buffer[8].ToString("");
                    }
                    break;
                case "06":
                    if (buffer[2].ToString("X2") == "04")
                    {
                        _antiControl.dtoNetworkBoard.Socket0AimAddress = (buffer[5] * 256 + buffer[6]).ToString();
                    }
                    break;
                case "07":
                    if (buffer[2].ToString("X2") == "03")
                    {
                        _antiControl.dtoNetworkBoard.Socket0WorkMode = buffer[5];
                    }
                    break;

                //socket1
                case "08":
                    if (buffer[2].ToString("X2") == "04")
                    {
                        _antiControl.dtoNetworkBoard.Socket1Address =(buffer[5] * 256 + buffer[6]).ToString();
                    }
                    break;
                case "09":
                    if (buffer[2].ToString("X2") == "06")
                    {
                        _antiControl.dtoNetworkBoard.Socket1AimIP =(buffer[5] * 256 + buffer[6]).ToString()
                                                   + "." + buffer[7].ToString("") + "." + buffer[8].ToString("");
                    }
                    break;
                case "0A":
                    if (buffer[2].ToString("X2") == "04")
                    {
                        _antiControl.dtoNetworkBoard.Socket1AimAddress =(buffer[5] * 256 + buffer[6]).ToString();
                    }
                    break;
                case "0B":
                    if (buffer[2].ToString("X2") == "03")
                    {
                        _antiControl.dtoNetworkBoard.Socket1WorkMode = buffer[5];
                    }
                    break;

                //socket2
                case "0C":
                    if (buffer[2].ToString("X2") == "04")
                    {
                        _antiControl.dtoNetworkBoard.Socket2Address =(buffer[5] * 256 + buffer[6]).ToString();
                    }
                    break;
                case "0D":
                    if (buffer[2].ToString("X2") == "06")
                    {
                        _antiControl.dtoNetworkBoard.Socket2AimIP =(buffer[5] * 256 + buffer[6]).ToString()
                                                   + "." + buffer[7].ToString("") + "." + buffer[8].ToString("");
                    }
                    break;
                case "0E":
                    if (buffer[2].ToString("X2") == "04")
                    {
                        _antiControl.dtoNetworkBoard.Socket2AimAddress =(buffer[5] * 256 + buffer[6]).ToString();
                    }
                    break;
                case "0F":
                    if (buffer[2].ToString("X2") == "03")
                    {
                        _antiControl.dtoNetworkBoard.Socket2WorkMode = buffer[5];
                    }
                    break;

                //socket3
                case "10":
                    if (buffer[2].ToString("X2") == "04")
                    {
                        _antiControl.dtoNetworkBoard.Socket3Address =(buffer[5] * 256 + buffer[6]).ToString();
                    }
                    break;
                case "11":
                    if (buffer[2].ToString("X2") == "06")
                    {
                        _antiControl.dtoNetworkBoard.Socket3AimIP =(buffer[5] * 256 + buffer[6]).ToString()
                                                   + "." + buffer[7].ToString("") + "." + buffer[8].ToString("");
                    }
                    break;
                case "12":
                    if (buffer[2].ToString("X2") == "04")
                    {
                        _antiControl.dtoNetworkBoard.Socket3AimAddress =(buffer[5] * 256 + buffer[6]).ToString();
                    }
                    break;
                case "13":
                    if (buffer[2].ToString("X2") == "03")
                    {
                        _antiControl.dtoNetworkBoard.Socket3WorkMode = buffer[5];
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 分析加热源，进样口，AUX
        /// </summary>
        /// <param name="_antiControl"></param>
        /// <param name="buffer"></param>
        private void AnalyseHeatingBoard(ChromatoTool.dto.AntiControlDto _antiControl, Byte[] buffer)
        {
            switch (buffer[4].ToString("X2"))
            {
                //加热源
                case "00":
                    if (buffer[2].ToString("X2") == "11")//无程升
                    {
                        _antiControl.dtoHeatingSource.HeatingState = buffer[5].ToString();
                        _antiControl.dtoHeatingSource.EnablingState = buffer[6].ToString();
                        _antiControl.dtoHeatingSource.InitTemp = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[7]))  + Convert.ToString(Convert.ToInt32(buffer[8]))  + Convert.ToString(Convert.ToInt32(buffer[9])));
                        _antiControl.dtoHeatingSource.AlertTemp = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[10]))  + Convert.ToString(Convert.ToInt32(buffer[11]))  + Convert.ToString(Convert.ToInt32(buffer[12])));
                        _antiControl.dtoHeatingSource.MaintainTime =Convert.ToSingle( Convert.ToString(Convert.ToInt32(buffer[13]))  + Convert.ToString(Convert.ToInt32(buffer[14]))  + Convert.ToString(Convert.ToInt32(buffer[15])));
                        _antiControl.dtoHeatingSource.BalanceTime = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[16]))  + Convert.ToString(Convert.ToInt32(buffer[17]))  + Convert.ToString(Convert.ToInt32(buffer[18])));
                        _antiControl.dtoHeatingSource.ColumnCount = buffer[19];
                    }
                    if (buffer[2].ToString("X2") == "1B")//一阶程升
                    {
                        _antiControl.dtoHeatingSource.HeatingState = buffer[5].ToString();
                        _antiControl.dtoHeatingSource.EnablingState = buffer[6].ToString();
                        _antiControl.dtoHeatingSource.InitTemp = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[7])) + Convert.ToString(Convert.ToInt32(buffer[8])) + Convert.ToString(Convert.ToInt32(buffer[9])));
                        _antiControl.dtoHeatingSource.AlertTemp = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[10])) + Convert.ToString(Convert.ToInt32(buffer[11])) + Convert.ToString(Convert.ToInt32(buffer[12])));
                        _antiControl.dtoHeatingSource.MaintainTime = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[13])) + Convert.ToString(Convert.ToInt32(buffer[14])) + Convert.ToString(Convert.ToInt32(buffer[15])));
                        _antiControl.dtoHeatingSource.BalanceTime = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[16])) + Convert.ToString(Convert.ToInt32(buffer[17])) + Convert.ToString(Convert.ToInt32(buffer[18])));
                        _antiControl.dtoHeatingSource.ColumnCount = buffer[19];
                        //COL1
                        _antiControl.dtoHeatingSource.RateCol1 =Convert.ToSingle( Convert.ToString(Convert.ToInt32(buffer[20]))    + Convert.ToString(Convert.ToInt32(buffer[21]))   + Convert.ToString(Convert.ToInt32(buffer[22]))  + Convert.ToString(Convert.ToInt32(buffer[23])));
                        _antiControl.dtoHeatingSource.TempCol1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[24]))   + Convert.ToString(Convert.ToInt32(buffer[25]))  + Convert.ToString(Convert.ToInt32(buffer[26])));
                        _antiControl.dtoHeatingSource.TempTimeCol1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[27]))   + Convert.ToString(Convert.ToInt32(buffer[28]))  + Convert.ToString(Convert.ToInt32(buffer[29])));
                    }
                    if (buffer[2].ToString("X2") == "25")//二阶程升
                    {
                        _antiControl.dtoHeatingSource.HeatingState = buffer[5].ToString();
                        _antiControl.dtoHeatingSource.EnablingState = buffer[6].ToString();
                        _antiControl.dtoHeatingSource.InitTemp = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[7])) + Convert.ToString(Convert.ToInt32(buffer[8])) + Convert.ToString(Convert.ToInt32(buffer[9])));
                        _antiControl.dtoHeatingSource.AlertTemp = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[10])) + Convert.ToString(Convert.ToInt32(buffer[11])) + Convert.ToString(Convert.ToInt32(buffer[12])));
                        _antiControl.dtoHeatingSource.MaintainTime = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[13])) + Convert.ToString(Convert.ToInt32(buffer[14])) + Convert.ToString(Convert.ToInt32(buffer[15])));
                        _antiControl.dtoHeatingSource.BalanceTime = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[16])) + Convert.ToString(Convert.ToInt32(buffer[17])) + Convert.ToString(Convert.ToInt32(buffer[18])));
                        _antiControl.dtoHeatingSource.ColumnCount = buffer[19];
                        //COL1
                        _antiControl.dtoHeatingSource.RateCol1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[20])) + Convert.ToString(Convert.ToInt32(buffer[21])) + Convert.ToString(Convert.ToInt32(buffer[22])) + Convert.ToString(Convert.ToInt32(buffer[23])));
                        _antiControl.dtoHeatingSource.TempCol1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[24])) + Convert.ToString(Convert.ToInt32(buffer[25])) + Convert.ToString(Convert.ToInt32(buffer[26])));
                        _antiControl.dtoHeatingSource.TempTimeCol1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[27])) + Convert.ToString(Convert.ToInt32(buffer[28])) + Convert.ToString(Convert.ToInt32(buffer[29])));
                        //COL2
                        _antiControl.dtoHeatingSource.RateCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[30])) + Convert.ToString(Convert.ToInt32(buffer[31])) + Convert.ToString(Convert.ToInt32(buffer[32])) + Convert.ToString(Convert.ToInt32(buffer[33])));
                        _antiControl.dtoHeatingSource.TempCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[34])) + Convert.ToString(Convert.ToInt32(buffer[35])) + Convert.ToString(Convert.ToInt32(buffer[36])));
                        _antiControl.dtoHeatingSource.TempTimeCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[37])) + Convert.ToString(Convert.ToInt32(buffer[38])) + Convert.ToString(Convert.ToInt32(buffer[39])));
                    }
                    if (buffer[2].ToString("X2") == "2F")//三阶程升
                    {
                        _antiControl.dtoHeatingSource.HeatingState = buffer[5].ToString();
                        _antiControl.dtoHeatingSource.EnablingState = buffer[6].ToString();
                        _antiControl.dtoHeatingSource.InitTemp = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[7])) + Convert.ToString(Convert.ToInt32(buffer[8])) + Convert.ToString(Convert.ToInt32(buffer[9])));
                        _antiControl.dtoHeatingSource.AlertTemp = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[10])) + Convert.ToString(Convert.ToInt32(buffer[11])) + Convert.ToString(Convert.ToInt32(buffer[12])));
                        _antiControl.dtoHeatingSource.MaintainTime = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[13])) + Convert.ToString(Convert.ToInt32(buffer[14])) + Convert.ToString(Convert.ToInt32(buffer[15])));
                        _antiControl.dtoHeatingSource.BalanceTime = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[16])) + Convert.ToString(Convert.ToInt32(buffer[17])) + Convert.ToString(Convert.ToInt32(buffer[18])));
                        _antiControl.dtoHeatingSource.ColumnCount = buffer[19];
                        //COL1
                        _antiControl.dtoHeatingSource.RateCol1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[20])) + Convert.ToString(Convert.ToInt32(buffer[21])) + Convert.ToString(Convert.ToInt32(buffer[22])) + Convert.ToString(Convert.ToInt32(buffer[23])));
                        _antiControl.dtoHeatingSource.TempCol1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[24])) + Convert.ToString(Convert.ToInt32(buffer[25])) + Convert.ToString(Convert.ToInt32(buffer[26])));
                        _antiControl.dtoHeatingSource.TempTimeCol1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[27])) + Convert.ToString(Convert.ToInt32(buffer[28])) + Convert.ToString(Convert.ToInt32(buffer[29])));
                        //COL2
                        _antiControl.dtoHeatingSource.RateCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[30])) + Convert.ToString(Convert.ToInt32(buffer[31])) + Convert.ToString(Convert.ToInt32(buffer[32])) + Convert.ToString(Convert.ToInt32(buffer[33])));
                        _antiControl.dtoHeatingSource.TempCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[34])) + Convert.ToString(Convert.ToInt32(buffer[35])) + Convert.ToString(Convert.ToInt32(buffer[36])));
                        _antiControl.dtoHeatingSource.TempTimeCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[37])) + Convert.ToString(Convert.ToInt32(buffer[38])) + Convert.ToString(Convert.ToInt32(buffer[39])));
                        //COL3
                        _antiControl.dtoHeatingSource.RateCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[30])) + Convert.ToString(Convert.ToInt32(buffer[41])) + Convert.ToString(Convert.ToInt32(buffer[42])) + Convert.ToString(Convert.ToInt32(buffer[43])));
                        _antiControl.dtoHeatingSource.TempCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[34])) + Convert.ToString(Convert.ToInt32(buffer[45])) + Convert.ToString(Convert.ToInt32(buffer[46])));
                        _antiControl.dtoHeatingSource.TempTimeCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[37])) + Convert.ToString(Convert.ToInt32(buffer[48])) + Convert.ToString(Convert.ToInt32(buffer[49])));
                    }
                    if (buffer[2].ToString("X2") == "39")//四阶程升
                    {
                        _antiControl.dtoHeatingSource.HeatingState = buffer[5].ToString();
                        _antiControl.dtoHeatingSource.EnablingState = buffer[6].ToString();
                        _antiControl.dtoHeatingSource.InitTemp = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[7])) + Convert.ToString(Convert.ToInt32(buffer[8])) + Convert.ToString(Convert.ToInt32(buffer[9])));
                        _antiControl.dtoHeatingSource.AlertTemp = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[10])) + Convert.ToString(Convert.ToInt32(buffer[11])) + Convert.ToString(Convert.ToInt32(buffer[12])));
                        _antiControl.dtoHeatingSource.MaintainTime = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[13])) + Convert.ToString(Convert.ToInt32(buffer[14])) + Convert.ToString(Convert.ToInt32(buffer[15])));
                        _antiControl.dtoHeatingSource.BalanceTime = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[16])) + Convert.ToString(Convert.ToInt32(buffer[17])) + Convert.ToString(Convert.ToInt32(buffer[18])));
                        _antiControl.dtoHeatingSource.ColumnCount = buffer[19];
                        //COL1
                        _antiControl.dtoHeatingSource.RateCol1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[20])) + Convert.ToString(Convert.ToInt32(buffer[21])) + Convert.ToString(Convert.ToInt32(buffer[22])) + Convert.ToString(Convert.ToInt32(buffer[23])));
                        _antiControl.dtoHeatingSource.TempCol1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[24])) + Convert.ToString(Convert.ToInt32(buffer[25])) + Convert.ToString(Convert.ToInt32(buffer[26])));
                        _antiControl.dtoHeatingSource.TempTimeCol1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[27])) + Convert.ToString(Convert.ToInt32(buffer[28])) + Convert.ToString(Convert.ToInt32(buffer[29])));
                        //COL2
                        _antiControl.dtoHeatingSource.RateCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[30])) + Convert.ToString(Convert.ToInt32(buffer[31])) + Convert.ToString(Convert.ToInt32(buffer[32])) + Convert.ToString(Convert.ToInt32(buffer[33])));
                        _antiControl.dtoHeatingSource.TempCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[34])) + Convert.ToString(Convert.ToInt32(buffer[35])) + Convert.ToString(Convert.ToInt32(buffer[36])));
                        _antiControl.dtoHeatingSource.TempTimeCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[37])) + Convert.ToString(Convert.ToInt32(buffer[38])) + Convert.ToString(Convert.ToInt32(buffer[39])));
                        //COL3
                        _antiControl.dtoHeatingSource.RateCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[30])) + Convert.ToString(Convert.ToInt32(buffer[41])) + Convert.ToString(Convert.ToInt32(buffer[42])) + Convert.ToString(Convert.ToInt32(buffer[43])));
                        _antiControl.dtoHeatingSource.TempCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[34])) + Convert.ToString(Convert.ToInt32(buffer[45])) + Convert.ToString(Convert.ToInt32(buffer[46])));
                        _antiControl.dtoHeatingSource.TempTimeCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[37])) + Convert.ToString(Convert.ToInt32(buffer[48])) + Convert.ToString(Convert.ToInt32(buffer[49])));
                        //COL4
                        _antiControl.dtoHeatingSource.RateCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[30])) + Convert.ToString(Convert.ToInt32(buffer[51])) + Convert.ToString(Convert.ToInt32(buffer[52])) + Convert.ToString(Convert.ToInt32(buffer[53])));
                        _antiControl.dtoHeatingSource.TempCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[34])) + Convert.ToString(Convert.ToInt32(buffer[55])) + Convert.ToString(Convert.ToInt32(buffer[56])));
                        _antiControl.dtoHeatingSource.TempTimeCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[37])) + Convert.ToString(Convert.ToInt32(buffer[58])) + Convert.ToString(Convert.ToInt32(buffer[59])));
                    }
                    if (buffer[2].ToString("X2") == "43")//五阶程升
                    {
                        _antiControl.dtoHeatingSource.HeatingState = buffer[5].ToString();
                        _antiControl.dtoHeatingSource.EnablingState = buffer[6].ToString();
                        _antiControl.dtoHeatingSource.InitTemp = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[7])) + Convert.ToString(Convert.ToInt32(buffer[8])) + Convert.ToString(Convert.ToInt32(buffer[9])));
                        _antiControl.dtoHeatingSource.AlertTemp = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[10])) + Convert.ToString(Convert.ToInt32(buffer[11])) + Convert.ToString(Convert.ToInt32(buffer[12])));
                        _antiControl.dtoHeatingSource.MaintainTime = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[13])) + Convert.ToString(Convert.ToInt32(buffer[14])) + Convert.ToString(Convert.ToInt32(buffer[15])));
                        _antiControl.dtoHeatingSource.BalanceTime = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[16])) + Convert.ToString(Convert.ToInt32(buffer[17])) + Convert.ToString(Convert.ToInt32(buffer[18])));
                        _antiControl.dtoHeatingSource.ColumnCount = buffer[19];
                        //COL1
                        _antiControl.dtoHeatingSource.RateCol1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[20])) + Convert.ToString(Convert.ToInt32(buffer[21])) + Convert.ToString(Convert.ToInt32(buffer[22])) + Convert.ToString(Convert.ToInt32(buffer[23])));
                        _antiControl.dtoHeatingSource.TempCol1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[24])) + Convert.ToString(Convert.ToInt32(buffer[25])) + Convert.ToString(Convert.ToInt32(buffer[26])));
                        _antiControl.dtoHeatingSource.TempTimeCol1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[27])) + Convert.ToString(Convert.ToInt32(buffer[28])) + Convert.ToString(Convert.ToInt32(buffer[29])));
                        //COL2
                        _antiControl.dtoHeatingSource.RateCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[30])) + Convert.ToString(Convert.ToInt32(buffer[31])) + Convert.ToString(Convert.ToInt32(buffer[32])) + Convert.ToString(Convert.ToInt32(buffer[33])));
                        _antiControl.dtoHeatingSource.TempCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[34])) + Convert.ToString(Convert.ToInt32(buffer[35])) + Convert.ToString(Convert.ToInt32(buffer[36])));
                        _antiControl.dtoHeatingSource.TempTimeCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[37])) + Convert.ToString(Convert.ToInt32(buffer[38])) + Convert.ToString(Convert.ToInt32(buffer[39])));
                        //COL3
                        _antiControl.dtoHeatingSource.RateCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[30])) + Convert.ToString(Convert.ToInt32(buffer[41])) + Convert.ToString(Convert.ToInt32(buffer[42])) + Convert.ToString(Convert.ToInt32(buffer[43])));
                        _antiControl.dtoHeatingSource.TempCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[34])) + Convert.ToString(Convert.ToInt32(buffer[45])) + Convert.ToString(Convert.ToInt32(buffer[46])));
                        _antiControl.dtoHeatingSource.TempTimeCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[37])) + Convert.ToString(Convert.ToInt32(buffer[48])) + Convert.ToString(Convert.ToInt32(buffer[49])));
                        //COL4
                        _antiControl.dtoHeatingSource.RateCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[30])) + Convert.ToString(Convert.ToInt32(buffer[51])) + Convert.ToString(Convert.ToInt32(buffer[52])) + Convert.ToString(Convert.ToInt32(buffer[53])));
                        _antiControl.dtoHeatingSource.TempCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[34])) + Convert.ToString(Convert.ToInt32(buffer[55])) + Convert.ToString(Convert.ToInt32(buffer[56])));
                        _antiControl.dtoHeatingSource.TempTimeCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[37])) + Convert.ToString(Convert.ToInt32(buffer[58])) + Convert.ToString(Convert.ToInt32(buffer[59])));
                        //COL5
                        _antiControl.dtoHeatingSource.RateCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[30])) + Convert.ToString(Convert.ToInt32(buffer[61])) + Convert.ToString(Convert.ToInt32(buffer[62])) + Convert.ToString(Convert.ToInt32(buffer[63])));
                        _antiControl.dtoHeatingSource.TempCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[34])) + Convert.ToString(Convert.ToInt32(buffer[65])) + Convert.ToString(Convert.ToInt32(buffer[66])));
                        _antiControl.dtoHeatingSource.TempTimeCol2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[37])) + Convert.ToString(Convert.ToInt32(buffer[68])) + Convert.ToString(Convert.ToInt32(buffer[69])));
                    }
                    break;
                //进样口
                case "80":
                    if (buffer[2].ToString("X2") == "23")
                    {
                        //INJ1
                        _antiControl.dtoInject.InitTemp1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[5]))   + Convert.ToString(Convert.ToInt32(buffer[6]))  + Convert.ToString(Convert.ToInt32(buffer[7])));
                        _antiControl.dtoInject.AlertTemp1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[8]))   + Convert.ToString(Convert.ToInt32(buffer[9]))  + Convert.ToString(Convert.ToInt32(buffer[10])));
                        _antiControl.dtoInject.ColumnType1 = buffer[11];
                        _antiControl.dtoInject.InjectTime1 =Convert.ToInt32( Convert.ToString(Convert.ToInt32(buffer[12]))   + Convert.ToString(Convert.ToInt32(buffer[13]))  + Convert.ToString(Convert.ToInt32(buffer[14])));
                        _antiControl.dtoInject.InjectMode1 = buffer[15];
                        //INJ2
                        _antiControl.dtoInject.InitTemp2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[16])) + Convert.ToString(Convert.ToInt32(buffer[17])) + Convert.ToString(Convert.ToInt32(buffer[18])));
                        _antiControl.dtoInject.AlertTemp2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[19])) + Convert.ToString(Convert.ToInt32(buffer[20])) + Convert.ToString(Convert.ToInt32(buffer[21])));
                        _antiControl.dtoInject.ColumnType2 = buffer[22];
                        _antiControl.dtoInject.InjectTime2 = Convert.ToInt32(Convert.ToString(Convert.ToInt32(buffer[23])) + Convert.ToString(Convert.ToInt32(buffer[24])) + Convert.ToString(Convert.ToInt32(buffer[25])));
                        _antiControl.dtoInject.InjectMode2 = buffer[26];
                        //INJ3
                        _antiControl.dtoInject.InitTemp3 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[27])) + Convert.ToString(Convert.ToInt32(buffer[28])) + Convert.ToString(Convert.ToInt32(buffer[29])));
                        _antiControl.dtoInject.AlertTemp3 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[30])) + Convert.ToString(Convert.ToInt32(buffer[31])) + Convert.ToString(Convert.ToInt32(buffer[32])));
                        _antiControl.dtoInject.ColumnType3 = buffer[33];
                        _antiControl.dtoInject.InjectTime3 = Convert.ToInt32(Convert.ToString(Convert.ToInt32(buffer[34])) + Convert.ToString(Convert.ToInt32(buffer[35])) + Convert.ToString(Convert.ToInt32(buffer[36])));
                        _antiControl.dtoInject.InjectMode3 = buffer[37];
                    }
                    break;
                //AUX
                case "A0":
                    if (buffer[2].ToString("X2") == "09")
                    {
                        //AUX1
                        if (buffer[5].ToString("X2") == "23")
                        {
                            _antiControl.dtoAux.InitTempAux1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[6]))   + Convert.ToString(Convert.ToInt32(buffer[7]))  + Convert.ToString(Convert.ToInt32(buffer[8])));
                            _antiControl.dtoAux.AlertTempAux1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[9]))   + Convert.ToString(Convert.ToInt32(buffer[10]))  + Convert.ToString(Convert.ToInt32(buffer[11])));
                            _antiControl.dtoAux.UserIndex = 1;
                        }
                        //AUX2
                        if (buffer[5].ToString("X2") == "24")
                        {
                            _antiControl.dtoAux.InitTempAux2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[6])) + Convert.ToString(Convert.ToInt32(buffer[7])) + Convert.ToString(Convert.ToInt32(buffer[8])));
                            _antiControl.dtoAux.AlertTempAux2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[9])) + Convert.ToString(Convert.ToInt32(buffer[10])) + Convert.ToString(Convert.ToInt32(buffer[11])));
                            _antiControl.dtoAux.UserIndex = 2;
                        }
                    }
                    //AUX1&&AUX2
                    if (buffer[2].ToString("X2") == "10")
                    {
                        _antiControl.dtoAux.InitTempAux1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[6])) + Convert.ToString(Convert.ToInt32(buffer[7])) + Convert.ToString(Convert.ToInt32(buffer[8])));
                        _antiControl.dtoAux.AlertTempAux1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[9])) + Convert.ToString(Convert.ToInt32(buffer[10])) + Convert.ToString(Convert.ToInt32(buffer[11])));

                        _antiControl.dtoAux.InitTempAux2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[13])) + Convert.ToString(Convert.ToInt32(buffer[14])) + Convert.ToString(Convert.ToInt32(buffer[15])));
                        _antiControl.dtoAux.AlertTempAux2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[16])) + Convert.ToString(Convert.ToInt32(buffer[17])) + Convert.ToString(Convert.ToInt32(buffer[18])));

                        _antiControl.dtoAux.UserIndex = 0;
                    }
                    break;
            }
        }

        /// <summary>
        /// 分析FID
        /// </summary>
        /// <param name="_antiControl"></param>
        /// <param name="buffer"></param>
        private void AnalyseFID(ChromatoTool.dto.AntiControlDto _antiControl, Byte[] buffer)
        {
            if (buffer[3].ToString("X2") == "40" && buffer[4].ToString("X2") == "00")
            {
                List<string> address = new List<string>();
                switch (buffer[2].ToString("X2"))
                {
                    case "0B":
                        address.Clear();
                        address.Add(SortFID(_antiControl, buffer, 5));

                        if (address[0] == addressCommand.FID1)
                        {
                            _antiControl.dtoFid.FID1Used = true;
                        }
                        else _antiControl.dtoFid.FID1Used = false;

                        if (address[0] == addressCommand.FID2)
                        {
                            _antiControl.dtoFid.FID2Used = true;
                        }
                        else _antiControl.dtoFid.FID2Used = false;

                        if (address[0] == addressCommand.FIDK1)
                        {
                            _antiControl.dtoFid.FIDK1Used = true;
                        }
                        else _antiControl.dtoFid.FIDK1Used = false;

                        if (address[0] == addressCommand.FIDK2)
                        {
                            _antiControl.dtoFid.FIDK2Used = true;
                        }
                        else _antiControl.dtoFid.FIDK2Used = false;

                        break;
                    case "14":
                        address.Clear();
                        address.Add(SortFID(_antiControl, buffer, 5));
                        address.Add(SortFID(_antiControl, buffer, 14));
                        if (address[0] == addressCommand.FID1 || address[1] == addressCommand.FID1)
                        {
                            _antiControl.dtoFid.FID1Used = true;
                        }
                        else _antiControl.dtoFid.FID1Used = false;

                        if (address[0] == addressCommand.FID2 || address[1] == addressCommand.FID2)
                        {
                            _antiControl.dtoFid.FID2Used = true;
                        }
                        else _antiControl.dtoFid.FID2Used = false;

                        if (address[0] == addressCommand.FIDK1 || address[1] == addressCommand.FIDK1)
                        {
                            _antiControl.dtoFid.FIDK1Used = true;
                        }
                        else _antiControl.dtoFid.FIDK1Used = false;

                        if (address[0] == addressCommand.FIDK2 || address[1] == addressCommand.FIDK2)
                        {
                            _antiControl.dtoFid.FIDK2Used = true;
                        }
                        else _antiControl.dtoFid.FIDK2Used = false;

                        break;
                    case "1D":
                        address.Clear();
                        address.Add(SortFID(_antiControl, buffer, 5));
                        address.Add(SortFID(_antiControl, buffer, 14));
                        address.Add(SortFID(_antiControl, buffer, 23));

                        if (address[0] == addressCommand.FID1 || address[1] == addressCommand.FID1 || address[2] == addressCommand.FID1)
                        { _antiControl.dtoFid.FID1Used = true; }
                        else _antiControl.dtoFid.FID1Used = false;

                        if (address[0] == addressCommand.FID2 || address[1] == addressCommand.FID2 || address[2] == addressCommand.FID2)
                        { _antiControl.dtoFid.FID2Used = true; }
                        else _antiControl.dtoFid.FID2Used = false;

                        if (address[0] == addressCommand.FIDK1 || address[1] == addressCommand.FIDK1 || address[2] == addressCommand.FIDK1)
                        { _antiControl.dtoFid.FIDK1Used = true; }
                        else _antiControl.dtoFid.FIDK1Used = false;

                        if (address[0] == addressCommand.FIDK2 || address[1] == addressCommand.FIDK2 || address[2] == addressCommand.FIDK2)
                        { _antiControl.dtoFid.FIDK2Used = true; }
                        else _antiControl.dtoFid.FIDK2Used = false;

                        break;
                    case "26":
                        SortFID(_antiControl, buffer, 5);
                        SortFID(_antiControl, buffer, 14);
                        SortFID(_antiControl, buffer, 23);
                        SortFID(_antiControl, buffer, 32);
                        _antiControl.dtoFid.FID1Used = true;
                        _antiControl.dtoFid.FID2Used = true;
                        _antiControl.dtoFid.FIDK1Used = true;
                        _antiControl.dtoFid.FIDK2Used = true;
                        break;
                }
            }
        }

        /// <summary>
        /// FID分类
        /// </summary>
        /// <param name="_antiControl"></param>
        /// <param name="buffer"></param>
        /// <param name="i"></param>
        private string SortFID(ChromatoTool.dto.AntiControlDto _antiControl, Byte[] buffer, int i)
        {
            switch (buffer[i].ToString("X2"))
            {
                //FID1
                case "41":
                    _antiControl.dtoFid.InitTemp1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[i + 1])) + Convert.ToString(Convert.ToInt32(buffer[i + 2])) + Convert.ToString(Convert.ToInt32(buffer[i + 3])));
                    _antiControl.dtoFid.AlertTemp1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[i + 4])) + Convert.ToString(Convert.ToInt32(buffer[i + 5])) + Convert.ToString(Convert.ToInt32(buffer[i + 6])));
                    _antiControl.dtoFid.MagnifyFactor1 = buffer[i + 7];
                    _antiControl.dtoFid.MagnifyFactor1 = buffer[i + 8];
                    return buffer[i].ToString("X2");
                    break;
                //FID2
                case "42":
                    _antiControl.dtoFid.InitTemp2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[i + 1])) + Convert.ToString(Convert.ToInt32(buffer[i + 2])) + Convert.ToString(Convert.ToInt32(buffer[i + 3])));
                    _antiControl.dtoFid.AlertTemp2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[i + 4])) + Convert.ToString(Convert.ToInt32(buffer[i + 5])) + Convert.ToString(Convert.ToInt32(buffer[i + 6])));
                    _antiControl.dtoFid.MagnifyFactor2 = buffer[i + 7];
                    _antiControl.dtoFid.MagnifyFactor2 = buffer[i + 8];
                    return buffer[i].ToString("X2");
                    break;
                //FIDK1
                case "43":
                    _antiControl.dtoFid.InitTempK1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[i + 1])) + Convert.ToString(Convert.ToInt32(buffer[i + 2])) + Convert.ToString(Convert.ToInt32(buffer[i + 3])));
                    _antiControl.dtoFid.AlertTempK1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[i + 4])) + Convert.ToString(Convert.ToInt32(buffer[i + 5])) + Convert.ToString(Convert.ToInt32(buffer[i + 6])));
                    _antiControl.dtoFid.MagnifyFactorK1 = buffer[i + 7];
                    _antiControl.dtoFid.MagnifyFactorK1 = buffer[i + 8];
                    return buffer[i].ToString("X2");
                    break;
                //FIDK2
                case "44":
                    _antiControl.dtoFid.InitTempK2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[i + 1])) + Convert.ToString(Convert.ToInt32(buffer[i + 2])) + Convert.ToString(Convert.ToInt32(buffer[i + 3])));
                    _antiControl.dtoFid.AlertTempK2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[i + 4])) + Convert.ToString(Convert.ToInt32(buffer[i + 5])) + Convert.ToString(Convert.ToInt32(buffer[i + 6])));
                    _antiControl.dtoFid.MagnifyFactorK2 = buffer[i + 7];
                    return buffer[i].ToString("X2");
                    _antiControl.dtoFid.MagnifyFactorK2 = buffer[i + 8];
                    break;
                default:
                    return buffer[i].ToString("X2");
                    break;
            }
        }

        /// <summary>
        /// 分析TCD
        /// </summary>
        /// <param name="_antiControl"></param>
        /// <param name="buffer"></param>
        private void AnalyseTCD(ChromatoTool.dto.AntiControlDto _antiControl, Byte[] buffer)
        {
            if (buffer[4].ToString() == "00")
            {
                switch (buffer[2].ToString())
                {
                    case "0D":
                        if (buffer[5].ToString() == "51")//TCD1
                        {
                            _antiControl.dtoTcd.InitTemp1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[6]))   + Convert.ToString(Convert.ToInt32(buffer[7]))  + Convert.ToString(Convert.ToInt32(buffer[8])));
                            _antiControl.dtoTcd.AlertTemp1 =Convert.ToSingle( Convert.ToString(Convert.ToInt32(buffer[9]))   + Convert.ToString(Convert.ToInt32(buffer[10]))  + Convert.ToString(Convert.ToInt32(buffer[11])));
                            _antiControl.dtoTcd.PolarityOne = (buffer[12] == 1) ? true : false;
                            _antiControl.dtoTcd.CurrentOne =Convert.ToSingle( Convert.ToString(Convert.ToInt32(buffer[13]))   + Convert.ToString(Convert.ToInt32(buffer[14]))  + Convert.ToString(Convert.ToInt32(buffer[15])));
                        }
                        if (buffer[5].ToString() == "52")//TCD2
                        {
                            _antiControl.dtoTcd.InitTemp2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[6]))   + Convert.ToString(Convert.ToInt32(buffer[7]))  + Convert.ToString(Convert.ToInt32(buffer[8])));
                            _antiControl.dtoTcd.AlertTemp2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[9]))   + Convert.ToString(Convert.ToInt32(buffer[10]))  + Convert.ToString(Convert.ToInt32(buffer[11])));
                            _antiControl.dtoTcd.PolarityTwo = (buffer[12] == 1) ? true : false;
                            _antiControl.dtoTcd.CurrentTwo = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[13]))   + Convert.ToString(Convert.ToInt32(buffer[14]))  + Convert.ToString(Convert.ToInt32(buffer[15])));
                        }
                        break;
                    case "18"://TCD1+TCD2
                        _antiControl.dtoTcd.InitTemp1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[6]))   + Convert.ToString(Convert.ToInt32(buffer[7]))  + Convert.ToString(Convert.ToInt32(buffer[8])));
                        _antiControl.dtoTcd.AlertTemp1 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[9]))   + Convert.ToString(Convert.ToInt32(buffer[10]))  + Convert.ToString(Convert.ToInt32(buffer[11])));
                        _antiControl.dtoTcd.PolarityOne = (buffer[12] == 1) ? true : false;
                        _antiControl.dtoTcd.CurrentOne = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[13]))   + Convert.ToString(Convert.ToInt32(buffer[14]))  + Convert.ToString(Convert.ToInt32(buffer[15])));

                        _antiControl.dtoTcd.InitTemp2 =Convert.ToSingle( Convert.ToString(Convert.ToInt32(buffer[17]))   + Convert.ToString(Convert.ToInt32(buffer[18]))  + Convert.ToString(Convert.ToInt32(buffer[19])));
                        _antiControl.dtoTcd.AlertTemp2 = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[20]))   + Convert.ToString(Convert.ToInt32(buffer[21]))  + Convert.ToString(Convert.ToInt32(buffer[22])));
                        _antiControl.dtoTcd.PolarityTwo = (buffer[23] == 1) ? true : false;
                        _antiControl.dtoTcd.CurrentTwo = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[24]))   + Convert.ToString(Convert.ToInt32(buffer[25]))  + Convert.ToString(Convert.ToInt32(buffer[26])));
                        break;
                }
            }
        }

        /// <summary>
        /// 分析ECD
        /// </summary>
        /// <param name="_antiControl"></param>
        /// <param name="buffer"></param>
        private void AnalyseECD(ChromatoTool.dto.AntiControlDto _antiControl, Byte[] buffer)
        {
            if (buffer[4].ToString() == "00")
            {
                if (buffer[2].ToString() == "08")
                {
                    //电流
                    _antiControl.dtoEcd.Current = Convert.ToSingle(Convert.ToString(Convert.ToInt32(buffer[5]))   + Convert.ToString(Convert.ToInt32(buffer[6]))  + Convert.ToString(Convert.ToInt32(buffer[7])));
                    //量程
                    _antiControl.dtoEcd.Capacity =Convert.ToSingle( Convert.ToString(Convert.ToInt32(buffer[8]))   + Convert.ToString(Convert.ToInt32(buffer[9]))  + Convert.ToString(Convert.ToInt32(buffer[10])));
                }
            }
        }

        /// <summary>
        /// 分析FPD
        /// </summary>
        /// <param name="_antiControl"></param>
        /// <param name="buffer"></param>
        private void AnalyseFPD(ChromatoTool.dto.AntiControlDto _antiControl, Byte[] buffer)
        {
        }

        #endregion


        #region 发送数据

        /// <summary>
        /// remove space in string
        /// </summary>
        /// <param name="putin"></param>
        /// <returns></returns>
        private string delspace(string putin)
        {
            string putout = "";
            for (int i = 0; i < putin.Length; i++)
            {
                if (putin[i] != ' ')
                    putout += putin[i];
            }
            return putout;
        }

        /// <summary>
        /// change to 16 hex
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private byte[] ChangeTo16Hex(string data)
        {
            string temps = delspace(data);
            byte[] tempb = new byte[data.Length];
            int j = 0;
            for (int i = 0; i < temps.Length; i = i + 2, j++)
            {
                tempb[j] = Convert.ToByte(temps.Substring(i, 2), 16);
            }
            byte[] send = new byte[j];
            Array.Copy(tempb, send, j);
            return send;
        }

        /// <summary>
        /// 通过串口 发送数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="isHex"></param>
        public void Send(string data, bool isHex)
        {
            byte[] bytes = null;

            if (this.IsOpen)
            {
                string lineEnding = "";
                switch (SerialOption.AppendToSend)
                {
                    case SerialOption.AppendType.AppendCR:
                        lineEnding = "\r"; break;
                    case SerialOption.AppendType.AppendLF:
                        lineEnding = "\n"; break;
                    case SerialOption.AppendType.AppendCRLF:
                        lineEnding = "\r\n"; break;
                }

                if (isHex)
                {
                    bytes = this.ChangeTo16Hex(data + lineEnding);
                    this.Write(bytes, 0, bytes.Length);
                }
                else
                {
                    bytes = Encoding.Unicode.GetBytes(data + lineEnding);
                    this.Write(bytes, 0, bytes.Length);

                }
                Console.Out.WriteLine("send data: " + data);

            }
        }

        public void Send(string s)
        {
            try
            {
                List<string> sArr = new List<string>();
                for (int i = 0; i < s.Length % 2 + 1; i++)
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
                if (Port.tag == 0)//RS-232方式
                {
                    _sictPort.Write(buffer.ToArray(), 0, buffer.Count);
                }
                if (Port.tag == 1)//以太网方式
                {
                    ns.Write(buffer.ToArray(), 0, buffer.Count);
                }
            }
            catch (Exception ex)
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

        /// <summary>
        /// 写串口
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        private void Write(byte[] buffer, int offset, int count)
        {
            if (Port.tag == 0)
                this._sictPort.Write(buffer, offset, count);
            else if (Port.tag == 1)
                this.ns.Write(buffer, offset, count);
        }

        /// <summary>
        /// 写串口
        /// </summary>
        /// <param name="text"></param>
        //private void Write(string text)
        //{
        //    byte[] buffer = Encoding.Unicode.GetBytes(text);     
        //    this._sictPort.Write(text);
        //}

        #endregion
    }
}
