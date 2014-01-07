/*-----------------------------------------------------------------------------
//  FILE NAME       : MethodView.cs
//  FUNCTION        : 方法浏览
//  AUTHOR          : 李锋(2009/05/07)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Data;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoTool.ini;
using ChromatoBll.bll;

namespace ChromatoCore.solu.Ana
{
    /// <summary>
    /// 方法浏览
    /// </summary>
    public partial class AnalyMng : UserControl
    {

        #region 变量

        /// <summary>
        /// 参数Dto
        /// </summary>
        public AnalyParaDto dtoAnaPara = null;

        /// <summary>
        /// 方法逻辑
        /// </summary>
        private AnalyParaBiz bizMethod = null;

        /// <summary>
        /// 方法集合
        /// </summary>
        private DataSet _dsMed = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public AnalyMng()
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
            this.bizMethod = new AnalyParaBiz();
            this.dtoAnaPara = new AnalyParaDto();

            this._dsMed = bizMethod.LoadMethod();
            if (0 < _dsMed.Tables[0].Rows.Count)
            {
                this.dgvAnalyPara.DataSource = this._dsMed.Tables[0];
                this.dtoAnaPara.AnalyParaID = Convert.ToInt32(
                   this._dsMed.Tables[0].Rows[0]["AnalyParaID"].ToString());
            }
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.dgvAnalyPara.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvMethod_CellDoubleClick);
            this.dgvAnalyPara.CellClick += new DataGridViewCellEventHandler(this.dgvMethod_CellClick);
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        }
        
        #endregion


        #region 方法

        /// <summary>
        /// 改变大小
        /// </summary>
        public void CtrlResize()
        {
            this.dgvAnalyPara.Width = this.Width - this.btnNew.Width - 5;
            this.btnNew.Left = this.dgvAnalyPara.Right + 2;
            this.btnRefresh.Left = this.dgvAnalyPara.Right + 2;
            this.btnDelete.Left = this.dgvAnalyPara.Right + 2;
                        
        }

        /// <summary>
        /// 单元格按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMethod_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex)
            {
                return;
            }

            this.dtoAnaPara.AnalyParaID = Convert.ToInt32(
                this.dgvAnalyPara.CurrentRow.Cells["AnalyParaID"].Value.ToString());
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

            this.dtoAnaPara.AnalyParaID = Convert.ToInt32(
                this.dgvAnalyPara.CurrentRow.Cells["AnalyParaID"].Value.ToString());

            this.ShowEditDlg();
        }

        /// <summary>
        /// 显示编辑窗口
        /// </summary>
        private void ShowEditDlg()
        {
            int medid = 0;
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

            AnalyEditFrm frmEdit = new AnalyEditFrm(this.dtoAnaPara, AccessMethod.Edit);
            frmEdit.ShowDialog();
            this.btnRefresh_Click(null, null);
            this.UpdateSelectedRow();
        }

        /// <summary>
        /// 新建按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {

            this.dtoAnaPara.AnalyParaID = this.bizMethod.GetNewAnalyParaID();
            this.dtoAnaPara.ArithmaticID = Arithmatic.Normalize;
            this.dtoAnaPara.ArithmaticPara = ArithmaticParameter.Area;
            this.dtoAnaPara.ColumuModel = "导净315";
            this.dtoAnaPara.Description = "";
            this.dtoAnaPara.AnalyName = "新建方法";
            this.dtoAnaPara.AimWay = ChromatoTool.ini.AimWay.Absolute;
            this.dtoAnaPara.AimPara = ChromatoTool.ini.AimPara.TimeBand;
            this.dtoAnaPara.PeakWide = DefaultAnaly.PeakWide;
            this.dtoAnaPara.Slope = DefaultAnaly.Slope;
            this.dtoAnaPara.Drift = 100;
            this.dtoAnaPara.MinAreaSize = 100;
            this.dtoAnaPara.ParaChangeTime = 100;
            this.dtoAnaPara.Ratio = 100;

            AnalyEditFrm frmEdit = new AnalyEditFrm(this.dtoAnaPara, AccessMethod.New);
            frmEdit.ShowDialog();
            this.btnRefresh_Click(null, null);
            this.UpdateSelectedRow();
        }

        /// <summary>
        /// 更新选中行
        /// </summary>
        private void UpdateSelectedRow()
        {
            if (null == this.dgvAnalyPara.CurrentRow)
            {
                MessageBox.Show("没有方法！", "警告");
                return;
            }

            int medid = 0;
            for (int i = 0; i < this._dsMed.Tables[0].Rows.Count; i++)
            {
                medid = Convert.ToInt32(this.dgvAnalyPara["AnalyParaID", i].Value.ToString());
                if (medid == this.dtoAnaPara.AnalyParaID)
                {
                    // clear datagridview selection
                    this.dgvAnalyPara.ClearSelection();
                    // select new row
                    this.dgvAnalyPara["AnalyParaID", i].Selected = true;
                    break;
                }
            }
        }

        /// <summary>
        /// 方法刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this._dsMed = this.bizMethod.LoadMethod();
            if (0 < _dsMed.Tables[0].Rows.Count)
            {
                this.dgvAnalyPara.DataSource = this._dsMed.Tables[0];
            }
        }

        /// <summary>
        /// 方法删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (null == this.dgvAnalyPara.CurrentRow)
            {
                MessageBox.Show("没有方法！", "警告");
                return;
            }
            if(DialogResult.OK  == MessageBox.Show("确认删除该方法吗？", "警告",MessageBoxButtons.OKCancel))
            {
                this.dtoAnaPara.AnalyParaID = Convert.ToInt32(
                    this.dgvAnalyPara.CurrentRow.Cells["AnalyParaID"].Value.ToString());
                this.bizMethod.DeleteAnalyParaID(this.dtoAnaPara.AnalyParaID);
                this.btnRefresh_Click(null, null);
            }

        }

        /// <summary>
        /// 标题栏按下的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMethod_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.UpdateSelectedRow();
        }
        #endregion


    }
}
