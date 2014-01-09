/*-----------------------------------------------------------------------------
//  FILE NAME       : ColumnParaUser.cs
//  FUNCTION        : 柱箱参数视图
//  AUTHOR          : 李锋(2009/06/30)
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
    /// 柱箱参数视图
    /// </summary>
    public partial class NetworkBoardUser : UserControl
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
        public NetworkBoardUser(AntiControlDto dto)
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
            this.txtBalanceTime.TextChanged += new System.EventHandler(this.txtBalanceTime_TextChanged);
            this.txtInitTemp.TextChanged += new System.EventHandler(this.txtInitTemp_TextChanged);
            this.txtMaintainTime.TextChanged += new System.EventHandler(this.txtMaintainTime_TextChanged);
            this.txtAlertTemp.TextChanged += new System.EventHandler(this.txtAlertTemp_TextChanged);
            this.txtColumnCount.TextChanged += new System.EventHandler(this.txtColumnCount_TextChanged);

            this.txtRateCol1.TextChanged += new System.EventHandler(this.txtRateCol1_TextChanged);
            this.txtRateCol2.TextChanged += new System.EventHandler(this.txtRateCol2_TextChanged);
            this.txtRateCol3.TextChanged += new System.EventHandler(this.txtRateCol3_TextChanged);
            this.txtRateCol4.TextChanged += new System.EventHandler(this.txtRateCol4_TextChanged);
            this.txtRateCol5.TextChanged += new System.EventHandler(this.txtRateCol5_TextChanged);

            this.txtTempCol1.TextChanged += new System.EventHandler(this.txtTempCol1_TextChanged);
            this.txtTempCol2.TextChanged += new System.EventHandler(this.txtTempCol2_TextChanged);
            this.txtTempCol3.TextChanged += new System.EventHandler(this.txtTempCol3_TextChanged);
            this.txtTempCol4.TextChanged += new System.EventHandler(this.txtTempCol4_TextChanged);
            this.txtTempCol5.TextChanged += new System.EventHandler(this.txtTempCol5_TextChanged);

            this.txtTempTimeCol1.TextChanged += new System.EventHandler(this.txtTempTimeCol1_TextChanged);
            this.txtTempTimeCol2.TextChanged += new System.EventHandler(this.txtTempTimeCol2_TextChanged);
            this.txtTempTimeCol3.TextChanged += new System.EventHandler(this.txtTempTimeCol3_TextChanged);
            this.txtTempTimeCol4.TextChanged += new System.EventHandler(this.txtTempTimeCol4_TextChanged);
            this.txtTempTimeCol5.TextChanged += new System.EventHandler(this.txtTempTimeCol5_TextChanged);


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
        private void LoadViewOrSaveAs()
        {
            if (null == this._dtoAntiControl.dtoColumnPara)
            {
                return;
            }
            this.txtBalanceTime.Text = this._dtoAntiControl.dtoColumnPara.BalanceTime.ToString();
            this.txtInitTemp.Text = this._dtoAntiControl.dtoColumnPara.InitTemp.ToString();
            this.txtMaintainTime.Text = this._dtoAntiControl.dtoColumnPara.MaintainTime.ToString();
            this.txtAlertTemp.Text = this._dtoAntiControl.dtoColumnPara.AlertTemp.ToString();
            this.txtColumnCount.Text = this._dtoAntiControl.dtoColumnPara.ColumnCount.ToString();

            this.txtRateCol1.Text = this._dtoAntiControl.dtoColumnPara.RateCol1.ToString();
            this.txtRateCol2.Text = this._dtoAntiControl.dtoColumnPara.RateCol2.ToString();
            this.txtRateCol3.Text = this._dtoAntiControl.dtoColumnPara.RateCol3.ToString();
            this.txtRateCol4.Text = this._dtoAntiControl.dtoColumnPara.RateCol4.ToString();
            this.txtRateCol5.Text = this._dtoAntiControl.dtoColumnPara.RateCol5.ToString();

            this.txtTempCol1.Text = this._dtoAntiControl.dtoColumnPara.TempCol1.ToString();
            this.txtTempCol2.Text = this._dtoAntiControl.dtoColumnPara.TempCol2.ToString();
            this.txtTempCol3.Text = this._dtoAntiControl.dtoColumnPara.TempCol3.ToString();
            this.txtTempCol4.Text = this._dtoAntiControl.dtoColumnPara.TempCol4.ToString();
            this.txtTempCol5.Text = this._dtoAntiControl.dtoColumnPara.TempCol5.ToString();

            this.txtTempTimeCol1.Text = this._dtoAntiControl.dtoColumnPara.TempTimeCol1.ToString();
            this.txtTempTimeCol2.Text = this._dtoAntiControl.dtoColumnPara.TempTimeCol2.ToString();
            this.txtTempTimeCol3.Text = this._dtoAntiControl.dtoColumnPara.TempTimeCol3.ToString();
            this.txtTempTimeCol4.Text = this._dtoAntiControl.dtoColumnPara.TempTimeCol4.ToString();
            this.txtTempTimeCol5.Text = this._dtoAntiControl.dtoColumnPara.TempTimeCol5.ToString();
           
        }

        /// <summary>
        /// 装载控件的风格
        /// </summary>
        /// <param name="isReadOnly"></param>
        private void LoadControlStyle(bool isReadOnly)
        {
            this.txtBalanceTime.ReadOnly = isReadOnly;
            this.txtInitTemp.ReadOnly = isReadOnly;
            this.txtMaintainTime.ReadOnly = isReadOnly;
            this.txtAlertTemp.ReadOnly = isReadOnly;
            this.txtColumnCount.ReadOnly = isReadOnly;

            this.txtRateCol1.ReadOnly = isReadOnly;
            this.txtRateCol2.ReadOnly = isReadOnly;
            this.txtRateCol3.ReadOnly = isReadOnly;
            this.txtRateCol4.ReadOnly = isReadOnly;
            this.txtRateCol5.ReadOnly = isReadOnly;

            this.txtTempCol1.ReadOnly = isReadOnly;
            this.txtTempCol2.ReadOnly = isReadOnly;
            this.txtTempCol3.ReadOnly = isReadOnly;
            this.txtTempCol4.ReadOnly = isReadOnly;
            this.txtTempCol5.ReadOnly = isReadOnly;

            this.txtTempTimeCol1.ReadOnly = isReadOnly;
            this.txtTempTimeCol2.ReadOnly = isReadOnly;
            this.txtTempTimeCol3.ReadOnly = isReadOnly;
            this.txtTempTimeCol4.ReadOnly = isReadOnly;
            this.txtTempTimeCol5.ReadOnly = isReadOnly;

            this.txtBalanceTime.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtInitTemp.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtMaintainTime.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtAlertTemp.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtColumnCount.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.txtRateCol1.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtRateCol2.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtRateCol3.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtRateCol4.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtRateCol5.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.txtTempCol1.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTempCol2.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTempCol3.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTempCol4.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTempCol5.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.txtTempTimeCol1.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTempTimeCol2.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTempTimeCol3.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTempTimeCol4.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTempTimeCol5.BackColor = isReadOnly ? Color.Beige : Color.White;
        }

        /// <summary>
        /// 新建立反控的信息
        /// </summary>
        public void LoadNew()
        {

            this.LoadControlStyle(false);


            if (null == this._dtoAntiControl.dtoColumnPara)
            {
                this._dtoAntiControl.dtoColumnPara = new ColumnParaDto();
            }
            this._dtoAntiControl.dtoColumnPara.BalanceTime = DefaultColumnPara.BalanceTime;
            this._dtoAntiControl.dtoColumnPara.InitTemp = DefaultColumnPara.InitTemp;
            this._dtoAntiControl.dtoColumnPara.MaintainTime = DefaultColumnPara.MaintainTime;
            this._dtoAntiControl.dtoColumnPara.AlertTemp = DefaultColumnPara.AlertTemp;
            this._dtoAntiControl.dtoColumnPara.ColumnCount = DefaultColumnPara.ColumnCount;

            this._dtoAntiControl.dtoColumnPara.RateCol1 = DefaultColumnPara.RateCol1;
            this._dtoAntiControl.dtoColumnPara.RateCol2 = DefaultColumnPara.RateCol2;
            this._dtoAntiControl.dtoColumnPara.RateCol3 = DefaultColumnPara.RateCol3;
            this._dtoAntiControl.dtoColumnPara.RateCol4 = DefaultColumnPara.RateCol4;
            this._dtoAntiControl.dtoColumnPara.RateCol5 = DefaultColumnPara.RateCol5;

            this._dtoAntiControl.dtoColumnPara.TempCol1 = DefaultColumnPara.TempCol1;
            this._dtoAntiControl.dtoColumnPara.TempCol2 = DefaultColumnPara.TempCol2;
            this._dtoAntiControl.dtoColumnPara.TempCol3 = DefaultColumnPara.TempCol3;
            this._dtoAntiControl.dtoColumnPara.TempCol4 = DefaultColumnPara.TempCol4;
            this._dtoAntiControl.dtoColumnPara.TempCol5 = DefaultColumnPara.TempCol5;

            this._dtoAntiControl.dtoColumnPara.TempTimeCol1 = DefaultColumnPara.TempTimeCol1;
            this._dtoAntiControl.dtoColumnPara.TempTimeCol2 = DefaultColumnPara.TempTimeCol2;
            this._dtoAntiControl.dtoColumnPara.TempTimeCol3 = DefaultColumnPara.TempTimeCol3;
            this._dtoAntiControl.dtoColumnPara.TempTimeCol4 = DefaultColumnPara.TempTimeCol4;
            this._dtoAntiControl.dtoColumnPara.TempTimeCol5 = DefaultColumnPara.TempTimeCol5;

            this.txtBalanceTime.Text = DefaultColumnPara.BalanceTime.ToString();
            this.txtInitTemp.Text = DefaultColumnPara.InitTemp.ToString();
            this.txtMaintainTime.Text = DefaultColumnPara.MaintainTime.ToString();
            this.txtAlertTemp.Text = DefaultColumnPara.AlertTemp.ToString();
            this.txtColumnCount.Text = DefaultColumnPara.ColumnCount.ToString();

            this.txtRateCol1.Text = DefaultColumnPara.RateCol1.ToString();
            this.txtRateCol2.Text = DefaultColumnPara.RateCol2.ToString();
            this.txtRateCol3.Text = DefaultColumnPara.RateCol3.ToString();
            this.txtRateCol4.Text = DefaultColumnPara.RateCol4.ToString();
            this.txtRateCol5.Text = DefaultColumnPara.RateCol5.ToString();

            this.txtTempCol1.Text = DefaultColumnPara.TempCol1.ToString();
            this.txtTempCol2.Text = DefaultColumnPara.TempCol2.ToString();
            this.txtTempCol3.Text = DefaultColumnPara.TempCol3.ToString();
            this.txtTempCol4.Text = DefaultColumnPara.TempCol4.ToString();
            this.txtTempCol5.Text = DefaultColumnPara.TempCol5.ToString();

            this.txtTempTimeCol1.Text = DefaultColumnPara.TempTimeCol1.ToString();
            this.txtTempTimeCol2.Text = DefaultColumnPara.TempTimeCol2.ToString();
            this.txtTempTimeCol3.Text = DefaultColumnPara.TempTimeCol3.ToString();
            this.txtTempTimeCol4.Text = DefaultColumnPara.TempTimeCol4.ToString();
            this.txtTempTimeCol5.Text = DefaultColumnPara.TempTimeCol5.ToString();
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
        /// 平衡时间焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBalanceTime_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtBalanceTime.Text))
            {
                MessageBox.Show("平衡时间不能为空！", "平衡时间");
                this.txtBalanceTime.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtBalanceTime.Text))
            {
                MessageBox.Show("平衡时间不是数值！", "平衡时间");
                this.txtBalanceTime.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.BalanceTime = Convert.ToSingle(this.txtBalanceTime.Text);
        }

        /// <summary>
        /// 初   温焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInitTemp_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtInitTemp.Text))
            {
                MessageBox.Show("初   温不能为空！", "初   温");
                this.txtInitTemp.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtInitTemp.Text))
            {
                MessageBox.Show("初   温不是数值！", "初   温");
                this.txtInitTemp.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.InitTemp = Convert.ToSingle(this.txtInitTemp.Text);
        }

        /// <summary>
        /// 维持时间焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMaintainTime_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtMaintainTime.Text))
            {
                MessageBox.Show("维持时间不能为空！", "维持时间");
                this.txtMaintainTime.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtMaintainTime.Text))
            {
                MessageBox.Show("维持时间不是数值！", "维持时间");
                this.txtMaintainTime.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.MaintainTime = Convert.ToSingle(this.txtMaintainTime.Text);
        }

        /// <summary>
        /// 报警温度焦点离开事件，合法性检验
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
            this._dtoAntiControl.dtoColumnPara.AlertTemp = Convert.ToSingle(this.txtAlertTemp.Text);
        }

        /// <summary>
        /// COL程升介数焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColumnCount_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtColumnCount.Text))
            {
                MessageBox.Show("COL程升介数不能为空！", "COL程升介数");
                this.txtColumnCount.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtColumnCount.Text))
            {
                MessageBox.Show("COL程升介数不是数值！", "COL程升介数");
                this.txtColumnCount.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.ColumnCount = Convert.ToSingle(this.txtColumnCount.Text);
        }

        /// <summary>
        /// COL-1程升速率焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRateCol1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtRateCol1.Text))
            {
                MessageBox.Show("COL-1程升速率不能为空！", "COL-1程升速率");
                this.txtRateCol1.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtRateCol1.Text))
            {
                MessageBox.Show("COL-1程升速率不是数值！", "COL-1程升速率");
                this.txtRateCol1.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.RateCol1 = Convert.ToSingle(this.txtRateCol1.Text);
        }

        /// <summary>
        /// COL-2程升速率焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRateCol2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtRateCol2.Text))
            {
                MessageBox.Show("COL-2程升速率不能为空！", "COL-程升速率");
                this.txtRateCol2.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtRateCol2.Text))
            {
                MessageBox.Show("COL-2程升速率不是数值！", "COL-2程升速率");
                this.txtRateCol2.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.RateCol2 = Convert.ToSingle(this.txtRateCol2.Text);
        }

        /// <summary>
        /// COL-3程升速率焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRateCol3_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtRateCol3.Text))
            {
                MessageBox.Show("COL-3程升速率不能为空！", "COL-3程升速率");
                this.txtRateCol3.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtRateCol3.Text))
            {
                MessageBox.Show("COL-3程升速率不是数值！", "COL-3程升速率");
                this.txtRateCol3.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.RateCol3 = Convert.ToSingle(this.txtRateCol3.Text);
        }

        /// <summary>
        /// COL-4程升速率焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRateCol4_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtRateCol4.Text))
            {
                MessageBox.Show("COL-4程升速率不能为空！", "COL-4程升速率");
                this.txtRateCol4.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtRateCol4.Text))
            {
                MessageBox.Show("COL-4程升速率不是数值！", "COL-4程升速率");
                this.txtRateCol4.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.RateCol4 = Convert.ToSingle(this.txtRateCol4.Text);
        }

        /// <summary>
        /// COL-5程升速率焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRateCol5_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtRateCol5.Text))
            {
                MessageBox.Show("COL-5程升速率不能为空！", "COL-5程升速率");
                this.txtRateCol5.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtRateCol5.Text))
            {
                MessageBox.Show("COL-5程升速率不是数值！", "COL-5程升速率");
                this.txtRateCol5.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.RateCol5 = Convert.ToSingle(this.txtRateCol5.Text);
        }

        /// <summary>
        /// COL-1程升恒温焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTempCol1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtTempCol1.Text))
            {
                MessageBox.Show("COL-1程升恒温不能为空！", "COL-1程升恒温");
                this.txtTempCol1.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtTempCol1.Text))
            {
                MessageBox.Show("COL-1程升恒温不是数值！", "COL-1程升恒温");
                this.txtTempCol1.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.TempCol1 = Convert.ToSingle(this.txtTempCol1.Text);
        }

        /// <summary>
        /// COL-2程升恒温焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTempCol2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtTempCol2.Text))
            {
                MessageBox.Show("COL-2程升恒温不能为空！", "COL-2程升恒温");
                this.txtTempCol2.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtTempCol2.Text))
            {
                MessageBox.Show("COL-2程升恒温不是数值！", "COL-2程升恒温");
                this.txtTempCol2.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.TempCol2 = Convert.ToSingle(this.txtTempCol2.Text);
        }

        /// <summary>
        /// COL-3程升恒温焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTempCol3_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtTempCol3.Text))
            {
                MessageBox.Show("COL-3程升恒温不能为空！", "COL-3程升恒温");
                this.txtTempCol3.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtTempCol3.Text))
            {
                MessageBox.Show("COL-3程升恒温不是数值！", "COL-3程升恒温");
                this.txtTempCol3.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.TempCol3 = Convert.ToSingle(this.txtTempCol3.Text);
        }

        /// <summary>
        /// COL-4程升恒温焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTempCol4_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtTempCol4.Text))
            {
                MessageBox.Show("COL-4程升恒温不能为空！", "COL-4程升恒温");
                this.txtTempCol4.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtTempCol4.Text))
            {
                MessageBox.Show("COL-4程升恒温不是数值！", "COL-4程升恒温");
                this.txtTempCol4.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.TempCol4 = Convert.ToSingle(this.txtTempCol4.Text);
        }

        /// <summary>
        /// COL-5程升恒温焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTempCol5_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtTempCol5.Text))
            {
                MessageBox.Show("COL-5程升恒温不能为空！", "COL-5程升恒温");
                this.txtTempCol5.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtTempCol5.Text))
            {
                MessageBox.Show("COL-5程升恒温不是数值！", "COL-5程升恒温");
                this.txtTempCol5.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.TempCol5 = Convert.ToSingle(this.txtTempCol5.Text);
        }

        /// <summary>
        /// COL-1程升恒温时间焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTempTimeCol1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtTempTimeCol1.Text))
            {
                MessageBox.Show("COL-1程升恒温时间不能为空！", "COL-1程升恒温时间");
                this.txtTempTimeCol1.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtTempTimeCol1.Text))
            {
                MessageBox.Show("COL-1程升恒温时间不是数值！", "COL-1程升恒温时间");
                this.txtTempTimeCol1.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.TempTimeCol1 = Convert.ToSingle(this.txtTempTimeCol1.Text);
        }

        /// <summary>
        /// COL-2程升恒温时间焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTempTimeCol2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtTempTimeCol2.Text))
            {
                MessageBox.Show("COL-2程升恒温时间不能为空！", "COL-2程升恒温时间");
                this.txtTempTimeCol2.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtTempTimeCol2.Text))
            {
                MessageBox.Show("COL-2程升恒温时间不是数值！", "COL-2程升恒温时间");
                this.txtTempTimeCol2.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.TempTimeCol2 = Convert.ToSingle(this.txtTempTimeCol2.Text);
        }

        /// <summary>
        /// COL-3程升恒温时间焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTempTimeCol3_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtTempTimeCol3.Text))
            {
                MessageBox.Show("COL-3程升恒温时间不能为空！", "COL-3程升恒温时间");
                this.txtTempTimeCol3.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtTempTimeCol3.Text))
            {
                MessageBox.Show("COL-3程升恒温时间不是数值！", "COL-3程升恒温时间");
                this.txtTempTimeCol3.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.TempTimeCol3 = Convert.ToSingle(this.txtTempTimeCol3.Text);
        }

        /// <summary>
        /// COL-4程升恒温时间焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTempTimeCol4_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtTempTimeCol4.Text))
            {
                MessageBox.Show("COL-4程升恒温时间不能为空！", "COL-4程升恒温时间");
                this.txtTempTimeCol4.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtTempTimeCol4.Text))
            {
                MessageBox.Show("COL-4程升恒温时间不是数值！", "COL-4程升恒温时间");
                this.txtTempTimeCol4.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.TempTimeCol4 = Convert.ToSingle(this.txtTempTimeCol4.Text);
        }

        /// <summary>
        /// COL-5程升恒温时间焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTempTimeCol5_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtTempTimeCol5.Text))
            {
                MessageBox.Show("COL-5程升恒温时间不能为空！", "COL-5程升恒温时间");
                this.txtTempTimeCol5.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtTempTimeCol5.Text))
            {
                MessageBox.Show("COL-5程升恒温时间不是数值！", "COL-5程升恒温时间");
                this.txtTempTimeCol5.Focus();
                return;
            }
            this._dtoAntiControl.dtoColumnPara.TempTimeCol5 = Convert.ToSingle(this.txtTempTimeCol5.Text);
        }

        #endregion


    }
}
