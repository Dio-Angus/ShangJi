/*-----------------------------------------------------------------------------
//  FILE NAME       : CastExcel.cs
//  FUNCTION        : 数据导出到EXCEL工具
//  AUTHOR          : XCAST 蔡海鹰(2009/07/08)
//  CHANGE LOG      :
//  FLAG               DATE        WHO      DESCRIPTION
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


using System;
using Microsoft.Office.Interop.Excel;
using System.Collections;
using Microsoft.Office.Core;
using System.IO;
using ChromatoTool.ini;
using System.Reflection;
using ChromatoTool.dto;
using ChromatoTool.log;


namespace ChromatoTool.util
{

    /// <summary>
    /// Excel生成处理
    /// </summary>
    public class CastExcel
    {

        #region 常量

        /// <summary>
        /// 开始列号
        /// </summary>
        private const Int32 StartColumn = 1;

        #endregion


        #region 变量

        /// <summary>
        /// 开始行号
        /// </summary>
        public static Int32 _currentRow { get; set; }

        #endregion


        #region 导出为Excel文件

        /// <summary>
        /// DataTable导出数据到Excel,这里可以根据需要再进行修改
        /// 调用说明:
        /// arrCol.Insert(0, "XM");
        /// arrCol.Insert(1, "NJ");
        /// arrCol.Insert(2, "SFZH");
        /// arrCol.Insert(3, "CSRQ");
        /// arrColName.Insert(0, "姓名");
        /// arrColName.Insert(1, "年龄");
        /// arrColName.Insert(2, "身份证号");
        /// arrColName.Insert(3, "出生日期");
        /// </summary>
        /// <param name="dtPlot">导出的数据集</param>
        /// <param name="arrColName">列名称objHasValue.add("序列号","字段名")</param>
        /// <param name="arrCol">列对应的说明 objHasValue.add("序列号","字段说明")</param>
        /// <param name="dtResult">结果集合</param>
        /// <param name="filepath">XLS文件路径</param>
        /// <param name="bmpPath">BMP文件路径</param>
        public static void ExportToXls(System.Data.DataTable dtPlot, ArrayList arrColName,
                                       ArrayList arrCol, System.Data.DataTable dtResult, string filepath, string bmpPath)
        {

            #region"初始化变量"
            Application appObject = new ApplicationClass();
            Workbook workBook = appObject.Workbooks.Add(true);
            object missing = Missing.Value;
            #endregion


            try
            {
                //实例化Sheet
                Worksheet sheetWork = new Worksheet();

                //设置总Sheet
                sheetWork = (Worksheet)workBook.ActiveSheet;
                sheetWork.Name = "目录";

                #region"设置分Sheet"

                appObject.Worksheets.Add(missing, sheetWork, missing, missing);

                sheetWork = (Worksheet)workBook.ActiveSheet;

                if( ExportFlag.Solution)
                {
                    sheetWork.Name = "方案";
                    CastExcel.ExportResultToCsv(dtResult, sheetWork);
                }
                if(ExportFlag.Result)
                {
                    sheetWork.Name = "结果";
                    CastExcel.ExportResultToCsv(dtResult, sheetWork);
                }
                if (ExportFlag.Data)
                {
                    sheetWork.Name = "数据";
                    CastExcel.ExportDataToXls(dtPlot, arrColName, arrCol, sheetWork);
                }


                //设置超级联接
                for (int t = 1; t <= 1; t++)
                {
                    Range r1 = (Range)sheetWork.Cells[t, 1];
                    //设置当前位置超连接到的Sheet
                    //r1.Hyperlinks.Add(r1, "", "信息" + t + "!A1", missing, "信息" + t);
                    r1.Hyperlinks.Add(r1, "", sheetWork.Name + t + "!A1", missing, sheetWork.Name + t);
                }

                //设置公式项
                Range r2 = (Range)sheetWork.Cells[4, 2];
                r2.Formula = "=SUM(B3+B2)";
                /*参数说明
                FileName                要创建的 OLE 对象的源文件。
                LinkToFile              要链接至的文件。
                SaveWithDocument        图片与文档一起保存。
                Left                    左上角的位置。
                Top                     图片左上角的位置。
                Width                   图片的宽度。
                Height                  图片的高度。
                往EXCEL中添加图片*/
                if (File.Exists(bmpPath))
                {
                    sheetWork.Shapes.AddPicture(bmpPath, MsoTriState.msoCTrue, MsoTriState.msoCTrue, 250, 0, 300, 100);
                }
  
                #endregion

                //保存工作薄
                sheetWork.SaveAs(filepath, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            }
            catch (Exception ex)
            {
                //添加错误日志
                //SEHR.BLL.Function.AddMsgLog.AddMsg(LogType.Msg, "生成EXCEL", "Table生成Excel出错", ex.StackTrace);
                CastLog.Logger("CastExcel", "ExportToCsv",ex.Message);
            }
            finally
            {
                #region"销毁Excel进程"
                appObject.Visible = true;//使excel可见*/

                //workBook.Close(false, Type.Missing, Type.Missing);
                //appObject.Workbooks.Close();
                //appObject.Quit();
                //Marshal.ReleaseComObject(workBook);
                //Marshal.ReleaseComObject(appObject);
                //workBook = null;
                //appObject = null;
                GC.Collect();
                #endregion
            }
        }


        /// <summary>
        /// 导出数据到Excel
        /// </summary>
        /// <param name="dtPlot"></param>
        /// <param name="arrColName"></param>
        /// <param name="arrCol"></param>
        /// <param name="sheetWork"></param>
        private static void ExportDataToXls(System.Data.DataTable dtPlot, ArrayList arrColName, ArrayList arrCol, Worksheet sheetWork)
        {

            #region"生成标题行"
            int m = 1;
            for (int i = 0; i <= arrColName.Count; i++)
            {
                if (i < arrColName.Count)
                {
                    sheetWork.Cells[1, m] = "'" + arrColName[i].ToString();
                    //Range r1 = (Range)sheetWork.Cells[1, m];
                    //r1.Font.Bold = true;
                    // r1.Borders.LineStyle = 1;                                   //单元格边框宽度
                    //r1.Borders.Color = System.Drawing.Color.Black.ToArgb();        //单元格边框颜色
                    //r1.Interior.Color = System.Drawing.Color.LightGray.ToArgb();   //单元格背景颜色
                    //r1.Borders[XlBordersIndex.xlDiagonalDown].Weight = 1;           //设置边筐样式    
                }
                else
                {
                    Range r1 = (Range)sheetWork.Cells[1, m];
                    //r1.Hyperlinks.Add(r1, "http://www.51job.com", "51job");
                    //设置返回到当前位置超连接
                    r1.Hyperlinks.Add(r1, "", "目录!A1", Missing.Value, "back");
                }
                m++;
            }
            #endregion

            #region"生成数据行"
            for (int i = 0; i < dtPlot.Rows.Count; i++)
            {
                int j = 1;
                for (int n = 0; n < arrCol.Count; n++)
                {
                    string str = arrCol[n].ToString();
                    string str1 = dtPlot.Columns[str].DataType.ToString();
                    //判断数据类型来做特殊处理
                    if (str1 == "System.DateTime")
                    {
                        sheetWork.Cells[i + 2, j] = "'" + Convert.ToDateTime(dtPlot.Rows[i][str]).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        sheetWork.Cells[i + 2, j] = dtPlot.Rows[i][str].ToString(); // +x.ToString();
                    }
                    j++;
                }
            }
            #endregion
        }


        /// <summary>
        /// DataTable导出数据到Excel,这里可以根据需要再进行修改
        /// 调用说明:
        /// arrCol.Insert(0, "XM");
        /// arrCol.Insert(1, "NJ");
        /// arrCol.Insert(2, "SFZH");
        /// arrCol.Insert(3, "CSRQ");
        /// arrColName.Insert(0, "姓名");
        /// arrColName.Insert(1, "年龄");
        /// arrColName.Insert(2, "身份证号");
        /// arrColName.Insert(3, "出生日期");
        /// </summary>
        /// <param name="dtPlot">导出的数据集</param>
        /// <param name="arrColName">列名称objHasValue.add("序列号","字段名")</param>
        /// <param name="arrCol">列对应的说明 objHasValue.add("序列号","字段说明")</param>
        /// <param name="dtResult">结果集合</param>
        /// <param name="filepath">XLS文件路径</param>
        /// <param name="bmpPath">BMP文件路径</param>
        public static void ExportToXls(ArrayList arrPlot, ArrayList arrColName,
                                       ArrayList arrCol, System.Data.DataTable dtResult, string filepath, string bmpPath)
        {

            #region"初始化变量"
            Application appObject = new ApplicationClass();
            Workbook workBook = appObject.Workbooks.Add(true);
            object missing = Missing.Value;
            #endregion


            try
            {
                //实例化Sheet
                Worksheet sheetWork = new Worksheet();

                //设置总Sheet
                sheetWork = (Worksheet)workBook.ActiveSheet;

                //设置行号
                _currentRow = 1;

                //设置名称和内容
                if (ExportFlag.Solution)
                {
                    //sheetWork.Name += "方案";
                    //CastExcel.ExportDataToXls(arrPlot, arrColName, arrCol, sheetWork);
                    //_currentRow++;
                } 
                
                if (ExportFlag.Data)
                {
                    sheetWork.Name += "数据";
                    CastExcel.ExportDataToXls(arrPlot, arrColName, arrCol, sheetWork);
                    _currentRow++;
                }

                if( ExportFlag.Result )
                {
                    sheetWork.Name += "结果";
                    CastExcel.ExportResultToCsv(dtResult, sheetWork);
                    _currentRow++;
                }
                

                //设置超级联接
                //for (int t = 1; t <= 1; t++)
                //{
                //    Range r1 = (Range)sheetWork.Cells[t, 1];
                //    //设置当前位置超连接到的Sheet
                //    //r1.Hyperlinks.Add(r1, "", "信息" + t + "!A1", missing, "信息" + t);
                //    r1.Hyperlinks.Add(r1, "", sheetWork.Name + t + "!A1", missing, sheetWork.Name + t);
                //}

                //设置公式项
                Range r2 = (Range)sheetWork.Cells[4, 2];
                r2.Formula = "=SUM(B3+B2)";
                /*参数说明
                FileName                要创建的 OLE 对象的源文件。
                LinkToFile              要链接至的文件。
                SaveWithDocument        图片与文档一起保存。
                Left                    左上角的位置。
                Top                     图片左上角的位置。
                Width                   图片的宽度。
                Height                  图片的高度。
                 * 
                往EXCEL中添加图片*/
                if (File.Exists(bmpPath))
                {
                    sheetWork.Shapes.AddPicture(bmpPath, MsoTriState.msoCTrue, MsoTriState.msoCTrue, 250, 0, 300, 100);
                }


                //保存工作薄
                sheetWork.SaveAs(filepath, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            }
            catch (Exception ex)
            {
                //添加错误日志
                //SEHR.BLL.Function.AddMsgLog.AddMsg(LogType.Msg, "生成EXCEL", "Table生成Excel出错", ex.StackTrace);
                CastLog.Logger("CastExcel", "ExportToCsv", ex.Message);
            }
            finally
            {
                #region"销毁Excel进程"
                appObject.Visible = true;//使excel可见*/

                GC.Collect();
                #endregion
            }
        }

        /// <summary>
        /// 导出数据到Excel
        /// </summary>
        /// <param name="dtPlot"></param>
        /// <param name="arrColName"></param>
        /// <param name="arrCol"></param>
        /// <param name="sheetWork"></param>
        private static void ExportDataToXls(ArrayList arrPlot, ArrayList arrColName, ArrayList arrCol, Worksheet sheetWork)
        {

            #region"生成标题行"
            int m = 1;
            for (int i = 0; i <= arrColName.Count; i++)
            {
                if (i < arrColName.Count)
                {
                    sheetWork.Cells[_currentRow, m] = "'" + arrColName[i].ToString();

                }
                else
                {
                    //Range r1 = (Range)sheetWork.Cells[_currentRow, m];
                    //r1.Hyperlinks.Add(r1, "http://www.51job.com", "51job");
                    //设置返回到当前位置超连接
                    //r1.Hyperlinks.Add(r1, "", "目录!A1", Missing.Value, "back");
                }
                m++;
            }
            _currentRow++;
            #endregion

            #region"生成数据行"
            foreach (OriginPointDto dto in arrPlot)
            //foreach (AvgExportDto dto in arrPlot)
            {
                sheetWork.Cells[_currentRow, 1] = dto.Index.ToString();
                sheetWork.Cells[_currentRow, 2] = dto.Moment.ToString();
                sheetWork.Cells[_currentRow, 3] = dto.Voltage.ToString();
                //sheetWork.Cells[row, 4] = dto.PeakWide.ToString();
                //sheetWork.Cells[row, 5] = dto.SettingSlope.ToString();
                //sheetWork.Cells[row, 6] = dto.Drift.ToString();
                //sheetWork.Cells[row, 7] = dto.Slope.ToString();
                //sheetWork.Cells[row, 8] = dto.StatusPoint;
                //sheetWork.Cells[row, 9] = dto.StatusAvgSlope;
                //sheetWork.Cells[row, 10] = dto.TrendPeak;
                _currentRow ++;
            }
            #endregion
        }

        #endregion


        #region 导出为CSV文件

        /// <summary>
        /// 导出DataTable为CSV格式文件
        /// </summary>
        /// <param name="dtPlot"></param>
        /// <param name="dtResult"></param>
        /// <param name="filePath"></param>
        public static void ExportToCsv(System.Data.DataTable dtPlot,
                                        System.Data.DataTable dtResult, string filePath)
        {

            Application appOb = new Application();//创建excel对象
            Workbook workBook = appOb.Workbooks.Add(true);
            object missing = System.Reflection.Missing.Value;

            try
            {
                //实例化Sheet
                Worksheet sheetWork = new Worksheet();

                sheetWork = (Worksheet)workBook.ActiveSheet;

                if( ExportFlag.Solution )
                {
                    sheetWork.Name += "方案";
                    //CastExcel.ExportResultToCsv(dtResult, sheetWork);
                }

                if( ExportFlag.Result )
                {
                    sheetWork.Name += "结果";
                    CastExcel.ExportResultToCsv(dtResult, sheetWork);
                }

                if( ExportFlag.Data)
                {
                    sheetWork.Name += "数据";
                    CastExcel.ExportDataToCsv(dtPlot, sheetWork);
                }

                //保存工作薄
                sheetWork.SaveAs(filePath, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            }
            catch (Exception ex)
            {
                //添加错误日志
                //SEHR.BLL.Function.AddMsgLog.AddMsg(LogType.Msg, "生成EXCEL", "Table生成Excel出错", ex.StackTrace);
                CastLog.Logger("CastExcel", "ExportToCsv", ex.Message);
            }
            finally
            {
                //使excel可见
                appOb.Visible = true;
            }
        }

        /// <summary>
        /// 导出ArrayList为CSV格式文件
        /// </summary>
        /// <param name="exportContent"></param>
        /// <param name="arrPlot"></param>
        /// <param name="dtResult"></param>
        /// <param name="filePath"></param>
        public static void ExportToCsv(ExportFlag exportContent, ArrayList arrPlot,
                                System.Data.DataTable dtResult, string filePath)
        {

            Application appOb = new Application();//创建excel对象
            Workbook workBook = appOb.Workbooks.Add(true);
            object missing = System.Reflection.Missing.Value;

            try
            {
                //实例化Sheet
                Worksheet sheetWork = new Worksheet();

                sheetWork = (Worksheet)workBook.ActiveSheet;


                if (ExportFlag.Solution)
                {
                    sheetWork.Name += "方案";
                    //CastExcel.ExportResultToCsv(dtResult, sheetWork);
                }

                if (ExportFlag.Result)
                {
                    sheetWork.Name += "结果";
                    CastExcel.ExportResultToCsv(dtResult, sheetWork);
                }

                if (ExportFlag.Data)
                {
                    sheetWork.Name += "数据";
                    CastExcel.ExportDataToCsv(arrPlot, sheetWork);
                }

                //保存工作薄
                sheetWork.SaveAs(filePath, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            }
            catch (Exception ex)
            {
                //添加错误日志
                //SEHR.BLL.Function.AddMsgLog.AddMsg(LogType.Msg, "生成EXCEL", "Table生成Excel出错", ex.StackTrace);
                CastLog.Logger("CastExcel", "ExportToCsv", ex.Message);
            }
            finally
            {
                //使excel可见
                //appOb.Visible = true;
            }
        }

        /// <summary>
        /// 导出结果
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sheetWork"></param>
        private static void ExportResultToCsv(System.Data.DataTable dt, Worksheet sheetWork)
        {
            if (null == dt && 0 == dt.Rows.Count)
            {
                return;
            }


            //把数据表的各个信息输入到excel表中
            for (int i = 0; i < dt.Columns.Count; i++)//取字段名
            {
                sheetWork.Cells[_currentRow, i + StartColumn] = dt.Columns[i].ColumnName.ToString();
            }
            _currentRow++;

            //取记录值
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sheetWork.Cells[_currentRow, j + StartColumn] = dt.Rows[i][j].ToString();
                }
                _currentRow++;
            }
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="dtPlot"></param>
        /// <param name="sheetWork"></param>
        private static void ExportDataToCsv(System.Data.DataTable dt, Worksheet sheetWork)
        {
            if (null == dt && 0 == dt.Rows.Count)
            {
                return;
            }

            //把数据表的各个信息输入到excel表中
            for (int i = 0; i < dt.Columns.Count; i++)//取字段名
            {
                sheetWork.Cells[1, i + 1] = dt.Columns[i].ColumnName.ToString();
            }

            //取记录值
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sheetWork.Cells[_currentRow, j + 1] = dt.Rows[i][j].ToString();
                }
                _currentRow++;
            }
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="dtPlot"></param>
        /// <param name="sheetWork"></param>
        private static void ExportDataToCsv(ArrayList arr, Worksheet sheetWork)
        {
            if (null == arr && 0 == arr.Count)
            {
                return;
            }

            //把数据表的各个信息输入到excel表中
            _currentRow = 1;
            sheetWork.Cells[_currentRow, 1] = "index";  // "索引";
            sheetWork.Cells[_currentRow, 2] = "minute"; // "时间（分钟）";
            sheetWork.Cells[_currentRow, 3] = "mv"; // "电压（毫伏）";
            //sheetWork.Cells[_currentRow, 4] = "峰宽";
            //sheetWork.Cells[_currentRow, 5] = "设定斜率";
            //sheetWork.Cells[_currentRow, 6] = "漂移";
            //sheetWork.Cells[_currentRow, 7] = "斜率";
            //sheetWork.Cells[_currentRow, 8] = "点的状态";
            //sheetWork.Cells[_currentRow, 9] = "平均斜率";
            //sheetWork.Cells[_currentRow, 10] = "峰的趋势";
            _currentRow++;


            foreach (OriginPointDto dto in arr)
            //foreach (AvgExportDto dto in arr)
            {
                sheetWork.Cells[_currentRow, 1] = dto.Index.ToString();
                sheetWork.Cells[_currentRow, 2] = dto.Moment.ToString();
                sheetWork.Cells[_currentRow, 3] = dto.Voltage.ToString();
                //sheetWork.Cells[_currentRow, 4] = dto.PeakWide.ToString();
                //sheetWork.Cells[_currentRow, 5] = dto.SettingSlope.ToString();
                //sheetWork.Cells[_currentRow, 6] = dto.Drift.ToString();
                //sheetWork.Cells[_currentRow, 7] = dto.Slope.ToString();
                //sheetWork.Cells[_currentRow, 8] = dto.StatusPoint;
                //sheetWork.Cells[_currentRow, 9] = dto.StatusAvgSlope;
                //sheetWork.Cells[_currentRow, 10] = dto.TrendPeak;
                _currentRow++;
            }
        }

        #endregion


        #region 快速导出为Excel文件,未成熟

        //快速保存内存中大量数据到Excel的WorkSheet。关键之处是使用Range一次存储多行多列数据。

        public static void ToXls(ExportFlag exportContent, ArrayList arrPlot, ArrayList arrColName,
                                      ArrayList arrCol, System.Data.DataTable dtResult, string filepath, string bmpPath)
        {


                //switch (exportContent)
                //{
                //    case ExportFlag.Data:
                //        sheetWork.Name = "数据";
                //        _currentRow = 1;
                //        CastExcel.ExportDataToXls(arrPlot, arrColName, arrCol, sheetWork);
                //        break;
                //    case ExportFlag.Result:
                //        sheetWork.Name = "结果";
                //        _currentRow = 1;
                //        CastExcel.ExportResultToCsv(dtResult, sheetWork);
                //        break;
                //    case ExportFlag.All:
                //        sheetWork.Name = "结果-数据";
                //        _currentRow = 1;
                //        CastExcel.ExportResultToCsv(dtResult, sheetWork);
                //        _currentRow++;
                //        CastExcel.ExportDataToXls(arrPlot, arrColName, arrCol, sheetWork);
                //        break;
                //}


                //保存工作薄
                //sheetWork.SaveAs(filepath, missing, missing, missing, missing, missing, missing, missing, missing, missing);

        }

        public static void ToExcel2(ExportFlag exportContent, ArrayList arrPlot, ArrayList arrColName,
                                      ArrayList arrCol, System.Data.DataTable dtResult, string filepath, string bmpPath)
        {


            System.Reflection.Missing miss = System.Reflection.Missing.Value;
            //创建EXCEL对象appExcel,Workbook对象,Worksheet对象,Range对象

            Microsoft.Office.Interop.Excel.Application appExcel;
            appExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbookData;
            Microsoft.Office.Interop.Excel.Worksheet worksheetData;
            Microsoft.Office.Interop.Excel.Range rangedata;

            //设置对象不可见

            appExcel.Visible = false;

            /*  在调用Excel应用程序，或创建Excel工作簿之前，记着加上下面的两行代码
            *  这是因为Excel有一个Bug，如果你的操作系统的环境不是英文的，而Excel就会在执行下面的代码时，报异常。
            */

            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture; 
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            workbookData = appExcel.Workbooks.Add(miss);
            worksheetData = (Microsoft.Office.Interop.Excel.Worksheet)workbookData.Worksheets.Add(miss, miss, miss, miss);

            //给工作表赋名称
            worksheetData.Name = "saved";

            //清零计数并开始计数
            //TimeP = new System.DateTime(0);
            //timer1.Start();
            //label1.Text = TimeP.ToString("HH:mm:ss");

            //  保存到WorkSheet的表头，你应该看到，是一个Cell一个Cell的存储，这样效率特别低，解决的办法是，使用Rang，一块一块地存储到Excel
            ExportDataToCsv(arrPlot, worksheetData);

            //for (int i = 0; i < arrPlot.Count; i++)
            //{
            //    worksheetData.Cells[1, i + 1] = ((AvgExportDto)arrPlot[i]).Columns.HeaderText.ToString();
            //}

            //先给Range对象一个范围为A2开始，Range对象可以给一个CELL的范围，也可以给例如A1到H10这样的范围
            //因为第一行已经写了表头，所以所有数据都应该从A2开始

            rangedata = worksheetData.get_Range("A2", miss);
            Microsoft.Office.Interop.Excel.Range xlRang = null;

            //iRowCount为实际行数，最大行
            int iRowCount = arrPlot.Count;
            int iParstedRow = 0, iCurrSize = 0;

            //iEachSize为每次写行的数值，可以自己设置，每次写1000行和每次写2000行大家可以自己测试下效率
            int iEachSize = 1000;

            //iColumnAccount为实际列数，最大列数
            int iColumnAccount = arrPlot.Count;

            //在内存中声明一个iEachSize×iColumnAccount的数组，iEachSize是每次最大存储的行数，iColumnAccount就是存储的实际列数
            object[,] objVal = new
            object[iEachSize, iColumnAccount];

            try
            {

                //给进度条赋最大值为实际行数最大值
                //progressBar1.Maximum = arrPlot.Count;
                iCurrSize = iEachSize;

                while (iParstedRow < iRowCount)
                {

                    if ((iRowCount - iParstedRow) < iEachSize)
                        iCurrSize = iRowCount - iParstedRow;

                    //用FOR循环给数组赋值
                    //for (int i = 0; i < iCurrSize; i++)
                    //{
                    //    for (int j = 0; j < iColumnAccount; j++)
                    //        objVal[i, j] = gridView[j, i + iParstedRow].Value.ToString();
                    //    progressBar1.Value++;
                    //    System.Windows.Forms.Application.DoEvents();
                    //}

                    /*

                    *  建议使用设置断点研究下哈
                    *  例如A1到H10的意思是从A到H，第一行到第十行
                    *  下句很关键，要保证获取Sheet中对应的Range范围
                    *  下句实际上是得到这样的一个代码语句xlRang  =  worksheetData.get_Range("A2","H100");
                    *  注意看实现的过程
                    *  'A'  +  iColumnAccount  -  1这儿是获取你的最后列，A的数字码为65，大家可以仔细看下是不是得到最后列的字母
                    *  iParstedRow  +  iCurrSize  +  1获取最后行
                    *  若WHILE第一次循环的话这应该是A2,最后列字母+最后行数字
                    *  iParstedRow  +  2要注意，每次循环这个值不一样，他取决于你每次循环RANGE取了多大，循环了几次，也就是iEachSize设置值的大小哦
                    */

                    xlRang = worksheetData.get_Range("A" + ((int)(iParstedRow + 2)).ToString(), 
                        ((char)('A' + iColumnAccount - 1)).ToString() + ((int)(iParstedRow + iCurrSize + 1)).ToString());
                    //  调用Range的Value2属性，把内存中的值赋给Excel

                    xlRang.Value2 = objVal;
                    iParstedRow = iParstedRow + iCurrSize;
                }


                /*参数说明
                FileName                要创建的 OLE 对象的源文件。
                LinkToFile              要链接至的文件。
                SaveWithDocument        图片与文档一起保存。
                Left                    左上角的位置。
                Top                     图片左上角的位置。
                Width                   图片的宽度。
                Height                  图片的高度。
                往EXCEL中添加图片*/
                if (File.Exists(bmpPath))
                {
                    worksheetData.Shapes.AddPicture(bmpPath, MsoTriState.msoCTrue, MsoTriState.msoCTrue, 250, 0, 300, 100);
                }

                //保存工作表

                worksheetData.SaveAs(filepath, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlRang);
                //xlRang = null;
                //progressBar1.Value = 0;
                //调用方法关闭EXCEL进程，大家可以试下不用的话如果程序不关闭在进程里一直会有EXCEL.EXE这个进程并锁定你的EXCEL表格
                //this.KillSpecialExcel(appExcel);
                //timer1.Stop();
                //MessageBox.Show("数据已经成功导出到：" + saveFileDialog.FileName.ToString(), "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                CastLog.Logger("CastExcel", "ToExcel2", ex.Message);
                //timer1.Stop();
                return;
            }
            finally
            {
                #region"销毁Excel进程"
                appExcel.Visible = true;//使excel可见*/

                GC.Collect();
                #endregion
            }
            //  别忘了在结束程序之前恢复你的环境！
            //System.Threading.Thread.CurrentThread.CurrentCulture = CurrentCI;
        }

        #endregion


    }
}
