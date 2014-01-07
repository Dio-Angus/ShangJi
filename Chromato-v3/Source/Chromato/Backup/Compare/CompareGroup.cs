/*-----------------------------------------------------------------------------
//  FILE NAME       : CompareGroup.cs
//  FUNCTION        : 比较组合
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
    /// 比较组合
    /// </summary>
    public partial class CompareGroup : UserControl
    {


        #region 变量

        /// <summary>
        /// 分隔条
        /// </summary>
        private Splitter _splitterMain = null;

        /// <summary>
        /// 样品列表
        /// </summary>
        private CompareList _listCompare = null;

        /// <summary>
        /// 样品项目集合
        /// </summary>
        private CompareBottom _bottomCompare = null;

        /// <summary>
        /// 样品dto
        /// </summary>
        private ParaDto _dtoPara = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public CompareGroup()
        {
            InitializeComponent();
            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._listCompare = new CompareList();
            this._listCompare.Dock = DockStyle.Top;

            this._splitterMain = new Splitter();
            this._splitterMain.Dock = System.Windows.Forms.DockStyle.Top;
            this._splitterMain.Location = new System.Drawing.Point(0, 2);
            this._splitterMain.Name = "splitterMain";
            this._splitterMain.Size = new System.Drawing.Size(666, 3);
            this._splitterMain.TabIndex = 20;
            this._splitterMain.TabStop = false;

            this._bottomCompare = new CompareBottom();
            this._bottomCompare.Dock = DockStyle.Fill;

            this.Controls.Add(this._bottomCompare);
            this.Controls.Add(this._splitterMain);
            this.Controls.Add(this._listCompare);

            this._splitterMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitterMain_SplitterMoved);

            //列表窗口追加样品事件
            this._listCompare.SampleAdded += new EventHandler<CompareSampleAddArgs>(listCompare_SampleAdded);
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
            this._bottomCompare.CreateLayer(lf, user, pipe);
        }

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="pipeFullName"></param>
        public void SetPipeName(string pipeFullName)
        {
            this._bottomCompare.SetPipeName(pipeFullName);
        }

        /// <summary>
        /// 改变各个page改变大小
        /// </summary>
        public void PageResize()
        {
            this._listCompare.Width = this.Width;
            this._listCompare.Height = this._splitterMain.Top;
            //this.listCompare.UserResize();

            this._splitterMain.Width = this.Width;
            this._splitterMain.Location = new Point(0, this._listCompare.Bottom);
            //this.splitterMain.BackColor = Color.BlueViolet;

            this._bottomCompare.Width = this.Width;
            this._bottomCompare.Top = this._listCompare.Bottom + this._splitterMain.Height;
            this._bottomCompare.Height = this.Height - this._listCompare.Height - this._splitterMain.Height;
            this._bottomCompare.PageResize();
        }

        /// <summary>
        /// 装载历史曲线
        /// </summary>
        /// <param name="dto"></param>
        public void LoadItem(ParaDto dto)
        {

            Cursor.Current = Cursors.WaitCursor;

            //装载曲线
            this._bottomCompare.LoadPlot(dto);
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 停止线程
        /// </summary>
        public void StopThread()
        {
            this._bottomCompare.StopThread();
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

        /// <summary>
        /// 列表窗口更换样品事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listCompare_SampleAdded(object sender, CompareSampleAddArgs e)
        {
            this._dtoPara = (ParaDto)e._var;
            this.LoadItem(this._dtoPara);
        }

        #endregion


    }
}
