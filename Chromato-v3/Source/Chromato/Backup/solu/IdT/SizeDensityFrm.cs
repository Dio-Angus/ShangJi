/*-----------------------------------------------------------------------------
//  FILE NAME       : SizeDensityFrm.cs
//  FUNCTION        : 面积浓度窗口容器
//  AUTHOR          : 李锋(2009/06/24)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using System.Collections;

namespace ChromatoCore.solu.IdT
{
    /// <summary>
    /// 面积浓度窗口容器
    /// </summary>
    public partial class SizeDensityFrm : Form
    {


        #region 变量

        /// <summary>
        /// 图形逻辑层
        /// </summary>
        private SizeDensityViewer _viewSizeDensity = null;

        #endregion 


        #region 构造

        /// <summary>
        /// 实例名
        /// </summary>
        static readonly SizeDensityFrm instance = new SizeDensityFrm();

        /// <summary>
        /// 唯一实例
        /// </summary>
        public static SizeDensityFrm Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// 构造
        /// </summary>
        public SizeDensityFrm()
        {
            InitializeComponent();

            this.LoadUi();
            this.LoadEvent();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._viewSizeDensity = new SizeDensityViewer();
            this.gbGraph.Controls.Add(this._viewSizeDensity);
            this._viewSizeDensity.Dock = DockStyle.Fill;

        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.tsBtnClose.Click += new System.EventHandler(this.tsBtnClose_Click);
        }

        #endregion


        #region 方法

        /// <summary>
        /// 装载曲线
        /// </summary>
        /// <param name="arrPoly"></param>
        /// <param name="arrSimu"></param>
        public void LoadPlot(ArrayList arrPoly, ArrayList arrSimu)
        {
            this._viewSizeDensity.LoadCorrectPoint(arrPoly, arrSimu);
            this._viewSizeDensity.OcxResize();
        }

        #endregion
        
        
        #region 事件

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        /// <summary>
        /// 改变大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SizeDensityFrm_Resize(object sender, EventArgs e)
        {
            this.gbGraph.Width = this.Width - 15;
            this.gbGraph.Height = this.Height - this.tsSizeDensity.Height - 30;
            this._viewSizeDensity.OcxResize();
        }

        #endregion




    }
}
