/*-----------------------------------------------------------------------------
//  FILE NAME       : IArea.cs
//  FUNCTION        : IAreaのインタフェイス
//  AUTHOR          : 李锋(2009/03//01)
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
    /// 区域接口
    /// </summary>
    interface IArea
    {
        Int32 Left { get; set; }
        Int32 Right { get; set; }
        Int32 Top { get; set; }
        Int32 Bottom { get; set; }
        Int32 ColorBrush { get; set; }
        Int32 XAxis { get; set; }
        Int32 YAxis { get; set; }
        double LeftValue { get; set; }
        double RightValue { get; set; }
        double TopValue { get; set; }
        double BottomValue { get; set; }
        bool Show { get; set; }
        bool Clip { get; set; }
        short ZorderOcx { get; set; }


    }
}
