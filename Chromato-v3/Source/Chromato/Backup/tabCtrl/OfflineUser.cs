/*-----------------------------------------------------------------------------
//  FILE NAME       : OfflineUser.cs
//  FUNCTION        : OfflineUser
//  AUTHOR          : 李锋(2009/04/15)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Windows.Forms;
using ChromatoTool.ini;
using ChromatoCore.Off;
using ChromatoTool.pipe;
using ChromatoCore.Auto;

namespace ChromatoCore.tabCtrl
{
    /// <summary>
    /// 离线用户
    /// </summary>
    public partial class OfflineUser : UserControl
    {

        #region 变量

        /// <summary>
        /// 采集组合
        /// </summary>
        private OffGroup _groupOff = null;

        #endregion


        #region 构造

        /// <summary>
        /// 离线Tab类
        /// </summary>
        public OfflineUser()
        {
            InitializeComponent();
            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._groupOff = new OffGroup();
            this.Controls.Add(this._groupOff);
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
            this._groupOff.CreateLayer(lf, user, pipe);
        }

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="pipeFullName"></param>
        public void SetPipeName(string pipeFullName)
        {
            this._groupOff.SetPipeName(pipeFullName);
        }

        /// <summary>
        /// 控件改变大小
        /// </summary>
        public void LoadPage()
        {
            this._groupOff.Width = this.Width;
            this._groupOff.Top = 0;
            this._groupOff.Height = this.Height;
            this._groupOff.PageResize();
        }

        /// <summary>
        /// 重新分析
        /// </summary>
        public void ReAnalysis()
        {
            this._groupOff.Analysis();
        }

        /// <summary>
        /// 自动采集分析对象
        /// </summary>
        /// <param name="auto"></param>
        public void InitAuto(AutoRequest auto)
        {
            switch (General.ObjectLink)
            {
                case General.LinkObject.AutoChromatoGas:
                    this._groupOff.InitAuto(auto);
                    break;
            }

        }
        #endregion


    }
}
