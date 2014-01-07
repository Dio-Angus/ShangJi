/*-----------------------------------------------------------------------------
//  FILE NAME       : ColumnModelUi.cs
//  FUNCTION        : 色谱柱选择
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
    public partial class ColumnModelUi : Form
    {

        /// <summary>
        /// 参数Dto
        /// </summary>
        public AnalyParaDto dtoAnaPara = null;

        /// <summary>
        /// 
        /// </summary>
        public ColumnModelUi(AnalyParaDto dto)
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
            this.txtColumnModel.Text = this.dtoAnaPara.ColumuModel;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.dtoAnaPara.ColumuModel = this.txtColumnModel.Text;
            this.Close();
        }
    }
}
