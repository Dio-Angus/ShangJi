/*-----------------------------------------------------------------------------
//  FILE NAME       : IOcxItem.cs
//  FUNCTION        : IOcxItemのインタフェイス
//  AUTHOR          : 李锋(2009/03//01)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;
using AxGRAPHOCXLib;
using ChromatoTool.dto;

namespace ChromatoBll.ocx.inf
{
    /// <summary>
    /// 2D控件对象和子对象id
    /// </summary>
    interface IOcxItem
    {
        /// <summary>
        /// 图形控件对象
        /// </summary>
        AxGraphOcx ocx { get; set; }
        /// <summary>
        /// 自控件ID
        /// </summary>
        short id { get; set; }

    }
}
