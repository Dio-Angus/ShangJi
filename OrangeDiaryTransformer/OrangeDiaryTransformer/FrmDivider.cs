using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//word组件
using MSWord = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;

namespace OrangeDiaryDivider
{


    public partial class FrmDivider : Form
    {
        private MSWord._Application App;
        private MSWord._Document Doc;
        private Object path;
        private string content;

        //构造窗口
        public FrmDivider()
        {        
            InitializeComponent();  
            defaltSet();
        }

        private void defaltSet()
        {
            tbSourcePath.Text = "C:\\Users\\Dio\\Desktop\\Title.docx";
            tbObjectivePath.Text = "C:\\Users\\Dio\\Documents\\OrangeDiary";
            tbKeyWord.Text = "Title";
        }

        private void btBrowse1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "OrangeDiary";
            op.FileName = "";
            op.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//为了获取特定的系统文件夹，可以使用System.Environment类的静态方法GetFolderPath()。该方法接受一个Environment.SpecialFolder枚举，其中可以定义要返回路径的哪个系统目录
            op.Filter = "Word文件(*.docx)|*.docx";//|文本文档（*.txt）|*.txt|All files|*.*";
            op.ValidateNames = true;     //文件有效性验证ValidateNames，验证用户输入是否是一个有效的Windows文件名
            op.CheckFileExists = true;  //验证路径有效性
            op.CheckPathExists = true; //验证文件有效性
            if (op.ShowDialog() == DialogResult.OK)
            {
                tbSourcePath.Text = op.FileName;
            }
        }

        private void btBrowse2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog sa = new FolderBrowserDialog();//文件夹路径
            //sa.RootFolder = Environment.SpecialFolder.MyDocuments;//为了获取特定的系统文件夹，可以使用System.Environment类的静态方法GetFolderPath()。该方法接受一个Environment.SpecialFolder枚举，其中可以定义要返回路径的哪个系统目录
            if (sa.ShowDialog() == DialogResult.OK)
            {
                tbObjectivePath.Text = sa.SelectedPath;
            }
        }

        private void btExcute_Click(object sender, EventArgs e)
        {
            import();
            if (tbKeyWord.Text == ""||content.Count()==0)
            {
                MessageBox.Show("请输入关键字");
            }
            else
            {
                Excute();
            }
        }

        private void btOption_Click(object sender, EventArgs e)
        {

        }

        #region 方法

        /// <summary>
        /// 导入文本
        /// </summary>
        private void import()
        {
            path = tbSourcePath.Text;
            App = new MSWord.Application();
            Object nothing = Type.Missing;
            Doc = App.Documents.Open(ref path, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                ref nothing, ref nothing, ref nothing, ref nothing);

            //range操作
            Object start = Type.Missing;
            Object end = Doc.Characters.Count;
            MSWord.Range Rng = Doc.Range(ref start, ref end);//通过Range对文本进行操作，也可用Range Rng=Doc.Content
            content = Rng.Text;

            Doc.Close();
        }

        /// <summary>
        /// 拆分文本，保存文章
        /// </summary>
        private void Excute()
        {
            try
            {
                string[] article = content.Split(new[] { tbKeyWord.Text }, StringSplitOptions.RemoveEmptyEntries);
                string name;
                label5.Text = "拆分中...";
                foreach (string s in article)
                {
                    if (s.IndexOf("Created") >= 0)
                    {
                        name = s.Substring(1, s.IndexOf("Created") - 2);
                        path = tbObjectivePath.Text + "\\" + name;
                        Object nothing = Type.Missing;
                        Doc = App.Documents.Add(ref nothing, ref nothing, ref nothing, ref nothing);
                        MSWord.Range Rng = Doc.Content;
                        Rng.Text = tbKeyWord.Text + s;
                        Doc.SaveAs(ref path);
                        Doc.Close();
                    }
                }
                App.Quit();
                label5.Text = "拆分成功";
            }
            catch
            {
                label5.Text = "拆分失败";
            }
        }

        #endregion
    }
}
