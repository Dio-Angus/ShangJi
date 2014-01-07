/*-----------------------------------------------------------------------------
//  FILE NAME       : AnalyParaDto.cs
//  FUNCTION        : 方法表
//  AUTHOR          : 李锋(2009/04/30)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.ini;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 方法表
    /// </summary>
    public class AnalyParaDto
    {

        /// <summary>
        /// 方法ID
        /// </summary>
        public Int32 AnalyParaID { get; set; }

        /// <summary>
        /// 方法名
        /// </summary>
        public String AnalyName { get; set; }

        /// <summary>
        /// 定量方法ID（外标，内标，归一，指数等）
        /// </summary>
        public Arithmatic ArithmaticID { get; set; }

        /// <summary>
        /// 定量参数（面积，高度）
        /// </summary>
        public ArithmaticParameter ArithmaticPara { get; set; }

        /// <summary>
        /// 对准参数（时间窗，时间带）
        /// </summary>
        public AimPara AimPara { get; set; }
        
        /// <summary>
        /// 对准方法（绝对，相对）
        /// </summary>
        public AimWay AimWay { get; set; }

        /// <summary>
        /// 色谱柱型号
        /// </summary>
        public String ColumuModel { get; set; }

        /// <summary>
        /// 描述（用于哪种物质的方法）
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// 峰宽
        /// </summary>
        public Int32 PeakWide { get; set; }

        /// <summary>
        /// 斜率
        /// </summary>
        public Int32 Slope { get; set; }

        /// <summary>
        /// 漂移
        /// </summary>
        public Int32 Drift { get; set; }

        /// <summary>
        /// 最小面积
        /// </summary>
        public Single MinAreaSize { get; set; }

        /// <summary>
        /// 变参时间
        /// </summary>
        public Int32 ParaChangeTime { get; set; }

        /// <summary>
        /// 比例系数
        /// </summary>
        public Single Ratio { get; set; }

        /// <summary>
        /// 时间窗（百分数）
        /// </summary>
        public Int32 TimeWindow { get; set; }

        /// <summary>
        /// 校正方法
        /// </summary>
        public FixCurveWay FixWay { get; set; }

    }
}
