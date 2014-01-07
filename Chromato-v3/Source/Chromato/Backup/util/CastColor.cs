/*-----------------------------------------------------------------------------
//  FILE NAME       : CastColor.cs
//  FUNCTION        : .NET和C++的颜色转换工具
//  AUTHOR          : XCAST 蔡海鹰(2009/03/11)
//  CHANGE LOG      :
//  FLAG               DATE        WHO      DESCRIPTION
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;

namespace ChromatoTool.util
{
    /// <summary>
    /// .NET和C++的颜色转换
    /// </summary>
    public class CastColor
    {
        /// <summary>
        /// Color转COLOREF
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static int GetCustomColor(Color color) 
        {            

             int nColor = color.ToArgb();            
             int blue = nColor & 255;             
             int green = nColor >> 8 & 255;            
             int red = nColor >> 16 & 255;   
          
             return Convert.ToInt32(blue << 16 | green << 8 | red);         
        }

        /// <summary>
        ///  COLOREF转Color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color GetArgbColor(int color)        
        {            
            int red = color & 255;
            int green = color >> 8 & 255;
            int blue = color >> 16 & 255;

            return Color.FromArgb(red, green, blue);        
         }  


    }
}
