/*-----------------------------------------------------------------------------
//  FILE NAME       : DriftUi.cs
//  FUNCTION        : 漂移编辑
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
    public partial class DriftUi : Form
    {
        /// <summary>
        /// 参数Dto
        /// </summary>
        public AnalyParaDto dtoAnaPara = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        public DriftUi(AnalyParaDto dto)
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
            this.numUdDrift.Value = Convert.ToInt32(this.dtoAnaPara.Drift);
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.numUdDrift.TextChanged += new System.EventHandler(this.numUdDrift_TextChanged);
            this.numUdDrift.Leave += new System.EventHandler(this.numUdDrift_Leave);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
        }


        /// <summary>
        /// 漂移文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUdDrift_TextChanged(object sender, EventArgs e)
        {
            Int32 v = Convert.ToInt32(this.numUdDrift.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 10000 < v)
            {
                MessageBox.Show("漂移范围不正确！", "漂移");
                this.numUdDrift.Focus();
                return;
            }
            this.dtoAnaPara.Drift = Convert.ToInt32(this.numUdDrift.Value);
        }

        /// <summary>
        ///  漂移焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUdDrift_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUdDrift.Value.ToString()))
            {
                MessageBox.Show("漂移范围不正确！", "漂移");
                this.numUdDrift.Focus();
                return;
            }
            this.dtoAnaPara.Drift = Convert.ToInt32(this.numUdDrift.Value);
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
