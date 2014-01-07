/*-----------------------------------------------------------------------------
//  FILE NAME       : SoluGroup.cs
//  FUNCTION        : 方案组合
//  AUTHOR          : 李锋(2009/05/22)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoTool.ini;

namespace ChromatoCore.solu
{
    /// <summary>
    /// 方案组合
    /// </summary>
    public partial class SoluGroup : UserControl
    {

        #region 变量

        /// <summary>
        /// 分隔条
        /// </summary>
        private Splitter _splitterMain = null;

        /// <summary>
        /// 方案列表
        /// </summary>
        private SoluList _listSolu = null;

        /// <summary>
        /// 方法项目集合
        /// </summary>
        private SoluItem _itemSolu = null;

        #endregion

        
        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SoluGroup()
        {
            InitializeComponent();
            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._listSolu = new SoluList();
            this._listSolu.Dock = DockStyle.Top;

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

            this._itemSolu = new SoluItem(AccessMethod.View, null);
            this._itemSolu.Dock = DockStyle.Fill;

            this.Controls.Add(this._itemSolu);
            this.Controls.Add(this._splitterMain);
            this.Controls.Add(this._listSolu);

            //方案选择改变事件
            this._listSolu.SolutionChanged += new EventHandler<SolutionChangeArgs>(listSolu_SolutionChanged);

            //方案选择改变事件
            this._itemSolu.TabPageChanged += new EventHandler<PageChangeArgs>(itemSolu_TabPageChanged);
        }

        #endregion


        #region 方法

        /// <summary>
        /// 改变各个page改变大小
        /// </summary>
        public void PageResize()
        {
            this._listSolu.Width = this.Width;
            this._listSolu.Height = this._splitterMain.Top;

            this._splitterMain.Width = this.Width;
            this._splitterMain.Location = new Point(0, this._listSolu.Bottom);
            //this.splitterMain.BackColor = Color.BlueViolet;

            this._itemSolu.Width = this.Width - 10;
            this._itemSolu.Top = this._listSolu.Bottom + this._splitterMain.Height;
            this._itemSolu.Height = this.Height - this._listSolu.Height - this._splitterMain.Height;
            this._itemSolu.LoadPage();
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
        private void listSolu_SolutionChanged(object sender, SolutionChangeArgs e)
        {
            this._itemSolu.LoadItem((SolutionDto)e._var, null);
        }

        /// <summary>
        /// 下部方案视图切换tab事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemSolu_TabPageChanged(object sender, PageChangeArgs e)
        {
            this._listSolu._currentTabTag = e._tag;
        }

        #endregion
   
    }
}
