/*-----------------------------------------------------------------------------
//  FILE NAME       : CompareColor.cs
//  FUNCTION        : 选中的比较列表
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
using System.Collections;

namespace ChromatoCore.Compare
{
    /// <summary>
    /// 选中的比较列表
    /// </summary>
    public partial class CompareColor : UserControl
    {


        #region 变量

        /// <summary>
        /// 样品颜色集合
        /// </summary>
        private DataSet _dsColorPara = null;

        /// <summary>
        /// 比较逻辑
        /// </summary>
        private CompareBiz _bizCompare = null;

        /// <summary>
        /// 颜色变更事件代理
        /// </summary>
        public event EventHandler<ChangeColorArgs> ColorChanged;

        /// <summary>
        ///移出事件代理
        /// </summary>
        public event EventHandler<ChangeColorArgs> ItemRemoved;

        /// <summary>
        /// 是否显示事件代理
        /// </summary>
        public event EventHandler<ChangeShowArgs> ShowChanged;

        /// <summary>
        /// 当前选中的样品事件代理
        /// </summary>
        public event EventHandler<CurrentSampleArgs> CurrentSample;


        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public CompareColor()
        {
            this.InitializeComponent();
            this.LoadEvent();
            this.LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._bizCompare = new CompareBiz();
            
            this._dsColorPara = this._bizCompare.LoadCompare();
            this.dgvSampleInfo.DataSource = this._dsColorPara.Tables[0];

            if (null == this._dsColorPara || null == this._dsColorPara.Tables[0] || 0 >= this._dsColorPara.Tables[0].Rows.Count)
            {
                return;
            }

            //更新选中行
            int count = this._dsColorPara.Tables[0].Rows.Count;
            DataRow cRow = this._dsColorPara.Tables[0].Rows[count-1];
            this.dgvSampleInfo.CurrentCell = this.dgvSampleInfo.Rows[count - 1].Cells["SampleName"];

            //this._dtoCompare.SampleID = cRow["SampleID"].ToString();
            //this._dtoCompare.ForeColor = Convert.ToInt32(cRow["ForeColor"].ToString());
            this.dgvSampleInfo.BackgroundColor = Color.FromArgb(General.DgvBackColor);
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.dgvSampleInfo.CellContentClick += new DataGridViewCellEventHandler(this.dgvSampleInfo_CellContentClick);
            this.dgvSampleInfo.CellContentDoubleClick += new DataGridViewCellEventHandler(this.dgvSampleInfo_CellContentClick);
            this.dgvSampleInfo.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvSampleInfo_ColumnHeaderMouseClick);
            this.dgvSampleInfo.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvSampleInfo_DataBindingComplete);
            this.dgvSampleInfo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvSampleInfo_KeyUp);

            this.tsBtnDelete.Click += new System.EventHandler(this.tsBtnDelete_Click);
            this.tsBtnChooseColor.Click += new System.EventHandler(this.tsBtnChooseColor_Click);
        }

        #endregion


        #region 方法

        /// <summary>
        /// 追加到样品列表
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="dtoCompare"></param>
        /// <returns></returns>
        public bool LoadToList(ParaDto dto, ref CompareDto dtoCompare)
        {
            bool bRet = false;
            CompareDto dtoCom = new CompareDto();
            dtoCom.SampleID = dto.SampleID;
            dtoCom.SampleName = dto.SampleName;
            dtoCom.PathData = dto.PathData;
            dtoCom.IsShow = false;
            dtoCom.CollectTime = dto.CollectTime;

            if (this._bizCompare.InsertToArr(dtoCom))
            {
                this.InsertToDs(dtoCom);
                dtoCompare = dtoCom;
                bRet = true;
            }
            else
            {
                MessageBox.Show(string.Format("{0}，已经存在！", dtoCom.SampleName), "提示");
            }
            return bRet;
        }

        /// <summary>
        /// 插入
        /// </summary>
        private void InsertToDs(CompareDto dto)
        {
            DataRow dr = null;
            if (null == this._dsColorPara || null == this._dsColorPara.Tables[0] || 0 == this._dsColorPara.Tables[0].Rows.Count)
            {
                this._dsColorPara = new DataSet();
                DataTable dt = this._dsColorPara.Tables.Add("T_Compare");

                dt.Columns.Add("IsShow"); 
                dt.Columns.Add("SampleName");
                dt.Columns.Add("PathData"); 
                dt.Columns.Add("SampleID"); 
                dt.Columns.Add("ForeColor");
                dt.Columns.Add("CollectTime");

                dr = this._dsColorPara.Tables[0].NewRow();
                dr["IsShow"] = dto.IsShow;
                dr["SampleName"] = dto.SampleName;
                dr["PathData"] = dto.PathData; 
                dr["SampleID"] = dto.SampleID;
                dr["ForeColor"] = dto.ForeColor;
                dr["CollectTime"] = dto.CollectTime;

                this.dgvSampleInfo.DataSource = dt;

                this._dsColorPara.Tables[0].Rows.Add(dr);
                this.dgvSampleInfo.CurrentCell = this.dgvSampleInfo.Rows[this.dgvSampleInfo.Rows.Count - 1].Cells["SampleName"];
            }
            else
            {
                dr = this._dsColorPara.Tables[0].NewRow();
                dr["IsShow"] = dto.IsShow;
                dr["SampleName"] = dto.SampleName;
                dr["PathData"] = dto.PathData;
                dr["SampleID"] = dto.SampleID;
                dr["ForeColor"] = dto.ForeColor;
                dr["CollectTime"] = dto.CollectTime;

                this._dsColorPara.Tables[0].Rows.Add(dr);
                this.dgvSampleInfo.CurrentCell = this.dgvSampleInfo.Rows[this.dgvSampleInfo.Rows.Count - 1].Cells["SampleName"];
            }
        }

        /// <summary>
        /// 移出
        /// </summary>
        /// <param name="dto"></param>
        private void RemoveItem(CompareDto dto)
        {
            DataRow dr = null;
            String sampleID = "";
            String collectTime = "";

            for (int i = 0; i < this._dsColorPara.Tables[0].Rows.Count; i++)
            {
                dr = this._dsColorPara.Tables[0].Rows[i];
                sampleID = dr["SampleID"].ToString();
                collectTime = dr["CollectTime"].ToString();
                if (sampleID.Equals(dto.SampleID) && collectTime.Equals(dto.CollectTime))
                {
                    break;
                }
            }

            this._dsColorPara.Tables[0].Rows.Remove(dr);

            //this.dgvSampleInfo.DataSource = this._dsColorPara;
            if (0 < this.dgvSampleInfo.Rows.Count)
            {
                this.dgvSampleInfo.CurrentCell = this.dgvSampleInfo.Rows[0].Cells["SampleName"];
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
                a.Height = 20;
            }
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

            CompareDto dto = new CompareDto();
            this.UpdateDto(dto);

            String sampleID = "";
            String collectTime = "";
            for (int i = 0; i < this._dsColorPara.Tables[0].Rows.Count; i++)
            {
                sampleID = this.dgvSampleInfo["SampleID", i].Value.ToString();
                collectTime = this.dgvSampleInfo["CollectTime", i].Value.ToString(); 
                if (sampleID.Equals(dto.SampleID) && collectTime.Equals(dto.CollectTime))
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
        private void UpdateDto(CompareDto dto)
        {
            DataGridViewRow cRow = this.dgvSampleInfo.CurrentRow;

            dto.SampleID = cRow.Cells["sampleID"].Value.ToString();
            dto.CollectTime = cRow.Cells["CollectTime"].Value.ToString(); 
            dto.ForeColor = Convert.ToInt32(cRow.Cells["colForeColor"].Value.ToString());
            dto.SampleName = cRow.Cells["SampleName"].Value.ToString();
            dto.PathData = cRow.Cells["PathData"].Value.ToString();

            //判断是否勾中了
            String temp = cRow.Cells["IsShow"].Value.ToString();

            if (String.IsNullOrEmpty(temp))
            {
                return;
            }
            dto.IsShow = Convert.ToBoolean(temp);
        }

        /// <summary>
        /// 取得列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetCompareArr()
        {
            return this._bizCompare.GetCompareArr();
        }

        #endregion


        #region 事件

        /// <summary>
        /// 单击视图内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            CompareDto dto = new CompareDto();

            if (0 <= e.RowIndex)
            {
                this.UpdateDto(dto);

                //更新是否显示属性
                this._bizCompare.UpdateShow(dto);

                CurrentSampleArgs eve1 = new CurrentSampleArgs(dto);
                if (this.CurrentSample != null)
                {
                    this.CurrentSample(this, eve1);
                }
            }
            
            if (0 <= e.RowIndex && 0 == e.ColumnIndex)
            {
                //显示或不显示选中曲线
                ChangeShowArgs eve = new ChangeShowArgs(dto);
                if (this.ShowChanged != null)
                {
                    this.ShowChanged(this, eve);
                }
            }
            else if (0 <= e.RowIndex && 4 == e.ColumnIndex)
            {
                //改变选中曲线的颜色
                this.tsBtnChooseColor_Click(null, null);
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
                //this.UpdateDto();
            }
        }

        /// <summary>
        /// 移出新样品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (null == this.dgvSampleInfo.CurrentRow)
            {
                MessageBox.Show("没有选中！", "警告");
                return;
            }

            CompareDto dto = new CompareDto();
            this.UpdateDto(dto);

            this._bizCompare.DeleteCompare(dto);

            //移除曲线
            ChangeColorArgs eve = new ChangeColorArgs(dto);
            if (this.ItemRemoved != null)
            {
                this.ItemRemoved(this, eve);
            }

            //移出列表
            this.RemoveItem(dto);
        }

        /// <summary>
        /// 改变样品显示的曲线颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnChooseColor_Click(object sender, EventArgs e)
        {
            CompareDto dto = new CompareDto();
            this.UpdateDto(dto);

            this.colorDlgBK.Color = Color.FromArgb(dto.ForeColor);
            if (DialogResult.OK != this.colorDlgBK.ShowDialog())
            {
                return;
            }
            if (this.colorDlgBK.Color.ToArgb() == dto.ForeColor)
            {
                return;
            }
            dto.ForeColor = this.colorDlgBK.Color.ToArgb();


            DataGridViewRow cRow = this.dgvSampleInfo.CurrentRow;
            cRow.Cells["IsShow"].Value = dto.IsShow;
            cRow.Cells["colForeColor"].Value = dto.ForeColor;
            cRow.DefaultCellStyle.ForeColor = Color.FromArgb(dto.ForeColor);
            cRow.Cells["colForeColor"].Style.BackColor = Color.FromArgb(dto.ForeColor);
            cRow.Cells["colForeColor"].Selected = false;
            this._bizCompare.UpdateCompare(dto);

            ChangeColorArgs eve = new ChangeColorArgs(dto);
            if (ColorChanged != null)
            {
                this.ColorChanged(this, eve);
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
            this.dgvSampleInfo.DefaultCellStyle.BackColor = Color.Beige;
            this.SetDgvCellHeight();

            Int32 foreColor = 0;
            foreach (DataGridViewRow a in this.dgvSampleInfo.Rows)
            {
                foreColor = Convert.ToInt32(a.Cells["colForeColor"].Value.ToString());
                a.DefaultCellStyle.ForeColor = Color.FromArgb(foreColor);
                a.Cells["colForeColor"].Style.BackColor = Color.FromArgb(foreColor);

            }
        }

        #endregion
    
    }
}
