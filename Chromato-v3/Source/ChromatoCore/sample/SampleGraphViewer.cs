/*-----------------------------------------------------------------------------
//  FILE NAME       : SampleGraphViewer.cs
//  FUNCTION        : 样品结果图形显示
//  AUTHOR          : 李锋(2009/06/04)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoBll.ocx;
using ChromatoBll.bll;
using System.Collections;
using ChromatoTool.ini;
using ChromatoTool.pipe;
using ChromatoTool.dto;
using ChromatoTool.log;
using ChromatoTool.util;
using System.Data;

namespace ChromatoCore.sample
{
    /// <summary>
    /// 样品结果图形显示
    /// </summary>
    public partial class SampleGraphViewer : UserControl
    {

        #region 变量

        /// <summary>
        /// 图形逻辑层
        /// </summary>
        private SampleGraphBiz _bizSamGraph = null;

        /// <summary>
        /// 样品逻辑
        /// </summary>
        private ParaBiz _bizPara = null;

        /// <summary>
        /// 放大光标
        /// </summary>
        private Cursor _inCur = null;

        /// <summary>
        /// 样品参数dto
        /// </summary>
        private ParaDto _dtoPara = null;

        /// <summary>
        /// 平均数据逻辑
        /// </summary>
        private AvgPointBiz _bizAvg = null;

        #endregion 


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SampleGraphViewer()
        {
            InitializeComponent();

            this._bizSamGraph = new SampleGraphBiz();
            this._bizPara = new ParaBiz();
            this._bizAvg = new AvgPointBiz();

            this.axGraphOcx.ClickEvent += new System.EventHandler(this.axGraphOcx_ClickEvent);
            this.axGraphOcx.DblClick += new System.EventHandler(this.axGraphOcx_DblClick);
            this.axGraphOcx.MouseDownEvent += new AxGRAPHOCXLib._DGraphOcxEvents_MouseDownEventHandler(this.axGraphOcx_MouseDownEvent);
            this.axGraphOcx.MouseUpEvent += new AxGRAPHOCXLib._DGraphOcxEvents_MouseUpEventHandler(this.axGraphOcx_MouseUpEvent);
            this.axGraphOcx.MouseMoveEvent += new AxGRAPHOCXLib._DGraphOcxEvents_MouseMoveEventHandler(this.axGraphOcx_MouseMoveEvent);

            this.miFullScale.Click += new System.EventHandler(this.miFullScale_Click);
            this.miHorizontal.Click += new System.EventHandler(this.miHorizontal_Click);
            this.miVertical.Click += new System.EventHandler(this.miVertical_Click);
            this.miShape.Click += new System.EventHandler(this.miShape_Click);
            this.miExport.Click += new System.EventHandler(this.miExport_Click);


            this.tsBtnRestore.Click += new System.EventHandler(this.miFullScale_Click);
            this.tsBtnHrizontal.Click += new System.EventHandler(this.miHorizontal_Click);
            this.tsBtnVertical.Click += new System.EventHandler(this.miVertical_Click);
            this.tsBtnShape.Click += new System.EventHandler(this.miShape_Click);
            this.tsExportBmp.Click += new System.EventHandler(this.miExport_Click);


            this.tsGraphMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsGraphMain_MouseMove);
            this.tsBtnRestore.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsGraphMain_MouseMove);
            this.tsBtnHrizontal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsGraphMain_MouseMove);
            this.tsBtnVertical.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsGraphMain_MouseMove);
            this.tsBtnShape.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsGraphMain_MouseMove);
            this.tsExportBmp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsGraphMain_MouseMove);

            //string path = Application.ExecutablePath;
            //int lastindex = path.LastIndexOf('\\');
            //path = path.Substring(0, lastindex + 1) + "\\Res\\magnify.cur";

            //装载放大光标
            this._inCur = CastCursor.LoadCursor("ChromatoTool.Res.magnify.cur");
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

            if (2 == e.button)
            {
                //右键弹出式菜单
                //this.menuContext.Show(c, p);
            }
            else if (1 == e.button)
            {
                if (General.OpenArrow)
                {
                    //this._bizSamGraph._bizArrow.ShowNormalArrow(e.x, e.y);
                }

                //开始放大缩小处理
                Console.Out.WriteLine("GraphExpandStartS");
                this._bizSamGraph._bizZoom.ZoomInStart(e.x, e.y);
            }
        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axGraphOcx_MouseMoveEvent(object sender, AxGRAPHOCXLib._DGraphOcxEvents_MouseMoveEvent e)
        {
            Cursor.Current = (null == this._inCur) ? Cursors.Arrow : this._inCur;

            Console.Out.WriteLine("axGraphOcx_MouseMoveEvent");
            if (2 == e.button)
            {
                return;
            }
            this._bizSamGraph._bizZoom.ZoomInRunning(e.x, e.y);
        }

        /// <summary>
        /// 鼠标提起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axGraphOcx_MouseUpEvent(object sender, AxGRAPHOCXLib._DGraphOcxEvents_MouseUpEvent e)
        {
            Console.Out.WriteLine("axGraphOcx_MouseUpEvent");
            if (2 == e.button)
            {
                return;
            }
            Console.Out.WriteLine("ExpandMouseUpS");
            this._bizSamGraph._bizZoom.ZoomInEnd(e.x, e.y);

            //刷新标签位置
            this._bizSamGraph._bizReserveTime.DrawLabel();
            this._bizSamGraph._bizBaseline.DrawBaseline();

        }

        /// <summary>
        /// 设置鼠标移动到图片菜单里面的形状
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsGraphMain_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Arrow;
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
                    this._bizSamGraph._bizArrow.MoveLeftOnePixel();

                    //刷新标签位置
                    this._bizSamGraph._bizReserveTime.DrawLabel();
                    this._bizSamGraph._bizBaseline.DrawBaseline();

                    break;

                case Keys.Right:
                    this._bizSamGraph._bizArrow.MoveRightOnePixel();

                    //刷新标签位置
                    this._bizSamGraph._bizReserveTime.DrawLabel();
                    this._bizSamGraph._bizBaseline.DrawBaseline();
                    break;

                case Keys.Up:
                    this._bizSamGraph._bizArrow.ZoomOutOneTime();

                    //刷新标签位置
                    this._bizSamGraph._bizReserveTime.DrawLabel();
                    this._bizSamGraph._bizBaseline.DrawBaseline();

                    break;

                case Keys.Down:
                    this._bizSamGraph._bizArrow.ZoomInOneTime();

                    //刷新标签位置
                    this._bizSamGraph._bizReserveTime.DrawLabel();
                    this._bizSamGraph._bizBaseline.DrawBaseline();

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
        private void miFullScale_Click(object sender, EventArgs e)
        {
            this._bizSamGraph.SetZoomState(ZoomStatus.normal);
            CastLog.Logger("", "", String.Format("Chromato {0}", this._bizSamGraph._bizZoom.GetExpandText()));

            //刷新标签位置
            this._bizSamGraph._bizReserveTime.DrawLabel();
            this._bizSamGraph._bizBaseline.DrawBaseline();
        }

        /// <summary>
        /// 水平放大模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miHorizontal_Click(object sender, EventArgs e)
        {
            this._bizSamGraph.SetZoomState(ZoomStatus.longitudianl);
            CastLog.Logger("", "", string.Format("Chromato {0}", this._bizSamGraph._bizZoom.GetExpandText()));
        }

        /// <summary>
        /// 垂直放大模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miVertical_Click(object sender, EventArgs e)
        {
            this._bizSamGraph.SetZoomState(ZoomStatus.transveral);
            CastLog.Logger("", "", string.Format("Chromato {0}", this._bizSamGraph._bizZoom.GetExpandText()));
        }

        /// <summary>
        /// 矩形放大模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miShape_Click(object sender, EventArgs e)
        {
            this._bizSamGraph.SetZoomState(ZoomStatus.square);
            CastLog.Logger("", "矩形放大模式",
                string.Format("Chromato {0}", this._bizSamGraph._bizZoom.GetExpandText()));
        }

        /// <summary>
        /// 导出当前图形为打印图形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miExport_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this._dtoPara.SampleID))
            {
                return;
            }
            this._bizSamGraph._bizExportBmp.NeedExportImage(this._dtoPara);
            CastLog.Logger("SampleGraphViewer", "miExport_Click",
                string.Format("导出当前图形为打印图形 {0}", this._dtoPara.SampleID));
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
            this._bizSamGraph.CreateLayer(lf, user, this.axGraphOcx, pipe);
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
        public bool LoadPlot(ParaDto dto)
        {
            if (null == dto || null == dto.PathData)
            {
                return false;
            }

            this._dtoPara = dto;

            if (String.IsNullOrEmpty(dto.PathData) || !this._bizSamGraph._isLayerCreated)
            {
                return false;
            }


            if (null == this._bizSamGraph._bizTransHis._plot.arr)
            {
                this._bizSamGraph._bizTransHis._plot.arr = new ArrayList();
            }


            DataSet ds = new DataSet();

            //从数据库提取数据
            OpenDbResult dbResult = this._bizAvg.OpenDataDb(dto.PathData, this._bizSamGraph._bizTransHis._plot.arr, ref ds);
            switch (dbResult)
            {
                case OpenDbResult.AlreadyOpened:
                    return false;
                case OpenDbResult.NotExist:
                    this._bizSamGraph._bizTransHis._plot.DataCount = 0;
                    return false;

                case OpenDbResult.Succeed:
                    this._bizSamGraph._bizArrow.UnvisibleArrow();
                    
                    //给控件传递数据
                    this._bizSamGraph._bizTransHis.LoadAvgPlot();

                    //更新谱图属性
                    this._bizSamGraph._bizResize.UpdateHisGraph();
                    this._bizSamGraph._bizZoom.SetFullGObj();
                    break;

                case OpenDbResult.NoData:
                    this._bizSamGraph._bizTransHis._plot.DataCount = 0;
                    return false;

            }

            return true;

        }

        /// <summary>
        /// 改变大小
        /// </summary>
        public void OcxResize()
        {
            if (this._bizSamGraph._isLayerCreated)
            {
                this._bizSamGraph._bizResize.GraphResize(0, 0,
                    this.Width, this.Height,
                    0, 0);
                this._bizSamGraph._bizArrow.UpdateArrow();

                //刷新标签位置
                this._bizSamGraph._bizReserveTime.DrawLabel();
                this._bizSamGraph._bizBaseline.DrawBaseline();
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
                this._bizSamGraph._bizReserveTime.ClearLabel();
                this._bizSamGraph._bizBaseline.ClearBaseline();
            }
            else
            {
                this._bizSamGraph._bizReserveTime.LoadLabel(ds);
                this._bizSamGraph._bizBaseline.LoadBaseline(ds);
                this._bizSamGraph._bizExportBmp.NeedExportImage(dto);
            }
        }

        #endregion



    }
}
