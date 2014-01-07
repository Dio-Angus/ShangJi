/*-----------------------------------------------------------------------------
//  FILE NAME       : GcDataAnalyFrm.cs
//  FUNCTION        : 分析通道数据窗口
//  AUTHOR          : 李锋(2010/06/12)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AnalyGc
{
    /// <summary>
    /// 分析通道数据窗口
    /// </summary>
    public partial class GcDataAnalyFrm : Form
    {

        #region 变量
        private int _countA = 0;
        private int _countB = 0;
        private int _countC = 0;
        private int _countD = 0;

        private StringBuilder _gcString = new StringBuilder();
        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public GcDataAnalyFrm()
        {
            InitializeComponent();
            this.LoadEvent();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
        }
        #endregion


        #region 方法

        /// <summary>
        /// 装载文本文件
        /// </summary>
        /// <param name="filePathName"></param>
        private void LoadGcFile(string filePathName)
        {
            this.lbResult.Items.Add("Start Load --> " + filePathName);

            StreamReader sr = null;
            string strLine = "";

            this._gcString.Remove(0,this._gcString.Length);


            //对数据的有效性进行验证
            if (String.IsNullOrEmpty(filePathName))
            {
                throw new Exception("请指定要载入的txt文件名");
            }
            else if (!File.Exists(filePathName))
            {
                throw new Exception("指定的txt文件不存在");
            }


            try
            {
                sr = new StreamReader(filePathName, Encoding.Default);
                strLine = sr.ReadLine();

                while (!String.IsNullOrEmpty(strLine))
                {
                    if (!String.IsNullOrEmpty(strLine) && strLine.Length > 0)
                    {
                        this._gcString.Append(strLine);
                    }
                    strLine = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
                sr.Close();
            }

            if (null == this._gcString)
            {
                this.lbResult.Items.Add("Load Finished, Length --> 0 ");
            }
            else
            {
                this.lbResult.Items.Add("Load Finished, Length --> " + this._gcString.Length);
            }
        }

        /// <summary>
        /// 分析通道数据
        /// </summary>
        private void AnalyGcData()
        {
            this.lbResult.Items.Add("Start Analy -->");

            int indexStart = 0;
            int indexEnd = 0;
            string oneFrame = "";

            if (null != this._gcString && 0 < this._gcString.Length)
            {
                this._gcString.Replace("\r\n", "");
                this._gcString.Replace(" ", "");
            }

            while (null != this._gcString)
            {

                //提取桢的开始位置
                indexStart = this._gcString.ToString().IndexOf(Version2000.StartChar);

                //提取桢的结束位置
                indexEnd = this._gcString.ToString().IndexOf(Version2000.EndChar, (-1 == indexStart) ? 0 : indexStart + 2);

                if (-1 == indexStart && -1 == indexEnd)
                {
                    break;
                }
                else if (-1 != indexStart && -1 == indexEnd)
                {
                    break;
                }
                else if (-1 == indexStart && -1 != indexEnd)
                {
                    this._gcString.Remove(0, indexEnd + 1);
                    //break;
                }
                else
                {
                    oneFrame = this._gcString.ToString().Substring(indexStart, indexEnd - indexStart + 2);

                    this.DealWithGasVoltage(oneFrame);
                    this._gcString.Remove(0, indexEnd + 1);
                }


            }

            this.lbResult.Items.Add("Count A = " + this._countA);
            this.lbResult.Items.Add("Count B = " + this._countB);
            this.lbResult.Items.Add("Count C = " + this._countC);
            this.lbResult.Items.Add("Count D = " + this._countD);
            this.lbResult.Items.Add("Analy Finished!");
            this.lbResult.SelectedIndex = this.lbResult.Items.Count - 1;
        }

        /// <summary>
        /// 处理电压值
        /// </summary>
        /// <param name="oneFrame"></param>
        private void DealWithGasVoltage(string oneFrame)
        {

            if (Version2000.FrameLength != oneFrame.Length)
            {
                this.lbResult.Items.Add(
                    String.Format("Error frame:{0}, length = {1}", oneFrame, oneFrame.Length));
                return;
            }

            switch (oneFrame.Substring(2, 1))
            {
                case GasChannel.A:
                    _countA++;
                    break;
                case GasChannel.E:
                    _countB++;
                    break;
                case GasChannel.B:
                    _countC++;
                    break;
                case GasChannel.F:
                    _countD++;
                    break;
            }
        }

        #endregion


        #region 事件

        /// <summary>
        /// 装载文件按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Multiselect = false;
                dlg.Title = "请选择txt文件";
                dlg.Filter = "txt Files (*.txt)|*.txt";
                //+ "|All Files (*.*)|*.*";
                dlg.InitialDirectory = Directory.GetCurrentDirectory();

                // If selected, add the new file(s)
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.txtLoadFile.Text = dlg.FileName;

                    Cursor.Current = Cursors.WaitCursor;

                    this._countA = 0;
                    this._countB = 0;
                    this._countC = 0;
                    this._countD = 0;

                    this.LoadGcFile(dlg.FileName);

                    this.AnalyGcData();

                    Cursor.Current = Cursors.Default;
                }
            }
        }

        #endregion

    }


    /// <summary>
    /// 2000型 桢特征
    /// </summary>
    public class Version2000
    {

        /// <summary>
        /// 桢开始字符
        /// </summary>
        public const string StartChar = "23";

        /// <summary>
        /// 桢结束字符
        /// </summary>
        public const string EndChar = "21";

        /// <summary>
        /// 桢长度 23 A1 A2 A3 A4 A5 A6 MM 21
        /// </summary>
        public const Int32 FrameLength = 9 * 2;

        /// <summary>
        /// 通道1的开始命令
        /// </summary>
        public const string StartCmdA = "25AAD79D8945BFA3409092A3C2134BA729DD21";

        /// <summary>
        /// 通道2的开始命令
        /// </summary>
        public const string StartCmdB = "25BBD79D8945BFA3409092A3C2134BA729DD21";
    }

    /// <summary>
    /// 通道气的通道类型
    /// </summary>
    public class GasChannel
    {

        /// <summary>
        /// 通道A
        /// </summary>
        [EnumDescription("A")]
        public const String A = "A";

        /// <summary>
        /// 通道B
        /// </summary>
        [EnumDescription("B")]
        public const String B = "B";

        /// <summary>
        /// 通道C
        /// </summary>
        [EnumDescription("C")]
        public const String C = "C";

        /// <summary>
        /// 通道D
        /// </summary>
        [EnumDescription("D")]
        public const String D = "D";

        /// <summary>
        /// 通道E
        /// </summary>
        [EnumDescription("E")]
        public const String E = "E";

        /// <summary>
        /// 通道F
        /// </summary>
        [EnumDescription("F")]
        public const String F = "F";
    }
}
