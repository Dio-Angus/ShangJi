/*-----------------------------------------------------------------------------
//  FILE NAME       : SoluRegistryFrm.cs
//  FUNCTION        : 方案注册,修改,复制窗口
//  AUTHOR          : 李锋(2009/06/12)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Windows.Forms;
using ChromatoTool.ini;
using ChromatoTool.dto;

namespace ChromatoCore.solu
{
    /// <summary>
    /// 方案注册窗口
    /// </summary>
    public partial class SoluRegistryFrm : Form
    {


        #region 定义

        /// <summary>
        /// 信息面板
        /// </summary>
        private SoluItem _itemSolu = null;

        /// <summary>
        /// 方案dto
        /// </summary>
        public SolutionDto _dtoSolution = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SoluRegistryFrm(AccessMethod am, SolutionDto dto, string tabtag)
        {
            InitializeComponent();
            this._dtoSolution = dto;
            this.LoadUi(am, dto, tabtag);
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi(AccessMethod am, SolutionDto dto, string tabtag)
        {
            this._itemSolu = new SoluItem(am,dto);
            this.Controls.Add(this._itemSolu);

            this._itemSolu.Width = this.Width - 10;
            this._itemSolu.Height = this.Height;
            this._itemSolu.LoadPage();

            this.Height = this._itemSolu.Height + this.btnReg.Height + 40;
            this.btnReg.Top = this._itemSolu.Bottom + 5;
            this.btnReg.Left = this._itemSolu.Right - this.btnReg.Width;

            switch (am)
            {
                case AccessMethod.View:
                    break;
                case AccessMethod.New:
                    this.Text = "注册方案";
                    this.btnReg.Text = "注册";
                    break;
                case AccessMethod.Edit:
                    this.Text = "编辑方案";
                    this.btnReg.Text = "保存";
                    break;
                case AccessMethod.SaveAs:
                    this.Text = "复制方案";
                    this.btnReg.Text = "保存";
                    break;
            }
            if (null == this._dtoSolution)
            {
                this._dtoSolution = new SolutionDto();
            }
            this._itemSolu.LoadItem(this._dtoSolution, tabtag);
        }

        #endregion


        #region 方法

        /// <summary>
        /// 改变各个page改变大小
        /// </summary>
        private void PageResize()
        {
            //this._itemSolu.Width = this.Width;
            //this._itemSolu.Height = this.Height - this.btnReg.Height - 2;
            this._itemSolu.LoadPage();
        }

        #endregion


        #region 事件

        /// <summary>
        /// 注册按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, System.EventArgs e)
        {

            if (this._itemSolu.SaveUi())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        #endregion

    }
}
