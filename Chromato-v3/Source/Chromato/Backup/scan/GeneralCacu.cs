/*-----------------------------------------------------------------------------
//  FILE NAME       : GeneralCacu.cs
//  FUNCTION        : 通用计算工具
//  AUTHOR          : XCAST 蔡海鹰(2009/09/22)
//  CHANGE LOG      :
//  FLAG               DATE        WHO      DESCRIPTION
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.ini;
using ChromatoTool.dto;

namespace ChromatoPeak.scan
{
    /// <summary>
    /// 通用计算工具
    /// </summary>
    public class GeneralCacu
    {
        /// <summary>
        /// 计算两点斜率 (微伏/分钟)
        /// </summary>
        /// <param name="dto1">前点</param>
        /// <param name="dto2">后点</param>
        /// <returns>斜率值</returns>
        public static float GetSlope(AvgPointDto dto1, AvgPointDto dto2)
        {
            Single slope = (dto2.Voltage - dto1.Voltage) * DefaultItem.uVol / (dto2.Moment - dto1.Moment);
            return slope;
        }

    }
}
