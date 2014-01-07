/*-----------------------------------------------------------------------------
//  FILE NAME       : ArithmaticUi.cs
//  FUNCTION        : 计算方法编辑
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
    /// 计算方法编辑
    /// </summary>
    public partial class ArithmaticUi : Form
    {
        /// <summary>
        /// 参数Dto
        /// </summary>
        public AnalyParaDto dtoAnaPara = null;

        /// <summary>
        /// 构造
        /// </summary>
        public ArithmaticUi(AnalyParaDto dto)
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
            switch ((Arithmatic)this.dtoAnaPara.ArithmaticID)
            {
                case Arithmatic.Normalize:
                    this.rbNormalize.Checked = true;
                    break;
                case Arithmatic.FixNormalize:
                    this.rbFixNormalize.Checked = true;
                    break;
                case Arithmatic.FixNormalizeWithRate:
                    this.rbFixNormalizeWithRate.Checked = true;
                    break;
                case Arithmatic.Inner:
                    this.rbInner.Checked = true;
                    break;
                case Arithmatic.Outer:
                    this.rbOuter.Checked = true;
                    break;
                case Arithmatic.Exponent:
                    this.rbExponent.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.rbNormalize.CheckedChanged += new System.EventHandler(this.rbNormalize_CheckedChanged);
            this.rbFixNormalize.CheckedChanged += new System.EventHandler(this.rbFixNormalize_CheckedChanged);
            this.rbFixNormalizeWithRate.CheckedChanged += new System.EventHandler(this.rbFixNormalizeWithRate_CheckedChanged);
            this.rbInner.CheckedChanged += new System.EventHandler(this.rbInner_CheckedChanged);
            this.rbOuter.CheckedChanged += new System.EventHandler(this.rbOuter_CheckedChanged);
            this.rbExponent.CheckedChanged += new System.EventHandler(this.rbExponent_CheckedChanged);
        }


        /// <summary>
        /// 归一法按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbNormalize_CheckedChanged(object sender, EventArgs e)
        {
            this.dtoAnaPara.ArithmaticID = Arithmatic.Normalize;
        }

        /// <summary>
        /// 修正归一法按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbFixNormalize_CheckedChanged(object sender, EventArgs e)
        {
            this.dtoAnaPara.ArithmaticID = Arithmatic.FixNormalize;
        }

        /// <summary>
        /// 带比例修正归一法按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbFixNormalizeWithRate_CheckedChanged(object sender, EventArgs e)
        {
            this.dtoAnaPara.ArithmaticID = Arithmatic.FixNormalizeWithRate;
        }

        /// <summary>
        /// 内标法按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbInner_CheckedChanged(object sender, EventArgs e)
        {
            this.dtoAnaPara.ArithmaticID = Arithmatic.Inner;
        }

        /// <summary>
        /// 外标法按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbOuter_CheckedChanged(object sender, EventArgs e)
        {
            this.dtoAnaPara.ArithmaticID = Arithmatic.Outer;
        }

        /// <summary>
        /// 指数法按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbExponent_CheckedChanged(object sender, EventArgs e)
        {
            this.dtoAnaPara.ArithmaticID = Arithmatic.Exponent;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
