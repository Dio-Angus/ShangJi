/*-----------------------------------------------------------------------------
//  FILE NAME       : AnalyParaDao.cs
//  FUNCTION        : 分析参数访问Dao
//  AUTHOR          : 李锋(2009/04/30)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.db;
using System.Data;
using ChromatoTool.dto;
using ChromatoTool.ini;

namespace ChromatoBll.dao
{
    /// <summary>
    /// 分析参数访问Dao
    /// </summary>
    public class AnalyParaDao
    {

        #region 变量

        /// <summary>
        /// 库操作类
        /// </summary>
        private SqliteHelper _sqlHelper = null;

        /// <summary>
        /// 分析参数数据集合
        /// </summary>
        private DataSet _ds = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public AnalyParaDao()
        {
            _sqlHelper = new SqliteHelper();
        }

        #endregion


        #region 访问数据库方法

        /// <summary>
        /// 查询分析参数
        /// </summary>
        /// <returns></returns>
        public DataSet LoadMethod()
        {
            String sql = "SELECT * FROM T_AnalyPara ";
            this._ds = _sqlHelper.GetDs(sql);
            return this._ds;
        }

        /// <summary>
        /// 查询分析参数
        /// </summary>
        /// <returns></returns>
        internal DataSet LoadMethodName()
        {
            String sql = "SELECT AnalyParaID,AnalyName FROM T_AnalyPara ";
            this._ds = _sqlHelper.GetDs(sql);
            return this._ds;
        }

        /// <summary>
        /// 查询是否存在该分析参数
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private int LoadMethod(AnalyParaDto dto)
        {
            String sql = "SELECT * FROM T_AnalyPara Where AnalyParaID =" + dto.AnalyParaID;
            DataSet ds = _sqlHelper.GetDs(sql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return 0;
            }
            return ds.Tables[0].Rows.Count;
        }

        /// <summary>
        /// 通过分析参数ID确定分析参数
        /// </summary>
        /// <param name="dto"></param>
        public void GetMethodByID(AnalyParaDto dto)
        {
            String sql = "SELECT * FROM T_AnalyPara Where AnalyParaID =" + dto.AnalyParaID;
            DataSet ds = _sqlHelper.GetDs(sql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return;
            }

            dto.AnalyName = ds.Tables[0].Rows[0]["AnalyName"].ToString();
            dto.ArithmaticID = (Arithmatic)Convert.ToInt32(ds.Tables[0].Rows[0]["ArithmaticID"].ToString());
            dto.ArithmaticPara = (ArithmaticParameter)Convert.ToInt32(ds.Tables[0].Rows[0]["ArithmaticPara"].ToString());
            dto.AimPara = (AimPara)Convert.ToInt32(ds.Tables[0].Rows[0]["AimPara"].ToString());
            dto.AimWay = (AimWay)Convert.ToInt32(ds.Tables[0].Rows[0]["AimWay"].ToString());
            dto.ColumuModel = ds.Tables[0].Rows[0]["ColumuModel"].ToString();
            dto.Description = ds.Tables[0].Rows[0]["Description"].ToString();
            dto.PeakWide = Convert.ToInt32(ds.Tables[0].Rows[0]["PeakWide"].ToString());
            dto.Slope = Convert.ToInt32(ds.Tables[0].Rows[0]["Slope"].ToString());
            dto.Drift = Convert.ToInt32(ds.Tables[0].Rows[0]["Drift"].ToString());
            dto.MinAreaSize = Convert.ToInt32(ds.Tables[0].Rows[0]["MinAreaSize"].ToString());
            dto.ParaChangeTime = Convert.ToInt32(ds.Tables[0].Rows[0]["ParaChangeTime"].ToString());
            dto.Ratio = Convert.ToSingle(ds.Tables[0].Rows[0]["Ratio"].ToString());
            dto.TimeWindow = Convert.ToInt32(ds.Tables[0].Rows[0]["TimeWindow"].ToString());
            dto.FixWay = (FixCurveWay)Convert.ToInt32(ds.Tables[0].Rows[0]["FixWay"].ToString());

        }

        /// <summary>
        /// 更新分析参数到对应的数据库
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateMethod(AnalyParaDto dto)
        {
            String sql = "UPDATE [T_AnalyPara] SET "
                + "AnalyName = '" + dto.AnalyName + "',"
                + "ArithmaticID = '" + (int)dto.ArithmaticID + "',"
                + "ArithmaticPara = '" + (int)dto.ArithmaticPara + "',"
                + "AimWay = '" + (int)dto.AimWay + "',"
                + "AimPara = '" + (int)dto.AimPara + "',"
                + "ColumuModel = '" + dto.ColumuModel + "',"
                + "Description = '" + dto.Description + "',"
                + "PeakWide = '" + dto.PeakWide + "',"
                + "Slope = '" + dto.Slope + "',"
                + "Drift = '" + dto.Drift + "',"
                + "Ratio = '" + dto.Ratio + "',"
                + "TimeWindow = '" + dto.TimeWindow + "',"
                + "MinAreaSize = '" + dto.MinAreaSize + "',"
                + "FixWay = '" + (int)dto.FixWay + "',"
                + "ParaChangeTime = '" + dto.ParaChangeTime + "' "
                + "Where AnalyParaID = " + dto.AnalyParaID;
            bool bRet = this._sqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 返回新的分析参数ID
        /// </summary>
        /// <returns></returns>
        internal int GetNewAnalyParaID()
        {
            String sql = "SELECT AnalyParaID,AnalyName,Description FROM T_AnalyPara ";
            this._ds = _sqlHelper.GetDs(sql);
            if (null == _ds || null == _ds.Tables[0] || 0 == _ds.Tables[0].Rows.Count)
            {
                //"no method find"
                return 1;
            }

            int nMax = 1;
            for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
            {
                int analyid = Convert.ToInt32(
                    _ds.Tables[0].Rows[i]["AnalyParaID"].ToString());
                if (nMax <= analyid)
                {
                    nMax = analyid;
                }
            }

            return (nMax + 1);
        }

        /// <summary>
        /// 插入分析参数信息
        /// </summary>
        /// <returns></returns>
        public bool InsertMethod(AnalyParaDto dto)
        {

            String sqlStr = "INSERT INTO T_AnalyPara(AnalyParaID,AnalyName,ArithmaticID,ArithmaticPara,"
            + "AimPara,AimWay,ColumuModel,PeakWide,Slope,Drift,MinAreaSize,ParaChangeTime,Ratio,"
            + "TimeWindow,FixWay,Description) VALUES ('"
                + dto.AnalyParaID + "','"
                + dto.AnalyName + "','"
                + (int)dto.ArithmaticID + "','"
                + (int)dto.ArithmaticPara + "','"
                + (int)dto.AimPara + "','"
                + (int)dto.AimWay + "','"
                + dto.ColumuModel + "','"
                + dto.PeakWide + "','"
                + dto.Slope + "','"
                + dto.Drift + "','"
                + dto.MinAreaSize + "','"
                + dto.ParaChangeTime + "','"
                + dto.Ratio + "','"
                + dto.TimeWindow + "','"
                + (int)dto.FixWay + "','"
                + dto.Description + "')";

            return _sqlHelper.ExecuteSql(sqlStr);
        }

        /// <summary>
        /// 插入或者更新分析参数信息
        /// </summary>
        /// <param name="dto"></param>
        public void InsertOrUpdateMethod(AnalyParaDto dto)
        {
            if (0 < this.LoadMethod(dto))
            {
                this.UpdateMethod(dto);
            }
            else
            {
                this.InsertMethod(dto);
            }
        }

        /// <summary>
        /// 删除分析参数
        /// </summary>
        /// <param name="analyParaID"></param>
        public void DeleteAnalyPara(int analyParaID)
        {
            String sql = "Delete FROM T_AnalyPara Where AnalyParaID =" + analyParaID;
            bool bRet = this._sqlHelper.ExecuteSql(sql);
        }

        #endregion



    }
}
