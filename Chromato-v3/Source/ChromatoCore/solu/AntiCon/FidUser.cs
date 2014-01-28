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
            //this.LoadControlStyle(false);
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.txtAlertTemp1.TextChanged += new System.EventHandler(this.txtAlertTemp1_TextChanged);
            this.txtAlertTemp2.TextChanged += new System.EventHandler(this.txtAlertTemp2_TextChanged);
            this.txtInitTemp1.TextChanged += new System.EventHandler(this.txtInitTemp1_TextChanged);
            this.txtInitTemp2.TextChanged += new System.EventHandler(this.txtInitTemp2_TextChanged);
        }

        #endregion


        #region 方法

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        public void LoadView(int antiControlID)
        {

            if (null == this._dtoAntiControl.dtoFid)
            {
                return;
            }

            this.LoadViewOrSaveAs();
            this.cmbMagnifyFactorFid1.Items.Clear();
            this.cmbMagnifyFactorFid2.Items.Clear();

            switch ((Magnify)this._dtoAntiControl.dtoFid.MagnifyFactor1)
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

            switch ((Magnify)this._dtoAntiControl.dtoFid.MagnifyFactor2)
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
            if (this._dtoAntiControl.dtoFid.FID1Used)
            {
                this.cb1.SelectedIndex = 0;
                this.txtInitTemp1.Text = this._dtoAntiControl.dtoFid.InitTemp1.ToString();
                this.txtAlertTemp1.Text = this._dtoAntiControl.dtoFid.AlertTemp1.ToString();
                this.cmbMagnifyFactorFid1.SelectedIndex = this._dtoAntiControl.dtoFid.MagnifyFactor1;
                this.cbxPolarityFid1.Checked = this._dtoAntiControl.dtoFid.Polarity1;
                this.cbxPolarityFid1.Text = this.cbxPolarityFid1.Checked ? Polarity.Positive : Polarity.Nagative;
            }
            else if (this._dtoAntiControl.dtoFid.FIDK1Used)
            {
                this.cb1.SelectedIndex = 1;
                this.txtInitTemp1.Text = this._dtoAntiControl.dtoFid.InitTempK1.ToString();
                this.txtAlertTemp1.Text = this._dtoAntiControl.dtoFid.AlertTempK1.ToString();
                this.cmbMagnifyFactorFid1.SelectedIndex = this._dtoAntiControl.dtoFid.MagnifyFactorK1;
                this.cbxPolarityFid1.Checked = this._dtoAntiControl.dtoFid.PolarityK1;
                this.cbxPolarityFid1.Text = this.cbxPolarityFid1.Checked ? Polarity.Positive : Polarity.Nagative;
            }

            if (this._dtoAntiControl.dtoFid.FID2Used)
            {
                this.cb2.SelectedIndex = 0;
                this.txtInitTemp2.Text = this._dtoAntiControl.dtoFid.InitTemp2.ToString();
                this.txtAlertTemp2.Text = this._dtoAntiControl.dtoFid.AlertTemp2.ToString();
                this.cmbMagnifyFactorFid2.SelectedIndex = this._dtoAntiControl.dtoFid.MagnifyFactor2;
                this.cbxPolarityFid2.Checked = this._dtoAntiControl.dtoFid.Polarity2;
                this.cbxPolarityFid2.Text = this.cbxPolarityFid2.Checked ? Polarity.Positive : Polarity.Nagative;
            }
            else if (this._dtoAntiControl.dtoFid.FIDK2Used)
            {
                this.cb2.SelectedIndex = 0;
                this.txtInitTemp2.Text = this._dtoAntiControl.dtoFid.InitTempK2.ToString();
                this.txtAlertTemp2.Text = this._dtoAntiControl.dtoFid.AlertTempK2.ToString();
                this.cmbMagnifyFactorFid2.SelectedIndex = this._dtoAntiControl.dtoFid.MagnifyFactorK2;
                this.cbxPolarityFid2.Checked = this._dtoAntiControl.dtoFid.PolarityK2;
                this.cbxPolarityFid2.Text = this.cbxPolarityFid2.Checked ? Polarity.Positive : Polarity.Nagative;
            }
        }

        /// <summary>
        /// 导出数据到缓冲区
        /// </summary>
        public void Export()
        {
            switch(this.cb1.Text)
            {
                case "Fid1":
                    this._dtoAntiControl.dtoFid.FID1Used = true;
                    this._dtoAntiControl.dtoFid.FIDK1Used = false;
                    this._dtoAntiControl.dtoFid.InitTemp1 = Convert.ToSingle(this.txtInitTemp1.Text);
                    this._dtoAntiControl.dtoFid.AlertTemp1 = Convert.ToSingle(this.txtAlertTemp1.Text);
                    this._dtoAntiControl.dtoFid.MagnifyFactor1 = cmbMagnifyFactorFid1.SelectedIndex;
                    this._dtoAntiControl.dtoFid.Polarity1 = this.cbxPolarityFid1.Checked;
                    break;
                case "FidK1":
                    this._dtoAntiControl.dtoFid.FID1Used = false;
                    this._dtoAntiControl.dtoFid.FIDK1Used = true;
                    this._dtoAntiControl.dtoFid.InitTempK1 = Convert.ToSingle(this.txtInitTemp1.Text);
                    this._dtoAntiControl.dtoFid.AlertTempK1 = Convert.ToSingle(this.txtAlertTemp1.Text);
                    this._dtoAntiControl.dtoFid.MagnifyFactorK1 = cmbMagnifyFactorFid1.SelectedIndex;
                    this._dtoAntiControl.dtoFid.PolarityK1 = this.cbxPolarityFid1.Checked;
                    break;
            }
            switch (this.cb2.Text)
            {
                case "Fid2":
                    this._dtoAntiControl.dtoFid.FID2Used = true;
                    this._dtoAntiControl.dtoFid.FIDK2Used = false;
                    this._dtoAntiControl.dtoFid.InitTemp2 = Convert.ToSingle(this.txtInitTemp2.Text);
                    this._dtoAntiControl.dtoFid.AlertTemp2 = Convert.ToSingle(this.txtAlertTemp2.Text);
                    this._dtoAntiControl.dtoFid.MagnifyFactor2 = cmbMagnifyFactorFid2.SelectedIndex;
                    this._dtoAntiControl.dtoFid.Polarity2 = this.cbxPolarityFid2.Checked;
                    break;
                case "FidK2":
                    this._dtoAntiControl.dtoFid.FID2Used = false;
                    this._dtoAntiControl.dtoFid.FIDK2Used = true;
                    this._dtoAntiControl.dtoFid.InitTempK2 = Convert.ToSingle(this.txtInitTemp2.Text);
                    this._dtoAntiControl.dtoFid.AlertTempK2 = Convert.ToSingle(this.txtAlertTemp2.Text);
                    this._dtoAntiControl.dtoFid.MagnifyFactorK2 = cmbMagnifyFactorFid2.SelectedIndex;
                    this._dtoAntiControl.dtoFid.PolarityK2 = this.cbxPolarityFid2.Checked;
                    break;
            }
        }

        /// <summary>
        /// 装载控件的风格
        /// </summary>
        /// <param name="isReadOnly"></param>
        public void LoadControlStyle(bool isReadOnly)
        {
            this.txtInitTemp1.ReadOnly = isReadOnly;
            this.txtInitTemp2.ReadOnly = isReadOnly;
            this.txtAlertTemp1.ReadOnly = isReadOnly;
            this.txtAlertTemp2.ReadOnly = isReadOnly;

            this.cbxPolarityFid1.Enabled = !isReadOnly;
            this.cbxPolarityFid2.Enabled = !isReadOnly;

            this.txtInitTemp1.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtAlertTemp1.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.cmbMagnifyFactorFid1.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.cmbMagnifyFactorFid2.BackColor = isReadOnly ? Color.Beige : Color.White;

            this._bIsEdit = !isReadOnly;

        }

        /// <summary>
        /// 新建立反控的信息
        /// </summary>
        public void LoadNew()
        {

            if (null == this._dtoAntiControl.dtoFid)
            {
                this._dtoAntiControl.dtoFid = new FidDto();
            }

            this.cb1.SelectedIndex = 0;
            this.cb2.SelectedIndex = 0;

            this.txtInitTemp1.Text = DefaultFid.InitTemp1.ToString();
            this.txtAlertTemp1.Text = DefaultFid.AlertTemp1.ToString();

            this.txtInitTemp2.Text = DefaultFid.InitTemp2.ToString();
            this.txtAlertTemp2.Text = DefaultFid.AlertTemp2.ToString();

            this.cbxPolarityFid1.Checked = DefaultFid.Polarity1;
            this.cbxPolarityFid2.Checked = DefaultFid.Polarity2;

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

            this.cmbMagnifyFactorFid1.SelectedIndex = DefaultFid.MagnifyFactor1;
            this.cmbMagnifyFactorFid2.SelectedIndex = DefaultFid.MagnifyFactor2;

            this._dtoAntiControl.dtoFid.FID1Used = true;
            this._dtoAntiControl.dtoFid.FID2Used = true;
            this._dtoAntiControl.dtoFid.FIDK1Used = false;
            this._dtoAntiControl.dtoFid.FIDK2Used = false;
            this._dtoAntiControl.dtoFid.AlertTemp1 = DefaultFid.AlertTemp1;
            this._dtoAntiControl.dtoFid.AlertTemp2 = DefaultFid.AlertTemp2;
            this._dtoAntiControl.dtoFid.InitTemp1 = DefaultFid.InitTemp1;
            this._dtoAntiControl.dtoFid.InitTemp2 = DefaultFid.InitTemp2;
            this._dtoAntiControl.dtoFid.Polarity1 = DefaultFid.Polarity1;
            this._dtoAntiControl.dtoFid.Polarity2 = DefaultFid.Polarity2;
            this._dtoAntiControl.dtoFid.MagnifyFactor1 = DefaultFid.MagnifyFactor1;
            this._dtoAntiControl.dtoFid.MagnifyFactor2 = DefaultFid.MagnifyFactor2;

        }

        /// <summary>
        /// 编辑当前反控的信息
        /// </summary>
        public void LoadEdit()
        {

            
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


            switch ((Magnify)this._dtoAntiControl.dtoFid.MagnifyFactor1)
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

            switch ((Magnify)this._dtoAntiControl.dtoFid.MagnifyFactor2)
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

            if (null == this._dtoAntiControl.dtoFid)
            {
                return;
            }

            this.LoadViewOrSaveAs();
            
            this.cmbMagnifyFactorFid1.Items.Clear();
            this.cmbMagnifyFactorFid2.Items.Clear();

            switch ((Magnify)this._dtoAntiControl.dtoFid.MagnifyFactor1)
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

            switch ((Magnify)this._dtoAntiControl.dtoFid.MagnifyFactor2)
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
            this._dtoAntiControl.dtoFid.Polarity1 = this.cbxPolarityFid1.Checked;
        }

        /// <summary>
        /// 极性2按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxPolarityFid2_CheckedChanged(object sender, EventArgs e)
        {
            this.cbxPolarityFid2.Text = this.cbxPolarityFid2.Checked ? Polarity.Positive : Polarity.Nagative;
            this._dtoAntiControl.dtoFid.Polarity2 = this.cbxPolarityFid2.Checked;
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
            this._dtoAntiControl.dtoFid.MagnifyFactor1 = this.cmbMagnifyFactorFid1.SelectedIndex;
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
            this._dtoAntiControl.dtoFid.MagnifyFactor2 = this.cmbMagnifyFactorFid2.SelectedIndex;
        }

        /// <summary>
        /// FID1报警温度焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAlertTemp1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtAlertTemp1.Text))
            {
                MessageBox.Show("报警温度不能为空！", "报警温度");
                this.txtAlertTemp1.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtAlertTemp1.Text))
            {
                MessageBox.Show("报警温度不是数值！", "报警温度");
                this.txtAlertTemp1.Focus();
                return;
            }
            this._dtoAntiControl.dtoFid.AlertTemp1 = Convert.ToSingle(this.txtAlertTemp1.Text);
        }

        /// <summary>
        /// FID1初   温焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInitTemp1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtInitTemp1.Text))
            {
                MessageBox.Show("初温不能为空！", "初   温");
                this.txtInitTemp1.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtInitTemp1.Text))
            {
                MessageBox.Show("初温不是数值！", "初   温");
                this.txtInitTemp1.Focus();
                return;
            }
            this._dtoAntiControl.dtoFid.InitTemp1 = Convert.ToSingle(this.txtInitTemp1.Text);
        }

        /// <summary>
        /// FID2报警温度焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAlertTemp2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtAlertTemp2.Text))
            {
                MessageBox.Show("报警温度不能为空！", "报警温度");
                this.txtAlertTemp2.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtAlertTemp2.Text))
            {
                MessageBox.Show("报警温度不是数值！", "报警温度");
                this.txtAlertTemp2.Focus();
                return;
            }
            this._dtoAntiControl.dtoFid.AlertTemp2 = Convert.ToSingle(this.txtAlertTemp2.Text);
        }

        /// <summary>
        /// FID2初   温焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInitTemp2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtInitTemp2.Text))
            {
                MessageBox.Show("初温不能为空！", "初   温");
                this.txtInitTemp2.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtInitTemp2.Text))
            {
                MessageBox.Show("初温不是数值！", "初   温");
                this.txtInitTemp2.Focus();
                return;
            }
            this._dtoAntiControl.dtoFid.InitTemp2 = Convert.ToSingle(this.txtInitTemp2.Text);
        }


        #endregion


    }
}
