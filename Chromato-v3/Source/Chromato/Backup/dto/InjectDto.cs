/*-----------------------------------------------------------------------------
//  FILE NAME       : InjectDto.cs
//  FUNCTION        : 反控方法->进样口表
//  AUTHOR          : 李锋(2009/07/01)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.ini;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 反控方法->进样口表
    /// </summary>
    public class InjectDto
    {
        public Single InitTemp { get; set; }
        public Single AlertTemp { get; set; }

        public TypeColumn ColumnType1 { get; set; }
        public Int32 InjectTime1 { get; set; }
        public ModeInject InjectMode1 { get; set; }

        public TypeColumn ColumnType2 { get; set; }
        public Int32 InjectTime2 { get; set; }
        public ModeInject InjectMode2 { get; set; }

        public TypeColumn ColumnType3 { get; set; }
        public Int32 InjectTime3 { get; set; }
        public ModeInject InjectMode3 { get; set; }
    }
}
