/*-----------------------------------------------------------------------------
//  FILE NAME       : RequestDao.cs
//  FUNCTION        : 请求表Dao
//  AUTHOR          : 李锋(2010/11/29)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.dto;
using ChromatoTool.db;
using System.Data;
using ChromatoTool.ini;
using System.Collections;

namespace AutoChromatoBll.dao
{
    class RequestDao
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
        public RequestDao()
        {
            _sqlHelper = new SqliteHelper();

        }
        #endregion


        #region 访问数据库

        /// <summary>
        /// 查询申请
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public DataSet QueryRequest(RequestDto dto)
        {
            String strSql = "";
            DataSet ds = null;
            strSql = "SELECT * FROM T_Request Where "
                    + "And regSampleName = '" + dto.regSampleName + "' "
                    + "And realSamepleID = '" + dto.SampleID + "' ";

            ds = _sqlHelper.GetDs(strSql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return null;
            }

            return ds;
        }

        /// <summary>
        /// 插入新的申请
        /// </summary>
        /// <param name="dto"></param>
        public bool InsertRequest(RequestDto dto)
        {
            String sqlStr = "INSERT INTO T_Request(regSampleName,SampleID,RegisterTime,Status"
            + ") VALUES ('"
                + dto.regSampleName + "','"
                + dto.SampleID + "','"
                + dto.RegisterTime + "','" 
                + (int)dto.Status + "')";

            return _sqlHelper.ExecuteSql(sqlStr);
        }


        /// <summary>
        /// 查询当前的全部申请
        /// </summary>
        /// <returns></returns>
        public DataSet LoadAllRequest()
        {
            String strSql = "";
            DataSet ds = null;

            strSql = "SELECT * FROM T_Request";

            ds = _sqlHelper.GetDs(strSql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return null;
            }

            return ds;
        }

        /// <summary>
        /// 查询需要启动还没有启动的请求类型
        /// </summary>
        /// <returns></returns>
        public bool QueryStart(ArrayList arr)
        {
            String strSql = "";
            DataSet ds = null;

            strSql = "SELECT * FROM T_Request Where status = '" + (int)PutStatus.Start + "' ";

            ds = _sqlHelper.GetDs(strSql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return false;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                RequestDto dto = new RequestDto();
                dto.regSampleName = dr["regSampleName"].ToString();
                dto.SampleID = dr["SampleID"].ToString();
                dto.RegisterTime = dr["RegisterTime"].ToString();

                arr.Add(dto);
            }


            strSql = "Update T_Request set status = '" + (int)PutStatus.Finished + "' ";
            bool bRet = _sqlHelper.ExecuteSql(strSql);

            //strSql = "Delete FROM T_Request";
            //bool bRet = _sqlHelper.ExecuteSql(strSql);
            return true;
        }

        #endregion

    }
}
