/*-----------------------------------------------------------------------------
//  FILE NAME       : DetailItem.cs
//  FUNCTION        : 打印详细设定
//  AUTHOR          : 蔡海鹰(2009/06/08)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Windows.Forms;

namespace ChromatoPrint
{
    /// <summary>
    /// 打印详细设定
    /// </summary>
    class DetailItem
    {

        #region 常量

        private int top = 0;
        private int topOld = 0;
        private int left = 0;
        private int leftOld = 0;
        private int width = 0;
        private int widthOld = 0;
        private int height = 0;
        private int heightOld = 0;
        private FormWindowState windowState;
        private string theFormName;
        private bool formFound = false;
        private string keyPath;
        private RegistryKey baseKey;
        private SortedList<string, object> extras = null;
        
        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="formName"></param>
        public DetailItem(String formName)
        {
            this.openBaseKey();
            this.theFormName = formName;
            this.keyPath = "Forms\\" + formName;
            RegistryKey formKey = this.baseKey.OpenSubKey(this.keyPath);
            if (formKey == null)
            {
                this.formFound = false;
            }
            else
            {
                this.formFound = true;
                string[] valueNames = formKey.GetValueNames();
                foreach (string valueName in valueNames)
                {
                    object value = formKey.GetValue(valueName);
                    switch (valueName)
                    {
                        case "top":
                            this.top = Convert.ToInt32(value);
                            this.topOld = top;
                            break;
                        case "left":
                            this.left = Convert.ToInt32(value);
                            this.leftOld = left;
                            break;
                        case "width":
                            this.width = Convert.ToInt32(value);
                            this.widthOld = width;
                            break;
                        case "height":
                            this.height = Convert.ToInt32(value);
                            this.heightOld = height;
                            break;
                        case "windowState":
                            this.windowState = (FormWindowState)Convert.ToInt32(value);
                            break;
                        default:
                            if (this.extras == null)
                            {
                                this.extras = new SortedList<string, object>();
                            }
                            this.extras.Add(valueName.Substring(3), value);
                            break;
                    }
                }
                formKey.Close();
            }
            this.baseKey.Close();
        }

        #endregion


        #region 方法

        /// <summary>
        /// 注册表加入信息
        /// </summary>
        private void openBaseKey()
        {
            string subKeyPath = "Software\\" + Application.CompanyName + "\\" + Application.ProductName;
            this.baseKey = Registry.CurrentUser.OpenSubKey(subKeyPath, true);
            if (this.baseKey == null)
            {
                this.baseKey = Registry.CurrentUser.CreateSubKey(subKeyPath);
            }
        }

        /// <summary>
        /// 上边界
        /// </summary>
		public int Top
		{
			get
			{
				return top;
			}
			set
			{
				topOld = top;
				top = value;
			}
		}

        /// <summary>
        /// 左边界
        /// </summary>
		public int Left
		{
			get
			{
				return left;
			}
			set
			{
				leftOld = left;
				left = value;
			}
		}

        /// <summary>
        /// 宽度
        /// </summary>
		public int Width
		{
			get
			{
				return width;
			}
			set
			{
				widthOld = width;
				width = value;
			}
		}

        /// <summary>
        /// 高度
        /// </summary>
		public int Height
		{
			get
			{
				return height;
			}
			set
			{
				heightOld = height;
				height = value;
			}
		}

        /// <summary>
        /// 窗口状态
        /// </summary>
		public FormWindowState WindowState
		{
			get
			{
				return windowState;
			}
			set
			{
				windowState = value;
			}
		}

		public bool FormFound
		{
			get
			{
				return formFound;
			}
		}

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
        /// 窗口配置信息保存到注册表
        /// </summary>
		public void SaveForm()
		{
            int topSave;
            int leftSave;
            int heightSave;
            int widthSave;
            if (this.windowState == FormWindowState.Normal)
            {
                topSave = this.top;
                leftSave = this.left;
                heightSave = this.height;
                widthSave = this.width;
            }
            else
            {
                topSave = this.topOld;
                leftSave = this.leftOld;
                heightSave = this.heightOld;
                widthSave = this.widthOld;
            }
            this.openBaseKey();
            RegistryKey formKey = this.baseKey.OpenSubKey(this.keyPath, true);
            if (formKey == null)
            {
                formKey = baseKey.CreateSubKey(this.keyPath);
            }
            formKey.SetValue("top", this.top);
            formKey.SetValue("left", this.left);
            formKey.SetValue("width", this.width);
            formKey.SetValue("height", this.height);
            formKey.SetValue("windowState", Convert.ToInt32(this.windowState));
            if (this.extras != null)
            {
                foreach (string propertyName in this.extras.Keys)
                {
                    formKey.SetValue("ex_" + propertyName, this.extras[propertyName]);
                }
            }
            formKey.Close();
            baseKey.Close();
        }
        #endregion
    
    }
}
