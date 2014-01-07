/*-----------------------------------------------------------------------------
//  FILE NAME       : SolutionEvent.cs
//  FUNCTION        : 方案自定义事件
//  AUTHOR          : 李锋(2009/06/11)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.dto;
using ChromatoTool.ini;

namespace ChromatoCore.solu
{
    /// <summary>
    /// 方案改变参数类
    /// </summary>
    public class SolutionChangeArgs : EventArgs
    {
        /// <summary>
        /// 参数
        /// </summary>
        public SolutionDto _var { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="m"></param>
        public SolutionChangeArgs(SolutionDto m)
        {
            _var = m;
        }
    }

    /// <summary>
    /// 方案中某项目改变参数类
    /// </summary>
    public class SolutionItemChangeArgs : EventArgs
    {
        /// <summary>
        /// 参数
        /// </summary>
        public SolutionItem _item { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public Int32 _id { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="m"></param>
        /// <param name="id"></param>
        public SolutionItemChangeArgs(SolutionItem m, int id)
        {
            _item = m;
            _id = id;
        }
    }

    /// <summary>
    /// 下部tab页改变参数类
    /// </summary>
    public class PageChangeArgs : EventArgs
    {

        /// <summary>
        /// 参数
        /// </summary>
        public String _tag { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="tag"></param>
        public PageChangeArgs(String tag)
        {
            _tag = tag;
        }
    }

    /// <summary>
    /// 分析方法改变参数类
    /// </summary>
    public class AnalyParaChangeArgs : EventArgs
    {

        /// <summary>
        /// 参数
        /// </summary>
        public AnalyParaDto _dto { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="dto"></param>
        public AnalyParaChangeArgs(AnalyParaDto dto)
        {
            _dto = dto;
        }
    }
}
