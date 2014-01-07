/*-----------------------------------------------------------------------------
//  FILE NAME       : OffGasSum.cs
//  FUNCTION        : 汇总样品结果选择控件
//  AUTHOR          : 李锋(2010/04/23)
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

namespace ChromatoCore.Off
{
    /// <summary>
    /// 汇总样品结果选择控件
    /// </summary>
    public partial class OffGasSum : UserControl
    {


        #region 变量

        /// <summary>
        /// 列表数据集合
        /// </summary>
        private DataSet _dsSample = null;

        /// <summary>
        /// 样品逻辑
        /// </summary>
        private ParaBiz _bizPara = null;

        /// <summary>
        /// 关闭按钮按下的事件代理
        /// </summary>
        public event CloseBtnClickDelegate BtnCloseClickedEvent;

        /// <summary>
        /// 汇总按钮按下的事件代理
        /// </summary>
        public event EventHandler<OffSumBtnClickArgs> SumClicked;

        /// <summary>
        /// 汇总逻辑
        /// </summary>
        private OffGasSumBiz _bizOffGasSum = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OffGasSum()
        {
            InitializeComponent();

            this.LoadEvent();
            this.LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._bizPara = new ParaBiz();
            this._bizOffGasSum = new OffGasSumBiz();

            this.cbxQuery.SelectedIndex = 3;
            this.dtPickerQuery.Enabled = true;
            this.dtPickerQueryEndDay.Enabled = false;
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {

            this.dgvSampleInfo.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvSampleInfo_ColumnHeaderMouseClick);
            this.dgvSampleInfo.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvSampleInfo_DataBindingComplete);

            //关闭按钮按下事件
            this.tsBtnClose.Click += new System.EventHandler(this.btnCancel_Click);

            //汇总按钮按下事件
            this.tsBtnSum.Click += new System.EventHandler(this.btnSum_Click);

            this.cbxQuery.SelectedIndexChanged += new System.EventHandler(this.cbxQuery_SelectedIndexChanged);
            this.tsBtnRefresh.Click += new System.EventHandler(this.tsRefresh_Click);

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
            if (this._bizOffGasSum._arr.Count == 0)
            {
                MessageBox.Show("没有选择！", "警告");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 装载结果
        /// </summary>
        public DataTable LoadResult(ParaDto dto)
        {

            //取得结果，刷新列表
            PeakBiz bizPeak = new PeakBiz();
            DataSet ds = bizPeak.LoadResult(dto.PathData);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return null;
            }

            return ds.Tables[0];
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

            this._bizOffGasSum._arr.Clear();
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
                    dto.RegisterTime = dr.Cells["RegisterTime"].Value.ToString();
                    dto.CollectTime = dr.Cells["CollectTime"].Value.ToString();
                    dto.SampleWeight = Convert.ToInt32(dr.Cells["SampleWeight"].Value.ToString());

                    this._bizOffGasSum._arr.Add(dto);
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
                foreach (ParaDto dto in this._bizOffGasSum._arr)
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
            this.BtnCloseClickedEvent();
        }

        /// <summary>
        /// 确定按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSum_Click(object sender, EventArgs e)
        {
            //设置焦点,必要
            this.lblChoose.Focus();

            //保存到列表
            this.SavePickupToArr();
            
            if (!this.CheckValid())
            {
                return;
            }

            //通过样品装载分析结果
            if (!this._bizOffGasSum.LoadResultByArr())
            {
                return;
            }

            //通知其它视图刷新
            OffSumBtnClickArgs eve = new OffSumBtnClickArgs(this._bizOffGasSum._arr, this._bizOffGasSum._dsResult);
            if (SumClicked != null)
            {
                this.SumClicked(this, eve);
            }
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
