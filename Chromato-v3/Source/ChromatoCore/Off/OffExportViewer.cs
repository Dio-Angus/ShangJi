/*-----------------------------------------------------------------------------
//  FILE NAME       : OffExportViewer.cs
//  FUNCTION        : 离线分析的导出画面
//  AUTHOR          : 李锋(2009/04/14)
//  CHANGE LOG      : 李锋(2009/07/09)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using ChromatoTool.util;
using System.IO;
using ChromatoTool.ini;
using ChromatoTool.log;
using ChromatoTool.dto;
using ChromatoBll.bll;

namespace ChromatoCore.Off
{
    /// <summary>
    /// 离线分析的导出画面
    /// </summary>
    public partial class OffExportViewer : UserControl
    {


        #region 变量

        /// <summary>
        /// 导出类型标志
        /// </summary>
        private ExportType _typeExport = ExportType.Csv;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OffExportViewer()
        {
            InitializeComponent();
            this.LoadUi();
            this.LoadEvent();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {

            switch (this._typeExport)
            {
                case ExportType.Excel:
                    this.rbExcel.Checked = true;
                    break;

                case ExportType.Csv:
                    this.rbCsv.Checked = true;
                    break;

                case ExportType.AIA:
                    this.rbAia.Checked = true;
                    break;
            }

            this.cbxSolution.Checked = ExportFlag.Solution ? true : false;
            this.cbxResult.Checked = ExportFlag.Result ? true : false;
            this.cbxPlot.Checked = ExportFlag.Data ? true : false;
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.cbxSolution.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
            this.cbxPlot.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
            this.cbxResult.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
        }

        #endregion


        #region 方法

        /// <summary>
        /// 导出DataTable为XLS
        /// </summary>
        /// <param name="dtPlot"></param>
        /// <param name="dto"></param>
        /// <param name="dtResult"></param>
        /// <param name="dtoSoluExport"></param>
        private void ExportToXls(System.Data.DataTable dtPlot, ParaDto dto, 
            System.Data.DataTable dtResult, SolutionExportDto dtoSoluExport)
        {
            ArrayList arrCol = new ArrayList();
            ArrayList arrColName = new ArrayList();

            arrCol.Insert(0, "Index");
            arrCol.Insert(1, "Moment");
            arrCol.Insert(2, "Voltage");

            arrColName.Insert(0, "索引");
            arrColName.Insert(1, "时间");
            arrColName.Insert(2, "电压");

            String dir = Application.ExecutablePath;
            int lastindex = dir.LastIndexOf('\\');
            String temp = dir.Substring(0, lastindex + 1) + "Xls\\" + dto.RegisterTime.Substring(0, 6) + "\\";
            if (!Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }

            String path = temp + dto.SampleName
                + "_" + dto.RegisterTime 
                + "_" + dto.ChannelID + ".xls";
            
            String bmpPath = dir.Substring(0, lastindex + 1) + "Bmp\\"
                + dto.RegisterTime.Substring(0, 6) + "\\"
                + dto.SampleName
                + "_" + dto.RegisterTime
                + "_" + dto.ChannelID + ".bmp";

            CastExcel.ExportToXls(dtPlot, arrColName, arrCol, dtResult, path, bmpPath);
            MessageBox.Show(String.Format("{0}:导出完成!", path), "导出到EXCEL");
        }

        /// <summary>
        /// 导出为DataTable为CSV
        /// </summary>
        /// <param name="dtPlot"></param>
        /// <param name="dto"></param>
        /// <param name="dtResult"></param>
        /// <param name="dtoSoluExport"></param>
        private void ExportToCsv(System.Data.DataTable dtPlot, ParaDto dto,
            System.Data.DataTable dtResult, SolutionExportDto dtoSoluExport)
        {
            String dir = Application.ExecutablePath;
            int lastindex = dir.LastIndexOf('\\');
            dir = dir.Substring(0, lastindex + 1) + "Csv\\" + dto.RegisterTime.Substring(0, 6) + "\\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            String path = dir
                + dto.SampleName
                + "_" + dto.RegisterTime
                + "_" + dto.ChannelID + ".csv";

            CastExcel.ExportToCsv(dtPlot, dtResult, path);
            MessageBox.Show(String.Format("{0}:导出完成!", path), "导出到CSV");
        }

        /// <summary>
        /// 导出DataTable为AIA
        /// </summary>
        /// <param name="dtPlot"></param>
        /// <param name="dto"></param>
        /// <param name="dtResult"></param>
        /// <param name="dtoSoluExport"></param>
        private void ExportToAIA(System.Data.DataTable dtPlot, ParaDto dto, 
            System.Data.DataTable dtResult, SolutionExportDto dtoSoluExport)
        {

        }

        /// <summary>
        /// 导出ArrayList为CSV
        /// </summary>
        /// <param name="arrPlot"></param>
        /// <param name="dto"></param>
        /// <param name="dt"></param>
        /// <param name="dtoSoluExport"></param>
        private void ExportToCsv(ArrayList arrPlot, ParaDto dto, DataTable dt, 
                                SolutionExportDto dtoSoluExport)
        {
            String dir = Application.ExecutablePath;
            int lastindex = dir.LastIndexOf('\\');
            dir = dir.Substring(0, lastindex + 1) + "Csv\\" + dto.RegisterTime.Substring(0, 6) + "\\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            String path = dir
                + dto.SampleName
                + "_" + dto.RegisterTime
                + "_" + dto.ChannelID + ".csv";

            CastLog.Logger("OffExportViewer", "ExportToCsv", path);
            //CastExcel.ExportToCsv(this._contentExport, arrPlot, dt, path);
            CsvStreamWriter.ExportToCsv(arrPlot, dt, path, dtoSoluExport);

            MessageBox.Show(String.Format("{0}:导出完成!", path), "导出到CSV");
        }

        /// <summary>
        /// 导出ArrayList为AIA
        /// </summary>
        /// <param name="arrPlot"></param>
        /// <param name="dto"></param>
        /// <param name="dtResult"></param>
        /// <param name="dtoSoluExport"></param>
        private void ExportToAIA(ArrayList arrPlot, ParaDto dto, DataTable dtResult, 
                                SolutionExportDto dtoSoluExport)
        {
            String dir = Application.ExecutablePath;
            int lastindex = dir.LastIndexOf('\\');
            dir = dir.Substring(0, lastindex + 1) + "Aia\\" + dto.RegisterTime.Substring(0, 6) + "\\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            String path = dir
                + dto.SampleName
                + "_" + dto.RegisterTime
                + "_" + dto.ChannelID + ".cdf";

            CastLog.Logger("OffExportViewer", "ExportToAIA", path);
            CastCdf.ExportToCdf(arrPlot, dtResult, path);

            MessageBox.Show(String.Format("{0}:导出完成!", path), "导出到AIA");
        }

        /// <summary>
        /// 导出ArrayList为XLS
        /// </summary>
        /// <param name="arrPlot"></param>
        /// <param name="dto"></param>
        /// <param name="dtResult"></param>
        /// <param name="dtoSoluExport"></param>
        private void ExportToXls(ArrayList arrPlot, ParaDto dto, DataTable dtResult, 
                                SolutionExportDto dtoSoluExport)
        {
            ArrayList arrCol = new ArrayList();
            ArrayList arrColName = new ArrayList();

            arrCol.Insert(0, "Index");
            arrCol.Insert(1, "Moment");
            arrCol.Insert(2, "Voltage");

            arrColName.Insert(0, "索引");
            arrColName.Insert(1, "时间");
            arrColName.Insert(2, "电压");

            String dir = Application.ExecutablePath;
            int lastindex = dir.LastIndexOf('\\');
            String temp = dir.Substring(0, lastindex + 1) + "Xls\\" + dto.RegisterTime.Substring(0, 6) + "\\";
            if (!Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }
            String path = temp
                + dto.SampleName
                + "_" + dto.RegisterTime
                + "_" + dto.ChannelID + ".xls";

            String bmpPath = dir.Substring(0, lastindex + 1) + "Bmp\\"
                + dto.RegisterTime.Substring(0, 6) + "\\"
                + dto.SampleName
                + "_" + dto.RegisterTime
                + "_" + dto.ChannelID + ".bmp";

            CastExcel.ExportToXls(arrPlot, arrColName, arrCol, dtResult, path, bmpPath);
            //CastExcel.ToExcel2(this._flagExport, arrPlot, arrColName, arrCol, dtResult, path, bmpPath);
            
            MessageBox.Show(String.Format("{0}:导出完成!", path), "导出到EXCEL");
        }

        /// <summary>
        /// 把DataSet导出到Excel按钮按下事件
        /// </summary>
        /// <param name="dsPlot"></param>
        /// <param name="dto"></param>
        /// <param name="dsResult"></param>
        public void ExportToFile(DataSet dsPlot, ParaDto dto, DataSet dsResult)
        {
            if (!ExportFlag.Solution && !ExportFlag.Result && !ExportFlag.Data)
            {
                MessageBox.Show("导出内容为空！", "提示");
                return;
            }

            // 平均数据集合
            DataTable dtPlot = null;
            if (null != dsPlot && null != dsPlot.Tables[0] && 0 < dsPlot.Tables[0].Rows.Count)
            {
                dtPlot = dsPlot.Tables[0];
            }

            // 结果集合
            DataTable dtResult = null;
            if (null != dsResult && null != dsResult.Tables[0] && 0 < dsResult.Tables[0].Rows.Count)
            {
                dtResult = dsResult.Tables[0];
            }

            SolutionExportDto dtoSoluExport = new SolutionExportDto();
            this.GetSolution(dto, dtoSoluExport);

            switch (this._typeExport)
            {
                case ExportType.Excel:
                    this.ExportToXls(dtPlot, dto, dtResult, dtoSoluExport);
                    break;

                case ExportType.Csv:
                    this.ExportToCsv(dtPlot, dto, dtResult, dtoSoluExport);
                    break;

                case ExportType.AIA:
                    this.ExportToAIA(dtPlot, dto, dtResult, dtoSoluExport);
                    break;
            }
        }

        /// <summary>
        /// 取得关联的方案信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="dtoSoluExport"></param>
        private void GetSolution(ParaDto dto, SolutionExportDto dtoSoluExport)
        {
            dtoSoluExport.InnerWeight = dto.InnerWeight;
            dtoSoluExport.SampleWeight = dto.SampleWeight;

            SolutionDto dtoSolu = new SolutionDto();
            SolutionBiz bizSolu = new SolutionBiz();
            RelationDto dtoRela = new RelationDto();

            dtoRela.SampleID = dto.SampleID;
            dtoRela.RegisterTime = dto.RegisterTime;
            dtoSolu.SolutionID = Convert.ToInt32(bizSolu.GetSolutionID(dtoRela));
            if (0 == dtoSolu.SolutionID)
            {
                MessageBox.Show("该样品没有指定方案!", "提示");
                return;
            }
            bizSolu.QuerySolu(dtoSolu);
            if (0 == dtoSolu.AnalyParaID)
            {
                MessageBox.Show("该样品没有指定方案!", "提示");
                return;
            }
            //查询分析方法的具体内容
            AnalyParaBiz bizAnaly = new AnalyParaBiz();
            AnalyParaDto dtoAnaly = new AnalyParaDto();
            dtoAnaly.AnalyParaID = dtoSolu.AnalyParaID;
            bizAnaly.GetMethodByID(dtoAnaly);
            dtoSoluExport._dtoAnalyPara = dtoAnaly;

            //是否使用时间程序
            dtoSoluExport._isUseTp = dtoSolu.IsUseTimeProc;
            if (dtoSolu.IsUseTimeProc)
            {
                //查询时间程序的具体内容
                TimeProcDto dtoTimeProc = new TimeProcDto();
                TimeProcBiz bizTimeProc = new TimeProcBiz();
                dtoTimeProc.TPid = dtoSolu.TimeProcID;
                DataSet ds = bizTimeProc.LoadTimeProcByID(dtoTimeProc);
                dtoSoluExport._timeProc = bizTimeProc.GetTpArray();
            }

            //传入ID表
            IngredientBiz bizIngre = new IngredientBiz();
            bizIngre.LoadIngredientByID(dtoSolu.IDTableID);
            dtoSoluExport._arrIngre = bizIngre.GetIngreArry();
            dtoSoluExport._arrCali = new ArrayList();
            CalibrateBiz bizCali = new CalibrateBiz();
            bizCali.ResetArray(dtoSolu.IDTableID);
            IngredientDto dtoIngre = null;
            for (int i = 0; i < dtoSoluExport._arrIngre.Count; i++)
            {
                dtoIngre = (IngredientDto)dtoSoluExport._arrIngre[i];
                dtoSoluExport._arrCali.Add(bizCali.LoadCalibrateInArray(dtoIngre));
            }

            switch (dtoAnaly.ArithmaticID)
            {
                case Arithmatic.Inner:
                    if (0 == dtoSoluExport.InnerWeight)
                    {
                        MessageBox.Show("该样品的内标量为0!", "提示");
                    }
                    break;
                case Arithmatic.Outer:
                case Arithmatic.Exponent:
                    if (0 == dtoSoluExport.SampleWeight)
                    {
                        MessageBox.Show("该样品的样品量为0!", "提示");
                    }
                    if (0 == dtoSoluExport.InnerWeight)
                    {
                        MessageBox.Show("该样品的内标量为0!", "提示");
                    }
                    break;
            }
        }

        /// <summary>
        /// 把DArrayList导出到Excel按钮按下事件
        /// </summary>
        /// <param name="arrPlot"></param>
        /// <param name="dto"></param>
        /// <param name="dsResult"></param>
        public void ExportToFile(ArrayList arrPlot, ParaDto dto, DataSet dsResult)
        {
            if (!ExportFlag.Solution && !ExportFlag.Result && !ExportFlag.Data)
            {
                MessageBox.Show("导出内容为空！", "提示");
                return;
            }

            // 结果集合
            DataTable dt = null;
            if (null != dsResult && null != dsResult.Tables[0] && 0 < dsResult.Tables[0].Rows.Count)
            {
                dt = dsResult.Tables[0];
            }

        　　//方案集合
            SolutionExportDto dtoSoluExport = new SolutionExportDto();
            this.GetSolution(dto, dtoSoluExport);

            switch (this._typeExport)
            {
                case ExportType.Excel:
                    this.ExportToXls(arrPlot, dto, dt, dtoSoluExport);
                    break;

                case ExportType.Csv:
                    this.ExportToCsv(arrPlot, dto, dt, dtoSoluExport);
                    break;

                case ExportType.AIA:
                    this.ExportToAIA(arrPlot, dto, dt, dtoSoluExport);
                    break;
            }
        }

        #endregion


        #region 事件

        /// <summary>
        /// Excel按钮按下处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbExcel_CheckedChanged(object sender, EventArgs e)
        {
            this._typeExport = ExportType.Excel;
            this.cbxSolution.Enabled = false;
        }

        /// <summary>
        /// Csv按钮按下处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbCsv_CheckedChanged(object sender, EventArgs e)
        {
            this._typeExport = ExportType.Csv;
            this.cbxSolution.Enabled = true;
        }

        /// <summary>
        /// AIA按钮按下处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbAia_CheckedChanged(object sender, EventArgs e)
        {
            this._typeExport = ExportType.AIA;
            this.cbxSolution.Enabled = false;
        }

        /// <summary>
        /// 数据，结果按钮按下处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_CheckedChanged(object sender, EventArgs e)
        {
            ExportFlag.Solution = (this.cbxSolution.Checked) ? true : false;
            ExportFlag.Data = (this.cbxPlot.Checked) ? true : false;
            ExportFlag.Result = (this.cbxResult.Checked) ? true : false;
        }

        #endregion

    }
}
