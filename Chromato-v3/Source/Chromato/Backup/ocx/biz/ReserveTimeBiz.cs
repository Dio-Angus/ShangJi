/*-----------------------------------------------------------------------------
//  FILE NAME       : ReserveTimeBiz.cs
//  FUNCTION        : 2D控件中保留时间的的显示处理
//  AUTHOR          : 李锋(2009/06/05)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


using System;
using ChromatoBll.ocx.item;
using System.Collections;
using System.Data;
using ChromatoTool.dto;
using ChromatoTool.ini;
using AxGRAPHOCXLib;
using System.Drawing;
using ChromatoTool.util;
using System.Text;

namespace ChromatoBll.ocx.biz
{

    /// <summary>
    /// 2D控件中保留时间的的显示处理
    /// </summary>
    public sealed class ReserveTimeBiz
    {

        #region 图形变量

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
        /// 标签
        /// </summary>
        public LabelImp _label = null;

        /// <summary>
        /// 曲线
        /// </summary>
        public PlotImp _plot { get; set; }

        /// <summary>
        /// ocx
        /// </summary>
        public AxGraphOcx _ocx { get; set; }
        
        #endregion


        #region 数据变量

        /// <summary>
        /// 标签集合
        /// </summary>
        private ArrayList _arrLabel { get; set; }

        /// <summary>
        /// 保留时间dto集合
        /// </summary>
        public ArrayList _arrPeak { get; set; }

        /// <summary>
        /// 数据dto
        /// </summary>
        private PeakDto _dtoPeak = null;

        #endregion

       
        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public ReserveTimeBiz()
        {
            this._dtoPeak = new PeakDto();
            this._arrPeak = new ArrayList();
        }

        #endregion


        #region 方法

        /// <summary>
        /// 标签集合初期
        /// </summary>
        public void InitLabelArray()
        {
            this._arrLabel = new ArrayList();
            if (null != this._label)
            {
                this._arrLabel.Add(this._label);
            }
        }

        /// <summary>
        /// 装载保留时间标签,显示标签
        /// </summary>
        public void LoadLabel(DataSet ds)
        {
            if (null == ds || null == ds.Tables[0])
            {
                return;
            }

            this._arrPeak.Clear();
            for(int i = 0; i<ds.Tables[0].Rows.Count; i++)
            {
                this._dtoPeak = new PeakDto();
                this._dtoPeak.PeakID = Convert.ToInt32(ds.Tables[0].Rows[i]["PeakID"].ToString());
                this._dtoPeak.TopPointIndex = Convert.ToInt32(ds.Tables[0].Rows[i]["TopPointIndex"].ToString());
                this._dtoPeak.StartPointIndex = Convert.ToInt32(ds.Tables[0].Rows[i]["StartPointIndex"].ToString());
                this._dtoPeak.EndPointIndex = Convert.ToInt32(ds.Tables[0].Rows[i]["EndPointIndex"].ToString());
                this._dtoPeak.ReserveTime = Convert.ToSingle(ds.Tables[0].Rows[i]["ReserveTime"].ToString());
                this._dtoPeak.PeakName = ds.Tables[0].Rows[i]["PeakName"].ToString();
                this._arrPeak.Add(this._dtoPeak);
            }

            this.DrawLabel();
        }

        /// <summary>
        /// 清空标签
        /// </summary>
        public void ClearLabel()
        {
            LabelImp impLabel = null;
            for (int i = 0; i < this._arrLabel.Count; i++)
            {
                impLabel = (LabelImp)this._arrLabel[i];
                impLabel.Show = false;
            }
            this._arrPeak.Clear();
        }

        /// <summary>
        /// 显示标签
        /// </summary>
        public void DrawLabel()
        {
            if (null == this._arrLabel)
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
            LabelImp lable = null;

            int i = 0;
            for (i = 0; i < this._arrPeak.Count; i++)
            {
                this._dtoPeak = (PeakDto)this._arrPeak[i];
                if(this._dtoPeak.TopPointIndex >= _plot.arr.Count)
                {
                    continue;
                }
                dto = (AvgPointDto)_plot.arr[this._dtoPeak.TopPointIndex];
                int xPixel = _area.Left + Convert.ToInt32( fMemoryValX * (dto.Moment - _axsX.StartValue) );
                int yPixel = _area.Bottom - Convert.ToInt32( fMemoryValY * (dto.Voltage - _area.BottomValue) );

                if (i >= this._arrLabel.Count)
                {
                    lable = new LabelImp(this._ocx);
                    lable.id = this._ocx.AddItem(this._label.id);
                    this.SetLabelProperty(lable, xPixel, yPixel);

                    this._arrLabel.Add(lable);
                }
                else
                {
                    lable = (LabelImp)this._arrLabel[i];
                    this.SetLabelProperty(lable, xPixel, yPixel);
                }
            }

            //其它的标签不显示
            for (int j = i; j < this._arrLabel.Count; j++)
            {
                lable = (LabelImp)this._arrLabel[j];
                lable.Show = false;
            }

        }

        /// <summary>
        /// 设置标签属性
        /// </summary>
        /// <param name="lable"></param>
        /// <param name="xPixel"></param>
        /// <param name="yPixel"></param>
        private void SetLabelProperty(LabelImp lable, int xPixel, int yPixel)
        {

            //边界设置
            if (xPixel < this._area.Left)
            {
                xPixel = this._area.Left;
            }
            if (xPixel > this._area.Right)
            {
                xPixel = this._area.Right;
            }

            if (yPixel < this._area.Top)
            {
                yPixel = this._area.Top + 15;
            }
            if (yPixel > this._area.Bottom)
            {
                yPixel = this._area.Bottom;
            }

            lable.X = xPixel;
            lable.Y = yPixel;
            lable.Direction = (int)LabelDirection.Y;
            lable.Align = (int)Alignment.Y_Left;
            lable.Show = true;
            lable.FontSize = 8;
            //StringBuilder temp = new StringBuilder();
            //temp.Append(this._dtoPeak.PeakName);
            //temp.AppendFormat("{ 0:F3}", this._dtoPeak.ReserveTime);
            //lable.Text = temp.ToString();
            lable.Text = String.Format("{0:F3}", this._dtoPeak.ReserveTime);
            lable.BackColor = CastColor.GetCustomColor(Color.White);
            lable.ForeColor = CastColor.GetCustomColor(Color.Green);
        }

        /// <summary>
        /// 删除某个标签
        /// </summary>
        /// <param name="index"></param>
        public Int32 DeleteLabel(int index)
        {
            foreach (PeakDto dto in this._arrPeak)
            {
                if (index >= dto.StartPointIndex && index <= dto.EndPointIndex)
                {

                    this._arrPeak.Remove(dto);
                    this.DrawLabel();
                    return dto.PeakID;
                }
            }
            return 0;
        }

        /// <summary>
        /// 删除某些范围内的标签
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public ArrayList DeleteLabel(int startIndex, int endIndex)
        {
            ArrayList arr = new ArrayList();
            foreach (PeakDto dto in this._arrPeak)
            {
                if ((startIndex >= dto.StartPointIndex && startIndex <= dto.EndPointIndex) ||
                    (endIndex >= dto.StartPointIndex && endIndex <= dto.EndPointIndex) ||
                    (startIndex < dto.StartPointIndex && endIndex > dto.EndPointIndex))
                {
                    arr.Add(dto);
                }
            }

            foreach (PeakDto dtoDelete in arr)
            {
                foreach (PeakDto dto in this._arrPeak)
                {
                    if (dtoDelete.PeakID == dto.PeakID)
                    {
                        this._arrPeak.Remove(dto);
                        break;
                    }
                }
            }

            return arr;
        }

        /// <summary>
        /// 列表中追加新的PeakDto
        /// </summary>
        /// <param name="newPeakdto"></param>
        public void AddPeak(PeakDto newPeakdto)
        {
            PeakDto dto = null;
            int i = 0;
            for( i = 0; i < this._arrPeak.Count; i++)
            {
                dto = (PeakDto)this._arrPeak[i];
                if (newPeakdto.EndPointIndex <= dto.StartPointIndex)
                {
                    break;
                }
            }
            
            this._arrPeak.Insert(i, newPeakdto);
            this.DrawLabel();
        }

        /// <summary>
        /// 分割峰
        /// </summary>
        /// <param name="index"></param>
        /// <returns>返回待分割的峰</returns>
        public PeakDto FindSplitPeak(int index)
        {

            foreach (PeakDto dto in this._arrPeak)
            {
                if (index > dto.StartPointIndex && index < dto.EndPointIndex)
                {
                    return dto;
                }
            }

            return null;
        }

        #endregion







    }
}
