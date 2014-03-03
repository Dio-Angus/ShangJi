using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            float a = Convert.ToSingle("001");
            label1.Text = a.ToString();

            Byte[] b = new Byte[] {51,46,53};
            MessageBox.Show(Chr(Convert.ToInt32(b[0])) + Chr(Convert.ToInt32(b[1])) + Chr(Convert.ToInt32(b[2])));
        }

        //bit转ascII码
        public static string Chr(int asciiCode)
        {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);
                if (strCharacter == " ")
                    return "0";
                else
                    return (strCharacter);
            }
            else
            {
                throw new Exception("ASCII Code is not valid.");
            }
        }
    }
}
