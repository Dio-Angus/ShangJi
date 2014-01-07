/*-----------------------------------------------------------------------------
//  FILE NAME       : PeakWideUi.cs
//  FUNCTION        : 峰宽编辑
//  AUTHOR          : 李锋(2009/05/07)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


using System;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoTool.util;

namespace ChromatoCore.solu.sUi
{
    /// <summary>
    /// 峰宽编辑
    /// </summary>
    public partial class PeakWideUi : Form
    {
        /// <summary>
        /// 参数Dto
        /// </summary>
        public AnalyParaDto dtoAnaPara = null;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="dto"></param>
        public PeakWideUi(AnalyParaDto dto)
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
            this.numUDPeakWide.Value = Convert.ToInt32(this.dtoAnaPara.PeakWide);
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.numUDPeakWide.TextChanged += new System.EventHandler(this.numUDPeakWide_TextChanged);
            this.numUDPeakWide.Leave += new System.EventHandler(this.numUDPeakWide_Leave);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
        }


        /// <summary>
        /// 峰宽文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDPeakWide_TextChanged(object sender, EventArgs e)
        {

            Int32 v = Convert.ToInt32(this.numUDPeakWide.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 100 < v)
            {
                MessageBox.Show("峰宽范围不正确！", "峰宽");
                this.numUDPeakWide.Focus();
                return;
            }
            this.dtoAnaPara.PeakWide = Convert.ToInt32(this.numUDPeakWide.Value);
        }

        /// <summary>
        /// 峰宽焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDPeakWide_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUDPeakWide.Value.ToString()))
            {
                MessageBox.Show("峰宽范围不正确！", "峰宽");
                this.numUDPeakWide.Focus();
                return;
            }
            this.dtoAnaPara.PeakWide = Convert.ToInt32(this.numUDPeakWide.Value);
        }

        /// <summary>
        /// 确定按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
