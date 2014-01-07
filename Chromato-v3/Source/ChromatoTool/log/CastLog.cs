/*-----------------------------------------------------------------------------
//  FILE NAME       : CastLog.cs
//  FUNCTION        : Logger工具
//  AUTHOR          : XCAST 蔡海鹰(2008/12/29)
//  CHANGE LOG      :
//  FLAG               DATE        WHO      DESCRIPTION
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.IO;
using System.Windows.Forms;
using ChromatoTool.ini;


namespace ChromatoTool.log
{
    /// <summary>
    /// 日志文件
    /// </summary>
    public class CastLog
    {

        #region 变量

        /// <summary>
        /// 日志文件名
        /// </summary>
        private static string FileName = "";

        /// <summary>
        /// 实时显示日志控件
        /// </summary>
        public static ListBox lbRealLog = null;

        //日志事件,不定义委托的事件，ReportLogArgs是类
        public static event EventHandler<ReportLogArgs> _reportLogEvent = null;

        /// <summary>
        /// 是否显示到列表中
        /// </summary>
        public static bool bHasList = false;

        #endregion


        #region 方法

        /// <summary>
        /// 写日志到日志文件
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="optFlg">操作标志</param>
        /// <param name="msg">内容</param>
        public static void Logger(String className, String optFlg, String msg)
        {
            string path = Application.ExecutablePath;
            int lastindex = path.LastIndexOf('\\');
            StreamWriter sw = null;
            FileStream fs = null;
            string temp = "";

            if (!General.TraceLog)
            {
                return;
            }

            try
            {

                temp = path.Substring(0, lastindex + 1) + "Log\\" + DateTime.Now.ToString("yyyyMM") + "\\";
                //创建日志目录
                if (!Directory.Exists(temp))
                {
                    Directory.CreateDirectory(temp);
                }
                temp = temp + DateTime.Now.ToString("yyyyMMdd") + ".Log";

                if (!File.Exists(temp))
                {
                    sw = File.CreateText(temp);
                    sw.Close();
                }

                CastLog.FileName = temp;
                fs = new FileStream(CastLog.FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);

                sw = new StreamWriter(fs, System.Text.Encoding.Default);
                 sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.Write("\r\n");

                temp = string.Format("{0} {1} {2} {3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"), className, optFlg, msg);

                sw.WriteLine(temp);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
            finally
            {
                if (null != sw)
                {
                    sw.Flush();
                    sw.Close();
                }
                if (null != fs)
                {
                    fs.Close();
                }
            }

            // 输出到实时的日志窗体中
            if ( bHasList )
            {
                //ReportLogArgs moduleEve = new ReportLogArgs(temp);
                //_reportLogEvent(null, eve);

                ReportLogArgs eve = new ReportLogArgs(temp);
                if (_reportLogEvent != null)
                {
                    _reportLogEvent(null, eve);
                }
            }

        }

        /// <summary>
        /// 写数据到临时文件
        /// </summary>
        /// <param name="msg">内容</param>
        public static void LoggerTemp(String msg)
        {
            string path = Application.ExecutablePath;
            int lastindex = path.LastIndexOf('\\');
            StreamWriter sw = null;
            FileStream fs = null;
            string temp = "";

            try
            {

                CastLog.FileName = path.Substring(0, lastindex + 1) + "Log\\" + DateTime.Now.ToString("yyyyMM") + "\\";
                if (!Directory.Exists(CastLog.FileName))
                {
                    Directory.CreateDirectory(CastLog.FileName);
                }
                CastLog.FileName += DateTime.Now.ToString("yyyyMMdd") + ".Txt";

                if (!File.Exists(CastLog.FileName))
                {
                    sw = File.CreateText(CastLog.FileName);
                    sw.Close();
                }

                fs = new FileStream(CastLog.FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);

                sw = new StreamWriter(fs, System.Text.Encoding.Default);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                //sw.Write("\r\n");

                temp = string.Format("{0}", msg);

                sw.WriteLine(temp);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
            finally
            {
                if (null != sw)
                {
                    sw.Flush();
                    sw.Close();
                }
                if (null != fs)
                {
                    fs.Close();
                }
            }

        }
        
        #endregion

    }
}

