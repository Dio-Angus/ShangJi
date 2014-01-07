/*-----------------------------------------------------------------------------
//  FILE NAME       : RatioUi.cs
//  FUNCTION        : 比例系数选择
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
    public partial class RatioUi : Form
    {
        /// <summary>
        /// 参数Dto
        /// </summary>
        public AnalyParaDto dtoAnaPara = null;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        public RatioUi(AnalyParaDto dto)
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
            this.numUdRatio.Value = Convert.ToInt32(this.dtoAnaPara.Ratio);
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.numUdRatio.TextChanged += new System.EventHandler(this.numUdRatio_TextChanged);
            this.numUdRatio.Leave += new System.EventHandler(this.numUdRatio_Leave);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
        }

        /// <summary>
        /// 漂移文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUdRatio_TextChanged(object sender, EventArgs e)
        {
            Int32 v = Convert.ToInt32(this.numUdRatio.Value);
            Console.Out.WriteLine(v);
            if (1 > v || 100 < v)
            {
                MessageBox.Show("比例系数范围不正确！", "比例系数");
                this.numUdRatio.Focus();
                return;
            }
            this.dtoAnaPara.Ratio = Convert.ToInt32(this.numUdRatio.Value);
        }

        /// <summary>
        ///  漂移焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUdRatio_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUdRatio.Value.ToString()))
            {
                MessageBox.Show("比例系数范围不正确！", "比例系数");
                this.numUdRatio.Focus();
                return;
            }
            this.dtoAnaPara.Ratio = Convert.ToInt32(this.numUdRatio.Value);
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
