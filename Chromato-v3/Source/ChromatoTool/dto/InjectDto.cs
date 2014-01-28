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
        /// <summary>
        /// INJ1初温
        /// </summary>
        public Single InitTemp1 { get; set; }
        /// <summary>
        /// INJ1报警温度
        /// </summary>
        public Single AlertTemp1 { get; set; }
        /// <summary>
        /// INJ1柱类型
        /// </summary>
        public Int32 ColumnType1 { get; set; }
        /// <summary>
        /// INJ1进样时间
        /// </summary>
        public Int32 InjectTime1 { get; set; }
        /// <summary>
        /// INJ1进样模式
        /// </summary>
        public Int32 InjectMode1 { get; set; }

        /// <summary>
        /// INJ2初温
        /// </summary>
        public Single InitTemp2 { get; set; }
        /// <summary>
        /// INJ2报警温度
        /// </summary>
        public Single AlertTemp2 { get; set; }
        /// <summary>
        /// INJ2柱类型
        /// </summary>
        public Int32 ColumnType2 { get; set; }
        /// <summary>
        /// INJ2进样时间
        /// </summary>
        public Int32 InjectTime2 { get; set; }
        /// <summary>
        /// INJ2进样模式
        /// </summary>
        public Int32 InjectMode2 { get; set; }

        /// <summary>
        /// INJ3初温
        /// </summary>
        public Single InitTemp3 { get; set; }
        /// <summary>
        /// INJ3报警温度
        /// </summary>
        public Single AlertTemp3 { get; set; }
        /// <summary>
        /// INJ3柱类型
        /// </summary>
        public Int32 ColumnType3 { get; set; }
        /// <summary>
        /// INJ3进样时间
        /// </summary>
        public Int32 InjectTime3 { get; set; }
        /// <summary>
        /// INJ3进样模式
        /// </summary>
        public Int32 InjectMode3 { get; set; }
    }
}
