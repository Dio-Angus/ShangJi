/*-----------------------------------------------------------------------------
//  FILE NAME       : OnlineUser.cs
//  FUNCTION        : 采集主画面
//  AUTHOR          : 李锋(2009/04/14)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoCore.On;
using ChromatoTool.ini;
using ChromatoTool.pipe;
using ChromatoBll.serialCom;
using ChromatoBll.ocx.biz;
using ChromatoCore.Auto;

namespace ChromatoCore.tabCtrl
{
    /// <summary>
    /// 采集主画面
    /// </summary>
    public partial class OnlineUser : UserControl
    {

        #region 变量

        /// <summary>
        /// 采集组合
        /// </summary>
        private OnGroupBase _groupOn = null;

        #endregion


        #region 构造

        /// <summary>
        /// 在线Tab类
        /// </summary>
        public OnlineUser()
        {
            InitializeComponent();
            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {

            switch (General.ObjectLink)
            {
                case General.LinkObject.SmallBoard:
                    this._groupOn = new OnGroup();
                    ((Comm2000)CommPort.Instance).CmdStart += new EventHandler<OnStartArgs>(this._groupOn.SmallBoard_StartAutoSample);
                    break;
                case General.LinkObject.ChannelGas:
                case General.LinkObject.AutoChromatoGas:
                    this._groupOn = new OnGasGroup();
                    ((CommGas)CommPort.Instance).CmdStart += new EventHandler<OnStartArgs>(this._groupOn.GasBoard_StartAutoSample);
                    break;
                case General.LinkObject.BigBoard:
                    this._groupOn = new OnGroup();
                    ((Comm3010)CommPort.Instance).BigBoardCmd += new EventHandler<OnBigBoardCmdArgs>(this._groupOn.BigBoard_GcCommand);
                    break;
            }

            this.Controls.Add(this._groupOn);
        }

        #endregion


        #region 方法

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="lf"></param>
        /// <param name="pipeFullName"></param>
        public void SetPipeName(ChannelID lf, string pipeFullName)
        {
            this._groupOn.SetPipeName(lf, pipeFullName);
        }

        /// <summary>
        /// 创建显示引擎
        /// </summary>
        /// <param name="lf"></param>
        /// <param name="user"></param>
        /// <param name="pipe"></param>
        public void CreateLayer(ChannelID lf, UserType user, CastPipe pipe)
        {
            this._groupOn.CreateLayer(lf, user, pipe);
        }

        /// <summary>
        /// 控件改变大小
        /// </summary>
        public void LoadPage()
        {
            this._groupOn.Width = this.Width;
            this._groupOn.Top = 0;
            this._groupOn.Height = this.Height;
            this._groupOn.PageResize();
            this._groupOn.UpdateDetectorLabel();
        }

        /// <summary>
        /// 更新检测器状态
        /// </summary>
        public void UpdateDetectorStatus()
        {
            this._groupOn.UpdateDetectorLabel();
        }

        /// <summary>
        /// 程序关闭,停止采集
        /// </summary>
        /// <param name="reason"></param>
        public void StopSample(StopSampleReason reason)
        {
            this._groupOn.StopSample(reason);
        }

        /// <summary>
        /// 通道的显示配置改变，自动更新画面
        /// </summary>
        public void OcxShowChange()
        {
            this._groupOn.OcxShowChange();
        }

        /// <summary>
        /// 是否存在正在采集或走基线的通道
        /// </summary>
        /// <returns></returns>
        public bool IsSampling()
        {
            return this._groupOn.IsSampling();
        }

        /// <summary>
        /// 自动采集分析对象
        /// </summary>
        /// <param name="auto"></param>
        public void InitAuto(AutoRequest auto)
        {
            switch (General.ObjectLink)
            {
                case General.LinkObject.AutoChromatoGas:
                    this._groupOn.InitAuto(auto);
                    break;
            }

        }
        #endregion




    }
}
