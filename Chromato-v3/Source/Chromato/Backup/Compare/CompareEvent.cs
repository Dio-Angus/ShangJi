/*-----------------------------------------------------------------------------
//  FILE NAME       : CompareEvent.cs
//  FUNCTION        : 比较自定义事件
//  AUTHOR          : 李锋(2009/07/28)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.dto;

namespace ChromatoCore.Compare
{


    /// <summary>
    /// 比较样品追加参数类
    /// </summary>
    public class CompareSampleAddArgs : EventArgs
    {
        /// <summary>
        /// 参数
        /// </summary>
        public ParaDto _var { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="m"></param>
        public CompareSampleAddArgs(ParaDto m)
        {
            _var = m;
        }
    }

    /// <summary>
    /// 颜色变更参数类
    /// </summary>
    public class ChangeColorArgs : EventArgs
    {
        /// <summary>
        /// 参数
        /// </summary>
        public CompareDto _var { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="m"></param>
        public ChangeColorArgs(CompareDto m)
        {
            _var = m;
        }
    }

    /// <summary>
    /// 是否显示变更参数类
    /// </summary>
    public class ChangeShowArgs : EventArgs
    {
        /// <summary>
        /// 参数
        /// </summary>
        public CompareDto _var { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="m"></param>
        public ChangeShowArgs(CompareDto m)
        {
            _var = m;
        }
    }

    /// <summary>
    /// 当前选中的样品参数类
    /// </summary>
    public class CurrentSampleArgs : EventArgs
    {
        /// <summary>
        /// 参数
        /// </summary>
        public CompareDto _var { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="m"></param>
        public CurrentSampleArgs(CompareDto m)
        {
            _var = m;
        }
    }
    

}
