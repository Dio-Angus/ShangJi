/*-----------------------------------------------------------------------------
//  FILE NAME       : LineUser.cs
//  FUNCTION        : LineUser
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
    /// 直线配置
    /// </summary>
    public partial class LineUser : UserControl
    {
        /// <summary>
        /// 构造
        /// </summary>
        public LineUser()
        {
            InitializeComponent();
            LoadLineID();
            LoadLine();
        }

        /// <summary>
        /// 装载直线ID
        /// </summary>
        private void LoadLineID()
        {
            this.cmbItemID_Line.Items.Clear();
            this.cmbItemID_Line.Items.Add(OffGraphBiz.Instance.GetLineID());
            this.cmbItemID_Line.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载直线属性
        /// </summary>
        private void LoadLine()
        {
            this.lsbLine.Items.Add("StartX");
            this.lsbLine.Items.Add("StartY");
            this.lsbLine.Items.Add("EndX");
            this.lsbLine.Items.Add("EndY");
            this.lsbLine.Items.Add("linepen.Style");
            this.lsbLine.Items.Add("linepen.Width");
            this.lsbLine.Items.Add("linepen.Color");
            this.lsbLine.Items.Add("Show");
            this.lsbLine.Items.Add("add");
            this.lsbLine.Items.Add("Remove");
            this.lsbLine.Items.Add("Zorder");
            this.lsbLine.SelectedIndex = 0;
        }

        /// <summary>
        /// 直线属性选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = this.lsbLine.SelectedIndex + 1;


            switch (nPropertyID)
            {
                case 1:    //StartX
                    sVal = OffGraphBiz.Instance._line.StartX.ToString();
                    break;

                case 2:    //StartY
                    sVal = OffGraphBiz.Instance._line.StartY.ToString();
                    break;

                case 3:    //EndX
                    sVal = OffGraphBiz.Instance._line.EndX.ToString();
                    break;
                case 4:    //EndY
                    sVal = OffGraphBiz.Instance._line.EndY.ToString();
                    break;
                case 5:    //linepen.Style
                    sVal = OffGraphBiz.Instance._line.Style.ToString();
                    break;
                case 6:    //linepen.Width
                    sVal = OffGraphBiz.Instance._line.Width.ToString();
                    break;
                case 7:    //linepen.Color
                    sVal = OffGraphBiz.Instance._line.Color.ToString();
                    break;
                case 8:    //Show
                    sVal = OffGraphBiz.Instance._line.Show.ToString();
                    break;
                case 9:    //add
                    break;
                case 10:   //Remove
                    break;
                case 11:   //Zorder
                    sVal = OffGraphBiz.Instance._line.ZorderOcx.ToString();
                    break;
            }


            this.txtValue_Line.Text = sVal;
        }

        /// <summary>
        /// 改变选中直线属性的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeLine_Click(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = this.lsbLine.SelectedIndex + 1;


            if (CastString.IsNumeric(this.txtValue_Line.Text))
            {
                sVal = this.txtValue_Line.Text;
            }
            else
            {
                MessageBox.Show("Please input Numeric");
                return;
            }

            switch (nPropertyID)
            {
                case 1:    //StartX
                    OffGraphBiz.Instance._line.StartX = Convert.ToInt32(sVal); //'100
                    break;
                case 2:    //StartY
                    OffGraphBiz.Instance._line.StartY = Convert.ToInt32(sVal); //'100
                    break;
                case 3:    //EndX
                    OffGraphBiz.Instance._line.EndX = Convert.ToInt32(sVal); //'500
                    break;
                case 4:    //EndY
                    OffGraphBiz.Instance._line.EndY = Convert.ToInt32(sVal); //'500
                    break;
                case 5:    //linepen.Style
                    OffGraphBiz.Instance._line.Style = Convert.ToInt32(sVal); //'4
                    break;
                case 6:    //linepen.Width
                    OffGraphBiz.Instance._line.Width = Convert.ToInt32(sVal); //'2
                    break;
                case 7:    //linepen.Color
                    OffGraphBiz.Instance._line.Color = Convert.ToInt32(sVal); //'RGB(0, 0, 255)
                    break;
                case 8:    //'Show
                    OffGraphBiz.Instance._line.Show = (0 < Convert.ToInt32(sVal)) ? true : false;
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
                    OffGraphBiz.Instance._line.ZorderOcx = Convert.ToInt16(sVal); //'140
                    break;
            }

        }


    }
}
