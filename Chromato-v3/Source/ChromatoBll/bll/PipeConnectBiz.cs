/*-----------------------------------------------------------------------------
//  FILE NAME       : PipeConnectBiz.cs
//  FUNCTION        : 命名管道连接逻辑
//  AUTHOR          : 李锋(2010/06/12)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.ini;
using ChromatoTool.log;
using ChromatoTool.util;
using ChromatoTool.pipe;
using System.Threading;

namespace ChromatoBll.bll
{
    class PipeConnectBiz
    {

        #region 常量

        /// <summary>
        /// 线程休眠间隔
        /// </summary>
        public const int SLEEP_INTERVAL = 50;

        #endregion


        #region 变量

        /// <summary>
        /// 要用到的属性，也就是我们要传递的参数,通道id
        /// </summary>
        private ChannelID _channelId = ChannelID.A;

        /// <summary>
        /// 要用到的属性，也就是我们要传递的参数,管道
        /// </summary>
        private CastPipe _realPipe = null;

        #endregion


        #region 构造

        /// <summary>
        /// 包含参数的构造函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pipe"></param>
        public PipeConnectBiz(ChannelID id, CastPipe pipe)
        {
            _channelId = id;
            _realPipe = pipe;
        }

        /// <summary>
        /// 要丢给线程执行的方法，本处无返回类型就是为了能让ThreadStart来调用
        /// </summary>
        public void RealPipeProcess()
        {
            bool ret = false;
            try
            {
                while (true)
                {
                    ret = NamedPipeNative.ConnectNamedPipe(this._realPipe._hPipe, null);//连接到管道

                    if (!ret)
                    {
                        if (NamedPipeNative.GetLastError() == NamedPipeNative.ERROR_PIPE_CONNECTED)  // 客户还在连接中
                        {
                            CastLog.Logger("PipeBiz", "RealPipeProcess", "连接正常,客户还在连接中……");//此处会出错，因为线程调用的问题
                            ret = true;
                        }

                        if (NamedPipeNative.GetLastError() == NamedPipeNative.ERROR_NO_DATA)         // 客户已经关闭
                        {
                            CastLog.Logger("PipeBiz", "RealPipeProcess", "客户已经关闭，等待客户…………");
                            NamedPipeNative.DisconnectNamedPipe(this._realPipe._hPipe);
                            continue;
                        }
                    }
                    else
                    {
                        CastLog.Logger("PipeBiz", "RealPipeProcess", String.Format("realPipe: {0} client 接入", 
                            EnumDescription.GetFieldText(this._channelId)));
                        break;
                    }

                    Thread.Sleep(SLEEP_INTERVAL);
                }

            }

            catch (Exception ex)
            {
                CastLog.Logger("PipeBiz", "RealPipeProcess", ex.ToString());
            }
            finally
            {
                CastLog.Logger("PipeBiz", "RealPipeProcess", "RealPipe1Process 线程退出！");
            }

        }
        
        #endregion

    }
}
