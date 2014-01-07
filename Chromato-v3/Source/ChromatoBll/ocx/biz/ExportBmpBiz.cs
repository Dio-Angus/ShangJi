/*-----------------------------------------------------------------------------
//  FILE NAME       : ExportBmpBiz.cs
//  FUNCTION        : 2D控件中导出位图的处理
//  AUTHOR          : 李锋(2009/06/09)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using AxGRAPHOCXLib;
using ChromatoTool.dto;
using System.Windows.Forms;
using System.IO;

namespace ChromatoBll.ocx.biz
{
    /// <summary>
    /// 2D控件中导出位图的处理
    /// </summary>
    public sealed class ExportBmpBiz
    {

        #region 变量

        /// <summary>
        /// ocx
        /// </summary>
        public AxGraphOcx _ocx { get; set; }

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public ExportBmpBiz()
        {
        }

        #endregion


        #region 方法

        /// <summary>
        /// 请求控件导出位图
        /// </summary>
        public void NeedExportImage(ParaDto dto)
        {
            String dir = Application.ExecutablePath;
            int lastindex = dir.LastIndexOf('\\');
            dir = dir.Substring(0, lastindex + 1) + "Bmp\\" + dto.RegisterTime.Substring(0, 6) + "\\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            String path = dir
                + dto.SampleName
                + "_" + dto.RegisterTime
                + "_" + dto.ChannelID + ".bmp";
            this._ocx.ExportImage( path );
        }

        #endregion

    }
}
