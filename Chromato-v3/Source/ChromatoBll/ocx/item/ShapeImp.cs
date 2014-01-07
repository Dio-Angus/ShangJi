/*-----------------------------------------------------------------------------
//  FILE NAME       : ShapeImp.cs
//  FUNCTION        : ShapeImp
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
    /// 矩形实现类
    /// </summary>
    public class ShapeImp : IOcxItem, IShape
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
        public ShapeImp(AxGraphOcx axOcx)
        {
            this.ocx = axOcx;
        }

        #endregion


        #region IShape 成员

        /// <summary>
        /// 矩形起点X坐标
        /// </summary>
        public int X
        {
            get
            {
                return ocx.get_ShapeX(this.id);
            }
            set
            {
                ocx.set_ShapeX(this.id, value);
            }
        }

        /// <summary>
        /// 矩形起点Y坐标
        /// </summary>
        public int Y
        {
            get
            {
                return ocx.get_ShapeY(this.id);
            }
            set
            {
                ocx.set_ShapeY(this.id, value);
            }
        }

        /// <summary>
        /// 矩形高度
        /// </summary>
        public int Height
        {
            get
            {
                return ocx.get_ShapeHeight(this.id);
            }
            set
            {
                ocx.set_ShapeHeight(this.id, value);
            }
        }

        /// <summary>
        /// 矩形宽度
        /// </summary>
        public int Width
        {
            get
            {
                return ocx.get_ShapeWidth(this.id);
            }
            set
            {
                ocx.set_ShapeWidth(this.id, value);
            }
        }

        /// <summary>
        /// 矩形是否显示
        /// </summary>
        public bool Show
        {
            get
            {
                return ocx.get_ShapeShow(this.id);
            }
            set
            {
                ocx.set_ShapeShow(this.id, value);
            }
        }

        /// <summary>
        /// 矩形是否透明
        /// </summary>
        public bool Transparent
        {
            get
            {
                return ocx.get_ShapeTransparent(this.id);
            }
            set
            {
                ocx.set_ShapeTransparent(this.id, value);
            }
        }

        /// <summary>
        /// 矩形起点填充模式
        /// </summary>
        public int FillPattern
        {
            get
            {
                return ocx.get_ShapeFillPattern(this.id);
            }
            set
            {
                ocx.set_ShapeFillPattern(this.id, value);
            }
        }

        /// <summary>
        /// 矩形填充颜色
        /// </summary>
        public int FillColor
        {
            get
            {
                return ocx.get_ShapeFillColor(this.id);
            }
            set
            {
                ocx.set_ShapeFillColor(this.id, value);
            }
        }

        /// <summary>
        /// 矩形边框颜色
        /// </summary>
        public int BorderColor
        {
            get
            {
                return ocx.get_ShapeBorderColor(this.id);
            }
            set
            {
                ocx.set_ShapeBorderColor(this.id, value);
            }
        }

        /// <summary>
        /// 矩形水平微调像素
        /// </summary>
        public int AdjustX
        {
            get
            {
                return ocx.get_ShapeAdjustX(this.id);
            }
            set
            {
                ocx.set_ShapeAdjustX(this.id, value);
            }
        }

        /// <summary>
        /// 矩形垂直微调像素
        /// </summary>
        public int AdjustY
        {
            get
            {
                return ocx.get_ShapeAdjustY(this.id);
            }
            set
            {
                ocx.set_ShapeAdjustY(this.id, value);
            }
        }

        /// <summary>
        /// 矩形Z方向序号
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
