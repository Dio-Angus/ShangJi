/*-----------------------------------------------------------------------------
//  FILE NAME       : TransHisBiz.cs
//  FUNCTION        : 通过命名管道传输历史数据到2D控件
//  AUTHOR          : 李锋(2009/04/02)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.pipe;
using AxGRAPHOCXLib;
using System.Threading;
using ChromatoTool.dto;
using ChromatoTool.ini;

namespace ChromatoBll.ocx.biz
{
    /// <summary>
    /// 传输历史数据
    /// </summary>
    public class TransHisBiz : TransBaseBiz
    {

        #region 变量

        /// <summary>
        /// 管道写数据线程
        /// </summary>
        private Thread _pWriteThread = null;

        /// <summary>
        /// 数量
        /// </summary>
        public volatile Int32 _valueCount = 0;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="pipe"></param>
        /// <param name="ocx"></param>
        public TransHisBiz(CastPipe pipe, AxGraphOcx ocx)
            : base(pipe, ocx)
        {
        }

        #endregion


        #region 数据文件装载

        /// <summary>
        /// 从数据文件装载数据
        /// </summary>
        public void LoadAvgPlot()
        {

            DateTime timeStart = DateTime.Now;

            if (null == base._plot.arr)
            {
                return;
            }
            this._valueCount = base._plot.arr.Count;

            lock (_arrChannel.SyncRoot)
            {
                this._arrChannel = base._plot.arr;
            }

            this.TransByPipe(0, 0, _valueCount);

            string consumed = String.Format("{0} point Transmit time:{1} ms",
                base._plot.arr.Count, (DateTime.Now - timeStart).TotalMilliseconds);
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
                lock (_arrChannel.SyncRoot)
                {
                    for (int i = startPoint; i < _arrChannel.Count; i++)
                    {
                        // send module instruction one
                        dto = (AvgPointDto)_arrChannel[i];

                        //顺序写曲线x轴的数据
                        _pipeCast.WriteFloat(dto.Moment);
                        //顺序写曲线y轴的数据
                        _pipeCast.WriteFloat(dto.Voltage);

                        //顺序写该点的峰趋势
                        _pipeCast.WriteInt((int)dto.TrendPeak);
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

        /// <summary>
        /// 重新加载曲线
        /// </summary>
        public void ResetPlot(int count)
        {

            DateTime timeStart = DateTime.Now;

            this._valueCount = count;
            Random rd = new Random();
            AvgPointDto dto = null;

            lock (_arrChannel.SyncRoot)
            {
                _arrChannel.Clear();
                for (int i = 0; i < _valueCount; i++)
                {
                    dto = new AvgPointDto();
                    switch (Offline.PlotType)
                    {
                        case SimuType.Sin:

                            dto.Moment = Convert.ToSingle(i) / Convert.ToSingle(General.Frequent) / Convert.ToSingle(DefaultItem.SecondsPerMin);
                            dto.Voltage = Convert.ToSingle(Math.Sin(Convert.ToSingle(i) / Convert.ToSingle(General.Frequent)));
                            break;
                        case SimuType.Random:

                            dto.Moment = Convert.ToSingle(i) / Convert.ToSingle(General.Frequent) / Convert.ToSingle(DefaultItem.SecondsPerMin);
                            dto.Voltage = Convert.ToSingle(rd.NextDouble());
                            break;
                        case SimuType.SinRandom:

                            dto.Moment = Convert.ToSingle(i) / Convert.ToSingle(General.Frequent) / Convert.ToSingle(DefaultItem.SecondsPerMin);
                            dto.Voltage = Convert.ToSingle(Math.Sin(Convert.ToSingle(i) / Convert.ToSingle(General.Frequent)) + rd.NextDouble() / 10.0);
                            break;

                    }
                    _arrChannel.Add(dto);
                }
                this._plot.arr = this._arrChannel;

            }

            string consumed = String.Format("{0} point Generate data time:{1} ms", count, (DateTime.Now - timeStart).TotalMilliseconds);
            Console.Out.WriteLine(consumed);

            timeStart = DateTime.Now;
            this.TransByPipe(0, 0, _valueCount);

            consumed = String.Format("{0} point Transmit time:{1} ms", count, (DateTime.Now - timeStart).TotalMilliseconds);
            Console.Out.WriteLine(consumed);


        }


        #endregion

    }
}
