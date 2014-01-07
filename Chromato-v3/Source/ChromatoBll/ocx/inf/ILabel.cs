/*-----------------------------------------------------------------------------
//  FILE NAME       : ILabel.cs
//  FUNCTION        : ILabelのインタフェイス
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
    /// 标签接口
    /// </summary>
    interface ILabel
    {
        Int32 X { get; set; }
        Int32 Y { get; set; }
        Int32 ForeColor { get; set; }
        Int32 BackColor { get; set; }
        Int32 FontSize { get; set; }
        bool FontUnderline { get; set; }
        bool FontBold { get; set; }
        bool FontItalic { get; set; }
        Int32 Direction { get; set; }
        Int32 Align { get; set; }
        bool Show { get; set; }
        String FontName { get; set; }
        String Text { get; set; }
        short ZorderOcx { get; set; }



    }
}
