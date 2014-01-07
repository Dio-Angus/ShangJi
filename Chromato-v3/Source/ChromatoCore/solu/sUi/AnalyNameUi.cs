/*-----------------------------------------------------------------------------
//  FILE NAME       : AnalyNameUi.cs
//  FUNCTION        : 方法名编辑
//  AUTHOR          : 李锋(2009/04//14)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoTool.dto;

namespace ChromatoCore.solu.sUi
{
    /// <summary>
    /// 方法名编辑
    /// </summary>
    public partial class AnalyNameUi : Form
    {
        /// <summary>
        /// 参数Dto
        /// </summary>
        public AnalyParaDto dtoAnaPara = null;

        /// <summary>
        /// 构造
        /// </summary>
        public AnalyNameUi(AnalyParaDto dto)
        {
            this.dtoAnaPara = dto;
            InitializeComponent();
            LoadUi();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadUi()
        {
            this.txtAnalyName.Text = this.dtoAnaPara.AnalyName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.dtoAnaPara.AnalyName = this.txtAnalyName.Text;
            this.Close();
        }
    }
}
