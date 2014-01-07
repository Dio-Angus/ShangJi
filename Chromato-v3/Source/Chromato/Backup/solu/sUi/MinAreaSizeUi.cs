/*-----------------------------------------------------------------------------
//  FILE NAME       : MinAreaSizeUi.cs
//  FUNCTION        : 最小面积编辑
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
    public partial class MinAreaSizeUi : Form
    {
        /// <summary>
        /// 参数Dto
        /// </summary>
        public AnalyParaDto dtoAnaPara = null;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="dto"></param>
        public MinAreaSizeUi(AnalyParaDto dto)
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
            this.numUdMinArea.Value = Convert.ToInt32(this.dtoAnaPara.MinAreaSize);
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.numUdMinArea.TextChanged += new System.EventHandler(this.numUdMinArea_TextChanged);
            this.numUdMinArea.Leave += new System.EventHandler(this.numUdMinArea_Leave);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
        }


        /// <summary>
        /// 最小面积文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUdMinArea_TextChanged(object sender, EventArgs e)
        {
            Int32 v = Convert.ToInt32(this.numUdMinArea.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 10000 < v)
            {
                MessageBox.Show("最小面积范围不正确！", "最小面积");
                this.numUdMinArea.Focus();
                return;
            }
            this.dtoAnaPara.MinAreaSize = Convert.ToInt32(this.numUdMinArea.Value);
        }

        /// <summary>
        ///  最小面积焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUdMinArea_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUdMinArea.Value.ToString()))
            {
                MessageBox.Show("最小面积范围不正确！", "最小面积");
                this.numUdMinArea.Focus();
                return;
            }
            this.dtoAnaPara.MinAreaSize = Convert.ToInt32(this.numUdMinArea.Value);
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
