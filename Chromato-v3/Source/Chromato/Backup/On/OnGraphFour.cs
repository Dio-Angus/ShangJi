/*-----------------------------------------------------------------------------
//  FILE NAME       : OnGraphFour.cs
//  FUNCTION        : 采集4图形显示
//  AUTHOR          : 李锋(2009/11/10)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Windows.Forms;
using ChromatoBll.ocx;
using ChromatoTool.ini;
using ChromatoTool.pipe;
using ChromatoTool.dto;
using System;

namespace ChromatoCore.On
{
    /// <summary>
    /// 采集4图形显示
    /// </summary>
    public partial class OnGraphFour : UserControl
    {

        #region 变量

        /// <summary>
        /// 图形逻辑层
        /// </summary>
        private OnGraphBiz _bizOnGraph = null;

        /// <summary>
        /// 内存显示备份
        /// </summary>
        private ShowChannelDto _dtoShowChannel = null;

        #endregion 


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OnGraphFour()
        {
            InitializeComponent();

            this._bizOnGraph = new OnGraphBiz();
            this.LoadEvent();

            this._dtoShowChannel = new ShowChannelDto();
            this._dtoShowChannel.A = true;
            this._dtoShowChannel.C = true;
            this._dtoShowChannel.B = true;
            this._dtoShowChannel.D = true;

        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.splitterGraph.SplitterMoved += new SplitterEventHandler(this.splitterGraph_SplitterMoved);
        }

        /// <summary>
        /// 获取图形逻辑对象
        /// </summary>
        /// <returns></returns>
        public OnGraphBiz GetGraphBiz()
        {
            return this._bizOnGraph;
        }

        #endregion


        #region 方法

        /// <summary>
        /// 配置改变时改变大小
        /// </summary>
        public void OcxResize()
        {
            if (null != this._bizOnGraph._bizTransSimu(ChannelID.A))
            {
                if ((this._dtoShowChannel.A == ShowChannel.A) &&
                    (this._dtoShowChannel.C == ShowChannel.C) &&
                    (this._dtoShowChannel.B == ShowChannel.B) &&
                    (this._dtoShowChannel.D == ShowChannel.D))
                {
                    ;// return;
                }

                if ((ShowChannel.A || ShowChannel.B) && (ShowChannel.C || ShowChannel.D))
                {
                    this.onGraphDouble1.Height = (this.Bottom - this.Top) / 2;
                }
                else if ((ShowChannel.A || ShowChannel.B) && (!ShowChannel.C && !ShowChannel.D))
                {
                    this.onGraphDouble1.Height = (this.Bottom - this.Top);
                    this.onGraphDouble2.Height = 0;
                }
                else if ((!ShowChannel.A && !ShowChannel.B) && (ShowChannel.C || ShowChannel.D))
                {
                    this.onGraphDouble1.Height = 0;
                    this.onGraphDouble2.Height = (this.Bottom - this.Top);
                }

                this.onGraphDouble1.OcxResize();
                this.onGraphDouble2.OcxResize();

                this._dtoShowChannel.A = ShowChannel.A;
                this._dtoShowChannel.C = ShowChannel.C;
                this._dtoShowChannel.B = ShowChannel.B;
                this._dtoShowChannel.D = ShowChannel.D;
            }
        }

        /// <summary>
        /// 初期和分隔条移动后改变大小
        /// </summary>
        public void OcxResizeNormal()
        {
            if (null != this._bizOnGraph._bizTransSimu(ChannelID.A))
            {
                this.onGraphDouble1.OcxResizeNormal();
                this.onGraphDouble2.OcxResizeNormal();
            }
        }

        /// <summary>
        /// 创建显示引擎
        /// </summary>
        /// <param name="lf"></param>
        /// <param name="user"></param>
        /// <param name="pipe"></param>
        public void CreateLayer(ChannelID lf, UserType user, CastPipe pipe)
        {
            switch (lf)
            {
                case ChannelID.A:
                case ChannelID.B:
                    this.onGraphDouble1.SetGraphBiz(this._bizOnGraph);
                    this.onGraphDouble1.CreateLayer(lf, user, pipe);
                    break;
                case ChannelID.C:
                case ChannelID.D:
                    this.onGraphDouble2.SetGraphBiz(this._bizOnGraph);
                    this.onGraphDouble2.CreateLayer(lf, user, pipe);
                    break;
            }
        }

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="lf"></param>
        /// <param name="pipeFullName"></param>
        public void SetPipeName(ChannelID lf, string pipeFullName)
        {

            switch (lf)
            {
                case ChannelID.A:
                case ChannelID.B:
                    this.onGraphDouble1.SetPipeName(lf, pipeFullName);
                    break;
                case ChannelID.C:
                case ChannelID.D:
                    this.onGraphDouble2.SetPipeName(lf, pipeFullName);
                    break;
            }
        }

        /// <summary>
        /// 启动采样
        /// </summary>
        /// <param name="dtoPara"></param>
        public void StartSample(ParaDto dtoPara)
        {
            switch (dtoPara.ChannelID)
            {
                case IdChannel.Tcd1:
                case GasChannel.A:
                    switch (General.ObjectLink)
                    {
                        case General.LinkObject.SimuGc:
                            this._bizOnGraph.StartSimu(ChannelID.A, dtoPara);
                            break;
                        case General.LinkObject.SmallBoard:
                        case General.LinkObject.BigBoard:
                        case General.LinkObject.ChannelGas:
                        case General.LinkObject.AutoChromatoGas:
                            this._bizOnGraph.StartReal(ChannelID.A, dtoPara);
                            break;
                    }
                    break;
                case IdChannel.Fid1:
                case GasChannel.B:
                    switch (General.ObjectLink)
                    {
                        case General.LinkObject.SimuGc:
                            this._bizOnGraph.StartSimu(ChannelID.B, dtoPara);
                            break;
                        case General.LinkObject.SmallBoard:
                        case General.LinkObject.BigBoard:
                        case General.LinkObject.ChannelGas:
                        case General.LinkObject.AutoChromatoGas:
                            this._bizOnGraph.StartReal(ChannelID.B, dtoPara);
                            break;
                    }
                    break;

                case IdChannel.Tcd2:
                case GasChannel.C:
                    switch (General.ObjectLink)
                    {
                        case General.LinkObject.SimuGc:
                            this._bizOnGraph.StartSimu(ChannelID.C, dtoPara);
                            break;
                        case General.LinkObject.SmallBoard:
                        case General.LinkObject.BigBoard:
                        case General.LinkObject.ChannelGas:
                        case General.LinkObject.AutoChromatoGas:
                            this._bizOnGraph.StartReal(ChannelID.C, dtoPara);
                            break;
                    }
                    break;
                case IdChannel.Fid2:
                case GasChannel.D:
                    switch (General.ObjectLink)
                    {
                        case General.LinkObject.SimuGc:
                            this._bizOnGraph.StartSimu(ChannelID.D, dtoPara);
                            break;
                        case General.LinkObject.SmallBoard:
                        case General.LinkObject.BigBoard:
                        case General.LinkObject.ChannelGas:
                        case General.LinkObject.AutoChromatoGas:
                            this._bizOnGraph.StartReal(ChannelID.D, dtoPara);
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// 走基线
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        public void RunBaseSample(ChannelID id, ParaDto dto)
        {
            switch (General.ObjectLink)
            {
                case General.LinkObject.SimuGc:
                    this._bizOnGraph.RunBaseSimu(id, dto);
                    break;
                case General.LinkObject.SmallBoard:
                case General.LinkObject.BigBoard:
                case General.LinkObject.ChannelGas:
                    this._bizOnGraph.RunBaseReal(id, dto);
                    this._bizOnGraph.UpdateCollection(id);
                    break;
            }
        }

        /// <summary>
        /// 停止采样(停止某个通道运行)
        /// </summary>
        /// <param name="id"></param>
        public void StopSample(ChannelID id)
        {

            switch (General.ObjectLink)
            {
                case General.LinkObject.SimuGc:
                    this._bizOnGraph.StopSimu(id);
                    break;
                case General.LinkObject.SmallBoard:
                case General.LinkObject.BigBoard:
                case General.LinkObject.ChannelGas:
                case General.LinkObject.AutoChromatoGas:
                    this._bizOnGraph.StopReal(id);
                    break;
            }
        }


        /// <summary>
        /// 停止采样(停止某个通道走基线)
        /// </summary>
        /// <param name="id"></param>
        public void StopBase(ChannelID id)
        {

            switch (General.ObjectLink)
            {
                case General.LinkObject.SimuGc:
                    this._bizOnGraph.StopSimu(id);
                    break;
                case General.LinkObject.SmallBoard:
                case General.LinkObject.BigBoard:
                case General.LinkObject.ChannelGas:
                    this._bizOnGraph.StopBase(id);
                    break;
            }
        }

        /// <summary>
        /// 停止采集
        /// </summary>
        /// <param name="reason"></param>
        public void StopSample(StopSampleReason reason)
        {
            switch (reason)
            {
                case StopSampleReason.ShutDown:
                    this.onGraphDouble1.StopThread();
                    this.onGraphDouble2.StopThread();
                    break;
            }
            this._bizOnGraph.StopSample();
        }

        /// <summary>
        /// 更新通道显示内存中的采集方法
        /// </summary>
        /// <param name="id"></param>
        public void UpdateTransCollection(ChannelID id)
        {
            this._bizOnGraph.UpdateTransCollection(id);
        }

        /// <summary>
        /// 设置通道运行信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmd"></param>
        /// <param name="info"></param>
        public void SetChannelText(ChannelID id, RealStatus cmd, string info)
        {
            switch (id)
            {
                case ChannelID.A:
                case ChannelID.B:
                    this.onGraphDouble1.SetChannelText(id, cmd, info);
                    break;
                case ChannelID.C:
                case ChannelID.D:
                    this.onGraphDouble2.SetChannelText(id, cmd, info); 
                    break;
            }
        }

        /// <summary>
        /// 更新实时电压
        /// </summary>
        /// <param name="id"></param>
        /// <param name="moment"></param>
        /// <param name="vol"></param>
        public void SetVoltageText(ChannelID id, Single moment, Single vol)
        {

            switch (id)
            {
                case ChannelID.A:
                case ChannelID.B:
                    this.onGraphDouble1.SetVoltageText(id, moment, vol);
                    break;
                case ChannelID.C:
                case ChannelID.D:
                    this.onGraphDouble2.SetVoltageText(id, moment, vol);
                    break;
            }
        }

        /// <summary>
        /// 更新检测器状态
        /// </summary>
        /// <param name="id"></param>
        public void UpdateDetectorLabel(String id)
        {
            switch (id)
            {
                case IdChannel.Tcd1:
                case IdChannel.Fid1:
                    this.onGraphDouble1.UpdateDetectorLabel(id);
                    break;
                case IdChannel.Tcd2:
                case IdChannel.Fid2:
                    this.onGraphDouble2.UpdateDetectorLabel(id);
                    break;
            }
        }

        #endregion


        #region 事件

        /// <summary>
        /// 分割条事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitterGraph_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.OcxResizeNormal();
        }

        #endregion

    }
}
