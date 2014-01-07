/*-----------------------------------------------------------------------------
//  FILE NAME       : ArrowLineBiz.cs
//  FUNCTION        : 2D控件中十字光标的显示处理
//  AUTHOR          : 李锋(2009/03/10)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


using System;
using ChromatoBll.ocx.item;
using ChromatoTool.ini;
using ChromatoTool.dto;

namespace ChromatoBll.ocx.biz
{
    /// <summary>
    /// 2D控件中十字光标的显示处理
    /// </summary>
    public sealed class ArrowLineBiz
    {

        #region 常量

        /// <summary>
        /// 显示时间的最小范围（秒）
        /// </summary>
        private const Int32 MinShowTimeDistance = 10;

        /// <summary>
        /// 缩放整个长度的倍数
        /// </summary>
        private const Double ZoomTimes = 10;

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
        /// 直线item
        /// </summary>
        public LineImp[] _arrowLine { get; set; }

        /// <summary>
        /// 曲线
        /// </summary>
        public PlotImp _plot { get; set; }

        /// <summary>
        /// 当前鼠标选中点
        /// </summary>
        public Int32 _arrayIndex { get; set; }

        /// <summary>
        /// 当前鼠标选中点X
        /// </summary>
        public Int32 _curXPixel { get; set; }

        /// <summary>
        /// 当前鼠标选中点Y
        /// </summary>
        public Int32 _curYPixel { get; set; }

        /// <summary>
        /// 结束点的电压
        /// </summary>
        public Single _downVoltage { get; set; }

        /// <summary>
        /// 是否在下方
        /// </summary>
        public bool _isDown { get; set; }

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public ArrowLineBiz()
        {
            this._arrowLine = new LineImp[2];
        }

        #endregion


        #region 显示坐标

        /// <summary>
        /// 更新十字光标
        /// </summary>
        public void UpdateArrow()
        {
            if (this._arrowLine[0].Show && this._arrowLine[1].Show)
            {
                this.CacuRange(false);
            }
        }
        
        /// <summary>
        /// 不显示十字光标
        /// </summary>
        public void UnvisibleArrow()
        {
            this._arrowLine[0].Show = false;
            this._arrowLine[1].Show = false;
        }

        /// <summary>
        /// 显示十字光标
        /// </summary>
        /// <param name="x">当前鼠标相对于客户区的X坐标</param>
        /// <param name="y">当前鼠标相对于客户区的Y坐标</param>
        public void CacuArrow(int x, int y)
        {
            // 点击区域外部设置到边界
            if (x < this._area.Left)
            {
                x = this._area.Left;
            }
            if (x > this._area.Right)
            {
                x = this._area.Right;
            }
            if (y < this._area.Top)
            {
                y = this._area.Top;
            }
            if (y > this._area.Bottom)
            {
                y = this._area.Bottom;
            }

            //屏幕坐标转换为曲线实际值 (x - left) / (Right - Left) = (fValue - StartValue) / (EndValue - StartValue)
            Single fValue = Convert.ToSingle(x - this._area.Left)
                * Convert.ToSingle(_axsX.EndValue - _axsX.StartValue)
                / Convert.ToSingle(_area.Right - _area.Left) + Convert.ToSingle(_axsX.StartValue);

            //compute the current count of X in Array
            Single fdata = fValue * Convert.ToSingle(General.Frequent) * DefaultItem.SecondsPerMin / DefaultAnaly.PeakWide;

            //确定用户选中的点
            this._arrayIndex = Convert.ToInt32(fdata);
        }

        /// <summary>
        /// 显示十字光标
        /// </summary>
        /// <param name="x">当前鼠标相对于客户区的X坐标</param>
        /// <param name="y">当前鼠标相对于客户区的Y坐标</param>
        public void ShowNormalArrow(int x,int y)
        {
            this.CacuArrow(x,y);
            this.CacuRange(false);
        }

        /// <summary>
        /// 显示十字光标
        /// </summary>
        /// <param name="x">当前鼠标相对于客户区的X坐标</param>
        /// <param name="y">当前鼠标相对于客户区的Y坐标</param>
        public void ShowPeakArrow(int x, int y)
        {
            this.CacuArrow(x, y);
            this.CacuRange(y);
        }

        /// <summary>
        /// 移动坐标
        /// </summary>
        /// <param name="y"></param>
        private void CacuRange(int y)
        {
            if (null == this._plot || null == this._plot.arr)
            {
                return;
            }

            Single fPntSizeX = _area.Right - _area.Left;
            Single fPntSizeY = _area.Bottom - _area.Top;

            Double fMemoryValX = fPntSizeX / (_axsX.EndValue - _axsX.StartValue);
            Double fMemoryValY = fPntSizeY / (_axsY.EndValue - _axsY.StartValue);

            if (this._arrayIndex >= _plot.arr.Count)
            {
                return;
            }
            AvgPointDto dto = (AvgPointDto)_plot.arr[this._arrayIndex];

            //把时间转化为像素
            this._curXPixel = _area.Left + Convert.ToInt32(fMemoryValX * (dto.Moment - _axsX.StartValue));

            //把电压转化为像素
            this._curYPixel = _area.Bottom - Convert.ToInt32(fMemoryValY * (dto.Voltage - _area.BottomValue));

            //当前点电压
            this._downVoltage = Convert.ToSingle(
               Convert.ToDouble(_area.Bottom - y) / fMemoryValY + _area.BottomValue);

            //如果距离小于三个像素,认为在线上
            if (Math.Abs(y - this._curYPixel) < 3 || this._downVoltage > dto.Voltage)
            {
                this._downVoltage = dto.Voltage;
                this._isDown = false;
            }
            else
            {
                this._isDown = true;
            }

            this.PositionTwoLine(this._curXPixel, this._curYPixel);
        }

        /// <summary>
        /// 移动坐标
        /// </summary>
        /// <param name="isRecursive"></param>
        private void CacuRange(bool isRecursive)
        {
            if (null == this._plot || null == this._plot.arr)
            {
                return;
            }

            Single fPntSizeX = _area.Right - _area.Left;
            Single fPntSizeY = _area.Bottom - _area.Top;

            Double fMemoryValX = fPntSizeX / (_axsX.EndValue - _axsX.StartValue);
            Double fMemoryValY = fPntSizeY / (_axsY.EndValue - _axsY.StartValue);

            if (this._arrayIndex >= _plot.arr.Count)
            {
                return;
            }
            AvgPointDto dto = (AvgPointDto)_plot.arr[this._arrayIndex];

            //把时间转化为像素
            this._curXPixel = _area.Left + Convert.ToInt32(fMemoryValX * (dto.Moment - _axsX.StartValue));

            //把电压转化为像素
            this._curYPixel = _area.Bottom - Convert.ToInt32(fMemoryValY * (dto.Voltage - _area.BottomValue));

            //是否递归
            if (isRecursive)
            {
                if (this._curXPixel > this._area.Right)
                {
                    this._area.LeftValue += dto.Moment - this._area.RightValue;
                    this._axsX.StartValue += dto.Moment - this._area.RightValue;
                    this._area.RightValue = dto.Moment;
                    this._axsX.EndValue = dto.Moment;
                    this.CacuRange(false);
                }

                if (this._curXPixel < this._area.Left)
                {
                    this._area.RightValue += dto.Moment - this._area.LeftValue;
                    this._axsX.EndValue += dto.Moment - this._area.LeftValue;
                    this._area.LeftValue = dto.Moment;
                    this._axsX.StartValue = dto.Moment;
                    this.CacuRange(false);
                }
            }
            this.PositionTwoLine(this._curXPixel, this._curYPixel);
        }

        /// <summary>
        /// 定位坐标的两根直线
        /// </summary>
        /// <param name="xPixel"></param>
        /// <param name="yPixel"></param>
        private void PositionTwoLine(int xPixel, int yPixel)
        {
            switch (General.ArrowStyle)
            {
                case General.StyleArrow.Big:
                    _arrowLine[0].StartX = xPixel;  // _area.Left + Convert.ToInt32(fMemoryValX * (dto.Moment - _axsX.StartValue));
                    _arrowLine[0].EndX = _arrowLine[0].StartX;
                    _arrowLine[0].StartY = _area.Top;
                    _arrowLine[0].EndY = _area.Bottom;
                    _arrowLine[0].Width = 1;

                    _arrowLine[1].StartY = yPixel; // _area.Bottom - Convert.ToInt32(fMemoryValY * (dto.Voltage - _area.BottomValue));
                    _arrowLine[1].EndY = _arrowLine[1].StartY;
                    _arrowLine[1].StartX = _area.Left;
                    _arrowLine[1].EndX = _area.Right;
                    _arrowLine[1].Width = 1;
                    break;

                case General.StyleArrow.Small:

                    //int xPixel = _area.Left + Convert.ToInt32(fMemoryValX * (dto.Moment - _axsX.StartValue));
                    //int yPixel = _area.Bottom - Convert.ToInt32(fMemoryValY * (dto.Voltage - _area.BottomValue));

                    _arrowLine[0].StartX = xPixel;
                    _arrowLine[0].EndX = xPixel;
                    _arrowLine[0].StartY = yPixel - 5;
                    _arrowLine[0].EndY = yPixel + 5;
                    _arrowLine[0].Width = 2;

                    _arrowLine[1].StartY = yPixel;
                    _arrowLine[1].EndY = yPixel;
                    _arrowLine[1].StartX = xPixel - 5;
                    _arrowLine[1].EndX = xPixel + 4;
                    _arrowLine[1].Width = 2;
                    break;
            }

            //设置光标颜色
            if (General.ArrowColor != _arrowLine[0].Color)
            {
                _arrowLine[0].Color = General.ArrowColor;
            }
            if (General.ArrowColor != _arrowLine[1].Color)
            {
                _arrowLine[1].Color = General.ArrowColor;
            }

            //设置显示光标
            //if (!_arrowLine[0].Show)
            //{
                _arrowLine[0].Show = General.OpenArrow;
            //}
            //if (!_arrowLine[1].Show)
            //{
                _arrowLine[1].Show = General.OpenArrow;
            //}
        }

        #endregion


        #region 键盘控制图形的放大和缩小

        /// <summary>
        /// 右边界减少宽度的1/10，图形放大
        /// </summary>
        public void ZoomOutOneTime()
        {

            if (this.IsArriveMinRange())
            {
                return;
            }

            _axsX.EndValue -= (this._axsX.EndValue - this._axsX.StartValue) / ZoomTimes;
            _area.RightValue = _axsX.EndValue;

            this.GetMarkerSize();
            this.UpdateArrow();
        }

        /// <summary>
        /// 是否达到图形的右边界
        /// </summary>
        /// <returns></returns>
        private bool IsPlotArriveEnd()
        {
            AvgPointDto dtoEnd = (AvgPointDto)_plot.arr[this._plot.arr.Count - 1];
            return (this._axsX.EndValue > dtoEnd.Moment) ? true : false;
        }

        /// <summary>
        /// 显示的时间范围是否达到最小范围
        /// </summary>
        /// <returns></returns>
        private bool IsArriveMinRange()
        {
            Double pixelCount = (this._axsX.EndValue - this._axsX.StartValue) * DefaultItem.SecondsPerMin;

            return (Convert.ToInt32(pixelCount) < MinShowTimeDistance) ? true : false;
        }

        /// <summary>
        /// 计算每个点显示需要的像素
        /// </summary>
        private void GetMarkerSize()
        {
            //每个点显示需要的像素
            Double pixelCount = 0;

            if (this._plot.ShowMarker)
            {
                // pixelCount = 总像素 / 点的总数 = 总像素 / （显示长度分钟 * 60 * 10 / 5）
                pixelCount = this._axsX.Length /
                    ((this._axsX.EndValue - this._axsX.StartValue) * DefaultItem.SecondsPerMin * General.Frequent / DefaultAnaly.PeakWide);

                this._plot.MarkerSize = (Convert.ToInt32(pixelCount) > MinShowTimeDistance) ? MinShowTimeDistance : Convert.ToInt32(pixelCount);
            }
        }

        /// <summary>
        /// 右边界增加宽度的1/10，图形缩小
        /// </summary>
        public void ZoomInOneTime()
        {
            if (this.IsPlotArriveEnd())
            {
                return;
            }

            _axsX.EndValue += (this._axsX.EndValue - this._axsX.StartValue) / ZoomTimes;
            _area.RightValue = _axsX.EndValue;

            this.GetMarkerSize();
            this.UpdateArrow();
        }

        /// <summary>
        /// 水平向右一个像素 (未放大情况下1个像素表示1点)
        /// </summary>
        public void MoveRightOnePixel()
        {
            if (this._plot.arr.Count > (this._arrayIndex + 1))
            {
                this._arrayIndex ++;
                this.CacuRange(true);
            }

            //double onePoint = Convert.ToSingle(1.0) 
            //    / Convert.ToSingle(General.Frequent) / Convert.ToSingle(OptionItem.SecondsPerMin);

            //_area.LeftValue += onePoint * General.MoveUnit;
            //_area.RightValue += onePoint * General.MoveUnit;

            //_axsX.StartValue += onePoint * General.MoveUnit;
            //_axsX.EndValue += onePoint * General.MoveUnit;
        }

        /// <summary>
        /// 水平向左一个像素 (未放大情况下1个像素表示1点)
        /// </summary>
        public void MoveLeftOnePixel()
        {
            //int xPixel = 0;
            //int yPixel = 0;

            if (0 <= (this._arrayIndex - 1))
            {
                this._arrayIndex--;
                this.CacuRange(true);
            }

            //double onePoint = Convert.ToSingle(1.0) 
            //    / Convert.ToSingle(General.Frequent) / Convert.ToSingle(OptionItem.SecondsPerMin);

            //_area.LeftValue -= onePoint * General.MoveUnit;
            //_area.RightValue -= onePoint * General.MoveUnit;

            //_axsX.StartValue -= onePoint * General.MoveUnit;
            //_axsX.EndValue -= onePoint * General.MoveUnit;
        }

        #endregion

    }
}
