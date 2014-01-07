/*-----------------------------------------------------------------------------
//  FILE NAME       : TransLateUtil.cs
//  FUNCTION        : 打印工具
//  AUTHOR          : 蔡海鹰(2009/06/09)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

namespace ChromatoPrint
{
    /// <summary>
    /// 打印工具
    /// </summary>
    public static class TransLateUtil
    {

        #region 方法

        /// <summary>
        /// 把列转换为整数
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static int translateInt(object column)
        {
            if (column == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(column);
            }
        }

        /// <summary>
        /// 把列转换为Bool
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static bool translateBool(object column)
        {
            if (column == DBNull.Value)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(column);
            }
        }

        /// <summary>
        /// 把列转换为Decimal
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static decimal translateDecimal(object column)
        {
            if (column == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(column);
            }
        }

        /// <summary>
        /// 把列转换为Double
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static double translateDouble(object column)
        {
            if (column == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(column);
            }
        }

        /// <summary>
        /// 把列转换为日期
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static DateTime translateDate(object column)
        {
            if (column == DBNull.Value)
            {
                return DateTime.MinValue;
            }
            else
            {
                return Convert.ToDateTime(column);
            }
        }

        /// <summary>
        /// 把列转换为字符串
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static string translateString(object column)
        {
            if (column == DBNull.Value)
            {
                return "";
            }
            else
            {
                return column.ToString();
            }
        }

        /// <summary>
        /// 把列转换为日期和时间的组合
        /// </summary>
        /// <param name="columnDate"></param>
        /// <param name="columnTime"></param>
        /// <returns></returns>
        public static DateTime combineDateTime(object columnDate, object columnTime)
        {
            DateTime retVal = DateTime.MinValue;
            if (columnDate != DBNull.Value)
            {
                retVal = Convert.ToDateTime(columnDate).Date;
            }
            if (columnTime != DBNull.Value)
            {
                DateTime timeVal = Convert.ToDateTime(columnTime);
                retVal = retVal.Add(timeVal.TimeOfDay);
            }
            return retVal;
        }

        /// <summary>
        /// 消息确认
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool confirm(string message)
        {
            return (MessageBox.Show(message, "Please Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes);
        }

        /// <summary>
        /// 取消消息确认
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DialogResult confirmWithCancel(string message)
        {
            return MessageBox.Show(message, "Please Confirm", MessageBoxButtons.YesNoCancel);
        }

        /// <summary>
        /// 打印行
        /// </summary>
        /// <param name="e"></param>
        /// <param name="line"></param>
        /// <param name="theFont"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="maxWidth"></param>
        /// <param name="rightAlign"></param>
        /// <param name="printColour"></param>
        /// <returns></returns>
        public static float printLine(PrintPageEventArgs e, String line, Font theFont, float xPos, float yPos, 
            float maxWidth, bool rightAlign, Brush printColour)
        {
            float retVal = 0;
            if (line != "")
            {
                StringFormat theFormat = new StringFormat();
                float lineHeight = theFont.GetHeight(e.Graphics);
                RectangleF rect = new RectangleF(xPos, yPos, maxWidth, lineHeight);
                if (rightAlign)
                {
                    theFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                }
                rect = calcTextRectangle(e, theFont, xPos, yPos, maxWidth, line);
                e.Graphics.DrawString(line, theFont, printColour, rect, theFormat);
                retVal = rect.Height;
            }
            return retVal;
        }

        /// <summary>
        /// 计算文本打印的大小
        /// </summary>
        /// <param name="e"></param>
        /// <param name="theFont"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="maxWidth"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static RectangleF calcTextRectangle( PrintPageEventArgs e, Font theFont, float xPos, float yPos, float maxWidth, string text)
        {
            int noOfLines = noOfPrintLines( e, theFont, maxWidth, text);
            float lineHeight = theFont.GetHeight(e.Graphics);
            lineHeight = lineHeight * noOfLines;
            RectangleF rect = new RectangleF(xPos, yPos, maxWidth, lineHeight);
            return rect;
        }

        /// <summary>
        /// 计算需要打印的行数
        /// </summary>
        /// <param name="e"></param>
        /// <param name="theFont"></param>
        /// <param name="maxWidth"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int noOfPrintLines(PrintPageEventArgs e, Font theFont, float maxWidth, string text)
        {
            string[] textSplit = text.Split("\n\r".ToCharArray());
            SizeF charSize = e.Graphics.MeasureString("A", theFont);
            int totalNoOfLines = 0;
            for (int i = 0; i < textSplit.Length; i++)
            {
                if ((textSplit[i] != "\n")
                    && (textSplit[i] != "\r")
                    && (textSplit[i] != ""))
                {
                    SizeF size = e.Graphics.MeasureString(textSplit[i], theFont);
                    float noOfLines = size.Width / maxWidth;
                    noOfLines = (float)Math.Ceiling(noOfLines);
                    totalNoOfLines += Convert.ToInt32(noOfLines);
                }
            }
            return totalNoOfLines;
        }
    
        #endregion 

    }
}
