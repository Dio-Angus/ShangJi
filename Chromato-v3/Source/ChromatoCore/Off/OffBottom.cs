/*-----------------------------------------------------------------------------
//  FILE NAME       : OffBottom.cs
//  FUNCTION        : 重分析下部项目
//  AUTHOR          : 李锋(2009/05/21)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoTool.ini;
using System.Drawing;
using ChromatoTool.pipe;
using ChromatoTool.dto;
using System.Data;
using System.Collections;

namespace ChromatoCore.Off
{
    /// <summary>
    /// 重分析下部项目
    /// </summary>
    public partial class OffBottom : UserControl
    {

        #region 变量

        /// <summary>
        /// 分隔条
        /// </summary>
        private Splitter splitterMain = null;

        /// <summary>
        /// 样品列表
        /// </summary>
        private OffGraphViewer _offGraphViewer = null;

        /// <summary>
        /// 样品项目集合
        /// </summary>
        private OffItem _offItem = null;

        /// <summary>
        /// 样品信息dto
        /// </summary>
        private ParaDto _dtoPara = null;

        /// <summary>
        /// 结果数据集合
        /// </summary>
        private DataSet _dsResult = null;

        /// <summary>
        /// 原始数据集合
        /// </summary>
        private DataSet _dsPlot = null;

        /// <summary> 
        /// 跨线程控件代理
        /// </summary> 
        private delegate void CrossThreadOperationControl();

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OffBottom()
        {
            InitializeComponent();
            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._offGraphViewer = new OffGraphViewer();
            this._offGraphViewer.Dock = DockStyle.Top;

            this.splitterMain = new Splitter();
            this.splitterMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterMain.Location = new System.Drawing.Point(0, 2);
            this.splitterMain.Name = "splitterMain";
            this.splitterMain.Size = new System.Drawing.Size(666, 3);
            this.splitterMain.TabIndex = 20;
            this.splitterMain.TabStop = false;
            this.splitterMain.SplitterMoved += new SplitterEventHandler(this.splitterMain_SplitterMoved);

            this._offItem = new OffItem();
            this._offItem.Dock = DockStyle.Fill;

            this.Controls.Add(this._offItem);
            this.Controls.Add(this.splitterMain);
            this.Controls.Add(this._offGraphViewer);

            //脱机联机返回事件
            this._offGraphViewer.AnalysisEvent += new AnalysisDelegate(this.ReAnalysis);

            //峰删除刷新事件
            this._offGraphViewer.PeakDeleted += new EventHandler<OffPeakDeleteArgs>(offGraph_PeakDeleted);

            //手动基线刷新事件
            this._offGraphViewer.PeakAdded += new EventHandler<ManualBaselineArgs>(offGraph_PeakAdded);

            //垂直切割刷新事件
            this._offGraphViewer.PeakSplited += new EventHandler<OffPeakSplitArgs>(offGraph_PeakSplited);

            //导出按钮按下的事件
            this._offGraphViewer.ExportToFileEvent += new ExportToFileDelegate(this.ExportToFile);

            //峰的强制拖尾刷新事件
            this._offGraphViewer.PeakTailed += new EventHandler<OffPeakTypeChangedArgs>(offGraph_PeakTailed);
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
            this._offGraphViewer.CreateLayer(lf, user, pipe);
        }

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="pipeFullName"></param>
        public void SetPipeName(string pipeFullName)
        {
            this._offGraphViewer.SetPipeName(pipeFullName);
        }

        /// <summary>
        /// 改变各个page改变大小
        /// </summary>
        public void PageResize()
        {
            this._offGraphViewer.Width = this.Width;
            this._offGraphViewer.Height = this.splitterMain.Top; // this.Height * 2 / 3;
            this._offGraphViewer.OcxResize();

            this.splitterMain.Width = this.Width;
            this.splitterMain.Location = new Point(0, this._offGraphViewer.Bottom);
            //this.splitterMain.BackColor = Color.BlueViolet;

            this._offItem.Width = this.Width;
            this._offItem.Top = this._offGraphViewer.Bottom + this.splitterMain.Height;
            this._offItem.Height = this.Height - this._offGraphViewer.Height - this.splitterMain.Height;
            this._offItem.UserResize();
        }

        /// <summary>
        /// 从数据库装载数据
        /// </summary>
        /// <param name="dto"></param>
        public void LoadPlot(ParaDto dto)
        {

            this._dtoPara = dto;
            this._offGraphViewer.LoadPlot(dto, ref this._dsPlot);

            if (null != dto && !String.IsNullOrEmpty(dto.PathData))
            {
                this._dsResult = this._offItem._resultViewer.LoadResult(dto);
                this._offGraphViewer.LoadLabelAndBaseline(this._dsResult, dto);
                this._offItem._configViewer.LoadView(dto);
            }
        }

        /// <summary>
        /// 重新分析
        /// </summary>
        public void Analysis(ParaDto dto)
        {
            if (String.IsNullOrEmpty(dto.PathData))
            {
                return;
            }
            this._dtoPara = dto;
            this.ReAnalysis();
        }

        /// <summary>
        /// 重新分析
        /// </summary>
        private void ReAnalysis()
        {
            Cursor.Current = Cursors.WaitCursor;

            this._offGraphViewer._arrDeducted = this._offItem._configViewer.LoadOriForDeducted();
            this._offGraphViewer.Analysis(this._dtoPara);
            this._dsResult = this._offItem._resultViewer.LoadResult(this._dtoPara);
            this._offGraphViewer.LoadLabelAndBaseline(this._dsResult, this._dtoPara);

            this._offItem._configViewer.LoadView(this._dtoPara);
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 导出数据和结果到文件
        /// </summary>
        private void ExportToFile()
        {
            Cursor.Current = Cursors.WaitCursor;

            ArrayList arr = new ArrayList();
            //this._offGraphViewer.LoadAvgForExport(this._dtoPara, arr);
            this._offGraphViewer.LoadOriForExport(this._dtoPara, arr);

            
            //this._offItem._exportViewer.ExportToFile(this._dsPlot,
            //    this._dtoPara.SampleID,
            //    this._dsResult);
            this._offItem._exportViewer.ExportToFile(arr, this._dtoPara, this._dsResult);
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 重新分析
        /// </summary>
        public void AutoAnalysis(ParaDto dto)
        {
            Cursor.Current = Cursors.WaitCursor;

            // 匿名代理
            CrossThreadOperationControl CrossAutoAnalysis = delegate()
            {
                this._offGraphViewer.Analysis(dto);
                //this.Analysis(dto);
            };
            if (this.InvokeRequired)
            {
                this.Invoke(CrossAutoAnalysis);
            }
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
        /// 图形窗口峰删除参数类事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void offGraph_PeakDeleted(object sender, OffPeakDeleteArgs e)
        {

            this._dsResult = this._offItem._resultViewer.LoadResult(this._dtoPara);
            //this._offGraphViewer.LoadLabelAndBaseline(ds, this._dtoPara);
            this._offItem._configViewer.LoadView(this._dtoPara);
        }

        /// <summary>
        /// 图形窗口手动基线刷新参数事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void offGraph_PeakAdded(object sender, ManualBaselineArgs e)
        {

            this._dsResult = this._offItem._resultViewer.LoadResult(this._dtoPara);
            //this._offGraphViewer.LoadLabelAndBaseline(ds, this._dtoPara);
            this._offItem._configViewer.LoadView(this._dtoPara);
        }

        /// <summary>
        /// 图形窗口峰手动垂直分割参数类事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void offGraph_PeakSplited(object sender, OffPeakSplitArgs e)
        {

            this._dsResult = this._offItem._resultViewer.LoadResult(this._dtoPara);
            //this._offGraphViewer.LoadLabelAndBaseline(ds, this._dtoPara);
            this._offItem._configViewer.LoadView(this._dtoPara);
        }

        /// <summary>
        /// 图形窗口峰的强制拖尾参数类事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void offGraph_PeakTailed(object sender, OffPeakTypeChangedArgs e)
        {

            this._dsResult = this._offItem._resultViewer.LoadResult(this._dtoPara);
            //this._offGraphViewer.LoadLabelAndBaseline(ds, this._dtoPara);
            this._offItem._configViewer.LoadView(this._dtoPara);
        }

        #endregion


    }
}
