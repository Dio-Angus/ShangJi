/*-----------------------------------------------------------------------------
//  FILE NAME       : IngredientDto.cs
//  FUNCTION        : 成分表
//  AUTHOR          : 李锋(2009/04/30)
//  CHANGE LOG      : 增加了是否匹配过的标志,供计算峰的浓度使用(2010/05/06)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;


namespace ChromatoTool.dto
{
    /// <summary>
    /// 成分表
    /// </summary>
    public class IngredientDto
    {
        /// <summary>
        /// ID表ID
        /// </summary>
        public Int32 IDTableID { get; set; }

        /// <summary>
        /// ID表名
        /// </summary>
        public String IDTableName { get; set; }

        /// <summary>
        /// 成分ID
        /// </summary>
        public Int32 IngredientID { get; set; }

        /// <summary>
        /// 保留时间
        /// </summary>
        public Single ReserveTime { get; set; }

        /// <summary>
        /// 组分名
        /// </summary>
        public String IngredientName { get; set; }

        /// <summary>
        /// 时间带(分钟)
        /// </summary>
        public Single TimeBand { get; set; }

        /// <summary>
        /// 是否内标峰
        /// </summary>
        public bool IsInnerPeak { get; set; }

        /// <summary>
        /// 是否匹配过(2010/05/06)
        /// </summary>
        public bool IsMatch { get; set; }
    }
}
