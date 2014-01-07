/*-----------------------------------------------------------------------------
//  FILE NAME       : VerticalSplitBiz.cs
//  FUNCTION        : 垂直切割基线
//  AUTHOR          : 李锋(2009/08/20)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoBll.ocx.item;
using ChromatoTool.dto;
using System.Collections;

namespace ChromatoBll.ocx.biz
{
    /// <summary>
    /// 垂直切割基线
    /// </summary>
    public class VerticalSplitBiz
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
        /// 曲线
        /// </summary>
        public PlotImp _plot { get; set; }

        #endregion
        

        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public VerticalSplitBiz()
        {
        }

        #endregion


        #region 方法

        /// <summary>
        /// 根据切割峰求出新的峰并更新切割峰
        /// y = k * x + b
        /// k = (y2-y1)/(x2-x1)
        /// b = y2 - k * x2
        /// </summary>
        /// <param name="splitDtoPeak">待切割峰</param>
        /// <param name="arrPeak">峰列表</param>
        /// <param name="index">分割点</param>
        /// <returns>新的峰</returns>
        public PeakDto SplitPeak(PeakDto splitDtoPeak, ArrayList arrPeak, int index)
        {
            AvgPointDto dto1 = (AvgPointDto)this._plot.arr[splitDtoPeak.StartPointIndex];
            AvgPointDto dto2 = (AvgPointDto)this._plot.arr[splitDtoPeak.EndPointIndex];
            AvgPointDto dtoAvgSplit = (AvgPointDto)this._plot.arr[index];

            float k = 0;
            float b = 0;

            //起始点都在曲线上
            if (!splitDtoPeak.IsStartDown && !splitDtoPeak.IsEndDown)
            {
                k = (dto2.Voltage - dto1.Voltage) / (dto2.Moment - dto1.Moment);
                b = dto2.Voltage - k * dto2.Moment;
            }
            //起点在曲线上，终点在曲线下方
            else if (!splitDtoPeak.IsStartDown && splitDtoPeak.IsEndDown)
            {
                k = (splitDtoPeak.EndVoltage - dto1.Voltage) / (dto2.Moment - dto1.Moment);
                b = splitDtoPeak.EndVoltage - k * dto2.Moment;
            }
            //起点在曲线下方，终点在曲线上
            else if (splitDtoPeak.IsStartDown && !splitDtoPeak.IsEndDown)
            {
                k = (dto2.Voltage - splitDtoPeak.StartVoltage) / (dto2.Moment - dto1.Moment);
                b = dto2.Voltage - k * dto2.Moment;
            }
            //起始点都在曲线下方
            else if (splitDtoPeak.IsStartDown && splitDtoPeak.IsEndDown)
            {
                k = (splitDtoPeak.EndVoltage - splitDtoPeak.StartVoltage) / (dto2.Moment - dto1.Moment);
                b = splitDtoPeak.EndVoltage - k * dto2.Moment;
            }

            //创建新的峰
            PeakDto newDtoPeak = new PeakDto();

            //求开始点,结束点,积分结束点
            newDtoPeak.StartPointIndex = index;
            newDtoPeak.StartPointCloseIndex = index;
            newDtoPeak.EndPointIndex = splitDtoPeak.EndPointIndex;
            newDtoPeak.EndPointCloseIndex = newDtoPeak.EndPointIndex;

            //设置是否手动处理的标志
            newDtoPeak.IsManual = true;

            //求开始点电压等
            newDtoPeak.IsStartDown = true;
            newDtoPeak.StartVoltage = k * dtoAvgSplit.Moment + b;

            //求结束点电压等
            newDtoPeak.IsEndDown = true;
            newDtoPeak.EndVoltage = splitDtoPeak.EndVoltage;

            //求开始点时间
            AvgPointDto dtoAvg = (AvgPointDto)this._plot.arr[newDtoPeak.StartPointIndex];
            newDtoPeak.StartMoment = dtoAvg.Moment;

            //求结束点时间
            dtoAvg = (AvgPointDto)this._plot.arr[newDtoPeak.EndPointIndex];
            newDtoPeak.EndMoment = dtoAvg.Moment;

            //求PeakID
            foreach (PeakDto dto in arrPeak)
            {
                if (newDtoPeak.PeakID <= dto.PeakID)
                {
                    newDtoPeak.PeakID = dto.PeakID + 1;
                }
            }

            //求保留时间，顶点
            Single max = dtoAvgSplit.Voltage;
            for (int i = newDtoPeak.StartPointIndex + 1; i < newDtoPeak.EndPointIndex; i++)
            {
                dtoAvg = (AvgPointDto)this._plot.arr[i];
                if (max < dtoAvg.Voltage)
                {
                    newDtoPeak.ReserveTime = dtoAvg.Moment;
                    newDtoPeak.TopPointIndex = i;
                    max = dtoAvg.Voltage;
                }
            }

            //修改老的峰,结束点,积分结束点
            splitDtoPeak.EndPointIndex = index;
            splitDtoPeak.EndPointCloseIndex = index;
            splitDtoPeak.IsEndDown = true;
            splitDtoPeak.EndVoltage = newDtoPeak.StartVoltage;

            //设置是否手动处理的标志
            splitDtoPeak.IsManual = true;

            //求开始点时间
            dtoAvg = (AvgPointDto)this._plot.arr[splitDtoPeak.StartPointIndex];
            splitDtoPeak.StartMoment = dtoAvg.Moment;

            //求结束点时间
            dtoAvg = (AvgPointDto)this._plot.arr[splitDtoPeak.EndPointIndex];
            splitDtoPeak.EndMoment = dtoAvg.Moment;

            //重新求保留时间，顶点
            max = dto1.Voltage;
            for (int i = splitDtoPeak.StartPointIndex + 1; i < splitDtoPeak.EndPointIndex; i++)
            {
                dtoAvg = (AvgPointDto)this._plot.arr[i];
                if (max < dtoAvg.Voltage)
                {
                    splitDtoPeak.ReserveTime = dtoAvg.Moment;
                    splitDtoPeak.TopPointIndex = i;
                    max = dtoAvg.Voltage;
                }
            }

            return newDtoPeak;
        }

        #endregion




    }
}
