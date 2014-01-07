/*-----------------------------------------------------------------------------
//  FILE NAME       : AvgPointDao.cs
//  FUNCTION        : 平均数据访问Dao
//  AUTHOR          : 李锋(2009/03/01)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.db;
using System.Collections;
using System.Data.SQLite;
using ChromatoTool.dto;
using System.Data.Common;
using ChromatoTool.ini;
using System.Data;

namespace ChromatoBll.dao
{
    /// <summary>
    /// 平均数据访问Dao
    /// </summary>
    class AvgPointDao
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
        public DataSet LoadAvgData(string path, ArrayList arr)
        {
            this._sqliteDbName = new SqliteDbName(path);
            string sql = "SELECT * FROM T_AvgPoint";
            DataSet ds = this._sqliteDbName.GetDs(sql);

            arr.Clear();
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return null;
            }

            AvgPointDto dto = null;
            string temp = null;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dto = new AvgPointDto();

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
                temp = ds.Tables[0].Rows[i]["PeakWide"].ToString();
                if (!"".Equals(temp))
                {
                    dto.PeakWide = Convert.ToInt32(temp);
                }

                temp = ds.Tables[0].Rows[i]["SettingSlope"].ToString();
                if (!"".Equals(temp))
                {
                    dto.SettingSlope = Convert.ToSingle(temp);
                }

                temp = ds.Tables[0].Rows[i]["Slope"].ToString();
                if (!"".Equals(temp))
                {
                    dto.Slope = Convert.ToSingle(temp);
                }

                temp = ds.Tables[0].Rows[i]["Drift"].ToString();
                if (!"".Equals(temp))
                {
                    dto.Drift = Convert.ToInt32(temp);
                }

                temp = ds.Tables[0].Rows[i]["StatusPoint"].ToString();
                if (!"".Equals(temp))
                {
                    dto.StatusPoint = (PointStatus)Convert.ToInt32(temp);
                }
                temp = ds.Tables[0].Rows[i]["StatusAvgSlope"].ToString();
                if (!"".Equals(temp))
                {
                    dto.StatusAvgSlope = (AverageSlopeStatus)Convert.ToSingle(temp);
                }
                temp = ds.Tables[0].Rows[i]["TrendPeak"].ToString();
                if (!"".Equals(temp))
                {
                    dto.TrendPeak = (PeakTrend)Convert.ToInt32(temp);
                }

                arr.Add(dto);
            }
            return ds;
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
                cmd.CommandText = "delete from T_AvgPoint";
                int total = cmd.ExecuteNonQuery();

                Single stime = 0;

                // 连续插入 count 条记录
                for (int i = 0; i < count; i++)
                {
                    cmd.CommandText = "insert into [T_AvgPoint] ([Moment],[Voltage],[Index])"
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
        /// </summary>
        public void AppendToDb(string path, ArrayList arr, int count)
        {
            _sqliteDbName = new SqliteDbName(path);

            DbTransaction trans = null;
            SQLiteConnection cn = null;
            SQLiteCommand cmd = null;
            AvgPointDto dto = null;
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
                cmd.Parameters.Add(cmd.CreateParameter());
                cmd.Parameters.Add(cmd.CreateParameter());
                cmd.Parameters.Add(cmd.CreateParameter());
                cmd.Parameters.Add(cmd.CreateParameter());
                cmd.Parameters.Add(cmd.CreateParameter());
                cmd.Parameters.Add(cmd.CreateParameter());
                cmd.Parameters.Add(cmd.CreateParameter());

                trans = cn.BeginTransaction(); // <-------------------

                // delete old data
                cmd.CommandText = "delete from T_AvgPoint";
                total = cmd.ExecuteNonQuery();

                // 连续插入 count 条记录
                for (int i = 0; i < count; i++)
                {
                    dto = (AvgPointDto)arr[i];
                    cmd.CommandText = "insert into [T_AvgPoint] ([Moment],[Voltage],[Index],[PeakWide],[SettingSlope],[Slope],[Drift], "
                        + "[StatusPoint],[StatusAvgSlope],[TrendPeak])"
                        + " values (?,?,?,?,?,?,?,?,?,?)";

                    cmd.Parameters[0].Value = dto.Moment;
                    cmd.Parameters[1].Value = dto.Voltage;
                    cmd.Parameters[2].Value = dto.Index;
                    cmd.Parameters[3].Value = dto.PeakWide;
                    cmd.Parameters[4].Value = dto.SettingSlope;
                    cmd.Parameters[5].Value = dto.Slope;
                    cmd.Parameters[6].Value = dto.Drift;
                    cmd.Parameters[7].Value = dto.StatusPoint;
                    cmd.Parameters[8].Value = dto.StatusAvgSlope;
                    cmd.Parameters[9].Value = dto.TrendPeak;
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
        /// 读数据文件,作为保存到CSV文件的数据源
        /// </summary>
        /// <param name="path"></param>
        /// <param name="arr"></param>
        public DataSet LoadAvgForExport(string path, ArrayList arr)
        {
            this._sqliteDbName = new SqliteDbName(path);
            string sql = "SELECT * FROM T_AvgPoint";
            DataSet ds = this._sqliteDbName.GetDs(sql);

            arr.Clear();
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return null;
            }

            AvgExportDto dto = null;
            string temp = null;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dto = new AvgExportDto();

                temp = ds.Tables[0].Rows[i]["Voltage"].ToString();
                if (!"".Equals(temp))
                {
                    dto.Voltage = Convert.ToSingle(temp);
                }

                temp = ds.Tables[0].Rows[i]["Moment"].ToString();
                if (!"".Equals(temp))
                {
                    dto.Moment = Convert.ToSingle(temp);
                }

                temp = ds.Tables[0].Rows[i]["Index"].ToString();
                if (!"".Equals(temp))
                {
                    dto.Index = Convert.ToInt32(temp);
                }

                temp = ds.Tables[0].Rows[i]["PeakWide"].ToString();
                if (!"".Equals(temp))
                {
                    dto.PeakWide = Convert.ToInt32(temp);
                }

                temp = ds.Tables[0].Rows[i]["SettingSlope"].ToString();
                if (!"".Equals(temp))
                {
                    dto.SettingSlope = Convert.ToSingle(temp);
                }

                temp = ds.Tables[0].Rows[i]["Drift"].ToString();
                if (!"".Equals(temp))
                {
                    dto.Drift = Convert.ToInt32(temp);
                }
                
                temp = ds.Tables[0].Rows[i]["Slope"].ToString();
                if (!"".Equals(temp))
                {
                    dto.Slope = Convert.ToSingle(temp);
                }

                temp = ds.Tables[0].Rows[i]["StatusPoint"].ToString();
                if (!"".Equals(temp))
                {
                    switch ((PointStatus)Convert.ToInt32(temp))
                    {
                        case PointStatus.Up:
                            dto.StatusPoint = "点上升";
                            break;

                        case PointStatus.Down:
                            dto.StatusPoint = "点下降";
                            break;

                        case PointStatus.Flat:
                            dto.StatusPoint = "点平坦";
                            break;
                    }
                }

                temp = ds.Tables[0].Rows[i]["StatusAvgSlope"].ToString();
                if (!"".Equals(temp))
                {
                    switch ((AverageSlopeStatus)Convert.ToSingle(temp))
                    {
                        case AverageSlopeStatus.Up:
                            dto.StatusAvgSlope = "平均斜率上升";
                            break;

                        case AverageSlopeStatus.Down:
                            dto.StatusAvgSlope = "平均斜率下降";
                            break;

                        case AverageSlopeStatus.Flat:
                            dto.StatusAvgSlope = "平均斜率平坦";
                            break;
                    }
                }

                temp = ds.Tables[0].Rows[i]["TrendPeak"].ToString();
                if (!"".Equals(temp))
                {
                    switch ((PeakTrend)Convert.ToInt32(temp))
                    {
                        case PeakTrend.Up:
                            dto.TrendPeak = "趋势上升";
                            break;

                        case PeakTrend.Down:
                            dto.TrendPeak = "趋势下降";
                            break;

                        case PeakTrend.Flat:
                            dto.TrendPeak = "趋势平坦";
                            break;
                    }
                }

                arr.Add(dto);
            }
            return ds;
        }

        #endregion


    }
}
