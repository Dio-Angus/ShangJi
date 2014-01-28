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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] array = new byte[1];
            array = System.Text.Encoding.ASCII.GetBytes(this.textBox1.Text);
            string s=null;
            foreach (byte a in array)
            {
                s += a.ToString("X2");
            }
            this.label1.Text = s;
        }
    }
}
