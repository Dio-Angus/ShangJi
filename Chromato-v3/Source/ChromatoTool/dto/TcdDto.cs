/*-----------------------------------------------------------------------------
//  FILE NAME       : TcdDto.cs
//  FUNCTION        : 反控方法->TCD
//  AUTHOR          : 李锋(2009/07/01)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 反控方法->TCD
    /// </summary>
    public class TcdDto
    {
        public int TcdIndex { get; set; }//0=同时，1=Tcd1，2=Tcd2

        public Single InitTemp1 { get; set; }
        public Single AlertTemp1 { get; set; }

        public Single InitTemp2 { get; set; }
        public Single AlertTemp2 { get; set; }

        public Single CurrentOne { get; set; }//电流  
        public bool PolarityOne { get; set; }//极性
        public Single AlertOne { get; set; }
        public bool OnOffOne { get; set; }

        public Single CurrentTwo { get; set; }
        public bool PolarityTwo { get; set; }
        public Single AlertTwo { get; set; }
        public bool OnOffTwo { get; set; }
    }
}
