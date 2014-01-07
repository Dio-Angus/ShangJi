/*-----------------------------------------------------------------------------
//  FILE NAME       : OffGraphViewer.cs
//  FUNCTION        : 离线分析的谱图页
//  AUTHOR          : 李锋(2009/03/10)
//  CHANGE LOG      : 李锋(2009/08/17)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoBll.ocx;
using ChromatoTool.log;
using ChromatoTool.ini;
using ChromatoBll.bll;
using ChromatoTool.dto;
using ChromatoTool.pipe;
using ChromatoTool.util;
using System.Collections;
using System.Data;
using ChromatoPeak.scan;

namespace ChromatoCore.Off
{
    /// <summary>
    /// 谱图页
    /// </summary>
    public partial class OffGraphViewer : UserControl
    {


        #region 变量

        /// <summary>
        /// 图形逻辑层
        /// </summary>
        private OffGraphBiz _bizOffGraph = null;

        /// <summary>
        /// 样品逻辑
        /// </summary>
        private ParaBiz _bizPara = null;

        /// <summary>
        /// 放大光标
        /// </summary>
        private Cursor _inCur = null;

        /// <summary>
        /// 手动编辑光标
        /// </summary>
        private Cursor _editCur = null;

        /// <summary>
        /// 更新联机脱机图标事件
        /// </summary>
        public event AnalysisDelegate AnalysisEvent;

        /// <summary>
        /// 平均数据保存
        /// </summary>
        private AvgPointBiz _bizAvg = null;

        /// <summary>
        /// 原始数据逻辑
        /// </summary>
        private OriginPointBiz _bizOri = null;

        /// <summary>
        /// 手动操作
        /// </summary>
        private ManualGraph _graphManual = ManualGraph.NoManual;

        /// <summary>
        /// 峰删除事件代理
        /// </summary>
        public event EventHandler<OffPeakDeleteArgs> PeakDeleted;

        /// <summary>
        /// 水平基线事件代理
        /// </summary>
        public event EventHandler<ManualBaselineArgs> PeakAdded;

        /// <summary>
        /// 垂直切割事件代理
        /// </summary>
        public event EventHandler<OffPeakSplitArgs> PeakSplited;

        /// <summary>
        /// 峰强制拖尾事件代理
        /// </summary>
        public event EventHandler<OffPeakTypeChangedArgs> PeakTailed;

        /// <summary>
        /// 样品信息dto
        /// </summary>
        private ParaDto _dtoPara = null;

        /// <summary>
        /// 导出按钮按下的事件
        /// </summary>
        public event ExportToFileDelegate ExportToFileEvent;

        /// <summary>
        /// 用户已经选中的历史节点
        /// </summary>
        private string _oldNodeName = "";

        /// <summary>
        /// 样品数据队列
        /// </summary>
        public ArrayList _arrDeducted = null;

        #endregion 


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OffGraphViewer()
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
            //this._bizOffGraph = new OffGraphBiz();
            this._bizOffGraph = OffGraphBiz.Instance;
            this._bizPara = new ParaBiz();
            this._bizOri = new OriginPointBiz();
            this._bizAvg = new AvgPointBiz();

            //装载放大光标
            this._inCur = CastCursor.LoadCursor("ChromatoTool.Res.magnify.cur");

            //装载手动编辑光标
            this._editCur = CastCursor.LoadCursor("ChromatoTool.Res.manual.cur");

            // 初始化工具栏
            this.tsBtnAnaly.ToolTipText = "分析";
            this.tsBtnManulBaseLine.ToolTipText = EnumDescription.GetFieldText(ManualGraph.Baseline);
            this.tsBtnVerticalDivide.ToolTipText = EnumDescription.GetFieldText(ManualGraph.VerticalLine);
            this.tsBtnDealTail.ToolTipText = EnumDescription.GetFieldText(ManualGraph.Tail);
            this.tsButtonDeletePeak.ToolTipText = EnumDescription.GetFieldText(ManualGraph.DeletePeak);
            this.tsBtnReserveNegetivePeak.ToolTipText = EnumDescription.GetFieldText(ManualGraph.ReserveNegetive);

            // 初期化汇总按钮
            this.tsBtnSum.Visible = (General.LinkObject.ChannelGas == General.ObjectLink) ? true : false;

        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.tsBtnAnaly.Click += new System.EventHandler(this.tsBtnAnaly_Click);
            this.tsBtnManulBaseLine.Click += new System.EventHandler(this.tsBtnManulBaseLine_Click);
            this.tsBtnVerticalDivide.Click += new System.EventHandler(this.tsBtnVerticalDivide_Click);
            this.tsBtnDealTail.Click += new System.EventHandler(this.tsBtnDealTail_Click);
            this.tsButtonDeletePeak.Click += new System.EventHandler(this.tsButtonDeletePeak_Click);
            this.tsBtnReserveNegetivePeak.Click += new System.EventHandler(this.tsBtnReserveNegetivePeak_Click);

            this.tsBtnRestore.Click += new System.EventHandler(this.MenuItemFullScale_Click);
            this.tsBtnHrizontal.Click += new System.EventHandler(this.MenuItemHorizontal_Click);
            this.tsBtnVertical.Click += new System.EventHandler(this.MenuItemVertical_Click);
            this.tsBtnShape.Click += new System.EventHandler(this.MenuItemShape_Click);
            this.tsBtnUpdate.Click += new System.EventHandler(this.tsBtnUpdate_Click);
            this.tsBtnExport.Click += new System.EventHandler(this.tsBtnExport_Click);
            this.tsBtnSum.Click += new System.EventHandler(this.tsBtnSum_Click);

            this.tsMoveUp.Click += new System.EventHandler(this.tsMoveUp_Click);
            this.tsMoveDown.Click += new System.EventHandler(this.tsMoveDown_Click);
            this.tsMoveLeft.Click += new System.EventHandler(this.tsMoveLeft_Click);
            this.tsMoveRight.Click += new System.EventHandler(this.tsMoveRight_Click);

            this.axGraphOcx.ClickEvent += new System.EventHandler(this.axGraphOcx_ClickEvent);
            this.axGraphOcx.DblClick += new System.EventHandler(this.axGraphOcx_DblClick);
            this.axGraphOcx.MouseDownEvent += new AxGRAPHOCXLib._DGraphOcxEvents_MouseDownEventHandler(this.axGraphOcx_MouseDownEvent);
            this.axGraphOcx.MouseUpEvent += new AxGRAPHOCXLib._DGraphOcxEvents_MouseUpEventHandler(this.axGraphOcx_MouseUpEvent);
            this.axGraphOcx.MouseMoveEvent += new AxGRAPHOCXLib._DGraphOcxEvents_MouseMoveEventHandler(this.axGraphOcx_MouseMoveEvent);

            this.tsBtnMaxMoveUp.Click += new System.EventHandler(this.tsBtnMaxMoveUp_Click);
            this.tsBtnMaxMoveDown.Click += new System.EventHandler(this.tsBtnMaxMoveDown_Click);
            this.tsBtnMinMoveUp.Click += new System.EventHandler(this.tsBtnMinMoveUp_Click);
            this.tsBtnMinMoveDown.Click += new System.EventHandler(this.tsBtnMinMoveDown_Click);

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


            if (2 == e.button)  //右键
            {
                if (ManualGraph.NoManual != this._graphManual)
                {
                    this._graphManual = ManualGraph.NoManual;
                }
                //右键弹出式菜单
                //this.menuContext.Show(c, p);
            }
            else if (1 == e.button) //左键
            {
                switch (this._graphManual)
                {
                    case ManualGraph.NoManual:
                        if (General.OpenArrow)
                        {
                            //显示十字光标
                            this._bizOffGraph._bizArrow.ShowNormalArrow(e.x, e.y);
                        }

                        //开始放大缩小处理
                        this._bizOffGraph._bizZoom.ZoomInStart(e.x, e.y);
                        break;

                    case ManualGraph.Baseline:
                        General.ArrowStyle = General.StyleArrow.Small;
                        this._bizOffGraph._bizArrow.ShowPeakArrow(e.x, e.y);
                        this._bizOffGraph._bizManualBaseline.
                            StartBaseline(this._bizOffGraph._bizArrow._curXPixel, e.y,
                            this._bizOffGraph._bizArrow._arrayIndex,
                            this._bizOffGraph._bizArrow._isDown,
                            this._bizOffGraph._bizArrow._downVoltage);
                        break;

                    case ManualGraph.VerticalLine:
                        this._bizOffGraph._bizArrow.CacuArrow(e.x, e.y);
                        this.SplitPeak();
                        break;

                    case ManualGraph.Tail:
                        this._bizOffGraph._bizArrow.CacuArrow(e.x, e.y);
                        this.TailPeak();
                        break;

                    case ManualGraph.ReserveNegetive:
                        General.ArrowStyle = General.StyleArrow.Small;
                        this._bizOffGraph._bizArrow.ShowPeakArrow(e.x, e.y);
                        this._bizOffGraph._bizManualNegativeBiz.
                            StartBaseline(this._bizOffGraph._bizArrow._curXPixel, e.y,
                            this._bizOffGraph._bizArrow._arrayIndex,
                            this._bizOffGraph._bizArrow._isDown,
                            this._bizOffGraph._bizArrow._downVoltage);
                        break;

                    case ManualGraph.DeletePeak:
                        this._bizOffGraph._bizArrow.CacuArrow(e.x, e.y);
                        this.DeletePeak();
                        break;
                }
            }
        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axGraphOcx_MouseMoveEvent(object sender, AxGRAPHOCXLib._DGraphOcxEvents_MouseMoveEvent e)
        {
            
            Console.Out.WriteLine("axGraphOcx_MouseMoveEvent");
            if (1 == e.button) //左键
            {
                switch (this._graphManual)
                {
                    case ManualGraph.NoManual:

                        //开始放大缩小处理
                        this._bizOffGraph._bizZoom.ZoomInRunning(e.x, e.y);
                        break;

                    case ManualGraph.Baseline:
                        Cursor.Current = (null == this._editCur) ? Cursors.WaitCursor : this._editCur;
                        this._bizOffGraph._bizArrow.ShowPeakArrow(e.x, e.y);
                        this._bizOffGraph._bizManualBaseline.MoveBaseline(this._bizOffGraph._bizArrow._curXPixel,e.y);
                        break;

                    case ManualGraph.VerticalLine:
                        Cursor.Current = (null == this._editCur) ? Cursors.WaitCursor : this._editCur;
                        break;

                    case ManualGraph.Tail:
                        Cursor.Current = (null == this._editCur) ? Cursors.WaitCursor : this._editCur;
                        break;

                    case ManualGraph.ReserveNegetive:
                        Cursor.Current = (null == this._editCur) ? Cursors.WaitCursor : this._editCur;
                        this._bizOffGraph._bizArrow.ShowPeakArrow(e.x, e.y);
                        this._bizOffGraph._bizManualNegativeBiz.MoveBaseline(this._bizOffGraph._bizArrow._curXPixel, e.y);
                        break;

                    case ManualGraph.DeletePeak:
                        Cursor.Current = (null == this._editCur) ? Cursors.WaitCursor : this._editCur;
                        break;
                }
            }
            else if (0 == e.button)
            {
                switch (this._graphManual)
                {
                    case ManualGraph.NoManual:

                        //缩小处理
                        Cursor.Current = (null == this._inCur) ? Cursors.WaitCursor : this._inCur;
                        break;

                    case ManualGraph.Baseline:
                    case ManualGraph.VerticalLine:
                    case ManualGraph.Tail:
                    case ManualGraph.ReserveNegetive:
                    case ManualGraph.DeletePeak:
                        Cursor.Current = (null == this._editCur) ? Cursors.WaitCursor : this._editCur;
                        break;
                } 
            }
        }

        /// <summary>
        /// 鼠标提起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axGraphOcx_MouseUpEvent(object sender, AxGRAPHOCXLib._DGraphOcxEvents_MouseUpEvent e)
        {
            if (1 == e.button) //左键
            {
                switch (this._graphManual)
                {
                    case ManualGraph.NoManual:

                        //结束缩小处理
                        this._bizOffGraph._bizZoom.ZoomInEnd(e.x, e.y);

                        //刷新标签位置
                        this._bizOffGraph._bizReserveTime.DrawLabel();
                        this._bizOffGraph._bizBaseline.DrawBaseline();

                        break;

                    case ManualGraph.Baseline:
                        
                        //设置光标为大光标
                        General.ArrowStyle = General.StyleArrow.Big;

                        //计算当前鼠标点在曲线中的索引,并计算该曲线点的坐标
                        this._bizOffGraph._bizArrow.ShowPeakArrow(e.x, e.y);

                        //画结束线
                        this._bizOffGraph._bizManualBaseline.StopBaseline(this._bizOffGraph._bizArrow._curXPixel,e.y,
                            this._bizOffGraph._bizArrow._arrayIndex,
                            this._bizOffGraph._bizArrow._isDown,
                            this._bizOffGraph._bizArrow._downVoltage);//this._bizOffGraph._bizArrow._curYPixel);
                        

                        //恢复手动图形状态
                        this._graphManual = ManualGraph.NoManual;

                        //添加这个手动峰到列表,并显示在图形中
                        this.AddPeak();

                        break;

                    case ManualGraph.VerticalLine:
                        this._graphManual = ManualGraph.NoManual;
                        break;

                    case ManualGraph.Tail:
                        this._graphManual = ManualGraph.NoManual;
                        break;

                    case ManualGraph.ReserveNegetive:
                        //设置光标为大光标
                        General.ArrowStyle = General.StyleArrow.Big;

                        //计算当前鼠标点在曲线中的索引,并计算该曲线点的坐标
                        this._bizOffGraph._bizArrow.ShowPeakArrow(e.x, e.y);

                        //画结束线
                        this._bizOffGraph._bizManualNegativeBiz.StopBaseline(this._bizOffGraph._bizArrow._curXPixel, e.y,
                            this._bizOffGraph._bizArrow._arrayIndex,
                            this._bizOffGraph._bizArrow._isDown,
                            this._bizOffGraph._bizArrow._downVoltage);//this._bizOffGraph._bizArrow._curYPixel);


                        //恢复手动图形状态
                        this._graphManual = ManualGraph.NoManual;

                        //添加这个手动峰到列表,并显示在图形中
                        this.AddNegativePeak();
                        break;

                    case ManualGraph.DeletePeak:
                        this._graphManual = ManualGraph.NoManual;
                        break;
                }
            }

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
                    this._bizOffGraph._bizArrow.MoveLeftOnePixel();

                    //刷新标签位置
                    this._bizOffGraph._bizReserveTime.DrawLabel();
                    this._bizOffGraph._bizBaseline.DrawBaseline();

                    break;

                case Keys.Right:
                    this._bizOffGraph._bizArrow.MoveRightOnePixel();

                    //刷新标签位置
                    this._bizOffGraph._bizReserveTime.DrawLabel();
                    this._bizOffGraph._bizBaseline.DrawBaseline();
                    break;

                case Keys.Up:
                    this._bizOffGraph._bizArrow.ZoomOutOneTime();

                    //刷新标签位置
                    this._bizOffGraph._bizReserveTime.DrawLabel();
                    this._bizOffGraph._bizBaseline.DrawBaseline();
                    break;

                case Keys.Down:
                    this._bizOffGraph._bizArrow.ZoomInOneTime();

                    //刷新标签位置
                    this._bizOffGraph._bizReserveTime.DrawLabel();
                    this._bizOffGraph._bizBaseline.DrawBaseline();
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
            this._bizOffGraph.SetZoomState(ZoomStatus.normal);
            CastLog.Logger("","", String.Format("Chromato {0}", this._bizOffGraph._bizZoom.GetExpandText()));

            //刷新标签位置
            this._bizOffGraph._bizReserveTime.DrawLabel();
            this._bizOffGraph._bizBaseline.DrawBaseline();
        }

        /// <summary>
        /// 水平放大模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemHorizontal_Click(object sender, EventArgs e)
        {
            this._bizOffGraph.SetZoomState(ZoomStatus.longitudianl);
            CastLog.Logger("","", string.Format("Chromato {0}", this._bizOffGraph._bizZoom.GetExpandText()));
        }

        /// <summary>
        /// 垂直放大模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemVertical_Click(object sender, EventArgs e)
        {
            this._bizOffGraph.SetZoomState(ZoomStatus.transveral);
            CastLog.Logger("","", string.Format("Chromato {0}", this._bizOffGraph._bizZoom.GetExpandText()));
        }

        /// <summary>
        /// 矩形放大模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemShape_Click(object sender, EventArgs e)
        {
            this._bizOffGraph.SetZoomState(ZoomStatus.square);
            CastLog.Logger("", "矩形放大模式", 
                string.Format("Chromato {0}", this._bizOffGraph._bizZoom.GetExpandText()));
        }

        /// <summary>
        /// 更新设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnUpdate_Click(object sender, EventArgs e)
        {
            this._bizOffGraph._bizResize.UpdateHisGraph();
            this._bizOffGraph._bizZoom.SetFullGObj();
            this._bizOffGraph._bizReserveTime.DrawLabel();
            this._bizOffGraph._bizBaseline.DrawBaseline();

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
            this._bizOffGraph.CreateLayer(lf, user, this.axGraphOcx, pipe);
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
        /// <param name="dsPlot"></param>
        /// <returns></returns>
        public bool LoadPlot(ParaDto dto, ref DataSet dsPlot)
        {
            this.tsBtnAnaly.Enabled = (null == dto) ? false : true;
            this.tsBtnManulBaseLine.Enabled = (null == dto) ? false : true;
            this.tsBtnVerticalDivide.Enabled = (null == dto) ? false : true;
            this.tsBtnDealTail.Enabled = (null == dto) ? false : true;
            this.tsButtonDeletePeak.Enabled = (null == dto) ? false : true;
            this.tsBtnReserveNegetivePeak.Enabled =(null == dto) ? false : true;
            this.tsBtnExport.Enabled = (null == dto) ? false : true;

            //检查选中样品信息是否为空
            if (null == dto || null == dto.PathData)
            {
                return false;
            }
            //检查是否当前节点
            if (this._oldNodeName.Equals(dto.PathData))
            {
                return false;
            }
            if (!this._bizOffGraph._isLayerCreated)
            {
                return false;
            }

            this._dtoPara = dto;

            if (null == this._bizOffGraph._bizTransHis._plot.arr)
            {
                this._bizOffGraph._plot.arr = new ArrayList();
            }

            this._oldNodeName = dto.PathData;

            //从数据库提取数据
            OpenDbResult dbResult = this._bizAvg.OpenDataDb(dto.PathData, this._bizOffGraph._plot.arr, ref dsPlot);
            switch (dbResult)
            {
                case OpenDbResult.AlreadyOpened:
                    return false;

                case OpenDbResult.NotExist:
                    this._bizOffGraph._plot.DataCount = 0;
                    return false;

                case OpenDbResult.Succeed:
                    //给控件传递数据
                    this._bizOffGraph._bizTransHis.LoadAvgPlot();

                    //更新谱图属性
                    this._bizOffGraph._bizArrow._plot = this._bizOffGraph._plot;
                    this._bizOffGraph._bizManualBaseline._plot = this._bizOffGraph._plot;
                    this._bizOffGraph._bizVerticalSplit._plot = this._bizOffGraph._plot;
                    this._bizOffGraph._bizManualNegativeBiz._plot = this._bizOffGraph._plot;
                    this._bizOffGraph._bizArrow.UnvisibleArrow();
                    this._bizOffGraph._bizResize.UpdateHisGraph();
                    this._bizOffGraph._bizZoom.SetFullGObj();
                    break;

                case OpenDbResult.NoData:
                    this._bizOffGraph._plot.DataCount = 0;
                    return false;

            }


            return true;
        }

        /// <summary>
        /// 根据数据和方案分析结果
        /// </summary>
        /// <param name="dto"></param>
        public void Analysis(ParaDto dto)
        {
            //样品信息检查
            if (null == dto || 0 == dto.SampleID.Length || 0 == dto.RegisterTime.Length)
            {
                return;
            }
            //创建峰的分析对象
            EditAvgPoint pointEdit = new EditAvgPoint();

            if (!this.InitAnalyObject(pointEdit, dto))
            {
                return;
            }

            //取得计算结果
            pointEdit.GetResult();

            //保存平均数据到数据库
            this._bizAvg.AppendToDb(dto.PathData, pointEdit._arrAvg, pointEdit._arrAvg.Count);

            //给控件传递平均数据
            this._bizOffGraph._plot.arr = pointEdit._arrAvg;
            this._bizOffGraph._bizTransHis.LoadAvgPlot();

            //更新谱图属性
            this._bizOffGraph._bizResize.UpdateHisGraph();
            this._bizOffGraph._bizZoom.SetFullGObj();

            //把峰的结果写入数据库,如果一条结果都没有,只删除数据库原来数据
            PeakBiz bizPeak = new PeakBiz();
            bizPeak.AppendToDb(dto.PathData, pointEdit._arrPeak, pointEdit._arrPeak.Count);

            //更新样品信息库中样品的状态为已经分析
            this._bizPara.UpdateParaToAnalyzed(dto.SampleID,dto.RegisterTime);

        }

        /// <summary>
        /// 初始化峰的分析对象
        /// </summary>
        /// <param name="pointEdit"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        private bool InitAnalyObject(EditAvgPoint pointEdit, ParaDto dto)
        {
            pointEdit.InnerWeight = dto.InnerWeight;
            pointEdit.SampleWeight = dto.SampleWeight;

            pointEdit._arr = new ArrayList();

            //读取原始数据
            OpenDbResult dbResult = this._bizOri.OpenDb(dto.PathData, pointEdit._arr);
            switch (dbResult)
            {
                case OpenDbResult.AlreadyOpened:
                    break;

                case OpenDbResult.NotExist:
                    return false;

                case OpenDbResult.Succeed:
                    break;

                case OpenDbResult.NoData:
                    return false;
            }

            //扣除基线处理
            this._bizOri.DealDeducted(pointEdit._arr, this._arrDeducted);

            SolutionDto dtoSolu = new SolutionDto();
            SolutionBiz bizSolu = new SolutionBiz();
            RelationDto dtoRela = new RelationDto();

            dtoRela.SampleID = dto.SampleID;
            dtoRela.RegisterTime = dto.RegisterTime;
            dtoSolu.SolutionID = Convert.ToInt32(bizSolu.GetSolutionID(dtoRela));
            if (0 == dtoSolu.SolutionID)
            {
                MessageBox.Show("该样品没有指定方案!", "提示");
                return false;
            }
            bizSolu.QuerySolu(dtoSolu);
            if (0 == dtoSolu.AnalyParaID)
            {
                MessageBox.Show("该样品没有指定方案!", "提示");
                return false;
            }
            //查询分析方法的具体内容
            AnalyParaBiz bizAnaly = new AnalyParaBiz();
            AnalyParaDto dtoAnaly = new AnalyParaDto();
            dtoAnaly.AnalyParaID = dtoSolu.AnalyParaID;
            bizAnaly.GetMethodByID(dtoAnaly);
            pointEdit._dtoAnalyPara = dtoAnaly;

            //是否使用时间程序
            pointEdit._isUseTp = dtoSolu.IsUseTimeProc;
            if (dtoSolu.IsUseTimeProc)
            {
                //查询时间程序的具体内容
                TimeProcDto dtoTimeProc = new TimeProcDto();
                TimeProcBiz bizTimeProc = new TimeProcBiz();
                dtoTimeProc.TPid = dtoSolu.TimeProcID;
                DataSet ds = bizTimeProc.LoadTimeProcByID(dtoTimeProc);
                pointEdit._timeProc = bizTimeProc.GetTpArray();
            }

            //传入ID表
            IngredientBiz bizIngre = new IngredientBiz();
            bizIngre.LoadIngredientByID(dtoSolu.IDTableID);
            pointEdit._arrIngre = bizIngre.GetIngreArry();
            pointEdit._arrCali = new ArrayList();
            CalibrateBiz bizCali = new CalibrateBiz();
            bizCali.ResetArray(dtoSolu.IDTableID);
            IngredientDto dtoIngre = null;
            for (int i = 0; i < pointEdit._arrIngre.Count; i++)
            {
                dtoIngre = (IngredientDto)pointEdit._arrIngre[i];
                pointEdit._arrCali.Add(bizCali.LoadCalibrateInArray(dtoIngre));
            }

            switch (dtoAnaly.ArithmaticID)
            {
                case Arithmatic.Inner:
                    if (0 == pointEdit.InnerWeight)
                    {
                        MessageBox.Show("该样品的内标量为0!", "提示");
                    }
                    break;
                case Arithmatic.Outer:
                case Arithmatic.Exponent:
                    if (0 == pointEdit.SampleWeight)
                    {
                        MessageBox.Show("该样品的样品量为0!", "提示");
                    }
                    if (0 == pointEdit.InnerWeight)
                    {
                        MessageBox.Show("该样品的内标量为0!", "提示");
                    }
                    break;
            }
            return true;
        }

        /// <summary>
        /// 改变大小
        /// </summary>
        public void OcxResize()
        {
            if (null != this._bizOffGraph._bizTransHis)
            {
                this._bizOffGraph._bizResize.GraphResize(0 + this.tsGraphMain.Height, 0 + this.tsArrow.Width,
                    this.Width - this.tsArrow.Width, this.Height - this.tsGraphMain.Height,
                    0, 0);
                this._bizOffGraph._bizArrow.UpdateArrow();
            }

            if (this._bizOffGraph._isLayerCreated)
            {
                //刷新标签位置
                this._bizOffGraph._bizReserveTime.DrawLabel();
                this._bizOffGraph._bizBaseline.DrawBaseline();
            }
        }

        /// <summary>
        /// 显示保留时间
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="dto"></param>
        public void LoadLabelAndBaseline(DataSet ds, ParaDto dto)
        {
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                //清空保留时间
                this._bizOffGraph._bizReserveTime.ClearLabel();
                this._bizOffGraph._bizBaseline.ClearBaseline();
            }
            else
            {
                this._bizOffGraph._bizReserveTime.LoadLabel(ds);
                this._bizOffGraph._bizBaseline.LoadBaseline(ds);
                //this._bizOffGraph._bizExportBmp.NeedExportImage(dto);
            }
        }

        /// <summary>
        /// 删除峰
        /// </summary>
        private void DeletePeak()
        {
            //删除内存中的标签
            Int32 peakId = this._bizOffGraph._bizReserveTime.DeleteLabel(this._bizOffGraph._bizArrow._arrayIndex);
            if (0 < peakId)
            {
                //删除内存中的标签
                this._bizOffGraph._bizBaseline.DeleteBaseline(this._bizOffGraph._bizArrow._arrayIndex);

                //同步数据库
                PeakBiz bizPeak = new PeakBiz();
                bizPeak.DeletePeak(this._dtoPara.PathData, peakId);

                //通知其它视图刷新
                OffPeakDeleteArgs eve = new OffPeakDeleteArgs(peakId);
                if (PeakDeleted != null)
                {
                    this.PeakDeleted(this, eve);
                }
            }
        }

        /// <summary>
        /// 删除手动基线覆盖的峰,添加手动的峰
        /// </summary>
        private void AddPeak()
        {

            //删除内存中的标签
            ArrayList arr = this._bizOffGraph._bizReserveTime.DeleteLabel(
                this._bizOffGraph._bizManualBaseline.GetStartIndex(),
                this._bizOffGraph._bizManualBaseline.GetEndIndex());

            //删除内存中的基线
            if (0 < arr.Count)
            {
                this._bizOffGraph._bizBaseline.DeleteBaseline(arr);
            }

            //追加新的dto
            PeakDto newPeakdto = this._bizOffGraph._bizManualBaseline.AddNewPeak(
                this._bizOffGraph._bizReserveTime._arrPeak);
            
            //列表追加
            this._bizOffGraph._bizReserveTime.AddPeak(newPeakdto);
            this._bizOffGraph._bizBaseline.AddPeak(newPeakdto);

            //重新分组,计算面积,浓度
            this.ReCacuSize(this._bizOffGraph._bizReserveTime._arrPeak);

            //绘图刷新基线
            this._bizOffGraph._bizBaseline.DrawBaseline();

            //同步到数据库
            PeakBiz bizPeak = new PeakBiz();
            foreach (PeakDto dto in arr)
            {
                bizPeak.DeletePeak(this._dtoPara.PathData, dto.PeakID);
            }
            bizPeak.AddPeak(this._dtoPara.PathData, newPeakdto);


            //通知其它视图刷新
            ManualBaselineArgs eve = new ManualBaselineArgs(arr, newPeakdto);
            if (PeakAdded != null)
            {
                this.PeakAdded(this, eve);
            }
        }

        /// <summary>
        /// 分割两个峰
        /// </summary>
        private void SplitPeak()
        {
            //寻找分割的峰id
            PeakDto splitDtoPeak = this._bizOffGraph._bizReserveTime.FindSplitPeak(this._bizOffGraph._bizArrow._arrayIndex);
            if (null != splitDtoPeak)
            {
                //分割峰
                PeakDto newDtoPeak = this._bizOffGraph._bizVerticalSplit.SplitPeak(
                    splitDtoPeak, this._bizOffGraph._bizReserveTime._arrPeak,
                    this._bizOffGraph._bizArrow._arrayIndex);

                //列表更新分割的峰
                this._bizOffGraph._bizBaseline.UpdatePeak(splitDtoPeak);

                //列表追加新的峰
                this._bizOffGraph._bizReserveTime.AddPeak(newDtoPeak);
                this._bizOffGraph._bizBaseline.AddPeak(newDtoPeak);

                //重新分组,计算面积,浓度
                this.ReCacuSize(this._bizOffGraph._bizReserveTime._arrPeak);

                //绘图刷新基线
                this._bizOffGraph._bizBaseline.DrawBaseline();

                //同步数据库
                PeakBiz bizPeak = new PeakBiz();
                bizPeak.UpdatePeak(this._dtoPara.PathData, splitDtoPeak);
                bizPeak.AddPeak(this._dtoPara.PathData, newDtoPeak);

                //通知其它视图刷新
                OffPeakSplitArgs eve = new OffPeakSplitArgs();
                if (PeakSplited != null)
                {
                    this.PeakSplited(this, eve);
                }
            }
        }

        /// <summary>
        ///重新分组,计算面积,浓度
        /// </summary>
        /// <param name="arrPeak"></param>
        private void ReCacuSize(ArrayList arrPeak)
        {

            //创建峰的分析对象
            EditAvgPoint pointEdit = new EditAvgPoint();

            //初始化分析对象
            if (!this.InitAnalyObject(pointEdit, this._dtoPara))
            {
                return;
            }

            //取得计算结果
            pointEdit.ReCacu(arrPeak);
        }

        /// <summary>
        /// 重新从数据库装载平均后的曲线
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="arr"></param>
        public void LoadAvgForExport(ParaDto dto, ArrayList arr)
        {
            if (null == dto || null == dto.PathData)
            {
                return;
            }

            if (!this._bizOffGraph._isLayerCreated)
            {
                return;
            }

            //从数据库提取数据
            OpenDbResult dbResult = this._bizAvg.LoadAvgForExport(dto.PathData, arr);
        }

        /// <summary>
        /// 重新从数据库装载原始的曲线
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="arr"></param>
        public void LoadOriForExport(ParaDto dto, ArrayList arr)
        {
            if (null == dto || null == dto.PathData)
            {
                return;
            }

            if (!this._bizOffGraph._isLayerCreated)
            {
                return;
            }

            //从数据库提取数据
            OpenDbResult dbResult = this._bizOri.OpenDb(dto.PathData, arr);

        }

        /// <summary>
        /// 强制拖尾
        /// </summary>
        private void TailPeak()
        {
            //改变内存中的基线
            Int32 peakId = this._bizOffGraph._bizBaseline.TailPeak(this._bizOffGraph._bizArrow._arrayIndex);

            if (0 < peakId)
            {
                
                //重新分组,计算面积,浓度
                this.ReCacuSize(this._bizOffGraph._bizBaseline._arrPeak);

                //this._bizOffGraph._bizBaseline.TailPeak(this._bizOffGraph._bizArrow._arrayIndex);
                //this._bizOffGraph._bizBaseline.LoadBaseline(ds);
                
                //绘图刷新基线
                this._bizOffGraph._bizBaseline.DrawBaseline();

                //同步数据库
                PeakBiz bizPeak = new PeakBiz();
                bizPeak.AppendToDb(this._dtoPara.PathData, 
                    this._bizOffGraph._bizBaseline._arrPeak,
                    this._bizOffGraph._bizBaseline._arrPeak.Count);

                //通知其它视图刷新
                OffPeakTypeChangedArgs eve = new OffPeakTypeChangedArgs(peakId);
                if (PeakTailed != null)
                {
                    this.PeakTailed(this, eve);
                }
            }
        }

        /// <summary>
        /// 负峰翻转,删除基线覆盖的峰,添加手动的负峰
        /// </summary>
        private void AddNegativePeak()
        {

            //删除内存中的标签
            ArrayList arr = this._bizOffGraph._bizReserveTime.DeleteLabel(
                this._bizOffGraph._bizManualNegativeBiz.GetStartIndex(),
                this._bizOffGraph._bizManualNegativeBiz.GetEndIndex());

            //删除内存中的基线
            if (0 < arr.Count)
            {
                this._bizOffGraph._bizBaseline.DeleteBaseline(arr);
            }

            //追加新的dto
            PeakDto newPeakdto = this._bizOffGraph._bizManualNegativeBiz.AddNewPeak(
                this._bizOffGraph._bizReserveTime._arrPeak);

            //列表追加
            this._bizOffGraph._bizReserveTime.AddPeak(newPeakdto);
            this._bizOffGraph._bizBaseline.AddPeak(newPeakdto);

            //重新分组,计算面积,浓度
            this.ReCacuSize(this._bizOffGraph._bizReserveTime._arrPeak);

            //绘图刷新基线
            this._bizOffGraph._bizBaseline.DrawBaseline();

            //同步到数据库
            PeakBiz bizPeak = new PeakBiz();
            foreach (PeakDto dto in arr)
            {
                bizPeak.DeletePeak(this._dtoPara.PathData, dto.PeakID);
            }
            bizPeak.AddPeak(this._dtoPara.PathData, newPeakdto);


            //通知其它视图刷新
            ManualBaselineArgs eve = new ManualBaselineArgs(arr, newPeakdto);
            if (PeakAdded != null)
            {
                this.PeakAdded(this, eve);
            }
        }

        #endregion


        #region 按钮事件

        /// <summary>
        /// 重新分析按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnAnaly_Click(object sender, EventArgs e)
        {
            this.AnalysisEvent();
        }

        /// <summary>
        /// 手动基线按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnManulBaseLine_Click(object sender, EventArgs e)
        {
            this._graphManual = ManualGraph.Baseline;
        }

        /// <summary>
        /// 垂直切割按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnVerticalDivide_Click(object sender, EventArgs e)
        {
            this._graphManual = ManualGraph.VerticalLine;
        }

        /// <summary>
        /// 脱尾处理按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnDealTail_Click(object sender, EventArgs e)
        {
            this._graphManual = ManualGraph.Tail;
        }

        /// <summary>
        /// 删除峰按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsButtonDeletePeak_Click(object sender, EventArgs e)
        {
            this._graphManual = ManualGraph.DeletePeak;
        }

        /// <summary>
        /// 翻转负峰按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnReserveNegetivePeak_Click(object sender, EventArgs e)
        {
            this._graphManual = ManualGraph.ReserveNegetive;
        }

        /// <summary>
        /// 导出按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnExport_Click(object sender, EventArgs e)
        {
            this.ExportToFileEvent();
        }

        /// <summary>
        /// 汇总按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnSum_Click(object sender, EventArgs e)
        {
            OffGasSumFrm frmOffGasSum = new OffGasSumFrm();
            frmOffGasSum.ShowDialog();
        }

        /// <summary>
        /// 向上平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMoveUp_Click(object sender, EventArgs e)
        {
            this._bizOffGraph._bizResize.MoveUp();

            //刷新标签位置
            this._bizOffGraph._bizReserveTime.DrawLabel();
            this._bizOffGraph._bizBaseline.DrawBaseline();
        }

        /// <summary>
        /// 向下平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMoveDown_Click(object sender, EventArgs e)
        {
            this._bizOffGraph._bizResize.MoveDown();

            //刷新标签位置
            this._bizOffGraph._bizReserveTime.DrawLabel();
            this._bizOffGraph._bizBaseline.DrawBaseline();
        }

        /// <summary>
        /// 向左平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMoveLeft_Click(object sender, EventArgs e)
        {
            this._bizOffGraph._bizResize.MoveLeft();

            //刷新标签位置
            this._bizOffGraph._bizReserveTime.DrawLabel();
            this._bizOffGraph._bizBaseline.DrawBaseline();
        }

        /// <summary>
        /// 向右平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMoveRight_Click(object sender, EventArgs e)
        {
            this._bizOffGraph._bizResize.MoveRight();

            //刷新标签位置
            this._bizOffGraph._bizReserveTime.DrawLabel();
            this._bizOffGraph._bizBaseline.DrawBaseline();
        }


        /// <summary>
        /// 通道Y最大值的向上平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnMaxMoveUp_Click(object sender, EventArgs e)
        {
            this._bizOffGraph._bizResize.UpdateY(UpDownFlag.MaxUp);

            //刷新标签位置
            this._bizOffGraph._bizReserveTime.DrawLabel();
            this._bizOffGraph._bizBaseline.DrawBaseline();
        }

        /// <summary>
        /// 通道Y最大值的向下平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnMaxMoveDown_Click(object sender, EventArgs e)
        {
            this._bizOffGraph._bizResize.UpdateY(UpDownFlag.MaxDown);

            //刷新标签位置
            this._bizOffGraph._bizReserveTime.DrawLabel();
            this._bizOffGraph._bizBaseline.DrawBaseline();
        }

        /// <summary>
        /// 通道Y最小值的向上平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnMinMoveUp_Click(object sender, EventArgs e)
        {
            this._bizOffGraph._bizResize.UpdateY(UpDownFlag.MinUp);

            //刷新标签位置
            this._bizOffGraph._bizReserveTime.DrawLabel();
            this._bizOffGraph._bizBaseline.DrawBaseline();
        }

        /// <summary>
        /// 通道Y最小值的向下平移按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnMinMoveDown_Click(object sender, EventArgs e)
        {
            this._bizOffGraph._bizResize.UpdateY(UpDownFlag.MinDown);

            //刷新标签位置
            this._bizOffGraph._bizReserveTime.DrawLabel();
            this._bizOffGraph._bizBaseline.DrawBaseline();
        }

        #endregion

    }
}
