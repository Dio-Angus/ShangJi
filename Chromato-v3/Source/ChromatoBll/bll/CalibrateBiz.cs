/*-----------------------------------------------------------------------------
//  FILE NAME       : CalibrateBiz.cs
//  FUNCTION        : 含量表的逻辑
//  AUTHOR          : 李锋(2009/05/15)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoBll.dao;
using System.Data;
using ChromatoTool.dto;
using System.Collections;
using System.Windows.Forms;
using ChromatoTool.ini;

namespace ChromatoBll.bll
{
    /// <summary>
    /// 含量表的逻辑
    /// </summary>
    public class CalibrateBiz
    {
        
        #region 常量

        /// <summary>
        /// 一百
        /// </summary>
        private Single OneHundred = 100;

        #endregion 


        #region 变量

        /// <summary>
        /// 参数Dao
        /// </summary>
        private CalibrateDao daoCalibrate = null;

        /// <summary>
        /// 编辑和新建时需要保存的含量表dto
        /// </summary>
        private ArrayList _arr = null;

        #endregion

        
        #region 构造
        
        /// <summary>
        /// 构造
        /// </summary>
        public CalibrateBiz()
        {
            this.daoCalibrate = new CalibrateDao();
            this._arr = new ArrayList();
        }

        #endregion


        #region 访问数据库方法

        /// <summary>
        /// 查询含量表
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCalibrate()
        {
            return this.daoCalibrate.LoadCalibrate();
        }

        /// <summary>
        /// 更新含量表
        /// </summary>
        public void UpdateDb()
        {
            this.daoCalibrate.UpdateDb();
        }

        /// <summary>
        /// 清空队列,重新通过id表id装载队列
        /// </summary>
        public void ResetArray(int idTableID)
        {
            this._arr.Clear();

            DataSet ds = this.daoCalibrate.LoadCaliByIdTableID(idTableID);

            if (null == ds || null == ds.Tables[0])
            {
                return;
            }

            CalibrateDto dtoCali = null;

            //追加到列表
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dtoCali = new CalibrateDto();
                dtoCali.IDTableID = Convert.ToInt32(ds.Tables[0].Rows[i]["IDTableID"].ToString());
                dtoCali.IngredientID = Convert.ToInt32(ds.Tables[0].Rows[i]["IngredientID"].ToString());
                dtoCali.CalibrateID = Convert.ToInt32(ds.Tables[0].Rows[i]["CalibrateID"].ToString());
                dtoCali.Density = Convert.ToSingle(ds.Tables[0].Rows[i]["Density"].ToString());
                dtoCali.PeakHeight = Convert.ToSingle(ds.Tables[0].Rows[i]["PeakHeight"].ToString());
                dtoCali.PeakSize = Convert.ToSingle(ds.Tables[0].Rows[i]["PeakSize"].ToString());
                dtoCali.SampleWeight = Convert.ToInt32(ds.Tables[0].Rows[i]["SampleWeight"].ToString());
                dtoCali.FactorOne = Convert.ToSingle(ds.Tables[0].Rows[i]["FactorOne"].ToString());
                dtoCali.FactorTwo = Convert.ToSingle(ds.Tables[0].Rows[i]["FactorTwo"].ToString());
                this._arr.Add(dtoCali);
            }
        }

        /// <summary>
        /// 通过ID表ID,成分id在数据库中查询该成分的详细
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public DataSet LoadCalibrateInDbById(IngredientDto dto)
        {
            return this.daoCalibrate.LoadCalibrateById(dto);
        }

        /// <summary>
        /// 删除含量
        /// </summary>
        /// <param name="dto"></param>
        private void DeleteCalibrate(CalibrateDto dto)
        {
            this.daoCalibrate.DeleteCalibrate(dto);
        }

        /// <summary>
        /// 更新含量表方法
        /// </summary>
        /// <param name="dtoCali"></param>
        public void UpdateMethod(CalibrateDto dtoCali)
        {
            //先删除
            this.DeleteCalibrate(dtoCali);

            //再插入
            this.InsertArray();
        }

        /// <summary>
        /// 插入新方法到数据库
        /// </summary>
        public void InsertArray()
        {
            CalibrateDto dto = null;
            for (int i = 0; i < this._arr.Count; i++)
            {
                dto = (CalibrateDto)this._arr[i];
                this.daoCalibrate.InsertCalibrate(dto);
            }
        }

        #endregion


        #region 内存访问逻辑

        /// <summary>
        /// 通过ID表ID,成分id在队列中查询该成分的详细
        /// </summary>
        /// <param name="dtoIngre"></param>
        /// <returns></returns>
        public DataSet LoadCalibrateInArrayById(IngredientDto dtoIngre)
        {
            DataSet ds = new DataSet();
            DataTable dtCail = ds.Tables.Add("T_Calibrate");

            dtCail.Columns.Add("IDTableID");
            dtCail.Columns.Add("IngredientID");
            dtCail.Columns.Add("CalibrateID");
            dtCail.Columns.Add("SampleID");
            dtCail.Columns.Add("PeakSize");
            dtCail.Columns.Add("PeakHeight");
            dtCail.Columns.Add("Density");
            dtCail.Columns.Add("SampleWeight");
            dtCail.Columns.Add("FactorOne");
            dtCail.Columns.Add("FactorTwo");

            DataRow dr = null;

            CalibrateDto dto = null;
            for (int i = 0; i < this._arr.Count; i++)
            {
                dto = (CalibrateDto)this._arr[i];
                if (dto.IDTableID == dtoIngre.IDTableID && dto.IngredientID == dtoIngre.IngredientID)
                {
                    dr = dtCail.NewRow();
                    dr["IDTableID"] = dto.IDTableID.ToString();
                    dr["IngredientID"] = dto.IngredientID.ToString();
                    dr["CalibrateID"] = dto.CalibrateID.ToString();
                    //dr["SampleID"] = dto.SampleID.ToString();
                    dr["PeakSize"] = dto.PeakSize.ToString();
                    dr["PeakHeight"] = dto.PeakHeight.ToString();
                    dr["Density"] = dto.Density.ToString();
                    dr["SampleWeight"] = dto.SampleWeight.ToString();
                    dr["FactorOne"] = dto.FactorOne.ToString();
                    dr["FactorTwo"] = dto.FactorTwo.ToString();
                    ds.Tables[0].Rows.Add(dr);
                }
            }

            return ds;
        }

        /// <summary>
        /// 更新列表
        /// </summary>
        /// <param name="dtoCali"></param>
        public void UpdateArray(CalibrateDto dtoCali)
        {
            CalibrateDto dto = null;
            for (int i = 0; i < this._arr.Count; i++)
            {
                dto = (CalibrateDto)this._arr[i];

                if (dto.IDTableID == dtoCali.IDTableID && dto.IngredientID == dtoCali.IngredientID
                    && dto.CalibrateID == dtoCali.CalibrateID)
                {
                    dto.Density = dtoCali.Density;
                    dto.PeakHeight = dtoCali.PeakHeight;
                    dto.PeakSize = dtoCali.PeakSize;
                    dto.FactorOne = dtoCali.FactorOne;
                    dto.FactorTwo = dtoCali.FactorTwo;
                }

                if (dto.IDTableID == dtoCali.IDTableID && dto.CalibrateID == dtoCali.CalibrateID)
                {
                    dto.SampleWeight = dtoCali.SampleWeight;
                }

            }
        }

        /// <summary>
        /// 在列表中计算新的ID
        /// </summary>
        /// <param name="dtoCali"></param>
        /// <returns></returns>
        public int GetNewIngredientIdInArray(CalibrateDto dtoCali)
        {
            CalibrateDto dto = null;

            //计算ID
            int caliID = 0;
            for (int i = 0; i < this._arr.Count; i++)
            {
                dto = (CalibrateDto)this._arr[i];

                if (dtoCali.IngredientID == dto.IngredientID && caliID <= dto.CalibrateID)
                {
                    caliID = dto.CalibrateID;
                }
            }
            caliID++;
            return caliID;
        }

        /// <summary>
        /// 插入一条dto到列表
        /// </summary>
        /// <param name="dto"></param>
        public void InsertToArray(CalibrateDto dto)
        {
            CalibrateDto newDto = new CalibrateDto();
            newDto.IDTableID = dto.IDTableID;
            newDto.IngredientID = dto.IngredientID;
            newDto.CalibrateID = dto.CalibrateID;
            newDto.Density = dto.Density;
            newDto.PeakHeight = dto.PeakHeight;
            newDto.PeakSize = dto.PeakSize;
            newDto.SampleWeight = dto.SampleWeight;
            newDto.FactorOne = dto.FactorOne;
            newDto.FactorTwo = dto.FactorTwo;
            this._arr.Add(newDto);
        }

        /// <summary>
        /// 删除列表中一条dto
        /// </summary>
        /// <param name="dtoCali"></param>
        public void RemoveInArray(CalibrateDto dtoCali)
        {
            CalibrateDto dto = null;
            for (int i = 0; i < this._arr.Count; i++)
            {
                dto = (CalibrateDto)this._arr[i];
                if (dto.IDTableID == dtoCali.IDTableID &&
                    dto.IngredientID == dtoCali.IngredientID &&
                    dto.CalibrateID == dtoCali.CalibrateID)
                {
                    this._arr.Remove(dto);
                    break;
                }
            }
        }

        /// <summary>
        /// 重新设置队列
        /// </summary>
        /// <param name="arr"></param>
        public void ResetArray(ArrayList arr)
        {
            this._arr = arr;
        }

        /// <summary>
        /// 检查浓度面积输入是否合法
        /// </summary>
        /// <returns></returns>
        public bool CheckDensityInArray()
        {
            bool bRet = true;
            CalibrateDto dto = null;

            for (int i = 0; i < this._arr.Count; i++)
            {
                dto = (CalibrateDto)this._arr[i];
                if (0 > dto.Density)
                {
                    MessageBox.Show("成分" + dto.IngredientID + ":浓度输入小于零!","提示");
                    bRet = false;
                    break;
                }
                if (0 > dto.PeakSize)
                {
                    MessageBox.Show("成分" + dto.IngredientID + ":峰面积小于零!", "提示");
                    bRet = false;
                    break;
                }

                if (0 > dto.PeakHeight)
                {
                    MessageBox.Show("成分" + dto.IngredientID + ":峰高度小于零!", "提示");
                    bRet = false;
                    break;
                }
            }
            return bRet;
        }

        /// <summary>
        /// 通过ID表ID,成分id在队列中查询该成分的详细
        /// </summary>
        /// <param name="dtoIngre"></param>
        /// <param name="dtoAnaly"></param>
        /// <param name="arrPoly"></param>
        /// <param name="arrSimu"></param>
        public void LoadCalibrateForCorrectPlot(IngredientDto dtoIngre, AnalyParaDto dtoAnaly, ref ArrayList arrPoly, ref ArrayList arrSimu)
        {
            ArrayList arrTemp = new ArrayList();
            CalibrateDto dto = null;
            CalibrateDto dtoCali = null;
            Single maxSizeHeight = 0;

            for (int i = 0; i < this._arr.Count; i++)
            {
                dto = (CalibrateDto)this._arr[i];
                if (dto.IDTableID == dtoIngre.IDTableID && dto.IngredientID == dtoIngre.IngredientID)
                {
                    switch(dtoAnaly.ArithmaticPara)
                    {
                        case ArithmaticParameter.Area:
                            dto.SizeHeight = dto.PeakSize;
                            dto.DensityTemp = dto.Density;
                            break;
                        case ArithmaticParameter.Height:
                            dto.SizeHeight = dto.PeakHeight;
                            dto.DensityTemp = dto.Density;
                           break;
                    }
                    arrTemp.Add(dto);
                }
            }

            arrTemp = this.SortCali(arrTemp, (ArithmaticParameter)dtoAnaly.ArithmaticPara);

            switch (dtoAnaly.FixWay)
            {
                case FixCurveWay.PolyLine:

                    //添加了（0，0）点
                    dtoCali = new CalibrateDto();
                    dtoCali.SizeHeight = 0;
                    dtoCali.DensityTemp = 0;
                    arrTemp.Insert(0,dtoCali);
                    arrPoly = arrTemp;
                    break;

                case FixCurveWay.SimuLine:
                    //添加了（0，0）点
                    dtoCali = new CalibrateDto();
                    dtoCali.SizeHeight = 0;
                    dtoCali.DensityTemp = 0;
                    arrTemp.Insert(0, dtoCali);
                    arrPoly = arrTemp;
                    
                    dto = (CalibrateDto)arrTemp[0];

                    //添加了（0，b）点
                    dtoCali = new CalibrateDto();
                    dtoCali.SizeHeight = 0;
                    dtoCali.DensityTemp = dto.FactorTwo;
                    arrSimu.Add(dtoCali);

                    //添加了（max，y）点
                    maxSizeHeight = dto.SizeHeight;
                    for (int i = 1; i < arrTemp.Count; i++)
                    {
                        dto = (CalibrateDto)arrTemp[i];
                        if (maxSizeHeight < dto.SizeHeight)
                        {
                            maxSizeHeight = dto.SizeHeight;
                        }
                    }
                    dtoCali = new CalibrateDto();
                    dtoCali.SizeHeight = maxSizeHeight;
                    dtoCali.DensityTemp = dto.FactorOne * maxSizeHeight + dto.FactorTwo;
                    arrSimu.Add(dtoCali);

                    break;
            }

        }

        /// <summary>
        /// 通过ID表ID,成分id在队列中查询该成分的详细
        /// </summary>
        /// <param name="dtoIngre">成分单元</param>
        /// <returns>含量队列</returns>
        public ArrayList LoadCalibrateInArray(IngredientDto dtoIngre)
        {
            ArrayList arrCali = new ArrayList();
            CalibrateDto dto = null;

            for (int i = 0; i < this._arr.Count; i++)
            {
                dto = (CalibrateDto)this._arr[i];
                if (dto.IDTableID == dtoIngre.IDTableID && dto.IngredientID == dtoIngre.IngredientID)
                {
                    arrCali.Add(dto);
                }
            }
            return arrCali;
        }

        /// <summary>
        /// 根据浓度面积计算因子值
        /// </summary>
        /// <param name="arrIngre">成份队列</param>
        /// <param name="dtoAnalyPara">分析方法单元</param>
        public void CacuFactorInArray(ArrayList arrIngre, AnalyParaDto dtoAnalyPara)
        {
            CalibrateDto dtoCali = null;
            ArrayList arrTemp = new ArrayList();

            //内标峰对应的含量列表
            ArrayList arrInner = new ArrayList();

            //在内标法中判断是否存在内标峰
            if (Arithmatic.Inner == dtoAnalyPara.ArithmaticID)
            {
                foreach (IngredientDto dtoIngre in arrIngre)
                {
                    //内标峰
                    if (dtoIngre.IsInnerPeak)
                    {
                        for (int j = 0; j < this._arr.Count; j++)
                        {
                            dtoCali = (CalibrateDto)this._arr[j];
                            if (dtoIngre.IngredientID == dtoCali.IngredientID)
                            {
                                arrInner.Add(dtoCali);
                            }
                        }
                    }
                }
                if (0 == arrInner.Count)
                {
                    MessageBox.Show("无法计算,不存在内标峰!", "提示");
                    return;
                }
            }

            //计算k,b
            foreach (IngredientDto dtoIngre in arrIngre)
            {
                arrTemp.Clear();

                for (int j = 0; j < this._arr.Count; j++)
                {
                    dtoCali = (CalibrateDto)this._arr[j];
                    if (dtoIngre.IngredientID == dtoCali.IngredientID)
                    {
                        arrTemp.Add(dtoCali);
                    }
                }

                if (Arithmatic.Inner == dtoAnalyPara.ArithmaticID && arrInner.Count != arrTemp.Count)
                {
                    MessageBox.Show("无法计算,成分中含量不同!", "提示");
                    return;
                }
                else if (0 == arrTemp.Count)
                {
                    MessageBox.Show("成分" + dtoIngre.IngredientID + ":不存在含量!", "提示");
                    return;
                }
                else
                {
                    //根据不同的校正方法计算因子
                    switch (dtoAnalyPara.FixWay)
                    {
                        case FixCurveWay.PolyLine:
                            arrTemp = this.SortCali(arrTemp, (ArithmaticParameter)dtoAnalyPara.ArithmaticPara);

                            //重新计算浓度和面积的中间变量
                            this.CacuTempValue(arrTemp, dtoAnalyPara, arrInner);

                            this.CacuFactoryByPolyline(arrTemp, dtoAnalyPara);
                            break;

                        case FixCurveWay.SimuLine:
                            arrTemp = this.SortCali(arrTemp, (ArithmaticParameter)dtoAnalyPara.ArithmaticPara);

                            //重新计算浓度和面积的中间变量
                            this.CacuTempValue(arrTemp, dtoAnalyPara, arrInner);

                            this.CacuFactoryBySimuline(arrTemp, dtoAnalyPara);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 根据面积大小对含量排序
        /// </summary>
        /// <param name="arrCali">含量队列</param>
        /// <param name="fixPara">计算参数</param>
        /// <returns>排序后的含量队列</returns>
        private ArrayList SortCali(ArrayList arrCali, ArithmaticParameter fixPara)
        {
            ArrayList arrTemp = new ArrayList();
            CalibrateDto dtoCaliMin = null;
            CalibrateDto dto = null;

            while (0 < arrCali.Count)
            {
                dtoCaliMin = (CalibrateDto)arrCali[0];
                for (int i = 1; i < arrCali.Count; i++)
                {
                    dto = (CalibrateDto)arrCali[i];
                    switch (fixPara)
                    {
                        case ArithmaticParameter.Area:
                            if (dtoCaliMin.PeakSize > dto.PeakSize)
                            {
                                dtoCaliMin = dto;
                            }
                            break;
                        case ArithmaticParameter.Height:
                            if (dtoCaliMin.PeakHeight > dto.PeakHeight)
                            {
                                dtoCaliMin = dto;
                            } 
                            break;
                    }
                }
                arrCali.Remove(dtoCaliMin);
                arrTemp.Add(dtoCaliMin);
            }

            return arrTemp;
        }

        /// <summary>
        /// 计算因子1和因子2
        /// </summary>
        /// <param name="arrCali">含量队列</param>
        /// <param name="dtoAnalyPara">分析方法单元</param>
        /// <param name="arrInner">内标队列</param>
        private void CacuTempValue(ArrayList arrCali, AnalyParaDto dtoAnalyPara, ArrayList arrInner)
        {
            CalibrateDto dto = null;
            CalibrateDto dtoCaliInner = null;

            switch (dtoAnalyPara.ArithmaticID)
            {
                case Arithmatic.FixNormalize:
                case Arithmatic.FixNormalizeWithRate:
                    for (int i = 0; i < arrCali.Count; i++)
                    {
                        dto = (CalibrateDto)arrCali[i];
                        dto.DensityTemp = dto.Density;

                        if (ArithmaticParameter.Area == dtoAnalyPara.ArithmaticPara)
                        {
                            dto.SizeHeight = dto.PeakSize;
                        }
                        else if (ArithmaticParameter.Height == dtoAnalyPara.ArithmaticPara)
                        {
                            dto.SizeHeight = dto.PeakHeight;
                        }
                    }
                    break;

                case Arithmatic.Inner:
                    for (int i = 0; i < arrCali.Count; i++)
                    {
                        dto = (CalibrateDto)arrCali[i];
                        dtoCaliInner = (CalibrateDto)arrInner[i];
                        dto.DensityTemp = dto.Density / dtoCaliInner.Density;

                        if (ArithmaticParameter.Area == dtoAnalyPara.ArithmaticPara)
                        {
                            dto.SizeHeight = dto.PeakSize / dtoCaliInner.PeakSize;
                        }
                        else if (ArithmaticParameter.Height == dtoAnalyPara.ArithmaticPara)
                        {
                            dto.SizeHeight = dto.PeakHeight / dtoCaliInner.PeakHeight;
                        }
                    }
                    break;

                case Arithmatic.Outer:
                    for (int i = 0; i < arrCali.Count; i++)
                    {
                        dto = (CalibrateDto)arrCali[i];
                        dto.DensityTemp = dto.Density * dto.SampleWeight / OneHundred;

                        if (ArithmaticParameter.Area == dtoAnalyPara.ArithmaticPara)
                        {
                            dto.SizeHeight = dto.PeakSize * dto.SampleWeight / OneHundred;
                        }
                        else if (ArithmaticParameter.Height == dtoAnalyPara.ArithmaticPara)
                        {
                            dto.SizeHeight = dto.PeakHeight * dto.SampleWeight / OneHundred;
                        }
                    }
                    break;

                case Arithmatic.Exponent:
                    for (int i = 0; i < arrCali.Count; i++)
                    {
                        dto = (CalibrateDto)arrCali[i];
                        dto.DensityTemp = Convert.ToSingle(Math.Log(dto.Density));

                        if (ArithmaticParameter.Area == dtoAnalyPara.ArithmaticPara)
                        {
                            dto.SizeHeight = Convert.ToSingle( Math.Log(dto.PeakSize));
                        }
                        else if (ArithmaticParameter.Height == dtoAnalyPara.ArithmaticPara)
                        {
                            dto.SizeHeight = Convert.ToSingle( Math.Log(dto.PeakHeight));
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 通过中间变量计算因子
        /// 采用折线法,计算响应因子
        /// 
        /// y = k * x + b
        /// k = (y2-y1)/(x2-x1)
        /// b = y2 - k * x2
        /// </summary>
        /// <param name="arrCali">含量队列</param>
        /// <param name="dtoAnalyPara">分析方法单元</param>
        private void CacuFactoryByPolyline(ArrayList arrCali, AnalyParaDto dtoAnalyPara)
        {
            CalibrateDto dto1 = null;
            CalibrateDto dto2 = null;

            if (Arithmatic.Normalize == dtoAnalyPara.ArithmaticID)
            {
                return;
            }

            //非归一法
            dto1 = (CalibrateDto)arrCali[0];
            if (0 == dto1.SizeHeight)
            {
                MessageBox.Show("面积或者高度为0!","警告");
                return;
            }
            dto1.FactorOne = Convert.ToSingle(Math.Round((dto1.DensityTemp / dto1.SizeHeight), 9));
            dto1.FactorTwo = 0;

            switch (dtoAnalyPara.ArithmaticID)
            {
                case Arithmatic.FixNormalize:
                case Arithmatic.FixNormalizeWithRate:
                case Arithmatic.Inner:
                case Arithmatic.Outer:
                    for (int i = 1; i < arrCali.Count; i++)
                    {
                        dto1 = (CalibrateDto)arrCali[i - 1];
                        dto2 = (CalibrateDto)arrCali[i];

                        //避免了除数为0
                        if (dto2.SizeHeight == dto1.SizeHeight)
                        {
                            dto2.FactorOne = 0;
                            dto2.FactorTwo = 0;
                        }
                        else
                        {
                            dto2.FactorOne = Convert.ToSingle(Math.Round((dto2.DensityTemp - dto1.DensityTemp) / (dto2.SizeHeight - dto1.SizeHeight), 9));
                            dto2.FactorTwo = Convert.ToSingle(Math.Round((dto2.DensityTemp - dto2.FactorOne * dto2.SizeHeight), 9));
                        }
                    }
                    break;

                case Arithmatic.Exponent:
                    for (int i = 1; i < arrCali.Count; i++)
                    {
                        dto1 = (CalibrateDto)arrCali[i - 1];
                        dto2 = (CalibrateDto)arrCali[i];

                        if (dto2.SizeHeight == dto1.SizeHeight)
                        {
                            dto2.FactorOne = 0;
                            dto2.FactorTwo = 0;
                        }
                        else
                        {
                            dto2.FactorOne = Convert.ToSingle(Math.Round((dto2.DensityTemp - dto1.DensityTemp) / (dto2.SizeHeight - dto1.SizeHeight), 9));
                            dto2.FactorTwo = Convert.ToSingle(Math.Round((dto2.DensityTemp - dto2.FactorOne * dto2.SizeHeight - Math.Log(OneHundred / dto2.SampleWeight)), 9));
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 采用拟和直线法,计算响应因子
        /// </summary>
        /// <param name="arrTemp">含量队列</param>
        /// <param name="dtoAnalyPara">分析方法单元</param>
        private void CacuFactoryBySimuline(ArrayList arrTemp, AnalyParaDto dtoAnalyPara)
        {

            Double sumX = 0;
            Double sumDesity = 0;
            Double sum3 = 0;
            Double sum4 = 0;
            Double count = arrTemp.Count + 1;

            Double avgX = 0;
            Double avgDesity = 0;
            Double valX = 0;
            Double valDesity = 0;

            Double k = 0;
            Double b = 0;

            if (Arithmatic.Normalize == dtoAnalyPara.ArithmaticID)
            {
                return;
            }

            //非归一法
            foreach (CalibrateDto dto in arrTemp)
            {
                sumX += dto.SizeHeight;
                sumDesity += dto.DensityTemp;
                sum3 += dto.SizeHeight * dto.DensityTemp;
                sum4 += dto.SizeHeight * dto.SizeHeight;
            }

            avgX = sumX / count;
            avgDesity = sumDesity / count;

            valX = sum3 - count * avgX * avgDesity;
            valDesity = sum4 - count * avgX * avgX;

            k = valX / valDesity;
            b = avgDesity - k * avgX;

            switch (dtoAnalyPara.ArithmaticID)
            {
                case Arithmatic.FixNormalize:
                case Arithmatic.FixNormalizeWithRate:
                case Arithmatic.Inner:
                case Arithmatic.Outer:
                    foreach (CalibrateDto dto in arrTemp)
                    {
                        dto.FactorOne = Convert.ToSingle(k);
                        dto.FactorTwo = Convert.ToSingle(b);
                    }
                    break;

                case Arithmatic.Exponent:
                    foreach (CalibrateDto dto in arrTemp)
                    {
                        dto.FactorOne = Convert.ToSingle(k);
                        dto.FactorTwo = Convert.ToSingle(b) - Convert.ToSingle(Math.Log(OneHundred / dto.SampleWeight));
                    }
                    break;
            }
        }

        /// <summary>
        /// 清空列表
        /// </summary>
        public void ClearArray()
        {
            this._arr.Clear();
        }

        #endregion



    }
}
