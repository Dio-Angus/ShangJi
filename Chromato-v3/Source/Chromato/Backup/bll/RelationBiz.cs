/*-----------------------------------------------------------------------------
//  FILE NAME       : RelationBiz.cs
//  FUNCTION        : 关系的逻辑
//  AUTHOR          : 李锋(2009/05/22)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using ChromatoBll.dao;
using ChromatoTool.dto;

namespace ChromatoBll.bll
{
    /// <summary>
    /// 关系的逻辑
    /// </summary>
    public class RelationBiz
    {

        #region 访问数据库

        /// <summary>
        /// 插入新的关系
        /// </summary>
        /// <param name="dto"></param>
        public bool InsertRelation(RelationDto dto)
        {
            RelationDao dao = new RelationDao();
            return dao.InsertRelation(dto);
        }

        /// <summary>
        /// 更新关系
        /// </summary>
        /// <param name="dto"></param>
        public bool UpdateRelation(RelationDto dto)
        {
            RelationDao dao = new RelationDao();
            return dao.UpdateRelation(dto);
        }

        #endregion



    }
}
