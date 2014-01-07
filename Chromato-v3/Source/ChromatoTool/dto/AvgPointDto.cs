/*-----------------------------------------------------------------------------
//  FILE NAME       : AvgPointDto.cs
//  FUNCTION        : 平均点表
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
    /// 平均点表
    /// </summary>
    public class AvgPointDto
    {

        /// <summary>
        /// 电压值
        /// </summary>
        public Single Voltage { get; set; }

        /// <summary>
        /// 时刻(相对于0)
        /// </summary>
        public Single Moment { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public Int32 Index { get; set; }

        /// <summary>
        /// 峰宽
        /// </summary>
        public Int32 PeakWide { get; set; }

        /// <summary>
        /// 斜率
        /// </summary>
        public float Slope { get; set; }

        /// <summary>
        /// 设定斜率参数
        /// </summary>
        public float SettingSlope { get; set; }

        /// <summary>
        /// 漂移
        /// </summary>
        public Int32 Drift { get; set; }

        /// <summary>
        /// 数据点属性
        /// </summary>
        public PointAttribute PointType { get; set; }

        /// <summary>
        /// 符合设定斜率的程度
        /// </summary>
        public PointAttribute UorD { get; set; }

        /// <summary>
        /// 最小面积
        /// </summary>
        public float minArea { get; set; }

        /// <summary>
        /// 变参时间
        /// </summary>
        public Int32 ParaChangeTime { get; set; }

        /// <summary>
        /// 无需峰削除(锁定时间)
        /// </summary>
        public bool isTimeLock { get; set; }

        /// <summary>
        /// 基线锁定
        /// </summary>
        public bool isBaselineLock { get; set; }

        /// <summary>
        /// 负峰翻转
        /// </summary>
        public bool isRevertNegative { get; set; }

        /// <summary>
        /// 水平基线
        /// </summary>
        public bool isHoriBaseline { get; set; }

        /// <summary>
        /// 拖尾峰处理
        /// </summary>
        public bool isTailProcess { get; set; }

        /// <summary>
        /// 每点的状态
        /// </summary>
        public PointStatus StatusPoint { get; set; }

        /// <summary>
        /// 平均斜率
        /// </summary>
        public AverageSlopeStatus StatusAvgSlope { get; set; }

        /// <summary>
        /// 峰的趋势
        /// </summary>
        public PeakTrend TrendPeak { get; set; }

    }
}
