/*-----------------------------------------------------------------------------
//  FILE NAME       : CorrectPointBiz.cs
//  FUNCTION        : ID表校正点的显示处理
//  AUTHOR          : 李锋(2009/06/24)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoBll.ocx.item;
using AxGRAPHOCXLib;
using System.Threading;
using ChromatoTool.pipe;
using System.Collections;
using ChromatoTool.dto;
using ChromatoTool.ini;

namespace ChromatoBll.ocx.biz
{
    /// <summary>
    /// ID表校正点的显示处理
    /// </summary>
    public sealed class CorrectPointBiz : TransBaseBiz
    {

        #region 常量

        /// <summary>
        /// 多点校正曲线ID
        /// </summary>
        private const Int32 PloyID = 0;

        /// <summary>
        /// 拟和直线ID
        /// </summary>
        private const Int32 SimuID = 1;

        #endregion 


        #region 变量

        /// <summary>
        /// 管道写数据线程
        /// </summary>
        private Thread _pWriteThread = null;

        /// <summary>
        /// 数量
        /// </summary>
        private volatile Int32 _valueCount = 0;

        /// <summary>
        /// 拟和直线对象
        /// </summary>
        private PlotImp _plotSimu = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="pipe"></param>
        /// <param name="ocx"></param>
        public CorrectPointBiz(CastPipe pipe, AxGraphOcx ocx)
            : base(pipe, ocx)
        {
        }

        #endregion


        #region 方法

        /// <summary>
        /// 创建拟和直线对象
        /// </summary>
        public void LoadInit()
        {
            //创建拟和直线对象
            if (null == this._plotSimu)
            {
                this._plotSimu = new PlotImp(base._ocx);
                this._plotSimu.id = base._ocx.AddItem(base._plot.id);
            }
        }

        /// <summary>
        /// 从数据文件装载数据
        /// </summary>
        public void LoadCorrectPlot(ArrayList arrPloy, ArrayList arrSimu)
        {
            Double maxY = 0;
            Double minY = 0;
            Double maxX = 0;
            Double minX = 0;


            if (null == arrPloy || 0 == arrPloy.Count)
            {
                return;
            }

            this._plot.DataCount = 0;
            if (null != this._plot.arr)
            {
                this._plot.arr.Clear();
            }
            else
            {
                this._plot.arr = new ArrayList();
            }

            foreach (CalibrateDto dto in arrPloy)
            {
                if (maxY < dto.DensityTemp)
                    maxY = dto.DensityTemp;
                if (minY > dto.DensityTemp)
                    minY = dto.DensityTemp;

                if (maxX < dto.SizeHeight)
                    maxX = dto.SizeHeight;
                if (minX > dto.SizeHeight)
                    minX = dto.SizeHeight;
                this._plot.arr.Add(dto);
            }

            this._plotSimu.DataCount = 0;
            if (null != this._plotSimu.arr)
            {
                this._plotSimu.arr.Clear();
            }
            else
            {
                this._plotSimu.arr = new ArrayList();
            }
            foreach (CalibrateDto dto in arrSimu)
            {
                if (maxY < dto.DensityTemp)
                    maxY = dto.DensityTemp;
                if (minY > dto.DensityTemp)
                    minY = dto.DensityTemp;

                if (maxX < dto.SizeHeight)
                    maxX = dto.SizeHeight;
                if (minX > dto.SizeHeight)
                    minX = dto.SizeHeight;
                this._plotSimu.arr.Add(dto);
            }

            _area.LeftValue = minX;
            _area.RightValue = maxX;

            _axsX.StartValue = minX;
            _axsX.EndValue = maxX;

            _axsX.FloatFigure = 2;
            _axsY.FloatFigure = 2;

            _area.TopValue = Convert.ToDouble(maxY + 1);
            _axsY.EndValue = _area.TopValue;

            _area.BottomValue = Convert.ToDouble(minY - 1);
            _axsY.StartValue = _area.BottomValue;

            this._axsX.UnitName = "面  积";
            this._axsY.UnitName = "浓  度";

            this.LoadSimuLine();
            this.LoadPolyLine();

        }

        /// <summary>
        /// 装载多点校正曲线
        /// </summary>
        private void LoadPolyLine()
        {
            DateTime timeStart = DateTime.Now;

            base._plot.Show = !this._plotSimu.Show;

            this._plot.ShowMarker = true;
            this._plot.MarkerSize = 5;
            this._plot.MarkerBorderwidth = 2;
            this._plot.MarkerTransparent = true;
            this._plot.DatalineStyle = 2;
            this._plot.DatalineWidth = 2;

            if (0 == base._plot.arr.Count)
            {
                return;
            }

            this._valueCount = this._plot.arr.Count;

            this._arrChannel = this._plot.arr;

            this.TransByPipe(base._plot, _valueCount);

            string consumed = String.Format("{0} point Transmit time:{1} ms",
                this._plot.arr.Count, (DateTime.Now - timeStart).TotalMilliseconds);
            Console.Out.WriteLine(consumed);
        }

        /// <summary>
        /// 装载拟和直线
        /// </summary>
        private void LoadSimuLine()
        {
            DateTime timeStart = DateTime.Now;

            this._plotSimu.Show = (0 == this._plotSimu.arr.Count) ? false : true;

            this._plotSimu.ShowMarker = false;// (0 == this._plotSimu.arr.Count) ? false : true;
            this._plotSimu.MarkerSize = 5;
            this._plotSimu.MarkerBorderwidth = 2;
            this._plotSimu.MarkerTransparent = true;
            this._plotSimu.DatalineStyle = 2;
            this._plotSimu.DatalineWidth = 2;

            if (0 == this._plotSimu.arr.Count)
            {
                return;
            }

            this._valueCount = this._plotSimu.arr.Count;

            this._arrChannel = this._plotSimu.arr;

            this.TransByPipe(this._plotSimu, _valueCount);

            string consumed = String.Format("{0} point Transmit time:{1} ms",
                this._plotSimu.arr.Count, (DateTime.Now - timeStart).TotalMilliseconds);
            Console.Out.WriteLine(consumed);
        }

        /// <summary>
        /// 通过Pipe设置曲线
        /// </summary>
        /// <param name="plot"></param>
        /// <param name="count"></param>
        private void TransByPipe(PlotImp plot, int count)
        {

            if (null != _pWriteThread)
            {
                _pWriteThread.Join();
                _pWriteThread = null;
            }
            _pWriteThread = new Thread(new ThreadStart(WriteProcess));
            _pWriteThread.IsBackground = true;
            _pWriteThread.Name = String.Format("Pipe Write Thread: {0} count", count);
            _pWriteThread.Start();// 启动线程,进行通信

            // 加载历史曲线
            this._ocx.SetPlotByPipe(plot.id, count);
        }

        /// <summary>
        /// 管道内写入大量数据的线程
        /// </summary>
        private void WriteProcess()
        {
            DateTime timeStart = DateTime.Now;
            CalibrateDto dto = null;

            try
            {
                lock (_arrChannel.SyncRoot)
                {
                    for (int i = 0; i < _arrChannel.Count; i++)
                    {
                        // send module instruction one
                        dto = (CalibrateDto)_arrChannel[i];

                        //顺序写曲线x轴的数据
                        _pipeCast.WriteFloat(dto.SizeHeight);
                        //顺序写曲线y轴的数据
                        _pipeCast.WriteFloat(dto.DensityTemp);
                        //顺序写该点的显示风格
                        _pipeCast.WriteInt((int)PeakTrend.Flat);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
            }
            finally
            {
                Console.Out.WriteLine(String.Format("线程 {0} 退出！", _pWriteThread.Name));
                Console.Out.WriteLine(String.Format("{0} point {1} time:{2} ms", _valueCount,
                    _pWriteThread.Name, (DateTime.Now - timeStart).TotalMilliseconds));
            }
        }

        #endregion


    }
}
