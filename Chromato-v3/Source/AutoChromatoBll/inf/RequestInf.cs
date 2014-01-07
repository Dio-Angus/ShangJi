/*-----------------------------------------------------------------------------
//  FILE NAME       : RequestInf.cs
//  FUNCTION        : 样品注册逻辑
//  AUTHOR          : 李锋(2010/11/28)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;
using ChromatoTool.dto;
using ChromatoTool.ini;
using AutoChromatoBll.bll;
using System.Data;
using AutoChromatoBll.dao;
using System.Collections;

namespace AutoChromatoBll.inf
{
    /// <summary>
    /// 样品注册逻辑
    /// </summary>
    public class RequestInf
    {

        #region 变量

        /// <summary>
        /// 方案逻辑
        /// </summary>
        private SolutionBiz _bizSolu = null;

        /// <summary>
        /// 样品逻辑
        /// </summary>
        private ParaBiz _bizPara = null;

        /// <summary>
        /// 关系表逻辑
        /// </summary>
        private RelationBiz _bizRelation = null;

        /// <summary>
        /// 申请表逻辑
        /// </summary>
        private RequestBiz _bizRequest = null;

        #endregion

        
        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public RequestInf()
        {
            this._bizPara = new ParaBiz();
            this._bizSolu = new SolutionBiz();
            this._bizRelation = new RelationBiz();
            this._bizRequest = new RequestBiz();
        }

        #endregion


        #region 方法

        /// <summary>
        /// 申请样品注册
        /// </summary>
        /// <param name="dtoPara"></param>
        /// <param name="dtoRelation"></param>
        /// <param name="checkA"></param>
        /// <param name="checkB"></param>
        /// <param name="checkC"></param>
        /// <param name="checkD"></param>
        /// <returns></returns>
        public int RegSampleInfo(ParaDto dtoPara, RelationDto dtoRelation,
            bool checkA, bool checkB, bool checkC, bool checkD)
        {
            int nRet = 0;
            if (!this.IsParaNameRepetited(dtoPara))
            {
                nRet = 1;
                //return 1;
            }

            //A通道样品
            if (checkA)
            {
                dtoPara.ChannelID = GasChannel.A;
                this.InsertParaAndRelation(dtoPara, dtoRelation);
            }

            //B通道样品
            if (checkB)
            {
                dtoPara.ChannelID = GasChannel.B;
                this.InsertParaAndRelation(dtoPara, dtoRelation);
            }

            //C通道样品
            if (checkC)
            {
                dtoPara.ChannelID = GasChannel.C;
                this.InsertParaAndRelation(dtoPara, dtoRelation);
            }

            //D通道样品
            if (checkD)
            {
                dtoPara.ChannelID = GasChannel.D;
                this.InsertParaAndRelation(dtoPara, dtoRelation);
            }

            return nRet;
        }

        /// <summary>
        /// 样品名是否重复
        /// </summary>
        /// <returns></returns>
        private bool IsParaNameRepetited(ParaDto dtoPara)
        {
            return this._bizPara.LoadParaByName(dtoPara.SampleName);
        }

        /// <summary>
        /// 插入样品和关系
        /// </summary>
        private void InsertParaAndRelation(ParaDto dtoPara, RelationDto dtoRelation)
        {
            bool bRet = false;

            dtoPara.PathData = "db\\" + DateTime.Now.ToString("yyyyMM") + "\\"
                + "通道" + dtoPara.ChannelID + "_" + dtoPara.RegisterTime + DefaultItem.Db_Extention;
            dtoPara.Remark = "";
            dtoPara.SampleID = "通道" + dtoPara.ChannelID + "_" + dtoPara.RegisterTime;
            bRet = this._bizPara.InsertPara(dtoPara);

            //插入关系
            dtoRelation.SampleID = dtoPara.SampleID;
            dtoRelation.RegisterTime = dtoPara.RegisterTime;
            bRet = this._bizRelation.InsertRelation(dtoRelation);
        }

        /// <summary>
        /// 取得方案信息
        /// </summary>
        /// <returns></returns>
        public DataSet LoadSoluList()
        {
            DataSet ds = this._bizSolu.LoadList();
            return ds;
        }

        /// <summary>
        /// 查询当前的全部申请
        /// </summary>
        /// <returns></returns>
        public DataSet LoadAllRequest()
        {
            RequestBiz bizRequest = new RequestBiz();
            return bizRequest.LoadAllRequest();
        }

        /// <summary>
        /// 取得分析结果
        /// </summary>
        /// <param name="dto"></param>
        public DataSet GetAnalyResult(ParaDto dto)
        {

            //取得结果
            String path = String.Empty;
            ParaBiz biz = new ParaBiz();
            bool bRet = biz.LoadParaByKey(dto);

            if (!bRet)
            {
                return null;
            }

            PeakDao daoPeak = new PeakDao();
            DataSet ds = daoPeak.LoadPeakResult(path);

            return ds;

        }

        /// <summary>
        /// 查询需要启动还没有启动的请求类型
        /// </summary>
        /// <returns></returns>
        public bool LoadStartRequest(ref ArrayList arr)
        {

            //取得结果
            String path = String.Empty;
            ArrayList arrRequest = new ArrayList();
            RequestDao daoRequest = new RequestDao();
            bool bRet = daoRequest.QueryStart(arrRequest);

            if (!bRet)
            {
                return false;
            }

            ParaDao dao = new ParaDao();
            ParaDto dto = null;

            if (0 == arrRequest.Count)
            {
                return false;
            }

            foreach (RequestDto dtoRequest in arrRequest)
            {
                dto = new ParaDto();
                dto.SampleID = dtoRequest.SampleID;
                dto.RegisterTime = dtoRequest.RegisterTime;
                bRet = dao.LoadParaByKey(dto);
                arr.Add(dto);

            }

            return true;
        }

        /// <summary>
        /// 查询需要分析的样品
        /// </summary>
        /// <returns></returns>
        public bool LoadCollectedSample(ParaDto dto)
        {
            ParaDao dao = new ParaDao();
            bool bRet = dao.LoadParaByStatus(dto);
            return bRet;
        }

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
        /// 查询当前样品文件
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCanStartPara()
        {
            ParaDao daoPara = new ParaDao();
            return daoPara.LoadCanStartPara();
        }

        /// <summary>
        /// 插入新的申请
        /// </summary>
        /// <param name="dto"></param>
        public void InsertRequest(RequestDto dto)
        {
            RequestDao daoRequest = new RequestDao();
            bool bRet = daoRequest.InsertRequest(dto);
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


        #endregion



    }
}
