/*-----------------------------------------------------------------------------
//  FILE NAME       : RequestBiz.cs
//  FUNCTION        : 请求表逻辑
//  AUTHOR          : 李锋(2010/11/29)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using ChromatoTool.dto;
using AutoChromatoBll.dao;
using System.Data;
using System;
using ChromatoTool.ini;

namespace AutoChromatoBll.bll
{
    /// <summary>
    /// 请求表逻辑
    /// </summary>
    class RequestBiz
    {


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public RequestBiz()
        {

        }

        #endregion


        #region 方法

        /// <summary>
        /// 插入新的申请
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>0 faied, 1 exist, 2 successed</returns>
        public int InsertRequest(RequestDto dto)
        {
            int nRet = 0;
            DataSet ds = null;
            RequestDao daoRequest = new RequestDao();
            nRet = (daoRequest.InsertRequest(dto)) ? 2 : 0;
            return nRet;
        }

        /// <summary>
        /// 查询当前的全部申请
        /// </summary>
        /// <returns></returns>
        public DataSet LoadAllRequest()
        {
            RequestDao daoRequest = new RequestDao();
            return daoRequest.LoadAllRequest();
        }


        #endregion

    }
}
