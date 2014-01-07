/*-----------------------------------------------------------------------------
//  FILE NAME       : PlotUser.cs
//  FUNCTION        : PlotUser
//  AUTHOR          : 李锋(2009/03/10)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoTool.util;
using ChromatoBll.ocx;
using ChromatoTool.ini;

namespace ChromatoCore.uiConf
{

    /// <summary>
    /// 曲线配置
    /// </summary>
    public partial class PlotUser : UserControl
    {

        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public PlotUser()
        {
            InitializeComponent();
            LoadPlotID();
            LoadPlot();
            LoadPara();
        }

        /// <summary>
        /// 装载参数
        /// </summary>
        private void LoadPara()
        {
            this.numUDPlotCount.Value = General.ShowCount;
            this.rbSin.Checked = (ChromatoTool.ini.Offline.PlotType == SimuType.Sin);
            this.rbRandom.Checked = (ChromatoTool.ini.Offline.PlotType == SimuType.Random);
            this.rbSinRandom.Checked = (ChromatoTool.ini.Offline.PlotType == SimuType.SinRandom);
        }

        /// <summary>
        /// 装载曲线ID
        /// </summary>
        private void LoadPlotID()
        {
            int count = 0;
            String[] sID = null;

            OffGraphBiz.Instance.GetPlotID(ref count, ref sID);
            this.cmbItemID_Plot.Items.Clear();
            for (int i = 0; i < sID.Length; i++)
            {
                this.cmbItemID_Plot.Items.Add(sID[i].ToString());
            }
            this.cmbItemID_Plot.SelectedIndex = 0;

        }

        /// <summary>
        /// 装载曲线属性
        /// </summary>
        private void LoadPlot()
        {
            this.lsbPlot.Items.Add("Area");
            this.lsbPlot.Items.Add("DataCount");
            this.lsbPlot.Items.Add("dataline.Style");
            this.lsbPlot.Items.Add("dataline.Width");
            this.lsbPlot.Items.Add("dataline.Color");
            this.lsbPlot.Items.Add("Show");
            this.lsbPlot.Items.Add("ShowMarker");
            this.lsbPlot.Items.Add("StartXValue");
            this.lsbPlot.Items.Add("StartYValue");
            this.lsbPlot.Items.Add("EndXValue");
            this.lsbPlot.Items.Add("EndYValue");
            this.lsbPlot.Items.Add("marker.Bordercolor");
            this.lsbPlot.Items.Add("marker.Borderwidth");
            this.lsbPlot.Items.Add("marker.Fillcolor");
            this.lsbPlot.Items.Add("marker.Size");
            this.lsbPlot.Items.Add("marker.Style");
            this.lsbPlot.Items.Add("marker.Transparent");
            this.lsbPlot.Items.Add("Zorder");
            this.lsbPlot.Items.Add("RemoveAllDataLabels");
            this.lsbPlot.Items.Add("add");
            this.lsbPlot.Items.Add("Remove");
            this.lsbPlot.Items.Add("Setdata");
            this.lsbPlot.Items.Add("MarkerState");
            this.lsbPlot.SelectedIndex = 2;
        }

        #endregion


        #region 重置,在线,属性改变

        /// <summary>
        /// 曲线选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbPlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;

            nPropertyID = this.lsbPlot.SelectedIndex + 1;

            switch ((PlotProperty)nPropertyID)
            {
                case PlotProperty.Area:     //Area
                    sVal = OffGraphBiz.Instance._plot.Area.ToString();
                    break;

                case PlotProperty.DataCount:     //DataCount
                    sVal = OffGraphBiz.Instance._plot.DataCount.ToString();
                    break;

                case PlotProperty.dataline_Style:     //dataline.Style
                    sVal = OffGraphBiz.Instance._plot.DatalineStyle.ToString();
                    break;

                case PlotProperty.dataline_Width:     //dataline.Width
                    sVal = OffGraphBiz.Instance._plot.DatalineWidth.ToString();
                    break;

                case PlotProperty.dataline_Color:     //dataline.Color
                    sVal = OffGraphBiz.Instance._plot.DatalineColor.ToString();
                    break;

                case PlotProperty.Show:     //Show
                    sVal = OffGraphBiz.Instance._plot.Show.ToString();
                    break;

                case PlotProperty.ShowMarker:     //ShowMarker
                    sVal = OffGraphBiz.Instance._plot.ShowMarker.ToString();
                    break;

                case PlotProperty.StartXValue:    //StartXValue
                    sVal = OffGraphBiz.Instance._plot.StartXValue.ToString();
                    break;

                case PlotProperty.StartYValue:     //StartYValue
                    sVal = OffGraphBiz.Instance._plot.StartYValue.ToString();
                    break;

                case PlotProperty.EndXValue:    //EndXValue
                    sVal = OffGraphBiz.Instance._plot.EndXValue.ToString();
                    break;

                case PlotProperty.EndYValue:    //EndYValue
                    sVal = OffGraphBiz.Instance._plot.EndYValue.ToString();
                    break;

                case PlotProperty.marker_Bordercolor:    //marker.Bordercolor
                    sVal = OffGraphBiz.Instance._plot.MarkerBordercolor.ToString();
                    break;

                case PlotProperty.marker_Borderwidth:    //marker.Borderwidth
                    sVal = OffGraphBiz.Instance._plot.MarkerBorderwidth.ToString();
                    break;

                case PlotProperty.marker_Fillcolor:    //marker.Fillcolor
                    sVal = OffGraphBiz.Instance._plot.MarkerFillColor.ToString();
                    break;

                case PlotProperty.marker_Size:    //marker.Size
                    sVal = OffGraphBiz.Instance._plot.MarkerSize.ToString();
                    break;

                case PlotProperty.marker_Style:   //marker.Style
                    sVal = OffGraphBiz.Instance._plot.MarkerStyle.ToString();
                    break;

                case PlotProperty.marker_Transparent:    //marker.Transparent
                    sVal = OffGraphBiz.Instance._plot.MarkerTransparent.ToString();
                    break;

                case PlotProperty.Zorder:    //Zorder
                    sVal = OffGraphBiz.Instance._plot.ZorderOcx.ToString();
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
                    sVal = OffGraphBiz.Instance._plot.GetMarkerState(5).ToString();
                    break;
            }

            this.txtValue_Plot.Text = sVal;
        }

        /// <summary>
        /// 改变选中曲线属性的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangePlot_Click(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;

            long iValueCount = 0;

            nPropertyID = this.lsbPlot.SelectedIndex + 1;

            if (CastString.IsNumeric(this.txtValue_Plot.Text))
            {
                sVal = this.txtValue_Plot.Text;
            }
            else
            {
                MessageBox.Show("Please input Numeric");
                return;
            }

            switch (nPropertyID)
            {
                case 1:    //Area
                    OffGraphBiz.Instance._plot.Area = Convert.ToInt32(sVal);
                    break;

                case 2:    //DataCount
                    OffGraphBiz.Instance._plot.DataCount = Convert.ToInt32(sVal);
                    break;

                case 3:    //'dataline.Style
                    OffGraphBiz.Instance._plot.DatalineStyle = Convert.ToInt32(sVal);
                    break;

                case 4:    //'dataline.Width
                    OffGraphBiz.Instance._plot.DatalineWidth = Convert.ToInt32(sVal);
                    break;

                case 5:    //'dataline.Color
                    OffGraphBiz.Instance._plot.DatalineColor = Convert.ToInt32(sVal);
                    break;

                case 6:    //'Show
                    OffGraphBiz.Instance._plot.Show = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 7:    //'ShowMarker
                    OffGraphBiz.Instance._plot.ShowMarker = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 8:    //'StartXValue
                    OffGraphBiz.Instance._plot.StartXValue = Convert.ToInt32(sVal);
                    break;

                case 9:    //'StartYValue
                    OffGraphBiz.Instance._plot.StartYValue = Convert.ToInt32(sVal);
                    break;

                case 10:   //'EndXValue
                    OffGraphBiz.Instance._plot.EndXValue = Convert.ToInt32(sVal);
                    break;

                case 11:   //'EndYValue
                    OffGraphBiz.Instance._plot.EndYValue = Convert.ToInt32(sVal);
                    break;

                case 12:   //'marker.Bordercolor
                    OffGraphBiz.Instance._plot.MarkerBordercolor = Convert.ToInt32(sVal);
                    break;

                case 13:   //'marker.Borderwidth
                    OffGraphBiz.Instance._plot.MarkerBorderwidth = Convert.ToInt32(sVal);
                    break;

                case 14:   //'marker.Fillcolor
                    OffGraphBiz.Instance._plot.MarkerFillColor = Convert.ToInt32(sVal);
                    break;

                case 15:   //'marker.Size
                    OffGraphBiz.Instance._plot.MarkerSize = Convert.ToInt32(sVal);
                    break;

                case 16:   //'marker.Style
                    OffGraphBiz.Instance._plot.MarkerStyle = Convert.ToInt32(sVal);
                    break;

                case 17:   //'marker.Transparent
                    OffGraphBiz.Instance._plot.MarkerTransparent = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 18:   //'Zorder
                    OffGraphBiz.Instance._plot.ZorderOcx = Convert.ToInt16(sVal);
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
                    iValueCount = OffGraphBiz.Instance._plot.DataCount;

                    for (int i = 0; i < iValueCount; i++)
                    {
                        OffGraphBiz.Instance._plot.SetMarkerState(i, (0 < Convert.ToInt32(sVal)) ? true : false);
                    }

                    break;
            }
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

            OffGraphBiz.Instance.ResetPlot(General.ShowCount);

            string consumed = String.Format("{0} point ResetPlot Total time:{1} ms",
                ChromatoTool.ini.Offline.FullScreenTime * General.Frequent * DefaultItem.SecondsPerMin,
                (DateTime.Now - timeStart).TotalMilliseconds);
            Console.Out.WriteLine(consumed);

            this.btnRestDataTo1000.Enabled = true;
        }

        #endregion


        #region 参数更新

        /// <summary>
        /// 满屏显示参数修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nemUDPlotCount_ValueChanged(object sender, EventArgs e)
        {
            General.ShowCount = Convert.ToInt32(this.numUDPlotCount.Value.ToString());
        }


        /// <summary>
        /// 曲线类型参数更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbSin_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbSin.Checked)
            {
                Offline.PlotType = SimuType.Sin;
            }
        }

        /// <summary>
        /// 曲线类型参数更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbRandom.Checked)
            {
                Offline.PlotType = SimuType.Random;
            }
        }

        /// <summary>
        /// 曲线类型参数更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbSinRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbSinRandom.Checked)
            {
                Offline.PlotType = SimuType.SinRandom;
            }

        }

        #endregion


        #region  曲线追加

        /// <summary>
        /// 追加一条相同曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPlot_Click(object sender, EventArgs e)
        {
            OffGraphBiz.Instance.AddPlot();
            this.LoadPlotID();
        }

        /// <summary>
        /// id选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbItemID_Plot_SelectedIndexChanged(object sender, EventArgs e)
        {
            String temp = this.cmbItemID_Plot.SelectedItem.ToString();
            if (String.IsNullOrEmpty(temp))
            {
                return;
            }
            //更新当前曲线
            OffGraphBiz.Instance.UpdateCurrentPlot(Convert.ToInt16(temp));
            //更新列表框
            this.lsbPlot_SelectedIndexChanged(null, null);
        }

        /// <summary>
        /// 插入新的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertDb_Click(object sender, EventArgs e)
        {
            //ParaBiz.Instance.InsertToFile(General.ShowCount);
        }

        #endregion



    }
}
