/*-----------------------------------------------------------------------------
//  FILE NAME       : OffGroup.cs
//  FUNCTION        : 分析组合
//  AUTHOR          : 李锋(2009/05/25)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoTool.pipe;
using ChromatoTool.ini;
using ChromatoCore.Auto;

namespace ChromatoCore.Off
{
    /// <summary>
    /// 分析组合
    /// </summary>
    public partial class OffGroup : UserControl
    {


        #region 变量

        /// <summary>
        /// 分隔条
        /// </summary>
        private Splitter splitterMain = null;

        /// <summary>
        /// 样品列表
        /// </summary>
        private OffList _listOff = null;

        /// <summary>
        /// 样品项目集合
        /// </summary>
        private OffBottom _bottomOff = null;

        /// <summary>
        /// 样品dto
        /// </summary>
        private ParaDto _dtoPara = null;

        /// <summary>
        /// 自动色谱对象
        /// </summary>
        private AutoRequest _autoQuest = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OffGroup()
        {
            InitializeComponent();
            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._listOff = new OffList();
            this._listOff.Dock = DockStyle.Top;

            this.splitterMain = new Splitter();
            this.splitterMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterMain.Location = new System.Drawing.Point(0, 2);
            this.splitterMain.Name = "splitterMain";
            this.splitterMain.Size = new System.Drawing.Size(666, 3);
            this.splitterMain.TabIndex = 20;
            this.splitterMain.TabStop = false;

            this._bottomOff = new OffBottom();
            this._bottomOff.Dock = DockStyle.Fill;

            this.Controls.Add(this._bottomOff);
            this.Controls.Add(this.splitterMain);
            this.Controls.Add(this._listOff);

            this.splitterMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitterMain_SplitterMoved);

            //列表窗口更换样品事件
            this._listOff.SampleChanged += new EventHandler<OffSampleChangeArgs>(listOff_SampleChanged);
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
            this._bottomOff.CreateLayer(lf, user, pipe);
        }

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="pipeFullName"></param>
        public void SetPipeName(string pipeFullName)
        {
            this._bottomOff.SetPipeName(pipeFullName);
        }

        /// <summary>
        /// 改变各个page改变大小
        /// </summary>
        public void PageResize()
        {
            this._listOff.Width = this.Width;
            this._listOff.Height = this.splitterMain.Top;
            this._listOff.UserResize();

            this.splitterMain.Width = this.Width;
            this.splitterMain.Location = new Point(0, this._listOff.Bottom);
            //this.splitterMain.BackColor = Color.BlueViolet;

            this._bottomOff.Width = this.Width;
            this._bottomOff.Top = this._listOff.Bottom + this.splitterMain.Height;
            this._bottomOff.Height = this.Height - this._listOff.Height - this.splitterMain.Height;
            this._bottomOff.PageResize();
        }

        /// <summary>
        /// 装载历史曲线
        /// </summary>
        /// <param name="dto"></param>
        public void LoadItem(ParaDto dto)
        {

            Cursor.Current = Cursors.WaitCursor;

            //装载谱图
            this._bottomOff.LoadPlot(dto);

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 装载分析后的谱图
        /// </summary>
        public void Analysis()
        {
            if (null == this._dtoPara)
            {
                return;
            }
            
            //装载谱图
            this._bottomOff.Analysis(this._dtoPara);
        }

        /// <summary>
        /// 自动分析发送命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void auto_AnalysisActioned(object sender, OnSampleAutoAnalysisArgs e)
        {
            this._bottomOff.AutoAnalysis(e._dtoPara);
        }


        /// <summary>
        /// 自动分析
        /// </summary>
        /// <param name="auto"></param>
        public void InitAuto(AutoRequest auto)
        {
            switch (General.ObjectLink)
            {
                case General.LinkObject.AutoChromatoGas:
                    //自动色谱对象发送命令事件
                    if (null != auto)
                    {
                        this._autoQuest = auto;
                        this._autoQuest.SampleAutoAnalysised += new EventHandler<OnSampleAutoAnalysisArgs>(auto_AnalysisActioned);
                    }
                    break;
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
        /// 列表窗口更换样品事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listOff_SampleChanged(object sender, OffSampleChangeArgs e)
        {
            this._dtoPara = (ParaDto)e._var;
            this.LoadItem(this._dtoPara);
        }

        #endregion



    }
}
