/*-----------------------------------------------------------------------------
//  FILE NAME       : MethodUi.cs
//  FUNCTION        : 方法选择
//  AUTHOR          : 李锋(2009/04//14)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Data;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoBll.dao;
using ChromatoTool.ini;

namespace ChromatoCore.solu.sUi
{
    /// <summary>
    /// 方法选择
    /// </summary>
    public partial class AnalyParaUi : Form
    {
        /// <summary>
        /// 参数Dto
        /// </summary>
        public AnalyParaDto dtoAnaPara = null;

        /// <summary>
        /// 参数Dao
        /// </summary>
        private AnalyParaDao daoMethod = null;

        /// <summary>
        /// 方法集合
        /// </summary>
        private DataSet _dsMed = null;
        
        /// <summary>
        /// 构造
        /// </summary>
        public AnalyParaUi()
        {
            InitializeComponent();
            LoadEvent();
            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this.daoMethod = new AnalyParaDao();
            this.dtoAnaPara = new AnalyParaDto();

            this._dsMed = daoMethod.LoadMethod();
            if (0 < _dsMed.Tables[0].Rows.Count)
            {
                this.dgvAnalyPara.DataSource = this._dsMed.Tables[0];
            }
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.dgvAnalyPara.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvMethod_CellDoubleClick);
        }

        /// <summary>
        /// 单元格按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMethod_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex)
            {
                return;
            }

            int medid = 0;
            this.dtoAnaPara.AnalyParaID = Convert.ToInt32(
                this.dgvAnalyPara.CurrentRow.Cells["AnalyParaID"].Value.ToString());
            for (int i = 0; i < this._dsMed.Tables[0].Rows.Count; i++)
            {
                medid = Convert.ToInt32(this._dsMed.Tables[0].Rows[i]["AnalyParaID"].ToString());
                if (medid == this.dtoAnaPara.AnalyParaID)
                {
                    DataTable dt = this._dsMed.Tables[0];

                    this.dtoAnaPara.ArithmaticID = (Arithmatic)Convert.ToInt32(dt.Rows[i]["ArithmaticID"].ToString());
                    this.dtoAnaPara.ArithmaticPara = (ArithmaticParameter)Convert.ToInt32(dt.Rows[i]["ArithmaticPara"].ToString());
                    this.dtoAnaPara.ColumuModel = dt.Rows[i]["ColumuModel"].ToString();
                    this.dtoAnaPara.Description = dt.Rows[i]["Description"].ToString();
                    this.dtoAnaPara.AnalyName = dt.Rows[i]["AnalyName"].ToString();
                    this.dtoAnaPara.AimWay = (AimWay)Convert.ToInt32(dt.Rows[i]["AimWay"].ToString());
                    this.dtoAnaPara.AimPara = (AimPara)Convert.ToInt32(dt.Rows[i]["AimPara"].ToString());
                    this.dtoAnaPara.PeakWide = Convert.ToInt32(dt.Rows[i]["PeakWide"].ToString());
                    this.dtoAnaPara.Slope = Convert.ToInt32(dt.Rows[i]["Slope"].ToString());
                    this.dtoAnaPara.Drift = Convert.ToInt32(dt.Rows[i]["Drift"].ToString());
                    this.dtoAnaPara.MinAreaSize = Convert.ToSingle(dt.Rows[i]["MinAreaSize"].ToString());
                    this.dtoAnaPara.ParaChangeTime = Convert.ToInt32(dt.Rows[i]["ParaChangeTime"].ToString());
                    this.dtoAnaPara.Ratio = Convert.ToSingle(dt.Rows[i]["Ratio"].ToString());
                }
            }
            this.Close();

        }

    }
}
