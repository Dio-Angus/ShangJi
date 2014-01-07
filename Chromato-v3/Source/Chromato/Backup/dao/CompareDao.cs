/*-----------------------------------------------------------------------------
//  FILE NAME       : CompareDao.cs
//  FUNCTION        : 图比较的访问Dao
//  AUTHOR          : 李锋(2009/07/28)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.db;
using System.Data;
using ChromatoTool.ini;
using ChromatoTool.dto;

namespace ChromatoBll.dao
{
    /// <summary>
    /// 图比较的访问Dao
    /// </summary>
    class CompareDao
    {

        #region 变量

        /// <summary>
        /// 库操作类
        /// </summary>
        private SqliteHelper _sqlHelper = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public CompareDao()
        {
            this._sqlHelper = new SqliteHelper();
        }

        #endregion


        #region 访问数据库方法

        /// <summary>
        /// 查询比较集合
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCompare()
        {
            String sql = "SELECT a.IsShow, b.SampleName, b.PathData, b.SampleID, a.ForeColor, b.CollectTime FROM T_Compare as a, T_Para as b "
                + "Where a.SampleID = b.SampleID "
                + "And a.CollectTime = b.CollectTime " 
                + "And b.SampleStatus <> '" + StatusSample.Deleted + "'";

            return _sqlHelper.GetDs(sql);
        }

        /// <summary>
        /// 删除比较表中数据
        /// </summary>
        /// <param name="dto"></param>
        public void DeleteCompare(CompareDto dto)
        {
            String sql = "Delete FROM T_Compare Where SampleID ='" + dto.SampleID + "' And CollectTime = '" + dto.CollectTime + "'";
            bool bRet = this._sqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 插入比较表
        /// </summary>
        /// <returns></returns>
        public bool InsertCompare(CompareDto dto)
        {
            int isShow = (dto.IsShow) ? 1 : 0;
            String sqlStr = "INSERT INTO T_Compare(SampleID,CollectTime,IsShow,ForeColor) VALUES ('"
                    + dto.SampleID + "','"
                    + dto.CollectTime + "','" 
                    + isShow + "','"
                    + dto.ForeColor + "')";

            return _sqlHelper.ExecuteSql(sqlStr);
        }

        /// <summary>
        /// 更新比较表
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateCompare(CompareDto dto)
        {

            int isShow = (dto.IsShow) ? 1 : 0;

            String sql = "UPDATE [T_Compare] SET "
                + "IsShow = '" + isShow + "',"
                + "ForeColor = '" + dto.ForeColor + "' "
                + "Where SampleID = '" + dto.SampleID + "' "
                + "And CollectTime = '" + dto.CollectTime + "' "; 
            bool bRet = this._sqlHelper.ExecuteSql(sql);
        }

        #endregion

    }
}
