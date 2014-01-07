/*-----------------------------------------------------------------------------
//  FILE NAME       : AntiControlDto.cs
//  FUNCTION        : 反控方法表
//  AUTHOR          : 李锋(2009/07/01)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 反控方法表
    /// </summary>
    public class AntiControlDto
    {
        /// <summary>
        /// 反控方法ID
        /// </summary>
        public Int32 AntiControlID { get; set; }

        /// <summary>
        /// 反控方法名
        /// </summary>
        public String AntiControlName { get; set; }
        
        /// <summary>
        /// 柱箱参数
        /// </summary>
        public ColumnParaDto dtoColumnPara { get; set; }

        /// <summary>
        /// 进样口参数
        /// </summary>
        public InjectDto dtoInject { get; set; }

        /// <summary>
        /// 辅助参数
        /// </summary>
        public AuxDto dtoAux { get; set; }

        /// <summary>
        /// 热导检测器参数
        /// </summary>
        public TcdDto dtoTcd { get; set; }

        /// <summary>
        /// 氢离子检测器参数
        /// </summary>
        public FidDto dtoFid { get; set; }

    }
}
