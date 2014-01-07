/*-----------------------------------------------------------------------------
//  FILE NAME       : ILine.cs
//  FUNCTION        : ILineのインタフェイス
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
    /// 直线接口
    /// </summary>
    interface ILine
    {
        /// <summary>
        /// 开始点X方向像素坐标
        /// </summary>
        Int32 StartX { get; set; }
        Int32 StartY { get; set; }
        Int32 EndX { get; set; }
        Int32 EndY { get; set; }
        Int32 Style { get; set; }
        Int32 Width { get; set; }
        Int32 Color { get; set; }
        bool Show { get; set; }
        short ZorderOcx { get; set; }


    }
}
