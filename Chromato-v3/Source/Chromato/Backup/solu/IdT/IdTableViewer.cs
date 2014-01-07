/*-----------------------------------------------------------------------------
//  FILE NAME       : IdTableViewer.cs
//  FUNCTION        : ID表视图
//  AUTHOR          : 李锋(2009/06/12)
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
using ChromatoTool.util;
using System.Collections;

namespace ChromatoCore.solu.IdT
{
    /// <summary>
    /// ID表视图
    /// </summary>
    public partial class IdTableViewer : UserControl
    {

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
        /// 成分表的逻辑
        /// </summary>
        private IngredientBiz _bizIngre = null;

        /// <summary>
        /// ID表dto
        /// </summary>
        private IngredientDto _dtoIngre = null;

        /// <summary>
        /// 是否第一次装载
        /// </summary>
        private bool _isFirst = true;

        /// <summary>
        /// Id表数据集合
        /// </summary>
        private DataSet _dsIngredient = null;

        /// <summary>
        /// 浏览复制,注册编辑标志
        /// </summary>
        private bool _isNeedLoadAll = false;

        /// <summary>
        /// 含量表数据集合
        /// </summary>
        private DataSet _dsCalibrate = null;

        /// <summary>
        /// 针对ComboBox类型控件设置的是否已经完成初始化
        /// </summary>
        private bool _isLoadUi = false;

        /// <summary>
        /// 含量表dto
        /// </summary>
        private CalibrateDto _dtoCalibrate = null;

        /// <summary>
        /// 含量表的逻辑
        /// </summary>
        private CalibrateBiz _bizCalibrate = null;

        /// <summary>
        /// 分析方法(只用到校正方法和定量参数)
        /// </summary>
        private AnalyParaDto _dtoAnalyPara = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="am"></param>
        public IdTableViewer(AccessMethod am)
        {
            InitializeComponent();
            this._accessM = am;

            this._bizIngre = new IngredientBiz();
            this._dtoIngre = new IngredientDto();

            this._bizCalibrate = new CalibrateBiz();
            this._dtoCalibrate = new CalibrateDto();
            this.LoadEvent();
            this.dgvCalibrate.BackgroundColor = Color.FromArgb(General.DgvBackColor);
            this.dgvIngredient.BackgroundColor = Color.FromArgb(General.DgvBackColor);

        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.cmbIngredient.SelectedIndexChanged += new System.EventHandler(this.cmbIngredient_SelectedIndexChanged);
            
            this.cbxInnerPeak.CheckedChanged += new System.EventHandler(this.cbxInnerPeak_CheckedChanged);

            this.dgvIngredient.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvIngredient_CellDoubleClick);
            this.dgvIngredient.CellClick += new DataGridViewCellEventHandler(this.dgvIngredient_CellDoubleClick);
            this.dgvIngredient.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvIngredient_ColumnHeaderMouseClick);
            this.dgvIngredient.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvIngredient_DataBindingComplete);
            this.dgvIngredient.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvIngredient_KeyUp);

            this.dgvCalibrate.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvCalibrate_CellDoubleClick);
            this.dgvCalibrate.CellClick += new DataGridViewCellEventHandler(this.dgvCalibrate_CellDoubleClick);
            this.dgvCalibrate.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvCalibrate_ColumnHeaderMouseClick);
            this.dgvCalibrate.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvCalibrate_DataBindingComplete);
            this.dgvCalibrate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvCalibrate_KeyUp);

            this.txtIdTableName.TextChanged += new System.EventHandler(this.txtIdTableName_TextChanged);
            this.txtReserverTime.TextChanged += new System.EventHandler(this.txtReserverTime_TextChanged);
            this.txtIngredientName.TextChanged += new System.EventHandler(this.txtIngredientName_TextChanged);
            this.txtTimeBand.TextChanged += new System.EventHandler(this.txtTimeBand_TextChanged);

            this.txtSampleWeight.TextChanged += new System.EventHandler(this.txtSampleWeight_TextChanged);
            this.txtDensity.TextChanged += new System.EventHandler(this.txtDensity_TextChanged);
            this.txtPeakSize.TextChanged += new System.EventHandler(this.txtPeakSize_TextChanged);
            this.txtPeakHeight.TextChanged += new System.EventHandler(this.txtPeakHeight_TextChanged);
            this.txtFactorOne.TextChanged += new System.EventHandler(this.txtFactorOne_TextChanged);
            this.txtFactorTwo.TextChanged += new System.EventHandler(this.txtFactorTwo_TextChanged);

            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            this.btnAddCali.Click += new System.EventHandler(this.btnAddCali_Click);
            this.btnAddIngre.Click += new System.EventHandler(this.btnAddIngre_Click);
            this.btnDeleteCali.Click += new System.EventHandler(this.btnDeleteCali_Click);
            this.btnDeleteIngre.Click += new System.EventHandler(this.btnDeleteIngre_Click);
            this.btnAutoBuild.Click += new System.EventHandler(this.btnAutoBuild_Click);
            this.btnReCacu.Click += new System.EventHandler(this.btnReCacu_Click);
            this.btnFixCurve.Click += new System.EventHandler(this.btnFixCurve_Click);
            this.btnClearTable.Click += new System.EventHandler(this.btnClearTable_Click);

        }

        #endregion


        #region 方法

        /// <summary>
        /// 复位，清除标志，用户选择的ID表方法改变
        /// </summary>
        public void Reset(int idTableID)
        {
            this.LoadView(idTableID);
            this._isFirst = false;
        }

        /// <summary>
        /// 显示ID表方法的详细信息
        /// </summary>
        /// <param name="dto"></param>
        public void LoadUi(SolutionDto dto)
        {
            this._dto = dto;
            this.gbIdTable.Enabled = (null == this._dto) ? false : true;
            if (null == this._dto)
            {
                return;
            }

            switch (this._accessM)
            {
                case AccessMethod.View:
                    this.LoadView(this._dto.IDTableID);
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
                        this.LoadCmbIngredient();
                        this._isFirst = false;
                    }
                    break;

                case AccessMethod.SaveAs:
                    if (this._isFirst)
                    {
                        this.LoadView(this._dto.IDTableID);
                        this._isFirst = false;
                    }
                    break;
            }
        }

        /// <summary>
        /// 显示ID表的信息
        /// </summary>
        private void LoadView(int idTableID)
        {

            this._dtoIngre.IDTableID = idTableID;

            //查询成分表的具体内容
            DataSet ds = this._bizIngre.LoadIngredientByID(this._dtoIngre.IDTableID);

            if (null != ds && null != ds.Tables[0] && 0 < ds.Tables[0].Rows.Count)
            {
                this._dtoIngre.IDTableName = ds.Tables[0].Rows[0]["IDTableName"].ToString();
                this.txtIdTableName.Text = this._dtoIngre.IDTableName;
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

                this._dsIngredient = ds;
                this.dgvIngredient.DataSource = this._dsIngredient.Tables[0];

                //开始时设定选中首行
                this.dgvIngredient.CurrentCell = this.dgvIngredient.Rows[0].Cells["ReserveTime"];

                //更新明细部分
                this.UpdateIngredientDetail();
            }
            else
            {
                //一条数据都没有的时候
                this.LoadControlStyle(true);
                this.cbxInnerPeak.Enabled = false;

            }

            this.cmbIngredient.Enabled = false;
        }

        /// <summary>
        /// 装载控件的风格
        /// </summary>
        /// <param name="isReadOnly"></param>
        private void LoadControlStyle(bool isReadOnly)
        {

            this.txtIdTableName.ReadOnly = isReadOnly;
            this.txtReserverTime.ReadOnly = isReadOnly;
            this.txtIngredientName.ReadOnly = isReadOnly;
            this.txtTimeBand.ReadOnly = isReadOnly;

            this.txtIdTableName.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtReserverTime.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtIngredientName.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTimeBand.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.txtSampleWeight.ReadOnly = isReadOnly;
            this.txtDensity.ReadOnly = isReadOnly;
            this.txtPeakHeight.ReadOnly = isReadOnly;
            this.txtPeakSize.ReadOnly = isReadOnly;
            this.txtFactorOne.ReadOnly = isReadOnly;
            this.txtFactorTwo.ReadOnly = isReadOnly;

            this.txtSampleWeight.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtDensity.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtPeakHeight.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtPeakSize.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtFactorOne.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtFactorTwo.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.btnAddCali.Visible = !isReadOnly;
            this.btnAddIngre.Visible = !isReadOnly;
            this.btnModify.Visible = !isReadOnly;
            this.btnDeleteCali.Visible = !isReadOnly;
            this.btnDeleteIngre.Visible = !isReadOnly;
            this.btnAutoBuild.Visible = !isReadOnly;
            this.btnReCacu.Visible = !isReadOnly;
            this.btnFixCurve.Visible = !isReadOnly;
            this.btnClearTable.Visible = !isReadOnly;
        }

        /// <summary>
        /// 新建立ID表的信息
        /// </summary>
        private void LoadNew()
        {
            this.LoadControlStyle(false);
            this.cbxInnerPeak.Enabled = true;

            this.txtIdTableName.Text = "新建ID表";
            this._dtoIngre.IDTableName = this.txtIdTableName.Text;

            this.txtIngredientName.Text = DefaultIdTable.IngredientName;
            this.txtReserverTime.Text = DefaultIdTable.ReserveTime.ToString();
            this.txtTimeBand.Text = DefaultIdTable.TimeBand.ToString();

            this._dtoIngre.IngredientID = 1;
            this._dtoIngre.IngredientName = this.txtIngredientName.Text;
            this._dtoIngre.ReserveTime = Convert.ToSingle(this.txtReserverTime.Text);
            this._dtoIngre.TimeBand = Convert.ToSingle(this.txtTimeBand.Text);
            this._dtoIngre.IsInnerPeak = false;

            this.txtSampleWeight.Text = DefaultIdTable.SampleWeight.ToString();
            this.txtDensity.Text = DefaultIdTable.Density.ToString();
            this.txtPeakHeight.Text = DefaultIdTable.PeakHeight.ToString();
            this.txtPeakSize.Text = DefaultIdTable.PeakSize.ToString();
            this.txtFactorOne.Text = DefaultIdTable.FactorOne.ToString();
            this.txtFactorTwo.Text = DefaultIdTable.FactorTwo.ToString();

            this._dtoCalibrate.CalibrateID = 1;
            this._dtoCalibrate.IngredientID = this._dtoIngre.IngredientID;
            this._dtoCalibrate.SampleWeight = Convert.ToInt32(this.txtSampleWeight.Text);
            this._dtoCalibrate.Density = Convert.ToSingle(this.txtDensity.Text);
            this._dtoCalibrate.PeakHeight = Convert.ToSingle(this.txtPeakHeight.Text);
            this._dtoCalibrate.PeakSize = Convert.ToSingle(this.txtPeakSize.Text);
            this._dtoCalibrate.FactorOne = Convert.ToSingle(this.txtFactorOne.Text);
            this._dtoCalibrate.FactorTwo = Convert.ToSingle(this.txtFactorTwo.Text);
            this._dtoCalibrate.SampleID = "notset";

            this._isNeedLoadAll = true;
            
            this.LoadCmbIngredient();

            this.btnAddIngre_Click(null, null);
        }

        /// <summary>
        /// 装载选择框
        /// </summary>
        private void LoadCmbIngredient()
        {
            DataSet ds = this._bizIngre.LoadMethodName();
            if (null != ds && null != ds.Tables[0] && 0 < ds.Tables[0].Rows.Count)
            {
                this.cmbIngredient.DataSource = ds.Tables[0];
                this.cmbIngredient.DisplayMember = "IDTableName";
                this.cmbIngredient.ValueMember = "IDTableID";
                this._isLoadUi = true;
            }
        }

        /// <summary>
        /// 编辑当前ID表的信息
        /// </summary>
        private void LoadEdit()
        {
            this._dtoIngre.IDTableID = this._dto.IDTableID;
            this._isNeedLoadAll = true;

            //查询ID表的具体内容
            DataSet ds = this._bizIngre.LoadIngredientByID(this._dtoIngre.IDTableID);

            //重新装载队列
            this._dtoCalibrate.IDTableID = this._dtoIngre.IDTableID;
            this._bizCalibrate.ResetArray(this._dtoIngre.IDTableID);

            //把数据集合连接到显示视图
            if (null != ds && null != ds.Tables[0] && 0 < ds.Tables[0].Rows.Count)
            {
                this._dtoIngre.IDTableName = ds.Tables[0].Rows[0]["IDTableName"].ToString();
                this.txtIdTableName.Text = this._dtoIngre.IDTableName;

                this._dsIngredient = ds;
                this.dgvIngredient.DataSource = this._dsIngredient.Tables[0];

                //开始时设定选中首行
                this.dgvIngredient.CurrentCell = this.dgvIngredient.Rows[0].Cells["ReserveTime"];

                this.UpdateIngredientDetail();
            }
            else
            {
                this.LoadControlStyle(false);
                this.cbxInnerPeak.Enabled = true;
            }
        }

        /// <summary>
        /// 设置行高
        /// </summary>
        private void SetDgvCellHeight(DataGridView dgv)
        {
            dgv.AllowUserToResizeRows = false;
            foreach (DataGridViewRow a in dgv.Rows)
            {
                a.Height = 18;
            }
        }

        /// <summary>
        /// 复制当前方案的信息
        /// </summary>
        private void LoadSaveAs()
        {
            this._dtoIngre.IDTableID = this._dto.IDTableID;

            //查询时间程序的具体内容
            DataSet ds = this._bizIngre.LoadIngredientByID(this._dtoIngre.IDTableID);

            if (null != ds && null != ds.Tables[0] && 0 < ds.Tables[0].Rows.Count)
            {
                this._dtoIngre.IDTableName = ds.Tables[0].Rows[0]["IDTableName"].ToString();
                this.txtIdTableName.Text = this._dtoIngre.IDTableName + DateTime.Now.ToString("_yyyyMMdd");
            }
            this.LoadViewOrSaveAs(ds);
        }

        /// <summary>
        /// 插入ID表方法
        /// </summary>
        public void SaveNew(SolutionDto dto)
        {
            if (0 == dto.IDTableID)
            {
                this._bizIngre.InsertArray();
                this._bizCalibrate.InsertArray();
                dto.IDTableID = this._dtoIngre.IDTableID;
            }
        }

        /// <summary>
        /// 更新ID表方法
        /// </summary>
        public void SaveEdit()
        {
            this._bizIngre.UpdateMethod(this._dtoIngre);
            this._bizCalibrate.UpdateMethod(this._dtoCalibrate);
        }

        /// <summary>
        /// 更新选中行
        /// </summary>
        private void UpdateIngredientSelectedRow()
        {
            if (null == this.dgvIngredient.CurrentRow)
            {
                MessageBox.Show("没有选中成分！", "警告");
                return;
            }

            int ingreID = 0;
            for (int i = 0; i < this._dsIngredient.Tables[0].Rows.Count; i++)
            {
                ingreID = Convert.ToInt32(this.dgvIngredient["IngredientID", i].Value.ToString());
                if (ingreID == this._dtoIngre.IngredientID)
                {
                    // clear datagridview selection
                    this.dgvIngredient.ClearSelection();
                    // select new row
                    this.dgvIngredient["IsInnerPeak", i].Selected = true;
                    break;
                }
            }
        }

        /// <summary>
        /// 更新选中行
        /// </summary>
        private void UpdateCalibrateSelectedRow()
        {
            if (null == this.dgvCalibrate.CurrentRow)
            {
                MessageBox.Show("没有选中含量！", "警告");
                return;
            }

            int caliID = 0;
            for (int i = 0; i < this._dsCalibrate.Tables[0].Rows.Count; i++)
            {
                caliID = Convert.ToInt32(this.dgvCalibrate["CalibrateID", i].Value.ToString());
                if (caliID == this._dtoCalibrate.CalibrateID)
                {
                    // clear datagridview selection
                    this.dgvCalibrate.ClearSelection();
                    // select new row
                    this.dgvCalibrate["SampleWeight", i].Selected = true;
                    break;
                }
            }
        }

        /// <summary>
        /// 通过事件发送dto
        /// </summary>
        private void UpdateIngredientDetail()
        {
            DataGridViewRow cRow = this.dgvIngredient.CurrentRow;

            if (null != cRow)
            {
                this._dtoIngre.IDTableID = Convert.ToInt32(cRow.Cells["IDTableID"].Value.ToString());
                this._dtoIngre.IDTableName = cRow.Cells["IDTableName"].Value.ToString();
                this._dtoIngre.IngredientID = Convert.ToInt32(cRow.Cells["IngredientID"].Value.ToString());
                this._dtoIngre.IngredientName = cRow.Cells["IngredientName"].Value.ToString();
                this._dtoIngre.IsInnerPeak = Convert.ToBoolean(cRow.Cells["IsInnerPeak"].Value.ToString());
                this._dtoIngre.ReserveTime = Convert.ToSingle(cRow.Cells["ReserveTime"].Value.ToString());
                this._dtoIngre.TimeBand = Convert.ToSingle(cRow.Cells["TimeBand"].Value.ToString());

                this.txtIdTableName.Text = this._dtoIngre.IDTableName;
                this.txtIngredientName.Text = this._dtoIngre.IngredientName;

                Decimal temp = Convert.ToDecimal(this._dtoIngre.ReserveTime);
                this.txtReserverTime.Text = temp.ToString();

                temp = Convert.ToDecimal(this._dtoIngre.TimeBand);
                this.txtTimeBand.Text = temp.ToString();

                this.LoadCalibrate();
            }

            this.cbxInnerPeak.Checked = this._dtoIngre.IsInnerPeak;

            // 浏览,复制状态
            if (!this._isNeedLoadAll)
            {
                this.LoadControlStyle(true);
                this.cbxInnerPeak.Enabled = false;
            }
            else //编辑状态
            {
                this.LoadControlStyle(false);
                this.cbxInnerPeak.Enabled = true;
            }
        }

        /// <summary>
        /// 装载含量视图
        /// </summary>
        private void LoadCalibrate()
        {
            DataSet ds = null;

            //查询含量表的具体内容
            if (this._isNeedLoadAll)
            {
                ds = this._bizCalibrate.LoadCalibrateInArrayById(this._dtoIngre);
            }
            else
            {
                ds = this._bizCalibrate.LoadCalibrateInDbById(this._dtoIngre);
            }
            if (null != ds && null != ds.Tables[0] && 0 < ds.Tables[0].Rows.Count)
            {
                this._dsCalibrate = ds;
                this.dgvCalibrate.DataSource = this._dsCalibrate.Tables[0];

                //开始时设定选中首行
                this.dgvCalibrate.CurrentCell = this.dgvCalibrate.Rows[0].Cells["Density"];
            }
            this.UpdateCalibrateDetail();
        }

        /// <summary>
        /// 更新含量视图的详细
        /// </summary>
        private void UpdateCalibrateDetail()
        {
            DataGridViewRow cRow = this.dgvCalibrate.CurrentRow;
            if (null != cRow)
            {
                this._dtoCalibrate.IDTableID = Convert.ToInt32(cRow.Cells["ID"].Value.ToString());
                this._dtoCalibrate.IngredientID = Convert.ToInt32(cRow.Cells["IngreID"].Value.ToString());
                this._dtoCalibrate.CalibrateID = Convert.ToInt32(cRow.Cells["CalibrateID"].Value.ToString());
                this._dtoCalibrate.Density = Convert.ToSingle(cRow.Cells["Density"].Value.ToString());
                this._dtoCalibrate.FactorOne = Convert.ToSingle(cRow.Cells["FactorOne"].Value.ToString());
                this._dtoCalibrate.FactorTwo = Convert.ToSingle(cRow.Cells["FactorTwo"].Value.ToString());
                this._dtoCalibrate.PeakHeight = Convert.ToSingle(cRow.Cells["PeakHeight"].Value.ToString());
                this._dtoCalibrate.PeakSize = Convert.ToSingle(cRow.Cells["PeakSize"].Value.ToString());
                this._dtoCalibrate.SampleWeight = Convert.ToInt32(cRow.Cells["SampleWeight"].Value.ToString());

                this.txtSampleWeight.Text = this._dtoCalibrate.SampleWeight.ToString();

                Decimal temp = Convert.ToDecimal(this._dtoCalibrate.Density);
                this.txtDensity.Text = temp.ToString();

                temp = Convert.ToDecimal(this._dtoCalibrate.PeakHeight);
                this.txtPeakHeight.Text = temp.ToString();

                temp = Convert.ToDecimal(this._dtoCalibrate.PeakSize);
                this.txtPeakSize.Text = temp.ToString();

                temp = Convert.ToDecimal(this._dtoCalibrate.FactorOne);
                this.txtFactorOne.Text = temp.ToString();

                temp = Convert.ToDecimal(this._dtoCalibrate.FactorTwo);
                this.txtFactorTwo.Text = temp.ToString();
            }
        }

        /// <summary>
        /// 插入方法
        /// </summary>
        private void InsertMark(IdTable idTable)
        {
            if (null == this._dsIngredient  || null == this._dsIngredient.Tables[0] 
                                            || 0 == this._dsIngredient.Tables[0].Rows.Count)
            {
                this.InitDataTable();

            }
            else
            {
                switch (idTable)
                {
                    case IdTable.Calibrate:
                        this.AddOneCaliInDgv();
                        break;
                    case IdTable.Ingredient:
                        this.AddOneIngreInDgv();
                        break;
                }
            }
        }

        /// <summary>
        /// 初期化数据表
        /// </summary>
        private void InitDataTable()
        {
            DataRow dr = null;
            DataTable dt = null;
            if (null == this._dsIngredient)
            {
                this._dsIngredient = new DataSet();
                dt = this._dsIngredient.Tables.Add("T_Ingredient");

                dt.Columns.Add("IDTableID");
                dt.Columns.Add("IDTableName");
                dt.Columns.Add("IngredientID");
                dt.Columns.Add("ReserveTime");
                dt.Columns.Add("IngredientName");
                dt.Columns.Add("TimeBand");
                dt.Columns.Add("IsInnerPeak");

                dr = dt.NewRow();
                this._dtoIngre.IDTableID = this._bizIngre.GetNewIdentityID();
            }
            else
            {
                this._dsIngredient.Tables[0].Rows.Clear();
                dt = this._dsIngredient.Tables[0];
                dr = dt.NewRow();
            }


            dr["IDTableID"] = this._dtoIngre.IDTableID.ToString();
            dr["IDTableName"] = this._dtoIngre.IDTableName;
            dr["IngredientID"] = this._dtoIngre.IngredientID.ToString();
            dr["ReserveTime"] = this._dtoIngre.ReserveTime.ToString();
            dr["IngredientName"] = this._dtoIngre.IngredientName;
            dr["TimeBand"] = this._dtoIngre.TimeBand.ToString();
            dr["IsInnerPeak"] = this._dtoIngre.IsInnerPeak;

            this.dgvIngredient.DataSource = dt;
            //this.dgvTimeProc.DataBind();

            this._dsIngredient.Tables[0].Rows.Add(dr);
            this.dgvIngredient.CurrentCell = this.dgvIngredient.Rows[this.dgvIngredient.Rows.Count - 1].Cells["ReserveTime"];

            DataTable dtCail = null;
            if (null == this._dsCalibrate)
            {
                this._dsCalibrate = new DataSet();
                dtCail = this._dsCalibrate.Tables.Add("T_Calibrate");

                dtCail.Columns.Add("IDTableID");
                dtCail.Columns.Add("IngredientID");
                dtCail.Columns.Add("CalibrateID");
                dtCail.Columns.Add("SampleID");
                dtCail.Columns.Add("PeakSize");
                dtCail.Columns.Add("PeakHeight");
                dtCail.Columns.Add("Density");
                dtCail.Columns.Add("FactorOne");
                dtCail.Columns.Add("FactorTwo");
                dtCail.Columns.Add("SampleWeight");

                dr = dtCail.NewRow();
                this._dtoCalibrate.IDTableID = this._dtoIngre.IDTableID;
            }
            else
            {
                this._dsCalibrate.Tables[0].Rows.Clear();
                dtCail = this._dsCalibrate.Tables[0];
                dr = dtCail.NewRow();
            }


            dr["IDTableID"] = this._dtoCalibrate.IDTableID.ToString();
            dr["IngredientID"] = this._dtoCalibrate.IngredientID.ToString();
            dr["CalibrateID"] = this._dtoCalibrate.CalibrateID.ToString();
            dr["SampleID"] = this._dtoCalibrate.SampleID.ToString();
            dr["PeakSize"] = this._dtoCalibrate.PeakSize.ToString();
            dr["PeakHeight"] = this._dtoCalibrate.PeakHeight.ToString();
            dr["Density"] = this._dtoCalibrate.Density.ToString();
            dr["FactorOne"] = this._dtoCalibrate.FactorOne.ToString();
            dr["FactorTwo"] = this._dtoCalibrate.FactorTwo.ToString();
            dr["SampleWeight"] = this._dtoCalibrate.SampleWeight.ToString();

            this.dgvCalibrate.DataSource = dtCail;
            //this.dgvTimeProc.DataBind();

            this._dsCalibrate.Tables[0].Rows.Add(dr);
            this.dgvCalibrate.CurrentCell = this.dgvCalibrate.Rows[this.dgvCalibrate.Rows.Count - 1].Cells["Density"];
        }

        /// <summary>
        /// 在含量视图中增加一条
        /// </summary>
        private void AddOneCaliInDgv()
        {
            DataRow dr = this._dsCalibrate.Tables[0].NewRow();
            this._dtoCalibrate.CalibrateID = this._bizCalibrate.GetNewIngredientIdInArray(this._dtoCalibrate);

            dr["IDTableID"] = this._dtoCalibrate.IDTableID.ToString();
            dr["IngredientID"] = this._dtoCalibrate.IngredientID.ToString();
            dr["CalibrateID"] = this._dtoCalibrate.CalibrateID.ToString();
            dr["Density"] = this._dtoCalibrate.Density.ToString();
            dr["PeakSize"] = this._dtoCalibrate.PeakSize.ToString();
            dr["PeakHeight"] = this._dtoCalibrate.PeakHeight.ToString();
            dr["FactorOne"] = this._dtoCalibrate.FactorOne.ToString();
            dr["FactorTwo"] = this._dtoCalibrate.FactorTwo.ToString();
            dr["SampleWeight"] = this._dtoCalibrate.SampleWeight.ToString();

            this._dsCalibrate.Tables[0].Rows.Add(dr);
            this.dgvCalibrate.CurrentCell = this.dgvCalibrate.Rows[this.dgvCalibrate.Rows.Count - 1].Cells["Density"];
        }

        /// <summary>
        /// 在成分视图中增加一条
        /// </summary>
        private void AddOneIngreInDgv()
        {
            DataRow dr = this._dsIngredient.Tables[0].NewRow();
            this._dtoIngre.IngredientID = this._bizIngre.GetNewIngredientIdInArray(this._dtoIngre);
            this._dtoCalibrate.IngredientID = this._dtoIngre.IngredientID;

            dr["IDTableID"] = this._dtoIngre.IDTableID.ToString();
            dr["IDTableName"] = this._dtoIngre.IDTableName;
            dr["IngredientID"] = this._dtoIngre.IngredientID.ToString();
            dr["ReserveTime"] = this._dtoIngre.ReserveTime.ToString();
            dr["IngredientName"] = this._dtoIngre.IngredientName;
            dr["TimeBand"] = this._dtoIngre.TimeBand.ToString();
            dr["IsInnerPeak"] = this._dtoIngre.IsInnerPeak;

            this._dsIngredient.Tables[0].Rows.Add(dr);
            this.dgvIngredient.CurrentCell = this.dgvIngredient.Rows[this.dgvIngredient.Rows.Count - 1].Cells["ReserveTime"];
        }

        /// <summary>
        /// 更新方法数据
        /// </summary>
        public void UpdateMark()
        {
            foreach (DataGridViewRow a in this.dgvIngredient.Rows)
            {
                int ingreId = Convert.ToInt32(a.Cells["IngredientID"].Value.ToString());
                if (ingreId == this._dtoIngre.IngredientID)
                {
                    a.Cells["IDTableName"].Value = this._dtoIngre.IDTableName;
                    a.Cells["ReserveTime"].Value = this._dtoIngre.ReserveTime.ToString();
                    a.Cells["IngredientName"].Value = this._dtoIngre.IngredientName;
                    a.Cells["TimeBand"].Value = this._dtoIngre.TimeBand.ToString();
                    a.Cells["IsInnerPeak"].Value = this._dtoIngre.IsInnerPeak;
                    break;
                }
            }

            foreach (DataGridViewRow b in this.dgvCalibrate.Rows)
            {
                int calibrateId = Convert.ToInt32(b.Cells["CalibrateID"].Value.ToString());
                if (calibrateId == this._dtoCalibrate.CalibrateID)
                {
                    b.Cells["PeakSize"].Value = this._dtoCalibrate.PeakSize.ToString();
                    b.Cells["PeakHeight"].Value = this._dtoCalibrate.PeakHeight.ToString();
                    b.Cells["Density"].Value = this._dtoCalibrate.Density.ToString();
                    b.Cells["SampleWeight"].Value = this._dtoCalibrate.SampleWeight.ToString();
                    b.Cells["FactorOne"].Value = this._dtoCalibrate.FactorOne.ToString();
                    b.Cells["FactorTwo"].Value = this._dtoCalibrate.FactorTwo.ToString();
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
            if (0 == this.dgvIngredient.Rows.Count)
            {
                MessageBox.Show("新建ID表至少要包含一项!", "提示");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 合法性检查
        /// </summary>
        /// <returns></returns>
        private bool CheckValid()
        {
            if (!this.CheckReserverTime())
            {
                return false;
            }
            if (!this.CheckTimeBand())
            {
                return false;
            }
            if (!this.CheckIdTableName())
            {
                return false;
            }
            if (!this.CheckDensity())
            {
                return false;
            }
            if (!this.CheckPeakHeight())
            {
                return false;
            }
            if (!this.CheckPeakSize())
            {
                return false;
            }
            if (!this.CheckFactorOne())
            {
                return false;
            }
            if (!this.CheckFactorTwo())
            {
                return false;
            }
            if (!this.CheckSampleWeight())
            {
                return false;
            }

            return true;
        }

        #endregion


        #region 事件

        /// <summary>
        /// 选择ID表选项变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._isLoadUi)
            {
                return;
            }

            if (null == this.cmbIngredient.SelectedValue)
            {
                return;
            }
            DataRowView dr = (DataRowView)this.cmbIngredient.SelectedItem;
            if (null == dr)
            {
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("载入这个ID表会清除当前ID表,确实要载入这个ID表吗,?", "确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                int iTemp = Convert.ToInt32(dr.Row["IDTableID"].ToString());
                this._dto.IDTableID = iTemp;
                this.LoadEdit();
            }
        }

        /// <summary>
        /// 分析方法中变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AnalyParaChanged(object sender, AnalyParaChangeArgs e)
        {

            this._dtoAnalyPara = e._dto;

            if (!this._isLoadUi)
            {
                return;
            }
            this.btnReCacu_Click(null, null);
        }

        /// <summary>
        /// 标题栏按下的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIngredient_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.UpdateIngredientSelectedRow();
        }

        /// <summary>
        /// 单击,双击单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIngredient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex)
            {
                return;
            }
            this.UpdateIngredientDetail();

            if (SizeDensityFrm.Instance.Visible)
            {
                this.btnFixCurve_Click(null, null);
            }
        }

        /// <summary>
        /// 设定单元格背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIngredient_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvIngredient.DefaultCellStyle.BackColor = Color.Beige;
            this.SetDgvCellHeight(this.dgvIngredient);
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIngredient_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                this.UpdateIngredientDetail();
            }
        }

        /// <summary>
        /// 更新按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (null == this._dsIngredient || null == this._dsIngredient.Tables[0] ||
                0 == this._dsIngredient.Tables[0].Rows.Count)
            {
                MessageBox.Show("没有ID表项", "提示");
                return;
            }

            if (this.CheckValid())
            {
                this.UpdateMark();
                this._bizIngre.UpdateArray(this._dtoIngre);
                this._bizCalibrate.UpdateArray(this._dtoCalibrate);
            }
        }

        /// <summary>
        /// 删除按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteCali_Click(object sender, EventArgs e)
        {

            if (null == this.dgvCalibrate.CurrentRow)
            {
                MessageBox.Show("没有选中含量表项目！", "提示");
                return;
            }

            if (1 >= this.dgvCalibrate.RowCount)
            //if (1 == this._dsCalibrate.Tables[0].Rows.Count)
            {
                MessageBox.Show("含量表项至少包含一项！", "提示");
                return;
            }

            if (DialogResult.Yes == MessageBox.Show("确实要删除该含量！", "确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                this.RemoveCaliInDgvAndArray();
            }
        }

        /// <summary>
        /// 删除成分按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteIngre_Click(object sender, EventArgs e)
        {
            if (null == this.dgvIngredient.CurrentRow)
            {
                MessageBox.Show("没有选中成分表项目！", "提示");
                return;
            }

            if (1 >= this.dgvIngredient.RowCount)
            {
                MessageBox.Show("成分表项至少包含一项！", "提示");
                return;
            }

            if (null == this._dsCalibrate || null == this._dsCalibrate.Tables[0] ||
                0 == this._dsCalibrate.Tables[0].Rows.Count)
            {
                MessageBox.Show("没有含量表项", "提示");
                return;
            }

            if (null == this.dgvCalibrate.CurrentRow)
            {
                MessageBox.Show("没有选中含量表项目！", "提示");
                return;
            }

            if (DialogResult.Yes == MessageBox.Show("确实要删除该成分！", "确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                this.RemoveIngreInDgvAndArray();
            }
        }

        /// <summary>
        /// 从含量视图和数据列表中删除当前选中的成分
        /// </summary>
        private void RemoveIngreInDgvAndArray()
        {
            int index = this.dgvIngredient.CurrentRow.Index;
            this.dgvIngredient.Rows.RemoveAt(index);
            this._bizIngre.RemoveInArray(this._dtoIngre);

            this.dgvCalibrate.Rows.RemoveAt(this.dgvCalibrate.CurrentRow.Index);
            this._bizCalibrate.RemoveInArray(this._dtoCalibrate);

            if (0 < this.dgvIngredient.Rows.Count)
            {
                //删除后，重新设定选中后一行，如果是最后一行，那么选中最后一行。
                if (index == this.dgvIngredient.Rows.Count)
                {
                    index = index - 1;
                }

                this.dgvIngredient.CurrentCell = this.dgvIngredient.Rows[index].Cells["ReserveTime"];
                this.UpdateIngredientDetail();

                //设定行选中
                UpdateIngredientSelectedRow();
            }
        }

        /// <summary>
        /// 从含量视图和数据列表中删除当前选中的含量
        /// </summary>
        private void RemoveCaliInDgvAndArray()
        {
            if (0 == this.dgvCalibrate.Rows.Count)
            {
                MessageBox.Show("只有一条含量,不能删除,只能删除成分!", "提示");
                return;
            }
            this.dgvCalibrate.Rows.RemoveAt(this.dgvCalibrate.CurrentRow.Index);
            this._bizCalibrate.RemoveInArray(this._dtoCalibrate);
            if (0 < this.dgvCalibrate.Rows.Count)
            {
                //开始时设定选中首行
                this.dgvCalibrate.CurrentCell = this.dgvCalibrate.Rows[0].Cells["Density"];
                this.UpdateCalibrateDetail();
            }
        }

        /// <summary>
        /// 添加含量按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCali_Click(object sender, EventArgs e)
        {
            if (this.CheckValid())
            {
                this.InsertMark(IdTable.Calibrate);
                this._bizCalibrate.InsertToArray(this._dtoCalibrate);
            }
        }

        /// <summary>
        /// 添加成分按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddIngre_Click(object sender, EventArgs e)
        {
            if (this.CheckValid())
            {
                this.InsertMark(IdTable.Ingredient);
                this._bizIngre.InsertToArray(this._dtoIngre);
                this._bizCalibrate.InsertToArray(this._dtoCalibrate);
                this.UpdateIngredientDetail();
            }
        }

        /// <summary>
        /// 自动建表按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoBuild_Click(object sender, EventArgs e)
        {

            if (null == this._dsIngredient || null == this._dsIngredient.Tables[0]
                                || 0 == this._dsIngredient.Tables[0].Rows.Count)
            {
                this._dtoIngre.IDTableID = this._bizIngre.GetNewIdentityID();
            }


            AutoBuildBase frmAutobuild = null;
            switch (General.ObjectLink)
            {
                case General.LinkObject.ChannelGas:
                case General.LinkObject.AutoChromatoGas:
                    frmAutobuild = (AutoBuildBase)new AutoBuildGasFrm(this._dtoIngre);
                    break;
                case General.LinkObject.BigBoard:
                case General.LinkObject.SmallBoard:
                    frmAutobuild = (AutoBuildBase)new AutoBuildFrm(this._dtoIngre);
                    break;
            }
            if (null == frmAutobuild)
            {
                return;
            }

            if (DialogResult.OK == frmAutobuild.ShowDialog())
            {
                this._dsIngredient = frmAutobuild._dsIngre;
                this._bizIngre.ResetArray(this._dsIngredient);
                this._bizCalibrate.ResetArray(frmAutobuild._arrCali);

                this.dgvIngredient.DataSource = this._dsIngredient.Tables[0];

                //开始时设定选中首行
                this.dgvIngredient.CurrentCell = this.dgvIngredient.Rows[0].Cells["ReserveTime"];

                this.UpdateIngredientDetail();

            }
        }

        /// <summary>
        /// 标题栏按下的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCalibrate_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.UpdateCalibrateSelectedRow();
        }

        /// <summary>
        /// 单击,双击单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCalibrate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex)
            {
                return;
            }
            this.UpdateCalibrateDetail();
        }

        /// <summary>
        /// 设定单元格背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCalibrate_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvCalibrate.DefaultCellStyle.BackColor = Color.Beige;
            this.SetDgvCellHeight(this.dgvCalibrate);
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCalibrate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                this.UpdateCalibrateDetail();
            }
        }

        /// <summary>
        /// 组分名焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtIngredientName_TextChanged(object sender, EventArgs e)
        {

            this._dtoIngre.IngredientName = this.txtIngredientName.Text;
        }

        /// <summary>
        /// 保留时间离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtReserverTime_TextChanged(object sender, EventArgs e)
        {
            if (!this.CheckReserverTime())
            {
                return;
            }

            this._dtoIngre.ReserveTime = Convert.ToSingle(this.txtReserverTime.Text);
        }

        /// <summary>
        /// 保留时间,合法性检验
        /// </summary>
        /// <returns></returns>
        private bool CheckReserverTime()
        {
            if (!CastString.IsNumeric(this.txtReserverTime.Text))
            {
                MessageBox.Show("保留时间不是数值！", "显示上限");
                this.txtReserverTime.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 时间带离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTimeBand_TextChanged(object sender, EventArgs e)
        {
            if (!this.CheckTimeBand())
            {
                return;
            }

            this._dtoIngre.TimeBand = Convert.ToSingle(this.txtTimeBand.Text);
        }

        /// <summary>
        /// 时间带，合法性检验
        /// </summary>
        /// <returns></returns>
        private bool CheckTimeBand()
        {
            if (String.IsNullOrEmpty(this.txtTimeBand.Text))
            {
                MessageBox.Show("时间带不能为空！", "时间带");
                this.txtTimeBand.Focus();
                return false;
            }
            if (!CastString.IsNumeric(this.txtTimeBand.Text))
            {
                MessageBox.Show("时间带不是数值！", "显示上限");
                this.txtTimeBand.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// ID表名称焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtIdTableName_TextChanged(object sender, EventArgs e)
        {
            if (!this.CheckIdTableName())
            {
                return;
            }

            this._dtoIngre.IDTableName = this.txtIdTableName.Text;
        }

        /// <summary>
        /// ID表名称，合法性检验
        /// </summary>
        /// <returns></returns>
        private bool CheckIdTableName()
        {
            if (String.IsNullOrEmpty(this.txtIdTableName.Text))
            {
                MessageBox.Show("ID表名称不能为空！", "ID表名称");
                this.txtIdTableName.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 浓度离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDensity_TextChanged(object sender, EventArgs e)
        {
            if (!this.CheckDensity())
            {
                return;
            }

            this._dtoCalibrate.Density = Convert.ToSingle(this.txtDensity.Text);
        }

        /// <summary>
        /// 浓度，合法性检验
        /// </summary>
        /// <returns></returns>
        private bool CheckDensity()
        {
            if (String.IsNullOrEmpty(this.txtDensity.Text))
            {
                MessageBox.Show("浓度不能为空！", "浓度");
                this.txtDensity.Focus();
                return false;
            }
            if (!CastString.IsNumeric(this.txtDensity.Text))
            {
                MessageBox.Show("浓度不是数值！", "浓度");
                this.txtDensity.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 高度离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPeakHeight_TextChanged(object sender, EventArgs e)
        {
            if (!this.CheckPeakHeight())
            {
                return;
            }

            this._dtoCalibrate.PeakHeight = Convert.ToSingle(this.txtPeakHeight.Text);
        }

        /// <summary>
        /// 高度，合法性检验
        /// </summary>
        /// <returns></returns>
        private bool CheckPeakHeight()
        {
            if (String.IsNullOrEmpty(this.txtPeakHeight.Text))
            {
                MessageBox.Show("高度不能为空！", "高度");
                this.txtPeakHeight.Focus();
                return false;
            }
            if (!CastString.IsNumeric(this.txtPeakHeight.Text))
            {
                MessageBox.Show("高度不是数值！", "高度");
                this.txtPeakHeight.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 面积离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPeakSize_TextChanged(object sender, EventArgs e)
        {
            if (!this.CheckPeakSize())
            {
                return;
            }

            this._dtoCalibrate.PeakSize = Convert.ToSingle(this.txtPeakSize.Text);
        }

        /// <summary>
        /// 面积，合法性检验
        /// </summary>
        /// <returns></returns>
        private bool CheckPeakSize()
        {
            if (String.IsNullOrEmpty(this.txtPeakSize.Text))
            {
                MessageBox.Show("面积不能为空！", "面积");
                this.txtPeakSize.Focus();
                return false;
            }
            if (!CastString.IsNumeric(this.txtPeakSize.Text))
            {
                MessageBox.Show("面积不是数值！", "面积");
                this.txtPeakSize.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 因子1离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFactorOne_TextChanged(object sender, EventArgs e)
        {
            if (!this.CheckFactorOne())
            {
                return;
            }
 
            this._dtoCalibrate.FactorOne = Convert.ToSingle(this.txtFactorOne.Text);
        }

        /// <summary>
        /// 因子1，合法性检验
        /// </summary>
        /// <returns></returns>
        private bool CheckFactorOne()
        {
            if (String.IsNullOrEmpty(this.txtFactorOne.Text))
            {
                MessageBox.Show("因子1不能为空！", "因子1");
                this.txtFactorOne.Focus();
                return false;
            }
            if (!CastString.IsNumeric(this.txtFactorOne.Text))
            {
                MessageBox.Show("因子1不是数值！", "因子1");
                this.txtFactorOne.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 因子2离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFactorTwo_TextChanged(object sender, EventArgs e)
        {
            if(!this.CheckFactorTwo())
            {
                return;
            }

            this._dtoCalibrate.FactorTwo = Convert.ToSingle(this.txtFactorTwo.Text);
        }

        /// <summary>
        /// 因子2，合法性检验
        /// </summary>
        /// <returns></returns>
        private bool CheckFactorTwo()
        {
            if (String.IsNullOrEmpty(this.txtFactorTwo.Text))
            {
                MessageBox.Show("因子2不能为空！", "因子2");
                this.txtFactorTwo.Focus();
                return false;
            }
            if (!CastString.IsNumeric(this.txtFactorTwo.Text))
            {
                MessageBox.Show("因子2不是数值！", "因子2");
                this.txtFactorTwo.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 样品量离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSampleWeight_TextChanged(object sender, EventArgs e)
        {
            if (!this.CheckSampleWeight())
            {
                return;
            }

            this._dtoCalibrate.SampleWeight = Convert.ToInt32(this.txtSampleWeight.Text);
        }

        /// <summary>
        /// 样品量，合法性检验
        /// </summary>
        /// <returns></returns>
        private bool CheckSampleWeight()
        {
            if (String.IsNullOrEmpty(this.txtSampleWeight.Text))
            {
                MessageBox.Show("样品量不能为空！", "样品量");
                this.txtSampleWeight.Focus();
                return false;
            }
            if (!CastString.IsNumber(this.txtSampleWeight.Text))
            {
                MessageBox.Show("样品量不是数字！", "样品量");
                this.txtSampleWeight.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 根据浓度和面积重新计算因子
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReCacu_Click(object sender, EventArgs e)
        {

            if (this._bizCalibrate.CheckDensityInArray())
            {
                if (Arithmatic.Normalize == this._dtoAnalyPara.ArithmaticID)
                {
                    return;
                }

                //非归一法
                this._bizCalibrate.CacuFactorInArray(this._bizIngre.GetIngreArry(), this._dtoAnalyPara);

                //开始时设定选中首行
                if (0 < this.dgvIngredient.Rows.Count)
                {
                    this.dgvIngredient.CurrentCell = this.dgvIngredient.Rows[0].Cells["ReserveTime"];

                    this.UpdateIngredientDetail();
                }
            }
        }

        /// <summary>
        /// 校正曲线按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFixCurve_Click(object sender, EventArgs e)
        {
            ArrayList arrPoly = new ArrayList();
            ArrayList arrSimu = new ArrayList();

            this._bizCalibrate.LoadCalibrateForCorrectPlot(this._dtoIngre, this._dtoAnalyPara, ref arrPoly, ref arrSimu);
            SizeDensityFrm.Instance.LoadPlot(arrPoly, arrSimu);

            if (!SizeDensityFrm.Instance.TopMost)
            {
                SizeDensityFrm.Instance.TopMost = true;
            }

            if (!SizeDensityFrm.Instance.Visible)
            {
                SizeDensityFrm.Instance.Visible = true;
            }
        }

        /// <summary>
        /// 成分视图鼠标落下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIngredient_MouseDown(object sender, MouseEventArgs e)
        {
            this.tsCorrectCurve.Enabled = this._isNeedLoadAll;
        }

        /// <summary>
        /// 是否内标峰选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxInnerPeak_CheckedChanged(object sender, EventArgs e)
        {
            this._dtoIngre.IsInnerPeak = this.cbxInnerPeak.Checked;
        }

        /// <summary>
        /// 清空ID表按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearTable_Click(object sender, EventArgs e)
        {

            this._dtoIngre.IngredientID = 1;
            this._dtoIngre.IngredientName = this.txtIngredientName.Text;
            this._dtoIngre.ReserveTime = Convert.ToSingle(this.txtReserverTime.Text);
            this._dtoIngre.TimeBand = Convert.ToSingle(this.txtTimeBand.Text);
            this._dtoIngre.IsInnerPeak = false;


            this._dtoCalibrate.CalibrateID = 1;
            this._dtoCalibrate.IngredientID = this._dtoIngre.IngredientID;
            this._dtoCalibrate.SampleWeight = Convert.ToInt32(this.txtSampleWeight.Text);
            this._dtoCalibrate.Density = Convert.ToSingle(this.txtDensity.Text);
            this._dtoCalibrate.PeakHeight = Convert.ToSingle(this.txtPeakHeight.Text);
            this._dtoCalibrate.PeakSize = Convert.ToSingle(this.txtPeakSize.Text);
            this._dtoCalibrate.FactorOne = Convert.ToSingle(this.txtFactorOne.Text);
            this._dtoCalibrate.FactorTwo = Convert.ToSingle(this.txtFactorTwo.Text);
            this._dtoCalibrate.SampleID = "notset";

            this.InitDataTable();
            this._bizIngre.ClearArray();
            this._bizIngre.InsertToArray(this._dtoIngre);

            this._bizCalibrate.ClearArray();
            this._bizCalibrate.InsertToArray(this._dtoCalibrate);
            this.UpdateIngredientDetail();

        }

        #endregion

    }
}
