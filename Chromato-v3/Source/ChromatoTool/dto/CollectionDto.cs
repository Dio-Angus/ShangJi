/*-----------------------------------------------------------------------------
//  FILE NAME       : CollectionDto.cs
//  FUNCTION        : 采集方法表
//  AUTHOR          : 李锋(2009/06/11)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.dto
{

    /// <summary>
    /// 采集方法表
    /// </summary>
    public class CollectionDto
    {
        /// <summary>
        /// 采集方法ID
        /// </summary>
        public Int32 CollectionID { get; set; }

        /// <summary>
        /// 采集方法名
        /// </summary>
        public String CollectionName { get; set; }

        /// <summary>
        /// 峰宽
        /// </summary>
        public Int32 PeakWide { get; set; }

        /// <summary>
        /// 斜率
        /// </summary>
        public Int32 Slope { get; set; }

        /// <summary>
        /// 停止时间
        /// </summary>
        public Int32 StopTime { get; set; }

        /// <summary>
        /// Y最大值
        /// </summary>
        public Single ShowMaxY { get; set; }

        /// <summary>
        /// Y最小值
        /// </summary>
        public Single ShowMinY { get; set; }

        /// <summary>
        /// 满屏时间
        /// </summary>
        public Int32 FullScreenTime { get; set; }

        /// <summary>
        /// 是否自动斜率
        /// </summary>
        public bool AutoSlope { get; set; }

        /// <summary>
        /// 曲线颜色
        /// </summary>
        public Int32 ForeColor { get; set; }

        /// <summary>
        /// 背景色
        /// </summary>
        public Int32 BackColor { get; set; }
    }
}
