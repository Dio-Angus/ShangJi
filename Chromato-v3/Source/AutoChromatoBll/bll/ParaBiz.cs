/*-----------------------------------------------------------------------------
//  FILE NAME       : ParaBiz.cs
//  FUNCTION        : 样品信息查询
//  AUTHOR          : 李锋(2009/03/19)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using AutoChromatoBll.dao;
using System.IO;
using System.Collections;
using System.Data;
using ChromatoTool.dto;

namespace AutoChromatoBll.bll
{
    /// <summary>
    /// 样品信息查询,从数据库读取
    /// </summary>
    class ParaBiz
    {


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public ParaBiz()
        {

        }

        #endregion


        #region 访问数据库

        /// <summary>
        /// 查询当前样品文件
        /// </summary>
        /// <returns></returns>
        public DataSet LoadPara(String ss)
        {
            ParaDao daoPara = new ParaDao();
            return daoPara.LoadPara(ss);
        }

        /// <summary>
        /// 查询全部的样品文件,增加IsPickup字段
        /// </summary>
        /// <param name="ss"></param>
        /// <returns></returns>
        public DataSet LoadPickupPara(String ss)
        {
            ParaDao daoPara = new ParaDao();
            return daoPara.LoadPickupPara(ss);
        }

        /// <summary>
        /// 查询从某天开始到今天的样品文件,增加IsPickup字段
        /// </summary>
        /// <param name="ss"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public DataSet LoadPickupPara(String ss, String startTime)
        {
            ParaDao daoPara = new ParaDao();
            return daoPara.LoadPickupPara(ss, startTime);
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
            ParaDao daoPara = new ParaDao();
            return daoPara.LoadPickupPara(ss, startTime, endTime);
        }

        /// <summary>
        /// 查询当前样品文件
        /// </summary>
        /// <returns></returns>
        public int LoadPickupPara(ParaDto dto)
        {
            ParaDao daoPara = new ParaDao();
            return daoPara.LoadPickupPara(dto);
        }

        /// <summary>
        /// 查询从某天开始到今天的样品文件
        /// </summary>
        /// <param name="ss"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public DataSet LoadPara(String ss, String startTime)
        {
            ParaDao daoPara = new ParaDao();
            return daoPara.LoadPara(ss, startTime);
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
            ParaDao daoPara = new ParaDao();
            return daoPara.LoadPara(ss, startTime,endTime);
        }

        /// <summary>
        /// 删除样品
        /// </summary>
        /// <param name="dto"></param>
        public bool UpdateStatus(ParaDto dto)
        {
            ParaDao daoPara = new ParaDao();
            return daoPara.UpdateStatus(dto);
        }

        /// <summary>
        /// 更新样品
        /// </summary>
        /// <param name="dto"></param>
        public bool UpdatePara(ParaDto dto)
        {
            ParaDao daoPara = new ParaDao();
            return daoPara.UpdatePara(dto);
        }

        /// <summary>
        /// 建立新样品信息
        /// </summary>
        /// <returns></returns>
        public bool InsertPara(ParaDto dto)
        {
            ParaDao daoPara = new ParaDao();
            return daoPara.InsertPara(dto);
        }

        /// <summary>
        /// 更新样品状态为已经采集
        /// </summary>
        /// <param name="sampleID"></param>
        /// <param name="regTime"></param>
        /// <returns></returns>
        public bool UpdateParaToCollected(string sampleID, String regTime)
        {
            ParaDao daoPara = new ParaDao();
            return daoPara.UpdateParaToCollected(sampleID,regTime);
        }

        /// <summary>
        /// 检查样品状态
        /// </summary>
        /// <param name="dto"></param>
        public String CheckParaStatus(ParaDto dto)
        {
            ParaDao daoPara = new ParaDao();
            return daoPara.CheckParaStatus(dto);
        }

        /// <summary>
        /// 修改正在采集的样品为已采集
        /// </summary>
        /// <param name="status"></param>
        public void ClearPara(string status)
        {
            ParaDao daoPara = new ParaDao();
            daoPara.ClearPara(status);
        }

        /// <summary>
        /// 查询样品
        /// </summary>
        /// <param name="sampleName"></param>
        /// <returns></returns>
        public bool LoadParaByName(String sampleName)
        {
            ParaDao dao = new ParaDao();
            DataSet ds = dao.LoadParaByName(sampleName);
            if (null == ds || null == ds.Tables[0] || 0 < ds.Tables[0].Rows.Count)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 查询样品
        /// </summary>
        /// <param name="sampleName"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool LoadParaByName(String sampleName, ParaDto dto)
        {
            ParaDao dao = new ParaDao();
            DataSet ds = dao.LoadParaByName(sampleName,dto);
            if (null == ds || null == ds.Tables[0] || 0 < ds.Tables[0].Rows.Count)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 装载全部通道的样品
        /// </summary>
        /// <param name="dto"></param>
        public ArrayList LoadAllChannelPara(ParaDto dto)
        {
            ParaDao daoPara = new ParaDao();
            return daoPara.LoadAllChannelPara(dto);
        }

        /// <summary>
        /// 查询样品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool LoadParaByKey(ParaDto dto)
        {
            ParaDao dao = new ParaDao();
            return dao.LoadParaByKey(dto);
        }

        #endregion

    }
}
