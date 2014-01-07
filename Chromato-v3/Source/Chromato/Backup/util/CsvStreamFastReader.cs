/*-----------------------------------------------------------------------------
//  FILE NAME       : CsvStreamFastReader.cs
//  FUNCTION        : CSV文件快速导入工具
//  AUTHOR          : XCAST 蔡海鹰(2010/05/06)
//  CHANGE LOG      :
//  FLAG               DATE        WHO      DESCRIPTION
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ChromatoTool.dto;
using ChromatoTool.ini;

namespace ChromatoTool.util
{
    /// <summary>
    /// CSVUtil is a helper class handling csv files.
    /// </summary>
    public class CsvStreamFastReader
    {

        #region 常量

        /// <summary>
        /// 导入csv文件第一行的标题内容
        /// </summary>
        private const string Header = "index,minute,mv";

        #endregion


        #region 构造

        private CsvStreamFastReader()
        {
        }

        #endregion


        #region 方法

        /// <summary>
        /// write a new file, existed file will be overwritten
        /// </summary>
        /// <param name="filePathName"></param>
        /// <param name="ls"></param>
        public static void WriteCSV(string filePathName,List<String[]>ls)
        {
            WriteCSV(filePathName,false,ls);
        }


        /// <summary>
        /// write a file, existed file will be overwritten if append = false
        /// </summary>
        /// <param name="filePathName"></param>
        /// <param name="append"></param>
        /// <param name="ls"></param>
        public static void WriteCSV(string filePathName,bool append, List<String[]> ls)
        {
            StreamWriter fileWriter=new StreamWriter(filePathName,append,Encoding.Default);
            foreach(String[] strArr in ls)
            {
                fileWriter.WriteLine(String.Join (",",strArr) );
            }
            fileWriter.Flush();
            fileWriter.Close();
            
        }

        /// <summary>
        /// 读取CSV文件
        /// </summary>
        /// <param name="filePathName"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static void ReadCSV(string filePathName, ArrayList arr)
        {
            String[] ls = null;
            StreamReader sr = null;
            string strLine = "";
            OriginPointDto dto = null;
            int count = 0;

            //对数据的有效性进行验证
            if (String.IsNullOrEmpty(filePathName))
            {
                throw new Exception("请指定要载入的CSV文件名");
            }
            else if (!File.Exists(filePathName))
            {
                throw new Exception("指定的CSV文件不存在");
            }


            try
            {
                sr = new StreamReader(filePathName, Encoding.Default);

                strLine = sr.ReadLine();
                //数据行出现奇数个引号
                if (String.IsNullOrEmpty(strLine))
                {
                    MessageBox.Show("CSV文件的格式有错误", "错误");
                }
                else if (strLine.Length < Header.Length || !Header.Equals(strLine.Substring(0, Header.Length)))
                {
                    MessageBox.Show("CSV文件的格式有错误", "错误");
                }

                while (!String.IsNullOrEmpty(strLine))
                {
                    strLine = sr.ReadLine();
                    if (!String.IsNullOrEmpty(strLine) && strLine.Length > 0)
                    {
                        ls = strLine.Split(',');
                        //Debug.WriteLine(strLine);

                        dto = new OriginPointDto();
                        dto.Index = count++;
                        dto.Moment = Convert.ToSingle(ls[1]);
                        dto.Voltage = Convert.ToSingle(ls[2]) / DefaultItem.uVol;
                        arr.Add(dto);
                    }
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"错误");
                sr.Close();
            }

        }
        
        #endregion
    }
}