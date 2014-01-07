/*-----------------------------------------------------------------------------
//  FILE NAME       : GeneralUser.cs
//  FUNCTION        : GeneralUser
//  AUTHOR          : 李锋(2009/03/10)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoBll.ocx;
using ChromatoTool.ini;
using ChromatoTool.util;

namespace ChromatoCore.uiConf
{
    /// <summary>
    /// 常规配置
    /// </summary>
    public partial class GeneralUser : UserControl
    {

        #region 构造
        
        /// <summary>
        /// 构造
        /// </summary>
        public GeneralUser()
        {
            InitializeComponent();
            this.LoadUi();
            this.LoadEvent();
        }

        /// <summary>
        /// 装载参数
        /// </summary>
        private void LoadUi()
        {
            // 图形控件背景色
            this.lblBkColor.BackColor = OffGraphBiz.Instance.GetBkColor();
            //异或,反色
            this.lblBkColor.ForeColor = Color.FromArgb(this.lblBkColor.BackColor.ToArgb() ^ 0xffffff);

            // DGV背景色
            this.lblDgvBackColor.BackColor = Color.FromArgb(General.DgvBackColor);


            this.numUDSampleRate.Value = Convert.ToDecimal(General.Frequent);
            this.numUDMoveUnit.Value = Convert.ToDecimal(General.MoveUnit);

            // 十字光标颜色
            this.LoadArrowColor();

            //设置采集对象(模拟，小板卡，大板卡，通道气板卡)
            this.cmbLinkObject.SelectedIndex = (int)General.ObjectLink;
            this.cmbLinkObject.Enabled = false;

            //设置是否启动日志记录器
            this.cbxLog.Checked = General.TraceLog;

            //设置是否自动命名
            this.cbxAutoName.Checked = General.AutoName;

            //设置十字光标大小
            switch (General.ArrowStyle)
            {
                case General.StyleArrow.Small:
                    this.rbSmall.Checked = true;
                    break;
                case General.StyleArrow.Big:
                    this.rbBig.Checked = true;
                    break;
            }

            //设置是否显示十字光标
            this.cbxOpenArrow.Checked = General.OpenArrow;

            //设置找峰方法
            this.cmbPeakSolution.Items.Add(EnumDescription.GetFieldText(PeakSolution.StatusMachine));
            this.cmbPeakSolution.Items.Add(EnumDescription.GetFieldText(PeakSolution.XCast));
            this.cmbPeakSolution.SelectedIndex = (int)General.SolutionPeak;
            this.cmbPeakSolution.Enabled = false;

            //设置扫描周期
            this.cmbScanPeriod.Items.Add(EnumDescription.GetFieldText(PeriodScan.OneHundred));
            this.cmbScanPeriod.Items.Add(EnumDescription.GetFieldText(PeriodScan.TwoHundred));
            this.cmbScanPeriod.Items.Add(EnumDescription.GetFieldText(PeriodScan.FourHundred));
            this.cmbScanPeriod.Items.Add(EnumDescription.GetFieldText(PeriodScan.EightHundred));
            this.cmbScanPeriod.Items.Add(EnumDescription.GetFieldText(PeriodScan.OneThousand));
            this.cmbScanPeriod.SelectedIndex = (int)General.ScanPeriod;

            //设置实时显示的通道
            switch (General.ObjectLink)
            {
                case General.LinkObject.AutoChromatoGas:
                case General.LinkObject.ChannelGas:
                    this.cbxTcd1.Text = GasChannel.A;
                    this.cbxTcd2.Text = GasChannel.C;
                    this.cbxFid1.Text = GasChannel.B;
                    this.cbxFid2.Text = GasChannel.D;
                    this.cbxSyn.Visible = true;
                    break;
                default:
                    this.cbxTcd1.Text = IdChannel.Tcd1;
                    this.cbxTcd2.Text = IdChannel.Tcd2;
                    this.cbxFid1.Text = IdChannel.Fid1;
                    this.cbxFid2.Text = IdChannel.Fid2;
                    this.cbxSyn.Visible = false;
                    break;
            }

            this.cbxTcd1.Checked = ShowChannel.A;
            this.cbxTcd2.Checked = ShowChannel.C;
            this.cbxFid1.Checked = ShowChannel.B;
            this.cbxFid2.Checked = ShowChannel.D;

            //是否同步（同时走基线，启动，停止）
            this.cbxSyn.Checked = ShowChannel.Syn;

            //检查通道是否正常，全无设置Tcd1为缺省
            if (!(this.cbxTcd1.Checked || this.cbxTcd2.Checked || this.cbxFid1.Checked || this.cbxFid2.Checked))
            {
                this.cbxTcd1.Checked = true;
                ShowChannel.A = true;
            }
            this.CheckChannel();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.cmbPeakSolution.SelectedIndexChanged += new System.EventHandler(this.cmbPeakSolution_SelectedIndexChanged);
            this.cmbLinkObject.SelectedIndexChanged += new System.EventHandler(this.cmbLinkObject_SelectedIndexChanged);
            this.cmbScanPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbScanPeriod_SelectedIndexChanged);

            this.cbxLog.CheckedChanged += new System.EventHandler(this.cbxLog_CheckedChanged);
            this.cbxAutoName.CheckedChanged += new System.EventHandler(this.cbxAutoName_CheckedChanged);
            this.cbxTcd1.CheckedChanged += new System.EventHandler(this.cbxTcd1_CheckedChanged);
            this.cbxTcd2.CheckedChanged += new System.EventHandler(this.cbxTcd2_CheckedChanged);
            this.cbxFid1.CheckedChanged += new System.EventHandler(this.cbxFid1_CheckedChanged);
            this.cbxFid2.CheckedChanged += new System.EventHandler(this.cbxFid2_CheckedChanged);
            this.cbxSyn.CheckedChanged += new System.EventHandler(this.cbxSyn_CheckedChanged);
        }

        /// <summary>
        /// 装载十字光标颜色
        /// </summary>
        private void LoadArrowColor()
        {
            this.lblArrowColor.BackColor = CastColor.GetArgbColor(General.ArrowColor);
            this.lblArrowColor.ForeColor = CastColor.GetArgbColor(General.ArrowColor ^ 0xffffff);
        }

        /// <summary>
        /// 检查通道是否正常，全无设置Tcd1
        /// </summary>
        private void CheckChannel()
        {
            if ((this.cbxTcd1.Checked && !this.cbxTcd2.Checked && !this.cbxFid1.Checked && !this.cbxFid2.Checked))
            {
                this.cbxTcd1.Enabled = false;
            }
            else if ((!this.cbxTcd1.Checked && this.cbxTcd2.Checked && !this.cbxFid1.Checked && !this.cbxFid2.Checked))
            {
                this.cbxTcd2.Enabled = false;
            }
            else if ((!this.cbxTcd1.Checked && !this.cbxTcd2.Checked && this.cbxFid1.Checked && !this.cbxFid2.Checked))
            {
                this.cbxFid1.Enabled = false;
            }
            else if ((!this.cbxTcd1.Checked && !this.cbxTcd2.Checked && !this.cbxFid1.Checked && this.cbxFid2.Checked))
            {
                this.cbxFid2.Enabled = false;
            }
            else
            {
                this.cbxTcd1.Enabled = true;
                this.cbxTcd2.Enabled = true;
                this.cbxFid1.Enabled = true;
                this.cbxFid2.Enabled = true;
            }
        }

        #endregion


        #region 参数更新事件

        /// <summary>
        /// 控件背景色更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblBkColor_Click(object sender, EventArgs e)
        {
            this.colorDlgBK.Color = OffGraphBiz.Instance.GetBkColor();
            if (DialogResult.OK == this.colorDlgBK.ShowDialog())
            {
                OffGraphBiz.Instance.SetBkColor(this.colorDlgBK.Color);
                this.lblBkColor.BackColor = this.colorDlgBK.Color;
                //异或,反色
                this.lblBkColor.ForeColor = Color.FromArgb(this.lblBkColor.BackColor.ToArgb() ^ 0xffffff);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblDgvBackColor_Click(object sender, EventArgs e)
        {
            this.colorDlgBK.Color = Color.FromArgb(General.DgvBackColor);
            if (DialogResult.OK == this.colorDlgBK.ShowDialog())
            {

                this.lblDgvBackColor.BackColor = this.colorDlgBK.Color;
                General.DgvBackColor = this.colorDlgBK.Color.ToArgb();
            }
        }


        /// <summary>
        /// 采样频率更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDSampleRate_ValueChanged(object sender, EventArgs e)
        {
            General.Frequent = Convert.ToInt32(this.numUDSampleRate.Value.ToString());
        }

        /// <summary>
        /// 移动单位更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDMoveUnit_ValueChanged(object sender, EventArgs e)
        {
            General.MoveUnit = Convert.ToInt32(this.numUDMoveUnit.Value.ToString());
        }

        /// <summary>
        ///十字光标颜色更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblArrowColor_Click(object sender, EventArgs e)
        {
            this.colorDlgBK.Color = CastColor.GetArgbColor(General.ArrowColor);
            this.colorDlgBK.ShowDialog();

            General.ArrowColor = CastColor.GetCustomColor(this.colorDlgBK.Color);
            // 十字光标颜色
            this.LoadArrowColor();
        }

        /// <summary>
        /// 是否启动日志记录器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxLog_CheckedChanged(object sender, EventArgs e)
        {
            General.TraceLog = this.cbxLog.Checked;
        }

        /// <summary>
        /// 选中小光标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            General.ArrowStyle = General.StyleArrow.Small;
        }

        /// <summary>
        /// 选中大光标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbBig_CheckedChanged(object sender, EventArgs e)
        {
            General.ArrowStyle = General.StyleArrow.Big;
        }

        /// <summary>
        /// 是否显示十字光标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxOpenArrow_CheckedChanged(object sender, EventArgs e)
        {
            General.OpenArrow = this.cbxOpenArrow.Checked;
        }

        /// <summary>
        /// 选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbLinkObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            General.ObjectLink = (General.LinkObject)this.cmbLinkObject.SelectedIndex;
        }

        /// <summary>
        /// 找峰方法变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPeakSolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            General.SolutionPeak = (PeakSolution)this.cmbPeakSolution.SelectedIndex;
        }

        /// <summary>
        /// 扫描周期变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbScanPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            General.ScanPeriod = (PeriodScan)this.cmbScanPeriod.SelectedIndex;
        }

        /// <summary>
        /// 是否自动命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxAutoName_CheckedChanged(object sender, EventArgs e)
        {
            General.AutoName = this.cbxAutoName.Checked;
        }

        /// <summary>
        /// 是否实时显示Tcd1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxTcd1_CheckedChanged(object sender, EventArgs e)
        {
            ShowChannel.A = this.cbxTcd1.Checked;
            this.CheckChannel();
        }

        /// <summary>
        /// 是否实时显示Tcd2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxTcd2_CheckedChanged(object sender, EventArgs e)
        {
            ShowChannel.C = this.cbxTcd2.Checked;
            this.CheckChannel();
        }

        /// <summary>
        /// 是否实时显示Fid1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxFid1_CheckedChanged(object sender, EventArgs e)
        {
            ShowChannel.B = this.cbxFid1.Checked;
            this.CheckChannel();
        }

        /// <summary>
        /// 是否实时显示Fid2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxFid2_CheckedChanged(object sender, EventArgs e)
        {
            ShowChannel.D = this.cbxFid2.Checked;
            this.CheckChannel();
        }

        /// <summary>
        /// 是否同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxSyn_CheckedChanged(object sender, EventArgs e)
        {
            ShowChannel.Syn = this.cbxSyn.Checked;
        }

        #endregion


    }
}
