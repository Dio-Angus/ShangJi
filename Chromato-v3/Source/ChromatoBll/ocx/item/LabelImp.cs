/*-----------------------------------------------------------------------------
//  FILE NAME       : LabelImp.cs
//  FUNCTION        : LabelImp
//  AUTHOR          : 李锋(2009/02/17)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


using AxGRAPHOCXLib;
using ChromatoBll.ocx.inf;

namespace ChromatoBll.ocx.item
{
    /// <summary>
    /// 标签实现类
    /// </summary>
    public class LabelImp : IOcxItem, ILabel
    {

        #region 变量

        /// <summary>
        /// 控件对象
        /// </summary>
        public AxGraphOcx ocx { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public short id { get; set; }

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="axOcx"></param>
        public LabelImp(AxGraphOcx axOcx)
        {
            this.ocx = axOcx;
        }

        #endregion


        #region ILabel 成员

        /// <summary>
        /// 开始点X坐标
        /// </summary>
        public int X
        {
            get
            {
                return ocx.get_LabelX(this.id);
            }
            set
            {
                ocx.set_LabelX(this.id, value);
            }
        }

        /// <summary>
        /// 开始点Y坐标
        /// </summary>
        public int Y
        {
            get
            {
                return ocx.get_LabelY(this.id);
            }
            set
            {
                ocx.set_LabelY(this.id, value);
            }
        }

        /// <summary>
        /// 前景色
        /// </summary>
        public int ForeColor
        {
            get
            {
                return ocx.get_LabelForeColor(this.id);
            }
            set
            {
                ocx.set_LabelForeColor(this.id, value);
            }
        }

        /// <summary>
        /// 背景色
        /// </summary>
        public int BackColor
        {
            get
            {
                return ocx.get_LabelBackColor(this.id);
            }
            set
            {
                ocx.set_LabelBackColor(this.id, value);
            }
        }

        /// <summary>
        /// 字体大小
        /// </summary>
        public int FontSize
        {
            get
            {
                return ocx.get_LabelFontSize(this.id);
            }
            set
            {
                ocx.set_LabelFontSize(this.id, value);
            }
        }

        /// <summary>
        /// 字体是否有下划线
        /// </summary>
        public bool FontUnderline
        {
            get
            {
                return ocx.get_LabelFontUnderline(this.id);
            }
            set
            {
                ocx.set_LabelFontUnderline(this.id, value);
            }
        }

        /// <summary>
        /// 字体是否为粗体
        /// </summary>
        public bool FontBold
        {
            get
            {
                return ocx.get_LabelFontBold(this.id);
            }
            set
            {
                ocx.set_LabelFontBold(this.id, value);
            }
        }

        /// <summary>
        /// 字体是否为斜体
        /// </summary>
        public bool FontItalic
        {
            get
            {
                return ocx.get_LabelFontItalic(this.id);
            }
            set
            {
                ocx.set_LabelFontItalic(this.id, value);
            }
        }

        /// <summary>
        /// 字体的方向（水平还是垂直）
        /// </summary>
        public int Direction
        {
            get
            {
                return ocx.get_LabelDirection(this.id);
            }
            set
            {
                ocx.set_LabelDirection(this.id, value);
            }
        }

        /// <summary>
        /// 停靠位置
        /// </summary>
        public int Align
        {
            get
            {
                return ocx.get_LabelAlign(this.id);
            }
            set
            {
                ocx.set_LabelAlign(this.id, value);
            }
        }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Show
        {
            get
            {
                return ocx.get_LabelShow(this.id);
            }
            set
            {
                ocx.set_LabelShow(this.id, value);
            }
        }

        /// <summary>
        /// 字体名
        /// </summary>
        public string FontName
        {
            get
            {
                return ocx.get_LabelFontName(this.id, 20);
            }
            set
            {
                ocx.set_LabelFontName(this.id, 20, value);
            }
        }

        /// <summary>
        /// 显示字符串
        /// </summary>
        public string Text
        {
            get
            {
                return "";
            }
            set
            {
                ocx.SetLabelText(this.id, 20, value);
            }
        }

        /// <summary>
        /// Z方向序号
        /// </summary>
        public short ZorderOcx
        {
            get
            {
                return ocx.get_ZorderOcx(this.id);
            }
            set
            {
                ocx.set_ZorderOcx(this.id, value);
            }
        }

        #endregion
    }
}
