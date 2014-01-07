/*-----------------------------------------------------------------------------
//  FILE NAME       : XaxsUser.cs
//  FUNCTION        : XaxsUser
//  AUTHOR          : 李锋(2009/03/10)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoBll.ocx;
using ChromatoTool.ini;
using ChromatoTool.util;

namespace ChromatoCore.uiConf
{
    /// <summary>
    /// X轴配置
    /// </summary>
    public partial class XaxsUser : UserControl
    {
        /// <summary>
        /// 构造
        /// </summary>
        public XaxsUser()
        {
            InitializeComponent();
            LoadXAxisID();
            LoadXAxis();
        }

        /// <summary>
        /// 装载X轴ID
        /// </summary>
        private void LoadXAxisID()
        {
            this.cmbItemID_XAxis.Items.Clear();
            this.cmbItemID_XAxis.Items.Add(OffGraphBiz.Instance.GetAxisXID());
            this.cmbItemID_XAxis.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载X轴属性
        /// </summary>
        private void LoadXAxis()
        {

            this.lsbAxsX.Items.Add("AxisLine.Color");
            this.lsbAxsX.Items.Add("AxisLine.Style");
            this.lsbAxsX.Items.Add("AxisLine.Width");
            this.lsbAxsX.Items.Add("Align");
            this.lsbAxsX.Items.Add("Show");
            this.lsbAxsX.Items.Add("Direction");
            this.lsbAxsX.Items.Add("StartValue");
            this.lsbAxsX.Items.Add("EndValue");
            this.lsbAxsX.Items.Add("FloatFigure");
            this.lsbAxsX.Items.Add("X");
            this.lsbAxsX.Items.Add("Y");
            this.lsbAxsX.Items.Add("Length");
            this.lsbAxsX.Items.Add("OffsetX");
            this.lsbAxsX.Items.Add("OffsetY");
            this.lsbAxsX.Items.Add("ScaleCount");
            this.lsbAxsX.Items.Add("ScaleLine.Color");
            this.lsbAxsX.Items.Add("ScaleLine.Style");
            this.lsbAxsX.Items.Add("ScaleLine.Width");
            this.lsbAxsX.Items.Add("ValueColor");
            this.lsbAxsX.Items.Add("lablefont.Bold");
            this.lsbAxsX.Items.Add("lablefont.Italic");
            this.lsbAxsX.Items.Add("lablefont.Name");
            this.lsbAxsX.Items.Add("lablefont.Size");
            this.lsbAxsX.Items.Add("lablefont.Underline");
            this.lsbAxsX.Items.Add("add");
            this.lsbAxsX.Items.Add("Remove");
            this.lsbAxsX.Items.Add("Zorder");
            this.lsbAxsX.Items.Add("UnitAndName");
            this.lsbAxsX.SelectedIndex = 0;
        }

        /// <summary>
        /// X轴选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbAxsX_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = this.lsbAxsX.SelectedIndex + 1;

            switch ((AxisProperty)nPropertyID)
            {
                case AxisProperty.AxisLine_Color:   //AxisLine.Color
                    sVal = OffGraphBiz.Instance._axsX.LineColor.ToString();
                    break;

                case AxisProperty.AxisLine_Style:   //AxisLine.Style
                    sVal = OffGraphBiz.Instance._axsX.LineStyle.ToString();
                    break;

                case AxisProperty.AxisLine_Width:   //AxisLine.Width
                    sVal = OffGraphBiz.Instance._axsX.LineWidth.ToString();
                    break;

                case AxisProperty.Align:   //Align
                    sVal = OffGraphBiz.Instance._axsX.Align.ToString();
                    break;

                case AxisProperty.Show:  //Show
                    sVal = OffGraphBiz.Instance._axsX.Show.ToString();
                    break;
                case AxisProperty.Direction:   //Direction
                    sVal = OffGraphBiz.Instance._axsX.Direction.ToString();
                    break;
                case AxisProperty.StartValue:   //StartValue
                    sVal = OffGraphBiz.Instance._axsX.StartValue.ToString();
                    break;
                case AxisProperty.EndValue:   //EndValue
                    sVal = OffGraphBiz.Instance._axsX.EndValue.ToString();
                    break;
                case AxisProperty.FloatFigure:   //FloatFigure
                    sVal = OffGraphBiz.Instance._axsX.FloatFigure.ToString();
                    break;
                case AxisProperty.X:   //X
                    sVal = OffGraphBiz.Instance._axsX.X.ToString();
                    break;
                case AxisProperty.Y:   //Y
                    sVal = OffGraphBiz.Instance._axsX.Y.ToString();
                    break;
                case AxisProperty.Length:   //Length
                    sVal = OffGraphBiz.Instance._axsX.Length.ToString();
                    break;
                case AxisProperty.OffsetX:   //OffsetX
                    sVal = OffGraphBiz.Instance._axsX.OffsetX.ToString();
                    break;
                case AxisProperty.OffsetY:   //OffsetY
                    sVal = OffGraphBiz.Instance._axsX.OffsetY.ToString();
                    break;
                case AxisProperty.ScaleCount:   //ScaleCount
                    sVal = OffGraphBiz.Instance._axsX.ScaleCount.ToString();
                    break;
                case AxisProperty.ScaleLine_Color:   //ScaleLine.Color
                    sVal = OffGraphBiz.Instance._axsX.ScaleLineColor.ToString();
                    break;
                case AxisProperty.ScaleLine_Style:   //ScaleLine.Style
                    sVal = OffGraphBiz.Instance._axsX.ScaleLineStyle.ToString();
                    break;
                case AxisProperty.ScaleLine_Width:   //ScaleLine.Width
                    sVal = OffGraphBiz.Instance._axsX.ScaleLineWidth.ToString();
                    break;
                case AxisProperty.ValueColor:   //ValueColor
                    sVal = OffGraphBiz.Instance._axsX.ValueColor.ToString();
                    break;
                case AxisProperty.lablefont_Bold:   //lablefont.Bold
                    sVal = OffGraphBiz.Instance._axsX.LabelFontBold.ToString();
                    break;
                case AxisProperty.lablefont_Italic:   //lablefont.Italic
                    sVal = OffGraphBiz.Instance._axsX.LabelFontItalic.ToString();
                    break;

                case AxisProperty.lablefont_Name:   //lablefont.Name
                    sVal = OffGraphBiz.Instance._axsX.LabelFontName.ToString(); // '"俵俽 俹僑僔僢僋"
                    break;

                case AxisProperty.lablefont_Size:   //lablefont.Size
                    sVal = OffGraphBiz.Instance._axsX.LabelFontSize.ToString();
                    break;

                case AxisProperty.lablefont_Underline:   //lablefont.Underline
                    sVal = OffGraphBiz.Instance._axsX.LabelFontUnderline.ToString();
                    break;

                case AxisProperty.add:   //add
                    break;

                case AxisProperty.Remove:   //remove
                    break;

                case AxisProperty.Zorder:   //Zorder
                    sVal = OffGraphBiz.Instance._axsX.ZorderOcx.ToString();
                    break;

                case AxisProperty.UnitAndName: //Unit And Name
                    sVal = OffGraphBiz.Instance._axsX.UnitName.ToString();
                    break;

            }


            this.txtValue_XAxis.Text = sVal;
        }

        /// <summary>
        /// 改变选中X轴属性的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeXAxis_Click(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = this.lsbAxsX.SelectedIndex + 1;

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

            switch (nPropertyID)
            {
                case 1:   //AxisLine.Color
                    OffGraphBiz.Instance._axsX.LineColor = Convert.ToInt32(sVal);
                    break;
                case 2:   //AxisLine.Style
                    OffGraphBiz.Instance._axsX.LineStyle = Convert.ToInt32(sVal);
                    break;

                case 3:   //AxisLine.Width
                    OffGraphBiz.Instance._axsX.LineWidth = Convert.ToInt32(sVal);
                    break;

                case 4:   //Align
                    OffGraphBiz.Instance._axsX.Align = Convert.ToInt32(sVal);
                    break;

                case 5:   //Show
                    OffGraphBiz.Instance._axsX.Show = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 6:   //Direction
                    OffGraphBiz.Instance._axsX.Direction = Convert.ToInt32(sVal);
                    break;

                case 7:   //StartValue
                    OffGraphBiz.Instance._axsX.StartValue = Convert.ToDouble(sVal);
                    break;

                case 8:   //EndValue
                    OffGraphBiz.Instance._axsX.EndValue = Convert.ToDouble(sVal);
                    break;

                case 9:   //FloatFigure
                    OffGraphBiz.Instance._axsX.FloatFigure = Convert.ToInt32(sVal);
                    break;

                case 10:  //X
                    OffGraphBiz.Instance._axsX.X = Convert.ToInt32(sVal);
                    break;

                case 11:  //Y
                    OffGraphBiz.Instance._axsX.Y = Convert.ToInt32(sVal);
                    break;

                case 12:  //Length
                    OffGraphBiz.Instance._axsX.Length = Convert.ToInt32(sVal);
                    break;

                case 13:  //OffsetX
                    OffGraphBiz.Instance._axsX.OffsetX = Convert.ToInt32(sVal);
                    break;

                case 14:  //'OffsetY
                    OffGraphBiz.Instance._axsX.OffsetY = Convert.ToInt32(sVal);
                    break;

                case 15:  //ScaleCount
                    OffGraphBiz.Instance._axsX.ScaleCount = Convert.ToInt32(sVal);
                    break;

                case 16:  //ScaleLine.Color
                    OffGraphBiz.Instance._axsX.ScaleLineColor = Convert.ToInt32(sVal);
                    break;

                case 17:  //ScaleLine.Style
                    OffGraphBiz.Instance._axsX.ScaleLineStyle = Convert.ToInt32(sVal);
                    break;

                case 18:  //ScaleLine.Width
                    OffGraphBiz.Instance._axsX.ScaleLineWidth = Convert.ToInt32(sVal);
                    break;

                case 19:  //ValueColor
                    OffGraphBiz.Instance._axsX.ValueColor = Convert.ToInt32(sVal);
                    break;

                case 20:  //lablefont.Bold
                    OffGraphBiz.Instance._axsX.LabelFontBold = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 21:  //lablefont.Italic
                    OffGraphBiz.Instance._axsX.LabelFontItalic = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 22:  //lablefont.Name
                    OffGraphBiz.Instance._axsX.LabelFontName = sVal;//'"俵俽 俹僑僔僢僋"
                    break;

                case 23:  //lablefont.Size
                    OffGraphBiz.Instance._axsX.LabelFontSize = Convert.ToInt32(sVal);
                    break;

                case 24:  //lablefont.Underline
                    OffGraphBiz.Instance._axsX.LabelFontUnderline = (0 < Convert.ToInt32(sVal)) ? true : false;
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
                    OffGraphBiz.Instance._axsX.ZorderOcx = Convert.ToInt16(sVal);
                    break;

                case 28:  //Unit And Name
                    OffGraphBiz.Instance._axsX.UnitName = sVal;//'"[Unit Name 揷拞]"
                    break;

            }


        }
    }
}
