/*-----------------------------------------------------------------------------
//  FILE NAME       : OnHardStatusViewer.cs
//  FUNCTION        : 硬件状态视图
//  AUTHOR          : 李锋(2009/06/25)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChromatoBll.serialCom;
using ChromatoTool.ini;
using ChromatoTool.util;
using ChromatoBll.ocx.biz;
using System.Threading;

namespace ChromatoCore.On
{

    /// <summary>
    /// 硬件状态视图
    /// </summary>
    public partial class OnHardStatusViewer : UserControl
    {

        #region 常量

        /// <summary>
        /// FID1调零
        /// </summary>
        private const String Fid1_Zero = "FID1调零";

        /// <summary>
        /// FID1回零
        /// </summary>
        private const String Fid1_To_Zero = "FID1回零";

        /// <summary>
        /// FID2调零
        /// </summary>
        private const String Fid2_Zero = "FID2调零";

        /// <summary>
        /// FID2回零
        /// </summary>
        private const String Fid2_To_Zero = "FID2回零";

        /// <summary>
        /// TCD1调零
        /// </summary>
        private const String Tcd1_Zero = "TCD1调零";

        /// <summary>
        /// TCD1回零
        /// </summary>
        private const String Tcd1_To_Zero = "TCD1回零";

        /// <summary>
        /// TCD2调零
        /// </summary>
        private const String Tcd2_Zero = "TCD2调零";

        /// <summary>
        /// TCD2回零
        /// </summary>
        private const String Tcd2_To_Zero = "TCD2回零";

        /// <summary>
        /// ℃
        /// </summary>
        private const String TempUnit = " ℃";
        
        /// <summary>
        /// 微伏
        /// </summary>
        private const String uVol = " 微伏";

        #endregion


        #region 变量

        /// <summary> 
        /// 跨线程控件代理
        /// </summary> 
        private delegate void CrossThreadOperationControl();

        /// <summary>
        /// 数据处理スレッド
        /// </summary>
        private Thread _flashThread = null;

        /// <summary>
        /// 是否闪烁LED
        /// </summary>
        private bool _isFlash = false;

        /// <summary>
        /// 显示
        /// </summary>
        private Color ReadyOn = Color.Cyan;

        /// <summary>
        /// 初期
        /// </summary>
        private Color ReadyOff = Color.Snow;

        /// <summary>
        /// 可以起动事件
        /// </summary>
        public event EventHandler<OnReadyActionArgs> ReadyChanged = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OnHardStatusViewer()
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
            this.lblColStatus.Text = "";
            this.lblColTemp.Text = "";
            this.lblTcdTemp.Text = "";
            this.lblFidTemp.Text = "";
            this.lblInjTemp.Text = "";
            this.lblAux1Temp.Text = "";
            this.lblAux2Temp.Text = "";
            this.lblFid1Signal.Text = "";
            this.lblFid2Signal.Text = "";
            this.lblTcd1Signal.Text = "";
            this.lblTcd2Signal.Text = "";

            this.cbxEnableAux2.Checked = false;
            this.cbxEnableAux1.Checked = false;
            this.cbxEnableINJ.Checked = false;
            this.cbxEnableFid1.Checked = false;
            this.cbxEnableTcd1.Checked = false;
            this.cbxEnableCol.Checked = false;

            this.cbxInit.BackColor = ReadyOff;
            this.cbxRaise.BackColor = ReadyOff;
            this.cbxAfter.BackColor = ReadyOff;
            this.cbxCool.BackColor = ReadyOff;
            this.cbxStop.BackColor = ReadyOff;
            this.cbxReady.BackColor = ReadyOff;

            
            switch (General.ObjectLink)
            {
                case General.LinkObject.BigBoard:

                    //GC状态实时输出更新事件
                    ((Comm3010)CommPort.Instance).RealHardUpdated += new EventHandler<OnRealHardUpdateArgs>(this.UpdateRealStatus);
                    
                    //柱箱准备状态LED线程
                    this._flashThread = new Thread(FlashStopRadioThread);
                    this._flashThread.Name = "FlashStopRadioThread->";
                    this._flashThread.Start();
                    break;
            }

        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadEvent()
        {
            this.btnSendHeat.Click += new System.EventHandler(this.btnSendHeat_Click);
            this.btnSendEnable.Click += new System.EventHandler(this.btnSendEnable_Click);

            this.btnFid1Zero.Click += new System.EventHandler(this.btnFid1Zero_Click);
            this.btnFid2Zero.Click += new System.EventHandler(this.btnFid2Zero_Click);

            this.btnTcd1Zero.Click += new System.EventHandler(this.btnTcd1Zero_Click);
            this.btnTcd2Zero.Click += new System.EventHandler(this.btnTcd2Zero_Click);

            this.btnTcd1OpenCurrent.Click += new System.EventHandler(this.btnTcd1OpenCurrent_Click);
            this.btnTcd2OpenCurrent.Click += new System.EventHandler(this.btnTcd2OpenCurrent_Click);

        }

        /// <summary>
        /// 是否准备好
        /// </summary>
        /// <returns></returns>
        public bool isReady()
        {
            return (!this._isFlash & this.cbxReady.BackColor == this.ReadyOn) ? true : false;
        }

        #endregion


        #region 方法

        /// <summary>
        /// 实时更新界面的GC状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UpdateRealStatus(object sender, OnRealHardUpdateArgs e)
        {
            // 匿名代理
            CrossThreadOperationControl CrossUpdateUi = delegate()
            {
                this.UpdateUi(e._type,e._value);
            };
            if (this.InvokeRequired)
            {
                this.Invoke(CrossUpdateUi);
            }
        }

        /// <summary>
        /// 刷新界面,℃ ℉
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        private void UpdateUi(String type, String value)
        {
            switch (type)
            {
                case GcCommand.ColStatus:
                    switch ((StepType)Convert.ToInt32(value, 16))
                    {
                        case StepType.Init:
                        case StepType.InitKeep:
                        case StepType.UpOne:
                        case StepType.KeepOne:
                        case StepType.UpTwo:
                        case StepType.KeepTwo:
                        case StepType.UpThree:
                        case StepType.KeepThree:
                        case StepType.UpFour:
                        case StepType.KeepFour:
                        case StepType.UpFive:
                        case StepType.KeepFive:
                        case StepType.Ready:
                            this.lblColStatus.Text = EnumDescription.GetFieldText((StepType)Convert.ToInt32(value, 16));
                            break;
                    }
                    break;

                case GcCommand.ColTargetTemp:
                    this.lblColTargetTemp.Text = value;
                    break;

                case GcCommand.ColTemp:
                    this.lblColTemp.Text = value;
                    break;

                case GcCommand.TcdTemp:
                    this.lblTcdTemp.Text = value;
                    break;

                case GcCommand.FidTemp:
                    this.lblFidTemp.Text = value;
                    break;

                case GcCommand.InjTemp:
                    this.lblInjTemp.Text = value;
                    break;

                case GcCommand.Aux1Temp:
                    this.lblAux1Temp.Text = value;
                    break;

                case GcCommand.Aux2Temp:
                    this.lblAux2Temp.Text = value;
                    break;

                case GcCommand.Fid1Signal:
                    this.lblFid1Signal.Text = String.Format("{0:0,0}",Convert.ToSingle(value));
                    break;
                case GcCommand.Fid2Signal:
                    this.lblFid2Signal.Text = String.Format("{0:0,0}", Convert.ToSingle(value));
                    break;
                case GcCommand.Tcd1Signal:
                    this.lblTcd1Signal.Text = String.Format("{0:0,0}", Convert.ToSingle(value));
                    break;
                case GcCommand.Tcd2Signal:
                    this.lblTcd2Signal.Text = String.Format("{0:0,0}", Convert.ToSingle(value));
                    break;

                case GcCommand.ColTempStatus:
                    this.SetColTempStatus(value);
                    break;

                case GcCommand.PrepareLed:
                    this.SetReadyLedStatus(value);
                    break;
            }
        }

        /// <summary>
        /// 更新界面柱箱温度状态
        /// </summary>
        /// <param name="val"></param>
        private void SetColTempStatus(String val)
        {
            Int32 status = Convert.ToInt32(val, 16);

            this.cbxInit.BackColor = (status & (int)ColumnTempStatus.Init) > 0 ? ReadyOn : ReadyOff;
            this.cbxRaise.BackColor = (status & (int)ColumnTempStatus.Raise) > 0 ? ReadyOn : ReadyOff;
            this.cbxAfter.BackColor = (status & (int)ColumnTempStatus.After) > 0 ? ReadyOn : ReadyOff;
            this.cbxCool.BackColor = (status & (int)ColumnTempStatus.Cool) > 0 ? ReadyOn : ReadyOff;
            this.cbxStop.BackColor = (status & (int)ColumnTempStatus.Stop) > 0 ? ReadyOn : ReadyOff;
            this.cbxReady.BackColor = (status & (int)ColumnTempStatus.Ready) > 0 ? ReadyOn : ReadyOff;
            this._isFlash = false;

            OnReadyActionArgs eve = null;

            eve = new OnReadyActionArgs(this.isReady());
            this.ReadyChanged(this, eve);
        }

        /// <summary>
        /// 更新准备灯的状态
        /// </summary>
        /// <param name="val"></param>
        private void SetReadyLedStatus(string val)
        {
            Int32 status = Convert.ToInt32(val, 16);
            this._isFlash = (status > 0) ? true : false;

            OnReadyActionArgs eve = null;

            eve = new OnReadyActionArgs(this.isReady());
            this.ReadyChanged(this, eve);
        }

        /// <summary>
        /// 更新准备灯状态
        /// </summary>
        public void FlashReadyColumn()
        {
            this.cbxReady.BackColor = (this.cbxReady.BackColor == ReadyOff ) ? ReadyOn : ReadyOff;
        }

        /// <summary>
        /// 更新准备灯状态的线程
        /// </summary>
        private void FlashStopRadioThread()
        {
            while (true)
            {
                if (this._isFlash)
                {
                    // 匿名代理
                    //CrossThreadOperationControl CrossFlashReadyColumn = delegate()
                    //{
                    //this.cbxReady.BackColor = (this.cbxReady.BackColor == ReadyOff) ? ReadyOn : ReadyOff;
                    this.FlashReadyColumn();
                    //};
                    //if (this.InvokeRequired)
                    //{
                    //    this.Invoke(CrossFlashReadyColumn);
                    //}

                    Thread.Sleep(50);
                }

                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// 停止工作线程
        /// </summary>
        public void StopThread()
        {
            this._flashThread.Abort();
            this._flashThread = null;
        }

        #endregion


        #region 事件

        /// <summary>
        /// 发送加热状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendHeat_Click(object sender, EventArgs e)
        {
            int tempHigh = 0xF;
            tempHigh &= this.cbxHeatAux2.Checked ? 0xF : 0x7;
            tempHigh &= this.cbxHeatAux1.Checked ? 0xF : 0xB;
            tempHigh &= this.cbxHeatINJ.Checked ? 0xF : 0xD;
            tempHigh &= this.cbxHeatFid1.Checked ? 0xF : 0xE;

            int tempLow = 0xC;
            tempLow &= this.cbxHeatTcd1.Checked ? 0xC : 0x4;
            tempLow &= this.cbxHeatCol.Checked ? 0xC : 0x0;

            StringBuilder para = new StringBuilder();
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.HeatStatus + "00" +
                Convert.ToString(tempHigh, 16) + Convert.ToString(tempLow, 16) + Version3010.FrameEnd);
            CommPort.Instance.Send(para.ToString(), true);
        }

        /// <summary>
        /// 发送使能状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendEnable_Click(object sender, EventArgs e)
        {
            int tempHigh = 0xF;
            tempHigh &= this.cbxEnableAux2.Checked ? 0xF : 0x7;
            tempHigh &= this.cbxEnableAux1.Checked ? 0xF : 0xB;
            tempHigh &= this.cbxEnableINJ.Checked ? 0xF : 0xD;
            tempHigh &= this.cbxEnableFid1.Checked ? 0xF : 0xE;

            int tempLow = 0xC;
            tempLow &= this.cbxEnableTcd1.Checked ? 0xC : 0x4;
            tempLow &= this.cbxEnableCol.Checked ? 0xC : 0x0;

            StringBuilder para = new StringBuilder();
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.EnableStatus + "00" +
                Convert.ToString(tempHigh, 16) + Convert.ToString(tempLow, 16) + Version3010.FrameEnd);
            CommPort.Instance.Send(para.ToString(), true);

        }

        /// <summary>
        /// Fid1调零回零命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFid1Zero_Click(object sender, EventArgs e)
        {
            this.btnFid1Zero.Enabled = false;
            String temp = this.btnFid1Zero.Text;
            StringBuilder para = new StringBuilder();

            if (Fid1_Zero.Equals(temp))
            {
                para.Append(Version3010.DataStart + ModuleAddress.FID1 + "38" + Version3010.FrameEnd);
                this.btnFid1Zero.Text = Fid1_To_Zero;
            }
            else
            {
                para.Append(Version3010.DataStart + ModuleAddress.FID1 + "3B" + Version3010.FrameEnd);
                this.btnFid1Zero.Text = Fid1_Zero;
            }
            CommPort.Instance.Send(para.ToString(), true);
            this.btnFid1Zero.Enabled = true;
        }

        /// <summary>
        /// Fid2调零回零命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFid2Zero_Click(object sender, EventArgs e)
        {
            this.btnFid2Zero.Enabled = false;
            String temp = this.btnFid2Zero.Text;
            StringBuilder para = new StringBuilder();

            if (Fid2_Zero.Equals(temp))
            {
                para.Append(Version3010.DataStart + ModuleAddress.FID2 + "38" + Version3010.FrameEnd);
                this.btnFid2Zero.Text = Fid2_To_Zero;
            }
            else
            {
                para.Append(Version3010.DataStart + ModuleAddress.FID2 + "3B" + Version3010.FrameEnd);
                this.btnFid2Zero.Text = Fid2_Zero;
            }
            CommPort.Instance.Send(para.ToString(), true);
            this.btnFid2Zero.Enabled = true;
        }

        /// <summary>
        /// Tcd1调零回零命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTcd1Zero_Click(object sender, EventArgs e)
        {
            this.btnTcd1Zero.Enabled = false;
            String temp = this.btnTcd1Zero.Text;
            StringBuilder para = new StringBuilder();

            if (Tcd1_Zero.Equals(temp))
            {
                para.Append(Version3010.DataStart + ModuleAddress.TCD1 + "39" + Version3010.FrameEnd);
                this.btnTcd1Zero.Text = Tcd1_To_Zero;
            }
            else
            {
                para.Append(Version3010.DataStart + ModuleAddress.TCD1 + "3C" + Version3010.FrameEnd);
                this.btnTcd1Zero.Text = Tcd1_Zero;
            }
            CommPort.Instance.Send(para.ToString(), true);
            this.btnTcd1Zero.Enabled = true;
        }

        /// <summary>
        /// Tcd2调零回零命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTcd2Zero_Click(object sender, EventArgs e)
        {
            this.btnTcd2Zero.Enabled = false;
            String temp = this.btnTcd2Zero.Text;
            StringBuilder para = new StringBuilder();

            if (Tcd2_Zero.Equals(temp))
            {
                para.Append(Version3010.DataStart + ModuleAddress.TCD2 + "39" + Version3010.FrameEnd);
                this.btnTcd2Zero.Text = Tcd2_To_Zero;
            }
            else
            {
                para.Append(Version3010.DataStart + ModuleAddress.TCD2 + "3C" + Version3010.FrameEnd);
                this.btnTcd2Zero.Text = Tcd2_Zero;
            }
            CommPort.Instance.Send(para.ToString(), true);
            this.btnTcd2Zero.Enabled = true;
        }

        /// <summary>
        /// Tcd1电流开启命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTcd1OpenCurrent_Click(object sender, EventArgs e)
        {
            this.btnTcd1OpenCurrent.Enabled = false;

            StringBuilder para = new StringBuilder();
            para.Append(Version3010.DataStart + ModuleAddress.TCD1 + "41" + Version3010.FrameEnd);
            CommPort.Instance.Send(para.ToString(), true);

            this.btnTcd1OpenCurrent.Enabled = true;
        }

        /// <summary>
        /// Tcd2电流开启命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTcd2OpenCurrent_Click(object sender, EventArgs e)
        {
            this.btnTcd2OpenCurrent.Enabled = false;

            StringBuilder para = new StringBuilder();
            para.Append(Version3010.DataStart + ModuleAddress.TCD2 + "41" + Version3010.FrameEnd);
            CommPort.Instance.Send(para.ToString(), true);

            this.btnTcd2OpenCurrent.Enabled = true;
        }

        #endregion



    }
}
