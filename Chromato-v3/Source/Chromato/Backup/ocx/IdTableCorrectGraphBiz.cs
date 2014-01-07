/*-----------------------------------------------------------------------------
//  FILE NAME       : IdTableCorrectGraphBiz.cs
//  FUNCTION        : 用于ID表校准的图形逻辑
//  AUTHOR          : 李锋(2009/06/24)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using ChromatoTool.ini;
using ChromatoBll.ocx.biz;
using ChromatoTool.pipe;
using AxGRAPHOCXLib;
using System.Drawing;
using ChromatoBll.bto;

namespace ChromatoBll.ocx
{
    /// <summary>
    /// 用于ID表校准的图形逻辑
    /// </summary>
    public class IdTableCorrectGraphBiz
    {


        #region 图形引擎变量

        /// <summary>
        /// 离线显示层
        /// </summary>
        private LayerBto dtoCorrectLayer { get; set; }

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
        public TransHisBiz _bizTransHis
        {
            get { return (TransHisBiz)dtoCorrectLayer._bizTrans; }
            set { ; }
        }

        /// <summary>
        /// 控件大小改变逻辑
        /// </summary>
        public ResizeBiz _bizResize
        {
            get { return dtoCorrectLayer._bizResize; }
            set { ; }
        }

        /// <summary>
        /// 图形放大缩小逻辑
        /// </summary>
        public ZoomPlotBiz _bizZoom
        {
            get { return dtoCorrectLayer._bizZoom; }
            set { ; }
        }

        /// <summary>
        /// 十字光标逻辑
        /// </summary>
        public ArrowLineBiz _bizArrow
        {
            get { return dtoCorrectLayer._bizArrow; }
            set { ; }
        }

        /// <summary>
        /// 保留时间逻辑
        /// </summary>
        public ReserveTimeBiz _bizReserveTime
        {
            get { return dtoCorrectLayer._bizReserveTime; }
            set { ; }
        }

        /// <summary>
        /// 基线逻辑
        /// </summary>
        public BaseLineBiz _bizBaseline
        {
            get { return dtoCorrectLayer._bizBaseline; }
            set { ; }
        }

        /// <summary>
        /// 导出逻辑
        /// </summary>
        public ExportBmpBiz _bizExportBmp
        {
            get { return dtoCorrectLayer._bizExportBmp; }
            set { ; }
        }

        /// <summary>
        /// 导出逻辑
        /// </summary>
        public CorrectPointBiz _bizCorrectPoint
        {
            get { return dtoCorrectLayer._bizCorrectPoint; }
            set { ; }
        }

        #endregion


        #region 构造析构

        /// <summary>
        /// 构造
        /// </summary>
        public IdTableCorrectGraphBiz()
        {

        }

        /// <summary>
        /// 析构
        /// </summary>
        ~IdTableCorrectGraphBiz()
        {
            if (null != this.dtoCorrectLayer && null != this.dtoCorrectLayer._bizTransSimu)
            {
                this.dtoCorrectLayer._bizTransSimu.CloseSimuThread();
            }
        }

        #endregion


        #region 方法

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
                case ChannelID.correct:
                    dtoCorrectLayer = new LayerBto(lf, user, ocx, pipe);
                    this._isLayerCreated = true;
                    break;
            }
        }

        /// <summary>
        /// 取得背景色
        /// </summary>
        /// <returns></returns>
        public Color GetBkColor()
        {
            return this.dtoCorrectLayer.ocx.BackWndColor;
        }

        /// <summary>
        /// 设置背景色
        /// </summary>
        /// <param name="bkColor"></param>
        public void SetBkColor(Color bkColor)
        {
            this.dtoCorrectLayer.ocx.BackWndColor = bkColor;
        }

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
