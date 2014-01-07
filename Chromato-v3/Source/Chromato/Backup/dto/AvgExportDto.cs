/*-----------------------------------------------------------------------------
//  FILE NAME       : AvgExportDto.cs
//  FUNCTION        : 平均点导出数据单元
//  AUTHOR          : 李锋(2009/09/11)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 平均点导出数据单元
    /// </summary>
    public class AvgExportDto
    {
        /// <summary>
        /// 电压值
        /// </summary>
        public Single Voltage { get; set; }

        /// <summary>
        /// 时刻(相对于0)
        /// </summary>
        public Single Moment { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public Int32 Index { get; set; }

        /// <summary>
        /// 峰宽
        /// </summary>
        public Int32 PeakWide { get; set; }

        /// <summary>
        /// 设定斜率参数
        /// </summary>
        public float SettingSlope { get; set; }

        /// <summary>
        /// 漂移
        /// </summary>
        public Int32 Drift { get; set; }

        /// <summary>
        /// 斜率
        /// </summary>
        public float Slope { get; set; }

        /// <summary>
        /// 每点的状态
        /// </summary>
        public String StatusPoint { get; set; }


        /// <summary>
        /// 平均斜率
        /// </summary>
        public String StatusAvgSlope { get; set; }

        /// <summary>
        /// 峰的趋势
        /// </summary>
        public String TrendPeak { get; set; }



    }
}
