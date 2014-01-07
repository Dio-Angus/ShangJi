/*-----------------------------------------------------------------------------
//  FILE NAME       : OnBottom.cs
//  FUNCTION        : 采集下部项目
//  AUTHOR          : 李锋(2009/05/24)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoTool.ini;
using ChromatoTool.dto;
using ChromatoTool.pipe;
using ChromatoBll.bll;
using ChromatoBll.serialCom;
using System.Drawing;

namespace ChromatoCore.On
{
    /// <summary>
    /// 采集下部项目
    /// </summary>
    public partial class OnBottom : UserControl
    {

        #region 变量

        /// <summary>
        /// 结果面板
        /// </summary>
        public OnHardStatusViewer _viewHardStatus = null;

        /// <summary>
        /// 报告面板
        /// </summary>
        public OnGraphFour _viewGraph = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OnBottom()
        {
            InitializeComponent();
            LoadUi();
        }

        /// <summary>
        /// 装载画面
        /// </summary>
        private void LoadUi()
        {
            this._viewGraph = new OnGraphFour();
            this.Controls.Add(this._viewGraph); 
            
            this._viewHardStatus = new OnHardStatusViewer();
            this.Controls.Add(this._viewHardStatus);

            this.tbMain.SelectedIndexChanged += new System.EventHandler(this.tbMain_SelectedIndexChanged);
            this.tbMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tbMain.DrawItem += new DrawItemEventHandler(this.tbMain_DrawItem);

        }

        #endregion


        #region 方法

        /// <summary>
        /// 装载方法
        /// </summary>
        public void PageResize()
        {

            this._viewHardStatus.Width = this.Width;
            this._viewHardStatus.Top = this.tbMain.Height;
            this._viewHardStatus.Height = this.Height - this.tbMain.Height;
            //this._viewHardStatus.CtrlResize();

            this._viewGraph.Width = this.Width;
            this._viewGraph.Top = this.tbMain.Height;
            this._viewGraph.Height = this.Height - this.tbMain.Height;
            this._viewGraph.OcxResize();
            //this._viewGraph.OcxResizeNormal();
        }

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="lf"></param>
        /// <param name="pipeFullName"></param>
        public void SetPipeName(ChannelID lf, string pipeFullName)
        {
            this._viewGraph.SetPipeName(lf, pipeFullName);
        }

        /// <summary>
        /// 创建显示引擎
        /// </summary>
        /// <param name="lf"></param>
        /// <param name="user"></param>
        /// <param name="pipe"></param>
        public void CreateLayer(ChannelID lf, UserType user, CastPipe pipe)
        {
            this._viewGraph.CreateLayer(lf, user, pipe);
        }

        /// <summary>
        /// 启动采样
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="dtoPara"></param>
        public void StartSample(ChannelCmd cmd, ParaDto dtoPara)
        {
            this._viewGraph.StartSample(dtoPara);
            this.tbMain.SelectedTab = this.FindTabByTag(CollectionTab.RealPlot);

            switch(cmd)
            {
                case ChannelCmd.StartTcd1:
                    this._viewGraph.UpdateTransCollection(ChannelID.A);
                    break;
                case ChannelCmd.StartFid1:
                    this._viewGraph.UpdateTransCollection(ChannelID.B);
                    break;
                case ChannelCmd.StartTcd2:
                    this._viewGraph.UpdateTransCollection(ChannelID.C);
                    break;
                case ChannelCmd.StartFid2:
                    this._viewGraph.UpdateTransCollection(ChannelID.D);
                    break;
            }
        }

        /// <summary>
        /// 某通道的采集方法更新
        /// </summary>
        /// <param name="dtoPara"></param>
        public void UpdateTransCollection(ParaDto dtoPara)
        {

            switch (dtoPara.ChannelID)
            {
                case IdChannel.Tcd1:
                case GasChannel.A:
                    this._viewGraph.UpdateTransCollection(ChannelID.A);
                    break;
                case IdChannel.Fid1:
                case GasChannel.B:
                    this._viewGraph.UpdateTransCollection(ChannelID.B);
                    break;
                case IdChannel.Tcd2:
                case GasChannel.C:
                    this._viewGraph.UpdateTransCollection(ChannelID.C);
                    break;
                case IdChannel.Fid2:
                case GasChannel.D:
                    this._viewGraph.UpdateTransCollection(ChannelID.D);
                    break;
            }
        }

        /// <summary>
        /// 走基线
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dtoPara"></param>
        public void RunBaseSample(ChannelID id, ParaDto dtoPara)
        {
            this._viewGraph.RunBaseSample(id, dtoPara);
            this.tbMain.SelectedTab = this.FindTabByTag(CollectionTab.RealPlot);
            this._viewGraph.UpdateTransCollection(id);
        }

        /// <summary>
        /// 停止采样
        /// </summary>
        /// <param name="channelCmd"></param>
        public void StopSample(ChannelCmd channelCmd)
        {
            switch (channelCmd)
            {
                case ChannelCmd.StopBaseTcd1:
                    this._viewGraph.StopBase(ChannelID.A);
                    break;
                case ChannelCmd.StopTcd1:
                    this._viewGraph.StopSample(ChannelID.A);
                    break;
                
                case ChannelCmd.StopBaseFid1:
                    this._viewGraph.StopBase(ChannelID.B);
                    break;
                case ChannelCmd.StopFid1:
                    this._viewGraph.StopSample(ChannelID.B);
                    break;

                case ChannelCmd.StopBaseTcd2:
                    this._viewGraph.StopBase(ChannelID.C);
                    break;
                case ChannelCmd.StopTcd2:
                    this._viewGraph.StopSample(ChannelID.C);
                    break;

                case ChannelCmd.StopBaseFid2:
                    this._viewGraph.StopBase(ChannelID.D);
                    break;
                case ChannelCmd.StopFid2:
                    this._viewGraph.StopSample(ChannelID.D);
                    break;
            }
            this.tbMain.SelectedTab = this.FindTabByTag(CollectionTab.RealPlot);
        }

        /// <summary>
        /// 查找tab页
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        private TabPage FindTabByTag(string tag)
        {
            foreach (TabPage tp in this.tbMain.TabPages)
            {
                if (tp.Tag.Equals(tag))
                {
                    return tp;
                }
            }
            return null;
        }

        /// <summary>
        /// 停止采集
        /// </summary>
        /// <param name="reason"></param>
        public void StopSample(StopSampleReason reason)
        {
            this._viewGraph.StopSample(reason);

            switch (General.ObjectLink)
            {
                case General.LinkObject.BigBoard:
                    this._viewHardStatus.StopThread();
                    break;
            }
        }

        /// <summary>
        /// 显示当前的tab
        /// </summary>
        private void ShowTab()
        {
            this.UnvisiableAllPanel();

            switch (tbMain.SelectedTab.Tag.ToString())
            {

                case CollectionTab.HardStatus:
                    this._viewHardStatus.Visible = true;
                    break;

                case CollectionTab.RealPlot:
                    this._viewGraph.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// 隐藏所有面板
        /// </summary>
        private void UnvisiableAllPanel()
        {
            this._viewHardStatus.Visible = false;
            this._viewGraph.Visible = false;
        }

        /// <summary>
        /// 下载当前的反控方法到GC
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="type"></param>
        public void DownloadAntiMethod(ParaDto dto, AntiControlType type)
        {
            //查询样品方案ID
            SolutionBiz bizSolu = new SolutionBiz();

            RelationDto dtoRela = new RelationDto();
            dtoRela.SampleID = dto.SampleID;
            dtoRela.RegisterTime = dto.RegisterTime;

            String temp = bizSolu.GetSolutionID(dtoRela);
            SolutionDto dtoSolu = new SolutionDto();
            dtoSolu.SolutionID = Convert.ToInt32(temp);
            bizSolu.QuerySolu(dtoSolu);

            AntiControlDto dtoAnti = new AntiControlDto();
            dtoAnti.AntiControlID = dtoSolu.AntiMethodID;

            //查询反控方法的具体内容
            AntiControlBiz bizAnti = new AntiControlBiz();
            bizAnti.GetMethodByID(dtoAnti);

            //下载
            HardBiz.Instance.DownloadAntiMethod(dtoAnti, type);

        }

        /// <summary>
        /// 通道的显示配置改变，自动更新画面
        /// </summary>
        public void OcxShowChange()
        {
            this._viewGraph.OcxResize();
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
            this.ShowTab();
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
