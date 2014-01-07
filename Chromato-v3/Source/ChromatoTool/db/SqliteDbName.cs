/*-----------------------------------------------------------------------------
//  FILE NAME       : SqliteDbName.cs
//  FUNCTION        : 从数据库操作类
//  AUTHOR          : 李锋(2008/12/03)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

using System.IO;
using System.Data.Common;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using ChromatoTool.dto;
using ChromatoTool.log;

namespace ChromatoTool.db
{
    /// <summary>
    /// 从数据库操作类
    /// </summary>
    public class SqliteDbName
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

        /// <summary>
        /// 路径
        /// </summary>
        public string dbPath { get; set; }

        /// <summary>
        /// 数据库名
        /// </summary>
        public string dbName { get; set; }
        
        #endregion


        #region 构造实例

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="path"></param>
        public SqliteDbName(string path)
        {
            Console.WriteLine("opening db...");

            if (null == path)
            {
                return;
            }

            int lastindex = Application.ExecutablePath.LastIndexOf('\\');
            //dbPath = @"g:\first.s3db";
            dbPath = Application.ExecutablePath.Substring(0, lastindex + 1) + path;

            lastindex = path.LastIndexOf('\\');
            dbName = path.Substring(lastindex + 1);

            this.ConnectDb();
        }


        #endregion


        #region 方法

        /// <summary>
        /// 连接数据库
        /// </summary>
        public void ConnectDb()
        {
            String temp = "";

            if (null == dbPath || null == dbName)
            {
                return;
            }
            try
            {
                if (!File.Exists(this.dbPath))
                {
                    temp = String.Format("路径{0} 没有找到该文件!", this.dbPath);
                    //MessageBox.Show(temp);
                    CastLog.Logger("SqliteDbName", "ConnectDb", temp);
                    return;


                    // 创建数据库文件
                    //File.Delete(this.dbPath);
                    //SQLiteConnection.CreateFile(this.dbName);

                    //DbProviderFactory factory = SQLiteFactory.Instance;
                    //using (this.cn = (SQLiteConnection)factory.CreateConnection())
                    //{
                    //    // 连接数据库
                    //    cn.ConnectionString = "Data Source = " + this.dbPath;
                    //    cn.Open();

                    //    // 创建数据表
                    //    string sql = "create table [sampleresult] ([deskId] INTEGER NOT NULL,"
                    //         + "[SampleID] INTEGER NOT NULL,[SampleTime] TEXT NOT NULL,[Result] REAL NOT NULL)";
                    //    DbCommand cmd = cn.CreateCommand();
                    //    cmd.Connection = cn;
                    //    cmd.CommandText = sql;
                    //    cmd.ExecuteNonQuery();
                    //    cn.Close();
                    //}
                }

                // Open database
                //if (Settings.General.PackDb)
                //{
                //    cn = new SQLiteConnection("Data Source = " + this.dbPath + ";password = cast1234");
                //}
                //else
                //{
                    cn = new SQLiteConnection("Data Source = " + this.dbPath);
                //}
                cn.Open();

            }
            catch (SQLiteException e)
            {
                Console.WriteLine("Fatal error: {0}", e.Message);
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
            try
            {
                SQLiteDataAdapter sda = new SQLiteDataAdapter(strSql, cn);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                Close();
                return ds;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                //MessageBox.Show("打开表失败","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return null;
            }
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
            ConnectDb();
            cmd = new SQLiteCommand(strSql, cn);
            cmd.ExecuteNonQuery();
            Close();
            #endregion
        }

        /// <summary>
        /// 执行Sql语句,返回Boolean
        /// </summary>
        /// <param name="strSql"></param>
        public bool ExecuteSql(string strSql)
        {
            #region
            bool bRet = false;

            try
            {
                ConnectDb();
                cmd = new SQLiteCommand(strSql, cn);
                bRet = (0 < cmd.ExecuteNonQuery() ) ? true : false;
            }
            catch (SQLiteException ex)
            {
                if (SQLiteErrorCode.Busy == ex.ErrorCode)
                {
                    Thread.Sleep(100);
                    this.ExecuteSql(strSql);
                }
                else
                {
                    throw (ex);
                }
            }
            finally
            {
                this.Close();
            }
            return bRet;
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

        #endregion


        #region OpDbNameDaoを利用する

        /// <summary>
        /// 插入数据，不使用
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="time"></param>
        public void UpdateAllValue(ArrayList arr, String time)
        {
            OriginPointDto dtoPointInfo = null;
            DbTransaction trans = null;



            try
            {
                this.ConnectDb();
                cmd = cn.CreateCommand();

                // 添加参数
                cmd.Parameters.Add(cmd.CreateParameter());
                cmd.Parameters.Add(cmd.CreateParameter());
                cmd.Parameters.Add(cmd.CreateParameter());
                cmd.Parameters.Add(cmd.CreateParameter());

                trans = cn.BeginTransaction(); // <-------------------

                // 连续插入 DATA_COUNT 条记录
                for (int i = 0; i < arr.Count; i++)
                {
                    dtoPointInfo = (OriginPointDto)arr[i];

                    cmd.CommandText = "insert into [T_ExpData] ([desk_indexID],[mdl_typeID],[data],[expTime]) values (?,?,?,?)";
                    //cmd.Parameters[0].Value = dtoPointInfo.desk_IndexID;
                    //cmd.Parameters[1].Value = dtoPointInfo.type_ID.ToString();
                    //cmd.Parameters[2].Value = dtoPointInfo.value;
                    cmd.Parameters[3].Value = time;

                    int count = cmd.ExecuteNonQuery();
                }

                trans.Commit(); // <-------------------
            }
            catch (Exception err)
            {
                trans.Rollback(); // <-------------------
                Console.Out.Write(err.Message);
            }

        }
        #endregion


    }
}
