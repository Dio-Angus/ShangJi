/*-----------------------------------------------------------------------------
//  FILE NAME       : SampleGasInfoViewer.cs
//  FUNCTION        : 通道气样品信息视图
//  AUTHOR          : 李锋(2010/04/20)
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
using ChromatoTool.util;

namespace ChromatoCore.sample
{
    /// <summary>
    /// 样品信息视图
    /// </summary>
    public partial class SampleGasInfoViewer : SampleUs
    {


        #region 变量

        /// <summary>
        /// 方案逻辑
        /// </summary>
        private SolutionBiz _bizSolu = null;

        /// <summary>
        /// 方案集合
        /// </summary>
        private DataSet _dsSolu = null;

        /// <summary>
        /// 关系信息
        /// </summary>
        private RelationDto _dtoRelation = null;

        /// <summary>
        /// 针对ComboBox类型控件设置的是否已经完成初始化
        /// </summary>
        private bool _isLoadUi = false;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="am"></param>
        public SampleGasInfoViewer(AccessMethod am)
        {
            InitializeComponent();
            this._accessM = am;
            this.LoadEvent();
            this.LoadUi();
        }

        /// <summary>
        /// 装载画面
        /// </summary>
        private void LoadUi()
        {
            this._bizSolu = new SolutionBiz();
            this._dtoRelation = new RelationDto(); 
            this.numUDSamPercent.Enabled = false;
            this.numUDInnerPercent.Enabled = false;
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.rbStandardSam.CheckedChanged += new System.EventHandler(this.rbStandardSam_CheckedChanged);
            this.rbUnknown.CheckedChanged += new System.EventHandler(this.rbUnknown_CheckedChanged);

            this.txtSampleName.TextChanged += new System.EventHandler(this.txtSampleName_TextChanged);

            this.numUDSamPercent.TextChanged += new System.EventHandler(this.numUDSamPercent_TextChanged);
            this.numUDSamPercent.Leave += new System.EventHandler(this.numUDSamPercent_Leave);

            this.numUDInnerPercent.TextChanged += new System.EventHandler(this.numUDInnerPercent_TextChanged);
            this.numUDInnerPercent.Leave += new System.EventHandler(this.numUDInnerPercent_Leave);

            this.cmbSolution.SelectedIndexChanged += new System.EventHandler(this.cbxSolution_SelectedIndexChanged);
        }


        #endregion


        #region 方法

        /// <summary>
        /// 装载画面
        /// </summary>
        /// <param name="dto"></param>
        public override void LoadUi(ParaDto dto)
        {
            if (null == dto)
            {
                return;
            }
            this._dtoPara = dto;
            this.txtStatus.ReadOnly = true;
            this.numUDSamPercent.Enabled = true;
            this.numUDInnerPercent.Enabled = true;

            switch (this._accessM)
            {
                case AccessMethod.View:
                    this.LoadView();
                    break;

                case AccessMethod.New:
                    this.LoadNew();
                    break;

                case AccessMethod.Edit:
                    this.LoadEdit();
                    break;

                case AccessMethod.SaveAs:
                    this.LoadSaveAs();
                    break;
            }

            this._isLoadUi = true;
        }

        /// <summary>
        /// 显示样品信息
        /// </summary>
        private void LoadView()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.txtSampleName.Text = this._dtoPara.SampleName;
            this.txtStatus.Text = _dtoPara.SampleStatus;

            this.LoadViewOrSaveAs();
            this.LoadControlStyle(true);
        }

        /// <summary>
        /// 查看或者复制
        /// </summary>
        private void LoadViewOrSaveAs()
        {

            //查询名
            this.cmbSolution.Items.Clear();

            RelationDto dtoRela = new RelationDto();
            dtoRela.SampleID = this._dtoPara.SampleID;
            dtoRela.RegisterTime = this._dtoPara.RegisterTime;

            String temp = this._bizSolu.GetSolutionNameBySampleID(dtoRela);
            if (!String.IsNullOrEmpty(temp))
            {
                this.cmbSolution.Items.Add(temp);
                this.cmbSolution.SelectedIndex = 0;
            }

            this.LoadRadioBtn();
            this.rbStandardSam.Enabled = this.rbStandardSam.Checked;
            this.rbUnknown.Enabled = this.rbUnknown.Checked;

            this.numUDSamPercent.Maximum = Convert.ToInt32(this._dtoPara.SampleWeight);
            this.numUDSamPercent.Minimum = Convert.ToInt32(this._dtoPara.SampleWeight);
            this.numUDSamPercent.Value = Convert.ToInt32(this._dtoPara.SampleWeight);

            this.numUDInnerPercent.Maximum = Convert.ToInt32(this._dtoPara.InnerWeight);
            this.numUDInnerPercent.Minimum = Convert.ToInt32(this._dtoPara.InnerWeight);
            this.numUDInnerPercent.Value = Convert.ToInt32(this._dtoPara.InnerWeight);

            this.LoadCheckbox();
        }

        /// <summary>
        /// 装载控件的风格
        /// </summary>
        /// <param name="isReadOnly"></param>
        private void LoadControlStyle(bool isReadOnly)
        {
            this.txtSampleName.ReadOnly = isReadOnly;

            this.numUDSamPercent.ReadOnly = isReadOnly;
            this.numUDInnerPercent.ReadOnly = isReadOnly;

            this.numUDSamPercent.InterceptArrowKeys = !isReadOnly;
            this.numUDInnerPercent.InterceptArrowKeys = !isReadOnly;

            this.txtSampleName.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.cmbSolution.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.numUDSamPercent.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.numUDInnerPercent.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.txtStatus.ReadOnly = true;
            this.txtStatus.BackColor = Color.Beige;

        }

        /// <summary>
        /// 注册样品信息
        /// </summary>
        private void LoadNew()
        {
            this.LoadControlStyle(false);

            this.BorderStyle = BorderStyle.None;
            this.txtSampleName.ReadOnly = false;
            this.txtSampleName.Text = "新建立样品";

            //查询全部方案
            this._dsSolu = this._bizSolu.LoadList();
            if (null != this._dsSolu && null != this._dsSolu.Tables[0] && 0 < this._dsSolu.Tables[0].Rows.Count)
            {
                this.cmbSolution.DataSource = this._dsSolu.Tables[0];
                this.cmbSolution.DisplayMember = "SolutionName";
                this.cmbSolution.ValueMember = "SolutionID";
                this.cmbSolution.SelectedIndex = 0;
                this._dtoRelation.SolutionID = Convert.ToInt32(this.cmbSolution.SelectedValue);
            }
            this.txtStatus.Text = StatusSample.Registered;
            this.rbStandardSam.Checked = true;

            this.numUDSamPercent.Value = DefaultSampleInfo.SampleWeight;
            this.numUDInnerPercent.Value = DefaultSampleInfo.InnerWeight;

            this._dtoPara.SampleWeight = DefaultSampleInfo.SampleWeight;
            this._dtoPara.InnerWeight = DefaultSampleInfo.InnerWeight;

            this.cbxA.Checked = true;
            this.cbxB.Checked = true;
            this.cbxC.Checked = true;
            this.cbxD.Checked = true;

        }

        /// <summary>
        /// 编辑样品信息
        /// </summary>
        private void LoadEdit()
        {
            this.BorderStyle = BorderStyle.None;
            this.txtSampleName.Text = this._dtoPara.SampleName;

            //查询全部方案
            this._dsSolu = this._bizSolu.LoadList();
            if (null == _dsSolu || null == _dsSolu.Tables[0])
            {
                ;
            }

            //查询样品方案ID
            RelationDto dtoRela = new RelationDto();
            dtoRela.SampleID = _dtoPara.SampleID;
            dtoRela.RegisterTime = _dtoPara.RegisterTime;

            String temp = this._bizSolu.GetSolutionID(dtoRela);

            this.cmbSolution.DataSource = this._dsSolu.Tables[0];
            this.cmbSolution.DisplayMember = "SolutionName";
            this.cmbSolution.ValueMember = "SolutionID";

            int index = FindIdInCombobox(
                this._dsSolu.Tables[0], temp, "SolutionID");

            this.cmbSolution.SelectedIndex = (0 < index) ? index : 0;
            this._dtoRelation.SolutionID = Convert.ToInt32(this.cmbSolution.SelectedValue);

            this.txtStatus.Text = _dtoPara.SampleStatus;

            this.LoadControlStyle(false);
            this.LoadRadioBtn();

            this.numUDSamPercent.Value = Convert.ToInt32(this._dtoPara.SampleWeight);
            this.numUDInnerPercent.Value = Convert.ToInt32(this._dtoPara.InnerWeight);

            this.LoadCheckbox();
        }

        /// <summary>
        /// 复制样品信息
        /// </summary>
        private void LoadSaveAs()
        {
            this.BorderStyle = BorderStyle.None;
            this.txtSampleName.Text = this._dtoPara.SampleName + DateTime.Now.ToString("_yyyyMMdd");

            //查询样品方案ID
            RelationDto dtoRela = new RelationDto();
            dtoRela.SampleID = _dtoPara.SampleID;
            dtoRela.RegisterTime = _dtoPara.RegisterTime;

            String temp = this._bizSolu.GetSolutionID(dtoRela);
            if (!String.IsNullOrEmpty(temp))
            {
                this._dtoRelation.SolutionID = Convert.ToInt32(temp);
            }

            this.LoadViewOrSaveAs();
            this.LoadControlStyle(true);

            this.txtStatus.Text = StatusSample.Registered;
            this.txtSampleName.BackColor = Color.White;
            this.txtSampleName.ReadOnly = false;
        }

        /// <summary>
        /// 装载选择按钮
        /// </summary>
        private void LoadRadioBtn()
        {

            switch ((TypeSample)_dtoPara.SampleType)
            {
                case TypeSample.Standard:
                    this.rbStandardSam.Checked = true;
                    break;
                case TypeSample.UnKnown:
                    this.rbUnknown.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// 装载复选框
        /// </summary>
        private void LoadCheckbox()
        {
            switch (this._dtoPara.ChannelID)
            {
                case GasChannel.A:
                    this.cbxA.Checked = true;
                    this.cbxB.Checked = false;
                    this.cbxC.Checked = false;
                    this.cbxD.Checked = false;
                    break;
                case GasChannel.B:
                    this.cbxA.Checked = false;
                    this.cbxB.Checked = true;
                    this.cbxC.Checked = false;
                    this.cbxD.Checked = false;
                    break;
                case GasChannel.C:
                    this.cbxA.Checked = false;
                    this.cbxB.Checked = false;
                    this.cbxC.Checked = true;
                    this.cbxD.Checked = false;
                    break;
                case GasChannel.D:
                    this.cbxA.Checked = false;
                    this.cbxB.Checked = false;
                    this.cbxC.Checked = false;
                    this.cbxD.Checked = true;
                    break;
            }

            this.cbxA.Enabled = false;
            this.cbxB.Enabled = false;
            this.cbxC.Enabled = false;
            this.cbxD.Enabled = false;
        }

        /// <summary>
        /// 根据ID从DataTable查找
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sID"></param>
        /// <param name="rowID"></param>
        /// <returns></returns>
        private int FindIdInCombobox(DataTable dt, string sID, string rowID)
        {
            int nCount = dt.Rows.Count;
            string sTemp = "";

            for (int i = 0; i < nCount; i++)
            {
                sTemp = dt.Rows[i][rowID].ToString();
                if (sTemp.Equals(sID))
                {
                    // find ok
                    return i;
                }
            }

            // not find
            return -1;
        }

        /// <summary>
        /// 按钮按下事件
        /// </summary>
        public override bool ButtonDealer()
        {
            ParaBiz bizPara = new ParaBiz();
            RelationBiz bizRelation = new RelationBiz();
            this._dtoPara.SampleName = this.txtSampleName.Text;
            bool bRet = true;

            switch (this._accessM)
            {
            case AccessMethod.New:

                if (!this.IsParaNameRepetited())
                {
                    MessageBox.Show("样品名重复", "错误");
                    return false;
                }
                this._dtoPara.RegisterTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                this._dtoPara.UserID = "cai";

                this._dtoPara.StopTime = DefaultCollection.StopTime;
                
                //A通道样品
                if (this.cbxA.Checked)
                {
                    this._dtoPara.ChannelID = GasChannel.A;
                    this.InsertParaAndRelation(bizPara, bizRelation);
                }

                //B通道样品
                if (this.cbxB.Checked)
                {
                    this._dtoPara.ChannelID = GasChannel.B;
                    this.InsertParaAndRelation(bizPara, bizRelation);
                }

                //C通道样品
                if (this.cbxC.Checked)
                {
                    this._dtoPara.ChannelID = GasChannel.C;
                    this.InsertParaAndRelation(bizPara, bizRelation);
                }

                //D通道样品
                if (this.cbxD.Checked)
                {
                    this._dtoPara.ChannelID = GasChannel.D;
                    this.InsertParaAndRelation(bizPara, bizRelation);
                }
                break;

            case AccessMethod.Edit:
                if (!this.IsParaNameRepetited(base._dtoPara))
                {
                    MessageBox.Show("样品名重复", "错误");
                    return false;
                }

                bRet = bizPara.UpdatePara(this._dtoPara);

                //更新关系
                this._dtoRelation.SampleID = this._dtoPara.SampleID;
                this._dtoRelation.RegisterTime = this._dtoPara.RegisterTime;
                bRet = bizRelation.UpdateRelation(this._dtoRelation);
                break;

            case AccessMethod.SaveAs:
                if (!this.IsParaNameRepetited())
                {
                    MessageBox.Show("样品名重复", "错误");
                    return false;
                }

                this._dtoPara.RegisterTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                this._dtoPara.UserID = "cai";

                this.InsertParaAndRelation(bizPara, bizRelation);

                break;
            }
            return bRet;
        }

        /// <summary>
        /// 插入样品和关系
        /// </summary>
        private void InsertParaAndRelation(ParaBiz bizPara, RelationBiz bizRelation)
        {
            bool bRet = false; 
            
            this._dtoPara.PathData = "db\\" + DateTime.Now.ToString("yyyyMM") + "\\"
                + "通道" + this._dtoPara.ChannelID + "_" + _dtoPara.RegisterTime + DefaultItem.Db_Extention;
            this._dtoPara.Remark = "";
            this._dtoPara.SampleID = "通道" + _dtoPara.ChannelID + "_" + _dtoPara.RegisterTime;
            this._dtoPara.SampleStatus = this.txtStatus.Text;
            bRet = bizPara.InsertPara(this._dtoPara);

            //插入关系
            this._dtoRelation.SampleID = this._dtoPara.SampleID;
            this._dtoRelation.RegisterTime = this._dtoPara.RegisterTime;
            bRet = bizRelation.InsertRelation(this._dtoRelation);
        }

        /// <summary>
        /// 注册的合法性检查
        /// </summary>
        /// <returns></returns>
        public override bool RegValidCheck()
        {
            switch (base._accessM)
            {
                case AccessMethod.New:
                    if (String.IsNullOrEmpty(this.txtSampleName.Text))
                    {
                        MessageBox.Show("样品名称不能为空！", "样品名称");
                        this.txtSampleName.Focus();
                        return false;
                    }
                    break;
                default:
                    break;
            }
            return true;
        }

        /// <summary>
        /// 样品名是否重复
        /// </summary>
        /// <returns></returns>
        public bool IsParaNameRepetited()
        {
            return base._bizPara.LoadParaByName(this.txtSampleName.Text.Trim());
        }


        /// <summary>
        /// 样品名是否重复
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool IsParaNameRepetited(ParaDto dto)
        {
            return base._bizPara.LoadParaByName(this.txtSampleName.Text.Trim(), dto);
        }

        #endregion


        #region 事件

        /// <summary>
        /// 样品名文字改变事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSampleName_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtSampleName.Text))
            {
                MessageBox.Show("样品名称不能为空！", "样品名称");
                this.txtSampleName.Focus();
                return;
            }
            this._dtoPara.SampleName = this.txtSampleName.Text;
        }

        /// <summary>
        /// 方案名改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxSolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._isLoadUi)
            {
                return;
            }

            if (null == this._dtoPara)
            {
                return;
            }
            if (null != this.cmbSolution.SelectedValue)
            {
                this._dtoRelation.SolutionID = Convert.ToInt32(this.cmbSolution.SelectedValue);
            }
        }

        /// <summary>
        /// 标准样品按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbStandardSam_CheckedChanged(object sender, EventArgs e)
        {
            this._dtoPara.SampleType = TypeSample.Standard;
        }

        /// <summary>
        /// 未知样品按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbUnknown_CheckedChanged(object sender, EventArgs e)
        {
            this._dtoPara.SampleType = TypeSample.UnKnown;
        }

        /// <summary>
        /// 样品量文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDSamPercent_TextChanged(object sender, EventArgs e)
        {

            Int32 v = Convert.ToInt32(this.numUDSamPercent.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 100000000 < v)
            {
                MessageBox.Show("样品量范围不正确！", "样品量");
                this.numUDSamPercent.Focus();
                return;
            }
            this._dtoPara.SampleWeight = Convert.ToInt32(this.numUDSamPercent.Value);
        }

        /// <summary>
        /// 样品量焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDSamPercent_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUDSamPercent.Value.ToString()))
            {
                MessageBox.Show("样品量范围不正确！", "样品量");
                this.numUDSamPercent.Focus();
                return;
            }
            this._dtoPara.SampleWeight = Convert.ToInt32(this.numUDSamPercent.Value);
        }

        /// <summary>
        /// 内标量文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDInnerPercent_TextChanged(object sender, EventArgs e)
        {

            Int32 v = Convert.ToInt32(this.numUDInnerPercent.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 100000000 < v)
            {
                MessageBox.Show("内标量范围不正确！", "内标量");
                this.numUDInnerPercent.Focus();
                return;
            }
            this._dtoPara.InnerWeight = Convert.ToInt32(this.numUDInnerPercent.Value);
        }

        /// <summary>
        /// 内标量焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDInnerPercent_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUDInnerPercent.Value.ToString()))
            {
                MessageBox.Show("内标量范围不正确！", "内标量");
                this.numUDInnerPercent.Focus();
                return;
            }
            this._dtoPara.InnerWeight = Convert.ToInt32(this.numUDInnerPercent.Value);
        }

        #endregion
    
    }
}
