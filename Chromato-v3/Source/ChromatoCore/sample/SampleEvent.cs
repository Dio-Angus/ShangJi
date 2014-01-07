/*-----------------------------------------------------------------------------
//  FILE NAME       : SampleEvent.cs
//  FUNCTION        : 样品自定义事件
//  AUTHOR          : 李锋(2009/06/02)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.dto;

namespace ChromatoCore.sample
{
    /// <summary>
    /// 在线样品改变参数类
    /// </summary>
    public class SampleChangeArgs : EventArgs
    {
        /// <summary>
        /// 参数
        /// </summary>
        public ParaDto _var { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="m"></param>
        public SampleChangeArgs(ParaDto m)
        {
            _var = m;
        }
    }

    /// <summary>
    /// 保存按钮按下的代理
    /// </summary>
    public delegate void SaveRemarkClickDelegate();

}
