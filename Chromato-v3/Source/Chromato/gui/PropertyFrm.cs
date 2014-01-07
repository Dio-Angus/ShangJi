/*-----------------------------------------------------------------------------
//  FILE NAME       : PropertyFrm.cs
//  FUNCTION        : 属性窗口
//  AUTHOR          : 李锋(2009/02/17)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoCore.ocx;
using ChromatoCore.util;
using ChromatoCore.ini;
using ChromatoCore.pipe;
using System.Threading;
using System.Timers;

namespace Chromato.gui
{
    /// <summary>
    /// 属性窗口
    /// </summary>
    public partial class PropertyFrm : Form
    {


        #region 变量

        /// <summary>
        /// 画面逻辑
        /// </summary>
        private GraphBiz _bizGraph = null;

        #endregion


        # region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public PropertyFrm()
        {
            InitializeComponent();

            this._bizGraph = GraphBiz.Instance;

        }

        /// <summary>
        /// 析构
        /// </summary>
        ~ PropertyFrm()
        {
            this.Dispose();
        }

        #endregion


        # region 初期

        /// <summary>
        /// 初期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PropertyFrm_Load(object sender, EventArgs e)
        {
            LoadPlot();
            LoadXAxis();
            LoadYAxis();
            LoadArea();
            LoadGrid();
            LoadLine();
            LoadShape();
            LoadLabel();

        }

        /// <summary>
        /// 设置对象
        /// </summary>
        public void LoadID()
        {
            LoadPlotID();
            LoadYAxisID();
            LoadXAxisID();
            LoadAreaID();
            LoadGridID();
            LoadShapeID();
            LoadLineID();
            LoadLabelID();

            this.lblBkColor.BackColor = this._bizGraph.GetBkColor();
            //this.StartResetTimer();

            //this.InitPlot();
        }


        #endregion


        # region 装载属性列表

        /// <summary>
        /// 装载曲线属性
        /// </summary>
        private void LoadPlot()
        {
            this.cmbProperty_Plot.Items.Add("Area");
            this.cmbProperty_Plot.Items.Add("DataCount");
            this.cmbProperty_Plot.Items.Add("dataline.Style");
            this.cmbProperty_Plot.Items.Add("dataline.Width");
            this.cmbProperty_Plot.Items.Add("dataline.Color");
            this.cmbProperty_Plot.Items.Add("Show");
            this.cmbProperty_Plot.Items.Add("ShowMarker");
            this.cmbProperty_Plot.Items.Add("StartXValue");
            this.cmbProperty_Plot.Items.Add("StartYValue");
            this.cmbProperty_Plot.Items.Add("EndXValue");
            this.cmbProperty_Plot.Items.Add("EndYValue");
            this.cmbProperty_Plot.Items.Add("marker.Bordercolor");
            this.cmbProperty_Plot.Items.Add("marker.Borderwidth");
            this.cmbProperty_Plot.Items.Add ("marker.Fillcolor");
            this.cmbProperty_Plot.Items.Add ("marker.Size");
            this.cmbProperty_Plot.Items.Add ("marker.Style");
            this.cmbProperty_Plot.Items.Add ("marker.Transparent");
            this.cmbProperty_Plot.Items.Add ("Zorder");
            this.cmbProperty_Plot.Items.Add ("RemoveAllDataLabels");
            this.cmbProperty_Plot.Items.Add ("add");
            this.cmbProperty_Plot.Items.Add ("Remove");
            this.cmbProperty_Plot.Items.Add ("Setdata");
            this.cmbProperty_Plot.Items.Add ("MarkerState");
            this.cmbProperty_Plot.SelectedIndex = 2;
        }

        /// <summary>
        /// 装载X轴属性
        /// </summary>
        private void LoadXAxis()
        {
            
            this.cmbProperty_XAxis.Items.Add("AxisLine.Color");
            this.cmbProperty_XAxis.Items.Add ("AxisLine.Style");
            this.cmbProperty_XAxis.Items.Add ("AxisLine.Width");
            this.cmbProperty_XAxis.Items.Add ("Align");
            this.cmbProperty_XAxis.Items.Add ("Show");
            this.cmbProperty_XAxis.Items.Add ("Direction");
            this.cmbProperty_XAxis.Items.Add ("StartValue");
            this.cmbProperty_XAxis.Items.Add ("EndValue");
            this.cmbProperty_XAxis.Items.Add ("FloatFigure");
            this.cmbProperty_XAxis.Items.Add ("X");
            this.cmbProperty_XAxis.Items.Add ("Y");
            this.cmbProperty_XAxis.Items.Add ("Length");
            this.cmbProperty_XAxis.Items.Add ("OffsetX");
            this.cmbProperty_XAxis.Items.Add ("OffsetY");
            this.cmbProperty_XAxis.Items.Add ("ScaleCount");
            this.cmbProperty_XAxis.Items.Add ("ScaleLine.Color");
            this.cmbProperty_XAxis.Items.Add ("ScaleLine.Style");
            this.cmbProperty_XAxis.Items.Add ("ScaleLine.Width");
            this.cmbProperty_XAxis.Items.Add ("ValueColor");
            this.cmbProperty_XAxis.Items.Add ("lablefont.Bold");
            this.cmbProperty_XAxis.Items.Add ("lablefont.Italic");
            this.cmbProperty_XAxis.Items.Add ("lablefont.Name");
            this.cmbProperty_XAxis.Items.Add ("lablefont.Size");
            this.cmbProperty_XAxis.Items.Add ("lablefont.Underline");
            this.cmbProperty_XAxis.Items.Add ("add");
            this.cmbProperty_XAxis.Items.Add ("Remove");
            this.cmbProperty_XAxis.Items.Add ("Zorder");
            this.cmbProperty_XAxis.Items.Add("UnitAndName");
            this.cmbProperty_XAxis.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载矩形属性
        /// </summary>
        private void LoadShape()
        {
            this.cmbProperty_Shape.Items.Add("X");
            this.cmbProperty_Shape.Items.Add ("Y");
            this.cmbProperty_Shape.Items.Add ("Width");
            this.cmbProperty_Shape.Items.Add ("Height");
            this.cmbProperty_Shape.Items.Add ("Show");
            this.cmbProperty_Shape.Items.Add ("sShapeAttr.BorderColor");
            this.cmbProperty_Shape.Items.Add ("sShapeAttr.FillColor");
            this.cmbProperty_Shape.Items.Add ("sShapeAttr.FillPattern");
            this.cmbProperty_Shape.Items.Add ("sShapeAttr.AdjustX");
            this.cmbProperty_Shape.Items.Add ("sShapeAttr.AdjustY");
            this.cmbProperty_Shape.Items.Add ("sShapeAttr.Transparent");
            this.cmbProperty_Shape.Items.Add ("add");
            this.cmbProperty_Shape.Items.Add ("Remove");
            this.cmbProperty_Shape.Items.Add ("Zorder");
            this.cmbProperty_Shape.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载文本属性
        /// </summary>
        private void LoadLabel()
        {
            this.cmbProperty_Label.Items.Add("Align");
            this.cmbProperty_Label.Items.Add ("Show");
            this.cmbProperty_Label.Items.Add ("Direction");
            this.cmbProperty_Label.Items.Add ("X");
            this.cmbProperty_Label.Items.Add ("Y");
            this.cmbProperty_Label.Items.Add ("ForeColor");
            this.cmbProperty_Label.Items.Add ("BackColor");
            this.cmbProperty_Label.Items.Add ("lablefont.Bold");
            this.cmbProperty_Label.Items.Add ("lablefont.Italic");
            this.cmbProperty_Label.Items.Add ("lablefont.Name");
            this.cmbProperty_Label.Items.Add ("lablefont.Size");
            this.cmbProperty_Label.Items.Add ("lablefont.Underline");
            this.cmbProperty_Label.Items.Add ("Text");
            this.cmbProperty_Label.Items.Add ("add");
            this.cmbProperty_Label.Items.Add ("Remove");
            this.cmbProperty_Label.Items.Add("Zorder");
            this.cmbProperty_Label.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载直线属性
        /// </summary>
        private void LoadLine()
        {
            this.cmbProperty_Line.Items.Add ("StartX");
            this.cmbProperty_Line.Items.Add("StartY");
            this.cmbProperty_Line.Items.Add("EndX");
            this.cmbProperty_Line.Items.Add("EndY");
            this.cmbProperty_Line.Items.Add("linepen.Style");
            this.cmbProperty_Line.Items.Add("linepen.Width");
            this.cmbProperty_Line.Items.Add("linepen.Color");
            this.cmbProperty_Line.Items.Add("Show");
            this.cmbProperty_Line.Items.Add("add");
            this.cmbProperty_Line.Items.Add("Remove");
            this.cmbProperty_Line.Items.Add("Zorder");
            this.cmbProperty_Line.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载网格属性
        /// </summary>
        private void LoadGrid()
        {
            this.cmbProperty_Grid.Items.Add ("left");
            this.cmbProperty_Grid.Items.Add ("right");
            this.cmbProperty_Grid.Items.Add ("top");
            this.cmbProperty_Grid.Items.Add ("bottom");
            this.cmbProperty_Grid.Items.Add ("TransParent");
            this.cmbProperty_Grid.Items.Add ("Show");
            this.cmbProperty_Grid.Items.Add ("VertGridCount");
            this.cmbProperty_Grid.Items.Add ("HorzGridCount");
            this.cmbProperty_Grid.Items.Add ("outpen.Style");
            this.cmbProperty_Grid.Items.Add ("outpen.Width");
            this.cmbProperty_Grid.Items.Add ("outpen.Color");
            this.cmbProperty_Grid.Items.Add ("brushColor");
            this.cmbProperty_Grid.Items.Add ("inpen.Style");
            this.cmbProperty_Grid.Items.Add ("inpen.Width");
            this.cmbProperty_Grid.Items.Add ("inpen.Color");
            this.cmbProperty_Grid.Items.Add ("add");
            this.cmbProperty_Grid.Items.Add ("Remove");
            this.cmbProperty_Grid.Items.Add("Zorder");
            this.cmbProperty_Grid.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载区域属性
        /// </summary>
        private void LoadArea()
        {
            this.cmbProperty_Area.Items.Add("left");
            this.cmbProperty_Area.Items.Add ("right");
            this.cmbProperty_Area.Items.Add ("top");
            this.cmbProperty_Area.Items.Add ("bottom");
            this.cmbProperty_Area.Items.Add ("ColorBrush");
            this.cmbProperty_Area.Items.Add ("XAxis");
            this.cmbProperty_Area.Items.Add ("YAxis");
            this.cmbProperty_Area.Items.Add ("LeftValue");
            this.cmbProperty_Area.Items.Add ("RightValue");
            this.cmbProperty_Area.Items.Add ("TopValue");
            this.cmbProperty_Area.Items.Add ("BottomValue");
            this.cmbProperty_Area.Items.Add ("Show");
            this.cmbProperty_Area.Items.Add ("add");
            this.cmbProperty_Area.Items.Add ("Remove");
            this.cmbProperty_Area.Items.Add ("Clip");
            this.cmbProperty_Area.Items.Add("Zorder");
            this.cmbProperty_Area.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载Y轴属性
        /// </summary>
        private void LoadYAxis()
        {
            this.cmbProperty_YAxis.Items.Add("AxisLine.Color");
            this.cmbProperty_YAxis.Items.Add ("AxisLine.Style");
            this.cmbProperty_YAxis.Items.Add ("AxisLine.Width");
            this.cmbProperty_YAxis.Items.Add ("Align");
            this.cmbProperty_YAxis.Items.Add ("Show");
            this.cmbProperty_YAxis.Items.Add ("Direction");
            this.cmbProperty_YAxis.Items.Add ("StartValue");
            this.cmbProperty_YAxis.Items.Add ("EndValue");
            this.cmbProperty_YAxis.Items.Add ("FloatFigure");
            this.cmbProperty_YAxis.Items.Add ("X");
            this.cmbProperty_YAxis.Items.Add ("Y");
            this.cmbProperty_YAxis.Items.Add ("Length");
            this.cmbProperty_YAxis.Items.Add ("OffsetX");
            this.cmbProperty_YAxis.Items.Add ("OffsetY");
            this.cmbProperty_YAxis.Items.Add ("ScaleCount");
            this.cmbProperty_YAxis.Items.Add ("ScaleLine.Color");
            this.cmbProperty_YAxis.Items.Add ("ScaleLine.Style");
            this.cmbProperty_YAxis.Items.Add ("ScaleLine.Width");
            this.cmbProperty_YAxis.Items.Add ("ValueColor");
            this.cmbProperty_YAxis.Items.Add ("lablefont.Bold");
            this.cmbProperty_YAxis.Items.Add ("lablefont.Italic");
            this.cmbProperty_YAxis.Items.Add ("lablefont.Name");
            this.cmbProperty_YAxis.Items.Add ("lablefont.Size");
            this.cmbProperty_YAxis.Items.Add ("lablefont.Underline");
            this.cmbProperty_YAxis.Items.Add ("add");
            this.cmbProperty_YAxis.Items.Add ("Remove");
            this.cmbProperty_YAxis.Items.Add ("Zorder");
            this.cmbProperty_YAxis.Items.Add("UnitAndName");
            this.cmbProperty_YAxis.SelectedIndex = 0;
        }

        #endregion


        #region 装载ID

        /// <summary>
        /// 装载文本ID
        /// </summary>
        private void LoadLabelID()
        {
            this.cmbItemID_Label.Items.Clear();
            this.cmbItemID_Label.Items.Add(this._bizGraph.GetLabelID());
            this.cmbItemID_Label.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载直线ID
        /// </summary>
        private void LoadLineID()
        {
            this.cmbItemID_Line.Items.Clear();
            this.cmbItemID_Line.Items.Add(this._bizGraph.GetLineID());
            this.cmbItemID_Line.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载矩形ID
        /// </summary>
        private void LoadShapeID()
        {
            this.cmbItemID_Shape.Items.Clear();
            this.cmbItemID_Shape.Items.Add(this._bizGraph.GetShapeID());
            this.cmbItemID_Shape.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载网格ID
        /// </summary>
        private void LoadGridID()
        {
            this.cmbItemID_Grid.Items.Clear();
            this.cmbItemID_Grid.Items.Add(this._bizGraph.GetGridID());
            this.cmbItemID_Grid.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载区域ID
        /// </summary>
        private void LoadAreaID()
        {
            this.cmbItemID_Area.Items.Clear();
            this.cmbItemID_Area.Items.Add(this._bizGraph.GetAreaID());
            this.cmbItemID_Area.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载X轴ID
        /// </summary>
        private void LoadXAxisID()
        {
            this.cmbItemID_XAxis.Items.Clear();
            this.cmbItemID_XAxis.Items.Add(this._bizGraph.GetAxisXID());
            this.cmbItemID_XAxis.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载Y轴ID
        /// </summary>
        private void LoadYAxisID()
        {
            this.cmbItemID_YAxis.Items.Clear();
            this.cmbItemID_YAxis.Items.Add(this._bizGraph.GetAxisYID());
            this.cmbItemID_YAxis.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载曲线ID
        /// </summary>
        private void LoadPlotID()
        {
            int count = 0;
            String[] sID = null;

            this._bizGraph.GetPlotID(ref count, ref sID);
            this.cmbItemID_Plot.Items.Clear();
            for (int i = 0; i < sID.Length; i++)
            {
                this.cmbItemID_Plot.Items.Add(sID[i].ToString());
            }
            this.cmbItemID_Plot.SelectedIndex = 0;
        }


        #endregion


        #region 关闭事件

        private void PropertyFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        #endregion


        #region 属性combo变更事件

        /// <summary>
        /// 曲线选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProperty_Plot_SelectedIndexChanged(object sender, EventArgs e)
        {

            string sVal = "";
            int nPropertyID = 0;
            int nItemId = 0;

            //If (mUserhandle = 0) Then Exit Sub

            nPropertyID = this.cmbProperty_Plot.SelectedIndex + 1;
            
            if("".Equals(this.cmbItemID_Plot.Text ))
            {
                MessageBox.Show( "Please choose no zero item");
                return;
            }


            nItemId = Convert.ToInt32(this.cmbItemID_Plot.Text);
            //Call mProperty.GetGraphIDbyItemID(nItemId, nGraph, nIndex);

            switch ((PlotProperty)nPropertyID)
            {
                case PlotProperty.Area:     //Area
                    sVal = this._bizGraph._plot.Area.ToString();
                    break;

                case PlotProperty.DataCount:     //DataCount
                    sVal = _bizGraph._plot.DataCount.ToString();
                    break;

                case PlotProperty.dataline_Style:     //dataline.Style
                    sVal = _bizGraph._plot.DatalineStyle.ToString();
                    break;

                case PlotProperty.dataline_Width:     //dataline.Width
                    sVal = _bizGraph._plot.DatalineWidth.ToString();
                    break;

                case PlotProperty.dataline_Color:     //dataline.Color
                    sVal = _bizGraph._plot.DatalineColor.ToString();
                    break;

                case PlotProperty.Show:     //Show
                    sVal = _bizGraph._plot.Show.ToString();
                    break;

                case PlotProperty.ShowMarker:     //ShowMarker
                    sVal = _bizGraph._plot.ShowMarker.ToString();
                    break;

                case PlotProperty.StartXValue:    //StartXValue
                    sVal = _bizGraph._plot.StartXValue.ToString();
                    break;

                case PlotProperty.StartYValue:     //StartYValue
                    sVal = _bizGraph._plot.StartYValue.ToString();
                    break;

                case PlotProperty.EndXValue:    //EndXValue
                    sVal = _bizGraph._plot.EndXValue.ToString();
                    break;

                case PlotProperty.EndYValue:    //EndYValue
                    sVal = _bizGraph._plot.EndYValue.ToString();
                    break;

                case PlotProperty.marker_Bordercolor:    //marker.Bordercolor
                    sVal = _bizGraph._plot.MarkerBordercolor.ToString();
                    break;

                case PlotProperty.marker_Borderwidth:    //marker.Borderwidth
                    sVal = _bizGraph._plot.MarkerBorderwidth.ToString();
                    break;

                case PlotProperty.marker_Fillcolor:    //marker.Fillcolor
                    sVal = _bizGraph._plot.MarkerFillColor.ToString();
                    break;

                case PlotProperty.marker_Size:    //marker.Size
                    sVal = _bizGraph._plot.MarkerSize.ToString();
                    break;

                case PlotProperty.marker_Style:   //marker.Style
                    sVal = _bizGraph._plot.MarkerStyle.ToString();
                    break;

                case PlotProperty.marker_Transparent:    //marker.Transparent
                    sVal = _bizGraph._plot.MarkerTransparent.ToString();
                    break;

                case PlotProperty.Zorder:    //Zorder
                    sVal = _bizGraph._plot.ZorderOcx.ToString();
                    break;

                case PlotProperty.RemoveAllDataLabels:    //RemoveAllDataLabels()
                    //'Call ComOcx(nItemNo, nPropertyID, 0, WRITE_OCX, WM_USER_MESSAGE, CMD_MESSAGE)
                    break;

                case PlotProperty.add:    //add()
                    break;

                case PlotProperty.Remove:    //Remove()
                    break;

                case PlotProperty.Setdata:    //Setdata()
                    break;

                case PlotProperty.marker_state:    //marker state
                    sVal = _bizGraph._plot.GetMarkerState(5).ToString();
                    break;
            }

            this.txtValue_Plot.Text = sVal;


        }

        /// <summary>
        /// X轴选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProperty_XAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;
            int nGraph = 0;

            //If (mUserhandle = 0) Then Exit Sub


            nPropertyID = this.cmbProperty_XAxis.SelectedIndex + 1;

            nGraph = this.cmbItemID_XAxis.SelectedIndex;

            if (nGraph < 0)
            {
                MessageBox.Show("Please choose no zero item");
                return;
            }


            switch( (AxisProperty)nPropertyID )
            {
                case AxisProperty.AxisLine_Color:   //AxisLine.Color
                    sVal = this._bizGraph._axsX.LineColor.ToString();
                    break;

                case AxisProperty.AxisLine_Style:   //AxisLine.Style
                    sVal = _bizGraph._axsX.LineStyle.ToString();
                    break;

                case AxisProperty.AxisLine_Width:   //AxisLine.Width
                    sVal = _bizGraph._axsX.LineWidth.ToString();
                    break;

                case AxisProperty.Align:   //Align
                    sVal = _bizGraph._axsX.Align.ToString();
                    break;

                case AxisProperty.Show:  //Show
                    sVal = _bizGraph._axsX.Show.ToString();
                    break;
                case AxisProperty.Direction:   //Direction
                    sVal = _bizGraph._axsX.Direction.ToString();
                    break;
                case AxisProperty.StartValue:   //StartValue
                    sVal = _bizGraph._axsX.StartValue.ToString();
                    break;
                case AxisProperty.EndValue:   //EndValue
                    sVal = _bizGraph._axsX.EndValue.ToString();
                    break;
                case AxisProperty.FloatFigure:   //FloatFigure
                    sVal = _bizGraph._axsX.FloatFigure.ToString();
                    break;
                case AxisProperty.X:   //X
                    sVal = _bizGraph._axsX.X.ToString();
                    break;
                case AxisProperty.Y:   //Y
                    sVal = _bizGraph._axsX.Y.ToString();
                    break;
                case AxisProperty.Length:   //Length
                    sVal = _bizGraph._axsX.Length.ToString();
                    break;
                case AxisProperty.OffsetX:   //OffsetX
                    sVal = _bizGraph._axsX.OffsetX.ToString();
                    break;
                case AxisProperty.OffsetY:   //OffsetY
                    sVal = _bizGraph._axsX.OffsetY.ToString();
                    break;
                case AxisProperty.ScaleCount:   //ScaleCount
                    sVal = _bizGraph._axsX.ScaleCount.ToString();
                    break;
                case AxisProperty.ScaleLine_Color:   //ScaleLine.Color
                    sVal = _bizGraph._axsX.ScaleLineColor.ToString();
                    break;
                case AxisProperty.ScaleLine_Style:   //ScaleLine.Style
                    sVal = _bizGraph._axsX.ScaleLineStyle.ToString();
                    break;
                case AxisProperty.ScaleLine_Width:   //ScaleLine.Width
                    sVal = _bizGraph._axsX.ScaleLineWidth.ToString();
                    break;
                case AxisProperty.ValueColor:   //ValueColor
                    sVal = _bizGraph._axsX.ValueColor.ToString();
                    break;
                case AxisProperty.lablefont_Bold:   //lablefont.Bold
                    sVal = _bizGraph._axsX.LabelFontBold.ToString();
                    break;
                case AxisProperty.lablefont_Italic:   //lablefont.Italic
                    sVal = _bizGraph._axsX.LabelFontItalic.ToString();
                    break;

                case AxisProperty.lablefont_Name:   //lablefont.Name
                    sVal = _bizGraph._axsX.LabelFontName.ToString(); // '"俵俽 俹僑僔僢僋"
                    break;

                case AxisProperty.lablefont_Size:   //lablefont.Size
                    sVal = _bizGraph._axsX.LabelFontSize.ToString();
                    break;

                case AxisProperty.lablefont_Underline:   //lablefont.Underline
                    sVal = _bizGraph._axsX.LabelFontUnderline.ToString();
                    break;

                case AxisProperty.add:   //add
                    break;

                case AxisProperty.Remove:   //remove
                    break;

                case AxisProperty.Zorder:   //Zorder
                    sVal = _bizGraph._axsX.ZorderOcx.ToString();
                    break;

                case AxisProperty.UnitAndName: //Unit And Name
                    sVal = _bizGraph._axsX.UnitName.ToString();
                    break;
        
            }


            this.txtValue_XAxis.Text = sVal;


        }

        /// <summary>
        /// Y轴选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProperty_YAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;
            int nGraph = 0;

            nPropertyID = this.cmbProperty_YAxis.SelectedIndex + 1;

            nGraph = this.cmbItemID_YAxis.SelectedIndex;

            if (nGraph < 0)
            {
                MessageBox.Show("Please choose no zero item");
                return;
            }


            switch (nPropertyID)
            {
                case 1:   //AxisLine.Color
                    sVal = _bizGraph._axsY.LineColor.ToString();
                    break;

                case 2:   //AxisLine.Style
                    sVal = _bizGraph._axsY.LineStyle.ToString();
                    break;

                case 3:   //AxisLine.Width
                    sVal = _bizGraph._axsY.LineWidth.ToString();
                    break;

                case 4:   //Align
                    sVal = _bizGraph._axsY.Align.ToString();
                    break;

                case 5:  //Show
                    sVal = _bizGraph._axsY.Show.ToString();
                    break;
                case 6:   //Direction
                    sVal = _bizGraph._axsY.Direction.ToString();
                    break;
                case 7:   //StartValue
                    sVal = _bizGraph._axsY.StartValue.ToString();
                    break;
                case 8:   //EndValue
                    sVal = _bizGraph._axsY.EndValue.ToString();
                    break;
                case 9:   //FloatFigure
                    sVal = _bizGraph._axsY.FloatFigure.ToString();
                    break;
                case 10:   //X
                    sVal = _bizGraph._axsY.X.ToString();
                    break;
                case 11:   //Y
                    sVal = _bizGraph._axsY.Y.ToString();
                    break;
                case 12:   //Length
                    sVal = _bizGraph._axsY.Length.ToString();
                    break;
                case 13:   //OffsetX
                    sVal = _bizGraph._axsY.OffsetX.ToString();
                    break;
                case 14:   //OffsetY
                    sVal = _bizGraph._axsY.OffsetY.ToString();
                    break;
                case 15:   //ScaleCount
                    sVal = _bizGraph._axsY.ScaleCount.ToString();
                    break;
                case 16:   //ScaleLine.Color
                    sVal = _bizGraph._axsY.ScaleLineColor.ToString();
                    break;
                case 17:   //ScaleLine.Style
                    sVal = _bizGraph._axsY.ScaleLineStyle.ToString();
                    break;
                case 18:   //ScaleLine.Width
                    sVal = _bizGraph._axsY.ScaleLineWidth.ToString();
                    break;
                case 19:   //ValueColor
                    sVal = _bizGraph._axsY.ValueColor.ToString();
                    break;
                case 20:   //lablefont.Bold
                    sVal = _bizGraph._axsY.LabelFontBold.ToString();
                    break;
                case 21:   //lablefont.Italic
                    sVal = _bizGraph._axsY.LabelFontItalic.ToString();
                    break;

                case 22:   //lablefont.Name
                    sVal = _bizGraph._axsY.LabelFontName.ToString(); // '"俵俽 俹僑僔僢僋"
                    break;

                case 23:   //lablefont.Size
                    sVal = _bizGraph._axsY.LabelFontSize.ToString();
                    break;

                case 24:   //lablefont.Underline
                    sVal = _bizGraph._axsY.LabelFontUnderline.ToString();
                    break;

                case 25:   //add
                    break;

                case 26:   //remove
                    break;

                case 27:   //Zorder
                    sVal = _bizGraph._axsY.ZorderOcx.ToString();
                    break;

                case 28: //Unit And Name
                    sVal = _bizGraph._axsY.UnitName.ToString();
                    break;

            }


            this.txtValue_YAxis.Text = sVal;


        }

        /// <summary>
        /// 区域选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProperty_Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;
            int nGraph = 0;

            //If (mUserhandle = 0) Then Exit Sub


            nPropertyID = this.cmbProperty_Area.SelectedIndex + 1;
            
            nGraph = this.cmbItemID_Area.SelectedIndex;

            if( nGraph < 0 )
            {
                MessageBox.Show( "Please choose no zero item");
                return;
            }
            
            switch( nPropertyID)
            {
                case 1:  //left
                    sVal = _bizGraph._area.Left.ToString();
                    break;
                case 2:   //right
                    sVal = _bizGraph._area.Right.ToString();
                    break;

                case 3:   //top
                    sVal = _bizGraph._area.Top.ToString();
                    break;

                case 4:   //bottom
                    sVal = _bizGraph._area.Bottom.ToString();
                    break;

                case 5:   //ColorBrush
                    sVal = _bizGraph._area.ColorBrush.ToString();
                    break;

                case 6:   //XAxis
                    sVal = _bizGraph._area.XAxis.ToString();
                    break;

                case 7:   //YAxis
                    sVal = _bizGraph._area.YAxis.ToString();
                    break;

                case 8:   //LeftValue
                    sVal = _bizGraph._area.LeftValue.ToString();
                    break;

                case 9:   //RightValue
                    sVal = _bizGraph._area.RightValue.ToString();
                    break;

                case 10:  //TopValue
                    sVal = _bizGraph._area.TopValue.ToString();
                    break;

                case 11:  //BottomValue
                    sVal = _bizGraph._area.BottomValue.ToString();
                    break;

                case 12:  //Show
                    sVal = _bizGraph._area.Show.ToString();
                     break;
               
                case 13:  //add
                    break;

                case 14:  //Remove
                    break;

                case 15:  //Clip
                    sVal = _bizGraph._area.Clip.ToString();
                     break;
           
                case 16:  //Zorder
                     sVal = _bizGraph._area.ZorderOcx.ToString();
                     break;
                   
            }

            this.txtValue_Area.Text = sVal;
        }

        /// <summary>
        /// 网格选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProperty_Grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;
            int nGraph = 0;

            //If (mUserhandle = 0) Then Exit Sub


            nPropertyID = this.cmbProperty_Grid.SelectedIndex + 1;

            nGraph = this.cmbItemID_Grid.SelectedIndex;

            if (nGraph < 0)
            {
                MessageBox.Show("Please choose no zero item");
                return;
            }

            switch (nPropertyID)
            {
                case 1://left
                    sVal = _bizGraph._grid.Left.ToString();
                    break;

                case 2:   //right
                    sVal = _bizGraph._grid.Right.ToString();
                    break;

                case 3:  //top
                    sVal = _bizGraph._grid.Top.ToString();
                    break;

                case 4:   //bottom
                    sVal = _bizGraph._grid.Bottom.ToString();
                    break;

                case 5:   //TransParent
                    sVal = _bizGraph._grid.TransParent.ToString();
                    break;

                case 6:  //'Show
                    sVal = _bizGraph._grid.Show.ToString();
                    break;

                case 7:  //'VertGridCount
                    sVal = _bizGraph._grid.VertCount.ToString();
                    break;

                case 8:  //HorzGridCount
                    sVal = _bizGraph._grid.HorzCount.ToString();
                    break;

                case 9:  //'outpen.Style
                    sVal = _bizGraph._grid.OutLineStyle.ToString();
                    break;

                case 10: //'outpen.Width
                    sVal = _bizGraph._grid.OutLineWidth.ToString();
                    break;

                case 11:  //outpen.Color
                    sVal = _bizGraph._grid.OutLineColor.ToString();
                    break;

                case 12:  //brushColor
                    sVal = _bizGraph._grid.BrushColor.ToString();
                    break;

                case 13:  //inpen.Style
                    sVal = _bizGraph._grid.InLineStyle.ToString();
                    break;

                case 14:  //inpen.Width
                    sVal = _bizGraph._grid.InLineWidth.ToString();
                    break;

                case 15:  //inpen.Color
                    sVal = _bizGraph._grid.InLineColor.ToString();
                    break;

                case 16: //add
                    break;

                    
                case 17:  //Remove

                    break;
                    
                case 18:  //Zorder
                    sVal = _bizGraph._grid.ZorderOcx.ToString();
                    break;

            }


            this.txtValue_Grid.Text = sVal;
        }

        /// <summary>
        /// 直线属性选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProperty_Line_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;
            int nGraph = 0;

            //If (mUserhandle = 0) Then Exit Sub


            nPropertyID = this.cmbProperty_Line.SelectedIndex + 1;

            nGraph = this.cmbItemID_Line.SelectedIndex;

            if (nGraph < 0)
            {
                MessageBox.Show("Please choose no zero item");
                return;
            }

            switch (nPropertyID)
            {
                case 1:    //StartX
                    sVal = _bizGraph._line.StartX.ToString();
                    break;

                case 2:    //StartY
                    sVal = _bizGraph._line.StartY.ToString();
                    break;

                case 3:    //EndX
                    sVal = _bizGraph._line.EndX.ToString();
                    break;
                case 4:    //EndY
                    sVal = _bizGraph._line.EndY.ToString();
                    break;
                case 5:    //linepen.Style
                    sVal = _bizGraph._line.Style.ToString();
                    break;
                case 6:    //linepen.Width
                    sVal = _bizGraph._line.Width.ToString();
                    break;
                case 7:    //linepen.Color
                    sVal = _bizGraph._line.Color.ToString();
                    break;
                case 8:    //Show
                    sVal = _bizGraph._line.Show.ToString();
                    break;
                case 9:    //add
                    break;
                case 10:   //Remove
                    break;
                case 11:   //Zorder
                    sVal = _bizGraph._line.ZorderOcx.ToString();
                    break;
            }


            this.txtValue_Line.Text = sVal;
        }

        /// <summary>
        /// 矩形选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProperty_Shape_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;
            int nGraph = 0;

            //If (mUserhandle = 0) Then Exit Sub


            nPropertyID = this.cmbProperty_Shape.SelectedIndex + 1;

            nGraph = this.cmbItemID_Shape.SelectedIndex;

            if (nGraph < 0)
            {
                MessageBox.Show("Please choose no zero item");
                return;
            }

            switch( nPropertyID)
            {
                case 1://   'X
                    sVal = _bizGraph._shape.X.ToString();
                    break;

                case 2://   'Y
                    sVal = _bizGraph._shape.Y.ToString();
                    break;

                case 3://   'Width
                    sVal = _bizGraph._shape.Width.ToString();
                    break;

                case 4://   'Height
                    sVal = _bizGraph._shape.Height.ToString();
                    break;

                case 5://   'Show
                    sVal = _bizGraph._shape.Show.ToString();
                    break;

                case 6://   'sShapeAttr.BorderColor
                    sVal = _bizGraph._shape.BorderColor.ToString();
                    break;

                case 7://   'sShapeAttr.FillColor
                    sVal = _bizGraph._shape.FillColor.ToString();
                    break;

                case 8://   'sShapeAttr.FillPattern
                    sVal = _bizGraph._shape.FillPattern.ToString();
                    break;

                case 9://   'sShapeAttr.AdjustX
                    sVal = _bizGraph._shape.AdjustX.ToString();
                    break;

                case 10://  'sShapeAttr.AdjustY
                    sVal = _bizGraph._shape.AdjustY.ToString();
                    break;

                case 11://  'sShapeAttr.Transparent
                    sVal = _bizGraph._shape.Transparent.ToString();
                    break;
                case 12://  'add
                    break;

                case 13://  'Remove
                    break;
                case 14://  'Zorder
                    sVal = _bizGraph._shape.ZorderOcx.ToString();
                             break;

            }
            this.txtValue_Shape.Text = sVal;
        }

        /// <summary>
        /// 文本选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProperty_Label_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;
            int nGraph = 0;

            //If (mUserhandle = 0) Then Exit Sub


            nPropertyID = this.cmbProperty_Label.SelectedIndex + 1;

            nGraph = this.cmbItemID_Label.SelectedIndex;

            if (nGraph < 0)
            {
                MessageBox.Show("Please choose no zero item");
                return;
            }

            switch( nPropertyID)
            {
                case 1:   //Align           UP = 0  DOWN = 1  LEFT = 2  CENTER = 3  RIGHT = 4
                    sVal = _bizGraph._label.Align.ToString();    //1
                    break;

                case 2:   //Show          Show = 1  Invisable = 0
                    sVal = _bizGraph._label.Show.ToString(); // 'True
                    break;

                case 3:   //Direction     X_AXIS_DIRECTION = 0   Y_AXIS_DIRECTION = 1
                    sVal = _bizGraph._label.Direction.ToString();    // '1
                    break;

                case 4:   //X
                    sVal = _bizGraph._label.X.ToString();    // '200
                    break;

                case 5:   //Y
                    sVal = _bizGraph._label.Y.ToString();    // '200
                    break;

                case 6:   //ForeColor
                    sVal = _bizGraph._label.ForeColor.ToString();    // 'RGB(255, 0, 0)
                    break;

                case 7:   //BackColor
                    sVal = _bizGraph._label.BackColor.ToString();   // 'RGB(0, 0, 0)
                    break;

                case 8:   //lablefont.Bold
                    sVal = _bizGraph._label.FontBold.ToString(); // 'False
                    break;

                case 9:   //lablefont.Italic
                    sVal = _bizGraph._label.FontItalic.ToString();   // 'False
                    break;

                case 10:  //lablefont.Name
                    sVal = _bizGraph._label.FontName.ToString(); //   '"俵俽 俹僑僔僢僋"
                    break;
   
                case 11:   //lablefont.Size
                    sVal = _bizGraph._label.FontSize.ToString(); // '20
                    break;

                case 12:   //lablefont.Underline
                    sVal = _bizGraph._label.FontUnderline.ToString();    //False
                    break;

                case 13:   //Text
                    //Call GraphObj.SetLabelText(nItemNo, 6, "123戝岲偒")
                    break;

                case 14:   //add
                    break;

                case 15:   //remove
                    break;

                case 16:   //Zorder
                    sVal = _bizGraph._label.ZorderOcx.ToString();
                   break;
            }


            if( nPropertyID == 10 || nPropertyID == 13 )
            {
                this.txtValue_Label.Text = sVal;
            }
            else
            {
                this.txtValue_Label.Text = sVal;
            }

        }

        #endregion


        #region 按钮事件

        /// <summary>
        /// 改变选中曲线属性的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangePlot_Click(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;
            int nGraph = 0;

            long iValueCount = 0;

            nGraph = this.cmbItemID_Plot.SelectedIndex;

            if (nGraph < 0)
            {
                MessageBox.Show("Please choose no zero item");
                return;
            }


            //Dim x() As Single
            //Dim y() As Single
            //Dim newPlot As Integer
            //Dim nItemId As Integer

            nPropertyID = this.cmbProperty_Plot.SelectedIndex + 1;

            //nItemId = Me.Cmb_PlotID.Text
            //Call mProperty.GetGraphIDbyItemID(nItemId, nGraph, nIndex)

            if (CastString.IsNumeric(this.txtValue_Plot.Text))
            {
                sVal = this.txtValue_Plot.Text;
            }
            else
            {
                MessageBox.Show("Please input Numeric");
                return;
            }
            
            //dVal = CDbl(Me.txt_Plot.Text)
    
            switch( nPropertyID )
            {
                case 1:    //Area
                    this._bizGraph._plot.Area = Convert.ToInt32(sVal);
                    break;
                
                case 2:    //DataCount
                    _bizGraph._plot.DataCount = Convert.ToInt32(sVal);
                    break;
               
                case 3:    //'dataline.Style
                    _bizGraph._plot.DatalineStyle =Convert.ToInt32(sVal);
                    break;
              
                case 4:    //'dataline.Width
                    _bizGraph._plot.DatalineWidth = Convert.ToInt32(sVal);
                    break;
              
                case 5:    //'dataline.Color
  //                  _bizGraph._plot.PlotDatalineColor(nGraph, nIndex, 0, Convert.ToInt32(sVal));
                    _bizGraph._plot.DatalineColor = Convert.ToInt32(sVal);
                    break;
                
                case 6:    //'Show
                    _bizGraph._plot.Show = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;
              
                case 7:    //'ShowMarker
                    _bizGraph._plot.ShowMarker = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;
                
                case 8:    //'StartXValue
                    _bizGraph._plot.StartXValue = Convert.ToInt32(sVal);
                    break;
               
                case 9:    //'StartYValue
                    _bizGraph._plot.StartYValue = Convert.ToInt32(sVal);
                    break;
              
                case 10:   //'EndXValue
                    _bizGraph._plot.EndXValue = Convert.ToInt32(sVal);
                    break;
               
                case 11:   //'EndYValue
                    _bizGraph._plot.EndYValue = Convert.ToInt32(sVal);
                    break;
               
                case 12:   //'marker.Bordercolor
                    _bizGraph._plot.MarkerBordercolor = Convert.ToInt32(sVal);
                    break;

                case 13:   //'marker.Borderwidth
                    _bizGraph._plot.MarkerBorderwidth = Convert.ToInt32(sVal);
                    break;

                case 14:   //'marker.Fillcolor
                    _bizGraph._plot.MarkerFillColor = Convert.ToInt32(sVal);
                    break;
              
                case 15:   //'marker.Size
                    _bizGraph._plot.MarkerSize = Convert.ToInt32(sVal);
                    break;

                case 16:   //'marker.Style
                    _bizGraph._plot.MarkerStyle = Convert.ToInt32(sVal);
                    break;

                case 17:   //'marker.Transparent
                    _bizGraph._plot.MarkerTransparent = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;
                
                case 18:   //'Zorder
                    _bizGraph._plot.ZorderOcx = Convert.ToInt16(sVal);
                    break;
               
                case 19:   //'RemoveAllDataLabels()
        //'         Call ComOcx(nItemNo, nPropertyID, 0, WRITE_OCX, WM_USER_MESSAGE, CMD_MESSAGE)
                    break;
                 
                case 20:   //'add()
        //'         newPlot = GraphObj.AddItem(nItemNo)
        //'         MsgBox ("newPlot, itemno = " & newPlot)
                    break;

            
                case 21:   //'Remove()
        //'         newPlot = GraphObj.AddItem(nItemNo)
        //'         MsgBox ("newPlot itemno is " & newPlot)
        //'         GraphObj.RemoveItem (newPlot)
        //'         MsgBox ("itemno " & newPlot & " be removed.")
                    break;
          
                case 22:   //'Setdata()
                    break;
               
                case 23:   //'marker state
                    iValueCount = _bizGraph._plot.DataCount;

                    for(int i = 0; i< iValueCount; i++)
                    {
                        _bizGraph._plot.SetMarkerState( i, (0 < Convert.ToInt32(sVal)) ? true : false);
                    }
                     
                    break;
                }
        }

        /// <summary>
        /// 改变选中X轴属性的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeXAxis_Click(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;
            int nGraph = 0;

            // If (mUserhandle = 0) Then Exit Sub

            nGraph = this.cmbItemID_XAxis.SelectedIndex;

            if (nGraph < 0)
            {
                MessageBox.Show("Please choose no zero item");
                return;
            }

            nPropertyID = this.cmbProperty_XAxis.SelectedIndex + 1;

            if (nPropertyID == 22 || nPropertyID == 28)
            {
                sVal = this.txtValue_XAxis.Text;
            }
            else
            {
                if (CastString.IsNumeric(this.txtValue_XAxis.Text))
                {
                    sVal = this.txtValue_XAxis.Text;
                }
                else
                {
                    MessageBox.Show("Please input Numeric");
                    return;
                }
            }

            //Call mProperty.ChangeXAxisProperty(WRITE_PROPERTY, 3, nPropertyID, dVal, sVal)
            switch(nPropertyID)
            {
                case 1:   //AxisLine.Color
                    this._bizGraph._axsX.LineColor = Convert.ToInt32(sVal);
                    break;
                case 2:   //AxisLine.Style
                    _bizGraph._axsX.LineStyle = Convert.ToInt32(sVal);
                    break;

                case 3:   //AxisLine.Width
                _bizGraph._axsX.LineWidth = Convert.ToInt32(sVal);
                    break;

                case 4:   //Align
                    _bizGraph._axsX.Align = Convert.ToInt32(sVal);
                    break;

                case 5:   //Show
                    _bizGraph._axsX.Show = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 6:   //Direction
                    _bizGraph._axsX.Direction = Convert.ToInt32(sVal);
                    break;

                case 7:   //StartValue
                    _bizGraph._axsX.StartValue = Convert.ToDouble(sVal);
                    break;

                case 8:   //EndValue
                    _bizGraph._axsX.EndValue = Convert.ToDouble(sVal);
                    break;

                case 9:   //FloatFigure
                    _bizGraph._axsX.FloatFigure = Convert.ToInt32(sVal);
                    break;

                case 10:  //X
                    _bizGraph._axsX.X = Convert.ToInt32(sVal);
                    break;

                case 11:  //Y
                    _bizGraph._axsX.Y = Convert.ToInt32(sVal);
                    break;

                case 12:  //Length
                    _bizGraph._axsX.Length = Convert.ToInt32(sVal);
                    break;

                case 13:  //OffsetX
                    _bizGraph._axsX.OffsetX = Convert.ToInt32(sVal);
                    break;

                case 14:  //'OffsetY
                    _bizGraph._axsX.OffsetY = Convert.ToInt32(sVal);
                    break;

                case 15:  //ScaleCount
                    _bizGraph._axsX.ScaleCount = Convert.ToInt32(sVal);
                    break;

                case 16:  //ScaleLine.Color
                    _bizGraph._axsX.ScaleLineColor = Convert.ToInt32(sVal);
                    break;

                case 17:  //ScaleLine.Style
                    _bizGraph._axsX.ScaleLineStyle = Convert.ToInt32(sVal);
                    break;

                case 18:  //ScaleLine.Width
                    _bizGraph._axsX.ScaleLineWidth = Convert.ToInt32(sVal);
                    break;

                case 19:  //ValueColor
                    _bizGraph._axsX.ValueColor = Convert.ToInt32(sVal);
                    break;

                case 20:  //lablefont.Bold
                    _bizGraph._axsX.LabelFontBold = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 21:  //lablefont.Italic
                    _bizGraph._axsX.LabelFontItalic = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 22:  //lablefont.Name
                    _bizGraph._axsX.LabelFontName = sVal;//'"俵俽 俹僑僔僢僋"
                    break;

                case 23:  //lablefont.Size
                    _bizGraph._axsX.LabelFontSize = Convert.ToInt32(sVal);
                    break;

                case 24:  //lablefont.Underline
                    _bizGraph._axsX.LabelFontUnderline = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 25:  //add
        //'        newAxis = mProperty.AddItem(0)
        //'        MsgBox ("newAxis itemno is " & newAxis)
                    break;

                case 26:  //remove
        //'        GraphObj.RemoveItem (newAxis)
        //'        MsgBox ("itemno " & newAxis & " be removed.")

                     break;
               case 27:  //Zorder
                     _bizGraph._axsX.ZorderOcx = Convert.ToInt16(sVal);
                    break;

                case 28:  //Unit And Name
                    _bizGraph._axsX.UnitName = sVal;//'"[Unit Name 揷拞]"
                    break;

                }


        }

        /// <summary>
        /// 改变选中Y轴属性的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeYAxis_Click(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;
            int nGraph = 0;

            // If (mUserhandle = 0) Then Exit Sub

            nGraph = this.cmbItemID_YAxis.SelectedIndex;

            if (nGraph < 0)
            {
                MessageBox.Show("Please choose no zero item");
                return;
            }

            nPropertyID = this.cmbProperty_YAxis.SelectedIndex + 1;

            if (nPropertyID == 22 || nPropertyID == 28)
            {
                sVal = this.txtValue_YAxis.Text;
            }
            else
            {
                if (CastString.IsNumeric(this.txtValue_YAxis.Text))
                {
                    sVal = this.txtValue_YAxis.Text;
                }
                else
                {
                    MessageBox.Show("Please input Numeric");
                    return;
                }
            }

            //Call mProperty.ChangeXAxisProperty(WRITE_PROPERTY, 3, nPropertyID, dVal, sVal)
            switch (nPropertyID)
            {
                case 1:   //AxisLine.Color
                    this._bizGraph._axsY.LineColor = Convert.ToInt32(sVal);
                    break;
                case 2:   //AxisLine.Style
                    _bizGraph._axsY.LineStyle = Convert.ToInt32(sVal);
                    break;

                case 3:   //AxisLine.Width
                    _bizGraph._axsY.LineWidth = Convert.ToInt32(sVal);
                    break;

                case 4:   //Align
                    _bizGraph._axsY.Align = Convert.ToInt32(sVal);
                    break;

                case 5:   //Show
                    _bizGraph._axsY.Show = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 6:   //Direction
                    _bizGraph._axsY.Direction = Convert.ToInt32(sVal);
                    break;

                case 7:   //StartValue
                    _bizGraph._axsY.StartValue = Convert.ToDouble(sVal);
                    break;

                case 8:   //EndValue
                    _bizGraph._axsY.EndValue = Convert.ToDouble(sVal);
                    break;

                case 9:   //FloatFigure
                    _bizGraph._axsY.FloatFigure =  Convert.ToInt32(sVal);
                    break;

                case 10:  //X
                    _bizGraph._axsY.X = Convert.ToInt32(sVal);
                    break;

                case 11:  //Y
                    _bizGraph._axsY.Y = Convert.ToInt32(sVal);
                    break;

                case 12:  //Length
                    _bizGraph._axsY.Length = Convert.ToInt32(sVal);
                    break;

                case 13:  //OffsetX
                    _bizGraph._axsY.OffsetX = Convert.ToInt32(sVal);
                    break;

                case 14:  //'OffsetY
                    _bizGraph._axsY.OffsetY = Convert.ToInt32(sVal);
                    break;

                case 15:  //ScaleCount
                    _bizGraph._axsY.ScaleCount = Convert.ToInt32(sVal);
                    break;

                case 16:  //ScaleLine.Color
                    _bizGraph._axsY.ScaleLineColor = Convert.ToInt32(sVal);
                    break;

                case 17:  //ScaleLine.Style
                    _bizGraph._axsY.ScaleLineStyle = Convert.ToInt32(sVal);
                    break;

                case 18:  //ScaleLine.Width
                    _bizGraph._axsY.ScaleLineWidth = Convert.ToInt32(sVal);
                    break;

                case 19:  //ValueColor
                    _bizGraph._axsY.ValueColor = Convert.ToInt32(sVal);
                    break;

                case 20:  //lablefont.Bold
                    _bizGraph._axsY.LabelFontBold = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 21:  //lablefont.Italic
                    _bizGraph._axsY.LabelFontItalic = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 22:  //lablefont.Name
                    _bizGraph._axsY.LabelFontName = sVal;//'"俵俽 俹僑僔僢僋"
                    break;

                case 23:  //lablefont.Size
                    _bizGraph._axsY.LabelFontSize = Convert.ToInt32(sVal);
                    break;

                case 24:  //lablefont.Underline
                    _bizGraph._axsY.LabelFontUnderline = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 25:  //add
                    //'        newAxis = mProperty.AddItem(0)
                    //'        MsgBox ("newAxis itemno is " & newAxis)
                    break;

                case 26:  //remove
                    //'        GraphObj.RemoveItem (newAxis)
                    //'        MsgBox ("itemno " & newAxis & " be removed.")

                    break;
                case 27:  //Zorder
                    _bizGraph._axsY.ZorderOcx = Convert.ToInt16(sVal);
                    break;

                case 28:  //Unit And Name
                    _bizGraph._axsY.UnitName = sVal;//'"[Unit Name 揷拞]"
                    break;

            }

        }

        /// <summary>
        /// 改变选中区域属性的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeArea_Click(object sender, EventArgs e)
        {
               // If (mUserhandle = 0) Then Exit Sub
            string sVal = "";
            int nPropertyID = 0;
            int nGraph = 0;

               // If (mUserhandle = 0) Then Exit Sub
    
            nGraph = this.cmbItemID_Area.SelectedIndex;

            if (nGraph < 0)
            {
                MessageBox.Show("Please choose no zero item");
                return;
            }

            nPropertyID = this.cmbProperty_Area.SelectedIndex + 1;
    
    
            if( CastString.IsNumeric(this.txtValue_Area.Text))
            {
                sVal = this.txtValue_Area.Text;
            }
            else
            {
                MessageBox.Show( "Please input Numeric");
                return;
            }

            switch( nPropertyID )
            {
                case 1:   //left
                    this._bizGraph._area.Left = Convert.ToInt32(sVal);
                    break;
                
                case 2:  //right
                    _bizGraph._area.Right = Convert.ToInt32(sVal);
                     break;
               
                case 3:   //top
                     _bizGraph._area.Top = Convert.ToInt32(sVal);
                    break;
                
                case 4:   //bottom
                    _bizGraph._area.Bottom = Convert.ToInt32(sVal);
                     break;
               
                case 5:   //ColorBrush
                     _bizGraph._area.ColorBrush = Convert.ToInt32(sVal);
                     break;
               
                case 6:   //XAxis
                     _bizGraph._area.XAxis = Convert.ToInt32(sVal);
                    break;
                
                case 7:   //YAxis
                    _bizGraph._area.YAxis = Convert.ToInt32(sVal);
                    break;
                
                case 8:   //LeftValue
                    _bizGraph._area.LeftValue = Convert.ToInt32(sVal);
                     break;
               
                case 9:   //RightValue
                     _bizGraph._area.RightValue = Convert.ToInt32(sVal);
                     break;
               
                case 10:  //TopValue
                     _bizGraph._area.TopValue = Convert.ToInt32(sVal);
                     break;
               
                case 11:  //BottomValue
                     _bizGraph._area.BottomValue = Convert.ToInt32(sVal);
                     break;
                
                case 12:  //Show
                     _bizGraph._area.Show = ( 0 < Convert.ToInt32(sVal)) ? true : false;
                     break;
                  
                case 13:  //add
            //'         newArea = mProperty.AddItem(nItemNo)
            //'         MsgBox ("newArea id is " & newArea)
                     break;
               
                case 14:  //Remove
            //'         newArea = mProperty.AddItem(nItemNo)
            //'         MsgBox ("newArea id is " & newArea)
            //'         GraphObj.RemoveItem (newArea)
            //'         MsgBox ("newArea  " & newArea & " is removed.")
                     break;
               
                case 15:  //Clip
                     _bizGraph._area.Clip =( 0 < Convert.ToInt32(sVal)) ? true : false;
                     break;
               
                case 16:  //Zorder
                     _bizGraph._area.ZorderOcx = Convert.ToInt16(sVal);
                     break;
                   
               }
        }

        /// <summary>
        /// 改变选中网格属性的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeGrid_Click(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;
            int nGraph = 0;

            //If (mUserhandle = 0) Then Exit Sub

            nGraph = this.cmbItemID_Grid.SelectedIndex;

            if (nGraph < 0)
            {
                MessageBox.Show("Please choose no zero item");
                return;
            }

            nPropertyID = this.cmbProperty_Grid.SelectedIndex + 1;

            if (CastString.IsNumeric(this.txtValue_Grid.Text))
            {
                sVal = this.txtValue_Grid.Text;
            }
            else
            {
                MessageBox.Show("Please input Numeric");
                return;
            }

            switch( nPropertyID )
            {
                case 1:   //left
                    this._bizGraph._grid.Left = Convert.ToInt32(sVal); //'60
                    break;

                case 2:   //right
                    _bizGraph._grid.Right = Convert.ToInt32(sVal); //640
                    break;

                case 3:   //top
                    _bizGraph._grid.Top = Convert.ToInt32(sVal); //30
                    break;

                case 4:   //bottom
                    _bizGraph._grid.Bottom = Convert.ToInt32(sVal);//330
                    break;

                case 5:   //TransParent
                    _bizGraph._grid.TransParent = ( 0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 6:   //Show
                    _bizGraph._grid.Show = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 7:   //VertGridCount
                    _bizGraph._grid.VertCount = Convert.ToInt32(sVal);//'4
                    break;

                case 8:   //HorzGridCount
                    _bizGraph._grid.HorzCount = Convert.ToInt32(sVal);//'5
                    break;

                case 9:   //outpen.Style
                    _bizGraph._grid.OutLineStyle = Convert.ToInt32(sVal);// '0
                    break;

                case 10:  //outpen.Width
                    _bizGraph._grid.OutLineWidth = Convert.ToInt32(sVal);// '3
                    break;

                case 11:  //outpen.Color
                    _bizGraph._grid.OutLineColor = Convert.ToInt32(sVal);// 'RGB(255, 0, 0)
                    break;

                case 12:  //brushColor
                    _bizGraph._grid.BrushColor = Convert.ToInt32(sVal);// 'RGB(0, 128, 128)
                    break;

                case 13:  //inpen.Style
                    _bizGraph._grid.InLineStyle = Convert.ToInt32(sVal);// '4
                    break;

                case 14:  //inpen.Width
                    _bizGraph._grid.InLineWidth = Convert.ToInt32(sVal);// '2
                    break;

                case 15:  //inpen.Color
                    _bizGraph._grid.InLineColor = Convert.ToInt32(sVal);// 'RGB(0, 255, 255)
                    break;

                case 16:  //add
                    //'        dVal = GraphObj.AddItem(nItemNo)
                    //'        MsgBox ("newGird id is " & dVal)

                    break;
                case 17:  //Remove
                    //'        newGird = GraphObj.AddItem(nItemNo)
                    //'        MsgBox ("newGird id is " & newGird)
                    //'        GraphObj.RemoveItem (newGird)
                    //'        MsgBox ("newGrid  " & newGird & " is removed.")

                    break;
                case 18:  //Zorder
                    _bizGraph._grid.ZorderOcx = Convert.ToInt16(sVal);// '130
                    break;
            }


        }

        /// <summary>
        /// 改变选中直线属性的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeLine_Click(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;
            int nGraph = 0;

               // If (mUserhandle = 0) Then Exit Sub
    
            nGraph = this.cmbItemID_Line.SelectedIndex;

            if (nGraph < 0)
            {
                MessageBox.Show("Please choose no zero item");
                return;
            }

            nPropertyID = this.cmbProperty_Line.SelectedIndex + 1;
    
    
            if( CastString.IsNumeric(this.txtValue_Line.Text))
            {
                sVal = this.txtValue_Line.Text;
            }
            else
            {
                MessageBox.Show( "Please input Numeric");
                return;
            }

            switch( nPropertyID )
            {
                case 1:    //StartX
                    this._bizGraph._line.StartX = Convert.ToInt32(sVal); //'100
                    break;
                case 2:    //StartY
                    _bizGraph._line.StartY = Convert.ToInt32(sVal); //'100
                    break;
                case 3:    //EndX
                    _bizGraph._line.EndX = Convert.ToInt32(sVal); //'500
                    break;
                case 4:    //EndY
                    _bizGraph._line.EndY = Convert.ToInt32(sVal); //'500
                    break;
                case 5:    //linepen.Style
                    _bizGraph._line.Style = Convert.ToInt32(sVal); //'4
                    break;
                case 6:    //linepen.Width
                    _bizGraph._line.Width = Convert.ToInt32(sVal); //'2
                    break;
                case 7:    //linepen.Color
                    _bizGraph._line.Color = Convert.ToInt32(sVal); //'RGB(0, 0, 255)
                    break;
                case 8:    //'Show
                    _bizGraph._line.Show = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;
                case 9:    //'add
                //'        newLine = GraphObj.AddItem(nItemNo)
                //'        MsgBox ("newLine id is " & newLine)
                    break;
                case 10:  //'Remove
        //'        newLine = GraphObj.AddItem(nItemNo)
        //'        MsgBox ("newLine id is " & newLine)
        //'        GraphObj.RemoveItem (newLine)
        //'        MsgBox ("newLine  " & newLine & " is removed.")
                break;
                case 11:  //'Zorder
                _bizGraph._line.ZorderOcx = Convert.ToInt16(sVal); //'140
                    break;
                }

        }

        /// <summary>
        /// 改变选中矩形属性的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeShape_Click(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;
            int nGraph = 0;

            //If (mUserhandle = 0) Then Exit Sub
    
            nGraph = this.cmbItemID_Shape.SelectedIndex;

            if (nGraph < 0)
            {
                MessageBox.Show("Please choose no zero item");
                return;
            }
    
            nPropertyID = this.cmbProperty_Shape.SelectedIndex + 1;
    
            if( CastString.IsNumeric(this.txtValue_Shape.Text))
            {
                sVal = this.txtValue_Shape.Text;
            }
            else
            {
                MessageBox.Show( "Please input Numeric");
                return;
            }

    
    //Call mProperty.ChangeShapeProperty(WRITE_PROPERTY, 5, nPropertyID, dVal)
            switch( nPropertyID )
            {
                case 1:   //X
                   this._bizGraph._shape.X = Convert.ToInt32(sVal); //'80
                   break;
                case 2:   //Y
                   _bizGraph._shape.Y = Convert.ToInt32(sVal); //'80
                   break;

                case 3:   //Width
                   _bizGraph._shape.Width = Convert.ToInt32(sVal); //200
                   break;

                case 4:   //Height
                   _bizGraph._shape.Height = Convert.ToInt32(sVal); //200
                   break;

                case 5:   //Show
                   _bizGraph._shape.Show = (0 < Convert.ToInt32(sVal)) ? true : false;
                   break;

                case 6:   //sShapeAttr.BorderColor
                   _bizGraph._shape.BorderColor = Convert.ToInt32(sVal); //RGB(255, 0, 0)
                   break;

                case 7:   //sShapeAttr.FillColor
                   _bizGraph._shape.FillColor = Convert.ToInt32(sVal); //RGB(255, 255, 255)
                   break;

                case 8:   //sShapeAttr.FillPattern
                   _bizGraph._shape.FillPattern = Convert.ToInt32(sVal); //0
                   break;

                case 9:   //sShapeAttr.AdjustX
                   _bizGraph._shape.AdjustX = Convert.ToInt32(sVal); //5
                   break;

                case 10: //sShapeAttr.AdjustY
                   _bizGraph._shape.AdjustY = Convert.ToInt32(sVal); //5
                   break;

                case 11:  //sShapeAttr.Transparent
                   _bizGraph._shape.Transparent = (0 < Convert.ToInt32(sVal)) ? true : false;
                   break;

                case 12:  //add
            //'        newShape = GraphObj.AddItem(nItemNo)
            //'        MsgBox ("newShape id is " & newShape)
                   break;
                
                case 13:  //Remove
            //'        newShape = GraphObj.AddItem(nItemNo)
            //'        MsgBox ("newShape id is " & newShape)
            //'        GraphObj.RemoveItem (newShape)
            //'        MsgBox ("newShape  " & newShape & " is removed.")
                   break;
                   
                case 14:  //Zorder
                    _bizGraph._shape.ZorderOcx = Convert.ToInt16(sVal); //150
                    break;

                }
        }

        /// <summary>
        /// 改变选中文本属性的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeLabel_Click(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;
            int nGraph = 0;

            // If (mUserhandle = 0) Then Exit Sub

            nGraph = this.cmbItemID_Label.SelectedIndex;

            if (nGraph < 0)
            {
                MessageBox.Show("Please choose no zero item");
                return;
            }

            nPropertyID = this.cmbProperty_Label.SelectedIndex + 1;

            if (nPropertyID == 10 || nPropertyID == 13)
            {
                sVal = this.txtValue_Label.Text;
            }
            else
            {
                if (CastString.IsNumeric(this.txtValue_Label.Text))
                {
                    sVal = this.txtValue_Label.Text;
                }
                else
                {
                    MessageBox.Show("Please input Numeric");
                    return;
                }
            }

            switch( nPropertyID)
            {
                case 1:   //Align           UP = 0  DOWN = 1  LEFT = 2  CENTER = 3  RIGHT = 4
                    this._bizGraph._label.Align  = Convert.ToInt32(sVal); //'1
                    break;

                case 2:   //Show          Show = 1  Invisable = 0
                    _bizGraph._label.Show = (0 < Convert.ToInt32(sVal)) ? true : false; //True
                    break;

                case 3:   //Direction     X_AXIS_DIRECTION = 0   Y_AXIS_DIRECTION = 1
                    _bizGraph._label.Direction = Convert.ToInt32(sVal); // '1
                    break;

                case 4:   //X
                    _bizGraph._label.X = Convert.ToInt32(sVal); //'200
                    break;

                case 5:   //Y
                    _bizGraph._label.Y = Convert.ToInt32(sVal); // '200
                    break;

                case 6:   //ForeColor
                    _bizGraph._label.ForeColor = Convert.ToInt32(sVal); // 'RGB(255, 0, 0)
                    break;

                case 7:   //BackColor
                    _bizGraph._label.BackColor = Convert.ToInt32(sVal); // 'RGB(0, 0, 0)
                    break;

                case 8:   //lablefont.Bold
                    _bizGraph._label.FontBold = (0 < Convert.ToInt32(sVal)) ? true : false; //False
                    break;

                case 9:   //lablefont.Italic
                    _bizGraph._label.FontItalic = (0 < Convert.ToInt32(sVal)) ? true : false; //False
                    break;

                case 10:  //lablefont.Name
                    _bizGraph._label.FontName = sVal; //'"俵俽 俹僑僔僢僋"
                    break;
   
                case 11:   //lablefont.Size
                    _bizGraph._label.FontSize = Convert.ToInt32(sVal); // '20
                    break;

                case 12:   //lablefont.Underline
                    _bizGraph._label.FontUnderline = (0 < Convert.ToInt32(sVal)) ? true : false;//'False
                    break;

                case 13:   //Text
                    _bizGraph._label.Text = sVal; // 'SetLabelText(nItemNo, 6, sVal)  '"123戝岲偒"
                    break;

                case 14:   //add
            //'        newLabel = GraphObj.AddItem(nItemNo)
            //'        MsgBox ("newLabel id is " & newLabel)
                     break;

                case 15:   //remove
    //'        newLabel = GraphObj.AddItem(nItemNo)
    //'        MsgBox ("newLabel id is " & newLabel)
    //'        GraphObj.RemoveItem (newLabel)
    //'        MsgBox ("newLabel  " & newLabel & " is removed.")
                     break;

                case 16:   //Zorder
                    _bizGraph._label.ZorderOcx = Convert.ToInt16(sVal); // '160
                     break;
   
            }


        }

        /// <summary>
        /// 改变控件背景颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblBkColor_Click(object sender, EventArgs e)
        {
            this.colorDlgBK.Color = this._bizGraph.GetBkColor();
            this.colorDlgBK.ShowDialog();
            this._bizGraph.SetBkColor(this.colorDlgBK.Color);
            this.lblBkColor.BackColor = this.colorDlgBK.Color;
        }

        /// <summary>
        /// 重新设置曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestDataTo1000_Click(object sender, EventArgs e)
        {
            this.btnRestDataTo1000.Enabled = false;

            DateTime timeStart = DateTime.Now;

            int count = Convert.ToInt32(this.nemUDPlotCount.Value.ToString());
            this._bizGraph.ResetPlot( count);

            string consumed = String.Format("{0} point ResetPlot Total time:{1} ms", count, (DateTime.Now - timeStart).TotalMilliseconds);
            Console.Out.WriteLine(consumed);

            this.btnRestDataTo1000.Enabled = true;
        }

        /// <summary>
        /// 增加一条曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPlot_Click(object sender, EventArgs e)
        {
            this._bizGraph.AddPlot();
        }

        /// <summary>
        /// 启动或者停止送数据线程
        /// </summary>
        /// <param name="online"></param>
        public void SetOnline(bool online)
        {
            if (online)
            {
                int count = Convert.ToInt32(this.nemUDPlotCount.Value.ToString());
                this._bizGraph.StartSimu(count);
            }
            else
            {
                this._bizGraph.StopSimu();
            }
            this.btnRestDataTo1000.Enabled = !online;

        }

        /// <summary>
        /// 插入指定大小的数据
        /// </summary>
        public void UpdateDbFile()
        {
            int count = Convert.ToInt32(this.nemUDPlotCount.Value.ToString());
            this._bizGraph.InsertToFile(count);
        }

        #endregion







    }
}
