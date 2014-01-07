/*-----------------------------------------------------------------------------
//  FILE NAME       : RegUser.cs
//  FUNCTION        : 样品注册控件
//  AUTHOR          : 李锋(2010/11/27)
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
using ChromatoTool.util;
using AutoChromatoBll.inf;

namespace TestGas
{
    public partial class RegUser : UserControl
    {


        #region 变量

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

        /// <summary>
        /// 参数dto
        /// </summary>
        private ParaDto _dtoPara = null;

        /// <summary>
        /// 样品注册逻辑
        /// </summary>
        private RequestInf _infReg = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public RegUser()
        {
            InitializeComponent();
            this.LoadEvent();
            this.LoadUi();
        }

        /// <summary>
        /// 装载画面
        /// </summary>
        private void LoadUi()
        {
            this._dtoRelation = new RelationDto();
            this._dtoPara = new ParaDto();
            this._infReg = new RequestInf();

            this.numUDSamPercent.Enabled = false;
            this.numUDInnerPercent.Enabled = false;

            this.LoadNew();

            this._isLoadUi = true;

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

            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);

        }


        #endregion


        #region 方法

        /// <summary>
        /// 装载画面
        /// </summary>
        /// <param name="dto"></param>
        public void LoadUi(ParaDto dto)
        {
            if (null == dto)
            {
                return;
            }
            this._dtoPara = dto;
            this.txtStatus.ReadOnly = true;
            this.numUDSamPercent.Enabled = true;
            this.numUDInnerPercent.Enabled = true;

            this.LoadNew();

            this._isLoadUi = true;
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

            this.txtSampleName.ReadOnly = false;
            this.txtSampleName.Text = "新建立样品";

            //查询全部方案
            this._dsSolu = this._infReg.LoadSoluList();
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
        /// 按钮按下事件
        /// </summary>
        public bool ButtonDealer()
        {
            int nRet = 0;
            this._dtoPara.SampleName = this.txtSampleName.Text;

            this._dtoPara.RegisterTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            this._dtoPara.UserID = "cai";

            this._dtoPara.StopTime = DefaultCollection.StopTime;
            this._dtoPara.SampleStatus = this.txtStatus.Text;

            nRet = this._infReg.RegSampleInfo(this._dtoPara, this._dtoRelation,
                this.cbxA.Checked,this.cbxB.Checked,this.cbxC.Checked,this.cbxD.Checked);
            switch(nRet)
            {
                case 1:
                    MessageBox.Show("样品名重复", "错误");
                    return false;
                case 2:
                    //MessageBox.Show("注册成功", "提示");
                    break;
            }

            return true;
        }

        /// <summary>
        /// 注册的合法性检查
        /// </summary>
        /// <returns></returns>
        public bool RegValidCheck()
        {
            if (String.IsNullOrEmpty(this.txtSampleName.Text))
            {
                MessageBox.Show("样品名称不能为空！", "样品名称");
                this.txtSampleName.Focus();
                return false;
            }
            return true;
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

        /// <summary>
        /// 样品注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            if (this.ButtonDealer())
            {
                MessageBox.Show("注册成功！", "样品注册");
            }
        }

        #endregion
    
    }
}
