/*-----------------------------------------------------------------------------
//  FILE NAME       : CastCursor.cs
//  FUNCTION        : 光标工具
//  AUTHOR          : XCAST 蔡海鹰(2009/06/04)
//  CHANGE LOG      :
//  FLAG               DATE        WHO      DESCRIPTION
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


using System;
using System.Windows.Forms;
using ChromatoTool.log;
using System.IO;
using System.Reflection;


namespace ChromatoTool.util
{
    /// <summary>
    /// 光标工具
    /// </summary>
    public class CastCursor
    {

        #region 方法

        /// <summary>
        /// 装载光标
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static Cursor LoadCursor(string resourceName)   
        {   
            try   
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))   
                {   
                    return new Cursor(stream);   
                }   
            }   
            catch(Exception   ex)   
            {
                CastLog.Logger("CastCursor", "LoadCursor", ex.Message);
            }
 
            return   null;
        }



        #endregion

    }
}
