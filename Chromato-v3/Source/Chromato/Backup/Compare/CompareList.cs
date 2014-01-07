/*-----------------------------------------------------------------------------
//  FILE NAME       : CompareList.cs
//  FUNCTION        : 比较列表
//  AUTHOR          : 李锋(2009/07/28)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoBll.bll;
using ChromatoTool.ini;

namespace ChromatoCore.Compare
{
    /// <summary>
    /// 比较列表
    /// </summary>
    public partial class CompareList : UserControl
    {


        #region 变量

        /// <summary>
        /// 样品改变事件代理
        /// </summary>
        public event EventHandler<CompareSampleAddArgs> SampleAdded;

        /// <summary>
        /// 样品
        /// </summary>
        private ParaDto _dtoPara = null;

        /// <summary>
        /// 列表数据集合
        /// </summary>
        private DataSet _dsSample = null;

        /// <summary>
        /// 样品逻辑
        /// </summary>
        private ParaBiz _bizPara = null;

        #endregion

        
        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public CompareList()
        {
            InitializeComponent();
            LoadUi();
            LoadEvent();
        }

        /// <summary>
        /// 装事件
        /// </summary>
        private void LoadEvent()
        {
            this.Load += new System.EventHandler(this.SampleList_Load);
            
            this.dgvSampleInfo.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvSampleInfo_CellDoubleClick);
            this.dgvSampleInfo.CellClick += new DataGridViewCellEventHandler(this.dgvSampleInfo_CellClick);
            this.dgvSampleInfo.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvSampleInfo_ColumnHeaderMouseClick);
            this.dgvSampleInfo.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvSampleInfo_DataBindingComplete);
            this.dgvSampleInfo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvSampleInfo_KeyUp);

            this.tsBtnRegNew.Click += new System.EventHandler(this.btnReg_Click);
            this.tsBtnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.cbxQuery.SelectedIndexChanged += new System.EventHandler(this.cbxQuery_SelectedIndexChanged);

        }

        /// <summary>
        /// 装界面
        /// </summary>
        private void LoadUi()
        {
            this._dtoPara = new ParaDto();
            this._bizPara = new ParaBiz();
            this.cbxQuery.SelectedIndex = 3;
            this.dtPickerQuery.Enabled = true;
            this.dtPickerQueryEndDay.Enabled = false;

            this.LoadList();
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
                    ds = this._bizPara.LoadPara(StatusSample.Collected, this.dtPickerQuery.Value.ToString("yyyyMMdd"),
                       (this.dtPickerQuery.Value + oneDay).ToString("yyyyMMdd"));
                    break;
                case QueryChoise.CustomStartDay:
                    ds = this._bizPara.LoadPara(StatusSample.Collected, this.dtPickerQuery.Value.ToString("yyyyMMdd"),
                        (this.dtPickerQueryEndDay.Value + oneDay).ToString("yyyyMMdd"));
                    break;
                case QueryChoise.All:
                    ds = this._bizPara.LoadPara(StatusSample.Collected);
                    break;
                case QueryChoise.RecentTwoWeeks:
                    ds = this._bizPara.LoadPara(StatusSample.Collected, dtStart.ToString("yyyyMMddHHmmss"));
                    break;
            }

            //空检查
            if (null == ds && null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
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

        }

        #endregion


        #region 方法

        /// <summary>
        /// 更新选中行
        /// </summary>
        private void UpdateSelectedRow()
        {
            if (null == this.dgvSampleInfo.CurrentRow)
            {
                MessageBox.Show("没有样品！", "警告");
                return;
            }

            String sampleID = "";
            for (int i = 0; i < this._dsSample.Tables[0].Rows.Count; i++)
            {
                sampleID = this.dgvSampleInfo["SampleID", i].Value.ToString();
                if (sampleID.Equals(this._dtoPara.SampleID))
                {
                    // clear datagridview selection
                    this.dgvSampleInfo.ClearSelection();
                    // select new row
                    this.dgvSampleInfo["SampleName", i].Selected = true;

                    break;
                }
            }
        }

        /// <summary>
        /// 通过事件发送dto
        /// </summary>
        private void UpdateDto()
        {
            DataGridViewRow cRow = this.dgvSampleInfo.CurrentRow;

            this._dtoPara.PathData = cRow.Cells["PathData"].Value.ToString();
            this._dtoPara.ChannelID = cRow.Cells["ChannelID"].Value.ToString();
            this._dtoPara.SampleID = cRow.Cells["sampleID"].Value.ToString();
            this._dtoPara.SampleName = cRow.Cells["SampleName"].Value.ToString();
            this._dtoPara.SampleStatus = cRow.Cells["SampleStatus"].Value.ToString();

            this._dtoPara.SampleType = (TypeSample)Convert.ToInt32(cRow.Cells["SampleType"].Value.ToString());
            this._dtoPara.StopTime = Convert.ToInt32(cRow.Cells["StopTime"].Value.ToString());

            this._dtoPara.InnerWeight = Convert.ToInt32(cRow.Cells["InnerWeight"].Value.ToString());
            this._dtoPara.SampleWeight = Convert.ToInt32(cRow.Cells["SampleWeight"].Value.ToString());
            this._dtoPara.CollectTime = cRow.Cells["CollectTime"].Value.ToString();
            this._dtoPara.RegisterTime = cRow.Cells["RegisterTime"].Value.ToString();
            this._dtoPara.Remark = cRow.Cells["Remark"].Value.ToString();
        }

        /// <summary>
        /// 刷新列表并定位
        /// </summary>
        public void RefreshList(ParaDto dto)
        {
            this._dtoPara = dto;
            this.LoadList();
            this.UpdateSelectedRow();
        }

        /// <summary>
        /// 设置行高
        /// </summary>
        private void SetDgvCellHeight()
        {
            this.dgvSampleInfo.AllowUserToResizeRows = false;
            foreach (DataGridViewRow a in this.dgvSampleInfo.Rows)
            {
                a.Height = 15;
            }
        }

        #endregion


        #region 事件

        /// <summary>
        /// 单击视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex)
            {
                return;
            }

            this.UpdateDto();
        }

        /// <summary>
        /// 双击视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex)
            {
                return;
            }
            this.UpdateDto();
            this.btnReg_Click(null, null);
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                this.UpdateDto();
            }
        }

        /// <summary>
        /// 注册新样品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            if (null == this.dgvSampleInfo.CurrentRow)
            {
                MessageBox.Show("没有选择样品！", "提示!");
            }

            CompareSampleAddArgs eve = new CompareSampleAddArgs(this._dtoPara);
            if (SampleAdded != null)
            {
                this.SampleAdded(this, eve);
            }
        }

        /// <summary>
        /// 样品刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.SampleList_Load(null, null);
        }

        /// <summary>
        /// 画面初期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SampleList_Load(object sender, EventArgs e)
        {
            this.LoadList();

            this._dtoPara = new ParaDto();
            if (null == this._dsSample || null == this._dsSample.Tables[0] || 0 >= this._dsSample.Tables[0].Rows.Count)
            {
                return;
            }

            //更新选中行
            DataRow cRow = this._dsSample.Tables[0].Rows[0];

            this._dtoPara.PathData = cRow["PathData"].ToString();
            this._dtoPara.ChannelID = cRow["ChannelID"].ToString();
            this._dtoPara.SampleID = cRow["sampleID"].ToString();
            this._dtoPara.SampleName = cRow["SampleName"].ToString();
            this._dtoPara.SampleStatus = cRow["SampleStatus"].ToString();

            this._dtoPara.SampleType = (TypeSample)Convert.ToInt32(cRow["SampleType"].ToString());
            this._dtoPara.StopTime = Convert.ToInt32(cRow["StopTime"].ToString());

            this._dtoPara.InnerWeight = Convert.ToInt32(cRow["InnerWeight"].ToString());
            this._dtoPara.SampleWeight = Convert.ToInt32(cRow["SampleWeight"].ToString());
            this._dtoPara.CollectTime = cRow["CollectTime"].ToString();
            this._dtoPara.RegisterTime = cRow["RegisterTime"].ToString();
            this._dtoPara.Remark = cRow["Remark"].ToString();

        }

        /// <summary>
        /// 标题栏按下的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.UpdateSelectedRow();
        }

        /// <summary>
        /// 根据样品状态设定单元格颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvSampleInfo.DefaultCellStyle.BackColor = Color.FromArgb(General.DgvBackColor);
            this.SetDgvCellHeight();

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
