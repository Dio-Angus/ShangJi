/*-----------------------------------------------------------------------------
//  FILE NAME       : CalibrateDto.cs
//  FUNCTION        : 含量表
//  AUTHOR          : 李锋(2009/04/30)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 含量表
    /// </summary>
    public class CalibrateDto
    {

        /// <summary>
        /// ID表ID
        /// </summary>
        public Int32 IDTableID { get; set; }

        /// <summary>
        /// 成分ID
        /// </summary>
        public Int32 IngredientID { get; set; }

        /// <summary>
        /// 含量ID
        /// </summary>
        public Int32 CalibrateID { get; set; }

        /// <summary>
        /// 样品ID
        /// </summary>
        public String SampleID { get; set; }

        /// <summary>
        /// 峰面积
        /// </summary>
        public Single PeakSize { get; set; }

        /// <summary>
        /// 峰高
        /// </summary>
        public Single PeakHeight { get; set; }

        /// <summary>
        /// 标样浓度
        /// </summary>
        public Single Density { get; set; }

        /// <summary>
        /// 响应因子F1
        /// </summary>
        public Single FactorOne { get; set; }

        /// <summary>
        /// 响应因子F2
        /// </summary>
        public Single FactorTwo { get; set; }

        /// <summary>
        /// 标样浓度中间变量
        /// </summary>
        public Single DensityTemp { get; set; }

        /// <summary>
        /// 峰面积/高度中间变量
        /// </summary>
        public Single SizeHeight { get; set; }

        /// <summary>
        /// 样品量
        /// </summary>
        public Int32 SampleWeight { get; set; }
    }
}
