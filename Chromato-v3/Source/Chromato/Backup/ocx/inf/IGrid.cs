/*-----------------------------------------------------------------------------
//  FILE NAME       : IGrid.cs
//  FUNCTION        : IGridのインタフェイス
//  AUTHOR          : 李锋(2009/03//02)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;

namespace ChromatoBll.ocx.inf
{
    /// <summary>
    /// 网格接口
    /// </summary>
    interface IGrid
    {
        Int32 Left { get; set; }
        Int32 Right { get; set; }
        Int32 Top { get; set; }
        Int32 Bottom { get; set; }
        Int32 OutLineStyle { get; set; }
        Int32 OutLineWidth { get; set; }
        Int32 OutLineColor { get; set; }
        Int32 InLineStyle { get; set; }
        Int32 InLineWidth { get; set; }
        Int32 InLineColor { get; set; }
        Int32 BrushColor { get; set; }
        Int32 HorzCount { get; set; }
        Int32 VertCount { get; set; }
        bool Show { get; set; }
        bool TransParent { get; set; }
        bool InLineShow { get; set; }
        short ZorderOcx { get; set; }
        

    }
}
