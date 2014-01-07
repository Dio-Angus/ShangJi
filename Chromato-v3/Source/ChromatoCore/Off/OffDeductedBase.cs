/*-----------------------------------------------------------------------------
//  FILE NAME       : OffDeductedBase.cs
//  FUNCTION        : 基线扣除控件
//  AUTHOR          : 李锋(2010/06/08)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using ChromatoTool.ini;
using ChromatoBll.bll;
using ChromatoTool.dto;
using System.Collections;

namespace ChromatoCore.Off
{
    /// <summary>
    /// 基线扣除控件
    /// </summary>
    public partial class OffDeductedBase : UserControl
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
        /// 选中样品
        /// </summary>
        private ParaDto _dtoPara = null;

        /// <summary>
        /// 样品数据队列
        /// </summary>
        private ArrayList _arr = null;

        /// <summary>
        /// 原始数据逻辑
        /// </summary>
        private OriginPointBiz _bizOri = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OffDeductedBase()
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
            this._dtoPara = new ParaDto();
            this._bizOri = new OriginPointBiz();
            this._arr = new ArrayList();

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
            this.dgvSampleInfo.CellContentClick += new DataGridViewCellEventHandler(this.dgvSampleInfo_CellContentClick);
            this.dgvSampleInfo.CellContentDoubleClick += new DataGridViewCellEventHandler(this.dgvSampleInfo_CellContentClick);

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
        private void ClearOtherCheck()
        {

            bool bIsPickup = false;
            String temp = null;
            ParaDto dto = new ParaDto();


            foreach (DataGridViewRow dr in this.dgvSampleInfo.Rows)
            {
                temp = dr.Cells["IsPickup"].EditedFormattedValue.ToString();
                dto.SampleID = dr.Cells["SampleID"].Value.ToString();
                dto.RegisterTime = dr.Cells["RegisterTime"].Value.ToString();
                dto.ChannelID = dr.Cells["ChannelID"].Value.ToString();

                if (String.IsNullOrEmpty(temp))
                {
                    continue;
                }

                if (dto.SampleID.Equals(this._dtoPara.SampleID) &&
                    dto.RegisterTime.Equals(this._dtoPara.RegisterTime) &&
                    dto.ChannelID.Equals(this._dtoPara.ChannelID))
                {
                    continue;
                }


                bIsPickup = Convert.ToBoolean(temp);
                if (bIsPickup)
                {
                    dr.Cells["IsPickup"].Value = false;
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
                if(null != this._dtoPara.SampleID && this._dtoPara.SampleID.Equals(sampleID) )
                {
                    //选中
                    this.dgvSampleInfo["SampleName", i].Selected = true;
                }
            }
        }

        /// <summary>
        /// 更新选中的样品
        /// </summary>
        private void UpdateDto()
        {
            DataGridViewRow cRow = this.dgvSampleInfo.CurrentRow;

            this._dtoPara.SampleID = cRow.Cells["SampleID"].Value.ToString();
            this._dtoPara.ChannelID = cRow.Cells["ChannelID"].Value.ToString();
            this._dtoPara.PathData = cRow.Cells["PathData"].Value.ToString();
            this._dtoPara.SampleName = cRow.Cells["SampleName"].Value.ToString();
            this._dtoPara.RegisterTime = cRow.Cells["RegisterTime"].Value.ToString();
            this._dtoPara.CollectTime = cRow.Cells["CollectTime"].Value.ToString();
            this._dtoPara.SampleWeight = Convert.ToInt32(cRow.Cells["SampleWeight"].Value.ToString());
        }

        /// <summary>
        /// 重新从数据库装载扣除基线的原始数据
        /// </summary>
        public ArrayList LoadOriForDeducted()
        {
            if (null == this._dtoPara || String.IsNullOrEmpty(this._dtoPara.PathData))
            {
                return null;
            }
            if (!this.CheckIsPickup())
            {
                return null;
            }
            //从数据库提取数据
            OpenDbResult dbResult = this._bizOri.OpenDb(this._dtoPara.PathData, this._arr);
            return this._arr;

        }

        /// <summary>
        /// 检查是否选中
        /// </summary>
        /// <returns></returns>
        private bool CheckIsPickup()
        {
            String temp = null;

            foreach (DataGridViewRow dr in this.dgvSampleInfo.Rows)
            {
                temp = dr.Cells["IsPickup"].EditedFormattedValue.ToString();

                if (String.IsNullOrEmpty(temp))
                {
                    continue;
                }

                if (Convert.ToBoolean(temp))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion


        #region 事件

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
        /// 单击视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 <= e.RowIndex && 15 == e.ColumnIndex)
            {
                this.UpdateDto();
                this.ClearOtherCheck();
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
