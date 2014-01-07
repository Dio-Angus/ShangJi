/*-----------------------------------------------------------------------------
//  FILE NAME       : RelationDto.cs
//  FUNCTION        : 索引关系表
//  AUTHOR          : 李锋(2009/05/06)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 索引关系
    /// </summary>
    public class RelationDto
    {
        /// <summary>
        /// 样品ID
        /// </summary>
        public String SampleID { get; set; }

        /// <summary>
        /// 方案ID
        /// </summary>
        public Int32 SolutionID { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public String RegisterTime { get; set; }
    }
}
