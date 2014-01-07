/*-----------------------------------------------------------------------------
//  FILE NAME       : SampleResultViewer.cs
//  FUNCTION        : 样品结果列表显示
//  AUTHOR          : 李锋(2009/06/02)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Windows.Forms;
using ChromatoBll.bll;
using ChromatoTool.dto;
using System.Data;
using System.Drawing;
using System;
using ChromatoTool.ini;

namespace ChromatoCore.sample
{
    /// <summary>
    /// 样品结果列表显示
    /// </summary>
    public partial class SampleResultViewer : UserControl
    {


        #region 变量

        /// <summary>
        /// 峰结果逻辑
        /// </summary>
        private PeakBiz _bizPeak = null;

        /// <summary>
        /// 结果集合
        /// </summary>
        private DataSet _dsResult = null;

        /// <summary>
        /// 当前峰dto
        /// </summary>
        private PeakDto _dtoPeak = null;

        #endregion 

       
        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SampleResultViewer()
        {
            InitializeComponent();

            this._bizPeak = new PeakBiz();
            this._dtoPeak = new PeakDto();
            this.dgvResult.BackgroundColor = Color.FromArgb(General.DgvBackColor);

            this.loadEvent();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void loadEvent()
        {
            this.dgvResult.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvResult_CellDoubleClick);
            this.dgvResult.CellClick += new DataGridViewCellEventHandler(this.dgvResult_CellDoubleClick);
            this.dgvResult.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvResult_DataBindingComplete);
            this.dgvResult.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvResult_ColumnHeaderMouseClick);
        }

        #endregion


        #region 方法

        /// <summary>
        /// 装载结果
        /// </summary>
        public DataSet LoadResult(ParaDto dto)
        {

            //取得结果，刷新列表
            DataSet ds = this._bizPeak.LoadResult(dto.PathData);
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                if (0 < this.dgvResult.Rows.Count)
                {
                    this._dsResult.Tables[0].Rows.Clear();
                    this.dgvResult.DataSource = this._dsResult.Tables[0];
                }
                return null;
            }

            this._dsResult = ds.Copy();
            this.SumDesity();

            this.dgvResult.DataSource = this._dsResult.Tables[0];
            this.UpdateDetail();

            return ds;

        }

        /// <summary>
        /// 计算浓度和
        /// </summary>
        private void SumDesity()
        {
            Double temp = 0;
            int maxPeakID = 0;
            int id = 0;

            for (int i = 0; i < this._dsResult.Tables[0].Rows.Count; i++)
            {
                temp += Convert.ToDouble(this._dsResult.Tables[0].Rows[i]["Density"].ToString());
                id = Convert.ToInt32(this._dsResult.Tables[0].Rows[i]["PeakID"].ToString());
                maxPeakID = (id > maxPeakID) ? id : maxPeakID;
            }

            DataRow dr = this._dsResult.Tables[0].NewRow();
            dr["Density"] = temp.ToString();
            dr["PeakID"] = (maxPeakID + 1).ToString();
            this._dsResult.Tables[0].Rows.Add(dr);

        }

        /// <summary>
        /// 设置行高
        /// </summary>
        private void SetDgvCellHeight()
        {
            this.dgvResult.AllowUserToResizeRows = false;
            foreach (DataGridViewRow a in this.dgvResult.Rows)
            {
                a.Height = 15;
            }
        }

        /// <summary>
        /// 更新选中行
        /// </summary>
        private void UpdateSelectedRow()
        {
            if (null == this.dgvResult.CurrentRow)
            {
                MessageBox.Show("没有选中时间程序！", "警告");
                return;
            }

            int peakID = 0;
            for (int i = 0; i < this._dsResult.Tables[0].Rows.Count; i++)
            {
                peakID = Convert.ToInt32(this.dgvResult["PeakID", i].Value.ToString());
                if (peakID == this._dtoPeak.PeakID)
                {
                    // clear datagridview selection
                    this.dgvResult.ClearSelection();
                    // select new row
                    this.dgvResult["PeakID", i].Selected = true;
                    break;
                }
            }
        }

        /// <summary>
        /// 通过事件发送dto
        /// </summary>
        private void UpdateDetail()
        {
            DataGridViewRow cRow = this.dgvResult.CurrentRow;

            this._dtoPeak.PeakID = Convert.ToInt32(cRow.Cells["PeakID"].Value.ToString());
        }

        #endregion


        #region 事件

        /// <summary>
        /// 设定单元格背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvResult_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvResult.DefaultCellStyle.BackColor = Color.White;

            this.dgvResult.Columns["PeakHeight"].DefaultCellStyle.Format = "0.0";
            this.dgvResult.Columns["AreaSize"].DefaultCellStyle.Format = "0.00";
            this.dgvResult.Columns["BaseK"].DefaultCellStyle.Format = "0.000000000";
            this.dgvResult.Columns["BaseB"].DefaultCellStyle.Format = "0.000000000";
            this.dgvResult.Columns["Density"].DefaultCellStyle.Format = "0.0000000";

            this.SetDgvCellHeight();
        }

        /// <summary>
        /// 标题栏按下的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvResult_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.UpdateSelectedRow();
        }


        /// <summary>
        /// 单击,双击单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex)
            {
                return;
            }
            this.UpdateDetail();
        }

        #endregion

    }
}
