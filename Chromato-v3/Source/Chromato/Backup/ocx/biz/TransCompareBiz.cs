/*-----------------------------------------------------------------------------
//  FILE NAME       : TransCompareBiz.cs
//  FUNCTION        : 通过命名管道传输历史比较数据到2D控件
//  AUTHOR          : 李锋(2009/07/29)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.pipe;
using AxGRAPHOCXLib;
using System.Threading;
using ChromatoTool.dto;
using System.Collections;
using ChromatoBll.ocx.item;
using ChromatoTool.util;
using System.Drawing;
using ChromatoTool.ini;

namespace ChromatoBll.ocx.biz
{
    /// <summary>
    /// 通过命名管道传输历史比较数据到2D控件
    /// </summary>
    public sealed class TransCompareBiz
    {

        #region 常量

        /// <summary>
        /// 缩放整个长度的倍数
        /// </summary>
        private const Single ZoomTimes = 200;

        #endregion


        #region 变量

        /// <summary>
        /// 管道写数据线程
        /// </summary>
        private Thread _pWriteThread = null;

        /// <summary>
        /// 管道实例
        /// </summary>
        private CastPipe _pipeCast { get; set; }

        /// <summary>
        /// ocx
        /// </summary>
        private AxGraphOcx _ocx { get; set; }

        /// <summary>
        /// PlotImp图形对象列表
        /// </summary>
        private ArrayList _arrPlot = null;

        /// <summary>
        /// 当前操作曲线
        /// </summary>
        private PlotImp _plot = null;

        /// <summary>
        /// X轴
        /// </summary>
        public AxisXImp _axsX = null;

        /// <summary>
        /// Y轴
        /// </summary>
        public AxisYImp _axsY = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="pipe"></param>
        /// <param name="ocx"></param>
        /// <param name="arr"></param>
        public TransCompareBiz(CastPipe pipe, AxGraphOcx ocx, ArrayList arr)
        {
            this._pipeCast = pipe;
            this._ocx = ocx;
            this._arrPlot = arr;
        }

        #endregion


        #region 传递数据

        /// <summary>
        /// 从数据文件装载数据
        /// </summary>
        public void LoadAvgPlot(ArrayList arr)
        {
            DateTime timeStart = DateTime.Now;

            if (null == this._plot || null == arr)
            {
                return;
            }

            this._plot.arr = arr;

            this.TransByPipe(0, 0, this._plot.arr.Count);

            string consumed = String.Format("{0} point Transmit time:{1} ms",
                this._plot.arr.Count, (DateTime.Now - timeStart).TotalMilliseconds);

            Console.Out.WriteLine(consumed);
        }

        /// <summary>
        /// 通过Pipe设置曲线
        /// </summary>
        /// <param name="GraphID"></param>
        /// <param name="indexID"></param>
        /// <param name="count"></param>
        private void TransByPipe(int GraphID, int indexID, int count)
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
           this._ocx.SetPlotByPipe(this._plot.id, count);

        }

        /// <summary>
        /// 管道内写入大量数据的线程
        /// </summary>
        private void WriteProcess()
        {
            DateTime timeStart = DateTime.Now;
            AvgPointDto dto = null;
            int startPoint = 0;

            try
            {
                lock (this._plot.arr.SyncRoot)
                {
                    for (int i = startPoint; i < this._plot.arr.Count; i++)
                    {
                        // send module instruction one
                        dto = (AvgPointDto)this._plot.arr[i];

                        //顺序写曲线x轴的数据
                        _pipeCast.WriteFloat(dto.Moment);
                        //顺序写曲线y轴的数据
                        _pipeCast.WriteFloat(dto.Voltage);
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
            }
        }

        #endregion


        #region 曲线相关方法

        /// <summary>
        /// 初期装载曲线列表，获取曲线id
        /// </summary>
        /// <param name="arr"></param>
        public void LoadInit(ArrayList arr)
        {
            //创建曲线对象
            PlotImp old = (PlotImp)this._arrPlot[0];
            PlotImp newPlot = null;
            for (int i = this._arrPlot.Count; i < arr.Count; i++)
            {
                newPlot = new PlotImp(this._ocx);
                newPlot.id = this._ocx.AddItem(old.id); //add one line for zoom horizotal,vertical
                this._arrPlot.Add(newPlot);
            }

            //保存曲线对象的id
            CompareDto dto = null;
            for (int i = 0; i < arr.Count; i++)
            {
                dto = (CompareDto)arr[i];
                newPlot = (PlotImp)this._arrPlot[i];
                dto.id = newPlot.id;
                newPlot.DatalineColor = CastColor.GetCustomColor(Color.FromArgb(dto.ForeColor));
                newPlot.Show = dto.IsShow;
                newPlot.isUsed = true;
                newPlot.DataCount = 0;
            }
        }

        /// <summary>
        /// 设置当前操作曲线
        /// </summary>
        /// <param name="id"></param>
        public void SetCurrentPlot(Int32 id)
        {
            foreach (PlotImp plot in this._arrPlot)
            {
                if (plot.id == id)
                {
                    this._plot = plot;
                    break;
                }
            }
        }

        /// <summary>
        /// 改变曲线颜色
        /// </summary>
        /// <param name="dto"></param>
        public void ChangePlotColor(CompareDto dto)
        {
            foreach (PlotImp plot in this._arrPlot)
            {
                if (plot.id == dto.id)
                {
                    plot.DatalineColor = CastColor.GetCustomColor(Color.FromArgb(dto.ForeColor));
                    break;
                }
            }
        }

        /// <summary>
        /// 初期装载曲线列表，获取曲线id
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="arr"></param>
        public void AppendPlot(CompareDto dto, ArrayList arr)
        {
            //创建曲线对象
            PlotImp old = (PlotImp)this._arrPlot[0];
            PlotImp newPlot = null;
            for (int i = this._arrPlot.Count; i < arr.Count; i++)
            {
                newPlot = new PlotImp(this._ocx);
                newPlot.id = this._ocx.AddItem(old.id); //add one line for zoom horizotal,vertical
                this._arrPlot.Add(newPlot);
            }

            //查询无用对象
            foreach (PlotImp plot in this._arrPlot)
            {
                if (!plot.isUsed)
                {
                    dto.id = plot.id;
                    plot.DatalineColor = CastColor.GetCustomColor(Color.FromArgb(dto.ForeColor));
                    plot.isUsed = true;
                    plot.Show = dto.IsShow;
                    break;
                }
            }
        }

        /// <summary>
        /// 从曲线列表中移出某个项目
        /// </summary>
        /// <param name="itemId"></param>
        public void RemovePlot(Int32 itemId)
        {
            foreach (PlotImp plot in this._arrPlot)
            {
                if (plot.id == itemId)
                {
                    plot.DataCount = 0;
                    plot.isUsed = false;

                    break;
                }
            }
        }

        /// <summary>
        /// 改变曲线是否显示属性
        /// </summary>
        /// <param name="dto"></param>
        public void ChangePlotShow(CompareDto dto)
        {
            foreach (PlotImp plot in this._arrPlot)
            {
                if (plot.id == dto.id)
                {
                    plot.Show = dto.IsShow;
                    break;
                }
            }
        }

        #endregion


        #region 曲线移动

        /// <summary>
        /// 移动选中的曲线
        /// </summary>
        /// <param name="direction"></param>
        public void Move(MoveDirection direction)
        {
            if (this._arrPlot.Count == 0)
            {
                return;
            }

            //取得曲线对象
            if (null == this._plot || null == this._plot.arr || 0 == this._plot.arr.Count)
            {
                return;
            }

            //取得数据
            //this._plot.arr = plotChoose.arr;

            //清空
            this._plot.DataCount = 0;

            Single diffY = Convert.ToSingle((this._axsY.EndValue - this._axsY.StartValue)) / ZoomTimes;
            Single diffX = Convert.ToSingle((this._axsX.EndValue - this._axsX.StartValue)) / ZoomTimes;

            switch (direction)
            {
                case MoveDirection.Up:
                    foreach (AvgPointDto dto in this._plot.arr)
                    {
                        dto.Voltage = dto.Voltage + diffY;
                    } 
                    break;
                case MoveDirection.Down:
                    foreach (AvgPointDto dto in this._plot.arr)
                    {
                        dto.Voltage = dto.Voltage - diffY;
                    }
                    break;
                case MoveDirection.Left:
                    foreach (AvgPointDto dto in this._plot.arr)
                    {
                        dto.Moment = dto.Moment - diffX;
                    }
                    break;
                case MoveDirection.Right:
                    foreach (AvgPointDto dto in this._plot.arr)
                    {
                        dto.Moment = dto.Moment + diffX;
                    }
                    break;
            }


            //重新传递数据
            this.TransByPipe(0, 0, this._plot.arr.Count);
        }

        #endregion

    }
}
