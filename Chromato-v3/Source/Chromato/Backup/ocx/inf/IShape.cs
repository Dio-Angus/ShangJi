/*-----------------------------------------------------------------------------
//  FILE NAME       : IShape.cs
//  FUNCTION        : IShapeのインタフェイス
//  AUTHOR          : 李锋(2009/03//03)
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
    /// 矩形接口
    /// </summary>
    interface IShape
    {
        Int32 X { get; set; }
        Int32 Y { get; set; }
        Int32 Height { get; set; }
        Int32 Width { get; set; }
        bool Show { get; set; }
        bool Transparent { get; set; }
        Int32 FillPattern { get; set; }
        Int32 FillColor { get; set; }
        Int32 BorderColor { get; set; }
        Int32 AdjustX { get; set; }
        Int32 AdjustY { get; set; }
        short ZorderOcx { get; set; }


    }
}
