/*-----------------------------------------------------------------------------
//  FILE NAME       : CacuDensity.cs
//  FUNCTION        : 计算峰的浓度
//  AUTHOR          : 谢玲(2009/08/14)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Collections;
using ChromatoTool.ini;
using ChromatoTool.dto;
using ChromatoTool.log;
using System.Windows.Forms;

namespace ChromatoPeak.scan
{
    /// <summary>
    /// 计算峰的浓度
    /// </summary>
    class CacuDensity
    {

        #region 常量

        /// <summary>
        /// 一百
        /// </summary>
        private Single OneHundred = 100;

        #endregion 


        #region 变量

        /// <summary>
        /// 数据集合 AvgPointDto 集合体
        /// 结果 PeakDto 集合体
        /// </summary>
        private ArrayList _arrPeak { get; set; }

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
        /// </summary>定量方法ID（外标，内标，归一，指数等）
        public ArrayList _arrCali { get; set; }

        /// <summary>
        /// 分析方法
        /// </summary>
        public AnalyParaDto _dtoAnalyPara { get; set; }

        /// <summary>
        ///  平均 AvgPointDto 集合体
        /// </summary>
        private ArrayList _arrAvg { get; set; }

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="result"></param>
        public CacuDensity(ArrayList avg, ArrayList result)
        {
            this._arrAvg = avg;
            this._arrPeak = result;
        }
       
        #endregion


        #region 入口

        /// <summary>
        /// 六种浓度定量计算方法
        /// </summary>
        public void Cacu()
        {
            this.MovePeakBySize();
            this.ClearMatch();

            switch (this._dtoAnalyPara.ArithmaticID)
            {
                case Arithmatic.Normalize:
                    this.Normalize();
                    break;

                case Arithmatic.FixNormalize:
                    this.FixNormalize();
                    break;

                case Arithmatic.FixNormalizeWithRate:
                    this.FixNormalizeWithRate();
                    break;

                case Arithmatic.Inner:
                    this.Inner();
                    break;

                case Arithmatic.Outer:
                    this.Outer();
                    break;

                case Arithmatic.Exponent:
                    this.Exponent();
                    break;
            }

        }

        /// <summary>
        /// 非归一法清空匹配标志
        /// </summary>
        private void ClearMatch()
        {
            //循环峰鉴定表
            foreach (IngredientDto dtoIngre in this._arrIngre)
            {
                dtoIngre.IsMatch = false;
            }
        }

        /// <summary>
        /// 根据最小面积的要求移走某些峰
        /// </summary>
        private void MovePeakBySize()
        {
            ArrayList arrMove = new ArrayList();
            AvgPointDto dtoAvg = null;

            foreach (PeakDto dto in this._arrPeak)
            {
                //取该峰顶点的最小设定面积
                dtoAvg = (AvgPointDto)this._arrAvg[dto.TopPointIndex];
                if (dto.AreaSize < dtoAvg.minArea)
                {
                    arrMove.Add(dto);
                }
            }

            foreach (PeakDto dto in arrMove)
            {
                this._arrPeak.Remove(dto);
            }
        }

        #endregion


        #region  归一法

        /// <summary>
        /// 归一法
        /// </summary>
        private void Normalize()
        {
            // 峰面积总和
            Double sum = 0;

            PeakDto dtoPeak = null;

            switch (this._dtoAnalyPara.ArithmaticPara)
            {
                case ArithmaticParameter.Area:
                    for (int i = 0; i < this._arrPeak.Count; i++)
                    {
                        dtoPeak = (PeakDto)this._arrPeak[i];
                        sum += dtoPeak.AreaSize;
                    }
                    for (int i = 0; i < this._arrPeak.Count; i++)
                    {
                        dtoPeak = (PeakDto)this._arrPeak[i];
                        dtoPeak.Density = Convert.ToSingle(dtoPeak.AreaSize / sum * OneHundred);
                    }
                    break;

                case ArithmaticParameter.Height:
                    for (int i = 0; i < this._arrPeak.Count; i++)
                    {
                        dtoPeak = (PeakDto)this._arrPeak[i];
                        sum += dtoPeak.PeakHeight;
                    }
                    for (int i = 0; i < this._arrPeak.Count; i++)
                    {
                        dtoPeak = (PeakDto)this._arrPeak[i];
                        dtoPeak.Density = Convert.ToSingle(dtoPeak.PeakHeight / sum * OneHundred);
                    }
                    break;
            }
        }

        #endregion


        #region 修正归一法

        /// <summary>
        /// 修正归一法
        /// </summary>
        private void FixNormalize()
        {

            Double sumFix = this.CacuKbAndSum();

            //算出符合条件的峰的浓度
            switch (this._dtoAnalyPara.ArithmaticPara)
            {
                case ArithmaticParameter.Area:
                    foreach (PeakDto dtoPeak in this._arrPeak)
                    {
                        if (0 != dtoPeak.BaseK)
                        {
                            dtoPeak.Density = Convert.ToSingle((dtoPeak.BaseK * dtoPeak.AreaSize + dtoPeak.BaseB) / sumFix * OneHundred);
                        }
                    }
                    break;

                case ArithmaticParameter.Height:
                    foreach (PeakDto dtoPeak in this._arrPeak)
                    {
                        if (0 != dtoPeak.BaseK)
                        {
                            dtoPeak.Density = Convert.ToSingle((dtoPeak.BaseK * dtoPeak.PeakHeight + dtoPeak.BaseB) / sumFix * OneHundred);
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 返回计算总和
        /// </summary>
        /// <returns></returns>
        private Double CacuKbAndSum()
        {
            Single innerVal = 0;
            Double sumFix = 0;

            //取出所有峰的数据
            foreach (PeakDto dtoPeak in this._arrPeak)
            {
                //在峰鉴定表中定性,寻找保留时间最接近的成分
                IngredientDto dtoIngre = this.FindIngreByReserveTime(dtoPeak);

                if (null != dtoIngre)
                {
                    this.FindKB(dtoIngre, dtoPeak, ref sumFix, ref innerVal);
                    dtoPeak.PeakName = dtoIngre.IngredientName;

                    //设置匹配标志
                    dtoIngre.IsMatch = true;
                }
            }
            return sumFix;
        }

        /// <summary>
        /// 在峰鉴定表中寻找保留时间最接近的成分
        /// </summary>
        /// <param name="dtoPeak"></param>
        /// <returns>成分dto</returns>
        private IngredientDto FindIngreByReserveTime(PeakDto dtoPeak)
        {
            // 最小保留时间差 （单位：分钟）
            Single sMinDistance = 10;

            // 中间变量
            Single sTemp = 0;

            // 找到的成分
            IngredientDto dtoFind = null;

            switch (this._dtoAnalyPara.AimPara)
            {
                case AimPara.TimeBand://采用时间带

                    //循环峰鉴定表
                    foreach (IngredientDto dtoIngre in this._arrIngre)
                    {
                        //如果匹配过,跳过
                        if (dtoIngre.IsMatch)
                        {
                            continue;
                        }

                        //保留时间（秒）
                        sTemp = Math.Abs(dtoPeak.ReserveTime - dtoIngre.ReserveTime);

                        //落入范围，时间带（单位分）
                        if (sTemp < dtoIngre.TimeBand * DefaultItem.SecondsPerMin)
                        {
                            if (sMinDistance > sTemp)
                            {
                                dtoFind = dtoIngre;

                                // 时间最小,匹配成功,返回
                                break;
                            }
                        }
                    }
                    break;

                case AimPara.TimeWindow:// 采用时间窗（百分数）

                    //循环峰鉴定表
                    foreach (IngredientDto dtoIngre in this._arrIngre)
                    {
                        //如果匹配过,跳过
                        if (dtoIngre.IsMatch)
                        {
                            continue;
                        }

                        //保留时间差（秒）
                        sTemp = Math.Abs(dtoPeak.ReserveTime - dtoIngre.ReserveTime);

                        //落入范围,时间窗（百分数）
                        if (sTemp < (Convert.ToSingle(this._dtoAnalyPara.TimeWindow) / OneHundred * dtoIngre.ReserveTime))
                        {
                            if (sMinDistance > sTemp)
                            {
                                dtoFind = dtoIngre;

                                //距离最近
                            }
                        }
                    }
                    break;
            }
            return dtoFind;
        }

        /// <summary>
        /// 根据成分表ID表的成分ID寻找对应的含量表
        /// </summary>
        /// <param name="dtoIngre"></param>
        /// <param name="dtoPeak"></param>
        /// <param name="sumFix"></param>
        /// <param name="innerVal">内标物的面积（高度）</param>
        private void FindKB(IngredientDto dtoIngre, PeakDto dtoPeak, ref Double sumFix, ref Single innerVal)
        {

            CalibrateDto dtoCalibrate = null;
            ArrayList arr = null;
            bool bFind = false;

            for (int i = 0; i < this._arrCali.Count; i++ )
            {
                arr = (ArrayList)this._arrCali[i];
                dtoCalibrate = (CalibrateDto)arr[0];
                if (dtoCalibrate.IngredientID == dtoIngre.IngredientID)
                {
                    bFind = true;
                    break;
                }
            }

            if (!bFind)
            {
                CastLog.Logger("CacuDensity", "FindKB", "Can not find Calibrate!");
                return;
            }
            int count = 0;

            //根据成分ID找出对应的含量表（CalibrateDto）数据
            switch (this._dtoAnalyPara.ArithmaticPara)
            {
                case ArithmaticParameter.Area:
                    foreach (CalibrateDto dtoCali in arr)
                    {
                        count++;
                        if (dtoPeak.AreaSize <= dtoCali.PeakSize || (dtoPeak.AreaSize > dtoCali.PeakSize && count == arr.Count))
                        {
                            dtoPeak.BaseK = dtoCali.FactorOne;
                            dtoPeak.BaseB = dtoCali.FactorTwo;
                            sumFix += dtoPeak.BaseK * dtoPeak.AreaSize + dtoPeak.BaseB;

                            if (dtoIngre.IsInnerPeak)
                            {
                                innerVal = dtoCali.PeakSize;
                            }
                            else if (Arithmatic.Inner == this._dtoAnalyPara.ArithmaticID)
                            {
                                MessageBox.Show(String.Format("峰ID={0}没有找到内标峰！",dtoPeak.PeakID), "提示");
                            }
                            break;
                        }
                    }
                    break;

                case ArithmaticParameter.Height:
                    foreach (CalibrateDto dtoCali in arr)
                    {
                        count++;
                        if (dtoPeak.PeakHeight <= dtoCali.PeakHeight || (dtoPeak.PeakHeight > dtoCali.PeakHeight && count == arr.Count))
                        {
                            dtoPeak.BaseK = dtoCali.FactorOne;
                            dtoPeak.BaseB = dtoCali.FactorTwo;
                            sumFix += dtoPeak.BaseK * dtoPeak.PeakHeight + dtoPeak.BaseB;

                            if (dtoIngre.IsInnerPeak)
                            {
                                innerVal = dtoCali.PeakHeight;
                            }
                            break;
                        }
                    }
                    break;
            }
        }

        #endregion 


        #region 带比例系数的修正归一法

        /// <summary>
        /// 带比例系数的修正归一法
        /// </summary>
        private void FixNormalizeWithRate()
        {
            Double sumFix = this.CacuKbAndSum();

            //算出符合条件的峰的浓度
            switch (this._dtoAnalyPara.ArithmaticPara)
            {
                case ArithmaticParameter.Area:
                    foreach (PeakDto dtoPeak in this._arrPeak)
                    {
                        if (0 != dtoPeak.BaseK)
                        {
                            dtoPeak.Density = Convert.ToSingle(
                                (dtoPeak.BaseK * dtoPeak.AreaSize + dtoPeak.BaseB) / sumFix * this._dtoAnalyPara.Ratio);
                        }
                    }
                    break;

                case ArithmaticParameter.Height:
                    foreach (PeakDto dtoPeak in this._arrPeak)
                    {
                        if (0 != dtoPeak.BaseK)
                        {
                            dtoPeak.Density = Convert.ToSingle(
                                (dtoPeak.BaseK * dtoPeak.PeakHeight + dtoPeak.BaseB) / sumFix * this._dtoAnalyPara.Ratio);
                        }
                    }
                    break;
            }
        }

        #endregion


        #region 内标法

        /// <summary>
        /// 内标法
        /// </summary>
        private void Inner()
        {
            //找出因子和内标
            Single innerVal = this.CacuKbAndInner();

            //算出符合条件的峰的浓度
            switch (this._dtoAnalyPara.ArithmaticPara)
            {
                case ArithmaticParameter.Area:
                    foreach (PeakDto dtoPeak in this._arrPeak)
                    {
                        if (0 != dtoPeak.BaseK)
                        {
                            dtoPeak.Density = Convert.ToSingle((dtoPeak.BaseK * dtoPeak.AreaSize / innerVal + dtoPeak.BaseB) /
                                (Convert.ToSingle(this.InnerWeight) / Convert.ToSingle(this.SampleWeight)) * OneHundred);
                        }
                    }
                    break;

                case ArithmaticParameter.Height:
                    foreach (PeakDto dtoPeak in this._arrPeak)
                    {
                        if (0 != dtoPeak.BaseK)
                        {
                            dtoPeak.Density = Convert.ToSingle((dtoPeak.BaseK * dtoPeak.PeakHeight / innerVal + dtoPeak.BaseB) /
                                (Convert.ToSingle(this.InnerWeight) / Convert.ToSingle(this.SampleWeight)) * OneHundred);
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 计算K,B,返回内标值
        /// </summary>
        /// <returns></returns>
        private Single CacuKbAndInner()
        {
            Single innerVal = 0;
            Double sumFix = 0;

            //取出所有峰的数据
            foreach (PeakDto dtoPeak in this._arrPeak)
            {
                //在峰鉴定表中寻找保留时间最接近的成分
                IngredientDto dtoIngre = this.FindIngreByReserveTime(dtoPeak);

                if (null != dtoIngre)
                {
                    this.FindKB(dtoIngre, dtoPeak, ref sumFix, ref innerVal);
                    dtoPeak.PeakName = dtoIngre.IngredientName;

                    //设置匹配标志
                    dtoIngre.IsMatch = true;
                }
            }

            return innerVal;
        }

        #endregion


        #region 外标法

        /// <summary>
        /// 绝对标准曲线法（外标）法
        /// </summary>
        private void Outer()
        {
            //找出因子和内标
            Double innerVal = this.CacuKbAndInner();

            //算出符合条件的峰的浓度
            switch (this._dtoAnalyPara.ArithmaticPara)
            {
                case ArithmaticParameter.Area:
                    foreach (PeakDto dtoPeak in this._arrPeak)
                    {
                        if (0 != dtoPeak.BaseK)
                        {
                            dtoPeak.Density = Convert.ToSingle(
                                (dtoPeak.BaseK * dtoPeak.AreaSize + dtoPeak.BaseB) / this.SampleWeight * OneHundred);
                        }
                    }
                    break;

                case ArithmaticParameter.Height:
                    foreach (PeakDto dtoPeak in this._arrPeak)
                    {
                        if (0 != dtoPeak.BaseK)
                        {
                            dtoPeak.Density = Convert.ToSingle(
                                (dtoPeak.BaseK * dtoPeak.PeakHeight + dtoPeak.BaseB) / this.SampleWeight * OneHundred);
                        }
                    }
                    break;
            }
        }

        #endregion


        #region 指数法

        /// <summary>
        /// 指数计算法
        /// </summary>
        private void Exponent()
        {
            //找出因子和内标
            Single innerVal = this.CacuKbAndInner();

            //算出符合条件的峰的浓度
            switch (this._dtoAnalyPara.ArithmaticPara)
            {
                case ArithmaticParameter.Area:
                    foreach (PeakDto dtoPeak in this._arrPeak)
                    {
                        if (0 != dtoPeak.BaseK)
                        {
                            dtoPeak.Density = Convert.ToSingle(Math.Exp(dtoPeak.BaseK * Math.Log(dtoPeak.AreaSize) + dtoPeak.BaseB))
                                / this.SampleWeight * OneHundred;
                        }
                    }
                    break;

                case ArithmaticParameter.Height:
                    foreach (PeakDto dtoPeak in this._arrPeak)
                    {
                        if (0 != dtoPeak.BaseK)
                        {
                            dtoPeak.Density = Convert.ToSingle(Math.Exp(dtoPeak.BaseK * Math.Log(dtoPeak.PeakHeight) + dtoPeak.BaseB))
                                / this.SampleWeight * OneHundred;
                        }
                    }
                    break;
            }
        }

        #endregion




    }
}
