/*-----------------------------------------------------------------------------
//  FILE NAME       : OnEvent.cs
//  FUNCTION        : 在线自定义事件
//  AUTHOR          : 李锋(2009/05/28)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.dto;
using ChromatoTool.ini;

namespace ChromatoCore.On
{

    /// <summary>
    /// 在线样品改变参数类
    /// </summary>
    public class OnSampleChangeArgs : EventArgs
    {
        /// <summary>
        /// 参数
        /// </summary>
        public ParaDto _var { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="m"></param>
        public OnSampleChangeArgs(ParaDto m)
        {
            _var = m;
        }
    }

    /// <summary>
    /// 在线通道动作改变参数类
    /// </summary>
    public class OnChannelActionArgs : EventArgs
    {
        /// <summary>
        /// 返回参数
        /// </summary>
        public ChannelAction _var { get; set; }

        /// <summary>
        /// 样品信息
        /// </summary>
        public ParaDto _dtoPara { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        /// <param name="m"></param>
        /// <param name="dto"></param>
        public OnChannelActionArgs(ChannelAction m, ParaDto dto)
        {
            _var = m;
            _dtoPara = dto;
        }
    }

    /// <summary>
    /// 下载按钮按下的代理
    /// </summary>
    public class OnDownloadActionArgs : EventArgs
    {

        /// <summary>
        /// 样品信息
        /// </summary>
        public ParaDto _dtoPara { get; set; }

        /// <summary>
        /// 反控方法类型
        /// </summary>
        public AntiControlType _type { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="acType"></param>
        public OnDownloadActionArgs(ParaDto dto, AntiControlType acType)
        {
            _dtoPara = dto;
            _type  = acType;
        }
    }


    /// <summary>
    /// 闪烁灯稳定并且为亮的状态下的代理
    /// </summary>
    public class OnReadyActionArgs : EventArgs
    {

        /// <summary>
        /// 是否可以起动
        /// </summary>
        public bool _isReady { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="ready"></param>
        public OnReadyActionArgs(bool ready)
        {
            _isReady = ready;
        }
    }

    /// <summary>
    /// 在线通道更新采集方法类
    /// </summary>
    public class OnChannelUpdateArgs : EventArgs
    {

        /// <summary>
        /// 样品信息
        /// </summary>
        public ParaDto _dtoPara { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        /// <param name="dto"></param>
        public OnChannelUpdateArgs(ParaDto dto)
        {
            _dtoPara = dto;
        }
    }
}
