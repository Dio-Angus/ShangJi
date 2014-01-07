/*-----------------------------------------------------------------------------
//  FILE NAME       : AreaUser.cs
//  FUNCTION        : AreaUser
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
    /// 区域配置
    /// </summary>
    public partial class AreaUser : UserControl
    {
        /// <summary>
        /// 构造
        /// </summary>
        public AreaUser()
        {
            InitializeComponent();
            LoadAreaID();
            LoadArea();
        }

        /// <summary>
        /// 装载区域ID
        /// </summary>
        private void LoadAreaID()
        {
            this.cmbItemID_Area.Items.Clear();
            this.cmbItemID_Area.Items.Add(OffGraphBiz.Instance.GetAreaID());
            this.cmbItemID_Area.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载区域属性
        /// </summary>
        private void LoadArea()
        {
            this.lsbArea.Items.Add("left");
            this.lsbArea.Items.Add("right");
            this.lsbArea.Items.Add("top");
            this.lsbArea.Items.Add("bottom");
            this.lsbArea.Items.Add("ColorBrush");
            this.lsbArea.Items.Add("XAxis");
            this.lsbArea.Items.Add("YAxis");
            this.lsbArea.Items.Add("LeftValue");
            this.lsbArea.Items.Add("RightValue");
            this.lsbArea.Items.Add("TopValue");
            this.lsbArea.Items.Add("BottomValue");
            this.lsbArea.Items.Add("Show");
            this.lsbArea.Items.Add("add");
            this.lsbArea.Items.Add("Remove");
            this.lsbArea.Items.Add("Clip");
            this.lsbArea.Items.Add("Zorder");
            this.lsbArea.SelectedIndex = 0;
        }

        /// <summary>
        /// 区域选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = this.lsbArea.SelectedIndex + 1;

            switch (nPropertyID)
            {
                case 1:  //left
                    sVal = OffGraphBiz.Instance._area.Left.ToString();
                    break;
                case 2:   //right
                    sVal = OffGraphBiz.Instance._area.Right.ToString();
                    break;

                case 3:   //top
                    sVal = OffGraphBiz.Instance._area.Top.ToString();
                    break;

                case 4:   //bottom
                    sVal = OffGraphBiz.Instance._area.Bottom.ToString();
                    break;

                case 5:   //ColorBrush
                    sVal = OffGraphBiz.Instance._area.ColorBrush.ToString();
                    break;

                case 6:   //XAxis
                    sVal = OffGraphBiz.Instance._area.XAxis.ToString();
                    break;

                case 7:   //YAxis
                    sVal = OffGraphBiz.Instance._area.YAxis.ToString();
                    break;

                case 8:   //LeftValue
                    sVal = OffGraphBiz.Instance._area.LeftValue.ToString();
                    break;

                case 9:   //RightValue
                    sVal = OffGraphBiz.Instance._area.RightValue.ToString();
                    break;

                case 10:  //TopValue
                    sVal = OffGraphBiz.Instance._area.TopValue.ToString();
                    break;

                case 11:  //BottomValue
                    sVal = OffGraphBiz.Instance._area.BottomValue.ToString();
                    break;

                case 12:  //Show
                    sVal = OffGraphBiz.Instance._area.Show.ToString();
                    break;

                case 13:  //add
                    break;

                case 14:  //Remove
                    break;

                case 15:  //Clip
                    sVal = OffGraphBiz.Instance._area.Clip.ToString();
                    break;

                case 16:  //Zorder
                    sVal = OffGraphBiz.Instance._area.ZorderOcx.ToString();
                    break;

            }

            this.txtValue_Area.Text = sVal;
        }

        /// <summary>
        /// 改变选中区域属性的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeArea_Click(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = this.lsbArea.SelectedIndex + 1;

            if (CastString.IsNumeric(this.txtValue_Area.Text))
            {
                sVal = this.txtValue_Area.Text;
            }
            else
            {
                MessageBox.Show("Please input Numeric");
                return;
            }

            switch (nPropertyID)
            {
                case 1:   //left
                    OffGraphBiz.Instance._area.Left = Convert.ToInt32(sVal);
                    break;

                case 2:  //right
                    OffGraphBiz.Instance._area.Right = Convert.ToInt32(sVal);
                    break;

                case 3:   //top
                    OffGraphBiz.Instance._area.Top = Convert.ToInt32(sVal);
                    break;

                case 4:   //bottom
                    OffGraphBiz.Instance._area.Bottom = Convert.ToInt32(sVal);
                    break;

                case 5:   //ColorBrush
                    OffGraphBiz.Instance._area.ColorBrush = Convert.ToInt32(sVal);
                    break;

                case 6:   //XAxis
                    OffGraphBiz.Instance._area.XAxis = Convert.ToInt32(sVal);
                    break;

                case 7:   //YAxis
                    OffGraphBiz.Instance._area.YAxis = Convert.ToInt32(sVal);
                    break;

                case 8:   //LeftValue
                    OffGraphBiz.Instance._area.LeftValue = Convert.ToInt32(sVal);
                    break;

                case 9:   //RightValue
                    OffGraphBiz.Instance._area.RightValue = Convert.ToInt32(sVal);
                    break;

                case 10:  //TopValue
                    OffGraphBiz.Instance._area.TopValue = Convert.ToInt32(sVal);
                    break;

                case 11:  //BottomValue
                    OffGraphBiz.Instance._area.BottomValue = Convert.ToInt32(sVal);
                    break;

                case 12:  //Show
                    OffGraphBiz.Instance._area.Show = (0 < Convert.ToInt32(sVal)) ? true : false;
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
                    OffGraphBiz.Instance._area.Clip = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 16:  //Zorder
                    OffGraphBiz.Instance._area.ZorderOcx = Convert.ToInt16(sVal);
                    break;

            }
        }
    }
}
