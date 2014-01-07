/*-----------------------------------------------------------------------------
//  FILE NAME       : SolutionExportDto.cs
//  FUNCTION        : 方案导出的存储单元
//  AUTHOR          : 李锋(2010/06/03)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


namespace ChromatoTool.dto
{
    /// <summary>
    /// 方案导出的存储单元
    /// </summary>
    public class SolutionExportDto
    {

        #region 变量

        /// <summary>
        /// 分析方法
        /// </summary>
        public AnalyParaDto _dtoAnalyPara { get; set; }

        /// <summary>
        /// 时间程序 TimeProcDto 集合体
        /// </summary>
        public ArrayList _timeProc { get; set; }

        /// <summary>
        /// 是否使用时间程序
        /// </summary>
        public bool _isUseTp = false;

        /// <summary>
        /// 样品量
        /// </summary>
        public Int32 SampleWeight { get; set; }

        /// <summary>
        /// 内标量
        /// </summary>
        public Int32 InnerWeight { get; set; }

        /// <summary>
        /// ID表 IngredientDto 集合体
        /// </summary>
        public ArrayList _arrIngre { get; set; }

        /// <summary>
        /// 含量表 CalibrateDto 集合体(根据IngredientDto.IngredientID嵌套)
        /// </summary>
        public ArrayList _arrCali { get; set; }

        #endregion

    }
}
