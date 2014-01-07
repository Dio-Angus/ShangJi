/*-----------------------------------------------------------------------------
//  FILE NAME       : SampleItem.cs
//  FUNCTION        : 样品项目
//  AUTHOR          : 李锋(2009/05/24)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.ini;
using ChromatoTool.pipe;
using ChromatoTool.dto;

namespace ChromatoCore.sample
{
    /// <summary>
    /// 样品项目
    /// </summary>
    public partial class SampleItem : UserControl
    {

        #region 变量

        /// <summary>
        /// 信息面板
        /// </summary>
        private SampleUs _viewInfo = null;

        /// <summary>
        /// 结果面板
        /// </summary>
        private SampleResult _viewResult = null;

        /// <summary>
        /// 报告面板
        /// </summary>
        private SampleReportViewer _viewReport = null;

        /// <summary>
        /// 备注面板
        /// </summary>
        public SampleRemarkViewer _viewRemark = null;

        /// <summary>
        /// 样品dto
        /// </summary>
        private ParaDto _dtoPara = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SampleItem()
        {
            InitializeComponent();
            LoadUi();
        }

        /// <summary>
        /// 装载画面
        /// </summary>
        private void LoadUi()
        {
            switch (General.ObjectLink)
            {
                case General.LinkObject.ChannelGas:
                case General.LinkObject.AutoChromatoGas:
                    this._viewInfo = (SampleUs)new SampleGasInfoViewer(AccessMethod.View);
                    break;
                default:
                    this._viewInfo = (SampleUs)new SampleInfoViewer(AccessMethod.View);
                    break;
            }
            this.Controls.Add(this._viewInfo);

            this._viewResult = new SampleResult();
            this.Controls.Add(this._viewResult);

            this._viewReport = new SampleReportViewer();
            this.Controls.Add(this._viewReport);

            this._viewRemark = new SampleRemarkViewer();
            this.Controls.Add(this._viewRemark);

            this.tbMain.SelectedIndexChanged += new System.EventHandler(this.tbMain_SelectedIndexChanged);
            this.tbMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tbMain.DrawItem += new DrawItemEventHandler(this.tbMain_DrawItem);

        }

        #endregion


        #region 方法

        /// <summary>
        /// 创建显示引擎
        /// </summary>
        /// <param name="lf"></param>
        /// <param name="user"></param>
        /// <param name="pipe"></param>
        public void CreateLayer(ChannelID lf, UserType user, CastPipe pipe)
        {
            this._viewResult.CreateLayer(lf, user, pipe);
        }

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="pipeFullName"></param>
        public void SetPipeName(string pipeFullName)
        {
            this._viewResult.SetPipeName(pipeFullName);
        }

        /// <summary>
        /// 装载方法
        /// </summary>
        public void LoadPage()
        {
            this._viewInfo.Width = this.Width;
            this._viewInfo.Top = this.tbMain.Height;
            this._viewInfo.Height = this.Height - this.tbMain.Height;

            this._viewResult.Width = this.Width;
            this._viewResult.Top = this.tbMain.Height;
            this._viewResult.Height = this.Height - this.tbMain.Height;
            this._viewResult.PageResize();

            this._viewReport.Width = this.Width;
            this._viewReport.Top = this.tbMain.Height;
            this._viewReport.Height = this.Height - this.tbMain.Height;
            this._viewReport.CtrlResize();

            this._viewRemark.Width = this.Width;
            this._viewRemark.Top = this.tbMain.Height;
            this._viewRemark.Height = this.Height - this.tbMain.Height;
            this._viewRemark.CtrlResize();

        }

        /// <summary>
        /// 装载数据流
        /// </summary>
        /// <param name="dto"></param>
        public void LoadItem(ParaDto dto)
        {
            this._dtoPara = dto;
            this.LoadViewer();
        }

        /// <summary>
        /// 装载视图
        /// </summary>
        private void LoadViewer()
        {

            switch (tbMain.SelectedTab.Tag.ToString())
            {
                case SampleTab.Info:
                    if (null != this._dtoPara)
                    {
                        this._viewInfo.LoadUi(this._dtoPara);
                    }
                    this._viewInfo.Visible = true;
                    break;
                case SampleTab.Result:
                    if (null != this._dtoPara)
                    {
                        this._viewResult.LoadPlot(this._dtoPara);
                    }
                    this._viewResult.Visible = true;
                    break;
                case SampleTab.Report:
                    if (null != this._dtoPara)
                    {
                        this._viewReport.LoadUi(this._dtoPara);
                    }
                    this._viewReport.Visible = true;
                    break;
                case SampleTab.Remark:
                    if (null != this._dtoPara)
                    {
                        this._viewRemark.LoadUi(this._dtoPara);
                    }
                    this._viewRemark.Visible = true;
                    break;
            }
        }


        /// <summary>
        /// 隐藏所有面板
        /// </summary>
        private void UnvisiableAllUser()
        {
            this._viewInfo.Visible = false;
            this._viewResult.Visible = false;
            this._viewReport.Visible = false;
            this._viewRemark.Visible = false;
        }

        #endregion


        #region 事件

        /// <summary>
        /// 索引改变后显示TAB切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UnvisiableAllUser();
            this.LoadViewer();
            
        }

        /// <summary>
        /// 描画Tab项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbMain_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {

            Font fontPage;
            Brush brushBkColor;
            Brush brushForeColor;


            Graphics g = e.Graphics;
            String txtPageName = this.tbMain.TabPages[e.Index].Text;
            Rectangle rectPage = e.Bounds;

            if (e.Index == this.tbMain.SelectedIndex)
            {
                fontPage = e.Font;
                brushForeColor = Brushes.Black;
                brushBkColor = Brushes.Ivory;

                //fntTab = new Font(e.Font, FontStyle.Regular);
                //bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, SystemColors.Control, SystemColors.Control, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                //bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, Color.Transparent, Color.LightGreen, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                //bshBack = new SolidBrush(Color.White);
                //bshFore = new SolidBrush(Color.Black);
                rectPage = new Rectangle(this.tbMain.Bounds.X, e.Bounds.Bottom + 4, this.tbMain.Bounds.Width, this.tbMain.Height - e.Bounds.Height - 4);
                //g.FillRectangle(brushBkColor, rectPage);
                //g.DrawRectangle(Pens.Black, rectPage);
            }
            else
            {
                fontPage = e.Font;
                brushForeColor = Brushes.Black;
                brushBkColor = new SolidBrush(SystemColors.Control);
            }

            StringFormat formatText = new StringFormat();
            g.FillRectangle(brushBkColor, e.Bounds);

            rectPage = new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width + 2, e.Bounds.Height - 2);
            g.DrawString(txtPageName, fontPage, brushForeColor, rectPage, formatText);

        }

        #endregion

    }
}
