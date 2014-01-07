/*-----------------------------------------------------------------------------
//  FILE NAME       : ArithParaUi.cs
//  FUNCTION        : 计算参数选择
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
    /// 计算参数
    /// </summary>
    public partial class ArithParaUi : Form
    {
        /// <summary>
        /// 参数Dto
        /// </summary>
        public AnalyParaDto dtoAnaPara = null;

        /// <summary>
        /// 构造
        /// </summary>
        public ArithParaUi(AnalyParaDto dto)
        {
            dtoAnaPara = dto;
            InitializeComponent();
            LoadEvent();
            LoadUi();

        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            switch (this.dtoAnaPara.ArithmaticPara)
            {
                case ArithmaticParameter.Area:
                    this.rbArea.Checked = true;
                    break;
                case ArithmaticParameter.Height:
                    this.rbHeight.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadEvent()
        {
            this.rbArea.CheckedChanged += new System.EventHandler(this.rbArea_CheckedChanged);
            this.rbHeight.CheckedChanged += new System.EventHandler(this.rbHeight_CheckedChanged);
        }



        /// <summary>
        /// 面积按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbArea_CheckedChanged(object sender, EventArgs e)
        {
            this.dtoAnaPara.ArithmaticPara = ArithmaticParameter.Area;
        }

        /// <summary>
        /// 高度按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbHeight_CheckedChanged(object sender, EventArgs e)
        {
            this.dtoAnaPara.ArithmaticPara = ArithmaticParameter.Height;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
