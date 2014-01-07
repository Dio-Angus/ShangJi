/*-----------------------------------------------------------------------------
//  FILE NAME       : OffGasSumFrm.cs
//  FUNCTION        : 汇总样品结果选择打印窗口
//  AUTHOR          : 李锋(2010/04/22)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChromatoCore.Off
{
    /// <summary>
    /// 汇总样品结果选择打印窗口
    /// </summary>
    public partial class OffGasSumFrm : Form
    {


        #region 变量

        /// <summary>
        /// 分隔条
        /// </summary>
        private Splitter splitterMain = null;

        /// <summary>
        /// 样品列表
        /// </summary>
        private OffGasSum _listGas = null;
    
        /// <summary>
        /// 报告报告
        /// </summary>
        private OffReportViewer _OffReport = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OffGasSumFrm()
        {
            InitializeComponent();
            this.LoadUi();
            this.LoadEvent();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._listGas = new OffGasSum();
            this._listGas.Dock = DockStyle.Top;

            this.splitterMain = new Splitter();
            this.splitterMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterMain.Location = new System.Drawing.Point(0, 2);
            this.splitterMain.Name = "splitterMain";
            this.splitterMain.Size = new System.Drawing.Size(666, 3);
            this.splitterMain.TabIndex = 20;
            this.splitterMain.TabStop = false;

            this._OffReport = new OffReportViewer();
            this._OffReport.Dock = DockStyle.Fill;

            this.Controls.Add(this._OffReport);
            this.Controls.Add(this.splitterMain);
            this.Controls.Add(this._listGas);

            this.splitterMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitterMain_SplitterMoved);

            //列表窗口更换样品事件
            //this._listGas.SampleChanged += new EventHandler<OffSampleChangeArgs>(listOff_SampleChanged);
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            //窗口改变大小
            this.Resize += new System.EventHandler(this.OffGasSumFrm_Resize);

            //关闭按钮按下的事件
            this._listGas.BtnCloseClickedEvent += new CloseBtnClickDelegate(this.CloseGasSum_Clicked);

            //汇总按钮按下的事件
            this._listGas.SumClicked += new EventHandler<OffSumBtnClickArgs>(this.SumPrint_Clicked);
        }

        #endregion


        #region 方法

        /// <summary>
        /// 改变各个page改变大小
        /// </summary>
        public void PageResize()
        {
            this._listGas.Width = this.Width;
            this._listGas.Height = this.splitterMain.Top;

            this.splitterMain.Width = this.Width;
            this.splitterMain.Location = new Point(0, this._listGas.Bottom);
            //this.splitterMain.BackColor = Color.BlueViolet;

            this._OffReport.Width = this.Width;
            this._OffReport.Top = this._listGas.Bottom + this.splitterMain.Height;
            this._OffReport.Height = this.Height - this._listGas.Height - this.splitterMain.Height;
            this._OffReport.CtrlResize();
        }
        

        /// <summary>
        /// 关闭窗口
        /// </summary>
        private void CloseGasSum_Clicked()
        {
            this.Close();
        }
        
        /// <summary>
        /// 汇总打印事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SumPrint_Clicked(object sender, OffSumBtnClickArgs e)
        {
            this._OffReport.LoadUi(e._arr, e._dtResult);

        }

        #endregion


        #region 事件

        /// <summary>
        /// 分割条事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitterMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.PageResize();
        }

        /// <summary>
        /// 列表窗口更换样品事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listOff_SampleChanged(object sender, OffSampleChangeArgs e)
        {
            //this.dtoPara = (ParaDto)e._var;
            //this.LoadItem(this.dtoPara);
        }

        /// <summary>
        /// 窗口改变大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OffGasSumFrm_Resize(object sender, EventArgs e)
        {
            this.PageResize();
        }

        #endregion




    }
}
