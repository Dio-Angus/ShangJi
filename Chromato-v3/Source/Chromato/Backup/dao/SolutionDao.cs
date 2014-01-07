/*-----------------------------------------------------------------------------
//  FILE NAME       : SolutionDao.cs
//  FUNCTION        : 方案Dao
//  AUTHOR          : 李锋(2009/05/25)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.db;
using System.Data;
using ChromatoTool.dto;

namespace ChromatoBll.dao
{
    /// <summary>
    /// 方案Dao
    /// </summary>
    class SolutionDao
    {

        #region 变量

        /// <summary>
        /// 库操作类
        /// </summary>
        private SqliteHelper _sqlHelper = null;

        /// <summary>
        /// 方法数据集合
        /// </summary>
        private DataSet _ds = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SolutionDao()
        {
            _sqlHelper = new SqliteHelper();
        }

        #endregion


        #region 访问数据库方法

        /// <summary>
        /// 查询全部方案
        /// </summary>
        /// <returns></returns>
        public DataSet LoadSolutionList()
        {
            String sql = "SELECT SolutionID,SolutionName FROM T_Solution";
            return _sqlHelper.GetDs(sql);
        }

        /// <summary>
        /// 查询全部方案
        /// </summary>
        /// <returns></returns>
        public DataSet LoadAllSolu()
        {
            String sql = "SELECT * FROM T_Solution";
            return _sqlHelper.GetDs(sql);
        }

        /// <summary>
        /// 查询方案
        /// </summary>
        /// <param name="startDay"></param>
        /// <returns></returns>
        public DataSet LoadSoluByTime(String startDay)
        {
            String sql = "SELECT * FROM T_Solution Where RegisterTime > '" + startDay + "' ";
            return _sqlHelper.GetDs(sql);
        }

        /// <summary>
        /// 查询某段时间范围的方案
        /// </summary>
        /// <param name="startDay"></param>
        /// <param name="endDay"></param>
        /// <returns></returns>
        public DataSet LoadSoluByTime(String startDay, String endDay)
        {
            String sql = "SELECT * FROM T_Solution Where RegisterTime > '" + startDay 
                       + "' And RegisterTime < '" + endDay + "' ";
            return _sqlHelper.GetDs(sql);
        }

        /// <summary>
        /// 插入方案数据
        /// </summary>
        /// <param name="dto"></param>
        public bool InsertSolution(SolutionDto dto)
        {
            int isUseTimeProc = (dto.IsUseTimeProc) ? 1 : 0;
            dto.RegisterTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            String sqlStr = "INSERT INTO T_Solution(SolutionID,SolutionName,RegisterTime,CollectionID,AnalyParaID,AntiMethodID,IDTableID,"
                + "TimeProcID,IsUseTimeProc,Remark) VALUES ('"
                + dto.SolutionID + "','"
                + dto.SolutionName + "','"
                + dto.RegisterTime + "','"
                + dto.CollectionID + "','"
                + dto.AnalyParaID + "','"
                + dto.AntiMethodID + "','"
                + dto.IDTableID + "','"
                + dto.TimeProcID + "','"
                + isUseTimeProc + "','"
                + dto.Remark + "')";

            return _sqlHelper.ExecuteSql(sqlStr);
        }

        /// <summary>
        /// 查询方案详细内容
        /// </summary>
        /// <param name="SolutionID"></param>
        /// <returns></returns>
        public DataSet GetSolutionInfoName(int SolutionID)
        {
            String sql = "Select distinct tS.SolutionName,tS.IsUseTimeProc, tc.CollectionName, tA.AnalyName, tId.IDTableName, tTP.TPName, tAC.AntiControlName "
                    + "From T_Solution as tS, T_Collection as tC, T_AnalyPara as tA, T_Ingredient as tId, T_TimeProc as tTP, T_AntiControl as tAC "
                    + "Where tS.SolutionID = " + SolutionID + " "
                    + "and tS.CollectionID = tC.CollectionID "
                    + "and tS.AnalyParaID = tA.AnalyParaID "
                    + "and tS.AntiMethodID = tAC.AntiControlID "
                    + "and tS.IDTableID = tId.IDTableID "
                    + "and tS.TimeProcID = tTP.TPid";

            return _sqlHelper.GetDs(sql);
        }

        /// <summary>
        /// 根据方案ID查询方案名
        /// </summary>
        /// <param name="soluID"></param>
        /// <returns></returns>
        public String GetSolutionNameByID(int soluID)
        {

            String sql = "SELECT * FROM T_Solution Where SolutionID = '" + soluID + "'";
            DataSet ds = _sqlHelper.GetDs(sql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return "";
            }

            return ds.Tables[0].Rows[0]["SolutionName"].ToString();
        }

        /// <summary>
        /// 返回新的方案ID
        /// </summary>
        /// <returns></returns>
        public int GetNewSolutionID()
        {
            String sql = "SELECT SolutionID FROM T_Solution ";
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
                    _ds.Tables[0].Rows[i]["SolutionID"].ToString());
                if (nMax <= analyid)
                {
                    nMax = analyid;
                }
            }

            return (nMax + 1);
        }

        /// <summary>
        /// 更新方案到对应的数据库
        /// </summary>
        /// <param name="dto"></param>
        public bool UpdateSolution(SolutionDto dto)
        {
            int isUseTimeProc = (dto.IsUseTimeProc) ? 1 : 0;

            String sql = "UPDATE [T_Solution] SET "
                + "SolutionName = '" + dto.SolutionName + "',"
                + "CollectionID = '" + dto.CollectionID + "',"
                + "AnalyParaID = '" + dto.AnalyParaID + "',"
                + "AntiMethodID = '" + dto.AntiMethodID + "',"
                + "IDTableID = '" + dto.IDTableID + "',"
                + "TimeProcID = '" + dto.TimeProcID + "',"
                + "Remark = '" + dto.Remark + "',"
                + "IsUseTimeProc = '" + isUseTimeProc + "' "
                + "Where SolutionID = " + dto.SolutionID;
            return this._sqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除方案
        /// </summary>
        /// <param name="dto"></param>
        public bool DeleteSolu(SolutionDto dto)
        {
            String sql = "Delete FROM T_Solution Where SolutionID =" + dto.SolutionID;
            bool bRet = this._sqlHelper.ExecuteSql(sql);
            return bRet;
        }

        /// <summary>
        /// 根据SolutionID查询某方案信息
        /// </summary>
        /// <param name="dto"></param>
        public void QuerySolu(SolutionDto dto)
        {
            String sql = "SELECT * FROM T_Solution Where SolutionID = '" + dto.SolutionID + "'";
            DataSet ds = _sqlHelper.GetDs(sql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return;
            }

            dto.AnalyParaID = Convert.ToInt32(ds.Tables[0].Rows[0]["AnalyParaID"].ToString());
            dto.AntiMethodID = Convert.ToInt32(ds.Tables[0].Rows[0]["AntiMethodID"].ToString());
            dto.CollectionID = Convert.ToInt32(ds.Tables[0].Rows[0]["CollectionID"].ToString());
            dto.IDTableID = Convert.ToInt32(ds.Tables[0].Rows[0]["IDTableID"].ToString());
            dto.IsUseTimeProc = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsUseTimeProc"].ToString());
            dto.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
            dto.SolutionName = ds.Tables[0].Rows[0]["SolutionName"].ToString();
            dto.TimeProcID = Convert.ToInt32(ds.Tables[0].Rows[0]["TimeProcID"].ToString());
            dto.RegisterTime = ds.Tables[0].Rows[0]["RegisterTime"].ToString();
        }

        /// <summary>
        /// 查询方案
        /// </summary>
        /// <param name="solutionName"></param>
        /// <returns></returns>
        public DataSet LoadSoluByName(String solutionName)
        {
            String sql = "SELECT * FROM T_Solution Where SolutionName = '" + solutionName + "' ";
            return _sqlHelper.GetDs(sql);
        }

        /// <summary>
        /// 查询方案
        /// </summary>
        /// <param name="solutionName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet LoadSoluByName(String solutionName, String id)
        {
            String sql = "SELECT * FROM T_Solution Where SolutionName = '" + solutionName 
                        + "' And SolutionID <> '" + id + "' ";
            return _sqlHelper.GetDs(sql);
        }

        #endregion



    }
}
