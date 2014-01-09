/*-----------------------------------------------------------------------------
//  FILE NAME       : OnGroupBase.cs
//  FUNCTION        : 采集窗口基类
//  AUTHOR          : 李锋(2010/04//21)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Windows.Forms;
using ChromatoTool.ini; 
using ChromatoTool.pipe;
using ChromatoBll.ocx.biz;
using ChromatoTool.dto;
using System.Collections;
using ChromatoCore.Auto;

namespace ChromatoCore.On
{
    /// <summary>
    /// 采集窗口基类
    /// </summary>
    public partial class OnGroupBase : UserControl
    {


        #region 变量

        /// <summary>
        /// 申请走基线的样品信息
        /// </summary>
        protected volatile ArrayList _arrApplyRunBase = null;

        /// <summary>
        /// 正在走基线的样品信息
        /// </summary>
        protected volatile ArrayList _arrRunBase = null;

        /// <summary>
        /// 自动申请启动列表
        /// </summary>
        protected volatile ArrayList _arrApplyRun = null;

        /// <summary>
        /// 正在运行的样品信息
        /// </summary>
        protected volatile ArrayList _arrRunning = null;

        /// <summary>
        /// 需要停止的样品信息
        /// </summary>
        protected volatile ArrayList _arrApplyStop = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OnGroupBase()
        {
            InitializeComponent();
        }

        #endregion


        #region 方法

        /// <summary>
        /// 改变各个page改变大小
        /// </summary>
        public virtual void PageResize()
        {
            ;
        }

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="lf"></param>
        /// <param name="pipeFullName"></param>
        public virtual void SetPipeName(ChannelID lf, string pipeFullName)
        {
            ;
        }

        /// <summary>
        /// 创建显示引擎
        /// </summary>
        /// <param name="lf"></param>
        /// <param name="user"></param>
        /// <param name="pipe"></param>
        public virtual void CreateLayer(ChannelID lf, UserType user, CastPipe pipe)
        {
            ;
        }

        /// <summary>
        /// 启动采样
        /// </summary>
        /// <param name="channelCmd"></param>
        /// <param name="dtoPara"></param>
        public virtual void StartSample(ChannelCmd channelCmd, ParaDto dtoPara)
        {
            ;
        }

        /// <summary>
        /// 停止采样
        /// </summary>
        /// <param name="channelCmd"></param>
        public virtual void StopSample(ChannelCmd channelCmd)
        {
            ;
        }

        /// <summary>
        /// 程序关闭,停止采集
        /// </summary>
        /// <param name="reason"></param>
        public virtual void StopSample(StopSampleReason reason)
        {
            ;
        }

        /// <summary>
        /// 更新检测器状态
        /// </summary>
        public virtual void UpdateDetectorLabel()
        {
            ;
        }

        /// <summary>
        /// 通道的显示配置改变，自动更新画面
        /// </summary>
        public virtual void OcxShowChange()
        {
            ;
        }

        /// <summary>
        /// 小板卡接收到串口的启动命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void SmallBoard_StartAutoSample(object sender, OnStartArgs e)
        {
            ;
        }

        /// <summary>
        /// 大板卡接收到串口的启动停止命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void BigBoard_GcCommand(object sender, OnBigBoardCmdArgs e)
        {
            ;
        }

        /// <summary>
        /// 通道气板卡接收到串口的启动命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void GasBoard_StartAutoSample(object sender, OnStartArgs e)
        {
            ;
        }

        /// <summary>
        /// 是否存在正在采集或走基线的通道
        /// </summary>
        /// <returns></returns>
        public bool IsSampling()
        {
            return (this._arrRunBase.Count > 0 || this._arrRunning.Count > 0) ? true : false;
        }

        public virtual void InitAuto(AutoRequest auto)
        {
            ;
        }
        #endregion




    }
}
