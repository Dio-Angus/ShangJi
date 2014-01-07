/*-----------------------------------------------------------------------------
//  FILE NAME       : StartUser.cs
//  FUNCTION        : 注册样品列表窗体
//  AUTHOR          : 李锋(2010/01/03)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using ChromatoTool.ini;
using ChromatoTool.dto;
using AutoChromatoBll.bll;
using AutoChromatoBll.inf;

namespace TestGas
{
    public partial class StartUser : UserControl
    {


        #region 变量

        /// <summary>
        /// 样品
        /// </summary>
        private RequestDto _dtoRequest = null;

        /// <summary>
        /// 列表数据集合
        /// </summary>
        private DataSet _dsRequest = null;

        /// <summary>
        /// 样品
        /// </summary>
        private ParaDto _dtoPara = null;

        /// <summary>
        /// 列表数据集合
        /// </summary>
        private DataSet _dsSample = null;

        /// <summary>
        /// 请求逻辑
        /// </summary>
        private RequestInf _infoRequest = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public StartUser()
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
            this.dgvSampleInfo.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvSampleInfo_CellDoubleClick);
            this.dgvSampleInfo.CellClick += new DataGridViewCellEventHandler(this.dgvSampleInfo_CellClick);
            this.dgvSampleInfo.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvSampleInfo_ColumnHeaderMouseClick);
            this.dgvSampleInfo.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvSampleInfo_DataBindingComplete);
            this.dgvSampleInfo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvSampleInfo_KeyUp);

            this.tsBtnRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
            this.tsBtnStart.Click += new System.EventHandler(this.btnStart_Click);
        }

        /// <summary>
        /// 装界面
        /// </summary>
        private void LoadUi()
        {
            this._infoRequest = new RequestInf();
            this._dtoRequest = new RequestDto();
            this._dtoPara = new ParaDto();

            this.LoadList();
            this.dgvSampleInfo.BackgroundColor = Color.FromArgb(General.DgvBackColor);
        }

        /// <summary>
        /// 装载列表
        /// </summary>
        private void LoadList()
        {

            DataSet ds = null;
            ds = this._infoRequest.LoadCanStartPara();

            //空检查
            if (null == ds || 0 == ds.Tables.Count || 0 == ds.Tables[0].Rows.Count)
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

            for (int i = 0; i < this._dsRequest.Tables[0].Rows.Count; i++)
            {
                if (this.dgvSampleInfo["realSamepleID", i].Value.ToString().Equals(this._dtoRequest.SampleID))
                {
                    // clear datagridview selection
                    this.dgvSampleInfo.ClearSelection();
                    // select new row
                    this.dgvSampleInfo["regSampleName", i].Selected = true;

                    break;
                }
            }
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
        /// 重新装载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsRefresh_Click(object sender, EventArgs e)
        {
            this.LoadList();
        }

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

            this.SendChangeEvent();
        }

        /// <summary>
        /// 通过事件发送dto
        /// </summary>
        private void SendChangeEvent()
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

            this._dtoRequest.regSampleName = this._dtoPara.SampleName;
            this._dtoRequest.SampleID = this._dtoPara.SampleID;
            this._dtoRequest.RegisterTime = this._dtoPara.RegisterTime;
            this._dtoRequest.Status = PutStatus.Start;

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

            this.SendChangeEvent();

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
                this.SendChangeEvent();
            }
        }

        /// <summary>
        /// 启动采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this._dtoRequest.SampleID))
            {
                return;
            }
            this._infoRequest.InsertRequest(this._dtoRequest);
        }

        #endregion

       
    }
}
