/*-----------------------------------------------------------------------------
//  FILE NAME       : YieldingPointDto.cs
//  FUNCTION        : 拐点的信息
//  AUTHOR          : 李锋(2009/08/20)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.ini;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 拐点的信息
    /// </summary>
    public class YieldingPointDto
    {
        /// <summary>
        /// 拐点状态
        /// </summary>
        public YieldingAttri AttriYielding { get; set; }

        /// <summary>
        /// 拐点在arrAvg中的索引
        /// </summary>
        public Int32 Index { get; set; }


    }
}
