﻿/*-----------------------------------------------------------------------------
//  FILE NAME       : AntiControlDao.cs
//  FUNCTION        : 反控方法访问dao
//  AUTHOR          : 李锋(2009/07/01)
//  CHANGE LOG      : 
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
    /// 反控方法访问dao
    /// </summary>
    class AntiControlDao
    {

        #region 变量

        /// <summary>
        /// 库操作类
        /// </summary>
        private SqliteHelper _sqlHelper = null;

        /// <summary>
        /// 反控方法数据集合
        /// </summary>
        private DataSet _ds = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public AntiControlDao()
        {
            _sqlHelper = new SqliteHelper();
        }

        #endregion


        #region 访问数据库方法

        /// <summary>
        /// 查询反控方法
        /// </summary>
        /// <returns></returns>
        public DataSet LoadMethod()
        {
            String sql = "SELECT AntiControlID,AntiControlName FROM T_AntiControl ";
            this._ds = _sqlHelper.GetDs(sql);
            return this._ds;
        }

        /// <summary>
        /// 查询是否存在该反控方法
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int LoadMethod(AntiControlDto dto)
        {
            String sql = "SELECT * FROM T_AntiControl Where AntiControlID =" + dto.AntiControlID;
            DataSet ds = _sqlHelper.GetDs(sql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return 0;
            }
            return ds.Tables[0].Rows.Count;
        }

        /// <summary>
        /// 通过反控ID确定反控方法
        /// </summary>
        /// <param name="dto"></param>
        public void GetMethodByID(AntiControlDto dto)
        {
            String sql = "SELECT tc.AntiControlID,tc.AntiControlName,tnb.GateIP,tnb.SourceIP,tnb.MAC,tnb.Mask,tnb.Socket0Address,tnb.Socket0AimIP,tnb.Socket0AimAddress,tnb.Socket0WorkMode,"
            + "tnb.Socket1Address,tnb.Socket1AimIP,tnb.Socket1AimAddress,tnb.Socket1WorkMode,tnb.Socket2Address,tnb.Socket2AimIP,tnb.Socket2AimAddress,tnb.Socket2WorkMode,"
            + "tnb.Socket3Address,tnb.Socket3AimIP,tnb.Socket3AimAddress,tnb.Socket3WorkMode,"
            + "ths.HeatingState,ths.EnablingState,ths.BalanceTime, ths.InitTemp as thsInitTemp,ths.MaintainTime, ths.AlertTemp as thsAlertTemp, ths.ColumnCount, "
            + "ths.RateCol1, ths.TempCol1, ths.TempTimeCol1, ths.RateCol2, ths.TempCol2, ths.TempTimeCol2, ths.RateCol3, ths.TempCol3, ths.TempTimeCol3,"
            + "ths.RateCol4, ths.TempCol4, ths.TempTimeCol4, ths.RateCol5, ths.TempCol5, ths.TempTimeCol5,"
            + "tin.InitTemp1 as tseInitTemp1,tin.InitTemp2 as tseInitTemp2,tin.InitTemp3 as tseInitTemp3,"
            + "tin.AlertTemp1 as tseAlertTemp1,tin.AlertTemp2 as tseAlertTemp2,tin.AlertTemp3 as tseAlertTemp3, tin.ColumnType1, tin.ColumnType2, tin.ColumnType3,"
            + "tin.InjectMode1, tin.InjectMode2, tin.InjectMode3, tin.InjectTime1, tin.InjectTime2, tin.InjectTime3,"
            + "ta.UserIndex, ta.InitTempAux1, ta.AlertTempAux1, ta.InitTempAux2, ta.AlertTempAux2,"
            + "tf.FID1Used,tf.FID2Used,tf.FIDK1Used,tf.FIDK2Used,"
            + "tf.InitTemp1 as tfInitTemp1,tf.InitTemp2 as tfInitTemp2, tf.AlertTemp1 as tfAlertTemp1, tf.AlertTemp2 as tfAlertTemp2,"
            + "tf.MagnifyFactorOne, tf.PolarityOne as tfPolarityOne, tf.MagnifyFactorTwo, tf.PolarityTwo as tfPolarityTwo,"
            + "tt.InitTemp1 as ttInitTemp1, tt.AlertTemp1 as ttAlertTemp1,"
            + "tt.InitTemp2 as ttInitTemp2, tt.AlertTemp2 as ttAlertTemp2,"
            + "tt.CurrentOne, tt.PolarityOne as ttPolarityOne, tt.OnOffOne, tt.AlertOne,"
            + "tt.CurrentTwo, tt.PolarityTwo as ttPolarityTwo, tt.OnOffTwo, tt.AlertTwo"
            + " FROM T_AntiControl as tc, T_NetworkBoard as tnb, T_HeatingSource as ths, T_Inject as tin,"
            + " T_Aux as ta, T_Fid as tf, T_Tcd as tt Where tc.AntiControlID =" + dto.AntiControlID
            + " And tc.AntiControlID = tnb.AntiControlID "
            + " And tc.AntiControlID = ths.AntiControlID "
            + " And tc.AntiControlID = tin.AntiControlID "
            + " And tc.AntiControlID = ta.AntiControlID "
            + " And tc.AntiControlID = tf.AntiControlID "
            + " And tc.AntiControlID = tt.AntiControlID ";

            DataSet ds = _sqlHelper.GetDs(sql);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return;
            }

            dto.AntiControlName = ds.Tables[0].Rows[0]["AntiControlName"].ToString();

            dto.dtoNetworkBoard = new NetworkBoardDto();
            dto.dtoNetworkBoard.GateIP = ds.Tables[0].Rows[0]["GateIP"].ToString();
            dto.dtoNetworkBoard.SourceIP = ds.Tables[0].Rows[0]["SourceIP"].ToString();
            dto.dtoNetworkBoard.MAC = ds.Tables[0].Rows[0]["MAC"].ToString();
            dto.dtoNetworkBoard.Mask = ds.Tables[0].Rows[0]["Mask"].ToString();
            dto.dtoNetworkBoard.Socket0Address = ds.Tables[0].Rows[0]["Socket0Address"].ToString();
            dto.dtoNetworkBoard.Socket0AimIP = ds.Tables[0].Rows[0]["Socket0AimIP"].ToString();
            dto.dtoNetworkBoard.Socket0AimAddress = ds.Tables[0].Rows[0]["Socket0AimAddress"].ToString();
            dto.dtoNetworkBoard.Socket0WorkMode = Convert.ToSingle(ds.Tables[0].Rows[0]["Socket0WorkMode"]);
            dto.dtoNetworkBoard.Socket1Address = ds.Tables[0].Rows[0]["Socket1Address"].ToString();
            dto.dtoNetworkBoard.Socket1AimIP = ds.Tables[0].Rows[0]["Socket1AimIP"].ToString();
            dto.dtoNetworkBoard.Socket1AimAddress = ds.Tables[0].Rows[0]["Socket1AimAddress"].ToString();
            dto.dtoNetworkBoard.Socket1WorkMode = Convert.ToSingle(ds.Tables[0].Rows[0]["Socket1WorkMode"]);
            dto.dtoNetworkBoard.Socket2Address = ds.Tables[0].Rows[0]["Socket2Address"].ToString();
            dto.dtoNetworkBoard.Socket2AimIP = ds.Tables[0].Rows[0]["Socket2AimIP"].ToString();
            dto.dtoNetworkBoard.Socket2AimAddress = ds.Tables[0].Rows[0]["Socket2AimAddress"].ToString();
            dto.dtoNetworkBoard.Socket2WorkMode = Convert.ToSingle(ds.Tables[0].Rows[0]["Socket2WorkMode"]);
            dto.dtoNetworkBoard.Socket3Address = ds.Tables[0].Rows[0]["Socket3Address"].ToString();
            dto.dtoNetworkBoard.Socket3AimIP = ds.Tables[0].Rows[0]["Socket3AimIP"].ToString();
            dto.dtoNetworkBoard.Socket3AimAddress = ds.Tables[0].Rows[0]["Socket3AimAddress"].ToString();
            dto.dtoNetworkBoard.Socket3WorkMode = Convert.ToSingle(ds.Tables[0].Rows[0]["Socket3WorkMode"]);

            dto.dtoHeatingSource = new HeatingSourceDto();
            dto.dtoHeatingSource.BalanceTime = Convert.ToSingle(ds.Tables[0].Rows[0]["BalanceTime"].ToString());
            dto.dtoHeatingSource.InitTemp = Convert.ToSingle(ds.Tables[0].Rows[0]["thsInitTemp"].ToString());
            dto.dtoHeatingSource.MaintainTime = Convert.ToSingle(ds.Tables[0].Rows[0]["MaintainTime"].ToString());
            dto.dtoHeatingSource.AlertTemp = Convert.ToSingle(ds.Tables[0].Rows[0]["thsAlertTemp"].ToString());
            dto.dtoHeatingSource.ColumnCount = Convert.ToSingle(ds.Tables[0].Rows[0]["ColumnCount"].ToString());
            dto.dtoHeatingSource.RateCol1 = Convert.ToSingle(ds.Tables[0].Rows[0]["RateCol1"].ToString());
            dto.dtoHeatingSource.RateCol2 = Convert.ToSingle(ds.Tables[0].Rows[0]["RateCol2"].ToString());
            dto.dtoHeatingSource.RateCol3 = Convert.ToSingle(ds.Tables[0].Rows[0]["RateCol3"].ToString());
            dto.dtoHeatingSource.RateCol4 = Convert.ToSingle(ds.Tables[0].Rows[0]["RateCol4"].ToString());
            dto.dtoHeatingSource.RateCol5 = Convert.ToSingle(ds.Tables[0].Rows[0]["RateCol5"].ToString());
            dto.dtoHeatingSource.TempCol1 = Convert.ToSingle(ds.Tables[0].Rows[0]["TempCol1"].ToString());
            dto.dtoHeatingSource.TempCol2 = Convert.ToSingle(ds.Tables[0].Rows[0]["TempCol2"].ToString());
            dto.dtoHeatingSource.TempCol3 = Convert.ToSingle(ds.Tables[0].Rows[0]["TempCol3"].ToString());
            dto.dtoHeatingSource.TempCol4 = Convert.ToSingle(ds.Tables[0].Rows[0]["TempCol4"].ToString());
            dto.dtoHeatingSource.TempCol5 = Convert.ToSingle(ds.Tables[0].Rows[0]["TempCol5"].ToString());
            dto.dtoHeatingSource.TempTimeCol1 = Convert.ToSingle(ds.Tables[0].Rows[0]["TempTimeCol1"].ToString());
            dto.dtoHeatingSource.TempTimeCol2 = Convert.ToSingle(ds.Tables[0].Rows[0]["TempTimeCol2"].ToString());
            dto.dtoHeatingSource.TempTimeCol3 = Convert.ToSingle(ds.Tables[0].Rows[0]["TempTimeCol3"].ToString());
            dto.dtoHeatingSource.TempTimeCol4 = Convert.ToSingle(ds.Tables[0].Rows[0]["TempTimeCol4"].ToString());
            dto.dtoHeatingSource.TempTimeCol5 = Convert.ToSingle(ds.Tables[0].Rows[0]["TempTimeCol5"].ToString());


            dto.dtoInject = new InjectDto();
            dto.dtoInject.AlertTemp1 = Convert.ToSingle(ds.Tables[0].Rows[0]["tseAlertTemp1"].ToString());
            dto.dtoInject.InitTemp1 = Convert.ToSingle(ds.Tables[0].Rows[0]["tseInitTemp1"].ToString());
            dto.dtoInject.AlertTemp2 = Convert.ToSingle(ds.Tables[0].Rows[0]["tseAlertTemp2"].ToString());
            dto.dtoInject.InitTemp2 = Convert.ToSingle(ds.Tables[0].Rows[0]["tseInitTemp2"].ToString());
            dto.dtoInject.AlertTemp3 = Convert.ToSingle(ds.Tables[0].Rows[0]["tseAlertTemp3"].ToString());
            dto.dtoInject.InitTemp3 = Convert.ToSingle(ds.Tables[0].Rows[0]["tseInitTemp3"].ToString());
            dto.dtoInject.ColumnType1 = Convert.ToInt32(ds.Tables[0].Rows[0]["ColumnType1"].ToString());
            dto.dtoInject.ColumnType2 = Convert.ToInt32(ds.Tables[0].Rows[0]["ColumnType2"].ToString());
            dto.dtoInject.ColumnType3 = Convert.ToInt32(ds.Tables[0].Rows[0]["ColumnType3"].ToString());
            dto.dtoInject.InjectMode1 = Convert.ToInt32(ds.Tables[0].Rows[0]["InjectMode1"].ToString());
            dto.dtoInject.InjectMode2 = Convert.ToInt32(ds.Tables[0].Rows[0]["InjectMode2"].ToString());
            dto.dtoInject.InjectMode3 = Convert.ToInt32(ds.Tables[0].Rows[0]["InjectMode3"].ToString());
            dto.dtoInject.InjectTime1 = Convert.ToInt32(ds.Tables[0].Rows[0]["InjectTime1"].ToString());
            dto.dtoInject.InjectTime2 = Convert.ToInt32(ds.Tables[0].Rows[0]["InjectTime2"].ToString());
            dto.dtoInject.InjectTime3 = Convert.ToInt32(ds.Tables[0].Rows[0]["InjectTime3"].ToString());

            dto.dtoAux = new AuxDto();
            dto.dtoAux.UserIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["UserIndex"].ToString());
            dto.dtoAux.AlertTempAux1 = Convert.ToSingle(ds.Tables[0].Rows[0]["AlertTempAux1"].ToString());
            dto.dtoAux.AlertTempAux2 = Convert.ToSingle(ds.Tables[0].Rows[0]["AlertTempAux2"].ToString());
            dto.dtoAux.InitTempAux1 = Convert.ToSingle(ds.Tables[0].Rows[0]["InitTempAux1"].ToString());
            dto.dtoAux.InitTempAux2 = Convert.ToSingle(ds.Tables[0].Rows[0]["InitTempAux2"].ToString());

            dto.dtoFid = new FidDto();
            dto.dtoFid.FID1Used = Convert.ToBoolean(ds.Tables[0].Rows[0]["FID1Used"]);
            dto.dtoFid.FID2Used = Convert.ToBoolean(ds.Tables[0].Rows[0]["FID2Used"]);
            dto.dtoFid.FIDK1Used = Convert.ToBoolean(ds.Tables[0].Rows[0]["FIDK1Used"]);
            dto.dtoFid.FIDK2Used = Convert.ToBoolean(ds.Tables[0].Rows[0]["FIDK2Used"]);
            dto.dtoFid.AlertTemp1 = Convert.ToSingle(ds.Tables[0].Rows[0]["tfAlertTemp1"].ToString());
            dto.dtoFid.InitTemp1 = Convert.ToSingle(ds.Tables[0].Rows[0]["tfInitTemp1"].ToString());
            dto.dtoFid.AlertTemp2 = Convert.ToSingle(ds.Tables[0].Rows[0]["tfAlertTemp2"].ToString());
            dto.dtoFid.InitTemp2 = Convert.ToSingle(ds.Tables[0].Rows[0]["tfInitTemp2"].ToString());
            dto.dtoFid.MagnifyFactor1 = Convert.ToInt32(ds.Tables[0].Rows[0]["MagnifyFactorOne"].ToString());
            dto.dtoFid.MagnifyFactor2 = Convert.ToInt32(ds.Tables[0].Rows[0]["MagnifyFactorTwo"].ToString());
            dto.dtoFid.Polarity1 = Convert.ToBoolean(ds.Tables[0].Rows[0]["tfPolarityOne"].ToString());
            dto.dtoFid.Polarity2 = Convert.ToBoolean(ds.Tables[0].Rows[0]["tfPolarityTwo"].ToString());

            dto.dtoTcd = new TcdDto();
            dto.dtoTcd.AlertTemp1 = Convert.ToSingle(ds.Tables[0].Rows[0]["ttAlertTemp1"].ToString());
            dto.dtoTcd.InitTemp1 = Convert.ToSingle(ds.Tables[0].Rows[0]["ttInitTemp1"].ToString());
            dto.dtoTcd.AlertTemp2 = Convert.ToSingle(ds.Tables[0].Rows[0]["ttAlertTemp2"].ToString());
            dto.dtoTcd.InitTemp2 = Convert.ToSingle(ds.Tables[0].Rows[0]["ttInitTemp2"].ToString());
            dto.dtoTcd.CurrentOne = Convert.ToSingle(ds.Tables[0].Rows[0]["CurrentOne"].ToString());
            dto.dtoTcd.CurrentTwo = Convert.ToSingle(ds.Tables[0].Rows[0]["CurrentTwo"].ToString());
            dto.dtoTcd.PolarityOne = Convert.ToBoolean(ds.Tables[0].Rows[0]["ttPolarityOne"].ToString());
            dto.dtoTcd.PolarityTwo = Convert.ToBoolean(ds.Tables[0].Rows[0]["ttPolarityTwo"].ToString());
            dto.dtoTcd.OnOffOne = Convert.ToBoolean(ds.Tables[0].Rows[0]["OnOffOne"].ToString());
            dto.dtoTcd.OnOffTwo = Convert.ToBoolean(ds.Tables[0].Rows[0]["OnOffTwo"].ToString());
            dto.dtoTcd.AlertOne = Convert.ToSingle(ds.Tables[0].Rows[0]["AlertOne"].ToString());
            dto.dtoTcd.AlertTwo = Convert.ToSingle(ds.Tables[0].Rows[0]["AlertTwo"].ToString());

            dto.dtoEcd = new EcdDto();
            dto.dtoEcd.Current = 1;
            dto.dtoEcd.Capacity = 1;

        }

        /// <summary>
        /// 更新反控方法到对应的数据库
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateMethod(AntiControlDto dto)
        {
            String sql = "UPDATE [T_AntiControl] SET "
                + "AntiControlName = '" + dto.AntiControlName + "' "
                + "Where AntiControlID = " + dto.AntiControlID;
            bool bRet = this._sqlHelper.ExecuteSql(sql);

            sql = "UPDATE [T_NetworkBoard] SET "
                + "GateIP = '" + dto.dtoNetworkBoard.GateIP + "', "
                + "SourceIP = '" + dto.dtoNetworkBoard.SourceIP + "', "
                + "MAC = '" + dto.dtoNetworkBoard.MAC + "', "
                + "Mask = '" + dto.dtoNetworkBoard.Mask + "', "
                + "Socket0Address = '" + dto.dtoNetworkBoard.Socket0Address + "', "
                + "Socket0AimIP = '" + dto.dtoNetworkBoard.Socket0AimIP + "', "
                + "Socket0AimAddress = '" + dto.dtoNetworkBoard.Socket0AimAddress + "', "
                + "Socket0WorkMode = '" + dto.dtoNetworkBoard.Socket0WorkMode + "', "
                + "Socket1Address = '" + dto.dtoNetworkBoard.Socket1Address + "', "
                + "Socket1AimIP = '" + dto.dtoNetworkBoard.Socket1AimIP + "', "
                + "Socket1AimAddress = '" + dto.dtoNetworkBoard.Socket1AimAddress + "', "
                + "Socket1WorkMode = '" + dto.dtoNetworkBoard.Socket1WorkMode + "', "
                + "Socket2Address = '" + dto.dtoNetworkBoard.Socket2Address + "', "
                + "Socket2AimIP = '" + dto.dtoNetworkBoard.Socket2AimIP + "', "
                + "Socket2AimAddress = '" + dto.dtoNetworkBoard.Socket2AimAddress + "', "
                + "Socket2WorkMode = '" + dto.dtoNetworkBoard.Socket2WorkMode + "', "
                + "Socket3Address = '" + dto.dtoNetworkBoard.Socket3Address + "', "
                + "Socket3AimIP = '" + dto.dtoNetworkBoard.Socket3AimIP + "', "
                + "Socket3AimAddress = '" + dto.dtoNetworkBoard.Socket3AimAddress + "', "
                + "Socket3WorkMode = '" + dto.dtoNetworkBoard.Socket3WorkMode + "', "

                + "Where AntiControlID = " + dto.AntiControlID;
            bRet = this._sqlHelper.ExecuteSql(sql);

            sql = "UPDATE [T_HeatingSource] SET "
                + "BalanceTime = '" + dto.dtoHeatingSource.BalanceTime + "', "
                + "InitTemp = '" + dto.dtoHeatingSource.InitTemp + "', "
                + "MaintainTime = '" + dto.dtoHeatingSource.MaintainTime + "', "
                + "AlertTemp = '" + dto.dtoHeatingSource.AlertTemp + "', "
                + "ColumnCount = '" + dto.dtoHeatingSource.ColumnCount + "', "
                + "RateCol1 = '" + dto.dtoHeatingSource.RateCol1 + "', "
                + "RateCol2 = '" + dto.dtoHeatingSource.RateCol2 + "', "
                + "RateCol3 = '" + dto.dtoHeatingSource.RateCol3 + "', "
                + "RateCol4 = '" + dto.dtoHeatingSource.RateCol4 + "', "
                + "RateCol5 = '" + dto.dtoHeatingSource.RateCol5 + "', "
                + "TempCol1 = '" + dto.dtoHeatingSource.TempCol1 + "', "
                + "TempCol2 = '" + dto.dtoHeatingSource.TempCol2 + "', "
                + "TempCol3 = '" + dto.dtoHeatingSource.TempCol3 + "', "
                + "TempCol4 = '" + dto.dtoHeatingSource.TempCol4 + "', "
                + "TempCol5 = '" + dto.dtoHeatingSource.TempCol5 + "', "
                + "TempTimeCol1 = '" + dto.dtoHeatingSource.TempTimeCol1 + "', "
                + "TempTimeCol2 = '" + dto.dtoHeatingSource.TempTimeCol2 + "', "
                + "TempTimeCol3 = '" + dto.dtoHeatingSource.TempTimeCol3 + "', "
                + "TempTimeCol4 = '" + dto.dtoHeatingSource.TempTimeCol4 + "', "
                + "TempTimeCol5 = '" + dto.dtoHeatingSource.TempTimeCol5 + "' "

                + "Where AntiControlID = " + dto.AntiControlID;
            bRet = this._sqlHelper.ExecuteSql(sql);

            sql = "UPDATE [T_Inject] SET "
                + "AlertTemp1 = '" + dto.dtoInject.AlertTemp1 + "', "
                + "InitTemp1 = '" + dto.dtoInject.InitTemp1 + "', "
                + "AlertTemp2 = '" + dto.dtoInject.AlertTemp2 + "', "
                + "InitTemp2 = '" + dto.dtoInject.InitTemp2 + "', "
                + "AlertTemp3 = '" + dto.dtoInject.AlertTemp3 + "', "
                + "InitTemp3 = '" + dto.dtoInject.InitTemp3 + "', "
                + "InjectMode1 = '" + dto.dtoInject.InjectMode1 + "', "
                + "InjectMode2 = '" + dto.dtoInject.InjectMode2 + "', "
                + "InjectMode3 = '" + dto.dtoInject.InjectMode3 + "', "
                + "InjectTime1 = '" + dto.dtoInject.InjectTime1 + "', "
                + "InjectTime2 = '" + dto.dtoInject.InjectTime2 + "', "
                + "InjectTime3 = '" + dto.dtoInject.InjectTime3 + "', "
                + "ColumnType1 = '" + dto.dtoInject.ColumnType1 + "', "
                + "ColumnType2 = '" + dto.dtoInject.ColumnType2 + "', "
                + "ColumnType3 = '" + dto.dtoInject.ColumnType3 + "' "
                + "Where AntiControlID = " + dto.AntiControlID;
            bRet = this._sqlHelper.ExecuteSql(sql);

            sql = "UPDATE [T_Aux] SET "
                + "UserIndex = '" + dto.dtoAux.UserIndex + "', "
                + "AlertTempAux1 = '" + dto.dtoAux.AlertTempAux1 + "', "
                + "AlertTempAux2 = '" + dto.dtoAux.AlertTempAux2 + "', "
                + "InitTempAux1 = '" + dto.dtoAux.InitTempAux1 + "', "
                + "InitTempAux2 = '" + dto.dtoAux.InitTempAux2 + "' "
               + "Where AntiControlID = " + dto.AntiControlID;
            bRet = this._sqlHelper.ExecuteSql(sql);

            int polarityOne = (dto.dtoFid.Polarity1) ? 1 : 0;
            int polarityTwo = (dto.dtoFid.Polarity2) ? 1 : 0;

            sql = "UPDATE [T_Fid] SET "
                + "FID1Used = '" + dto.dtoFid.FID1Used + "', "
                + "FID2Used = '" + dto.dtoFid.FID2Used + "', "
                + "FIDK1Used = '" + dto.dtoFid.FIDK1Used + "', "
                + "FIDK2Used = '" + dto.dtoFid.FIDK2Used + "', "
                + "AlertTemp = '" + dto.dtoFid.AlertTemp1 + "', "
                + "InitTemp = '" + dto.dtoFid.InitTemp1 + "', "
                + "MagnifyFactorOne = '" + dto.dtoFid.MagnifyFactor1 + "', "
                + "MagnifyFactorTwo = '" + dto.dtoFid.MagnifyFactor2 + "', "
                + "PolarityOne = '" + polarityOne + "', "
                + "PolarityTwo = '" + polarityTwo + "' "
               + "Where AntiControlID = " + dto.AntiControlID;
            bRet = this._sqlHelper.ExecuteSql(sql);

            polarityOne = (dto.dtoTcd.PolarityOne) ? 1 : 0;
            polarityTwo = (dto.dtoTcd.PolarityTwo) ? 1 : 0;
            int onOffOne = (dto.dtoTcd.OnOffOne) ? 1 : 0;
            int onOffTwo = (dto.dtoTcd.OnOffTwo) ? 1 : 0;

            sql = "UPDATE [T_Tcd] SET "
                + "AlertTemp1 = '" + dto.dtoTcd.AlertTemp1 + "', "
                + "InitTemp1 = '" + dto.dtoTcd.InitTemp1 + "', "
                + "AlertTemp2 = '" + dto.dtoTcd.AlertTemp2 + "', "
                + "InitTemp2 = '" + dto.dtoTcd.InitTemp2 + "', "
                + "CurrentOne = '" + dto.dtoTcd.CurrentOne + "', "
                + "CurrentTwo = '" + dto.dtoTcd.CurrentTwo + "', "
                + "AlertOne = '" + dto.dtoTcd.AlertOne + "', "
                + "AlertTwo = '" + dto.dtoTcd.AlertTwo + "', "
                + "OnOffOne = '" + onOffOne + "', "
                + "OnOffTwo = '" + onOffTwo + "', "
                + "PolarityOne = '" + polarityOne + "', "
                + "PolarityTwo = '" + polarityTwo + "' "
                + "Where AntiControlID = " + dto.AntiControlID;
            bRet = this._sqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 返回新的反控方法ID
        /// </summary>
        /// <returns></returns>
        internal int GetNewAntiControlID()
        {
            String sql = "SELECT AntiControlID FROM T_AntiControl ";
            this._ds = _sqlHelper.GetDs(sql);
            if (null == _ds || null == _ds.Tables[0] || 0 == _ds.Tables[0].Rows.Count)
            {
                //"no method find"
                return 1;
            }

            int nMax = 1;
            for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
            {
                int analyid = Convert.ToInt32(
                    _ds.Tables[0].Rows[i]["AntiControlID"].ToString());
                if (nMax <= analyid)
                {
                    nMax = analyid;
                }
            }

            return (nMax + 1);
        }

        /// <summary>
        /// 插入反控方法信息
        /// </summary>
        /// <returns></returns>
        public bool InsertMethod(AntiControlDto dto)
        {
            String sqlStr = "INSERT INTO T_AntiControl(AntiControlID,AntiControlName) VALUES ('"
                + dto.AntiControlID + "','"
                + dto.AntiControlName + "')";
            bool bRet = _sqlHelper.ExecuteSql(sqlStr);

            sqlStr = "INSERT INTO T_NetworkBoard(AntiControlID,GateIP,SourceIP,MAC,Mask,"
            + "Socket0Address,Socket0AimIP,Socket0AimAddress,Socket0WorkMode,"
            + "Socket1Address,Socket1AimIP,Socket1AimAddress,Socket1WorkMode,"
            + "Socket2Address,Socket2AimIP,Socket2AimAddress,Socket2WorkMode,"
            + "Socket3Address,Socket3AimIP,Socket3AimAddress,Socket3WorkMode)  VALUES ('"
            + dto.AntiControlID + "','"
            + dto.dtoNetworkBoard.GateIP + "','"
            + dto.dtoNetworkBoard.SourceIP + "','"
            + dto.dtoNetworkBoard.MAC + "','"
            + dto.dtoNetworkBoard.Mask + "','"
            + dto.dtoNetworkBoard.Socket0Address + "','"
            + dto.dtoNetworkBoard.Socket0AimIP + "','"
            + dto.dtoNetworkBoard.Socket0AimAddress + "','"
            + dto.dtoNetworkBoard.Socket0WorkMode + "','"
            + dto.dtoNetworkBoard.Socket1Address + "','"
            + dto.dtoNetworkBoard.Socket1AimIP + "','"
            + dto.dtoNetworkBoard.Socket1AimAddress + "','"
            + dto.dtoNetworkBoard.Socket1WorkMode + "','"
            + dto.dtoNetworkBoard.Socket2Address + "','"
            + dto.dtoNetworkBoard.Socket2AimIP + "','"
            + dto.dtoNetworkBoard.Socket2AimAddress + "','"
            + dto.dtoNetworkBoard.Socket2WorkMode + "','"
            + dto.dtoNetworkBoard.Socket3Address + "','"
            + dto.dtoNetworkBoard.Socket3AimIP + "','"
            + dto.dtoNetworkBoard.Socket3AimAddress + "','"
            + dto.dtoNetworkBoard.Socket3WorkMode + "')'";
            bRet = _sqlHelper.ExecuteSql(sqlStr);

            sqlStr = "INSERT INTO T_HeatingSource(AntiControlID,HeatingState,EnablingState,AlertTemp,BalanceTime,MaintainTime,ColumnCount,"
            + "InitTemp,RateCol1,RateCol2,RateCol3,RateCol4,RateCol5,TempCol1,TempCol2,TempCol3,TempCol4,TempCol5,"
            + "TempTimeCol1,TempTimeCol2,TempTimeCol3,TempTimeCol4,TempTimeCol5) VALUES ('"
                + dto.AntiControlID + "','"
                + dto.dtoHeatingSource.AlertTemp + "','"
                + dto.dtoHeatingSource.BalanceTime + "','"
                + dto.dtoHeatingSource.MaintainTime + "','"
                + dto.dtoHeatingSource.ColumnCount + "','"
                + dto.dtoHeatingSource.InitTemp + "','"
                + dto.dtoHeatingSource.RateCol1 + "','"
                + dto.dtoHeatingSource.RateCol2 + "','"
                + dto.dtoHeatingSource.RateCol3 + "','"
                + dto.dtoHeatingSource.RateCol4 + "','"
                + dto.dtoHeatingSource.RateCol5 + "','"
                + dto.dtoHeatingSource.TempCol1 + "','"
                + dto.dtoHeatingSource.TempCol2 + "','"
                + dto.dtoHeatingSource.TempCol3 + "','"
                + dto.dtoHeatingSource.TempCol4 + "','"
                + dto.dtoHeatingSource.TempCol5 + "','"
                + dto.dtoHeatingSource.TempTimeCol1 + "','"
                + dto.dtoHeatingSource.TempTimeCol2 + "','"
                + dto.dtoHeatingSource.TempTimeCol3 + "','"
                + dto.dtoHeatingSource.TempTimeCol4 + "','"
                + dto.dtoHeatingSource.TempTimeCol5 + "')";
            bRet = _sqlHelper.ExecuteSql(sqlStr);

            sqlStr = "INSERT INTO T_Inject(AntiControlID,AlertTemp1,InitTemp1,AlertTemp2,InitTemp2,CAlertTemp3,InitTemp3,olumnType1,ColumnType2,ColumnType3,"
                + "InjectMode1,InjectMode2,InjectMode3,InjectTime1,InjectTime2,InjectTime3) VALUES ('"
                + dto.AntiControlID + "','"
                + dto.dtoInject.AlertTemp1 + "','"
                + dto.dtoInject.InitTemp1 + "','"
                + dto.dtoInject.AlertTemp2 + "','"
                + dto.dtoInject.InitTemp2 + "','"
                + dto.dtoInject.AlertTemp3 + "','"
                + dto.dtoInject.InitTemp3 + "','"
                + (int)dto.dtoInject.ColumnType1 + "','"
                + (int)dto.dtoInject.ColumnType2 + "','"
                + (int)dto.dtoInject.ColumnType3 + "','"
                + (int)dto.dtoInject.InjectMode1 + "','"
                + (int)dto.dtoInject.InjectMode2 + "','"
                + (int)dto.dtoInject.InjectMode3 + "','"
                + dto.dtoInject.InjectTime1 + "','"
                + dto.dtoInject.InjectTime2 + "','"
                + dto.dtoInject.InjectTime3 + "')";
            bRet = _sqlHelper.ExecuteSql(sqlStr);

            sqlStr = "INSERT INTO T_Aux(AntiControlID,UserEndex,AlertTempAux1,AlertTempAux2,InitTempAux1,InitTempAux2) VALUES ('"
                + dto.AntiControlID + "','"
                + dto.dtoAux.UserIndex + "','"
                + dto.dtoAux.AlertTempAux1 + "','"
                + dto.dtoAux.AlertTempAux2 + "','"
                + dto.dtoAux.InitTempAux1 + "','"
                + dto.dtoAux.InitTempAux2 + "')";
            bRet = _sqlHelper.ExecuteSql(sqlStr);

            int polarityOne = (dto.dtoFid.Polarity1) ? 1 : 0;
            int polarityTwo = (dto.dtoFid.Polarity2) ? 1 : 0;

            sqlStr = "INSERT INTO T_Fid(AntiControlID,FID1Used,FID2Used,FIDK1Used,FIDK2Used,AlertTemp,InitTemp,MagnifyFactorOne,MagnifyFactorTwo,"
                + "PolarityOne,PolarityTwo) VALUES ('"
                + dto.AntiControlID + "','"
                + dto.dtoFid.FID1Used + "','"
                + dto.dtoFid.FID2Used + "','"
                + dto.dtoFid.FIDK1Used + "','"
                + dto.dtoFid.FIDK2Used + "','"
                + dto.dtoFid.AlertTemp1 + "','"
                + dto.dtoFid.InitTemp1 + "','"
                + dto.dtoFid.MagnifyFactor1 + "','"
                + dto.dtoFid.MagnifyFactor2 + "','"
                + polarityOne + "','"
                + polarityTwo + "')";
            bRet = _sqlHelper.ExecuteSql(sqlStr);

            polarityOne = (dto.dtoTcd.PolarityOne) ? 1 : 0;
            polarityTwo = (dto.dtoTcd.PolarityTwo) ? 1 : 0;
            int onOffOne = (dto.dtoTcd.OnOffOne) ? 1 : 0;
            int onOffTwo = (dto.dtoTcd.OnOffTwo) ? 1 : 0;

            sqlStr = "INSERT INTO T_Tcd(AntiControlID,AlertTemp1,InitTemp1,AlertTemp2,InitTemp2,CurrentOne,CurrentTwo,"
                + "AlertOne, AlertTwo, OnOffOne, OnOffTwo, PolarityOne, PolarityTwo) VALUES ('"
                + dto.AntiControlID + "','"
                + dto.dtoTcd.AlertTemp1 + "','"
                + dto.dtoTcd.InitTemp1 + "','"
                + dto.dtoTcd.AlertTemp2 + "','"
                + dto.dtoTcd.InitTemp2 + "','"
                + dto.dtoTcd.CurrentOne + "','"
                + dto.dtoTcd.CurrentTwo + "','"
                + dto.dtoTcd.AlertOne + "','"
                + dto.dtoTcd.AlertTwo + "','"
                + onOffOne + "','"
                + onOffTwo + "','"
                + polarityOne + "','"
                + polarityTwo + "')";
            bRet = _sqlHelper.ExecuteSql(sqlStr);

            return bRet;
        }

        /// <summary>
        /// 插入或者更新反控方法信息
        /// </summary>
        /// <param name="dto"></param>
        internal void InsertOrUpdateMethod(AntiControlDto dto)
        {
            if (0 < this.LoadMethod(dto))
            {
                this.UpdateMethod(dto);
            }
            else
            {
                this.InsertMethod(dto);
            }
        }

        /// <summary>
        /// 删除反控方法
        /// </summary>
        /// <param name="antiControlID"></param>
        public void DeleteAntiControl(int antiControlID)
        {
            String sql = "Delete FROM T_ColumnPara Where AntiControlID =" + antiControlID;
            bool bRet = this._sqlHelper.ExecuteSql(sql);

            sql = "Delete FROM T_Inject Where AntiControlID =" + antiControlID;
            bRet = this._sqlHelper.ExecuteSql(sql);

            sql = "Delete FROM T_Aux Where AntiControlID =" + antiControlID;
            bRet = this._sqlHelper.ExecuteSql(sql);

            sql = "Delete FROM T_Fid Where AntiControlID =" + antiControlID;
            bRet = this._sqlHelper.ExecuteSql(sql);

            sql = "Delete FROM T_Tcd Where AntiControlID =" + antiControlID;
            bRet = this._sqlHelper.ExecuteSql(sql);

            sql = "Delete FROM T_AntiControl Where AntiControlID =" + antiControlID;
            bRet = this._sqlHelper.ExecuteSql(sql);
        }

        #endregion


    }
}
