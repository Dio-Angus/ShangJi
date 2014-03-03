/*-----------------------------------------------------------------------------
//  FILE NAME       : AuxUser.cs
//  FUNCTION        : 反控方法AUX
//  AUTHOR          : 李锋(2009/07/01)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoTool.ini;
using ChromatoTool.util;

namespace ChromatoCore.solu.AntiCon
{
    /// <summary>
    /// 反控方法AUX
    /// </summary>
    public partial class AuxUser : UserControl
    {


        #region 变量

        /// <summary>
        /// 分析方法dto
        /// </summary>
        private AntiControlDto _dtoAntiControl = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public AuxUser(AntiControlDto dto)
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
            this.txtAlertTempAux1.TextChanged += new System.EventHandler(this.txtAlertTempAux1_TextChanged);
            this.txtAlertTempAux2.TextChanged += new System.EventHandler(this.txtAlertTempAux2_TextChanged);

            this.txtInitTempAux1.TextChanged += new System.EventHandler(this.txtInitTempAux1_TextChanged);
            this.txtInitTempAux2.TextChanged += new System.EventHandler(this.txtInitTempAux2_TextChanged);
        }
        #endregion


        #region 方法

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        public void LoadView(int antiControlID)
        {
            this.LoadViewOrSaveAs();
            //this.LoadControlStyle(true);
        }

        /// <summary>
        /// 查看或者复制
        /// </summary>
        public void LoadViewOrSaveAs()
        {
            if(null == this._dtoAntiControl.dtoAux)
            {
                return;
            }

            switch (this._dtoAntiControl.dtoAux.UserIndex.ToString())
            {
                case "0":
                    this.cbAux1.Checked = true;
                    this.cbAux2.Checked = true;

                    txtInitTempAux1.Enabled = true;
                    txtAlertTempAux1.Enabled = true;

                    txtInitTempAux1.Enabled = true;
                    txtAlertTempAux1.Enabled = true;
                    break;
                case "1":
                    this.cbAux1.Checked = true;
                    this.cbAux2.Checked = false;

                    txtInitTempAux1.Enabled = true;
                    txtAlertTempAux1.Enabled = true;

                    txtInitTempAux1.Enabled = false;
                    txtAlertTempAux1.Enabled = false;
                    break;
                case "2":
                    this.cbAux1.Checked = false;
                    this.cbAux2.Checked = true;

                    txtInitTempAux1.Enabled = false;
                    txtAlertTempAux1.Enabled = false;

                    txtInitTempAux1.Enabled = true;
                    txtAlertTempAux1.Enabled = true;
                    break;
                default:
                    break;
            }

            this.txtInitTempAux1.Text = this._dtoAntiControl.dtoAux.InitTempAux1.ToString();
            this.txtAlertTempAux1.Text = this._dtoAntiControl.dtoAux.AlertTempAux1.ToString();

            this.txtInitTempAux2.Text = this._dtoAntiControl.dtoAux.InitTempAux2.ToString();
            this.txtAlertTempAux2.Text = this._dtoAntiControl.dtoAux.AlertTempAux2.ToString();

            //当Tcd2存在时，Aux2被其占用
            if (this._dtoAntiControl.dtoNetworkBoard.TCD2Used==true)
            {
                this.cbAux2.Checked = true;
                this.cbAux2.Enabled = false;
                this.txtInitTempAux2.Enabled = false;
                this.txtAlertTempAux2.Enabled = false;
                this.txtInitTempAux2.Text = this._dtoAntiControl.dtoTcd.InitTemp2.ToString();
                this.txtAlertTempAux2.Text = this._dtoAntiControl.dtoTcd.AlertTemp2.ToString();
            }
        }

        /// <summary>
        /// 装载控件的风格
        /// </summary>
        /// <param name="isReadOnly"></param>
        public void LoadControlStyle(bool isReadOnly)
        {
            this.txtInitTempAux1.ReadOnly = isReadOnly;
            this.txtAlertTempAux1.ReadOnly = isReadOnly;
            this.txtInitTempAux2.ReadOnly = isReadOnly;
            this.txtAlertTempAux2.ReadOnly = isReadOnly;

            this.txtInitTempAux1.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtAlertTempAux1.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtInitTempAux2.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtAlertTempAux2.BackColor = isReadOnly ? Color.Beige : Color.White;
        }

        /// <summary>
        /// 导出到缓冲区
        /// </summary>
        public void Export()
        {
            if (this.cbAux1.Checked == true && this.cbAux2.Checked == true)
            {
                _dtoAntiControl.dtoAux.UserIndex = 0;
            }
            else if (this.cbAux1.Checked == true && this.cbAux2.Checked == false)
            {
                _dtoAntiControl.dtoAux.UserIndex = 1;
            }
            else if (this.cbAux1.Checked == false && this.cbAux2.Checked == true)
            {
                _dtoAntiControl.dtoAux.UserIndex = 2;
            }
            _dtoAntiControl.dtoAux.InitTempAux1 = Convert.ToSingle(this.txtInitTempAux1.Text);
            _dtoAntiControl.dtoAux.InitTempAux2 = Convert.ToSingle(this.txtInitTempAux2.Text);
            _dtoAntiControl.dtoAux.AlertTempAux1= Convert.ToSingle(this.txtAlertTempAux1.Text);
            _dtoAntiControl.dtoAux.AlertTempAux2 = Convert.ToSingle(this.txtAlertTempAux2.Text);

        }

        /// <summary>
        /// 新建立反控的信息
        /// </summary>
        public void LoadNew()
        {

            this.LoadControlStyle(false);

            if (null == this._dtoAntiControl.dtoAux)
            {
                this._dtoAntiControl.dtoAux = new AuxDto();
            }

            this._dtoAntiControl.dtoAux.UserIndex = DefaultAux.UserIndex;

            this._dtoAntiControl.dtoAux.AlertTempAux1 = DefaultAux.AlertTempAux1;
            this._dtoAntiControl.dtoAux.AlertTempAux2 = DefaultAux.AlertTempAux2;
            this._dtoAntiControl.dtoAux.InitTempAux1 = DefaultAux.InitTempAux1;
            this._dtoAntiControl.dtoAux.InitTempAux2 = DefaultAux.InitTempAux2;

            this.cbAux1.Checked = true;
            this.cbAux2.Checked = true;

            this.txtAlertTempAux1.Text = DefaultAux.AlertTempAux1.ToString();
            this.txtInitTempAux1.Text = DefaultAux.InitTempAux1.ToString();

            this.txtAlertTempAux2.Text = DefaultAux.AlertTempAux2.ToString();
            this.txtInitTempAux2.Text = DefaultAux.InitTempAux2.ToString();

        }

        /// <summary>
        /// 编辑当前反控的信息
        /// </summary>
        public void LoadEdit()
        {
            this.LoadViewOrSaveAs();
            this.LoadControlStyle(false);
        }

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        public void LoadSaveAs()
        {
            this.LoadViewOrSaveAs();
            this.LoadControlStyle(true);
        }

        #endregion


        #region 事件

        /// <summary>
        /// Aux1 报警温度焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAlertTempAux1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtAlertTempAux1.Text))
            {
                MessageBox.Show("Aux1 报警温度不能为空！", "Aux1 报警温度");
                this.txtAlertTempAux1.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtAlertTempAux1.Text))
            {
                MessageBox.Show("Aux1 报警温度不是数值！", "Aux1 报警温度");
                this.txtAlertTempAux1.Focus();
                return;
            }
            this._dtoAntiControl.dtoAux.AlertTempAux1 = Convert.ToSingle(this.txtAlertTempAux1.Text);
        }

        /// <summary>
        /// Aux2 报警温度焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAlertTempAux2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtAlertTempAux2.Text))
            {
                MessageBox.Show("Aux2 报警温度不能为空！", "Aux2 报警温度");
                this.txtAlertTempAux2.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtAlertTempAux2.Text))
            {
                MessageBox.Show("Aux2 报警温度不是数值！", "Aux2 报警温度");
                this.txtAlertTempAux2.Focus();
                return;
            }
            this._dtoAntiControl.dtoAux.AlertTempAux2 = Convert.ToSingle(this.txtAlertTempAux2.Text);
        }

        /// <summary>
        /// Aux1 初温焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInitTempAux1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtInitTempAux1.Text))
            {
                MessageBox.Show("Aux1 初温不能为空！", "Aux1 初温");
                this.txtInitTempAux1.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtInitTempAux1.Text))
            {
                MessageBox.Show("Aux1 初温不是数值！", "Aux1 初温");
                this.txtInitTempAux1.Focus();
                return;
            }
            this._dtoAntiControl.dtoAux.InitTempAux1 = Convert.ToSingle(this.txtInitTempAux1.Text);
        }

        /// <summary>
        /// Aux2 初温焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInitTempAux2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtInitTempAux2.Text))
            {
                MessageBox.Show("Aux2 初温不能为空！", "Aux2 初温");
                this.txtInitTempAux2.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtInitTempAux2.Text))
            {
                MessageBox.Show("Aux2 初温不是数值！", "Aux2 初温");
                this.txtInitTempAux2.Focus();
                return;
            }
            this._dtoAntiControl.dtoAux.InitTempAux2 = Convert.ToSingle(this.txtInitTempAux2.Text);
        }
        
        /// <summary>
        /// Aux1选择框勾选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAux1_Click(object sender, EventArgs e)
        {
            if (cbAux1.Checked == false && cbAux2.Checked == false)
            {
                cbAux1.Checked = true;

                txtInitTempAux1.Enabled = true;
                txtAlertTempAux1.Enabled = true;

                txtInitTempAux2.Enabled = false;
                txtAlertTempAux2.Enabled = false;
            }
            else if (cbAux1.Checked == true && cbAux2.Checked == false)
            {
                txtInitTempAux1.Enabled = true;
                txtAlertTempAux1.Enabled = true;

                txtInitTempAux2.Enabled = false;
                txtAlertTempAux2.Enabled = false;
            }
            else if (cbAux1.Checked == false && cbAux2.Checked == true)
            {
                txtInitTempAux1.Enabled = false;
                txtAlertTempAux1.Enabled = false;

                txtInitTempAux2.Enabled = true;
                txtAlertTempAux2.Enabled = true;
            }
            else if (cbAux1.Checked == true && cbAux2.Checked == true)
            {
                txtInitTempAux1.Enabled = true;
                txtAlertTempAux1.Enabled = true;

                txtInitTempAux2.Enabled = true;
                txtAlertTempAux2.Enabled = true;
            }
        }

        /// <summary>
        /// Aux2选择框勾选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAux2_Click(object sender, EventArgs e)
        {
            if (cbAux1.Checked == false && cbAux2.Checked == false)
            {
                cbAux2.Checked = true;

                txtInitTempAux1.Enabled = false;
                txtAlertTempAux1.Enabled = false;

                txtInitTempAux2.Enabled = true;
                txtAlertTempAux2.Enabled = true;
            }
            else if (cbAux1.Checked == true && cbAux2.Checked == false)
            {
                txtInitTempAux1.Enabled = true;
                txtAlertTempAux1.Enabled = true;

                txtInitTempAux2.Enabled = false;
                txtAlertTempAux2.Enabled = false;
            }
            else if (cbAux1.Checked == false && cbAux2.Checked == true)
            {
                txtInitTempAux1.Enabled = false;
                txtAlertTempAux1.Enabled = false;

                txtInitTempAux2.Enabled = true;
                txtAlertTempAux2.Enabled = true;
            }
            else if (cbAux1.Checked == true && cbAux2.Checked == true)
            {
                txtInitTempAux1.Enabled = true;
                txtAlertTempAux1.Enabled = true;

                txtInitTempAux2.Enabled = true;
                txtAlertTempAux2.Enabled = true;
            }
        }
        #endregion

    }
}
