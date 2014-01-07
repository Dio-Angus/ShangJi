/*-----------------------------------------------------------------------------
//  FILE NAME       : MethodEditFrm.cs
//  FUNCTION        : 方法编辑窗口
//  AUTHOR          : 李锋(2009/05//07)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoTool.util;
using ChromatoBll.dao;
using ChromatoTool.ini;
using ChromatoCore.solu.sUi;

namespace ChromatoCore.solu.Ana
{
    /// <summary>
    /// 方法编辑窗口
    /// </summary>
    public partial class AnalyEditFrm : Form
    {

        #region 变量

        /// <summary>
        /// 方法Dto
        /// </summary>
        public AnalyParaDto dtoAnaPara = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public AnalyEditFrm(AnalyParaDto dto, AccessMethod am)
        {
            this.dtoAnaPara = dto;
            InitializeComponent();
            LoadEvent();
            LoadUi(am);
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.btnChangeArith.Click += new System.EventHandler(this.btnChangeArith_Click);
            this.btnChangeArithPara.Click += new System.EventHandler(this.btnChangeArithPara_Click);
            this.btnChangeReserveTime.Click += new System.EventHandler(this.btnChangeReserveTime_Click);
            this.btnChangeColumnModel.Click += new System.EventHandler(this.btnChangeColumnModel_Click);
            this.btnChangeDescription.Click += new System.EventHandler(this.btnChangeDescription_Click);
            this.btnChangeName.Click += new System.EventHandler(this.btnChangeName_Click);
            this.btnAimPara.Click += new System.EventHandler(this.btnAimPara_Click);
            this.btnPeakWide.Click += new System.EventHandler(this.btnPeakWide_Click);
            this.btnSlope.Click += new System.EventHandler(this.btnSlope_Click);
            this.btnDrift.Click += new System.EventHandler(this.btnDrift_Click);
            this.btnMinAreaSize.Click += new System.EventHandler(this.btnMinAreaSize_Click);
            this.btnChangeParaTime.Click += new System.EventHandler(this.btnChangeParaTime_Click);
            this.btnRatio.Click += new System.EventHandler(this.btnRatio_Click);
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi(AccessMethod am)
        {
            switch (am)
            {
                case AccessMethod.Edit:
                    this.Text = "编辑方法";
                    break;
                case AccessMethod.New:
                    this.Text = "新建方法";
                    break;
            }

            //初始化
            this.lblArithmatic.Text = EnumDescription.GetFieldText(this.dtoAnaPara.ArithmaticID);
            this.lblArithmeticPara.Text = EnumDescription.GetFieldText(this.dtoAnaPara.ArithmaticPara);
            this.lblAimWay.Text = EnumDescription.GetFieldText(this.dtoAnaPara.AimWay);
            this.lblColumuModel.Text = this.dtoAnaPara.ColumuModel;
            this.lblDescription.Text = this.dtoAnaPara.Description;
            this.lblAnalyName.Text = this.dtoAnaPara.AnalyName;
            this.lblPeakWide.Text = Convert.ToString(this.dtoAnaPara.PeakWide);
            this.lblSlope.Text = Convert.ToString(this.dtoAnaPara.Slope);
            this.lblDrift.Text = this.dtoAnaPara.Drift.ToString();
            this.lblMinAreaSize.Text = this.dtoAnaPara.MinAreaSize.ToString();
            this.lblChangeParaTime.Text = this.dtoAnaPara.ParaChangeTime.ToString();
            this.lblRatio.Text = this.dtoAnaPara.Ratio.ToString();
            this.lblAimPara.Text = EnumDescription.GetFieldText(this.dtoAnaPara.AimPara);

        }

        #endregion


        #region 事件

 
        /// <summary>
        /// 改变计算方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeArith_Click(object sender, EventArgs e)
        {
            ArithmaticUi ui = new ArithmaticUi(this.dtoAnaPara);
            ui.ShowDialog();
            this.lblArithmatic.Text = EnumDescription.GetFieldText(this.dtoAnaPara.ArithmaticID);

        }
        /// <summary>
        /// 改变算法参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeArithPara_Click(object sender, EventArgs e)
        {
            ArithParaUi ui = new ArithParaUi(this.dtoAnaPara);
            ui.ShowDialog();
            this.lblArithmeticPara.Text = EnumDescription.GetFieldText(this.dtoAnaPara.ArithmaticPara);
        }
        /// <summary>
        /// 改变对准方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeReserveTime_Click(object sender, EventArgs e)
        {
            AimWayUi ui = new AimWayUi(this.dtoAnaPara);
            ui.ShowDialog();
            this.lblAimWay.Text = EnumDescription.GetFieldText(this.dtoAnaPara.AimWay);
        }

        /// <summary>
        /// 改变色谱柱型号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeColumnModel_Click(object sender, EventArgs e)
        {
            ColumnModelUi ui = new ColumnModelUi(this.dtoAnaPara);
            ui.ShowDialog();
            this.lblColumuModel.Text = this.dtoAnaPara.ColumuModel;
        }

        /// <summary>
        /// 改变描述
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeDescription_Click(object sender, EventArgs e)
        {
            DescriptionUi ui = new DescriptionUi(this.dtoAnaPara);
            ui.ShowDialog();
            this.lblDescription.Text = this.dtoAnaPara.Description;
        }

        /// <summary>
        /// 改变方法名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeName_Click(object sender, EventArgs e)
        {
            AnalyNameUi ui = new AnalyNameUi(this.dtoAnaPara);
            ui.ShowDialog();
            this.lblAnalyName.Text = this.dtoAnaPara.AnalyName;
        }

        /// <summary>
        /// 改变峰宽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPeakWide_Click(object sender, EventArgs e)
        {
            PeakWideUi ui = new PeakWideUi(this.dtoAnaPara);
            ui.ShowDialog();
            this.lblPeakWide.Text = Convert.ToString(this.dtoAnaPara.PeakWide);
        }

        /// <summary>
        /// 改变斜率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSlope_Click(object sender, EventArgs e)
        {
            SlopeUi ui = new SlopeUi(this.dtoAnaPara);
            ui.ShowDialog();
            this.lblSlope.Text = Convert.ToString(this.dtoAnaPara.Slope);
        }

        /// <summary>
        /// 改变漂移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrift_Click(object sender, EventArgs e)
        {
            DriftUi ui = new DriftUi(this.dtoAnaPara);
            ui.ShowDialog();
            this.lblDrift.Text = this.dtoAnaPara.Drift.ToString();
        }

        /// <summary>
        /// 改变最小面积
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinAreaSize_Click(object sender, EventArgs e)
        {
            MinAreaSizeUi ui = new MinAreaSizeUi(this.dtoAnaPara);
            ui.ShowDialog();
            this.lblMinAreaSize.Text = this.dtoAnaPara.MinAreaSize.ToString();
        }

        /// <summary>
        /// 改变变参时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeParaTime_Click(object sender, EventArgs e)
        {
            ChangeParaTimeUi ui = new ChangeParaTimeUi(this.dtoAnaPara);
            ui.ShowDialog();
            this.lblChangeParaTime.Text = this.dtoAnaPara.ParaChangeTime.ToString();
        }

        /// <summary>
        /// 改变比例系数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRatio_Click(object sender, EventArgs e)
        {
            RatioUi ui = new RatioUi(this.dtoAnaPara);
            ui.ShowDialog();
            this.lblRatio.Text = this.dtoAnaPara.Ratio.ToString();
        }

        /// <summary>
        /// 改变对准参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAimPara_Click(object sender, EventArgs e)
        {
            AimParaUi ui = new AimParaUi(this.dtoAnaPara);
            ui.ShowDialog();
            this.lblAimPara.Text = EnumDescription.GetFieldText(this.dtoAnaPara.AimPara);
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (0 == this.dtoAnaPara.AnalyParaID)
            {
                MessageBox.Show("请选择方法!", "信息");
                return;
            }
            if ("" == this.dtoAnaPara.AnalyName)
            {
                MessageBox.Show("请输入方法名!", "信息");
                return;
            }
            if ("" == this.dtoAnaPara.Description)
            {
                MessageBox.Show("请输入描述信息!", "信息");
                return;
            }

            AnalyParaDao daoMethod = new AnalyParaDao();
            daoMethod.InsertOrUpdateMethod(dtoAnaPara);
            this.Close();

        }

        #endregion




    
    }
}
