/*-----------------------------------------------------------------------------
//  FILE NAME       : SoluList.cs
//  FUNCTION        : 方案列表窗体
//  AUTHOR          : 李锋(2009/03/19)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoBll.bll;
using ChromatoTool.ini;

namespace ChromatoCore.solu
{

    /// <summary>
    /// 方案列表窗体
    /// </summary>
    public partial class SoluList : UserControl
    {

        #region 变量

        /// <summary>
        /// 方案选择改变事件
        /// </summary>
        public event EventHandler<SolutionChangeArgs> SolutionChanged;

        /// <summary>
        /// 方案Dto
        /// </summary>
        private SolutionDto _dtoSolution = null;

        /// <summary>
        /// 方案逻辑
        /// </summary>
        private SolutionBiz _bizSolution = null;

        /// <summary>
        /// 列表数据集合
        /// </summary>
        private DataSet _dsSolution = null;

        /// <summary>
        /// 下部视图当前tab的tag
        /// </summary>
        public String _currentTabTag = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SoluList()
        {
            InitializeComponent();
            LoadUi();
            LoadEvent();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.dgvSolution.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvSolution_CellDoubleClick);
            this.dgvSolution.CellClick += new DataGridViewCellEventHandler(this.dgvSolution_CellClick);
            this.dgvSolution.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSolution_ColumnHeaderMouseClick);
            this.dgvSolution.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSolution_DataBindingComplete);
            this.dgvSolution.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvSolution_KeyUp);

            this.tsBtnRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
            this.tsBtnRegNew.Click += new System.EventHandler(this.btnReg_Click);
            this.tsBtnEdit.Click += new System.EventHandler(this.btnModify_Click);
            this.tsBtnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            this.tsBtnDelete.Click += new System.EventHandler(this.btnDel_Click);

            this.cbxQuery.SelectedIndexChanged += new System.EventHandler(this.cbxQuery_SelectedIndexChanged);
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._dtoSolution = new SolutionDto();
            this._bizSolution = new SolutionBiz();
            this.cbxQuery.SelectedIndex = 3;
            this.dtPickerQuery.Enabled = true;
            this.dtPickerQueryEndDay.Enabled = false;

            this.LoadList();
            this.dgvSolution.BackgroundColor = Color.FromArgb(General.DgvBackColor);

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
                    ds = this._bizSolution.LoadSoluByTime(this.dtPickerQuery.Value.ToString("yyyyMMdd"),
                       (this.dtPickerQuery.Value + oneDay).ToString("yyyyMMdd"));
                    break;
                case QueryChoise.CustomStartDay:
                    ds = this._bizSolution.LoadSoluByTime(this.dtPickerQuery.Value.ToString("yyyyMMdd"),
                        (this.dtPickerQueryEndDay.Value + oneDay).ToString("yyyyMMdd"));
                    break;
                case QueryChoise.All:
                    ds = this._bizSolution.LoadAllSolu();
                    break;
                case QueryChoise.RecentTwoWeeks:
                    ds = this._bizSolution.LoadSoluByTime(dtStart.ToString("yyyyMMddHHmmss"));
                    break;
            }

            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                this.tsBtnDelete.Enabled = false;
                this.tsBtnEdit.Enabled = false;
                this.tsBtnSaveAs.Enabled = false;

                if (0 < this.dgvSolution.Rows.Count)
                {
                    this._dsSolution.Tables[0].Rows.Clear();
                    this.dgvSolution.DataSource = this._dsSolution.Tables[0];
                }

                this._dtoSolution = null;
                SolutionChangeArgs eve = new SolutionChangeArgs(this._dtoSolution);
                if (SolutionChanged != null)
                {
                    this.SolutionChanged(this, eve);
                }
                return;
            }

            this.tsBtnDelete.Enabled = true;
            this.tsBtnEdit.Enabled = true;
            this.tsBtnSaveAs.Enabled = true;

            this._dsSolution = ds;
            this.dgvSolution.DataSource = this._dsSolution.Tables[0];

        }

        #endregion


        #region 方法

        /// <summary>
        /// 更新选中行
        /// </summary>
        private void UpdateSelectedRow()
        {
            if (null == this.dgvSolution.CurrentRow)
            {
                MessageBox.Show("没有方案！", "警告");
                return;
            }

            int soluID = 0;
            for (int i = 0; i < this._dsSolution.Tables[0].Rows.Count; i++)
            {
                soluID = Convert.ToInt32(this.dgvSolution["SolutionID", i].Value.ToString());
                if (soluID == this._dtoSolution.SolutionID)
                {
                    // clear datagridview selection
                    this.dgvSolution.ClearSelection();
                    // select new row
                    this.dgvSolution["SolutionID", i].Selected = true;
                    break;
                }
            }
        }


        /// <summary>
        /// 通过事件发送dto
        /// </summary>
        private void SendChangeEvent()
        {
            DataGridViewRow cRow = this.dgvSolution.CurrentRow;

            this._dtoSolution.SolutionID = Convert.ToInt32(cRow.Cells["SolutionID"].Value.ToString());
            this._dtoSolution.SolutionName = cRow.Cells["SolutionName"].Value.ToString();
            this._dtoSolution.CollectionID = Convert.ToInt32(cRow.Cells["CollectionID"].Value.ToString());
            this._dtoSolution.AnalyParaID = Convert.ToInt32(cRow.Cells["AnalyParaID"].Value.ToString());
            this._dtoSolution.AntiMethodID = Convert.ToInt32(cRow.Cells["AntiMethodID"].Value.ToString());
            this._dtoSolution.IDTableID = Convert.ToInt32(cRow.Cells["IDTableID"].Value.ToString());
            this._dtoSolution.TimeProcID = Convert.ToInt32(cRow.Cells["TimeProcID"].Value.ToString());
            this._dtoSolution.Remark = cRow.Cells["Remark"].Value.ToString();

            SolutionChangeArgs eve = new SolutionChangeArgs(this._dtoSolution);
            if (SolutionChanged != null)
            {
                this.SolutionChanged(this, eve);
            }
        }

        /// <summary>
        /// 设置行高
        /// </summary>
        private void SetDgvCellHeight()
        {
            this.dgvSolution.AllowUserToResizeRows = false;
            foreach (DataGridViewRow a in this.dgvSolution.Rows)
            {
                a.Height = 18;
            }
        }

        #endregion


        #region 事件

        /// <summary>
        /// 单击网格视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSolution_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex)
            {
                return;
            }

            this.SendChangeEvent();
        }

        /// <summary>
        /// 双击网格视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSolution_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex)
            {
                return;
            }

            SoluRegistryFrm soluForm = new SoluRegistryFrm(AccessMethod.Edit, this._dtoSolution, this._currentTabTag);

            if (DialogResult.OK == soluForm.ShowDialog())
            {
                this.RefreshList(soluForm._dtoSolution);
            }
        }
        
        /// <summary>
        /// 注册按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            SoluRegistryFrm soluForm = new SoluRegistryFrm(AccessMethod.New, null, _currentTabTag);

            if (DialogResult.OK == soluForm.ShowDialog())
            {
                this.RefreshList(soluForm._dtoSolution);
            }
        }

        /// <summary>
        /// 刷新列表并定位
        /// </summary>
        public void RefreshList(SolutionDto dto)
        {
            this._dtoSolution = dto;
            this.LoadList();
            this.UpdateSelectedRow();
            SolutionChangeArgs eve = new SolutionChangeArgs(this._dtoSolution);
            if (SolutionChanged != null)
            {
                this.SolutionChanged(this, eve);
            }
        }

        /// <summary>
        /// 修改按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            SoluRegistryFrm soluForm = new SoluRegistryFrm(AccessMethod.Edit, this._dtoSolution, this._currentTabTag);

            if (DialogResult.OK == soluForm.ShowDialog())
            {
                this.RefreshList(soluForm._dtoSolution);
            }
        }

        /// <summary>
        /// 另存为按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SoluRegistryFrm soluForm = new SoluRegistryFrm(AccessMethod.SaveAs, this._dtoSolution, this._currentTabTag);

            if (DialogResult.OK == soluForm.ShowDialog())
            {
                this.RefreshList(soluForm._dtoSolution);
            }
        }

        /// <summary>
        /// 删除按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定删除方案【" + this._dtoSolution.SolutionID + ':' + this._dtoSolution.SolutionName + "】吗?", "删除提示!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                this._bizSolution.DeleteSolu(this._dtoSolution);
                this.SoluList_Load(null, null);
            }
        }

        /// <summary>
        /// 画面初期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoluList_Load(object sender, EventArgs e)
        {
            this.LoadList();

            this._dtoSolution = new SolutionDto();
            if (null == this._dsSolution || null == this._dsSolution.Tables[0] || 0 >= this._dsSolution.Tables[0].Rows.Count)
            {
                return;
            }

            //更新选中行
            DataRow cRow = this._dsSolution.Tables[0].Rows[0];

            this._dtoSolution.SolutionID = Convert.ToInt32(cRow["SolutionID"].ToString());
            this._dtoSolution.SolutionName = cRow["SolutionName"].ToString();
            this._dtoSolution.CollectionID = Convert.ToInt32(cRow["CollectionID"].ToString());
            this._dtoSolution.AnalyParaID = Convert.ToInt32(cRow["AnalyParaID"].ToString());
            this._dtoSolution.AntiMethodID = Convert.ToInt32(cRow["AntiMethodID"].ToString());
            this._dtoSolution.IDTableID = Convert.ToInt32(cRow["IDTableID"].ToString());
            this._dtoSolution.TimeProcID = Convert.ToInt32(cRow["TimeProcID"].ToString());
            this._dtoSolution.Remark = cRow["Remark"].ToString();

            SolutionChangeArgs eve = new SolutionChangeArgs(this._dtoSolution);
            if (SolutionChanged != null)
            {
                this.SolutionChanged(this, eve);
            }
        }

        /// <summary>
        /// 设定单元格背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSolution_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvSolution.DefaultCellStyle.BackColor = Color.FromArgb(General.DgvBackColor);
            this.SetDgvCellHeight();

            foreach (DataGridViewRow a in this.dgvSolution.Rows)
            {
                a.DefaultCellStyle.ForeColor = Color.White;
            }
        }

        /// <summary>
        /// 刷新菜单项按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsRefresh_Click(object sender, EventArgs e)
        {
            this.SoluList_Load(null, null);
        }

        /// <summary>
        /// 标题栏按下的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSolution_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.UpdateSelectedRow();
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSolution_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                this.SendChangeEvent();
            }
        }


        /// <summary>
        /// 查询方案改变
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
            this.SoluList_Load(null, null);
        }


        #endregion


    }
}
