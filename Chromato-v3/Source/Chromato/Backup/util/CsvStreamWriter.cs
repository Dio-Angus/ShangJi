/*-----------------------------------------------------------------------------
//  FILE NAME       : CsvStreamWriter.cs
//  FUNCTION        : CSV文件导入工具
//  AUTHOR          : XCAST 蔡海鹰(2009/10/27)
//  CHANGE LOG      :
//  FLAG               DATE        WHO      DESCRIPTION
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Data;
using System.Text; 
using System.Windows.Forms;
using System.IO;
using System.Collections;
using ChromatoTool.dto;
using ChromatoTool.ini;

namespace ChromatoTool.util
{   
    /// <summary>
    /// CSV文件导入工具
    /// </summary>
    public class CsvStreamWriter 
    {

        #region 方法

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="path"></param>
        public static void ExportToSvc(System.Data.DataTable dt, string path) 
        { 

            //导出.csv文件 
            string strPath = path;

            //先打印标头 
            StringBuilder strColu = new StringBuilder(); 
            StringBuilder strValue = new StringBuilder(); 
            int t = 0; 
            try 
            { 
                StreamWriter sw = new StreamWriter(new FileStream(strPath, FileMode.CreateNew), Encoding.Unicode);//.GetEncoding("GB2312"));
                for (t = 0; t < dt.Columns.Count; t++) 
                { 
                    strColu.Append(dt.Columns[t].ColumnName); 
                    strColu.Append(","); 
                } 
                strColu.Remove(strColu.Length - 1, 1);//移出掉最后一个,字符 
                sw.WriteLine(strColu); 
                foreach (DataRow dr in dt.Rows) 
                { 
                    strValue.Remove(0, strValue.Length);//移出 
                    for (t = 0; t < dt.Columns.Count; t++) 
                    { 
                        strValue.Append(dr[t].ToString()); 
                        strValue.Append(","); 
                    } 
                    strValue.Remove(strValue.Length - 1, 1);//移出掉最后一个,字符 
                    sw.WriteLine(strValue); 
                }
                sw.Close(); 
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="arrPlot"></param>
        /// <param name="dtResult"></param>
        /// <param name="filePath"></param>
        /// <param name="dtoSoluExport"></param>
        public static void ExportToCsv(ArrayList arrPlot, System.Data.DataTable dtResult, 
                            string filePath, SolutionExportDto dtoSoluExport)
        {

            try
            {
                StreamWriter sw = new StreamWriter(new FileStream(filePath, FileMode.Create), Encoding.GetEncoding("GB2312"));//.Unicode);//

                if( ExportFlag.Solution)
                {
                    CsvStreamWriter.ExportSolution(sw, dtoSoluExport, filePath);
                }
                if(ExportFlag.Result)
                {
                    CsvStreamWriter.ExportResult(sw, dtResult, filePath);
                }
                if (ExportFlag.Data)
                {
                    CsvStreamWriter.ExportData(sw, arrPlot, filePath);
                }
                sw.Close();

                //打开文件
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "Excel.exe";
                //避免路径中的空格
                p.StartInfo.Arguments = "\"" + filePath + "\"";
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        /// <summary>
        /// 导出谱图数据
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="arr"></param>
        /// <param name="path"></param>
        private static void ExportData(StreamWriter sw, ArrayList arr, string path)
        {
            if (null == arr && 0 == arr.Count)
            {
                return;
            }

            //sw.WriteLine("[谱图数据]");

            //先打印标头 
            StringBuilder strColu = new StringBuilder();
            StringBuilder strValue = new StringBuilder();

            //把数据表的各个信息输入到excel表中
            strColu.Append("index,");    //( "索引,");
            strColu.Append("minute,");  //( "时间（分钟）,") ;
            strColu.Append("mv");   // "电压（毫伏）,");
            //strColu.Append("峰宽,");
            //strColu.Append("设定斜率,");
            //strColu.Append("漂移,");
            //strColu.Append("斜率,");
            //strColu.Append("点的状态,");
            //strColu.Append("平均斜率,");
            //strColu.Append("峰的趋势");

            sw.WriteLine(strColu);
            //sw.WriteLine("");

            foreach (OriginPointDto dto in arr)
            //foreach (AvgExportDto dto in arr)
            {
                strValue.Remove(0, strValue.Length);    //移出 
                strValue.Append(dto.Index.ToString());
                strValue.Append(",");
                strValue.Append(dto.Moment.ToString());
                strValue.Append(",");
                strValue.Append((dto.Voltage * DefaultItem.uVol).ToString());
                strValue.Append(",");
                //strValue.Append(dto.PeakWide.ToString());
                //strValue.Append(",");
                //strValue.Append(dto.SettingSlope.ToString());
                //strValue.Append(",");
                //strValue.Append(dto.Drift.ToString());
                //strValue.Append(",");
                //strValue.Append(dto.Slope.ToString());
                //strValue.Append(",");
                //strValue.Append(dto.StatusPoint);
                //strValue.Append(",");
                //strValue.Append(dto.StatusAvgSlope.ToString());
                //strValue.Append(",");
                //strValue.Append(dto.TrendPeak.ToString());
                sw.WriteLine(strValue);
            }
            sw.WriteLine("");
        }

        /// <summary>
        /// 导出分析结果
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="dt"></param>
        /// <param name="path"></param>
        private static void ExportResult(StreamWriter sw, System.Data.DataTable dt, string path)
        {
            if (null == dt && 0 == dt.Rows.Count)
            {
                return;
            }

            sw.WriteLine("[分析结果]");

            //先打印标头 
            StringBuilder strColu = new StringBuilder();
            StringBuilder strValue = new StringBuilder();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                strColu.Append(dt.Columns[i].ColumnName);
                strColu.Append(",");
            }
            strColu.Remove(strColu.Length - 1, 1);//移出掉最后一个,字符 
            sw.WriteLine(strColu);
            foreach (DataRow dr in dt.Rows)
            {
                strValue.Remove(0, strValue.Length);//移出 
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    strValue.Append(dr[i].ToString());
                    strValue.Append(",");
                }
                strValue.Remove(strValue.Length - 1, 1);//移出掉最后一个,字符 
                sw.WriteLine(strValue);
            }
            sw.WriteLine("");
        }

        /// <summary>
        /// 导出关联方案
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="dtoSoluExport"></param>
        /// <param name="filePath"></param>
        private static void ExportSolution(StreamWriter sw, SolutionExportDto dtoSoluExport, string filePath)
        {
            if (null == dtoSoluExport._dtoAnalyPara)
            {
                return;
            }

            StringBuilder strValue = new StringBuilder();
            //sw.WriteLine("[方案信息]");
            sw.WriteLine("[分析方法]");

            strValue.Append("峰宽=");
            strValue.Append(dtoSoluExport._dtoAnalyPara.PeakWide);
            sw.WriteLine(strValue);

            strValue.Remove(0, strValue.Length);
            strValue.Append("斜率=");
            strValue.Append(dtoSoluExport._dtoAnalyPara.Slope);
            sw.WriteLine(strValue);

            strValue.Remove(0, strValue.Length);
            strValue.Append("漂移=");
            strValue.Append(dtoSoluExport._dtoAnalyPara.Drift);
            sw.WriteLine(strValue);

            strValue.Remove(0, strValue.Length);
            strValue.Append("最小面积=");
            strValue.Append(dtoSoluExport._dtoAnalyPara.MinAreaSize);
            sw.WriteLine(strValue);

            strValue.Remove(0, strValue.Length);
            strValue.Append("定量方法=");
            strValue.Append(EnumDescription.GetFieldText(dtoSoluExport._dtoAnalyPara.ArithmaticID));
            sw.WriteLine(strValue);

            strValue.Remove(0, strValue.Length);
            strValue.Append("定量参数=");
            strValue.Append(EnumDescription.GetFieldText(dtoSoluExport._dtoAnalyPara.ArithmaticPara));
            sw.WriteLine(strValue);

            strValue.Remove(0, strValue.Length);
            strValue.Append("对准参数=");
            strValue.Append(EnumDescription.GetFieldText(dtoSoluExport._dtoAnalyPara.AimPara));
            sw.WriteLine(strValue);

            strValue.Remove(0, strValue.Length);
            strValue.Append("校正方法=");
            strValue.Append(EnumDescription.GetFieldText(dtoSoluExport._dtoAnalyPara.FixWay));
            sw.WriteLine(strValue);

            if (dtoSoluExport._isUseTp)
            {
                sw.WriteLine("[时间程序]");
                sw.WriteLine("名称,开始时间,结束时间,值");

                foreach (TimeProcDto dtoTp in dtoSoluExport._timeProc)
                {
                    strValue.Remove(0, strValue.Length);
                    strValue.Append(dtoTp.TPName);
                    strValue.Append(",");
                    strValue.Append(dtoTp.StartTime);
                    strValue.Append(",");
                    strValue.Append(dtoTp.StopTime);
                    strValue.Append(",");
                    strValue.Append(dtoTp.TpValue); 
                    sw.WriteLine(strValue);
                }
            }

            sw.WriteLine("[峰鉴定表]");

            int i = 0;
            foreach (IngredientDto dtoIngre in dtoSoluExport._arrIngre)
            {
                sw.WriteLine("名称,开始时间,结束时间,值");
                strValue.Remove(0, strValue.Length);
                strValue.Append(dtoIngre.IngredientID);
                strValue.Append(",");
                strValue.Append(dtoIngre.IngredientName);
                strValue.Append(",");
                strValue.Append(dtoIngre.ReserveTime.ToString());
                sw.WriteLine(strValue);

                sw.WriteLine("峰高,峰面积,浓度,因子一,因子二");
                foreach (CalibrateDto dtoCali in (ArrayList)dtoSoluExport._arrCali[i])
                {
                    strValue.Remove(0, strValue.Length);
                    strValue.Append(dtoCali.PeakHeight.ToString());
                    strValue.Append(",");
                    strValue.Append(dtoCali.PeakSize.ToString());
                    strValue.Append(",");
                    strValue.Append(dtoCali.Density.ToString());
                    strValue.Append(",");
                    strValue.Append(dtoCali.FactorOne.ToString());
                    strValue.Append(",");
                    strValue.Append(dtoCali.FactorTwo.ToString()); 
                    sw.WriteLine(strValue);
                }
                i++;
            }
            sw.WriteLine("");

        }

        #endregion

    } 
} 

