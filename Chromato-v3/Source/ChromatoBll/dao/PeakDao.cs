/*-----------------------------------------------------------------------------
//  FILE NAME       : PeakDao.cs
//  FUNCTION        : 峰分析访问Dao
//  AUTHOR          : 李锋(2009/04/16)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.db;
using ChromatoTool.dto;
using System.Collections;
using System.Data;
using System.Data.SQLite;
using System.Data.Common;

namespace ChromatoBll.dao
{
    class PeakDao
    {

        #region 变量

        /// <summary>
        /// 数据库操作对象
        /// </summary>
        private SqliteDbName _sqliteDbName = null;

        #endregion


        #region 访问数据库Dao

        /// <summary>
        /// 提取谱图参数
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dto"></param>
        public void LoadPeak(string path, ref PeakDto dto)
        {
            this._sqliteDbName = new SqliteDbName(path);
            String sql = "SELECT * FROM T_Peak ";
            DataSet ds = _sqliteDbName.GetDs(sql);
            if (null != ds && null != ds.Tables[0] && 0 < ds.Tables[0].Rows.Count)
            {
                //dto = new ParaDto();
                //dto.PeakWide = Convert.ToInt32(ds.Tables[0].Rows[0]["PeakWide"].ToString());
                //dto.Slope = Convert.ToInt32(ds.Tables[0].Rows[0]["Slope"].ToString());
                //dto.Drift = Convert.ToInt32(ds.Tables[0].Rows[0]["Drift"].ToString());
                //dto.MinAreaSize = Convert.ToInt32(ds.Tables[0].Rows[0]["MinAreaSize"].ToString());
                //dto.ParaChangeTime = Convert.ToInt32(ds.Tables[0].Rows[0]["ParaChangeTime"].ToString());
                //dto.ShowMaxY = Convert.ToSingle(ds.Tables[0].Rows[0]["ShowMaxY"].ToString());
                //dto.ShowMinY = Convert.ToSingle(ds.Tables[0].Rows[0]["ShowMinY"].ToString());
            }
        }

        /// <summary>
        /// 结果表中更新一个峰
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdatePeak(string path, PeakDto dto)
        {

            int isStartDown = (dto.IsStartDown) ? 1 : 0;
            int isEndDown = (dto.IsEndDown) ? 1 : 0;

            this._sqliteDbName = new SqliteDbName(path);
            String sql = "UPDATE [T_Peak] SET "
                + "StartPointIndex = '" + dto.StartPointIndex + "',"
                + "EndPointIndex = '" + dto.EndPointIndex + "',"
                + "TopPointIndex = '" + dto.TopPointIndex + "',"
                + "ReserveTime = '" + dto.ReserveTime + "',"
                + "BaseK = '" + dto.BaseK + "',"
                + "BaseB = '" + dto.BaseB + "',"
                + "PeakName = '" + dto.PeakName + "',"
                + "AreaSize = '" + dto.AreaSize + "',"
                + "PeakHeight = '" + dto.PeakHeight + "',"
                + "Density = '" + dto.Density + "',"
                + "PeakType = '" + dto.PeakType + "',"
                + "GroupID = '" + dto.GroupID + "',"
                + "IsStartDown = '" + isStartDown + "',"
                + "IsEndDown = '" + isEndDown + "',"
                + "StartMoment = '" + dto.StartMoment + "',"
                + "EndMoment = '" + dto.EndMoment + "',"
                + "StartVoltage = '" + dto.StartVoltage + "',"
                + "EndVoltage = '" + dto.EndVoltage + "',"
                + "StartPointCloseIndex = '" + dto.StartPointCloseIndex + "',"
                + "EndPointCloseIndex = '" + dto.EndPointCloseIndex + "',"
                + "PeakStep = '" + dto.PeakStep + "' "
                + "Where PeakID = " + dto.PeakID;

            bool bRet = this._sqliteDbName.ExecuteSql(sql);
            return bRet;
        }

        /// <summary>
        /// 删除一条峰的结果
        /// </summary>
        /// <param name="path"></param>
        /// <param name="peakID"></param>
        public bool DeletePeak(string path, int peakID)
        {
            this._sqliteDbName = new SqliteDbName(path);
            String sql = "Delete FROM T_Peak Where PeakID =" + peakID;

            bool bRet = this._sqliteDbName.ExecuteSql(sql);
            return bRet;
        }

        /// <summary>
        /// 结果表中追加一个峰
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddPeak(string path, PeakDto dto)
        {
            int isStartDown = (dto.IsStartDown) ? 1 : 0;
            int isEndDown = (dto.IsEndDown) ? 1 : 0;

            this._sqliteDbName = new SqliteDbName(path);
            String sql = "insert into [T_Peak] ([PeakID],[StartPointIndex],[EndPointIndex],[TopPointIndex],"
                        + "[ReserveTime],[BaseK],[BaseB],[PeakName],[AreaSize],[PeakHeight],[Density],[PeakType],[GroupID],"
                        + "[IsStartDown],[IsEndDown],[StartMoment],[EndMoment],[StartVoltage],[EndVoltage],[StartPointCloseIndex],[EndPointCloseIndex],[PeakStep]) "
                        + "VALUES ('"
                        + dto.PeakID + "','"
                        + dto.StartPointIndex + "','"
                        + dto.EndPointIndex + "','"
                        + dto.TopPointIndex + "','"
                        + dto.ReserveTime + "','"
                        + dto.BaseK + "','"
                        + dto.BaseB + "','"
                        + dto.PeakName + "','"
                        + dto.AreaSize + "','"
                        + dto.PeakHeight + "','"
                        + dto.Density + "','"
                        + dto.PeakType + "','"
                        + dto.GroupID + "','"
                        + isStartDown + "','"
                        + isEndDown + "','"
                        + dto.StartMoment + "','"
                        + dto.EndMoment + "','"
                        + dto.StartVoltage + "','"
                        + dto.EndVoltage + "','"
                        + dto.StartPointCloseIndex + "','"
                        + dto.EndPointCloseIndex + "','"
                        + dto.PeakStep + "')";
            bool bRet = this._sqliteDbName.ExecuteSql(sql);
            return bRet;
        }

        /// <summary>
        /// 查询峰的结果
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public DataSet LoadPeakResult(string path)
        {
            this._sqliteDbName = new SqliteDbName(path);
            String sql = "SELECT * FROM T_Peak ";
            return this._sqliteDbName.GetDs(sql);
        }

        /// <summary>
        /// 查询峰的结果
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public DataSet LoadPrintPeakResult(string path)
        {
            this._sqliteDbName = new SqliteDbName(path);
            String sql = "SELECT PeakID as '峰ID', PeakName as '组分名', ReserveTime as '保留时间', PeakHeight as '峰高(微伏)',"
                        + "AreaSize as '峰面积(微伏*秒)', Density as '浓度', PeakType as '类型'  FROM T_Peak ";
            return this._sqliteDbName.GetDs(sql);
        }

        /// <summary>
        /// 插入结果到数据库,真实数据用
        /// </summary>
        public void AppendToDb(string path, ArrayList arr, int count)
        {
            _sqliteDbName = new SqliteDbName(path);

            DbTransaction trans = null;
            SQLiteConnection cn = null;
            SQLiteCommand cmd = null;
            PeakDto dto = null;
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
                cmd.Parameters.Add(cmd.CreateParameter());
                cmd.Parameters.Add(cmd.CreateParameter());

                trans = cn.BeginTransaction(); // <-------------------

                // delete old data
                if (count >= 0)
                {
                    cmd.CommandText = "delete from T_Peak";
                    total = cmd.ExecuteNonQuery();
                }

                // 连续插入 count 条记录
                for (int i = 0; i < count; i++)
                {
                    dto = (PeakDto)arr[i];
                    cmd.CommandText = "insert into [T_Peak] ([PeakID],[StartPointIndex],[EndPointIndex],[TopPointIndex],"
                        + "[ReserveTime],[BaseK],[BaseB],[PeakName],[AreaSize],[PeakHeight],[Density],[PeakType],[GroupID],"
                        + "[IsStartDown],[IsEndDown],[StartMoment],[EndMoment],[StartVoltage],[EndVoltage],[StartPointCloseIndex],[EndPointCloseIndex],[PeakStep]) "
                        + " values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                    cmd.Parameters[0].Value = dto.PeakID;
                    cmd.Parameters[1].Value = dto.StartPointIndex;
                    cmd.Parameters[2].Value = dto.EndPointIndex;
                    cmd.Parameters[3].Value = dto.TopPointIndex;
                    cmd.Parameters[4].Value = dto.ReserveTime;
                    cmd.Parameters[5].Value = dto.BaseK;
                    cmd.Parameters[6].Value = dto.BaseB;
                    cmd.Parameters[7].Value = dto.PeakName;
                    cmd.Parameters[8].Value = dto.AreaSize;
                    cmd.Parameters[9].Value = dto.PeakHeight;
                    cmd.Parameters[10].Value = dto.Density;
                    cmd.Parameters[11].Value = dto.PeakType;
                    cmd.Parameters[12].Value = dto.GroupID;
                    cmd.Parameters[13].Value = dto.IsStartDown;
                    cmd.Parameters[14].Value = dto.IsEndDown;
                    cmd.Parameters[15].Value = dto.StartMoment;
                    cmd.Parameters[16].Value = dto.EndMoment;
                    cmd.Parameters[17].Value = dto.StartVoltage;
                    cmd.Parameters[18].Value = dto.EndVoltage;
                    cmd.Parameters[19].Value = dto.StartPointCloseIndex;
                    cmd.Parameters[20].Value = dto.EndPointCloseIndex;
                    cmd.Parameters[21].Value = dto.PeakStep;
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
