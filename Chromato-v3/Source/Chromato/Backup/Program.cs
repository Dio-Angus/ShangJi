/*-----------------------------------------------------------------------------
//  FILE NAME       : Program.cs
//  FUNCTION        : Application Entry Point
//  AUTHOR          : 李锋(2009/03/09)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using Chromato.gui;
using ChromatoTool.ini;
using System.Threading;
using System.Text;
using ChromatoCore.Login;

namespace Chromato
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Boolean bCreateNew;
            Mutex instance = new Mutex(true, "Chromato", out bCreateNew);

            if (!bCreateNew)
            {
                MessageBox.Show("只能创建一个实例，请先退出存在的实例！",
                    "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();

            }
            else
            {
                String a = String.Format("{0:0,0}  (µV)", 50.6789 * DefaultItem.uVol);
                bool ret = IsLeapYear(2000);

                String temp = "A4";
                GcChannel.Tcd2 = (Convert.ToInt32(temp, 16) & 0x20) > 0 ? true : false;
                GcChannel.Tcd1 = (Convert.ToInt32(temp, 16) & 0x10) > 0 ? true : false;
                GcChannel.Fid2 = (Convert.ToInt32(temp, 16) & 0x8) > 0 ? true : false;
                GcChannel.Fid1 = (Convert.ToInt32(temp, 16) & 0x4) > 0 ? true : false;
                Setting.Read();
                if (General.NeedLogin)
                {
                    LoginFrm frmLogin = new LoginFrm();
                    if (frmLogin.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }

                switch(General.ObjectLink)
                {
                    case General.LinkObject.AutoChromatoGas:
                        //AutoChromatoFrm frmAuto = new AutoChromatoFrm();
                        //Application.Run(frmAuto);
                        //break;
                    case General.LinkObject.SimuGc:
                    case General.LinkObject.SmallBoard:
                    case General.LinkObject.BigBoard:
                    case General.LinkObject.ChannelGas:
                        ChromatoFrm frmChromato = new ChromatoFrm();
                        Application.Run(frmChromato);
                       break;
                    default:
                       break;

                }
                //notuse();
            }
        }

        public static bool IsLeapYear(int year)
        {
            if( (0 == year % 400) || ((0 == year % 4) && (0 != year % 100)))
            {
                return true;
            }
            return false;
        }

        public static void notuse()
        {
            Byte[] bytes = new Byte[] {
                     65,  83,  67,  73,  73,  32,  69,
                    110,  99, 111, 100, 105, 110, 103,
                     32,  69, 120,  97, 109, 112, 108, 101, 170, 171, 172, 01
                };

            string temp = String.Format("{0:X5}",Microsoft.VisualBasic.Conversion.Hex(bytes[25]));

            String decoded = Encoding.BigEndianUnicode.GetString(bytes, 0, 26);
            //String decoded = ascii.GetString(bytes, 0, 26);
            Console.WriteLine(decoded);

            for (int i = 0; i < 26; i++)
            {

            }

            // Encode the string.
            Byte[] encodedBytes = Encoding.BigEndianUnicode.GetBytes(decoded);
            Console.WriteLine();
            Console.WriteLine("Encoded bytes:");
            foreach (Byte b in encodedBytes)
            {
                Console.Write("[{0}]", b);
            }
        }


    }
}
