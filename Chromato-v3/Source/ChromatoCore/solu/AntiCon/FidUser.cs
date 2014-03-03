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
            this.txtInitTemp1.TextChanged += new System.EventHandler(this.txtInitTemp1_TextChanged);
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

            this.cmbMagnifyFactorFid1.SelectedIndex = 0;

        }

        /// <summary>
        /// 查看或者复制
        /// </summary>
        public void LoadViewOrSaveAs()
        {
            this.txtInitTemp1.Text = _dtoAntiControl.dtoFid.InitTemp1.ToString();
            this.txtAlertTemp1.Text = _dtoAntiControl.dtoFid.AlertTemp1.ToString();

            gb1.Visible = false;
            gb2.Visible = false;
            gb3.Visible = false;

            int n = 1;
            if (_dtoAntiControl.dtoNetworkBoard.FID1Used == true)
            {
                switch (n)
                {
                    case 1:
                        gb1.Visible = true;
                        n++;
                        this.gb1.Text = "FID1";
                        this.cmbMagnifyFactorFid1.SelectedIndex = _dtoAntiControl.dtoFid.MagnifyFactor1;
                        this.cbxPolarityFid1.Checked = _dtoAntiControl.dtoFid.Polarity1;
                        break;
                    case 2:
                        gb2.Visible = true;
                        n++;
                        this.gb2.Text = "FID1";
                        this.cmbMagnifyFactorFid2.SelectedIndex = _dtoAntiControl.dtoFid.MagnifyFactor1;
                        this.cbxPolarityFid2.Checked = _dtoAntiControl.dtoFid.Polarity1;
                        break;
                    case 3:
                        gb3.Visible = true;
                        n++;
                        this.gb3.Text = "FID1";
                        this.cmbMagnifyFactorFid3.SelectedIndex = _dtoAntiControl.dtoFid.MagnifyFactor1;
                        this.cbxPolarityFid3.Checked = _dtoAntiControl.dtoFid.Polarity1;
                        break;
                }
            }
            if (_dtoAntiControl.dtoNetworkBoard.FID2Used == true)
            {
                switch (n)
                {
                    case 1:
                        gb1.Visible = true;
                        n++;
                        this.gb1.Text = "FID2";
                        this.cmbMagnifyFactorFid1.SelectedIndex = _dtoAntiControl.dtoFid.MagnifyFactor2;
                        this.cbxPolarityFid1.Checked = _dtoAntiControl.dtoFid.Polarity2;
                        break;
                    case 2:
                        gb1.Visible = true;
                        n++;
                        this.gb2.Text = "FID2";
                        this.cmbMagnifyFactorFid2.SelectedIndex = _dtoAntiControl.dtoFid.MagnifyFactor2;
                        this.cbxPolarityFid2.Checked = _dtoAntiControl.dtoFid.Polarity2;
                        break;
                    case 3:
                        gb1.Visible = true;
                        n++;
                        this.gb3.Text = "FID2";
                        this.cmbMagnifyFactorFid3.SelectedIndex = _dtoAntiControl.dtoFid.MagnifyFactor2;
                        this.cbxPolarityFid3.Checked = _dtoAntiControl.dtoFid.Polarity2;
                        break;
                }
            }
            if (_dtoAntiControl.dtoNetworkBoard.FIDK1Used == true)
            {
                switch (n)
                {
                    case 1:
                        gb1.Visible = true;
                        n++;
                        this.gb1.Text = "FIDK1";
                        this.cmbMagnifyFactorFid1.SelectedIndex = _dtoAntiControl.dtoFid.MagnifyFactorK1;
                        this.cbxPolarityFid1.Checked = _dtoAntiControl.dtoFid.PolarityK1;
                        break;
                    case 2:
                        gb1.Visible = true;
                        n++;
                        this.gb2.Text = "FIDK1";
                        this.cmbMagnifyFactorFid2.SelectedIndex = _dtoAntiControl.dtoFid.MagnifyFactorK1;
                        this.cbxPolarityFid2.Checked = _dtoAntiControl.dtoFid.PolarityK1;
                        break;
                    case 3:
                        gb1.Visible = true;
                        n++;
                        this.gb3.Text = "FIDK1";
                        this.cmbMagnifyFactorFid3.SelectedIndex = _dtoAntiControl.dtoFid.MagnifyFactorK1;
                        this.cbxPolarityFid3.Checked = _dtoAntiControl.dtoFid.PolarityK1;
                        break;
                }
            }
            if (_dtoAntiControl.dtoNetworkBoard.FIDK2Used == true)
            {
                switch (n)
                {
                    case 1:
                        gb1.Visible = true;
                        n++;
                        this.gb1.Text = "FIDK2";
                        this.cmbMagnifyFactorFid1.SelectedIndex = _dtoAntiControl.dtoFid.MagnifyFactorK2;
                        this.cbxPolarityFid1.Checked = _dtoAntiControl.dtoFid.PolarityK2;
                        break;
                    case 2:
                        gb1.Visible = true;
                        n++;
                        this.gb2.Text = "FIDK2";
                        this.cmbMagnifyFactorFid2.SelectedIndex = _dtoAntiControl.dtoFid.MagnifyFactorK2;
                        this.cbxPolarityFid2.Checked = _dtoAntiControl.dtoFid.PolarityK2;
                        break;
                    case 3:
                        gb1.Visible = true;
                        n++;
                        this.gb3.Text = "FIDK2";
                        this.cmbMagnifyFactorFid3.SelectedIndex = _dtoAntiControl.dtoFid.MagnifyFactorK2;
                        this.cbxPolarityFid3.Checked = _dtoAntiControl.dtoFid.PolarityK2;
                        break;
                }
            }
            if (_dtoAntiControl.dtoNetworkBoard.FIDK2Used == true)
            {
                switch (n)
                {
                    case 1:
                        gb1.Visible = true;
                        n++;
                        this.gb1.Text = "FIDK2";
                        this.cmbMagnifyFactorFid1.SelectedIndex = _dtoAntiControl.dtoFid.MagnifyFactorK2;
                        this.cbxPolarityFid1.Checked = _dtoAntiControl.dtoFid.PolarityK2;
                        break;
                    case 2:
                        gb1.Visible = true;
                        n++;
                        this.gb2.Text = "FIDK2";
                        this.cmbMagnifyFactorFid2.SelectedIndex = _dtoAntiControl.dtoFid.MagnifyFactorK2;
                        this.cbxPolarityFid2.Checked = _dtoAntiControl.dtoFid.PolarityK2;
                        break;
                    case 3:
                        gb1.Visible = true;
                        n++;
                        this.gb3.Text = "FIDK2";
                        this.cmbMagnifyFactorFid3.SelectedIndex = _dtoAntiControl.dtoFid.MagnifyFactorK2;
                        this.cbxPolarityFid3.Checked = _dtoAntiControl.dtoFid.PolarityK2;
                        break;
                }
            }
            if (_dtoAntiControl.dtoNetworkBoard.ECDUsed == true)
            {
                switch (n)
                {
                    case 1:
                        gb1.Visible = true;
                        n++;
                        this.gb1.Text = "ECD";
                        this.cmbMagnifyFactorFid1.SelectedIndex = _dtoAntiControl.dtoEcd.MagnifyFactor;
                        this.cbxPolarityFid1.Checked = _dtoAntiControl.dtoEcd.Polarity;
                        break;
                    case 2:
                        gb1.Visible = true;
                        n++;
                        this.gb2.Text = "ECD";
                        this.cmbMagnifyFactorFid2.SelectedIndex = _dtoAntiControl.dtoEcd.MagnifyFactor;
                        this.cbxPolarityFid2.Checked = _dtoAntiControl.dtoEcd.Polarity;
                        break;
                    case 3:
                        gb1.Visible = true;
                        n++;
                        this.gb3.Text = "ECD";
                        this.cmbMagnifyFactorFid3.SelectedIndex = _dtoAntiControl.dtoEcd.MagnifyFactor;
                        this.cbxPolarityFid3.Checked = _dtoAntiControl.dtoEcd.Polarity;
                        break;
                }
            }
            if (_dtoAntiControl.dtoNetworkBoard.FPDUsed == true)
            {
                switch (n)
                {
                    case 1:
                        gb1.Visible = true;
                        n++;
                        this.gb1.Text = "FPD";
                        this.cmbMagnifyFactorFid1.SelectedIndex = _dtoAntiControl.dtoFpd.MagnifyFactor;
                        this.cbxPolarityFid1.Checked = _dtoAntiControl.dtoFpd.Polarity;
                        break;
                    case 2:
                        gb1.Visible = true;
                        n++;
                        this.gb2.Text = "FPD";
                        this.cmbMagnifyFactorFid2.SelectedIndex = _dtoAntiControl.dtoFpd.MagnifyFactor;
                        this.cbxPolarityFid2.Checked = _dtoAntiControl.dtoFpd.Polarity;
                        break;
                    case 3:
                        gb1.Visible = true;
                        n++;
                        this.gb3.Text = "FPD";
                        this.cmbMagnifyFactorFid3.SelectedIndex = _dtoAntiControl.dtoFpd.MagnifyFactor;
                        this.cbxPolarityFid3.Checked = _dtoAntiControl.dtoFpd.Polarity;
                        break;
                }
            }
        }

        /// <summary>
        /// 导出数据到缓冲区
        /// </summary>
        public void Export()
        {
            switch(this.gb1.Text)
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
                case "Fid2":
                    this._dtoAntiControl.dtoFid.FID2Used = true;
                    this._dtoAntiControl.dtoFid.FIDK2Used = false;
                    this._dtoAntiControl.dtoFid.InitTemp2 = Convert.ToSingle(this.txtInitTemp1.Text);
                    this._dtoAntiControl.dtoFid.AlertTemp2 = Convert.ToSingle(this.txtAlertTemp1.Text);
                    this._dtoAntiControl.dtoFid.MagnifyFactor2 = cmbMagnifyFactorFid1.SelectedIndex;
                    this._dtoAntiControl.dtoFid.Polarity2 = this.cbxPolarityFid1.Checked;
                    break;
                case "FidK2":
                    this._dtoAntiControl.dtoFid.FID2Used = false;
                    this._dtoAntiControl.dtoFid.FIDK2Used = true;
                    this._dtoAntiControl.dtoFid.InitTempK2 = Convert.ToSingle(this.txtInitTemp1.Text);
                    this._dtoAntiControl.dtoFid.AlertTempK2 = Convert.ToSingle(this.txtAlertTemp1.Text);
                    this._dtoAntiControl.dtoFid.MagnifyFactorK2 = cmbMagnifyFactorFid1.SelectedIndex;
                    this._dtoAntiControl.dtoFid.PolarityK2 = this.cbxPolarityFid1.Checked;
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
            this.txtAlertTemp1.ReadOnly = isReadOnly;

            this.cbxPolarityFid1.Enabled = !isReadOnly;

            this.txtInitTemp1.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtAlertTemp1.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.cmbMagnifyFactorFid1.BackColor = isReadOnly ? Color.Beige : Color.White;

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

            this.gb1.Text = "FID1";

            this.txtInitTemp1.Text = DefaultFid.InitTemp1.ToString();
            this.txtAlertTemp1.Text = DefaultFid.AlertTemp1.ToString();

            this.cbxPolarityFid1.Checked = DefaultFid.Polarity1;

            this.cbxPolarityFid1.Text = this.cbxPolarityFid1.Checked ? Polarity.Positive : Polarity.Nagative;

            this.cmbMagnifyFactorFid1.Items.Clear();

            this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Zero));
            this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.One));
            this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Two));
            this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Three));

            this.cmbMagnifyFactorFid1.SelectedIndex = DefaultFid.MagnifyFactor1;

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
            
            this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Zero));
            this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.One));
            this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Two));
            this.cmbMagnifyFactorFid1.Items.Add(EnumDescription.GetFieldText(Magnify.Three));


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
            this.cmbMagnifyFactorFid1.SelectedIndex = 0;

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

        #endregion


    }
}
