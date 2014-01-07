/*-----------------------------------------------------------------------------
//  FILE NAME       : TransSimuBiz.cs
//  FUNCTION        : 通过命名管道传输模拟数据到2D控件
//  AUTHOR          : 李锋(2009/03/01)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Threading;
using ChromatoTool.pipe;
using ChromatoTool.dto;
using ChromatoTool.ini;
using ChromatoTool.log;
using AxGRAPHOCXLib;
using ChromatoBll.serialCom;


namespace ChromatoBll.ocx.biz
{
    /// <summary>
    /// 通过命名管道传输模拟数据到2D控件
    /// </summary>
    public sealed class TransSimuBiz : TransBaseBiz
    {


        #region 变量

        /// <summary>
        /// 管道写数据线程
        /// </summary>
        private Thread _pWriteThread = null;

        /// <summary>
        /// 模拟在线送数据的线程
        /// </summary>
        private Thread _pOnlineThread = null;

        /// <summary>
        /// 模拟在线送数据线程运行标志,true,部分发送数据列表, false 全部发送
        /// </summary>
        private volatile bool _isRunOnline = false;

        /// <summary>
        /// 采集状态,是否保存模拟数据到数据库
        /// </summary>
        public volatile bool _isSaveToDb = false;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="pipe"></param>
        /// <param name="ocx"></param>
        public TransSimuBiz(CastPipe pipe, AxGraphOcx ocx)
            : base(pipe, ocx)
        {
        }

      
        #endregion


        #region 模拟制造数据的处理

        /// <summary>
        /// 启动制造数据线程
        /// </summary>
        public void StartSimuThread(CollectionDto dtoCol)
        {
            base._dtoCollect = dtoCol;

            if (this._isRunOnline)
            {
                return;
            }

            //启动模拟制造数据线程
            CastLog.bHasList = true;

            _pOnlineThread = new Thread(new ThreadStart(SimuOnlineThread));
            _pOnlineThread.IsBackground = true;
            _pOnlineThread.Name = String.Format("Simu Online Thread Start");
            _pOnlineThread.Start();// 启动线程,进行通信
            _isRunOnline = true;
        }

        /// <summary>
        /// 模拟制造数据线程
        /// </summary>
        private void SimuOnlineThread()
        {

            DateTime dt = DateTime.Now;
            string tempTime = string.Format("SimuOnlineThread Start: {0}:{1}:{2} {3}:{4}:{5} {6}",
                dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            CastLog.Logger("TransSimuBiz", "SimuOnlineThread", tempTime);


            //增加了dt.Second  <---------------- By Chencong
            DateTime dtStart = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            DateTime dtRealStart = DateTime.Now;

            //间隔1s
            TimeSpan waitTime = new TimeSpan(0, 0, 0, 1, 0);

            double remainMs = 0;

            int count = 0;

            double dStart = 0;
            double dEnd = 0;

            _axsX.FloatFigure = 3;
            _axsY.FloatFigure = 1;

            _plot.DataCount = 0;

            int nEclipseCount = 0;
            Single needCount = 0;
            double sLastTime = 0;

            _arrChannel.Clear();

            // main loop
            while (this._isRunOnline)
            {
                if (null != this._pWriteThread && this._pWriteThread.IsAlive)
                {
                    CastLog.Logger("TransSimuBiz", "SimuOnlineThread", "_pWriteThread IsAlive, waitting");
                    Thread.Sleep(100);
                    continue;
                }

                // 制造数据
                this.GeneratePlot(ref dStart, ref dEnd, ref sLastTime, ref nEclipseCount);

                // 传送数据
                //this.TransByPipe(0, 0, count);
                this.TransByPipeWithoutThread(0, 0, count);

                // 调整属性
                if (_area.LeftValue != dStart)
                {
                    _area.LeftValue = dStart;
                    _axsX.StartValue = dStart;
                }

                if (_area.RightValue != dEnd)
                {
                    _area.RightValue = dEnd;
                    _axsX.EndValue = dEnd;
                }

                //_bizPlot.ShowMarker(0, 0, true);

                //计算可以使用的时间
                dtStart = dtStart + waitTime;

                // have a rest
                remainMs = (dtStart - DateTime.Now).TotalMilliseconds;
                if (0 < remainMs)
                {
                    Thread.Sleep(Convert.ToInt32(remainMs));
                    tempTime = String.Format("SimuOnlineThread->Sleep {0} ms ", Convert.ToString(remainMs));
                    //CastLog.Logger("TransSimuBiz", "SimuOnlineThread", tempTime);
                }
                else
                {
                    dt = DateTime.Now;
                    //增加了dt.Second  <---------------- By Chencong
                    dtStart = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
                }


                // 达到停止时间,停止线程
                //CastLog.Logger("TransSimuBiz", "SimuOnlineThread", String.Format("eclipse time = {0}", (DateTime.Now - dtRealStart).TotalMilliseconds));
                needCount = _dtoCollect.StopTime * Convert.ToSingle(General.Frequent) * Convert.ToSingle(DefaultItem.SecondsPerMin);
                //CastLog.Logger("TransSimuBiz", "SimuOnlineThread", String.Format("needCount = {0}, EclipseCount = {1}", needCount, nEclipseCount));
                if (Convert.ToInt32(needCount) <= nEclipseCount)
                {
                    if (RealStatus.SimuCollecting == CommPort.Instance.GetRealStatus(ChannelID.A) &&
                        this._idChannel == ChannelID.A)
                        break;
                    if (RealStatus.SimuCollecting == CommPort.Instance.GetRealStatus(ChannelID.B) &&
                       this._idChannel == ChannelID.B)
                        break;
                }
            }

            //保存剩余数据
            this.SaveToDb(base._arrChannel.Count, this._isSaveToDb);

            dt = DateTime.Now;
            tempTime = string.Format("SimuOnlineThread Finished: {0}:{1}:{2} {3}:{4}:{5} {6}",
                dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            CastLog.Logger("TransSimuBiz", "SimuOnlineThread", tempTime);
        }

        /// <summary>
        /// 制造数据
        /// </summary>
        private void GeneratePlot(ref double dStart, ref double dEnd, ref double dLastTime, ref int nEclipseCount)
        {
            OriginPointDto dto = null;
            Random rd = new Random();

            DateTime dtTemp = DateTime.Now;

            for (int i = 0; i < Convert.ToInt32(General.Frequent); i++)
            {
                dto = new OriginPointDto();

                dto.Moment = Convert.ToSingle(dLastTime) +
                    Convert.ToSingle(i + 1) / Convert.ToSingle(General.Frequent) / 
                    Convert.ToSingle(DefaultItem.SecondsPerMin);

                switch (General.PlotType)
                {
                    case SimuType.Sin:

                        dto.Voltage = Convert.ToSingle(Math.Sin(
                            dto.Moment * Convert.ToSingle(DefaultItem.SecondsPerMin)));
                        break;
                    case SimuType.Random:

                        dto.Voltage = Convert.ToSingle(rd.NextDouble());
                        break;
                    case SimuType.SinRandom:

                        dto.Voltage = Convert.ToSingle(Math.Sin(
                            dto.Moment * Convert.ToSingle(DefaultItem.SecondsPerMin))
                            + rd.NextDouble() / 10.0);
                        break;
                }

                dto.Index = nEclipseCount;
                //dto.SampleID = base._dbName;
                _arrChannel.Add(dto);
                nEclipseCount ++;
            }

            dLastTime = dto.Moment;
            string consumed = String.Format("{0} point Generate data time:{1} ms",
                nEclipseCount, (DateTime.Now - dtTemp).TotalMilliseconds);
            Console.Out.WriteLine(consumed);

            //半屏点数
            int screenCountHalf = Convert.ToInt32(_dtoCollect.FullScreenTime * General.Frequent * DefaultItem.SecondsPerMin / 2.0);
            int temp = Convert.ToInt32(nEclipseCount / screenCountHalf) * screenCountHalf;

            // 显示区域起点值
            dStart = 0 < temp ? (temp - screenCountHalf) / General.Frequent / DefaultItem.SecondsPerMin : 0;

            // 显示区域终点值
            dEnd = dStart + _dtoCollect.FullScreenTime;

        }

        /// <summary>
        /// 关闭线程
        /// </summary>
        public void CloseSimuThread()
        {
            //スレッドを閉じる
            if (this._isRunOnline)
            {
                CastLog.bHasList = false;
                this._isRunOnline = false;
                Thread.Sleep(100); 
                
                _pOnlineThread.Join();	//block until exits
                _pOnlineThread = null;
            }
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

            if (this._isRunOnline)
            {
                // 实时传输
                _ocx.AddPlotByPipe(this._plot.id, Convert.ToInt32(General.Frequent), count);
            }
        }

        /// <summary>
        /// 管道内写入大量数据的线程
        /// </summary>
        private void WriteProcess()
        {
            DateTime timeStart = DateTime.Now;
            OriginPointDto dto = null;
            int startPoint = 0;

            if (this._isRunOnline)
            {
                startPoint = _arrChannel.Count - Convert.ToInt32(General.Frequent);
                Console.Out.WriteLine(String.Format("startPoint = {0}", startPoint));
            }

            try
            {
                lock (_arrChannel.SyncRoot)
                {
                    for (int i = startPoint; i < _arrChannel.Count; i++)
                    {
                        // send module instruction one
                        dto = (OriginPointDto)_arrChannel[i];

                        //顺序写曲线x轴的数据
                        _pipeCast.WriteFloat(dto.Moment);
                        //顺序写曲线y轴的数据
                        _pipeCast.WriteFloat(dto.Voltage);
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
                Console.Out.WriteLine(String.Format("线程 {0} point {1} time:{2} ms",
                    _pWriteThread.Name, _arrChannel.Count, (DateTime.Now - timeStart).TotalMilliseconds));
            }

        }

        /// <summary>
        /// 通过Pipe设置曲线
        /// </summary>
        /// <param name="GraphID"></param>
        /// <param name="indexID"></param>
        /// <param name="count"></param>
        private void TransByPipeWithoutThread(int GraphID, int indexID, int count)
        {
            DateTime timeStart = DateTime.Now;
            OriginPointDto dto = null;
            int startPoint = 0;

            if (this._isRunOnline)
            {
                startPoint = _arrChannel.Count - Convert.ToInt32(General.Frequent);
                Console.Out.WriteLine(String.Format("startPoint = {0}", startPoint));
            }

            lock (_arrChannel.SyncRoot)
            {
                for (int i = startPoint; i < _arrChannel.Count; i++)
                {
                    // send module instruction one
                    dto = (OriginPointDto)_arrChannel[i];

                    //顺序写曲线x轴的数据
                    _pipeCast.WriteFloat(dto.Moment);
                    //顺序写曲线y轴的数据
                    _pipeCast.WriteFloat(dto.Voltage);
                }

                if (this._isRunOnline)
                {
                    //自动斜率
                    base.CacuAutoSlope(startPoint, this._arrChannel);
                }

                //保存数据到数据库
                if (General.SaveMaxCount <= this._arrChannel.Count)
                {
                    this.SaveToDb(base._arrChannel.Count, this._isSaveToDb);
                }
            }

            if (this._isRunOnline)
            {
                // 实时传输
                _ocx.AddPlotByPipe(this._plot.id, Convert.ToInt32(General.Frequent), count);
            }
        }


        #endregion



    }
}
