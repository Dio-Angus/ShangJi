/*-----------------------------------------------------------------------------
//  FILE NAME       : AttributImp.cs
//  FUNCTION        : AttributImp
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
    /// 属性实现类
    /// </summary>
    public class AttributImp : IOcxItem, IAttri
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
        public AttributImp(AxGraphOcx axOcx)
        {
            this.ocx = axOcx;
        }

        #endregion


        #region IAttri 成员

        /// <summary>
        /// 起点X坐标
        /// </summary>
        public int X
        {
            get
            {
                return ocx.get_AttributeX(this.id);
            }
            set
            {
                ocx.set_AttributeX(this.id, value);
            }
        }

        /// <summary>
        /// 起点Y坐标
        /// </summary>
        public int Y
        {
            get
            {
                return ocx.get_AttributeY(this.id);
            }
            set
            {
                ocx.set_AttributeY(this.id, value);
            }
        }

        /// <summary>
        /// 前景色
        /// </summary>
        public int ForeColor
        {
            get
            {
                return ocx.get_AttributeForeColor(this.id);
            }
            set
            {
                ocx.set_AttributeForeColor(this.id, value);
            }
        }

        /// <summary>
        /// 背景色
        /// </summary>
        public int BackColor
        {
            get
            {
                return ocx.get_AttributeBackColor(this.id);
            }
            set
            {
                ocx.set_AttributeBackColor(this.id, value);
            }
        }

        /// <summary>
        /// 字体大小
        /// </summary>
        public int FontSize
        {
            get
            {
                return ocx.get_AttributeFontSize(this.id);
            }
            set
            {
                ocx.set_AttributeFontSize(this.id, value);
            }
        }

        /// <summary>
        /// 是否下划线
        /// </summary>
        public bool FontUnderline
        {
            get
            {
                return ocx.get_AttributeFontUnderline(this.id);
            }
            set
            {
                ocx.set_AttributeFontUnderline(this.id, value);
            }
        }

        /// <summary>
        /// 是否粗体
        /// </summary>
        public bool FontBold
        {
            get
            {
                return ocx.get_AttributeFontBold(this.id);
            }
            set
            {
                ocx.set_AttributeFontBold(this.id, value);
            }
        }

        /// <summary>
        /// 是否斜体
        /// </summary>
        public bool FontItalic
        {
            get
            {
                return ocx.get_AttributeFontItalic(this.id);
            }
            set
            {
                ocx.set_AttributeFontItalic(this.id, value);
            }
        }

        /// <summary>
        /// 方向
        /// </summary>
        public int Direction
        {
            get
            {
                return ocx.get_AttributeDirection(this.id);
            }
            set
            {
                ocx.set_AttributeDirection(this.id, value);
            }
        }

        /// <summary>
        /// 停靠
        /// </summary>
        public int Align
        {
            get
            {
                return ocx.get_AttributeAlign(this.id);
            }
            set
            {
                ocx.set_AttributeAlign(this.id, value);
            }
        }

        /// <summary>
        /// 字体名
        /// </summary>
        public string FontName
        {
            get
            {
                return ocx.get_AttributeFontName(this.id);
            }
            set
            {
                ocx.set_AttributeFontName(this.id, value);
            }
        }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Show
        {
            get
            {
                return ocx.get_AttributeShow(this.id);
            }
            set
            {
                ocx.set_AttributeShow(this.id, value);
            }
        }

        /// <summary>
        /// 右部坐标
        /// </summary>
        public int Right
        {
            get
            {
                return ocx.get_AttributeRight(this.id);
            }
            set
            {
                ocx.set_AttributeRight(this.id, value);
            }
        }

        /// <summary>
        /// 底部坐标
        /// </summary>
        public int Bottom
        {
            get
            {
                return ocx.get_AttributeBottom(this.id);
            }
            set
            {
                ocx.set_AttributeBottom(this.id, value);
            }
        }

        /// <summary>
        /// 是否透明
        /// </summary>
        public bool Transparent
        {
            get
            {
                return ocx.get_AttributeTransparent(this.id);
            }
            set
            {
                ocx.set_AttributeTransparent(this.id, value);
            }
        }
        
        #endregion


        #region 方法

        /// <summary>
        /// 设定颜色
        /// </summary>
        /// <param name="nID"></param>
        /// <param name="color"></param>
        public void SetLabelColor(short nID, int color)
        {
            ocx.set_AttributeLabelColor(this.id, nID, color);
        }

        /// <summary>
        /// 取得颜色
        /// </summary>
        /// <param name="nID"></param>
        /// <returns></returns>
        public int GetLabelColor(short nID)
        {
            return ocx.get_AttributeLabelColor(this.id, nID);
        }

        /// <summary>
        /// 设定字符串
        /// </summary>
        /// <param name="nID"></param>
        /// <param name="name"></param>
        public void SetName(short nID, string name)
        {
            ocx.set_AttributeName(this.id, nID, name);
        }

        /// <summary>
        /// 取得字符串
        /// </summary>
        /// <param name="nID"></param>
        /// <returns></returns>
        public string GetName(short nID)
        {
            return ocx.get_AttributeName(this.id, nID);
        }

        #endregion

    }
}
