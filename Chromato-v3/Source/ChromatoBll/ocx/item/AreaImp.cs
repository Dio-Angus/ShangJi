/*-----------------------------------------------------------------------------
//  FILE NAME       : AreaImp.cs
//  FUNCTION        : AreaImp
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
    /// 区域实现类
    /// </summary>
    public class AreaImp : IOcxItem, IArea
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
        public AreaImp(AxGraphOcx axOcx)
        {
            this.ocx = axOcx;
        }

        #endregion


        #region IArea Members

        /// <summary>
        /// 左边像素
        /// </summary>
        public int Left
        {
            get
            {
               return ocx.get_AreaLeft(this.id);
            }
            set
            {
                ocx.set_AreaLeft(this.id, value);
            }
        }

        /// <summary>
        /// 右边像素
        /// </summary>
        public int Right
        {
            get
            {
                return ocx.get_AreaRight(this.id);
            }
            set
            {
                ocx.set_AreaRight(this.id, value);
            }
        }

        /// <summary>
        /// 上边像素
        /// </summary>
        public int Top
        {
            get
            {
                return ocx.get_AreaTop(this.id);
            }
            set
            {
                ocx.set_AreaTop(this.id, value);
            }
        }

        /// <summary>
        /// 下边像素
        /// </summary>
        public int Bottom
        {
            get
            {
                return ocx.get_AreaBottom(this.id);
            }
            set
            {
                ocx.set_AreaBottom(this.id, value);
            }
        }

        /// <summary>
        /// 颜色
        /// </summary>
        public int ColorBrush
        {
            get
            {
                return ocx.get_AreaColorBrush(this.id);
            }
            set
            {
                ocx.set_AreaColorBrush(this.id, value);
            }
        }

        /// <summary>
        /// 关联的X轴
        /// </summary>
        public int XAxis
        {
            get
            {
                return ocx.get_AreaXAxis(this.id);
            }
            set
            {
                ocx.set_AreaXAxis(this.id, value);
            }
        }

        /// <summary>
        /// 关联的Y轴
        /// </summary>
        public int YAxis
        {
            get
            {
                return ocx.get_AreaYAxis(this.id);
            }
            set
            {
                ocx.set_AreaYAxis(this.id, value);
            }
        }

        /// <summary>
        /// 左边界值
        /// </summary>
        public double LeftValue
        {
            get
            {
                return ocx.get_AreaLeftValue(this.id);
            }
            set
            {
                ocx.set_AreaLeftValue(this.id, value);
            }
        }

        /// <summary>
        /// 右边界值
        /// </summary>
        public double RightValue
        {
            get
            {
                return ocx.get_AreaRightValue(this.id);
            }
            set
            {
                ocx.set_AreaRightValue(this.id, value);
            }
        }

        /// <summary>
        /// 上边界值
        /// </summary>
        public double TopValue
        {
            get
            {
                return ocx.get_AreaTopValue(this.id);
            }
            set
            {
                ocx.set_AreaTopValue(this.id, value);
            }
        }

        /// <summary>
        /// 下边界值
        /// </summary>
        public double BottomValue
        {
            get
            {
                return ocx.get_AreaBottomValue(this.id);
            }
            set
            {
                ocx.set_AreaBottomValue(this.id, value);
            }
        }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Show
        {
            get
            {
                return ocx.get_AreaShow(this.id);
            }
            set
            {
                ocx.set_AreaShow(this.id, value);
            }
        }

        /// <summary>
        /// 是否显示区域外
        /// </summary>
        public bool Clip
        {
            get
            {
                return ocx.get_AreaClip(this.id);
            }
            set
            {
                ocx.set_AreaClip(this.id, value);
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
