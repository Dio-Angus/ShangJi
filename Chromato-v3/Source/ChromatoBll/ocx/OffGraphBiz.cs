/*-----------------------------------------------------------------------------
//  FILE NAME       : OffGraphBiz.cs
//  FUNCTION        : 用于谱图分析的图形逻辑
//  AUTHOR          : 李锋(2009/02/17)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using AxGRAPHOCXLib;
using ChromatoTool.ini;
using ChromatoBll.ocx.item;
using ChromatoBll.ocx.biz;
using ChromatoTool.pipe;
using ChromatoBll.bto;

namespace ChromatoBll.ocx
{
    /// <summary>
    /// 用于谱图分析的图形逻辑
    /// </summary>
    public sealed class OffGraphBiz
    {

        #region 图形引擎变量

        /// <summary>
        /// 离线显示层
        /// </summary>
        private LayerBto dtoHisLayer { get; set; }

        /// <summary>
        /// 在线离线标志
        /// </summary>
        public ChannelID _currentLF { get; set; }

        /// <summary>
        /// 显示引擎创建标志
        /// </summary>
        public bool _isLayerCreated { get; set; }

        #endregion


        #region 属性变量

        /// <summary>
        /// 区域
        /// </summary>
        public AreaImp _area
        {
            get { return dtoHisLayer._area; }
            set { ; }
        }

        /// <summary>
        /// 属性
        /// </summary>
        public AttributImp _attr
        {
            get { return dtoHisLayer._attr; }
            set { ; }
        }

        /// <summary>
        /// X轴
        /// </summary>
        public AxisXImp _axsX
        {
            get { return dtoHisLayer._axsX; }
            set { ; }
        }

        /// <summary>
        /// Y轴
        /// </summary>
        public AxisYImp _axsY
        {
            get { return dtoHisLayer._axsY; }
            set { ; }
        }

        /// <summary>
        /// 网格
        /// </summary>
        public GridImp _grid
        {
            get { return dtoHisLayer._grid; }
            set { ; }
        }

        /// <summary>
        /// 标签
        /// </summary>
        public LabelImp _label
        {
            get { return dtoHisLayer._label; }
            set { ; }
        }

        /// <summary>
        /// 直线
        /// </summary>
        public LineImp _line
        {
            get { return dtoHisLayer._line[0]; }
            set { ; }
        }

        /// <summary>
        /// 曲线
        /// </summary>
        public PlotImp _plot
        {
            get { return dtoHisLayer._plot; }
            set { ; }
        }

        /// <summary>
        /// 矩形
        /// </summary>
        public ShapeImp _shape
        {
            get { return dtoHisLayer._shape; }
            set { ; }
        }

        #endregion


        #region 逻辑变量

        /// <summary>
        /// 离线传输逻辑
        /// </summary>
        public TransHisBiz _bizTransHis
        {
            get { return (TransHisBiz)dtoHisLayer._bizTrans; }
            set { ; }
        }

        /// <summary>
        /// 控件大小改变逻辑
        /// </summary>
        public ResizeBiz _bizResize
        {
            get { return dtoHisLayer._bizResize; }
            set { ; }
        }

        /// <summary>
        /// 图形放大缩小逻辑
        /// </summary>
        public ZoomPlotBiz _bizZoom
        {
            get { return dtoHisLayer._bizZoom; }
            set { ; }
        }

        /// <summary>
        /// 十字光标逻辑
        /// </summary>
        public ArrowLineBiz _bizArrow
        {
            get { return dtoHisLayer._bizArrow; }
            set { ; }
        }

        /// <summary>
        /// 保留时间逻辑
        /// </summary>
        public ReserveTimeBiz _bizReserveTime
        {
            get { return dtoHisLayer._bizReserveTime; }
            set { ; }
        }

        /// <summary>
        /// 基线逻辑
        /// </summary>
        public BaseLineBiz _bizBaseline
        {
            get { return dtoHisLayer._bizBaseline; }
            set { ; }
        }

        /// <summary>
        /// 手动水平基线逻辑
        /// </summary>
        public ManualBaseBiz _bizManualBaseline
        {
            get { return dtoHisLayer._bizManualBaseline; }
            set { ; }
        }

        /// <summary>
        /// 手动垂直切割逻辑
        /// </summary>
        public VerticalSplitBiz _bizVerticalSplit
        {
            get { return dtoHisLayer._bizVerticalSplit; }
            set { ; }
        }

        /// <summary>
        /// 手动画负峰翻转基线逻辑
        /// </summary>
        public ManualNegativeBiz _bizManualNegativeBiz
        {
            get { return dtoHisLayer._bizManualNegativeBiz; }
            set { ; }
        }

        #endregion


        #region 构造

        /// <summary>
        /// 创建唯一对象
        /// </summary>
        static readonly OffGraphBiz instance = new OffGraphBiz();

        /// <summary>
        /// 取得唯一对象
        /// </summary>
        public static OffGraphBiz Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// 构造
        /// </summary>
        public OffGraphBiz()
        {

        }

        /// <summary>
        /// 创建显示层
        /// </summary>
        /// <param name="lf"></param>
        /// <param name="user"></param>
        /// <param name="ocx"></param>
        /// <param name="pipe"></param>
        public void CreateLayer(ChannelID lf, UserType user, AxGraphOcx ocx, CastPipe pipe)
        {
            switch (lf)
            {
                case ChannelID.off:
                    dtoHisLayer = new LayerBto(lf, user, ocx, pipe);
                    this._isLayerCreated = true;
                    break;
            }
        }

        #endregion

        
        #region 析构

        /// <summary>
        /// 析构
        /// </summary>
        ~OffGraphBiz()
        {
            if (null != this.dtoHisLayer && null != this.dtoHisLayer._bizTransSimu)
            {
                this.dtoHisLayer._bizTransSimu.CloseSimuThread();
            }
            
        }

        #endregion


        #region 改变背景色

        /// <summary>
        /// 取得背景色
        /// </summary>
        /// <returns></returns>
        public Color GetBkColor()
        {
            return this.dtoHisLayer.ocx.BackWndColor;
        }

        /// <summary>
        /// 设置背景色
        /// </summary>
        /// <param name="bkColor"></param>
        public void SetBkColor(Color bkColor)
        {
            this.dtoHisLayer.ocx.BackWndColor = bkColor;
        }
        #endregion


        #region 图形缩放

        /// <summary>
        /// 设置放大缩小状态
        /// </summary>
        /// <param name="zs"></param>
        public void SetZoomState(ZoomStatus zs)
        {
            this._bizZoom.SetZoomState(zs);
        }

        /// <summary>
        /// 是否是非放大缩小状态
        /// </summary>
        /// <returns></returns>
        public bool IsNormalState()
        {
            return this._bizZoom.IsNormalState();
        }

        #endregion


        #region 设置动态曲线

        /// <summary>
        /// 根据Online.showCount重新设置曲线
        /// </summary>
        /// <param name="count"></param>
        public void ResetPlot(int count)
        {
            this._bizTransHis.ResetPlot(count);
            this._bizResize.UpdateOffGraph();
            this._bizZoom.SetFullGObj();
        }

        #endregion


        #region 取得各种类型的ID

        /// <summary>
        /// 取得曲线ID
        /// </summary>
        /// <param name="count"></param>
        /// <param name="sID"></param>
        public void GetPlotID(ref int count, ref string[] sID)
        {

            sID = new String[this.dtoHisLayer._arrPlot.Count];

            for (int i = 0; i < this.dtoHisLayer._arrPlot.Count; i++)
            {
                sID[i] = ((PlotImp)this.dtoHisLayer._arrPlot[i]).id.ToString();
            }
        }

        /// <summary>
        /// 取得Y轴ID
        /// </summary>
        /// <returns></returns>
        public String GetAxisYID()
        {
            return this.dtoHisLayer._axsY.id.ToString();
        }

        /// <summary>
        /// 取得X轴ID
        /// </summary>
        /// <returns></returns>
        public String GetAxisXID()
        {
            return this.dtoHisLayer._axsX.id.ToString();
        }

        /// <summary>
        /// 取得区域ID
        /// </summary>
        /// <returns></returns>
        public String GetAreaID()
        {
            return this.dtoHisLayer._area.id.ToString();
        }

        /// <summary>
        /// 取得网格ID
        /// </summary>
        /// <returns></returns>
        public String GetGridID()
        {
            return this.dtoHisLayer._grid.id.ToString();
        }

        /// <summary>
        /// 取得矩形ID
        /// </summary>
        /// <returns></returns>
        public String GetShapeID()
        {
            return this.dtoHisLayer._shape.id.ToString();
        }

        /// <summary>
        /// 取得直线ID
        /// </summary>
        /// <returns></returns>
        public String GetLineID()
        {
            return this.dtoHisLayer._line[0].id.ToString();
        }

        /// <summary>
        /// 取得标签ID
        /// </summary>
        /// <returns></returns>
        public String GetLabelID()
        {
            return this.dtoHisLayer._label.id.ToString();
        }

        #endregion


        #region 增加曲线

        /// <summary>
        /// 增加曲线
        /// </summary>
        /// <returns></returns>
        public int AddPlot()
        {

            //int nArea = dtoLayer[nGraph].nArea;
            //dtoLayer[nGraph].bPlot = true;

            //if (UserType.wave <= dtoLayer[0].nUser && UserType.toyota >= dtoLayer[0].nUser)
            //{
            //if (nGraph >= 1 && !_dtoGraph[nGraph].bDisp &&
            //    _dtoGraph[0].nUser >= UserType.relativeGr && _dtoGraph[0].nUser <= UserType.toyota)
            //{
            //    _dtoGraph[nGraph].bDisp = true;

            //    this._bizArea.Right(nGraph, this._bizArea.Right(0)); //墶埵抲寛掕
            //    this._bizArea.Left(nGraph, this._bizArea.Left(0));
            //    this._bizAxisY.AxsYX(nGraph, this._bizGrid.Right(0));

            //    this._bizAxisY.AxsYY(nGraph, this._bizAxisY.AxsYY(0)); //230);	 //廲埵抲愝掕
            //    this._bizAxisY.AxsYLength(nGraph, this._bizAxisY.AxsYLength(0) / 3); //gGcAppProFile.GetProfileInt(mPrntForm.FormSect, "Y2Len" + CStr(Graph), AxsYLength(0) / 4)
            //    this._bizArea.Top(nGraph, 0);
            //    this._bizArea.Bottom(nGraph, this._bizAxisY.AxsYY(nGraph));
            //    this._bizArea.Top(nGraph, this._bizAxisY.AxsYY(nGraph) + this._bizAxisY.AxsYLength(nGraph));
            //    this._bizAxisY.AxsYScaleCount(nGraph, 5);
            //    this._bizAxisY.AxsYFloatFigure(nGraph, 2);     //倄幉偺愝掕                   
            //    this._bizAxisY.AxsYShow(nGraph, true);	//Y幉栚惙彫悢揰埲壓寘悢愝掕
            //    //SetSubGraphSizeS(nGraph, inum, 2);
            //    //Call CompressArea
            //}
            //}
            //dtoLayer[nGraph].Plot[inum - 1].id = ocx.AddItem(dtoLayer[iOriGraph].Plot[0].id);

            //bind plot to Area
            PlotImp impPlot = new PlotImp(dtoHisLayer.ocx);
            impPlot.id = dtoHisLayer.ocx.AddItem(this._plot.id);
            impPlot.Area = this._plot.Area;
            impPlot.Show = true;
            dtoHisLayer._arrPlot.Add(impPlot);

            //this._bizResize.ChangeSubObject();
            return impPlot.id;
        }

        /// <summary>
        /// 设置当前操作的曲线
        /// </summary>
        /// <param name="id"></param>
        public void UpdateCurrentPlot(short id)
        {
            if (null == this.dtoHisLayer._bizTransSimu)
            {
                return;
            }

            PlotImp tempPlot = null;
            for (int i = 0; i < this.dtoHisLayer._arrPlot.Count; i++)
            {
                tempPlot = (PlotImp)this.dtoHisLayer._arrPlot[i];
                if (tempPlot.id == id)
                {
                    this._plot = tempPlot;
                    this.dtoHisLayer._bizTransSimu._plot = tempPlot;
                    this._bizArrow._plot = tempPlot;
                    break;
                }
            }
        }

        #endregion


        #region 第二根Y轴的移动

        bool IsDblClickY2Axis(int iGNo, int fX, int fY)	//'Y2幉偺僋儕僢僋敾掕
        {
            //if (false == dtoLayer[iGNo].bPlot) return false;

            //if ((long)AxisScale.yUpLeft == this._axsY.Align(iGNo) ||
            //    (long)AxisScale.yDownLeft == this._axsY.Align(iGNo))
            //{
            //    if (fX > (this._axsY.X(iGNo) - 20) && fX < this._axsY.X(iGNo))   //minus 20 pixels
            //        if (fY < this._axsY.Y(iGNo) && fY > (this._axsY.Y(iGNo) + this._axsY.Length(iGNo)))
            //            return true;
            //}
            //else
            //{
            //    if (fX > this._axsY.X(iGNo) && fX < (this._axsY.X(iGNo) + 20))  //add 20 pixels
            //        if (fY < this._axsY.Y(iGNo) && fY > (this._axsY.Y(iGNo) + this._axsY.Length(iGNo)))
            //            return true;
            //}
            return false;
        }

        void Y2ModeChg(int iGNo, AxisMoveStatus Mode) //Y2幉偺儌乕僪曄峏
        {
            //if (AxisMoveStatus.normal == dtoLayer[iGNo].nMode)
            //{
            //this._axsY.id = iGNo;
            //this._axsY.LabelFontBold = true;
            //this._axsY.LabelFontItalic = true;
            //this._axsY.ScaleLineColor = Color.Red.ToArgb();
            //this._axsY.ValueColor = Color.Red.ToArgb();
            //this._axsY.LineColor = Color.Red.ToArgb();
            //this._axsY.id = 0;
            //dtoLayer[iGNo].nMode = Mode;
            //}
        }

        void Y2MoveStart(int iGNo, int lY) //Y2幉偺堏摦奐巒
        {
            //if (AxisMoveStatus.moveWait == dtoLayer[iGNo].nMode)
            //{
            //dtoGraph[iGNo].nMoveStY = this._axsY.Y(iGNo);
            //dtoGraph[iGNo].nMoveStYM = lY;
            //dtoGraph[iGNo].nMode = AxisMoveStatus.moving;
            //}
        }

        void MoveY2(int iGNo, int lY, int lX) //Y2幉堏摦
        {
            //if (AxisMoveStatus.moving == _dtoGraph[iGNo].nMode)
            //{	//Y幉偺忋尷抣丆壓尷抣娫傪堏摦偡傞

            //    if (_dtoGraph[iGNo].nMoveStY + (lY - _dtoGraph[iGNo].nMoveStYM) + this._bizAxisY.AxsYLength(iGNo) < this._bizArea.Top)
            //        lY = this._bizArea.Top - (_dtoGraph[iGNo].nMoveStY - _dtoGraph[iGNo].nMoveStYM + this._bizAxisY.AxsYLength(iGNo));
            //    else
            //    {
            //        if (_dtoGraph[iGNo].nMoveStY + (lY - _dtoGraph[iGNo].nMoveStYM) > this._bizArea.Bottom)
            //            lY = this._bizArea.Bottom - (_dtoGraph[iGNo].nMoveStY - _dtoGraph[iGNo].nMoveStYM);
            //    }

            //    this._bizAxisY.AxsYY(iGNo, _dtoGraph[iGNo].nMoveStY + (lY - _dtoGraph[iGNo].nMoveStYM));
            //    this._bizArea.Top(iGNo, 0);
            //    this._bizArea.Bottom(iGNo, this._bizAxisY.AxsYY(iGNo));
            //    this._bizArea.Top(iGNo, this._bizAxisY.AxsYY(iGNo) + this._bizAxisY.AxsYLength(iGNo));
            //    _dtoGraph[iGNo].dRelPos = this._bizAxisY.AxsYY(iGNo) / (this._bizArea.Bottom(0) - this._bizArea.Top);
            //    this._bizAxisY.AxsYX(iGNo, lX);
            //}
        }

        void Y2MoveEnd(int iGNo)	//Y2幉偺堏摦廔椆
        {
            //if (UserType.wave <= dtoLayer[0].nUser && UserType.toyota >= dtoLayer[0].nUser)
            //{
            //    if (AxisMoveStatus.moving == dtoLayer[iGNo].nMode)
            //    {
            //        this._axsY.LabelFontBold(iGNo, this._axsY.LabelFontBold(0));
            //        this._axsY.LabelFontItalic(iGNo, this._axsY.LabelFontItalic(0));
            //        dtoGraph[iGNo].nMode = AxisMoveStatus.normal;
            //        this._axsY.ScaleLineColor(iGNo, this._axsY.ScaleLineColor(0));
            //        this._axsY.ValueColor(iGNo, this._axsY.ValueColor(0));
            //        this._axsY.LineColor(iGNo, this._axsY.LineColor(0));

            //        if (this._axsY.X(iGNo) > (this._axsX.X + this._axsX.Length / 2))
            //        {
            //            this._axsY.X(iGNo, this._area.Right);
            //            this._axsY.Align(iGNo, (int)AxisScale.yUpRight);
            //        }
            //        else
            //        {
            //            this._axsY.X(iGNo, this._area.Left);
            //            this._axsY.Align(iGNo, (int)AxisScale.yUpLeft);
            //        }
            //    }
            //}
        }


        #endregion


        #region Test Shape

        void ChangeMouseMoveProperty(int nFlag, int nButton, int nShift, Int32 x, Int32 y)
        {
            Int32 nWidth;
            Int32 nHeight;


            nWidth = x - this._shape.X;
            if (nWidth <= 0)
            {
                this._shape.AdjustX = 0;
                nWidth = 0 - nWidth;
            }
            else
                this._shape.AdjustX = 1;
            this._shape.Width = nWidth;

            nHeight = y - this._shape.Y;
            if (nHeight <= 0)
            {
                this._shape.AdjustY = 0;
                nHeight = 0 - nHeight;
            }
            else
                this._shape.AdjustY = 1;
            this._shape.Height = nHeight;

        }
        #endregion


        #region Attri移动

        //bool IsDblClickAttri(int iGNo, int fX, int fY, sENV_GRAPH_ATTRI* pEnvAttr)	//Attri偺僋儕僢僋敾掕
        //{
        //    int nId = mtSub[iGNo].nAttri;
        //    int i= 0;

        //    if( false == AttributeShow( iGNo )) return false;
        //    if( fX < AttributeX( iGNo ) || fX > AttributeRight( iGNo ) ||
        //        fY < AttributeY( iGNo ) || fY > AttributeBottom(iGNo)   )
        //        return false;

        //    COLORREF nColor = 0;
        //    for( i = 0; i<10; i++)
        //    {
        //        if( fX > (AttributeX(iGNo) + AttributeRight(iGNo))/2 &&
        //            fX < AttributeRight(iGNo) &&
        //            fY > (AttributeY(iGNo) + i * (AttributeBottom(iGNo) - AttributeY(iGNo)) /10 ) && 
        //            fY < (AttributeY(iGNo) + (i+1)*(AttributeBottom(iGNo) - AttributeY(iGNo)) /10 ) )
        //        {
        //            nColor = AttributeLabelColor(iGNo, i);
        //            CColorDialog dlg(nColor/*, CC_FULLOPEN*/);
        //            if(IDOK == dlg.DoModal())
        //            {
        //                nColor = dlg.GetColor();
        //                pEnvAttr->Chnl[i].Color = nColor;
        //                AttributeLabelColor(iGNo, i, nColor);
        //            }
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        void AttrModeChg(int iGNo, int Mode) //Attr偺儌乕僪曄峏
        {
            //_attr.FontBold(iGNo, true);
            //_attr.FontItalic(iGNo, true);
            //_attr.FontSize(iGNo, 7);
            //_attr.Transparent(iGNo, false);
            //_attr.BackColor(iGNo, Color.Green.ToArgb());
            //_attr.ForeColor(iGNo, Color.Red.ToArgb());
        }
        void AttrMoveStart(int iGNo, int lY, int lX) //Attr偺堏摦奐巒
        {
            //dtoLayer[iGNo].Attri.startX = _attr.X(iGNo);
            //dtoLayer[iGNo].Attri.startY = _attr.Y(iGNo);
            //dtoLayer[iGNo].Attri.startRight = _attr.Right(iGNo);
            //dtoLayer[iGNo].Attri.startBottom = _attr.Bottom(iGNo);

            //dtoLayer[iGNo].Attri.mouseX = lX;
            //dtoLayer[iGNo].Attri.mouseY = lY;
        }

        void MoveAttr(int iGNo, int lY, int lX) //Attr堏摦
        {
            //Attr偺忋尷抣丆壓尷抣娫傪堏摦偡傞
            //int nNowX = _dtoGraph[iGNo].nAttrStX + (lX-_dtoGraph[iGNo].nAttrMouseX);
            //int nNowY = _dtoGraph[iGNo].nAttrStY + (lY-_dtoGraph[iGNo].nAttrMouseY);
            //int nNowRight  = _dtoGraph[iGNo].nAttrStRight + (lX-_dtoGraph[iGNo].nAttrMouseX);
            //int nNowBottom = _dtoGraph[iGNo].nAttrStBottom + (lY-_dtoGraph[iGNo].nAttrMouseY);

            //if (nNowX >= this._bizArea.Left(iGNo) && nNowX <= this._bizArea.Right(iGNo) &&
            //    nNowY >= this._bizArea.Top(iGNo) && nNowY <= this._bizArea.Bottom(iGNo) &&
            //    nNowRight >= this._bizArea.Left(iGNo) && nNowRight <= this._bizArea.Right(iGNo) &&
            //    nNowBottom >= this._bizArea.Top(iGNo) && nNowBottom <= this._bizArea.Bottom(iGNo))
            //{
            //    _bizAttribute.X(iGNo, nNowX);
            //    _bizAttribute.Y(iGNo, nNowY);
            //}
        }

        void AttrMoveEnd(int iGNo)	//Attr偺堏摦廔椆
        {
            _attr.FontBold = false;
            _attr.FontItalic = false;
            _attr.FontSize = 8;
            _attr.Transparent = true;
            _attr.BackColor = this._grid.BrushColor;//  RGB(0, 255, 0));
            _attr.ForeColor = Color.Red.ToArgb();
        }

        #endregion

    }
}
