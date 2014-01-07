/*-----------------------------------------------------------------------------
//  FILE NAME       : SampleRemarkViewer.cs
//  FUNCTION        : 样品备注编辑和显示
//  AUTHOR          : 李锋(2009/06/04)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoBll.bll;
using System.Drawing;

namespace ChromatoCore.sample
{
    /// <summary>
    /// 样品备注编辑和显示
    /// </summary>
    public partial class SampleRemarkViewer : UserControl
    {

        #region 变量

        /// <summary>
        /// 样品dto
        /// </summary>
        public ParaDto _dtoPara = null;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event SaveRemarkClickDelegate SaveRemarkClickEvent;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SampleRemarkViewer()
        {
            InitializeComponent();
        }
        #endregion


        #region 方法

        /// <summary>
        /// 装载界面
        /// </summary>
        /// <param name="dto"></param>
        public void LoadUi(ParaDto dto)
        {
            this._dtoPara = dto;
            if (null == dto || String.IsNullOrEmpty(dto.Remark))
            {
                this.rtbRemark.Text = "";
            }
            else
            {
                this.rtbRemark.Text = dto.Remark;
            }
            this.rtbRemark.BackColor = Color.White;
        }

        /// <summary>
        /// 改变大小
        /// </summary>
        public void CtrlResize()
        {
            //this.gbRemark.Width = this.Width;
            this.gbRemark.Height = this.Height - this.btnSave.Height - 5;
            this.btnSave.Top = this.gbRemark.Bottom + 1;
        }

        #endregion


        #region 事件

        /// <summary>
        /// 保存按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (null == this._dtoPara)
            {
                return;
            }

            this._dtoPara.Remark = this.rtbRemark.Text;
            ParaBiz biz = new ParaBiz();
            bool ret = biz.UpdatePara(this._dtoPara);
            this.SaveRemarkClickEvent();
        }

        #endregion

    }
}
