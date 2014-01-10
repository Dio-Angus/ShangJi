/*-----------------------------------------------------------------------------
//  FILE NAME       : ColumnParaDto.cs
//  FUNCTION        : 反控方法->柱箱表
//  AUTHOR          : 李锋(2009/07/01)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 反控方法->柱箱表
    /// </summary>
    public class HeatingSourceDto
    {
        /// <summary>
        /// 平衡时间
        /// </summary>
        public Single BalanceTime { get; set; }
        /// <summary>
        /// 初温
        /// </summary>
        public Single InitTemp { get; set; }
        /// <summary>
        /// 维持时间
        /// </summary>
        public Single MaintainTime { get; set; }
        /// <summary>
        /// 报警温度
        /// </summary>
        public Single AlertTemp { get; set; }
        /// <summary>
        /// 柱箱恒升阶数
        /// </summary>
        public Single ColumnCount { get; set; }

        /// <summary>
        /// 1阶速率
        /// </summary>
        public Single RateCol1 { get; set; }
        /// <summary>
        /// 1阶温度
        /// </summary>
        public Single TempCol1 { get; set; }
        /// <summary>
        /// 1阶恒温时间
        /// </summary>
        public Single TempTimeCol1 { get; set; }

        /// <summary>
        /// 2阶速率
        /// </summary>
        public Single RateCol2 { get; set; }
        /// <summary>
        /// 2阶温度
        /// </summary>
        public Single TempCol2 { get; set; }
        /// <summary>
        /// 2阶恒温时间
        /// </summary>
        public Single TempTimeCol2 { get; set; }

        /// <summary>
        /// 3阶速率
        /// </summary>
        public Single RateCol3 { get; set; }
        /// <summary>
        /// 3阶温度
        /// </summary>
        public Single TempCol3 { get; set; }
        /// <summary>
        /// 3阶恒温时间
        /// </summary>
        public Single TempTimeCol3 { get; set; }

        /// <summary>
        /// 4阶速率
        /// </summary>
        public Single RateCol4 { get; set; }
        /// <summary>
        /// 4阶温度
        /// </summary>
        public Single TempCol4 { get; set; }
        /// <summary>
        /// 4阶恒温时间
        /// </summary>
        public Single TempTimeCol4 { get; set; }

        /// <summary>
        /// 5阶速率
        /// </summary>
        public Single RateCol5 { get; set; }
        /// <summary>
        /// 5阶温度
        /// </summary>
        public Single TempCol5 { get; set; }
        /// <summary>
        /// 5阶恒温时间
        /// </summary>
        public Single TempTimeCol5 { get; set; }

    }
}
