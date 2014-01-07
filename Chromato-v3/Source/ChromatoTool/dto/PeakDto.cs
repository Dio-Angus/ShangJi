/*-----------------------------------------------------------------------------
//  FILE NAME       : PeakDto.cs
//  FUNCTION        : 该样品中峰的信息
//  AUTHOR          : 李锋(2009/02/27)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 峰的信息
    /// </summary>
    public class PeakDto
    {
        /// <summary>
        /// 样品ID
        /// </summary>
        public Int32 SampleID { get; set; }

        /// <summary>
        /// 峰ID
        /// </summary>
        public Int32 PeakID { get; set; }
        
        /// <summary>
        /// 开始点Index
        /// </summary>
        public Int32 StartPointIndex { get; set; }

        /// <summary>
        /// 结束点Index
        /// </summary>
        public Int32 EndPointIndex { get; set; }
        
        /// <summary>
        /// 保留时间
        /// </summary>
        public Single ReserveTime { get; set; }

        /// <summary>
        /// 峰最高点Index
        /// </summary>
        public Int32 TopPointIndex { get; set; }

        /// <summary>
        /// 基线斜率
        /// </summary>
        public Single BaseK { get; set; }

        /// <summary>
        /// 基线截距
        /// </summary>
        public Single BaseB { get; set; }

        /// <summary>
        /// 峰组分名
        /// </summary>
        public String PeakName { get; set; }
        
        /// <summary>
        /// 峰面积
        /// </summary>
        public Single AreaSize { get; set; }

        /// <summary>
        /// 峰高
        /// </summary>
        public Single PeakHeight { get; set; }

        /// <summary>
        /// 浓度
        /// </summary>
        public Single Density { get; set; }

        /// <summary>
        /// 峰类型
        /// </summary>
        public String PeakType { get; set; }

        /// <summary>
        /// 组号
        /// </summary>
        public Int32 GroupID { get; set; }

        /// <summary>
        /// 起点是否在曲线下方（否则在曲线上）
        /// </summary>
        public bool IsStartDown { get; set; }

        /// <summary>
        /// 终点是否在曲线下方（否则在曲线上）
        /// </summary>
        public bool IsEndDown { get; set; }

        /// <summary>
        /// 封闭线起始点Y坐标
        /// </summary>
        public Single StartVoltage { get; set; }

        /// <summary>
        /// 封闭线终点Y坐标
        /// </summary>
        public Single EndVoltage { get; set; }

        /// <summary>
        /// 封闭线起始点X坐标
        /// </summary>
        public Single StartMoment { get; set; }

        /// <summary>
        /// 封闭线终点X坐标
        /// </summary>
        public Single EndMoment { get; set; }

        /// <summary>
        /// 封闭线开始点Index
        /// </summary>
        public Int32 StartPointCloseIndex { get; set; }

        /// <summary>
        /// 封闭线结束点Index
        /// </summary>
        public Int32 EndPointCloseIndex { get; set; }

        /// <summary>
        /// 是否进行了手动处理(手动垂直切割，手动基线)
        /// </summary>
        public bool IsManual { get; set; }

        /// <summary>
        /// 状态经历步骤
        /// </summary>
        public String PeakStep { get; set; }

        /// <summary>
        /// 是否进行了手动脱尾
        /// </summary>
        public bool IsManualTail { get; set; }
    }
}
