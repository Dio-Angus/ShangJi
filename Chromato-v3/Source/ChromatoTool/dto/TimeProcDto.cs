/*-----------------------------------------------------------------------------
//  FILE NAME       : TimeProcDto.cs
//  FUNCTION        : 时间程序表
//  AUTHOR          : 李锋(2009/05/06)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 时间程序表
    /// </summary>
    public class TimeProcDto
    {
        /// <summary>
        /// 时间程序ID
        /// </summary>
        public Int32 TPid { get; set; }

        /// <summary>
        /// 时间程序名
        /// </summary>
        public String TPName { get; set; }

        /// <summary>
        /// 动作ID
        /// </summary>
        public Int32 SerialID { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public String ActionName { get; set; }

        /// <summary>
        /// 起始时间 分
        /// </summary>
        public Single StartTime { get; set; }

        /// <summary>
        /// 结束时间 分
        /// </summary>
        public Single StopTime { get; set; }

        /// <summary>
        /// 是否是命令值
        /// </summary>
        public bool IsCmd { get; set; }

        /// <summary>
        /// 命令值
        /// </summary>
        public Int32 TpValue { get; set; }
        
    }
}
