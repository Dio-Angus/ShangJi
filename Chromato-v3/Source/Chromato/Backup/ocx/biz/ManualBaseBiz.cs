/*-----------------------------------------------------------------------------
//  FILE NAME       : ManualBaseBiz.cs
//  FUNCTION        : 手动画水平基线
//  AUTHOR          : 李锋(2009/08/14)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


using System;
using ChromatoBll.ocx.item;
using ChromatoTool.util;
using System.Drawing;
using ChromatoTool.dto;
using System.Collections;

namespace ChromatoBll.ocx.biz
{
    /// <summary>
    /// 手动画水平基线
    /// </summary>
    public class ManualBaseBiz
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
        /// 水平基线直线item
        /// </summary>
        public LineImp _baseLine { get; set; }

        /// <summary>
        /// 是否开始放大缩小处理
        /// </summary>
        private Boolean _isStartManual = false;

        /// <summary>
        /// 曲线
        /// </summary>
        public PlotImp _plot { get; set; }

        /// <summary>
        /// 新增加的峰,水平基线手动增加的PeakDto
        /// </summary>
        private PeakDto _newPeakDto { get; set; }

        #endregion
        

        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public ManualBaseBiz()
        {
        }

        #endregion


        #region 方法

        /// <summary>
        /// 开始水平基线的处理
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="startIndex"></param>
        /// <param name="isDown"></param>
        /// <param name="voltage"></param>
        public void StartBaseline(Int32 X, Int32 Y, Int32 startIndex, bool isDown, Single voltage)
        {
            this._baseLine.StartX = X;
            this._baseLine.EndX = X;
            this._baseLine.StartY = Y;
            this._baseLine.EndY = Y;
            this._baseLine.Color = CastColor.GetCustomColor(Color.Red);
            this._baseLine.Show = true;

            this._isStartManual = true;
            this._newPeakDto = new PeakDto();
            this._newPeakDto.StartPointIndex = startIndex;
            this._newPeakDto.IsStartDown = isDown;
            this._newPeakDto.StartVoltage = voltage;
        }

        /// <summary>
        /// 水平基线的动态变化处理
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void MoveBaseline(Int32 X, Int32 Y)
        {
            if (!this._isStartManual)
            {
                return;
            }

            this._baseLine.EndX = X;
            this._baseLine.EndY = Y;
        }

        /// <summary>
        /// 水平基线的结束处理
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="endIndex"></param>
        /// <param name="isDown"></param>
        /// <param name="voltage"></param>
        public void StopBaseline(Int32 X, Int32 Y, Int32 endIndex, bool isDown, Single voltage)
        {
            Int32 tempIndex = this._newPeakDto.StartPointIndex;
            bool tempDown = this._newPeakDto.IsStartDown;
            Single tempVoltage = this._newPeakDto.StartVoltage;

            if (this._isStartManual)
            {
                _isStartManual = false;

                //测试竖线
                this._baseLine.EndX = X;
                this._baseLine.EndY = Y;
                this._baseLine.Show = false;

                //起点大于终点,反方向画
                if (this._newPeakDto.StartPointIndex > endIndex)
                {
                    this._newPeakDto.StartPointIndex = endIndex;
                    this._newPeakDto.EndPointIndex = tempIndex;

                    this._newPeakDto.IsStartDown = isDown;
                    this._newPeakDto.IsEndDown = tempDown;

                    this._newPeakDto.StartVoltage = voltage;
                    this._newPeakDto.EndVoltage = tempVoltage;
                }
                else// 起点小于终点,正方向画
                {
                    this._newPeakDto.EndPointIndex = endIndex;
                    this._newPeakDto.IsEndDown = isDown;
                    this._newPeakDto.EndVoltage = voltage;
                }
            }
        }

        /// <summary>
        /// 添加新的峰
        /// </summary>
        /// <param name="arrPeak"></param>
        /// <returns></returns>
        public PeakDto AddNewPeak(ArrayList arrPeak)
        {

            //求PeakID
            foreach (PeakDto dto in arrPeak)
            {
                if (this._newPeakDto.PeakID <= dto.PeakID)
                {
                    this._newPeakDto.PeakID = dto.PeakID + 1;
                }
            }

            //求开始点，结束点
            AvgPointDto dtoAvg = null;
            this._newPeakDto.StartPointCloseIndex = this._newPeakDto.StartPointIndex;
            this._newPeakDto.EndPointCloseIndex = this._newPeakDto.EndPointIndex;
            this._newPeakDto.IsManual = true;

            AvgPointDto dtoStartAvg = (AvgPointDto)this._plot.arr[this._newPeakDto.StartPointIndex];
            this._newPeakDto.StartMoment = dtoStartAvg.Moment;
            Single max = dtoStartAvg.Voltage;

            AvgPointDto dtoEndAvg = (AvgPointDto)this._plot.arr[this._newPeakDto.EndPointIndex];
            this._newPeakDto.EndMoment = dtoEndAvg.Moment;

            //求保留时间，顶点
            for (int i = this._newPeakDto.StartPointIndex + 1; i < this._newPeakDto.EndPointIndex; i++)
            {
                dtoAvg = (AvgPointDto)this._plot.arr[i];
                if (max < dtoAvg.Voltage)
                {
                    this._newPeakDto.ReserveTime = dtoAvg.Moment;
                    this._newPeakDto.TopPointIndex = i;
                    max = dtoAvg.Voltage;
                }
            }
            return this._newPeakDto;
        }

        /// <summary>
        /// 取得手动峰起点,基线开始点在arrayAvg中的index
        /// </summary>
        /// <returns></returns>
        public Int32 GetStartIndex()
        {
            return this._newPeakDto.StartPointIndex;
        }

        /// <summary>
        /// 取得手动峰终点,基线结束点在arrayAvg中的index
        /// </summary>
        /// <returns></returns>
        public Int32 GetEndIndex()
        {
            return this._newPeakDto.EndPointIndex;
        }

        #endregion



    }
}
