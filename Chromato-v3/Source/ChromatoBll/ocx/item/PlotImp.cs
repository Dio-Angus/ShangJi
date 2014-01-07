/*-----------------------------------------------------------------------------
//  FILE NAME       : PlotImp.cs
//  FUNCTION        : PlotImp
//  AUTHOR          : 李锋(2009/02/17)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


using AxGRAPHOCXLib;
using ChromatoBll.ocx.inf;
using System.Collections;

namespace ChromatoBll.ocx.item
{
    /// <summary>
    /// 图形实现类
    /// </summary>
    public class PlotImp : IOcxItem, IPlot
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

        /// <summary>
        /// 点队列
        /// </summary>
        public ArrayList arr { get; set; }

        /// <summary>
        /// 该对象是否被使用
        /// </summary>
        public bool isUsed { get; set; }

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="axOcx"></param>
        public PlotImp(AxGraphOcx axOcx)
        {
            this.ocx = axOcx;
        }

        #endregion


        #region IPlot 成员

        /// <summary>
        /// 关联区域id
        /// </summary>
        public int Area
        {
            get
            {
                return ocx.get_PlotArea(this.id);
            }
            set
            {
                ocx.set_PlotArea(this.id, value);
            }
        }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Show
        {
            get
            {
                return ocx.get_PlotShow(this.id);
            }
            set
            {
                ocx.set_PlotShow(this.id, value);
            }
        }

        /// <summary>
        /// 是否显示点
        /// </summary>
        public bool ShowMarker
        {
            get
            {
                return ocx.get_PlotShowMarker(this.id);
            }
            set
            {
                ocx.set_PlotShowMarker(this.id, value);
            }
        }

        /// <summary>
        /// 数据总数
        /// </summary>
        public int DataCount
        {
            get
            {
                return ocx.get_PlotDataCount(this.id);
            }
            set
            {
                ocx.set_PlotDataCount(this.id, value);
            }
        }

        /// <summary>
        /// 开始点X值
        /// </summary>
        public double StartXValue
        {
            get
            {
                return ocx.get_PlotStartXValue(this.id);
            }
            set
            {
                ocx.set_PlotStartXValue(this.id, value);
            }
        }

        /// <summary>
        /// 结束点X值
        /// </summary>
        public double EndXValue
        {
            get
            {
                return ocx.get_PlotEndXValue(this.id);
            }
            set
            {
                ocx.set_PlotEndXValue(this.id, value);
            }
        }

        /// <summary>
        /// 开始点Y值
        /// </summary>
        public double StartYValue
        {
            get
            {
                return ocx.get_PlotStartYValue(this.id);
            }
            set
            {
                ocx.set_PlotStartYValue(this.id, value);
            }
        }

        /// <summary>
        /// 结束点Y值
        /// </summary>
        public double EndYValue
        {
            get
            {
                return ocx.get_PlotEndYValue(this.id);
            }
            set
            {
                ocx.set_PlotEndYValue(this.id, value);
            }
        }

        /// <summary>
        /// 曲线风格
        /// </summary>
        public int DatalineStyle
        {
            get
            {
                return ocx.get_PlotDatalineStyle(this.id);
            }
            set
            {
                ocx.set_PlotDatalineStyle(this.id, value);
            }
        }

        /// <summary>
        /// 曲线颜色
        /// </summary>
        public int DatalineColor
        {
            get
            {
                return ocx.get_PlotDatalineColor(this.id);
            }
            set
            {
                ocx.set_PlotDatalineColor(this.id, value);
            }
        }

        /// <summary>
        /// 点是否透明
        /// </summary>
        public bool MarkerTransparent
        {
            get
            {
                return ocx.get_PlotMarkerTransparent(this.id);
            }
            set
            {
                ocx.set_PlotMarkerTransparent(this.id, value);
            }
        }

        /// <summary>
        /// 点的风格
        /// </summary>
        public int MarkerStyle
        {
            get
            {
                return ocx.get_PlotMarkerStyle(this.id);
            }
            set
            {
                ocx.set_PlotMarkerStyle(this.id, value);
            }
        }

        /// <summary>
        /// 点的大小
        /// </summary>
        public int MarkerSize
        {
            get
            {
                return ocx.get_PlotMarkerSize(this.id);
            }
            set
            {
                ocx.set_PlotMarkerSize(this.id, value);
            }
        }

        /// <summary>
        /// 点的边框颜色
        /// </summary>
        public int MarkerBordercolor
        {
            get
            {
                return ocx.get_PlotMarkerBordercolor(this.id);
            }
            set
            {
                ocx.set_PlotMarkerBordercolor(this.id, value);
            }
        }

        /// <summary>
        /// 点的边框宽度
        /// </summary>
        public int MarkerBorderwidth
        {
            get
            {
                return ocx.get_PlotMarkerBorderwidth(this.id);
            }
            set
            {
                ocx.set_PlotMarkerBorderwidth(this.id, value);
            }
        }

        /// <summary>
        /// 点的填充颜色
        /// </summary>
        public int MarkerFillColor
        {
            get
            {
                return ocx.get_PlotMarkerFillColor(this.id);
            }
            set
            {
                ocx.set_PlotMarkerFillColor(this.id, value);
            }
        }

        /// <summary>
        /// 曲线左边像素
        /// </summary>
        public int Left
        {
            get
            {
                return ocx.get_PlotLeft(this.id);
            }
            set
            {
                ocx.set_PlotLeft(this.id, value);
            }
        }

        /// <summary>
        /// 曲线右边像素
        /// </summary>
        public int Right
        {
            get
            {
                return ocx.get_PlotRight(this.id);
            }
            set
            {
                ocx.set_PlotRight(this.id, value);
            }
        }

        /// <summary>
        /// 曲线上边像素
        /// </summary>
        public int Top
        {
            get
            {
                return ocx.get_PlotTop(this.id);
            }
            set
            {
                ocx.set_PlotTop(this.id, value);
            }
        }

        /// <summary>
        /// 曲线下边像素
        /// </summary>
        public int Bottom
        {
            get
            {
                return ocx.get_PlotBottom(this.id);
            }
            set
            {
                ocx.set_PlotBottom(this.id, value);
            }
        }

        /// <summary>
        /// 曲线左边值
        /// </summary>
        public double LeftValue
        {
            get
            {
                return ocx.get_PlotLeftValue(this.id);
            }
            set
            {
                ocx.set_PlotLeftValue(this.id, value);
            }
        }

        /// <summary>
        /// 曲线右边值
        /// </summary>
        public double RightValue
        {
            get
            {
                return ocx.get_PlotRightValue(this.id);
            }
            set
            {
                ocx.set_PlotRightValue(this.id, value);
            }
        }

        /// <summary>
        /// 曲线上边值
        /// </summary>
        public double TopValue
        {
            get
            {
                return ocx.get_PlotTopValue(this.id);
            }
            set
            {
                ocx.set_PlotTopValue(this.id, value);
            }
        }

        /// <summary>
        /// 曲线下边值
        /// </summary>
        public double BottomValue
        {
            get
            {
                return ocx.get_PlotBottomValue(this.id);
            }
            set
            {
                ocx.set_PlotBottomValue(this.id, value);
            }
        }

        /// <summary>
        /// 区域外的线是否显示
        /// </summary>
        public bool Clip
        {
            get
            {
                return ocx.get_PlotClip(this.id);
            }
            set
            {
                ocx.set_PlotClip(this.id, value);
            }
        }

        /// <summary>
        /// 使用线段类
        /// </summary>
        public bool UseDashline
        {
            get
            {
                return ocx.get_PlotUseDashline(this.id);
            }
            set
            {
                ocx.set_PlotUseDashline(this.id, value);
            }
        }

        /// <summary>
        /// 数据线的宽度
        /// </summary>
        public int DatalineWidth
        {
            get
            {
                return ocx.get_PlotDatalineWidth(this.id);
            }
            set
            {
                ocx.set_PlotDatalineWidth(this.id, value);
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

        /// <summary>
        /// 取得标记点状态
        /// </summary>
        /// <param name="nMarkerId"></param>
        /// <returns></returns>
        public bool GetMarkerState(int nMarkerId)
        {
            return ocx.get_PlotMarkerState(this.id, nMarkerId);
        }

        /// <summary>
        /// 设定标记点状态
        /// </summary>
        /// <param name="nMarkerId"></param>
        /// <param name="value"></param>
        public void SetMarkerState(int nMarkerId, bool value)
        {
            ocx.set_PlotMarkerState(this.id, nMarkerId, value);
        }

        #endregion
    }
}
