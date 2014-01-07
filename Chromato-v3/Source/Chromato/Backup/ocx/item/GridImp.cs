/*-----------------------------------------------------------------------------
//  FILE NAME       : GridImp.cs
//  FUNCTION        : GridImp
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
    /// 网格实现类
    /// </summary>
    public class GridImp : IOcxItem, IGrid
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
        public GridImp(AxGraphOcx axOcx)
        {
            this.ocx = axOcx;
        }

        #endregion


        #region IGrid 成员

        /// <summary>
        /// 左边界像素
        /// </summary>
        public int Left
        {
            get
            {
                return ocx.get_GridLeft(this.id);
            }
            set
            {
                ocx.set_GridLeft(this.id, value);
            }
        }

        /// <summary>
        /// 右边界像素
        /// </summary>
        public int Right
        {
            get
            {
                return ocx.get_GridRight(this.id);
            }
            set
            {
                ocx.set_GridRight(this.id, value);
            }
        }

        /// <summary>
        /// 上边界像素
        /// </summary>
        public int Top
        {
            get
            {
                return ocx.get_GridTop(this.id);
            }
            set
            {
                ocx.set_GridTop(this.id, value);
            }
        }

        /// <summary>
        /// 下边界像素
        /// </summary>
        public int Bottom
        {
            get
            {
                return ocx.get_GridBottom(this.id);
            }
            set
            {
                ocx.set_GridBottom(this.id, value);
            }
        }

        /// <summary>
        /// 外框线风格
        /// </summary>
        public int OutLineStyle
        {
            get
            {
                return ocx.get_GridOutLineStyle(this.id);
            }
            set
            {
                ocx.set_GridOutLineStyle(this.id, value);
            }
        }

        /// <summary>
        /// 外框线宽度
        /// </summary>
        public int OutLineWidth
        {
            get
            {
                return ocx.get_GridOutLineWidth(this.id);
            }
            set
            {
                ocx.set_GridOutLineWidth(this.id, value);
            }
        }

        /// <summary>
        /// 外框线颜色
        /// </summary>
        public int OutLineColor
        {
            get
            {
                return ocx.get_GridOutLineColor(this.id);
            }
            set
            {
                ocx.set_GridOutLineColor(this.id, value);
            }
        }

        /// <summary>
        /// 内部分割线风格
        /// </summary>
        public int InLineStyle
        {
            get
            {
                return ocx.get_GridInLineStyle(this.id);
            }
            set
            {
                ocx.set_GridInLineStyle(this.id, value);
            }
        }

        /// <summary>
        /// 内部分割线宽度
        /// </summary>
        public int InLineWidth
        {
            get
            {
                return ocx.get_GridInLineWidth(this.id);
            }
            set
            {
                ocx.set_GridInLineWidth(this.id, value);
            }
        }

        /// <summary>
        /// 内部分割线颜色
        /// </summary>
        public int InLineColor
        {
            get
            {
                return ocx.get_GridInLineColor(this.id);
            }
            set
            {
                ocx.set_GridInLineColor(this.id, value);
            }
        }

        /// <summary>
        /// 填充颜色
        /// </summary>
        public int BrushColor
        {
            get
            {
                return ocx.get_GridBrushColor(this.id);
            }
            set
            {
                ocx.set_GridBrushColor(this.id, value);
            }
        }

        /// <summary>
        /// 水平分割数量
        /// </summary>
        public int HorzCount
        {
            get
            {
                return ocx.get_GridHorzCount(this.id);
            }
            set
            {
                ocx.set_GridHorzCount(this.id, value);
            }
        }

        /// <summary>
        /// 垂直分割数量
        /// </summary>
        public int VertCount
        {
            get
            {
                return ocx.get_GridVertCount(this.id);
            }
            set
            {
                ocx.set_GridVertCount(this.id, value);
            }
        }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Show
        {
            get
            {
                return ocx.get_GridShow(this.id);
            }
            set
            {
                ocx.set_GridShow(this.id, value);
            }
        }

        /// <summary>
        /// 是否透明
        /// </summary>
        public bool TransParent
        {
            get
            {
                return ocx.get_GridTransParent(this.id);
            }
            set
            {
                ocx.set_GridTransParent(this.id, value);
            }
        }

        /// <summary>
        /// 是否显示分割线
        /// </summary>
        public bool InLineShow
        {
            get
            {
                return ocx.get_GridInLineShow(this.id);
            }
            set
            {
                ocx.set_GridInLineShow(this.id, value);
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
