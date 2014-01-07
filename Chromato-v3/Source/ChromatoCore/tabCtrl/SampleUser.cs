/*-----------------------------------------------------------------------------
//  FILE NAME       : SampleUser.cs
//  FUNCTION        : 样品主画面
//  AUTHOR          : 李锋(2009/05/22)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Windows.Forms;
using ChromatoCore.sample;
using ChromatoTool.ini;
using ChromatoTool.pipe;

namespace ChromatoCore.tabCtrl
{
    /// <summary>
    /// 样品主画面
    /// </summary>
    public partial class SampleUser : UserControl
    {

        #region 变量

        /// <summary>
        /// 方案组合
        /// </summary>
        private SampleGroup _groupSample = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SampleUser()
        {
            InitializeComponent();

            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._groupSample = new SampleGroup();
            //this.groupSolu.Dock = DockStyle.Top;

            this.Controls.Add(this._groupSample);
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
            this._groupSample.CreateLayer(lf, user, pipe);
        }

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="pipeFullName"></param>
        public void SetPipeName(string pipeFullName)
        {
            this._groupSample.SetPipeName(pipeFullName);
        }

        /// <summary>
        /// 改变各个page改变大小
        /// </summary>
        public void LoadPage()
        {
            this._groupSample.Width = this.Width;
            this._groupSample.Top = 0;
            this._groupSample.Height = this.Height;

            this._groupSample.PageResize();

        }

        #endregion
    
    
    }
}
