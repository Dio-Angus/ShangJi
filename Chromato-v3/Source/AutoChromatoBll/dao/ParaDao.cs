/*-----------------------------------------------------------------------------
//  FILE NAME       : ParaDao.cs
//  FUNCTION        : 谱图参数访问Dao
//  AUTHOR          : 李锋(2009/04/16)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.db;
using ChromatoTool.dto;
using System.Data;
using ChromatoTool.ini;
using System.Collections;

namespace AutoChromatoBll.dao
{
    /// <summary>
    /// 谱图参数访问Dao
    /// </summary>
    class ParaDao
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
        public ParaDao()
        {
            _sqlHelper = new SqliteHelper();

        }
        #endregion


        #region 访问数据库

        /// <summary>
        /// 提取列表信息
        /// </summary>
        /// <returns></returns>
        public DataSet LoadPara(String ss)
        {
            String strSql = "";
            String channelID = this.GetAllowChannelID();

            switch (ss)
            {
                case StatusSample.All:
                case StatusSample.Registered:
                    strSql = "SELECT * FROM T_Para Where SampleStatus <> '" + StatusSample.Deleted + "' "
                            + channelID
                            + this.GetSortOrder();
                    break;
                case StatusSample.Collected:
                    strSql = "SELECT * FROM T_Para Where SampleStatus = '" + StatusSample.Collected + "' "
                            + channelID
                            + this.GetSortOrder();
                    break;
            }
            return _sqlHelper.GetDs(strSql);
        }

        /// <summary>
        /// 取得缺省的排序方式
        /// </summary>
        /// <returns></returns>
        private string GetSortOrder()
        {
            return " order by RegisterTime";
        }

        /// <summary>
        /// 获取允许的通道ID类型
        /// </summary>
        /// <returns></returns>
        private string GetAllowChannelID()
        {
            String channelID = "";


            channelID = " And ( ChannelID = '" + GasChannel.A + "' "
                       + "or ChannelID = '" + GasChannel.B + "' "
                       + "or ChannelID = '" + GasChannel.C + "' "
                       + "or ChannelID = '" + GasChannel.D + "') ";
 
            return channelID;
        }

        /// <summary>
        /// 查询从某天开始到今天的样品文件
        /// </summary>
        /// <param name="ss"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public DataSet LoadPara(String ss, String startTime)
        {
            String strSql = "";
            String channelID = this.GetAllowChannelID();
            switch (ss)
            {
                case StatusSample.All:
                case StatusSample.Registered:
                    strSql = "SELECT * FROM T_Para Where RegisterTime > '" + startTime + "' "
                            + "And SampleStatus <> '" + StatusSample.Deleted + "' "
                            + channelID
                            + this.GetSortOrder();
                    break;
                case StatusSample.Collected:
                    strSql = "SELECT * FROM T_Para Where RegisterTime > '" + startTime + "' "
                            + "And SampleStatus = '" + StatusSample.Collected + "' "
                            + channelID
                            + this.GetSortOrder();
                    break;
            }
            return _sqlHelper.GetDs(strSql);
        }

        /// <summary>
        /// 查询某段时间范围的样品文件
        /// </summary>
        /// <param name="ss"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataSet LoadPara(String ss, String startTime, String endTime)
        {
            String strSql = "";
            String channelID = this.GetAllowChannelID();
            switch (ss)
            {
                case StatusSample.All:
                case StatusSample.Registered:
                    strSql = "SELECT * FROM T_Para Where RegisterTime > '" + startTime + "' "
                            + "And RegisterTime < '" + endTime + "' "
                            + "And SampleStatus <> '" + StatusSample.Deleted + "' "
                            + channelID
                            + this.GetSortOrder();
                    break;
                case StatusSample.Collected:
                    strSql = "SELECT * FROM T_Para Where RegisterTime > '" + startTime + "' "
                            + "And RegisterTime < '" + endTime + "' "
                            + "And SampleStatus = '" + StatusSample.Collected + "' "
                            + channelID
                            + this.GetSortOrder();
                    break;
            }
            return _sqlHelper.GetDs(strSql);
        }


        /// <summary>
        /// 查询全部的样品文件,增加IsPickup字段
        /// </summary>
        /// <param name="ss"></param>
        /// <returns></returns>
        public DataSet LoadPickupPara(String ss)
        {
            String strSql = "";
            DataSet ds = null;
            String channelID = this.GetAllowChannelID();

            switch (ss)
            {
                case StatusSample.All:
                case StatusSample.Registered:
                    strSql = "SELECT * FROM T_Para Where SampleStatus <> '" + StatusSample.Deleted + "' "
                            + channelID
                            + this.GetSortOrder();
                    break;
                case StatusSample.Collected:
                    strSql = "SELECT * FROM T_Para Where SampleStatus = '" + StatusSample.Collected + "' "
                            + channelID
                            + this.GetSortOrder();
                    break;
            }
            ds = _sqlHelper.GetDs(strSql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return ds;
            }
            ds.Tables[0].Columns.Add("IsPickup");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["IsPickup"] = false;
            }
            return ds;
        }

        /// <summary>
        /// 查询从某天开始到今天的样品文件,增加IsPickup字段
        /// </summary>
        /// <param name="ss"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public DataSet LoadPickupPara(String ss, String startTime)
        {
            String strSql = "";
            DataSet ds = null;
            String channelID = this.GetAllowChannelID();

            switch (ss)
            {
                case StatusSample.All:
                case StatusSample.Registered:
                    strSql = "SELECT * FROM T_Para Where SampleStatus <> '" + StatusSample.Deleted + "' "
                            + "And RegisterTime > '" + startTime + "' "
                            + channelID
                            + this.GetSortOrder();
                    break;
                case StatusSample.Collected:
                    strSql = "SELECT * FROM T_Para Where SampleStatus = '" + StatusSample.Collected + "' "
                            + "And RegisterTime > '" + startTime + "' "
                            + channelID
                            + this.GetSortOrder();
                    break;
            }
            ds =  _sqlHelper.GetDs(strSql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return ds;
            }
            ds.Tables[0].Columns.Add("IsPickup");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["IsPickup"] = false;
            }
            return ds;
        }

        /// <summary>
        /// 查询某段时间范围的样品文件,增加IsPickup字段
        /// </summary>
        /// <param name="ss"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataSet LoadPickupPara(String ss, String startTime, String endTime)
        {
            String strSql = "";
            DataSet ds = null;
            String channelID = this.GetAllowChannelID();

            switch (ss)
            {
                case StatusSample.All:
                case StatusSample.Registered:
                    strSql = "SELECT * FROM T_Para Where SampleStatus <> '" + StatusSample.Deleted + "' "
                            + "And RegisterTime > '" + startTime + "' "
                            + "And RegisterTime < '" + endTime + "' "
                            + channelID
                            + this.GetSortOrder();
                    break;
                case StatusSample.Collected:
                    strSql = "SELECT * FROM T_Para Where SampleStatus = '" + StatusSample.Collected + "' "
                            + "And RegisterTime > '" + startTime + "' "
                            + "And RegisterTime < '" + endTime + "' "
                            + channelID
                            + this.GetSortOrder();
                    break;
            }
            ds = _sqlHelper.GetDs(strSql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return ds;
            }
            ds.Tables[0].Columns.Add("IsPickup");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["IsPickup"] = false;
            }
            return ds;
        }

        /// <summary>
        /// 查询当前样品文件
        /// </summary>
        /// <returns></returns>
        public int LoadPickupPara(ParaDto dto)
        {
            int count = 0;
            String strSql = "";
            String channelID = this.GetAllowChannelID();

            strSql = "SELECT * FROM T_Para Where SampleStatus <>  '" + StatusSample.Deleted
                    + "' And SampleID = '" + dto.SampleID.ToString() + "' "
                    + channelID;

            DataSet ds = _sqlHelper.GetDs(strSql);
            if (null != ds && null != ds.Tables[0])
            {
                count = ds.Tables[0].Rows.Count;
            }
            return count;
        }

        /// <summary>
        /// 保存谱图参数到对应的数据库
        /// </summary>
        /// <param name="dto"></param>
        public bool UpdateStatus(ParaDto dto)
        {
            String sql = "UPDATE [T_Para] SET "
                + "SampleStatus = '" + dto.SampleStatus.ToString() + "' "
                + "Where SampleID = '" + dto.SampleID.ToString() + "' "
                + "And RegisterTime = '" + dto.RegisterTime + "' ";
            return this._sqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 插入参数信息
        /// </summary>
        /// <returns></returns>
        public bool UpdatePara(ParaDto dto)
        {
            String sqlStr = "UPDATE [T_Para] SET "
                    + "SampleType = '" + (int)dto.SampleType + "',"
                    + "UserID = '" + dto.UserID + "',"
                    + "SampleName = '" + dto.SampleName + "',"
                    + "StopTime = '" + dto.StopTime + "',"
                    + "SampleWeight = '" + dto.SampleWeight + "',"
                    + "InnerWeight = '" + dto.InnerWeight + "',"
                    + "PathData = '" + dto.PathData + "',"
                    + "SampleStatus = '" + dto.SampleStatus.ToString() + "',"
                    + "ChannelID = '" + dto.ChannelID + "',"
                    + "Remark = '" + dto.Remark + "',"
                    + "CollectTime = '" + dto.CollectTime + "' "
                    + "Where SampleID = '" + dto.SampleID + "' "
                    + "And RegisterTime = " + dto.RegisterTime;

            return _sqlHelper.ExecuteSql(sqlStr);
        }

        /// <summary>
        /// 更新样品信息
        /// </summary>
        /// <returns></returns>
        public bool InsertPara(ParaDto dto)
        {
            String sqlStr = "INSERT INTO T_Para(SampleType,SampleID,UserID,SampleName,"
            + "StopTime,SampleWeight,InnerWeight,"
            + "RegisterTime,PathData,SampleStatus,ChannelID) VALUES ('"
                + (int)dto.SampleType + "','"
                + dto.SampleID + "','"
                + dto.UserID + "','"
                + dto.SampleName + "','"
                + dto.StopTime + "','"
                + dto.SampleWeight + "','"
                + dto.InnerWeight + "','"
                + dto.RegisterTime + "','"
                + dto.PathData + "','"
                + dto.SampleStatus + "','"
                + dto.ChannelID.ToString() + "')";

            return _sqlHelper.ExecuteSql(sqlStr);
        }

        /// <summary>
        /// 更新样品状态为已经采集
        /// </summary>
        /// <param name="sampleID"></param>
        /// <param name="regTime"></param>
        /// <returns></returns>
        public bool UpdateParaToCollected(String sampleID, String regTime)
        {
            String sql = "UPDATE [T_Para] SET "
                + "SampleStatus = '" + StatusSample.Collected + "' "
                + "Where SampleID = '" + sampleID + "' "
                + "And RegisterTime = '" + regTime + "' ";
            return this._sqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 检查样品状态
        /// </summary>
        /// <param name="dto"></param>
        public String CheckParaStatus(ParaDto dto)
        {
            String status = null;
            String sql = "SELECT * FROM T_Para "
                + "Where SampleID = '" + dto.SampleID + "' "
                + "And RegisterTime = '" + dto.RegisterTime + "' ";

            DataSet ds = _sqlHelper.GetDs(sql);
            if (null != ds && null != ds.Tables[0])
            {
                status = ds.Tables[0].Rows[0]["SampleStatus"].ToString();
            }
            return status;
        }

        /// <summary>
        /// 修改正在采集的样品为已采集
        /// </summary>
        /// <param name="status"></param>
        public void ClearPara(string status)
        {
            String sql = "UPDATE [T_Para] SET "
                + "SampleStatus = '" + StatusSample.Collected + "' "
                + "Where SampleStatus = '" + status + "' ";
            bool bRet = this._sqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 查询样品
        /// </summary>
        /// <param name="sampleName"></param>
        /// <returns></returns>
        public DataSet LoadParaByName(String sampleName)
        {
            String channelID = this.GetAllowChannelID();
            String sql = "SELECT * FROM T_Para Where SampleStatus <>  '" + StatusSample.Deleted
                    + "' And SampleName = '" + sampleName + "' "
                    + channelID;
            return _sqlHelper.GetDs(sql);
        }

        /// <summary>
        /// 查询样品
        /// </summary>
        /// <param name="sampleName"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public DataSet LoadParaByName(String sampleName, ParaDto dto)
        {
            String channelID = this.GetAllowChannelID();
            String sql = "SELECT * FROM T_Para Where SampleStatus <>  '" + StatusSample.Deleted
                    + "' And SampleName = '" + sampleName
                    + "' And ChannelID = '" + dto.ChannelID
                    + "' And RegisterTime <> '" + dto.RegisterTime + "' "
                    + channelID;

            
            return _sqlHelper.GetDs(sql);
        }

        /// <summary>
        /// 装载全部通道的样品
        /// </summary>
        /// <param name="dto"></param>
        public ArrayList LoadAllChannelPara(ParaDto dto)
        {
            ArrayList arr = new ArrayList();
            String channelID = this.GetAllowChannelID();
            String sql = "SELECT * FROM T_Para Where SampleStatus <>  '" + StatusSample.Deleted
                    + "' And SampleName = '" + dto.SampleName
                    + "' And RegisterTime = '" + dto.RegisterTime + "' "
                    + channelID;


            DataSet ds = _sqlHelper.GetDs(sql);
            ParaDto dtoPara = null;

            if (null != ds && null != ds.Tables[0] && 0 < ds.Tables[0].Rows.Count)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dtoPara = new ParaDto();
                    dtoPara.SampleID = dr["SampleID"].ToString();
                    dtoPara.SampleName = dr["SampleName"].ToString();
                    dtoPara.RegisterTime = dr["RegisterTime"].ToString();
                    dtoPara.ChannelID = dr["ChannelID"].ToString();
                    dtoPara.InnerWeight = Convert.ToInt32(dr["InnerWeight"].ToString());
                    dtoPara.SampleStatus = dr["SampleStatus"].ToString();
                    dtoPara.SampleWeight = Convert.ToInt32(dr["SampleWeight"].ToString());
                    dtoPara.PathData = dr["PathData"].ToString();
                    dtoPara.SampleType = (TypeSample)Convert.ToInt32(dr["SampleType"].ToString());
                    dtoPara.UserID = dr["UserID"].ToString();
                    dtoPara.StopTime = Convert.ToInt32(dr["StopTime"].ToString());
                    dtoPara.Remark = dr["Remark"].ToString();
                    dtoPara.CollectTime = dr["CollectTime"].ToString();

                    arr.Add(dtoPara);
                }
            }
            return arr;
        }

        /// <summary>
        /// 查询样品
        /// </summary>
        /// <param name="dto"></param>
        public bool LoadParaByKey(ParaDto dto)
        {

            String channelID = this.GetAllowChannelID();
            String sql = "SELECT * FROM T_Para Where SampleStatus <>  '" + StatusSample.Deleted
                    + "' And SampleID = '" + dto.SampleID
                    + "' And RegisterTime = '" + dto.RegisterTime + "' "
                    + channelID;


            DataSet ds = _sqlHelper.GetDs(sql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return false;
            }

            if (null != ds && null != ds.Tables[0] && 0 < ds.Tables[0].Rows.Count)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dto.SampleID = dr["SampleID"].ToString();
                    dto.SampleName = dr["SampleName"].ToString();
                    dto.RegisterTime = dr["RegisterTime"].ToString();
                    dto.ChannelID = dr["ChannelID"].ToString();
                    dto.InnerWeight = Convert.ToInt32(dr["InnerWeight"].ToString());
                    dto.SampleStatus = dr["SampleStatus"].ToString();
                    dto.SampleWeight = Convert.ToInt32(dr["SampleWeight"].ToString());
                    dto.PathData = dr["PathData"].ToString();
                    dto.SampleType = (TypeSample)Convert.ToInt32(dr["SampleType"].ToString());
                    dto.UserID = dr["UserID"].ToString();
                    dto.StopTime = Convert.ToInt32(dr["StopTime"].ToString());
                    dto.Remark = dr["Remark"].ToString();
                    dto.CollectTime = dr["CollectTime"].ToString();
                }
            }
            return true;
        }


        /// <summary>
        /// 根据样品ID，注册时间来查询已采集的样品
        /// </summary>
        /// <param name="dto"></param>
        public bool LoadParaByStatus(ParaDto dto)
        {

            String channelID = this.GetAllowChannelID();
            String sql = "SELECT * FROM T_Para Where SampleStatus ==  '" + StatusSample.Collected
                    + "' And SampleID = '" + dto.SampleID
                    + "' And RegisterTime = '" + dto.RegisterTime + "' "
                    + channelID;


            DataSet ds = _sqlHelper.GetDs(sql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return false;
            }

            if (null != ds && null != ds.Tables[0] && 0 < ds.Tables[0].Rows.Count)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dto.SampleID = dr["SampleID"].ToString();
                    dto.SampleName = dr["SampleName"].ToString();
                    dto.RegisterTime = dr["RegisterTime"].ToString();
                    dto.ChannelID = dr["ChannelID"].ToString();
                    dto.InnerWeight = Convert.ToInt32(dr["InnerWeight"].ToString());
                    dto.SampleStatus = dr["SampleStatus"].ToString();
                    dto.SampleWeight = Convert.ToInt32(dr["SampleWeight"].ToString());
                    dto.PathData = dr["PathData"].ToString();
                    dto.SampleType = (TypeSample)Convert.ToInt32(dr["SampleType"].ToString());
                    dto.UserID = dr["UserID"].ToString();
                    dto.StopTime = Convert.ToInt32(dr["StopTime"].ToString());
                    dto.Remark = dr["Remark"].ToString();
                    dto.CollectTime = dr["CollectTime"].ToString();
                }
            }
            return true;
        }

        /// <summary>
        /// 查询当前样品文件
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCanStartPara()
        {
            String strSql = "";
            String channelID = this.GetAllowChannelID();

            strSql = "SELECT * FROM T_Para Where SampleStatus = '" + StatusSample.Collected + "' "
                            + "or SampleStatus = '" + StatusSample.Registered + "' "
                            + "or SampleStatus = '" + StatusSample.Analyzed + "' "
                            + channelID
                            + this.GetSortOrder();

            return _sqlHelper.GetDs(strSql);
        }
        #endregion


    }
}
