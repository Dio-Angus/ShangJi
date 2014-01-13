/*-----------------------------------------------------------------------------
//  FILE NAME       : SampleReportViewer.cs
//  FUNCTION        : 样品报告
//  AUTHOR          : 李锋(2009/06/04)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using ChromatoTool.util;
using ChromatoTool.dto;
using ChromatoPrint;
using ChromatoTool.log;
using ChromatoBll.bll;
using System.IO;
using System.Data;
using ChromatoTool.ini;
using System.Text;

namespace ChromatoCore.sample
{
    /// <summary>
    /// 样品报告
    /// </summary>
    public partial class SampleReportViewer : UserControl
    {


        #region 常数

        /// <summary>
        /// 打印表格中的单元格宽度
        /// </summary>
        private const int Cell_Width_ID = 60;

        /// <summary>
        /// 打印表格中的单元格宽度
        /// </summary>
        private const int Cell_Width_Name = 120;

        /// <summary>
        /// 打印表格中的单元格宽度
        /// </summary>
        private const int Cell_Width_ReserveTime = 120;

        /// <summary>
        /// 打印表格中的单元格宽度
        /// </summary>
        private const int Cell_Width_Height = 120;

        /// <summary>
        /// 打印表格中的单元格宽度
        /// </summary>
        private const int Cell_Width_Size = 200;

        /// <summary>
        /// 打印表格中的单元格宽度
        /// </summary>
        private const int Cell_Width_Density = 100;

        /// <summary>
        /// 打印表格中的单元格宽度
        /// </summary>
        private const int Cell_Width_Type = 80;

        /// <summary>
        /// 表头每项内容的最大长度
        /// </summary>
        private const int MaxDistance = 300;

        #endregion 


        #region 变量

        /// <summary>
        /// 样品dto
        /// </summary>
        private ParaDto _dtoPara = null;

        /// <summary>
        /// 绘画内容对象
        /// </summary>
        private PrintDocument _docToPrint = null;

        /// <summary>
        /// 打印工具条管理对象
        /// </summary>
        private PrintMngUser _printManage = null;

        /// <summary>
        /// 显示预览的效果
        /// </summary>
        private PrintPreviewControl _pptReport = null;

        /// <summary>
        /// 方案逻辑，查询方案名
        /// </summary>
        private SolutionBiz _bizSolu = null;

        /// <summary>
        /// 峰结果逻辑
        /// </summary>
        private PeakBiz _bizPeak = null;

        /// <summary>
        /// 页号码
        /// </summary>
        private int _pageNo = 0;

        /// <summary>
        /// 样品结果
        /// </summary>
        private DataSet _dsResult = null;

        /// <summary>
        /// 已经打印表格行数
        /// </summary>
        private int _countPrinted = 0;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SampleReportViewer()
        {
            InitializeComponent();
            this.SetupAll();
        }

        /// <summary>
        /// 全部建立
        /// </summary>
        private void SetupAll()
        {
            this._bizSolu = new SolutionBiz();
            this._bizPeak = new PeakBiz();

            // Associate the event-handling method with the
            // document's PrintPage event.
            this._docToPrint = new PrintDocument();
            this._docToPrint.PrintPage += new PrintPageEventHandler(docToPrint_PrintPage);

            this._printManage = new PrintMngUser();
            this.Controls.Add(this._printManage);

            this.printBar.Document = this._docToPrint;
            this.printBar.PrintMngUser = this._printManage;
            this.printBar.PrintPropertiesChanged += new printPropertiesChanged(this.printBar_PrintPropertiesChanged);

            this.SetupReport();
        }

        /// <summary>
        /// 建立对象
        /// </summary>
        private void SetupReport()
        {

            this._pptReport = new System.Windows.Forms.PrintPreviewControl();
            this._pptReport.Dock = System.Windows.Forms.DockStyle.None;
            this._pptReport.Location = new System.Drawing.Point(0, 25);
            this._pptReport.Name = "pptReport";
            //this.pptReport.Size = new System.Drawing.Size(651, 376);
            this._pptReport.TabIndex = 4;

            this._pptReport.Document = this._docToPrint;

            // Set the zoom to 25 percent.
            this._pptReport.Zoom = 1;  // 0.25;

            // Set the document name. This will show be displayed when 
            // the document is loading into the control.
            this._pptReport.Document.DocumentName = "c:\\someFile";

            // Set the UseAntiAlias property to true so fonts are smoothed
            // by the operating system.
            this._pptReport.UseAntiAlias = true;
            this.printBar.PreviewControl = this._pptReport;
            this.Controls.Add(this._pptReport);
            this.printBar.LoadDefaults();
            this.CtrlResize();

            this._pageNo = 1;
            this._countPrinted = 0;

            //样品结果
            if (null != this._dtoPara)
            {
                this._dsResult = this._bizPeak.LoadPrintPeakResultWithSum(this._dtoPara.PathData);
            }
        }

        #endregion


        #region 方法

        /// <summary>
        /// 装载界面
        /// </summary>
        /// <param name="dto"></param>
        public void LoadUi(ParaDto dto)
        {
            this._dtoPara = dto;
            this.Controls.Remove(this._pptReport);
            this.SetupReport();
        }

        /// <summary>
        /// 改变控件位置
        /// </summary>
        public void CtrlResize()
        {
            this._pptReport.Top = this.printBar.Bottom;
            this._pptReport.Height = this.Height - this.printBar.Height;
            this._pptReport.Width = this.Width;
        }

        /// <summary>
        /// 右对齐
        /// </summary>
        /// <param name="str"></param>
        /// <param name="totalByteCount"></param>
        /// <returns></returns>
        private string PadRightEx(string str, int totalByteCount)
        {
            if (null == str)
            {
                return "";
            }
            Encoding coding = Encoding.GetEncoding("GB18030");
            //Encoding coding = Encoding.GetEncoding(65001);
            int dcount = 0;
            foreach (char ch in str.ToCharArray())
            {
                dcount += coding.GetByteCount(ch.ToString());
            }
            string w = str.PadRight(totalByteCount - dcount);
            return w;
        }

        #endregion


        #region 事件

        /// <summary>
        /// 打印输出内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void docToPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (null == this._dtoPara)
            {
                return;
            }

            float currentPosition = e.MarginBounds.Top;

            if (1 == this._pageNo)
            {
                //输出样品标题和信息
                this.PrintInfo(e, ref currentPosition);
                this.PrintGraph(e, ref currentPosition);
            }

            if (null == this._dsResult || null == this._dsResult.Tables[0])
            {
                e.HasMorePages = false;
                this._countPrinted = 0;
                return;
            }

            this.printDataTable(this._dsResult.Tables[0], e, Convert.ToInt32(currentPosition));
        }

        /// <summary>
        /// 输出样品图形
        /// </summary>
        /// <param name="e"></param>
        /// <param name="currentPosition"></param>
        private void PrintGraph(PrintPageEventArgs e, ref float currentPosition)
        {
            try
            {
                String dir = Application.ExecutablePath;
                int lastindex = dir.LastIndexOf('\\');
                String path = dir.Substring(0, lastindex + 1) + "Bmp\\" + this._dtoPara.RegisterTime.Substring(0,6) + "\\"
                    + this._dtoPara.SampleName
                    + "_" + this._dtoPara.RegisterTime
                    + "_" + this._dtoPara.ChannelID + ".bmp";

                if (File.Exists(path))
                {
                    Image newImage = Image.FromFile(path);

                    // Create parallelogram for drawing image.
                    Point ulCorner = new Point(Convert.ToInt32(e.MarginBounds.Left), Convert.ToInt32(currentPosition));
                    Point urCorner = new Point(Convert.ToInt32(e.MarginBounds.Right), Convert.ToInt32(currentPosition));
                    Point llCorner = new Point(Convert.ToInt32(e.MarginBounds.Left), Convert.ToInt32(currentPosition + 300));
                    Point[] destPara = { ulCorner, urCorner, llCorner };

                    // Draw image to screen.
                    e.Graphics.DrawImage(newImage, destPara);
                    currentPosition += 300;
                }
            }
            catch (Exception ex)
            {
                CastLog.Logger("SampleReportViewer", "docToPrint_PrintPage", String.Format("%s", ex.Message));
            }
        }

        /// <summary>
        /// 输出样品标题和信息
        /// </summary>
        /// <param name="e"></param>
        /// <param name="currentPosition"></param>
        private void PrintInfo(PrintPageEventArgs e, ref float currentPosition)
        {
            String fontName = "宋体";
            Font fontHeader = new Font(fontName, 18, FontStyle.Bold);
            Font fontInfo = new Font(fontName, 10, FontStyle.Regular);

            float categoryHeight = fontHeader.GetHeight(e.Graphics);
            float itemHeight = fontInfo.GetHeight(e.Graphics);

            Brush normalColour = Brushes.Black;
            Brush urgentColour = Brushes.Red;

            Pen thePen = new Pen(Brushes.Black);
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            float printWidth = e.MarginBounds.Width;
            float printHeight = e.MarginBounds.Height;
            float rightMargin = leftMargin + printWidth;
            float numberWidth = 70;
            float lineWidth = printWidth - numberWidth;
            float lineLeft = leftMargin;
            float numberLeft = leftMargin + lineWidth;

            //输出样品标题
            String text = String.Format("{0}", DefaultItem.SoftName);
            float height = TransLateUtil.printLine(e, text, fontHeader, lineLeft + 100, currentPosition, lineWidth, false, Brushes.Black);

            currentPosition += 2 * height;

            //输出样品名和色谱柱型号
            SolutionDto dtoSolu = new SolutionDto();

            RelationDto dtoRela = new RelationDto();
            dtoRela.SampleID = this._dtoPara.SampleID;
            dtoRela.RegisterTime = this._dtoPara.RegisterTime;
            dtoSolu.SolutionID = Convert.ToInt32(this._bizSolu.GetSolutionID(dtoRela));
            if (0 == dtoSolu.SolutionID)
            {
                MessageBox.Show("该样品没有指定方案!", "提示");
                return;
            }
            this._bizSolu.QuerySolu(dtoSolu);
            AnalyParaBiz bizAnaly = new AnalyParaBiz();
            AnalyParaDto dtoAnaly = new AnalyParaDto();
            dtoAnaly.AnalyParaID = dtoSolu.AnalyParaID;
            bizAnaly.GetMethodByID(dtoAnaly);

            String sampleName = String.Format("样品名：{0}",this._dtoPara.SampleName);
            String columnType = String.Format("色谱柱：{0}",dtoAnaly.ColumuModel);

            height = TransLateUtil.printLine(e, sampleName, fontInfo, lineLeft, currentPosition, lineWidth/2, false, Brushes.Black);
            height = TransLateUtil.printLine(e, columnType, fontInfo, lineLeft + MaxDistance, currentPosition, lineWidth / 2, false, Brushes.Black);
            currentPosition += height;

            //输出方案名和柱温类型
            String soluName = this._bizSolu.GetSolutionNameByID(dtoSolu.SolutionID);
            if (String.IsNullOrEmpty(soluName))
            {
                soluName = String.Format("方案名：{0}", "");
            }
            else
            {
                soluName = String.Format("方案名：{0}", soluName);
            }
            AntiControlBiz bizAnti = new AntiControlBiz();
            AntiControlDto dtoAnti = new AntiControlDto();
            dtoAnti.AntiControlID = dtoSolu.AntiMethodID;
            bizAnti.GetMethodByID(dtoAnti);
            String columnStep = String.Format("升温状态：{0}",EnumDescription.GetFieldText((StepType)dtoAnti.dtoHeatingSource .ColumnCount + 1));

            height = TransLateUtil.printLine(e, soluName, fontInfo, lineLeft, currentPosition, lineWidth / 2, false, Brushes.Black);
            height = TransLateUtil.printLine(e, columnStep, fontInfo, lineLeft + MaxDistance, currentPosition, lineWidth / 2, false, Brushes.Black);
            currentPosition += height;

            //输出检测器类型和检测器参数
            String detector = String.Format("检测器：{0}", this._dtoPara.ChannelID);
            String para = "";
            switch (this._dtoPara.ChannelID)
            {
                case IdChannel.Tcd1:
                case GasChannel.A:
                    para = String.Format("初温：{0}℃   电流：{1}mA", dtoAnti.dtoTcd.InitTemp1, dtoAnti.dtoTcd.CurrentOne);
                    break;
                case IdChannel.Tcd2:
                case GasChannel.C:
                    para = String.Format("初温：{0}℃   电流：{1}mA", dtoAnti.dtoTcd.InitTemp2, dtoAnti.dtoTcd.CurrentTwo);
                    break;
                case IdChannel.Fid1:
                case GasChannel.B:
                    para = String.Format("初温：{0}℃   放大倍数：{1}", dtoAnti.dtoFid.InitTemp, EnumDescription.GetFieldText((Magnify)dtoAnti.dtoFid.MagnifyFactorOne));
                    break;
                case IdChannel.Fid2:
                case GasChannel.D:
                    para = String.Format("初温：{0}℃   放大倍数：{1}", dtoAnti.dtoFid.InitTemp, EnumDescription.GetFieldText((Magnify)dtoAnti.dtoFid.MagnifyFactorTwo));
                    break;
            }

            height = TransLateUtil.printLine(e, detector, fontInfo, lineLeft, currentPosition, lineWidth / 2, false, Brushes.Black);
            if (!String.IsNullOrEmpty(para))
            {
                height = TransLateUtil.printLine(e, para, fontInfo, lineLeft + MaxDistance, currentPosition, lineWidth / 2, false, Brushes.Black);
            }
            currentPosition += height;

            //输出样品类型和进样口温度
            String sampleType = String.Format("样品类型：{0}",EnumDescription.GetFieldText(this._dtoPara.SampleType));
            String injectTemp = String.Format("进样口温度：{0}℃", dtoAnti.dtoInject.InitTemp);

            height = TransLateUtil.printLine(e, sampleType, fontInfo, lineLeft, currentPosition, lineWidth / 2, false, Brushes.Black);
            height = TransLateUtil.printLine(e, injectTemp, fontInfo, lineLeft + MaxDistance, currentPosition, lineWidth / 2, false, Brushes.Black);
            currentPosition += 2 * height;
        }

        /// <summary>
        /// 表格形式输出结果
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="e"></param>
        /// <param name="curentPos"></param>
        private void printDataTable(DataTable dt, PrintPageEventArgs e, int curentPos) 
        { 

            //取得对应的Graphics对象 
            Graphics g = e.Graphics;
            int width = 0;
            int height = 0;
            //获得相关页面X坐标、Y坐标、打印区域宽度、长度 
            int x = e.PageSettings.Margins.Left;
            int y = curentPos;
            if (e.PageSettings.Landscape)
            {
                width = e.PageSettings.PaperSize.Height - e.PageSettings.Margins.Left - e.PageSettings.Margins.Right;
                height = e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Top - e.PageSettings.Margins.Bottom;
            }
            else
            {
                width = e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Left - e.PageSettings.Margins.Right;
                height = e.PageSettings.PaperSize.Height - e.PageSettings.Margins.Top - e.PageSettings.Margins.Bottom;
            }
            //定义打印字体 
            Font font = new Font("宋体",10); 

            //rowCount是除去打印过的行数后剩下的行数 
            int rowCount = dt.Rows.Count - this._countPrinted; 

            //maxPageRow是当前设置下该页面可以打印的最大行数 
            int maxPageRow = Convert.ToInt32(( height - curentPos )/ font.GetHeight()); 

            //标题
            int xPixel = x;
            g.DrawString(dt.Columns[(int)PrintItem.Id].ColumnName, font, Brushes.Black, xPixel, y);
            g.DrawString(dt.Columns[(int)PrintItem.Name].ColumnName, font, Brushes.Black, xPixel += Cell_Width_ID, y);
            g.DrawString(dt.Columns[(int)PrintItem.ReserveTime].ColumnName, font, Brushes.Black, xPixel += Cell_Width_Name, y);
            g.DrawString(dt.Columns[(int)PrintItem.Height].ColumnName, font, Brushes.Black, xPixel += Cell_Width_ReserveTime, y);
            g.DrawString(dt.Columns[(int)PrintItem.AreaSize].ColumnName, font, Brushes.Black, xPixel += Cell_Width_Height, y);
            g.DrawString(dt.Columns[(int)PrintItem.Density].ColumnName, font, Brushes.Black, xPixel += Cell_Width_Size, y);
            g.DrawString(dt.Columns[(int)PrintItem.PeakType].ColumnName, font, Brushes.Black, xPixel += Cell_Width_Density, y);

            y += (int)font.GetHeight();
            g.DrawLine(new Pen(Brushes.Black, 1), new Point(x, y), new Point(xPixel += Cell_Width_Type, y)); 

            int countPrintedInPage = 0;

            //判断，如果剩下的行数小于可打印的最大行数，则执行下列代码 
            if( maxPageRow >= rowCount ) 
            {
                //当前行数小于Table内总行数时，循环 
                while(this._countPrinted < dt.Rows.Count) 
                { 

                    //打印每个单元格内的数据 
                    xPixel = x;
                    this.DrawItem(PrintItem.Id, dt.Rows[this._countPrinted][(int)PrintItem.Id].ToString(), font, ref xPixel, y, countPrintedInPage, maxPageRow, g);
                    this.DrawItem(PrintItem.Name, dt.Rows[this._countPrinted][(int)PrintItem.Name].ToString(), font, ref xPixel, y, countPrintedInPage, maxPageRow, g);
                    this.DrawItem(PrintItem.ReserveTime, dt.Rows[this._countPrinted][(int)PrintItem.ReserveTime].ToString(), font, ref xPixel, y, countPrintedInPage, maxPageRow, g);
                    this.DrawItem(PrintItem.Height, dt.Rows[this._countPrinted][(int)PrintItem.Height].ToString(), font, ref xPixel, y, countPrintedInPage, maxPageRow, g);
                    this.DrawItem(PrintItem.AreaSize, dt.Rows[this._countPrinted][(int)PrintItem.AreaSize].ToString(), font, ref xPixel, y, countPrintedInPage, maxPageRow, g);
                    this.DrawItem(PrintItem.Density, dt.Rows[this._countPrinted][(int)PrintItem.Density].ToString(), font, ref xPixel, y, countPrintedInPage, maxPageRow, g);
                    this.DrawItem(PrintItem.PeakType, dt.Rows[this._countPrinted][(int)PrintItem.PeakType].ToString(), font, ref xPixel, y, countPrintedInPage, maxPageRow, g);

                    this._countPrinted ++;
                    countPrintedInPage ++;
                }
            } 
            //判断，如果剩下的行数大于可打印的最大行数，则执行下列代码 
            else 
            {
                int countNewPage = 0;
                do 
                {
                    
                    //打印每个单元格内的数据 
                    xPixel = x;
                    this.DrawItem(PrintItem.Id, dt.Rows[this._countPrinted][(int)PrintItem.Id].ToString(), font, ref xPixel, y, countPrintedInPage, maxPageRow, g);
                    this.DrawItem(PrintItem.Name, dt.Rows[this._countPrinted][(int)PrintItem.Name].ToString(), font, ref xPixel, y, countPrintedInPage, maxPageRow, g);
                    this.DrawItem(PrintItem.ReserveTime, dt.Rows[this._countPrinted][(int)PrintItem.ReserveTime].ToString(), font, ref xPixel, y, countPrintedInPage, maxPageRow, g);
                    this.DrawItem(PrintItem.Height, dt.Rows[this._countPrinted][(int)PrintItem.Height].ToString(), font, ref xPixel, y, countPrintedInPage, maxPageRow, g);
                    this.DrawItem(PrintItem.AreaSize, dt.Rows[this._countPrinted][(int)PrintItem.AreaSize].ToString(), font, ref xPixel, y, countPrintedInPage, maxPageRow, g);
                    this.DrawItem(PrintItem.Density, dt.Rows[this._countPrinted][(int)PrintItem.Density].ToString(), font, ref xPixel, y, countPrintedInPage, maxPageRow, g);
                    this.DrawItem(PrintItem.PeakType, dt.Rows[this._countPrinted][(int)PrintItem.PeakType].ToString(), font, ref xPixel, y, countPrintedInPage, maxPageRow, g);

                    this._countPrinted++;
                    countPrintedInPage ++;
                    countNewPage++;
                } while (countNewPage % maxPageRow > 0); 
            } 

            //显示页码
            this.DrawFooter(e,g);

            //指定HasMorePages值，如果页面最大行数小于剩下的行数，则返回true（还有），否则返回false 
            if(maxPageRow < rowCount) 
            {
                this._pageNo++;
                e.HasMorePages = true;
            } 
            else 
            { 
                e.HasMorePages = false;
                _countPrinted = 0;
                this._pageNo = 1;
            }
        }

        /// <summary>
        /// 打印每一行的数据
        /// </summary>
        /// <param name="item"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="countPrintedInPage"></param>
        /// <param name="maxPageRow"></param>
        /// <param name="g"></param>
        private void DrawItem(PrintItem item, string text, Font font, ref int x, int y, int countPrintedInPage, int maxPageRow, Graphics g)
        {
            switch (item)
            {
                case PrintItem.Id:
                    if (!String.IsNullOrEmpty(text))
                    {
                        g.DrawString(text, font, Brushes.Black, x,
                            y + (countPrintedInPage % maxPageRow) * (int)font.GetHeight() + (int)font.GetHeight());
                    }

                    x += Cell_Width_ID;
                    break;

                case PrintItem.Name:
                    if (!String.IsNullOrEmpty(text))
                    {
                        g.DrawString(text, font, Brushes.Black, x,
                            y + (countPrintedInPage % maxPageRow) * (int)font.GetHeight() + (int)font.GetHeight());
                    }

                    x += Cell_Width_Name;
                    break;

                case PrintItem.ReserveTime:
                    if (!String.IsNullOrEmpty(text))
                    {
                        //保留3位小数
                        text = String.Format("{0:F3}", Convert.ToSingle(text));
                        g.DrawString(text, font, Brushes.Black, x,
                                y + (countPrintedInPage % maxPageRow) * (int)font.GetHeight() + (int)font.GetHeight());
                    }

                    x += Cell_Width_ReserveTime;
                    break;

                case PrintItem.Height:
                    if (!String.IsNullOrEmpty(text))
                    {
                        //保留2位小数
                        text = String.Format("{0:F2}", Convert.ToSingle(text));
                        g.DrawString(text, font, Brushes.Black, x,
                                y + (countPrintedInPage % maxPageRow) * (int)font.GetHeight() + (int)font.GetHeight());
                    }

                    x += Cell_Width_Height;
                    break;

                case PrintItem.AreaSize:
                    if (!String.IsNullOrEmpty(text))
                    {
                        //保留2位小数
                        text = String.Format("{0:F2}", Convert.ToSingle(text));
                        g.DrawString(text, font, Brushes.Black, x,
                                y + (countPrintedInPage % maxPageRow) * (int)font.GetHeight() + (int)font.GetHeight());
                    }

                    x += Cell_Width_Size;
                    break;

                case PrintItem.Density:
                    if (!String.IsNullOrEmpty(text))
                    {
                        //保留4位小数
                        text = String.Format("{0:F6}", Convert.ToSingle(text));
                        g.DrawString(text, font, Brushes.Black, x,
                                y + (countPrintedInPage % maxPageRow) * (int)font.GetHeight() + (int)font.GetHeight());
                    }

                    x += Cell_Width_Density;
                    break;

                case PrintItem.PeakType:
                    if (!String.IsNullOrEmpty(text))
                    {
                        g.DrawString(text, font, Brushes.Black, x,
                                y + (countPrintedInPage % maxPageRow) * (int)font.GetHeight() + (int)font.GetHeight());
                    }

                    x += Cell_Width_Type;
                    break;

            }
        }

        /// <summary>
        /// 显示页码
        /// </summary>
        /// <param name="e"></param>
        /// <param name="g"></param>
        private void DrawFooter(PrintPageEventArgs e, Graphics g)
        {

            // Writing the Page Number on the Bottom of Page
            String pageNum = " 第 " + this._pageNo.ToString() + " 页";
            Font pageNoFont = new Font("宋体", 10);

            //横方向
            float x = e.MarginBounds.Left + (e.MarginBounds.Width - g.MeasureString(pageNum, pageNoFont, e.MarginBounds.Width).Width) / 2;
            float y = e.MarginBounds.Top + e.MarginBounds.Height;

            g.DrawString(pageNum, pageNoFont, Brushes.Black, x, y);
        }

        /// <summary>
        /// 打印属性改变后的事件
        /// </summary>
        private void printBar_PrintPropertiesChanged()
        {
            //If the the print properties change (orientation, margins etc)
            // we need to re-create the report with the new parameters.
            this.Controls.Remove(this._pptReport);
            this.SetupReport();
        }

        #endregion

    }
}
