/*-----------------------------------------------------------------------------
//  FILE NAME       : OffGasSumBiz.cs
//  FUNCTION        : 管道气样品汇总的逻辑
//  AUTHOR          : 李锋(2010/04/29)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


using System;
using System.Collections;
using System.Data;
using ChromatoTool.dto;
using System.Windows.Forms;
using ChromatoTool.ini;

namespace ChromatoBll.bll
{
    /// <summary>
    /// 管道气样品汇总的逻辑
    /// </summary>
    public class OffGasSumBiz
    {

        #region 常量

        /// <summary>
        /// 一百
        /// </summary>
        private Single OneHundred = 100;

        #endregion 


        #region 变量


        /// <summary>
        /// 选中的样品列表
        /// </summary>
        public ArrayList _arr = null;

        /// <summary>
        /// 选中的样品结果列表
        /// </summary>
        public DataTable _dsResult = null;

        /// <summary>
        /// 峰结果逻辑
        /// </summary>
        private PeakBiz _bizPeak = null;

        /// <summary>
        /// 方案逻辑，查询方案名
        /// </summary>
        private SolutionBiz _bizSolu = null;

        #endregion

        
        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OffGasSumBiz()
        {

            this._arr = new ArrayList();
            this._dsResult = new DataTable("T_GasSum");

            this._dsResult.Columns.Add("峰ID");
            this._dsResult.Columns.Add("组分名");
            this._dsResult.Columns.Add("保留时间");
            this._dsResult.Columns.Add("峰高(微伏)");
            this._dsResult.Columns.Add("峰面积(微伏*秒)");
            this._dsResult.Columns.Add("浓度");
            this._dsResult.Columns.Add("类型");

            this._bizPeak = new PeakBiz();
            this._bizSolu = new SolutionBiz();
        }

        #endregion


        #region 方法

        /// <summary>
        /// 通过样品装载分析结果
        /// </summary>
        /// <returns></returns>
        public bool LoadResultByArr()
        {
            this._dsResult.Clear();

            DataSet ds = null;
            String temp = "";
            DataRow drNew = null;

            // 样品计数器
            int count = 0;

            // 分析方法
            AnalyParaDto dtoAnalyPara = null;

            foreach (ParaDto dto in this._arr)
            {
                ds = this._bizPeak.LoadPrintPeakResult(dto.PathData);
                if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
                {
                    temp = String.Format("样品 {0} 没有分析结果", dto.SampleName);
                    MessageBox.Show(temp, "提示");
                    return false;
                }

                if (!this.CanArithmatic(dto, ref dtoAnalyPara))
                {
                    return false;
                }

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    drNew = this._dsResult.NewRow();

                    //开始作为中间变量，记录样品id
                    drNew["峰ID"] = count;

                    drNew["组分名"] = dr[(int)PrintItem.Name].ToString();
                    drNew["保留时间"] = dr[(int)PrintItem.ReserveTime].ToString();
                    drNew["峰高(微伏)"] = dr[(int)PrintItem.Height].ToString();
                    drNew["峰面积(微伏*秒)"] = dr[(int)PrintItem.AreaSize].ToString();
                    drNew["浓度"] = dr[(int)PrintItem.Density].ToString();
                    drNew["类型"] = dr[(int)PrintItem.PeakType].ToString();
                    this._dsResult.Rows.Add(drNew);

                }
                count++;
            }

            switch (dtoAnalyPara.ArithmaticID)
            {
                case Arithmatic.Normalize:
                    this.ReCacuDesityByNormal(dtoAnalyPara);
                    break;

                case Arithmatic.Outer:
                    this.ReCacuDesityByOuter(dtoAnalyPara);
                    break;
                default:
                    break;
            }


            return true;
        }

        /// <summary>
        /// 能否计算（归一法或者外标法可以计算）
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="dtoAnalyPara"></param>
        /// <returns></returns>
        private bool CanArithmatic(ParaDto dto, ref AnalyParaDto dtoAnalyPara)
        {
            String temp = "";

            //输出样品名和色谱柱型号
            SolutionDto dtoSolu = new SolutionDto();
            RelationDto dtoRela = new RelationDto();

            dtoRela.SampleID = dto.SampleID;
            dtoRela.RegisterTime = dto.RegisterTime;
            dtoSolu.SolutionID = Convert.ToInt32(this._bizSolu.GetSolutionID(dtoRela));
            if (0 == dtoSolu.SolutionID)
            {
                temp = String.Format("样品 {0}：没有指定方案！", dto.SampleName);
                MessageBox.Show(temp, "提示");
                return false;
            }
            this._bizSolu.QuerySolu(dtoSolu);
            AnalyParaBiz bizAnaly = new AnalyParaBiz();
            AnalyParaDto dtoAnaly = new AnalyParaDto();

            dtoAnaly.AnalyParaID = dtoSolu.AnalyParaID;
            bizAnaly.GetMethodByID(dtoAnaly);

            if (null != dtoAnalyPara && dtoAnalyPara.ArithmaticID != dtoAnaly.ArithmaticID)
            {
                MessageBox.Show("样品的计算方法不同！", "提示");
                return false;
            }

            switch (dtoAnaly.ArithmaticID)
            {
                case Arithmatic.Normalize:
                    break;
                case Arithmatic.Outer:
                    if (0 == dto.SampleWeight)
                    {
                        temp = String.Format("样品 {0}：样品量为0！", dto.SampleName);
                        MessageBox.Show(temp, "提示");
                        return false;
                    }
                    break;
                default:
                    temp = String.Format("样品 {0}：计算方法不是归一法或者外标法！", dto.SampleName);
                    MessageBox.Show(temp, "提示");
                    return false;
            }

            dtoAnalyPara = dtoAnaly;
            return true;
        }

        /// <summary>
        /// 归一法汇总
        /// </summary>
        /// <param name="dtoAnaly"></param>
        private void ReCacuDesityByNormal(AnalyParaDto dtoAnaly)
        {
            // 峰面积/高度 总和
            Single sum = 0;

            //归一法汇总，重新根据面积,高度,计算浓度
            Single density = 0;

            // 峰ID
            int count = 1;

            switch (dtoAnaly.ArithmaticPara)
            {
                case ArithmaticParameter.Area:

                    //总和
                    foreach (DataRow dr in this._dsResult.Rows)
                    {
                        sum += Convert.ToSingle(dr[(int)PrintItem.AreaSize].ToString());
                    }

                    foreach (DataRow dr in this._dsResult.Rows)
                    {
                        density = Convert.ToSingle(dr[(int)PrintItem.AreaSize].ToString());
                        dr[(int)PrintItem.Density] = density / sum * OneHundred;
                        dr[(int)PrintItem.Id] = count++;
                    }
                    break;

                case ArithmaticParameter.Height:
                    //总和
                    foreach (DataRow dr in this._dsResult.Rows)
                    {
                        sum += Convert.ToSingle(dr[(int)PrintItem.Height].ToString());
                    }

                    foreach (DataRow dr in this._dsResult.Rows)
                    {
                        density = Convert.ToSingle(dr[(int)PrintItem.Height].ToString());
                        dr[(int)PrintItem.Density] = density / sum * OneHundred;
                    }
                    break;
            }
        }
        
        /// <summary>
        /// 外标法汇总
        /// A中组分浓度 A1 A2 A3   B中组分B1 B2  C中组分 C1 C2， 
        /// 新的浓度计算过程为：（1） A1=A1/Wa A2=A2/Wa B1=B1/Wb C1=C1/Wc ….。
        ///                     （2） W=A1+A2+A3+B1+…. 
        ///                     （3） A1=A1/W*100 …
        /// </summary>
        /// <param name="dtoAnaly"></param>
        private void ReCacuDesityByOuter(AnalyParaDto dtoAnaly)
        {
            // 浓度 总和
            Single sum = 0;

            //外标法汇总，重新计算浓度
            Single density = 0;

            // 样品计数器
            int count = 0;

            // 总和
            foreach (ParaDto dto in this._arr)
            {
                foreach (DataRow dr in this._dsResult.Rows)
                {
                    if (count == Convert.ToSingle(dr[(int)PrintItem.Id].ToString()))
                    {
                        density = Convert.ToSingle(dr[(int)PrintItem.Density].ToString()) / dto.SampleWeight;
                        dr[(int)PrintItem.Density] = density.ToString();
                        sum += density;
                    }
                }

                count++;
            }

            // 峰ID
            count = 1;

            // 计算浓度
            foreach (DataRow dr in this._dsResult.Rows)
            {
                density = Convert.ToSingle(dr[(int)PrintItem.Density].ToString());
                dr[(int)PrintItem.Density] = density / sum * OneHundred;
                dr[(int)PrintItem.Id] = count++;
            }
        }

        #endregion

    }
}
