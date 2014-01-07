/*-----------------------------------------------------------------------------
//  FILE NAME       : SizeDensityViewer.cs
//  FUNCTION        : 面积浓度视图
//  AUTHOR          : 李锋(2009/06/24)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Windows.Forms;
using ChromatoBll.ocx;
using ChromatoTool.ini;
using ChromatoTool.pipe;
using System.Collections;
using ChromatoBll.bll;

namespace ChromatoCore.solu.IdT
{
    /// <summary>
    /// 面积浓度视图
    /// </summary>
    public partial class SizeDensityViewer : UserControl
    {

        #region 变量

        /// <summary>
        /// 图形逻辑层
        /// </summary>
        private IdTableCorrectGraphBiz _bizCorrectGraph = null;

        #endregion 


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SizeDensityViewer()
        {
            InitializeComponent();
            this._bizCorrectGraph = new IdTableCorrectGraphBiz();
            this.SetPipeName(PipeBiz.Instance._correctPipe._pipeFullName);
            this.CreateLayer(ChannelID.correct, UserType.osc, PipeBiz.Instance._correctPipe);
        }

        #endregion 


        #region 方法

        /// <summary>
        /// 创建显示引擎
        /// </summary>
        /// <param name="lf"></param>
        /// <param name="user"></param>
        /// <param name="pipe"></param>
        public void CreateLayer(ChannelID lf, UserType user, CastPipe pipe)
        {
            this._bizCorrectGraph.CreateLayer(lf, user, this.axGraphOcx, pipe);
        }

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="pipeFullName"></param>
        public void SetPipeName(string pipeFullName)
        {
            this.axGraphOcx.FullPipeName = pipeFullName;
        }

        /// <summary>
        /// 从数据库装载数据
        /// </summary>
        /// <param name="arrPoly"></param>
        /// <param name="arrSimu"></param>
        /// <returns></returns>
        public bool LoadCorrectPoint(ArrayList arrPoly, ArrayList arrSimu)
        {
            //显示图形
            this._bizCorrectGraph._bizCorrectPoint.LoadInit();
            this._bizCorrectGraph._bizCorrectPoint.LoadCorrectPlot(arrPoly, arrSimu);

            ////隐藏十字光标
            //this._bizCorrectGraph._bizArrow.UnvisibleArrow();

            ////更新谱图属性
            this._bizCorrectGraph._bizZoom.SetFullGObj();
            return true;
        }

        /// <summary>
        /// 改变大小
        /// </summary>
        public void OcxResize()
        {
            if (this._bizCorrectGraph._isLayerCreated)
            {
                this._bizCorrectGraph._bizResize.GraphResize(0, 0,
                    this.Width, this.Height,
                    0, 0);
                //this._bizCorrectGraph._bizArrow.UpdateArrow();
            }
        }

        #endregion
    }
}
