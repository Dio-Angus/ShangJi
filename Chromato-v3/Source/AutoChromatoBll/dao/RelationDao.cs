/*-----------------------------------------------------------------------------
//  FILE NAME       : RelationDao.cs
//  FUNCTION        : 索引关系Dao
//  AUTHOR          : 李锋(2009/04/30)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.db;
using System.Data;
using ChromatoTool.dto;

namespace AutoChromatoBll.dao
{
    /// <summary>
    /// 索引关系Dao
    /// </summary>
    class RelationDao
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
        public RelationDao()
        {
            _sqlHelper = new SqliteHelper();
        }

        #endregion


        #region 访问数据库方法

        /// <summary>
        /// 查询全部关系
        /// </summary>
        /// <returns></returns>
        public DataSet LoadRelationList()
        {
            String sql = "SELECT * FROM T_Relation";
            return _sqlHelper.GetDs(sql);
        }

        /// <summary>
        /// 根据样品ID查找方案ID
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int GetSolutionID(RelationDto dto)
        {

            String sql = "SELECT * FROM T_Relation "
                + "Where SampleID = '" + dto.SampleID + "' "
                + "And RegisterTime = '" + dto.RegisterTime + "' ";

           DataSet ds = _sqlHelper.GetDs(sql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return 0;
            }

            return Convert.ToInt32(ds.Tables[0].Rows[0]["SolutionID"].ToString());
        }

        /// <summary>
        /// 插入索引关系数据
        /// </summary>
        /// <param name="dto"></param>
        public bool InsertRelation(RelationDto dto)
        {
            String sqlStr = "INSERT INTO T_Relation( SolutionID,SampleID,RegisterTime"
                + ") VALUES ('"
                + dto.SolutionID + "','"
                + dto.SampleID + "','"
                + dto.RegisterTime + "')";

            return _sqlHelper.ExecuteSql(sqlStr);
        }

        /// <summary>
        /// 更新关系
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdateRelation(RelationDto dto)
        {
            String sql = "UPDATE [T_Relation] SET "
                + "SolutionID = '" + dto.SolutionID + "' "
                + "Where SampleID = '" + dto.SampleID + "' "
                + "And RegisterTime = '" + dto.RegisterTime + "' ";

            bool bRet = this._sqlHelper.ExecuteSql(sql);
            if (!bRet)
            {
                bRet = this.InsertRelation(dto);
            }
            return bRet;
        }

        #endregion
    

    }
}
