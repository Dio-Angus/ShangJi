/*-----------------------------------------------------------------------------
//  FILE NAME       : SoluInfoViewer.cs
//  FUNCTION        : 方案的详细信息视图
//  AUTHOR          : 李锋(2009/05/22)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Data;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoBll.bll;
using ChromatoTool.ini;
using System.Drawing;

namespace ChromatoCore.solu.Info
{
    /// <summary>
    /// 方案的详细信息视图
    /// </summary>
    public partial class SoluInfoViewer : UserControl
    {


        #region 变量

        /// <summary>
        /// 访问方法
        /// </summary>
        public AccessMethod _accessM = AccessMethod.New;

        /// <summary>
        /// 关系逻辑
        /// </summary>
        private SolutionBiz _bizSolution = null;

        /// <summary>
        /// 方案dto
        /// </summary>
        private SolutionDto _dto = null;

        /// <summary>
        /// 是否第一次装载
        /// </summary>
        private bool _isFirst = true;

        /// <summary>
        /// 方案选择改变事件
        /// </summary>
        public event EventHandler<SolutionItemChangeArgs> ItemChanged;

        /// <summary>
        /// 针对ComboBox类型控件设置的是否已经完成初始化
        /// </summary>
        private bool _isLoadUi = false;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SoluInfoViewer(AccessMethod am)
        {
            InitializeComponent();
            this._accessM = am;
            this._bizSolution = new SolutionBiz();
            this.LoadEvent();
            this._dto = new SolutionDto();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.txtSolutionName.TextChanged += new System.EventHandler(this.txtSolutionName_TextChanged);
        }
        
        #endregion


        #region 方法

        /// <summary>
        /// 设置信息区的详细信息
        /// </summary>
        /// <param name="dto"></param>
        public void LoadUi(SolutionDto dto)
        {
            this._dto = dto;
            this.grpInfo.Enabled = (null == this._dto) ? false : true;
            if (null == this._dto)
            {
                return;
            }

            switch (this._accessM)
            {
                case AccessMethod.View:
                    this.LoadView();
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
                        this.LoadSaveAs();
                        this._isFirst = false;
                    }
                    break;
            }
        }

        /// <summary>
        /// 显示方案的信息
        /// </summary>
        private void LoadView()
        {
            DataSet ds = this._bizSolution.GetSolutionInfoName(_dto.SolutionID);
            this.txtSolutionName.Text = _dto.SolutionName.ToString();

            this.LoadNormalControl(ds);

            this.LoadControlStyle(false);
            this.txtSolutionName.BackColor = Color.Beige;
            this.cbxUseTimeProc.Enabled = false;

        }

        /// <summary>
        /// 装载普通控件
        /// </summary>
        /// <param name="ds"></param>
        private void LoadNormalControl(DataSet ds)
        {
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                MessageBox.Show("数据库中方案的信息不完整", "提示");
                return;
            }

            String temp = ds.Tables[0].Rows[0]["CollectionName"].ToString();
            if (!String.IsNullOrEmpty(temp))
            {
                this.cmbAcquName.Items.Clear();
                this.cmbAcquName.Items.Add(temp);
                this.cmbAcquName.SelectedIndex = 0;
            }

            temp = ds.Tables[0].Rows[0]["AnalyName"].ToString();
            if (!String.IsNullOrEmpty(temp))
            {
                this.cmbAnalyName.Items.Clear();
                this.cmbAnalyName.Items.Add(temp);
                this.cmbAnalyName.SelectedIndex = 0;
            }

            temp = ds.Tables[0].Rows[0]["IDTableName"].ToString();
            if (!String.IsNullOrEmpty(temp))
            {
                this.cmbIdTableName.Items.Clear();
                this.cmbIdTableName.Items.Add(temp);
                this.cmbIdTableName.SelectedIndex = 0;
            }

            temp = ds.Tables[0].Rows[0]["TPName"].ToString();
            if (!String.IsNullOrEmpty(temp))
            {
                this.cmbTimeProcName.Items.Clear();
                this.cmbTimeProcName.Items.Add(temp);
                this.cmbTimeProcName.SelectedIndex = 0;
            }

            temp = ds.Tables[0].Rows[0]["AntiControlName"].ToString();
            if (!String.IsNullOrEmpty(temp))
            {
                this.cmbAntiConName.Items.Clear();
                this.cmbAntiConName.Items.Add(temp);
                this.cmbAntiConName.SelectedIndex = 0;
            }

            temp = ds.Tables[0].Rows[0]["IsUseTimeProc"].ToString();
            this.cbxUseTimeProc.Checked = Convert.ToBoolean(temp);
        }

        /// <summary>
        /// 装载控件背景色
        /// </summary>
        /// <param name="isEdit"></param>
        private void LoadControlStyle(bool isEdit)
        {
            this.cmbAcquName.BackColor = isEdit ? Color.White : Color.Beige;
            this.cmbAnalyName.BackColor = isEdit ? Color.White : Color.Beige;
            this.cmbIdTableName.BackColor = isEdit ? Color.White : Color.Beige;
            this.cmbTimeProcName.BackColor = isEdit ? Color.White : Color.Beige;
            this.cmbAntiConName.BackColor = isEdit ? Color.White : Color.Beige;

        }

        /// <summary>
        /// 新建立方案的信息
        /// </summary>
        private void LoadNew()
        {
            this.txtSolutionName.Text = "新建立方案";
            this.txtSolutionName.ReadOnly = false;
            this.txtSolutionName.BackColor = Color.White;

            //采集方法
            CollectionBiz bizCol = new CollectionBiz();
            DataSet dsCol = bizCol.LoadMethodName();
            if (null != dsCol && null != dsCol.Tables[0])
            {
                this.cmbAcquName.DataSource = dsCol.Tables[0];
                this.cmbAcquName.DisplayMember = "CollectionName";
                this.cmbAcquName.ValueMember = "CollectionID";
                this.cmbAcquName.SelectedIndex = -1;
            }

            //分析方法
            AnalyParaBiz bizAna = new AnalyParaBiz();
            DataSet dsAna = bizAna.LoadMethodName();
            if (null != dsAna && null != dsAna.Tables[0])
            {
                this.cmbAnalyName.DataSource = dsAna.Tables[0];
                this.cmbAnalyName.DisplayMember = "AnalyName";
                this.cmbAnalyName.ValueMember = "AnalyParaID";
                this.cmbAnalyName.SelectedIndex = -1;
            }

            //ID表
            IngredientBiz bizIdT = new IngredientBiz();
            DataSet dsIdT = bizIdT.LoadMethodName();
            if (null != dsIdT && null != dsIdT.Tables[0])
            {
                this.cmbIdTableName.DataSource = dsIdT.Tables[0];
                this.cmbIdTableName.DisplayMember = "IDTableName";
                this.cmbIdTableName.ValueMember = "IDTableID";
                this.cmbIdTableName.SelectedIndex = -1;
            }


            //时间程序
            TimeProcBiz bizTp = new TimeProcBiz();
            DataSet dsTp = bizTp.LoadMethodName();
            if (null != dsTp && null != dsTp.Tables[0])
            {
                this.cmbTimeProcName.DataSource = dsTp.Tables[0];
                this.cmbTimeProcName.DisplayMember = "TPName";
                this.cmbTimeProcName.ValueMember = "TPid";
                this.cmbTimeProcName.SelectedIndex = -1;
            }


            //反控方法
            AntiControlBiz bizAnti = new AntiControlBiz();
            DataSet dsAnti = bizAnti.LoadMethod();
            if (null != dsAnti && null != dsAnti.Tables[0])
            {
                this.cmbAntiConName.DataSource = dsAnti.Tables[0];
                this.cmbAntiConName.DisplayMember = "AntiControlName";
                this.cmbAntiConName.ValueMember = "AntiControlID";
                this.cmbAntiConName.SelectedIndex = -1;
            }

            this.cbxUseTimeProc.Checked = false;
            this.cbxUseTimeProc.Enabled = true;

            this._isLoadUi = true;
            this._dto.SolutionName = this.txtSolutionName.Text;
            this._dto.IsUseTimeProc = this.cbxUseTimeProc.Checked;

            this.LoadControlStyle(true);
            this.txtSolutionName.BackColor = Color.White;

        }

        /// <summary>
        /// 编辑当前方案的信息
        /// </summary>
        private void LoadEdit()
        {
            this.txtSolutionName.ReadOnly = false;
            this.txtSolutionName.BackColor = Color.White;

            DataSet ds = this._bizSolution.GetSolutionInfoName(_dto.SolutionID);
            this.txtSolutionName.Text = _dto.SolutionName.ToString();

            this.LoadNormalControl(ds);
            this.LoadControlStyle(false);
            this.cbxUseTimeProc.Enabled = true;
            this._dto.IsUseTimeProc = this.cbxUseTimeProc.Checked;

        }

        /// <summary>
        /// 复制当前方案的信息
        /// </summary>
        private void LoadSaveAs()
        {
            DataSet ds = this._bizSolution.GetSolutionInfoName(_dto.SolutionID);
            this.txtSolutionName.Text = _dto.SolutionName.ToString() + DateTime.Now.ToString("_yyyyMMdd");
            this.txtSolutionName.ReadOnly = false;
            this.txtSolutionName.BackColor = Color.White;

            this.LoadNormalControl(ds);
            this.LoadControlStyle(false);
            this.cbxUseTimeProc.Enabled = false;
        }

        /// <summary>
        /// 另外保存，复制自身
        /// </summary>
        /// <param name="dto"></param>
        public bool SaveAsUi(SolutionDto dto)
        {
            return this._bizSolution.InsertSolu(dto);
        }

        /// <summary>
        /// 插入采集方法
        /// </summary>
        public void SaveNew()
        {
            if (0 == this._dto.SolutionID)
            {
                this._bizSolution.InsertSolu(this._dto);
            }
        }

        /// <summary>
        /// 更新采集方法
        /// </summary>
        public void SaveEdit()
        {
            this._bizSolution.UpdateSolu(this._dto);
        }

        /// <summary>
        /// 方案名是否重复
        /// </summary>
        /// <returns></returns>
        public bool IsSolutionNameRepetited()
        {
            return this._bizSolution.LoadSoluByName(this.txtSolutionName.Text.Trim());
        }

        /// <summary>
        /// 方案名是否重复
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsSolutionNameRepetited(String id)
        {
            return this._bizSolution.LoadSoluByName(this.txtSolutionName.Text.Trim(), id);
        }

        #endregion
        

        #region 事件

        /// <summary>
        /// 方案名焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSolutionName_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtSolutionName.Text))
            {
                MessageBox.Show("方案名称不能为空！", "方案名称");
                this.txtSolutionName.Focus();
                return;
            }
            this._dto.SolutionName = this.txtSolutionName.Text;
        }

        /// <summary>
        /// 采集方法变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxAcquName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._isLoadUi)
            {
                return;
            }
            if (null == this.cmbAcquName.SelectedValue)
            {
                return;
            }
            DataRowView dr = (DataRowView)this.cmbAcquName.SelectedItem;
            if (null == dr)
            {
                return;
            }

            int iTemp = Convert.ToInt32(dr.Row["CollectionID"].ToString());
            if (iTemp == this._dto.CollectionID)
            {
                return;
            }

            this._dto.CollectionID = iTemp;

            SolutionItemChangeArgs eve = new SolutionItemChangeArgs(SolutionItem.Collection, this._dto.CollectionID);
            if (ItemChanged != null)
            {
                this.ItemChanged(this, eve);
            }
        }

        /// <summary>
        /// 分析方法变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxAnalyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._isLoadUi)
            {
                return;
            }
            if (null == this.cmbAnalyName.SelectedValue)
            {
                return;
            }
            DataRowView dr = (DataRowView)this.cmbAnalyName.SelectedItem;
            if (null == dr)
            {
                return;
            }

            int iTemp = Convert.ToInt32(dr.Row["AnalyParaID"].ToString());
            if (iTemp == this._dto.AnalyParaID)
            {
                return;
            }

            this._dto.AnalyParaID = iTemp;

            SolutionItemChangeArgs eve = new SolutionItemChangeArgs(SolutionItem.Analysis, this._dto.AnalyParaID);
            if (ItemChanged != null)
            {
                this.ItemChanged(this, eve);
            }
        }

        /// <summary>
        /// ID表变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxIdTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._isLoadUi)
            {
                return;
            }
            if (null == this.cmbIdTableName.SelectedValue)
            {
                return;
            }
            DataRowView dr = (DataRowView)this.cmbIdTableName.SelectedItem;
            if (null == dr)
            {
                return;
            }

            int iTemp = Convert.ToInt32(dr.Row["IDTableID"].ToString());
            if (iTemp == this._dto.IDTableID)
            {
                return;
            }

            this._dto.IDTableID = iTemp;

            SolutionItemChangeArgs eve = new SolutionItemChangeArgs(SolutionItem.IdTable, this._dto.IDTableID);
            if (ItemChanged != null)
            {
                this.ItemChanged(this, eve);
            }
        }

        /// <summary>
        /// 时间程序变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxTimeProcName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._isLoadUi)
            {
                return;
            }
            if (null == this.cmbTimeProcName.SelectedValue)
            {
                return;
            }
            DataRowView dr = (DataRowView)this.cmbTimeProcName.SelectedItem;
            if (null == dr)
            {
                return;
            }

            int iTemp = Convert.ToInt32(dr.Row["TPid"].ToString());
            if (iTemp == this._dto.TimeProcID)
            {
                return;
            }

            this._dto.TimeProcID = iTemp;

            SolutionItemChangeArgs eve = new SolutionItemChangeArgs(SolutionItem.TimeProc, this._dto.TimeProcID);
            if (ItemChanged != null)
            {
                this.ItemChanged(this, eve);
            }
        }

        /// <summary>
        /// 反控制方法变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxAntiConName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._isLoadUi)
            {
                return;
            }
            if (null == this.cmbAntiConName.SelectedValue)
            {
                return;
            }
            DataRowView dr = (DataRowView)this.cmbAntiConName.SelectedItem;
            if (null == dr)
            {
                return;
            }

            int iTemp = Convert.ToInt32(dr.Row["AntiControlID"].ToString());
            if (iTemp == this._dto.AntiMethodID)
            {
                return;
            }

            this._dto.AntiMethodID = iTemp;

            SolutionItemChangeArgs eve = new SolutionItemChangeArgs(SolutionItem.AntiControl, this._dto.AntiMethodID);
            if (ItemChanged != null)
            {
                this.ItemChanged(this, eve);
            }
        }

        /// <summary>
        /// 使用时间程序选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxUseTimeProc_Click(object sender, EventArgs e)
        {
            this._dto.IsUseTimeProc = this.cbxUseTimeProc.Checked;
        }

        #endregion


    }
}
