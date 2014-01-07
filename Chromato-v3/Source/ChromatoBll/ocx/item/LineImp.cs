/*-----------------------------------------------------------------------------
//  FILE NAME       : LineImp.cs
//  FUNCTION        : LineImp
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
    /// 直线实现类
    /// </summary>
    public class LineImp : IOcxItem, ILine
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
        public LineImp(AxGraphOcx axOcx)
        {
            this.ocx = axOcx;
        }

        #endregion


        #region ILine 成员

        /// <summary>
        /// 开始点X方向像素坐标
        /// </summary>
        public int StartX
        {
            get
            {
                return ocx.get_LineStratX(this.id);
            }
            set
            {
                ocx.set_LineStratX(this.id, value);
            }
        }

        /// <summary>
        /// 开始点Y方向像素坐标
        /// </summary>
        public int StartY
        {
            get
            {
                return ocx.get_LineStartY(this.id);
            }
            set
            {
                ocx.set_LineStartY(this.id, value);
            }
        }

        /// <summary>
        /// 结束点X方向像素坐标
        /// </summary>
        public int EndX
        {
            get
            {
                return ocx.get_LineEndX(this.id);
            }
            set
            {
                ocx.set_LineEndX(this.id, value);
            }
        }

        /// <summary>
        /// 结束点Y方向像素坐标
        /// </summary>
        public int EndY
        {
            get
            {
                return ocx.get_LineEndY(this.id);
            }
            set
            {
                ocx.set_LineEndY(this.id, value);
            }
        }

        /// <summary>
        /// 线风格
        /// </summary>
        public int Style
        {
            get
            {
                return ocx.get_LineStyle(this.id);
            }
            set
            {
                ocx.set_LineStyle(this.id, value);
            }
        }

        /// <summary>
        /// 线宽度
        /// </summary>
        public int Width
        {
            get
            {
                return ocx.get_LineWidth(this.id);
            }
            set
            {
                ocx.set_LineWidth(this.id, value);
            }
        }

        /// <summary>
        /// 线颜色
        /// </summary>
        public int Color
        {
            get
            {
                return ocx.get_LineColor(this.id);
            }
            set
            {
                ocx.set_LineColor(this.id, value);
            }
        }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Show
        {
            get
            {
                return ocx.get_LineShow(this.id);
            }
            set
            {
                ocx.set_LineShow(this.id, value);
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
