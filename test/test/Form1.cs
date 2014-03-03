using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            bool[] b=new bool[5]{true,true,false,false,true};
            BitArray ba = new BitArray(b);
            for (int i = 0; i < 5; i++)
            {
              // MessageBox.Show(ba[i].ToString());
            }

            List<byte> buffer = new List<byte>();
            buffer.Add(123);
            buffer.Add(145);
            if (2>=buffer.Count)
            {
                MessageBox.Show("List到达边界");
            }                    
        }
    }
}
