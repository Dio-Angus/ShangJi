/*-----------------------------------------------------------------------------
//  FILE NAME       : SampleGroup.cs
//  FUNCTION        : 样品组合
//  AUTHOR          : 李锋(2009/05/24)
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

namespace ChromatoCore.sample
{
    /// <summary>
    /// 样品组合
    /// </summary>
    public partial class SampleGroup : UserControl
    {

        #region 变量

        /// <summary>
        /// 分隔条
        /// </summary>
        private Splitter _splitterMain = null;

        /// <summary>
        /// 样品列表
        /// </summary>
        private SampleList _listSample = null;

        /// <summary>
        /// 样品项目集合
        /// </summary>
        private SampleItem _itemSample = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SampleGroup()
        {
            InitializeComponent();
            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._listSample = new SampleList();
            this._listSample.Dock = DockStyle.Top;

            this._splitterMain = new Splitter();

            //设定最小面积
            this._splitterMain.MinExtra = 100;
            this._splitterMain.MinSize = 95;

            this._splitterMain.Dock = System.Windows.Forms.DockStyle.Top;
            this._splitterMain.Location = new System.Drawing.Point(0, 2);
            this._splitterMain.Name = "splitterMain";
            this._splitterMain.Size = new System.Drawing.Size(666, 3);
            this._splitterMain.TabIndex = 20;
            this._splitterMain.TabStop = false;
            this._splitterMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitterMain_SplitterMoved);

            this._itemSample = new SampleItem();
            this._itemSample.Dock = DockStyle.Fill;

            this.Controls.Add(this._itemSample);
            this.Controls.Add(this._splitterMain);
            this.Controls.Add(this._listSample);

            //列表窗口更换样品事件
            this._listSample.SampleChanged += new EventHandler<SampleChangeArgs>(listSample_SampleChanged);

            //备注保存完成事件
            this._itemSample._viewRemark.SaveRemarkClickEvent += new SaveRemarkClickDelegate(this.SaveClick);

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
            this._itemSample.CreateLayer(lf, user, pipe);
        }

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="pipeFullName"></param>
        public void SetPipeName(string pipeFullName)
        {
            this._itemSample.SetPipeName(pipeFullName);
        }

        /// <summary>
        /// 改变各个page改变大小
        /// </summary>
        public void PageResize()
        {
            this._listSample.Width = this.Width;
            this._listSample.Height = this._splitterMain.Top;

            this._splitterMain.Width = this.Width;
            this._splitterMain.Location = new Point(0, this._listSample.Bottom);
            //this.splitterMain.BackColor = Color.BlueViolet;

            this._itemSample.Width = this.Width;
            this._itemSample.Top = this._listSample.Bottom + this._splitterMain.Height;
            this._itemSample.Height = this.Height - this._listSample.Height - this._splitterMain.Height;
            this._itemSample.LoadPage();
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
        private void listSample_SampleChanged(object sender, SampleChangeArgs e)
        {
            this._itemSample.LoadItem((ParaDto)e._var);
        }

        /// <summary>
        /// 备注保存完成事件
        /// </summary>
        private void SaveClick()
        {
            this._listSample.RefreshList(this._itemSample._viewRemark._dtoPara);
        }

        #endregion
    
    }
}
