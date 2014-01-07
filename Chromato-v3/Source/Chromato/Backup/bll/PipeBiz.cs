/*-----------------------------------------------------------------------------
//  FILE NAME       : PipeBiz.cs
//  FUNCTION        : 命名管道资源,创建逻辑
//  AUTHOR          : 李锋(2009/03/27)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.pipe;
using System.Threading;
using ChromatoTool.log;
using ChromatoTool.ini;
using ChromatoTool.util;

namespace ChromatoBll.bll
{
    /// <summary>
    /// 命名管道的资源初期,创建等逻辑
    /// </summary>
    public class PipeBiz
    {

        #region 常量

        /// <summary>
        /// 线程休眠间隔
        /// </summary>
        public const int SLEEP_INTERVAL = 50;

        #endregion


        #region 变量

        /// <summary>
        /// 管道实例
        /// </summary>
        public CastPipe _hisPipe { get; set; }

        /// <summary>
        /// 采集管道实例
        /// </summary>
        public CastPipe[] _realPipe = new CastPipe[4];

        /// <summary>
        /// 样品实例
        /// </summary>
        public CastPipe _samplePipe { get; set; }

        /// <summary>
        /// 校正实例
        /// </summary>
        public CastPipe _correctPipe { get; set; }

        /// <summary>
        /// 比较实例
        /// </summary>
        public CastPipe _comparePipe { get; set; }

        /// <summary>
        /// 采集管道线程
        /// </summary>
        private Thread[] _realThread = new Thread[4];

        #endregion


        #region 构造

        /// <summary>
        /// 实例名
        /// </summary>
        static readonly PipeBiz instance = new PipeBiz();

        /// <summary>
        /// 唯一实例
        /// </summary>
        public static PipeBiz Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// 构造
        /// </summary>
        public PipeBiz()
        {
            this._realPipe = new CastPipe[4];
            this.LoadRealPipe(ChannelID.A);
            this.LoadRealPipe(ChannelID.B);
            this.LoadRealPipe(ChannelID.C);
            this.LoadRealPipe(ChannelID.D);
            this.LoadHisPipe();
            this.LoadSamplePipe();
            this.LoadCorrectPipe();
            this.LoadComparePipe();
        }


        #endregion 


        #region 创建管道，监听

        /// <summary>
        /// 加载实时管道
        /// </summary>
        private void LoadRealPipe(ChannelID id)
        {
            _realPipe[(int)id] = new CastPipe("realPipe" + EnumDescription.GetFieldText(id));
            _realPipe[(int)id].CreatePipe(); //创建管道

            //管道监听线程
            //实例化PipeConnectBiz类，为线程提供参数
            PipeConnectBiz tws = new PipeConnectBiz(id, this._realPipe[(int)id]);

            // 创建执行任务的线程，并执行
            _realThread[(int)id] = new Thread(new ThreadStart(tws.RealPipeProcess));
            _realThread[(int)id].IsBackground = true;
            _realThread[(int)id].Name = String.Format("Real Pipe {0} Listen Thread", EnumDescription.GetFieldText(id));
            _realThread[(int)id].Start();// 启动线程.监听管道，进行通信

            Thread.Sleep(SLEEP_INTERVAL);
        }

        /// <summary>
        /// 加载历史管道
        /// </summary>
        private void LoadHisPipe()
        {
            _hisPipe = new CastPipe("hisPipe");
            _hisPipe.CreatePipe();  //创建管道

            //管道监听线程
            Thread hisThread = new Thread(new ThreadStart(HisPipeProcess));
            hisThread.IsBackground = true;
            hisThread.Name = "His Pipe Listen Thread";
            hisThread.Start();// 启动线程.监听管道，进行通信
            Thread.Sleep(SLEEP_INTERVAL);
        }

        /// <summary>
        /// 加载样品管道
        /// </summary>
        private void LoadSamplePipe()
        {
            _samplePipe = new CastPipe("samplePipe");
            _samplePipe.CreatePipe();  //创建管道

            //管道监听线程
            Thread sampleThread = new Thread(new ThreadStart(SamplePipeProcess));
            sampleThread.IsBackground = true;
            sampleThread.Name = "Sample Pipe Listen Thread";
            sampleThread.Start();// 启动线程.监听管道，进行通信
            Thread.Sleep(SLEEP_INTERVAL);
        }

        /// <summary>
        /// 加载校正管道
        /// </summary>
        private void LoadCorrectPipe()
        {
            this._correctPipe = new CastPipe("correctPipe");
            this._correctPipe.CreatePipe();  //创建管道

            //管道监听线程
            Thread correctThread = new Thread(new ThreadStart(CorrectPipeProcess));
            correctThread.IsBackground = true;
            correctThread.Name = "Correct Pipe Listen Thread";
            correctThread.Start();// 启动线程.监听管道，进行通信
            Thread.Sleep(SLEEP_INTERVAL);
        }

        /// <summary>
        /// 加载比较管道
        /// </summary>
        private void LoadComparePipe()
        {
            this._comparePipe = new CastPipe("comparePipe");
            this._comparePipe.CreatePipe();  //创建管道

            //管道监听线程
            Thread compareThread = new Thread(new ThreadStart(ComparePipeProcess));
            compareThread.IsBackground = true;
            compareThread.Name = "Compare Pipe Listen Thread";
            compareThread.Start();// 启动线程.监听管道，进行通信
            Thread.Sleep(SLEEP_INTERVAL);
        }

        /// <summary>
        /// 监视客户机连接服务器管道的线程
        /// </summary>
        public void HisPipeProcess()
        {

            bool ret = false;
            try
            {
                while (true)
                {
                    ret = NamedPipeNative.ConnectNamedPipe(_hisPipe._hPipe, null);//连接到管道

                    if (!ret)
                    {
                        if (NamedPipeNative.GetLastError() == NamedPipeNative.ERROR_PIPE_CONNECTED)  // 客户还在连接中
                        {
                            CastLog.Logger("PipeBiz", "HisPipeProcess", "连接正常,客户还在连接中……");//此处会出错，因为线程调用的问题
                            ret = true;
                        }

                        if (NamedPipeNative.GetLastError() == NamedPipeNative.ERROR_NO_DATA)         // 客户已经关闭
                        {
                            CastLog.Logger("PipeBiz", "HisPipeProcess", "客户已经关闭，等待客户…………");
                            NamedPipeNative.DisconnectNamedPipe(_hisPipe._hPipe);
                            continue;
                        }
                    }
                    else
                    {
                        CastLog.Logger("PipeBiz", "HisPipeProcess", "hisPipe client 接入");
                        break;
                    }

                    Thread.Sleep(SLEEP_INTERVAL);
                }

            }

            catch (Exception ex)
            {
                CastLog.Logger("PipeBiz", "HisPipeProcess", ex.ToString());
            }
            finally
            {
                CastLog.Logger("PipeBiz", "HisPipeProcess", "HisPipeProcess 线程退出！");
            }

        }

        /// <summary>
        /// 监视客户机连接样品服务器管道的线程
        /// </summary>
        public void SamplePipeProcess()
        {

            bool ret = false;
            try
            {
                while (true)
                {
                    ret = NamedPipeNative.ConnectNamedPipe(this._samplePipe._hPipe, null);//连接到管道

                    if (!ret)
                    {
                        if (NamedPipeNative.GetLastError() == NamedPipeNative.ERROR_PIPE_CONNECTED)  // 客户还在连接中
                        {
                            CastLog.Logger("PipeBiz", "SamplePipeProcess", "连接正常,客户还在连接中……");//此处会出错，因为线程调用的问题
                            ret = true;
                        }

                        if (NamedPipeNative.GetLastError() == NamedPipeNative.ERROR_NO_DATA)         // 客户已经关闭
                        {
                            CastLog.Logger("PipeBiz", "SamplePipeProcess", "客户已经关闭，等待客户…………");
                            NamedPipeNative.DisconnectNamedPipe(this._samplePipe._hPipe);
                            continue;
                        }
                    }
                    else
                    {
                        CastLog.Logger("PipeBiz", "SamplePipeProcess", "samplePipe client 接入");
                        break;
                    }

                    Thread.Sleep(SLEEP_INTERVAL);
                }

            }

            catch (Exception ex)
            {
                CastLog.Logger("PipeBiz", "SamplePipeProcess", ex.ToString());
            }
            finally
            {
                CastLog.Logger("PipeBiz", "SamplePipeProcess", "SamplePipeProcess 线程退出！");
            }

        }

        /// <summary>
        /// 监视客户机连接校正服务器管道的线程
        /// </summary>
        public void CorrectPipeProcess()
        {

            bool ret = false;
            try
            {
                while (true)
                {
                    ret = NamedPipeNative.ConnectNamedPipe(this._correctPipe._hPipe, null);//连接到管道

                    if (!ret)
                    {
                        if (NamedPipeNative.GetLastError() == NamedPipeNative.ERROR_PIPE_CONNECTED)  // 客户还在连接中
                        {
                            CastLog.Logger("PipeBiz", "CorrectPipeProcess", "连接正常,客户还在连接中……");//此处会出错，因为线程调用的问题
                            ret = true;
                        }

                        if (NamedPipeNative.GetLastError() == NamedPipeNative.ERROR_NO_DATA)         // 客户已经关闭
                        {
                            CastLog.Logger("PipeBiz", "CorrectPipeProcess", "客户已经关闭，等待客户…………");
                            NamedPipeNative.DisconnectNamedPipe(this._correctPipe._hPipe);
                            continue;
                        }
                    }
                    else
                    {
                        CastLog.Logger("PipeBiz", "CorrectPipeProcess", "correctPipe client 接入");
                        break;
                    }

                    Thread.Sleep(SLEEP_INTERVAL);
                }

            }

            catch (Exception ex)
            {
                CastLog.Logger("PipeBiz", "CorrectPipeProcess", ex.ToString());
            }
            finally
            {
                CastLog.Logger("PipeBiz", "CorrectPipeProcess", "CorrectPipeProcess 线程退出！");
            }

        }

        /// <summary>
        /// 监视客户机连接比较服务器管道的线程
        /// </summary>
        public void ComparePipeProcess()
        {

            bool ret = false;
            try
            {
                while (true)
                {
                    ret = NamedPipeNative.ConnectNamedPipe(this._comparePipe._hPipe, null);//连接到管道

                    if (!ret)
                    {
                        if (NamedPipeNative.GetLastError() == NamedPipeNative.ERROR_PIPE_CONNECTED)  // 客户还在连接中
                        {
                            CastLog.Logger("PipeBiz", "ComparePipeProcess", "连接正常,客户还在连接中……");//此处会出错，因为线程调用的问题
                            ret = true;
                        }

                        if (NamedPipeNative.GetLastError() == NamedPipeNative.ERROR_NO_DATA)         // 客户已经关闭
                        {
                            CastLog.Logger("PipeBiz", "ComparePipeProcess", "客户已经关闭，等待客户…………");
                            NamedPipeNative.DisconnectNamedPipe(this._comparePipe._hPipe);
                            continue;
                        }
                    }
                    else
                    {
                        CastLog.Logger("PipeBiz", "ComparePipeProcess", "comparePipe client 接入");
                        break;
                    }

                    Thread.Sleep(SLEEP_INTERVAL);
                }

            }

            catch (Exception ex)
            {
                CastLog.Logger("PipeBiz", "ComparePipeProcess", ex.ToString());
            }
            finally
            {
                CastLog.Logger("PipeBiz", "ComparePipeProcess", "ComparePipeProcess 线程退出！");
            }

        }

        #endregion

    }

}
