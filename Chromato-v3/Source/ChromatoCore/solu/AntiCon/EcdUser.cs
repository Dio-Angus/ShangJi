using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoTool.ini;
using ChromatoTool.util;

namespace ChromatoCore.solu.AntiCon
{
    public partial class EcdUser : UserControl
    { 
        #region 变量

        /// <summary>
        /// 分析方法dto
        /// </summary>
        private AntiControlDto _dtoAntiControl = null;

        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public EcdUser(AntiControlDto dto)
        {
            InitializeComponent();
            this._dtoAntiControl = dto;
            //this.LoadEvent();
        }

        #region 方法

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        public void LoadView(int antiControlID)
        {
           // this.LoadViewOrSaveAs();
            //this.LoadControlStyle(true);
        }

        /*// <summary>
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
        }*/
        public void LoadNew()
        { }

        /// <summary>
        /// 编辑当前反控的信息
        /// </summary>
        public void LoadEdit()
        {
           // this.LoadViewOrSaveAs();
            //this.LoadControlStyle(false);
        }

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        public void LoadSaveAs()
        {
          //  this.LoadViewOrSaveAs();
            //this.LoadControlStyle(true);
        }

        #endregion
    }
}
