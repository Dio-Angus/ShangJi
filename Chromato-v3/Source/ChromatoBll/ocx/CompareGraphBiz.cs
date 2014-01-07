/*-----------------------------------------------------------------------------
//  FILE NAME       : CompareGraphBiz.cs
//  FUNCTION        : 用于谱图比较的图形逻辑
//  AUTHOR          : 李锋(2009/07/28)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Drawing;
using AxGRAPHOCXLib;
using ChromatoTool.ini;
using ChromatoBll.ocx.biz;
using ChromatoTool.pipe;
using ChromatoBll.bto;

namespace ChromatoBll.ocx
{
    /// <summary>
    /// 用于谱图比较的图形逻辑
    /// </summary>
    public sealed class CompareGraphBiz
    {

        #region 图形引擎变量

        /// <summary>
        /// 离线显示层
        /// </summary>
        private LayerBto dtoHisLayer { get; set; }

        /// <summary>
        /// 在线离线标志
        /// </summary>
        public ChannelID _currentLF { get; set; }

        /// <summary>
        /// 显示引擎创建标志
        /// </summary>
        public bool _isLayerCreated { get; set; }

        #endregion


        #region 属性变量

        /// <summary>
        /// 离线传输逻辑
        /// </summary>
        public TransCompareBiz _bizTransCompare
        {
            get { return (TransCompareBiz)dtoHisLayer._bizTransCompare; }
            set { ; }
        }

        /// <summary>
        /// 控件大小改变逻辑
        /// </summary>
        public CompareResizeBiz _bizResize
        {
            get { return dtoHisLayer._bizCompareResize; }
            set { ; }
        }

        /// <summary>
        /// 图形放大缩小逻辑
        /// </summary>
        public ZoomPlotBiz _bizZoom
        {
            get { return dtoHisLayer._bizZoom; }
            set { ; }
        }

        /// <summary>
        /// 十字光标逻辑
        /// </summary>
        public ArrowLineBiz _bizArrow
        {
            get { return dtoHisLayer._bizArrow; }
            set { ; }
        }

        /// <summary>
        /// 保留时间逻辑
        /// </summary>
        public ReserveTimeBiz _bizReserveTime
        {
            get { return dtoHisLayer._bizReserveTime; }
            set { ; }
        }

        /// <summary>
        /// 基线逻辑
        /// </summary>
        public BaseLineBiz _bizBaseline
        {
            get { return dtoHisLayer._bizBaseline; }
            set { ; }
        }

        /// <summary>
        /// 导出逻辑
        /// </summary>
        public ExportBmpBiz _bizExportBmp
        {
            get { return dtoHisLayer._bizExportBmp; }
            set { ; }
        }

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public CompareGraphBiz()
        {

        }

        /// <summary>
        /// 创建显示层
        /// </summary>
        /// <param name="lf"></param>
        /// <param name="user"></param>
        /// <param name="ocx"></param>
        /// <param name="pipe"></param>
        public void CreateLayer(ChannelID lf, UserType user, AxGraphOcx ocx, CastPipe pipe)
        {
            switch (lf)
            {
                case ChannelID.compare:
                    dtoHisLayer = new LayerBto(lf, user, ocx, pipe);
                    this._isLayerCreated = true;
                    break;
            }
        }

        #endregion


        #region 改变背景色

        /// <summary>
        /// 取得背景色
        /// </summary>
        /// <returns></returns>
        public Color GetBkColor()
        {
            return this.dtoHisLayer.ocx.BackWndColor;
        }

        /// <summary>
        /// 设置背景色
        /// </summary>
        /// <param name="bkColor"></param>
        public void SetBkColor(Color bkColor)
        {
            this.dtoHisLayer.ocx.BackWndColor = bkColor;
        }
        #endregion


        #region 图形缩放

        /// <summary>
        /// 设置放大缩小状态
        /// </summary>
        /// <param name="zs"></param>
        public void SetZoomState(ZoomStatus zs)
        {
            this._bizZoom.SetZoomState(zs);
        }

        /// <summary>
        /// 是否是非放大缩小状态
        /// </summary>
        /// <returns></returns>
        public bool IsNormalState()
        {
            return this._bizZoom.IsNormalState();
        }

        #endregion
    }
}