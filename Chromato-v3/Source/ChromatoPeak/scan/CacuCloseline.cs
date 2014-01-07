/*-----------------------------------------------------------------------------
//  FILE NAME       : CacuCloseline.cs
//  FUNCTION        : 计算峰的闭合线
//  AUTHOR          : 蔡海鹰(2009/08/25)
//  CHANGE LOG      : 蔡海鹰(2009/09/23)添加了时间程序中锁定基线的处理DealLockBaseline
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Collections;
using ChromatoTool.dto;
using ChromatoTool.ini;

namespace ChromatoPeak.scan
{
    /// <summary>
    /// 计算峰的闭合线
    /// </summary>
    class CacuCloseline
    {


        #region 常量

        /// <summary>
        /// 电压差(曲线上的点和直线上的点的电压差)
        /// </summary>
        private const double VoltageDistance = 0.001;

        #endregion


        #region 变量

        /// <summary>
        ///  平均 AvgPointDto 集合体
        /// </summary>
        private ArrayList _arrAvg { get; set; }

        /// <summary>
        /// 峰外层分组列表，结果 PeakDto 集合体，ArrayList嵌套
        /// </summary>
        private ArrayList _arrGroup { get; set; }

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public CacuCloseline(ArrayList avg, ArrayList group)
        {
            this._arrAvg = avg;
            this._arrGroup = group;
        }
        
        #endregion


        #region 方法

        /// <summary>
        /// 设置闭合线
        /// </summary>
        public void Cacu()
        {
            foreach (ArrayList arr in this._arrGroup)
            {
                //设置一组内峰的闭合线
                this.CacuLine(arr);

                //处理时间程序中的锁定基线
                this.DealLockBaseline(arr);

                //处理时间程序中的水平基线
                this.DealHoriBaseline(arr);
            }
        }

        /// <summary>
        /// 设置一组内峰的闭合线
        /// </summary>
        /// <param name="arr"></param>
        private void CacuLine(ArrayList arr)
        {

            //组内第一个峰
            PeakDto dtoStart = (PeakDto)arr[0];
            //组内最后一个峰
            PeakDto dtoEnd = (PeakDto)arr[arr.Count - 1];

            //组内第一个峰的起点
            AvgPointDto dtoGroupStart = (AvgPointDto)this._arrAvg[dtoStart.StartPointIndex];
            //组内最后一个峰的结束点
            AvgPointDto dtoGroupEnd = (AvgPointDto)this._arrAvg[dtoEnd.EndPointIndex];

            //y = kx + b;
            float k = Convert.ToSingle(
                (dtoGroupEnd.Voltage - dtoGroupStart.Voltage) / (dtoGroupEnd.Moment - dtoGroupStart.Moment));
            float b = Convert.ToSingle(dtoGroupEnd.Voltage - dtoGroupEnd.Moment * k);

            PeakDto dto = null;

            int currentIndex = 0;
            while( currentIndex < arr.Count )
            {
                dto = (PeakDto)arr[currentIndex];
                if (dto.IsManual) //如果手动处理
                {
                    currentIndex++;
                    continue;
                }

                switch (dto.PeakType)
                {
                    case TypeOfPeak.Main:
                        this.GetMainLine(dto, currentIndex, k, b, arr);
                        currentIndex++;
                        break;

                    case TypeOfPeak.Overlap:
                        this.GetMainLine(dto, currentIndex, k, b, arr);
                        currentIndex++;
                        break;

                    case TypeOfPeak.Tail:
                        this.GetTailLine(dto, ref currentIndex, arr);
                        break;
                }
            }
        }

        /// <summary>
        /// 取得拖尾峰的下部闭合线
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="currentIndex"></param>
        /// <param name="arr"></param>
        private void GetTailLine(PeakDto dto, ref int currentIndex, ArrayList arr)
        {
            PeakDto dtoPeak = null;
            int endIndex = currentIndex;

            //找到连续拖尾峰的最后一个索引
            for (int i = currentIndex; i < arr.Count; i++)
            {
                dtoPeak = (PeakDto)arr[i];
                if (TypeOfPeak.Tail.Equals(dtoPeak.PeakType))
                {
                    endIndex = i;
                }
                else
                {
                    break;
                }
            }

            this.GetContinuousTailLine(currentIndex, endIndex, arr);
            currentIndex = endIndex + 1;

        }

        /// <summary>
        /// 计算连续拖尾峰的下部闭合线
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="arr"></param>
        private void GetContinuousTailLine(int currentIndex, int endIndex, ArrayList arr)
        {

            //连续拖尾峰内第一个峰
            PeakDto dtoStart = (PeakDto)arr[currentIndex];
            //连续拖尾峰内最后一个峰
            PeakDto dtoEnd = (PeakDto)arr[endIndex];

            //连续拖尾峰内第一个峰的起点
            AvgPointDto dtoContinuousStart = (AvgPointDto)this._arrAvg[dtoStart.StartPointIndex];
            //连续拖尾峰内最后一个峰的结束点
            AvgPointDto dtoContinuousEnd = (AvgPointDto)this._arrAvg[dtoEnd.EndPointIndex];

            //y = kx + b;
            float k = Convert.ToSingle(
                (dtoContinuousEnd.Voltage - dtoContinuousStart.Voltage) / (dtoContinuousEnd.Moment - dtoContinuousStart.Moment));
            float b = Convert.ToSingle(dtoContinuousEnd.Voltage - dtoContinuousEnd.Moment * k);

            PeakDto dto = null;
            Single voltage = 0;
            AvgPointDto dtoAvg = null;

            for (int i = currentIndex; i <= endIndex; i++)
            {
                dto = (PeakDto)arr[i];
                
                dtoAvg = (AvgPointDto)this._arrAvg[dto.StartPointIndex];
                voltage = k * dtoAvg.Moment + b;
                dto.StartMoment = dtoAvg.Moment;

                dto.IsStartDown = (dtoAvg.Voltage - voltage) > VoltageDistance ? true : false;
                dto.StartVoltage = (dto.IsStartDown) ? voltage : dtoAvg.Voltage;
                
                dtoAvg = (AvgPointDto)this._arrAvg[dto.EndPointIndex];
                voltage = k * dtoAvg.Moment + b;
                dto.EndMoment = dtoAvg.Moment;

                //峰的结束点在倾斜线的下方
                if ((voltage - dtoAvg.Voltage) > VoltageDistance && (endIndex > currentIndex))
                {
                    dto.IsEndDown = false;
                    dto.EndVoltage = dtoAvg.Voltage;

                    //递归
                    this.GetContinuousTailLine(i + 1, endIndex, arr);
                    break;
                }
                else
                {
                    dto.IsEndDown = true;
                    dto.EndVoltage = voltage;
                }
            }
        }

        /// <summary>
        /// 取得主峰或者重叠峰的下部闭合线
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="currentIndex"></param>
        /// <param name="k"></param>
        /// <param name="b"></param>
        /// <param name="arr"></param>
        private void GetMainLine(PeakDto dto, int currentIndex, float k, float b, ArrayList arr)
        {
            PeakDto dtoPeak = null;
            Single voltage = 0;
            AvgPointDto dtoAvg = null;
            bool bHasTail = false;

            dtoAvg = (AvgPointDto)this._arrAvg[dto.StartPointIndex];
            dto.StartMoment = dtoAvg.Moment;
            voltage = k * dtoAvg.Moment + b;

            dto.IsStartDown = (dtoAvg.Voltage - voltage) > VoltageDistance ? true : false;
            dto.StartVoltage = (dto.IsStartDown) ? voltage : dtoAvg.Voltage;

            for (int i = (currentIndex + 1); i < arr.Count; i++)
            {
                dtoPeak = (PeakDto)arr[i];
                if (TypeOfPeak.Tail.Equals(dtoPeak.PeakType))
                {
                    bHasTail = true;
                }
                else
                {
                    dtoPeak = (PeakDto)arr[i-1];
                    break;
                }
            }

            dtoAvg = (bHasTail) ? (AvgPointDto)this._arrAvg[dtoPeak.EndPointIndex] : 
                (AvgPointDto)this._arrAvg[dto.EndPointIndex];

            voltage = k * dtoAvg.Moment + b;
            dto.EndMoment = dtoAvg.Moment;

            dto.IsEndDown = ((dtoAvg.Voltage - voltage) > VoltageDistance) ? true : false;
            dto.EndVoltage = (dto.IsEndDown) ? voltage : dtoAvg.Voltage;

        }

        /// <summary>
        /// 处理时间程序中的锁定基线
        /// </summary>
        /// <param name="arr"></param>
        private void DealLockBaseline(ArrayList arr)
        {

            //某个点信息
            AvgPointDto dtoAvg = null;
            
            //查找某个峰是否在锁定时间范围
            foreach (PeakDto dto in arr)
            {
                dtoAvg = (AvgPointDto)this._arrAvg[dto.StartPointIndex];

                //某个峰开始点的锁定基线状态为On
                if (dtoAvg.isBaselineLock)
                {
                    DealWithStartOn(dto);
                }

                dtoAvg = (AvgPointDto)this._arrAvg[dto.EndPointIndex];

                //某个峰结束点的锁定基线状态为On
                if (dtoAvg.isBaselineLock)
                {
                    DealWithEndOn(dto, dtoAvg);
                }
            }
        }

        /// <summary>
        /// 开始点的锁定基线状态On
        /// </summary>
        /// <param name="dto"></param>
        private void DealWithStartOn(PeakDto dto)
        {

            //某点信息
            AvgPointDto dtoAvg = null;

            //基线前方on->off点
            AvgPointDto dtoOff = null;

            //基线前方参考点
            AvgPointDto dtoRef = null;

            for (int i = dto.StartPointIndex - 1; i >= 0; i--)
            {
                dtoAvg = (AvgPointDto)this._arrAvg[i];

                //确定参考点,取得参考点电压
                if (!dtoAvg.isBaselineLock)
                {
                    dtoOff = dtoAvg;
                    break;
                }
            }

            this.IsInPeak(ref dtoRef, dtoOff);

            //本峰上升途中是否存在On-off
            bool bHasOff = false;
            for (int i = dto.StartPointIndex + 1; i <= dto.TopPointIndex; i++)
            {
                dtoAvg = (AvgPointDto)this._arrAvg[i];
                if (!dtoAvg.isBaselineLock)
                {
                    bHasOff = true;
                    break;
                }
            }

            //如果上升途中存在On-off,扫描结束点为dtoAvg,否则为顶点
            AvgPointDto dtoScanEnd = bHasOff ? dtoAvg : (AvgPointDto)this._arrAvg[dto.TopPointIndex];

            //开始点信息
            AvgPointDto dtoScanStart = (AvgPointDto)this._arrAvg[dto.StartPointIndex];

            //参考点不在范围内 (扫描开始点，扫描结束点)，认为不完全进入
            if (dtoScanStart.Voltage > dtoRef.Voltage || dtoRef.Voltage > dtoScanEnd.Voltage)
            {
                return;
            }

            //电压距离差
            Single minDistance = Math.Abs(dtoScanStart.Voltage - dtoRef.Voltage);
 
            //在上升过程中寻找一个电压接近参考电压的点
            for (int i = dto.StartPointIndex + 1; i <= dtoScanEnd.Index; i++)
            {
                dtoAvg = (AvgPointDto)this._arrAvg[i];

                //修正积分开始时间和索引
                if (minDistance > Math.Abs(dtoAvg.Voltage - dtoRef.Voltage))
                {
                    dtoScanStart = dtoAvg;
                    minDistance = Math.Abs(dtoAvg.Voltage - dtoRef.Voltage);
                }
            }

            //是否完全进入
            //if (dtoOff.Voltage > dtoRef.Voltage)
            //{
                dto.StartPointCloseIndex = dtoScanStart.Index;
                dto.StartMoment = dtoScanStart.Moment;
                dto.StartVoltage = dtoScanStart.Voltage;
                dto.IsStartDown  = false;
            //}
        }

        /// <summary>
        /// 取的参考点
        /// 该点是否在峰内,如果在峰内,取开始点作为参考点
        /// 如果不在峰内,取该变化点作为参考点
        /// </summary>
        /// <param name="dtoRef">参考点</param>
        /// <param name="dtoOff">变化点</param>
        private void IsInPeak(ref AvgPointDto dtoRef, AvgPointDto dtoOff)
        {
            foreach (ArrayList arr in this._arrGroup)
            {
                foreach (PeakDto dto in arr)
                {
                    if (dto.StartPointIndex <= dtoOff.Index && dtoOff.Index <= dto.EndPointIndex)
                    {
                        dtoRef = (AvgPointDto)this._arrAvg[dto.StartPointIndex];
                        return;
                    }
                }
            }

            dtoRef = dtoOff;
        }

        /// <summary>
        /// 结束点的锁定基线状态On
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="dtoStart"></param>
        private void DealWithEndOn(PeakDto dto, AvgPointDto dtoStart)
        {

            //某点信息
            AvgPointDto dtoAvg = null;

            //基线前方on->off点
            AvgPointDto dtoOff = null;

            //基线前方参考点
            AvgPointDto dtoRef = null;

            //寻找Off点
            for (int i = dto.EndPointIndex - 1; i >= 0; i--)
            {
                dtoAvg = (AvgPointDto)this._arrAvg[i];

                //确定参考点,取得参考点电压
                if (!dtoAvg.isBaselineLock)
                {
                    dtoOff = dtoAvg;
                    break;
                }
            }

            this.IsInPeak(ref dtoRef, dtoOff);

            //本峰上升途中是否存在On-off
            bool bHasOff = false;
            for (int i = dto.TopPointIndex + 1; i <= dto.EndPointIndex; i++)
            {
                dtoAvg = (AvgPointDto)this._arrAvg[i];
                if (!dtoAvg.isBaselineLock)
                {
                    bHasOff = true;
                    break;
                }
            }

            //如果上升途中存在On-off,扫描开始点为dtoAvg,否则为顶点
            AvgPointDto dtoScanStart = bHasOff ? dtoAvg : (AvgPointDto)this._arrAvg[dto.TopPointIndex];

            //结束点信息
            AvgPointDto dtoScanEnd = (AvgPointDto)this._arrAvg[dto.EndPointIndex];

            //参考点不在范围内 (扫描开始点，扫描结束点)，认为不完全进入
            if (!(dtoScanStart.Voltage > dtoRef.Voltage && dtoRef.Voltage > dtoScanEnd.Voltage))
            {
                return;
            }

            //电压距离差
            Single minDistance = Math.Abs(dtoScanStart.Voltage - dtoRef.Voltage);

            //在下降过程中寻找一个电压接近参考电压的点
            for (int i = dtoScanStart.Index + 1; i <= dto.EndPointIndex; i++)
            {
                dtoAvg = (AvgPointDto)this._arrAvg[i];

                //修正积分开始时间和索引
                if (minDistance > Math.Abs(dtoAvg.Voltage - dtoRef.Voltage))
                {
                    dtoScanEnd = dtoAvg;
                    minDistance = Math.Abs(dtoAvg.Voltage - dtoRef.Voltage);
                }
            }

            //是否完全进入
            //if (dtoOff.Voltage > dtoRef.Voltage)
            //{
                dto.EndPointCloseIndex = dtoScanEnd.Index;
                dto.EndMoment = dtoScanEnd.Moment;
                dto.EndVoltage = dtoScanEnd.Voltage;
                dto.IsEndDown = false;
            //}
        }

        /// <summary>
        /// 处理时间程序中的水平基线
        /// </summary>
        /// <param name="arr"></param>
        private void DealHoriBaseline(ArrayList arr)
        {
            //某个点信息
            AvgPointDto dtoAvg = null;

            //是否存在水平基线的峰
            bool bHasOn = false;

            //斜率
            Single k = 0;

            //截距
            Single b = 0;

            //本组内最后一个峰
            PeakDto dtoEnd = (PeakDto)arr[arr.Count - 1];

            //电压
            Single vol = 0;

            //查找某个峰是否在水平基线范围
            foreach (PeakDto dto in arr)
            {
                dtoAvg = (AvgPointDto)this._arrAvg[dto.TopPointIndex];

                //某个峰开始点的水平基线状态为On
                if (dtoAvg.isHoriBaseline)
                {
                    DealWithTopOn(dto);
                    bHasOn = true;

                    //新封闭线斜率
                    k = (dtoEnd.EndVoltage - dto.EndVoltage) / (dtoEnd.EndMoment - dto.EndMoment);
                    //新封闭线截距
                    b = dto.EndVoltage - k * dto.EndMoment;

                    continue;
                }
                //某个峰开始点的水平基线状态为Off
                else
                {
                    //前方存在水平基线状态为On的峰
                    if (!bHasOn)
                    {
                        continue;
                    }

                    vol = k * dto.StartMoment + b;
                    if (VoltageDistance < (dto.StartVoltage - vol))
                    {
                        dto.StartVoltage = vol;
                        dto.IsStartDown = true;
                    }

                    vol = k * dto.EndMoment + b;
                    if (VoltageDistance < (dto.EndVoltage - vol))
                    {
                        dto.EndVoltage = vol;
                        dto.IsEndDown = true;
                    }
                }
            }
        }

        /// <summary>
        /// 顶点的水平基线状态On
        /// </summary>
        /// <param name="dto"></param>
        private void DealWithTopOn(PeakDto dto)
        {

            //某点信息
            AvgPointDto dtoAvg = null;

            //基线前方on->off点
            AvgPointDto dtoOff = null;

            //基线前方参考点
            AvgPointDto dtoRef = null;

            //寻找Off点
            for (int i = dto.TopPointIndex - 1; i >= 0; i--)
            {
                dtoAvg = (AvgPointDto)this._arrAvg[i];

                //确定参考点,取得参考点电压
                if (!dtoAvg.isHoriBaseline)
                {
                    dtoOff = dtoAvg;
                    break;
                }
            }

            this.IsInPeak(ref dtoRef, dtoOff);

            //修正开始积分点电压,需要满足开始点电压高于参考点电压
            AvgPointDto dtoAvgStart = (AvgPointDto)this._arrAvg[dto.StartPointIndex];
            if (VoltageDistance < (dtoAvgStart.Voltage - dtoRef.Voltage))
            {
                dto.StartVoltage = dtoRef.Voltage;
                dto.IsStartDown = true;
            }

            //修正结束积分点电压,需要满足结束点电压高于参考点电压
            AvgPointDto dtoAvgEnd = (AvgPointDto)this._arrAvg[dto.EndPointIndex];
            if (VoltageDistance < (dtoAvgEnd.Voltage - dtoRef.Voltage))
            {
                dto.EndVoltage = dtoRef.Voltage;
                dto.IsEndDown = true;
            }

            //特殊情况,开始点和结束点都小于参考点电压
            if (VoltageDistance > (dtoAvgStart.Voltage - dtoRef.Voltage) && VoltageDistance > (dtoAvgEnd.Voltage - dtoRef.Voltage))
            {
                dto.StartVoltage = dtoAvgStart.Voltage;
                dto.IsStartDown = false;

                if (dtoAvgStart.Voltage < dtoAvgEnd.Voltage)
                {
                    dto.EndVoltage = dto.StartVoltage;
                    dto.IsEndDown = true;
                }
                else
                {
                    dto.EndVoltage = dtoAvgEnd.Voltage;
                    dto.IsEndDown = false;
                }
            }
        }

        #endregion

    }
}
