/*-----------------------------------------------------------------------------
//  FILE NAME       : TimeProcDao.cs
//  FUNCTION        : 时间程序Dao
//  AUTHOR          : 李锋(2009/05/20)
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
    /// 时间程序访问Dao
    /// </summary>
    class TimeProcDao
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
        public TimeProcDao()
        {
            _sqlHelper = new SqliteHelper();
        }

        #endregion


        #region 访问数据库方法

        /// <summary>
        /// 查询时间程序
        /// </summary>
        /// <returns></returns>
        public DataSet LoadTimeProc()
        {
            String sql = "SELECT distinct TPid,TPName FROM T_TimeProc ";
            this._ds = _sqlHelper.GetDs(sql);
            return this._ds;
        }

        /// <summary>
        /// 查询时间程序
        /// </summary>
        /// <returns></returns>
        public DataSet LoadTimeProcByID(TimeProcDto dto)
        {
            String sql = "SELECT * FROM T_TimeProc Where TPid =" + dto.TPid;
            this._ds = _sqlHelper.GetDs(sql);
            return this._ds;
        }

        /// <summary>
        /// 查询是否存在该时间程序
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private int LoadTimeProc(TimeProcDto dto)
        {
            String sql = "SELECT * FROM T_TimeProc Where TPid =" + dto.TPid + "and SerialID =" + dto.SerialID;
            DataSet ds = _sqlHelper.GetDs(sql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return 0;
            }
            return ds.Tables[0].Rows.Count;
        }

        /// <summary>
        /// 通过时间程序ID确定时间程序
        /// </summary>
        /// <param name="dto"></param>
        internal void GetTimeProcByID(TimeProcDto dto)
        {
            String sql = "SELECT * FROM T_TimeProc Where TPid =" + dto.TPid + "and SerialID =" + dto.SerialID;
            DataSet ds = _sqlHelper.GetDs(sql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return;
            }

            dto.TPName = ds.Tables[0].Rows[0]["TPName"].ToString();
            dto.ActionName = ds.Tables[0].Rows[0]["ActionName"].ToString();
            dto.StartTime = Convert.ToSingle(ds.Tables[0].Rows[0]["StartTime"].ToString());
            dto.StopTime = Convert.ToSingle(ds.Tables[0].Rows[0]["StopTime"].ToString());
            dto.TpValue = Convert.ToInt32(ds.Tables[0].Rows[0]["TpValue"].ToString());
            dto.IsCmd = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsCmd"].ToString());
        }

        /// <summary>
        /// 更新时间程序到对应的数据库
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateTimeProc(TimeProcDto dto)
        {
            int isCmd = (dto.IsCmd) ? 1 : 0;

            String sql = "UPDATE [T_TimeProc] SET "
                + "TPName = '" + dto.TPName + "',"
                + "ActionName = '" + dto.ActionName + "',"
                + "StartTime = '" + dto.StartTime + "',"
                + "StopTime = '" + dto.StopTime + "',"
                + "IsCmd = '" + isCmd + ",'"
                + "TpValue = '" + dto.TpValue + "' "
                + "Where TPid = " + dto.TPid + " "
                + "And SerialID = " + dto.SerialID;

            bool bRet = this._sqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 更新时间程序名到对应的数据库
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateTPName(TimeProcDto dto)
        {
            String sql = "UPDATE [T_TimeProc] SET "
                + "TPName = '" + dto.TPName + "' "
                + "Where TPid = " + dto.TPid;
            bool bRet = this._sqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 返回新的时间程序ID
        /// </summary>
        /// <returns></returns>
        internal int GetNewTimeProcID()
        {
            String sql = "SELECT distinct TPid FROM T_TimeProc ";
            this._ds = _sqlHelper.GetDs(sql);
            if (null == _ds || null == _ds.Tables[0] || 0 == _ds.Tables[0].Rows.Count)
            {
                //"no method find"
                return 1;
            }

            int nMax = 1;
            for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
            {
                int timeProcID = Convert.ToInt32(
                    _ds.Tables[0].Rows[i]["TPid"].ToString());
                if (nMax <= timeProcID)
                {
                    nMax = timeProcID;
                }
            }

            return (nMax + 1);
        }

        /// <summary>
        /// 返回新的序列ID
        /// </summary>
        /// <returns></returns>
        internal int GetNewSerialID(TimeProcDto dto)
        {
            String sql = "SELECT SerialID FROM T_TimeProc Where TPid =" + dto.TPid;
            this._ds = _sqlHelper.GetDs(sql);
            if (null == _ds || null == _ds.Tables[0] || 0 == _ds.Tables[0].Rows.Count)
            {
                //"no method find"
                return 1;
            }

            int nMax = 1;
            for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
            {
                int serialID = Convert.ToInt32(
                    _ds.Tables[0].Rows[i]["SerialID"].ToString());
                if (nMax <= serialID)
                {
                    nMax = serialID;
                }
            }

            return (nMax + 1);
        }

        /// <summary>
        /// 插入时间程序信息
        /// </summary>
        /// <returns></returns>
        public bool InsertTimeProc(TimeProcDto dto)
        {
            int isCmd = (dto.IsCmd) ? 1 : 0;

            String sqlStr = "INSERT INTO T_TimeProc(TPid,TPName,SerialID,ActionName,StartTime,StopTime,"
                    + "IsCmd,TpValue) VALUES ('"
                    + dto.TPid + "','"
                    + dto.TPName + "','"
                    + dto.SerialID + "','"
                    + dto.ActionName + "','"
                    + dto.StartTime + "','"
                    + dto.StopTime + "',"
                    + isCmd + ",'"
                    + dto.TpValue + "')";

            return _sqlHelper.ExecuteSql(sqlStr);
        }

        /// <summary>
        /// 插入或者更新时间程序信息
        /// </summary>
        /// <param name="dto"></param>
        internal void InsertOrUpdateMethod(TimeProcDto dto)
        {
            if (0 < this.LoadTimeProc(dto))
            {
                this.UpdateTimeProc(dto);
            }
            else
            {
                this.InsertTimeProc(dto);
            }
        }

        /// <summary>
        /// 删除时间程序
        /// </summary>
        /// <param name="dto"></param>
        public void DeleteSerial(TimeProcDto dto)
        {
            String sql = "Delete FROM T_TimeProc Where TPid =" + dto.TPid + " and SerialID =" + dto.SerialID;
            bool bRet = this._sqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除时间程序
        /// </summary>
        /// <param name="dto"></param>
        public void DeleteTimeProc(TimeProcDto dto)
        {
            String sql = "Delete FROM T_TimeProc Where TPid =" + dto.TPid;
            bool bRet = this._sqlHelper.ExecuteSql(sql);
        }

        #endregion


    }
}
