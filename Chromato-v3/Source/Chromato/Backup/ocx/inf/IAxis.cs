/*-----------------------------------------------------------------------------
//  FILE NAME       : IAxis.cs
//  FUNCTION        : IAxisのインタフェイス
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
    /// 坐标轴接口
    /// </summary>
    interface IAxis
    {

        Int32 LineColor { get; set; }
        Int32 LineStyle { get; set; }
        Int32 LineWidth { get; set; }
        Int32 Align { get; set; }
        bool Show { get; set; }
        Int32 Direction { get; set; }
        double StartValue { get; set; }
        double EndValue { get; set; }
        Int32 FloatFigure { get; set; }
        Int32 X { get; set; }
        Int32 Y { get; set; }
        Int32 Length { get; set; }
        Int32 OffsetX { get; set; }
        Int32 OffsetY { get; set; }
        Int32 ScaleCount { get; set; }
        Int32 ScaleLineColor { get; set; }
        Int32 ScaleLineStyle { get; set; }
        Int32 ScaleLineWidth { get; set; }
        Int32 ValueColor { get; set; }
        bool LabelFontBold { get; set; }
        bool LabelFontItalic { get; set; }
        String LabelFontName { get; set; }
        Int32 LabelFontSize { get; set; }
        bool LabelFontUnderline { get; set; }
        short ZorderOcx { get; set; }
        String UnitName { get; set; }
        
    }
}
