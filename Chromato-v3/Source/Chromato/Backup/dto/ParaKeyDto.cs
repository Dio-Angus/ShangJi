/*-----------------------------------------------------------------------------
//  FILE NAME       : ParaKeyDto.cs
//  FUNCTION        : 样品的信息主键列表
//  AUTHOR          : 李锋(2009/10/30)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 样品的信息主键列表
    /// </summary>
    public class ParaKeyDto
    {
        /// <summary>
        /// 样品ID
        /// </summary>
        public String SampleID { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public String RegisterTime { get; set; }

    }
}
