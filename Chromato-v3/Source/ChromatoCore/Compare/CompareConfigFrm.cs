/*-----------------------------------------------------------------------------
//  FILE NAME       : CompareConfigFrm.cs
//  FUNCTION        : 配置视图
//  AUTHOR          : 李锋(2009/07/30)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoTool.ini;
using ChromatoTool.util;

namespace ChromatoCore.Compare
{
    /// <summary>
    /// 配置视图
    /// </summary>
    public partial class CompareConfigFrm : Form
    {

        #region 构造

        /// <summary>
        /// 
        /// </summary>
        public CompareConfigFrm()
        {
            InitializeComponent();
            this.LoadUi();
            this.LoadEvent();
        }

        /// <summary>
        /// 装载画面
        /// </summary>
        private void LoadUi()
        {
            this.txtShowMaxY.Text = Math.Round(CompareConfig.ShowMaxY, 6).ToString();
            this.txtShowMinY.Text = Math.Round(CompareConfig.ShowMinY, 6).ToString();
            this.txtShowMaxX.Text = Math.Round(CompareConfig.ShowMaxX, 6).ToString();
            this.txtShowMinX.Text = Math.Round(CompareConfig.ShowMinX, 6).ToString();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.txtShowMaxY.TextChanged += new System.EventHandler(this.txtShowMaxY_TextChanged);
            this.txtShowMinY.TextChanged += new System.EventHandler(this.txtShowMinY_TextChanged);
            this.txtShowMaxX.TextChanged += new System.EventHandler(this.txtShowMaxX_TextChanged);
            this.txtShowMinX.TextChanged += new System.EventHandler(this.txtShowMinX_TextChanged);
        }

        #endregion


        #region 事件

        /// <summary>
        /// 上限焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtShowMaxY_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtShowMaxY.Text))
            {
                MessageBox.Show("显示上限不能为空！", "显示上限");
                this.txtShowMaxY.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtShowMaxY.Text))
            {
                MessageBox.Show("显示上限不是数值！", "显示上限");
                this.txtShowMaxY.Focus();
                return;
            }
            CompareConfig.ShowMaxY = Convert.ToSingle(this.txtShowMaxY.Text);
        }

        /// <summary>
        /// 下限焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtShowMinY_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtShowMinY.Text))
            {
                MessageBox.Show("显示下限不能为空！", "显示下限");
                this.txtShowMinY.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtShowMinY.Text))
            {
                MessageBox.Show("显示下限不是数值！", "显示下限");
                this.txtShowMinY.Focus();
                return;
            }
            CompareConfig.ShowMinY = Convert.ToSingle(this.txtShowMinY.Text);
        }

        /// <summary>
        /// 左限焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtShowMaxX_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtShowMaxX.Text))
            {
                MessageBox.Show("显示左限不能为空！", "显示左限");
                this.txtShowMaxX.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtShowMaxX.Text))
            {
                MessageBox.Show("显示左限不是数值！", "显示左限");
                this.txtShowMaxX.Focus();
                return;
            }
            CompareConfig.ShowMaxX = Convert.ToSingle(this.txtShowMaxX.Text);
        }

        /// <summary>
        /// 右限焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtShowMinX_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtShowMinX.Text))
            {
                MessageBox.Show("显示右限不能为空！", "显示右限");
                this.txtShowMinX.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtShowMinX.Text))
            {
                MessageBox.Show("显示右限不是数值！", "显示右限");
                this.txtShowMinX.Focus();
                return;
            }
            CompareConfig.ShowMinX = Convert.ToSingle(this.txtShowMinX.Text);
        }

        #endregion

    }
}
