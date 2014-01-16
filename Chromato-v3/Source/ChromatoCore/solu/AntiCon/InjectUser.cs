/*-----------------------------------------------------------------------------
//  FILE NAME       : InjectUser.cs
//  FUNCTION        : 进样口参数视图
//  AUTHOR          : 李锋(2009/06/30)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoTool.ini;
using System;
using ChromatoTool.util;

namespace ChromatoCore.solu.AntiCon
{
    /// <summary>
    /// 进样口参数视图
    /// </summary>
    public partial class InjectUser : UserControl
    {


        #region 变量

        /// <summary>
        /// 分析方法dto
        /// </summary>
        private AntiControlDto _dtoAntiControl = null;

        /// <summary>
        /// 针对ComboBox类型控件设置的是否已经完成初始化
        /// </summary>
        private bool _isLoadUi = false;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public InjectUser(AntiControlDto dto)
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
            this.txtAlertTemp.TextChanged += new System.EventHandler(this.txtAlertTemp_TextChanged);
            this.txtInitTemp.TextChanged += new System.EventHandler(this.txtInitTemp_TextChanged);
            this.txtInjectTime1.TextChanged += new System.EventHandler(this.txtInjectTime1_TextChanged);
            this.txtInjectTime2.TextChanged += new System.EventHandler(this.txtInjectTime2_TextChanged);
            this.txtInjectTime3.TextChanged += new System.EventHandler(this.txtInjectTime3_TextChanged);

            this.rbFill1.CheckedChanged += new System.EventHandler(this.rbFill1_CheckedChanged);
            this.rbCapillary1.CheckedChanged += new System.EventHandler(this.rbCapillary1_CheckedChanged);

            this.rbFill2.CheckedChanged += new System.EventHandler(this.rbFill2_CheckedChanged);
            this.rbCapillary2.CheckedChanged += new System.EventHandler(this.rbCapillary2_CheckedChanged);

            this.rbFill3.CheckedChanged += new System.EventHandler(this.rbFill3_CheckedChanged);
            this.rbCapillary3.CheckedChanged += new System.EventHandler(this.rbCapillary3_CheckedChanged);

            this.cmbInjectMode1.SelectedIndexChanged += new System.EventHandler(this.cmbInjectMode1_SelectedIndexChanged);
            this.cmbInjectMode2.SelectedIndexChanged += new System.EventHandler(this.cmbInjectMode2_SelectedIndexChanged);
            this.cmbInjectMode3.SelectedIndexChanged += new System.EventHandler(this.cmbInjectMode3_SelectedIndexChanged);

        }

        #endregion


        #region 方法

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        public void LoadView(int antiControlID)
        {
            this.LoadRadioBtn();
            this.LoadViewComboBox();
            this.LoadTextBox();
        }

        /// <summary>
        /// 新建立反控的信息
        /// </summary>
        public void LoadNew()
        {

            if (null == this._dtoAntiControl.dtoInject)
            {
                this._dtoAntiControl.dtoInject = new InjectDto(); ;
            }

            this.txtInitTemp.Text = DefaultInject.InitTemp.ToString();
            this.txtAlertTemp.Text = DefaultInject.AlertTemp.ToString();
            
            this.txtInjectTime1.Text = DefaultInject.InjectTime.ToString();
            this.txtInjectTime2.Text = DefaultInject.InjectTime.ToString();
            this.txtInjectTime3.Text = DefaultInject.InjectTime.ToString();
            this._dtoAntiControl.dtoInject.InitTemp = DefaultInject.InitTemp;
            this._dtoAntiControl.dtoInject.AlertTemp = DefaultInject.AlertTemp;
            
            this._dtoAntiControl.dtoInject.InjectTime1 = (int)DefaultInject.InjectTime;
            this._dtoAntiControl.dtoInject.InjectTime2 = (int)DefaultInject.InjectTime;
            this._dtoAntiControl.dtoInject.InjectTime3 = (int)DefaultInject.InjectTime;

            this._dtoAntiControl.dtoInject.ColumnType1 = DefaultInject.ColumnType;
            this._dtoAntiControl.dtoInject.ColumnType2 = DefaultInject.ColumnType;
            this._dtoAntiControl.dtoInject.ColumnType3 = DefaultInject.ColumnType;

            this._dtoAntiControl.dtoInject.InjectMode1 = DefaultInject.InjectMode;
            this._dtoAntiControl.dtoInject.InjectMode2 = DefaultInject.InjectMode;
            this._dtoAntiControl.dtoInject.InjectMode3 = DefaultInject.InjectMode;

            this.LoadRadioBtn();
            this.LoadNewComboBox();
            this.LoadLimitation();

        }

        /// <summary>
        /// 编辑当前反控的信息
        /// </summary>
        public void LoadEdit()
        {
            this.LoadRadioBtn();
            this.LoadTextBox();
            this.LoadEditComboBox();

            //this.txtInitTemp.ReadOnly = false;
            //this.txtAlertTemp.ReadOnly = false;

            //this.txtInitTemp.BackColor = Color.White;
            //this.txtAlertTemp.BackColor = Color.White;

            this.LoadLimitation();

        }

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        public void LoadSaveAs()
        {
            this.LoadRadioBtn();
            this.LoadTextBox();
            this.LoadViewComboBox();
        }

        /// <summary>
        /// 装载选项按钮
        /// </summary>
        private void LoadRadioBtn()
        {
            switch (this._dtoAntiControl.dtoInject.ColumnType1)
            {
                case TypeColumn.Fill:
                    this.rbFill1.Checked = true;
                    break;
                case TypeColumn.Capillary:
                    this.rbCapillary1.Checked = true;
                    break;
            }

            switch (this._dtoAntiControl.dtoInject.ColumnType2)
            {
                case TypeColumn.Fill:
                    this.rbFill2.Checked = true;
                    break;
                case TypeColumn.Capillary:
                    this.rbCapillary2.Checked = true;
                    break;
            }

            switch (this._dtoAntiControl.dtoInject.ColumnType3)
            {
                case TypeColumn.Fill:
                    this.rbFill3.Checked = true;
                    break;
                case TypeColumn.Capillary:
                    this.rbCapillary3.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// 装载进样模式控件
        /// </summary>
        private void LoadViewComboBox()
        {
            //装载进样模式1
            this.cmbInjectMode1.Items.Clear();
            switch (this._dtoAntiControl.dtoInject.InjectMode1)
            {
                case ModeInject.NoTributary:
                case ModeInject.Tributary:
                case ModeInject.UnTributary:
                    break;
                default:
                    return;
            }

            this.cmbInjectMode1.Items.Add(EnumDescription.GetFieldText(this._dtoAntiControl.dtoInject.InjectMode1));
            this.cmbInjectMode1.SelectedIndex = 0;

            //装载进样模式2
            this.cmbInjectMode2.Items.Clear();
            switch (this._dtoAntiControl.dtoInject.InjectMode2)
            {
                case ModeInject.NoTributary:
                case ModeInject.Tributary:
                case ModeInject.UnTributary:
                    break;
                default:
                    return;
            }

            this.cmbInjectMode2.Items.Add(EnumDescription.GetFieldText(this._dtoAntiControl.dtoInject.InjectMode2));
            this.cmbInjectMode2.SelectedIndex = 0;

            //装载进样模式3
            this.cmbInjectMode3.Items.Clear();
            switch (this._dtoAntiControl.dtoInject.InjectMode3)
            {
                case ModeInject.NoTributary:
                case ModeInject.Tributary:
                case ModeInject.UnTributary:
                    break;
                default:
                    return;
            }

            this.cmbInjectMode3.Items.Add(EnumDescription.GetFieldText(this._dtoAntiControl.dtoInject.InjectMode3));
            this.cmbInjectMode3.SelectedIndex = 0;

        }

        /// <summary>
        /// 新进样方法,全部装载
        /// </summary>
        private void LoadNewComboBox()
        {
            //装载进样模式
            this.LoadInjectMode(cmbInjectMode1);
            this.LoadInjectMode(cmbInjectMode2);
            this.LoadInjectMode(cmbInjectMode3);

            //设置索引
            this.cmbInjectMode1.SelectedIndex = 0;
            this.cmbInjectMode2.SelectedIndex = 0;
            this.cmbInjectMode3.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载进样模式项目
        /// </summary>
        /// <param name="cmbMode"></param>
        private void LoadInjectMode(ComboBox cmbMode)
        {
            cmbMode.Items.Add(EnumDescription.GetFieldText(ModeInject.NoTributary));
            cmbMode.Items.Add(EnumDescription.GetFieldText(ModeInject.UnTributary));
            cmbMode.Items.Add(EnumDescription.GetFieldText(ModeInject.Tributary));
        }

        /// <summary>
        /// 编辑进样方法,全部装载
        /// </summary>
        private void LoadEditComboBox()
        {
            //装载进样模式
            this.LoadInjectMode(cmbInjectMode1);
            this.LoadInjectMode(cmbInjectMode2);
            this.LoadInjectMode(cmbInjectMode3);

            //设置索引
            this.cmbInjectMode1.SelectedIndex = (int)this._dtoAntiControl.dtoInject.InjectMode1;
            this.cmbInjectMode2.SelectedIndex = (int)this._dtoAntiControl.dtoInject.InjectMode2;
            this.cmbInjectMode3.SelectedIndex = (int)this._dtoAntiControl.dtoInject.InjectMode3;
        }

        /// <summary>
        /// 查看或者复制
        /// </summary>
        private void LoadTextBox()
        {
            if (null == this._dtoAntiControl.dtoInject)
            {
                return;
            }
            this.txtInitTemp.Text = this._dtoAntiControl.dtoInject.InitTemp.ToString();
            this.txtAlertTemp.Text = this._dtoAntiControl.dtoInject.AlertTemp.ToString();
            this.txtInjectTime1.Text = this._dtoAntiControl.dtoInject.InjectTime1.ToString();
            this.txtInjectTime2.Text = this._dtoAntiControl.dtoInject.InjectTime2.ToString();
            this.txtInjectTime3.Text = this._dtoAntiControl.dtoInject.InjectTime3.ToString();
        }

        /// <summary>
        /// 装载控件的风格
        /// </summary>
        /// <param name="isReadOnly"></param>
        private void LoadControlStyle(bool isReadOnly)
        {
            this.txtInitTemp.ReadOnly = isReadOnly;
            this.txtAlertTemp.ReadOnly = isReadOnly;
            this.txtInjectTime1.ReadOnly = isReadOnly;
            this.txtInjectTime2.ReadOnly = isReadOnly;
            this.txtInjectTime3.ReadOnly = isReadOnly;

            this.rbFill1.Enabled = this.rbFill1.Checked;
            this.rbFill2.Enabled = this.rbFill2.Checked;
            this.rbFill3.Enabled = this.rbFill3.Checked;

            this.rbCapillary1.Enabled = this.rbCapillary1.Checked;
            this.rbCapillary2.Enabled = this.rbCapillary2.Checked;
            this.rbCapillary3.Enabled = this.rbCapillary3.Checked;

            this.txtInitTemp.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtAlertTemp.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.txtInjectTime1.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtInjectTime2.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtInjectTime3.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.cmbInjectMode1.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.cmbInjectMode2.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.cmbInjectMode3.BackColor = isReadOnly ? Color.Beige : Color.White;
        }

        /// <summary>
        /// 初始化约束条件
        /// </summary>
        private void LoadLimitation()
        {

            if (this.rbFill1.Checked)
            {
                this.cmbInjectMode1.Enabled = false;
                this.txtInjectTime1.Enabled = false;
            }
            if (this.rbFill2.Checked)
            {
                this.cmbInjectMode2.Enabled = false;
                this.txtInjectTime2.Enabled = false;
            }
            if (this.rbFill3.Checked)
            {
                this.cmbInjectMode3.Enabled = false;
                this.txtInjectTime3.Enabled = false;
            }
            this._isLoadUi = true;
        }

        #endregion


        #region 文本框事件

        /// <summary>
        /// 报警温度文字改变事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAlertTemp_TextChanged(object sender, EventArgs e)
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
            this._dtoAntiControl.dtoInject.AlertTemp = Convert.ToSingle(this.txtAlertTemp.Text);
        }

        /// <summary>
        /// 初   温文字改变事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInitTemp_TextChanged(object sender, EventArgs e)
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
            this._dtoAntiControl.dtoInject.InitTemp = Convert.ToSingle(this.txtInitTemp.Text);
        }

        /// <summary>
        /// 进样时间1文字改变事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInjectTime1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtInjectTime1.Text))
            {
                MessageBox.Show("进样时间1不能为空！", "初   温");
                this.txtInjectTime1.Focus();
                return;
            }
            if (!CastString.IsNumber(this.txtInjectTime1.Text))
            {
                MessageBox.Show("进样时间1不是数值！", "初   温");
                this.txtInjectTime1.Focus();
                return;
            }
            this._dtoAntiControl.dtoInject.InjectTime1 = Convert.ToInt32(this.txtInjectTime1.Text);
        }

        /// <summary>
        /// 进样时间2文字改变事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInjectTime2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtInjectTime2.Text))
            {
                MessageBox.Show("进样时间2不能为空！", "初   温");
                this.txtInjectTime2.Focus();
                return;
            }
            if (!CastString.IsNumber(this.txtInjectTime2.Text))
            {
                MessageBox.Show("进样时间2不是数值！", "初   温");
                this.txtInjectTime2.Focus();
                return;
            }
            this._dtoAntiControl.dtoInject.InjectTime2 = Convert.ToInt32(this.txtInjectTime2.Text);
        }

        /// <summary>
        /// 进样时间3文字改变事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInjectTime3_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtInjectTime3.Text))
            {
                MessageBox.Show("进样时间3不能为空！", "初   温");
                this.txtInjectTime3.Focus();
                return;
            }
            if (!CastString.IsNumber(this.txtInjectTime3.Text))
            {
                MessageBox.Show("进样时间3不是数值！", "初   温");
                this.txtInjectTime3.Focus();
                return;
            }
            this._dtoAntiControl.dtoInject.InjectTime3 = Convert.ToInt32(this.txtInjectTime3.Text);
        }
        
        #endregion


        #region RadioBtn事件

        /// <summary>
        /// 填充柱1按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbFill1_CheckedChanged(object sender, EventArgs e)
        {
            if (this._dtoAntiControl.dtoInject.ColumnType1 == TypeColumn.Fill)
            {
                return;
            }

            this._dtoAntiControl.dtoInject.ColumnType1 = TypeColumn.Fill;

            this.cmbInjectMode1.Enabled = false;
            this.txtInjectTime1.Enabled = false;
        }

        /// <summary>
        /// 毛细管1按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbCapillary1_CheckedChanged(object sender, EventArgs e)
        {
            if (this._dtoAntiControl.dtoInject.ColumnType1 == TypeColumn.Capillary)
            {
                return;
            }

            this._dtoAntiControl.dtoInject.ColumnType1 = TypeColumn.Capillary;

            this.cmbInjectMode1.Enabled = true;
            this.txtInjectTime1.Enabled = true;
        }

        /// <summary>
        /// 填充柱2按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbFill2_CheckedChanged(object sender, EventArgs e)
        {
            if (this._dtoAntiControl.dtoInject.ColumnType2 == TypeColumn.Fill)
            {
                return;
            }

            this._dtoAntiControl.dtoInject.ColumnType2 = TypeColumn.Fill;

            this.cmbInjectMode2.Enabled = false;
            this.txtInjectTime2.Enabled = false;
        }

        /// <summary>
        /// 毛细管2按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbCapillary2_CheckedChanged(object sender, EventArgs e)
        {
            if (this._dtoAntiControl.dtoInject.ColumnType2 == TypeColumn.Capillary)
            {
                return;
            }

            this._dtoAntiControl.dtoInject.ColumnType2 = TypeColumn.Capillary;

            this.cmbInjectMode2.Enabled = true;
            this.txtInjectTime2.Enabled = true;
        }

        /// <summary>
        /// 填充柱3按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbFill3_CheckedChanged(object sender, EventArgs e)
        {
            if (this._dtoAntiControl.dtoInject.ColumnType3 == TypeColumn.Fill)
            {
                return;
            }

            this._dtoAntiControl.dtoInject.ColumnType3 = TypeColumn.Fill;

            this.cmbInjectMode3.Enabled = false;
            this.txtInjectTime3.Enabled = false;
        }

        /// <summary>
        /// 毛细管3按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbCapillary3_CheckedChanged(object sender, EventArgs e)
        {
            if (this._dtoAntiControl.dtoInject.ColumnType3 == TypeColumn.Capillary)
            {
                return;
            }

            this._dtoAntiControl.dtoInject.ColumnType3 = TypeColumn.Capillary;

            this.cmbInjectMode3.Enabled = true;
            this.txtInjectTime3.Enabled = true;
        }

        #endregion


        #region ComboBox事件
        
        /// <summary>
        /// 进样模式1变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbInjectMode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._isLoadUi)
            {
                return;
            }


            if (this.cmbInjectMode1.SelectedIndex.ToString().Equals(this._dtoAntiControl.dtoInject.InjectMode1))
            {
                return;
            }

            this._dtoAntiControl.dtoInject.InjectMode1 = (ModeInject)this.cmbInjectMode1.SelectedIndex;
            switch (this._dtoAntiControl.dtoInject.InjectMode1)
            {
                case ModeInject.NoTributary:
                case ModeInject.Tributary:
                    this.txtInjectTime1.Enabled = false;
                    break;
                case ModeInject.UnTributary:
                    this.txtInjectTime1.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// 进样模式2变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbInjectMode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._isLoadUi)
            {
                return;
            }

            if (this.cmbInjectMode2.SelectedIndex.ToString().Equals(this._dtoAntiControl.dtoInject.InjectMode2))
            {
                return;
            }

            this._dtoAntiControl.dtoInject.InjectMode2 = (ModeInject)this.cmbInjectMode2.SelectedIndex;

            switch (this._dtoAntiControl.dtoInject.InjectMode2)
            {
                case ModeInject.NoTributary:
                case ModeInject.Tributary:
                    this.txtInjectTime2.Enabled = false;
                    break;
                case ModeInject.UnTributary:
                    this.txtInjectTime2.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// 进样模式3变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbInjectMode3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._isLoadUi)
            {
                return;
            }

            if (this.cmbInjectMode3.SelectedIndex.ToString().Equals(this._dtoAntiControl.dtoInject.InjectMode3))
            {
                return;
            }

            this._dtoAntiControl.dtoInject.InjectMode3 = (ModeInject)this.cmbInjectMode3.SelectedIndex;

            switch (this._dtoAntiControl.dtoInject.InjectMode3)
            {
                case ModeInject.NoTributary:
                case ModeInject.Tributary:
                    this.txtInjectTime3.Enabled = false;
                    break;
                case ModeInject.UnTributary:
                    this.txtInjectTime3.Enabled = true;
                    break;
            }
        }

        #endregion

    }
}
