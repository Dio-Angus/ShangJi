/*-----------------------------------------------------------------------------
//  FILE NAME       : CollectionBiz.cs
//  FUNCTION        : 采集方法的逻辑
//  AUTHOR          : 李锋(2009/06/11)
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
    /// 采集方法的逻辑
    /// </summary>
    public class CollectionBiz
    {


        #region 变量

        /// <summary>
        /// 参数Dao
        /// </summary>
        private CollectionDao _daoCollection = null;

        #endregion

        
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public CollectionBiz()
        {
            this._daoCollection = new CollectionDao();
        }

        #endregion


        #region 访问DAO

        /// <summary>
        /// 查询采集参数
        /// </summary>
        /// <returns></returns>
        public DataSet LoadMethod()
        {
            return this._daoCollection.LoadMethod();
        }

        /// <summary>
        /// 查询采集参数
        /// </summary>
        /// <returns></returns>
        public DataSet LoadMethodName()
        {
            return this._daoCollection.LoadMethodName();
        }

        /// <summary>
        /// 查询是否存在该采集方法
        /// </summary>
        /// <returns></returns>
        public int LoadMethod(CollectionDto dto)
        {
            return this._daoCollection.LoadMethod(dto);
        }

        /// <summary>
        /// 通过采集方法ID确定采集方法
        /// </summary>
        /// <returns></returns>
        public void GetMethodByID(CollectionDto dto)
        {
            this._daoCollection.GetMethodByID(dto);
        }

        /// <summary>
        /// 更新采集方法信息
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateMethod(CollectionDto dto)
        {
            this._daoCollection.UpdateMethod(dto);
        }

        /// <summary>
        /// 插入新的采集方法
        /// </summary>
        /// <param name="dto"></param>
        public void InsertMethod(CollectionDto dto)
        {
            dto.CollectionID = this._daoCollection.GetNewCollectionID();
            this._daoCollection.InsertMethod(dto);
        }

        #endregion

    }
}
