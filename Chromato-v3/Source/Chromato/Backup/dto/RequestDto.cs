/*-----------------------------------------------------------------------------
//  FILE NAME       : RequestDto.cs
//  FUNCTION        : 申请表
//  AUTHOR          : 李锋(2010/11/29)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;
using ChromatoTool.ini;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 申请表
    /// </summary>
    public class RequestDto
    {

        /// <summary>
        /// 申请样品名
        /// </summary>
        public String regSampleName { get; set; }

        /// <summary>
        /// 真实样品ID (通道A_YYYYMMDDhhmmss)
        /// </summary>
        public String SampleID { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public String RegisterTime { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public PutStatus Status { get; set; }
    }
}
