/*-----------------------------------------------------------------------------
//  FILE NAME       : SoluRemarkViewer.cs
//  FUNCTION        : 方案备注视图
//  AUTHOR          : 李锋(2009/06/12)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.ini;
using ChromatoTool.dto;

namespace ChromatoCore.solu.Remark
{
    /// <summary>
    /// 方案备注视图
    /// </summary>
    public partial class SoluRemarkViewer : UserControl
    {

        
        #region 变量

        /// <summary>
        /// 访问方法
        /// </summary>
        public AccessMethod _accessM = AccessMethod.New;

        /// <summary>
        /// 方案dto
        /// </summary>
        private SolutionDto _dto = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SoluRemarkViewer(AccessMethod am)
        {
            InitializeComponent();
            this._accessM = am;

            this.LoadEvent();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            //this.txtShowMaxY.TextChanged += new System.EventHandler(this.txtShowMaxY_TextChanged);
            //this.txtShowMinY.TextChanged += new System.EventHandler(this.txtShowMinY_TextChanged);
        }

        #endregion


        #region 方法

        /// <summary>
        /// 显示采集方法的详细信息
        /// </summary>
        /// <param name="dto"></param>
        public void LoadUi(SolutionDto dto)
        {
            this._dto = dto;
            this.gbRemark.Enabled = (null == this._dto) ? false : true;
            if (null == this._dto)
            {
                return;
            }

            switch (this._accessM)
            {
                case AccessMethod.View:
                    this.LoadView();
                    break;

                case AccessMethod.New:
                    this.LoadNew();
                    break;

                case AccessMethod.Edit:
                    this.LoadEdit();
                    break;

                case AccessMethod.SaveAs:
                    this.LoadSaveAs();
                    break;
            }
        }

        /// <summary>
        /// 显示方案的信息
        /// </summary>
        private void LoadView()
        {
            this.rtbRemark.Text = this._dto.Remark;
            this.rtbRemark.ReadOnly = true;
            this.rtbRemark.BackColor = Color.Beige;
        }

        /// <summary>
        /// 新建立方案的信息
        /// </summary>
        private void LoadNew()
        {
            this.rtbRemark.Text = "新方案";
            this.rtbRemark.ReadOnly = false;
            this.rtbRemark.BackColor = Color.White;
            this._dto.Remark = this.rtbRemark.Text;
        }

        /// <summary>
        /// 编辑当前方案的信息
        /// </summary>
        private void LoadEdit()
        {
            this.rtbRemark.Text = this._dto.Remark;
            this.rtbRemark.ReadOnly = false;
            this.rtbRemark.BackColor = Color.White;
        }

        /// <summary>
        /// 复制当前方案的信息
        /// </summary>
        private void LoadSaveAs()
        {
            this.rtbRemark.Text = this._dto.Remark;
            this.rtbRemark.ReadOnly = true;
            this.rtbRemark.BackColor = Color.Beige;
        }

        #endregion


        #region 事件

        /// <summary>
        /// 备注文字改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbRemark_TextChanged(object sender, System.EventArgs e)
        {
            this._dto.Remark = this.rtbRemark.Text;
        }

        #endregion


    }
}
