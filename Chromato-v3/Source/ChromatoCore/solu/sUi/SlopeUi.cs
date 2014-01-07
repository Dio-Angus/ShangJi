/*-----------------------------------------------------------------------------
//  FILE NAME       : SlopeUi.cs
//  FUNCTION        : 斜率选择
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
    /// 
    /// </summary>
    public partial class SlopeUi : Form
    {
        /// <summary>
        /// 参数Dto
        /// </summary>
        public AnalyParaDto dtoAnaPara = null;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="dto"></param>
        public SlopeUi(AnalyParaDto dto)
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
            this.numUDSlope.Value = Convert.ToInt32(this.dtoAnaPara.Slope);
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.numUDSlope.TextChanged += new System.EventHandler(this.numUDSlope_TextChanged);
            this.numUDSlope.Leave += new System.EventHandler(this.numUDSlope_Leave);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
        }

        /// <summary>
        /// 斜率文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDSlope_TextChanged(object sender, EventArgs e)
        {
            Int32 v = Convert.ToInt32(this.numUDSlope.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 100000 < v)
            {
                MessageBox.Show("斜率范围不正确！", "斜率");
                this.numUDSlope.Focus();
                return;
            }
            this.dtoAnaPara.Slope = Convert.ToInt32(this.numUDSlope.Value);
        }

        /// <summary>
        ///  斜率焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDSlope_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUDSlope.Value.ToString()))
            {
                MessageBox.Show("斜率范围不正确！", "斜率");
                this.numUDSlope.Focus();
                return;
            }
            this.dtoAnaPara.Slope = Convert.ToInt32(this.numUDSlope.Value);
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
