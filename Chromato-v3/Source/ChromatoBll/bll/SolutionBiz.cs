/*-----------------------------------------------------------------------------
//  FILE NAME       : SolutionBiz.cs
//  FUNCTION        : 方案逻辑
//  AUTHOR          : 李锋(2009/05/25)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Data;
using ChromatoBll.dao;
using ChromatoTool.dto;

namespace ChromatoBll.bll
{
    /// <summary>
    /// 方案逻辑
    /// </summary>
    public class SolutionBiz
    {

        #region 方法

        /// <summary>
        /// 查询方案
        /// </summary>
        /// <returns></returns>
        public DataSet LoadList()
        {
            SolutionDao dao = new SolutionDao();
            return dao.LoadSolutionList();
        }

        /// <summary>
        /// 查询方案
        /// </summary>
        /// <returns></returns>
        public DataSet LoadAllSolu()
        {
            SolutionDao dao = new SolutionDao();
            return dao.LoadAllSolu();
        }

        /// <summary>
        /// 查询方案
        /// </summary>
        /// <param name="startDay"></param>
        /// <returns></returns>
        public DataSet LoadSoluByTime(String startDay)
        {
            SolutionDao dao = new SolutionDao();
            return dao.LoadSoluByTime(startDay);
        }

        /// <summary>
        /// 查询某段时间范围的方案
        /// </summary>
        /// <param name="startDay"></param>
        /// <param name="endDay"></param>
        /// <returns></returns>
        public DataSet LoadSoluByTime(String startDay,String endDay)
        {
            SolutionDao dao = new SolutionDao();
            return dao.LoadSoluByTime(startDay, endDay);
        }

        /// <summary>
        /// 查询方案详细内容
        /// </summary>
        /// <param name="SolutionID"></param>
        /// <returns></returns>
        public DataSet GetSolutionInfoName(int SolutionID)
        {
            SolutionDao dao = new SolutionDao();
            return dao.GetSolutionInfoName(SolutionID);
        }

        /// <summary>
        /// 查询方案名
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public String GetSolutionNameBySampleID(RelationDto dto)
        {
            RelationDao dao = new RelationDao();
            int soluID = dao.GetSolutionID(dto);

            SolutionDao daoSolu = new SolutionDao();
            return daoSolu.GetSolutionNameByID(soluID);
        }

        /// <summary>
        /// 查询方案名
        /// </summary>
        /// <param name="soluID"></param>
        /// <returns></returns>
        public String GetSolutionNameByID(int soluID)
        {
            SolutionDao daoSolu = new SolutionDao();
            return daoSolu.GetSolutionNameByID(soluID);
        }

        /// <summary>
        /// 查询方案ID
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public String GetSolutionID(RelationDto dto)
        {
            RelationDao dao = new RelationDao();
            return dao.GetSolutionID(dto).ToString();
        }

        /// <summary>
        /// 插入新的方案
        /// </summary>
        /// <param name="dto"></param>
        public bool InsertSolu(SolutionDto dto)
        {
            SolutionDao dao = new SolutionDao();
            dto.SolutionID = dao.GetNewSolutionID();
            return dao.InsertSolution(dto);
        }

        /// <summary>
        /// 更新某方案
        /// </summary>
        /// <param name="dto"></param>
        public bool UpdateSolu(SolutionDto dto)
        {
            SolutionDao dao = new SolutionDao();
            return dao.UpdateSolution(dto);
        }

        /// <summary>
        /// 删除指定方案
        /// </summary>
        /// <param name="dto"></param>
        public void DeleteSolu(SolutionDto dto)
        {
            SolutionDao dao = new SolutionDao();
            bool bRet = dao.DeleteSolu(dto);
        }

        /// <summary>
        /// 根据SolutionID查询某方案信息
        /// </summary>
        /// <param name="dto"></param>
        public void QuerySolu(SolutionDto dto)
        {
            SolutionDao dao = new SolutionDao();
            dao.QuerySolu(dto);
        }

        /// <summary>
        /// 查询方案
        /// </summary>
        /// <param name="solutionName"></param>
        /// <returns></returns>
        public bool LoadSoluByName(String solutionName)
        {
            SolutionDao dao = new SolutionDao();
            DataSet ds = dao.LoadSoluByName(solutionName);
            if (null == ds || null == ds.Tables[0] || 0 < ds.Tables[0].Rows.Count)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 查询方案
        /// </summary>
        /// <param name="solutionName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool LoadSoluByName(String solutionName, String id)
        {
            SolutionDao dao = new SolutionDao();
            DataSet ds = dao.LoadSoluByName(solutionName, id);
            if (null == ds || null == ds.Tables[0] || 0 < ds.Tables[0].Rows.Count)
            {
                return false;
            }
            return true;
        }

        #endregion


    }
}
