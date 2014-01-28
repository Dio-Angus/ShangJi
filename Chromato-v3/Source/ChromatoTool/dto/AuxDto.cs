/*-----------------------------------------------------------------------------
//  FILE NAME       : AuxDto.cs
//  FUNCTION        : 反控方法->AUX
//  AUTHOR          : 李锋(2009/07/01)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 反控方法->AUX
    /// </summary>
    public class AuxDto
    {
        public int UserIndex { get; set; }

        public Single InitTempAux1 { get; set; }
        public Single AlertTempAux1 { get; set; }

        public Single InitTempAux2 { get; set; }
        public Single AlertTempAux2 { get; set; }
    }
}
