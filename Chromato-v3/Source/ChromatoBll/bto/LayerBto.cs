/*-----------------------------------------------------------------------------
//  FILE NAME       : LayerBto.cs
//  FUNCTION        : 控件数据层
//  AUTHOR          : 李锋(2009/02/17)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using ChromatoTool.ini;
using System.Collections;
using AxGRAPHOCXLib;
using ChromatoBll.ocx.item;
using ChromatoBll.ocx.biz;
using ChromatoTool.pipe;
using System.Drawing;
using ChromatoTool.util;

namespace ChromatoBll.bto
{
    /// <summary>
    /// 控件层
    /// </summary>
    public class LayerBto
    {

        #region 属性

        /// <summary>
        /// 调用用户
        /// </summary>
        public UserType nUser { get; set; }	// 1-OSC, 2-MNT, 3-ANL,4-FLT,5-WAVE,6-GROUP,7-UPPEAK,8-SHIFT

        /// <summary>
        /// 区域
        /// </summary>
        public AreaImp _area = null;

        /// <summary>
        /// 属性（未使用）
        /// </summary>
        public AttributImp _attr = null;
        
        /// <summary>
        /// X轴
        /// </summary>
        public AxisXImp _axsX = null;
        
        /// <summary>
        /// Y轴
        /// </summary>
        public AxisYImp _axsY = null;
        
        /// <summary>
        /// 网格
        /// </summary>
        public GridImp _grid = null;
        
        /// <summary>
        /// 标签
        /// </summary>
        public LabelImp _label = null;
        
        /// <summary>
        /// 直线
        /// </summary>
        public LineImp[] _line = null;//'拡大線 1:開始位置 2:終了位置, all use Honrizontal, Vertical
        
        /// <summary>
        /// 曲线
        /// </summary>
        public PlotImp _plot = null;
        
        /// <summary>
        /// 矩形
        /// </summary>
        public ShapeImp _shape = null;

        /// <summary>
        /// 曲线集合
        /// </summary>
        public ArrayList _arrPlot { get; set; }

        /// <summary>
        /// 图形空间对象
        /// </summary>
        public AxGraphOcx ocx { get; set; }


        #endregion 


        #region 图形逻辑变量

        /// <summary>
        /// 传输逻辑（真正实时，历史）
        /// </summary>
        public TransBaseBiz _bizTrans { get; set; }
        
        /// <summary>
        /// 模拟传输逻辑
        /// </summary>
        public TransSimuBiz _bizTransSimu { get; set; }

        /// <summary>
        /// 传输逻辑（图形比较）
        /// </summary>
        public TransCompareBiz _bizTransCompare { get; set; }

        /// <summary>
        /// 改变大小逻辑
        /// </summary>
        public ResizeBiz _bizResize { get; set; }
        
        /// <summary>
        /// 放大缩小逻辑
        /// </summary>
        public ZoomPlotBiz _bizZoom { get; set; }
        
        /// <summary>
        /// 十字光标逻辑
        /// </summary>
        public ArrowLineBiz _bizArrow { get; set; }

        /// <summary>
        /// 保留时间显示位置逻辑
        /// </summary>
        public ReserveTimeBiz _bizReserveTime { get; set; }

        /// <summary>
        /// 基线显示位置逻辑
        /// </summary>
        public BaseLineBiz _bizBaseline { get; set; }

        /// <summary>
        /// 导出位图逻辑
        /// </summary>
        public ExportBmpBiz _bizExportBmp { get; set; }

        /// <summary>
        /// 校正点逻辑
        /// </summary>
        public CorrectPointBiz _bizCorrectPoint { get; set; }

        /// <summary>
        /// 改变大小逻辑
        /// </summary>
        public CompareResizeBiz _bizCompareResize { get; set; }

        /// <summary>
        /// 手动水平基线逻辑
        /// </summary>
        public ManualBaseBiz _bizManualBaseline { get; set; }
        
        /// <summary>
        /// 手动垂直切割逻辑
        /// </summary>
        public VerticalSplitBiz _bizVerticalSplit { get; set; }

        /// <summary>
        /// 手动画负峰翻转基线逻辑
        /// </summary>
        public ManualNegativeBiz _bizManualNegativeBiz { get; set; }
        
        #endregion


        #region 构造

        /// <summary>
        /// 构造图形引擎
        /// </summary>
        /// <param name="lf"></param>
        /// <param name="user"></param>
        /// <param name="ocx"></param>
        /// <param name="pipe"></param>
        public LayerBto(ChannelID lf, UserType user, AxGraphOcx ocx, CastPipe pipe)
        {
            this._area = new AreaImp(ocx);
            this._attr = new AttributImp(ocx);
            this._axsX = new AxisXImp(ocx);
            this._axsY = new AxisYImp(ocx);
            this._grid = new GridImp(ocx);
            this._label = new LabelImp(ocx);
            this._plot = new PlotImp(ocx);
            this._shape = new ShapeImp(ocx);

            this._line = new LineImp[2];
            this._line[0] = new LineImp(ocx);
            this._line[1] = new LineImp(ocx);
            this._attr = new AttributImp(ocx);

            this.nUser = user;      //record the caller type
            this.ocx = ocx;

            this._area.id = 1;
            this._grid.id = 2;
            this._axsX.id = 3;
            this._axsY.id = 4;
            this._shape.id = 5;
            this._line[0].id = 6;
            this._line[1].id = ocx.AddItem(this._line[0].id); //add one line for zoom horizotal,vertical

            this._arrPlot = new ArrayList();
            this._arrPlot.Add(_plot);
            this._plot.id = 7;
            this._plot.Show = true;
            this._plot.DataCount = 0;

            this._line[0].Show = false;
            this._line[1].Show = false;
            this._shape.Show = true;
            this._grid.Show = true;


            if (UserType.osc == this.nUser)
            {
                this._attr.id = 9;
                this._label.id = 8;

                this._label.Show = false;
                this._attr.Show = false;
                this._plot.ShowMarker = false;
                this._plot.DatalineColor = CastColor.GetCustomColor(Color.Blue);
                this._grid.Show = false;
                this.ocx.BackWndColor = Color.White;

                this._axsX.LineColor = CastColor.GetCustomColor(Color.Gray);
                this._axsX.ScaleLineColor = CastColor.GetCustomColor(Color.Gray);
                this._axsX.ValueColor = CastColor.GetCustomColor(Color.Gray);

                this._axsY.LineColor = CastColor.GetCustomColor(Color.Gray);
                this._axsY.ScaleLineColor = CastColor.GetCustomColor(Color.Gray);
                this._axsY.ValueColor = CastColor.GetCustomColor(Color.Gray);
            }


            //创建ocx相关的各个逻辑对象
            switch (lf)
            {
                case ChannelID.A:
                    this._bizTrans = new TransRealBiz(pipe, ocx);
                    this._bizTransSimu = new TransSimuBiz(pipe, ocx);
                    break;

                case ChannelID.B:
                    this._bizTrans = new TransRealBiz(pipe, ocx);
                    this._bizTransSimu = new TransSimuBiz(pipe, ocx);
                    break;

                case ChannelID.C:
                    this._bizTrans = new TransRealBiz(pipe, ocx);
                    this._bizTransSimu = new TransSimuBiz(pipe, ocx);
                    break;

                case ChannelID.D:
                    this._bizTrans = new TransRealBiz(pipe, ocx);
                    this._bizTransSimu = new TransSimuBiz(pipe, ocx);
                    break;

                case ChannelID.off:
                    this._bizTrans = new TransHisBiz(pipe, ocx);
                    this._bizManualBaseline = new ManualBaseBiz();
                    this._bizVerticalSplit = new VerticalSplitBiz();
                    this._bizManualNegativeBiz = new ManualNegativeBiz();
                    break;

                case ChannelID.sample:
                    this._bizTrans = new TransHisBiz(pipe, ocx);
                    break;

                case ChannelID.compare:
                    this._bizTransCompare = new TransCompareBiz(pipe, ocx, this._arrPlot);
                    this._bizCompareResize = new CompareResizeBiz(user);
                    this._bizTransCompare._axsX = this._axsX;
                    this._bizTransCompare._axsY = this._axsY;
                    break;

                case ChannelID.correct:
                    this._bizCorrectPoint = new CorrectPointBiz(pipe, ocx);
                    break;
            }

            this._bizResize = new ResizeBiz(user);
            this._bizZoom = new ZoomPlotBiz(user);
            this._bizArrow = new ArrowLineBiz();
            this._bizReserveTime = new ReserveTimeBiz();
            this._bizBaseline = new BaseLineBiz();
            this._bizExportBmp = new ExportBmpBiz();

            //把所需要的模块配置到控件实际传输逻辑对象中
            if (null != this._bizTrans)
            {
                this._bizTrans._area = this._area;
                this._bizTrans._axsX = this._axsX;
                this._bizTrans._axsY = this._axsY;
                this._bizTrans._plot = this._plot;
            }

            //把所需要的模块配置到控件模拟传输逻辑对象中
            if (null != this._bizTransSimu)
            {
                this._bizTransSimu._area = this._area;
                this._bizTransSimu._axsX = this._axsX;
                this._bizTransSimu._axsY = this._axsY;
                this._bizTransSimu._plot = this._plot;
            }

            //把所需要的模块配置到控件大小改变逻辑对象中
            if (null != this._bizResize)
            {
                this._bizResize._area = this._area;
                this._bizResize._axsX = this._axsX;
                this._bizResize._axsY = this._axsY;
                this._bizResize._grid = this._grid;
                this._bizResize._plot = this._plot;
            }

            //把所需要的模块配置到控件大小改变逻辑对象中
            if (null != this._bizCompareResize)
            {
                this._bizCompareResize._area = this._area;
                this._bizCompareResize._axsX = this._axsX;
                this._bizCompareResize._axsY = this._axsY;
                this._bizCompareResize._grid = this._grid;
            }

            //把所需要的模块配置到控件缩放逻辑对象中
            if (null != this._bizZoom)
            {
                this._bizZoom._area = this._area;
                this._bizZoom._axsX = this._axsX;
                this._bizZoom._axsY = this._axsY;
                this._bizZoom._zoomLine[0] = this._line[0];
                this._bizZoom._zoomLine[1] = this._line[1];
                this._bizZoom._zoomShape = this._shape;
            }

            //把所需要的模块配置到控件十字光标逻辑对象中
            if (null != this._bizArrow)
            {
                this._bizArrow._area = this._area;
                this._bizArrow._axsX = this._axsX;
                this._bizArrow._axsY = this._axsY;
                this._bizArrow._arrowLine[0] = this._line[0];
                this._bizArrow._arrowLine[1] = this._line[1];
                this._bizArrow._plot = this._plot;
            }

            //把所需要的模块配置到控件保留时间逻辑对象中
            if (null != this._bizReserveTime)
            {
                this._bizReserveTime._area = this._area;
                this._bizReserveTime._axsX = this._axsX;
                this._bizReserveTime._axsY = this._axsY;
                this._bizReserveTime._label = this._label;
                this._bizReserveTime._plot = this._plot;
                this._bizReserveTime._ocx = this.ocx;
                this._bizReserveTime.InitLabelArray();
            }

            //把所需要的模块配置到控件保留时间逻辑对象中
            if (null != this._bizBaseline)
            {
                this._bizBaseline._area = this._area;
                this._bizBaseline._axsX = this._axsX;
                this._bizBaseline._axsY = this._axsY;
                this._bizBaseline._line = this._line[0];
                this._bizBaseline._plot = this._plot;
                this._bizBaseline._ocx = this.ocx;
                this._bizBaseline.InitBaselineArray();
            }

            //把所需要的模块配置到控件到处逻辑对象中
            if (null != this._bizExportBmp)
            {
                this._bizExportBmp._ocx = this.ocx;
            }

            //把所需要的模块配置到控件校正点传输逻辑对象中
            if (null != this._bizCorrectPoint)
            {
                this._bizCorrectPoint._area = this._area;
                this._bizCorrectPoint._axsX = this._axsX;
                this._bizCorrectPoint._axsY = this._axsY;
                this._bizCorrectPoint._plot = this._plot;
            }

            //把所需要的模块配置到控件手动水平基线逻辑对象中
            if (null != this._bizManualBaseline)
            {
                this._bizManualBaseline._area = this._area;
                this._bizManualBaseline._axsX = this._axsX;
                this._bizManualBaseline._axsY = this._axsY;
                this._bizManualBaseline._baseLine = new LineImp(ocx);
                this._bizManualBaseline._baseLine.id = ocx.AddItem(this._line[0].id);
            }

            //把所需要的模块配置到控件手动垂直切割逻辑对象中
            if (null != this._bizVerticalSplit)
            {
                this._bizVerticalSplit._area = this._area;
                this._bizVerticalSplit._axsX = this._axsX;
                this._bizVerticalSplit._axsY = this._axsY;
                this._bizVerticalSplit._plot = this._plot;
            }

            //把所需要的模块配置到控件手动画负峰翻转基线逻辑对象中
            if (null != this._bizManualNegativeBiz)
            {
                this._bizManualNegativeBiz._area = this._area;
                this._bizManualNegativeBiz._axsX = this._axsX;
                this._bizManualNegativeBiz._axsY = this._axsY;
                this._bizManualNegativeBiz._negaBaseLine = new LineImp(ocx);
                this._bizManualNegativeBiz._negaBaseLine.id = ocx.AddItem(this._line[0].id);
            }
        }

        #endregion


        #region 未使用

        //public bool bPlot { get; set; }	    // Plotあるか
        //public bool bDisp { get; set; }	    // 表示しているか

        //public short  nValueLine;	                //used in TCM-ANL only
        //public short[] nWaveLine = new short[2];	//used in SGR-WAVE only
        //public short  nEosLine { get; set; }	    //SGR-GROUP夋柺EOS梡偺慄
        //public short[] nEditLine = new short[2];	//SGR-GROUP, SHIFT, UPPEAK use
        //public short[] nSctLine = new short[4];	    //SGR-AbsGR画面のSect線

        //public AxisMoveStatus nMode { get; set; }	//堏摦儌乕僪 1-捠忢 2-堏摦懸偪 3-堏摦
        //public int		nMoveStY { get; set; }	//堏摦奐巒揰Y
        //public int		nMoveStYM { get; set; }	//堏摦奐巒帪偺儅僂僗埵抲
        //public double	dRelPos { get; set; }	//僌儔僼僄儕傾偵懳偡傞憡懳埵抲(廲埵抲)


        #endregion

    }
}
