/*-----------------------------------------------------------------------------
//  FILE NAME       : WelcomeFrm.cs
//  FUNCTION        : 欢迎画面
//  AUTHOR          : 李锋(2009/06/25)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Threading;
using System.Windows.Forms;

namespace Chromato.gui
{
    /// <summary>
    /// 欢迎画面
    /// </summary>
    public partial class WelcomeFrm : Form
    {

        #region 变量

        /// <summary>
        /// 百分比
        /// </summary>
        public Int32 _percent { get; set; }

        /// <summary>
        /// 刷新线程
        /// </summary>
        private Thread _updateThread { get; set; }

        /// <summary>
        /// 停止标志
        /// </summary>
        private Boolean _stop { get; set; }

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public WelcomeFrm()
        {
            this.InitializeComponent();
            _percent = 0;
            _stop = false;
        }
        #endregion


        #region 方法

        /// <summary>
        /// 开始
        /// </summary>
        public void Begin()
        {

            _updateThread = new Thread(Work);
            _updateThread.Start();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void End()
        {
            _stop = true;
            _updateThread.Join();
        }

        /// <summary>
        /// 更新进度条
        /// </summary>
        /// <param name="percent"></param>
        void UpdateProgress(Int32 percent)
        {
            progressBarMain.Value = percent;
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="status"></param>
        /// <param name="percent"></param>
        public void UpdateLabelText(String status, int percent)
        {
            this.lblStatus.Text = status;
            this.progressBarMain.Value = percent;
            Application.DoEvents();
        }

        /// <summary>
        /// 工作者线程
        /// </summary>
        void Work()
        {
            this.Show();

            while (!_stop)
            {
                if (_percent < 99)
                {
                    ++_percent;
                    UpdateProgress(_percent);
                }

                System.Threading.Thread.Sleep(20);
            }
            while (_percent < 100)
            {
                ++_percent;
                UpdateProgress(_percent);
                Thread.Sleep(1);
            }
            this.Close();
        }

        #endregion

    }
}
