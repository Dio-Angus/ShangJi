/*-----------------------------------------------------------------------------
//  FILE NAME       : TimeProcViewer.cs
//  FUNCTION        : 时间程序视图
//  AUTHOR          : 李锋(2009/06/12)
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
using ChromatoBll.bll;
using ChromatoTool.util;

namespace ChromatoCore.solu.Tp
{
    /// <summary>
    /// 时间程序视图
    /// </summary>
    public partial class TimeProcViewer : UserControl
    {

        #region 常量

        /// <summary>
        /// 停止时间最大值
        /// </summary>
        private const int MaxValue = 999;

        #endregion


        #region 变量

        /// <summary>
        /// 访问方法
        /// </summary>
        public AccessMethod _accessM = AccessMethod.New;

        /// <summary>
        /// 方案dto
        /// </summary>
        private SolutionDto _dto = null;

        /// <summary>
        /// 时间程序逻辑
        /// </summary>
        private TimeProcBiz _bizTimeProc = null;

        /// <summary>
        /// 时间程序dto
        /// </summary>
        private TimeProcDto _dtoTimeProc = null;

        /// <summary>
        /// 是否第一次装载
        /// </summary>
        private bool _isFirst = true;

        /// <summary>
        /// 时间程序数据集合
        /// </summary>
        private DataSet _dsTimeProc = null;

        /// <summary>
        /// 针对ComboBox类型控件设置的是否已经完成初始化
        /// </summary>
        private bool _isLoadUi = false;

        /// <summary>
        /// 浏览复制,注册编辑标志
        /// </summary>
        private bool _isNeedLoadAll = false;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public TimeProcViewer(AccessMethod am)
        {
            InitializeComponent();
            this._accessM = am;
            this._bizTimeProc = new TimeProcBiz();
            this._dtoTimeProc = new TimeProcDto();

            this.LoadEvent();

            this.dgvTimeProc.BackgroundColor = Color.FromArgb(General.DgvBackColor);

        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.dgvTimeProc.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvTimeProc_CellDoubleClick);
            this.dgvTimeProc.CellClick += new DataGridViewCellEventHandler(this.dgvTimeProc_CellDoubleClick);
            this.dgvTimeProc.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvTimeProc_ColumnHeaderMouseClick);
            this.dgvTimeProc.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvTimeProc_DataBindingComplete);
            this.dgvTimeProc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvTimeProc_KeyUp);

            this.txtStartTime.TextChanged += new System.EventHandler(this.txtStartTime_TextChanged);
            this.txtStopTime.TextChanged += new System.EventHandler(this.txtStopTime_TextChanged);
            this.txtTpName.TextChanged += new System.EventHandler(this.txtTpName_TextChanged);
            this.txtCmdValue.TextChanged += new System.EventHandler(this.txtCmdValue_TextChanged);

            this.rbStatusOn.CheckedChanged += new System.EventHandler(this.rbStatusOn_CheckedChanged);
            this.rbStatusOff.CheckedChanged += new System.EventHandler(this.rbStatusOff_CheckedChanged);

            this.cbxMaxStopTime.CheckedChanged += new System.EventHandler(this.cbxMaxStopTime_CheckedChanged);

        }

        #endregion


        #region 方法

        /// <summary>
        /// 复位，清除标志，用户选择的时间程序方法改变
        /// </summary>
        public void Reset(int tpID)
        {
            this.LoadView(tpID);
            this._isFirst = false;
        }

        /// <summary>
        /// 显示时间程序的详细信息
        /// </summary>
        /// <param name="dto"></param>
        public void LoadUi(SolutionDto dto)
        {
            this._dto = dto;
            this.gbTimeProc.Enabled = (null == this._dto) ? false : true;
            if (null == this._dto)
            {
                return;
            }

            switch (this._accessM)
            {
                case AccessMethod.View:
                    this.LoadView(this._dto.TimeProcID);
                    break;

                case AccessMethod.New:
                    if (this._isFirst)
                    {
                        this.LoadNew();
                        this._isFirst = false;
                    }
                    break;

                case AccessMethod.Edit:
                    if (this._isFirst)
                    {
                        this.LoadEdit();
                        this._isFirst = false;
                    }
                    break;

                case AccessMethod.SaveAs:
                    if (this._isFirst)
                    {
                        this.LoadView(this._dto.TimeProcID);
                        this._isFirst = false;
                    }
                    break;
            }
        }

        /// <summary>
        /// 显示时间程序的信息
        /// </summary>
        private void LoadView(int tpID)
        {
            this._dtoTimeProc.TPid = tpID;

            //查询时间程序的具体内容
            DataSet ds = this._bizTimeProc.LoadTimeProcByID(this._dtoTimeProc);

            if (null != ds && null != ds.Tables[0] && 0 < ds.Tables[0].Rows.Count)
            {
                this._dtoTimeProc.TPName = ds.Tables[0].Rows[0]["TPName"].ToString();
                this.txtTpName.Text = this._dtoTimeProc.TPName;
            }

            this._isNeedLoadAll = false;
            this.LoadViewOrSaveAs(ds);
        }

        /// <summary>
        /// 查看或者复制
        /// </summary>
        private void LoadViewOrSaveAs(DataSet ds)
        {

            if (null != ds && null != ds.Tables[0] && 0 < ds.Tables[0].Rows.Count)
            {

                this._dsTimeProc = ds;
                this.dgvTimeProc.DataSource = this._dsTimeProc.Tables[0];

                //开始时设定选中首行
                this.dgvTimeProc.CurrentCell = this.dgvTimeProc.Rows[0].Cells["ActionName"];

                this.UpdateDetail();
            }
            else
            {
                //一条数据都没有的时候
                this.LoadControlStyle(true);

                this.rbStatusOn.Enabled = false;
                this.rbStatusOff.Enabled = false;
            }
        }

        /// <summary>
        /// 装载控件的风格
        /// </summary>
        /// <param name="isReadOnly"></param>
        private void LoadControlStyle(bool isReadOnly)
        {

            this.txtStartTime.ReadOnly = isReadOnly;
            this.txtStopTime.ReadOnly = isReadOnly;
            this.txtCmdValue.ReadOnly = isReadOnly;
            this.txtTpName.ReadOnly = isReadOnly;

            this.txtStartTime.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtStopTime.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtCmdValue.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTpName.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.cmbTimeProc.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.btnAdd.Visible = !isReadOnly;
            this.btnModify.Visible = !isReadOnly;
            this.btnDelete.Visible = !isReadOnly;
        }

        /// <summary>
        /// 装载下拉式列表框
        /// </summary>
        private void LoadCmbTimeProc()
        {
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.PeakWide));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.Slope));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.Drift));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.MinSize));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.ChangeParaTime));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.TimeLock));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.LockBaseline));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.RevertPeak));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.HoriBaseline));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.DealTailPeak));


            this.cmbTimeProc.Text = this._dtoTimeProc.ActionName;
        }

        /// <summary>
        /// 新建时间程序的信息
        /// </summary>
        private void LoadNew()
        {
            this.LoadControlStyle(false);

            this.LoadCmbTimeProc();
            this._isNeedLoadAll = true;

            this._isLoadUi = true;

            this.cmbTimeProc.SelectedIndex = 0;
            this.txtTpName.Text = "新建时间程序";
            this.txtStartTime.Text = "1";
            this.txtStopTime.Text = "2";

            this.txtCmdValue.Enabled = true;
            this.txtCmdValue.ReadOnly = false;
            this.txtCmdValue.BackColor = Color.White;
            this.txtCmdValue.Text = "5";

            this.rbStatusOn.Enabled = false;
            this.rbStatusOff.Enabled = false;

            this.lblValue.Text = "命令值";

            this._dtoTimeProc.IsCmd = true;
            this._dtoTimeProc.SerialID = 1;
            this._dtoTimeProc.StartTime = Convert.ToSingle(this.txtStartTime.Text);
            this._dtoTimeProc.StopTime = Convert.ToSingle(this.txtStopTime.Text);
            this._dtoTimeProc.TPName = this.txtTpName.Text;
            this._dtoTimeProc.TpValue = Convert.ToInt32(this.txtCmdValue.Text);

            //队列和界面加入缺省的一条时间程序
            this.btnAdd_Click(null, null);
        }

        /// <summary>
        /// 编辑当前方案的信息
        /// </summary>
        private void LoadEdit()
        {
            this._dtoTimeProc.TPid = this._dto.TimeProcID;
            this._isNeedLoadAll = true;

            //查询时间程序的具体内容
            DataSet ds = this._bizTimeProc.LoadTimeProcByID(this._dtoTimeProc);

            if (null != ds && null != ds.Tables[0] && 0 < ds.Tables[0].Rows.Count)
            {
                this._dtoTimeProc.TPName = ds.Tables[0].Rows[0]["TPName"].ToString();
                this.txtTpName.Text = this._dtoTimeProc.TPName;
            }

            if (null != ds && null != ds.Tables[0] && 0 < ds.Tables[0].Rows.Count)
            {

                this._dsTimeProc = ds;
                this.dgvTimeProc.DataSource = this._dsTimeProc.Tables[0];

                //开始时设定选中首行
                this.dgvTimeProc.CurrentCell = this.dgvTimeProc.Rows[0].Cells["ActionName"];

                this.UpdateDetail();
            }
            else
            {
                this.LoadControlStyle(false);
            }
        }

        /// <summary>
        /// 从下拉列表中选择命令名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private int FindNameInCmb(string name)
        {
            int index = -1;
            String an = "";
            for (int i = 0; i < this.cmbTimeProc.Items.Count; i++ )
            {
                an = this.cmbTimeProc.Items[i].ToString();
                if (an.Equals(name))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        /// <summary>
        /// 设置行高
        /// </summary>
        private void SetDgvCellHeight()
        {
            this.dgvTimeProc.AllowUserToResizeRows = false;
            foreach (DataGridViewRow a in this.dgvTimeProc.Rows)
            {
                a.Height = 15;
            }
        }

        /// <summary>
        /// 显示分析方法的信息
        /// </summary>
        private void LoadSaveAs()
        {
            this._dtoTimeProc.TPid = this._dto.TimeProcID;

            //查询时间程序的具体内容
            DataSet ds = this._bizTimeProc.LoadTimeProcByID(this._dtoTimeProc);

            if (null != ds && null != ds.Tables[0])
            {
                this._dtoTimeProc.TPName = ds.Tables[0].Rows[0]["TPName"].ToString();
                this.txtTpName.Text = this._dtoTimeProc.TPName + DateTime.Now.ToString("_yyyyMMdd");
            }
            this.LoadViewOrSaveAs(ds);
        }
        
        /// <summary>
        /// 插入分析方法
        /// </summary>
        public void SaveNew(SolutionDto dto)
        {

            if (0 == dto.TimeProcID)
            {
                this._bizTimeProc.InsertArray();
                dto.TimeProcID = this._dtoTimeProc.TPid;
            }
        }

        /// <summary>
        /// 更新采集方法
        /// </summary>
        public void SaveEdit()
        {
            this._bizTimeProc.UpdateMethod(this._dtoTimeProc);
        }

        /// <summary>
        /// 更新选中行
        /// </summary>
        private void UpdateSelectedRow()
        {
            if (null == this.dgvTimeProc.CurrentRow)
            {
                MessageBox.Show("没有选中时间程序！", "警告");
                return;
            }

            int serialID = 0;
            for (int i = 0; i < this._dsTimeProc.Tables[0].Rows.Count; i++)
            {
                serialID = Convert.ToInt32(this.dgvTimeProc["SerialID", i].Value.ToString());
                if (serialID == this._dtoTimeProc.SerialID)
                {
                    // clear datagridview selection
                    this.dgvTimeProc.ClearSelection();
                    // select new row
                    this.dgvTimeProc["SerialID", i].Selected = true;
                    break;
                }
            }
        }

        /// <summary>
        /// 通过事件发送dto
        /// </summary>
        private void UpdateDetail()
        {
            DataGridViewRow cRow = this.dgvTimeProc.CurrentRow;

            this._dtoTimeProc.TPid = Convert.ToInt32(cRow.Cells["TPid"].Value.ToString());
            this._dtoTimeProc.TPName = cRow.Cells["TPName"].Value.ToString();
            this._dtoTimeProc.SerialID = Convert.ToInt32(cRow.Cells["SerialID"].Value.ToString());
            this._dtoTimeProc.ActionName = cRow.Cells["ActionName"].Value.ToString();
            this._dtoTimeProc.StartTime = Convert.ToSingle(cRow.Cells["StartTime"].Value.ToString());
            this._dtoTimeProc.StopTime = Convert.ToSingle(cRow.Cells["StopTime"].Value.ToString());
            this._dtoTimeProc.IsCmd = Convert.ToBoolean(cRow.Cells["IsCmd"].Value.ToString());
            this._dtoTimeProc.TpValue = Convert.ToInt32(cRow.Cells["TpValue"].Value.ToString());

            this.txtStartTime.Text = this._dtoTimeProc.StartTime.ToString();
            this.txtStopTime.Text = this._dtoTimeProc.StopTime.ToString();


            // 浏览,复制状态
            if (!this._isNeedLoadAll)
            {
                this.cmbTimeProc.Items.Clear();
                this.cmbTimeProc.Items.Add(this._dtoTimeProc.ActionName);
                this.cmbTimeProc.SelectedIndex = 0;

                this.LoadControlStyle(true);

                if (this._dtoTimeProc.IsCmd)
                {
                    this.txtCmdValue.Text = this._dtoTimeProc.TpValue.ToString();
                    this.txtCmdValue.Enabled = true;
                    this.txtCmdValue.ReadOnly = true;

                    this.rbStatusOn.Enabled = false;
                    this.rbStatusOff.Enabled = false;

                    this.lblValue.Text = "命令值";
                }
                else
                {
                    this.txtCmdValue.Enabled = false;

                    if ((int)TpStatus.Open == this._dtoTimeProc.TpValue)
                    {
                        this.rbStatusOn.Checked = true;
                    }
                    else if ((int)TpStatus.Stop == this._dtoTimeProc.TpValue)
                    {
                        this.rbStatusOff.Checked = true;
                    }

                    this.rbStatusOn.Enabled = this.rbStatusOn.Checked;
                    this.rbStatusOff.Enabled = this.rbStatusOff.Checked;

                    this.lblValue.Text = "状态值";
                }
            }
            else //编辑状态
            {
                this.LoadControlStyle(false);

                if (this._dtoTimeProc.IsCmd)
                {
                    this.txtCmdValue.Text = this._dtoTimeProc.TpValue.ToString();
                    this.txtCmdValue.Enabled = true;
                    this.txtCmdValue.ReadOnly = false;
                    this.txtCmdValue.BackColor = Color.White;

                    this.rbStatusOn.Enabled = false;
                    this.rbStatusOff.Enabled = false;

                    this.lblValue.Text = "命令值";
                }
                else
                {
                    if ((int)TpStatus.Open == this._dtoTimeProc.TpValue)
                    {
                        this.rbStatusOn.Checked = true;
                    }
                    else if ((int)TpStatus.Stop == this._dtoTimeProc.TpValue)
                    {
                        this.rbStatusOff.Checked = true;
                    }

                    this.txtCmdValue.Enabled = false;
                    this.txtCmdValue.ReadOnly = true;
                    this.txtCmdValue.BackColor = Color.Beige;

                    this.rbStatusOn.Enabled = true;
                    this.rbStatusOff.Enabled = true;
                    this.lblValue.Text = "状态值";
                }

                this.cmbTimeProc.Items.Clear();
                this.LoadCmbTimeProc();
                this.cmbTimeProc.SelectedIndex = this.FindNameInCmb(this._dtoTimeProc.ActionName);
                this._isLoadUi = true;

            }
        }

        /// <summary>
        /// 输入的合法性检查
        /// </summary>
        /// <returns></returns>
        private bool CheckValid()
        {
            if (this._dtoTimeProc.IsCmd)
            {
                if (String.IsNullOrEmpty(this.txtCmdValue.Text))
                {
                    MessageBox.Show("没有输入命令值", "提示");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 插入方法
        /// </summary>
        private void InsertMark()
        {
            DataRow dr = null;
            if (null == this._dsTimeProc || null == this._dsTimeProc.Tables[0] || 0 == this._dsTimeProc.Tables[0].Rows.Count)
            {
                this._dsTimeProc = new DataSet();
                DataTable dt = this._dsTimeProc.Tables.Add("T_TimeProc");

                dt.Columns.Add("TPid");
                dt.Columns.Add("SerialID");
                dt.Columns.Add("TPName");
                dt.Columns.Add("ActionName");
                dt.Columns.Add("StartTime");
                dt.Columns.Add("StopTime");
                dt.Columns.Add("TpValue");
                dt.Columns.Add("IsCmd");

                dr = this._dsTimeProc.Tables[0].NewRow();

                this._dtoTimeProc.TPid = this._bizTimeProc.GetNewTimeProcID();
                dr["TPid"] = this._dtoTimeProc.TPid;
                dr["SerialID"] = this._dtoTimeProc.SerialID;
                dr["TPName"] = this._dtoTimeProc.TPName;
                dr["ActionName"] = this._dtoTimeProc.ActionName;
                dr["StartTime"] = this._dtoTimeProc.StartTime.ToString();
                dr["StopTime"] = this._dtoTimeProc.StopTime.ToString();
                dr["TpValue"] = this._dtoTimeProc.TpValue.ToString();
                dr["IsCmd"] = this._dtoTimeProc.IsCmd;

                this.dgvTimeProc.DataSource = dt;
                //this.dgvTimeProc.DataBind();

                this._dsTimeProc.Tables[0].Rows.Add(dr);
                this.dgvTimeProc.CurrentCell = this.dgvTimeProc.Rows[this.dgvTimeProc.Rows.Count - 1].Cells["ActionName"];
            }
            else
            {
                dr = this._dsTimeProc.Tables[0].NewRow();
                this._dtoTimeProc.SerialID = this._bizTimeProc.GetNewSerialIdInArray(this._dtoTimeProc);

                dr["TPid"] = this._dtoTimeProc.TPid;
                dr["SerialID"] = this._dtoTimeProc.SerialID;
                dr["TPName"] = this._dtoTimeProc.TPName;
                dr["ActionName"] = this._dtoTimeProc.ActionName;
                dr["StartTime"] = this._dtoTimeProc.StartTime.ToString();
                dr["StopTime"] = this._dtoTimeProc.StopTime.ToString();
                dr["TpValue"] = this._dtoTimeProc.TpValue.ToString();
                dr["IsCmd"] = this._dtoTimeProc.IsCmd;

                this._dsTimeProc.Tables[0].Rows.Add(dr);
                this.dgvTimeProc.CurrentCell = this.dgvTimeProc.Rows[this.dgvTimeProc.Rows.Count - 1].Cells["ActionName"];

            }
        }

        /// <summary>
        /// 更新方法数据
        /// </summary>
        public void UpdateMark()
        {
            foreach (DataGridViewRow a in this.dgvTimeProc.Rows)
            {
                int serialId = Convert.ToInt32(a.Cells["SerialID"].Value.ToString());
                if (serialId == this._dtoTimeProc.SerialID)
                {
                    a.Cells["TPName"].Value = this._dtoTimeProc.TPName;
                    a.Cells["ActionName"].Value = this._dtoTimeProc.ActionName;
                    a.Cells["StartTime"].Value = this._dtoTimeProc.StartTime.ToString();
                    a.Cells["StopTime"].Value = this._dtoTimeProc.StopTime.ToString();
                    a.Cells["TpValue"].Value = this._dtoTimeProc.TpValue.ToString();
                    a.Cells["IsCmd"].Value = this._dtoTimeProc.IsCmd;
                    break;
                }
            }
        }

        /// <summary>
        /// 检查是否存在新项
        /// </summary>
        /// <returns></returns>
        public bool CheckNewValid()
        {
            if (0 == this.dgvTimeProc.Rows.Count)
            {
                MessageBox.Show("新建时间程序至少要包含一项!", "提示");
                return false;
            }
            return true;
        }

        #endregion


        #region 事件

        /// <summary>
        /// 标题栏按下的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTimeProc_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.UpdateSelectedRow();
        }

        /// <summary>
        /// 单击,双击单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTimeProc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex)
            {
                return;
            }
            this.UpdateDetail();
        }

        /// <summary>
        /// 设定单元格背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTimeProc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvTimeProc.DefaultCellStyle.BackColor = Color.FromArgb(General.DgvBackColor);
            this.SetDgvCellHeight();
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTimeProc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                this.UpdateDetail();
            }
        }

        /// <summary>
        /// 更新某项时间程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (null == this._dsTimeProc || null == this._dsTimeProc.Tables[0] ||
                0 == this._dsTimeProc.Tables[0].Rows.Count)
            {
                MessageBox.Show("没有时间程序项", "提示");
                return;
            }

            switch ((TimeProcType)this.cmbTimeProc.SelectedIndex)
            {
                case TimeProcType.PeakWide:
                case TimeProcType.Slope:
                case TimeProcType.Drift:
                case TimeProcType.MinSize:
                    if (!this.CheckValid())
                    {
                        return;
                    }
                    break;

                case TimeProcType.ChangeParaTime:
                case TimeProcType.TimeLock:
                case TimeProcType.LockBaseline:
                case TimeProcType.HoriBaseline:
                case TimeProcType.RevertPeak:
                case TimeProcType.DealTailPeak:
                    break;

            }

            this.UpdateMark();
            this._bizTimeProc.UpdateArray(this._dtoTimeProc);
        }

        /// <summary>
        /// 删除某项时间程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (null == this._dsTimeProc || null == this._dsTimeProc.Tables[0] ||
            //    0 == this._dsTimeProc.Tables[0].Rows.Count)
            //{
            //    MessageBox.Show("没有时间程序项", "提示");
            //    return;
            //}

            if (null == this.dgvTimeProc.CurrentRow)
            {
                MessageBox.Show("没有选中时间程序项目！", "提示");
                return;
            }

            //if (1 >= this._dsTimeProc.Tables[0].Rows.Count)
            if (1 >= this.dgvTimeProc.RowCount)
            {
                MessageBox.Show("时间程序至少包含一项！", "提示");
                return;
            }

            this.dgvTimeProc.Rows.RemoveAt(this.dgvTimeProc.CurrentRow.Index);
            this._bizTimeProc.RemoveSerial(this._dtoTimeProc);
            if (0 < this.dgvTimeProc.Rows.Count)
            {
                //开始时设定选中首行
                this.dgvTimeProc.CurrentCell = this.dgvTimeProc.Rows[0].Cells["ActionName"];
                this.UpdateDetail();
            }
        }

        /// <summary>
        /// 添加某项时间程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch ((TimeProcType)this.cmbTimeProc.SelectedIndex)
            {
                case TimeProcType.PeakWide:
                case TimeProcType.Slope:
                case TimeProcType.Drift:
                case TimeProcType.MinSize:
                    if (!this.CheckValid())
                    {
                        return;
                    }
                    break;

                case TimeProcType.ChangeParaTime:
                case TimeProcType.TimeLock:
                case TimeProcType.LockBaseline:
                case TimeProcType.HoriBaseline:
                case TimeProcType.RevertPeak:
                case TimeProcType.DealTailPeak:
                    break;

            }

            this.InsertMark();
            this._bizTimeProc.InsertToArray(this._dtoTimeProc);
        }

        /// <summary>
        /// 时间程序命令变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTimeProc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._isLoadUi)
            {
                return;
            }

            switch ((TimeProcType)this.cmbTimeProc.SelectedIndex)
            {
                case TimeProcType.PeakWide:
                case TimeProcType.Slope:
                case TimeProcType.Drift:
                case TimeProcType.MinSize:

                    this.txtStopTime.Enabled = true;
                    this.txtStopTime.BackColor = Color.White;

                    this.txtCmdValue.Enabled = true;
                    this.txtCmdValue.BackColor = Color.White;
                    this.txtCmdValue.ReadOnly = false;

                    this.rbStatusOn.Enabled = false;
                    this.rbStatusOff.Enabled = false;
                    this.lblValue.Text = "命令值";

                    this._dtoTimeProc.IsCmd = true;
                    break;

                case TimeProcType.ChangeParaTime:

                    this.txtStopTime.Enabled = false;
                    this.txtStopTime.BackColor = Color.Beige;
                    this.txtStopTime.Text = MaxValue.ToString();

                    this.txtCmdValue.Enabled = false;
                    this.txtCmdValue.BackColor = Color.Beige;
                    this.txtCmdValue.ReadOnly = true; 
                    
                    this.rbStatusOn.Enabled = false;
                    this.rbStatusOff.Enabled = false;
                    this.lblValue.Text = "命令值";
                    this._dtoTimeProc.IsCmd = true;
                    break;

                case TimeProcType.TimeLock:
                case TimeProcType.LockBaseline:
                case TimeProcType.HoriBaseline:
                case TimeProcType.RevertPeak:
                case TimeProcType.DealTailPeak:

                    this.txtStopTime.Enabled = true;
                    this.txtStopTime.BackColor = Color.White;

                    this.txtCmdValue.Enabled = false;
                    this.txtCmdValue.BackColor = Color.Beige;
                    this.txtCmdValue.ReadOnly = true;
                    this.txtCmdValue.Text = "";

                    this.rbStatusOn.Enabled = true;
                    this.rbStatusOff.Enabled = true;
                    this.lblValue.Text = "状态值";

                    this._dtoTimeProc.IsCmd = false;
                    break;
            }


            this._dtoTimeProc.ActionName = this.cmbTimeProc.Text;
        }

        /// <summary>
        /// 命令值焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCmdValue_TextChanged(object sender, EventArgs e)
        {
            switch ((TimeProcType)this.cmbTimeProc.SelectedIndex)
            {
                case TimeProcType.ChangeParaTime:
                case TimeProcType.TimeLock:
                case TimeProcType.LockBaseline:
                case TimeProcType.HoriBaseline:
                case TimeProcType.RevertPeak:
                case TimeProcType.DealTailPeak:
                    return;
            }

            if (!CastString.IsNumber(this.txtCmdValue.Text))
            {
                MessageBox.Show("命令值不是整数！", "取值");
                this.txtCmdValue.Focus();
                return;
            }
            this._dtoTimeProc.TpValue = Convert.ToInt32(this.txtCmdValue.Text);
        }

        /// <summary>
        /// 开始时间焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStartTime_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtStartTime.Text))
            {
                MessageBox.Show("开始时间不能为空！", "开始时间");
                this.txtStartTime.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtStartTime.Text))
            {
                MessageBox.Show("开始时间不是数值！", "开始时间");
                this.txtStartTime.Focus();
                return;
            }
            if (0 > Convert.ToSingle(this.txtStartTime.Text))
            {
                MessageBox.Show("开始时间不是正数！", "开始时间");
                this.txtStartTime.Focus();
                return;
            }
            if (999 < Convert.ToSingle(this.txtStartTime.Text))
            {
                MessageBox.Show("开始时间超过最大范围！", "开始时间");
                this.txtStartTime.Focus();
                return;
            }
            this._dtoTimeProc.StartTime = Convert.ToSingle(this.txtStartTime.Text);
        }

        /// <summary>
        /// 结束时间焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStopTime_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtStopTime.Text))
            {
                MessageBox.Show("结束时间不能为空！", "结束时间");
                this.txtStopTime.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtStopTime.Text))
            {
                MessageBox.Show("结束时间不是数值！", "结束时间");
                this.txtStopTime.Focus();
                return;
            }
            if (0 > Convert.ToSingle(this.txtStopTime.Text))
            {
                MessageBox.Show("结束时间不是正数！", "结束时间");
                this.txtStopTime.Focus();
                return;
            }
            if (999 < Convert.ToSingle(this.txtStopTime.Text))
            {
                MessageBox.Show("结束时间超过最大范围！", "结束时间");
                this.txtStartTime.Focus();
                return;
            }
            if (this._dtoTimeProc.StartTime >= Convert.ToSingle(this.txtStopTime.Text))
            {
                MessageBox.Show("结束时间小于开始时间！", "结束时间");
                this.txtStopTime.Focus();
                return;
            }
            this._dtoTimeProc.StopTime = Convert.ToSingle(this.txtStopTime.Text);
        }

        /// <summary>
        /// 时间程序方法名称焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTpName_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtTpName.Text))
            {
                MessageBox.Show("时间程序方法名称不能为空！", "时间程序方法名称");
                this.txtTpName.Focus();
                return;
            }
            this._dtoTimeProc.TPName = this.txtTpName.Text;
        }

        /// <summary>
        /// 打开按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbStatusOn_CheckedChanged(object sender, EventArgs e)
        {
            this._dtoTimeProc.TpValue = (int)TpStatus.Open;
        }

        /// <summary>
        /// 关闭按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbStatusOff_CheckedChanged(object sender, EventArgs e)
        {
            this._dtoTimeProc.TpValue = (int)TpStatus.Stop;
        }

        /// <summary>
        /// 停止时间设置最大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxMaxStopTime_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxMaxStopTime.Checked)
            {
                this.txtStopTime.Text = MaxValue.ToString();
                this._dtoTimeProc.StopTime = Convert.ToSingle(MaxValue);
                //this.txtStopTime.Enabled = false;
                //this.txtStopTime.BackColor = Color.Beige;
            }
        }

        #endregion






    }
}
