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

            //关闭串口
            _sictPort.Close();

            CastLog.Logger("CommPort", "Close", "serial port closed");

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
                return _sictPort.IsOpen;
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
            CastLog.Logger("CommPort", "CloseLoop", String.Format("count={0}", count++));

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
                        CastLog.Logger("CommPort", "CloseLoop", String.Format("set _isRunLoop = false, time={0}", count++));
                    }

                    if (null != _processThread)
                    {
                        CastLog.Logger("CommPort", "CloseLoop", _processThread.Name + " Join");
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


        #region 接収数据

        /// <summary>
        /// 清除串口数据
        /// </summary>
        protected void ClearSict()
        {
            TimeSpan waitTime = new TimeSpan(0, 0, 0, 0, 50);
            byte[] readBuffer = new byte[this._sictPort.ReadBufferSize + 1];
            this._tSictCount = 0;


            while (CommConst.AI_CLEAN_COUNT > this._tSictCount)
            {
                try
                {
                    int count = this._sictPort.Read(readBuffer, 0, this._sictPort.ReadBufferSize);
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
        protected void ReadSict()
        {
            TimeSpan waitTime = new TimeSpan(0, 0, 0, 0, 50);
            byte[] readBuffer = new byte[this._sictPort.ReadBufferSize + 1];
            String temp = "";
            this._tSictCount = 0;

            //Thread.Sleep(waitTime);

            while (CommConst.AI_ALLOW_COUNT > this._tSictCount)
            {
                try
                {

                    int count = this._sictPort.Read(readBuffer, 0, this._sictPort.ReadBufferSize);

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
                    //bytes = System.Text.Encoding.Default.GetBytes(data + lineEnding);
                    this.Write(data + lineEnding);

                }
                Console.Out.WriteLine("send data: " + data);

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
            this._sictPort.Write(buffer, offset, count);
        }

        /// <summary>
        /// 写串口
        /// </summary>
        /// <param name="text"></param>
        private void Write(string text)
        {
            this._sictPort.Write(text);
        }

        #endregion
    }
}
