/*-----------------------------------------------------------------------------
//  FILE NAME       : CompareGraphViewer.cs
//  FUNCTION        : 比较图形显示
//  AUTHOR          : 李锋(2009/07/28)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.ini;
using ChromatoTool.pipe;
using ChromatoBll.bll;
using ChromatoBll.ocx;
using ChromatoTool.dto;
using ChromatoTool.util;
using System.Collections;
using System.Threading;

namespace ChromatoCore.Compare
{
    /// <summary>
    /// 比较图形显示
    /// </summary>
    public partial class CompareGraphViewer : UserControl
    {

        #region 变量

        /// <summary>
        /// 图形逻辑层
        /// </summary>
        private CompareGraphBiz _bizCompareGraph = null;

        /// <summary>
        /// 样品逻辑
        /// </summary>
        private ParaBiz _bizPara = null;

        /// <summary>
        /// 放大光标
        /// </summary>
        private Cursor _inCur = null;

        /// <summary>
        /// 原始数据逻辑
        /// </summary>
        private OriginPointBiz _bizOri = null;

        /// <summary>
        /// 平均数据保存
        /// </summary>
        private AvgPointBiz _bizAvg = null;

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
        /// 电压或者时间轴的标志
        /// </summary>
        private VolTimeFlag _vtFlag = VolTimeFlag.Voltage;

        /// <summary>
        /// 是否停止线程
        /// </summary>
        private volatile bool _isKill = false;

        /// <summary>
        /// 当前选中的比较样品
        /// </summary>
        private CompareDto _dtoCompare = null;

        #endregion 


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public CompareGraphViewer()
        {
            InitializeComponent();

            this.LoadUi();
            this.LoadEvent();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._bizCompareGraph = new CompareGraphBiz();
            this._bizPara = new ParaBiz();
            this._bizOri = new OriginPointBiz();
            this._bizAvg = new AvgPointBiz();

            //装载放大光标
            this._inCur = CastCursor.LoadCursor("ChromatoTool.Res.magnify.cur");
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.tsBtnRestore.Click += new System.EventHandler(this.MenuItemFullScale_Click);
            this.tsBtnHrizontal.Click += new System.EventHandler(this.MenuItemHorizontal_Click);
            this.tsBtnVertical.Click += new System.EventHandler(this.MenuItemVertical_Click);
            this.tsBtnShape.Click += new System.EventHandler(this.MenuItemShape_Click);
            this.tsConfig.Click += new System.EventHandler(this.tsConfig_Click);

            //鼠标事件
            this.axGraphOcx.ClickEvent += new System.EventHandler(this.axGraphOcx_ClickEvent);
            this.axGraphOcx.DblClick += new System.EventHandler(this.axGraphOcx_DblClick);
            this.axGraphOcx.MouseDownEvent += new AxGRAPHOCXLib._DGraphOcxEvents_MouseDownEventHandler(this.axGraphOcx_MouseDownEvent);
            this.axGraphOcx.MouseUpEvent += new AxGRAPHOCXLib._DGraphOcxEvents_MouseUpEventHandler(this.axGraphOcx_MouseUpEvent);
            this.axGraphOcx.MouseMoveEvent += new AxGRAPHOCXLib._DGraphOcxEvents_MouseMoveEventHandler(this.axGraphOcx_MouseMoveEvent);

            //电压
            this.tsVolMaxUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsVolMaxUp_MouseDown);
            this.tsVolMaxDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsVolMaxDown_MouseDown);
            this.tsVolMinUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsVolMinUp_MouseDown);
            this.tsVolMinDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsVolMinDown_MouseDown);

            this.tsVolMaxUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tsVolTime_MouseUp);
            this.tsVolMaxDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tsVolTime_MouseUp);
            this.tsVolMinUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tsVolTime_MouseUp);
            this.tsVolMinDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tsVolTime_MouseUp);

            //时间
            this.tsTimeMaxUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsTimeMaxUp_MouseDown);
            this.tsTimeMaxDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsTimeMaxDown_MouseDown);
            this.tsTimeMinUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsTimeMinUp_MouseDown);
            this.tsTimeMinDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsTimeMinDown_MouseDown);

            this.tsTimeMaxUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tsVolTime_MouseUp);
            this.tsTimeMaxDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tsVolTime_MouseUp);
            this.tsTimeMinUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tsVolTime_MouseUp);
            this.tsTimeMinDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tsVolTime_MouseUp);

            //曲线位置移动
            this.tsMoveUp.Click += new System.EventHandler(this.tsMoveUp_Click);
            this.tsMoveDown.Click += new System.EventHandler(this.tsMoveDown_Click);
            this.tsMoveLeft.Click += new System.EventHandler(this.tsMoveLeft_Click);
            this.tsMoveRight.Click += new System.EventHandler(this.tsMoveRight_Click);

        }

        #endregion


        #region 控件响应鼠标事件

        /// <summary>
        /// 单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axGraphOcx_ClickEvent(object sender, EventArgs e)
        {
            Console.Out.WriteLine("axGraphOcx_ClickEvent");
        }

        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axGraphOcx_DblClick(object sender, EventArgs e)
        {
            Console.Out.WriteLine("axGraphOcx_DblClick");
        }

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
                    this._bizCompareGraph._bizArrow.ShowNormalArrow(e.x, e.y);
                }

                //开始放大缩小处理
                Console.Out.WriteLine("GraphExpandStartS");
                this._bizCompareGraph._bizZoom.ZoomInStart(e.x, e.y);
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
            this._bizCompareGraph._bizZoom.ZoomInRunning(e.x, e.y);
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
            this._bizCompareGraph._bizZoom.ZoomInEnd(e.x, e.y);

            //刷新标签位置
            this._bizCompareGraph._bizReserveTime.DrawLabel();
            this._bizCompareGraph._bizBaseline.DrawBaseline();

        }

        #endregion


        #region 控件响应键盘事件

        /// <summary>
        /// 过滤键盘消息,KeyPreview property should set to true
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    this._bizCompareGraph._bizArrow.MoveLeftOnePixel();

                    //刷新标签位置
                    this._bizCompareGraph._bizReserveTime.DrawLabel();
                    this._bizCompareGraph._bizBaseline.DrawBaseline();

                    break;

                case Keys.Right:
                    this._bizCompareGraph._bizArrow.MoveRightOnePixel();

                    //刷新标签位置
                    this._bizCompareGraph._bizReserveTime.DrawLabel();
                    this._bizCompareGraph._bizBaseline.DrawBaseline();
                    break;

                case Keys.Up:
                    this._bizCompareGraph._bizArrow.ZoomOutOneTime();

                    //刷新标签位置
                    this._bizCompareGraph._bizReserveTime.DrawLabel();
                    this._bizCompareGraph._bizBaseline.DrawBaseline();
                    break;

                case Keys.Down:
                    this._bizCompareGraph._bizArrow.ZoomInOneTime();

                    //刷新标签位置
                    this._bizCompareGraph._bizReserveTime.DrawLabel();
                    this._bizCompareGraph._bizBaseline.DrawBaseline();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        #endregion


        #region 弹出式菜单事件

        /// <summary>
        /// 全景模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemFullScale_Click(object sender, EventArgs e)
        {
            this._bizCompareGraph.SetZoomState(ZoomStatus.normal);

            //刷新标签位置
            this._bizCompareGraph._bizReserveTime.DrawLabel();
            this._bizCompareGraph._bizBaseline.DrawBaseline();
        }

        /// <summary>
        /// 水平放大模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemHorizontal_Click(object sender, EventArgs e)
        {
            this._bizCompareGraph.SetZoomState(ZoomStatus.longitudianl);
        }

        /// <summary>
        /// 垂直放大模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemVertical_Click(object sender, EventArgs e)
        {
            this._bizCompareGraph.SetZoomState(ZoomStatus.transveral);
        }

        /// <summary>
        /// 矩形放大模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemShape_Click(object sender, EventArgs e)
        {
            this._bizCompareGraph.SetZoomState(ZoomStatus.square);
        }

        /// <summary>
        /// 配置窗口显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsConfig_Click(object sender, EventArgs e)
        {
            CompareConfigFrm frm = new CompareConfigFrm();
            if (DialogResult.OK == frm.ShowDialog())
            {
                this._bizCompareGraph._bizResize.UpdateHisGraph();
            }
        }

        #endregion


        #region 菜单按钮事件

        /// <summary>
        /// 鼠标点击移动按钮的处理线程
        /// </summary>
        private void ContinueMouseDownThread()
        {

            while (!_isKill)
            {
                if (!this._isMouseDown)
                {
                    Thread.Sleep(5);
                    continue;
                }
                switch (this._vtFlag)
                {
                    case VolTimeFlag.Voltage:
                        this._bizCompareGraph._bizResize.UpdateVol(this._udFlag);
                        break;
                    case VolTimeFlag.Time:
                        this._bizCompareGraph._bizResize.UpdateTime(this._udFlag);
                        break;
                }
                Thread.Sleep(5);
            }
        }

        /// <summary>
        /// 电压最大值的向上平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsVolMaxUp_MouseDown(object sender, MouseEventArgs e)
        {
            this._vtFlag = VolTimeFlag.Voltage;
            this._udFlag = UpDownFlag.MaxUp;
            this._isMouseDown = true;
        }

        /// <summary>
        /// 电压最大值的向下平移按钮提起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsVolMaxDown_MouseDown(object sender, MouseEventArgs e)
        {
            this._vtFlag = VolTimeFlag.Voltage;
            this._udFlag = UpDownFlag.MaxDown;
            this._isMouseDown = true;
        }

        /// <summary>
        /// 电压最小值的向上平移按钮提起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsVolMinUp_MouseDown(object sender, EventArgs e)
        {
            this._vtFlag = VolTimeFlag.Voltage;
            this._udFlag = UpDownFlag.MinUp;
            this._isMouseDown = true;
        }

        /// <summary>
        /// 电压最小值的向下平移按钮提起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsVolMinDown_MouseDown(object sender, EventArgs e)
        {
            this._vtFlag = VolTimeFlag.Voltage;
            this._udFlag = UpDownFlag.MinDown;
            this._isMouseDown = true;
        }

        /// <summary>
        /// 时间最大值的向上平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsTimeMaxUp_MouseDown(object sender, MouseEventArgs e)
        {
            this._vtFlag = VolTimeFlag.Time;
            this._udFlag = UpDownFlag.MaxUp;
            this._isMouseDown = true;
        }

        /// <summary>
        /// 时间最大值的向下平移按钮提起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsTimeMaxDown_MouseDown(object sender, MouseEventArgs e)
        {
            this._vtFlag = VolTimeFlag.Time;
            this._udFlag = UpDownFlag.MaxDown;
            this._isMouseDown = true;
        }

        /// <summary>
        /// 时间最小值的向上平移按钮提起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsTimeMinUp_MouseDown(object sender, EventArgs e)
        {
            this._vtFlag = VolTimeFlag.Time;
            this._udFlag = UpDownFlag.MinUp;
            this._isMouseDown = true;
        }

        /// <summary>
        /// 时间最小值的向下平移按钮提起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsTimeMinDown_MouseDown(object sender, EventArgs e)
        {
            this._vtFlag = VolTimeFlag.Time;
            this._udFlag = UpDownFlag.MinDown;
            this._isMouseDown = true;
        }

        /// <summary>
        /// 电压或者时间的最小值按钮提起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsVolTime_MouseUp(object sender, EventArgs e)
        {
            this._isMouseDown = false;
        }

        #endregion


        #region 方法

        /// <summary>
        /// 创建显示引擎
        /// </summary>
        /// <param name="lf"></param>
        /// <param name="user"></param>
        /// <param name="pipe"></param>
        public void CreateLayer(ChannelID lf, UserType user, CastPipe pipe)
        {
            this._bizCompareGraph.CreateLayer(lf, user, this.axGraphOcx, pipe);

            this._processThread = new Thread(ContinueMouseDownThread);
            this._processThread.Name = "ContinueMouseDownThread->" + EnumDescription.GetFieldText(lf);
            this._processThread.Start();
        }

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="pipeFullName"></param>
        public void SetPipeName(string pipeFullName)
        {
            this.axGraphOcx.FullPipeName = pipeFullName;
        }

        /// <summary>
        /// 从数据库装载数据
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        private OpenDbResult LoadPlot(CompareDto dto, ArrayList arr)
        {
            if (null == dto || null == dto.PathData)
            {
                return OpenDbResult.NoPath;
            }

            if (!this._bizCompareGraph._isLayerCreated)
            {
                return OpenDbResult.NoLayer;
            }

            //从数据库提取数据
            OpenDbResult dbResult = this._bizAvg.OpenDataDb(dto.PathData, arr);
            return dbResult;
        }

        /// <summary>
        /// 改变大小
        /// </summary>
        public void OcxResize()
        {
            if (null != this._bizCompareGraph._bizTransCompare)
            {
                this._bizCompareGraph._bizResize.GraphResize(this.tsGraphMain.Height, 0,
                    this.Width -this.tsLeft.Width , this.Height - this.tsGraphMain.Height - this.tsBottom.Height,
                    0, 0);
                this._bizCompareGraph._bizArrow.UpdateArrow();
            }

            if (this._bizCompareGraph._isLayerCreated)
            {
                //刷新标签位置
                //this._bizCompareGraph._bizReserveTime.DrawLabel();
                //this._bizCompareGraph._bizBaseline.DrawBaseline();
            }
        }

        /// <summary>
        /// 初期装载曲线列表
        /// </summary>
        /// <param name="arr"></param>
        public void LoadInit(ArrayList arr)
        {
            this._bizCompareGraph._bizTransCompare.LoadInit(arr);
            ArrayList arrPlot = null;

            foreach (CompareDto dto in arr)
            {

                arrPlot = new ArrayList();
                OpenDbResult dbResult = this.LoadPlot(dto, arrPlot);

                switch (dbResult)
                {
                    case OpenDbResult.AlreadyOpened:
                        break;

                    case OpenDbResult.NotExist:
                        //this._bizCompareGraph._bizTransCompare._plot.DataCount = 0;
                        break;

                    case OpenDbResult.Succeed:

                        //设置显示曲线为当前曲线
                        this._bizCompareGraph._bizTransCompare.SetCurrentPlot(dto.id);
                        //给控件传递数据
                        this._bizCompareGraph._bizTransCompare.LoadAvgPlot(arrPlot);

                        //更新谱图属性
                        this._bizCompareGraph._bizArrow.UnvisibleArrow();
                        this._bizCompareGraph._bizResize.UpdateHisGraph();
                        this._bizCompareGraph._bizZoom.SetFullGObj();
                        break;

                    case OpenDbResult.NoData:
                        break;
                }
            }
        }

        /// <summary>
        /// 曲线颜色变更处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void plot_ColorChanged(object sender, ChangeColorArgs e)
        {
            CompareDto dto = (CompareDto)e._var;
            this._bizCompareGraph._bizTransCompare.ChangePlotColor(dto);
        }

        /// <summary>
        /// 追加一条新曲线到图形中
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="arr"></param>
        public void AppendPlot(CompareDto dto,ArrayList arr)
        {
            ArrayList arrPlot = new ArrayList();
            OpenDbResult dbResult = this.LoadPlot(dto, arrPlot);

            switch (dbResult)
            {
                case OpenDbResult.AlreadyOpened:
                    break;

                case OpenDbResult.NotExist:
                    //this._bizCompareGraph._bizTransCompare._plot.DataCount = 0;
                    break;

                case OpenDbResult.Succeed:

                    //增加图形
                    this._bizCompareGraph._bizTransCompare.AppendPlot(dto, arr);

                    //设置显示曲线为当前曲线
                    this._bizCompareGraph._bizTransCompare.SetCurrentPlot(dto.id);
                    //给控件传递数据
                    this._bizCompareGraph._bizTransCompare.LoadAvgPlot(arrPlot);

                    //更新谱图属性
                    this._bizCompareGraph._bizArrow.UnvisibleArrow();
                    this._bizCompareGraph._bizResize.UpdateHisGraph();
                    this._bizCompareGraph._bizZoom.SetFullGObj();
                    break;

                case OpenDbResult.NoData:
                    break;
            }

        }

        /// <summary>
        /// 项目移出处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void plot_ItemRemoved(object sender, ChangeColorArgs e)
        {
            CompareDto dto = (CompareDto)e._var;
            this._bizCompareGraph._bizTransCompare.RemovePlot(dto.id);
        }

        /// <summary>
        /// 曲线是否显示变更处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void plot_ShowChanged(object sender, ChangeShowArgs e)
        {
            CompareDto dto = (CompareDto)e._var;
            this._bizCompareGraph._bizTransCompare.ChangePlotShow(dto);
        }

        /// <summary>
        /// 当前选中的样品参数变更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void plot_SampleCurrent(object sender, CurrentSampleArgs e)
        {
            this._dtoCompare = (CompareDto)e._var;
        }

        /// <summary>
        /// 停止工作线程
        /// </summary>
        public void StopThread()
        {
            if (null != this._processThread)
            {
                this._isKill = true;
                this._processThread.Join();
                this._processThread = null;
            }
        }

        #endregion


        #region 曲线位置移动

        /// <summary>
        /// 向下平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMoveDown_Click(object sender, EventArgs e)
        {
            //设置显示曲线为当前曲线
            if (null != this._dtoCompare)
            {
                this._bizCompareGraph._bizTransCompare.SetCurrentPlot(this._dtoCompare.id);
            }

            this._bizCompareGraph._bizTransCompare.Move(MoveDirection.Down);
        }

        /// <summary>
        /// 向上平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMoveUp_Click(object sender, EventArgs e)
        {
            //设置显示曲线为当前曲线
            if (null != this._dtoCompare)
            {
                this._bizCompareGraph._bizTransCompare.SetCurrentPlot(this._dtoCompare.id);
            } 
            
            this._bizCompareGraph._bizTransCompare.Move(MoveDirection.Up);
        }


        /// <summary>
        /// 向左平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMoveLeft_Click(object sender, EventArgs e)
        {
            //设置显示曲线为当前曲线
            if (null != this._dtoCompare)
            {
                this._bizCompareGraph._bizTransCompare.SetCurrentPlot(this._dtoCompare.id);
            } 
            
            this._bizCompareGraph._bizTransCompare.Move(MoveDirection.Left);
        }

        /// <summary>
        /// 向右平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMoveRight_Click(object sender, EventArgs e)
        {
            //设置显示曲线为当前曲线
            if (null != this._dtoCompare)
            {
                this._bizCompareGraph._bizTransCompare.SetCurrentPlot(this._dtoCompare.id);
            } 
            
            this._bizCompareGraph._bizTransCompare.Move(MoveDirection.Right);
        }

        #endregion
    }
}
