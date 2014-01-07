/*-----------------------------------------------------------------------------
//  FILE NAME       : DescriptionUi.cs
//  FUNCTION        : 描述编辑
//  AUTHOR          : 李锋(2009/05/07)
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
    /// 描述编辑
    /// </summary>
    public partial class DescriptionUi : Form
    {
        /// <summary>
        /// 参数Dto
        /// </summary>
        public AnalyParaDto dtoAnaPara = null;

        /// <summary>
        /// 
        /// </summary>
        public DescriptionUi(AnalyParaDto dto)
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
            this.rtbDescription.Text = this.dtoAnaPara.Description;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.dtoAnaPara.Description = this.rtbDescription.Text;
            this.Close();
        }
    }
}
