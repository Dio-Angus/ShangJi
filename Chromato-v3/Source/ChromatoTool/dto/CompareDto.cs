/*-----------------------------------------------------------------------------
//  FILE NAME       : CompareDto.cs
//  FUNCTION        : 比较表
//  AUTHOR          : 李锋(2009/07/28)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 比较表
    /// </summary>
    public class CompareDto
    {
        /// <summary>
        /// 样品ID
        /// </summary>
        public String SampleID { get; set; }

        /// <summary>
        /// 前景色(Color.ToArgb)
        /// </summary>
        public Int32 ForeColor { get; set; }

        /// <summary>
        /// 样品名
        /// </summary>
        public String SampleName { get; set; }

        /// <summary>
        /// 数据路径
        /// </summary>
        public String PathData { get; set; }

        /// <summary>
        /// 控件id
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { get; set; }

        /// <summary>
        /// 采集时间
        /// </summary>
        public String CollectTime { get; set; }
    }
}
