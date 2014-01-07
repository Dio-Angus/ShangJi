/*-----------------------------------------------------------------------------
//  FILE NAME       : CompareUser.cs
//  FUNCTION        : 比较主画面
//  AUTHOR          : 李锋(2009/07/28)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Windows.Forms;
using ChromatoCore.Compare;
using ChromatoTool.ini;
using ChromatoTool.pipe;

namespace ChromatoCore.tabCtrl
{
    /// <summary>
    /// 谱图比较画面
    /// </summary>
    public partial class CompareUser : UserControl
    {

        #region 变量

        /// <summary>
        /// 采集组合
        /// </summary>
        private CompareGroup _groupCompare = null;

        #endregion


        #region 构造

        /// <summary>
        /// 离线Tab类
        /// </summary>
        public CompareUser()
        {
            InitializeComponent();
            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._groupCompare = new CompareGroup();
            this.Controls.Add(this._groupCompare);
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
            this._groupCompare.CreateLayer(lf, user, pipe);
        }

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="pipeFullName"></param>
        public void SetPipeName(string pipeFullName)
        {
            this._groupCompare.SetPipeName(pipeFullName);
        }

        /// <summary>
        /// 控件改变大小
        /// </summary>
        public void LoadPage()
        {
            this._groupCompare.Width = this.Width;
            this._groupCompare.Top = 0;
            this._groupCompare.Height = this.Height;
            this._groupCompare.PageResize();
        }

        /// <summary>
        /// 停止线程
        /// </summary>
        public void StopThread()
        {
            this._groupCompare.StopThread();
        }

        #endregion


    }
}
