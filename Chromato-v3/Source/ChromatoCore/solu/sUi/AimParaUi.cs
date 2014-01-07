/*-----------------------------------------------------------------------------
//  FILE NAME       : AimParaUi.cs
//  FUNCTION        : 对准参数编辑
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
    /// 对准参数编辑
    /// </summary>
    public partial class AimParaUi : Form
    {
        
        /// <summary>
        /// 参数Dto
        /// </summary>
        public AnalyParaDto dtoAnaPara = null;
        
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="dto"></param>
        public AimParaUi(AnalyParaDto dto)
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

            switch (this.dtoAnaPara.AimPara)
            {
                case AimPara.TimeWindow:
                    this.rbTimeWindow.Checked = true;
                    break;
                case AimPara.TimeBand:
                    this.rbTimeBand.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.rbTimeWindow.CheckedChanged += new System.EventHandler(this.rbTimeWindow_CheckedChanged);
            this.rbTimeBand.CheckedChanged += new System.EventHandler(this.rbTimeBand_CheckedChanged);
        }

        /// <summary>
        /// 时间窗按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbTimeWindow_CheckedChanged(object sender, EventArgs e)
        {
            this.dtoAnaPara.AimPara = AimPara.TimeWindow;
        }

        /// <summary>
        /// 时间带按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbTimeBand_CheckedChanged(object sender, EventArgs e)
        {
            this.dtoAnaPara.AimPara = AimPara.TimeBand;
        }

        /// <summary>
        /// ok按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
