/*-----------------------------------------------------------------------------
//  FILE NAME       : LoginFrm.cs
//  FUNCTION        : 登陆窗体
//  AUTHOR          : 李锋(2009/12/03)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoBll.bll;
using ChromatoTool.dto;
using ChromatoTool.ini;
using ChromatoTool.util;

namespace ChromatoCore.Login
{
    /// <summary>
    /// 登陆窗体
    /// </summary>
    public partial class LoginFrm : Form
    {
        
        
        #region 构造
        
        /// <summary>
        /// 构造
        /// </summary>
        public LoginFrm()
        {
            InitializeComponent();
            this.Text = "登陆到" + DefaultItem.Project_Name;
            this.LoadEvent();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            this.txtPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPwd_KeyDown);
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
            dto.UserID = this.txtUserID.Text.Trim();
            dto.Password = this.txtPwd.Text.Trim();

            UserInfo info = bizUser.QueryUserinfo(dto);
            switch (info)
            {
                case UserInfo.Pass:
                    this.DialogResult = DialogResult.OK;
                    General.UserID = dto.UserID;
                    this.Close();
                    break;
                case ChromatoTool.ini.UserInfo.InvalidPwd:
                case ChromatoTool.ini.UserInfo.InvalidUser:
                    MessageBox.Show(EnumDescription.GetFieldText(info),"警告");
                    break;
            }

        }

        /// <summary>
        /// 密码文本框按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                this.btnSure_Click(sender, e);
            }
        }

        #endregion



    }
}
