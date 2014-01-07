/*-----------------------------------------------------------------------------
//  FILE NAME       : FidUser.cs
//  FUNCTION        : 反控方法FID
//  AUTHOR          : 李锋(2009/07/01)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.ini;
using ChromatoTool.dto;
using ChromatoTool.util;

namespace ChromatoCore.solu.AntiCon
{
    /// <summary>
    /// 反控方法FID
    /// </summary>
    public partial class FidUser : UserControl
    {


        #region 变量

        /// <summary>
        /// 分析方法dto
        /// </summary>
        private AntiControlDto _dtoAntiControl = null;

        /// <summary>
        /// 放大倍数是否处于编辑状态
        /// </summary>
        private bool _bIsEdit = false;
 
        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public FidUser(AntiControlDto dto)
        {
            InitializeComponent();
            this._dtoAntiControl = dto;
            this.LoadEvent();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.txtAlertTemp.TextChanged += new System.EventHandler(this.txtAlertTemp1_TextChanged);
            this.txtInitTemp.TextChanged += new System.EventHandler(this.txtInitTemp1_TextChanged);
        }

        #endregion


        #region 方法

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        public void LoadView(int antiControlID)
        {
            this.LoadControlStyle(true);

            if (null == this._dtoAntiControl.dtoFid)
            {
                return;
            }

            this.LoadViewOrSaveAs();
            this.cmbMagnifyFactorFid1.Items.Clear();
            this.cmbMagnifyFactorFid2.Items.Clear();

            switch ((Magnify)this._dtoAntiControl.dtoFid.MagnifyFactorOne)
            {
                case Magnify.Zero:
                    this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Zero));
                    break;
                case Magnify.One:
                    this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.One));
                    break;
                case Magnify.Two:
                    this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Two));
                    break;
                case Magnify.Three:
                    this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Three));
                    break;

            }

            switch ((Magnify)this._dtoAntiControl.dtoFid.MagnifyFactorTwo)
            {
                case Magnify.Zero:
                    this.cmbMagnifyFactorFid2.Items.Add(EnumDescription.GetFieldText(Magnify.Zero));
                    break;
                case Magnify.One:
                    this.cmbMagnifyFactorFid2.Items.Add(EnumDescription.GetFieldText(Magnify.One));
                    break;
                case Magnify.Two:
                    this.cmbMagnifyFactorFid2.Items.Add(EnumDescription.GetFieldText(Magnify.Two));
                    break;
                case Magnify.Three:
                    this.cmbMagnifyFactorFid2.Items.Add(EnumDescription.GetFieldText(Magnify.Three));
                    break;

            }
            this.cmbMagnifyFactorFid1.SelectedIndex = 0;
            this.cmbMagnifyFactorFid2.SelectedIndex = 0;

        }

        /// <summary>
        /// 查看或者复制
        /// </summary>
        public void LoadViewOrSaveAs()
        {

            this.txtInitTemp.Text = this._dtoAntiControl.dtoFid.InitTemp.ToString();
            this.txtAlertTemp.Text = this._dtoAntiControl.dtoFid.AlertTemp.ToString();

            this.cbxPolarityFid1.Checked = this._dtoAntiControl.dtoFid.PolarityOne;
            this.cbxPolarityFid1.Text = this.cbxPolarityFid1.Checked ? Polarity.Positive : Polarity.Nagative;

            this.cbxPolarityFid2.Checked = this._dtoAntiControl.dtoFid.PolarityTwo;
            this.cbxPolarityFid2.Text = this.cbxPolarityFid2.Checked ? Polarity.Positive : Polarity.Nagative;
        }

        /// <summary>
        /// 装载控件的风格
        /// </summary>
        /// <param name="isReadOnly"></param>
        public void LoadControlStyle(bool isReadOnly)
        {
            this.txtInitTemp.ReadOnly = isReadOnly;
            this.txtAlertTemp.ReadOnly = isReadOnly;

            this.cbxPolarityFid1.Enabled = !isReadOnly;
            this.cbxPolarityFid2.Enabled = !isReadOnly;

            this.txtInitTemp.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtAlertTemp.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.cmbMagnifyFactorFid1.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.cmbMagnifyFactorFid2.BackColor = isReadOnly ? Color.Beige : Color.White;

            this._bIsEdit = !isReadOnly;

        }

        /// <summary>
        /// 新建立反控的信息
        /// </summary>
        public void LoadNew()
        {

            this.LoadControlStyle(false);

            if (null == this._dtoAntiControl.dtoFid)
            {
                this._dtoAntiControl.dtoFid = new FidDto();
            }

            this.txtInitTemp.Text = DefaultFid.InitTemp.ToString();
            this.txtAlertTemp.Text = DefaultFid.AlertTemp.ToString();

            this.cbxPolarityFid1.Checked = DefaultFid.PolarityOne;
            this.cbxPolarityFid2.Checked = DefaultFid.PolarityTwo;

            this.cbxPolarityFid1.Text = this.cbxPolarityFid1.Checked ? Polarity.Positive : Polarity.Nagative;
            this.cbxPolarityFid2.Text = this.cbxPolarityFid2.Checked ? Polarity.Positive : Polarity.Nagative;

            this.cmbMagnifyFactorFid1.Items.Clear();
            this.cmbMagnifyFactorFid2.Items.Clear();

            this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Zero));
            this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.One));
            this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Two));
            this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Three));

            this.cmbMagnifyFactorFid2.Items.Add(EnumDescription.GetFieldText(Magnify.Zero));
            this.cmbMagnifyFactorFid2.Items.Add(EnumDescription.GetFieldText(Magnify.One));
            this.cmbMagnifyFactorFid2.Items.Add(EnumDescription.GetFieldText(Magnify.Two));
            this.cmbMagnifyFactorFid2.Items.Add(EnumDescription.GetFieldText(Magnify.Three));

            this.cmbMagnifyFactorFid1.SelectedIndex = DefaultFid.MagnifyFactorOne;
            this.cmbMagnifyFactorFid2.SelectedIndex = DefaultFid.MagnifyFactorTwo;

            this._dtoAntiControl.dtoFid.AlertTemp = DefaultFid.AlertTemp;
            this._dtoAntiControl.dtoFid.InitTemp = DefaultFid.InitTemp;
            this._dtoAntiControl.dtoFid.PolarityOne = DefaultFid.PolarityOne;
            this._dtoAntiControl.dtoFid.PolarityTwo = DefaultFid.PolarityTwo;
            this._dtoAntiControl.dtoFid.MagnifyFactorOne = DefaultFid.MagnifyFactorOne;
            this._dtoAntiControl.dtoFid.MagnifyFactorTwo = DefaultFid.MagnifyFactorTwo;

        }

        /// <summary>
        /// 编辑当前反控的信息
        /// </summary>
        public void LoadEdit()
        {

            this.LoadControlStyle(false);
            
            if (null == this._dtoAntiControl.dtoFid)
            {
                return;
            }

            this.cmbMagnifyFactorFid1.Items.Clear();
            this.cmbMagnifyFactorFid2.Items.Clear();
            
            this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Zero));
            this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.One));
            this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Two));
            this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Three));

            this.cmbMagnifyFactorFid2.Items.Add(EnumDescription.GetFieldText(Magnify.Zero));
            this.cmbMagnifyFactorFid2.Items.Add(EnumDescription.GetFieldText(Magnify.One));
            this.cmbMagnifyFactorFid2.Items.Add(EnumDescription.GetFieldText(Magnify.Two));
            this.cmbMagnifyFactorFid2.Items.Add(EnumDescription.GetFieldText(Magnify.Three));


            switch ((Magnify)this._dtoAntiControl.dtoFid.MagnifyFactorOne)
            {
                case Magnify.Zero:
                    this.cmbMagnifyFactorFid1.SelectedIndex = 0;
                    break;
                case Magnify.One:
                    this.cmbMagnifyFactorFid1.SelectedIndex = 1;
                    break;
                case Magnify.Two:
                    this.cmbMagnifyFactorFid1.SelectedIndex = 2;
                    break;
                case Magnify.Three:
                    this.cmbMagnifyFactorFid1.SelectedIndex = 3;
                    break;
            }

            switch ((Magnify)this._dtoAntiControl.dtoFid.MagnifyFactorTwo)
            {
                case Magnify.Zero:
                    this.cmbMagnifyFactorFid2.SelectedIndex = 0;
                    break;
                case Magnify.One:
                    this.cmbMagnifyFactorFid2.SelectedIndex = 1;
                    break;
                case Magnify.Two:
                    this.cmbMagnifyFactorFid2.SelectedIndex = 2;
                    break;
                case Magnify.Three:
                    this.cmbMagnifyFactorFid2.SelectedIndex = 3;
                    break;
            }

            this.LoadViewOrSaveAs();

        }

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        public void LoadSaveAs()
        {

            this.LoadControlStyle(true);
            if (null == this._dtoAntiControl.dtoFid)
            {
                return;
            }

            this.LoadViewOrSaveAs();
            
            this.cmbMagnifyFactorFid1.Items.Clear();
            this.cmbMagnifyFactorFid2.Items.Clear();

            switch ((Magnify)this._dtoAntiControl.dtoFid.MagnifyFactorOne)
            {
                case Magnify.Zero:
                    this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Zero));
                    break;
                case Magnify.One:
                    this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.One));
                    break;
                case Magnify.Two:
                    this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Two));
                    break;
                case Magnify.Three:
                    this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Three));
                    break;

            }

            switch ((Magnify)this._dtoAntiControl.dtoFid.MagnifyFactorTwo)
            {
                case Magnify.Zero:
                    this.cmbMagnifyFactorFid2.Items.Add(EnumDescription.GetFieldText(Magnify.Zero));
                    break;
                case Magnify.One:
                    this.cmbMagnifyFactorFid2.Items.Add(EnumDescription.GetFieldText(Magnify.One));
                    break;
                case Magnify.Two:
                    this.cmbMagnifyFactorFid2.Items.Add(EnumDescription.GetFieldText(Magnify.Two));
                    break;
                case Magnify.Three:
                    this.cmbMagnifyFactorFid2.Items.Add(EnumDescription.GetFieldText(Magnify.Three));
                    break;

            }
            this.cmbMagnifyFactorFid1.SelectedIndex = 0;
            this.cmbMagnifyFactorFid2.SelectedIndex = 0;

        }

        #endregion


        #region 事件

        /// <summary>
        /// 极性1按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxPolarityFid1_CheckedChanged(object sender, EventArgs e)
        {
            this.cbxPolarityFid1.Text = this.cbxPolarityFid1.Checked ? Polarity.Positive : Polarity.Nagative;
            this._dtoAntiControl.dtoFid.PolarityOne = this.cbxPolarityFid1.Checked;
        }

        /// <summary>
        /// 极性2按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxPolarityFid2_CheckedChanged(object sender, EventArgs e)
        {
            this.cbxPolarityFid2.Text = this.cbxPolarityFid2.Checked ? Polarity.Positive : Polarity.Nagative;
            this._dtoAntiControl.dtoFid.PolarityTwo = this.cbxPolarityFid2.Checked;
        }

        /// <summary>
        /// 放大倍数1选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMagnifyFactorFid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._bIsEdit)
            {
                return;
            }
            this._dtoAntiControl.dtoFid.MagnifyFactorOne = this.cmbMagnifyFactorFid1.SelectedIndex;
        }

        /// <summary>
        /// 放大倍数2选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMagnifyFactorFid2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._bIsEdit)
            {
                return;
            }
            this._dtoAntiControl.dtoFid.MagnifyFactorTwo = this.cmbMagnifyFactorFid2.SelectedIndex;
        }

        /// <summary>
        /// 报警温度焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAlertTemp1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtAlertTemp.Text))
            {
                MessageBox.Show("报警温度不能为空！", "报警温度");
                this.txtAlertTemp.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtAlertTemp.Text))
            {
                MessageBox.Show("报警温度不是数值！", "报警温度");
                this.txtAlertTemp.Focus();
                return;
            }
            this._dtoAntiControl.dtoFid.AlertTemp = Convert.ToSingle(this.txtAlertTemp.Text);
        }

        /// <summary>
        /// 初   温焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInitTemp1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtInitTemp.Text))
            {
                MessageBox.Show("初温不能为空！", "初   温");
                this.txtInitTemp.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtInitTemp.Text))
            {
                MessageBox.Show("初温不是数值！", "初   温");
                this.txtInitTemp.Focus();
                return;
            }
            this._dtoAntiControl.dtoFid.InitTemp = Convert.ToSingle(this.txtInitTemp.Text);
        }


        #endregion


    }
}
