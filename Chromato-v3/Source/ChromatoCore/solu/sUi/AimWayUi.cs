/*-----------------------------------------------------------------------------
//  FILE NAME       : AimWayUi.cs
//  FUNCTION        : 对准方法编辑
//  AUTHOR          : 李锋(2009/05/06)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoTool.ini;

namespace ChromatoCore.solu.sUi
{
    /// <summary>
    /// 对准方法编辑
    /// </summary>
    public partial class AimWayUi : Form
    {
        /// <summary>
        /// 参数Dto
        /// </summary>
        public AnalyParaDto dtoAnaPara = null;

        /// <summary>
        /// 
        /// </summary>
        public AimWayUi(AnalyParaDto dto)
        {
            this.dtoAnaPara = dto;
            InitializeComponent();
            LoadEvent();
            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {

            switch (this.dtoAnaPara.AimWay)
            {
                case AimWay.Absolute:
                    this.rbAbsolute.Checked = true;
                    break;
                case AimWay.Relative:
                    this.rbRelative.Checked = true;
                    break;
            }
        }


        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.rbAbsolute.CheckedChanged += new System.EventHandler(this.rbAbsolute_CheckedChanged);
            this.rbRelative.CheckedChanged += new System.EventHandler(this.rbRelative_CheckedChanged);

        }

        /// <summary>
        /// 绝对按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbAbsolute_CheckedChanged(object sender, EventArgs e)
        {
            this.dtoAnaPara.AimWay = AimWay.Absolute;
        }

        /// <summary>
        /// 相对按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbRelative_CheckedChanged(object sender, EventArgs e)
        {
            this.dtoAnaPara.AimWay = AimWay.Relative;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
