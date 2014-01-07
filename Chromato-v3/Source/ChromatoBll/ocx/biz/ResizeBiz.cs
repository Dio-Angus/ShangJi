/*-----------------------------------------------------------------------------
//  FILE NAME       : ResizeBiz.cs
//  FUNCTION        : 容器改变大小后2D控件大小改变逻辑
//  AUTHOR          : 李锋(2009/03/01)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using ChromatoBll.ocx.item;
using ChromatoTool.ini;
using ChromatoTool.dto;

namespace ChromatoBll.ocx.biz
{
    /// <summary>
    /// 容器改变大小后2D控件大小改变逻辑
    /// </summary>
    public class ResizeBiz
    {

        #region 常量

        /// <summary>
        /// 放大倍数
        /// </summary>
        private const double MoveTimes = 0.1;

        /// <summary>
        /// 缩放整个长度的倍数
        /// </summary>
        private const Single ZoomTimes = 10;

        #endregion


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
        public GridImp _grid { get; set; }

        /// <summary>
        /// 曲线
        /// </summary>
        public PlotImp _plot { get; set; }
        /// <summary>
        /// 用户对象
        /// </summary>
        private UserType _ut { get; set; }

        #endregion


        #region  构造

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="user"></param>
        public ResizeBiz(UserType user)
        {
            _ut = user;
        }

        #endregion


        #region 图形跟随窗口改变大小

        /// <summary>
        /// 图形改变大小
        /// </summary>
        /// <param name="ocxtop"></param>
        /// <param name="ocxleft"></param>
        /// <param name="dlgWidth"></param>
        /// <param name="dlgHeight"></param>
        /// <param name="OffWidth"></param>
        /// <param name="OffHeight"></param>
        public void GraphResize(int ocxtop, int ocxleft,
                         int dlgWidth, int dlgHeight,
                         int OffWidth, int OffHeight)
        {
            Rectangle genericRect = new Rectangle();
            Point pt = new Point(ocxleft,ocxtop);
            genericRect.Location = pt;

            //set  ocx  height and width
            switch (_ut)
            {
                case UserType.osc:
                case UserType.mnt:
                case UserType.anl:
                    genericRect.Height = dlgHeight - OffHeight;
                    genericRect.Width = dlgWidth - OffWidth;
                    break;

                case UserType.flt:
                case UserType.wave:
                case UserType.group:
                case UserType.upPeak:
                    genericRect.Height = dlgHeight - (845 + 850) / 15;
                    genericRect.Width = dlgWidth - OffWidth;
                    break;

                case UserType.shift:
                case UserType.downPeak:
                    genericRect.Height = dlgHeight - OffHeight;
                    genericRect.Width = dlgWidth - OffWidth;
                    break;

                case UserType.relativeGr:
                case UserType.absoluteGr:
                case UserType.toyota:
                    genericRect.Height = dlgHeight - OffHeight;
                    genericRect.Width = dlgWidth - OffWidth;
                    break;

                default:
                    genericRect.Height = dlgHeight - OffHeight;
                    genericRect.Width = dlgWidth - OffWidth;
                    break;
            }
            this._area.ocx.Bounds = genericRect;

            //set ocx and StatusBar width
            //nStatusbarWidth = genericRect.Width()
            ChangeSubObject();
        }

        /// <summary>
        /// 改变子对象
        /// </summary>
        public void ChangeSubObject()
        {
            Rectangle genericRect = _area.ocx.ClientRectangle;

            //set Grid
            this._grid.Left = GetLeftSpace(false);
            this._grid.Right = genericRect.Width - GetRightSpace();
            this._grid.Top = GetTopSpace();
            this._grid.Bottom = genericRect.Height - GetBottomSpace();

            //set Area
            this._area.Left = this._grid.Left;
            this._area.Right = _grid.Right;
            this._area.Bottom = this._grid.Bottom;
            this._area.Top = this._grid.Top;

            this._area.LeftValue = this._axsX.StartValue;
            this._area.RightValue = this._axsX.EndValue;

            //mPrntForm.ScaleMode = vbTwips

            //set Axis_Y
            this._axsY.X = this._grid.Left;
            this._axsY.Y = this._grid.Bottom;
            this._axsY.Length = this._grid.Top - this._grid.Bottom;

            //set Axis_X
            this._axsX.X = this._grid.Left;
            this._axsX.Y = this._grid.Bottom;
            this._axsX.Length = this._grid.Right - this._grid.Left;

            //this.UpdateGraph();

            //set Line
            if (UserType.anl == this._ut)
            {
                //    ValueLineStartX = GridLeft(0)
                //    ValueLineEndX = GridLeft(0)
                //    ValueLineStartY = GridTop(0)
                //    ValueLineEndY = GridBottom(0)
            }

            //set Y2
            if (this._ut == UserType.downPeak || this._ut == UserType.relativeGr ||
                this._ut == UserType.absoluteGr || this._ut == UserType.toyota)
            {
                //for (int iCnt = 1; iCnt < 3; iCnt++)
                //{
                //    //			if( mtSub[iCnt].bPlot )
                //    //			{
                //    //墶埵抲寛掕
                //    this._bizArea.Right(iCnt, this._bizArea.Right(0));
                //    this._bizArea.Left(iCnt, this._bizArea.Left(0));
                //    this._bizAxisY.AxsYX(iCnt, this._bizArea.Right(iCnt));

                //    //廲埵抲愝掕
                //    this._bizAxisY.AxsYY(iCnt, Convert.ToInt32((this._bizArea.Bottom(0) - this._bizArea.Top(0)) / 2));
                //    this._bizAxisY.AxsYLength(iCnt, this._bizAxisY.AxsYLength(0) / 3);  //mlGrfProp.YY(iCnt).AxsLen
                //    this._bizAxisY.AxsYX(iCnt, this._bizGrid.Right(0));
                //    this._bizArea.Top(iCnt, 0);
                //    this._bizArea.Bottom(iCnt, this._bizAxisY.AxsYY(iCnt));
                //    this._bizArea.Top(iCnt, this._bizAxisY.AxsYY(iCnt) + this._bizAxisY.AxsYLength(iCnt));
                //    //			}
                //}
            }
        }

        /// <summary>
        /// 取得左边间距
        /// </summary>
        /// <param name="bSGRFlg"></param>
        /// <returns></returns>
        private int GetLeftSpace(bool bSGRFlg) //true -SGR
        {
            int nValuePixel = 0;
            int nEndValue = 0;
            int nStartValue = 0;
            String sTemp;

            if (!bSGRFlg)
            {
                sTemp = String.Format("{0}", Convert.ToInt32(this._axsY.StartValue));
                nStartValue = sTemp.Length;
                sTemp = String.Format("{0}", Convert.ToInt32(this._axsY.EndValue));
                nEndValue = sTemp.Length;
                nValuePixel = (nStartValue > nEndValue) ? nStartValue : nEndValue;
                nValuePixel += this._axsY.FloatFigure;
                nValuePixel += (this._axsY.FloatFigure > 0) ? 1 : 0;
            }
            else
            {
                sTemp = String.Format("{0}", Convert.ToInt32(this._axsY.EndValue));
                nValuePixel = sTemp.Length;
            }
            nValuePixel = Convert.ToInt32(nValuePixel * this._axsY.LabelFontSize * ResizePara.FONT_HOZ_SIZE_FACTOR + ResizePara.LEFT_SPACE);
            //	nValuePixel = m_GraphObj.get_AxisLabelAndUnitSize( mtSub[0].nAxisY );
            return nValuePixel;
        }

        /// <summary>
        /// 区的顶部间距
        /// </summary>
        /// <returns></returns>
        private int GetTopSpace()
        {
            int labelpixel;
            labelpixel = Convert.ToInt32(this._axsY.LabelFontSize * ResizePara.FONT_VER_SIZE_FACTOR + ResizePara.TOP_SPACE);
            return labelpixel;
        }

        /// <summary>
        /// 取得底部间距
        /// </summary>
        /// <returns></returns>
        private int GetBottomSpace()
        {
            int labelpixel = 0;
            labelpixel = Convert.ToInt32(this._axsX.LabelFontSize * ResizePara.FONT_VER_SIZE_FACTOR + ResizePara.BOTTOM_SPACE);
            //	labelpixel = m_GraphObj.get_AxisLabelAndUnitSize( mtSub[0].nAxisX );
            return labelpixel;
        }

        /// <summary>
        /// 取得右边间距
        /// </summary>
        /// <returns></returns>
        private int GetRightSpace()
        {
            int[] pixellen = new int[2];
            //int nEndValue;
            //int nStartValue;
            //String sTemp;
            int nValuePixel = 0;

            pixellen[0] = 0;
            pixellen[1] = 0;
            //Y2
            for (int i = 1; i < 3; i++)
            {
            //    if (_area.layer[i].bDisp)
            //    {
            //        sTemp = String.Format("{0}", (this._axsY.StartValue(i)));
            //        nStartValue = sTemp.Length;
            //        sTemp = String.Format("[0]", (this._axsY.EndValue(i)));
            //        nEndValue = sTemp.Length;
            //        pixellen[i - 1] = (nStartValue > nEndValue) ? nStartValue : nEndValue;
            //        pixellen[i - 1] += this._axsY.FloatFigure(i);
            //        pixellen[i - 1] += (this._axsY.FloatFigure(i) > 0) ? 1 : 0;
            //        pixellen[i - 1] = pixellen[i - 1] * this._axsY.LabelFontSize(i);
            //    }
            }
            nValuePixel = (pixellen[0] > pixellen[1]) ? pixellen[0] : pixellen[1];
            nValuePixel = Convert.ToInt32((nValuePixel * ResizePara.FONT_HOZ_SIZE_FACTOR + ResizePara.RIGHT_SPACE));

            pixellen[0] = 0;
            pixellen[1] = 0;
            for (int i = 1; i < 3; i++)
            {
                //if (_area.layer[i].bDisp)
                //{
                //    pixellen[i - 1] = _area.ocx.GetAxisLabelAndUnitSize(_area.layer[0].nAxisY);
                //}
            }
            nValuePixel = (pixellen[0] > pixellen[1]) ? pixellen[0] : pixellen[1];
            nValuePixel = Convert.ToInt32(nValuePixel + ResizePara.RIGHT_SPACE);
            return nValuePixel;
        }

        #endregion


        #region 更新图形

        /// <summary>
        /// 更新离线图形
        /// </summary>
        public void UpdateOffGraph()
        {
            double maxXval = this._area.ocx.Width / Convert.ToSingle(General.Frequent)
                / Convert.ToSingle(DefaultItem.SecondsPerMin);

            _area.LeftValue = 0;
            _area.RightValue = maxXval;

            _axsX.StartValue = 0;
            _axsX.EndValue = maxXval;

            _axsX.FloatFigure = 3;
            _axsY.FloatFigure = 3;

            _axsY.StartValue = _area.BottomValue;
            _axsY.EndValue = _area.TopValue;

            //_plot.ShowMarker(0, 0, true);
        }

        /// <summary>
        /// 更新Y轴最大值
        /// </summary>
        public void UpdateMaxY(Single maxY)
        {
            _area.TopValue = Convert.ToDouble(maxY);
            _axsY.EndValue = _area.TopValue;
        }

        /// <summary>
        /// 更新Y轴最小值
        /// </summary>
        public void UpdateMinY(Single minY)
        {
            _area.BottomValue = Convert.ToDouble(minY);
            _axsY.StartValue = _area.BottomValue;
        }

        /// <summary>
        /// 更新图形
        /// </summary>
        public void UpdateHisGraph()
        {
            double maxXval = this._area.ocx.Width / Convert.ToSingle(General.Frequent)
                / Convert.ToSingle(DefaultItem.SecondsPerMin);

            Single maxY = 0; 
            Single minY = 0;
            Single maxX = 0;
            Single minX = 0;

            //自动坐标范围
            if (Offline.AutoScale)
            {
                foreach (AvgPointDto dto in this._plot.arr)
                {
                    if (maxY < dto.Voltage)
                    {
                        maxY = dto.Voltage;
                    }
                    if (minY > dto.Voltage)
                    {
                        minY = dto.Voltage;
                    }
                    if (maxX < dto.Moment)
                    {
                        maxX = dto.Moment;
                    }
                    if (minX > dto.Moment)
                    {
                        minX = dto.Moment;
                    }
                }
                _area.LeftValue = minX;
                _area.RightValue = maxX;

                _axsX.StartValue = minX;
                _axsX.EndValue = maxX;

            }
            else
            {
                maxY = Offline.ShowMaxY;
                minY = Offline.ShowMinY;

                _area.LeftValue = Offline.ShowMinX;
                _area.RightValue = Offline.ShowMaxX;

                _axsX.StartValue = Offline.ShowMinX;
                _axsX.EndValue = Offline.ShowMaxX;
            }

            _axsX.FloatFigure = 3;
            _axsY.FloatFigure = 3;

            this.UpdateHisMaxY( maxY );
            this.UpdateHisMinY( minY );
            this._plot.ShowMarker = Offline.ShowMarker;

        }

        /// <summary>
        /// 更新Y轴显示最大值
        /// </summary>
        /// <param name="maxY"></param>
        private void UpdateHisMaxY(Single maxY)
        {
            _area.TopValue = Convert.ToDouble(maxY + 0.5);
            _axsY.EndValue = _area.TopValue;
        }

        /// <summary>
        /// 更新Y轴显示最小值
        /// </summary>
        /// <param name="minY"></param>
        private void UpdateHisMinY(Single minY)
        {
            _area.BottomValue = Convert.ToDouble(minY - 0.2);
            _axsY.StartValue = _area.BottomValue;
        }

        /// <summary>
        /// 向上移动
        /// </summary>
        public void MoveUp()
        {
            double diff = this._area.TopValue - this._area.BottomValue;

            this._area.TopValue += diff * MoveTimes;
            this._area.BottomValue += diff * MoveTimes;

            this._axsY.EndValue += diff * MoveTimes;
            this._axsY.StartValue += diff * MoveTimes;
        }

        /// <summary>
        /// 向下移动
        /// </summary>
        public void MoveDown()
        {
            double diff = this._area.TopValue - this._area.BottomValue;

            this._area.TopValue -= diff * MoveTimes;
            this._area.BottomValue -= diff * MoveTimes;

            this._axsY.EndValue -= diff * MoveTimes;
            this._axsY.StartValue -= diff * MoveTimes;
        }

        /// <summary>
        /// 向左移动
        /// </summary>
        public void MoveLeft()
        {
            double diff = this._area.RightValue - this._area.LeftValue;

            this._area.RightValue += diff * MoveTimes;
            this._area.LeftValue += diff * MoveTimes;

            this._axsX.EndValue += diff * MoveTimes;
            this._axsX.StartValue += diff * MoveTimes;
        }

        /// <summary>
        /// 向右移动
        /// </summary>
        public void MoveRight()
        {
            double diff = this._area.RightValue - this._area.LeftValue;

            this._area.RightValue -= diff * MoveTimes;
            this._area.LeftValue -= diff * MoveTimes;

            this._axsX.EndValue -= diff * MoveTimes;
            this._axsX.StartValue -= diff * MoveTimes;
        }

        /// <summary>
        /// 更新Y轴坐标
        /// </summary>
        /// <param name="flag"></param>
        public void UpdateY(UpDownFlag flag)
        {
            switch (flag)
            {
                case UpDownFlag.MaxUp:
                    this._area.TopValue += (this._area.TopValue - this._area.BottomValue) / ZoomTimes;
                    _axsY.EndValue = _area.TopValue;
                    break;

                case UpDownFlag.MaxDown:
                    this._area.TopValue -= (this._area.TopValue - this._area.BottomValue) / ZoomTimes;
                    _axsY.EndValue = _area.TopValue;
                    break;

                case UpDownFlag.MinUp:
                    this._area.BottomValue += (this._area.TopValue - this._area.BottomValue) / ZoomTimes;
                    _axsY.StartValue = _area.BottomValue;
                    break;

                case UpDownFlag.MinDown:
                    this._area.BottomValue -= (this._area.TopValue - this._area.BottomValue) / ZoomTimes;
                    _axsY.StartValue = _area.BottomValue;
                    break;
            }
        }

        #endregion





    }
}
