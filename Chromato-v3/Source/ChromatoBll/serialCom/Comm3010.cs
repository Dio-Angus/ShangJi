/*-----------------------------------------------------------------------------
//  FILE NAME       : Comm3010.cs
//  FUNCTION        : 3010型串口封装类
//  AUTHOR          : 李锋(2010/06/14)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Threading;
using ChromatoBll.ocx.biz;
using ChromatoTool.dto;
using ChromatoTool.ini;
using ChromatoTool.log;
using ChromatoTool.util;

namespace ChromatoBll.serialCom
{
    /// <summary>
    /// 3010型串口封装类
    /// </summary>
    public class Comm3010 : CommBase
    {

        #region 变量

        /// <summary>
        /// 实时更新事件
        /// </summary>
        public event EventHandler<OnRealHardUpdateArgs> RealHardUpdated = null;

        /// <summary>
        /// 更新联机脱机图标事件
        /// </summary>
        public event LinkGcDelegate LinkGcEvent;

        /// <summary>
        /// 大板卡串口接收到启动命令事件
        /// </summary>
        public event EventHandler<OnBigBoardCmdArgs> BigBoardCmd = null;
        
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
                    case General.LinkObject.AutoChromatoGas:
                        if (!String.IsNullOrEmpty(this.Open()))
                        {
                            CastLog.Logger("CommPort", "Close",
                                String.Format("打开串口{0}失败 ！", Port.SictPort));
                            return false;
                        }

                        break;
                    case General.LinkObject.BigBoard:
                        return false;
                }
            }

            //スレッドを閉じる
            if (!_isRunLoop)
            {
                CastLog.bHasList = true;
                _isRunLoop = true;

                //清除串口数据
                this.ClearSict();

                this._processThread = new Thread(DataProcessBigBoardThread);
                this._processThread.Name = "DataProcessBigBoardThread";
                this._processThread.Start();
            }

            return true;
        }

        #endregion


        #region 大板卡数据处理线程

        /// <summary>
        /// 数据捕获线程
        /// </summary>
        private void DataProcessBigBoardThread()
        {

            DateTime dt = DateTime.Now;
            string tempTime = string.Format("DataProcessBigBoardThread Start: {0}:{1}:{2} {3}:{4}:{5} {6}",
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

                //计算电压值
                dtStart = DateTime.Now;

                //读数据
                this.ReadSict();
                CastLog.Logger("CommPort", "DataProcessBigBoardThread",
                    String.Format("ReadSict eclipse {0} ms ", Convert.ToString((DateTime.Now - dtStart).TotalMilliseconds)));


                dtStart = DateTime.Now;
                //把数据变成电压
                this.GenerateBigBoardVoltage();

                CastLog.Logger("CommPort", "DataProcessBigBoardThread",
                    String.Format("GenerateVoltage eclipse {0} ms ", Convert.ToString((DateTime.Now - dtStart).TotalMilliseconds)));

                dtStart = DateTime.Now;

                //传输并显示新的曲线点
                RealStatus rs = this._realStatus[(int)ChannelID.A];
                switch (rs)
                {
                    case RealStatus.RealCollecting:
                    case RealStatus.ManulStop:
                    case RealStatus.RunBase:
                        rs = this._bizTrans[(int)ChannelID.A].TransRealByPipeWithOutThread(rs);
                        this._realStatus[(int)ChannelID.A] = rs;
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
                    case RealStatus.ManulStop:
                    case RealStatus.RunBase:
                        rs = this._bizTrans[(int)ChannelID.B].TransRealByPipeWithOutThread(rs);
                        this._realStatus[(int)ChannelID.B] = rs;
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
                    case RealStatus.ManulStop:
                    case RealStatus.RunBase:
                        rs = this._bizTrans[(int)ChannelID.C].TransRealByPipeWithOutThread(rs);
                        this._realStatus[(int)ChannelID.C] = rs;
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
                    case RealStatus.ManulStop:
                    case RealStatus.RunBase:
                        rs = this._bizTrans[(int)ChannelID.D].TransRealByPipeWithOutThread(rs);
                        this._realStatus[(int)ChannelID.D] = rs;
                        break;
                    case RealStatus.StopBase:
                        this._realStatus[(int)ChannelID.D] = RealStatus.Ready;
                        break;
                    case RealStatus.Ready:
                        break;
                }
                CastLog.Logger("CommPort", "DataProcessBigBoardThread",
                    String.Format("TransRealByPipeWithOutThread eclipse {0} ms ", Convert.ToString((DateTime.Now - dtStart).TotalMilliseconds)));


                //计算下个扫描周期的开始时刻
                dt += waitTime;

                // have a rest
                remainMs = (dt - DateTime.Now).TotalMilliseconds;
                if (0 < remainMs)
                {
                    CastLog.Logger("CommPort", "DataProcessBigBoardThread",
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
            tempTime = string.Format("DataProcessThread Finished: {0}:{1}:{2} {3}:{4}:{5} {6}",
                dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            CastLog.Logger("CommPort", "DataProcessBigBoardThread", tempTime);
        }

        /// <summary>
        /// 数据处理
        /// </summary>
        private void GenerateBigBoardVoltage()
        {
            int indexStart = 0;
            int indexEnd = 0;
            string oneFrame = "";
            string temp = this._sictRead.ToString();

            while (true)
            {
                if (String.IsNullOrEmpty(temp))
                {
                    break;
                }
                //提取桢的开始位置
                indexStart = temp.IndexOf(Version3010.DataStart);

                //提取桢的结束位置
                indexEnd = temp.IndexOf(Version3010.FrameEnd, (-1 == indexStart) ? 0 : indexStart + 2);

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
                    this._sictRead.Remove(0, indexEnd + 1);
                    break;
                }
                else
                {
                    oneFrame = temp.Substring(indexStart, indexEnd - indexStart + 2);

                    if (Version3010.MinLength <= oneFrame.Length)
                    {

                        string flag = oneFrame.Substring(4, 2);

                        switch (flag)
                        {
                            case GcCommand.ColTargetTemp:
                                this.DealWithTargetTemp(oneFrame);
                                break;
                            case GcCommand.ColTemp:
                            case GcCommand.TcdTemp:
                            case GcCommand.FidTemp:
                            case GcCommand.InjTemp:
                            case GcCommand.Aux1Temp:
                            case GcCommand.Aux2Temp:
                                this.DealWithTempControl(oneFrame);
                                break;
                            case GcCommand.Fid1Signal:
                                this.DealWithTempControl(oneFrame);
                                this.DealWithFid1(oneFrame);
                                //this.SaveToFile(oneFrame);
                                break;
                            case GcCommand.Fid2Signal:
                                this.DealWithTempControl(oneFrame);
                                this.DealWithFid2(oneFrame);
                                break;
                            case GcCommand.Tcd1Signal:
                                this.DealWithTempControl(oneFrame);
                                this.DealWithTcd1(oneFrame);
                                break;
                            case GcCommand.Tcd2Signal:
                                this.DealWithTcd2(oneFrame);
                                this.DealWithTempControl(oneFrame);
                                break;
                            case GcCommand.LinkResponse:
                                this.DealWithLink(oneFrame);
                                break;
                            case GcCommand.ColTempStatus:
                            case GcCommand.PrepareLed:
                                this.DealWithColTemp(oneFrame);
                                break;
                            case GcCommand.GcStart:
                            case GcCommand.GcStop:
                                this.DealWithStartOrStop(oneFrame);
                                break;
                        }
                    }
                    this._sictRead.Remove(0, indexEnd + 1);
                }
            }
        }

        /// <summary>
        /// 联机返回命令
        /// </summary>
        /// <param name="oneFrame"></param>
        private void DealWithLink(string oneFrame)
        {
            string temp = oneFrame.Substring(4, 2);

            //联机返回命令
            if (GcCommand.LinkResponse.Equals(temp))
            {
                HardBiz.Instance.LinkGc = LinkGcStatus.On;

                temp = oneFrame.Substring(8, 2);
                GcChannel.Tcd2 = (Convert.ToInt32(temp, 16) & 0x20) > 0 ? true : false;
                GcChannel.Tcd1 = (Convert.ToInt32(temp, 16) & 0x10) > 0 ? true : false;
                GcChannel.Fid2 = (Convert.ToInt32(temp, 16) & 0x8) > 0 ? true : false;
                GcChannel.Fid1 = (Convert.ToInt32(temp, 16) & 0x4) > 0 ? true : false;
                this.LinkGcEvent();

            }
            //脱机返回命令
            else if ("02".Equals(temp))
            {
                HardBiz.Instance.LinkGc = LinkGcStatus.Off;
                this.LinkGcEvent();
            }
        }

        /// <summary>
        /// 接收データを変換, "33312E3235"==> "31.25"
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        private String ConvertToValue(String inString)
        {

            //组成电压字符串
            string value = "";

            string mid = "";
            Int32 iConvert = 0;

            for (int i = 0; i < inString.Length / 2; i++)
            {
                if (Version3010.Space.Equals(inString.Substring(i * 2, 2)))
                {
                    continue;
                }
                else if (Version3010.PointHex.Equals(inString.Substring(i * 2, 2)))
                {
                    mid = Version3010.Point;
                }
                else if (Version3010.NegativeHex.Equals(inString.Substring(i * 2, 2)))
                {
                    mid = Version3010.Negative;
                }
                else
                {
                    iConvert = Convert.ToInt32(inString.Substring(i * 2 + 1, 1), 16);
                    mid = Convert.ToString(iConvert, 10);
                }
                value += mid;
            }
            if (!CastString.IsNumeric(value))
            {
                return "0";
            }
            return Convert.ToSingle(value).ToString();
        }

        /// <summary>
        /// TCD1数据转换，保存
        /// </summary>
        /// <param name="oneFrame"></param>
        private void DealWithTcd1(string oneFrame)
        {
            string temp = oneFrame.Substring(4, 2);
            string val = oneFrame.Substring(8, oneFrame.Length - 10);

            if (null == this._bizTrans[(int)ChannelID.A])
            {
                return;
            }

            OriginPointDto dto = new OriginPointDto();
            dto.Voltage = Convert.ToSingle(this.ConvertToValue(val)) / DefaultItem.uVol;
            dto.Moment = Convert.ToSingle(this._bizTrans[(int)ChannelID.A]._collectCount)
                / Convert.ToSingle(General.Frequent) / Convert.ToSingle(DefaultItem.SecondsPerMin);

            RealStatus rs = this._realStatus[(int)ChannelID.A];
            if (RealStatus.RealCollecting == rs || RealStatus.RunBase == rs)
            {
                dto.Index = this._bizTrans[(int)ChannelID.A]._collectCount;
                this._bizTrans[(int)ChannelID.A]._arrChannel.Add(dto);
                this._bizTrans[(int)ChannelID.A]._collectCount++;
            }

            CastLog.Logger("CommPort", "ProcessData",
                String.Format("frame:{0}, 通道:1, time:{1}, value:{2}", oneFrame, dto.Moment, dto.Voltage));

        }

        /// <summary>
        /// TCD2数据转换，保存
        /// </summary>
        /// <param name="oneFrame"></param>
        private void DealWithTcd2(string oneFrame)
        {
            string temp = oneFrame.Substring(4, 2);
            string val = oneFrame.Substring(8, oneFrame.Length - 10);

            if (null == this._bizTrans[(int)ChannelID.B])
            {
                return;
            }

            OriginPointDto dto = new OriginPointDto();
            dto.Voltage = Convert.ToSingle(this.ConvertToValue(val)) / DefaultItem.uVol;

            dto.Moment = Convert.ToSingle(this._bizTrans[(int)ChannelID.B]._collectCount)
                    / Convert.ToSingle(General.Frequent) / Convert.ToSingle(DefaultItem.SecondsPerMin);

            RealStatus rs = this._realStatus[(int)ChannelID.B];
            if (RealStatus.RealCollecting == rs || RealStatus.RunBase == rs)
            {
                dto.Index = this._bizTrans[(int)ChannelID.B]._collectCount;
                this._bizTrans[(int)ChannelID.B]._arrChannel.Add(dto);
                this._bizTrans[(int)ChannelID.B]._collectCount++;
            }

            CastLog.Logger("CommPort", "ProcessData",
                String.Format("frame:{0}, 通道:2, time:{1}, value:{2}", oneFrame, dto.Moment, dto.Voltage));
        }

        /// <summary>
        /// FID1数据转换，保存
        /// </summary>
        /// <param name="oneFrame"></param>
        private void DealWithFid1(string oneFrame)
        {
            string val = oneFrame.Substring(8, oneFrame.Length - 10);

            if (null == this._bizTrans[(int)ChannelID.C])
            {
                return;
            }

            OriginPointDto dto = new OriginPointDto();
            dto.Voltage = Convert.ToSingle(this.ConvertToValue(val)) / DefaultItem.uVol;

            dto.Moment = Convert.ToSingle(this._bizTrans[(int)ChannelID.C]._collectCount)
                / Convert.ToSingle(General.Frequent) / Convert.ToSingle(DefaultItem.SecondsPerMin);

            RealStatus rs = this._realStatus[(int)ChannelID.C];
            if (RealStatus.RealCollecting == rs || RealStatus.RunBase == rs)
            {
                dto.Index = this._bizTrans[(int)ChannelID.C]._collectCount;
                this._bizTrans[(int)ChannelID.C]._arrChannel.Add(dto);
                this._bizTrans[(int)ChannelID.C]._collectCount++;
            }
            CastLog.Logger("CommPort", "ProcessData",
                String.Format("frame:{0}, 通道:1, time:{1}, value:{2}", oneFrame, dto.Moment, dto.Voltage));
        }

        /// <summary>
        /// FID2数据转换，保存
        /// </summary>
        /// <param name="oneFrame"></param>
        private void DealWithFid2(string oneFrame)
        {
            string temp = oneFrame.Substring(4, 2);
            string val = oneFrame.Substring(8, oneFrame.Length - 10);

            RealStatus rs = RealStatus.Ready;

            if (null == this._bizTrans[(int)ChannelID.D])
            {
                return;
            }

            OriginPointDto dto = new OriginPointDto();
            dto.Voltage = Convert.ToSingle(this.ConvertToValue(val)) / DefaultItem.uVol;

            dto.Moment = Convert.ToSingle(this._bizTrans[(int)ChannelID.D]._collectCount)
                    / Convert.ToSingle(General.Frequent) / Convert.ToSingle(DefaultItem.SecondsPerMin);

            rs = this._realStatus[(int)ChannelID.D];
            if (RealStatus.RealCollecting == rs || RealStatus.RunBase == rs)
            {
                dto.Index = this._bizTrans[(int)ChannelID.D]._collectCount;
                this._bizTrans[(int)ChannelID.D]._arrChannel.Add(dto);
                this._bizTrans[(int)ChannelID.D]._collectCount++;
            }

            CastLog.Logger("CommPort", "ProcessData",
                String.Format("frame:{0}, 通道:2, time:{1}, value:{2}", oneFrame, dto.Moment, dto.Voltage));
        }

        /// <summary>
        /// 温度控制转换，保存
        /// </summary>
        /// <param name="oneFrame"></param>
        private void DealWithTempControl(string oneFrame)
        {
            string temp = oneFrame.Substring(4, 2);
            OnRealHardUpdateArgs eve = null;

            string tempLen = oneFrame.Substring(6, 2);
            string val = oneFrame.Substring(8, oneFrame.Length - 10);

            switch (temp)
            {
                case GcCommand.Aux1Temp:
                case GcCommand.Aux2Temp:
                case GcCommand.ColTemp:
                case GcCommand.FidTemp:
                case GcCommand.InjTemp:
                case GcCommand.TcdTemp:
                case GcCommand.Fid1Signal:
                case GcCommand.Fid2Signal:
                case GcCommand.Tcd1Signal:
                case GcCommand.Tcd2Signal:
                    eve = new OnRealHardUpdateArgs(temp, this.ConvertToValue(val));
                    break;
                case GcCommand.ColTempStatus:
                    eve = new OnRealHardUpdateArgs(GcCommand.ColTempStatus, this.ConvertToValue(val));
                    break;

            }

            if (this.RealHardUpdated != null)
            {
                this.RealHardUpdated(this, eve);
            }
        }

        /// <summary>
        /// 目标温度
        /// </summary>
        /// <param name="oneFrame"></param>
        private void DealWithTargetTemp(string oneFrame)
        {
            string temp = oneFrame.Substring(4, 2);
            OnRealHardUpdateArgs eve = null;

            string colStatus = oneFrame.Substring(6, 2);

            //取得中间的数据，除去开始,地址，命令，长度，结束字符
            string val = oneFrame.Substring(8, oneFrame.Length - 10);

            switch (temp)
            {
                case GcCommand.ColTargetTemp:
                    eve = new OnRealHardUpdateArgs(GcCommand.ColStatus, this.ConvertToValue(colStatus));
                    if (this.RealHardUpdated != null)
                    {
                        this.RealHardUpdated(this, eve);
                    }

                    eve = new OnRealHardUpdateArgs(GcCommand.ColTargetTemp, this.ConvertToValue(val));
                    if (this.RealHardUpdated != null)
                    {
                        this.RealHardUpdated(this, eve);
                    }
                    break;
            }
        }

        /// <summary>
        /// 柱箱温度状态
        /// </summary>
        /// <param name="oneFrame"></param>
        private void DealWithColTemp(string oneFrame)
        {
            string temp = oneFrame.Substring(4, 2);
            OnRealHardUpdateArgs eve = null;
            string val = oneFrame.Substring(8, oneFrame.Length - 10);

            switch (temp)
            {
                case GcCommand.ColTempStatus:
                case GcCommand.PrepareLed:
                    eve = new OnRealHardUpdateArgs(temp, val);
                    break;
            }

            if (this.RealHardUpdated != null)
            {
                this.RealHardUpdated(this, eve);
            }
        }

        /// <summary>
        /// 处理开始命令
        /// </summary>
        private void DealWithStartOrStop(string oneFrame)
        {

            string temp = oneFrame.Substring(4, 2);
            string val = oneFrame.Substring(6, 2);

            switch (temp)
            {
                case GcCommand.GcStart:
                case GcCommand.GcStop:
                    OnBigBoardCmdArgs eve = new OnBigBoardCmdArgs(temp);
                    if (this.BigBoardCmd != null)
                    {
                        this.BigBoardCmd(this, eve);
                    }
                    break;
            }
        }

        #endregion
    
    }
}
