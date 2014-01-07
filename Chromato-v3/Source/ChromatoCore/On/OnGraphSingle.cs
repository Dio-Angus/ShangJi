/*-----------------------------------------------------------------------------
//  FILE NAME       : OnGraphSingle.cs
//  FUNCTION        : 单个图形和工具栏组合
//  AUTHOR          : 李锋(2009/10/13)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoBll.ocx;
using ChromatoTool.ini;
using System.Threading;
using ChromatoTool.util;
using System.Drawing;

namespace ChromatoCore.On
{
    /// <summary>
    /// 单个图形和工具栏组合
    /// </summary>
    public partial class OnGraphSingle : UserControl
    {
        
        #region 变量

        /// <summary>
        /// 图形逻辑层
        /// </summary>
        private OnGraphBiz _bizOnGraph = null;

        /// <summary>
        /// 通道id
        /// </summary>
        public ChannelID _id { get; set; }

        /// <summary>
        /// 鼠标是否按下
        /// </summary>
        private bool _isMouseDown = false;

        /// <summary>
        /// 数据处理スレッド
        /// </summary>
        private Thread _processThread = null;

        /// <summary>
        /// 增加或者减少的标志
        /// </summary>
        private UpDownFlag _udFlag = UpDownFlag.MaxUp;

        /// <summary>
        /// 是否停止线程
        /// </summary>
        private volatile bool _isKill = false;

        /// <summary> 
        /// 跨线程控件代理
        /// </summary> 
        private delegate void CrossThreadOperationControl();

        /// <summary>
        /// 放大光标
        /// </summary>
        private Cursor _inCur = null;

        #endregion 


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OnGraphSingle()
        {
            InitializeComponent();
            this.LoadEvent();
            this.LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this.tsBtnMinMoveDown.Dock = DockStyle.Bottom;

            //装载放大光标
            this._inCur = CastCursor.LoadCursor("ChromatoTool.Res.magnify.cur");
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.tsBtnMaxMoveUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsBtnMaxMoveUp_MouseDown);
            this.tsBtnMaxMoveUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tsBtnMaxMoveUp_MouseUp);

            this.tsBtnMaxMoveDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsBtnMaxMoveDown_MouseDown);
            this.tsBtnMaxMoveDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tsBtnMaxMoveDown_MouseUp);

            this.tsBtnMinMoveUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsBtnMinMoveUp_MouseDown);
            this.tsBtnMinMoveUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tsBtnMinMoveUp_MouseUp);

            this.tsBtnMinMoveDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsBtnMinMoveDown_MouseDown);
            this.tsBtnMinMoveDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tsBtnMinMoveDown_MouseUp);

            //鼠标在控件上的事件
            this.axGraphOcx.MouseDownEvent += new AxGRAPHOCXLib._DGraphOcxEvents_MouseDownEventHandler(this.axGraphOcx_MouseDownEvent);
            this.axGraphOcx.MouseUpEvent += new AxGRAPHOCXLib._DGraphOcxEvents_MouseUpEventHandler(this.axGraphOcx_MouseUpEvent);
            this.axGraphOcx.MouseMoveEvent += new AxGRAPHOCXLib._DGraphOcxEvents_MouseMoveEventHandler(this.axGraphOcx_MouseMoveEvent);
            this.axGraphOcx.DblClick += new System.EventHandler(this.axGraphOcx_DblClick);
        }

        /// <summary>
        /// 获取图形逻辑对象
        /// </summary>
        /// <returns></returns>
        public AxGRAPHOCXLib.AxGraphOcx GetOcx()
        {
            return this.axGraphOcx;
        }

        /// <summary>
        /// 设置图形逻辑层对象
        /// </summary>
        /// <param name="bizOnGraph"></param>
        public void SetGraphBiz(OnGraphBiz bizOnGraph)
        {
            this._bizOnGraph = bizOnGraph;

            this._processThread = new Thread(ContinueMouseDownThread);
            this._processThread.Name = "ContinueMouseDownThread->" + EnumDescription.GetFieldText(this._id);
            this._processThread.Start();


            switch (_id)
            {
                case ChannelID.A:
                    if (General.LinkObject.ChannelGas == General.ObjectLink ||
                        General.LinkObject.AutoChromatoGas == General.ObjectLink)
                    {
                        this.tsChannelName.Text = GasChannel.A;
                    }
                    else
                    {
                        this.tsChannelName.Text = IdChannel.Tcd1;
                    }
                    break;
                case ChannelID.B:
                    if (General.LinkObject.ChannelGas == General.ObjectLink ||
                        General.LinkObject.AutoChromatoGas == General.ObjectLink)
                    {
                        this.tsChannelName.Text = GasChannel.B;
                    }
                    else
                    {
                        this.tsChannelName.Text = IdChannel.Fid1;
                    }
                    break;
                case ChannelID.C:
                    if (General.LinkObject.ChannelGas == General.ObjectLink ||
                        General.LinkObject.AutoChromatoGas == General.ObjectLink)
                    {
                        this.tsChannelName.Text = GasChannel.C;
                    }
                    else
                    {
                        this.tsChannelName.Text = IdChannel.Tcd2;
                    }
                    break;
                case ChannelID.D:
                    if (General.LinkObject.ChannelGas == General.ObjectLink ||
                        General.LinkObject.AutoChromatoGas == General.ObjectLink)
                    {
                        this.tsChannelName.Text = GasChannel.D;
                    }
                    else
                    {
                        this.tsChannelName.Text = IdChannel.Fid2;
                    }
                    break;
            }
        }

        #endregion


        #region 方法

        /// <summary>
        /// 停止工作线程
        /// </summary>
        public void StopThread()
        {
            this._isKill = true;
            this._processThread.Join();
            this._processThread = null;
        }

        /// <summary>
        /// 设置通道运行信息
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="info"></param>
        public void SetChannelText(RealStatus cmd, string info)
        {
            switch (cmd)
            {

                case RealStatus.Ready:
                    this.tsLabel.Text = info + "->待机";
                    break;

                case RealStatus.RealCollecting:
                    this.tsLabel.Text = info + "->正在采集";
                    break;

                case RealStatus.SimuCollecting:
                    this.tsLabel.Text = info + "->正在模拟采集";
                    break;

                case RealStatus.ManulStart:
                    this.tsLabel.Text = info + "->手动运行";
                    break;

                case RealStatus.ManulStop:
                    this.tsLabel.Text = info + "->手动停止";
                    break;

                case RealStatus.RunBase:
                    this.tsLabel.Text = info + "->走基线";
                    break;

                case RealStatus.StopBase:
                    this.tsLabel.Text = info + "->停止基线";
                    break;


            }
        }

        /// <summary>
        /// 更新实时电压
        /// </summary>
        /// <param name="moment"></param>
        /// <param name="vol"></param>
        public void SetVoltageText(Single moment, Single vol)
        {
 
            // 匿名代理
            CrossThreadOperationControl CrossUpdateVoltageLabel = delegate()
            {
                UpdateVoltageLabel(moment, vol);
            };
            if (this.InvokeRequired)
            {
                this.Invoke(CrossUpdateVoltageLabel);
            }
        }

        /// <summary>
        /// 更新实时电压
        /// </summary>
        /// <param name="moment"></param>
        /// <param name="vol"></param>
        private void UpdateVoltageLabel(Single moment, Single vol)
        {
            //this.tsMoment.Text = moment + "  (min)";
            //this.tsVoltage.Text = String.Format("{0:0,0}  ", Convert.ToSingle(vol)) + " (µV)";

            this.tsMoment.Text = String.Format("{0:F3}  (min)", moment);
            this.tsVoltage.Text = String.Format("{0:0,0}  (µV)", vol * DefaultItem.uVol);
        }


        /// <summary>
        /// 更新检测器状态
        /// </summary>
        public void UpdateDetectorLabel(String id)
        {
            if (General.LinkObject.ChannelGas == General.ObjectLink ||
                General.LinkObject.AutoChromatoGas == General.ObjectLink)
            {
                switch (id)
                {
                    case IdChannel.Tcd1:
                        this.tsDetector.Text = GasChannel.A + "_已安装";
                        break;
                    case IdChannel.Fid1:
                        this.tsDetector.Text = GasChannel.B + "_已安装";
                        break;
                    case IdChannel.Tcd2:
                        this.tsDetector.Text = GasChannel.C + "_已安装";
                        break;
                    case IdChannel.Fid2:
                        this.tsDetector.Text = GasChannel.D + "_已安装";
                        break;
                }
            }
            else
            {
                switch (id)
                {
                    case IdChannel.Tcd1:
                        this.tsDetector.Text = GcChannel.Tcd1 ? (IdChannel.Tcd1 + "_已安装") : (IdChannel.Tcd1 + "_未安装");
                        break;
                    case IdChannel.Fid1:
                        this.tsDetector.Text = GcChannel.Fid1 ? (IdChannel.Fid1 + "_已安装") : (IdChannel.Fid1 + "_未安装");
                        break;
                    case IdChannel.Tcd2:
                        this.tsDetector.Text = GcChannel.Tcd2 ? (IdChannel.Tcd2 + "_已安装") : (IdChannel.Tcd2 + "_未安装");
                        break;
                    case IdChannel.Fid2:
                        this.tsDetector.Text = GcChannel.Fid2 ? (IdChannel.Fid2 + "_已安装") : (IdChannel.Fid2 + "_未安装");
                        break;
                }
            }
        }

        /// <summary>
        /// 设置自动斜率信息
        /// </summary>
        /// <param name="idChannel"></param>
        /// <param name="info"></param>
        public void SetAutoSlopeText(String idChannel, string info)
        {
 
            // 匿名代理
            CrossThreadOperationControl CrossUpdateAutoSlope = delegate()
            {
                UpdateAutoSlopeLabel1(idChannel, info);
            };
            if (this.InvokeRequired)
            {
                this.Invoke(CrossUpdateAutoSlope);
            }
        }

        /// <summary>
        /// 更新自动斜率
        /// </summary>
        /// <param name="idChannel"></param>
        /// <param name="info"></param>
        private void UpdateAutoSlopeLabel1(string idChannel, string info)
        {
            this.tsLabelAutoSlope.Text = "斜率:" + info;
        }

        #endregion


        #region 鼠标点击移动按钮的事件

        /// <summary>
        /// 鼠标点击移动按钮的处理线程
        /// </summary>
        private void ContinueMouseDownThread()
        {

            while (!this._isKill)
            {
                if(!this._isMouseDown)
                {
                    Thread.Sleep(100);
                    continue;
                }

                this._bizOnGraph.UpdateAxisY(this._udFlag,this._id);
                
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 通道Y最大值的向上平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnMaxMoveUp_MouseDown(object sender, MouseEventArgs e)
        {
            this._udFlag = UpDownFlag.MaxUp;
            this._isMouseDown = true;
        }

        /// <summary>
        /// 通道Y最大值的向上平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnMaxMoveUp_MouseUp(object sender, MouseEventArgs e)
        {
            this._isMouseDown = false;
        }

        /// <summary>
        /// 通道Y最大值的向下平移按钮提起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnMaxMoveDown_MouseDown(object sender, MouseEventArgs e)
        {
            this._udFlag = UpDownFlag.MaxDown;
            this._isMouseDown = true;
        }

        /// <summary>
        /// 通道Y最大值的向下平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnMaxMoveDown_MouseUp(object sender, MouseEventArgs e)
        {
            this._isMouseDown = false;
        }

        /// <summary>
        /// 通道Y最小值的向上平移按钮提起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnMinMoveUp_MouseDown(object sender, EventArgs e)
        {
            this._udFlag = UpDownFlag.MinUp;
            this._isMouseDown = true;
        }

        /// <summary>
        /// 通道Y最小值的向上平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnMinMoveUp_MouseUp(object sender, EventArgs e)
        {
            this._isMouseDown = false;
        }

        /// <summary>
        /// 通道Y最小值的向下平移按钮提起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnMinMoveDown_MouseDown(object sender, EventArgs e)
        {
            this._udFlag = UpDownFlag.MinDown;
            this._isMouseDown = true;
        }

        /// <summary>
        /// 通道Y最小值的向下平移按钮提起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnMinMoveDown_MouseUp(object sender, EventArgs e)
        {
            this._isMouseDown = false;
        }

        #endregion


        #region 控件响应鼠标事件

        /// <summary>
        /// 鼠标落下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axGraphOcx_MouseDownEvent(object sender, AxGRAPHOCXLib._DGraphOcxEvents_MouseDownEvent e)
        {
            Console.Out.WriteLine("axGraphOcx_MouseDownEvent");

            Control c = sender as Control;
            Point p = new Point(e.x, e.y);

            if (1 == e.button)
            {
                if (General.OpenArrow)
                {
                    this._bizOnGraph._bizArrow(this._id).ShowNormalArrow(e.x, e.y);
                }


                //开始放大缩小处理
                Console.Out.WriteLine("GraphExpandStartS");
                this._bizOnGraph._bizZoom(this._id).ZoomInStart(e.x, e.y);
            }
        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axGraphOcx_MouseMoveEvent(object sender, AxGRAPHOCXLib._DGraphOcxEvents_MouseMoveEvent e)
        {
            Cursor.Current = (null == this._inCur) ? Cursors.WaitCursor : this._inCur;

            Console.Out.WriteLine("axGraphOcx_MouseMoveEvent");
            if (2 == e.button)
            {
                return;
            }
            this._bizOnGraph._bizZoom(this._id).ZoomInRunning(e.x, e.y);
        }

        /// <summary>
        /// 鼠标提起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axGraphOcx_MouseUpEvent(object sender, AxGRAPHOCXLib._DGraphOcxEvents_MouseUpEvent e)
        {
            if (2 == e.button)
            {
                return;
            }
            Console.Out.WriteLine("ExpandMouseUpS");
            this._bizOnGraph._bizZoom(this._id).ZoomInEnd(e.x, e.y);


        }

        /// <summary>
        /// 双击复员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axGraphOcx_DblClick(object sender, EventArgs e)
        {
            this._bizOnGraph._bizZoom(this._id).SetZoomState(ZoomStatus.normal);
        }

        #endregion

    }
}
