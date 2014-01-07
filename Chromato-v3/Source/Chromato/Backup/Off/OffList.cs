/*-----------------------------------------------------------------------------
//  FILE NAME       : OffList.cs
//  FUNCTION        : 已完成采集样品列表窗体
//  AUTHOR          : 李锋(2009/03/19)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using ChromatoBll.bll;
using ChromatoTool.dto;
using ChromatoTool.ini;
using ChromatoCore.solu;

namespace ChromatoCore.Off
{

    /// <summary>
    /// 已完成采集样品列表窗体
    /// </summary>
    public partial class OffList : UserControl
    {


        #region 变量

        /// <summary>
        /// 样品改变事件代理
        /// </summary>
        public event EventHandler<OffSampleChangeArgs> SampleChanged;

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

        private SolutionDto _dtoSolution = null;


        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OffList()
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
            this.dgvSampleInfo.CellClick += new DataGridViewCellEventHandler(this.dgvSampleInfo_CellDoubleClick);
            this.dgvSampleInfo.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvSampleInfo_ColumnHeaderMouseClick);
            this.dgvSampleInfo.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvSampleInfo_DataBindingComplete);
            this.dgvSampleInfo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvSampleInfo_KeyUp);

            this.tsBtnRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
            this.tsBtnEditSlu.Click += new System.EventHandler(this.tsEditSlu_Click);

            this.cbxQuery.SelectedIndexChanged += new System.EventHandler(this.cbxQuery_SelectedIndexChanged);
        }

        /// <summary>
        /// 装界面
        /// </summary>
        private void LoadUi()
        {
            this._bizPara = new ParaBiz();
            this.cbxQuery.SelectedIndex = 3;
            this.dtPickerQuery.Enabled = true;
            this.dtPickerQueryEndDay.Enabled = false;

            this.LoadList();
            this.dgvSampleInfo.BackgroundColor = Color.FromArgb(General.DgvBackColor);
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
            if (null == ds || 0 == ds.Tables.Count || 0 == ds.Tables[0].Rows.Count)
            {
                if (0 < this.dgvSampleInfo.Rows.Count)
                {
                    this._dsSample.Tables[0].Rows.Clear();
                    this.dgvSampleInfo.DataSource = this._dsSample.Tables[0];
                }

                //发送空的dto
                this._dtoPara = null;
                OffSampleChangeArgs eve = new OffSampleChangeArgs(this._dtoPara);
                if (SampleChanged != null)
                {
                    this.SampleChanged(this, eve);
                }

                return;
            }

            this._dsSample = ds;
            this.dgvSampleInfo.DataSource = this._dsSample.Tables[0];
        }

        #endregion


        #region 方法

        /// <summary>
        /// 改变面板大小
        /// </summary>
        public void UserResize()
        {
            //this.dgvSampleInfo.Width = this.Width;
            //this.dgvSampleInfo.Height = this.Height - this.lblOffline.Height - 15;
        }

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

            OffSampleChangeArgs eve = new OffSampleChangeArgs(this._dtoPara);
            if (SampleChanged != null)
            {
                this.SampleChanged(this, eve);
            }
        }

        /// <summary>
        /// 重新装载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsRefresh_Click(object sender, EventArgs e)
        {
            this.OffList_Load(null, null);
        }

        /// <summary>
        /// 窗口显示初期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OffList_Load(object sender, EventArgs e)
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

            OffSampleChangeArgs eve = new OffSampleChangeArgs(this._dtoPara);
            if (SampleChanged != null)
            {
                this.SampleChanged(this, eve);
            }
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
            this.LoadList();
        }

        /// <summary>
        /// 编辑解决方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsEditSlu_Click(object sender, EventArgs e)
        {
            this._dtoSolution = new SolutionDto();
            DataSet tempDs;
            tempDs = new DataSet();
            tempDs = this._bizPara.getSolutionByPara(this._dtoPara);
            string sss = tempDs.Tables[0].Rows[0][0].ToString();
            if (tempDs.Tables[0].Rows.Count > 0)
            {
                this._dtoSolution.AnalyParaID = Convert.ToInt32(tempDs.Tables[0].Rows[0]["AnalyParaID"].ToString());
                this._dtoSolution.AntiMethodID = Convert.ToInt32(tempDs.Tables[0].Rows[0]["AntiMethodID"].ToString());
                this._dtoSolution.CollectionID = Convert.ToInt32(tempDs.Tables[0].Rows[0]["CollectionID"].ToString());
                this._dtoSolution.IDTableID = Convert.ToInt32(tempDs.Tables[0].Rows[0]["IDTableID"].ToString());
                this._dtoSolution.IsUseTimeProc = Convert.ToBoolean(tempDs.Tables[0].Rows[0]["IsUseTimeProc"].ToString());
                this._dtoSolution.RegisterTime = tempDs.Tables[0].Rows[0]["RegisterTime"].ToString();
                this._dtoSolution.Remark = tempDs.Tables[0].Rows[0]["Remark"].ToString();

                this._dtoSolution.SolutionID =  Convert.ToInt32( tempDs.Tables[0].Rows[0]["SolutionID"].ToString());
                this._dtoSolution.SolutionName = tempDs.Tables[0].Rows[0]["SolutionName"].ToString();
                this._dtoSolution.TimeProcID = Convert.ToInt32( tempDs.Tables[0].Rows[0]["TimeProcID"].ToString());
               




                SoluRegistryFrm soluForm = new SoluRegistryFrm(AccessMethod.Edit, this._dtoSolution, null);
                if (DialogResult.OK == soluForm.ShowDialog())
                {
                  //  this.RefreshList(soluForm._dtoSolution);
                }
            }
            else
                return; 

            
        }
        #endregion

    
    }
}
