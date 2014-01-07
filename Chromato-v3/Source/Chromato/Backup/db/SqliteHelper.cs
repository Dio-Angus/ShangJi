/*-----------------------------------------------------------------------------
//  FILE NAME       : SqliteHelper.cs
//  FUNCTION        : 主数据库操作类
//  AUTHOR          : 李锋(2008/12/03)
//  Modify          : 陈聪(2009/2/26)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using ChromatoTool.log;
using ChromatoTool.ini;


namespace ChromatoTool.db
{
    /// <summary>
    /// 主数据库操作类
    /// </summary>
    public class SqliteHelper
    {

        #region 字段

        /// <summary>
        /// 父库连接
        /// </summary>
        private SQLiteConnection cn = null;

        /// <summary>
        /// 父库SQL命令
        /// </summary>
        private SQLiteCommand cmd = null;

        #endregion


        #region 构造实例
        
        /// <summary>
        /// 构造实例
        /// </summary>
        public SqliteHelper()
        {
            if (!String.IsNullOrEmpty(DbConfig.path) && !String.IsNullOrEmpty(DbConfig.name))
            {
                ConnectDb();
            }
            else
            {
                DbConfig.path = Application.ExecutablePath;
                int lastindex = DbConfig.path.LastIndexOf('\\');
                DbConfig.path = DbConfig.path.Substring(0, lastindex + 1) + DefaultItem.SQLite_DBMain;
                DbConfig.name = DefaultItem.SQLite_DBMain;

                DbConfig.Historypath = DbConfig.path.Substring(0, lastindex + 1) + DefaultItem.SQLite_DBName;
                DbConfig.nameHistory = DefaultItem.SQLite_DBName;

                ConnectDb();
            }
        }
        
        #endregion


        #region 方法
        /// <summary>
        /// 连接父数据库
        /// </summary>
        public void ConnectDb()
        {
            try
            {
                if (!File.Exists(DbConfig.path))
                {
                    CastLog.Logger("SqliteDbName", "严重错误！", "主数据库路径不存在");
                    return;
                }

                if (General.PackDb)
                {
                    cn = new SQLiteConnection("Data Source = " + DbConfig.path + ";password = cast1234");
                }
                else
                {
                    cn = new SQLiteConnection("Data Source = " + DbConfig.path);
                }
                cn.Open();

            }
            catch (SQLiteException)
            {
                //Console.WriteLine("非法错误: {0}", e.Message);
                return;
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            if (cn != null)
            {
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// 返回DataSet数据集
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        public DataSet GetDs(string strSql)
        {
            #region
            ConnectDb();

            SQLiteDataAdapter sda = new SQLiteDataAdapter(strSql, cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            Close();
            return ds;
            #endregion
        }

        /// <summary>
        /// 添加DataSet表
        /// </summary>
        /// <param name="ds">DataSet对象</param>
        /// <param name="strSql">Sql语句</param>
        /// <param name="strTableName">表名</param>
        public void GetDs(DataSet ds, string strSql, string strTableName)
        {
            #region
            ConnectDb();
            SQLiteDataAdapter sda = new SQLiteDataAdapter(strSql, cn);
            sda.Fill(ds, strTableName);
            Close();
            #endregion
        }

        /// <summary>
        /// 返回DataView数据视图
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        public DataView GetDv(string strSql)
        {
            #region
            DataView dv = GetDs(strSql).Tables[0].DefaultView;
            return dv;
            #endregion
        }

        /// <summary>
        /// 获得DataTable对象
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public DataTable GetTable(string strSql)
        {
            #region
            return GetDs(strSql).Tables[0];
            #endregion
        }

        /// <summary>
        /// 获得单表的查询结果
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public bool GetQueryResult(string strSql)
        {
            #region
            return (0 < GetDs(strSql).Tables[0].Rows.Count) ? true : false;
            #endregion
        }

        /// <summary>
        /// 获得SqlDataReader对象 使用完须关闭DataReader,关闭数据库连接
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public SQLiteDataReader GetDataReader(string strSql)
        {
            #region
            ConnectDb();
            cmd = new SQLiteCommand(strSql, cn);
            SQLiteDataReader sdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            return sdr;
            #endregion
        }

        /// <summary>
        /// 执行Sql语句
        /// </summary>
        /// <param name="strSql"></param>
        public void RunSql(string strSql)
        {
            #region
            try
            {
                ConnectDb();
                cmd = new SQLiteCommand(strSql, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Close();
            }
            #endregion
        }

        /// <summary>
        /// 执行Sql语句,返回Boolean
        /// </summary>
        /// <param name="strSql"></param>
        public bool ExecuteSql(string strSql)
        {
            #region
            try
            {
                ConnectDb();
                cmd = new SQLiteCommand(strSql, cn);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw (ex);
            }
            finally
            {
                this.Close();
                //return false;
            }
            #endregion
        }

        /// <summary>
        /// 执行Sql语句,返回int
        /// </summary>
        /// <param name="strSql"></param>
        public int ExecuteSqlRetInt(string strSql)
        {
            #region
            try
            {
                ConnectDb();
                cmd = new SQLiteCommand(strSql, cn);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Close();
            }
            #endregion
        }

        /// <summary>
        /// 执行SQL语句，并返回第一行第一列结果
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public string RunSqlReturn(string strSql)
        {
            #region
            string strReturn = "";
            ConnectDb();
            try
            {
                cmd = new SQLiteCommand(strSql, cn);
                strReturn = cmd.ExecuteScalar().ToString();
            }
            catch { }
            Close();
            return strReturn;
            #endregion
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <returns>返回存储过程返回值</returns>
        public int RunProc(string procName)
        {
            #region
            cmd = CreateCommand(procName, null);
            cmd.ExecuteNonQuery();
            Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
            #endregion
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>返回存储过程返回值</returns>
        public int RunProc(string procName, SQLiteParameter[] prams)
        {
            #region
            cmd = CreateCommand(procName, prams);
            cmd.ExecuteNonQuery();
            Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
            #endregion
        }

        /// <summary>
        /// 执行存储过程返回DataReader对象
        /// </summary>
        /// <param name="procName">Sql语句</param>
        /// <param name="dataReader">DataReader对象</param>
        public void RunProc(string procName, SQLiteDataReader dataReader)
        {
            #region
            cmd = CreateCommand(procName, null);
            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            #endregion
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="dataReader">DataReader对象</param>
        public void RunProc(string procName, SQLiteParameter[] prams, SQLiteDataReader dataReader)
        {
            #region
            cmd = CreateCommand(procName, prams);
            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            #endregion
        }

        /// <summary>
        /// 创建一个SqlCommand对象以此来执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>返回SqlCommand对象</returns>
        private SQLiteCommand CreateCommand(string procName, SQLiteParameter[] prams)
        {
            #region
            // 确认打开连接
            ConnectDb();
            cmd = new SQLiteCommand(procName, cn);
            cmd.CommandType = CommandType.StoredProcedure;

            // 依次把参数传入存储过程
            if (prams != null)
            {
                foreach (SQLiteParameter parameter in prams)
                    cmd.Parameters.Add(parameter);
            }

            // 加入返回参数
            cmd.Parameters.Add(
                new SQLiteParameter("ReturnValue", DbType.Int32, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return cmd;
            #endregion
        }


        /// <summary>
        /// 传入输入参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        private SQLiteParameter MakeInParam(string ParamName, DbType DbType, int Size, object Value)
        {
            #region
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);

            #endregion
        }

        /// <summary>
        /// 传入返回值参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <returns>新的 parameter 对象</returns>
        private SQLiteParameter MakeOutParam(string ParamName, DbType DbType, int Size)
        {
            #region
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
            #endregion
        }

        /// <summary>
        /// 生成存储过程参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Direction">参数方向</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        private SQLiteParameter MakeParam(string ParamName, DbType DbType, Int32 Size,
            ParameterDirection Direction, object Value)
        {
            #region
            SQLiteParameter param = null;

            if (Size > 0)
                param = new SQLiteParameter(ParamName, DbType, Size);
            else
                param = new SQLiteParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
            #endregion
        }


        /// <summary>
        /// 返回DataSet数据集
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        public DataSet GetDs(string strSql, ref SQLiteDataAdapter sda)
        {
            #region
            ConnectDb();

            sda = new SQLiteDataAdapter(strSql, cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            Close();
            return ds;
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        public void UpdateDb( SQLiteDataAdapter adapter, DataTable dt)
        {
            //SQLiteDataAdapter adapter = new SQLiteDataAdapter();

            //this.ConnectDb();
            //cmd = cn.CreateCommand();

            //cmd = new SQLiteCommand(strSql, cn);
            //adapter.SelectCommand = new SQLiteCommand(queryString, cn);
            //SQLiteCommandBuilder cb = new SQLiteCommandBuilder(adapter);

            ////connection.Open();
            //adapter.Fill(ds, tableName);
            //adapter.Update(ds, tableName);//有了OleDbCommandBuilder，此行才有效 
            ////connection.Close();
            //SQLiteCommandBuilder cmdbuilder = new SQLiteCommandBuilder(adapter);
            //adapter.UpdateCommand = cmdbuilder.GetUpdateCommand();
            //adapter.UpdateCommand 
            //adapter.Update(dt);
        }

        #endregion



    }
}
