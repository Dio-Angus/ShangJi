/*-----------------------------------------------------------------------------
//  FILE NAME       : ChromatoFrm.cs
//  FUNCTION        : 主窗体
//  AUTHOR          : 李锋(2009/02/17)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoTool.ini;
using System.Drawing;
using ChromatoTool.log;
using ChromatoCore.tabCtrl;
using System.Reflection;
using ChromatoTool.util;
using ChromatoBll.serialCom;
using ChromatoBll.bll;
using ChromatoCore.Login;
using ChromatoCore.Auto;

namespace Chromato.gui
{

    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class ChromatoFrm : Form
    {

        #region 变量

        /// <summary> 
        /// 跨线程控件代理
        /// </summary> 
        private delegate void CrossThreadOperationControl();

        /// <summary>
        /// 样品Tab面板
        /// </summary>
        private SampleUser _tabSample = null;

        /// <summary>
        /// 方案Tab面板
        /// </summary>
        private SolutionUser _tabSolution = null;

        /// <summary>
        /// 采集Tab面板
        /// </summary>
        private OnlineUser _tabOnline = null;

        /// <summary>
        /// 分析Tab面板
        /// </summary>
        private OfflineUser _tabOffline = null;

        /// <summary>
        /// 比较Tab面板
        /// </summary>
        private CompareUser _tabCompare = null;

        /// <summary>
        /// 欢迎画面
        /// </summary>
        private WelcomeFrm _boot = null;

        /// <summary>
        /// 自动色谱对象
        /// </summary>
        private AutoRequest _autoQuest = null;

        #endregion


        #region 图片对象

        /// <summary>
        /// 工具栏上的已经连接图片
        /// </summary>
        private Image connectImage = null;

        /// <summary>
        /// 工具栏上的连接断开图片
        /// </summary>
        private Image disconnectImage = null;

        /// <summary>
        /// 工具栏上的选项图片
        /// </summary>
        private Image optionImage = null;

        /// <summary>
        /// 工具栏上的帮助图片
        /// </summary>
        private Image helpImage = null;

        /// <summary>
        /// 工具栏上的分析图片
        /// </summary>
        private Image analyImage = null;

        #endregion


        #region 初期

        /// <summary>
        /// 构造
        /// </summary>
        public ChromatoFrm()
        {
            this._boot = new WelcomeFrm();
            this._boot.Show();

            this._boot.UpdateLabelText("装载主画面", 10);
            InitializeComponent();

            //boot.Begin();

            this._boot.UpdateLabelText("装载日志", 20);
            this.LoadLog();

            this._boot.UpdateLabelText("装载图标", 30);
            this.LoadIcon();

            this._boot.UpdateLabelText("装载主树", 50);
            this.LoadTree();

            //测试
           // this.SelectNodeToFocus(MainTreeName.Online);

            this._boot.UpdateLabelText("装载面板", 40);
            this.LoadPanel();

            this._boot.UpdateLabelText("装载管道", 60);
            this.LoadPipe();

            this._boot.UpdateLabelText("装载事件", 80);
            this.LoadEvent();

            CastLog.Logger("ChromatoFrm", "ChromatoFrm_Load", "Chromato 载入");

            //boot.End();

            //int hOcx = this.axGraphOcx.UserHandle;

        }

        /// <summary>
        /// 装载日志
        /// </summary>
        private void LoadLog()
        {
            CastLog.lbRealLog = this.lbTrace;
            CastLog.bHasList = true;
            //ListBox.CheckForIllegalCrossThreadCalls = false;

            // 添加日志事件，直接绑定新方法的用法，s是内容，eve是事件数据的类型，后面是绑定的方法内容
            CastLog._reportLogEvent += new EventHandler<ReportLogArgs>((s, eve) =>
            {
                // 匿名代理
                CrossThreadOperationControl CrossUpdateListBox = delegate()
                {
                    //接收日志字符串
                    UpdateRealLog(eve._var.ToString());
                };
                if (this.Created && !this.IsDisposed && CastLog.bHasList && this.lbTrace.InvokeRequired)
                {
                    this.lbTrace.Invoke(CrossUpdateListBox);
                }

            });
        }

        /// <summary>
        /// 更新日志列表控件
        /// </summary>
        /// <param name="item">日志内容项</param>
        private void UpdateRealLog(string item)
        {
            // 只保存1000条日志
            if (null == this.lbTrace)
            {
                return;
            }

            if (1000 <= lbTrace.Items.Count)
            {
                lbTrace.Items.RemoveAt(0);
            }
            lbTrace.Items.Add(item);
            // 选中最后一行
            lbTrace.SelectedIndex = lbTrace.Items.Count - 1;
        }

        /// <summary>
        /// 装载图标
        /// </summary>
        private void LoadIcon()
        {
            // 初始化工具栏
            //从程序集中获取指定的清单资源
            connectImage = Image.FromStream(Assembly.GetExecutingAssembly().
                    GetManifestResourceStream("Chromato.Res.connect.ico"));

            disconnectImage = Image.FromStream(Assembly.GetExecutingAssembly().
                    GetManifestResourceStream("Chromato.Res.disconnect.ico"));

            optionImage = Image.FromStream(Assembly.GetExecutingAssembly().
                    GetManifestResourceStream("Chromato.Res.option.ico"));

            analyImage = Image.FromStream(Assembly.GetExecutingAssembly().
                    GetManifestResourceStream("Chromato.Res.analysis.ico"));

            helpImage = Image.FromStream(Assembly.GetExecutingAssembly().
                    GetManifestResourceStream("Chromato.Res.About.bmp"));

            this.tsBtnConnect.Image = connectImage;
            this.tsBtnDisConnect.Image = disconnectImage;
            this.tsButtonOption.Image = optionImage;
            this.tsButtonHelp.Image = helpImage;
            this.tsButtonAnaly.Image = analyImage;

            this.tsBtnConnect.ToolTipText = EnumDescription.GetFieldText(LinkGcStatus.On);
            this.tsBtnDisConnect.ToolTipText = EnumDescription.GetFieldText(LinkGcStatus.Off);
            this.tsButtonOption.ToolTipText = "配置";
            this.tsButtonHelp.ToolTipText = "关于";
            this.tsButtonAnaly.ToolTipText = "分析";

            this.tsStatusBar.Checked = General.StatusBar;
            this.lbTrace.Visible = General.StatusBar;

            //脱机联机返回事件
            switch (General.ObjectLink)
            {
                case General.LinkObject.BigBoard:
                    ((Comm3010)CommPort.Instance).LinkGcEvent += new LinkGcDelegate(this.LinkGcResponse);
                    break;
            }

        }

        /// <summary>
        /// 装载面板
        /// </summary>
        private void LoadPanel()
        {
            this._tabSample = new SampleUser();
            this._tabSolution = new SolutionUser();
            //这一句启动采集线程OnlineUser→OnGroup→ApplyRunThread
            this._tabOnline = new OnlineUser();
            this._tabOffline = new OfflineUser();
            this._tabCompare = new CompareUser();


            //加入控件队列
            this.Controls.Add(this._tabSample);
            this.Controls.Add(this._tabSolution);
            this.Controls.Add(this._tabOnline);
            this.Controls.Add(this._tabOffline);
            this.Controls.Add(this._tabCompare);

            //Z轴移动到gbMain的前面，gbMain用来做底部大小容器

            this._tabSample.BringToFront();
            this._tabSolution.BringToFront();
            this._tabOnline.BringToFront();
            this._tabOffline.BringToFront();
            this._tabCompare.BringToFront();

        }

        /// <summary>
        /// 装载主树
        /// </summary>
        private void LoadTree()
        {
            this.tvCategory.AfterSelect += new TreeViewEventHandler(this.tvCategory_AfterSelect);
            this.tvCategory.BeforeSelect += new TreeViewCancelEventHandler(this.tvCategory_BeforeSelect);

            this.tvCategory.CheckBoxes = true;
            // treeView1.ShowLines = false;
            //点击节点后，先beforeselect再afterselect，接着drawmode，接着是on类中定义的drawitem委托
            tvCategory.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            tvCategory.DrawNode += new DrawTreeNodeEventHandler(this.tvCategory_DrawNode);

            // first level
            TreeNode rnSample = new TreeNode();
            TreeNode rnSolution = new TreeNode();
            TreeNode rnOffline = new TreeNode();
            TreeNode rnOnline = new TreeNode();
            TreeNode rnCompare = new TreeNode();

            //親ノードのテキストを作成 
            //first level 
            rnSample.Text = MainTreeText.Sample;
            rnSample.Name = MainTreeName.Sample;

            rnSolution.Text = MainTreeText.Solution;
            rnSolution.Name = MainTreeName.Solution;

            rnOnline.Text = MainTreeText.Online;
            rnOnline.Name = MainTreeName.Online;

            rnOffline.Text = MainTreeText.Offline;
            rnOffline.Name = MainTreeName.Offline;

            rnCompare.Text = MainTreeText.Compare;
            rnCompare.Name = MainTreeName.Compare;

            //親ノードをTreeViewに追加
            tvCategory.Nodes.Add(rnSample);
            tvCategory.Nodes.Add(rnSolution);
            tvCategory.Nodes.Add(rnOnline);
            tvCategory.Nodes.Add(rnOffline);
            tvCategory.Nodes.Add(rnCompare);

            //全展開する
            tvCategory.ExpandAll();

            //チェックボックスを表示しない
            tvCategory.CheckBoxes = false;

            //level two 展開する
            //rnMain.Expand();

            // 根ノードを選択
            tvCategory.SelectedNode = rnSample;

        }

        /// <summary>
        /// 装载管道
        /// </summary>
        private void LoadPipe()
        {

            this._tabOnline.SetPipeName(ChannelID.A, PipeBiz.Instance._realPipe[(int)ChannelID.A]._pipeFullName);
            this._tabOnline.CreateLayer(ChannelID.A, UserType.osc, PipeBiz.Instance._realPipe[(int)ChannelID.A]);

            this._tabOnline.SetPipeName(ChannelID.B, PipeBiz.Instance._realPipe[(int)ChannelID.B]._pipeFullName);
            this._tabOnline.CreateLayer(ChannelID.B, UserType.osc, PipeBiz.Instance._realPipe[(int)ChannelID.B]);

            this._tabOnline.SetPipeName(ChannelID.C, PipeBiz.Instance._realPipe[(int)ChannelID.C]._pipeFullName);
            this._tabOnline.CreateLayer(ChannelID.C, UserType.osc, PipeBiz.Instance._realPipe[(int)ChannelID.C]);

            this._tabOnline.SetPipeName(ChannelID.D, PipeBiz.Instance._realPipe[(int)ChannelID.D]._pipeFullName);
            this._tabOnline.CreateLayer(ChannelID.D, UserType.osc, PipeBiz.Instance._realPipe[(int)ChannelID.D]);

            //User→Group→Bottom→GraphViewer→GraphBiz
            this._tabOffline.SetPipeName(PipeBiz.Instance._hisPipe._pipeFullName);
            this._tabOffline.CreateLayer(ChannelID.off, UserType.osc, PipeBiz.Instance._hisPipe);

            this._tabSample.SetPipeName(PipeBiz.Instance._samplePipe._pipeFullName);
            this._tabSample.CreateLayer(ChannelID.sample, UserType.osc, PipeBiz.Instance._samplePipe);

            this._tabCompare.SetPipeName(PipeBiz.Instance._comparePipe._pipeFullName);
            this._tabCompare.CreateLayer(ChannelID.compare, UserType.osc, PipeBiz.Instance._comparePipe);
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.tsViewSample.Click += new System.EventHandler(this.tsViewSample_Click);
            this.tsViewSolution.Click += new System.EventHandler(this.tsViewSolution_Click);
            this.tsViewCollection.Click += new System.EventHandler(this.tsViewCollection_Click);
            this.tsViewAnalysis.Click += new System.EventHandler(this.tsViewAnalysis_Click);
            this.tsViewCompare.Click += new System.EventHandler(this.tsViewCompare_Click);

            this.tsToolOption.Click += new System.EventHandler(this.tsToolOption_Click);
            this.tsStatusBar.Click += new System.EventHandler(this.tsStatusBar_Click);
            this.tsUser.Click += new System.EventHandler(this.tsUser_Click);
            this.tsUpdatePwd.Click += new System.EventHandler(this.tsUpdatePwd_Click);
            this.tsDatabaseExport.Click += new System.EventHandler(this.tsDatabaseExport_Click);
            this.tsDatabaseImport.Click += new System.EventHandler(this.tsDatabaseImport_Click);

            this.tsHelpAbout.Click += new System.EventHandler(this.tsHelpAbout_Click);
            this.tsHelpExit.Click += new System.EventHandler(this.tsHelpExit_Click);

             this.tsBtnConnect.Click += new System.EventHandler(this.tsButtonConnect_Click);
             this.tsBtnDisConnect.Click += new System.EventHandler(this.tsBtnDisConnect_Click);

        }

        /// <summary>
        /// 画面显示初期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChromatoFrm_Load(object sender, EventArgs e)
        {
            //主画面最大化
            this._boot.UpdateLabelText("主画面最大化", 100);

            // 设置通道，这里预设的是SmallBoard
            switch (General.ObjectLink)
            {
                case General.LinkObject.SmallBoard:
                    GcChannel.Tcd1 = true;
                    GcChannel.Tcd2 = false;
                    GcChannel.Fid1 = true;
                    GcChannel.Fid2 = false;
                    this.tsBtnConnect.Visible = false;
                    this.tsBtnDisConnect.Visible = false;
                    break;

                case General.LinkObject.BigBoard:
                    GcChannel.Tcd1 = false;
                    GcChannel.Tcd2 = false;
                    GcChannel.Fid1 = false;
                    GcChannel.Fid2 = false;
                    break;

                case General.LinkObject.ChannelGas:
                    GcChannel.Tcd1 = true;
                    GcChannel.Tcd2 = true;
                    GcChannel.Fid1 = true;
                    GcChannel.Fid2 = true;
                    this.tsBtnConnect.Visible = false;
                    this.tsBtnDisConnect.Visible = false;
                    break;

                case General.LinkObject.AutoChromatoGas:
                    GcChannel.Tcd1 = true;
                    GcChannel.Tcd2 = true;
                    GcChannel.Fid1 = true;
                    GcChannel.Fid2 = true;
                    this.tsBtnConnect.Visible = false;
                    this.tsBtnDisConnect.Visible = false;
                    this._autoQuest = new AutoRequest();
                    this._tabOnline.InitAuto(this._autoQuest);
                    this._tabOffline.InitAuto(this._autoQuest);
                    this._autoQuest.Start();
                    break;
            }

            // 设置用户管理菜单
            if (General.NeedLogin)
            {
                if (DefaultItem.UserID.ToLower().Equals(General.UserID.ToLower()))
                {
                    this.tsUser.Visible = true;
                    this.tsUpdatePwd.Visible = false;
                }
                else
                {
                    this.tsUser.Visible = false;
                    this.tsUpdatePwd.Visible = true;
                }
            }
            else
            {
                this.tsUser.Visible = false;
                this.tsUpdatePwd.Visible = false;
            }

            //this.CacuBafeita();
            //this.SetTopLevel(true);
            this.WindowState = FormWindowState.Maximized;

            _boot.Close();
        }

        /// <summary>
        /// 巴菲特计算
        /// </summary>
        private void CacuBafeita()
        {
            const double eachMoney = 1.0;
            const int loopYear = 30;
            double total = eachMoney;
            
            for (int i = 0; i < loopYear - 1; i++)
            {
                total = total * 1.2;
                total = total + eachMoney;
            }

            MessageBox.Show(String.Format("You get {0}",total),"info");
        }



        #endregion


        #region 主树表示

        /// <summary>
        /// 全てパネルを表示しない
        /// </summary>
        private void UnVisibleAllPanels()
        {
            this._tabSample.Visible = false;
            this._tabSolution.Visible = false;
            this._tabOnline.Visible = false;
            this._tabOffline.Visible = false;
            this._tabCompare.Visible = false;
        }

        /// <summary>
        /// 選択まえに
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// BeforeSelect事件在展开节点时触发的事件,AfterSelect事件在展开节点后触发的事件
        private void tvCategory_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (null == this.tvCategory.SelectedNode)
            {
                return;
            }

            switch (this.tvCategory.SelectedNode.Name)
            {
                // Sample
                case MainTreeName.Sample:
                    break;
                // Online
                case MainTreeName.Online:
                    break;

                default:
                    break;
            }

            this.tvCategory.SelectedNode.BackColor = Color.FromArgb(255, 255, 192);
            this.tvCategory.SelectedNode.ForeColor = Color.Black;
        }

        /// <summary>
        /// ツリーのノードを選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.UnVisibleAllPanels();

            e.Node.ForeColor = Color.FromArgb(255, 255, 192);
            e.Node.BackColor = Color.Black;

            this.ChangePanelOrPlot(e.Node.Name);

            // 设置窗口标题
            this.UpdateAppText();
        }

        /// <summary>
        /// 改变当前面板大小等属性
        /// </summary>
        /// <param name="nodename"></param>
        private void ChangePanelOrPlot(String nodename)
        {
            switch (nodename)
            {
                case MainTreeName.Sample:
                    this.ShowPanel(this._tabSample);
                    this._tabSample.LoadPage();
                    this.tsButtonAnaly.Enabled = false;
                    break;

                case MainTreeName.Solution:
                    this.ShowPanel(this._tabSolution);
                    this._tabSolution.LoadPage();
                    this.tsButtonAnaly.Enabled = false;
                    break;

                case MainTreeName.Online:
                    this.ShowPanel(this._tabOnline);
                    this._tabOnline.LoadPage();
                    this.tsButtonAnaly.Enabled = false;
                    break;

                case MainTreeName.Offline:
                    this.ShowPanel(this._tabOffline);
                    this._tabOffline.LoadPage();
                    this.tsButtonAnaly.Enabled = true;
                    break;

                case MainTreeName.Compare:
                    this.ShowPanel(this._tabCompare);
                    this._tabCompare.LoadPage();
                    this.tsButtonAnaly.Enabled = false;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 显示选中面板
        /// </summary>
        /// <param name="us"></param>
        private void ShowPanel(Control us)
        {
            if (us.Location != this.gbMain.Location)
            {
                us.Location = this.gbMain.Location;
            }
            if (us.Size != this.gbMain.Size)
            {
                us.Size = this.gbMain.Size;
            }
            us.Visible = true;
        }

        /// <summary>
        /// 描画节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvCategory_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;
        }

        /// <summary>
        /// 选中树中节点
        /// </summary>
        private void SelectNodeToFocus(String nodeName)
        {
            TreeNode tnRet = null;
            foreach (TreeNode tn in this.tvCategory.Nodes)
            {
                tnRet = this.FindNode(tn, nodeName);
                if (tnRet != null)
                {
                    this.tvCategory.SelectedNode = tnRet;
                    break;
                }
            }
        }

        /// <summary>
        /// 查询树中节点
        /// </summary>
        private TreeNode FindNode(String nodeName)
        {
            TreeNode tnRet = null;
            foreach (TreeNode tn in this.tvCategory.Nodes)
            {
                tnRet = this.FindNode(tn, nodeName);
                if (tnRet != null)
                {
                    break;
                }
            }
            return tnRet;
        }

        /// <summary>
        /// ノードを検索
        /// </summary>
        /// <param name="tnParent"></param>
        /// <param name="strValue"></param>
        /// <returns></returns>
        private TreeNode FindNode(TreeNode tnParent, String strValue)
        {

            if (tnParent == null) return null;
            if (tnParent.Text.IndexOf(strValue) != -1)
            {
                return tnParent;
            }

            TreeNode tnRet = null;

            foreach (TreeNode tn in tnParent.Nodes)
            {
                tnRet = FindNode(tn, strValue);

                if (tnRet != null) break;
            }
            return tnRet;
        }

        #endregion


        #region 窗体和主菜单事件

        /// <summary>
        /// 窗口大小改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphDemoFrm_Resize(object sender, EventArgs e)
        {
            if (null == this.tvCategory.SelectedNode)
            {
                return;
            }
            this.ChangePanelOrPlot(this.tvCategory.SelectedNode.Name);

        }

        /// <summary>
        /// 窗体退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChromatoFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.CheckRealStatus())
            {
                MessageBox.Show("请停止样品的采集", "警告");
                e.Cancel = true;
                return;
            }

            String temp = "是否要退出" + DefaultItem.Project_Name + "?";
            if (DialogResult.No == MessageBox.Show(temp,
                "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                e.Cancel = true;
            }
            else
            {
                CastLog.bHasList = false;
                Setting.Write();
                this._tabOnline.StopSample(StopSampleReason.ShutDown);
                this._tabCompare.StopThread();

                if (null != this._autoQuest)
                {
                    this._autoQuest.Stop();
                }
                
                if (!this.IsDisposed)
                {
                    this.Dispose();
                }
            }
        }

        /// <summary>
        /// 样品菜单按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsViewSample_Click(object sender, EventArgs e)
        {
            this.SelectNodeToFocus(MainTreeName.Sample);
        }

        /// <summary>
        /// 方案菜单按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsViewSolution_Click(object sender, EventArgs e)
        {
            this.SelectNodeToFocus(MainTreeName.Solution);
        }

        /// <summary>
        /// 采集菜单按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsViewCollection_Click(object sender, EventArgs e)
        {
            this.SelectNodeToFocus(MainTreeName.Online);
        }

        /// <summary>
        /// 分析菜单按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsViewAnalysis_Click(object sender, EventArgs e)
        {
            this.SelectNodeToFocus(MainTreeName.Offline);
        }

        /// <summary>
        /// 比较菜单按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsViewCompare_Click(object sender, EventArgs e)
        {
            this.SelectNodeToFocus(MainTreeName.Compare);
        }

        /// <summary>
        /// 配置菜单按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsToolOption_Click(object sender, EventArgs e)
        {
            SettingFrm frmSetting = new SettingFrm(this._tabOnline);
            if (DialogResult.OK == frmSetting.ShowDialog())
            {
                this._tabOnline.OcxShowChange();
            }
        }

        /// <summary>
        /// 导出菜单按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDatabaseExport_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 导入菜单按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDatabaseImport_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 关于菜单按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsHelpAbout_Click(object sender, EventArgs e)
        {
            AboutMeFrm frmAboutMe = new AboutMeFrm();
            frmAboutMe.ShowDialog();
        }

        /// <summary>
        /// 退出菜单按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsHelpExit_Click(object sender, EventArgs e)
        {

            if (this.CheckRealStatus())
            {
                MessageBox.Show("请停止样品的采集", "警告");
                return;
            }

            String temp = "是否要退出" + DefaultItem.Project_Name + "?";
            if (DialogResult.Yes == MessageBox.Show(temp,
                "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                CastLog.bHasList = false;
                Setting.Write();

                this._tabOnline.StopSample(StopSampleReason.ShutDown);
                this._tabCompare.StopThread();

                if (null != this._autoQuest)
                {
                    this._autoQuest.Stop();
                }

                if (!this.IsDisposed)
                {
                    this.Dispose();
                }
            }
        }

        /// <summary>
        /// 检查通道状态
        /// </summary>
        /// <returns></returns>
        private bool CheckRealStatus()
        {
            bool bRet = false;

            if ((RealStatus.RealCollecting == CommPort.Instance.GetRealStatus(IdChannel.Tcd1)) ||
            (RealStatus.RunBase == CommPort.Instance.GetRealStatus(IdChannel.Tcd1)) ||
            (RealStatus.RealCollecting == CommPort.Instance.GetRealStatus(IdChannel.Fid1)) ||
            (RealStatus.RunBase == CommPort.Instance.GetRealStatus(IdChannel.Fid1)) ||
            (RealStatus.RealCollecting == CommPort.Instance.GetRealStatus(IdChannel.Tcd2)) ||
            (RealStatus.RunBase == CommPort.Instance.GetRealStatus(IdChannel.Tcd2)) ||
            (RealStatus.RealCollecting == CommPort.Instance.GetRealStatus(IdChannel.Fid2)) ||
            (RealStatus.RunBase == CommPort.Instance.GetRealStatus(IdChannel.Fid2)))
            {
                bRet = true;
            }

            return bRet;
        }
        #endregion


        #region 分割条事件

        /// <summary>
        /// 下分割条事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitterMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            //e.SplitX = 0;
            //e.SplitY = e.Y;
            //this.lbTrace.Items.Add("splitterMain_SplitterMoved");
            CastLog.Logger("", "", "splitterMain_SplitterMoved");
            if (null == this.tvCategory.SelectedNode)
            {
                return;
            }
            this.ChangePanelOrPlot(this.tvCategory.SelectedNode.Name);
        }

        /// <summary>
        /// 左分割条事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitterTree_SplitterMoved(object sender, SplitterEventArgs e)
        {
            CastLog.Logger("", "", "splitterTree_SplitterMoved");

            if (null == this.tvCategory.SelectedNode)
            {
                return;
            }
            this.ChangePanelOrPlot(this.tvCategory.SelectedNode.Name);
        }

        #endregion


        #region 工具条事件

        /// <summary>
        /// 联机按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsButtonConnect_Click(object sender, EventArgs e)
        {

            HardBiz.Instance.LinkToGc();
        }

        /// <summary>
        /// 脱机按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnDisConnect_Click(object sender, EventArgs e)
        {

            HardBiz.Instance.OfflineToGc();

            GcChannel.Tcd1 = false;
            GcChannel.Tcd2 = false;
            GcChannel.Fid1 = false;
            GcChannel.Fid2 = false;

            this.UpdateAppText();
            this._tabOnline.UpdateDetectorStatus(); 
        }

        /// <summary>
        /// 联机脱机返回事件
        /// </summary>
        private void LinkGcResponse()
        {

            // 设置窗口标题
            CrossThreadOperationControl CrossUpdateAppText = delegate()
            {
                //接收日志字符串
                this.UpdateAppText();
                this._tabOnline.UpdateDetectorStatus();
            };
            if (this.InvokeRequired)
            {
                this.Invoke(CrossUpdateAppText);
            }
        }

        /// <summary>
        /// 设置窗口标题
        /// </summary>
        private void UpdateAppText()
        {
            // 设置窗口标题
            String temp = (General.ObjectLink == General.LinkObject.BigBoard) ?
                " - [" + EnumDescription.GetFieldText(HardBiz.Instance.LinkGc) + "]" : "";

            this.Text = DefaultItem.Project_Name
                + temp
                + " - [" + this.tvCategory.SelectedNode.Name.ToString() + "]" 
                + " - [当前用户:"  + General.UserID + "]";
        }

        /// <summary>
        /// 选项按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsButtonOption_Click(object sender, EventArgs e)
        {
            SettingFrm frmSetting = new SettingFrm(this._tabOnline);
            //点下确定
            if (DialogResult.OK == frmSetting.ShowDialog())
            {
                this._tabOnline.OcxShowChange();
            }
        }

        /// <summary>
        /// 帮助按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsButtonHelp_Click(object sender, EventArgs e)
        {
            AboutMeFrm frmAboutMe = new AboutMeFrm();
            frmAboutMe.ShowDialog();
        }

        /// <summary>
        /// 重新分析按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsButtonAnaly_Click(object sender, EventArgs e)
        {
            this._tabOffline.ReAnalysis();
        }

        /// <summary>
        /// 状态栏按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsStatusBar_Click(object sender, EventArgs e)
        {
            this.lbTrace.Visible = this.tsStatusBar.Checked;
            General.StatusBar = this.tsStatusBar.Checked;
        }

        /// <summary>
        /// 用户编辑按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsUser_Click(object sender, EventArgs e)
        {
            UserEditFrm frmUser = new UserEditFrm();
            frmUser.ShowDialog();
        }

        /// <summary>
        /// 密码更新按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsUpdatePwd_Click(object sender, EventArgs e)
        {
            PwdUpdateFrm frmPwdUpdate = new PwdUpdateFrm();
            frmPwdUpdate.ShowDialog();
        }

        #endregion


    }
}
