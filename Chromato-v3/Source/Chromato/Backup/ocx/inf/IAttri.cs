/*-----------------------------------------------------------------------------
//  FILE NAME       : IAttri.cs
//  FUNCTION        : IAttriのインタフェイス
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
    /// 属性接口
    /// </summary>
    interface IAttri
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
        String FontName { get; set; }
        bool Show { get; set; }
        Int32 Right { get; set; }
        Int32 Bottom { get; set; }
        bool Transparent { get; set; }

        void SetLabelColor(short id, Int32 color);
        Int32 GetLabelColor(short id);

        void SetName(short nID, String name);
        String GetName(short nID);
       

        
    }
}
