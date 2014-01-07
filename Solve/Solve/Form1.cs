using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Solve
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 矩阵的秩
        /// </summary>
        private static int Order = 6;
        private static int num = 12;
        /// <summary>
        /// 原方阵
        /// </summary>
        private double[,] originalPhalanx = new double[Order, Order];
        /// <summary>
        /// 逆方阵
        /// </summary>
        private double[,] inversePhalanx = new double[Order, Order];
        /// <summary>
        /// 结果矩阵
        /// </summary>
        private double[] resultMatrix = new double[Order];
        /// <summary>
        /// 系数
        /// </summary>
        private double[] coefficient = new double[Order];
        /// <summary>
        /// 系数矩阵
        /// </summary>
        private List<double[]> coePhalanx = new List<double[]>();
        /// <summary>
        /// 回归矩阵的x值
        /// </summary>
        private List<List<double>> equationOfX = new List<List<double>>();//[Order][num]
        /// <summary>
        /// 回归矩阵的y值
        /// </summary>
        private List<double> equationOfY = new List<double>();//[num]
        /// <summary>
        /// 方差
        /// </summary>
        //double standardVariance;
        private DataTable dt0 = new DataTable();
        private DataTable dt1 = new DataTable();
        private DataSet ds = new DataSet();

        public Form1()
        {
            InitializeComponent();
            btCalculate.Enabled = false;
            btSave.Enabled = false;
            comboBox1.Enabled = false;
        }

        /// <summary>
        /// 点击按钮导入数据
        /// 作者：lhxhappy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOpen_Click(object sender, EventArgs e)
        {
            Order = int.Parse(textBox1.Text);
            num = int.Parse(textBox2.Text);
            //打开一个文件选择框
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Excel文件";
            ofd.FileName = "";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//为了获取特定的系统文件夹，可以使用System.Environment类的静态方法GetFolderPath()。该方法接受一个Environment.SpecialFolder枚举，其中可以定义要返回路径的哪个系统目录
            ofd.Filter = "Excel文件(*.xls)|*.xls";
            ofd.ValidateNames = true;     //文件有效性验证ValidateNames，验证用户输入是否是一个有效的Windows文件名
            ofd.CheckFileExists = true;  //验证路径有效性
            ofd.CheckPathExists = true; //验证文件有效性


            string strName = string.Empty;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strName = ofd.FileName;
            }

            if (strName == "" && ds.Tables.Count == 0)
            {
                MessageBox.Show("没有选择Excel文件！无法进行数据导入");
                return;
            }
            //调用导入数据方法
            EcxelToDataGridView(strName, this.hpGridView1);
            btCalculate.Enabled = true;
            btSave.Enabled = true;
            comboBox1.Enabled = true;
            for (int i = 0; i < 14; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
            comboBox1.SelectedIndex = 0;
        }

        /// <summary>
        /// Excel数据导入方法
        /// 作者:lhxhappy
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="dgv"></param>
        public void EcxelToDataGridView(string filePath, DataGridView dgv)
        {
            try
            {
                #region 导入excel
                //根据路径打开一个Excel文件并将数据填充到DataSet中
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + filePath + ";Extended Properties ='Excel 8.0;HDR=NO;IMEX=1'";//导入时包含Excel中的第一行数据，并且将数字和字符混合的单元格视为文本进行导入
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                System.Data.DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                string tableName = schemaTable.Rows[0][2].ToString().Trim();
                string strExcel = "select * from[" + tableName + "]";

                //string strExcel = "select  * from   [汽油$]";
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, conn);
                myCommand.Fill(ds, tableName);
                conn.Close();
                dgv.DataMember = tableName;
                dgv.DataSource = ds;
                num = ds.Tables[0].Columns.Count / 2;
                ds.Tables[0].Rows[0].Delete();
                ds.Tables[0].Rows[1].Delete();
                //dgv.Columns[0].HeaderText = "1";
                // MessageBox.Show(ds.Tables[0].Rows[3][1].ToString());
                #endregion

                YChanged("0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开出错，请检查是否正确的excel文件");
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            YChanged(comboBox1.Text);
        }

        /// <summary>
        /// y数据改变
        /// /// </summary>
        /// <param name="s"></param>
        private void YChanged(string s)
        {
            equationOfX.Clear();
            if (s == "0")
            {
                equationOfY.Clear();
                for (int i = 0; i < num; i++)
                {
                    if (ds.Tables[0].Rows[2][2 * i + 2].ToString() == "")
                    {
                        ds.Tables[0].Rows[2][2 * i + 2] = 0;
                    }
                    equationOfY.Add(Convert.ToDouble(ds.Tables[0].Rows[2][2 * i + 2].ToString()));
                }

                List<double> x = new List<double>();
                for (int i = 0; i < num; i++)
                {
                    x.Add(1);
                }
                equationOfX.Add(x);
                for (int i = 0; i < Order - 1; i++)
                {
                    List<double> xx = new List<double>();
                    for (int j = 0; j < num; j++)
                    {
                        xx.Add(Convert.ToDouble(ds.Tables[0].Rows[i + 2][2 * j + 1].ToString())); ;
                    }
                    equationOfX.Add(xx);
                }
            }
            else if (Convert.ToInt32(s) > 11)
            {
                equationOfY.Clear();
                for (int i = 0; i < num; i++)
                {
                    if (ds.Tables[0].Rows[Convert.ToInt32(s) + 3][2 * i + 2].ToString() == "")
                    {
                        ds.Tables[0].Rows[Convert.ToInt32(s) + 3][2 * i + 2] = 0;
                    }
                    equationOfY.Add(Convert.ToDouble(ds.Tables[0].Rows[Convert.ToInt32(s) + 3][2 * i + 2].ToString()));
                }

                List<double> x = new List<double>();
                for (int i = 0; i < num; i++)
                {
                    x.Add(1);
                }
                equationOfX.Add(x);
                for (int i = 1; i < Order; i++)
                {
                    List<double> xx = new List<double>();
                    for (int j = 0; j < num; j++)
                    {
                        xx.Add(Convert.ToDouble(ds.Tables[0].Rows[i + 11][2 * j + 1].ToString())); ;
                    }
                    equationOfX.Add(xx);
                }
            }
            else
            {
                equationOfY.Clear();
                for (int i = 0; i < num; i++)
                {
                    if (ds.Tables[0].Rows[Convert.ToInt32(s) + 3][2 * i + 2].ToString() == "")
                    {
                        ds.Tables[0].Rows[Convert.ToInt32(s) + 3][2 * i + 2] = 0;
                    }
                    equationOfY.Add(Convert.ToDouble(ds.Tables[0].Rows[3 + Convert.ToInt32(s)][2 * i + 2].ToString()));
                }

                List<double> x = new List<double>();
                for (int i = 0; i < num; i++)
                {
                    x.Add(1);
                }
                equationOfX.Add(x);
                for (int i = 1; i < Order ; i++)
                {
                    List<double> xx = new List<double>();
                    for (int j = 0; j < num; j++)
                    {
                        xx.Add(Convert.ToDouble(ds.Tables[0].Rows[i + Convert.ToInt32(s)][2 * j + 1].ToString())); ;
                    }
                    equationOfX.Add(xx);
                }
            }
        }

        private void btCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                coeCalculate();

                //double squareE = 0;
                for (int i = 0; i < num; i++)
                {
                    double y = 0;
                    int n = 0;
                    for (; n < Order; n++)
                    {
                        y += coefficient[n] * equationOfX[n][i];
                    }
                    //squareE += (equationOfY[i] - y) * (equationOfY[i] - y);
                }

                #region 显示结果
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add(" ", typeof(string));
                dt.Columns.Add("系数", typeof(string));
                for (int i = 0; i < Order; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[" "] = "a" + i.ToString();
                    //MessageBox.Show(coefficient[i].ToString());
                    dr["系数"] = coefficient[i].ToString("F10");
                    dt.Rows.Add(dr);
                }
                dt0 = dt;
                ds.Tables.Add(dt);
                //MessageBox.Show(ds.Tables[0].Rows[0][0].ToString());
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.DataSource = ds.Tables[0].DefaultView;

                DataSet dss = new DataSet();
                DataTable dtt = new DataTable();
                dtt.Columns.Add(" ", typeof(string));
                dtt.Columns.Add("y值", typeof(double));
                for (int i = 0; i < num; i++)
                {
                    int j = 0;
                    double y = 0;
                    foreach (double d in coefficient)
                    {
                        y += d * equationOfX[j][i];
                        j++;
                    }
                    DataRow drr = dtt.NewRow();
                    drr[0] = y.ToString("F10");
                    drr[1] = equationOfY[i];
                    dtt.Rows.Add(drr);
                }
                dt1 = dtt;
                dss.Tables.Add(dtt);
                dataGridView2.DataSource = dss.Tables[0];
                dataGridView2.DataSource = dss.Tables[0].DefaultView;
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 计算系数
        /// </summary>
        private void coeCalculate()
        {
            coefficient = new double[Order];
            Phalanx(0, num);
            PhalanxOfInverseTransformation();
            for (int i = 0; i < Order; i++)
            {
                coefficient[i] = 0;
                for (int n = 0; n < Order; n++)
                {
                    coefficient[i] += inversePhalanx[i, n] * resultMatrix[n];
                }
            }
        }

        /// <summary>
        /// 从样本计算得方阵
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private void Phalanx(int start, int end)
        {
            int i, j;
            /*样本求得三角方阵*/
            for (i = 0; i < Order; i++)
            {
                for (j = i; j < Order; j++)
                {
                    originalPhalanx[i, j] = 0;
                    int a = start;
                    for (; a < end; a++)
                    {
                        originalPhalanx[i, j] += equationOfX[i][a] * equationOfX[j][a];
                    }
                }
            }
            /*样本求得对应列阵*/
            for (i = 0; i < Order; i++)
            {
                resultMatrix[i] = 0;
                int a = start;
                for (; a < end; a++)
                {
                    resultMatrix[i] += equationOfY[a] * equationOfX[i][a];
                }
            }
            /*根据方阵对称性补充完整方阵*/
            for (i = 1; i < Order; i++)
            {
                for (j = 0; j < i; j++)
                {
                    originalPhalanx[i, j] = originalPhalanx[j, i];
                }
            }
        }

        /// <summary>
        /// 求出方阵的逆阵
        /// </summary>
        private void PhalanxOfInverseTransformation()
        {
            int m = 0;
            double[,] PoitOriginalPhalanx = new double[Order, Order];
            int i, j;
            for (i = 0; i < Order; i++)
            {
                for (j = 0; j < Order; j++)
                {
                    PoitOriginalPhalanx[i, j] = originalPhalanx[i, j];
                    inversePhalanx[i, j] = 0;
                }
                inversePhalanx[i, i] = 1;
            }
            int r, s, t;
            for (r = 0; r < Order; r++)
            {
                m = r;
                if (Math.Abs(PoitOriginalPhalanx[r, r]) < 0.0000000000001)
                {
                    m = r + 1;
                    if (m < Order)
                        for (; m < Order && Math.Abs(PoitOriginalPhalanx[m, r]) < 0.0000000000001; m++) ;
                    if (m >= Order)
                    {
                        return;
                    }
                    else
                    {
                        int n;
                        for (n = 0; n < Order; n++)//
                        {
                            double c = PoitOriginalPhalanx[r, n];
                            PoitOriginalPhalanx[r, n] = PoitOriginalPhalanx[m, n];
                            PoitOriginalPhalanx[m, n] = c;

                            c = inversePhalanx[r, n];
                            inversePhalanx[r, n] = inversePhalanx[m, n];
                            inversePhalanx[m, n] = c;
                        }
                    }
                }
                for (s = m + 1; s < Order; s++)//
                {
                    if (Math.Abs(PoitOriginalPhalanx[s, r]) > 0.0000000000001)
                    {
                        double x = PoitOriginalPhalanx[s, r];
                        for (t = 0; t < Order; t++)//
                        {
                            PoitOriginalPhalanx[s, t] = PoitOriginalPhalanx[s, t] / x * PoitOriginalPhalanx[r, r] - PoitOriginalPhalanx[r, t];
                            inversePhalanx[s, t] = inversePhalanx[s, t] / x * PoitOriginalPhalanx[r, r] - inversePhalanx[r, t];
                        }
                    }
                }
            }
            if (Math.Abs(PoitOriginalPhalanx[Order - 1, Order - 1]) < 0.0000000000001)
            {
                return;
            }
            else
            {
                for (r = Order - 1; r > 0; r--)
                {
                    double c = PoitOriginalPhalanx[r, r];
                    PoitOriginalPhalanx[r, r] = 1;
                    for (t = Order - 1; t >= 0; t--)
                    {
                        inversePhalanx[r, t] = inversePhalanx[r, t] / c;
                    }
                    for (s = r - 1; s >= 0; s--)
                    {
                        if (Math.Abs(PoitOriginalPhalanx[s, r]) > 0.0000000000001)
                        {
                            double d = PoitOriginalPhalanx[s, r];
                            for (t = Order - 1; t >= 0; t--)
                            {
                                PoitOriginalPhalanx[s, t] = PoitOriginalPhalanx[s, t] / d - PoitOriginalPhalanx[r, t];
                                inversePhalanx[s, t] = inversePhalanx[s, t] / d - inversePhalanx[r, t];
                            }
                        }
                    }
                }
                double cc = PoitOriginalPhalanx[0, 0];
                PoitOriginalPhalanx[0, 0] = 1;
                for (t = Order - 1; t >= 0; t--)
                {
                    inversePhalanx[0, t] = inversePhalanx[0, t] / cc;
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            for(int i=0;i<14;i++)
            {
                YChanged(i.ToString());
                coeCalculate();
                coePhalanx.Add(coefficient);
            }

            System.Windows.Forms.SaveFileDialog objSave = new System.Windows.Forms.SaveFileDialog();
            objSave.Filter = "(*.cof)|*.cof|"+"(*.*)|*.*";
            objSave.FileName = "系数列表";
            if (objSave.ShowDialog() == DialogResult.OK)
            {
                #region 导入txt
                using (StreamWriter objWriter = new StreamWriter(objSave.FileName, false, System.Text.Encoding.UTF8))
                {
                    for (int i = 0; i < 14; i++)
                    {
                        if (i<2)
                        {
                            for (int j = 1; j < Order; j++)
                            {
                                objWriter.Write(coePhalanx[i][j] + ",");
                            }
                            for (int j = 0; j < 10; j++)
                            {
                                objWriter.Write("0,");
                            }
                            objWriter.Write(coePhalanx[i][0] + "\r\n");                            
                        }
                        else if (i > 10)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                objWriter.Write("0,");
                            }
                            for (int j = 1; j < Order; j++)
                            {
                                objWriter.Write(coePhalanx[i][j] + ",");
                            }
                            objWriter.Write(coePhalanx[i][0] + "\r\n");
                        }
                        else
                        {
                            for (int j = 0; j < i - 1; j++)
                            {
                                objWriter.Write("0,");
                            }
                            for (int j = 1; j < Order; j++)
                            {
                                objWriter.Write(coePhalanx[i][j] + ",");
                            }
                            for (int j = 0; j < 11 - i; j++)
                            {
                                objWriter.Write("0,");
                            }
                            objWriter.Write(coePhalanx[i][0] + "\r\n");
                        }
                    }
                   /* objWriter.WriteLine("Yp0".PadRight(6) + coePhalanx[0][0].ToString("F10").PadRight(15) + coePhalanx[0][1].ToString("F10").PadRight(15) + coePhalanx[0][2].ToString("F10").PadRight(15) +
                        coePhalanx[0][3].ToString("F10").PadRight(15) + coePhalanx[0][4].ToString("F10").PadRight(15) + coePhalanx[0][5].ToString("F10").PadRight(15) + "0".PadRight(15) + "0".PadRight(15) +
                        "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15));
                    objWriter.WriteLine("Yp5".PadRight(6) + coePhalanx[1][0].ToString("F10").PadRight(15) + coePhalanx[1][1].ToString("F10").PadRight(15) + coePhalanx[1][2].ToString("F10").PadRight(15) +
                        coePhalanx[1][3].ToString("F10").PadRight(15) + coePhalanx[1][4].ToString("F10").PadRight(15) + coePhalanx[1][5].ToString("F10").PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) +
                        "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15));
                    objWriter.WriteLine("Yp10".PadRight(6) + coePhalanx[2][0].ToString("F10").PadRight(15) + "0".PadRight(15) + coePhalanx[2][1].ToString("F10").PadRight(15) + coePhalanx[2][2].ToString("F10").PadRight(15) +
                        coePhalanx[2][3].ToString("F10").PadRight(15) + coePhalanx[2][4].ToString("F10").PadRight(15) + coePhalanx[2][5].ToString("F10").PadRight(15) + "0".PadRight(15) + "0".PadRight(15) +
                        "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15));
                    objWriter.WriteLine("Yp20".PadRight(6) + coePhalanx[3][0].ToString("F10").PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + coePhalanx[3][1].ToString("F10").PadRight(15) + coePhalanx[3][2].ToString("F10").PadRight(15) +
                        coePhalanx[3][3].ToString("F10").PadRight(15) + coePhalanx[3][4].ToString("F10").PadRight(15) + coePhalanx[3][5].ToString("F10").PadRight(15) + "0".PadRight(15) +
                        "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15));
                    objWriter.WriteLine("Yp30".PadRight(6) + coePhalanx[4][0].ToString("F10").PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15)
                        + coePhalanx[4][1].ToString("F10").PadRight(15) + coePhalanx[4][2].ToString("F10").PadRight(15) +
                        coePhalanx[4][3].ToString("F10").PadRight(15) + coePhalanx[4][4].ToString("F10").PadRight(15) + coePhalanx[4][5].ToString("F10").PadRight(15) +
                        "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15));
                    objWriter.WriteLine("Yp40".PadRight(6) + coePhalanx[5][0].ToString("F10").PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) +
                        "0".PadRight(15) + coePhalanx[5][1].ToString("F10").PadRight(15) + coePhalanx[5][2].ToString("F10").PadRight(15) +
                        coePhalanx[5][3].ToString("F10").PadRight(15) + coePhalanx[5][4].ToString("F10").PadRight(15) + coePhalanx[5][5].ToString("F10").PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) +
                        "0".PadRight(15) + "0".PadRight(15));
                    objWriter.WriteLine("Yp50".PadRight(6) + coePhalanx[6][0].ToString("F10").PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) +
                        "0".PadRight(15) + "0".PadRight(15) + coePhalanx[6][1].ToString("F10").PadRight(15) + coePhalanx[6][2].ToString("F10").PadRight(15) +
                        coePhalanx[6][3].ToString("F10").PadRight(15) + coePhalanx[6][4].ToString("F10").PadRight(15) + coePhalanx[6][5].ToString("F10").PadRight(15) + "0".PadRight(15) + "0".PadRight(15) +
                        "0".PadRight(15) + "0".PadRight(15));
                    objWriter.WriteLine("Yp60".PadRight(6) + coePhalanx[7][0].ToString("F10").PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) +
                        "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + coePhalanx[7][1].ToString("F10").PadRight(15) + coePhalanx[7][2].ToString("F10").PadRight(15) +
                        coePhalanx[7][3].ToString("F10").PadRight(15) + coePhalanx[7][4].ToString("F10").PadRight(15) + coePhalanx[7][5].ToString("F10").PadRight(15) + "0".PadRight(15) +
                        "0".PadRight(15) + "0".PadRight(15));
                    objWriter.WriteLine("Yp70".PadRight(6) + coePhalanx[8][0].ToString("F10").PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) +
                        "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + coePhalanx[8][1].ToString("F10").PadRight(15) + coePhalanx[8][2].ToString("F10").PadRight(15) +
                        coePhalanx[8][3].ToString("F10").PadRight(15) + coePhalanx[8][4].ToString("F10").PadRight(15) + coePhalanx[8][5].ToString("F10").PadRight(15) +
                        "0".PadRight(15) + "0".PadRight(15));
                    objWriter.WriteLine("Yp80".PadRight(6) + coePhalanx[9][0].ToString("F10").PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) +
                        "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + coePhalanx[9][1].ToString("F10").PadRight(15) + coePhalanx[9][2].ToString("F10").PadRight(15) +
                        coePhalanx[9][3].ToString("F10").PadRight(15) + coePhalanx[9][4].ToString("F10").PadRight(15) + coePhalanx[9][5].ToString("F10").PadRight(15) + "0".PadRight(15));
                    objWriter.WriteLine("Yp90".PadRight(6) + coePhalanx[10][0].ToString("F10").PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) +
                        "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) +
                        "0".PadRight(15) + coePhalanx[10][1].ToString("F10").PadRight(15) + coePhalanx[10][2].ToString("F10").PadRight(15) +
                        coePhalanx[10][3].ToString("F10").PadRight(15) + coePhalanx[10][4].ToString("F10").PadRight(15) + coePhalanx[10][5].ToString("F10").PadRight(15));

                    objWriter.WriteLine("Yp100".PadRight(6) + coePhalanx[11][0].ToString("F10").PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) +
                        "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) +
                        "0".PadRight(15) + coePhalanx[11][1].ToString("F10").PadRight(15) + coePhalanx[11][2].ToString("F10").PadRight(15) +
                        coePhalanx[11][3].ToString("F10").PadRight(15) + coePhalanx[11][4].ToString("F10").PadRight(15) + coePhalanx[11][5].ToString("F10").PadRight(15));
                    //Process.Start(objSave.FileName);*/
                #endregion
                }
            }
           // ExportTexcel(dt0);
            //ExportTexcel(dt1);
        }


        #region 导出excel方法

        public static void ExportTexcel(System.Data.DataTable dt)
        {
            System.Data.DataTable data = dt;
            data.Columns.Add("特殊说明");
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Execl files (*.xlsx)|*.xlsx";
            saveDlg.FilterIndex = 0;
            saveDlg.RestoreDirectory = true;
            saveDlg.CreatePrompt = true;
            saveDlg.Title = "导出文件保存路径";
            saveDlg.FileName = "新建Excel文档";

            if (DialogResult.OK == saveDlg.ShowDialog())
            {
                try
                {

                    string strName = saveDlg.FileName;
                    if (strName.Length != 0)
                    {

                        System.Reflection.Missing miss = System.Reflection.Missing.Value;
                        Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                        excel.Application.Workbooks.Add(true); ;
                        excel.Visible = false;//若是true，则在导出的时候会显示EXcel界面。
                        if (excel == null)
                        {
                            MessageBox.Show("EXCEL无法启动！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
                        Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)(books.Add(miss));
                        Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
                        sheet.Name = "系数报表";

                        //Microsoft.Office.Interop.Excel.Application excel;
                        //Microsoft.Office.Interop.Excel._Workbook xBk;
                        //Microsoft.Office.Interop.Excel._Worksheet sheet;

                        int rowIndex = 4;
                        int colIndex = 0;

                        //excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                        //xBk = excel.Workbooks.Add(true);
                        //sheet = (Microsoft.Office.Interop.Excel._Worksheet)xBk.ActiveSheet;

                        //取得列标题 
                        foreach (DataColumn col in data.Columns)
                        {
                            colIndex++;
                            excel.Cells[4, colIndex] = col.ColumnName;

                            //设置标题格式为居中对齐
                            sheet.get_Range(excel.Cells[4, colIndex], excel.Cells[4, colIndex]).Font.Bold = true;
                            sheet.get_Range(excel.Cells[4, colIndex], excel.Cells[4, colIndex]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            sheet.get_Range(excel.Cells[4, colIndex], excel.Cells[4, colIndex]).Select();

                            //sheet.get_Range(excel.Cells[4, colIndex], excel.Cells[4, colIndex]).Interior.ColorIndex = 19;//19;//设置为浅黄色，共计有56种
                        }

                        //取得表格中的数据 
                        foreach (DataRow row in data.Rows)
                        {
                            rowIndex++;
                            colIndex = 0;
                            foreach (DataColumn col in data.Columns)
                            {
                                colIndex++;
                                if (col.DataType == System.Type.GetType("System.DateTime"))
                                {
                                    excel.Cells[rowIndex, colIndex] = (Convert.ToDateTime(row[col.ColumnName].ToString())).ToString("yyyy-MM-dd");
                                    sheet.get_Range(excel.Cells[rowIndex, colIndex], excel.Cells[rowIndex, colIndex]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;//设置日期型的字段格式为居中对齐
                                }
                                else
                                    if (col.DataType == System.Type.GetType("System.String"))
                                    {
                                        excel.Cells[rowIndex, colIndex] = "'" + row[col.ColumnName].ToString();
                                        sheet.get_Range(excel.Cells[rowIndex, colIndex], excel.Cells[rowIndex, colIndex]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;//设置字符型的字段格式为居中对齐
                                    }
                                    else
                                    {
                                        excel.Cells[rowIndex, colIndex] = row[col.ColumnName].ToString();
                                    }
                            }
                        }

                        int rowSum = rowIndex + 1;

                        //取得整个报表的标题 
                        excel.Cells[2, 2] = "质检报表";
                        excel.Cells[3, 6] = "日期：" + DateTime.Now.ToString("yyyy年MM月dd日");

                        //设置整个报表的标题格式 
                        sheet.get_Range(excel.Cells[2, 2], excel.Cells[2, 2]).Font.Bold = true;
                        sheet.get_Range(excel.Cells[2, 2], excel.Cells[2, 2]).Font.Size = 22;

                        //设置报表表格为最适应宽度 
                        sheet.get_Range(excel.Cells[4, 2], excel.Cells[rowSum, colIndex]).Select();
                        sheet.get_Range(excel.Cells[4, 2], excel.Cells[rowSum, colIndex]).Columns.AutoFit();

                        //设置整个报表的标题为跨列居中 
                        sheet.get_Range(excel.Cells[2, 2], excel.Cells[2, colIndex]).Select();
                        sheet.get_Range(excel.Cells[2, 2], excel.Cells[2, colIndex]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                        //绘制边框 
                        sheet.get_Range(excel.Cells[4, 1], excel.Cells[rowSum, colIndex]).Borders.LineStyle = 1;
                        sheet.get_Range(excel.Cells[4, 1], excel.Cells[rowSum, 1]).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;//设置左边线
                        sheet.get_Range(excel.Cells[4, 1], excel.Cells[4, colIndex]).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;//设置上边线
                        sheet.get_Range(excel.Cells[4, colIndex], excel.Cells[rowSum, colIndex]).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;//设置右边线
                        sheet.get_Range(excel.Cells[rowSum, 1], excel.Cells[rowSum, colIndex]).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;//设置下边线

                        sheet.SaveAs(strName, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
                        book.Close(false, miss, miss);
                        books.Close();
                        excel.Quit();

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);

                        GC.Collect();
                        MessageBox.Show("数据已经成功导出到：" + saveDlg.FileName.ToString(), "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //toolStripProgressBar1.Value = 0;
                        //toolStripProgressBar1.Visible = false;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
