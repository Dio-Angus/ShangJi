/*-----------------------------------------------------------------------------
//  FILE NAME       : PrintMngUser.cs
//  FUNCTION        : 打印管理的用户控件
//  AUTHOR          : ｲﾌｺ｣坥(2009/06/09)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace ChromatoPrint
{
    /// <summary>
    /// 打印管理的用户控件
    /// </summary>
    [ToolboxBitmap(typeof(PrintExtBar), "PrintBar.Res.FormManagement.bmp")]
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class PrintMngUser : UserControl
    {

        #region 变量

        private string namePrePend = "";
        private SortedList<string, object> extras = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public PrintMngUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintBar_Load(object sender, EventArgs e)
        {
            if (!(this.ParentForm.Parent != null &&
                this.ParentForm.Parent.ToString().Equals("System.Windows.Forms.Design.DesignerFrame+OverlayControl")))
            {
                this.LoadSettings();
                this.ParentForm.Closing += new CancelEventHandler(theParent_Closing);
            }
            else if (this.ParentForm.Parent != null)
            {
                this.ParentForm.StartPosition = FormStartPosition.Manual;
            }
        }

        #endregion


        #region 方法

        /// <summary>
        /// 
        /// </summary>
        public string NamePrepend
        {
            get
            {
                return this.namePrePend;
            }
            set
            {
                this.namePrePend = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="property"></param>
        public void AddExtra(string propertyName, object property)
        {
            if (this.extras == null)
            {
                this.extras = new SortedList<string,object>();
            }
            if (this.extras.ContainsKey(propertyName))
            {
                this.extras[propertyName] = property;
            }
            else
            {
                this.extras.Add(propertyName, property);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SortedList<string, object> Extras
        {
            get
            {
                return this.extras;
            }
            set
            {
                this.extras = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadSettings()
        {
            DetailItem itemDetail = new DetailItem(this.namePrePend + this.ParentForm.Name);
            if (itemDetail.FormFound)
            {
                this.ParentForm.Top = itemDetail.Top;
                this.ParentForm.Left = itemDetail.Left;
                this.ParentForm.Width = itemDetail.Width;
                this.ParentForm.Height = itemDetail.Height;
                this.ParentForm.WindowState = itemDetail.WindowState;
                this.extras = itemDetail.Extras;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveSettings()
        {
            DetailItem theForm = new DetailItem(this.namePrePend + this.ParentForm.Name);
            theForm.Top = this.ParentForm.Top;
            theForm.Left = this.ParentForm.Left;
            theForm.Width = this.ParentForm.Width;
            theForm.Height = this.ParentForm.Height;
            theForm.WindowState = this.ParentForm.WindowState;
            theForm.Extras = this.extras;
            theForm.SaveForm();
        }

        /// <summary>
        /// 父窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void theParent_Closing(object sender, CancelEventArgs e)
        {
            this.SaveSettings();
        }

        #endregion


    }
}
