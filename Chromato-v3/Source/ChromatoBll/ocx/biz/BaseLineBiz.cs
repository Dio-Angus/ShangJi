/*-----------------------------------------------------------------------------
//  FILE NAME       : BaseLineBiz.cs
//  FUNCTION        : 2D控件中各个峰的基线的显示处理
//  AUTHOR          : 李锋(2009/06/07)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoBll.ocx.item;
using AxGRAPHOCXLib;
using System.Collections;
using ChromatoTool.dto;
using System.Data;
using ChromatoTool.util;
using System.Drawing;
using ChromatoTool.ini;
using System.Windows.Forms;

namespace ChromatoBll.ocx.biz
{
    /// <summary>
    /// 2D控件中各个峰的基线的显示处理
    /// </summary>
    public sealed class BaseLineBiz
    {

        #region 变量

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
        /// 直线
        /// </summary>
        public LineImp _line = null;

        /// <summary>
        /// 曲线
        /// </summary>
        public PlotImp _plot { get; set; }

        /// <summary>
        /// ocx
        /// </summary>
        public AxGraphOcx _ocx { get; set; }

        /// <summary>
        /// 峰起点直线集合
        /// </summary>
        private ArrayList _arrStartLine { get; set; }

        /// <summary>
        /// 峰终点直线集合
        /// </summary>
        private ArrayList _arrEndLine { get; set; }

        /// <summary>
        /// 峰基线集合
        /// </summary>
        private ArrayList _arrBaseLine { get; set; }

        /// <summary>
        /// 保留时间集合
        /// </summary>
        public ArrayList _arrPeak { get; set; }

        #endregion

  
        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public BaseLineBiz()
        {
            this._arrPeak = new ArrayList();
         }

        #endregion


        #region 方法

        /// <summary>
        /// 标签集合初期
        /// </summary>
        public void InitBaselineArray()
        {
            this._arrStartLine = new ArrayList();
            this._arrEndLine = new ArrayList();
            this._arrBaseLine = new ArrayList();
        }

        /// <summary>
        /// 装载保留时间标签,显示标签
        /// </summary>
        public void LoadBaseline(DataSet ds)
        {
            if (null == ds || null == ds.Tables[0])
            {
                return;
            }

            this._arrPeak.Clear();
            String temp = "";
            PeakDto dtoPeak = null;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dtoPeak = new PeakDto();
                dtoPeak.PeakID = Convert.ToInt32(ds.Tables[0].Rows[i]["PeakID"].ToString());
                dtoPeak.StartPointIndex = Convert.ToInt32(ds.Tables[0].Rows[i]["StartPointIndex"].ToString());
                dtoPeak.EndPointIndex = Convert.ToInt32(ds.Tables[0].Rows[i]["EndPointIndex"].ToString());
                dtoPeak.StartPointCloseIndex = Convert.ToInt32(ds.Tables[0].Rows[i]["StartPointCloseIndex"].ToString());
                dtoPeak.EndPointCloseIndex = Convert.ToInt32(ds.Tables[0].Rows[i]["EndPointCloseIndex"].ToString());
                dtoPeak.TopPointIndex = Convert.ToInt32(ds.Tables[0].Rows[i]["TopPointIndex"].ToString());

                dtoPeak.PeakType = ds.Tables[0].Rows[i]["PeakType"].ToString();
                dtoPeak.AreaSize = Convert.ToSingle(ds.Tables[0].Rows[i]["AreaSize"].ToString());
                dtoPeak.PeakHeight = Convert.ToSingle(ds.Tables[0].Rows[i]["PeakHeight"].ToString());
                dtoPeak.ReserveTime = Convert.ToSingle(ds.Tables[0].Rows[i]["ReserveTime"].ToString());

                temp = ds.Tables[0].Rows[i]["IsStartDown"].ToString();
                if (!String.IsNullOrEmpty(temp))
                {
                    dtoPeak.IsStartDown = Convert.ToBoolean(temp);
                }

                temp = ds.Tables[0].Rows[i]["IsEndDown"].ToString();
                if (!String.IsNullOrEmpty(temp))
                {
                    dtoPeak.IsEndDown = Convert.ToBoolean(temp);
                }

                temp = ds.Tables[0].Rows[i]["StartMoment"].ToString();
                if (!String.IsNullOrEmpty(temp))
                {
                    dtoPeak.StartMoment = Convert.ToSingle(temp);
                }

                temp = ds.Tables[0].Rows[i]["EndMoment"].ToString();
                if (!String.IsNullOrEmpty(temp))
                {
                    dtoPeak.EndMoment = Convert.ToSingle(temp);
                }

                temp = ds.Tables[0].Rows[i]["StartVoltage"].ToString();
                if (!String.IsNullOrEmpty(temp))
                {
                    dtoPeak.StartVoltage = Convert.ToSingle(temp);
                }

                temp = ds.Tables[0].Rows[i]["EndVoltage"].ToString();
                if (!String.IsNullOrEmpty(temp))
                {
                    dtoPeak.EndVoltage = Convert.ToSingle(temp);
                }
                this._arrPeak.Add(dtoPeak);
            }

            this.DrawBaseline();
            
        }

        /// <summary>
        /// 清空标签
        /// </summary>
        public void ClearBaseline()
        {
            LineImp impLine = null;
            for (int i = 0; i < this._arrStartLine.Count; i++)
            {
                impLine = (LineImp)this._arrStartLine[i];
                impLine.Show = false;
            }
            for (int i = 0; i < this._arrEndLine.Count; i++)
            {
                impLine = (LineImp)this._arrEndLine[i];
                impLine.Show = false;
            }
            for (int i = 0; i < this._arrBaseLine.Count; i++)
            {
                impLine = (LineImp)this._arrBaseLine[i];
                impLine.Show = false;
            }
            this._arrPeak.Clear();

        }

        /// <summary>
        /// 显示标签
        /// </summary>
        public void DrawBaseline()
        {
            if (null == this._arrStartLine)
            {
                return;
            }
            if (0 == this._arrPeak.Count)
            {
                return;
            }
            if (0 == this._plot.arr.Count)
            {
                return;
            }

            Single fPntSizeX = _area.Right - _area.Left;
            Single fPntSizeY = _area.Bottom - _area.Top;

            if (_axsX.EndValue <= _axsX.StartValue)
            {
                return;
            }
            Double fMemoryValX = fPntSizeX / (_axsX.EndValue - _axsX.StartValue);
            Double fMemoryValY = fPntSizeY / (_axsY.EndValue - _axsY.StartValue);

            AvgPointDto dto = null;
            LineImp line = null;

            int i = 0;

            //起点
            int PixelStartX = 0;
            int PixelStartY = 0;
            //峰开始竖线结束点Y
            int PixelDownStartY = 0;

            //终点
            int PixelEndX = 0;
            int PixelEndY = 0;
            //峰结束竖线结束点Y
            int PixelDownEndY = 0;

            PeakDto dtoPeak = null;

            for (i = 0; i < this._arrPeak.Count; i++)
            {
                dtoPeak = (PeakDto)this._arrPeak[i];
                if (dtoPeak.StartPointIndex >= _plot.arr.Count)
                {
                    continue;
                }
                if (dtoPeak.EndPointIndex >= _plot.arr.Count)
                {
                    continue;
                }

                dto = (AvgPointDto)_plot.arr[dtoPeak.StartPointCloseIndex];
                PixelStartX = _area.Left + Convert.ToInt32(fMemoryValX * (dtoPeak.StartMoment - _axsX.StartValue));
                PixelStartY = _area.Bottom - Convert.ToInt32(fMemoryValY * (dto.Voltage - _area.BottomValue));
                PixelDownStartY = _area.Bottom - Convert.ToInt32(fMemoryValY * (dtoPeak.StartVoltage - _area.BottomValue));

                dto = (AvgPointDto)_plot.arr[dtoPeak.EndPointCloseIndex];
                PixelEndX = _area.Left + Convert.ToInt32(fMemoryValX * (dtoPeak.EndMoment - _axsX.StartValue));
                PixelEndY = _area.Bottom - Convert.ToInt32(fMemoryValY * (dto.Voltage - _area.BottomValue));
                PixelDownEndY = _area.Bottom - Convert.ToInt32(fMemoryValY * (dtoPeak.EndVoltage - _area.BottomValue));

                //起点和终点都在曲线上
                if (!dtoPeak.IsStartDown && !dtoPeak.IsEndDown)
                {
                    this.GenerateStartLine(i, PixelStartX, PixelStartY - 6, PixelStartY);
                    this.GenerateEndLine(i, PixelEndX, PixelEndY, PixelEndY + 6);
                    this.GenerateBaseLine(i, PixelStartX, PixelStartY, PixelEndX, PixelEndY);
                }
                //起点在均线上,终点不在曲线上
                else if (!dtoPeak.IsStartDown && dtoPeak.IsEndDown)
                {
                    this.GenerateStartLine(i, PixelStartX, PixelStartY - 6, PixelStartY);
                    this.GenerateEndLine(i, PixelEndX, PixelEndY, PixelDownEndY);
                    this.GenerateBaseLine(i, PixelStartX, PixelStartY, PixelEndX, PixelDownEndY);
                }
                //起点不在均线上,终点在曲线上
                else if (dtoPeak.IsStartDown && !dtoPeak.IsEndDown)
                {
                    this.GenerateStartLine(i, PixelStartX, PixelStartY, PixelDownStartY);
                    this.GenerateEndLine(i, PixelEndX, PixelEndY, PixelEndY + 6);
                    this.GenerateBaseLine(i, PixelStartX, PixelDownStartY, PixelEndX, PixelEndY);
                }
                //起点,终点在都不在曲线上
                else if (dtoPeak.IsStartDown && dtoPeak.IsEndDown)
                {
                    this.GenerateStartLine(i, PixelStartX, PixelStartY, PixelDownStartY);
                    this.GenerateEndLine(i, PixelEndX, PixelEndY, PixelDownEndY);
                    this.GenerateBaseLine(i, PixelStartX, PixelDownStartY, PixelEndX, PixelDownEndY);
                }
            }

            //其它的标签不显示
            for (int j = i; j < this._arrStartLine.Count; j++)
            {
                line = (LineImp)this._arrStartLine[j];
                line.Show = false;
            }
            for (int j = i; j < this._arrEndLine.Count; j++)
            {
                line = (LineImp)this._arrEndLine[j];
                line.Show = false;
            }
            for (int j = i; j < this._arrBaseLine.Count; j++)
            {
                line = (LineImp)this._arrBaseLine[j];
                line.Show = false;
            }
        }

        /// <summary>
        /// 构造峰开始点的竖线
        /// </summary>
        /// <param name="i"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="endY"></param>
        private void GenerateStartLine(int i, int startX, int startY, int endY)
        {
            LineImp line = null;

            if (i >= this._arrStartLine.Count)
            {
                line = new LineImp(this._ocx);
                line.id = this._ocx.AddItem(this._line.id);

                this.AddLineProperty(line,startX,startY,endY);
                this._arrStartLine.Add(line);
            }
            else
            {
                line = (LineImp)this._arrStartLine[i];
                this.AddLineProperty(line, startX, startY, endY);
            }
        }

        /// <summary>
        /// 设置开始,结束线的属性
        /// </summary>
        /// <param name="line"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="endY"></param>
        private void AddLineProperty(LineImp line, int startX, int startY, int endY)
        {
            //边界设置
            if (startX < this._area.Left)
            {
                startX = this._area.Left;
            }
            if (startX > this._area.Right)
            {
                startX = this._area.Right;
            }

            if (startY < this._area.Top)
            {
                startY = this._area.Top;
            }
            if (startY > this._area.Bottom)
            {
                startY = this._area.Bottom;
            }

            if (endY < this._area.Top)
            {
                endY = this._area.Top;
            }
            if (endY > this._area.Bottom)
            {
                endY = this._area.Bottom;
            }

            //起点和终点的X相同
            line.StartX = startX;
            line.StartY = startY;
            line.EndX = startX;
            line.EndY = endY;
            line.Width = 1;
            line.Color = CastColor.GetCustomColor(Color.Red);
            line.Show = true;
        }

        /// <summary>
        /// 构造峰结束点的竖线
        /// </summary>
        /// <param name="i"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="endY"></param>
        private void GenerateEndLine(int i, int startX, int startY, int endY)
        {
            LineImp line = null;

            if (i >= this._arrEndLine.Count)
            {
                line = new LineImp(this._ocx);
                line.id = this._ocx.AddItem(this._line.id);

                this.AddLineProperty(line, startX, startY, endY);
                this._arrEndLine.Add(line);
            }
            else
            {
                line = (LineImp)this._arrEndLine[i];
                this.AddLineProperty(line, startX, startY, endY);
            }
        }

        /// <summary>
        /// 构造峰的基准直线
        /// </summary>
        /// <param name="i"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="endX"></param>
        /// <param name="endY"></param>
        private void GenerateBaseLine(int i, int startX, int startY, int endX, int endY)
        {
            LineImp line = null;

            if (i >= this._arrBaseLine.Count)
            {
                line = new LineImp(this._ocx);
                line.id = this._ocx.AddItem(this._line.id);

                this.AddLineProperty(line, startX, startY, endX, endY);
                this._arrBaseLine.Add(line);
            }
            else
            {
                line = (LineImp)this._arrBaseLine[i];
                this.AddLineProperty(line, startX, startY, endX, endY);
            }
        }

        /// <summary>
        /// 设置基准直线的属性
        /// </summary>
        /// <param name="line"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="endX"></param>
        /// <param name="endY"></param>
        private void AddLineProperty(LineImp line, int startX, int startY, int endX, int endY)
        {
            //边界设置
            if (startX < this._area.Left)
            {
                startX = this._area.Left;
            }
            if (startX > this._area.Right)
            {
                startX = this._area.Right;
            }

            if (endX < this._area.Left)
            {
                endX = this._area.Left;
            }
            if (endX > this._area.Right)
            {
                endX = this._area.Right;
            }

            if (startY < this._area.Top)
            {
                startY = this._area.Top;
            }
            if (startY > this._area.Bottom)
            {
                startY = this._area.Bottom;
            }

            if (endY < this._area.Top)
            {
                endY = this._area.Top;
            }
            if (endY > this._area.Bottom)
            {
                endY = this._area.Bottom;
            }

            line.StartX = startX;
            line.EndX = endX;
            line.StartY = startY;
            line.EndY = endY;
            line.Width = 1;
            line.Color = CastColor.GetCustomColor(Color.Red);
            line.Show = true;
        }

        /// <summary>
        /// 删除指定基线
        /// </summary>
        /// <param name="index"></param>
        public void DeleteBaseline(int index)
        {
            foreach (PeakDto dto in this._arrPeak)
            {
                if (index >= dto.StartPointIndex && index <= dto.EndPointIndex)
                {
                    this._arrPeak.Remove(dto);
                    this.DrawBaseline();
                    break;
                }
            }
        }

        /// <summary>
        /// 删除某些基线
        /// </summary>
        /// <param name="arr"></param>
        public void DeleteBaseline(ArrayList arr)
        {
            foreach (PeakDto dtoDelete in arr)
            {
                foreach (PeakDto dto in this._arrPeak)
                {
                    if (dto.PeakID == dtoDelete.PeakID)
                    {
                        this._arrPeak.Remove(dto);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 列表中追加新的PeakDto
        /// </summary>
        /// <param name="newPeakdto"></param>
        public void AddPeak(PeakDto newPeakdto)
        {
            PeakDto dto = null;
            int i = 0;
            for (i = 0; i < this._arrPeak.Count; i++)
            {
                dto = (PeakDto)this._arrPeak[i];
                if (newPeakdto.EndPointIndex <= dto.StartPointIndex)
                {
                    break;
                }
            }

            this._arrPeak.Insert(i, newPeakdto);
            //this.DrawBaseline();
        }

        /// <summary>
        /// 删除某个已经存在列表中的峰
        /// </summary>
        /// <param name="splitDtoPeak"></param>
        public void UpdatePeak(PeakDto splitDtoPeak)
        {
            foreach (PeakDto dto in this._arrPeak)
            {
                if (dto.PeakID == splitDtoPeak.PeakID)
                {
                    this._arrPeak.Remove(dto);
                    this._arrPeak.Add(splitDtoPeak);
                    break;
                }
            }
        }

        /// <summary>
        /// 改变内存中的基线,指定的峰为拖尾峰
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int TailPeak(int index)
        {
            foreach (PeakDto dto in this._arrPeak)
            {
                if (index >= dto.StartPointIndex && index <= dto.EndPointIndex)
                {
                    switch (dto.PeakType)
                    {
                        case TypeOfPeak.Main:
                            MessageBox.Show("该峰是主峰！", "提示");
                            break;
                        case TypeOfPeak.Tail:
                            MessageBox.Show("已经是拖尾峰！", "提示");
                            break;
                        case TypeOfPeak.Overlap:
                            dto.IsManualTail = true;
                            return dto.PeakID;
                    }
                }
            }
            return 0;
        }

        #endregion


    }
}
