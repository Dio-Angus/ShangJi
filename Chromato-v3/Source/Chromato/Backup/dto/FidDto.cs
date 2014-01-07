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
        public Single InitTemp { get; set; }
        public Single AlertTemp { get; set; }
        public Int32 MagnifyFactorOne { get; set; }
        public bool PolarityOne { get; set; }

        public Int32 MagnifyFactorTwo { get; set; }
        public bool PolarityTwo { get; set; }

    }
}
