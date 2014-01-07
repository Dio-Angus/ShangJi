/*-----------------------------------------------------------------------------
//  FILE NAME       : SolutionUser.cs
//  FUNCTION        : 方案主画面
//  AUTHOR          : 李锋(2009/05/22)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Windows.Forms;
using ChromatoCore.solu;

namespace ChromatoCore.tabCtrl
{
    /// <summary>
    /// 方案主画面
    /// </summary>
    public partial class SolutionUser : UserControl
    {


        #region 变量

        /// <summary>
        /// 方案组合
        /// </summary>
        private SoluGroup groupSolu = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SolutionUser()
        {
            InitializeComponent();
            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this.groupSolu = new SoluGroup();
            //this.groupSolu.Dock = DockStyle.Top;

            this.Controls.Add(this.groupSolu);
        }

        #endregion


        #region 方法

        /// <summary>
        /// 改变各个page改变大小
        /// </summary>
        public void LoadPage()
        {
            this.groupSolu.Width = this.Width;
            this.groupSolu.Top = 0;
            this.groupSolu.Height = this.Height;
            this.groupSolu.PageResize();

        }

        #endregion





    }
}
