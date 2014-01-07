/*-----------------------------------------------------------------------------
//  FILE NAME       : ShapeUser.cs
//  FUNCTION        : ShapeUser
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
    /// 矩形配置
    /// </summary>
    public partial class ShapeUser : UserControl
    {
        /// <summary>
        /// 构造
        /// </summary>
        public ShapeUser()
        {
            InitializeComponent();
            LoadShapeID();
            LoadShape();
        }

        /// <summary>
        /// 装载矩形ID
        /// </summary>
        private void LoadShapeID()
        {
            this.cmbItemID_Shape.Items.Clear();
            this.cmbItemID_Shape.Items.Add(OffGraphBiz.Instance.GetShapeID());
            this.cmbItemID_Shape.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载矩形属性
        /// </summary>
        private void LoadShape()
        {
            this.lsbShape.Items.Add("X");
            this.lsbShape.Items.Add("Y");
            this.lsbShape.Items.Add("Width");
            this.lsbShape.Items.Add("Height");
            this.lsbShape.Items.Add("Show");
            this.lsbShape.Items.Add("sShapeAttr.BorderColor");
            this.lsbShape.Items.Add("sShapeAttr.FillColor");
            this.lsbShape.Items.Add("sShapeAttr.FillPattern");
            this.lsbShape.Items.Add("sShapeAttr.AdjustX");
            this.lsbShape.Items.Add("sShapeAttr.AdjustY");
            this.lsbShape.Items.Add("sShapeAttr.Transparent");
            this.lsbShape.Items.Add("add");
            this.lsbShape.Items.Add("Remove");
            this.lsbShape.Items.Add("Zorder");
            this.lsbShape.SelectedIndex = 0;
        }

        /// <summary>
        /// 矩形选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = this.lsbShape.SelectedIndex + 1;

            switch (nPropertyID)
            {
                case 1://   'X
                    sVal = OffGraphBiz.Instance._shape.X.ToString();
                    break;

                case 2://   'Y
                    sVal = OffGraphBiz.Instance._shape.Y.ToString();
                    break;

                case 3://   'Width
                    sVal = OffGraphBiz.Instance._shape.Width.ToString();
                    break;

                case 4://   'Height
                    sVal = OffGraphBiz.Instance._shape.Height.ToString();
                    break;

                case 5://   'Show
                    sVal = OffGraphBiz.Instance._shape.Show.ToString();
                    break;

                case 6://   'sShapeAttr.BorderColor
                    sVal = OffGraphBiz.Instance._shape.BorderColor.ToString();
                    break;

                case 7://   'sShapeAttr.FillColor
                    sVal = OffGraphBiz.Instance._shape.FillColor.ToString();
                    break;

                case 8://   'sShapeAttr.FillPattern
                    sVal = OffGraphBiz.Instance._shape.FillPattern.ToString();
                    break;

                case 9://   'sShapeAttr.AdjustX
                    sVal = OffGraphBiz.Instance._shape.AdjustX.ToString();
                    break;

                case 10://  'sShapeAttr.AdjustY
                    sVal = OffGraphBiz.Instance._shape.AdjustY.ToString();
                    break;

                case 11://  'sShapeAttr.Transparent
                    sVal = OffGraphBiz.Instance._shape.Transparent.ToString();
                    break;
                case 12://  'add
                    break;

                case 13://  'Remove
                    break;
                case 14://  'Zorder
                    sVal = OffGraphBiz.Instance._shape.ZorderOcx.ToString();
                    break;

            }
            this.txtValue_Shape.Text = sVal;
        }

        /// <summary>
        /// 改变选中矩形属性的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeShape_Click(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = this.lsbShape.SelectedIndex + 1;

            if (CastString.IsNumeric(this.txtValue_Shape.Text))
            {
                sVal = this.txtValue_Shape.Text;
            }
            else
            {
                MessageBox.Show("Please input Numeric");
                return;
            }


            //Call mProperty.ChangeShapeProperty(WRITE_PROPERTY, 5, nPropertyID, dVal)
            switch (nPropertyID)
            {
                case 1:   //X
                    OffGraphBiz.Instance._shape.X = Convert.ToInt32(sVal); //'80
                    break;
                case 2:   //Y
                    OffGraphBiz.Instance._shape.Y = Convert.ToInt32(sVal); //'80
                    break;

                case 3:   //Width
                    OffGraphBiz.Instance._shape.Width = Convert.ToInt32(sVal); //200
                    break;

                case 4:   //Height
                    OffGraphBiz.Instance._shape.Height = Convert.ToInt32(sVal); //200
                    break;

                case 5:   //Show
                    OffGraphBiz.Instance._shape.Show = (0 < Convert.ToInt32(sVal)) ? true : false;
                    break;

                case 6:   //sShapeAttr.BorderColor
                    OffGraphBiz.Instance._shape.BorderColor = Convert.ToInt32(sVal); //RGB(255, 0, 0)
                    break;

                case 7:   //sShapeAttr.FillColor
                    OffGraphBiz.Instance._shape.FillColor = Convert.ToInt32(sVal); //RGB(255, 255, 255)
                    break;

                case 8:   //sShapeAttr.FillPattern
                    OffGraphBiz.Instance._shape.FillPattern = Convert.ToInt32(sVal); //0
                    break;

                case 9:   //sShapeAttr.AdjustX
                    OffGraphBiz.Instance._shape.AdjustX = Convert.ToInt32(sVal); //5
                    break;

                case 10: //sShapeAttr.AdjustY
                    OffGraphBiz.Instance._shape.AdjustY = Convert.ToInt32(sVal); //5
                    break;

                case 11:  //sShapeAttr.Transparent
                    OffGraphBiz.Instance._shape.Transparent = (0 < Convert.ToInt32(sVal)) ? true : false;
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
                    OffGraphBiz.Instance._shape.ZorderOcx = Convert.ToInt16(sVal); //150
                    break;

            }
        }

    }
}
