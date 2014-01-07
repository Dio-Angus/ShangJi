/*-----------------------------------------------------------------------------
//  FILE NAME       : ZoomPlotBiz.cs
//  FUNCTION        : 2D控件内部的按比例缩放
//  AUTHOR          : 李锋(2009/03/01)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.dto;
using ChromatoTool.ini;
using ChromatoBll.ocx.item;
using System.Drawing;
using ChromatoTool.util;

namespace ChromatoBll.ocx.biz
{
    /// <summary>
    /// 2D控件内部的按比例缩放
    /// </summary>
    public class ZoomPlotBiz
    {

        #region 变量

        /// <summary>
        /// 区域item
        /// </summary>
        public AreaImp _area { get; set; }
        
        /// <summary>
        /// X轴item
        /// </summary>
        public AxisXImp _axsX { get; set; }
        
        /// <summary>
        /// Y轴item
        /// </summary>
        public AxisYImp _axsY { get; set; }

        /// <summary>
        /// 矩形item
        /// </summary>
        public ShapeImp _zoomShape { get; set; }
        
        /// <summary>
        /// 直线item
        /// </summary>
        public LineImp[] _zoomLine { get; set; }

        /// <summary>
        /// 缩放dto
        /// </summary>
        private ZoomDto _dtoZoom { get; set; }

        /// <summary>
        /// 用户对象
        /// </summary>
        private UserType _ut { get; set; }

        /// <summary>
        /// 放大缩小种类
        /// </summary>
        private ZoomStatus _expandState { get; set; }

        /// <summary>
        /// 是否开始放大缩小处理
        /// </summary>
        private Boolean _isStartZoom = false;

        //ZoomIn or ZoomOut, restore
        RangeDto mtExRange = new RangeDto();
        RangeDto mtExRange1 = new RangeDto();  //SGR-Wave僌儔僼堏摦帪偺儗儞僕婰壇
        RangeDto mtOscRange = new RangeDto();

        #endregion
        

        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public ZoomPlotBiz(UserType user)
        {
            this._expandState = ZoomStatus.square;
            this._dtoZoom = new ZoomDto();
            this._zoomLine = new LineImp[2];
            this._ut = user;
        }

        #endregion


        #region 方法

        /// <summary>
        /// 是否是非放大缩小状态
        /// </summary>
        /// <returns></returns>
        public bool IsNormalState()
        {
            return (this._expandState == ZoomStatus.normal) ? true : false;
        }


        /// <summary>
        /// 设置放大缩小状态
        /// </summary>
        /// <param name="zs"></param>
        public void SetZoomState(ZoomStatus zs)
        {
            if (zs == ZoomStatus.normal)
            {
                this.FullScaleS();
            }
            else
            {
                this._expandState = zs;
            }
        }

        #endregion


        #region 鼠标控制图形的放大和缩小

        /// <summary>
        /// 保存变化前的区域
        /// </summary>
        public void SetFullGObj()
        {
            _dtoZoom.fTopVY = this._area.TopValue;
            _dtoZoom.fBottomVY = this._area.BottomValue;
            _dtoZoom.fLeftVX = this._area.LeftValue;
            _dtoZoom.fRightVX = this._area.RightValue;
        }

        /// <summary>
        /// 恢复全景模式
        /// </summary>
        private void FullScaleS()
        {
            //Area值
            this._area.LeftValue = _dtoZoom.fLeftVX;
            this._area.RightValue = _dtoZoom.fRightVX;
            this._area.TopValue = _dtoZoom.fTopVY;
            this._area.BottomValue = _dtoZoom.fBottomVY;

            //Y0值
            this._axsY.StartValue = _dtoZoom.fBottomVY;   //Y幉巒揰抣愝掕
            this._axsY.EndValue = _dtoZoom.fTopVY;   //Y幉廔揰抣愝掕

            //X幉傪愝掕
            this._axsX.StartValue = _dtoZoom.fLeftVX;   //X幉巒揰抣愝掕
            this._axsX.EndValue = _dtoZoom.fRightVX;   //X幉廔揰抣愝掕

            if (UserType.downPeak == this._ut || UserType.relativeGr == this._ut ||
                UserType.absoluteGr == this._ut)
            {
                //for (int i = 1; i < 3; i++)
                //    if (_dtoGraph[i].bDisp)
                //    {
                //        this._bizArea.LeftValue(i, _dtoGraph[i].fLeftVX);
                //        this._bizArea.RightValue(i, _dtoGraph[i].fRightVX);
                //        this._bizPlot.Show(i, 0, true);
                //        this._bizAxisY.AxsYShow(i, true);
                //    }
            }

            _expandState = ZoomStatus.square;

        }

        /// <summary>
        /// 设置起点
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="iXpnt"></param>
        /// <param name="iYpnt"></param>
        private void SetStartPosS(Int32 X, Int32 Y, ref int iXpnt, ref int iYpnt)
        {
            Single fTmpVal = 0;
            this.GetGraphCoordinateF(X, Y, ref iXpnt, ref iYpnt);

            //奐巒揰嵗昗抣庢摼  X嵗昗
            fTmpVal = Convert.ToSingle(iXpnt - this._area.Left) / Convert.ToSingle(this._area.Right - this._area.Left);
            mtExRange.StartValX = fTmpVal * (this._area.RightValue - this._area.LeftValue) + this._area.LeftValue;

            //Y嵗昗
            fTmpVal = Convert.ToSingle(iYpnt - this._area.Top) / Convert.ToSingle(this._area.Top - this._area.Bottom);
            mtExRange.StartValY = (1 + fTmpVal) * (this._area.TopValue - this._area.BottomValue) + this._area.BottomValue;

            mtExRange.StartPosX = iXpnt;
            mtExRange.StartPosY = iYpnt;
        }

        /// <summary>
        /// 开始放大缩小的处理
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void ZoomInStart(Int32 X, Int32 Y)
        {
            int i;
            int iXpnt = 0;	//倃嵗昗
            int iYpnt = 0;	//倄嵗昗

            if (this._expandState == ZoomStatus.normal)
            {
                return;
            }

            this.SetStartPosS(X, Y, ref iXpnt, ref iYpnt);	//奼戝張棟奐巒

            if (this._ut >= UserType.wave && this._ut <= UserType.toyota)
            {
                // ShapeBorderColor(0, mlGrfProp.ZoomColor);
                // for( i = 1; i<3; i++ )
                //     cbLineColor(i, mlGrfProp.ZoomColor);
            }

            switch (_expandState)
            {
                case ZoomStatus.square:		//矩形
                    this._zoomShape.X = iXpnt;
                    this._zoomShape.Y = iYpnt;
                    this._zoomShape.Height = 0;
                    this._zoomShape.Width = 0;
                    this._zoomShape.Show = true;
                    this._zoomShape.Transparent = true;
                    break;
                case ZoomStatus.transveral:	//gdManuAddNew, gdHzShift, gdAbsDistSel 垂直
                    for (i = 0; i < 2; i++)
                    {
                        this._zoomLine[i].StartX = iXpnt;
                        this._zoomLine[i].EndX = iXpnt;
                        this._zoomLine[i].StartY = this._area.Top;
                        this._zoomLine[i].EndY = this._area.Bottom;
                        this._zoomLine[i].Color = CastColor.GetCustomColor(Color.Red);
                        this._zoomLine[i].Show = true;
                    }
                    break;
                case ZoomStatus.longitudianl:	//水平
                    for (i = 0; i < 2; i++)
                    {
                        this._zoomLine[i].StartY = iYpnt;
                        this._zoomLine[i].EndY = iYpnt;
                        this._zoomLine[i].StartX = this._area.Left;
                        this._zoomLine[i].EndX = this._area.Right;
                        this._zoomLine[i].Color = CastColor.GetCustomColor(Color.Red);
                        this._zoomLine[i].Show = true;
                    }
                    break;
                case ZoomStatus.editSendUp:	//only use in WAVE
                case ZoomStatus.editTurnDown:
                case ZoomStatus.editGearDown:
                    this._zoomShape.X = iXpnt;
                    this._zoomShape.Y = iYpnt;
                    this._zoomShape.Height = 0;
                    this._zoomShape.Width = 0;
                    this._zoomShape.Show = true;
                    break;
                default:
                    break;
            }

            this._isStartZoom = true;
        }

        /// <summary>
        /// 获取新的坐标
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="iXpnt"></param>
        /// <param name="iYpnt"></param>
        private void GetGraphCoordinateF(Int32 X, Int32 Y, ref Int32 iXpnt, ref Int32 iYpnt)
        {
            iXpnt = X;	// / Screen.TwipsPerPixelX

            if (iXpnt < this._area.Left)
                iXpnt = this._area.Left;
            if (iXpnt > this._area.Right)
                iXpnt = this._area.Right;

            iYpnt = Y;	// Screen.TwipsPerPixelY
            if (iYpnt < this._area.Top)
                iYpnt = this._area.Top;
            if (iYpnt > this._area.Bottom)
                iYpnt = this._area.Bottom;
        }

        /// <summary>
        /// 放大缩小的鼠标移动处理
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void ZoomInRunning(Int32 X, Int32 Y)
        {
            int iXpnt = 0;	//倃嵗昗
            int iYpnt = 0;	//倄嵗昗

            if (this._expandState == ZoomStatus.normal || !this._isStartZoom)
            {
                return;
            }
            
            this.GetGraphCoordinateF(X, Y, ref iXpnt, ref iYpnt);	//僌儔僼僄儕傾嵗昗偺庢摼

            switch (_expandState)	//廔揰昞帵
            {
                case ZoomStatus.square:	//巐妏偺奼戝
                case ZoomStatus.editSendUp:
                case ZoomStatus.editTurnDown:
                case ZoomStatus.editGearDown:
                    if (iXpnt < this._zoomShape.X)	//埵抲崌傢偣曽朄愝掕
                        this._zoomShape.AdjustX = 0;	//僄儕傾偺塃尷傑偱
                    else
                        this._zoomShape.AdjustX = 1;	//僄儕傾偺嵍尷傑偱

                    if (iYpnt < this._zoomShape.Y)
                        this._zoomShape.AdjustY = 0; //僄儕傾偺壓尷傑偱
                    else
                        this._zoomShape.AdjustY = 1;	//僄儕傾偺忋尷傑偱

                    this._zoomShape.Height = Math.Abs(iYpnt - this._zoomShape.Y);
                    this._zoomShape.Width = Math.Abs(iXpnt - this._zoomShape.X);
                    break;
                case ZoomStatus.transveral:	//墶奼戝
                    //case gdManuAddNew:
                    //case gdHzShift:
                    //case gdAbsDistSel:
                    this._zoomLine[1].StartX = iXpnt;
                    this._zoomLine[1].EndX = iXpnt;
                    break;
                case ZoomStatus.longitudianl:	//廲奼戝
                    this._zoomLine[1].StartY = iYpnt;
                    this._zoomLine[1].EndY = iYpnt;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 放大缩小的结束处理
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void ZoomInEnd(Int32 X, Int32 Y)
        {
            int i;
            int iXpnt = 0;	//倃嵗昗
            int iYpnt = 0;	//倄嵗昗
            double mMinScaleX = 0;
            double mMinScaleY = 0;
            double fdum;
            int ldum;

            if (this._isStartZoom)
            {
                _isStartZoom = false;
            }
            if (_expandState == ZoomStatus.normal )
            {
                return;
            }


            this.GetGraphCoordinateF(X, Y, ref iXpnt, ref iYpnt);    //僌儔僼僄儕傾嵗昗偺庢摼
            this.SetEndPosS(iXpnt, iYpnt);               //廔揰婰壇

            switch (_expandState)	//廔揰昞帵
            {
                case ZoomStatus.square:	//巐妏偺奼戝
                    if (0 == this._zoomShape.Height || 0 == this._zoomShape.Width) return; //崅偝丒暆偑側偄応崌偼張棟廔椆
                    break;
                case ZoomStatus.transveral:	//墶奼戝
                    if (this._zoomLine[0].StartX == this._zoomLine[1].StartX) return;	//斖埻偑慖戰偝傟偰偄側偄応崌丄張棟廔椆
                    break;
                case ZoomStatus.longitudianl:	//廲奼戝
                    //    case gdManuAddNew:
                    if (this._zoomLine[0].StartY == this._zoomLine[1].StartY) return;	//斖埻偑慖戰偝傟偰偄側偄応崌丄張棟廔椆
                    break;
                case ZoomStatus.editSendUp:
                case ZoomStatus.editTurnDown:
                case ZoomStatus.editGearDown:
                    //    case gdHzShift:
                    if (0 == this._zoomShape.Height || 0 == this._zoomShape.Width) return;
                    break;
                default:
                    break;
            }

            if (_expandState != ZoomStatus.editSendUp && _expandState != ZoomStatus.editTurnDown &&
                _expandState != ZoomStatus.editGearDown) // && miExpandState != gdHzShift )
            {
                for (i = 0; i < 2; i++) // 奼戝慄傪 not show
                    this._zoomLine[i].Show = false;
                this._zoomShape.Show = false;
            }

            if (mtExRange.EndValX < mtExRange.StartValX) //巒揰丆廔揰偺嵍塃乛忋壓偺斀揮傪峫椂
            {
                fdum = mtExRange.StartValX;
                mtExRange.StartValX = mtExRange.EndValX;
                mtExRange.EndValX = fdum;
                ldum = mtExRange.StartPosX;
                mtExRange.StartPosX = mtExRange.EndPosX;
                mtExRange.EndPosX = ldum;
            }

            if (mtExRange.EndValY > mtExRange.StartValY)
            {
                fdum = mtExRange.StartValY;
                mtExRange.StartValY = mtExRange.EndValY;
                mtExRange.EndValY = fdum;
                ldum = mtExRange.StartPosY;
                mtExRange.StartPosY = mtExRange.EndPosY;
                mtExRange.EndPosY = ldum;
            }

            switch (_expandState)	//奼戝張棟
            {
                case ZoomStatus.square:	//巐妏偺奼戝
                    if (Math.Abs(mtExRange.EndValX - mtExRange.StartValX) > mMinScaleX) //僄儕傾傪愝掕
                    {
                        this._area.LeftValue = mtExRange.StartValX;
                        this._area.RightValue = mtExRange.EndValX;
                        this._axsX.StartValue = mtExRange.StartValX;	//X幉巒揰抣愝掕
                        this._axsX.EndValue = mtExRange.EndValX;       //X幉廔揰抣愝掕
                    }
                    if (Math.Abs(mtExRange.EndValY - mtExRange.StartValY) > mMinScaleY)
                    {
                        this._area.TopValue = mtExRange.StartValY;
                        this._area.BottomValue = mtExRange.EndValY;
                        this._axsY.StartValue = mtExRange.EndValY;     //Y幉巒揰抣愝掕
                        this._axsY.EndValue = mtExRange.StartValY;     //Y幉廔揰抣愝掕
                    }
                    //        if( mtSub(0).iUser = sGRAPH.UserType.FORM_WAVE )
                    //		{
                    //            mPrntForm.ImgMove(1).Enabled = True
                    //            mPrntForm.ImgMove(2).Enabled = True
                    //            mPrntForm.ImgMove(3).Enabled = True
                    //            mPrntForm.ImgMove(4).Enabled = True
                    //            mPrntForm.ImgMove(1).Picture = LoadPicture(gsSystemPath & "\trueLeft.ico")
                    //            mPrntForm.ImgMove(2).Picture = LoadPicture(gsSystemPath & "\trueRight.ico")
                    //            mPrntForm.ImgMove(3).Picture = LoadPicture(gsSystemPath & "\trueUp.ico")
                    //            mPrntForm.ImgMove(4).Picture = LoadPicture(gsSystemPath & "\trueDown.ico")
                    //        }
                    break;
                case ZoomStatus.transveral:	//墶奼戝
                    if (mtExRange.EndValX - mtExRange.StartValX > mMinScaleX)
                    {
                        //僄儕傾傪愝掕
                        this._area.LeftValue = mtExRange.StartValX;
                        this._area.RightValue = mtExRange.EndValX;
                        //X幉傪愝掕
                        this._axsX.StartValue = mtExRange.StartValX;   //X幉巒揰抣愝掕
                        this._axsX.EndValue = mtExRange.EndValX;		//X幉廔揰抣愝掕
                        //X幉傪愝掕
                    }
                    break;
                case ZoomStatus.longitudianl:	//廲奼戝
                    if (Math.Abs(mtExRange.EndValY - mtExRange.StartValY) > mMinScaleY)
                    {
                        //僄儕傾傪愝掕
                        this._area.TopValue = mtExRange.StartValY;
                        this._area.BottomValue = mtExRange.EndValY;
                        //Y幉傪愝掕
                        this._axsY.StartValue = mtExRange.EndValY;     //Y幉巒揰抣愝掕
                        this._axsY.EndValue = mtExRange.StartValY;     //Y幉廔揰抣愝掕
                        //            If mtSub(0).iUser = sGRAPH.UserType.FORM_WAVE Then
                        //                mPrntForm.ImgMove(3).Enabled = True
                        //                mPrntForm.ImgMove(4).Enabled = True
                        //                mPrntForm.ImgMove(3).Picture = LoadPicture(gsSystemPath & "\trueUp.ico")
                        //                mPrntForm.ImgMove(4).Picture = LoadPicture(gsSystemPath & "\trueDown.ico")
                        //            End If
                    }
                    break;
                default:
                    break;
            }

            this._expandState = ZoomStatus.square;
        }

        /// <summary>
        /// 设置终点
        /// </summary>
        /// <param name="iXpnt"></param>
        /// <param name="iYpnt"></param>
        private void SetEndPosS(int iXpnt, int iYpnt)
        {
            double fTmpVal = 0;
            double fdum = 0;
            int ldum = 0;

            //X嵗昗
            fTmpVal = Convert.ToDouble(iXpnt - this._area.Left) / Convert.ToDouble(this._area.Right - this._area.Left);
            mtExRange.EndValX = fTmpVal * (this._area.RightValue - this._area.LeftValue) + this._area.LeftValue;
            //Y嵗昗
            fTmpVal = Convert.ToDouble(iYpnt - this._area.Top) / Convert.ToDouble(this._area.Top - this._area.Bottom);
            mtExRange.EndValY = (1 + fTmpVal) * (this._area.TopValue - this._area.BottomValue) + this._area.BottomValue;

            mtExRange.EndPosX = iXpnt;
            mtExRange.EndPosY = iYpnt;

            //巒揰丆廔揰偺嵍塃乛忋壓偺斀揮傪峫椂
            if (mtExRange.EndValX < mtExRange.StartValX)
            {
                fdum = mtExRange.StartValX;
                mtExRange.StartValX = mtExRange.EndValX;
                mtExRange.EndValX = fdum;
                ldum = mtExRange.StartPosX;
                mtExRange.StartPosX = mtExRange.EndPosX;
                mtExRange.EndPosX = ldum;
                mtExRange1.StartValX = mtExRange.StartValX;
            }
            if (mtExRange.EndValY > mtExRange.StartValY)
            {
                fdum = mtExRange.StartValY;
                mtExRange.StartValY = mtExRange.EndValY;
                mtExRange.EndValY = fdum;
                ldum = mtExRange.StartPosY;
                mtExRange.StartPosY = mtExRange.EndPosY;
                mtExRange.EndPosY = ldum;
                mtExRange1.StartValY = mtExRange.StartValY;
            }
        }

        /// <summary>
        /// 返回当前操作的字符串
        /// </summary>
        /// <returns></returns>
        public string GetExpandText()
        {
            String temp = "";
            if (this._ut >= UserType.osc && this._ut <= UserType.toyota)
            {
                switch (this._expandState)
                {
                    case ZoomStatus.transveral:
                        temp = "垂直放大";
                        break;
                    case ZoomStatus.longitudianl:
                        temp = "水平放大";
                        break;
                    case ZoomStatus.square:
                        temp = "区域放大";
                        break;
                    case ZoomStatus.normal:
                        temp = "全景";
                        break;
                    default:
                        break;
                }
            }
            return temp;
        }

        #endregion


        #region 设置区域 未使用

        /********************************************************************************/
        /***     SetAreaAndAxisScale for osc and mnt                                  ***
        /********************************************************************************/
        void GetAreaRange(int nGraph)
        {
            //mtOscRange.EndValY = this._bizArea.TopValue(nGraph);
            //mtOscRange.StartValY = this._bizArea.BottomValue(nGraph);
            //mtOscRange.StartValX = this._bizArea.LeftValue(nGraph);
            //mtOscRange.EndValX = this._bizArea.RightValue(nGraph);
        }

        void SetAreaAndAxisScale(int nGraph)
        {
            //this._bizArea.TopValue(nGraph, mtOscRange.EndValY);
            //this._bizAxisY.AxsYEndValue(nGraph, mtOscRange.EndValY);
            //this._bizAxisY.AxsYStartValue(nGraph, mtOscRange.StartValY);
            //this._bizArea.BottomValue(nGraph, mtOscRange.StartValY);
            //this._bizArea.LeftValue(nGraph, mtOscRange.StartValX);
            //this._bizAxisX.StartValue(nGraph, mtOscRange.StartValX);
            //this._bizArea.RightValue(nGraph, mtOscRange.EndValX);
            //this._bizAxisX.EndValue(nGraph, mtOscRange.EndValX);
        }

        #endregion





    }
}
