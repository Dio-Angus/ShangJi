/*-----------------------------------------------------------------------------
//  FILE NAME       : CompareBottom.cs
//  FUNCTION        : 比较下部项目
//  AUTHOR          : 李锋(2009/07/28)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoTool.ini;
using ChromatoTool.pipe;

namespace ChromatoCore.Compare
{
    /// <summary>
    /// 比较下部项目
    /// </summary>
    public partial class CompareBottom : UserControl
    {

        #region 变量

        /// <summary>
        /// 分隔条
        /// </summary>
        private Splitter _splitterMain = null;

        /// <summary>
        /// 样品列表
        /// </summary>
        private CompareGraphViewer _compareGraphViewer = null;

        /// <summary>
        /// 样品项目集合
        /// </summary>
        private CompareColor _colorCompare = null;

        /// <summary>
        /// 样品信息dto
        /// </summary>
        private ParaDto _dtoPara = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public CompareBottom()
        {
            InitializeComponent();
            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._compareGraphViewer = new CompareGraphViewer();
            this._compareGraphViewer.Dock = DockStyle.Left;

            this._splitterMain = new Splitter();
            this._splitterMain.Dock = System.Windows.Forms.DockStyle.Left;
            this._splitterMain.Location = new System.Drawing.Point(0, 2);
            this._splitterMain.Name = "splitterMain";
            this._splitterMain.Size = new System.Drawing.Size(3, 555);
            this._splitterMain.TabIndex = 20;
            this._splitterMain.TabStop = false;
            this._splitterMain.SplitterMoved += new SplitterEventHandler(this.splitterMain_SplitterMoved);

            this._colorCompare = new CompareColor();
            this._colorCompare.Dock = DockStyle.Fill;

            this.Controls.Add(this._colorCompare);
            this.Controls.Add(this._splitterMain);
            this.Controls.Add(this._compareGraphViewer);

            //曲线颜色变更事件
            this._colorCompare.ColorChanged += new EventHandler<ChangeColorArgs>(this._compareGraphViewer.plot_ColorChanged);

            //项目移出事件
            this._colorCompare.ItemRemoved += new EventHandler<ChangeColorArgs>(this._compareGraphViewer.plot_ItemRemoved);
          
            //曲线是否显示变更事件
            this._colorCompare.ShowChanged += new EventHandler<ChangeShowArgs>(this._compareGraphViewer.plot_ShowChanged);

            //当前选中的样品参数变更事件
            this._colorCompare.CurrentSample += new EventHandler<CurrentSampleArgs>(this._compareGraphViewer.plot_SampleCurrent);
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
            this._compareGraphViewer.CreateLayer(lf, user, pipe);
            this._compareGraphViewer.LoadInit(this._colorCompare.GetCompareArr());
        }

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="pipeFullName"></param>
        public void SetPipeName(string pipeFullName)
        {
            this._compareGraphViewer.SetPipeName(pipeFullName);
        }

        /// <summary>
        /// 改变各个page改变大小
        /// </summary>
        public void PageResize()
        {
            this._compareGraphViewer.Height = this.Height;
            this._compareGraphViewer.Width = this._splitterMain.Left; // this.Height * 2 / 3;
            this._compareGraphViewer.OcxResize();

            this._splitterMain.Height = this.Height;
            this._splitterMain.Location = new Point(this._compareGraphViewer.Right, 0);
            //this.splitterMain.BackColor = Color.BlueViolet;

            this._colorCompare.Height = this.Height;
            this._colorCompare.Left = this._compareGraphViewer.Right + this._splitterMain.Width;
            this._colorCompare.Width = this.Width - this._compareGraphViewer.Width - this._splitterMain.Width;
        }

        /// <summary>
        /// 从数据库装载数据
        /// </summary>
        /// <param name="dto"></param>
        public void LoadPlot(ParaDto dto)
        {
            if (String.IsNullOrEmpty(dto.PathData))
            {
                return;
            }

            this._dtoPara = dto;
            CompareDto dtoCompare = null;
            if (this._colorCompare.LoadToList(dto, ref dtoCompare))
            {
                this._compareGraphViewer.AppendPlot(dtoCompare,this._colorCompare.GetCompareArr());
            }
        }

        /// <summary>
        /// 停止线程
        /// </summary>
        public void StopThread()
        {
            this._compareGraphViewer.StopThread();
        }

        #endregion


        #region 事件

        /// <summary>
        /// 分割条事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitterMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.PageResize();
        }

        #endregion


    }
}
