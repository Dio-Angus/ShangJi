/*-----------------------------------------------------------------------------
//  FILE NAME       : OnGraphDouble.cs
//  FUNCTION        : 采集多图形显示
//  AUTHOR          : 李锋(2009/10/13)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Windows.Forms;
using ChromatoBll.ocx;
using ChromatoTool.ini;
using ChromatoTool.pipe;
using System;

namespace ChromatoCore.On
{
    /// <summary>
    /// 采集多图形显示
    /// </summary>
    public partial class OnGraphDouble : UserControl
    {

        #region 变量

        /// <summary>
        /// 图形逻辑层
        /// </summary>
        private OnGraphBiz _bizOnGraph = null;

        #endregion 


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OnGraphDouble()
        {
            InitializeComponent();
            this.LoadEvent();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.splitterGraph.SplitterMoved += new SplitterEventHandler(this.splitterGraph_SplitterMoved);
        }

        /// <summary>
        /// 设置图形逻辑层对象
        /// </summary>
        /// <param name="bizOnGraph"></param>
        public void SetGraphBiz(OnGraphBiz bizOnGraph)
        {
            this._bizOnGraph = bizOnGraph;
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


        #region 方法

        /// <summary>
        /// 配置改变时Ocx改变大小
        /// </summary>
        public void OcxResize()
        {
            switch (this.onGraphSingle1._id)
            {
                case ChannelID.A:


                    if (ShowChannel.A && ShowChannel.B)
                    {
                        this.onGraphSingle1.Height = (this.Bottom - this.Top) / 2;
                    }
                    else if (ShowChannel.A && !ShowChannel.B)
                    {
                        this.onGraphSingle1.Height = (this.Bottom - this.Top);
                        this.onGraphSingle2.Height = 0;
                    }
                    else if (!ShowChannel.A && ShowChannel.B)
                    {
                        this.onGraphSingle1.Height = 0;
                        this.onGraphSingle2.Height = (this.Bottom - this.Top);
                    }
                    else
                    {
                        this.onGraphSingle1.Height = 0;
                        this.onGraphSingle2.Height = 0;
                    }
                    this.OcxResizeAB();
                    break;

                case ChannelID.C:

                    if (ShowChannel.C && ShowChannel.D)
                    {
                        this.onGraphSingle1.Height = (this.Bottom - this.Top) / 2;
                    }
                    else if (ShowChannel.C && !ShowChannel.D)
                    {
                        this.onGraphSingle1.Height = (this.Bottom - this.Top);
                        this.onGraphSingle2.Height = 0;
                    }
                    else if (!ShowChannel.C && ShowChannel.D)
                    {
                        this.onGraphSingle1.Height = 0;
                        this.onGraphSingle2.Height = (this.Bottom - this.Top);
                    }
                    else
                    {
                        this.onGraphSingle1.Height = 0;
                        this.onGraphSingle2.Height = 0;
                    }
                    this.OcxResizeCD(); 
                    break;
            }
        }

        /// <summary>
        /// 初期和分隔条移动时Ocx改变大小
        /// </summary>
        public void OcxResizeNormal()
        {
            switch (this.onGraphSingle1._id)
            {
                case ChannelID.A:
                    if (ShowChannel.A && !ShowChannel.B)
                    {
                        this.onGraphSingle1.Height = (this.Bottom - this.Top);
                        this.onGraphSingle2.Height = 0;
                    }
                    else if (!ShowChannel.A && ShowChannel.B)
                    {
                        this.onGraphSingle1.Height = 0;
                        this.onGraphSingle2.Height = (this.Bottom - this.Top);
                    }
                    else if (!ShowChannel.A && !ShowChannel.B)
                    {
                        this.onGraphSingle1.Height = 0;
                        this.onGraphSingle2.Height = 0;
                    }
                    this.OcxResizeAB();
                    break;

                case ChannelID.C:
                    if (ShowChannel.C && !ShowChannel.D)
                    {
                        this.onGraphSingle1.Height = (this.Bottom - this.Top);
                        this.onGraphSingle2.Height = 0;
                    }
                    else if (!ShowChannel.C && ShowChannel.D)
                    {
                        this.onGraphSingle1.Height = 0;
                        this.onGraphSingle2.Height = (this.Bottom - this.Top);
                    }
                    else if (!ShowChannel.C && !ShowChannel.D)
                    {
                        this.onGraphSingle1.Height = 0;
                        this.onGraphSingle2.Height = 0;
                    }
                    this.OcxResizeCD();
                    break;
            }
        }

        /// <summary>
        /// Tcd大小改变
        /// </summary>
        private void OcxResizeAB()
        {

            this._bizOnGraph._bizResize(ChannelID.A).GraphResize(2, 0,
               this.Width, this.splitterGraph.Top, // * 2 / 3,
               0, 0);
            this._bizOnGraph._bizArrow(ChannelID.A).UpdateArrow();

            this._bizOnGraph._bizResize(ChannelID.B).GraphResize(this.splitterGraph.Bottom, 0,
                this.Width, this.Height - this.splitterGraph.Bottom,
                0, 0);
            this._bizOnGraph._bizArrow(ChannelID.B).UpdateArrow();
        }

        /// <summary>
        /// Fid大小改变
        /// </summary>
        private void OcxResizeCD()
        {
            this._bizOnGraph._bizResize(ChannelID.C).GraphResize(2, 0,
             this.Width, this.splitterGraph.Top, // * 2 / 3,
             0, 0);
            this._bizOnGraph._bizArrow(ChannelID.C).UpdateArrow();

            this._bizOnGraph._bizResize(ChannelID.D).GraphResize(this.splitterGraph.Bottom, 0,
                this.Width, this.Height - this.splitterGraph.Bottom,
                0, 0);
            this._bizOnGraph._bizArrow(ChannelID.D).UpdateArrow();
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
                case ChannelID.C:
                    this._bizOnGraph.CreateLayer(lf, user, this.onGraphSingle1.GetOcx(), pipe);
                    this.onGraphSingle1._id = lf;
                    this.onGraphSingle1.SetGraphBiz(this._bizOnGraph);
                    break;
                case ChannelID.B:
                case ChannelID.D:
                    this._bizOnGraph.CreateLayer(lf, user, this.onGraphSingle2.GetOcx(), pipe);
                    this.onGraphSingle2._id = lf;
                    this.onGraphSingle2.SetGraphBiz(this._bizOnGraph);
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
                case ChannelID.C:
                    this.onGraphSingle1.GetOcx().FullPipeName = pipeFullName;
                    break;
                case ChannelID.B:
                case ChannelID.D:
                    this.onGraphSingle2.GetOcx().FullPipeName = pipeFullName;
                    break;
            }
        }

        /// <summary>
        /// 停止按钮线程
        /// </summary>
        public void StopThread()
        {
            this.onGraphSingle1.StopThread();
            this.onGraphSingle2.StopThread();
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
                case ChannelID.C:
                    this.onGraphSingle1.SetChannelText(cmd, info);
                    break;
                case ChannelID.B:
                case ChannelID.D: 
                    this.onGraphSingle2.SetChannelText(cmd, info);
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
                    this.onGraphSingle1.SetVoltageText(moment, vol);
                    break;

                case ChannelID.C:
                    this.onGraphSingle1.SetVoltageText(moment, vol);
                    break;
                case ChannelID.B:
                case ChannelID.D:
                    this.onGraphSingle2.SetVoltageText(moment, vol);
                    break;
            }
        }

        /// <summary>
        /// 更新检测器状态
        /// </summary>
        public void UpdateDetectorLabel(String id)
        {
            switch (id)
            {
                case IdChannel.Tcd1:
                case IdChannel.Tcd2:
                    this.onGraphSingle1.UpdateDetectorLabel(id);
                    break;
                case IdChannel.Fid1:
                case IdChannel.Fid2:
                    this.onGraphSingle2.UpdateDetectorLabel(id);
                    break;
            }
        }

        #endregion

    }
}
