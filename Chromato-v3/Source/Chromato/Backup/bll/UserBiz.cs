/*-----------------------------------------------------------------------------
//  FILE NAME       : UserBiz.cs
//  FUNCTION        : 用户逻辑
//  AUTHOR          : 李锋(2009/12/04)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using ChromatoBll.dao;
using ChromatoTool.ini;
using ChromatoTool.dto;
using System.Data;

namespace ChromatoBll.bll
{
    /// <summary>
    /// 用户逻辑
    /// </summary>
    public class UserBiz
    {

        #region 变量

        /// <summary>
        /// 参数Dao
        /// </summary>
        private UserDao daoUser = null;

        #endregion


        #region 构造
        
        /// <summary>
        /// 构造
        /// </summary>
        public UserBiz()
        {
            this.daoUser = new UserDao();
        }

        #endregion


        #region 访问DAO

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public UserInfo QueryUserinfo(UserDto dto)
        {
            UserDao dao = new UserDao();
            return dao.QueryUserinfo(dto);
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <returns></returns>
        public DataSet LoadAll()
        {
            UserDao dao = new UserDao();
            return dao.LoadAll();
        }

        /// <summary>
        /// 插入新的用户
        /// </summary>
        /// <param name="dto"></param>
        public bool InsertUser(UserDto dto)
        {
            UserDao dao = new UserDao();
            return dao.InsertUser(dto);
        }

        /// <summary>
        /// 更新某用户
        /// </summary>
        /// <param name="dto"></param>
        public bool UpdateUser(UserDto dto)
        {
            UserDao dao = new UserDao();
            return dao.UpdateUser(dto);
        }

        /// <summary>
        /// 更新某用户密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool UpdateUser(string userId, string pwd)
        {
            UserDao dao = new UserDao();
            return dao.UpdateUser(userId, pwd);
        }

        /// <summary>
        /// 删除指定用户
        /// </summary>
        /// <param name="dto"></param>
        public void DeleteUser(UserDto dto)
        {
            UserDao dao = new UserDao();
            bool bRet = dao.DeleteUser(dto);
        }

        /// <summary>
        /// 该用户是否存在
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool IsExist(UserDto dto)
        {
            UserDao dao = new UserDao();
            return dao.IsExist(dto);
        }

        #endregion




    }
}
