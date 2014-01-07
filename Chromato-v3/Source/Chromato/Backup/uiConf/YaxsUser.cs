/*-----------------------------------------------------------------------------
//  FILE NAME       : YaxsUser.cs
//  FUNCTION        : YaxsUser
//  AUTHOR          : 李锋(2009/03/10)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoBll.ocx;
using ChromatoTool.util;

namespace ChromatoCore.uiConf
{
    /// <summary>
    /// Y轴配置
    /// </summary>
    public partial class YaxsUser : UserControl
    {
        /// <summary>
        /// 构造
        /// </summary>
        public YaxsUser()
        {
            InitializeComponent();
            LoadYAxisID();
            LoadYAxis();
        }

        /// <summary>
        /// 装载Y轴ID
        /// </summary>
        private void LoadYAxisID()
        {
            this.cmbItemID_YAxis.Items.Clear();
            this.cmbItemID_YAxis.Items.Add(OffGraphBiz.Instance.GetAxisYID());
            this.cmbItemID_YAxis.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载Y轴属性
        /// </summary>
        private void LoadYAxis()
        {
            this.lsbAxsY.Items.Add("AxisLine.Color");
            this.lsbAxsY.Items.Add("AxisLine.Style");
            this.lsbAxsY.Items.Add("AxisLine.Width");
            this.lsbAxsY.Items.Add("Align");
            this.lsbAxsY.Items.Add("Show");
            this.lsbAxsY.Items.Add("Direction");
            this.lsbAxsY.Items.Add("StartValue");
            this.lsbAxsY.Items.Add("EndValue");
            this.lsbAxsY.Items.Add("FloatFigure");
            this.lsbAxsY.Items.Add("X");
            this.lsbAxsY.Items.Add("Y");
            this.lsbAxsY.Items.Add("Length");
            this.lsbAxsY.Items.Add("OffsetX");
            this.lsbAxsY.Items.Add("OffsetY");
            this.lsbAxsY.Items.Add("ScaleCount");
            this.lsbAxsY.Items.Add("ScaleLine.Color");
            this.lsbAxsY.Items.Add("ScaleLine.Style");
            this.lsbAxsY.Items.Add("ScaleLine.Width");
            this.lsbAxsY.Items.Add("ValueColor");
            this.lsbAxsY.Items.Add("lablefont.Bold");
            this.lsbAxsY.Items.Add("lablefont.Italic");
            this.lsbAxsY.Items.Add("lablefont.Name");
            this.lsbAxsY.Items.Add("lablefont.Size");
            this.lsbAxsY.Items.Add("lablefont.Underline");
            this.lsbAxsY.Items.Add("add");
            this.lsbAxsY.Items.Add("Remove");
            this.lsbAxsY.Items.Add("Zorder");
            this.lsbAxsY.Items.Add("UnitAndName");
            this.lsbAxsY.SelectedIndex = 0;
        }

        /// <summary>
        /// Y轴选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbAxsY_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = 0;
            int nGraph = 0;

            nPropertyID = this.lsbAxsY.SelectedIndex + 1;

            nGraph = this.cmbItemID_YAxis.SelectedIndex;

            if (nGraph < 0)
            {
                MessageBox.Show("Please choose no zero item");
                return;
            }


            switch (nPropertyID)
            {
                case 1:   //AxisLine.Color
                    sVal = OffGraphBiz.Instance._axsY.LineColor.ToString();
                    break;

                case 2:   //AxisLine.Style
                    sVal = OffGraphBiz.Instance._axsY.LineStyle.ToString();
                    break;

                case 3:   //AxisLine.Width
                    sVal = OffGraphBiz.Instance._axsY.LineWidth.ToString();
                    break;

                case 4:   //Align
                    sVal = OffGraphBiz.Instance._axsY.Align.ToString();
                    break;

                case 5:  //Show
                    sVal = OffGraphBiz.Instance._axsY.Show.ToString();
                    break;
                case 6:   //Direction
                    sVal = OffGraphBiz.Instance._axsY.Direction.ToString();
                    break;
                case 7:   //StartValue
                    sVal = OffGraphBiz.Instance._axsY.StartValue.ToString();
                    break;
                case 8:   //EndValue
                    sVal = OffGraphBiz.Instance._axsY.EndValue.ToString();
                    break;
                case 9:   //FloatFigure
                    sVal = OffGraphBiz.Instance._axsY.FloatFigure.ToString();
                    break;
                case 10:   //X
                    sVal = OffGraphBiz.Instance._axsY.X.ToString();
                    break;
                case 11:   //Y
                    sVal = OffGraphBiz.Instance._axsY.Y.ToString();
                    break;
                case 12:   //Length
                    sVal = OffGraphBiz.Instance._axsY.Length.ToString();
                    break;
                case 13:   //OffsetX
                    sVal = OffGraphBiz.Instance._axsY.OffsetX.ToString();
                    break;
                case 14:   //OffsetY
                    sVal = OffGraphBiz.Instance._axsY.OffsetY.ToString();
                    break;
                case 15:   //ScaleCount
                    sVal = OffGraphBiz.Instance._axsY.ScaleCount.ToString();
                    break;
                case 16:   //ScaleLine.Color
                    sVal = OffGraphBiz.Instance._axsY.ScaleLineColor.ToString();
                    break;
                case 17:   //ScaleLine.Style
                    sVal = OffGraphBiz.Instance._axsY.ScaleLineStyle.ToString();
                    break;
                case 18:   //ScaleLine.Width
                    sVal = OffGraphBiz.Instance._axsY.ScaleLineWidth.ToString();
                    break;
                case 19:   //ValueColor
                    sVal = OffGraphBiz.Instance._axsY.ValueColor.ToString();
                    break;
                case 20:   //lablefont.Bold
                    sVal = OffGraphBiz.Instance._axsY.LabelFontBold.ToString();
                    break;
                case 21:   //lablefont.Italic
                    sVal = OffGraphBiz.Instance._axsY.LabelFontItalic.ToString();
                    break;

                case 22:   //lablefont.Name
                    sVal = OffGraphBiz.Instance._axsY.LabelFontName.ToString(); // '"俵俽 俹僑僔僢僋"
                    break;

                case 23:   //lablefont.Size
                    sVal = OffGraphBiz.Instance._axsY.LabelFontSize.ToString();
                    break;

                case 24:   //lablefont.Underline
                    sVal = OffGraphBiz.Instance._axsY.LabelFontUnderline.ToString();
                    break;

                case 25:   //add
                    break;

                case 26:   //remove
                    break;

                case 27:   //Zorder
                    sVal = OffGraphBiz.Instance._axsY.ZorderOcx.ToString();
                    break;

                case 28: //Unit And Name
                    sVal = OffGraphBiz.Instance._axsY.UnitName.ToString();
                    break;

            }


            this.txtValue_YAxis.Text = sVal;
        }

        /// <summary>
        /// 改变选中Y轴属性的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeYAxis_Click(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = this.lsbAxsY.SelectedIndex + 1;

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

            switch (nPropertyID)
            {
                case 1:   //AxisLine.Color
                    OffGraphBiz.Instance._axsY.LineColor = Convert.ToInt32(sVal);
                    break;
                case 2:   //AxisLine.Style
                    OffGraphBiz.Instance._axsY.LineStyle = Convert.ToInt32(sVal);
                    break;

                case 3:   //AxisLine.Width
                    OffGraphBiz.Instance._axsY.LineWidth = Convert.ToInt32(sVal);
                    break;

                case 4:   //Align
                    OffGraphBiz.Instance._axsY.Align = Convert.ToInt32(sVal);
                    break;

                case 5:   //Show
                    OffGraphBiz.Instance._axsY.Show = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 6:   //Direction
                    OffGraphBiz.Instance._axsY.Direction = Convert.ToInt32(sVal);
                    break;

                case 7:   //StartValue
                    OffGraphBiz.Instance._axsY.StartValue = Convert.ToDouble(sVal);
                    break;

                case 8:   //EndValue
                    OffGraphBiz.Instance._axsY.EndValue = Convert.ToDouble(sVal);
                    break;

                case 9:   //FloatFigure
                    OffGraphBiz.Instance._axsY.FloatFigure = Convert.ToInt32(sVal);
                    break;

                case 10:  //X
                    OffGraphBiz.Instance._axsY.X = Convert.ToInt32(sVal);
                    break;

                case 11:  //Y
                    OffGraphBiz.Instance._axsY.Y = Convert.ToInt32(sVal);
                    break;

                case 12:  //Length
                    OffGraphBiz.Instance._axsY.Length = Convert.ToInt32(sVal);
                    break;

                case 13:  //OffsetX
                    OffGraphBiz.Instance._axsY.OffsetX = Convert.ToInt32(sVal);
                    break;

                case 14:  //'OffsetY
                    OffGraphBiz.Instance._axsY.OffsetY = Convert.ToInt32(sVal);
                    break;

                case 15:  //ScaleCount
                    OffGraphBiz.Instance._axsY.ScaleCount = Convert.ToInt32(sVal);
                    break;

                case 16:  //ScaleLine.Color
                    OffGraphBiz.Instance._axsY.ScaleLineColor = Convert.ToInt32(sVal);
                    break;

                case 17:  //ScaleLine.Style
                    OffGraphBiz.Instance._axsY.ScaleLineStyle = Convert.ToInt32(sVal);
                    break;

                case 18:  //ScaleLine.Width
                    OffGraphBiz.Instance._axsY.ScaleLineWidth = Convert.ToInt32(sVal);
                    break;

                case 19:  //ValueColor
                    OffGraphBiz.Instance._axsY.ValueColor = Convert.ToInt32(sVal);
                    break;

                case 20:  //lablefont.Bold
                    OffGraphBiz.Instance._axsY.LabelFontBold = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 21:  //lablefont.Italic
                    OffGraphBiz.Instance._axsY.LabelFontItalic = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 22:  //lablefont.Name
                    OffGraphBiz.Instance._axsY.LabelFontName = sVal;//'"俵俽 俹僑僔僢僋"
                    break;

                case 23:  //lablefont.Size
                    OffGraphBiz.Instance._axsY.LabelFontSize = Convert.ToInt32(sVal);
                    break;

                case 24:  //lablefont.Underline
                    OffGraphBiz.Instance._axsY.LabelFontUnderline = (0 < Convert.ToInt32(sVal)) ? true : false;
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
                    OffGraphBiz.Instance._axsY.ZorderOcx = Convert.ToInt16(sVal);
                    break;

                case 28:  //Unit And Name
                    OffGraphBiz.Instance._axsY.UnitName = sVal;//'"[Unit Name 揷拞]"
                    break;

            }

        }
    }
}
