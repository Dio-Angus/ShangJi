/*-----------------------------------------------------------------------------
//  FILE NAME       : OnList.cs
//  FUNCTION        : 在线样品列表窗体
//  AUTHOR          : 李锋(2009/05/24)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoBll.bll;
using ChromatoTool.ini;
using System.Collections;
using System.Threading;

namespace ChromatoCore.On
{

    /// <summary>
    /// 在线样品列表窗体
    /// </summary>
    public partial class OnList : UserControl
    {


        #region 变量

        /// <summary>
        /// 样品改变事件代理
        /// </summary>
        public event EventHandler<OnSampleChangeArgs> SampleChanged;

        /// <summary>
        /// 样品
        /// </summary>
        private ParaDto _dtoPara = null;

        /// <summary>
        /// 列表数据集合
        /// </summary>
        private DataSet _dsSample = null;

        /// <summary>
        /// 正在样品运行列表（ParaKeyDto集合体）
        /// </summary>
        private ArrayList _arrRun = null;

        /// <summary>
        /// 样品逻辑
        /// </summary>
        private ParaBiz _bizPara = null;

        /// <summary>
        /// 通道动作的代理
        /// </summary>
        public event EventHandler<OnChannelActionArgs> ChannelActioned = null;//EventHandler<OnChannelActionArgs>有返回值的委托类型，这里用event定义了一个事件

        //事件与委托，只有声明委托和使用委托或事件时需要加括号注明参数类型，其他时候只需要名字：public event void 函数名；函数名+=函数名；函数名-=函数名

        /// <summary> 
        /// 跨线程控件代理
        /// </summary> 
        private delegate void CrossThreadOperationControl();

        /// <summary>
        /// 下载事件
        /// </summary>
        public event EventHandler<OnDownloadActionArgs> DownloadClicked = null;

        /// <summary>
        /// 更新采集方法事件的代理
        /// </summary>
        public event EventHandler<OnChannelUpdateArgs> UpdateClicked = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OnList()
        {
            InitializeComponent();
            LoadUi();
            LoadEvent();

            /*/测试
            Thread.Sleep(1000);
            this.tsBtnStart.PerformClick();
            Thread.Sleep(1000);
            if (OnGroup.RunDone)
            {
                this.tsBtnStart.PerformClick();
            }*/

        }

        /// <summary>
        /// 装事件
        /// </summary>
        private void LoadEvent()
        {
            this.dgvSampleInfo.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvSampleInfo_CellDoubleClick);
            this.dgvSampleInfo.CellClick += new DataGridViewCellEventHandler(this.dgvSampleInfo_CellClick);
            this.dgvSampleInfo.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvSampleInfo_ColumnHeaderMouseClick);
            this.dgvSampleInfo.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvSampleInfo_DataBindingComplete);
            this.dgvSampleInfo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvSampleInfo_KeyUp);

            this.tsBtnRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
            this.tsBtnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.tsBtnStop.Click += new System.EventHandler(this.btnStop_Click);
            this.tsBtnBaseline.Click += new System.EventHandler(this.btnCollectBaseLine_Click);

            this.tsFid1.Click += new System.EventHandler(this.tsFid1_Click);
            this.tsFid2.Click += new System.EventHandler(this.tsFid2_Click);
            this.tsTcd1.Click += new System.EventHandler(this.tsTcd1_Click);
            this.tsTcd2.Click += new System.EventHandler(this.tsTcd2_Click);
            this.tsAux.Click += new System.EventHandler(this.tsAux_Click);
            this.tsInj1.Click += new System.EventHandler(this.tsInj1_Click);
            this.tsInj2.Click += new System.EventHandler(this.tsInj2_Click);
            this.tsInj3.Click += new System.EventHandler(this.tsInj3_Click);
            this.tsColumnPara.Click += new System.EventHandler(this.tsColumnPara_Click);

            this.viewConfig._viewer._btnUpdate.Click += new System.EventHandler(this.viewConfig_Click);

            this._arrRun = new ArrayList();
            //this.splitterGraph.SplitterMoved += new SplitterEventHandler(this.splitterGraph_SplitterMoved);

            this.cbxQuery.SelectedIndexChanged += new System.EventHandler(this.cbxQuery_SelectedIndexChanged);
        }

        /// <summary>
        /// 装界面
        /// </summary>
        private void LoadUi()
        {
            this._bizPara = new ParaBiz();
            this.cbxQuery.SelectedIndex = 3;
            this.dtPickerQuery.Enabled = true;
            this.dtPickerQueryEndDay.Enabled = false;

            switch (General.ObjectLink)
            {
                case General.LinkObject.SmallBoard:
                case General.LinkObject.ChannelGas:
                //    this.tsBtnStart.Enabled = true;
                    break;
                case General.LinkObject.BigBoard:
                    this.tsBtnStart.Enabled = true;
                    break;
                case General.LinkObject.AutoChromatoGas:
                 //   this.gbQuery.Enabled = false;
                 //   this.tsSample.Enabled = false;
                 //   this.tsBtnStart.Enabled = false;
                    this.gbQuery.Enabled = true;
                    this.tsSample.Enabled = true;
                    this.tsBtnStart.Enabled = true;
                    break;
            }

            this.LoadList();

            this.dgvSampleInfo.BackgroundColor = Color.FromArgb(General.DgvBackColor);
            this.OnList_Load(null, null);
        }

        /// <summary>
        /// 装载列表
        /// </summary>
        private void LoadList()
        {
            DateTime dt = DateTime.Now;
            TimeSpan waitTime = new TimeSpan(14, 0, 0, 0, 0);

            DateTime dtStart = dt - waitTime;
            DataSet ds = null;
            TimeSpan oneDay = new TimeSpan(1, 0, 0, 0, 0);

            switch ((QueryChoise)this.cbxQuery.SelectedIndex)
            {
                case QueryChoise.CustomDay:
                    ds = this._bizPara.LoadPara(StatusSample.Registered, this.dtPickerQuery.Value.ToString("yyyyMMdd"),
                       (this.dtPickerQuery.Value + oneDay).ToString("yyyyMMdd"));
                    break;

                case QueryChoise.CustomStartDay:
                    ds = this._bizPara.LoadPara(StatusSample.Registered, this.dtPickerQuery.Value.ToString("yyyyMMdd"),
                        (this.dtPickerQueryEndDay.Value + oneDay).ToString("yyyyMMdd"));
                    break;

                case QueryChoise.All:
                    ds = this._bizPara.LoadPara(StatusSample.Registered);
                    break;

                case QueryChoise.RecentTwoWeeks:
                    ds = this._bizPara.LoadPara(StatusSample.Registered, dtStart.ToString("yyyyMMddHHmmss"));
                    break;
            }

            //空检查
            if (null == ds || 0 == ds.Tables.Count || 0 == ds.Tables[0].Rows.Count)
            {
                this.tsBtnBaseline.Enabled = false;
                this.tsBtnStart.Enabled = false;
                this.tsBtnStop.Enabled = false;

                if (0 < this.dgvSampleInfo.Rows.Count)
                {
                    this._dsSample.Tables[0].Rows.Clear();
                    this.dgvSampleInfo.DataSource = this._dsSample.Tables[0];
                }
                return;
            }

            this.tsBtnBaseline.Enabled = true;
            this.tsBtnStart.Enabled = true;
            this.tsBtnStop.Enabled = true;

            this._dsSample = ds;
            this.dgvSampleInfo.DataSource = this._dsSample.Tables[0];

            switch (General.ObjectLink)
            {
                case General.LinkObject.SmallBoard:
                case General.LinkObject.ChannelGas:
                    break;
                case General.LinkObject.BigBoard:
                    break;
                case General.LinkObject.AutoChromatoGas:
                    //this.gbQuery.Enabled = false;
                    //this.tsSample.Enabled = false;
                    break;
            }
        }

        #endregion


        #region 方法

        /// <summary>
        /// 改变面板大小
        /// </summary>
        public void UserResize()
        {
            //this.dgvSampleInfo.Width = this.Width - 3;
            //this.dgvSampleInfo.Height = this.Height - this.lblOffline.Height - 15;
        }

        /// <summary>
        /// 更新选中行
        /// </summary>
        private void UpdateSelectedRow()
        {
            if (null == this.dgvSampleInfo.CurrentRow)
            {
                MessageBox.Show("没有样品！", "警告");
                return;
            }

            for (int i = 0; i < this._dsSample.Tables[0].Rows.Count; i++)
            {
                if (this.dgvSampleInfo["SampleID", i].Value.ToString().Equals(this._dtoPara.SampleID) &&
                    this.dgvSampleInfo["RegisterTime", i].Value.ToString().Equals(this._dtoPara.RegisterTime))
                {
                    // clear datagridview selection
                    this.dgvSampleInfo.ClearSelection();
                    // select new row
                    this.dgvSampleInfo["SampleName", i].Selected = true;

                    break;
                }
            }
        }

        /// <summary>
        /// 设定正在采集样品的颜色
        /// </summary>
        /// <param name="ca"></param>
        /// <param name="dtoPara"></param>
        /// <param name="isFresh"></param>
        public void StartMark(ChannelAction ca, ParaDto dtoPara, bool isFresh)
        {
            if (null == dtoPara.SampleID || "".Equals(dtoPara.SampleID))
            {
                return;
            }

            if (isFresh)
            {
                this.LoadUi();
                this._dtoPara = dtoPara;
                this.UpdateSelectedRow();
            }
            this.UpdateMark(ca, dtoPara.SampleID, dtoPara.RegisterTime);
        }

        /// <summary>
        /// 更新样品颜色
        /// </summary>
        /// <param name="ca"></param>
        /// <param name="sampleID"></param>
        /// <param name="regTime"></param>
        private void UpdateMark(ChannelAction ca, String sampleID, String regTime)
        {
            ParaKeyDto dtoKey = null;
            foreach (DataGridViewRow a in this.dgvSampleInfo.Rows)
            {
                if (a.Cells["SampleID"].Value.ToString().Equals(sampleID)
                    && a.Cells["RegisterTime"].Value.ToString().Equals(regTime))
                {
                    switch(ca)
                    {
                        case ChannelAction.Start:
                            a.Cells["SampleStatus"].Value = StatusSample.Collecting;
                            //this._bizPara.UpdateStatus(sampleID, StatusSample.Collecting);
                            dtoKey = new ParaKeyDto();
                            dtoKey.SampleID = sampleID;
                            dtoKey.RegisterTime = regTime;
                            this._arrRun.Add(dtoKey);
                            return;

                        case ChannelAction.Stop:
                            a.Cells["SampleStatus"].Value = StatusSample.Collected;
                            ParaDto dtoPara = new ParaDto();
                            dtoPara.SampleID = sampleID;
                            dtoPara.RegisterTime = regTime;
                            dtoPara.SampleStatus = StatusSample.Collected;
                            this._bizPara.UpdateStatus(dtoPara);

                            foreach (ParaKeyDto dto in this._arrRun)
                            {
                                if (dto.RegisterTime.Equals(regTime) && dto.SampleID.Equals(sampleID))
                                {
                                    this._arrRun.Remove(dto);
                                    break;
                                }
                            }
                            return;
                    }
                }
            }
        }

        /// <summary>
        /// 检查是否启动该样品
        /// </summary>
        /// <param name="sampleId"></param>
        /// <param name="regTime"></param>
        /// <returns></returns>
        public bool StopCheck(String sampleId, String regTime)
        {
            ParaKeyDto dtoKey = null;
            for (int i = 0; i < this._arrRun.Count; i++)
            {
                dtoKey = (ParaKeyDto)this._arrRun[i];
                if (dtoKey.SampleID.Equals(sampleId) && dtoKey.RegisterTime.Equals(regTime))
                {
                    this.UpdateMark(ChannelAction.Stop, sampleId, regTime);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 设置行高
        /// </summary>
        private void SetDgvCellHeight()
        {
            this.dgvSampleInfo.AllowUserToResizeRows = false;
            foreach (DataGridViewRow a in this.dgvSampleInfo.Rows)
            {
                a.Height = 15;
            }
        }

        #endregion


        #region 事件

        /// <summary>
        /// 重新装载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsRefresh_Click(object sender, EventArgs e)
        {
            if (0 == this._arrRun.Count)
            {
                this.OnList_Load(null, null);
            }
        }

        /// <summary>
        /// 右键刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnList_Load(object sender, EventArgs e)
        {
            this.LoadList();

            this._dtoPara = new ParaDto();
            if (null == this._dsSample || null == this._dsSample.Tables[0] || 0 >= this._dsSample.Tables[0].Rows.Count)
            {
                return;
            }

            //更新选中行
            DataRow cRow = this._dsSample.Tables[0].Rows[0];

            this._dtoPara.PathData = cRow["PathData"].ToString();
            this._dtoPara.ChannelID = cRow["ChannelID"].ToString();
            this._dtoPara.SampleID = cRow["sampleID"].ToString();
            this._dtoPara.SampleName = cRow["SampleName"].ToString();
            this._dtoPara.SampleStatus = cRow["SampleStatus"].ToString();

            this._dtoPara.SampleType = (TypeSample)Convert.ToInt32(cRow["SampleType"].ToString());
            this._dtoPara.StopTime = Convert.ToInt32(cRow["StopTime"].ToString());

            this._dtoPara.SampleWeight = Convert.ToInt32(cRow["SampleWeight"].ToString());
            this._dtoPara.InnerWeight = Convert.ToInt32(cRow["InnerWeight"].ToString());
            this._dtoPara.CollectTime = cRow["CollectTime"].ToString();
            this._dtoPara.RegisterTime = cRow["RegisterTime"].ToString();

            OnSampleChangeArgs eve = new OnSampleChangeArgs(this._dtoPara);
            if (SampleChanged != null)
            {
                this.SampleChanged(this, eve);
                this.viewConfig.LoadPara(this._dtoPara);
            }
        }

        /// <summary>
        /// 单击视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex)
            {
                return;
            }

            this.SendChangeEvent();
        }

        /// <summary>
        /// 通过事件发送dto
        /// </summary>
        private void SendChangeEvent()
        {
            DataGridViewRow cRow = this.dgvSampleInfo.CurrentRow;
            this._dtoPara.PathData = cRow.Cells["PathData"].Value.ToString();
            this._dtoPara.ChannelID = cRow.Cells["ChannelID"].Value.ToString();
            this._dtoPara.SampleID = cRow.Cells["sampleID"].Value.ToString();
            this._dtoPara.SampleName = cRow.Cells["SampleName"].Value.ToString();
            this._dtoPara.SampleStatus = cRow.Cells["SampleStatus"].Value.ToString();

            this._dtoPara.SampleType = (TypeSample)Convert.ToInt32(cRow.Cells["SampleType"].Value.ToString());
            this._dtoPara.StopTime = Convert.ToInt32(cRow.Cells["StopTime"].Value.ToString());

            this._dtoPara.SampleWeight = Convert.ToInt32(cRow.Cells["SampleWeight"].Value.ToString());
            this._dtoPara.InnerWeight = Convert.ToInt32(cRow.Cells["InnerWeight"].Value.ToString());
            this._dtoPara.CollectTime = cRow.Cells["CollectTime"].Value.ToString();
            this._dtoPara.RegisterTime = cRow.Cells["RegisterTime"].Value.ToString();

            OnSampleChangeArgs eve = new OnSampleChangeArgs(this._dtoPara);
            if (SampleChanged != null)
            {
                this.SampleChanged(this, eve);
                this.viewConfig.LoadPara(this._dtoPara);
            }
        }

        /// <summary>
        /// 双击视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex)
            {
                return;
            }

            this.SendChangeEvent();

            this.btnCollectBaseLine_Click(null, null);
        }

        /// <summary>
        /// 标题栏按下的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.UpdateSelectedRow();
        }

        /// <summary>
        /// 根据样品状态设定单元格颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvSampleInfo.DefaultCellStyle.BackColor = Color.FromArgb(General.DgvBackColor);
            this.SetDgvCellHeight();

            foreach (DataGridViewRow a in this.dgvSampleInfo.Rows)
            {

                switch (a.Cells["SampleStatus"].Value.ToString())
                {
                    case StatusSample.Collecting:
                        a.DefaultCellStyle.ForeColor = Color.Gray;
                        break;
                    case StatusSample.Registered:
                        a.DefaultCellStyle.ForeColor = Color.Chocolate;
                        break;
                    case StatusSample.Collected:
                        a.DefaultCellStyle.ForeColor = Color.White;
                        break;
                    case StatusSample.Analyzed:
                        a.DefaultCellStyle.ForeColor = Color.Purple;
                        break;
                }
            }
        }

        /// <summary>
        /// 右键菜单是否可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_MouseDown(object sender, MouseEventArgs e)
        {
            this.tsRefresh.Enabled = (0 < this._arrRun.Count) ? false : true;
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSampleInfo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                this.SendChangeEvent();
            }
        }

        /// <summary>
        /// 启动采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            OnGroup.RunDone = false;
            if (!this.CheckDetector())
            {
                return;
            }

            
            OnChannelActionArgs channelEve = null;

            //储存了返回参数和样本信息
            //操作参数（此处为开始，0），样本信息
            channelEve = new OnChannelActionArgs(ChannelAction.Start, this._dtoPara);

            //委托，指向了OnGroup中的listOn_ChannelActioned
            this.ChannelActioned(this, channelEve);
        }

        /// <summary>
        /// 检查是否安装了检测器
        /// </summary>
        /// <returns></returns>
        private bool CheckDetector()
        {
            switch (General.ObjectLink)
            {
                    //输出的messagebox都是没装检测器的
                case General.LinkObject.SimuGc:
                case General.LinkObject.SmallBoard:
                    if (this._dtoPara.ChannelID.Equals(IdChannel.Tcd2))
                    {
                        MessageBox.Show("Tcd2没有安装监测器,不能启动!");
                        return false;
                    }
                    if (this._dtoPara.ChannelID.Equals(IdChannel.Fid2))
                    {
                        MessageBox.Show("Fid2没有安装监测器,不能启动!");
                        return false;
                    }
                    break;
                case General.LinkObject.BigBoard:
                    if (this._dtoPara.ChannelID.Equals(IdChannel.Tcd1) && !GcChannel.Tcd1)
                    {
                        MessageBox.Show("Tcd1没有安装监测器,不能启动!");
                        return false;
                    }
                    if (this._dtoPara.ChannelID.Equals(IdChannel.Tcd2) && !GcChannel.Tcd2)
                    {
                        MessageBox.Show("Tcd2没有安装监测器,不能启动!");
                        return false;
                    }
                    if (this._dtoPara.ChannelID.Equals(IdChannel.Fid1) && !GcChannel.Fid1)
                    {
                        MessageBox.Show("Fid1没有安装监测器,不能启动!");
                        return false;
                    } if (this._dtoPara.ChannelID.Equals(IdChannel.Fid2) && !GcChannel.Fid2)
                    {
                        MessageBox.Show("Fid2没有安装监测器,不能启动!");
                        return false;
                    }
                    break;
                case General.LinkObject.ChannelGas:
                case General.LinkObject.AutoChromatoGas:
                    break;
            }
            return true;
        }

        /// <summary>
        /// 停止采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!this.CheckDetector())
            {
                return;
            }
            
            OnChannelActionArgs channelEve = null;

            channelEve = new OnChannelActionArgs(ChannelAction.Stop, this._dtoPara);
            this.ChannelActioned(this, channelEve);
        }

        /// <summary>
        /// 采集基线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCollectBaseLine_Click(object sender, EventArgs e)
        {
            if (!this.CheckDetector())
            {
                return;
            }

            OnChannelActionArgs channelEve = null;

            channelEve = new OnChannelActionArgs(ChannelAction.RunBase, this._dtoPara);
            this.ChannelActioned(this, channelEve);
        }

        /// <summary>
        /// 下载当前反控方法Fid1参数到GC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsFid1_Click(object sender, EventArgs e)
        {
            OnDownloadActionArgs eve = null;

            eve = new OnDownloadActionArgs(this._dtoPara, AntiControlType.Fid1);
            this.DownloadClicked(this, eve);
        }

        /// <summary>
        /// 下载当前反控方法Fid2参数到GC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsFid2_Click(object sender, EventArgs e)
        {
            OnDownloadActionArgs eve = null;

            eve = new OnDownloadActionArgs(this._dtoPara, AntiControlType.Fid2);
            this.DownloadClicked(this, eve);
        }

        /// <summary>
        /// 下载当前反控方法Tcd1参数到GC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsTcd1_Click(object sender, EventArgs e)
        {
            OnDownloadActionArgs eve = null;

            eve = new OnDownloadActionArgs(this._dtoPara, AntiControlType.Tcd1);
            this.DownloadClicked(this, eve);
        }

        /// <summary>
        /// 下载当前反控方法Tcd2参数到GC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsTcd2_Click(object sender, EventArgs e)
        {
            OnDownloadActionArgs eve = null;

            eve = new OnDownloadActionArgs(this._dtoPara, AntiControlType.Tcd2);
            this.DownloadClicked(this, eve);
        }

        /// <summary>
        /// 下载当前反控方法Aux参数到GC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsAux_Click(object sender, EventArgs e)
        {
            OnDownloadActionArgs eve = null;

            eve = new OnDownloadActionArgs(this._dtoPara, AntiControlType.Aux);
            this.DownloadClicked(this, eve);
        }

        /// <summary>
        /// 下载当前反控方法Inj1参数到GC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsInj1_Click(object sender, EventArgs e)
        {
            OnDownloadActionArgs eve = null;

            eve = new OnDownloadActionArgs(this._dtoPara, AntiControlType.Injecter1);
            this.DownloadClicked(this, eve);
        }

        /// <summary>
        /// 下载当前反控方法Inj2参数到GC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsInj2_Click(object sender, EventArgs e)
        {
            OnDownloadActionArgs eve = null;

            eve = new OnDownloadActionArgs(this._dtoPara, AntiControlType.Injecter2);
            this.DownloadClicked(this, eve);
        }

        /// <summary>
        /// 下载当前反控方法Inj3参数到GC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsInj3_Click(object sender, EventArgs e)
        {
            OnDownloadActionArgs eve = null;

            eve = new OnDownloadActionArgs(this._dtoPara, AntiControlType.Injecter3);
            this.DownloadClicked(this, eve);
        }

        /// <summary>
        /// 下载当前反控方法柱箱参数到GC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsColumnPara_Click(object sender, EventArgs e)
        {
            OnDownloadActionArgs eve = null;

            eve = new OnDownloadActionArgs(this._dtoPara, AntiControlType.HeatingSource);
            this.DownloadClicked(this, eve);
        }

        /// <summary>
        /// 更新样品状态为已经采集
        /// </summary>
        /// <param name="sampleID"></param>
        /// <param name="regTime"></param>
        public void UpdateParaToCollected(String sampleID, String regTime)
        {
            this._bizPara.UpdateParaToCollected(sampleID, regTime);
        }

        /// <summary>
        /// 分割条事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitterMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            //this.dgvSampleInfo.Height = this.splitContainerMain.Panel2.Height;
            //this.dgvSampleInfo.Left = this.splitContainerMain.Panel2.Left;
            //this.dgvSampleInfo.Width = this.splitterGraph.Left;

            //this..Width = this.Width;
            //this._viewHardStatus.Top = this.tbMain.Height;
            //this._viewHardStatus.Height = this.Height - this.tbMain.Height;
            //this._viewHardStatus.CtrlResize();
        }

        /// <summary>
        /// 准备起动事件
        /// </summary>
        public void ReadyChanged(bool isReady)
        {
            this.tsBtnStart.Enabled = isReady;
        }

        /// <summary>
        /// 点击了更新事件
        /// </summary>
        private void viewConfig_Click(object sender, EventArgs e)
        {
            OnChannelUpdateArgs updateEve = null;

            updateEve = new OnChannelUpdateArgs(this._dtoPara);
            this.UpdateClicked(this, updateEve);
        }

        /// <summary>
        /// 查询选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((QueryChoise)this.cbxQuery.SelectedIndex)
            {
                case QueryChoise.CustomDay:
                    this.dtPickerQuery.Enabled = true;
                    this.dtPickerQueryEndDay.Enabled = false;
                    break;

                case QueryChoise.CustomStartDay:
                    this.dtPickerQuery.Enabled = true;
                    this.dtPickerQueryEndDay.Enabled = true;
                    break;

                case QueryChoise.RecentTwoWeeks:
                case QueryChoise.All:
                    this.dtPickerQuery.Enabled = false;
                    this.dtPickerQueryEndDay.Enabled = false;
                    break;
            }
            this.OnList_Load(null, null);
        }
        #endregion


    }
}
