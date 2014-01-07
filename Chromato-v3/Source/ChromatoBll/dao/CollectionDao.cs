/*-----------------------------------------------------------------------------
//  FILE NAME       : CollectionDao.cs
//  FUNCTION        : 采集方法Dao
//  AUTHOR          : 李锋(2009/06/11)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Data;
using ChromatoTool.db;
using ChromatoTool.dto;

namespace ChromatoBll.dao
{
    /// <summary>
    /// 采集方法Dao
    /// </summary>
    class CollectionDao
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
        public CollectionDao()
        {
            _sqlHelper = new SqliteHelper();
        }

        #endregion


        #region 访问数据库方法

        /// <summary>
        /// 查询采集方法
        /// </summary>
        /// <returns></returns>
        public DataSet LoadMethod()
        {
            String sql = "SELECT * FROM T_Collection ";
            this._ds = _sqlHelper.GetDs(sql);
            return this._ds;
        }

        /// <summary>
        /// 查询采集方法
        /// </summary>
        /// <returns></returns>
        public DataSet LoadMethodName()
        {
            String sql = "SELECT CollectionID, CollectionName FROM T_Collection ";
            this._ds = _sqlHelper.GetDs(sql);
            return this._ds;
        }

        /// <summary>
        /// 查询是否存在该采集方法
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int LoadMethod(CollectionDto dto)
        {
            String sql = "SELECT * FROM T_Collection Where CollectionID =" + dto.CollectionID;
            DataSet ds = _sqlHelper.GetDs(sql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return 0;
            }
            return ds.Tables[0].Rows.Count;
        }


        /// <summary>
        /// 通过采集方法ID确定采集方法
        /// </summary>
        /// <param name="dto"></param>
        public void GetMethodByID(CollectionDto dto)
        {
            String sql = "SELECT * FROM T_Collection Where CollectionID =" + dto.CollectionID;
            DataSet ds = _sqlHelper.GetDs(sql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return;
            }

            dto.CollectionName = ds.Tables[0].Rows[0]["CollectionName"].ToString();
            dto.FullScreenTime = Convert.ToInt32(ds.Tables[0].Rows[0]["FullScreenTime"].ToString());
            dto.PeakWide = Convert.ToInt32(ds.Tables[0].Rows[0]["PeakWide"].ToString());
            dto.ShowMaxY = Convert.ToSingle(ds.Tables[0].Rows[0]["ShowMaxY"].ToString());
            dto.ShowMinY = Convert.ToSingle(ds.Tables[0].Rows[0]["ShowMinY"].ToString());
            dto.Slope = Convert.ToInt32(ds.Tables[0].Rows[0]["Slope"].ToString());
            dto.StopTime = Convert.ToInt32(ds.Tables[0].Rows[0]["StopTime"].ToString());
            dto.AutoSlope = Convert.ToBoolean(ds.Tables[0].Rows[0]["AutoSlope"].ToString());
            dto.ForeColor = Convert.ToInt32(ds.Tables[0].Rows[0]["ForeColor"].ToString());
            dto.BackColor = Convert.ToInt32(ds.Tables[0].Rows[0]["BackColor"].ToString());

        }

        /// <summary>
        /// 更新采集方法到对应的数据库
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateMethod(CollectionDto dto)
        {
            int isAutoSlope = (dto.AutoSlope) ? 1 : 0;

            String sql = "UPDATE [T_Collection] SET "
                + "CollectionName = '" + dto.CollectionName + "',"
                + "FullScreenTime = '" + dto.FullScreenTime + "',"
                + "ForeColor = '" + dto.ForeColor + "',"
                + "BackColor = '" + dto.BackColor + "',"
                + "PeakWide = '" + dto.PeakWide + "',"
                + "ShowMaxY = '" + dto.ShowMaxY + "',"
                + "ShowMinY = '" + dto.ShowMinY + "',"
                + "Slope = '" + dto.Slope + "',"
                + "StopTime = '" + dto.StopTime + "',"
                + "AutoSlope = '" + isAutoSlope + "' "
                + "Where CollectionID = " + dto.CollectionID;
            bool bRet = this._sqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 返回新的采集方法ID
        /// </summary>
        /// <returns></returns>
        public int GetNewCollectionID()
        {
            String sql = "SELECT CollectionID FROM T_Collection ";
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
                    _ds.Tables[0].Rows[i]["CollectionID"].ToString());
                if (nMax <= analyid)
                {
                    nMax = analyid;
                }
            }

            return (nMax + 1);
        }

        /// <summary>
        /// 插入方法
        /// </summary>
        /// <returns></returns>
        public bool InsertMethod(CollectionDto dto)
        {
            int isAutoSlope = (dto.AutoSlope) ? 1 : 0;

            String sqlStr = "INSERT INTO T_Collection(CollectionID,CollectionName,FullScreenTime,"
                    + "ForeColor,BackColor,PeakWide,"
                    + "ShowMaxY,ShowMinY,Slope,StopTime,AutoSlope) VALUES ('"
                    + dto.CollectionID + "','"
                    + dto.CollectionName + "','"
                    + dto.FullScreenTime + "','"
                    + dto.ForeColor + "','"
                    + dto.BackColor + "','"
                    + dto.PeakWide + "','"
                    + dto.ShowMaxY + "','"
                    + dto.ShowMinY + "','"
                    + dto.Slope + "','"
                    + dto.StopTime + "','"
                    + isAutoSlope + "')";

            return _sqlHelper.ExecuteSql(sqlStr);
        }

        #endregion


    }
}
