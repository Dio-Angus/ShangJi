/*-----------------------------------------------------------------------------
//  FILE NAME       : AxisYImp.cs
//  FUNCTION        : AxisYImp
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
    /// Y坐标轴实现类
    /// </summary>
    public class AxisYImp : IOcxItem,IAxis
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
        public AxisYImp(AxGraphOcx axOcx)
        {
            this.ocx = axOcx;
        }

        #endregion


        #region IAxis 成员
        
        /// <summary>
        /// 坐标轴线颜色
        /// </summary>
        public int LineColor
        {
            get
            {
                return ocx.get_AxisLineColor(this.id);
            }
            set
            {
                ocx.set_AxisLineColor(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴线风格
        /// </summary>
        public int LineStyle
        {
            get
            {
                return ocx.get_AxisLineStyle(this.id);
            }
            set
            {
                ocx.set_AxisLineStyle(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴线宽度
        /// </summary>
        public int LineWidth
        {
            get
            {
                return ocx.get_AxisLineWidth(this.id);
            }
            set
            {
                ocx.set_AxisLineWidth(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴标签停靠位置
        /// </summary>
        public int Align
        {
            get
            {
                return ocx.get_AxisAlign(this.id);
            }
            set
            {
                ocx.set_AxisAlign(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴是否显示
        /// </summary>
        public bool Show
        {
            get
            {
                return ocx.get_AxisShow(this.id);
            }
            set
            {
                ocx.set_AxisShow(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的方向
        /// </summary>
        public int Direction
        {
            get
            {
                return ocx.get_AxisDirection(this.id);
            }
            set
            {
                ocx.set_AxisDirection(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的开始值
        /// </summary>
        public double StartValue
        {
            get
            {
                return ocx.get_AxisStartValue(this.id);
            }
            set
            {
                ocx.set_AxisStartValue(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的结束值
        /// </summary>
        public double EndValue
        {
            get
            {
                return ocx.get_AxisEndValue(this.id);
            }
            set
            {
                ocx.set_AxisEndValue(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的小数位数
        /// </summary>
        public int FloatFigure
        {
            get
            {
                return ocx.get_AxisFloatFigure(this.id);
            }
            set
            {
                ocx.set_AxisFloatFigure(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的开始点横坐标
        /// </summary>
        public int X
        {
            get
            {
                return ocx.get_AxisX(this.id);
            }
            set
            {
                ocx.set_AxisX(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的开始点纵坐标
        /// </summary>
        public int Y
        {
            get
            {
                return ocx.get_AxisY(this.id);
            }
            set
            {
                ocx.set_AxisY(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的长度
        /// </summary>
        public int Length
        {
            get
            {
                return ocx.get_AxisLength(this.id);
            }
            set
            {
                ocx.set_AxisLength(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的X方向偏移量
        /// </summary>
        public int OffsetX
        {
            get
            {
                return ocx.get_AxisOffsetX(this.id);
            }
            set
            {
                ocx.set_AxisOffsetX(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的Y方向偏移量
        /// </summary>
        public int OffsetY
        {
            get
            {
                return ocx.get_AxisOffsetY(this.id);
            }
            set
            {
                ocx.set_AxisOffsetY(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的刻度数量
        /// </summary>
        public int ScaleCount
        {
            get
            {
                return ocx.get_AxisScaleCount(this.id);
            }
            set
            {
                ocx.set_AxisScaleCount(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的刻度线颜色
        /// </summary>
        public int ScaleLineColor
        {
            get
            {
                return ocx.get_AxisScaleLineColor(this.id);
            }
            set
            {
                ocx.set_AxisScaleLineColor(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的刻度线风格
        /// </summary>
        public int ScaleLineStyle
        {
            get
            {
                return ocx.get_AxisScaleLineStyle(this.id);
            }
            set
            {
                ocx.set_AxisScaleLineStyle(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的刻度线宽度
        /// </summary>
        public int ScaleLineWidth
        {
            get
            {
                return ocx.get_AxisScaleLineWidth(this.id);
            }
            set
            {
                ocx.set_AxisScaleLineWidth(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的标签颜色
        /// </summary>
        public int ValueColor
        {
            get
            {
                return ocx.get_AxisValueColor(this.id);
            }
            set
            {
                ocx.set_AxisValueColor(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的标签字体是否粗体
        /// </summary>
        public bool LabelFontBold
        {
            get
            {
                return ocx.get_AxisLabelFontBold(this.id);
            }
            set
            {
                ocx.set_AxisLabelFontBold(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的标签字体是否斜体
        /// </summary>
        public bool LabelFontItalic
        {
            get
            {
                return ocx.get_AxisLabelFontItalic(this.id);
            }
            set
            {
                ocx.set_AxisLabelFontItalic(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的标签字体名
        /// </summary>
        public string LabelFontName
        {
            get
            {
                return ocx.get_AxisLabelFontName(this.id, 20);
            }
            set
            {
                ocx.set_AxisLabelFontName(this.id, 20, value);
            }
        }

        /// <summary>
        /// 坐标轴的标签字体大小
        /// </summary>
        public int LabelFontSize
        {
            get
            {
                return ocx.get_AxisLabelFontSize(this.id);
            }
            set
            {
                ocx.set_AxisLabelFontSize(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的标签字体是否有下划线
        /// </summary>
        public bool LabelFontUnderline
        {
            get
            {
                return ocx.get_AxisLabelFontUnderline(this.id);
            }
            set
            {
                ocx.set_AxisLabelFontUnderline(this.id, value);
            }
        }

        /// <summary>
        /// 坐标轴的Z方向序号
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
        /// 坐标轴的显示单位名
        /// </summary>
        public string UnitName
        {
            get
            {
                return ocx.get_AxisUnitName(this.id, 20);
            }
            set
            {
                ocx.set_AxisUnitName(this.id, 20, value);
            }
        }

        #endregion

    }
}
