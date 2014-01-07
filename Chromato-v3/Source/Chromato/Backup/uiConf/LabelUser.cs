/*-----------------------------------------------------------------------------
//  FILE NAME       : LabelUser.cs
//  FUNCTION        : LabelUser
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
    /// 标签配置
    /// </summary>
    public partial class LabelUser : UserControl
    {
        /// <summary>
        /// 构造
        /// </summary>
        public LabelUser()
        {
            InitializeComponent();
            LoadLabelID();
            LoadLabel();
        }

        /// <summary>
        /// 装载文本ID
        /// </summary>
        private void LoadLabelID()
        {
            this.cmbItemID_Label.Items.Clear();
            this.cmbItemID_Label.Items.Add(OffGraphBiz.Instance.GetLabelID());
            this.cmbItemID_Label.SelectedIndex = 0;
        }

        /// <summary>
        /// 装载文本属性
        /// </summary>
        private void LoadLabel()
        {
            this.lsbLabel.Items.Add("Align");
            this.lsbLabel.Items.Add("Show");
            this.lsbLabel.Items.Add("Direction");
            this.lsbLabel.Items.Add("X");
            this.lsbLabel.Items.Add("Y");
            this.lsbLabel.Items.Add("ForeColor");
            this.lsbLabel.Items.Add("BackColor");
            this.lsbLabel.Items.Add("lablefont.Bold");
            this.lsbLabel.Items.Add("lablefont.Italic");
            this.lsbLabel.Items.Add("lablefont.Name");
            this.lsbLabel.Items.Add("lablefont.Size");
            this.lsbLabel.Items.Add("lablefont.Underline");
            this.lsbLabel.Items.Add("Text");
            this.lsbLabel.Items.Add("add");
            this.lsbLabel.Items.Add("Remove");
            this.lsbLabel.Items.Add("Zorder");
            this.lsbLabel.SelectedIndex = 0;
        }

        /// <summary>
        /// 文本选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbLabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sVal = "";
            int nPropertyID = this.lsbLabel.SelectedIndex + 1;

            switch (nPropertyID)
            {
                case 1:   //Align           UP = 0  DOWN = 1  LEFT = 2  CENTER = 3  RIGHT = 4
                    sVal = OffGraphBiz.Instance._label.Align.ToString();    //1
                    break;

                case 2:   //Show          Show = 1  Invisable = 0
                    sVal = OffGraphBiz.Instance._label.Show.ToString(); // 'True
                    break;

                case 3:   //Direction     X_AXIS_DIRECTION = 0   Y_AXIS_DIRECTION = 1
                    sVal = OffGraphBiz.Instance._label.Direction.ToString();    // '1
                    break;

                case 4:   //X
                    sVal = OffGraphBiz.Instance._label.X.ToString();    // '200
                    break;

                case 5:   //Y
                    sVal = OffGraphBiz.Instance._label.Y.ToString();    // '200
                    break;

                case 6:   //ForeColor
                    sVal = OffGraphBiz.Instance._label.ForeColor.ToString();    // 'RGB(255, 0, 0)
                    break;

                case 7:   //BackColor
                    sVal = OffGraphBiz.Instance._label.BackColor.ToString();   // 'RGB(0, 0, 0)
                    break;

                case 8:   //lablefont.Bold
                    sVal = OffGraphBiz.Instance._label.FontBold.ToString(); // 'False
                    break;

                case 9:   //lablefont.Italic
                    sVal = OffGraphBiz.Instance._label.FontItalic.ToString();   // 'False
                    break;

                case 10:  //lablefont.Name
                    sVal = OffGraphBiz.Instance._label.FontName.ToString(); //   '"俵俽 俹僑僔僢僋"
                    break;

                case 11:   //lablefont.Size
                    sVal = OffGraphBiz.Instance._label.FontSize.ToString(); // '20
                    break;

                case 12:   //lablefont.Underline
                    sVal = OffGraphBiz.Instance._label.FontUnderline.ToString();    //False
                    break;

                case 13:   //Text
                    //Call GraphObj.SetLabelText(nItemNo, 6, "123戝岲偒")
                    break;

                case 14:   //add
                    break;

                case 15:   //remove
                    break;

                case 16:   //Zorder
                    sVal = OffGraphBiz.Instance._label.ZorderOcx.ToString();
                    break;
            }


            if (nPropertyID == 10 || nPropertyID == 13)
            {
                this.txtValue_Label.Text = sVal;
            }
            else
            {
                this.txtValue_Label.Text = sVal;
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
            int nPropertyID = this.lsbLabel.SelectedIndex + 1;

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

            switch (nPropertyID)
            {
                case 1:   //Align           UP = 0  DOWN = 1  LEFT = 2  CENTER = 3  RIGHT = 4
                    OffGraphBiz.Instance._label.Align = Convert.ToInt32(sVal); //'1
                    break;

                case 2:   //Show          Show = 1  Invisable = 0
                    OffGraphBiz.Instance._label.Show = (0 < Convert.ToInt32(sVal)) ? true : false; //True
                    break;

                case 3:   //Direction     X_AXIS_DIRECTION = 0   Y_AXIS_DIRECTION = 1
                    OffGraphBiz.Instance._label.Direction = Convert.ToInt32(sVal); // '1
                    break;

                case 4:   //X
                    OffGraphBiz.Instance._label.X = Convert.ToInt32(sVal); //'200
                    break;

                case 5:   //Y
                    OffGraphBiz.Instance._label.Y = Convert.ToInt32(sVal); // '200
                    break;

                case 6:   //ForeColor
                    OffGraphBiz.Instance._label.ForeColor = Convert.ToInt32(sVal); // 'RGB(255, 0, 0)
                    break;

                case 7:   //BackColor
                    OffGraphBiz.Instance._label.BackColor = Convert.ToInt32(sVal); // 'RGB(0, 0, 0)
                    break;

                case 8:   //lablefont.Bold
                    OffGraphBiz.Instance._label.FontBold = (0 < Convert.ToInt32(sVal)) ? true : false; //False
                    break;

                case 9:   //lablefont.Italic
                    OffGraphBiz.Instance._label.FontItalic = (0 < Convert.ToInt32(sVal)) ? true : false; //False
                    break;

                case 10:  //lablefont.Name
                    OffGraphBiz.Instance._label.FontName = sVal; //'"俵俽 俹僑僔僢僋"
                    break;

                case 11:   //lablefont.Size
                    OffGraphBiz.Instance._label.FontSize = Convert.ToInt32(sVal); // '20
                    break;

                case 12:   //lablefont.Underline
                    OffGraphBiz.Instance._label.FontUnderline = (0 < Convert.ToInt32(sVal)) ? true : false;//'False
                    break;

                case 13:   //Text
                    OffGraphBiz.Instance._label.Text = sVal; // 'SetLabelText(nItemNo, 6, sVal)  '"123戝岲偒"
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
                    OffGraphBiz.Instance._label.ZorderOcx = Convert.ToInt16(sVal); // '160
                    break;

            }


        }


    }
}
