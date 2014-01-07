/*-----------------------------------------------------------------------------
//  FILE NAME       : PwdUpdateFrm.cs
//  FUNCTION        : 密码更新窗体
//  AUTHOR          : 李锋(2009/12/22)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


using System.Data;
using System.Windows.Forms;
using ChromatoBll.bll;
using ChromatoTool.dto;
using System;
using ChromatoTool.ini;


namespace ChromatoCore.Login
{

    /// <summary>
    /// 密码更新窗体
    /// </summary>
    public partial class PwdUpdateFrm : Form
    {


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public PwdUpdateFrm()
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
            this.txtUserID.Text = General.UserID;
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            this.txtNewPwdConfirmed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPwdConfirmed_KeyDown);
        }

        #endregion


        #region 方法

        /// <summary>
        /// 确定按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            UserBiz bizUser = new UserBiz();
            UserDto dto = new UserDto();
            dto.UserID = General.UserID;
            dto.Password = this.txtOldPwd.Text.Trim();

            if(String.IsNullOrEmpty(dto.Password))
            {
                MessageBox.Show("旧密码为空", "警告");
                this.txtOldPwd.Focus();
                return;
            }

            String temp1 = this.txtNewPwd.Text.Trim();
            if(String.IsNullOrEmpty(temp1))
            {
                MessageBox.Show("新密码为空", "警告");
                this.txtNewPwd.Focus();
                return;
            }

            String temp2 = this.txtNewPwdConfirmed.Text.Trim();
            if(String.IsNullOrEmpty(temp2))
            {
                MessageBox.Show("确认新密码为空", "警告");
                this.txtNewPwdConfirmed.Focus();
                return;
            }

            if(!temp1.Equals(temp2))
            {
                MessageBox.Show("新密码和确认新密码不同", "警告");
                this.txtNewPwdConfirmed.Focus();
                return;
            }

            UserInfo info = bizUser.QueryUserinfo(dto);
            switch (info)
            {
                case UserInfo.Pass:
                    dto.Password = temp1;
                    bizUser.UpdateUser(dto);
                    MessageBox.Show("更新成功!", "提示");
                    this.Close();
                    break;
                case ChromatoTool.ini.UserInfo.InvalidPwd:
                case ChromatoTool.ini.UserInfo.InvalidUser:
                    MessageBox.Show("旧密码不正确", "警告");
                    this.txtOldPwd.Focus();
                   return;
            }
        }

        /// <summary>
        /// 确认密码文本框按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNewPwdConfirmed_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                this.btnSure_Click(sender, e);
            }
        }

        #endregion


    }
}
