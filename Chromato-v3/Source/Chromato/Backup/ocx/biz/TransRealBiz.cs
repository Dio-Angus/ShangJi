/*-----------------------------------------------------------------------------
//  FILE NAME       : TransRealBiz.cs
//  FUNCTION        : 通过命名管道传输真实数据到2D控件
//  AUTHOR          : 李锋(2009/03/29)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.pipe;
using AxGRAPHOCXLib;
using ChromatoTool.ini;
using ChromatoTool.dto;
using System.Drawing;
using ChromatoTool.util;

namespace ChromatoBll.ocx.biz
{

    /// <summary>
    /// 通过命名管道传输真实数据到2D控件
    /// </summary>
    public sealed class TransRealBiz : TransBaseBiz
    {

        #region 变量

        /// <summary>
        /// 采样峰宽
        /// </summary>
        private int _peakWide = 0;

        /// <summary>
        /// 完成传输总数
        /// </summary>
        public int _transEclipseCount { get; set; }

        /// <summary>
        /// 采集完成总数
        /// </summary>
        public int _collectCount { get; set; }

        /// <summary>
        /// 采集完成总数
        /// </summary>
        public int _transNotSaveCount { get; set; }

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="pipe"></param>
        /// <param name="ocx"></param>
        public TransRealBiz(CastPipe pipe, AxGraphOcx ocx)
            : base(pipe,ocx)
        {
        }

        #endregion


        #region 真实数据传输

        /// <summary>
        /// 重新设置传输点
        /// </summary>
        public void Reset(ParaDto dtoPara, CollectionDto dtoCol)
        {
            this._transEclipseCount = 0;
            this._collectCount = 0;
            this._arrChannel.Clear();
            this._transNotSaveCount = 0;

            base._dtoCollect = dtoCol;
            base.CreateDb(dtoPara);
            base._plot.DataCount = 0;
        }

        /// <summary>
        /// 重新设置传输点
        /// </summary>
        public void Reset(CollectionDto dtoCol)
        {
            this._transEclipseCount = 0;
            this._collectCount = 0;
            this._arrChannel.Clear();
            this._transNotSaveCount = 0;

            base._dtoCollect = dtoCol;

            //调整显示属性
            base._area.LeftValue = 0;
            base._axsX.StartValue = 0;

            base._area.RightValue = 1;
            base._axsX.EndValue = 1;

            base._plot.DataCount = 0;

        }

        /// <summary>
        /// 更新通道显示内存中的采集方法
        /// </summary>
        public void UpdateTransCollection(CollectionDto dtoCol)
        {
            base._dtoCollect = dtoCol;

            // 是否改变背景色
            if (base._ocx.BackWndColor != Color.FromArgb(base._dtoCollect.BackColor))
            {
                base._ocx.BackWndColor = Color.FromArgb(base._dtoCollect.BackColor);
            }

            // 是否改变曲线颜色
            if (CastColor.GetArgbColor(base._plot.DatalineColor) != Color.FromArgb(base._dtoCollect.ForeColor))
            {
                base._plot.DatalineColor = CastColor.GetCustomColor(Color.FromArgb(base._dtoCollect.ForeColor));
            }

            if (base._area.TopValue != base._dtoCollect.ShowMaxY)
            {
                base._area.TopValue = Convert.ToDouble(base._dtoCollect.ShowMaxY);
                base._axsY.EndValue = base._area.TopValue;
            }

            if (base._area.BottomValue != base._dtoCollect.ShowMinY)
            {
                base._area.BottomValue = Convert.ToDouble(base._dtoCollect.ShowMinY);
                base._axsY.StartValue = base._area.BottomValue;
            }

            base._axsY.FloatFigure = 3;

        }

        /// <summary>
        /// 通过Pipe传递采集数据
        /// </summary>
        public RealStatus TransRealByPipeWithOutThread(RealStatus rs)
        {
            // 手动停止
            if (RealStatus.ManulStop == rs)
            {
                //保存未保存数据
                this.SaveToDb(this._arrChannel.Count, true);

                return RealStatus.Ready;
            }

            // 是否有新数据
            if ((this._arrChannel.Count - this._transNotSaveCount) < base._dtoCollect.PeakWide)
            {
                return rs;
            }

            //从配置中取得峰宽
            this._peakWide = base._dtoCollect.PeakWide;

            DateTime timeStart = DateTime.Now;
            OriginPointDto dto = new OriginPointDto();

            //Console.Out.WriteLine(String.Format("startPoint = {0}", _transEclipseCount));

            base.CacuAutoSlope(this._transNotSaveCount, this._arrChannel);

            int nlen = 0;

            for (int i = this._transNotSaveCount; i < _arrChannel.Count; i += this._peakWide)
            {
                if (_arrChannel.Count <( i + this._peakWide))
                {
                    break;
                }

                dto.Voltage = 0;

                //_peakWide点平均
                for (int j = 0; j < this._peakWide; j++)
                {
                    dto.Voltage += ((OriginPointDto)_arrChannel[i + j]).Voltage;
                }

                dto.Voltage = dto.Voltage / Convert.ToSingle(this._peakWide);
                dto.Moment = ((OriginPointDto)_arrChannel[i]).Moment;
                //dto.SampleID = base._dbName;

                //顺序写曲线x轴的数据
                _pipeCast.WriteFloat(dto.Moment);

                //顺序写曲线y轴的数据
                _pipeCast.WriteFloat(dto.Voltage);

                //通知窗口更新数据
                base.ShowVoltage(dto.Moment, dto.Voltage);

                //特定峰宽下本次传送数量
                nlen++;

                //传输总数增加
                this._transEclipseCount += this._peakWide;

                //已经传送但未保存点数增加
                this._transNotSaveCount += this._peakWide;

                if (General.Frequent <= nlen)
                {
                    break;
                }
            }

            //更新图形
            base.UpdatePlot(nlen, this._transEclipseCount);

            //采集数据保存
            if (this._transNotSaveCount > General.SaveMaxCount)
            {
                if (RealStatus.RealCollecting == rs)
                {
                    this.SaveToDb(this._transNotSaveCount, true);
                }
                else if (RealStatus.RunBase == rs)
                {
                    base._arrChannel.Clear();
                }
                this._transNotSaveCount = 0;
            }

            //需要采集的点数
            Single needCount = base._dtoCollect.StopTime * Convert.ToSingle(General.Frequent) * Convert.ToSingle(DefaultItem.SecondsPerMin);
            
            // 达到停止时间,停止该通道的处理线程
            if (Convert.ToInt32(needCount) <= this._collectCount)
            {
                if (RealStatus.RealCollecting == rs)
                {
                    //保存未保存数据
                    this.SaveToDb(this._arrChannel.Count, true);

                    //通知采集窗口更新状态
                    base.AutoStop();

                    return RealStatus.Ready;
                }
            }

            return rs;
        }

        #endregion
  
    
    }
}
