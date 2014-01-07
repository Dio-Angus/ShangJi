/*-----------------------------------------------------------------------------
//  FILE NAME       : UserEditFrm.cs
//  FUNCTION        : 用户编辑窗体
//  AUTHOR          : 李锋(2009/12/04)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoBll.bll;
using ChromatoTool.ini;

namespace ChromatoCore.Login
{
    /// <summary>
    /// 用户编辑窗体
    /// </summary>
    public partial class UserEditFrm : Form
    {

        #region 变量

        /// <summary>
        /// 用户
        /// </summary>
        private UserDto _dtoUser = null;

        /// <summary>
        /// 用户逻辑
        /// </summary>
        private UserBiz _bizUser = null;

        /// <summary>
        /// 列表数据集合
        /// </summary>
        private DataSet _dsUser = null;

        #endregion

        
        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public UserEditFrm()
        {
            InitializeComponent();
            this.LoadUi();
            this.LoadEvent();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.txtUserID.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            this.txtPwd.TextChanged += new System.EventHandler(this.txtPwd_TextChanged);
            this.txtChineseName.TextChanged += new System.EventHandler(this.txtChineseName_TextChanged);

            this.Load += new System.EventHandler(this.UserList_Load);
            
            this.dgvUser.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvSampleInfo_CellClick);
            this.dgvUser.CellClick += new DataGridViewCellEventHandler(this.dgvSampleInfo_CellClick);
            this.dgvUser.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvSampleInfo_ColumnHeaderMouseClick);
            this.dgvUser.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvSampleInfo_DataBindingComplete);
            this.dgvUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvSampleInfo_KeyUp);

            this.tsBtnUpdate.Click += new System.EventHandler(this.tsBtnUpdate_Click);
            this.tsBtnRegNew.Click += new System.EventHandler(this.tsBtnRegNew_Click);
            this.tsBtnDelete.Click += new System.EventHandler(this.tsBtnDelete_Click);
            this.tsBtnRefresh.Click += new System.EventHandler(this.tsBtnRefresh_Click);
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._dtoUser = new UserDto();
            this._bizUser = new UserBiz();
            this.LoadList();
        }

        /// <summary>
        /// 装载列表
        /// </summary>
        private void LoadList()
        {
            DateTime dt = DateTime.Now;
            TimeSpan waitTime = new TimeSpan(14, 0, 0, 0, 0);

            DateTime dtStart = dt - waitTime;
            DataSet ds = this._bizUser.LoadAll();

            //空检查
            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                if (0 < this.dgvUser.Rows.Count)
                {
                    this._dsUser.Tables[0].Rows.Clear();
                    this.dgvUser.DataSource = this._dsUser.Tables[0];
                }
                return;
            }

            this._dsUser = ds;
            this.dgvUser.DataSource = this._dsUser.Tables[0];
        }

        /// <summary>
        /// 画面初期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserList_Load(object sender, EventArgs e)
        {
            this.LoadList();

            this._dtoUser = new UserDto();
            if (null == this._dsUser || null == this._dsUser.Tables[0] || 0 >= this._dsUser.Tables[0].Rows.Count)
            {
                return;
            }

            //更新选中行
            DataRow cRow = this._dsUser.Tables[0].Rows[0];

            this._dtoUser.UserID = cRow["UserID"].ToString();
            this._dtoUser.ChineseName = cRow["ChineseName"].ToString();
            this._dtoUser.Password = cRow["Password"].ToString();

            this.txtUserID.Text = this._dtoUser.UserID;
            this.txtChineseName.Text = this._dtoUser.ChineseName;
            this.txtPwd.Text = this._dtoUser.Password;

        }

        #endregion


        #region 方法

        /// <summary>
        /// 设置行高
        /// </summary>
        private void SetDgvCellHeight()
        {
            this.dgvUser.AllowUserToResizeRows = false;
            foreach (DataGridViewRow a in this.dgvUser.Rows)
            {
                a.Height = 15;
            }
        }

        /// <summary>
        /// 更新选中行
        /// </summary>
        private void UpdateSelectedRow()
        {
            if (null == this.dgvUser.CurrentRow)
            {
                MessageBox.Show("没有选中用户！", "警告");
                return;
            }

            String userID = "";
            for (int i = 0; i < this._dsUser.Tables[0].Rows.Count; i++)
            {
                userID = this.dgvUser["UserID", i].Value.ToString();
                if (userID.Equals(this._dtoUser.UserID))
                {
                    // clear datagridview selection
                    this.dgvUser.ClearSelection();
                    // select new row
                    this.dgvUser["UserID", i].Selected = true;

                    break;
                }
            }
        }

        /// <summary>
        /// 更新内存的用户dto
        /// </summary>
        private void UpdateMemory()
        {
            DataGridViewRow cRow = this.dgvUser.CurrentRow;

            this._dtoUser.UserID = cRow.Cells["UserID"].Value.ToString();
            this._dtoUser.ChineseName = cRow.Cells["ChineseName"].Value.ToString();
            this._dtoUser.Password = cRow.Cells["Password"].Value.ToString();


            this.txtUserID.Text = this._dtoUser.UserID;
            this.txtChineseName.Text = this._dtoUser.ChineseName;
            this.txtPwd.Text = this._dtoUser.Password;
        }

        #endregion


        #region 事件

        /// <summary>
        /// 用户名更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(this.txtUserID.Text))
            {
                MessageBox.Show("用户名不能为空！", "用户名");
                this.txtUserID.Focus();
                return;
            }

            UserDto dto = new UserDto();
            dto.UserID = this.txtUserID.Text.Trim();
            if (!dto.UserID.Equals(this._dtoUser.UserID))
            {
                if (this._bizUser.IsExist(dto))
                {
                    MessageBox.Show("该用户已经存在！", "用户名");
                    this.txtUserID.Focus();
                    return;
                }
            }

            this._dtoUser.UserID = dto.UserID;
        }

        /// <summary>
        /// 密码更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtPwd.Text))
            {
                MessageBox.Show("密码不能为空！", "密码");
                this.txtPwd.Focus();
                return;
            }
            this._dtoUser.Password = this.txtPwd.Text.Trim();
        } 
        
        /// <summary>
        /// 中文名更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtChineseName_TextChanged(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(this.txtChineseName.Text))
            {
                MessageBox.Show("中文名不能为空！", "中文名");
                this.txtChineseName.Focus();
                return;
            }
            this._dtoUser.ChineseName = this.txtChineseName.Text.Trim();
        }

        /// <summary>
        /// 单击视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex)
            {
                return;
            }

            this.UpdateMemory();
        }


        /// <summary>
        /// 根据样品状态设定单元格颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvUser.DefaultCellStyle.BackColor = Color.FromArgb(General.DgvBackColor);
            this.SetDgvCellHeight();

        }

        /// <summary>
        /// 标题栏按下的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.UpdateSelectedRow();
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                this.UpdateMemory();
            }
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnUpdate_Click(object sender, EventArgs e)
        {
            if (this._bizUser.IsExist(this._dtoUser))
            {
                this._bizUser.UpdateUser(this._dtoUser);
                this.UserList_Load(null, null);
            }
        }

        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnRegNew_Click(object sender, EventArgs e)
        {
            if (this._bizUser.IsExist(this._dtoUser))
            {
                MessageBox.Show("该用户已经存在！", "提示");
            }
            else
            {
                this._bizUser.InsertUser(this._dtoUser);
                this.UserList_Load(null, null);
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (this._dtoUser.UserID.Equals(General.UserID))
            {
                MessageBox.Show("不能删除当前用户！", "警告");
                return;

            }
            if (MessageBox.Show("确认删除该用户吗？", "警告", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this._bizUser.DeleteUser(this._dtoUser);
                this.UserList_Load(null, null);

            }
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnRefresh_Click(object sender, EventArgs e)
        {
            this.UserList_Load(null, null);
        }

        #endregion

    }
}
