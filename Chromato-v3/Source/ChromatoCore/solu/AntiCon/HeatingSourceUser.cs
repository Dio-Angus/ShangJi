using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoTool.ini;
using ChromatoTool.util;

namespace ChromatoCore.solu.AntiCon
{
    public partial class HeatingSourceUser : UserControl
    {
        private AntiControlDto _dtoAntiControl = null;

        /// <summary>
        /// 构造
        /// </summary>
        public HeatingSourceUser(AntiControlDto dto)
        {
            InitializeComponent();
            this._dtoAntiControl = dto;
        }

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        public void LoadView(int antiControlID)
        {
            //this.LoadViewOrSaveAs();
            //this.LoadControlStyle(true);
        }

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        public void LoadSaveAs()
        {
            //this.LoadViewOrSaveAs();
            //this.LoadControlStyle(true);
        }

        /// <summary>
        /// 编辑当前反控的信息
        /// </summary>
        public void LoadEdit()
        {
            //this.LoadViewOrSaveAs();
            //this.LoadControlStyle(false);
        }

        /// <summary>
        /// 新建立反控的信息
        /// </summary>
        public void LoadNew()
        {

            /*this.LoadControlStyle(false);


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
            this.txtTempTimeCol5.Text = DefaultColumnPara.TempTimeCol5.ToString();*/
        }
    }
}
