/*-----------------------------------------------------------------------------
//  FILE NAME       : SampleRegFrm.cs
//  FUNCTION        : 样品注册窗口
//  AUTHOR          : 李锋(2009/06/03)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoTool.ini;
using ChromatoTool.dto;

namespace ChromatoCore.sample
{
    public partial class SampleRegFrm : Form
    {

        #region 变量

        /// <summary>
        /// 注册窗口
        /// </summary>
        private SampleUs _infoViewer = null;

        /// <summary>
        /// 样品dto
        /// </summary>
        public ParaDto _dtoPara = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="am"></param>
        /// <param name="dto"></param>
        public SampleRegFrm(AccessMethod am, ParaDto dto)
        {
            InitializeComponent();

            switch (General.ObjectLink)
            {
                case General.LinkObject.ChannelGas:
                case General.LinkObject.AutoChromatoGas:
                    this._infoViewer = (SampleUs)new SampleGasInfoViewer(am);
                    break;
                default:
                    this._infoViewer = (SampleUs)new SampleInfoViewer(am);
                    break;
            }


            this.Controls.Add(_infoViewer);
            this.btnReg.Top = this._infoViewer.Bottom;
            this.Height = this._infoViewer.Height + this.btnReg.Height + 40;
            this.Width = this._infoViewer.Width + 10;

            this._dtoPara = dto;

            this.LoadUi(am);
            this._infoViewer.LoadUi(this._dtoPara);
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi(AccessMethod am)
        {
            switch(am)
            {
            case AccessMethod.New:
                this._dtoPara = new ParaDto();
                this.Text = "注册样品";
                this.btnReg.Text = "注册";
                break;

            case AccessMethod.Edit:
                this.Text = "编辑样品";
                this.btnReg.Text = "保存";
                break;

            case AccessMethod.SaveAs:
                this.Text = "复制样品";
                this.btnReg.Text = "保存";
                break;
            }
        }

        #endregion


        #region 事件

        /// <summary>
        /// 注册按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {

            if (this._infoViewer.RegValidCheck())
            {
                if (this._infoViewer.ButtonDealer())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        #endregion

    }
}
