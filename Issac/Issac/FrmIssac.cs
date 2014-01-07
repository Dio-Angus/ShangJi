using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace issac
{
    public partial class FrmIssac : Form
    {
        private DataSet ds = new DataSet();
        List<Item> ItemGroup = new List<Item>();

        public FrmIssac()
        {
            InitializeComponent();
        }

        private void FrmIssac_Load(object sender, EventArgs e)
        {
            EcxelToDataGridView("all.xls", this.hpGridView1);
            for (int i = 0; i < 256; i++)
            {
                Item item = new Item();
                item.Name = hpGridView1.Rows[i].Cells[0].Value.ToString();
                item.Ima = (Image)hpGridView1.Rows[i].Cells[1].Value;
                item.Description = hpGridView1.Rows[i].Cells[2].Value.ToString();
                if (i < 52) item.tag = 0;
                else if (i >= 52 && i < 196) item.tag = 1;
                else if (i >= 196 && i < 229) item.tag = 2;
                else item.tag = 3;
                ItemGroup.Add(item);
            }
        }

        public void EcxelToDataGridView(string filePath, DataGridView dgv)
        {
            try
            {
                #region 导入excel
                //根据路径打开一个Excel文件并将数据填充到DataSet中
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + filePath + ";Extended Properties ='Excel 8.0;HDR=NO;IMEX=1'";//导入时包含Excel中的第一行数据，并且将数字和字符混合的单元格视为文本进行导入
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                string strExcel = "select  * from   [Sheet1$]";
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, conn);
                myCommand.Fill(ds, "[Sheet1$]");
                conn.Close();
                dgv.DataMember = "[Sheet1$]";
                dgv.DataSource = ds;
                //ds.Tables[0].Rows[0].Delete();
                //dgv.Columns[0].HeaderText = "1";
                // MessageBox.Show(ds.Tables[0].Rows[3][1].ToString());
                #endregion
                DataGridViewImageColumn dvic = new DataGridViewImageColumn(false);
                dvic.Name = "Images";
                dvic.HeaderText = "Images";  
                dgv.Columns.Insert(1,dvic);        
                dgv.Columns[0].HeaderText = "Name";
                dgv.Columns[0].Name = "Name";
                dgv.Columns[2].HeaderText = "Description";
                dgv.Columns[2].Name = "Description";
                for (int i = 0; i <256; i++)
                {
                    dgv.Rows[i].Cells[1].Value = imageList1.Images[i];
                }
                for (int i = 0; i < 3; i++)
                {
                    dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查excel文件是否标准格式" + ex.ToString());
            }
        }

        private void hpGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (hpGridView1.ColumnCount == 3 && hpGridView1.Columns[2].Name == "Description")
            {
                pictureBox1.BackgroundImage = (Image)hpGridView1.Rows[e.RowIndex].Cells["Images"].Value;
                label2.Text=hpGridView1.Rows[e.RowIndex].Cells["Description"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds.Clear();
            imageList1.Images.Clear();
            int Num = 0;
            for (int i = 0; i < 256; i++)
            {
                if (ItemGroup[i].tag == 0)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr[0] = ItemGroup[i].Name;
                    dr[1] = ItemGroup[i].Description;
                    ds.Tables[0].Rows.Add(dr);
                    imageList1.Images.Add(ItemGroup[i].Ima);
                    Num++;
                }
            }
            for (int i = 0; i < Num; i++)
            {
                hpGridView1.Rows[i].Cells[1].Value = imageList1.Images[i];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.Clear();
            imageList1.Images.Clear();
            int Num = 0;
            for (int i = 0; i < 256; i++)
            {
                if (ItemGroup[i].tag == 1)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr[0] = ItemGroup[i].Name;
                    dr[1] = ItemGroup[i].Description;
                    ds.Tables[0].Rows.Add(dr);
                    imageList1.Images.Add(ItemGroup[i].Ima);
                    Num++;
                }
            }
            for (int i = 0; i < Num; i++)
            {
                hpGridView1.Rows[i].Cells[1].Value = imageList1.Images[i];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ds.Clear();
            imageList1.Images.Clear();
            int Num = 0;
            for (int i = 0; i < 256; i++)
            {
                if (ItemGroup[i].tag == 2)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr[0] = ItemGroup[i].Name;
                    dr[1] = ItemGroup[i].Description;
                    ds.Tables[0].Rows.Add(dr);
                    imageList1.Images.Add(ItemGroup[i].Ima);
                    Num++;
                }
            }
            for (int i = 0; i < Num; i++)
            {
                hpGridView1.Rows[i].Cells[1].Value = imageList1.Images[i];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ds.Clear();
            imageList1.Images.Clear();
            int Num = 0;
            for (int i = 0; i < 256; i++)
            {
                if (ItemGroup[i].tag == 3)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr[0] = ItemGroup[i].Name;
                    dr[1] = ItemGroup[i].Description;
                    ds.Tables[0].Rows.Add(dr);
                    imageList1.Images.Add(ItemGroup[i].Ima);
                    Num++;
                }
            }
            for (int i = 0; i < Num; i++)
            {
                hpGridView1.Rows[i].Cells[1].Value = imageList1.Images[i];
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ds.Clear();
            imageList1.Images.Clear();
            int Num = 0;
            string s = textBox1.Text.Trim().ToLower();
            for (int i = 0; i < 256; i++)
            {
                if (ItemGroup[i].Name.ToLower().Contains(s))
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr[0] = ItemGroup[i].Name;
                    dr[1] = ItemGroup[i].Description;
                    ds.Tables[0].Rows.Add(dr);
                    imageList1.Images.Add(ItemGroup[i].Ima);
                    Num++;
                }
            }
            for (int i = 0; i < Num; i++)
            {
                hpGridView1.Rows[i].Cells[1].Value = imageList1.Images[i];
            }
        }
    }
}
