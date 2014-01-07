/*-----------------------------------------------------------------------------
//  FILE NAME       : ParaDto.cs
//  FUNCTION        : 样品的信息表
//  AUTHOR          : 李锋(2009/04/16)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.ini;


namespace ChromatoTool.dto
{
    /// <summary>
    /// 谱图的信息表
    /// </summary>
    public class ParaDto
    {
        /// <summary>
        /// 样品ID
        /// </summary>
        public String SampleID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public String UserID { get; set; }

        /// <summary>
        /// 样品名
        /// </summary>
        public String SampleName { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public String RegisterTime { get; set; }

        /// <summary>
        /// 采样类型（标样，待测）
        /// </summary>
        public TypeSample SampleType { get; set; }
        
        /// <summary>
        /// 停止时间
        /// </summary>
        public Int32 StopTime { get; set; }

        /// <summary>
        /// 样品量
        /// </summary>
        public Int32 SampleWeight { get; set; }

        /// <summary>
        /// 内标量
        /// </summary>
        public Int32 InnerWeight { get; set; }

        /// <summary>
        /// 采集时间
        /// </summary>
        public String CollectTime { get; set; }

        /// <summary>
        /// 数据路径
        /// </summary>
        public String PathData { get; set; }

        /// <summary>
        /// 采样通道号(Tcd1,Tcd2,Fid1,Fid2)
        /// </summary>
        public String ChannelID { get; set; }

        /// <summary>
        /// 样品状态(已注册,已采集,已分析)
        /// </summary>
        public String SampleStatus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Remark { get; set; }
        
    }
}
