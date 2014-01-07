/*-----------------------------------------------------------------------------
//  FILE NAME       : IniFile.cs
//  FUNCTION        : Iniファイルのロジック
//  AUTHOR          : 李锋(2008/12/01)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Text;
using System.Runtime.InteropServices;


namespace ChromatoTool.ini
{
    /// <summary>
    /// Read/Write values to an ini file
    /// </summary>
    public class IniFile 
    {
        /// <summary>
        /// 路径
        /// </summary>
        public string _path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key,string val,string filePath);
        
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
            string key,string def, StringBuilder retVal, int size,string filePath);

        public IniFile(string INIPath){
            _path = INIPath;
        }

        public void WriteValue(string Section, string Key, string Value) {
            WritePrivateProfileString(Section, Key, Value, this._path);
        }
        
        public string ReadValue(string Section, string Key, string Default) {
            StringBuilder buffer = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, Default, buffer, 255, this._path);

            return buffer.ToString();
        }

        public void WriteValue(string Section, string Key, int Value)
        {
            WritePrivateProfileString(Section, Key, Value.ToString(), this._path);
        }

        public int ReadValue(string Section, string Key, int Default)
        {
            StringBuilder buffer = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, Default.ToString(), buffer, 255, this._path);

            return int.Parse(buffer.ToString());
        }
    }
}
