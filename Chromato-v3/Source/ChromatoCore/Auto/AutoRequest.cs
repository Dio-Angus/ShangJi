/*-----------------------------------------------------------------------------
//  FILE NAME       : AutoRequest.cs
//  FUNCTION        : 自动色谱线程
//  AUTHOR          : 李锋(2010/02/08)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.log;
using System.Data;
using System.Threading;
using ChromatoTool.util;
using AutoChromatoBll.bll;
using ChromatoTool.ini;
using AutoChromatoBll.inf;
using ChromatoTool.dto;
using System.Collections;
using ChromatoCore.On;
using ChromatoCore.Off;
using ChromatoBll.bll;

namespace ChromatoCore.Auto
{
    /// <summary>
    /// 自动色谱线程
    /// </summary>
    public class AutoRequest
    {

        #region 变量
        /// <summary>
        /// 查询スレッド
        /// </summary>
        protected volatile Thread _loopThread = null;

        /// <summary>
        /// 试验取值线程运行标志
        /// </summary>
        protected volatile bool _isRunLoop = false;

        /// <summary>
        /// 自动通道动作的代理
        /// </summary>
        public event EventHandler<OnChannelActionArgs> ChannelActioned = null;

        /// <summary>
        /// 自动分析动作的代理
        /// </summary>
        public event EventHandler<OnSampleAutoAnalysisArgs> SampleAutoAnalysised = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public AutoRequest()
        {
            this.LoadAutoChromatoThread();

        }

        /// <summary>
        /// 装载主处理线程
        /// </summary>
        private void LoadAutoChromatoThread()
        {
            this._loopThread = new Thread(AutoChromatoThread);
            this._loopThread.Name = "AutoChromatoThread";
            this._loopThread.Start();
            this._isRunLoop = false;
        }

        #endregion


        #region 方法
        /// <summary>
        /// 停止线程
        /// </summary>
        public void Stop()
        {
            if (this._isRunLoop)
            {
                this._isRunLoop = false;
                this._loopThread.Join();
            }
        }
        public void Start()
        {
            this._isRunLoop = true;
        }
        #endregion


        #region 通道气数据处理线程

        /// <summary>
        /// 数据捕获线程
        /// </summary>
        private void AutoChromatoThread()
        {

            DateTime dt = DateTime.Now;
            string tempTime = string.Format("AutoChromatoThread Start: {0}:{1}:{2} {3}:{4}:{5} {6}",
                dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            // Console.Out.WriteLine(tempTime);


            // get start time (yyyy MM dd HH mm ss)
            dt = DateTime.Now;

            //间隔1s
            TimeSpan waitTime = new TimeSpan(0, 0, 0, 2, Convert.ToInt32(EnumDescription.GetFieldText(General.ScanPeriod)));

            double remainMs = 0;

            DateTime dtStart = DateTime.Now;

            //自动样品列表
            ArrayList arrStart = new ArrayList();
            
            //自动样品列表
            ArrayList arrAnalysis = new ArrayList();

            // main loop
            while (_isRunLoop)
            {

                //计算时间
                dtStart = DateTime.Now;

                //扫描采集请求
                this.ScanStart(arrStart);

                //扫描分析
                this.ScanAnalysis(arrStart, ref arrAnalysis);

                //计算下个扫描周期的开始时刻
                dt += waitTime;

                // have a rest
                remainMs = (dt - DateTime.Now).TotalMilliseconds;
                if (0 < remainMs)
                {
                    CastLog.Logger("ChromatoFrm", "AutoChromatoThread",
                        String.Format("Sleep {0} ms ", Convert.ToString(remainMs)));
                    Thread.Sleep(Convert.ToInt32(remainMs));
                }
                else
                {
                    dt = DateTime.Now;
                }
            }

            //线程结束，输出到日志
            this._isRunLoop = false;
            dt = DateTime.Now;
            tempTime = string.Format("AutoChromatoThread Finished: {0}:{1}:{2} {3}:{4}:{5} {6}",
                dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            CastLog.Logger("ChromatoFrm", "AutoChromatoThread", tempTime);

        }

        /// <summary>
        /// 追加到运行队列
        /// </summary>
        private void ScanStart(ArrayList arrStart)
        {

            RequestInf infRequest = new RequestInf();

            ArrayList arr = new ArrayList();
            bool bRet = infRequest.LoadStartRequest(ref arr);

            if (!bRet)
            {
                return;
            }

            OnChannelActionArgs channelEve = null;

            channelEve = new OnChannelActionArgs(ChannelAction.Start, (ParaDto)arr[0]);
            this.ChannelActioned(this, channelEve);
            //只放置一次到队列

            arrStart.Add((ParaDto)arr[0]);
        }

        /// <summary>
        /// 追加到分析队列
        /// </summary>
        private void ScanAnalysis(ArrayList arrStart, ref ArrayList arrAnalysis)
        {

            ParaBiz bizPara = new ParaBiz();
            if (0 < arrStart.Count)
            {
                arrAnalysis = bizPara.LoadCollectedPara((ParaDto)arrStart[0]);
                if (3 < arrAnalysis.Count)   // 四通道必须全采集完
                {
                    arrStart.Remove(arrStart[0]);
                }
                else return;
            }
            else return;


            RequestInf infRequest = new RequestInf();

            foreach (ParaDto dto in arrAnalysis)
            {

                if (infRequest.LoadCollectedSample(dto))
                {
                    OnSampleAutoAnalysisArgs autoAnalysisEve = null;

                    autoAnalysisEve = new OnSampleAutoAnalysisArgs(dto);
                    this.SampleAutoAnalysised(this, autoAnalysisEve);
                    
                   // arrAnalysis.Remove(dto);
                }
            }
        }
        #endregion


    }
}
