/*-----------------------------------------------------------------------------
//  FILE NAME       : OriginPointDao.cs
//  FUNCTION        : 原始数据访问Dao
//  AUTHOR          : 李锋(2009/03/01)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


using System;
using ChromatoTool.db;
using System.Data;
using System.Data.SQLite;
using System.Collections;
using ChromatoTool.dto;
using System.Data.Common;
using ChromatoTool.ini;

namespace ChromatoBll.dao
{
    /// <summary>
    /// 原始数据访问Dao
    /// </summary>
    public class OriginPointDao
    {

        #region 变量

        /// <summary>
        /// 数据库操作对象
        /// </summary>
        private SqliteDbName _sqliteDbName = null;

        #endregion


        #region 访问数据库方法
        
        /// <summary>
        /// 读数据文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="arr"></param>
        public DataSet LoadOriData(string path, ArrayList arr)
        {
            this._sqliteDbName = new SqliteDbName(path);
            string sql = "SELECT * FROM T_OrigiPoint";
            DataSet ds = this._sqliteDbName.GetDs(sql);

            arr.Clear();
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return null;
            }

            OriginPointDto dto = null;
            string temp = null;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dto = new OriginPointDto();

                temp = ds.Tables[0].Rows[i]["Index"].ToString();
                if (!"".Equals(temp))
                {
                    dto.Index = Convert.ToInt32(temp);
                }
                temp = ds.Tables[0].Rows[i]["Moment"].ToString();
                if (!"".Equals(temp))
                {
                    dto.Moment = Convert.ToSingle(temp);
                }

                temp = ds.Tables[0].Rows[i]["Voltage"].ToString();
                if (!"".Equals(temp))
                {
                    dto.Voltage = Convert.ToSingle(temp);
                }

                arr.Add(dto);
            }
            return ds;
        }

        /// <summary>
        /// 读数据文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="arr"></param>
        public void LoadOriginalData(string path, ArrayList arr)
        {
            _sqliteDbName = new SqliteDbName(path);
            string sql = "SELECT * FROM T_OrigiPoint";
            SQLiteDataReader rdr = _sqliteDbName.GetDataReader(sql);

            if (rdr == null)
            {
                return;
            }

            arr.Clear();
            OriginPointDto dto = null;
            string temp = null;

            while (rdr.Read())
            {
                dto = new OriginPointDto();
                // get the results of each column


                temp = rdr["Index"].ToString();
                if (!"".Equals(temp))
                {
                    dto.Index = Convert.ToInt32(temp);
                }

                //temp = rdr["defineK"].ToString();
                //if (!"".Equals(temp))
                //{
                //    dto.defineK = Convert.ToSingle(temp);
                //}       
                //temp = rdr["peakFloat"].ToString();
                //if (!"".Equals(temp))
                //{
                //    dto.peakFloat = Convert.ToSingle(temp);
                //}

                //temp = rdr["peakId"].ToString();
                //if (!"".Equals(temp))
                //{
                //    dto.peakId = Convert.ToInt32(temp);
                //}

                //temp = rdr["peakWide"].ToString();
                //if (!"".Equals(temp))
                //{
                //    dto.peakWide = Convert.ToInt32(temp);
                //}

                //temp = rdr["pointK"].ToString();
                //if (!"".Equals(temp))
                //{
                //    dto.pointK = Convert.ToSingle(temp);
                //}

                //temp = rdr["upOrDown"].ToString();
                //if (!"".Equals(temp))
                //{
                //    dto.upOrDown = Convert.ToInt16(temp);
                //}

                temp = rdr["Moment"].ToString();
                if (!"".Equals(temp))
                {
                    dto.Moment = Convert.ToSingle(temp);
                }

                temp = rdr["Voltage"].ToString();
                if (!"".Equals(temp))
                {
                    dto.Voltage = Convert.ToSingle(temp);
                }

                arr.Add(dto);
            }


            if (rdr != null)
            {
                rdr.Close();
            }

        }

        /// <summary>
        /// 插入数据到数据文件,测试用
        /// </summary>
        public void InsertToDb(string path, int count)
        {
            _sqliteDbName = new SqliteDbName(path);

            DbTransaction trans = null;
            SQLiteConnection cn = null;
            SQLiteCommand cmd = null;

            Random rd = new Random();

            try
            {
                // Open database   
                cn = new SQLiteConnection("Data Source = " + _sqliteDbName.dbPath);
                cn.Open();

                _sqliteDbName.ConnectDb();
                cmd = cn.CreateCommand();

                // 添加参数
                cmd.Parameters.Add(cmd.CreateParameter());
                cmd.Parameters.Add(cmd.CreateParameter());
                cmd.Parameters.Add(cmd.CreateParameter());

                trans = cn.BeginTransaction(); // <-------------------

                // delete old data
                cmd.CommandText = "delete from T_OrigiPoint";
                int total = cmd.ExecuteNonQuery();

                Single stime = 0;

                // 连续插入 count 条记录
                for (int i = 0; i < count; i++)
                {
                    cmd.CommandText = "insert into [T_OrigiPoint] ([Moment],[Voltage],[Index])"
                        + " values (?,?,?)";

                    cmd.Parameters[0].Value = Convert.ToSingle(i) / 
                        Convert.ToSingle(General.Frequent) / Convert.ToSingle(DefaultItem.SecondsPerMin);

                    switch (Offline.PlotType)
                    {
                        case SimuType.Sin:

                            stime = Convert.ToSingle(Math.Sin(Convert.ToSingle(i) / Convert.ToSingle(General.Frequent)));
                            cmd.Parameters[1].Value = Convert.ToSingle(Math.Sin(stime));
                            break;
                        case SimuType.Random:

                            cmd.Parameters[1].Value = Convert.ToSingle(rd.NextDouble());
                            break;
                        case SimuType.SinRandom:

                            stime = Convert.ToSingle(Math.Sin(Convert.ToSingle(i) / Convert.ToSingle(General.Frequent)));
                            cmd.Parameters[1].Value = Convert.ToSingle(Math.Sin(stime) + rd.NextDouble() / 10.0);
                            break;
                    }
                    cmd.Parameters[2].Value = Convert.ToSingle(i);

                    total = cmd.ExecuteNonQuery();
                }

                trans.Commit(); // <-------------------
            }
            catch (Exception err)
            {
                trans.Rollback(); // <-------------------
                Console.Out.Write(err.Message);
            }
        }

        /// <summary>
        /// 插入数据到数据文件,真实数据用
        /// </summary>>
        /// <param name="path"></param>
        /// <param name="arr"></param>
        /// <param name="count"></param>
        /// <param name="bIsDeletet">是否删除原来数据</param>
        public void AppendToDb(string path, ArrayList arr, int count, bool bIsDeletet)
        {
            _sqliteDbName = new SqliteDbName(path);

            DbTransaction trans = null;
            SQLiteConnection cn = null;
            SQLiteCommand cmd = null;
            OriginPointDto dto = null;
            int total = 0;

            try
            {
                // Open database   
                cn = new SQLiteConnection("Data Source = " + _sqliteDbName.dbPath);
                cn.Open();

                _sqliteDbName.ConnectDb();
                cmd = cn.CreateCommand();

                // 添加参数
                cmd.Parameters.Add(cmd.CreateParameter());
                cmd.Parameters.Add(cmd.CreateParameter());
                cmd.Parameters.Add(cmd.CreateParameter());


                trans = cn.BeginTransaction(); // <-------------------

                if (bIsDeletet)
                {
                    // 删除老的数据
                    cmd.CommandText = "delete from T_OrigiPoint";
                    total = cmd.ExecuteNonQuery();
                }

                // 连续插入 count 条记录
                for (int i = 0; i < count; i++)
                {
                    dto = (OriginPointDto)arr[i];
                    cmd.CommandText = "insert into [T_OrigiPoint] ([Moment],[Voltage],[Index])"
                        + " values (?,?,?)";

                    cmd.Parameters[0].Value = dto.Moment;
                    cmd.Parameters[1].Value = dto.Voltage;
                    cmd.Parameters[2].Value = dto.Index;
                    total = cmd.ExecuteNonQuery();
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
