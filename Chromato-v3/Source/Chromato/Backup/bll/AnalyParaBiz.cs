/*-----------------------------------------------------------------------------
//  FILE NAME       : AnalyParaBiz.cs
//  FUNCTION        : 分析方法的逻辑
//  AUTHOR          : 李锋(2009/05/08)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Data;
using ChromatoBll.dao;
using ChromatoTool.dto;

namespace ChromatoBll.bll
{
    /// <summary>
    /// 分析方法的逻辑
    /// </summary>
    public class AnalyParaBiz
    {

        #region 变量

        /// <summary>
        /// 参数Dao
        /// </summary>
        private AnalyParaDao daoAnalyPara = null;

        #endregion


        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public AnalyParaBiz()
        {
            this.daoAnalyPara = new AnalyParaDao();
        }

        #endregion


        #region 访问DAO

        /// <summary>
        /// 选择全部方法
        /// </summary>
        /// <returns>分析方法集合</returns>
        public DataSet LoadMethod()
        {
            return this.daoAnalyPara.LoadMethod();
        }

        /// <summary>
        /// 选择全部方法
        /// </summary>
        /// <returns>分析方法集合</returns>
        public DataSet LoadMethodName()
        {
            return this.daoAnalyPara.LoadMethodName();
        }

        /// <summary>
        /// 取得新的分析参数ID
        /// </summary>
        /// <returns>分析参数ID</returns>
        public int GetNewAnalyParaID()
        {
            return this.daoAnalyPara.GetNewAnalyParaID();
        }

        /// <summary>
        /// 删除分析参数
        /// </summary>
        /// <param name="AnalyParaID">分析方法ID</param>
        public void DeleteAnalyParaID(int AnalyParaID)
        {
            this.daoAnalyPara.DeleteAnalyPara(AnalyParaID);
        }

        /// <summary>
        /// 通过分析方法ID确定分析方法
        /// </summary>
        /// <param name="dto">分析方法单元</param>
        public void GetMethodByID(AnalyParaDto dto)
        {
            this.daoAnalyPara.GetMethodByID(dto);
        }

        /// <summary>
        /// 更新分析方法信息
        /// </summary>
        /// <param name="dto">分析方法单元</param>
        public void UpdateMethod(AnalyParaDto dto)
        {
            this.daoAnalyPara.UpdateMethod(dto);
        }

        /// <summary>
        /// 插入新的分析方法
        /// </summary>
        /// <param name="dto">分析方法单元</param>
        public void InsertMethod(AnalyParaDto dto)
        {
            dto.AnalyParaID = this.daoAnalyPara.GetNewAnalyParaID();
            bool bRet = this.daoAnalyPara.InsertMethod(dto);
        }

        #endregion

    }
}
