/*-----------------------------------------------------------------------------
//  FILE NAME       : AnalyViewer.cs
//  FUNCTION        : 分析方法视图
//  AUTHOR          : 李锋(2009/06/12)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.ini;
using ChromatoTool.dto;
using ChromatoBll.bll;
using ChromatoTool.util;

namespace ChromatoCore.solu.Ana
{
    /// <summary>
    /// 分析方法视图
    /// </summary>
    public partial class AnalyViewer : UserControl
    {

        #region 变量

        /// <summary>
        /// 类访问方式
        /// </summary>
        public AccessMethod _accessM = AccessMethod.New;

        /// <summary>
        /// 方案dto
        /// </summary>
        private SolutionDto _dto = null;

        /// <summary>
        /// 分析方法逻辑
        /// </summary>
        private AnalyParaBiz _bizAnaly = null;

        /// <summary>
        /// 分析方法dto
        /// </summary>
        private AnalyParaDto _dtoAnaly = null;

        /// <summary>
        /// 是否第一次装载
        /// </summary>
        private bool _isFirst = true;

        /// <summary>
        /// 编辑状态下是否改变了数据
        /// </summary>
        private bool _isEdit = false;

        /// <summary>
        /// 分析方法选择改变事件
        /// </summary>
        public event EventHandler<AnalyParaChangeArgs> ParaChanged;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public AnalyViewer(AccessMethod am)
        {
            InitializeComponent();
            this._accessM = am;
            this._bizAnaly = new AnalyParaBiz();

            this.LoadEvent();
            this._dtoAnaly = new AnalyParaDto();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.rbNormalize.CheckedChanged += new System.EventHandler(this.rbNormalize_CheckedChanged);
            this.rbFixNormalize.CheckedChanged += new System.EventHandler(this.rbFixNormalize_CheckedChanged);
            this.rbFixNormalizeWithRate.CheckedChanged += new System.EventHandler(this.rbFixNormalizeWithRate_CheckedChanged);
            this.rbInner.CheckedChanged += new System.EventHandler(this.rbInner_CheckedChanged);
            this.rbOuter.CheckedChanged += new System.EventHandler(this.rbOuter_CheckedChanged);
            this.rbExponent.CheckedChanged += new System.EventHandler(this.rbExponent_CheckedChanged);

            this.rbArea.CheckedChanged += new System.EventHandler(this.rbArea_CheckedChanged);
            this.rbHeight.CheckedChanged += new System.EventHandler(this.rbHeight_CheckedChanged);

            this.rbTimeWindow.CheckedChanged += new System.EventHandler(this.rbTimeWindow_CheckedChanged);
            this.rbTimeBand.CheckedChanged += new System.EventHandler(this.rbTimeBand_CheckedChanged);

            this.rbAbsolute.CheckedChanged += new System.EventHandler(this.rbAbsolute_CheckedChanged);
            this.rbRelative.CheckedChanged += new System.EventHandler(this.rbRelative_CheckedChanged);

            this.txtAnalyName.TextChanged += new System.EventHandler(this.txtAnalyName_TextChanged);
            this.txtColumnModel.TextChanged += new System.EventHandler(this.txtColumnModel_TextChanged);
            this.rtbDescription.TextChanged += new System.EventHandler(this.rtbDescription_TextChanged);

            this.numUDPeakWide.TextChanged += new System.EventHandler(this.numUDPeakWide_TextChanged);
            this.numUDPeakWide.Leave += new System.EventHandler(this.numUDPeakWide_Leave);

            this.numUDSlope.TextChanged += new System.EventHandler(this.numUDSlope_TextChanged);
            this.numUDSlope.Leave += new System.EventHandler(this.numUDSlope_Leave);

            this.numUdDrift.TextChanged += new System.EventHandler(this.numUdDrift_TextChanged);
            this.numUdDrift.Leave += new System.EventHandler(this.numUdDrift_Leave);

            this.numUdMinArea.TextChanged += new System.EventHandler(this.numUdMinArea_TextChanged);
            this.numUdMinArea.Leave += new System.EventHandler(this.numUdMinArea_Leave);

            this.numUDParaChangeTime.TextChanged += new System.EventHandler(this.numUDParaChangeTime_TextChanged);
            this.numUDParaChangeTime.Leave += new System.EventHandler(this.numUDParaChangeTime_Leave);

            this.numUdRatio.TextChanged += new System.EventHandler(this.numUdRatio_TextChanged);
            this.numUdRatio.Leave += new System.EventHandler(this.numUdRatio_Leave);

            this.numUDTimeWindow.TextChanged += new System.EventHandler(this.numUDTimeWindow_TextChanged);
            this.numUDTimeWindow.Leave += new System.EventHandler(this.numUDTimeWindow_Leave);

            this.cmbFixCurve.SelectedIndexChanged += new System.EventHandler(this.cmbFixCurve_SelectedIndexChanged);
        }

        #endregion


        #region 方法

        /// <summary>
        /// 复位，清除标志，用户选择的分析方法改变
        /// </summary>
        public void Reset(int analyID)
        {
            this.LoadView(analyID);
            this._isFirst = false;
        }

        /// <summary>
        /// 显示分析方法的详细信息
        /// </summary>
        /// <param name="dto"></param>
        public void LoadUi(SolutionDto dto)
        {
            this._dto = dto;
            //this.numUDPeakWide.Enabled = (null == this._dto) ? false : true;
            //this.numUDSlope.Enabled = (null == this._dto) ? false : true;
            //this.numUDStopTime.Enabled = (null == this._dto) ? false : true;
            //this.txtShowMaxY.Enabled = (null == this._dto) ? false : true;
            //this.txtShowMinY.Enabled = (null == this._dto) ? false : true;
            //this.numUDFullScreenTime.Enabled = (null == this._dto) ? false : true;
            //this.cbxAutoSlope.Enabled = (null == this._dto) ? false : true;
            //this.txtCollectionName.Enabled = (null == this._dto) ? false : true;
            this.gbAnaly.Enabled = (null == this._dto) ? false : true;
            if (null == this._dto)
            {
                return;
            }

            switch (this._accessM)
            {
                case AccessMethod.View:
                    this.LoadView(this._dto.AnalyParaID);
                    break;

                case AccessMethod.New:
                    if (this._isFirst)
                    {
                        this.LoadNew();
                        this._isFirst = false;
                    }
                    break;

                case AccessMethod.Edit:
                    if (this._isFirst)
                    {
                        this.LoadEdit();
                        this._isFirst = false;
                    }
                    break;

                case AccessMethod.SaveAs:   //复制当前分析方法
                    if (this._isFirst)
                    {
                        this.LoadView(this._dto.AnalyParaID);
                        this._isFirst = false;
                    }
                    break;
            }
        }

        /// <summary>
        /// 显示分析方法
        /// </summary>
        private void LoadView(int analyID)
        {
            this._dtoAnaly.AnalyParaID = analyID;

            //查询分析方法的具体内容
            this._bizAnaly.GetMethodByID(this._dtoAnaly);

            this.txtAnalyName.Text = this._dtoAnaly.AnalyName;
            this.LoadViewOrSaveAs();
        }

        /// <summary>
        /// 查看或者复制
        /// </summary>
        private void LoadViewOrSaveAs()
        {
            this.txtColumnModel.Text = this._dtoAnaly.ColumuModel;
            this.rtbDescription.Text = this._dtoAnaly.Description;

            this.numUDPeakWide.Maximum = Convert.ToInt32(this._dtoAnaly.PeakWide);
            this.numUDPeakWide.Minimum = Convert.ToInt32(this._dtoAnaly.PeakWide);
            this.numUDPeakWide.Value = Convert.ToInt32(this._dtoAnaly.PeakWide);

            this.numUDSlope.Maximum = Convert.ToInt32(this._dtoAnaly.Slope);
            this.numUDSlope.Minimum = Convert.ToInt32(this._dtoAnaly.Slope);
            this.numUDSlope.Value = Convert.ToInt32(this._dtoAnaly.Slope);

            this.numUdDrift.Maximum = Convert.ToInt32(this._dtoAnaly.Drift);
            this.numUdDrift.Minimum = Convert.ToInt32(this._dtoAnaly.Drift);
            this.numUdDrift.Value = Convert.ToInt32(this._dtoAnaly.Drift);

            this.numUdMinArea.Maximum = Convert.ToInt32(this._dtoAnaly.MinAreaSize);
            this.numUdMinArea.Minimum = Convert.ToInt32(this._dtoAnaly.MinAreaSize);
            this.numUdMinArea.Value = Convert.ToInt32(this._dtoAnaly.MinAreaSize);

            this.numUDParaChangeTime.Maximum = Convert.ToInt32(this._dtoAnaly.ParaChangeTime);
            this.numUDParaChangeTime.Minimum = Convert.ToInt32(this._dtoAnaly.ParaChangeTime);
            this.numUDParaChangeTime.Value = Convert.ToInt32(this._dtoAnaly.ParaChangeTime);

            this.numUdRatio.Maximum = Convert.ToInt32(this._dtoAnaly.Ratio);
            this.numUdRatio.Minimum = Convert.ToInt32(this._dtoAnaly.Ratio);
            this.numUdRatio.Value = Convert.ToInt32(this._dtoAnaly.Ratio);

            this.numUDTimeWindow.Maximum = Convert.ToInt32(this._dtoAnaly.TimeWindow);
            this.numUDTimeWindow.Minimum = Convert.ToInt32(this._dtoAnaly.TimeWindow);
            this.numUDTimeWindow.Value = Convert.ToInt32(this._dtoAnaly.TimeWindow);

            this.LoadRadioBtn();

            this.rbTimeWindow.Enabled = this.rbTimeWindow.Checked;
            this.rbTimeBand.Enabled = this.rbTimeBand.Checked;

            this.rbAbsolute.Enabled = this.rbAbsolute.Checked;
            this.rbRelative.Enabled = this.rbRelative.Checked;

            this.rbArea.Enabled = this.rbArea.Checked;
            this.rbHeight.Enabled = this.rbHeight.Checked;

            this.rbNormalize.Enabled = this.rbNormalize.Checked;
            this.rbFixNormalize.Enabled = this.rbFixNormalize.Checked;
            this.rbFixNormalizeWithRate.Enabled = this.rbFixNormalizeWithRate.Checked;
            this.rbInner.Enabled = this.rbInner.Checked;
            this.rbOuter.Enabled = this.rbOuter.Checked;
            this.rbExponent.Enabled = this.rbExponent.Checked;

            this.cmbFixCurve.Items.Clear();
            switch (this._dtoAnaly.FixWay)
            {
                case FixCurveWay.PolyLine:
                    this.cmbFixCurve.Items.Add(EnumDescription.GetFieldText(FixCurveWay.PolyLine));
                    break;
                case FixCurveWay.SimuLine:
                    this.cmbFixCurve.Items.Add(EnumDescription.GetFieldText(FixCurveWay.SimuLine));
                    break;
            }
            this.cmbFixCurve.SelectedIndex = 0;

            this.txtAnalyName.ReadOnly = true;
            this.txtColumnModel.ReadOnly = true;
            this.rtbDescription.ReadOnly = true;

            this.numUDPeakWide.ReadOnly = true;
            this.numUDSlope.ReadOnly = true;
            this.numUdDrift.ReadOnly = true;
            this.numUdMinArea.ReadOnly = true;
            this.numUDParaChangeTime.ReadOnly = true;
            this.numUdRatio.ReadOnly = true;
            this.numUDTimeWindow.ReadOnly = true;

            this.txtAnalyName.BackColor = Color.Beige;
            this.txtColumnModel.BackColor = Color.Beige;
            this.rtbDescription.BackColor = Color.Beige;
            this.cmbFixCurve.BackColor = Color.Beige;

            this.numUDPeakWide.BackColor = Color.Beige;
            this.numUDSlope.BackColor = Color.Beige;
            this.numUdDrift.BackColor = Color.Beige;
            this.numUdMinArea.BackColor = Color.Beige;
            this.numUDParaChangeTime.BackColor = Color.Beige;
            this.numUdRatio.BackColor = Color.Beige;
            this.numUDTimeWindow.BackColor = Color.Beige;
        }

        /// <summary>
        /// 新建立方法
        /// </summary>
        private void LoadNew()
        {

            this.txtAnalyName.BackColor = Color.White;
            this.txtColumnModel.BackColor = Color.White;
            this.rtbDescription.BackColor = Color.White;
            this.cmbFixCurve.BackColor = Color.White;

            this.numUDPeakWide.BackColor = Color.White;
            this.numUDSlope.BackColor = Color.White;
            this.numUdDrift.BackColor = Color.White;
            this.numUdMinArea.BackColor = Color.White;
            this.numUDParaChangeTime.BackColor = Color.White;
            this.numUdRatio.BackColor = Color.White;
            this.numUDTimeWindow.BackColor = Color.White;

            this.txtAnalyName.Text = "新建分析方法";
            this.txtColumnModel.Text = DefaultAnaly.ColumuModel;
            this.rtbDescription.Text = DefaultAnaly.Description;

            this.numUDPeakWide.Value = DefaultAnaly.PeakWide;
            this.numUDSlope.Value = DefaultAnaly.Slope;
            this.numUdDrift.Value = DefaultAnaly.Drift;
            this.numUdMinArea.Value = Convert.ToInt32(DefaultAnaly.MinAreaSize);
            this.numUDParaChangeTime.Value = DefaultAnaly.ParaChangeTime;
            this.numUdRatio.Value = Convert.ToInt32(DefaultAnaly.Ratio);
            this.numUDTimeWindow.Value = Convert.ToInt32(DefaultAnaly.TimeWindow);

            switch (DefaultAnaly.AimPara)
            {
                case AimPara.TimeWindow:
                    this.rbTimeWindow.Checked = true;
                    break;
                case AimPara.TimeBand:
                    this.rbTimeBand.Checked = true;
                    break;
            }

            switch (DefaultAnaly.AimWay)
            {
                case AimWay.Absolute:
                    this.rbAbsolute.Checked = true;
                    break;
                case AimWay.Relative:
                    this.rbRelative.Checked = true;
                    break;
            }

            switch (DefaultAnaly.ArithmaticParameter)
            {
                case ArithmaticParameter.Area:
                    this.rbArea.Checked = true;
                    break;
                case ArithmaticParameter.Height:
                    this.rbHeight.Checked = true;
                    break;
            }

            switch (DefaultAnaly.Arithmatic)
            {
                case Arithmatic.Normalize:
                    this.rbNormalize.Checked = true;
                    break;
                case Arithmatic.FixNormalize:
                    this.rbFixNormalize.Checked = true;
                    break;
                case Arithmatic.FixNormalizeWithRate:
                    this.rbFixNormalizeWithRate.Checked = true;
                    break;
                case Arithmatic.Inner:
                    this.rbInner.Checked = true;
                    break;
                case Arithmatic.Outer:
                    this.rbOuter.Checked = true;
                    break;
                case Arithmatic.Exponent:
                    this.rbExponent.Checked = true;
                    break;
            }

            this._dtoAnaly.AimPara = DefaultAnaly.AimPara;
            this._dtoAnaly.AimWay = DefaultAnaly.AimWay;
            this._dtoAnaly.AnalyName = this.txtAnalyName.Text;
            this._dtoAnaly.ArithmaticID = DefaultAnaly.Arithmatic;
            this._dtoAnaly.ArithmaticPara = DefaultAnaly.ArithmaticParameter;
            this._dtoAnaly.ColumuModel = DefaultAnaly.ColumuModel;
            this._dtoAnaly.Description = DefaultAnaly.Description;
            this._dtoAnaly.Drift = DefaultAnaly.Drift;
            this._dtoAnaly.MinAreaSize = DefaultAnaly.MinAreaSize;
            this._dtoAnaly.ParaChangeTime = DefaultAnaly.ParaChangeTime;
            this._dtoAnaly.PeakWide = DefaultAnaly.PeakWide;
            this._dtoAnaly.Ratio = DefaultAnaly.Ratio;
            this._dtoAnaly.Slope = DefaultAnaly.Slope;
            this._dtoAnaly.TimeWindow = DefaultAnaly.TimeWindow;
            this._dtoAnaly.FixWay = DefaultAnaly.FixWay;

            this.cmbFixCurve.Items.Add(EnumDescription.GetFieldText(FixCurveWay.PolyLine));
            this.cmbFixCurve.Items.Add(EnumDescription.GetFieldText(FixCurveWay.SimuLine));
            this.cmbFixCurve.SelectedIndex = (int)this._dtoAnaly.FixWay;

        }

        /// <summary>
        /// 编辑当前分析方法
        /// </summary>
        private void LoadEdit()
        {
            this._dtoAnaly.AnalyParaID = this._dto.AnalyParaID;

            //查询分析方法的具体内容
            this._bizAnaly.GetMethodByID(this._dtoAnaly);

            this.txtAnalyName.Text = this._dtoAnaly.AnalyName;
            this.txtColumnModel.Text = this._dtoAnaly.ColumuModel;
            this.rtbDescription.Text = this._dtoAnaly.Description;

            this.numUDPeakWide.Value = Convert.ToInt32(this._dtoAnaly.PeakWide);
            this.numUDSlope.Value = Convert.ToInt32(this._dtoAnaly.Slope);
            this.numUdDrift.Value = Convert.ToInt32(this._dtoAnaly.Drift);
            this.numUdMinArea.Value = Convert.ToInt32(this._dtoAnaly.MinAreaSize);
            this.numUDParaChangeTime.Value = Convert.ToInt32(this._dtoAnaly.ParaChangeTime);
            this.numUdRatio.Value = Convert.ToInt32(this._dtoAnaly.Ratio);
            this.numUDTimeWindow.Value = Convert.ToInt32(this._dtoAnaly.TimeWindow);

            this.txtAnalyName.BackColor = Color.White;
            this.txtColumnModel.BackColor = Color.White;
            this.rtbDescription.BackColor = Color.White;
            this.cmbFixCurve.BackColor = Color.White;

            this.numUDPeakWide.BackColor = Color.White;
            this.numUDSlope.BackColor = Color.White;
            this.numUdDrift.BackColor = Color.White;
            this.numUdMinArea.BackColor = Color.White;
            this.numUDParaChangeTime.BackColor = Color.White;
            this.numUdRatio.BackColor = Color.White;
            this.numUDTimeWindow.BackColor = Color.White;

            this.txtAnalyName.ReadOnly = false;
            this.txtColumnModel.ReadOnly = false;
            this.rtbDescription.ReadOnly = false;

            this.numUDPeakWide.ReadOnly = false;
            this.numUDSlope.ReadOnly = false;
            this.numUdDrift.ReadOnly = false;
            this.numUdMinArea.ReadOnly = false;
            this.numUDParaChangeTime.ReadOnly = false;
            this.numUdRatio.ReadOnly = false;
            this.numUDTimeWindow.ReadOnly = false;

            this.LoadRadioBtn();
            this.numUDTimeWindow.Enabled = this.rbTimeWindow.Checked;

            this.cmbFixCurve.Items.Add(EnumDescription.GetFieldText(FixCurveWay.PolyLine));
            this.cmbFixCurve.Items.Add(EnumDescription.GetFieldText(FixCurveWay.SimuLine));
            this.cmbFixCurve.SelectedIndex = (int)this._dtoAnaly.FixWay;

            this.SendParaChangedEvent();

        }

        /// <summary>
        /// 装载选项按钮
        /// </summary>
        private void LoadRadioBtn()
        {

            switch (this._dtoAnaly.AimPara)
            {
                case AimPara.TimeWindow:
                    this.rbTimeWindow.Checked = true;
                    break;
                case AimPara.TimeBand:
                    this.rbTimeBand.Checked = true;
                    break;
            }

            switch (this._dtoAnaly.AimWay)
            {
                case AimWay.Absolute:
                    this.rbAbsolute.Checked = true;
                    break;
                case AimWay.Relative:
                    this.rbRelative.Checked = true;
                    break;
            }

            switch (this._dtoAnaly.ArithmaticPara)
            {
                case ArithmaticParameter.Area:
                    this.rbArea.Checked = true;
                    break;
                case ArithmaticParameter.Height:
                    this.rbHeight.Checked = true;
                    break;
            }

            switch (this._dtoAnaly.ArithmaticID)
            {
                case Arithmatic.Normalize:
                    this.rbNormalize.Checked = true;
                    break;
                case Arithmatic.FixNormalize:
                    this.rbFixNormalize.Checked = true;
                    break;
                case Arithmatic.FixNormalizeWithRate:
                    this.rbFixNormalizeWithRate.Checked = true;
                    break;
                case Arithmatic.Inner:
                    this.rbInner.Checked = true;
                    break;
                case Arithmatic.Outer:
                    this.rbOuter.Checked = true;
                    break;
                case Arithmatic.Exponent:
                    this.rbExponent.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// 显示复制分析方法
        /// </summary>
        private void LoadSaveAs()
        {
            this._dtoAnaly.AnalyParaID = this._dto.AnalyParaID;

            //查询分析方法的具体内容
            this._bizAnaly.GetMethodByID(this._dtoAnaly);

            this.txtAnalyName.Text = this._dtoAnaly.AnalyName + DateTime.Now.ToString("_yyyyMMdd");
            this.LoadViewOrSaveAs();
        }

        /// <summary>
        /// 插入分析方法
        /// </summary>
        public void SaveNew(SolutionDto dto)
        {
            if (0 == dto.AnalyParaID)
            {
                this._bizAnaly.InsertMethod(this._dtoAnaly);
                dto.AnalyParaID = this._dtoAnaly.AnalyParaID;
            }
        }

        /// <summary>
        /// 更新分析方法
        /// </summary>
        public void SaveEdit()
        {
            //如果用户编辑过了，那么更新数据库
            if (this._isEdit)
            {
                this._bizAnaly.UpdateMethod(this._dtoAnaly);
            }
        }

        /// <summary>
        /// 向ID表画面发送分析方法变更事件
        /// </summary>
        private void SendParaChangedEvent()
        {
            AnalyParaChangeArgs eve = new AnalyParaChangeArgs(this._dtoAnaly);
            if (ParaChanged != null)
            {
                this.ParaChanged(this, eve);
            }
        }

        #endregion


        #region 事件

        /// <summary>
        /// 归一法按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbNormalize_CheckedChanged(object sender, EventArgs e)
        {
            if (this._dtoAnaly.ArithmaticID == Arithmatic.Normalize)
            {
                return;
            }

            this._dtoAnaly.ArithmaticID = Arithmatic.Normalize;

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 修正归一法按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbFixNormalize_CheckedChanged(object sender, EventArgs e)
        {
            if (this._dtoAnaly.ArithmaticID == Arithmatic.FixNormalize)
            {
                return;
            }

            this._dtoAnaly.ArithmaticID = Arithmatic.FixNormalize;

            //更新变更标志
            this._isEdit = true;

            this.SendParaChangedEvent();
        }

        /// <summary>
        /// 带比例修正归一法按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbFixNormalizeWithRate_CheckedChanged(object sender, EventArgs e)
        {
            if (this._dtoAnaly.ArithmaticID == Arithmatic.FixNormalizeWithRate)
            {
                return;
            }

            this._dtoAnaly.ArithmaticID = Arithmatic.FixNormalizeWithRate;

            //更新变更标志
            this._isEdit = true;

            this.SendParaChangedEvent();
        }

        /// <summary>
        /// 内标法按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbInner_CheckedChanged(object sender, EventArgs e)
        {
            if (this._dtoAnaly.ArithmaticID == Arithmatic.Inner)
            {
                return;
            }

            this._dtoAnaly.ArithmaticID = Arithmatic.Inner;

            //更新变更标志
            this._isEdit = true;

            this.SendParaChangedEvent();
        }

        /// <summary>
        /// 外标法按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbOuter_CheckedChanged(object sender, EventArgs e)
        {
            if (this._dtoAnaly.ArithmaticID == Arithmatic.Outer)
            {
                return;
            }

            this._dtoAnaly.ArithmaticID = Arithmatic.Outer;

            //更新变更标志
            this._isEdit = true;

            this.SendParaChangedEvent();
        }

        /// <summary>
        /// 指数法按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbExponent_CheckedChanged(object sender, EventArgs e)
        {
            if (this._dtoAnaly.ArithmaticID == Arithmatic.Exponent)
            {
                return;
            }

            this._dtoAnaly.ArithmaticID = Arithmatic.Exponent;

            //更新变更标志
            this._isEdit = true;

            this.SendParaChangedEvent();
        }

        /// <summary>
        /// 面积按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbArea_CheckedChanged(object sender, EventArgs e)
        {
            if (this._dtoAnaly.ArithmaticPara == ArithmaticParameter.Area)
            {
                return;
            }

            this._dtoAnaly.ArithmaticPara = ArithmaticParameter.Area;

            //更新变更标志
            this._isEdit = true;

            this.SendParaChangedEvent();
        }

        /// <summary>
        /// 高度按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbHeight_CheckedChanged(object sender, EventArgs e)
        {
            if (this._dtoAnaly.ArithmaticPara == ArithmaticParameter.Height)
            {
                return;
            }

            this._dtoAnaly.ArithmaticPara = ArithmaticParameter.Height;

            //更新变更标志
            this._isEdit = true;

            this.SendParaChangedEvent();

        }

        /// <summary>
        /// 时间窗按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbTimeWindow_CheckedChanged(object sender, EventArgs e)
        {
            this._dtoAnaly.AimPara = AimPara.TimeWindow;
            this.numUDTimeWindow.Enabled = true;

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 时间带按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbTimeBand_CheckedChanged(object sender, EventArgs e)
        {
            this._dtoAnaly.AimPara = AimPara.TimeBand;
            this.numUDTimeWindow.Enabled = false;

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 绝对按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbAbsolute_CheckedChanged(object sender, EventArgs e)
        {
            this._dtoAnaly.AimWay = AimWay.Absolute;

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 相对按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbRelative_CheckedChanged(object sender, EventArgs e)
        {
            this._dtoAnaly.AimWay = AimWay.Relative;

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 分析方法名称焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAnalyName_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtAnalyName.Text))
            {
                MessageBox.Show("分析方法名称不能为空！", "分析方法名称");
                this.txtAnalyName.Focus();
                return;
            }
            this._dtoAnaly.AnalyName = this.txtAnalyName.Text;

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 色谱柱型号焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColumnModel_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtColumnModel.Text))
            {
                MessageBox.Show("色谱柱型号不能为空！", "色谱柱型号");
                this.txtColumnModel.Focus();
                return;
            }
            this._dtoAnaly.ColumuModel = this.txtColumnModel.Text;

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 描述焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.rtbDescription.Text))
            {
                MessageBox.Show("描述不能为空！", "描述");
                this.rtbDescription.Focus();
                return;
            }
            this._dtoAnaly.Description = this.rtbDescription.Text;

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 峰宽文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDPeakWide_TextChanged(object sender, EventArgs e)
        {

            Int32 v = Convert.ToInt32(this.numUDPeakWide.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 100 < v)
            {
                MessageBox.Show("峰宽范围不正确！", "峰宽");
                this.numUDPeakWide.Focus();
                return;
            }
            this._dtoAnaly.PeakWide = Convert.ToInt32(this.numUDPeakWide.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 峰宽焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDPeakWide_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUDPeakWide.Value.ToString()))
            {
                MessageBox.Show("峰宽范围不正确！", "峰宽");
                this.numUDPeakWide.Focus();
                return;
            }
            this._dtoAnaly.PeakWide = Convert.ToInt32(this.numUDPeakWide.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 斜率文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDSlope_TextChanged(object sender, EventArgs e)
        {
            Int32 v = Convert.ToInt32(this.numUDSlope.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 100000 < v)
            {
                MessageBox.Show("斜率范围不正确！", "斜率");
                this.numUDSlope.Focus();
                return;
            }
            this._dtoAnaly.Slope = Convert.ToInt32(this.numUDSlope.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        ///  斜率焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDSlope_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUDSlope.Value.ToString()))
            {
                MessageBox.Show("斜率范围不正确！", "斜率");
                this.numUDSlope.Focus();
                return;
            }
            this._dtoAnaly.Slope = Convert.ToInt32(this.numUDSlope.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 漂移文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUdDrift_TextChanged(object sender, EventArgs e)
        {
            Int32 v = Convert.ToInt32(this.numUdDrift.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 10000 < v)
            {
                MessageBox.Show("漂移范围不正确！", "漂移");
                this.numUdDrift.Focus();
                return;
            }
            this._dtoAnaly.Drift = Convert.ToInt32(this.numUdDrift.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        ///  漂移焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUdDrift_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUdDrift.Value.ToString()))
            {
                MessageBox.Show("漂移范围不正确！", "漂移");
                this.numUdDrift.Focus();
                return;
            }
            this._dtoAnaly.Drift = Convert.ToInt32(this.numUdDrift.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 最小面积文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUdMinArea_TextChanged(object sender, EventArgs e)
        {
            Int32 v = Convert.ToInt32(this.numUdMinArea.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 10000 < v)
            {
                MessageBox.Show("最小面积范围不正确！", "最小面积");
                this.numUdMinArea.Focus();
                return;
            }
            this._dtoAnaly.MinAreaSize = Convert.ToInt32(this.numUdMinArea.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        ///  最小面积焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUdMinArea_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUdMinArea.Value.ToString()))
            {
                MessageBox.Show("最小面积范围不正确！", "最小面积");
                this.numUdMinArea.Focus();
                return;
            }
            this._dtoAnaly.MinAreaSize = Convert.ToInt32(this.numUdMinArea.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 变参时间文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDParaChangeTime_TextChanged(object sender, EventArgs e)
        {
            Int32 v = Convert.ToInt32(this.numUDParaChangeTime.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 10000 < v)
            {
                MessageBox.Show("变参时间范围不正确！", "变参时间");
                this.numUDParaChangeTime.Focus();
                return;
            }
            this._dtoAnaly.ParaChangeTime = Convert.ToInt32(this.numUDParaChangeTime.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        ///  变参时间焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDParaChangeTime_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUDParaChangeTime.Value.ToString()))
            {
                MessageBox.Show("变参时间范围不正确！", "变参时间");
                this.numUDParaChangeTime.Focus();
                return;
            }
            this._dtoAnaly.ParaChangeTime = Convert.ToInt32(this.numUDParaChangeTime.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 比例系数文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUdRatio_TextChanged(object sender, EventArgs e)
        {
            Int32 v = Convert.ToInt32(this.numUdRatio.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 10000 < v)
            {
                MessageBox.Show("比例系数范围不正确！", "比例系数");
                this.numUdRatio.Focus();
                return;
            }
            this._dtoAnaly.Ratio = Convert.ToInt32(this.numUdRatio.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        ///  比例系数焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUdRatio_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUdRatio.Value.ToString()))
            {
                MessageBox.Show("比例系数范围不正确！", "比例系数");
                this.numUdRatio.Focus();
                return;
            }
            this._dtoAnaly.Ratio = Convert.ToInt32(this.numUdRatio.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 时间窗文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDTimeWindow_TextChanged(object sender, EventArgs e)
        {
            Int32 v = Convert.ToInt32(this.numUDTimeWindow.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 10000 < v)
            {
                MessageBox.Show("时间窗范围不正确！", "时间窗");
                this.numUDTimeWindow.Focus();
                return;
            }
            this._dtoAnaly.TimeWindow = Convert.ToInt32(this.numUDTimeWindow.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        ///  时间窗焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDTimeWindow_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUDTimeWindow.Value.ToString()))
            {
                MessageBox.Show("时间窗范围不正确！", "时间窗");
                this.numUDTimeWindow.Focus();
                return;
            }
            this._dtoAnaly.TimeWindow = Convert.ToInt32(this.numUDTimeWindow.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 校正方法选项变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFixCurve_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._dtoAnaly.FixWay == (FixCurveWay)this.cmbFixCurve.SelectedIndex)
            {
                return;
            }

            this._dtoAnaly.FixWay = (FixCurveWay)this.cmbFixCurve.SelectedIndex;

            this.SendParaChangedEvent();
        }
        #endregion



    }
}
