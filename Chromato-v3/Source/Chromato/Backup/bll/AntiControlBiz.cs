/*-----------------------------------------------------------------------------
//  FILE NAME       : AntiControlBiz.cs
//  FUNCTION        : 反控方法的逻辑
//  AUTHOR          : 李锋(2009/07/02)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using ChromatoBll.dao;
using System.Data;
using ChromatoTool.dto;

namespace ChromatoBll.bll
{
    /// <summary>
    /// 反控方法的逻辑
    /// </summary>
    public class AntiControlBiz
    {

        #region 变量

        /// <summary>
        /// 参数Dao
        /// </summary>
        private AntiControlDao daoAntiControl = null;

        #endregion


        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public AntiControlBiz()
        {
            this.daoAntiControl = new AntiControlDao();
        }

        #endregion


        #region 访问DAO

        /// <summary>
        /// 选择全部反控方法
        /// </summary>
        /// <returns>反控方法集合</returns>
        public DataSet LoadMethod()
        {
            return this.daoAntiControl.LoadMethod();
        }

        /// <summary>
        /// 选择方法
        /// </summary>
        /// <returns>反控方法单元</returns>
        public int LoadMethod(AntiControlDto dto)
        {
            return this.daoAntiControl.LoadMethod(dto);
        }


        /// <summary>
        /// 取得新的反控方法ID
        /// </summary>
        /// <returns>反控方法ID</returns>
        public int GetNewAntiControlID()
        {
            return this.daoAntiControl.GetNewAntiControlID();
        }

        /// <summary>
        /// 删除反控方法
        /// </summary>
        /// <param name="AntiControlID">反控方法ID</param>
        public void DeleteAnalyParaID(int AntiControlID)
        {
            this.daoAntiControl.DeleteAntiControl(AntiControlID);
        }

        /// <summary>
        /// 通过反控方法ID确定反控方法
        /// </summary>
        /// <returns>反控方法单元</returns>
        public void GetMethodByID(AntiControlDto dto)
        {
            this.daoAntiControl.GetMethodByID(dto);
        }

        /// <summary>
        /// 更新反控方法信息
        /// </summary>
        /// <param name="dto">反控方法单元</param>
        public void UpdateMethod(AntiControlDto dto)
        {
            this.daoAntiControl.UpdateMethod(dto);
        }

        /// <summary>
        /// 插入新的反控方法
        /// </summary>
        /// <param name="dto">反控方法单元</param>
        public void InsertMethod(AntiControlDto dto)
        {
            dto.AntiControlID = this.daoAntiControl.GetNewAntiControlID();
            bool bRet = this.daoAntiControl.InsertMethod(dto);
        }

        #endregion

    }
}
