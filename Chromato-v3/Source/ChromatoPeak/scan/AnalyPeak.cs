/*-----------------------------------------------------------------------------
//  FILE NAME       : AnalyPeak.cs
//  FUNCTION        : 求峰的包络线
//  AUTHOR          : 蔡海鹰(2009/07/23)
//  CHANGE LOG      : 
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
    /// 求峰的包络线
    /// </summary>
    class AnalyPeak
    {

        #region 常量

        /// <summary>
        /// 漂移等于0时的组间隔（峰宽的倍数）
        /// </summary>
        private const double GroupDistance = 1.5;

        /// <summary>
        /// 漂移不等于0时的组间隔（峰宽的倍数）
        /// </summary>
        private const Single GroupDistanceWithDrift = 3;

        /// <summary>
        /// 开始索引
        /// </summary>
        private const Int32 StartIndex = 10;

        #endregion


        #region 变量

        /// <summary>
        /// 数据dto
        /// </summary>
        public AvgPointDto _dtoAvg = null;

        /// <summary>
        ///  平均 AvgPointDto 集合体
        /// </summary>
        private ArrayList _arrAvg { get; set; }

        /// <summary>
        /// 峰外层分组列表，结果 PeakDto 集合体，ArrayList嵌套
        /// </summary>
        public ArrayList _arrGroup = null;

        /// <summary>
        /// 内层峰列表
        /// </summary>
        public ArrayList _arrPeak = null;

        /// <summary>
        /// 扫描状态
        /// </summary>
        private ScanStatus _statusScan = ScanStatus.Start;

        /// <summary>
        /// 上一次扫描状态
        /// </summary>
        private ScanStatus _lastStatus = ScanStatus.Start;

        /// <summary>
        /// 当前扫描索引
        /// </summary>
        private Int32 _currentIndex = StartIndex;

        /// <summary>
        /// 当前结果dto
        /// </summary>
        private PeakDto _dtoPeak = null;

        /// <summary>
        /// 当前平均点
        /// </summary>
        private AvgPointDto _dtoCur = null;

        /// <summary>
        /// 拖尾峰是否存在第一个峰
        /// </summary>
        private bool _bHasFirstPeak = false;
        
        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public AnalyPeak(ArrayList avg)
        {
            this._arrAvg = avg;
            this._arrGroup = new ArrayList();
        }

        #endregion


        #region 主循环

        /// <summary>
        /// 主循环
        /// </summary>
        /// <returns></returns>
        public bool LoopPeak()
        {
            this.GetPointStatus();
            this.GetAvgSlope();
            this.GetPeakTrend();

            this._currentIndex = StartIndex;

            while(this._currentIndex <= (this._arrAvg.Count - 1) )
            {
                this._dtoCur = (AvgPointDto)this._arrAvg[this._currentIndex];

                if (this._dtoCur.Moment > 1.35)
                {
                    ;
                }

                if (this._statusScan != this._lastStatus)
                {
                    this._dtoPeak.PeakStep += this._lastStatus.ToString() + ",";
                    this._lastStatus = this._statusScan;
                }

                switch (this._statusScan)
                {
                    case  ScanStatus.Start:
                        this.DealWithStart();

                        break;

                    case  ScanStatus.UpUp:
                        this.DoUpUp();
                        break;

                    case ScanStatus.UpFlat:
                        this.DoUpFlat();
                        break;

                    case ScanStatus.UpDown:
                        this.DoUpDown();
                        break;

                    case ScanStatus.FlatFlat:
                        this.DoFlatFlat();
                        break;

                    case ScanStatus.DownDown:
                        this.DoDownDown();
                        break;

                    case ScanStatus.DownUp:
                        this.DoDownUp();
                        break;

                    case ScanStatus.FlatUp:
                        this.DoFlatUp();
                        break;

                    case ScanStatus.DownFlat:
                        this.DoDownFlat();
                        break;

                    case ScanStatus.FlatDown:
                        this.DoFlatDown();
                        break;
                }

                //累加索引
                this._currentIndex++;

            }
            return (0 < this._arrGroup.Count) ? true : false;
        }

        /// <summary>
        /// 计算点的状态
        /// </summary>
        private void GetPointStatus()
        {
            AvgPointDto dto1 = null;
            AvgPointDto dto2 = null;

            for (int i = 1; i < this._arrAvg.Count; i++)
            {
                dto1 = (AvgPointDto)this._arrAvg[i-1];
                dto2 = (AvgPointDto)this._arrAvg[i];
                dto1.Slope = GeneralCacu.GetSlope(dto1, dto2);

                if (dto2.Slope > dto2.SettingSlope)
                {
                    dto2.StatusPoint = PointStatus.Up;
                }
                else if (dto1.Slope < (0 - dto2.SettingSlope))
                {
                    dto2.StatusPoint = PointStatus.Down;
                }
                else
                {
                    dto2.StatusPoint = PointStatus.Flat;
                }
            }
        }

        /// <summary>
        /// 计算平均斜率,开始4点无平均斜率 [1,2,3,4,5]
        /// </summary>
        private void GetAvgSlope()
        {
            AvgPointDto dto1 = null;
            AvgPointDto dto5 = null;

            for (int i = 4; i < this._arrAvg.Count; i++)
            {
                dto1 = (AvgPointDto)this._arrAvg[i];
                dto5 = (AvgPointDto)this._arrAvg[i - 4];

                dto5.Slope = GeneralCacu.GetSlope(dto1, dto5);

                if (dto5.Slope > dto5.SettingSlope)
                {
                    dto5.StatusAvgSlope = AverageSlopeStatus.Up;
                }
                else if (dto5.Slope < (0 - dto5.SettingSlope))
                {
                    dto5.StatusAvgSlope = AverageSlopeStatus.Down;
                }
                else
                {
                    dto5.StatusAvgSlope = AverageSlopeStatus.Flat;
                }
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

            for (int i = 10; i < this._arrAvg.Count; i++)
            {
                dto = (AvgPointDto)this._arrAvg[i];

                upCount = 0;
                downCount = 0;
                flatCount = 0;
                for (int j = 0; j < dto.PeakWide; j++)
                {
                    dtoBefore = (AvgPointDto)this._arrAvg[i - dto.PeakWide + j];
                    switch(dtoBefore.StatusPoint)
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

                if (dtoBefore.StatusAvgSlope == AverageSlopeStatus.Up
                    && (upCount > (downCount + flatCount))
                    && dtoBefore.Slope > dto.Slope)
                {
                    dto.TrendPeak = PeakTrend.Up;
                }
                else if (dtoBefore.StatusAvgSlope == AverageSlopeStatus.Down
                    && (downCount > (upCount + flatCount))
                    && dtoBefore.Slope <= (0 - dto.Slope))
                {
                    dto.TrendPeak = PeakTrend.Down;
                }
                else
                {
                    dto.TrendPeak = PeakTrend.Flat;
                }
            }
        }

        #endregion


        #region 状态转换

        /// <summary>
        /// 状态1处理
        /// </summary>
        private void DoUpUp()
        {
            switch (this._dtoCur.TrendPeak)
            {
                case PeakTrend.Up:
                    break;

                case PeakTrend.Flat:
                    this.GetTop();
                    this._statusScan = ScanStatus.UpFlat;
                    break;

                case PeakTrend.Down:
                    this.GetTop();
                    if (this.IsTail())
                    {
                        this._statusScan = ScanStatus.DownFlat;
                    }
                    else
                    {
                        this._statusScan = ScanStatus.UpDown;
                    }
                    break;
            }
        }

        /// <summary>
        /// 状态2处理 
        /// </summary>
        private void DoUpFlat()
        {
            switch (this._dtoCur.TrendPeak)
            {
                case PeakTrend.Up:
                    if (this.IsDriftDown())
                    {
                        //当前峰结束
                        this.GetPeakEnd();

                        //当前组结束
                        this.DealGroupEnd();
                    }
                    else
                    {
                        if (this.IsTail())
                        {
                            this._statusScan = ScanStatus.DownUp;
                        }
                        else
                        {
                            this._dtoPeak.PeakType = TypeOfPeak.Overlap;
                            this._statusScan = ScanStatus.UpUp;
                        }
                    }
                    break;

                case PeakTrend.Flat:
                    this.GetTop();
                    if (this.IsDriftDown())
                    {
                        //当前峰结束
                        this.GetPeakEnd();

                        //当前组结束
                        this.DealGroupEnd();
                    }
                    break;

                case PeakTrend.Down:
                    this.GetTop();
                    if (this.IsTail())
                    {
                        this._statusScan = ScanStatus.DownFlat;
                    }
                    else
                    {
                        this._statusScan = ScanStatus.UpDown;
                    }
                    break;
            }
        }

        /// <summary>
        /// 状态3处理 
        /// </summary>
        private void DoUpDown()
        {
            switch (this._dtoCur.TrendPeak)
            {
                case PeakTrend.Down:
                    if (this.IsDriftDown())
                    {
                        //终止斜率判定
                        if (this.IsStopSlope())
                        {

                            //当前峰结束
                            this.GetPeakEnd();

                            //当前组结束
                            this.DealGroupEnd();
                        }
                    }
                    break;

                case PeakTrend.Up:

                    //组结束判断
                    if (this.IsDriftDown())
                    {
                        //当前峰结束
                        this.GetPeakEnd();

                        //当前组结束
                        this.DealGroupEnd();
                    }
                    else
                    {
                        this._dtoPeak.PeakType = TypeOfPeak.Overlap;
                        //当前峰结束
                        this.GetPeakEnd();

                        //新的峰开始
                        this.GetPeakStart();
                        this._statusScan = ScanStatus.UpUp;
                    }
                    break;

                case PeakTrend.Flat:
                    if (this.IsDriftDown())
                    {
                        //当前峰结束
                        this.GetPeakEnd();

                        //当前组结束
                        this.DealGroupEnd();
                    }
                    else
                    {
                        this._statusScan = ScanStatus.FlatFlat;
                    }
                    break;
            }
        }

        /// <summary>
        /// 状态4处理
        /// </summary>
        private void DoFlatFlat()
        {
            switch (this._dtoCur.TrendPeak)
            {
                case PeakTrend.Up:
                    //当前峰结束
                    this.GetPeakEnd();

                    //新的峰开始
                    this.GetPeakStart();
                    this._statusScan = ScanStatus.UpUp;
                    break;

                case PeakTrend.Flat:
                    if (this.IsDriftDown())
                    {
                        //当前峰结束
                        this.GetPeakEnd();

                        //当前组结束
                        this.DealGroupEnd();
                    }
                    break;

                case PeakTrend.Down:
                    if (this.IsTail())
                    {
                        this._statusScan = ScanStatus.DownFlat;
                    }
                    else
                    {
                        //当前峰结束
                        //this.GetPeakEnd();

                        //新的峰开始
                        //this.GetPeakStart();
                        this._statusScan = ScanStatus.UpDown;
                    }
                    break;
            }
        }

        /// <summary>
        /// 状态10处理
        /// </summary>
        private void DoDownDown()
        {
            switch (this._dtoCur.TrendPeak)
            {
                case PeakTrend.Up:
                    if (this.IsDriftDown())
                    {
                        //当前峰结束
                        this.GetPeakEnd();

                        //当前组结束
                        this.DealGroupEnd();
                    }
                    else
                    {
                        this._statusScan = ScanStatus.DownUp;
                    }
                    break;

                case PeakTrend.Flat:
                    if (this.IsDriftDown())
                    {
                        //当前峰结束
                        this.GetPeakEnd();

                        //当前组结束
                        this.DealGroupEnd();
                    }
                    else
                    {
                        this._statusScan = ScanStatus.FlatDown;
                    }
                    break;

                case PeakTrend.Down:
                    break;
            }
        }

        /// <summary>
        /// 状态11处理
        /// </summary>
        private void DoDownUp()
        {
            switch (this._dtoCur.TrendPeak)
            {
                case PeakTrend.Up:
                    break;

                case PeakTrend.Flat:
                    this.GetTop();
                    this._statusScan = ScanStatus.FlatUp;
                    break;

                case PeakTrend.Down:
                    this.GetTop();
                    if (this.IsTail())
                    {
                        this._statusScan = ScanStatus.DownFlat;
                    }
                    else
                    {
                        this._statusScan = ScanStatus.UpDown;
                    }
                    break;
            }
        }

        /// <summary>
        /// 状态12处理
        /// </summary>
        private void DoFlatUp()
        {
            switch (this._dtoCur.TrendPeak)
            {
                case PeakTrend.Flat:
                    this.GetTop();
                    if (this.IsDriftDown())
                    {
                        //当前峰结束
                        this.GetPeakEnd();

                        //当前组结束
                        this.DealGroupEnd();
                    }
                    break;

                case PeakTrend.Up:
                    if (this.IsTail())
                    {
                        this._statusScan = ScanStatus.DownUp;
                    }
                    else
                    {
                        this._statusScan = ScanStatus.UpUp;
                    }
                    break;

                case PeakTrend.Down:
                    if (this.IsTail())
                    {
                        this._statusScan = ScanStatus.DownFlat;
                    }
                    else
                    {
                        this._statusScan = ScanStatus.UpDown;
                    }
                    break;
            }
        }

        /// <summary>
        /// 状态13处理
        /// </summary>
        private void DoDownFlat()
        {
            switch (this._dtoCur.TrendPeak)
            {
                case PeakTrend.Up:
                    if (this.IsDriftDown())
                    {
                        //当前峰结束
                        this.GetPeakEnd();

                        //当前组结束
                        this.DealGroupEnd();
                    }
                    else
                    {
                        this._statusScan = ScanStatus.DownUp;
                    }
                    break;

                case PeakTrend.Flat:
                    if (this.IsDriftDown())
                    {
                        //当前峰结束
                        this.GetPeakEnd();

                        //当前组结束
                        this.DealGroupEnd();
                    }
                    else
                    {
                        this._statusScan = ScanStatus.FlatDown;
                    }
                    break;

                case PeakTrend.Down:
                    if (this.IsStopSlope())
                    {
                        this._statusScan = ScanStatus.DownDown;
                    }
                    break;
            }
        }

        /// <summary>
        /// 状态14处理
        /// </summary>
        private void DoFlatDown()
        {
            switch (this._dtoCur.TrendPeak)
            {
                case PeakTrend.Up:
                    this._statusScan = ScanStatus.DownUp;

                    break;

                case PeakTrend.Down:
                    if (this.IsTail())
                    {
                        this._statusScan = ScanStatus.DownFlat;
                    }
                    else
                    {
                        this._statusScan = ScanStatus.UpDown;
                    }
                    break;

                case PeakTrend.Flat:
                    if (this.IsDriftDown())
                    {
                        //当前峰结束
                        this.GetPeakEnd();

                        //当前组结束
                        this.DealGroupEnd();
                    }
                    break;
            }
        }

        #endregion
         

        #region 条件

        /// <summary>
        /// 状态0处理 
        /// </summary>
        private void DealWithStart()
        {
            //不符合上升趋势
            if (_dtoCur.TrendPeak != PeakTrend.Up)
            {
                return;
            }

            this._arrPeak = new ArrayList();
            this.GetPeakStart();
            this._statusScan = ScanStatus.UpUp;
        }

        /// <summary>
        /// 取峰的开始点
        /// </summary>
        private void GetPeakStart()
        {
            if (this._dtoCur.Moment > 2.5)
            {
                ;
            }
            AvgPointDto dtoAvg = null;
            this._dtoPeak = new PeakDto();
            Single minVoltage = 0;

            //缺省前方第5点
            this._dtoPeak.StartPointIndex = this._currentIndex - this._dtoCur.PeakWide + 1;

            //无上升点，电压值最小
            for (int i = (this._currentIndex - 2 * this._dtoCur.PeakWide + 1); i < (this._currentIndex - this._dtoCur.PeakWide + 1); i++)
            {
                dtoAvg = (AvgPointDto)this._arrAvg[i];
                if (dtoAvg.TrendPeak != PeakTrend.Up)
                {
                    if (minVoltage > dtoAvg.Voltage)
                    {
                        minVoltage = dtoAvg.Voltage;
                        this._dtoPeak.StartPointIndex = i;
                    }
                }
            }
        }

        /// <summary>
        /// 取得峰的结束点
        /// </summary>
        private void GetPeakEnd()
        {
            AvgPointDto dtoAvg = null;
            Single minVoltage = 0;

            //缺省前方第5点
            this._dtoPeak.EndPointIndex = this._currentIndex - this._dtoCur.PeakWide + 1;

            //无上升点，电压值最小
            for (int i = (this._currentIndex - 2 * this._dtoCur.PeakWide + 1); i < (this._currentIndex - this._dtoCur.PeakWide + 1); i++)
            {
                dtoAvg = (AvgPointDto)this._arrAvg[i];
                if (dtoAvg.TrendPeak != PeakTrend.Up)
                {
                    if (minVoltage > dtoAvg.Voltage)
                    {
                        minVoltage = dtoAvg.Voltage;

                        //保存结束点
                        this._dtoPeak.EndPointIndex = i;
                    }
                }
            }

            if (this._dtoPeak.EndPointIndex <= this._dtoPeak.TopPointIndex)
            {
                this._dtoPeak.EndPointIndex = this._currentIndex;
            }

            this._bHasFirstPeak = true;

            //加入内层列表
            this._arrPeak.Add(this._dtoPeak);
        }

        /// <summary>
        /// 是否脱尾
        /// </summary>
        /// <returns></returns>
        private bool IsTail()
        {
            bool bTail = false;
            ArrayList arr = null;
            PeakDto dtoPeakMain = null;
            bool bCondition1 = false;
            bool bCondition2 = false;
            bool bCondition3 = false;

            AvgPointDto dtoAvgFirstStart = null;
            AvgPointDto dtoAvgFirstTop = null;
            AvgPointDto dtoAvgFirstEnd = null;

            if (!this._bHasFirstPeak)
            {
                return false;
            }

            if (0 < this._arrGroup.Count)
            {
                arr = (ArrayList)this._arrGroup[this._arrGroup.Count - 1];
                dtoPeakMain = (PeakDto)arr[0];

                dtoAvgFirstStart = (AvgPointDto)this._arrAvg[dtoPeakMain.StartPointIndex];
                dtoAvgFirstTop = (AvgPointDto)this._arrAvg[dtoPeakMain.TopPointIndex];
                dtoAvgFirstEnd = (AvgPointDto)this._arrAvg[dtoPeakMain.EndPointIndex];

                //条件1
                bCondition1 = (dtoAvgFirstTop.Voltage - dtoAvgFirstStart.Voltage) >
                    ((dtoAvgFirstEnd.Voltage - dtoAvgFirstStart.Voltage) * 10.0) ? true : false;

                //条件2
                bCondition2 = (this._dtoCur.Voltage - dtoAvgFirstStart.Voltage) <
                    ((dtoAvgFirstEnd.Voltage - dtoAvgFirstStart.Voltage) * 100.0) ? true : false;

                //条件3
                bCondition3 = (dtoAvgFirstEnd.Moment - dtoAvgFirstTop.Moment) >
                    ((this._dtoCur.Moment - dtoAvgFirstEnd.Moment) * 3.0) ? true : false;


                if (bCondition1 && bCondition2 && bCondition3)
                {
                    this._dtoPeak.PeakType = TypeOfPeak.Tail;
                    bTail = true;
                }
            }

            return bTail;
        }

        /// <summary> 
        /// 得到最高点
        /// </summary>
        private void GetTop()
        {
            AvgPointDto dtoAvg = null;
            if (0 != this._dtoPeak.TopPointIndex)
            {
                dtoAvg = (AvgPointDto)this._arrAvg[this._dtoPeak.TopPointIndex];
                if (this._dtoCur.Voltage > dtoAvg.Voltage)
                {
                    this._dtoPeak.TopPointIndex = this._currentIndex;
                    this._dtoPeak.ReserveTime = this._dtoCur.Moment;
                }
            }
            else
            {
                this._dtoPeak.TopPointIndex = this._currentIndex;
                this._dtoPeak.ReserveTime = this._dtoCur.Moment;
            }
        }

        /// <summary>
        /// 得到结束点
        /// </summary>
        private void DealGroupEnd()
        {
            if (this._dtoCur.Moment >= 10.35)
            {
                ;
            }

            //复位脱尾标志
            this._bHasFirstPeak = false;

            //设置组号
            foreach (PeakDto dto in this._arrPeak)
            {
                dto.GroupID = this._arrGroup.Count + 1;

                if (this._arrPeak.Count == 1)
                {
                    dto.PeakType = TypeOfPeak.Main;
                }
            }
            //加入外层列表
            this._arrGroup.Add(this._arrPeak);

            //返回找组的开始点状态
            this._statusScan = ScanStatus.Start;
        }

        /// <summary>
        /// 是否在漂移点的下方
        /// </summary>
        /// <returns></returns>
        private bool IsDriftDown()
        {
            bool bRet = false;
            PeakDto dtoPeakMain = null;
            AvgPointDto dtoFirst = null;

            if (this._currentIndex == 1107)
            {
                ;
            }

            //if (!this._bHasFirstPeak)
            //{
            //    dtoFirst = (AvgPointDto)this._arrAvg[this._dtoPeak.EndPointIndex];
            //    bRet = this.JudgeDrift(dtoFirst);
            //}
            if (0 < this._arrPeak.Count)
            {
                dtoPeakMain = (PeakDto)this._arrPeak[0];
                dtoFirst = (AvgPointDto)this._arrAvg[dtoPeakMain.EndPointIndex];
                bRet = this.JudgeDrift(dtoFirst);
            }

            return bRet;
        }

        /// <summary>
        /// 根据漂移判断组结束
        /// </summary>
        /// <param name="dtoFirst"></param>
        /// <returns></returns>
        private bool JudgeDrift(AvgPointDto dtoFirst)
        {
            bool bRet = false;
            Single k = 0;
            
            //漂移等于0
            if (0 == dtoFirst.Drift)
            {
                //1.5倍峰宽
                if (GroupDistance * dtoFirst.PeakWide <= (this._dtoCur.Index - dtoFirst.Index))
                {
                    bRet = true;
                }
            }
            //漂移大于0
            else if (0 < dtoFirst.Drift)
            {
                //取得斜率
                k = GeneralCacu.GetSlope(dtoFirst, this._dtoCur);

                //大于开始点漂移
                bRet = (k > dtoFirst.Drift) ? false : true;

                //3倍峰宽
                if (GroupDistanceWithDrift * dtoFirst.PeakWide <= (this._dtoCur.Index - dtoFirst.Index))
                {
                    bRet = true;
                }
            }
            return bRet;
        }

        /// <summary>
        /// 是否满足终止斜率
        /// </summary>
        /// <returns></returns>
        private bool IsStopSlope()
        {

            if (0 == this._dtoPeak.StartPointIndex)
            {
                return false;
            }
            AvgPointDto dtoStart = (AvgPointDto)this._arrAvg[this._dtoPeak.StartPointIndex];
            AvgPointDto dto5 = (AvgPointDto)this._arrAvg[this._currentIndex - this._dtoCur.PeakWide];

            //终止斜率
            Single stopSlope = GeneralCacu.GetSlope(dtoStart, dto5);

            AvgPointDto dtoAfter = null;
            AvgPointDto dtoBefore = null;
            Int32 countSmall = 0;
            Int32 countBig = 0;
            for (int i = this._currentIndex; i < this._currentIndex - this._dtoCur.PeakWide + 1; i--)
            {
                dtoAfter = (AvgPointDto)this._arrAvg[i];
                dtoBefore = (AvgPointDto)this._arrAvg[i - 1];
                if (stopSlope < GeneralCacu.GetSlope(dtoBefore, dtoAfter))
                {
                    countBig++;
                }
                else
                {
                    countSmall++;
                }
            }

            //前面连续5点的斜率与终止斜率比较
            return (countBig > countSmall) ? true : false ;
        }

        #endregion

    }
}
