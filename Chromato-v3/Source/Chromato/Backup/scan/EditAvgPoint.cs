/*-----------------------------------------------------------------------------
//  FILE NAME       : EditAvgPoint.cs
//  FUNCTION        : 对原始数据求平均,确定各点的属性
//  AUTHOR          : 谢玲(2009/07/06)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Collections;
using ChromatoTool.dto;
using ChromatoTool.ini;
using System;
using ChromatoTool.util;

namespace ChromatoPeak.scan
{
    /// <summary>
    /// 对原始数据求平均,确定各点的属性
    /// </summary>
    public class EditAvgPoint
    {

        #region 常量

        /// <summary>
        /// 变参倍数
        /// </summary>
        private const int ChangeParaTime = 2;

        #endregion


        #region 变量

        /// <summary>
        /// 数据集合 OriginPointDto 集合体
        /// </summary>
        public ArrayList _arr { get; set; }

        /// <summary>
        /// 分析方法
        /// </summary>
        public AnalyParaDto _dtoAnalyPara { get; set; }

        /// <summary>
        /// 时间程序 TimeProcDto 集合体
        /// </summary>
        public ArrayList _timeProc { get; set; }

        /// <summary>
        /// 是否使用时间程序
        /// </summary>
        public bool _isUseTp = false;

        /// <summary>
        /// 结果 PeakDto 集合体
        /// </summary>
        public ArrayList _arrPeak { get; set; }

        /// <summary>
        ///  平均 AvgPointDto 集合体
        /// </summary>
        public ArrayList _arrAvg { get; set; }

        /// <summary>
        /// 样品量
        /// </summary>
        public Int32 SampleWeight { get; set; }

        /// <summary>
        /// 内标量
        /// </summary>
        public Int32 InnerWeight { get; set; }

        /// <summary>
        /// ID表 IngredientDto 集合体
        /// </summary>
        public ArrayList _arrIngre { get; set; }

        /// <summary>
        /// 含量表 CalibrateDto 集合体(根据IngredientDto.IngredientID嵌套)
        /// </summary>
        public ArrayList _arrCali { get; set; }

        #endregion

        
        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public EditAvgPoint()
        {
            this._arrAvg = new ArrayList();
            this._arrPeak = new ArrayList();
        }

        #endregion


        #region 内部方法

        /// <summary>
        /// 求平均点，保存各点的属性到_arrAvg
        /// </summary>
        /// <returns></returns>
        private void GetAvgArray()
        {
            //设置原始点的默认峰宽,默认斜率
            this.SetDefaultInOri();

            //根据时间程序设置峰宽
            this.SetPeakWideByTp();

            //根据时间程序设置斜率
            this.SetSlopeByTp();

            //根据变参时间设置峰宽，斜率
            this.SetPwAndSlopeByTp();

            //根据前两步的峰宽开始做平均
            this.GetAvg();

            //计算斜率
            this.SetSlope();

            //扫描时间程序，给平均后的每点设置其他7个parameters
            this.SetOtherProperty();
        }

        /// <summary>
        /// 设置原始点的默认峰宽,大于5的时候设置为5
        /// </summary>
        private void SetDefaultInOri()
        {
            foreach (OriginPointDto oriDto in this._arr)
            {
                oriDto.AvgPeakWide = (DefaultAnaly.PeakWide < _dtoAnalyPara.PeakWide) 
                    ? DefaultAnaly.PeakWide : _dtoAnalyPara.PeakWide;

                oriDto.SettingSlope = this._dtoAnalyPara.Slope;
            }
        }

        /// <summary>
        /// 根据时间程序的峰宽设置峰宽
        /// </summary>
        private void SetPeakWideByTp()
        {
            //时间程序不为空
            if (!this._isUseTp || this._timeProc == null)
            {
                return;
            }

            //开始依次循环原始点，若在时间程序的峰宽的时间范围内，则改变峰宽为时间程序的峰宽
            foreach (TimeProcDto dtoTp in this._timeProc)
            {
                //时间类型为峰宽时，取出命令值作为峰宽
                if (EnumDescription.GetFieldText(TimeProcType.PeakWide).Equals(dtoTp.ActionName))
                {
                    foreach (OriginPointDto dtoOri in this._arr)
                    {
                        if (dtoOri.Moment >= dtoTp.StartTime && dtoOri.Moment < dtoTp.StopTime)
                        {
                            dtoOri.AvgPeakWide = dtoTp.TpValue;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 根据时间程序设置斜率
        /// </summary>
        private void SetSlopeByTp()
        {
            //时间程序不为空
            if (!this._isUseTp || this._timeProc == null)
            {
                return;
            }

            foreach (TimeProcDto dtoTp in this._timeProc)
            {
                //时间类型为斜率时，取出命令值作为斜率
                if (EnumDescription.GetFieldText(TimeProcType.Slope).Equals(dtoTp.ActionName))
                {
                    foreach (OriginPointDto dtoOri in this._arr)
                    {
                        if (dtoOri.Moment >= dtoTp.StartTime && dtoOri.Moment < dtoTp.StopTime)
                        {
                            dtoOri.SettingSlope = dtoTp.TpValue;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 根据变参时间设置峰宽，斜率
        /// </summary>
        private void SetPwAndSlopeByTp()
        {
            //时间程序不为空
            if (!this._isUseTp || this._timeProc == null)
            {
                return;
            }

            TimeProcDto dtoChangePt = null;

            //时间程序中是否存在变参时间，如果存在多条，以最后一条为准
            bool bChangeParaTime = false;
            for (int i = 0; i < this._timeProc.Count; i++)
            {
                dtoChangePt = (TimeProcDto)this._timeProc[i];
                if (EnumDescription.GetFieldText(TimeProcType.ChangeParaTime).Equals(dtoChangePt.ActionName))
                {
                    bChangeParaTime = true;
                }
            }

            //存在变参时间（峰宽加倍，斜率减半）
            if (!bChangeParaTime)
            {
                return;
            }

            //变参倍数
            int ptTimes = 1;

            //原始点计数
            int iCurIndex = 0;

            OriginPointDto dtoOri = null;

            int index = Convert.ToInt32(dtoChangePt.StartTime * DefaultItem.SecondsPerMin * General.Frequent);
            
            while (iCurIndex < this._arr.Count)//开始循环原始点
            {
                dtoOri = (OriginPointDto)_arr[iCurIndex];

                if (index > iCurIndex)
                {
                    //峰宽加倍
                    dtoOri.AvgPeakWide = dtoOri.AvgPeakWide * ptTimes;
                    //斜率减半
                    dtoOri.SettingSlope = dtoOri.SettingSlope / ptTimes;

                    iCurIndex++;
                }
                else
                {
                    index *= ChangeParaTime;
                    ptTimes *= ChangeParaTime;
                }
            }
        }

        /// <summary>
        /// 根据原始点峰宽计算出平均点
        /// </summary>
        private void GetAvg()
        {
            //原始点计数
            int iCurIndex = 0;

            //峰宽平均点的所有点的Y轴坐标之和
            float sumVoltage = 0;

            //结束点索引
            int iEndIndex = 0;

            AvgPointDto avgDto = null;
            OriginPointDto oriDto = null;

            while (iCurIndex < this._arr.Count)//开始循环原始点
            {
                oriDto = (OriginPointDto)_arr[iCurIndex];   //开始求和的起始点 
                sumVoltage = 0;

                if ((iCurIndex + oriDto.AvgPeakWide) < this._arr.Count)
                {
                    iEndIndex = iCurIndex + oriDto.AvgPeakWide;
                }
                else
                {
                    iEndIndex = this._arr.Count;
                }

                for (int j = iCurIndex; j < iEndIndex; j++)
                {
                    sumVoltage += ((OriginPointDto)_arr[j]).Voltage;
                }

                // avgDto 平均点
                avgDto = new AvgPointDto();

                //平均点的电压，即为y轴
                avgDto.Voltage = sumVoltage / (iEndIndex - iCurIndex);

                //平均点的时刻，即为x轴
                avgDto.Moment = oriDto.Moment;

                //平均点的峰宽
                avgDto.PeakWide = oriDto.AvgPeakWide;

                //平均点的斜率,采用的是原始点的值
                avgDto.SettingSlope = oriDto.SettingSlope;

                //平均点的索引
                avgDto.Index = this._arrAvg.Count;

                //平均点的漂移,采用的是默认的值，在第4步会修改
                avgDto.Drift = _dtoAnalyPara.Drift;

                //平均点的最小面,采用的是默认的值，在第4步会修改
                avgDto.minArea = _dtoAnalyPara.MinAreaSize;

                //平均点的变参时间,采用的是默认的值，在第4步会修改
                avgDto.ParaChangeTime = _dtoAnalyPara.ParaChangeTime;

                this._arrAvg.Add(avgDto);

                iCurIndex = iEndIndex;
            }
        }

        /// <summary>
        /// 设置斜率
        /// </summary>
        private void SetSlope()
        {
            AvgPointDto dtoCur = null;
            AvgPointDto dtoNext = null;
            for (int i = 0; i < this._arrAvg.Count - 1; i++)
            {
                dtoCur = (AvgPointDto)this._arrAvg[i];
                dtoNext = (AvgPointDto)this._arrAvg[i + 1];
                dtoCur.Slope = GeneralCacu.GetSlope(dtoCur, dtoNext);

                if (dtoCur.Slope > dtoCur.SettingSlope)
                {
                    dtoCur.UorD = PointAttribute.Up;
                }
                else if (dtoCur.Slope < (0 - dtoCur.SettingSlope))
                {
                    dtoCur.UorD = PointAttribute.Down;
                }
            }
        }

        /// <summary>
        /// 根据时间程序设置其它属性
        /// </summary>
        private void SetOtherProperty()
        {
            //时间程序不为空
            if (!this._isUseTp || this._timeProc == null)
            {
                return;
            }

            //漂移，斜率，最小面积，变参时间等参数，还有拖尾峰处理 未考虑
            //开始依次循环原始点，若在时间程序的峰宽的时间范围内，则改变峰宽为时间程序的峰宽
            foreach(AvgPointDto dtoAvg in this._arrAvg)
            {
                foreach (TimeProcDto dtoTp in this._timeProc)
                {

                    //时间类型为漂移时，取出漂移命令值
                    if (EnumDescription.GetFieldText(TimeProcType.Drift).Equals(dtoTp.ActionName))
                    {
                        if (dtoAvg.Moment >= dtoTp.StartTime && dtoAvg.Moment < dtoTp.StopTime)
                        {
                            dtoAvg.PeakWide = dtoTp.TpValue;
                        }
                    }

                    //时间类型为最小面积时，取出命令值作为最小面积
                    if (EnumDescription.GetFieldText(TimeProcType.MinSize).Equals(dtoTp.ActionName))
                    {
                        if (dtoAvg.Moment >= dtoTp.StartTime && dtoAvg.Moment < dtoTp.StopTime)
                        {
                            dtoAvg.minArea = dtoTp.TpValue;
                        }
                    }

                    //时间类型为无需峰削除时，ON时开始削除无需峰，OFF时解除，又名锁定时间
                    if (EnumDescription.GetFieldText(TimeProcType.TimeLock).Equals(dtoTp.ActionName))
                    {
                        if (dtoAvg.Moment >= dtoTp.StartTime && dtoAvg.Moment < dtoTp.StopTime)
                        {
                            //命令值为101表示OFF，为100表示ON
                            dtoAvg.isTimeLock = ((Int32)TpStatus.Open == dtoTp.TpValue) ? true : false;
                        }
                    }

                    //时间类型为基线锁定时，在ON，OFF区域内的负峰均被削除
                    if (EnumDescription.GetFieldText(TimeProcType.LockBaseline).Equals(dtoTp.ActionName))
                    {
                        if (dtoAvg.Moment >= dtoTp.StartTime && dtoAvg.Moment < dtoTp.StopTime)
                        {
                            //命令值为101表示OFF，为100表示ON
                            dtoAvg.isBaselineLock = ((Int32)TpStatus.Open == dtoTp.TpValue) ? true : false;
                        }
                    }
                    
                    //时间类型为负峰翻转时，在ON，OFF区域内的负峰均被翻转过来
                    if (EnumDescription.GetFieldText(TimeProcType.RevertPeak).Equals(dtoTp.ActionName))
                    {
                        if (dtoAvg.Moment >= dtoTp.StartTime && dtoAvg.Moment < dtoTp.StopTime)
                        {
                            //命令值为101表示OFF，为100表示ON
                            dtoAvg.isRevertNegative = ((Int32)TpStatus.Open == dtoTp.TpValue) ? true : false;
                        }
                    }
                    
                    //时间类型为水平基线时，在ON，OFF区域内峰按水平基线计算
                    if (EnumDescription.GetFieldText(TimeProcType.HoriBaseline).Equals(dtoTp.ActionName))
                    {
                        if (dtoAvg.Moment >= dtoTp.StartTime && dtoAvg.Moment < dtoTp.StopTime)
                        {
                            //命令值为101表示OFF，为100表示ON
                            dtoAvg.isHoriBaseline = ((Int32)TpStatus.Open == dtoTp.TpValue) ? true : false;
                        }
                    }
                    //时间类型为拖尾峰处理时，在ON，OFF区域内峰按拖尾峰处理
                    if (EnumDescription.GetFieldText(TimeProcType.DealTailPeak).Equals(dtoTp.ActionName))
                    {
                        if (dtoAvg.Moment >= dtoTp.StartTime && dtoAvg.Moment < dtoTp.StopTime)
                        {
                            //命令值为101表示OFF，为100表示ON
                            dtoAvg.isTailProcess = ((Int32)TpStatus.Open == dtoTp.TpValue) ? true : false;
                        }
                    }
                }
            }
        }

        #endregion 


        #region 外部方法

        /// <summary>
        /// 取得结果
        /// </summary>
        /// <returns></returns>
        public ArrayList GetResult()
        {
            this.GetAvgArray();

            switch (General.SolutionPeak)
            {

                case PeakSolution.StatusMachine:
                    AnalyPeak peakAnaly = new AnalyPeak(this._arrAvg);
                    if (peakAnaly.LoopPeak())
                    {
                        ObtainType oType = new ObtainType(this._arrAvg, peakAnaly._arrGroup);
                        oType.Obtain();

                        CacuCloseline cClose = new CacuCloseline(this._arrAvg, peakAnaly._arrGroup);
                        cClose.Cacu();

                        CacuSize sCacu = new CacuSize(this._arrAvg, peakAnaly._arrGroup, this._arrPeak);
                        sCacu.Cacu(true);

                        CacuDensity dCacu = new CacuDensity(this._arrAvg, this._arrPeak);
                        dCacu.InnerWeight = this.InnerWeight;
                        dCacu.SampleWeight = this.SampleWeight;
                        dCacu._arrIngre = this._arrIngre;
                        dCacu._arrCali = this._arrCali;
                        dCacu._dtoAnalyPara = this._dtoAnalyPara;
                        dCacu.Cacu();
                    }
                    break;

                case PeakSolution.XCast:
                    FindPeak peakFind = new FindPeak(this._arrAvg,this._arrPeak);
                    if (peakFind.Find())
                    {
                        AutoGroup groupDivide = new AutoGroup(this._arrAvg, this._arrPeak);
                        if (groupDivide.Divide())
                        {
                            ObtainType oType = new ObtainType(this._arrAvg, groupDivide._arrGroup);
                            oType.Obtain();

                            CacuCloseline cClose = new CacuCloseline(this._arrAvg, groupDivide._arrGroup);
                            cClose.Cacu();
                          
                            CacuSize sCacu = new CacuSize(this._arrAvg, groupDivide._arrGroup, this._arrPeak);
                            sCacu.Cacu(false);

                            CacuDensity dCacu = new CacuDensity(this._arrAvg, this._arrPeak);
                            dCacu.InnerWeight = this.InnerWeight;
                            dCacu.SampleWeight = this.SampleWeight;
                            dCacu._arrIngre = this._arrIngre;
                            dCacu._arrCali = this._arrCali;
                            dCacu._dtoAnalyPara = this._dtoAnalyPara;
                            dCacu.Cacu();
                        }
                    }
                    break;
            }

            return this._arrPeak;
        }

        /// <summary>
        ///重新分组,计算面积,浓度
        /// </summary>
        /// <param name="arrPeak"></param>
        public void ReCacu(ArrayList arrPeak)
        {
            this.GetAvgArray();

            AutoGroup groupDivide = new AutoGroup(this._arrAvg, arrPeak);
            if (groupDivide.Divide())
            {
                ObtainType oType = new ObtainType(this._arrAvg, groupDivide._arrGroup);
                oType.Obtain();

                CacuCloseline cClose = new CacuCloseline(this._arrAvg, groupDivide._arrGroup);
                cClose.Cacu();

                CacuSize sCacu = new CacuSize(this._arrAvg, groupDivide._arrGroup, arrPeak);
                sCacu.Cacu(false);

                CacuDensity dCacu = new CacuDensity(this._arrAvg, arrPeak);
                dCacu.InnerWeight = this.InnerWeight;
                dCacu.SampleWeight = this.SampleWeight;
                dCacu._arrIngre = this._arrIngre;
                dCacu._arrCali = this._arrCali;
                dCacu._dtoAnalyPara = this._dtoAnalyPara;
                dCacu.Cacu();
            }
        }

        #endregion
   
    }
}
