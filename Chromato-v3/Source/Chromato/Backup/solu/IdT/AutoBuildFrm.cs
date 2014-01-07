/*-----------------------------------------------------------------------------
//  FILE NAME       : AutoBuildFrm.cs
//  FUNCTION        : ID表校准选择窗口
//  AUTHOR          : 李锋(2009/06/22)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoBll.bll;
using ChromatoTool.ini;
using System.Collections;

namespace ChromatoCore.solu.IdT
{
    /// <summary>
    /// ID表校准选择窗口
    /// </summary>
    public partial class AutoBuildFrm : AutoBuildBase
    {

        #region 变量

        /// <summary>
        /// 列表数据集合
        /// </summary>
        protected DataSet _dsSample = null;

        /// <summary>
        /// 选中的样品列表
        /// </summary>
        protected ArrayList _arr = null;
        
        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public AutoBuildFrm(IngredientDto dto)
            : base(dto)
        {
            InitializeComponent();
            this._dtoIngre = dto;

            this.LoadUi();
            this.LoadEvent();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._arr = new ArrayList();

            this.cbxQuery.SelectedIndex = 3;
            this.dtPickerQuery.Enabled = true;
            this.dtPickerQueryEndDay.Enabled = false;

            this.cmbCheckCount.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.dgvSampleInfo.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvSampleInfo_ColumnHeaderMouseClick);
            this.dgvSampleInfo.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvSampleInfo_DataBindingComplete);
            
            this.cbxQuery.SelectedIndexChanged += new System.EventHandler(this.cbxQuery_SelectedIndexChanged);
            this.tsBtnRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

        }

        /// <summary>
        /// 装载列表
        /// </summary>
        private void LoadList()
        {
            DateTime dt = DateTime.Now;
            TimeSpan waitTime = new TimeSpan(14, 0, 0, 0, 0);
            TimeSpan oneDay = new TimeSpan(1, 0, 0, 0, 0);

            DateTime dtStart = dt - waitTime;
            DataSet ds = null;

            switch ((QueryChoise)this.cbxQuery.SelectedIndex)
            {
                case QueryChoise.CustomDay:
                    ds = this._bizPara.LoadPickupPara(StatusSample.Collected, this.dtPickerQuery.Value.ToString("yyyyMMdd"),
                       (this.dtPickerQuery.Value + oneDay).ToString("yyyyMMdd"));
                    break;
                case QueryChoise.CustomStartDay:
                    ds = this._bizPara.LoadPickupPara(StatusSample.Collected, this.dtPickerQuery.Value.ToString("yyyyMMdd"),
                        (this.dtPickerQueryEndDay.Value + oneDay).ToString("yyyyMMdd"));
                    break;
                case QueryChoise.RecentTwoWeeks:
                    ds = this._bizPara.LoadPickupPara(StatusSample.Collected, dtStart.ToString("yyyyMMddHHmmss"));
                    break;
                case QueryChoise.All:
                    ds = this._bizPara.LoadPickupPara(StatusSample.Collected);
                    break;
            }

            //空检查
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                if (0 < this.dgvSampleInfo.Rows.Count)
                {
                    this._dsSample.Tables[0].Rows.Clear();
                    this.dgvSampleInfo.DataSource = this._dsSample.Tables[0];
                }
                return;
            }

            this._dsSample = ds;
            this.dgvSampleInfo.DataSource = this._dsSample.Tables[0];
            this.dgvSampleInfo.CurrentCell = this.dgvSampleInfo.Rows[this.dgvSampleInfo.Rows.Count - 1].Cells["SampleName"];
        }

        #endregion


        #region 方法

        /// <summary>
        /// 合法性检验
        /// </summary>
        /// <returns></returns>
        private bool CheckValid()
        {
            int nCheckCount = this.cmbCheckCount.SelectedIndex;
            if (0 == nCheckCount && 0 == this._arr.Count)
            {
                MessageBox.Show("至少选择一点！", "警告");
                return false;
            }
            else if (0 == nCheckCount && 1 < this._arr.Count)
            {
                MessageBox.Show("只能选择一点！", "警告");
                return false;
            }
            else if (0 < nCheckCount && 1 >= this._arr.Count)
            {
                MessageBox.Show("至少选择两点！", "警告");
                return false;
            }
            
            //根据选择的样品计算成分
            //初期化数据集合
            this._dsIngre = new DataSet();
            DataTable dt = this._dsIngre.Tables.Add("T_Ingredient");

            dt.Columns.Add("IDTableID");
            dt.Columns.Add("IDTableName");
            dt.Columns.Add("IngredientID");
            dt.Columns.Add("ReserveTime");
            dt.Columns.Add("IngredientName");
            dt.Columns.Add("TimeBand");
            dt.Columns.Add("IsInnerPeak");

            PeakBiz bizPeak = new PeakBiz();
            ArrayList arrResult = new ArrayList();
            bool bRet = bizPeak.ConvertToIngre(this._arr, this._dtoIngre, ref this._dsIngre, arrResult);
            if (!bRet)
            {
                return false;
            }

            //根据选择的样品计算含量
            this._arrCali = new ArrayList();
            bRet = bizPeak.ConvertToCali(arrResult, this._dtoIngre, this._arrCali, 0);
            if (!bRet)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 设置行高
        /// </summary>
        private void SetDgvCellHeight(DataGridView dgv)
        {
            dgv.AllowUserToResizeRows = false;
            foreach (DataGridViewRow a in dgv.Rows)
            {
                a.Height = 20;
            }
        }

        /// <summary>
        /// 通过事件发送dto
        /// </summary>
        private void SavePickupToArr()
        {

            this._arr.Clear();
            ParaDto dto = null;
            bool bIsPickup = false;
            String temp = null;

            foreach (DataGridViewRow dr in this.dgvSampleInfo.Rows)
            {
                temp = dr.Cells["IsPickup"].Value.ToString();
                if (String.IsNullOrEmpty(temp))
                {
                    continue;
                }
                bIsPickup = Convert.ToBoolean(temp);
                if (bIsPickup)
                {
                    dto = new ParaDto();
                    dto.SampleID = dr.Cells["SampleID"].Value.ToString();
                    dto.PathData = dr.Cells["PathData"].Value.ToString();
                    dto.SampleName = dr.Cells["SampleName"].Value.ToString();
                    dto.SampleWeight = Convert.ToInt32(dr.Cells["SampleWeight"].Value.ToString());

                    this._arr.Add(dto);
                }
            }
        }

        /// <summary>
        /// 更新选中行
        /// </summary>
        private void UpdateDgvSelectedRow()
        {

            //清空选区
            this.dgvSampleInfo.ClearSelection();

            String sampleID = "";
            for (int i = 0; i < this.dgvSampleInfo.RowCount; i++)
            {
                sampleID = this.dgvSampleInfo["SampleID", i].Value.ToString();
                foreach (ParaDto dto in this._arr)
                {
                    if(dto.SampleID.Equals(sampleID))
                    {
                        //选中
                        this.dgvSampleInfo["SampleName", i].Selected = true;
                    }
                }
            }
        }

        #endregion


        #region 事件

        /// <summary>
        /// 取消按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 确定按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SavePickupToArr();
            
            if (!this.CheckValid())
            {
                return;
            }

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        /// <summary>
        /// 标题栏按下的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.UpdateDgvSelectedRow();
        }

        /// <summary>
        /// 设定单元格背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvSampleInfo.DefaultCellStyle.BackColor = Color.FromArgb(General.DgvBackColor);
            this.SetDgvCellHeight(this.dgvSampleInfo);
            foreach (DataGridViewRow a in this.dgvSampleInfo.Rows)
            {

                switch (a.Cells["SampleStatus"].Value.ToString())
                {
                    case StatusSample.Collecting:
                        a.DefaultCellStyle.ForeColor = Color.Gray;
                        break;
                    case StatusSample.Registered:
                        a.DefaultCellStyle.ForeColor = Color.Chocolate;
                        break;
                    case StatusSample.Collected:
                        a.DefaultCellStyle.ForeColor = Color.White;
                        break;
                    case StatusSample.Analyzed:
                        a.DefaultCellStyle.ForeColor = Color.Purple;
                        break;
                }
            }
        }

        /// <summary>
        /// 重新装载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsRefresh_Click(object sender, EventArgs e)
        {
            this.LoadList();
        }

        /// <summary>
        /// 查询选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((QueryChoise)this.cbxQuery.SelectedIndex)
            {
                case QueryChoise.CustomDay:
                    this.dtPickerQuery.Enabled = true;
                    this.dtPickerQueryEndDay.Enabled = false;
                    break;

                case QueryChoise.CustomStartDay:
                    this.dtPickerQuery.Enabled = true;
                    this.dtPickerQueryEndDay.Enabled = true;
                    break;

                case QueryChoise.RecentTwoWeeks:
                case QueryChoise.All:
                    this.dtPickerQuery.Enabled = false;
                    this.dtPickerQueryEndDay.Enabled = false;
                    break;
            }
        }

        #endregion

    }
}
