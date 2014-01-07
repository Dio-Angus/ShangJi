/*-----------------------------------------------------------------------------
//  FILE NAME       : SolutionDto.cs
//  FUNCTION        : 方案表
//  AUTHOR          : 李锋(2009/05/25)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 方案表
    /// </summary>
    public class SolutionDto
    {
        /// <summary>
        /// 方案ID
        /// </summary>
        public Int32 SolutionID { get; set; }
        
        /// <summary>
        /// 方案名
        /// </summary>
        public String SolutionName { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public String RegisterTime { get; set; }

        /// <summary>
        /// 采集方法ID
        /// </summary>
        public Int32 CollectionID { get; set; }

        /// <summary>
        /// 分析方法ID
        /// </summary>
        public Int32 AnalyParaID { get; set; }

        /// <summary>
        /// 反控方法ID
        /// </summary>
        public Int32 AntiMethodID { get; set; }

        /// <summary>
        /// ID表ID
        /// </summary>
        public Int32 IDTableID { get; set; }

        /// <summary>
        /// 时间程序ID
        /// </summary>
        public Int32 TimeProcID { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        /// 是否使用时间程序
        /// </summary>
        public bool IsUseTimeProc { get; set; }
        
    }
}
