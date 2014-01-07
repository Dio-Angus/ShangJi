/*-----------------------------------------------------------------------------
//  FILE NAME       : UserDao.cs
//  FUNCTION        : 用户Dao
//  AUTHOR          : 李锋(2009/12/04)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.db;
using System.Data;
using ChromatoTool.dto;
using ChromatoTool.ini;

namespace ChromatoBll.dao
{
    /// <summary>
    /// 用户Dao
    /// </summary>
    class UserDao
    {

        
        #region 变量

        /// <summary>
        /// 库操作类
        /// </summary>
        private SqliteHelper _sqlHelper = null;

        /// <summary>
        /// 方法数据集合
        /// </summary>
        private DataSet _ds = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public UserDao()
        {
            _sqlHelper = new SqliteHelper();
        }

        #endregion


        #region 访问数据库方法

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public UserInfo QueryUserinfo(UserDto dto)
        {
            String sql = "SELECT * FROM T_User "
                + " Where UserID = '" + dto.UserID + "' ";
            this._ds = _sqlHelper.GetDs(sql);

            if (null == this._ds || null == this._ds.Tables[0] || 0 == this._ds.Tables[0].Rows.Count)
            {
                return UserInfo.InvalidUser;
            }

            sql = "SELECT * FROM T_User "
                + " Where UserID = '" + dto.UserID + "' "
                + " And Password = '" + dto.Password + "' ";

            this._ds = _sqlHelper.GetDs(sql);

            if (null == this._ds || null == this._ds.Tables[0] || 0 == this._ds.Tables[0].Rows.Count)
            {
                return UserInfo.InvalidPwd;
            }

            return UserInfo.Pass;
        }
        
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <returns></returns>
        public DataSet LoadAll()
        {
            String sql = "SELECT * FROM T_User ";
            return _sqlHelper.GetDs(sql);
        }

        /// <summary>
        /// 插入新的用户
        /// </summary>
        /// <param name="dto"></param>
        public bool InsertUser(UserDto dto)
        {
            String sqlStr = "INSERT INTO T_User(UserID,ChineseName,Password) "
                + " VALUES ('"
                + dto.UserID + "','"
                + dto.ChineseName + "','"
                + dto.Password + "')";

            return _sqlHelper.ExecuteSql(sqlStr);
        }

        /// <summary>
        /// 更新某用户
        /// </summary>
        /// <param name="dto"></param>
        public bool UpdateUser(UserDto dto)
        {
            String sql = "UPDATE [T_User] SET "
                + "ChineseName = '" + dto.ChineseName + "', "
                + "Password = '" + dto.Password + "' "
                + "Where UserID = '" + dto.UserID + "' ";

            return this._sqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 更新某用户密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool UpdateUser(string userId, string pwd)
        {
            String sql = "UPDATE [T_User] SET "
                + "Password = '" + pwd + "' "
                + "Where UserID = '" + userId + "' ";

            return this._sqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除指定用户
        /// </summary>
        /// <param name="dto"></param>
        public bool DeleteUser(UserDto dto)
        {
            String sql = "Delete FROM T_User Where UserID = '" + dto.UserID + "' ";
            
            return this._sqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 该用户是否存在
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool IsExist(UserDto dto)
        {
            String sql = "SELECT * FROM T_User "
                + " Where UserID = '" + dto.UserID + "' ";
            this._ds = _sqlHelper.GetDs(sql);

            if (null == this._ds || null == this._ds.Tables[0] || 0 == this._ds.Tables[0].Rows.Count)
            {
                return false;
            }
            return true;
        }

        #endregion




    }
}
