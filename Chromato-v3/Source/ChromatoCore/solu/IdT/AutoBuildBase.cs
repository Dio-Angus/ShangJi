/*-----------------------------------------------------------------------------
//  FILE NAME       : AutoBuildBase.cs
//  FUNCTION        : ID表自动建表基类
//  AUTHOR          : 李锋(2010/06/01)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using ChromatoBll.bll;
using ChromatoTool.dto;

namespace ChromatoCore.solu.IdT
{
    /// <summary>
    /// ID表自动建表基类
    /// </summary>
    public partial class AutoBuildBase : Form
    {

        #region 变量

        /// <summary>
        /// 样品逻辑
        /// </summary>
        protected ParaBiz _bizPara = null;
        
        /// <summary>
        /// 成分列表数据集合
        /// </summary>
        public DataSet _dsIngre = null;

        /// <summary>
        /// 含量列表数据集合
        /// </summary>
        public ArrayList _arrCali = null;

        /// <summary>
        /// ID表ID
        /// </summary>
        protected IngredientDto _dtoIngre = null;

        #endregion


        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public AutoBuildBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造
        /// </summary>
        public AutoBuildBase(IngredientDto dto)
        {
            InitializeComponent();

            this._dtoIngre = dto;
            this._bizPara = new ParaBiz();
        }
        
        #endregion


        #region 事件

        /// <summary>
        /// 取消按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void btnCancel_Click(object sender, EventArgs e)
        {
            ;
        }

        /// <summary>
        /// 确定按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void btnOK_Click(object sender, EventArgs e)
        {
            ;
        }

        #endregion
   
    }
}
