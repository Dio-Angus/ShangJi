/*-----------------------------------------------------------------------------
//  FILE NAME       : OnGroup.cs
//  FUNCTION        : 采集组合
//  AUTHOR          : 李锋(2009/05/24)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoTool.ini;
using ChromatoTool.pipe;
using ChromatoTool.dto;
using ChromatoTool.util;
using ChromatoBll.serialCom;
using ChromatoBll.ocx.biz;
using ChromatoBll.bll;
using System.Collections;
using System.Threading;

namespace ChromatoCore.On
{
    /// <summary>
    /// 采集组合
    /// </summary>
    public partial class OnGroup : OnGroupBase
    {

        #region 变量

        /// <summary>
        /// 分隔条
        /// </summary>
        private Splitter _splitterMain = null;

        /// <summary>
        /// 样品列表
        /// </summary>
        private OnList _listOn = null;

        /// <summary>
        /// 样品项目集合
        /// </summary>
        private OnBottom _bottomOn = null;

        /// <summary> 
        /// 跨线程控件代理
        /// </summary> 
        private delegate void CrossThreadOperationControl();

        /// <summary>
        /// 扫描列表线程
        /// </summary>
        private Thread _applyThread = null;

        public static bool RunDone = true;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OnGroup()
        {
            InitializeComponent();
            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._listOn = new OnList();
            this._listOn.Dock = DockStyle.Top;

            this._splitterMain = new Splitter();
            this._splitterMain.Dock = System.Windows.Forms.DockStyle.Top;
            this._splitterMain.Location = new System.Drawing.Point(0, 2);
            this._splitterMain.Name = "splitterMain";
            this._splitterMain.Size = new System.Drawing.Size(666, 3);
            this._splitterMain.TabIndex = 20;
            this._splitterMain.TabStop = false;
            this._splitterMain.SplitterMoved += new SplitterEventHandler(this.splitterMain_SplitterMoved);

            this._bottomOn = new OnBottom();
            this._bottomOn.Dock = DockStyle.Fill;

            this.Controls.Add(this._bottomOn);
            this.Controls.Add(this._splitterMain);
            this.Controls.Add(this._listOn);

            //列表窗口更换样品事件
            this._listOn.SampleChanged += new EventHandler<OnSampleChangeArgs>(listOn_SampleChanged);

            //列表窗口发送命令事件
            this._listOn.ChannelActioned += new EventHandler<OnChannelActionArgs>(listOn_ChannelActioned);

            //备注保存完成事件
            this._listOn.DownloadClicked += new EventHandler<OnDownloadActionArgs>(this.DownloadClick);

            //准备起动事件
            this._bottomOn._viewHardStatus.ReadyChanged += new EventHandler<OnReadyActionArgs>(this.ReadyChanged);

            //列表窗口右侧样品信息窗口中更新采集方法事件
            this._listOn.UpdateClicked += new EventHandler<OnChannelUpdateArgs>(listOn_UpdateClicked);


            //创建申请走基线的样品列表
            base._arrApplyRunBase = new ArrayList();

            //创建走基线的样品列表
            base._arrRunBase = new ArrayList();

            //创建自动申请启动列表
            base._arrApplyRun = new ArrayList();

            //创建运行列表
            base._arrRunning = new ArrayList();

            //创建停止列表
            base._arrApplyStop = new ArrayList();

            //创建申请启动线程
            this._applyThread = new Thread(ApplyRunThread);
            this._applyThread.Name = "ApplyRunThread";
            this._applyThread.Start();

        }

        #endregion


        #region 方法

        /// <summary>
        /// 改变各个page改变大小
        /// </summary>
        public override void PageResize()
        {
            this._listOn.UserResize();
            this._bottomOn.PageResize();
        }

        /// <summary>
        /// 设置管道名
        /// </summary>
        /// <param name="lf"></param>
        /// <param name="pipeFullName"></param>
        public override void SetPipeName(ChannelID lf, string pipeFullName)
        {
            this._bottomOn.SetPipeName(lf, pipeFullName);
        }

        /// <summary>
        /// 创建显示引擎
        /// </summary>
        /// <param name="lf"></param>
        /// <param name="user"></param>
        /// <param name="pipe"></param>
        public override void CreateLayer(ChannelID lf, UserType user, CastPipe pipe)
        {
            this._bottomOn.CreateLayer(lf, user, pipe);

            //显示实时电压更新事件
            switch (General.ObjectLink)
            {
                case General.LinkObject.SimuGc:
                    switch (lf)
                    {
                        case ChannelID.B:
                            this._bottomOn._viewGraph.GetGraphBiz()._bizTransSimu(ChannelID.B).AutoSlopeActioned 
                                += new EventHandler<OnAutoSlopeActionArgs>(this.AutoSlopeActioned);
                            this._bottomOn._viewGraph.GetGraphBiz()._bizTransSimu(ChannelID.B).ShowVoltageActioned 
                                += new EventHandler<OnVoltageActionArgs>(this.ShowVoltageActioned);
                            break;
                    }

                    break;

                case General.LinkObject.SmallBoard:
                case General.LinkObject.BigBoard:
                case General.LinkObject.ChannelGas:
                    switch (lf)
                    {
                        case ChannelID.A:
                            CommPort.Instance.GetTransBiz(IdChannel.Tcd1).ShowVoltageActioned 
                                += new EventHandler<OnVoltageActionArgs>(this.ShowVoltageActioned);
                            CommPort.Instance.GetTransBiz(IdChannel.Tcd1).AutoSlopeActioned 
                                += new EventHandler<OnAutoSlopeActionArgs>(this.AutoSlopeActioned);
                            CommPort.Instance.GetTransBiz(IdChannel.Tcd1).AutoStopActioned 
                                += new EventHandler<OnAutoStopActionArgs>(this.AutoStopActioned);
                            break;

                        case ChannelID.B:
                            CommPort.Instance.GetTransBiz(IdChannel.Fid1).ShowVoltageActioned 
                                += new EventHandler<OnVoltageActionArgs>(this.ShowVoltageActioned);
                            CommPort.Instance.GetTransBiz(IdChannel.Fid1).AutoSlopeActioned 
                                += new EventHandler<OnAutoSlopeActionArgs>(this.AutoSlopeActioned);
                            CommPort.Instance.GetTransBiz(IdChannel.Fid1).AutoStopActioned 
                                += new EventHandler<OnAutoStopActionArgs>(this.AutoStopActioned);
                            break;
                        
                        case ChannelID.C:
                            CommPort.Instance.GetTransBiz(IdChannel.Tcd2).ShowVoltageActioned 
                                += new EventHandler<OnVoltageActionArgs>(this.ShowVoltageActioned);
                            CommPort.Instance.GetTransBiz(IdChannel.Tcd2).AutoSlopeActioned 
                                += new EventHandler<OnAutoSlopeActionArgs>(this.AutoSlopeActioned);
                            CommPort.Instance.GetTransBiz(IdChannel.Tcd2).AutoStopActioned 
                                += new EventHandler<OnAutoStopActionArgs>(this.AutoStopActioned);
                            break;


                        case ChannelID.D:
                            CommPort.Instance.GetTransBiz(IdChannel.Fid2).ShowVoltageActioned 
                                += new EventHandler<OnVoltageActionArgs>(this.ShowVoltageActioned);
                            CommPort.Instance.GetTransBiz(IdChannel.Fid2).AutoSlopeActioned 
                                += new EventHandler<OnAutoSlopeActionArgs>(this.AutoSlopeActioned);
                            CommPort.Instance.GetTransBiz(IdChannel.Fid2).AutoStopActioned 
                                += new EventHandler<OnAutoStopActionArgs>(this.AutoStopActioned);

                            break;
                    }

                    break;
            }
        }

        /// <summary>
        /// 启动采样
        /// </summary>
        /// <param name="channelCmd"></param>
        /// <param name="dtoPara"></param>
        public override void StartSample(ChannelCmd channelCmd, ParaDto dtoPara)
        {
            this._bottomOn.StartSample(channelCmd, dtoPara);
        }

        /// <summary>
        /// 停止采样
        /// </summary>
        /// <param name="channelCmd"></param>
        public override void StopSample(ChannelCmd channelCmd)
        {
            this._bottomOn.StopSample(channelCmd);
        }

        /// <summary>
        /// 程序关闭,停止采集
        /// </summary>
        /// <param name="reason"></param>
        public override void StopSample(StopSampleReason reason)
        {
            ParaDto dto = null;

            switch (General.ObjectLink)
            {
                case General.LinkObject.BigBoard:
                    break;
            }

            while (this._arrRunBase.Count > 0)
            {
                dto = (ParaDto)this._arrRunBase[0];
                this.ApplyStopSample(dto);
                Thread.Sleep(100);
            }

            while (this._arrRunning.Count > 0)
            {
                dto = (ParaDto)this._arrRunning[0];
                this.ApplyStopSample(dto);
                Thread.Sleep(100);
            }

            switch (reason)
            {
                case StopSampleReason.ShutDown:
                    this._applyThread.Abort();
                    this._applyThread = null;
                    break;
                case StopSampleReason.SwitchPort:
                    break;
            }

            this._bottomOn.StopSample(reason);

        }

        /// <summary>
        /// 申请启动线程
        /// </summary>
        private void ApplyRunThread()
        {
            while(true)
            {
                if (0 < base._arrApplyRunBase.Count)
                {
                    //走基线
                    ParaDto dto = (ParaDto)base._arrApplyRunBase[0];

                    // 匿名代理
                    CrossThreadOperationControl CrossApplyAutoRunBase = delegate()
                    {
                        this.ApplyRunBase(dto);
                        base._arrApplyRunBase.Remove(dto);
                    };
                    if (this.InvokeRequired)
                    {
                        this.Invoke(CrossApplyAutoRunBase);
                    }

                }
                Thread.Sleep(100);

                if (0 < base._arrApplyRun.Count)
                {
                    //运行
                    ParaDto dto = (ParaDto)base._arrApplyRun[0];

                    // 匿名代理
                    CrossThreadOperationControl CrossApplyAutoRun = delegate()
                    {
                        this.ApplyRunSample(dto);
                        base._arrApplyRun.Remove(dto);
                    };
                    if (this.InvokeRequired)
                    {
                        this.Invoke(CrossApplyAutoRun);
                    }

                    RunDone = true;
                }
                Thread.Sleep(100);

                if (0 < this._arrApplyStop.Count)
                {
                    //停止
                    ParaDto dto = (ParaDto)base._arrApplyStop[0];

                    // 匿名代理
                    CrossThreadOperationControl CrossApplyAutoStop = delegate()
                    {
                        this.ApplyStopSample(dto);
                        base._arrApplyStop.Remove(dto);
                    };
                    if (this.InvokeRequired)
                    {
                        this.Invoke(CrossApplyAutoStop);
                    }

                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 更新检测器状态
        /// </summary>
        public override void UpdateDetectorLabel()
        {
            this._bottomOn._viewGraph.UpdateDetectorLabel(IdChannel.Tcd1);
            this._bottomOn._viewGraph.UpdateDetectorLabel(IdChannel.Fid1);
            this._bottomOn._viewGraph.UpdateDetectorLabel(IdChannel.Tcd2);
            this._bottomOn._viewGraph.UpdateDetectorLabel(IdChannel.Fid2);
        }

        /// <summary>
        /// 大板卡接收到串口的停止命令
        /// </summary>
        private void GcStop()
        {

            ArrayList arrTemp = new ArrayList();

            foreach (ParaDto dto in this._arrRunning)
            {
                this._arrApplyStop.Add(dto);
                arrTemp.Add(dto);
            }

            //foreach (ParaDto dto in arrTemp)
            //{
            //    this._arrRunning.Remove(dto);
            //}
        }

        /// <summary>
        /// 大板卡接收到串口的启动命令
        /// </summary>
        private void GcStart()
        {
            ArrayList arrTemp = new ArrayList();

            //没有在LED准备好的状态，返回
            if (!this._bottomOn._viewHardStatus.isReady())
            {
                return;
            }

            foreach (ParaDto dto in this._arrRunBase)
            {
                if (dto.ChannelID.Equals(IdChannel.Tcd1) && GcChannel.Tcd1)
                {
                    this._arrApplyRun.Add(dto);
                    arrTemp.Add(dto);
                }
                if (dto.ChannelID.Equals(IdChannel.Fid1) && GcChannel.Fid1)
                {
                    this._arrApplyRun.Add(dto);
                    arrTemp.Add(dto);
                } 
                if (dto.ChannelID.Equals(IdChannel.Tcd2) && GcChannel.Tcd2)
                {
                    this._arrApplyRun.Add(dto);
                    arrTemp.Add(dto);
                }

                if (dto.ChannelID.Equals(IdChannel.Fid2) && GcChannel.Fid2)
                {
                    this._arrApplyRun.Add(dto);
                    arrTemp.Add(dto);
                }
            }

            //foreach (ParaDto dto in arrTemp)
            //{
            //    this._arrRunBase.Remove(dto);
            //}
        }

        /// <summary>
        /// 申请停止当前样品采集
        /// </summary>
        /// <param name="dto"></param>
        private void ApplyStopSample(ParaDto dto)
        {
            //样品检查
            if (null == dto || "".Equals(dto.SampleID) || "".Equals(dto.ChannelID))
            {
                MessageBox.Show("没有选择样品！", "提示");
                return;
            }

            switch (dto.ChannelID)
            {
                case IdChannel.Tcd1:
                    this.StopChannel(dto, ChannelCmd.StopTcd1, ChannelCmd.StopBaseTcd1, ChannelID.A);
                    break;

                case IdChannel.Fid1:
                    this.StopChannel(dto, ChannelCmd.StopFid1, ChannelCmd.StopBaseFid1, ChannelID.B);
                    break;

                case IdChannel.Tcd2:
                    this.StopChannel(dto, ChannelCmd.StopTcd2, ChannelCmd.StopBaseTcd2, ChannelID.C);
                    break;

                case IdChannel.Fid2:
                    this.StopChannel(dto, ChannelCmd.StopFid2, ChannelCmd.StopBaseFid2, ChannelID.D);
                    break;
            }
        }

        /// <summary>
        /// 停止某个通道
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="stopCmd"></param>
        /// <param name="stopBaseCmd"></param>
        /// <param name="id"></param>
        private void StopChannel(ParaDto dto, ChannelCmd stopCmd, ChannelCmd stopBaseCmd, ChannelID id)
        {
            switch (CommPort.Instance.GetRealStatus(dto.ChannelID))
            {
                case RealStatus.Ready:
      //              MessageBox.Show(dto.ChannelID + "通道已经停止！", "提示");
                   

       //             break;

                case RealStatus.SimuCollecting:
                case RealStatus.RealCollecting:

                    this.RemoveInRunBase(dto);
                    if (!this.IsInRunningList(dto))
                    {
                        MessageBox.Show("选择的这个样品不在列表！", "提示");
                        //return;
                    }

                    this._listOn.StopCheck(dto.SampleID, dto.RegisterTime);
                    this._bottomOn.StopSample( stopCmd );
                    dto.SampleStatus = StatusSample.Collected;
                    Thread.Sleep(20);
                    this.RemoveInRunning(dto);
                    this._bottomOn._viewGraph.SetChannelText(id, 
                        CommPort.Instance.GetRealStatus( dto.ChannelID ), dto.SampleName);

                    break;

                case RealStatus.ManulStop:
                case RealStatus.StopBase:
                    MessageBox.Show(dto.ChannelID + "通道正在停止中，请启动或停止其它通道！", "提示");
                    break;

                case RealStatus.ManulStart:
                    MessageBox.Show(dto.ChannelID + "通道正在启动中，请启动或停止其它通道！", "提示");
                    break;

                case RealStatus.RunBase:
                    if (!this.IsInRunbaseList(dto))
                    {
                        MessageBox.Show("选择的这个样品不在列表！", "提示");
                        //return;
                    }
                    this._bottomOn.StopSample( stopBaseCmd );
                    Thread.Sleep(20);
                    this.RemoveInRunBase(dto);
                    this._bottomOn._viewGraph.SetChannelText(id, 
                        CommPort.Instance.GetRealStatus( dto.ChannelID ), dto.SampleName);

                    break;
            }
        }

        /// <summary>
        /// 申请启动当前样品采集
        /// </summary>
        /// <param name="dto"></param>
        private void ApplyRunSample(ParaDto dto)
        {
            //样品检查
            if (null == dto || "".Equals(dto.SampleID) || "".Equals(dto.ChannelID))
            {
                MessageBox.Show("没有选择样品！", "提示");
                return;
            }

            //是否运行基线检查
            //if (!this.IsInRunbaseList(dto))
            //{
            //    MessageBox.Show("该样品没有运行基线！", "提示");
            //    return;
            //}
            switch (dto.ChannelID)
            {
                case IdChannel.Tcd1:
                    this.RunChannel(dto, ChannelCmd.StartTcd1, ChannelID.A);
                    break;

                case IdChannel.Fid1:
                    this.RunChannel(dto, ChannelCmd.StartFid1, ChannelID.B);
                    break;
                
                case IdChannel.Tcd2:
                    this.RunChannel(dto, ChannelCmd.StartTcd2, ChannelID.C);
                    break;

                case IdChannel.Fid2:
                    this.RunChannel(dto, ChannelCmd.StartFid2, ChannelID.D);
                    break;
            }
        }

        /// <summary>
        /// 运行某个通道
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="startCmd"></param>
        /// <param name="id"></param>
        private void RunChannel(ParaDto dto, ChannelCmd startCmd, ChannelID id)
        {
            switch (CommPort.Instance.GetRealStatus(dto.ChannelID))
            {

                case RealStatus.SimuCollecting:
                    MessageBox.Show(dto.ChannelID + "通道正在模拟采集，请启动其它通道或停止！", "提示");
                    break;

                case RealStatus.RealCollecting:
                    //MessageBox.Show(dto.ChannelID + "通道正在采集，请启动其它通道或停止！", "提示");
                    break;

                case RealStatus.StopBase:
                    //MessageBox.Show(dto.ChannelID + "通道正在停止中，请启动或停止其它通道！", "提示");
                    break;

                case RealStatus.ManulStart:
                    //MessageBox.Show(dto.ChannelID + "通道正在启动中，请启动或停止其它通道！", "提示");
                    break;

                case RealStatus.Ready:
                //MessageBox.Show(dto.ChannelID + "通道请走基线！", "提示");
                //break;
                case RealStatus.RunBase:
                case RealStatus.ManulStop:

                    this.RemoveInRunBase(dto);

                    if (StatusSample.Collected.Equals(dto.SampleStatus) ||
                        StatusSample.Analyzed.Equals(dto.SampleStatus))
                    {
                        //已收集或已分析过
                        this.InsertPara(ref dto);//更新时间
                        Thread.Sleep(20);
                        this._bottomOn.StartSample(startCmd, dto);
                        Thread.Sleep(20);
                        this._listOn.StartMark(ChannelAction.Start, dto, true);
                    }
                    else
                    {
                        this._bottomOn.StartSample(startCmd, dto);
                        Thread.Sleep(20);
                        this._listOn.StartMark(ChannelAction.Start, dto, false);
                    }
                    this.AddParaToRunningList(dto);//添加到正在运行列表
                    this._bottomOn._viewGraph.SetChannelText(id, 
                        CommPort.Instance.GetRealStatus(dto.ChannelID), dto.SampleName);
                    break;

            }
        }

        /// <summary>
        /// 从基线列表中删除
        /// </summary>
        /// <param name="dtoPara"></param>
        private void RemoveInRunBase(ParaDto dtoPara)
        {
            foreach (ParaDto dto in this._arrRunBase)
            {
                if (dto.SampleID.Equals(dtoPara.SampleID) && dto.RegisterTime.Equals(dtoPara.RegisterTime))
                {
                    this._arrRunBase.Remove(dto);
                    break;
                }
            }
        }

        /// <summary>
        /// 从运行列表中删除
        /// </summary>
        /// <param name="dtoPara"></param>
        private void RemoveInRunning(ParaDto dtoPara)
        {
            foreach (ParaDto dto in this._arrRunning)
            {
                if (dto.SampleID.Equals(dtoPara.SampleID) && dto.RegisterTime.Equals(dtoPara.RegisterTime))
                {
                    this._arrRunning.Remove(dto);
                    break;
                }
            }
        }

        /// <summary>
        ///该样品是否在运行基线的队列
        /// </summary>
        /// <param name="dtoPara"></param>
        /// <returns></returns>
        private bool IsInRunbaseList(ParaDto dtoPara)
        {
            foreach (ParaDto dto in this._arrRunBase)
            {
                if (dto.SampleID.Equals(dtoPara.SampleID) && dto.RegisterTime.Equals(dtoPara.RegisterTime))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 添加样品到正在运行的列表
        /// </summary>
        /// <param name="dto"></param>
        private void AddParaToRunningList(ParaDto dto)
        {
            this._arrRunning.Add(dto);
        }

        /// <summary>
        ///该样品是否在正在运行的列表
        /// </summary>
        /// <param name="dtoPara"></param>
        /// <returns></returns>
        private bool IsInRunningList(ParaDto dtoPara)
        {
            foreach (ParaDto dto in this._arrRunning)
            {
                if (dto.SampleID.Equals(dtoPara.SampleID) && dto.RegisterTime.Equals(dtoPara.RegisterTime))
                { 
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        ///该样品是否在申请运行的队列
        /// </summary>
        /// <param name="dtoPara"></param>
        /// <returns></returns>
        private bool IsInApplyRunnList(ParaDto dtoPara)
        {
            foreach (ParaDto dto in this._arrApplyRun)
            {
                if (dto.SampleID.Equals(dtoPara.SampleID) && dto.RegisterTime.Equals(dtoPara.RegisterTime))
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        ///该样品是否在申请基线的队列
        /// </summary>
        /// <param name="dtoPara"></param>
        /// <returns></returns>
        private bool IsInApplyBaseList(ParaDto dtoPara)
        {
            foreach (ParaDto dto in this._arrApplyRunBase)
            {
                if (dto.SampleID.Equals(dtoPara.SampleID) && dto.RegisterTime.Equals(dtoPara.RegisterTime))
                {
                    return true;
                }
            }
            return false;
        }

        
        /// <summary>
        /// 插入相同的样品ID,不同的注册时间
        /// </summary>
        /// <param name="dto"></param>
        private void InsertPara(ref ParaDto dto)
        {
            ParaBiz bizPara = new ParaBiz();
            RelationBiz bizRelation = new RelationBiz();
            RelationDto dtoRelation = new RelationDto();

            //插入关系
            SolutionBiz bizSolu = new SolutionBiz();
            SolutionDto dtoSolu = new SolutionDto();

            //自动命名
            if (General.AutoName)
            {
                int count = bizPara.LoadPickupPara(dto);
                int len = dto.SampleName.Length;
                int index = dto.SampleName.LastIndexOf('_');

                if (-1 != index)
                {
                    String temp = dto.SampleName.Substring(index + 1);
                    if (CastString.IsNumber(temp))
                    {
                        dto.SampleName = String.Format("{0}{1:D3}", dto.SampleName.Substring(0, index + 1), count + 1);
                    }
                    else
                    {
                        dto.SampleName = String.Format("{0}_{1:D3}", dto.SampleName, count + 1);
                    }
                }
                else
                {
                    dto.SampleName = String.Format("{0}_{1:D3}", dto.SampleName, count + 1);
                }
            }

            dtoRelation.SampleID = dto.SampleID;
            dtoRelation.RegisterTime = dto.RegisterTime;
            dtoRelation.SolutionID = Convert.ToInt32(bizSolu.GetSolutionID(dtoRelation));

            dto.RegisterTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            dto.UserID = "cai";
            dto.PathData = "db\\" + DateTime.Now.ToString("yyyyMM") + "\\"
                + "通道" + dto.ChannelID + "_" + dto.RegisterTime + DefaultItem.Db_Extention;
            dto.Remark = "";
            dto.SampleStatus = StatusSample.Collecting;
            dto.StopTime = 10000;
            bool bRet = bizPara.InsertPara(dto);

            dtoRelation.RegisterTime = dto.RegisterTime;

            bRet = bizRelation.InsertRelation(dtoRelation);
        }

        /// <summary>
        /// 申请开始走基线
        /// </summary>
        /// <param name="dto"></param>
        private void ApplyRunBase(ParaDto dto)
        {
            //样品检查
            if (null == dto || "".Equals(dto.SampleID) || "".Equals(dto.ChannelID))
            {
                MessageBox.Show("没有选择样品！", "提示");
                return;
            }


            switch (dto.ChannelID)
            {
                case IdChannel.Tcd1:
                    this.RunBaseChannel(dto, ChannelCmd.RunBaseTcd1, ChannelID.A);
                    break;

                case IdChannel.Fid1:
                    this.RunBaseChannel(dto, ChannelCmd.RunBaseFid1, ChannelID.B);
                    break;
                
                case IdChannel.Tcd2:
                    this.RunBaseChannel(dto, ChannelCmd.RunBaseTcd2, ChannelID.C);
                    break;

                case IdChannel.Fid2:
                    this.RunBaseChannel(dto, ChannelCmd.RunBaseFid2, ChannelID.D);
                    break;
            }
        }

        /// <summary>
        /// 运行某个通道基线
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="runBaseCmd"></param>
        /// <param name="id"></param>
        private void RunBaseChannel(ParaDto dto, ChannelCmd runBaseCmd, ChannelID id)
        {
            switch (CommPort.Instance.GetRealStatus(dto.ChannelID))
            {
                case RealStatus.Ready:
                    this._bottomOn.RunBaseSample(id, dto);
                    this.AddParaToRunbaseList(dto);
                    this._bottomOn._viewGraph.SetChannelText(id,
                        CommPort.Instance.GetRealStatus(dto.ChannelID), dto.SampleName);
                    break;

                case RealStatus.SimuCollecting:
                    MessageBox.Show(dto.ChannelID + "通道正在模拟采集！", "提示");
                    break;

                case RealStatus.RealCollecting:
                    //MessageBox.Show(dto.ChannelID + "通道正在采集！", "提示");
                    break;

                case RealStatus.ManulStop:
                case RealStatus.StopBase:
                    //MessageBox.Show(dto.ChannelID + "通道正在停止中！", "提示");
                    this._bottomOn.RunBaseSample(id, dto);
                    this.AddParaToRunbaseList(dto);
                    this._bottomOn._viewGraph.SetChannelText(id,
                        CommPort.Instance.GetRealStatus(dto.ChannelID), dto.SampleName);
                    break;

                case RealStatus.ManulStart:
                    //MessageBox.Show(dto.ChannelID + "通道正在启动中！", "提示");
                    break;

                case RealStatus.RunBase:
                    //MessageBox.Show(dto.ChannelID + "通道正在走基线！", "提示");
                    break;
            }
        }

        /// <summary>
        /// 向列表中追加走基线的样品
        /// </summary>
        /// <param name="dtopara"></param>
        private void AddParaToRunbaseList(ParaDto dtopara)
        {
            ParaDto dto = new ParaDto();
            dto.ChannelID = dtopara.ChannelID;
            dto.CollectTime = dtopara.CollectTime;
            dto.InnerWeight = dtopara.InnerWeight;
            dto.PathData = dtopara.PathData;
            dto.RegisterTime = dtopara.RegisterTime;
            dto.Remark = dtopara.Remark;
            dto.SampleID = dtopara.SampleID;
            dto.SampleName = dtopara.SampleName;
            dto.SampleStatus = dtopara.SampleStatus;
            dto.SampleType = dtopara.SampleType;
            dto.SampleWeight = dtopara.SampleWeight;
            dto.StopTime = dtopara.StopTime;
            dto.UserID = dtopara.UserID;

            this._arrRunBase.Add(dto);
        }

        /// <summary>
        /// 通道的显示配置改变，自动更新画面
        /// </summary>
        public override void OcxShowChange()
        {
            this._bottomOn.OcxShowChange();
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
        private void listOn_SampleChanged(object sender, OnSampleChangeArgs e)
        {
            //this._bottomOn.LoadPara((ParaDto)e._var);
        }

        /// <summary>
        /// 控制窗口发送命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listOn_ChannelActioned(object sender, OnChannelActionArgs e)
        {
            ChannelAction ca = (ChannelAction)e._var;

            switch (ca)
            {
                case ChannelAction.RunBase:
                   if ((!(this.IsInApplyBaseList(e._dtoPara)))&&(!(this.IsInRunbaseList(e._dtoPara)))

                       &&(!(this.IsInApplyRunnList(e._dtoPara))) && (!(this.IsInRunningList(e._dtoPara))))
                       {
                           base._arrApplyRunBase.Add(e._dtoPara); 
                        } 
                   break;
                case ChannelAction.Start:
                   if ((!(this.IsInApplyRunnList(e._dtoPara))) && (!(this.IsInRunningList(e._dtoPara))))
                      {
                           base._arrApplyRun.Add(e._dtoPara);
                      }
                    break;

                case ChannelAction.Stop:
                    base._arrApplyStop.Add(e._dtoPara);
                    break;
            }
        }

        /// <summary>
        /// 接收到串口的启动命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void SmallBoard_StartAutoSample(object sender, OnStartArgs e)
        {

            foreach (ParaDto dto in this._arrRunBase)
            {
                if (dto.ChannelID.Equals(e._channelID))
                {
                    this._arrApplyRun.Add(dto);
                    break;
                }
            }
        }

        /// <summary>
        /// 自动斜率事件
        /// </summary>
        private void AutoSlopeActioned(object sender, OnAutoSlopeActionArgs e)
        {
            //this._bottomOn._viewConfig.SetAutoSlopeText(e._idChannel, e._autoSlope);
            //this._bottomOn._viewGraph.SetAutoSlopeText(e._idChannel, e._autoSlope);
        }

        /// <summary>
        /// 下载事件
        /// </summary>
        private void DownloadClick(object sender, OnDownloadActionArgs e)
        {
            this._bottomOn.DownloadAntiMethod(e._dtoPara, e._type);
        }

        /// <summary>
        /// 显示实时电压事件
        /// </summary>
        private void ShowVoltageActioned(object sender, OnVoltageActionArgs e)
        {
            this._bottomOn._viewGraph.SetVoltageText(e._idChannel, e._moment, e._voltage);
        }

        /// <summary>
        /// 自动停止采集事件
        /// </summary>
        private void AutoStopActioned(object sender, OnAutoStopActionArgs e)
        {
            ParaDto dto = new ParaDto();

            this._listOn.StopCheck(e._sampleID, e._registerTime);
            this._listOn.UpdateParaToCollected(e._sampleID, e._registerTime);
            dto.SampleID = e._sampleID;
            dto.RegisterTime = e._registerTime;

            this._bottomOn._viewGraph.SetChannelText(e._channelID, RealStatus.Ready, e._sampleName);
        }

        /// <summary>
        /// 大板卡接收到串口的启动停止命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void BigBoard_GcCommand(object sender, OnBigBoardCmdArgs e)
        {
            switch (e._cmd)
            {
                case GcCommand.GcStart:
                    this.GcStart();
                    break;
                case GcCommand.GcStop:
                    this.GcStop();
                    break;
            }
        }

        /// <summary>
        /// 准备起动事件
        /// </summary>
        private void ReadyChanged(object sender, OnReadyActionArgs e)
        {
            this._listOn.ReadyChanged( e._isReady);
        }

        /// <summary>
        /// 某通道的采集方法更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listOn_UpdateClicked(object sender, OnChannelUpdateArgs e)
        {
            ParaDto dto = (ParaDto)e._dtoPara;
            this._bottomOn.UpdateTransCollection(dto);
        }

        #endregion


    }
}
