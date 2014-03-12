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
    public partial class HeatingSourceUser : UserControl
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
        public HeatingSourceUser(AntiControlDto dto)
        {
            InitializeComponent();
            this._dtoAntiControl = dto;
            this.LoadEvent();
            //this.LoadControlStyle(true);
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
            this.txtColumnCount.Validated += new System.EventHandler(this.txtColumnCount_Validated);

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

        }

        /// <summary>
        /// 从缓冲区导入
        /// </summary>
        private void LoadViewOrSaveAs()
        {
            if (null == this._dtoAntiControl.dtoHeatingSource )
            {
                return;
            }
            this.txtBalanceTime.Text = this._dtoAntiControl.dtoHeatingSource .BalanceTime.ToString();
            this.txtInitTemp.Text = this._dtoAntiControl.dtoHeatingSource .InitTemp.ToString();
            this.txtMaintainTime.Text = this._dtoAntiControl.dtoHeatingSource .MaintainTime.ToString();
            this.txtAlertTemp.Text = this._dtoAntiControl.dtoHeatingSource .AlertTemp.ToString();
            this.txtColumnCount.Text = this._dtoAntiControl.dtoHeatingSource .ColumnCount.ToString();

            if (Convert.ToInt32(this.txtColumnCount.Text) == 0)
            {
                txtRateCol1.Enabled = false;
                txtTempCol1.Enabled = false;
                txtTempTimeCol1.Enabled = false;

                txtRateCol2.Enabled = false;
                txtTempCol2.Enabled = false;
                txtTempTimeCol2.Enabled = false;

                txtRateCol3.Enabled = false;
                txtTempCol3.Enabled = false;
                txtTempTimeCol3.Enabled = false;

                txtRateCol4.Enabled = false;
                txtTempCol4.Enabled = false;
                txtTempTimeCol4.Enabled = false;

                txtRateCol5.Enabled = false;
                txtTempCol5.Enabled = false;
                txtTempTimeCol5.Enabled = false;
            }
            else if (Convert.ToInt32(this.txtColumnCount.Text) == 1)
            {
                txtRateCol1.Enabled = true;
                txtTempCol1.Enabled = true;
                txtTempTimeCol1.Enabled = true;

                txtRateCol2.Enabled = false;
                txtTempCol2.Enabled = false;
                txtTempTimeCol2.Enabled = false;

                txtRateCol3.Enabled = false;
                txtTempCol3.Enabled = false;
                txtTempTimeCol3.Enabled = false;

                txtRateCol4.Enabled = false;
                txtTempCol4.Enabled = false;
                txtTempTimeCol4.Enabled = false;

                txtRateCol5.Enabled = false;
                txtTempCol5.Enabled = false;
                txtTempTimeCol5.Enabled = false;
            }
            else if (Convert.ToInt32(this.txtColumnCount.Text) == 2)
            {
                txtRateCol1.Enabled = true;
                txtTempCol1.Enabled = true;
                txtTempTimeCol1.Enabled = true;

                txtRateCol2.Enabled = true;
                txtTempCol2.Enabled = true;
                txtTempTimeCol2.Enabled = true;

                txtRateCol3.Enabled = false;
                txtTempCol3.Enabled = false;
                txtTempTimeCol3.Enabled = false;

                txtRateCol4.Enabled = false;
                txtTempCol4.Enabled = false;
                txtTempTimeCol4.Enabled = false;

                txtRateCol5.Enabled = false;
                txtTempCol5.Enabled = false;
                txtTempTimeCol5.Enabled = false;
            }
            else if (Convert.ToInt32(this.txtColumnCount.Text) == 3)
            {
                txtRateCol1.Enabled = true;
                txtTempCol1.Enabled = true;
                txtTempTimeCol1.Enabled = true;

                txtRateCol2.Enabled = true;
                txtTempCol2.Enabled = true;
                txtTempTimeCol2.Enabled = true;

                txtRateCol3.Enabled = true;
                txtTempCol3.Enabled = true;
                txtTempTimeCol3.Enabled = true;

                txtRateCol4.Enabled = false;
                txtTempCol4.Enabled = false;
                txtTempTimeCol4.Enabled = false;

                txtRateCol5.Enabled = false;
                txtTempCol5.Enabled = false;
                txtTempTimeCol5.Enabled = false;
            }
            else if (Convert.ToInt32(this.txtColumnCount.Text) == 4)
            {
                txtRateCol1.Enabled = true;
                txtTempCol1.Enabled = true;
                txtTempTimeCol1.Enabled = true;

                txtRateCol2.Enabled = true;
                txtTempCol2.Enabled = true;
                txtTempTimeCol2.Enabled = true;

                txtRateCol3.Enabled = true;
                txtTempCol3.Enabled = true;
                txtTempTimeCol3.Enabled = true;

                txtRateCol4.Enabled = true;
                txtTempCol4.Enabled = true;
                txtTempTimeCol4.Enabled = true;

                txtRateCol5.Enabled = false;
                txtTempCol5.Enabled = false;
                txtTempTimeCol5.Enabled = false;
            }
            else if (Convert.ToInt32(this.txtColumnCount.Text) == 5)
            {
                txtRateCol1.Enabled = true;
                txtTempCol1.Enabled = true;
                txtTempTimeCol1.Enabled = true;

                txtRateCol2.Enabled = true;
                txtTempCol2.Enabled = true;
                txtTempTimeCol2.Enabled = true;

                txtRateCol3.Enabled = true;
                txtTempCol3.Enabled = true;
                txtTempTimeCol3.Enabled = true;

                txtRateCol4.Enabled = true;
                txtTempCol4.Enabled = true;
                txtTempTimeCol4.Enabled = true;

                txtRateCol5.Enabled = true;
                txtTempCol5.Enabled = true;
                txtTempTimeCol5.Enabled = true;
            }

            this.txtRateCol1.Text = this._dtoAntiControl.dtoHeatingSource .RateCol1.ToString();
            this.txtRateCol2.Text = this._dtoAntiControl.dtoHeatingSource .RateCol2.ToString();
            this.txtRateCol3.Text = this._dtoAntiControl.dtoHeatingSource .RateCol3.ToString();
            this.txtRateCol4.Text = this._dtoAntiControl.dtoHeatingSource .RateCol4.ToString();
            this.txtRateCol5.Text = this._dtoAntiControl.dtoHeatingSource .RateCol5.ToString();

            this.txtTempCol1.Text = this._dtoAntiControl.dtoHeatingSource .TempCol1.ToString();
            this.txtTempCol2.Text = this._dtoAntiControl.dtoHeatingSource .TempCol2.ToString();
            this.txtTempCol3.Text = this._dtoAntiControl.dtoHeatingSource .TempCol3.ToString();
            this.txtTempCol4.Text = this._dtoAntiControl.dtoHeatingSource .TempCol4.ToString();
            this.txtTempCol5.Text = this._dtoAntiControl.dtoHeatingSource .TempCol5.ToString();

            this.txtTempTimeCol1.Text = this._dtoAntiControl.dtoHeatingSource .TempTimeCol1.ToString();
            this.txtTempTimeCol2.Text = this._dtoAntiControl.dtoHeatingSource .TempTimeCol2.ToString();
            this.txtTempTimeCol3.Text = this._dtoAntiControl.dtoHeatingSource .TempTimeCol3.ToString();
            this.txtTempTimeCol4.Text = this._dtoAntiControl.dtoHeatingSource .TempTimeCol4.ToString();
            this.txtTempTimeCol5.Text = this._dtoAntiControl.dtoHeatingSource .TempTimeCol5.ToString();
           
        }

        /// <summary>
        /// 导出到缓冲区
        /// </summary>
        public void Export()
        {
            this._dtoAntiControl.dtoHeatingSource.BalanceTime = Convert.ToInt32(this.txtBalanceTime.Text);
            this._dtoAntiControl.dtoHeatingSource.InitTemp = Convert.ToInt32(this.txtInitTemp.Text);
            this._dtoAntiControl.dtoHeatingSource.MaintainTime = Convert.ToInt32(this.txtMaintainTime.Text);
            this._dtoAntiControl.dtoHeatingSource.AlertTemp = Convert.ToInt32(this.txtAlertTemp.Text);
            this._dtoAntiControl.dtoHeatingSource.ColumnCount = Convert.ToInt32(this.txtColumnCount.Text);

            this._dtoAntiControl.dtoHeatingSource.RateCol1 = Convert.ToInt32(this.txtRateCol1.Text);
            this._dtoAntiControl.dtoHeatingSource.RateCol2 = Convert.ToInt32(this.txtRateCol2.Text);
            this._dtoAntiControl.dtoHeatingSource.RateCol3 = Convert.ToInt32(this.txtRateCol3.Text);
            this._dtoAntiControl.dtoHeatingSource.RateCol4 = Convert.ToInt32(this.txtRateCol4.Text);
            this._dtoAntiControl.dtoHeatingSource.RateCol5 = Convert.ToInt32(this.txtRateCol5.Text);

            this._dtoAntiControl.dtoHeatingSource.TempCol1 = Convert.ToInt32(this.txtTempCol1.Text);
            this._dtoAntiControl.dtoHeatingSource.TempCol2 = Convert.ToInt32(this.txtTempCol2.Text);
            this._dtoAntiControl.dtoHeatingSource.TempCol3 = Convert.ToInt32(this.txtTempCol3.Text);
            this._dtoAntiControl.dtoHeatingSource.TempCol4 = Convert.ToInt32(this.txtTempCol4.Text);
            this._dtoAntiControl.dtoHeatingSource.TempCol5 = Convert.ToInt32(this.txtTempCol5.Text);

            this._dtoAntiControl.dtoHeatingSource.TempTimeCol1 = Convert.ToInt32(this.txtTempTimeCol1.Text);
            this._dtoAntiControl.dtoHeatingSource.TempTimeCol2 = Convert.ToInt32(this.txtTempTimeCol2.Text);
            this._dtoAntiControl.dtoHeatingSource.TempTimeCol3 = Convert.ToInt32(this.txtTempTimeCol3.Text);
            this._dtoAntiControl.dtoHeatingSource.TempTimeCol4 = Convert.ToInt32(this.txtTempTimeCol4.Text);
            this._dtoAntiControl.dtoHeatingSource.TempTimeCol5 = Convert.ToInt32(this.txtTempTimeCol5.Text);
        }

        /// <summary>
        /// 导入缺省数据到缓冲区
        /// </summary>
        public void LoadNew()
        {
            if (null == this._dtoAntiControl.dtoHeatingSource )
            {
                this._dtoAntiControl.dtoHeatingSource  = new HeatingSourceDto();
            }
            this._dtoAntiControl.dtoHeatingSource .BalanceTime = DefaultHeatingSource.BalanceTime;
            this._dtoAntiControl.dtoHeatingSource .InitTemp = DefaultHeatingSource.InitTemp;
            this._dtoAntiControl.dtoHeatingSource .MaintainTime = DefaultHeatingSource.MaintainTime;
            this._dtoAntiControl.dtoHeatingSource .AlertTemp = DefaultHeatingSource.AlertTemp;
            this._dtoAntiControl.dtoHeatingSource .ColumnCount = DefaultHeatingSource.ColumnCount;

            this._dtoAntiControl.dtoHeatingSource .RateCol1 = DefaultHeatingSource.RateCol1;
            this._dtoAntiControl.dtoHeatingSource .RateCol2 = DefaultHeatingSource.RateCol2;
            this._dtoAntiControl.dtoHeatingSource .RateCol3 = DefaultHeatingSource.RateCol3;
            this._dtoAntiControl.dtoHeatingSource .RateCol4 = DefaultHeatingSource.RateCol4;
            this._dtoAntiControl.dtoHeatingSource .RateCol5 = DefaultHeatingSource.RateCol5;

            this._dtoAntiControl.dtoHeatingSource .TempCol1 = DefaultHeatingSource.TempCol1;
            this._dtoAntiControl.dtoHeatingSource .TempCol2 = DefaultHeatingSource.TempCol2;
            this._dtoAntiControl.dtoHeatingSource .TempCol3 = DefaultHeatingSource.TempCol3;
            this._dtoAntiControl.dtoHeatingSource .TempCol4 = DefaultHeatingSource.TempCol4;
            this._dtoAntiControl.dtoHeatingSource .TempCol5 = DefaultHeatingSource.TempCol5;

            this._dtoAntiControl.dtoHeatingSource .TempTimeCol1 = DefaultHeatingSource.TempTimeCol1;
            this._dtoAntiControl.dtoHeatingSource .TempTimeCol2 = DefaultHeatingSource.TempTimeCol2;
            this._dtoAntiControl.dtoHeatingSource .TempTimeCol3 = DefaultHeatingSource.TempTimeCol3;
            this._dtoAntiControl.dtoHeatingSource .TempTimeCol4 = DefaultHeatingSource.TempTimeCol4;
            this._dtoAntiControl.dtoHeatingSource .TempTimeCol5 = DefaultHeatingSource.TempTimeCol5;
        }



        /// <summary>
        /// 编辑当前反控的信息
        /// </summary>
        public void LoadEdit()
        {
            this.LoadViewOrSaveAs();

        }

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        public void LoadSaveAs()
        {
            this.LoadViewOrSaveAs();

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
            this._dtoAntiControl.dtoHeatingSource .BalanceTime = Convert.ToSingle(this.txtBalanceTime.Text);
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
            this._dtoAntiControl.dtoHeatingSource .InitTemp = Convert.ToSingle(this.txtInitTemp.Text);
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
            this._dtoAntiControl.dtoHeatingSource .MaintainTime = Convert.ToSingle(this.txtMaintainTime.Text);
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
            this._dtoAntiControl.dtoHeatingSource .AlertTemp = Convert.ToSingle(this.txtAlertTemp.Text);
        }

        /// <summary>
        /// COL程升阶数焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColumnCount_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtColumnCount.Text))
            {
                MessageBox.Show("COL程升阶数不能为空！", "COL程升阶数");
                this.txtColumnCount.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtColumnCount.Text))
            {
                MessageBox.Show("COL程升阶数不是数值！", "COL程升阶数");
                this.txtColumnCount.Focus();
                return;
            }     
            if (Convert.ToSingle(this.txtColumnCount.Text) * 10 % 10 != 0)
            {
                MessageBox.Show("COL程升阶数应为整数", "COL程升阶数");
                this.txtColumnCount.Focus();
                return;
            }
            if (Convert.ToInt32(this.txtColumnCount.Text) < 0 || Convert.ToInt32(this.txtColumnCount.Text) > 5)
            {
                MessageBox.Show("COL程升阶数应在0到5之间","COL程升阶数");
                this.txtColumnCount.Focus();
                return;
            }

            if (Convert.ToInt32(this.txtColumnCount.Text) == 0)
            {
                txtRateCol1.Enabled = false;
                txtTempCol1.Enabled = false;
                txtTempTimeCol1.Enabled = false;

                txtRateCol2.Enabled = false;
                txtTempCol2.Enabled = false;
                txtTempTimeCol2.Enabled = false;

                txtRateCol3.Enabled = false;
                txtTempCol3.Enabled = false;
                txtTempTimeCol3.Enabled = false;

                txtRateCol4.Enabled = false;
                txtTempCol4.Enabled = false;
                txtTempTimeCol4.Enabled = false;

                txtRateCol5.Enabled = false;
                txtTempCol5.Enabled = false;
                txtTempTimeCol5.Enabled = false;
            }
            else if (Convert.ToInt32(this.txtColumnCount.Text) == 1)
            {
                txtRateCol1.Enabled = true;
                txtTempCol1.Enabled = true;
                txtTempTimeCol1.Enabled = true;

                txtRateCol2.Enabled = false;
                txtTempCol2.Enabled = false;
                txtTempTimeCol2.Enabled = false;

                txtRateCol3.Enabled = false;
                txtTempCol3.Enabled = false;
                txtTempTimeCol3.Enabled = false;

                txtRateCol4.Enabled = false;
                txtTempCol4.Enabled = false;
                txtTempTimeCol4.Enabled = false;

                txtRateCol5.Enabled = false;
                txtTempCol5.Enabled = false;
                txtTempTimeCol5.Enabled = false;
            }
            else if (Convert.ToInt32(this.txtColumnCount.Text) == 2)
            {
                txtRateCol1.Enabled = true;
                txtTempCol1.Enabled = true;
                txtTempTimeCol1.Enabled = true;

                txtRateCol2.Enabled = true;
                txtTempCol2.Enabled = true;
                txtTempTimeCol2.Enabled = true;

                txtRateCol3.Enabled = false;
                txtTempCol3.Enabled = false;
                txtTempTimeCol3.Enabled = false;

                txtRateCol4.Enabled = false;
                txtTempCol4.Enabled = false;
                txtTempTimeCol4.Enabled = false;

                txtRateCol5.Enabled = false;
                txtTempCol5.Enabled = false;
                txtTempTimeCol5.Enabled = false;
            }
            else if (Convert.ToInt32(this.txtColumnCount.Text) == 3)
            {
                txtRateCol1.Enabled = true;
                txtTempCol1.Enabled = true;
                txtTempTimeCol1.Enabled = true;

                txtRateCol2.Enabled = true;
                txtTempCol2.Enabled = true;
                txtTempTimeCol2.Enabled = true;

                txtRateCol3.Enabled = true;
                txtTempCol3.Enabled = true;
                txtTempTimeCol3.Enabled = true;

                txtRateCol4.Enabled = false;
                txtTempCol4.Enabled = false;
                txtTempTimeCol4.Enabled = false;

                txtRateCol5.Enabled = false;
                txtTempCol5.Enabled = false;
                txtTempTimeCol5.Enabled = false;
            }
            else if (Convert.ToInt32(this.txtColumnCount.Text) == 4)
            {
                txtRateCol1.Enabled = true;
                txtTempCol1.Enabled = true;
                txtTempTimeCol1.Enabled = true;

                txtRateCol2.Enabled = true;
                txtTempCol2.Enabled = true;
                txtTempTimeCol2.Enabled = true;

                txtRateCol3.Enabled = true;
                txtTempCol3.Enabled = true;
                txtTempTimeCol3.Enabled = true;

                txtRateCol4.Enabled = true;
                txtTempCol4.Enabled = true;
                txtTempTimeCol4.Enabled = true;

                txtRateCol5.Enabled = false;
                txtTempCol5.Enabled = false;
                txtTempTimeCol5.Enabled = false;
            }
            else if (Convert.ToInt32(this.txtColumnCount.Text) == 5)
            {
                txtRateCol1.Enabled = true;
                txtTempCol1.Enabled = true;
                txtTempTimeCol1.Enabled = true;

                txtRateCol2.Enabled = true;
                txtTempCol2.Enabled = true;
                txtTempTimeCol2.Enabled = true;

                txtRateCol3.Enabled = true;
                txtTempCol3.Enabled = true;
                txtTempTimeCol3.Enabled = true;

                txtRateCol4.Enabled = true;
                txtTempCol4.Enabled = true;
                txtTempTimeCol4.Enabled = true;

                txtRateCol5.Enabled = true;
                txtTempCol5.Enabled = true;
                txtTempTimeCol5.Enabled = true;
            }

            this._dtoAntiControl.dtoHeatingSource .ColumnCount = Convert.ToSingle(this.txtColumnCount.Text);
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
            this._dtoAntiControl.dtoHeatingSource .RateCol1 = Convert.ToSingle(this.txtRateCol1.Text);
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
            this._dtoAntiControl.dtoHeatingSource .RateCol2 = Convert.ToSingle(this.txtRateCol2.Text);
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
            this._dtoAntiControl.dtoHeatingSource.RateCol3 = Convert.ToSingle(this.txtRateCol3.Text);
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
            this._dtoAntiControl.dtoHeatingSource .RateCol4 = Convert.ToSingle(this.txtRateCol4.Text);
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
            this._dtoAntiControl.dtoHeatingSource .RateCol5 = Convert.ToSingle(this.txtRateCol5.Text);
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
            this._dtoAntiControl.dtoHeatingSource .TempCol1 = Convert.ToSingle(this.txtTempCol1.Text);
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
            this._dtoAntiControl.dtoHeatingSource .TempCol2 = Convert.ToSingle(this.txtTempCol2.Text);
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
            this._dtoAntiControl.dtoHeatingSource .TempCol3 = Convert.ToSingle(this.txtTempCol3.Text);
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
            this._dtoAntiControl.dtoHeatingSource .TempCol4 = Convert.ToSingle(this.txtTempCol4.Text);
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
            this._dtoAntiControl.dtoHeatingSource .TempCol5 = Convert.ToSingle(this.txtTempCol5.Text);
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
            this._dtoAntiControl.dtoHeatingSource .TempTimeCol1 = Convert.ToSingle(this.txtTempTimeCol1.Text);
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
            this._dtoAntiControl.dtoHeatingSource .TempTimeCol2 = Convert.ToSingle(this.txtTempTimeCol2.Text);
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
            this._dtoAntiControl.dtoHeatingSource .TempTimeCol3 = Convert.ToSingle(this.txtTempTimeCol3.Text);
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
            this._dtoAntiControl.dtoHeatingSource .TempTimeCol4 = Convert.ToSingle(this.txtTempTimeCol4.Text);
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
            this._dtoAntiControl.dtoHeatingSource .TempTimeCol5 = Convert.ToSingle(this.txtTempTimeCol5.Text);
        }

        #endregion


    }
}
