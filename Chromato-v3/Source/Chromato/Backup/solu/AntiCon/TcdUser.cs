/*-----------------------------------------------------------------------------
//  FILE NAME       : TcdUser.cs
//  FUNCTION        : 反控方法TCD
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
    /// 反控方法TCD
    /// </summary>
    public partial class TcdUser : UserControl
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
        public TcdUser(AntiControlDto dto)
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
            this.txtAlertTemp1.TextChanged += new System.EventHandler(this.txtAlertTemp1_TextChanged);
            this.txtInitTemp1.TextChanged += new System.EventHandler(this.txtInitTemp1_TextChanged);
            this.txtAlertTemp2.TextChanged += new System.EventHandler(this.txtAlertTemp2_TextChanged);
            this.txtInitTemp2.TextChanged += new System.EventHandler(this.txtInitTemp2_TextChanged);
            this.txtCurrentTcd1.TextChanged += new System.EventHandler(this.txtCurrentTcd1_TextChanged);
            this.txtCurrentTcd2.TextChanged += new System.EventHandler(this.txtCurrentTcd2_TextChanged);
            this.txtAlertTcd1.TextChanged += new System.EventHandler(this.txtAlertTcd1_TextChanged);
            this.txtAlertTcd2.TextChanged += new System.EventHandler(this.txtAlertTcd2_TextChanged);
        }
        #endregion


        #region 方法

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        public void LoadView(int antiControlID)
        {
            this.LoadViewOrSaveAs();
            this.LoadControlStyle(true);
        }

        /// <summary>
        /// 查看或者复制
        /// </summary>
        public void LoadViewOrSaveAs()
        {
            if (null == this._dtoAntiControl.dtoTcd)
            {
                return;
            }
            this.txtInitTemp1.Text = this._dtoAntiControl.dtoTcd.InitTemp1.ToString();
            this.txtAlertTemp1.Text = this._dtoAntiControl.dtoTcd.AlertTemp1.ToString();

            this.txtInitTemp2.Text = this._dtoAntiControl.dtoTcd.InitTemp2.ToString();
            this.txtAlertTemp2.Text = this._dtoAntiControl.dtoTcd.AlertTemp2.ToString();

            this.txtCurrentTcd1.Text = this._dtoAntiControl.dtoTcd.CurrentOne.ToString();
            this.txtCurrentTcd2.Text = this._dtoAntiControl.dtoTcd.CurrentTwo.ToString();

            this.cbxPolarityTcd1.Checked = this._dtoAntiControl.dtoTcd.PolarityOne;
            this.cbxPolarityTcd2.Checked = this._dtoAntiControl.dtoTcd.PolarityTwo;

            this.cbxPolarityTcd1.Text = this.cbxPolarityTcd1.Checked ? Polarity.Positive : Polarity.Nagative;
            this.cbxPolarityTcd2.Text = this.cbxPolarityTcd2.Checked ? Polarity.Positive : Polarity.Nagative;
        }

        /// <summary>
        /// 装载控件的风格
        /// </summary>
        /// <param name="isReadOnly"></param>
        public void LoadControlStyle(bool isReadOnly)
        {
            this.txtInitTemp1.ReadOnly = isReadOnly;
            this.txtAlertTemp1.ReadOnly = isReadOnly;
            
            this.txtInitTemp2.ReadOnly = isReadOnly;
            this.txtAlertTemp2.ReadOnly = isReadOnly;
            
            this.txtCurrentTcd1.ReadOnly = isReadOnly;
            this.txtCurrentTcd2.ReadOnly = isReadOnly;

            this.cbxPolarityTcd1.Enabled = !isReadOnly;
            this.cbxPolarityTcd2.Enabled = !isReadOnly;

            this.txtInitTemp1.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtAlertTemp1.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.txtInitTemp2.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtAlertTemp2.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.txtCurrentTcd1.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtCurrentTcd2.BackColor = isReadOnly ? Color.Beige : Color.White;
        }

        /// <summary>
        /// 新建立反控的信息
        /// </summary>
        public void LoadNew()
        {

            this.LoadControlStyle(false);

            if (null == this._dtoAntiControl.dtoTcd)
            {
                this._dtoAntiControl.dtoTcd = new TcdDto();
            }

            this.txtInitTemp1.Text = DefaultTcd.InitTemp1.ToString();
            this.txtAlertTemp1.Text = DefaultTcd.AlertTemp1.ToString();
            this.txtInitTemp2.Text = DefaultTcd.InitTemp2.ToString();
            this.txtAlertTemp2.Text = DefaultTcd.AlertTemp2.ToString();

            this.txtCurrentTcd1.Text = DefaultTcd.CurrentOne.ToString();
            this.txtCurrentTcd2.Text = DefaultTcd.CurrentTwo.ToString();
            this.cbxPolarityTcd1.Checked = DefaultTcd.PolarityOne;
            this.cbxPolarityTcd2.Checked = DefaultTcd.PolarityTwo;

            this._dtoAntiControl.dtoTcd.InitTemp1 = DefaultTcd.InitTemp1;
            this._dtoAntiControl.dtoTcd.AlertTemp1 = DefaultTcd.AlertTemp1;
            this._dtoAntiControl.dtoTcd.InitTemp2 = DefaultTcd.InitTemp2;
            this._dtoAntiControl.dtoTcd.AlertTemp2 = DefaultTcd.AlertTemp2;
            
            this._dtoAntiControl.dtoTcd.CurrentOne = DefaultTcd.CurrentOne;
            this._dtoAntiControl.dtoTcd.CurrentTwo = DefaultTcd.CurrentTwo;
            this._dtoAntiControl.dtoTcd.PolarityOne = DefaultTcd.PolarityOne;
            this._dtoAntiControl.dtoTcd.PolarityTwo = DefaultTcd.PolarityTwo;
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
        /// 极性1变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxPolarityTcd1_CheckedChanged(object sender, EventArgs e)
        {
            this.cbxPolarityTcd1.Text = this.cbxPolarityTcd1.Checked ? Polarity.Positive : Polarity.Nagative;
            this._dtoAntiControl.dtoTcd.PolarityOne = this.cbxPolarityTcd1.Checked;
        }

        /// <summary>
        /// 极性2变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxPolarityTcd2_CheckedChanged(object sender, EventArgs e)
        {
            this.cbxPolarityTcd2.Text = this.cbxPolarityTcd2.Checked ? Polarity.Positive : Polarity.Nagative;
            this._dtoAntiControl.dtoTcd.PolarityTwo = this.cbxPolarityTcd2.Checked;
        }

        /// <summary>
        /// 启动关闭1命令变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxCmdTcd1_CheckedChanged(object sender, EventArgs e)
        {
            this.cbxCmdTcd1.Text = this.cbxCmdTcd1.Checked ? TcdOnOff.On : TcdOnOff.Off;
            this._dtoAntiControl.dtoTcd.OnOffOne = this.cbxCmdTcd1.Checked;
        }

        /// <summary>
        /// 启动关闭2命令变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxCmdTcd2_CheckedChanged(object sender, EventArgs e)
        {
            this.cbxCmdTcd2.Text = this.cbxCmdTcd2.Checked ? TcdOnOff.On : TcdOnOff.Off;
            this._dtoAntiControl.dtoTcd.OnOffTwo = this.cbxCmdTcd2.Checked;
        }

        /// <summary>
        /// 报警温度1焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAlertTemp1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtAlertTemp1.Text))
            {
                MessageBox.Show("报警温度1不能为空！", "报警温度");
                this.txtAlertTemp1.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtAlertTemp1.Text))
            {
                MessageBox.Show("报警温度1不是数值！", "报警温度");
                this.txtAlertTemp1.Focus();
                return;
            }
            this._dtoAntiControl.dtoTcd.AlertTemp1 = Convert.ToSingle(this.txtAlertTemp1.Text);
        }

        /// <summary>
        /// 初   温焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInitTemp1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtInitTemp1.Text))
            {
                MessageBox.Show("初温1不能为空！", "初   温");
                this.txtInitTemp1.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtInitTemp1.Text))
            {
                MessageBox.Show("初温1不是数值！", "初   温");
                this.txtInitTemp1.Focus();
                return;
            }
            this._dtoAntiControl.dtoTcd.InitTemp1 = Convert.ToSingle(this.txtInitTemp1.Text);
        }

        /// <summary>
        /// 报警温度2焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAlertTemp2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtAlertTemp2.Text))
            {
                MessageBox.Show("报警温度2不能为空！", "报警温度");
                this.txtAlertTemp2.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtAlertTemp2.Text))
            {
                MessageBox.Show("报警温度2不是数值！", "报警温度");
                this.txtAlertTemp2.Focus();
                return;
            }
            this._dtoAntiControl.dtoTcd.AlertTemp2 = Convert.ToSingle(this.txtAlertTemp2.Text);
        }

        /// <summary>
        /// 初   温2焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInitTemp2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtInitTemp2.Text))
            {
                MessageBox.Show("初温2不能为空！", "初   温");
                this.txtInitTemp2.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtInitTemp2.Text))
            {
                MessageBox.Show("初温2不是数值！", "初   温");
                this.txtInitTemp2.Focus();
                return;
            }
            this._dtoAntiControl.dtoTcd.InitTemp2 = Convert.ToSingle(this.txtInitTemp2.Text);
        }

        /// <summary>
        /// TCD1 电流值焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCurrentTcd1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtCurrentTcd1.Text))
            {
                MessageBox.Show("TCD1 电流值不能为空！", "TCD1 电流值");
                this.txtCurrentTcd1.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtCurrentTcd1.Text))
            {
                MessageBox.Show("TCD1 电流值不是数值！", "TCD1 电流值");
                this.txtCurrentTcd1.Focus();
                return;
            }
            this._dtoAntiControl.dtoTcd.CurrentOne = Convert.ToSingle(this.txtCurrentTcd1.Text);
        }

        /// <summary>
        /// TCD2 电流值焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCurrentTcd2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtCurrentTcd2.Text))
            {
                MessageBox.Show("TCD2 电流值不能为空！", "TCD2 电流值");
                this.txtCurrentTcd2.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtCurrentTcd2.Text))
            {
                MessageBox.Show("TCD2 电流值不是数值！", "TCD2 电流值");
                this.txtCurrentTcd2.Focus();
                return;
            }
            this._dtoAntiControl.dtoTcd.CurrentTwo = Convert.ToSingle(this.txtCurrentTcd2.Text);
        }

        /// <summary>
        /// TCD1 报警数据焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAlertTcd1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtAlertTcd1.Text))
            {
                MessageBox.Show("TCD1 报警数据不能为空！", "TCD1 报警数据");
                this.txtAlertTcd1.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtAlertTcd1.Text))
            {
                MessageBox.Show("TCD1 报警数据不是数值！", "TCD1 报警数据");
                this.txtAlertTcd1.Focus();
                return;
            }
            this._dtoAntiControl.dtoTcd.AlertOne = Convert.ToSingle(this.txtAlertTcd1.Text);
        }

        /// <summary>
        /// TCD2 报警数据焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAlertTcd2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtAlertTcd2.Text))
            {
                MessageBox.Show("TCD2 报警数据不能为空！", "TCD2 报警数据");
                this.txtAlertTcd2.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtAlertTcd2.Text))
            {
                MessageBox.Show("TCD2 报警数据不是数值！", "TCD2 报警数据");
                this.txtAlertTcd2.Focus();
                return;
            }
            this._dtoAntiControl.dtoTcd.AlertTwo = Convert.ToSingle(this.txtAlertTcd2.Text);
        }

        #endregion



    }
}
