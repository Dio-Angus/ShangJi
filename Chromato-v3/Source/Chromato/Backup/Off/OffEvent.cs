/*-----------------------------------------------------------------------------
//  FILE NAME       : OffEvent.cs
//  FUNCTION        : 分析自定义事件
//  AUTHOR          : 李锋(2009/06/01)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.dto;
using System.Collections;
using System.Data;

namespace ChromatoCore.Off
{

    /// <summary>
    /// 在线样品改变参数类
    /// </summary>
    public class OffSampleChangeArgs : EventArgs
    {
        /// <summary>
        /// 参数
        /// </summary>
        public ParaDto _var { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="m"></param>
        public OffSampleChangeArgs(ParaDto m)
        {
            _var = m;
        }
    }

    /// <summary>
    /// 分析按钮按下的代理
    /// </summary>
    public delegate void AnalysisDelegate();

    /// <summary>
    /// 峰删除刷新参数类
    /// </summary>
    public class OffPeakDeleteArgs : EventArgs
    {
        /// <summary>
        /// 参数
        /// </summary>
        public Int32 _peakId { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="m"></param>
        public OffPeakDeleteArgs(Int32 m)
        {
            _peakId = m;
        }
    }

    /// <summary>
    /// 手动基线刷新参数类
    /// </summary>
    public class ManualBaselineArgs : EventArgs
    {
        /// <summary>
        /// 参数
        /// </summary>
        public ArrayList _arr { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public PeakDto _newPeak { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="dto"></param>
        public ManualBaselineArgs(ArrayList arr, PeakDto dto)
        {
            _arr = arr;
            _newPeak = dto;
        }
    }

    /// <summary>
    /// 峰分割刷新参数类
    /// </summary>
    public class OffPeakSplitArgs : EventArgs
    {
        /// <summary>
        /// 构造
        /// </summary>
        public OffPeakSplitArgs()
        {
        }
    }

    /// <summary>
    /// 导出按钮按下的代理
    /// </summary>
    public delegate void ExportToFileDelegate();

    /// <summary>
    /// 峰的类型改变参数类
    /// </summary>
    public class OffPeakTypeChangedArgs : EventArgs
    {
        /// <summary>
        /// 参数
        /// </summary>
        public Int32 _peakId { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="m"></param>
        public OffPeakTypeChangedArgs(Int32 m)
        {
            _peakId = m;
        }
    }


    /// <summary>
    /// 汇总画面关闭按钮按下的代理
    /// </summary>
    public delegate void CloseBtnClickDelegate();

    /// <summary>
    /// 峰的类型改变参数类
    /// </summary>
    public class OffSumBtnClickArgs : EventArgs
    {
        /// <summary>
        /// 参数
        /// </summary>
        public DataTable _dtResult { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public ArrayList _arr { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="m"></param>
        public OffSumBtnClickArgs(ArrayList arr, DataTable m)
        {
            _arr = arr;
            _dtResult = m;
        }
    }


    /// <summary>
    /// 样品自动分析改变参数类
    /// </summary>
    public class OnSampleAutoAnalysisArgs : EventArgs
    {

        /// <summary>
        /// 样品信息
        /// </summary>
        public ParaDto _dtoPara { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        /// <param name="dto"></param>
        public OnSampleAutoAnalysisArgs(ParaDto dto)
        {
            _dtoPara = dto;
        }
    }
}
