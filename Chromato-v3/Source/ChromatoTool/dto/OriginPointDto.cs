/*-----------------------------------------------------------------------------
//  FILE NAME       : OriginPointDto.cs
//  FUNCTION        : 原始点的信息
//  AUTHOR          : 李锋(2009/02/27)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 点的信息
    /// </summary>
    public class OriginPointDto
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
        public Int32 AvgPeakWide { get; set; }

        /// <summary>
        /// 设定斜率
        /// </summary>
        public Int32 SettingSlope { get; set; }
    }
}
