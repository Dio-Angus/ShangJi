/*-----------------------------------------------------------------------------
//  FILE NAME       : CastCdf.cs
//  FUNCTION        : 数据导出到NetCdf工具
//  AUTHOR          : XCAST 蔡海鹰(2009/12/09)
//  CHANGE LOG      :
//  FLAG               DATE        WHO      DESCRIPTION
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


using System;
using ucar.nc2;
using ucar.ma2;
using ChromatoTool.dto;
using ChromatoTool.ini;
using System.Windows.Forms;

namespace ChromatoTool.util
{
    /// <summary>
    /// 数据导出到NetCdf工具
    /// </summary>
    public class CastCdf
    {

        #region 方法

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="arrPlot"></param>
        /// <param name="dtResult"></param>
        /// <param name="filePath"></param>
        public static void ExportToCdf(System.Collections.ArrayList arrPlot,
                                       System.Data.DataTable dtResult, string filePath)
        {
            try
            {
                CastCdf.Export(arrPlot, filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 导出ArrayList到NetCdf
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="filepath"></param>
        private static void Export(System.Collections.ArrayList arr, string filepath)
        {
            
            NetcdfFileWriteable ncfile = new NetcdfFileWriteable();

            ncfile.setName(filepath);
            Dimension timeDim = ncfile.addDimension("time", arr.Count);
            Dimension valtageDim = ncfile.addDimension("valtage", arr.Count);

            Dimension[] dim2 = new Dimension[2];
            dim2[0] = timeDim;
            dim2[1] = valtageDim;


            ncfile.addVariable("chromato", java.lang.Float.TYPE, dim2);
            ncfile.addVariableAttribute("chromato", "long_name", "voltage");
            ncfile.addVariableAttribute("chromato", "units", "mV");

            ncfile.addGlobalAttribute("title", "Chromato Data");
            ncfile.create();

            Console.WriteLine("ncfile = " + ncfile);

            ArrayFloat value = new ArrayFloat.D2(arr.Count, 2);

        
            Index ima = value.getIndex();
            OriginPointDto dto = null;
            for (int i = 0; i < arr.Count; i++)
            {
                dto = (OriginPointDto)arr[i];
                //dto = (AvgExportDto)arr[i];
                value.setFloat(ima.set(i, 0), dto.Moment);
                value.setFloat(ima.set(i, 1), dto.Voltage);
            }


            if (ExportFlag.Solution)
            {
                //ncfile.write("chromato", value);
            }
            else if (ExportFlag.Result)
            {
                //ncfile.write("chromato", value);
            }
            else if (ExportFlag.Data)
            {
                ncfile.write("chromato", value);
            }

            
            ncfile.close();

        }

        #endregion

    }
}
