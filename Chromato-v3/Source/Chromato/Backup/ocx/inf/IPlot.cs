/*-----------------------------------------------------------------------------
//  FILE NAME       : IPlot.cs
//  FUNCTION        : IPlotのインタフェイス
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
    /// 图形接口
    /// </summary>
    interface IPlot
    {

        Int32 Area { get; set; }
        bool Show { get; set; }
        bool ShowMarker { get; set; }
        Int32 DataCount { get; set; }
        double StartXValue { get; set; }
        double EndXValue { get; set; }
        double StartYValue { get; set; }
        double EndYValue { get; set; }
        Int32 DatalineStyle { get; set; }
        Int32 DatalineColor { get; set; }
        bool MarkerTransparent { get; set; }
        Int32 MarkerStyle { get; set; }
        Int32 MarkerSize { get; set; }
        Int32 MarkerBordercolor { get; set; }
        Int32 MarkerBorderwidth { get; set; }
        Int32 MarkerFillColor { get; set; }
        Int32 Left { get; set; }
        Int32 Right { get; set; }
        Int32 Top { get; set; }
        Int32 Bottom { get; set; }
        double LeftValue { get; set; }
        double RightValue { get; set; }
        double TopValue { get; set; }
        double BottomValue { get; set; }
        bool Clip { get; set; }
        bool UseDashline { get; set; }
        Int32 DatalineWidth { get; set; }
        short ZorderOcx { get; set; }

        bool GetMarkerState(Int32 nMarkerId);
        void SetMarkerState(Int32 nMarkerId, bool value);


    }
}
