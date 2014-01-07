/*-----------------------------------------------------------------------------
//  FILE NAME       : SampleUs.cs
//  FUNCTION        : 样品信息基类
//  AUTHOR          : 李锋(2010/04//20)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoTool.ini;
using ChromatoBll.bll;

namespace ChromatoCore.sample
{
    /// <summary>
    /// 样品信息基类
    /// </summary>
    public partial class SampleUs : UserControl
    {

        #region 变量

        /// <summary>
        /// 访问方法
        /// </summary>
        public AccessMethod _accessM = AccessMethod.New;

        /// <summary>
        /// 参数dto
        /// </summary>
        public ParaDto _dtoPara = null;

        /// <summary>
        /// 样品逻辑
        /// </summary>
        protected ParaBiz _bizPara = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SampleUs()
        {
            InitializeComponent();
            this._bizPara = new ParaBiz();
        }

        #endregion


        #region 方法

        /// <summary>
        /// 装载画面
        /// </summary>
        /// <param name="dto"></param>
        public virtual void LoadUi(ParaDto dto)
        {
            ;
        }

        /// <summary>
        /// 按钮按下事件
        /// </summary>
        public virtual bool ButtonDealer()
        {
            return true;
        }

        /// <summary>
        /// 注册的合法性检查
        /// </summary>
        /// <returns></returns>
        public virtual bool RegValidCheck()
        {
            return true;
        }

        #endregion


    }
}
