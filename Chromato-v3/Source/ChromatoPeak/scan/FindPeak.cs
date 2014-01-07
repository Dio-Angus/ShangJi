/*-----------------------------------------------------------------------------
//  FILE NAME       : FindPeak.cs
//  FUNCTION        : 求峰的开始点,结束点
//  AUTHOR          : 蔡海鹰(2009/08/20)
//  CHANGE LOG      : 蔡海鹰(2009/09/22)添加了时间程序中锁定时间的处理DealLockTime
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.dto;
using System.Collections;
using ChromatoTool.ini;

namespace ChromatoPeak.scan
{
    /// <summary>
    /// 求峰的开始点,结束点
    /// </summary>
    class FindPeak
    {

        #region 常量

        /// <summary>
        /// 开始索引
        /// </summary>
        private const Int32 StartIndex = 0;

        /// <summary>
        /// 前峰结束点和后峰开始点合并范围(单位:点)
        /// </summary>
        private const Int32 MergeDistance = 2;

        #endregion


        #region 变量

        /// <summary>
        ///  平均 AvgPointDto 集合体
        /// </summary>
        private ArrayList _arrAvg { get; set; }

        /// <summary>
        ///  结果 PeakDto 集合体,输出列表
        /// </summary>
        private ArrayList _arrPeak { get; set; }

        /// <summary>
        ///  结果 YieldingPointDto 集合体,中间列表
        /// </summary>
        private ArrayList _arrYieldingPoint { get; set; }

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public FindPeak(ArrayList avg, ArrayList result)
        {
            this._arrAvg = avg;
            this._arrPeak = result;
            this._arrYieldingPoint = new ArrayList();
        }
        #endregion


        #region 方法

        /// <summary>
        /// 峰的开始点,结束点寻找
        /// </summary>
        /// <returns></returns>
        public bool Find()
        {
            this.GetPointStatus();
            this.GetAvgSlope();
            this.GetPeakTrend();

            this.FilterFlat();

            this.FindYielding();
            this.AssembleYield();
            this.MergeEndPoint();

            this.CacuReserveTime();

            this.DealLockTime();

            if (this._arrPeak.Count == 0)
                return false;
            return true;
        }

        /// <summary>
        /// 计算点的状态
        /// </summary>
        private void GetPointStatus()
        {
            AvgPointDto dtoCurrent = null;
            AvgPointDto dtoNext = null;

            for (int i = 0; i < this._arrAvg.Count - 1; i++)
            {
                dtoCurrent = (AvgPointDto)this._arrAvg[i];
                dtoNext = (AvgPointDto)this._arrAvg[i + 1];
                dtoCurrent.Slope = GeneralCacu.GetSlope(dtoCurrent, dtoNext);

                if (dtoCurrent.Slope > dtoCurrent.SettingSlope)
                {
                    dtoCurrent.StatusPoint = PointStatus.Up;
                }
                else if (dtoCurrent.Slope < (0 - dtoCurrent.SettingSlope))
                {
                    dtoCurrent.StatusPoint = PointStatus.Down;
                }
                else
                {
                    dtoCurrent.StatusPoint = PointStatus.Flat;
                }
            }
        }

        /// <summary>
        /// 计算平均斜率,开始4点无平均斜率 [1,2,3,4,5]
        /// </summary>
        private void GetAvgSlope()
        {
            AvgPointDto dtoBefore = null;
            AvgPointDto dtoCur = (AvgPointDto)this._arrAvg[0];
            int iCurIndex = 0;
            Single slope = 0;
            int iBeforeIndex = 0;

            while (iCurIndex < this._arrAvg.Count)
            {

                dtoCur = (AvgPointDto)this._arrAvg[iCurIndex];
                iBeforeIndex = iCurIndex - dtoCur.PeakWide + 1;
                if (0 > iBeforeIndex)
                {
                    iBeforeIndex = 0;
                }

                dtoBefore = (AvgPointDto)this._arrAvg[iBeforeIndex];

                slope = GeneralCacu.GetSlope(dtoBefore, dtoCur);

                if (slope > dtoCur.SettingSlope)
                {
                    dtoCur.StatusAvgSlope = AverageSlopeStatus.Up;
                }
                else if (slope < (0 - dtoCur.SettingSlope))
                {
                    dtoCur.StatusAvgSlope = AverageSlopeStatus.Down;
                }
                else
                {
                    dtoCur.StatusAvgSlope = AverageSlopeStatus.Flat;
                }
                iCurIndex++;
            }
        }

        /// <summary>
        /// 计算峰的趋势
        /// </summary>
        private void GetPeakTrend()
        {
            //当前点
            AvgPointDto dto = null;

            //前面的参考点
            AvgPointDto dtoBefore = null;

            int upCount = 0;
            int downCount = 0;
            int flatCount = 0;
            int iBeforeIndex = 0;


            for (int i = StartIndex; i < this._arrAvg.Count; i++)
            {
                dto = (AvgPointDto)this._arrAvg[i];

                upCount = 0;
                downCount = 0;
                flatCount = 0;

                if (40 <= i)
                {
                    ;
                }
                //求状态点的个数
                for (int j = 1; j <= dto.PeakWide; j++)
                {
                    iBeforeIndex = i - dto.PeakWide + j;
                    if (0 > iBeforeIndex)
                    {
                        iBeforeIndex = 0;
                    }
                    //if (0 > iBeforeIndex)
                    //{
                    //    iBeforeIndex = 0;
                    //}

                    dtoBefore = (AvgPointDto)this._arrAvg[iBeforeIndex];
                    switch (dtoBefore.StatusPoint)
                    {
                        case PointStatus.Up:
                            upCount++;
                            break;
                        case PointStatus.Down:
                            downCount++;
                            break;
                        case PointStatus.Flat:
                            flatCount++;
                            break;
                    }
                }

                //4号点
                iBeforeIndex = i - dto.PeakWide + 1;
                if (0 > iBeforeIndex)
                {
                    iBeforeIndex = 0;
                }
                dtoBefore = (AvgPointDto)this._arrAvg[iBeforeIndex];


                //满足三个条件，确定为上升趋势 (平均斜率，上升点的个数，前面第4点的状态)
                if (dto.StatusAvgSlope == AverageSlopeStatus.Up &&
                    (upCount > (downCount + flatCount)) &&
                    dtoBefore.StatusPoint == PointStatus.Up
                    )
                {
                    dto.TrendPeak = PeakTrend.Up;
                }
                //满足三个条件，确定为下降趋势 (平均斜率，下降点的个数，前面第4点的状态)
                else if (dto.StatusAvgSlope == AverageSlopeStatus.Down &&
                     (downCount > (upCount + flatCount)) &&
                     dtoBefore.StatusPoint == PointStatus.Down
                        )
                {
                    dto.TrendPeak = PeakTrend.Down;
                }
                //其余确定为平坦趋势
                else
                {
                    dto.TrendPeak = PeakTrend.Flat;
                }
            }
        }

        /// <summary>
        /// 把峰的平坦的趋势点变成上升或者下降趋势
        /// </summary>
        private void FilterFlat()
        {
            AvgPointDto dtoBefore = null;
            AvgPointDto dto = null;
            AvgPointDto dtoAfter = null;

            for (int i = StartIndex + 1; i < this._arrAvg.Count - 1; i++)
            {
                dtoBefore = (AvgPointDto)this._arrAvg[i - 1];
                dto = (AvgPointDto)this._arrAvg[i];
                dtoAfter = (AvgPointDto)this._arrAvg[i + 1];

                if (dtoBefore.TrendPeak == PeakTrend.Up && dtoAfter.TrendPeak == PeakTrend.Up && dto.TrendPeak == PeakTrend.Flat)
                {
                    dto.TrendPeak = PeakTrend.Up;
                }
                if (dtoBefore.TrendPeak == PeakTrend.Down && dtoAfter.TrendPeak == PeakTrend.Down && dto.TrendPeak == PeakTrend.Flat)
                {
                    dto.TrendPeak = PeakTrend.Down;
                }
            }
        }

        /// <summary>
        /// 确定可能是开始或者结束的拐点
        /// </summary>
        private void FindYielding()
        {
            AvgPointDto dto1 = null;
            AvgPointDto dto2 = null;
            YieldingPointDto dtoYield = null;

            //当前索引
            Int32 currentIndex = StartIndex;
            //前一个拐点的索引
            Int32 lastIndex = StartIndex;
           
            while (currentIndex <= (this._arrAvg.Count - 2))
            {
                if (40 <= currentIndex)
                {
                    ;
                }

                dto1 = (AvgPointDto)this._arrAvg[currentIndex];
                dto2 = (AvgPointDto)this._arrAvg[currentIndex + 1];

                if (PeakTrend.Down == dto1.TrendPeak && PeakTrend.Up == dto2.TrendPeak)
                {
                    dtoYield = new YieldingPointDto();
                    dtoYield.Index = this.GetYieldingAfter(ref currentIndex);
                    dtoYield.AttriYielding = YieldingAttri.StartEnd;
                    this._arrYieldingPoint.Add(dtoYield);
                    lastIndex = dtoYield.Index;
                }
                else if (PeakTrend.Flat == dto1.TrendPeak && PeakTrend.Up == dto2.TrendPeak)
                {
                    dtoYield = new YieldingPointDto();
                    dtoYield.Index = this.GetYieldingBefore(currentIndex, lastIndex);
                    dtoYield.AttriYielding = YieldingAttri.StartEnd;
                    this._arrYieldingPoint.Add(dtoYield);
                    lastIndex = dtoYield.Index;
                }
                else if (PeakTrend.Down == dto1.TrendPeak && PeakTrend.Flat == dto2.TrendPeak)
                {
                    dtoYield = new YieldingPointDto();
                    dtoYield.Index = this.GetYieldingAfter(ref currentIndex);
                    dtoYield.AttriYielding = YieldingAttri.StartEnd;
                    this._arrYieldingPoint.Add(dtoYield);
                    lastIndex = dtoYield.Index;
                }

                else if (PeakTrend.Flat == dto1.TrendPeak && PeakTrend.Down == dto2.TrendPeak)
                {
                    dtoYield = new YieldingPointDto();
                    dtoYield.Index = currentIndex;
                    dtoYield.AttriYielding = YieldingAttri.Top;
                    this._arrYieldingPoint.Add(dtoYield);
                    lastIndex = dtoYield.Index;

                }
                else if (PeakTrend.Up == dto1.TrendPeak && PeakTrend.Down == dto2.TrendPeak)
                {
                    dtoYield = new YieldingPointDto();
                    dtoYield.Index = currentIndex;
                    dtoYield.AttriYielding = YieldingAttri.Top;
                    this._arrYieldingPoint.Add(dtoYield);
                    lastIndex = dtoYield.Index;

                }
                else if (PeakTrend.Up == dto1.TrendPeak && PeakTrend.Flat == dto2.TrendPeak)
                {
                    dtoYield = new YieldingPointDto();
                    dtoYield.Index = currentIndex;
                    dtoYield.AttriYielding = YieldingAttri.Top;
                    this._arrYieldingPoint.Add(dtoYield);
                    lastIndex = dtoYield.Index;
                }


                //累加索引
                currentIndex++;
            }
        }

        /// <summary>
        /// 向前推10个点，作为拐点
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <param name="lastIndex"></param>
        /// <returns></returns>
        private int GetYieldingBefore(int currentIndex, int lastIndex)
        {
 
            AvgPointDto dtoAvg = null;
            Single minVoltage = 0;
            int index = 0;
            int iBeforeIndex = 0;

            //缺省前方第5点
            dtoAvg = (AvgPointDto)this._arrAvg[currentIndex];
            index = currentIndex - 2 * dtoAvg.PeakWide + 1 ;
            if (0 > index)
            {
                index = 0;
            }
            minVoltage = dtoAvg.Voltage;

            
            //无上升点，电压值最小
            for (int i = (currentIndex - 2 * dtoAvg.PeakWide + 1); i < (currentIndex - dtoAvg.PeakWide + 1); i++)
            {
                if (i < 0)
                {
                    iBeforeIndex = 0;
                }
                else
                {
                    iBeforeIndex = i;
                }
                dtoAvg = (AvgPointDto)this._arrAvg[iBeforeIndex];

                if (dtoAvg.TrendPeak != PeakTrend.Up)
                {
                    if (minVoltage > dtoAvg.Voltage)
                    {
                        minVoltage = dtoAvg.Voltage;
                        index = iBeforeIndex;
                    }
                }
            }
            
            //如果超过前方拐点,那么设置为前方拐点的后一点
            if (index <= lastIndex)
            {
                index = lastIndex + 1;
            }
            return index;
        }

        /// <summary>
        /// 向后推5个点，作为拐点
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <returns></returns>
        private int GetYieldingAfter(ref int currentIndex)
        {

            AvgPointDto dtoAvg = null;
            Single minVoltage = 0;

            //缺省为当前点
            dtoAvg = (AvgPointDto)this._arrAvg[currentIndex];
            int indexStart = (this._arrAvg.Count < currentIndex) ? this._arrAvg.Count : currentIndex;
            int indexEnd = (this._arrAvg.Count < (currentIndex + dtoAvg.PeakWide)) ? this._arrAvg.Count : (currentIndex + dtoAvg.PeakWide);
            dtoAvg = (AvgPointDto)this._arrAvg[indexStart];
 
            minVoltage = dtoAvg.Voltage;

            //无上升点，电压值最小
            for (int i = indexStart; i < indexEnd; i++)
            {
                dtoAvg = (AvgPointDto)this._arrAvg[i];
                if (dtoAvg.TrendPeak != PeakTrend.Up)
                {
                    if (minVoltage > dtoAvg.Voltage)
                    {
                        minVoltage = dtoAvg.Voltage;
                        currentIndex = i;
                    }
                }
            }

            return currentIndex;
        }

        /// <summary>
        /// 组合拐点成峰（只有两种特征：开始结束点，顶点）
        /// </summary>
        private void AssembleYield()
        {
            PeakDto dtoPeak = null;
            AvgPointDto dtoAvg = null;

            //峰识别步骤
            IdentifyStep step = IdentifyStep.Start;

            foreach (YieldingPointDto dto in this._arrYieldingPoint)
            {
                if (229 <= dto.Index)
                {
                    ;
                }

                switch (step)
                {
                    case IdentifyStep.Start:
                        //符合开始结束点特征
                        if (dto.AttriYielding == YieldingAttri.StartEnd)
                        {
                            dtoPeak = new PeakDto();
                            dtoPeak.StartPointIndex = dto.Index;
                            step = IdentifyStep.Top;
                        }
                        break;

                    case IdentifyStep.Top:
                        //符合顶点特征
                        if (dto.AttriYielding == YieldingAttri.Top)
                        {
                            dtoPeak.TopPointIndex = dto.Index;
                            dtoPeak.ReserveTime = ((AvgPointDto)this._arrAvg[dtoPeak.TopPointIndex]).Moment;
                            step = IdentifyStep.End;
                        }
                        else
                        {
                            dtoPeak.StartPointIndex = dto.Index;
                        }
                        break;

                    case IdentifyStep.End:
                        if (dto.AttriYielding == YieldingAttri.StartEnd)
                        {
                            //符合开始结束点特征
                            dtoAvg = (AvgPointDto)this._arrAvg[dto.Index];
                            //if ((dto.Index - dtoAvg.PeakWide) > dtoPeak.TopPointIndex)
                            //{
                            dtoPeak.EndPointIndex = dto.Index;
                            dtoPeak.PeakID = this._arrPeak.Count + 1;
                            this._arrPeak.Add(dtoPeak);

                            dtoPeak = new PeakDto();
                            dtoPeak.StartPointIndex = dto.Index;
                            step = IdentifyStep.Top;
                            //}
                        }
                        else
                        {
                            dtoPeak.TopPointIndex = dto.Index;

                            //int temp = dtoPeak.TopPointIndex;
                            //Single volTop = ((AvgPointDto)this._arrAvg[temp]).Voltage;

                            ////和前面一个最高点比较这段范围内的最高电压点，重新设置保留时间
                            //for (int i = temp; i < dto.Index; i++)
                            //{
                            //    AvgPointDto dtoTop = (AvgPointDto)this._arrAvg[i];
                            //    if (volTop < dtoTop.Voltage)
                            //    {
                            //        volTop = dtoTop.Voltage;
                            //        dtoPeak.ReserveTime = dtoTop.Moment;
                            //        dtoPeak.TopPointIndex = i;
                            //   }
                            //}
                        }
                        break;
                }

            }
        }

        /// <summary>
        /// 合并相近的结束点和开始点
        /// </summary>
        private void MergeEndPoint()
        {
            PeakDto dtoCur = null;
            PeakDto dtoNext = null;

            for (int i = 0; i < this._arrPeak.Count - 1; i++)
            {
                dtoCur = (PeakDto)this._arrPeak[i];
                dtoNext = (PeakDto)this._arrPeak[i + 1];
                if ((dtoNext.StartPointIndex - dtoCur.EndPointIndex) <= MergeDistance && (dtoNext.StartPointIndex > dtoCur.EndPointIndex))
                {
                    AvgPointDto dtoAvg = (AvgPointDto)this._arrAvg[dtoCur.EndPointIndex];
                    Single minVol = dtoAvg.Voltage;
                    int index = dtoCur.EndPointIndex;

                    for (int j = dtoCur.EndPointIndex + 1; j <= dtoNext.StartPointIndex; j++)
                    {
                        dtoAvg = (AvgPointDto)this._arrAvg[j];
                        if (minVol > dtoAvg.Voltage)
                        {
                            minVol = dtoAvg.Voltage;
                            index = j;
                        }
                    }

                    dtoCur.EndPointIndex = index;
                    dtoNext.StartPointIndex = index;
                }
            }
        }

        /// <summary>
        /// 重新校正保留时间（最高点）
        /// </summary>
        private void CacuReserveTime()
        {
            AvgPointDto dtoAvg = null;
            Single maxVol = 0;

            foreach (PeakDto dto in this._arrPeak)
            {
                dtoAvg = (AvgPointDto)this._arrAvg[dto.StartPointIndex];
                maxVol = dtoAvg.Voltage;

                for (int i = dto.StartPointIndex; i < dto.EndPointIndex; i++)
                {
                    dtoAvg = (AvgPointDto)this._arrAvg[i];
                    if (maxVol < dtoAvg.Voltage)
                    {
                        maxVol = dtoAvg.Voltage;
                        dto.ReserveTime = dtoAvg.Moment;
                        dto.TopPointIndex = i;
                    }
                }
            }
        }

        /// <summary>
        /// 处理时间程序中的锁定时间
        /// </summary>
        private void DealLockTime()
        {
            //某点信息
            AvgPointDto dtoAvg = null;

            //删除列表
            ArrayList arrDelete = new ArrayList();

            //查找是否存在锁定时间范围内的峰
            foreach (PeakDto dto in this._arrPeak)
            {
                dtoAvg = (AvgPointDto)this._arrAvg[dto.TopPointIndex];

                //如果顶点为On,则删除
                if (dtoAvg.isTimeLock)
                {
                    arrDelete.Add(dto);
                    continue;
                }
                else
                {
                    //开始点是否向后移动
                    for (int i = dto.TopPointIndex - 1; i >= dto.StartPointIndex; i--)
                    {
                        dtoAvg = (AvgPointDto)this._arrAvg[i];

                        if (dtoAvg.isTimeLock)
                        {
                            //移动该峰的终点
                            dto.StartPointIndex = i;
                            break;
                        }
                    }

                    //结束点是否向前移动
                    for (int i = dto.TopPointIndex + 1; i <= dto.EndPointIndex; i++)
                    {
                        dtoAvg = (AvgPointDto)this._arrAvg[i];

                        //第一个Off-->On点
                        if (dtoAvg.isTimeLock)
                        {
                            //移动该峰的终点
                            dto.EndPointIndex = i;
                            break;
                        }
                    }
                }
            }

            //从列表中移除
            foreach (PeakDto dtoDel in arrDelete)
            {
                foreach (PeakDto dto in this._arrPeak)
                {
                    if (dtoDel.PeakID == dto.PeakID)
                    {
                        this._arrPeak.Remove(dto);
                        break;
                    }
                }
            }
        }

        #endregion


    }
}
