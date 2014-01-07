/*-----------------------------------------------------------------------------
//  FILE NAME       : LogEvent.cs
//  FUNCTION        : 日志自定义事件
//  AUTHOR          : 李锋(2009/07/10)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.log
{

    /// <summary>
    /// 传递给主线程的日志参数类
    /// </summary>
    public class ReportLogArgs : EventArgs
    {

        /// <summary>
        /// 日至字符串
        /// </summary>
        public string _var { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="m"></param>
        public ReportLogArgs(string m)
        {
            _var = m;
        }
    }
}
