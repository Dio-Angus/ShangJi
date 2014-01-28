/*-----------------------------------------------------------------------------
//  FILE NAME       : FidDto.cs
//  FUNCTION        : 反控方法->FID
//  AUTHOR          : 李锋(2009/07/01)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 反控方法->FID
    /// </summary>
    public class FidDto
    {
        public bool FID1Used { get; set; }
        public bool FID2Used { get; set; }
        public bool FIDK1Used { get; set; }
        public bool FIDK2Used { get; set; }

        /// <summary>
        /// FID1初温
        /// </summary>
        public Single InitTemp1 { get; set; }
        /// <summary>
        /// FID1报警温度
        /// </summary>
        public Single AlertTemp1 { get; set; }
        /// <summary>
        /// FID1放大倍数
        /// </summary>
        public Int32 MagnifyFactor1 { get; set; }
        /// <summary>
        /// FID1极性
        /// </summary>
        public bool Polarity1 { get; set; }

        /// <summary>
        /// FID2初温
        /// </summary>
        public Single InitTemp2 { get; set; }
        /// <summary>
        /// FID2报警温度
        /// </summary>
        public Single AlertTemp2 { get; set; }
        /// <summary>
        /// FID2放大倍数    
        /// </summary>
        public Int32 MagnifyFactor2 { get; set; }
        /// <summary>
        /// FID2极性
        /// </summary>
        public bool Polarity2 { get; set; }

        /// <summary>
        /// FIDK1初温
        /// </summary>
        public Single InitTempK1 { get; set; }
        /// <summary>
        /// FIDK1报警温度
        /// </summary>
        public Single AlertTempK1 { get; set; }
        /// <summary>
        /// FIDK1放大倍数
        /// </summary>
        public Int32 MagnifyFactorK1 { get; set; }
        /// <summary>
        /// FIDK1极性
        /// </summary>
        public bool PolarityK1 { get; set; }

        /// <summary>
        /// FIDK2初温
        /// </summary>
        public Single InitTempK2 { get; set; }
        /// <summary>
        /// FIDK2报警温度
        /// </summary>
        public Single AlertTempK2 { get; set; }
        /// <summary>
        /// FIDK2放大倍数
        /// </summary>
        public Int32 MagnifyFactorK2 { get; set; }
        /// <summary>
        /// FIDK2极性
        /// </summary>
        public bool PolarityK2 { get; set; }
    }
}
