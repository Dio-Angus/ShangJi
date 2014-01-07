/*-----------------------------------------------------------------------------
//  FILE NAME       : GridUser.cs
//  FUNCTION        : GridUser
//  AUTHOR          : 李锋(2009/03/10)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoTool.util;
using ChromatoBll.ocx;

namespace ChromatoCore.uiConf
{
    /// <summary>
    /// 网格配置
    /// </summary>
    public partial class GridUser : UserControl
    {
        /// <summary>
        /// 构造
        /// </summary>
        public GridUser()
        {
            InitializeComponent();
            LoadGridID();
            LoadGrid();
        }

        /// <summary>
        /// 装载网格ID
        /// </summary>
        private void LoadGridID()
        {
            this.cmbItemID_Grid.Items.Clear();
            this.cmbItemID_Grid.Items.Add(OffGraphBiz.Instance.GetGridID());
            this.cmbItemID_Grid.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载网格属性
        /// </summary>
        private void LoadGrid()
        {
            this.lsbGrid.Items.Add("left");
            this.lsbGrid.Items.Add("right");
            this.lsbGrid.Items.Add("top");
            this.lsbGrid.Items.Add("bottom");
            this.lsbGrid.Items.Add("TransParent");
            this.lsbGrid.Items.Add("Show");
            this.lsbGrid.Items.Add("VertGridCount");
            this.lsbGrid.Items.Add("HorzGridCount");
            this.lsbGrid.Items.Add("outpen.Style");
            this.lsbGrid.Items.Add("outpen.Width");
            this.lsbGrid.Items.Add("outpen.Color");
            this.lsbGrid.Items.Add("brushColor");
            this.lsbGrid.Items.Add("inpen.Style");
            this.lsbGrid.Items.Add("inpen.Width");
            this.lsbGrid.Items.Add("inpen.Color");
            this.lsbGrid.Items.Add("add");
            this.lsbGrid.Items.Add("Remove");
            this.lsbGrid.Items.Add("Zorder");
            this.lsbGrid.SelectedIndex = 0;
        }

        /// <summary>
        /// 网格选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = this.lsbGrid.SelectedIndex + 1;

            switch (nPropertyID)
            {
                case 1://left
                    sVal = OffGraphBiz.Instance._grid.Left.ToString();
                    break;

                case 2:   //right
                    sVal = OffGraphBiz.Instance._grid.Right.ToString();
                    break;

                case 3:  //top
                    sVal = OffGraphBiz.Instance._grid.Top.ToString();
                    break;

                case 4:   //bottom
                    sVal = OffGraphBiz.Instance._grid.Bottom.ToString();
                    break;

                case 5:   //TransParent
                    sVal = OffGraphBiz.Instance._grid.TransParent.ToString();
                    break;

                case 6:  //'Show
                    sVal = OffGraphBiz.Instance._grid.Show.ToString();
                    break;

                case 7:  //'VertGridCount
                    sVal = OffGraphBiz.Instance._grid.VertCount.ToString();
                    break;

                case 8:  //HorzGridCount
                    sVal = OffGraphBiz.Instance._grid.HorzCount.ToString();
                    break;

                case 9:  //'outpen.Style
                    sVal = OffGraphBiz.Instance._grid.OutLineStyle.ToString();
                    break;

                case 10: //'outpen.Width
                    sVal = OffGraphBiz.Instance._grid.OutLineWidth.ToString();
                    break;

                case 11:  //outpen.Color
                    sVal = OffGraphBiz.Instance._grid.OutLineColor.ToString();
                    break;

                case 12:  //brushColor
                    sVal = OffGraphBiz.Instance._grid.BrushColor.ToString();
                    break;

                case 13:  //inpen.Style
                    sVal = OffGraphBiz.Instance._grid.InLineStyle.ToString();
                    break;

                case 14:  //inpen.Width
                    sVal = OffGraphBiz.Instance._grid.InLineWidth.ToString();
                    break;

                case 15:  //inpen.Color
                    sVal = OffGraphBiz.Instance._grid.InLineColor.ToString();
                    break;

                case 16: //add
                    break;


                case 17:  //Remove

                    break;

                case 18:  //Zorder
                    sVal = OffGraphBiz.Instance._grid.ZorderOcx.ToString();
                    break;

            }


            this.txtValue_Grid.Text = sVal;
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

            nPropertyID = this.lsbGrid.SelectedIndex + 1;

            if (CastString.IsNumeric(this.txtValue_Grid.Text))
            {
                sVal = this.txtValue_Grid.Text;
            }
            else
            {
                MessageBox.Show("Please input Numeric");
                return;
            }

            switch (nPropertyID)
            {
                case 1:   //left
                    OffGraphBiz.Instance._grid.Left = Convert.ToInt32(sVal); //'60
                    break;

                case 2:   //right
                    OffGraphBiz.Instance._grid.Right = Convert.ToInt32(sVal); //640
                    break;

                case 3:   //top
                    OffGraphBiz.Instance._grid.Top = Convert.ToInt32(sVal); //30
                    break;

                case 4:   //bottom
                    OffGraphBiz.Instance._grid.Bottom = Convert.ToInt32(sVal);//330
                    break;

                case 5:   //TransParent
                    OffGraphBiz.Instance._grid.TransParent = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 6:   //Show
                    OffGraphBiz.Instance._grid.Show = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 7:   //VertGridCount
                    OffGraphBiz.Instance._grid.VertCount = Convert.ToInt32(sVal);//'4
                    break;

                case 8:   //HorzGridCount
                    OffGraphBiz.Instance._grid.HorzCount = Convert.ToInt32(sVal);//'5
                    break;

                case 9:   //outpen.Style
                    OffGraphBiz.Instance._grid.OutLineStyle = Convert.ToInt32(sVal);// '0
                    break;

                case 10:  //outpen.Width
                    OffGraphBiz.Instance._grid.OutLineWidth = Convert.ToInt32(sVal);// '3
                    break;

                case 11:  //outpen.Color
                    OffGraphBiz.Instance._grid.OutLineColor = Convert.ToInt32(sVal);// 'RGB(255, 0, 0)
                    break;

                case 12:  //brushColor
                    OffGraphBiz.Instance._grid.BrushColor = Convert.ToInt32(sVal);// 'RGB(0, 128, 128)
                    break;

                case 13:  //inpen.Style
                    OffGraphBiz.Instance._grid.InLineStyle = Convert.ToInt32(sVal);// '4
                    break;

                case 14:  //inpen.Width
                    OffGraphBiz.Instance._grid.InLineWidth = Convert.ToInt32(sVal);// '2
                    break;

                case 15:  //inpen.Color
                    OffGraphBiz.Instance._grid.InLineColor = Convert.ToInt32(sVal);// 'RGB(0, 255, 255)
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
                    OffGraphBiz.Instance._grid.ZorderOcx = Convert.ToInt16(sVal);// '130
                    break;
            }


        }


    }
}
