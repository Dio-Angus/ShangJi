/*-----------------------------------------------------------------------------
//  FILE NAME       : CalibrateDao.cs
//  FUNCTION        : 含量访问Dao
//  AUTHOR          : 李锋(2009/05/15)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.db;
using System.Data;
using System.Data.SQLite;
using ChromatoTool.dto;

namespace ChromatoBll.dao
{
    class CalibrateDao
    {

        #region 变量

        /// <summary>
        /// 库操作类
        /// </summary>
        private SqliteHelper _sqlHelper = null;

        /// <summary>
        /// 查询适配器
        /// </summary>
        private SQLiteDataAdapter sda = null;

        /// <summary>
        /// 数据集合
        /// </summary>
        private DataSet _ds = null;

        #endregion

                
        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public CalibrateDao()
        {
            _sqlHelper = new SqliteHelper();
        }

        #endregion


        #region 访问数据库方法

        /// <summary>
        /// 查询含量表
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCalibrate()
        {
            String sql = "SELECT * FROM T_Calibrate ";
            this._ds = _sqlHelper.GetDs(sql, ref this.sda);
            return this._ds;
        }

        /// <summary>
        /// 通过id表id查询含量
        /// </summary>
        /// <param name="idTableID"></param>
        /// <returns></returns>
        public DataSet LoadCaliByIdTableID(int idTableID)
        {
            String sql = "SELECT * FROM T_Calibrate Where IDTableID = " + idTableID;
            return _sqlHelper.GetDs(sql);
        }

        /// <summary>
        /// 通过ID查询该ID表的详细
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public DataSet LoadCalibrateById(IngredientDto dto)
        {
            String sql = "SELECT * FROM T_Calibrate Where IDTableID = " + dto.IDTableID +
                " And IngredientID = " + dto.IngredientID;
            return _sqlHelper.GetDs(sql);
        }


        public void UpdateDb()
        {
            _sqlHelper.UpdateDb(this.sda, this._ds.Tables[0]);
        }

        /// <summary>
        /// 删除含量表
        /// </summary>
        /// <param name="dto"></param>
        public void DeleteCalibrate(CalibrateDto dto)
        {
            String sql = "Delete FROM T_Calibrate Where IDTableID =" + dto.IDTableID;
            bool bRet = this._sqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 插入含量表
        /// </summary>
        /// <returns></returns>
        public bool InsertCalibrate(CalibrateDto dto)
        {

            String sqlStr = "INSERT INTO T_Calibrate(IDTableID,IngredientID,CalibrateID,SampleID,PeakSize,PeakHeight,SampleWeight,"
                    + "Density, FactorOne, FactorTwo) VALUES ('"
                    + dto.IDTableID + "','"
                    + dto.IngredientID + "','"
                    + dto.CalibrateID + "','"
                    + dto.SampleID + "','"
                    + dto.PeakSize + "','"
                    + dto.PeakHeight + "','"
                    + dto.SampleWeight + "','"
                    + dto.Density + "','"
                    + dto.FactorOne + "','"
                    + dto.FactorTwo + "')";

            return _sqlHelper.ExecuteSql(sqlStr);
        }


        #endregion

    }
}
