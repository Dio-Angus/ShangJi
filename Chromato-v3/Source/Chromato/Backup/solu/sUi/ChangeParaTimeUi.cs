/*-----------------------------------------------------------------------------
//  FILE NAME       : ChangeParaTimeUi.cs
//  FUNCTION        : 变参时间选择
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
    /// 变参时间选择
    /// </summary>
    public partial class ChangeParaTimeUi : Form
    {

        /// <summary>
        /// 参数Dto
        /// </summary>
        public AnalyParaDto dtoAnaPara = null;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="dto"></param>
        public ChangeParaTimeUi(AnalyParaDto dto)
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
            this.numUDParaChangeTime.Value = Convert.ToInt32(this.dtoAnaPara.ParaChangeTime);
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.numUDParaChangeTime.TextChanged += new System.EventHandler(this.numUDParaChangeTime_TextChanged);
            this.numUDParaChangeTime.Leave += new System.EventHandler(this.numUDParaChangeTime_Leave);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
        }



        /// <summary>
        /// 变参时间文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDParaChangeTime_TextChanged(object sender, EventArgs e)
        {
            Int32 v = Convert.ToInt32(this.numUDParaChangeTime.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 10000 < v)
            {
                MessageBox.Show("变参时间范围不正确！", "变参时间");
                this.numUDParaChangeTime.Focus();
                return;
            }
            this.dtoAnaPara.ParaChangeTime = Convert.ToInt32(this.numUDParaChangeTime.Value);
        }

        /// <summary>
        ///  变参时间焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDParaChangeTime_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUDParaChangeTime.Value.ToString()))
            {
                MessageBox.Show("变参时间范围不正确！", "变参时间");
                this.numUDParaChangeTime.Focus();
                return;
            }
            this.dtoAnaPara.ParaChangeTime = Convert.ToInt32(this.numUDParaChangeTime.Value);
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
