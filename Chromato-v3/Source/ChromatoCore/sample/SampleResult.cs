/*-----------------------------------------------------------------------------
//  FILE NAME       : SampleResult.cs
//  FUNCTION        : 样品结果组合
//  AUTHOR          : 李锋(2009/06/04)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.ini;
using ChromatoTool.pipe;
using ChromatoTool.dto;
using System.Data;

namespace ChromatoCore.sample
{
    /// <summary>
    /// 样品结果组合
    /// </summary>
    public partial class SampleResult : UserControl
    {

        #region 变量

        /// <summary>
        /// 分隔条
        /// </summary>
        private Splitter splitterMain = null;

        /// <summary>
        /// 样品图形
        /// </summary>
        private SampleGraphViewer _graphViewer = null;

        /// <summary>
        /// 样品结果
        /// </summary>
        private SampleResultViewer _resultViewer = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SampleResult()
        {
            InitializeComponent();
            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._graphViewer = new SampleGraphViewer();
            this._graphViewer.Dock = DockStyle.Top;

            this.splitterMain = new Splitter();

            splitterMain.MinExtra = 100;
            splitterMain.MinSize = 95;

            this.splitterMain.Dock = DockStyle.Top;
            this.splitterMain.Location = new System.Drawing.Point(0, 2);
            this.splitterMain.Name = "splitterMain";
            this.splitterMain.Size = new System.Drawing.Size(666, 3);
            this.splitterMain.TabIndex = 20;
            this.splitterMain.TabStop = false;
            this.splitterMain.SplitterMoved += new SplitterEventHandler(this.splitterMain_SplitterMoved);

            this._resultViewer = new SampleResultViewer();
            this._resultViewer.Dock = DockStyle.Fill;

            this.Controls.Add(this._resultViewer);
            this.Controls.Add(this.splitterMain);
            this.Controls.Add(this._graphViewer);

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
            this._graphViewer.CreateLayer(lf, user, pipe);
        }

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="pipeFullName"></param>
        public void SetPipeName(string pipeFullName)
        {
            this._graphViewer.SetPipeName(pipeFullName);
        }

        /// <summary>
        /// 改变各个page改变大小
        /// </summary>
        public void PageResize()
        {
            this._graphViewer.Width = this.Width;
            this._graphViewer.Height = this.splitterMain.Top;// * 2 / 3;
            this._graphViewer.OcxResize();

            this.splitterMain.Width = this.Width;
            this.splitterMain.Location = new Point(0, this._graphViewer.Bottom);
            //this.splitterMain.BackColor = Color.BlueViolet;

            this._resultViewer.Width = this.Width;
            this._resultViewer.Top = this._graphViewer.Bottom + this.splitterMain.Height;
            this._resultViewer.Height = this.Height - this._graphViewer.Height - this.splitterMain.Height;
            //this._resultViewer.LoadPage();
        }

        /// <summary>
        /// 从数据库装载数据
        /// </summary>
        /// <param name="dto"></param>
        public void LoadPlot(ParaDto dto)
        {
            Cursor.Current = Cursors.WaitCursor;
            this._graphViewer.LoadPlot(dto);
            DataSet ds = this._resultViewer.LoadResult(dto);
            this._graphViewer.LoadLabelAndBaseline(ds, dto);
            Cursor.Current = Cursors.Default;
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
