/*-----------------------------------------------------------------------------
//  FILE NAME       : TransEvent.cs
//  FUNCTION        : 在线传输自定义事件
//  AUTHOR          : 李锋(2009/05/28)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.ini;

namespace ChromatoBll.ocx.biz
{

    /// <summary>
    /// 更新自动斜率的代理
    /// </summary>
    public class OnAutoSlopeActionArgs : EventArgs
    {
        /// <summary>
        /// 通道
        /// </summary>
        public ChannelID _idChannel { get; set; }

        /// <summary>
        /// 自动斜率
        /// </summary>
        public String _autoSlope { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="id"></param>
        /// <param name="slope"></param>
        public OnAutoSlopeActionArgs(ChannelID id, String slope)
        {
            _idChannel = id;
            _autoSlope = slope;
        }
    }


    /// <summary>
    /// 更新GC实时输出的代理
    /// </summary>
    public class OnRealHardUpdateArgs : EventArgs
    {
        /// <summary>
        /// 类型
        /// </summary>
        public String _type { get; set; }

        /// <summary>
        /// 自动斜率
        /// </summary>
        public String _value { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public OnRealHardUpdateArgs(String type, String value)
        {
            _type = type;
            _value = value;
        }
    }


    /// <summary>
    /// 更新显示实时电压的代理
    /// </summary>
    public class OnVoltageActionArgs : EventArgs
    {
        /// <summary>
        /// 通道
        /// </summary>
        public ChannelID _idChannel { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public Single _moment { get; set; }
        
        /// <summary>
        /// 电压
        /// </summary>
        public Single _voltage { get; set; }

        /// <summary>
        /// 样品名
        /// </summary>
        public String _sampleName { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="id"></param>
        /// <param name="moment"></param>
        /// <param name="vol"></param>
        public OnVoltageActionArgs(ChannelID id, Single moment, Single vol)
        {
            _idChannel = id;
            _moment = moment;
            _voltage = vol;
        }
    }


    /// <summary>
    /// 自动停止采集的代理
    /// </summary>
    public class OnAutoStopActionArgs : EventArgs
    {

        /// <summary>
        /// 样品ID
        /// </summary>
        public String  _sampleID { get; set; }

        /// <summary>
        /// 样品注册时间
        /// </summary>
        public String _registerTime { get; set; }

        /// <summary>
        /// 样品通道id
        /// </summary>
        public ChannelID _channelID { get; set; }

        /// <summary>
        /// 样品名
        /// </summary>
        public String _sampleName { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="id"></param>
        /// <param name="regTime"></param>
        /// <param name="channelId"></param>
        /// <param name="sampleName"></param>
        public OnAutoStopActionArgs(String id, String regTime, ChannelID channelId, String sampleName)
        {
            this._sampleID = id;
            this._registerTime = regTime;
            this._channelID = channelId;
            this._sampleName = sampleName;
       }
    }

    /// <summary>
    /// 小板卡串口接收到启动命令的代理
    /// </summary>
    public class OnStartArgs : EventArgs
    {
        /// <summary>
        /// 类型
        /// </summary>
        public String _channelID { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="id"></param>
        public OnStartArgs(String id)
        {
            _channelID = id;
        }
    }

    /// <summary>
    /// 大板卡串口接收到启动命令的代理
    /// </summary>
    public class OnBigBoardCmdArgs : EventArgs
    {
        /// <summary>
        /// 类型
        /// </summary>
        public String _cmd { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="cmd"></param>
        public OnBigBoardCmdArgs(String cmd)
        {
            _cmd = cmd;
        }
    }

}
