/*-----------------------------------------------------------------------------
//  FILE NAME       : IngredientFrm.cs
//  FUNCTION        : 成分含量编辑窗口
//  AUTHOR          : 李锋(2009/05/15)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


using System;
using System.Data;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoBll.bll;

namespace ChromatoCore.solu.IdT
{
    /// <summary>
    /// 成分含量编辑窗口
    /// </summary>
    public partial class IngredientFrm : Form
    {

        #region 变量

        /// <summary>
        /// 成分dto
        /// </summary>
        private IngredientDto dtoIngre = null;

        /// <summary>
        /// 成分数据集合
        /// </summary>
        private DataSet dsIngre = null;


        CalibrateBiz bizCalibrate = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public IngredientFrm(IngredientDto dto)
        {
            InitializeComponent();
            this.dtoIngre = dto;
            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this.Text = "编辑成分ID：" + this.dtoIngre.IngredientID;
            this.lblIngredientName.Text = this.dtoIngre.IngredientName;
            this.lblReserveTime.Text = this.dtoIngre.ReserveTime.ToString();
            this.lblTimeBand.Text = this.dtoIngre.TimeBand.ToString();
            this.cbxInnerPeak.Checked = this.dtoIngre.IsInnerPeak;

            this.bizCalibrate = new CalibrateBiz();
            this.dsIngre = bizCalibrate.LoadCalibrate();
            if (null == this.dsIngre && null == this.dsIngre.Tables[0])
            {
                return;
            }

            //装载grid
            this.dgvIdTable.DataSource = this.dsIngre.Tables[0];

        }

        #endregion


        #region 事件

        private void btnChangeReserveTime_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 保存更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.bizCalibrate.UpdateDb();
        }

        #endregion

    }
}
