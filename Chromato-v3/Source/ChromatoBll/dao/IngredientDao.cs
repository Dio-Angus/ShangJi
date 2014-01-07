/*-----------------------------------------------------------------------------
//  FILE NAME       : IngredientDao.cs
//  FUNCTION        : ID表访问Dao
//  AUTHOR          : 李锋(2009/05/15)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.db;
using System.Data;
using ChromatoTool.dto;

namespace ChromatoBll.dao
{
    class IngredientDao
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
        public IngredientDao()
        {
            _sqlHelper = new SqliteHelper();
        }

        #endregion


        #region 访问数据库方法

        /// <summary>
        /// 查询ID表
        /// </summary>
        /// <returns></returns>
        public DataSet LoadIdentity()
        {
            String sql = "SELECT distinct IDTableID, IDTableName FROM T_Ingredient ";
            DataSet ds = _sqlHelper.GetDs(sql);
            return ds;
        }

        /// <summary>
        /// 通过idTableID查询该ID表的详细
        /// </summary>
        /// <param name="idTableID"></param>
        /// <returns></returns>
        public DataSet LoadIngredientByIdTableID(int idTableID)
        {
            String sql = "SELECT * FROM T_Ingredient Where IDTableID = " + idTableID;
            return _sqlHelper.GetDs(sql);
        }

        /// <summary>
        /// 取得新的ID表ID
        /// </summary>
        /// <returns></returns>
        public int GetNewIdentityID()
        {
            String sql = "SELECT distinct IDTableID,IDTableName FROM T_Ingredient ";
            DataSet ds = _sqlHelper.GetDs(sql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                //"no IdTable find"
                return 1;
            }

            int nMax = 1;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int analyid = Convert.ToInt32(
                    ds.Tables[0].Rows[i]["IDTableID"].ToString());
                if (nMax <= analyid)
                {
                    nMax = analyid;
                }
            }

            return (nMax + 1);
        }

        /// <summary>
        /// 删除ID表
        /// </summary>
        /// <param name="dto"></param>
        public void DeleteIdentity(IngredientDto dto)
        {
            String sql = "Delete FROM T_Ingredient Where IDTableID =" + dto.IDTableID;
            bool bRet = this._sqlHelper.ExecuteSql(sql);
        }


        /// <summary>
        /// 插入成分表
        /// </summary>
        /// <returns></returns>
        public bool InsertIngredient(IngredientDto dto)
        {
            int isInnerPeak = (dto.IsInnerPeak) ? 1 : 0;

            String sqlStr = "INSERT INTO T_Ingredient(IDTableID,IDTableName,IngredientID,ReserveTime,"
                    + " IngredientName,TimeBand,IsInnerPeak) VALUES ('"
                    + dto.IDTableID + "','"
                    + dto.IDTableName + "','"
                    + dto.IngredientID + "','"
                    + dto.ReserveTime + "','"
                    + dto.IngredientName + "','"
                    + dto.TimeBand + "','"
                    + isInnerPeak + "')";

            return _sqlHelper.ExecuteSql(sqlStr);
        }

        #endregion




    }
}
