/*-----------------------------------------------------------------------------
//  FILE NAME       : CastString.cs
//  FUNCTION        : string类型的判断处理工具
//  AUTHOR          : XCAST 蔡海鹰(2009/02/20)
//  CHANGE LOG      :
//  FLAG               DATE        WHO      DESCRIPTION
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Text.RegularExpressions;
using System;
using ChromatoTool.log;


namespace ChromatoTool.util
{
    /// <summary>
    /// 字符串类型的处理工具
    /// </summary>
    public class CastString
    {


        /// <summary>
        /// 该字符串是否是数字
        /// </summary>
        /// <param name="strNumber">字符串</param>
        /// <returns>true:是 false 否</returns>
        public static bool IsNumber(string strNumber)   
        {

            Regex objNotNumberPattern = new Regex("[^0-9.-]");   
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");   
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");   
            string strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";   
            string strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";   
            Regex objNumberPattern = new Regex("("   +   strValidRealPattern   +")|("   +   strValidIntegerPattern   +   ")");   

            return  !objNotNumberPattern.IsMatch(strNumber)  &&   
                    !objTwoDotPattern.IsMatch(strNumber)   &&   
                    !objTwoMinusPattern.IsMatch(strNumber)   &&   
                    objNumberPattern.IsMatch(strNumber);   
        }


        /// <summary>
        /// 该字符串是否是数值类型
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns>true:是 false 否</returns>
        public static bool IsNumeric(string value)
        {
            bool ret = true;

            try
            {
                ret = Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
                Convert.ToSingle(value);
            }
            catch (Exception ex)
            {
                CastLog.Logger("CastString", "IsNumeric", ex.Message);
                ret = false;
            }
            return ret;
        }


        /// <summary>
        /// 该字符串是否是整数类型
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns>true:是 false 否</returns>
        public static bool IsInt(string value)   
        {   
            return Regex.IsMatch(value, @"^[+-]?\d*$");   
        }


        /// <summary>
        /// 该字符串是否是无符号整数类型
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns>true:是 false 否</returns>
        public static bool IsUnsign(string value)   
        {   
            return Regex.IsMatch(value, @"^\d*[.]?\d*$");   
        }

        /*=============================================================================
        //    IsPhone()
        //    该字符串是否是电话号码
        // PARAMETER
        //    string value
        // RETURN
        //    bool true:是 false 否
        // EXCEPTION
        //    Nothing
        //---------------------------------------------------------------------------*/
        public static bool IsPhone(string value)
        {
            return Regex.IsMatch(value, @"\d{3}-\d{8}|\d{4}-\d{7}");
        }


        /// <summary>
        /// 该字符串是否是国内手机号码
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns>true:是 false 否</returns>
        public static bool IsMobile(string value)
        {
            return Regex.IsMatch(value, @"^1(3\d{1}|5[389])\d{8}$");
        }


        /// <summary>
        /// 该字符串是否是电子邮件地址
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns>true:是 false 否</returns>
        public static bool IsEmail(string value)
        {
            return Regex.IsMatch(value, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }


        /// <summary>
        /// 匹配帐号是否合法(字母开头，允许5-16字节，允许字母数字下划线)
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns>true:是 false 否</returns>
        public static bool IsIDCard(string value)
        {
            return Regex.IsMatch(value, @"^[a-zA-Z][a-zA-Z0-9_]{4,15}$");
        }


        /// <summary>
        /// 判断输入字符是否为空
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns>true:是 false 否</returns>
        public static bool IsNull(string value)
        {
            if (value.Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}