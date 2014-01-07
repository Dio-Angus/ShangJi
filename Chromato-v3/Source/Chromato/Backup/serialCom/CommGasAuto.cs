/*-----------------------------------------------------------------------------
//  FILE NAME       : CommGasAuto.cs
//  FUNCTION        : 煤矿气自动色谱串口封装类
//  AUTHOR          : 李锋(2010/11/07)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Threading;
using ChromatoTool.log;
using ChromatoTool.ini;
using ChromatoBll.ocx.biz;
using ChromatoTool.dto;
using ChromatoTool.util;


namespace ChromatoBll.serialCom
{
    /// <summary>
    /// 煤矿气串口封装类
    /// </summary>
    public class CommGasAuto : CommBase
    {

        #region 变量

        /// <summary>
        /// 煤矿气板卡串口接收到启动命令事件
        /// </summary>
        public event EventHandler<OnStartArgs> CmdStart = null;

        #endregion


        #region 方法

        /// <summary>
        /// 打开主循环
        /// </summary>
        public override bool OpenLoop()
        {
            //打开串口
            if (!this.IsOpen)
            {
                switch (General.ObjectLink)
                {
                    case General.LinkObject.SmallBoard:
                    case General.LinkObject.ChannelGas:
                    case General.LinkObject.BigBoard:
                        return false;
                    case General.LinkObject.AutoChromatoGas:
                        if (!String.IsNullOrEmpty(this.Open()))
                        {
                            CastLog.Logger("CommPort", "Close",
                                String.Format("打开串口{0}失败 ！", Port.SictPort));
                            return false;
                        }

                        break;

                }
            }

            //スレッドを閉じる
            if (!_isRunLoop)
            {
                CastLog.bHasList = true;
                _isRunLoop = true;

                //清除串口数据
                this.ClearSict();

                this._processThread = new Thread(DataProcessAutoChromatoThread);
                this._processThread.Name = "DataProcessAutoChromatoThread";
                 this._processThread.Start();
            }

            return true;
        }

        #endregion


        #region 通道气数据处理线程

        /// <summary>
        /// 数据捕获线程
        /// </summary>
        private void DataProcessAutoChromatoThread()
        {

            DateTime dt = DateTime.Now;
            string tempTime = string.Format("DataProcessAutoChromatoThread Start: {0}:{1}:{2} {3}:{4}:{5} {6}",
                dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            // Console.Out.WriteLine(tempTime);

            if (!this.IsOpen)
            {
                return;
            }

            // get start time (yyyy MM dd HH mm ss)
            dt = DateTime.Now;

            //间隔1s
            TimeSpan waitTime = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(EnumDescription.GetFieldText(General.ScanPeriod)));

            double remainMs = 0;

            DateTime dtStart = DateTime.Now;

            // main loop
            while (_isRunLoop)
            {

                //计算时间
                dtStart = DateTime.Now;

                //读数据
                this.ReadSict();

                //把数据变成电压
                this.GenerateGasBoardVoltage();

                //CastLog.Logger("CommPort", "DataProcessGasBoardThread",
                //    String.Format("GenerateVoltage eclipse {0} ms ", Convert.ToString((DateTime.Now - dtStart).TotalMilliseconds)));

                //传输并显示新的曲线点
                RealStatus rs = this._realStatus[(int)ChannelID.A];
                switch (rs)
                {
                    case RealStatus.RealCollecting:
                    case RealStatus.RunBase:
                        rs = this._bizTrans[(int)ChannelID.A].TransRealByPipeWithOutThread(rs);
                        this._realStatus[(int)ChannelID.A] = rs;
                        break;
                    case RealStatus.ManulStop:
                        rs = this._bizTrans[(int)ChannelID.A].TransRealByPipeWithOutThread(rs);
                        this._realStatus[(int)ChannelID.A] = RealStatus.Ready;
                        break;
                    case RealStatus.StopBase:
                        this._realStatus[(int)ChannelID.A] = RealStatus.Ready;
                        break;
                    case RealStatus.Ready:
                        break;
                }

                rs = this._realStatus[(int)ChannelID.B];
                switch (rs)
                {
                    case RealStatus.RealCollecting:
                    case RealStatus.RunBase:
                        rs = this._bizTrans[(int)ChannelID.B].TransRealByPipeWithOutThread(rs);
                        this._realStatus[(int)ChannelID.B] = rs;
                        break;
                    case RealStatus.ManulStop:
                        rs = this._bizTrans[(int)ChannelID.B].TransRealByPipeWithOutThread(rs);
                        this._realStatus[(int)ChannelID.B] = RealStatus.Ready;
                        break;
                    case RealStatus.StopBase:
                        this._realStatus[(int)ChannelID.B] = RealStatus.Ready;
                        break;
                    case RealStatus.Ready:
                        break;
                }

                rs = this._realStatus[(int)ChannelID.C];
                switch (rs)
                {
                    case RealStatus.RealCollecting:
                    case RealStatus.RunBase:
                        rs = this._bizTrans[(int)ChannelID.C].TransRealByPipeWithOutThread(rs);
                        this._realStatus[(int)ChannelID.C] = rs;
                        break;
                    case RealStatus.ManulStop:
                        rs = this._bizTrans[(int)ChannelID.C].TransRealByPipeWithOutThread(rs);
                        this._realStatus[(int)ChannelID.C] = RealStatus.Ready;
                        break;
                    case RealStatus.StopBase:
                        this._realStatus[(int)ChannelID.C] = RealStatus.Ready;
                        break;
                    case RealStatus.Ready:
                        break;
                }

                rs = this._realStatus[(int)ChannelID.D];
                switch (rs)
                {
                    case RealStatus.RealCollecting:
                    case RealStatus.RunBase:
                        rs = this._bizTrans[(int)ChannelID.D].TransRealByPipeWithOutThread(rs);
                        this._realStatus[(int)ChannelID.D] = rs;
                        break;
                    case RealStatus.ManulStop:
                        rs = this._bizTrans[(int)ChannelID.D].TransRealByPipeWithOutThread(rs);
                        this._realStatus[(int)ChannelID.D] = RealStatus.Ready;
                        break;
                    case RealStatus.StopBase:
                        this._realStatus[(int)ChannelID.D] = RealStatus.Ready;
                        break;
                    case RealStatus.Ready:
                        break;
                }


                //计算下个扫描周期的开始时刻
                dt += waitTime;

                // have a rest
                remainMs = (dt - DateTime.Now).TotalMilliseconds;
                if (0 < remainMs)
                {
                    CastLog.Logger("CommPort", "DataProcessGasBoardThread",
                        String.Format("Sleep {0} ms ", Convert.ToString(remainMs)));
                    Thread.Sleep(Convert.ToInt32(remainMs));
                }
                else
                {
                    dt = DateTime.Now;
                }
            }

            //关闭串口
            this.Close();

            //线程结束，输出到日志
            this._isRunLoop = false;
            dt = DateTime.Now;
            tempTime = string.Format("DataProcessAutoChromatoThread Finished: {0}:{1}:{2} {3}:{4}:{5} {6}",
                dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            CastLog.Logger("CommPort", "DataProcessAutoChromatoThread", tempTime);

        }

        /// <summary>
        /// 数据处理
        /// </summary>
        private void GenerateGasBoardVoltage()
        {
            int indexStart = 0;
            int indexEnd = 0;
            string oneFrame = "";

            while (true)
            {
                if (null == this._sictRead || 0 == this._sictRead.Length)
                {
                    break;
                }

                //判断是否存在通道1的开始命令
                this.DealWithGasStartButton();

                //提取桢的开始位置
                indexStart = this._sictRead.ToString().IndexOf(Version2000.StartChar);

                //提取桢的结束位置
                indexEnd = this._sictRead.ToString().IndexOf(Version2000.EndChar, (-1 == indexStart) ? 0 : indexStart + 2);

                if (-1 == indexStart && -1 == indexEnd)
                {
                    break;
                }
                else if (-1 != indexStart && -1 == indexEnd)
                {
                    break;
                }
                else if (-1 == indexStart && -1 != indexEnd)
                {
                    //temp = temp.Substring(indexEnd + 2);
                    this._sictRead.Remove(0, indexEnd + 2);
                    break;
                }
                else
                {
                    oneFrame = this._sictRead.ToString().Substring(indexStart, indexEnd - indexStart + 2);

                    this.SaveToFile(oneFrame);
                    this.DealWithGasVoltage(oneFrame);

                    //temp = temp.Substring(indexEnd + 2);
                    this._sictRead.Remove(0, indexEnd + 2);
                }
            }
        }

        /// <summary>
        /// 处理电压值
        /// </summary>
        /// <param name="oneFrame"></param>
        private void DealWithGasVoltage(string oneFrame)
        {
            OriginPointDto dto = null;
            RealStatus rs = RealStatus.Ready;

            if (Version2000.FrameLength != oneFrame.Length)
            {
                CastLog.Logger("CommPort", "DealWithGasVoltage",
                    String.Format("Error frame:{0}, length = {1}", oneFrame, oneFrame.Length));
                return;
            }

            dto = new OriginPointDto();
            dto.Voltage = this.PrepareData(oneFrame);

            switch (oneFrame.Substring(2, 1))
            {
                case GasChannel.A:
                    dto.Moment = Convert.ToSingle(this._bizTrans[(int)ChannelID.A]._collectCount)
                      / Convert.ToSingle(General.Frequent) / DefaultItem.SecondsPerMin;

                    rs = this._realStatus[(int)ChannelID.A];
                    if (RealStatus.RealCollecting == rs || RealStatus.RunBase == rs)
                    {
                        dto.Index = this._bizTrans[(int)ChannelID.A]._collectCount;
                        this._bizTrans[(int)ChannelID.A]._arrChannel.Add(dto);
                        this._bizTrans[(int)ChannelID.A]._collectCount++;
                    }
                    break;

                case GasChannel.B:
                    dto.Moment = Convert.ToSingle(this._bizTrans[(int)ChannelID.B]._collectCount)
                            / Convert.ToSingle(General.Frequent) / Convert.ToSingle(DefaultItem.SecondsPerMin);

                    rs = this._realStatus[(int)ChannelID.B];
                    if (RealStatus.RealCollecting == rs || RealStatus.RunBase == rs)
                    {
                        dto.Index = this._bizTrans[(int)ChannelID.B]._collectCount;
                        this._bizTrans[(int)ChannelID.B]._arrChannel.Add(dto);
                        this._bizTrans[(int)ChannelID.B]._collectCount++;
                    }
                    break;

                case GasChannel.E:
                    dto.Moment = Convert.ToSingle(this._bizTrans[(int)ChannelID.C]._collectCount)
                    / Convert.ToSingle(General.Frequent) / Convert.ToSingle(DefaultItem.SecondsPerMin);

                    rs = this._realStatus[(int)ChannelID.C];
                    if (RealStatus.RealCollecting == rs || RealStatus.RunBase == rs)
                    {
                        dto.Index = this._bizTrans[(int)ChannelID.C]._collectCount;
                        this._bizTrans[(int)ChannelID.C]._arrChannel.Add(dto);
                        this._bizTrans[(int)ChannelID.C]._collectCount++;
                    }
                    break;

                case GasChannel.F:
                    dto.Moment = Convert.ToSingle(this._bizTrans[(int)ChannelID.D]._collectCount)
                            / Convert.ToSingle(General.Frequent) / Convert.ToSingle(DefaultItem.SecondsPerMin);

                    rs = this._realStatus[(int)ChannelID.D];
                    if (RealStatus.RealCollecting == rs || RealStatus.RunBase == rs)
                    {
                        dto.Index = this._bizTrans[(int)ChannelID.D]._collectCount;
                        this._bizTrans[(int)ChannelID.D]._arrChannel.Add(dto);
                        this._bizTrans[(int)ChannelID.D]._collectCount++;
                    }
                    break;
            }
        }

        /// <summary>
        /// 处理开始命令
        /// </summary>
        private void DealWithGasStartButton()
        {
            OnStartArgs eve = null;

            if (-1 != this._sictRead.ToString().IndexOf(Version2000.StartCmdA, 0))
            {
                eve = new OnStartArgs(GasChannel.A);
                if (this.CmdStart != null)
                {
                    this.CmdStart(this, eve);
                }
                this._sictRead.Replace(Version2000.StartCmdA, "");
                CastLog.Logger("CommPort", "DealWithStartButton", "CmdStart->A");

                eve = new OnStartArgs(GasChannel.B);
                if (this.CmdStart != null)
                {
                    this.CmdStart(this, eve);
                }
                CastLog.Logger("CommPort", "DealWithStartButton", "CmdStart->B");
            }

            if (-1 != this._sictRead.ToString().IndexOf(Version2000.StartCmdB, 0))
            {
                eve = new OnStartArgs(GasChannel.C);
                if (this.CmdStart != null)
                {
                    this.CmdStart(this, eve);
                }
                this._sictRead.Replace(Version2000.StartCmdB, "");
                CastLog.Logger("CommPort", "DealWithStartButton", "CmdStart->C");

                eve = new OnStartArgs(GasChannel.D);
                if (this.CmdStart != null)
                {
                    this.CmdStart(this, eve);
                }
                CastLog.Logger("CommPort", "DealWithStartButton", "CmdStart->D");
            }
        }

        #endregion

    }
}
