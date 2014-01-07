/*-----------------------------------------------------------------------------
//  FILE NAME       : TransBaseBiz.cs
//  FUNCTION        : 通过命名管道传输数据的基类
//  AUTHOR          : 李锋(2009/04/10)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using ChromatoTool.pipe;
using ChromatoBll.ocx.item;
using AxGRAPHOCXLib;
using ChromatoBll.dao;
using System;
using System.Windows.Forms;
using System.IO;
using ChromatoTool.ini;
using ChromatoTool.dto;
using System.Collections;


namespace ChromatoBll.ocx.biz
{
    /// <summary>
    /// 传输基类
    /// </summary>
    public class TransBaseBiz
    {


        #region 变量

        /// <summary>
        /// 管道实例
        /// </summary>
        public CastPipe _pipeCast { get; set; }

        /// <summary>
        /// 区域item
        /// </summary>
        public AreaImp _area { get; set; }

        /// <summary>
        /// X轴item
        /// </summary>
        public AxisXImp _axsX { get; set; }

        /// <summary>
        /// Y轴item
        /// </summary>
        public AxisYImp _axsY { get; set; }

        /// <summary>
        /// plot
        /// </summary>
        public PlotImp _plot { get; set; }

        /// <summary>
        /// ocx
        /// </summary>
        public AxGraphOcx _ocx { get; set; }

        /// <summary>
        /// 概要保存
        /// </summary>
        private ParaDao _daoPara = null;

        /// <summary>
        /// 在线采集方法
        /// </summary>
        public CollectionDto _dtoCollect = null;

        /// <summary>
        /// 数据保存路径
        /// </summary>
        public string _dbPath = "";

        /// <summary>
        /// 数据保存路径
        /// </summary>
        public string _dbName = "";

        /// <summary>
        /// 数据保存
        /// </summary>
        private OriginPointDao _daoPointInfo = null;

        /// <summary>
        /// 采集的原始数据列表,传输后清空
        /// </summary>
        public ArrayList _arrChannel = null;

        /// <summary>
        ///自动斜率事件
        /// </summary>
        public event EventHandler<OnAutoSlopeActionArgs> AutoSlopeActioned = null;

        /// <summary>
        /// 实时电压事件
        /// </summary>
        public event EventHandler<OnVoltageActionArgs> ShowVoltageActioned = null;

        /// <summary>
        /// 自动完成采集事件
        /// </summary>
        public event EventHandler<OnAutoStopActionArgs> AutoStopActioned = null;

        /// <summary>
        /// 自动停止使用的样品id
        /// </summary>
        private String _sampleId = null;

        /// <summary>
        /// 自动停止使用的通道id
        /// </summary>
        public ChannelID _idChannel = ChannelID.A;

        /// <summary>
        /// 样品的注册时间
        /// </summary>
        public String _registerTime = null;

        /// <summary>
        /// 样品名
        /// </summary>
        public String _sampleName = null;

        /// <summary> 
        /// 跨线程控件代理
        /// </summary> 
        private delegate void CrossThreadOperationControl();

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="pipe"></param>
        /// <param name="ocx"></param>
        public TransBaseBiz(CastPipe pipe, AxGraphOcx ocx)
        {
            this._pipeCast = pipe;
            this._ocx = ocx;
            this._daoPara = new ParaDao();
            this._daoPointInfo = new OriginPointDao();
            this._arrChannel = new ArrayList();
        }

        #endregion


        #region 方法

        /// <summary>
        /// 重新设置传输点
        /// </summary>
        public void CreateDb(ParaDto dtoPara)
        {

            dtoPara.CollectTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            this._dbPath = dtoPara.PathData;

            dtoPara.UserID = "cai";
            dtoPara.Remark = "";

            _daoPara.UpdatePara(dtoPara);

            //自动停止使用
            this._sampleId = dtoPara.SampleID;

            //自动停止使用,实时显示时间电压使用
            switch (dtoPara.ChannelID)
            {
                case GasChannel.A:
                case IdChannel.Tcd1:
                    this._idChannel = ChannelID.A;
                    break;
                case GasChannel.B:
                case IdChannel.Fid1:
                    this._idChannel = ChannelID.B;
                    break;
                case GasChannel.C:
                case IdChannel.Tcd2:
                    this._idChannel = ChannelID.C;
                    break;
                case GasChannel.D:
                case IdChannel.Fid2:
                    this._idChannel = ChannelID.D;
                    break;
                default:
                    //this._idChannel = dtoPara.ChannelID;
                    break;
            }
            //注册时间
            this._registerTime = dtoPara.RegisterTime;
            //样品名
            this._sampleName = dtoPara.SampleName;

            this.CopyFile(this._dbPath);
        }

        /// <summary>
        /// 复制标准文件到\db下
        /// </summary>
        /// <param name="expID"></param>
        /// <returns></returns>
        private String CopyFile(String expID)
        {
            int lastindex = Application.ExecutablePath.LastIndexOf('\\');
            String fromPath = Application.ExecutablePath.Substring(0, lastindex + 1) + DefaultItem.SQLite_DBName;

            lastindex = DbConfig.path.LastIndexOf('\\');
            string path = DbConfig.path.Substring(0, lastindex);
            String toPath = path + '\\' + expID;

            lastindex = toPath.LastIndexOf('\\');
            path = toPath.Substring(0, lastindex);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.Copy(fromPath, toPath, true);
            return toPath;
        }

        /// <summary>
        /// 保存到数据库
        /// </summary>
        public void SaveToDb(int count, bool isSave)
        {
            //保存到数据库中
            if (isSave)
            {
                this._daoPointInfo.AppendToDb(this._dbPath, this._arrChannel, count, false);
            }

            //内存重复利用 
            this._arrChannel.RemoveRange(0, count);
        }

        /// <summary>
        /// 更新样品信息
        /// </summary>
        public void UpdatePara(ParaDto dtoPara)
        {
            if (null != dtoPara)
            {
                dtoPara.SampleStatus = StatusSample.Collected;
                this._daoPara.UpdatePara(dtoPara);
            }
        }

        /// <summary>
        /// 计算自动斜率,如果峰宽5点,那么就有4个斜率,做平均求一个斜率
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="arr"></param>
        public void CacuAutoSlope(int startPoint, ArrayList arr)
        {
            //if (!this._dtoCollect.AutoSlope)
            //{
            //    return;
            //}

            Single slopeSum = 0;
            OriginPointDto dto1 = null;
            OriginPointDto dto2 = null;
            int temp = 0;

            for (int i = startPoint; i < arr.Count; i += this._dtoCollect.PeakWide)
            {
                slopeSum = 0;
                if (i + this._dtoCollect.PeakWide > arr.Count)
                {
                    break;
                }

                for (int j = i; j < i + this._dtoCollect.PeakWide - 1; j++)
                {
                    dto1 = (OriginPointDto)arr[j];
                    dto2 = (OriginPointDto)arr[j + 1];
                    slopeSum += (dto2.Voltage - dto1.Voltage) / (dto2.Moment - dto1.Moment);
                }

                //设置为正值，避免负数
                temp = Convert.ToInt32(slopeSum / (this._dtoCollect.PeakWide - 1));
                this._dtoCollect.Slope = Math.Abs(temp);

                OnAutoSlopeActionArgs eve = new OnAutoSlopeActionArgs(this._idChannel, temp.ToString());
                if (this.AutoSlopeActioned != null)
                {
                    this.AutoSlopeActioned(this, eve);
                }
            }
        }

        /// <summary>
        /// 传递电压
        /// </summary>
        /// <param name="ti"></param>
        /// <param name="vol"></param>
        protected void ShowVoltage(Single ti, Single vol)
        {
            //double moment = Math.Round(Convert.ToDouble(ti), 3);
            //double temp = Math.Round(Convert.ToDouble(vol), 3) * DefaultItem.uVol;
            OnVoltageActionArgs eve = new OnVoltageActionArgs(this._idChannel, ti, vol);
            if (this.ShowVoltageActioned != null)
            {
                this.ShowVoltageActioned(this, eve);
            }
        }

        /// <summary>
        /// 通知窗口采集自动完成
        /// </summary>
        protected void AutoStop()
        {
            OnAutoStopActionArgs eve = new OnAutoStopActionArgs(this._sampleId, this._registerTime, this._idChannel, this._sampleName);
            if (this.AutoStopActioned != null)
            {
                this.AutoStopActioned(this, eve);
            }
        }


        /// <summary>
        /// 更新图形
        /// </summary>
        /// <param name="nlen"></param>
        /// <param name="transCount"></param>
        protected void UpdatePlotStyle(int nlen, int transCount)
        {
            double dStart = 0.0;
            double dEnd = 0.0;

            int temp = 0;
            int screenCountHalf = 0;

            //报告传输点数
            _ocx.AddPlotByPipe(this._plot.id, nlen,
                Convert.ToInt32(this._dtoCollect.FullScreenTime * General.Frequent * DefaultItem.SecondsPerMin));

            //半屏点数
            screenCountHalf = Convert.ToInt32(this._dtoCollect.FullScreenTime * General.Frequent * DefaultItem.SecondsPerMin / 2.0);
            if (screenCountHalf > 0)
            {
                temp = Convert.ToInt32(transCount / screenCountHalf) * screenCountHalf;

                //显示区域起点值
                dStart = 0 < temp ? (temp - screenCountHalf) / General.Frequent / DefaultItem.SecondsPerMin : 0;

                //显示区域终点值
                dEnd = dStart + this._dtoCollect.FullScreenTime;

                //调整显示属性
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
            }
        }

        /// <summary>
        /// 更新实时电压
        /// </summary>
        /// <param name="nlen"></param>
        /// <param name="transCount"></param>
        public void UpdatePlot(int nlen, int transCount)
        {
            // 匿名代理
            CrossThreadOperationControl CrossUpdatePlotStyle = delegate()
            {
                UpdatePlotStyle(nlen, transCount);
            };
            if (_ocx.InvokeRequired)
            {
                _ocx.Invoke(CrossUpdatePlotStyle);
            }
        }

        #endregion


    }
}
