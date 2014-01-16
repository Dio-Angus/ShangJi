/*-----------------------------------------------------------------------------
//  FILE NAME       : AntiControlViewer.cs
//  FUNCTION        : 反控方法视图
//  AUTHOR          : 李锋(2009/06/23)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoTool.ini;
using System.Drawing;
using ChromatoBll.bll;
using System;
using System.Text;

namespace ChromatoCore.solu.AntiCon
{
    /// <summary>
    /// 反控方法视图
    /// </summary>
    public partial class AntiControlViewer : UserControl
    {


        #region 变量

        /// <summary>
        /// 访问方法
        /// </summary>
        public AccessMethod _accessM = AccessMethod.New;

        /// <summary>
        /// 方案dto
        /// </summary>
        private SolutionDto _dto = null;

        /// <summary>
        /// 是否第一次装载
        /// </summary>
        private bool _isFirst = true;

        /// <summary>
        /// 网络板参数
        /// </summary>
        private NetworkBoardUser _viewNetworkBoard = null;

        /// <summary>
        /// 加热源参数
        /// </summary>
        private HeatingSourceUser _viewHeatingSource = null;

        /// <summary>
        /// 进样口参数
        /// </summary>
        private InjectUser _viewInject = null;

        /// <summary>
        /// Tcd参数
        /// </summary>
        private TcdUser _viewTcd = null;

        /// <summary>
        /// FID参数
        /// </summary>
        private FidUser _viewFid = null;

        /// <summary>
        /// Aux参数
        /// </summary>
        private AuxUser _viewAux = null;

        /// <summary>
        /// Ecd参数
        /// </summary>
        private EcdUser _viewEcd = null;

        /// <summary>
        /// Fpd参数
        /// </summary>
        private FpdUser _viewFpd = null;

        /// <summary>
        /// 分析方法逻辑
        /// </summary>
        private AntiControlBiz _bizAntiControl = null;

        /// <summary>
        /// 分析方法dto
        /// </summary>
        private AntiControlDto _dtoAntiControl = null;

        private ChromatoBll.serialCom.CommandMaker _makeCommand = new ChromatoBll.serialCom.CommandMaker();


        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public AntiControlViewer(AccessMethod am)
        {
            InitializeComponent();
            this._accessM = am;
            this._bizAntiControl = new AntiControlBiz();
            this._dtoAntiControl = new AntiControlDto();

            this.LoadEvent();
            this.AddViewer();
            this.InitTreeCategory();
            this.InitPanel();
        }

        /// <summary>
        /// 添加视图
        /// </summary>
        private void AddViewer()
        {
            this._viewNetworkBoard = new NetworkBoardUser(this._dtoAntiControl);
            this._viewHeatingSource = new HeatingSourceUser(this._dtoAntiControl);
            this._viewInject = new InjectUser(this._dtoAntiControl);
            this._viewTcd = new TcdUser(this._dtoAntiControl);
            this._viewFid = new FidUser(this._dtoAntiControl);
            this._viewAux = new AuxUser(this._dtoAntiControl);
            this._viewEcd = new EcdUser(this._dtoAntiControl);
            this._viewFpd = new FpdUser(this._dtoAntiControl);

            this.Controls.Add(this._viewNetworkBoard);
            this.Controls.Add(this._viewHeatingSource);
            this.Controls.Add(this._viewInject);
            this.Controls.Add(this._viewTcd);
            this.Controls.Add(this._viewFid);
            this.Controls.Add(this._viewAux);
            this.Controls.Add(this._viewEcd);
            this.Controls.Add(this._viewFpd);            
        }
        
        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.tvAntiControl.AfterSelect += new TreeViewEventHandler(this.tvAntiControl_AfterSelect);
            this.tvAntiControl.BeforeSelect += new TreeViewCancelEventHandler(this.tvAntiControl_BeforeSelect);
            this.txtAntiControlName.TextChanged += new System.EventHandler(this.txtAntiControlName_TextChanged);

        }

        /// <summary>
        /// ツリーを初期
        /// </summary>
        private void InitTreeCategory()
        {
            this.tvAntiControl.CheckBoxes = true;
            // treeView1.ShowLines = false;
            this.tvAntiControl.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            this.tvAntiControl.DrawNode += new DrawTreeNodeEventHandler(this.tvAntiControl_DrawNode);

            // first level
            TreeNode rnNetworkBoard = new TreeNode();
            TreeNode rnHeatingSource = new TreeNode();
            TreeNode rnSampleEntry = new TreeNode();
            TreeNode rnTcd = new TreeNode();
            TreeNode rnFid = new TreeNode();
            TreeNode rnAux = new TreeNode();
            TreeNode rnEcd = new TreeNode();
            TreeNode rnFpd = new TreeNode();


            //親ノードのテキストを作成 
            rnNetworkBoard.Text = AntiControl.NetworkBoard;
            rnNetworkBoard.Name = AntiControl.NetworkBoard;

            rnHeatingSource.Text = AntiControl.HeatingSource;
            rnHeatingSource.Name = AntiControl.HeatingSource;

            rnSampleEntry.Text = AntiControl.Inject;
            rnSampleEntry.Name = AntiControl.Inject;

            rnTcd.Text = AntiControl.Tcd;
            rnTcd.Name = AntiControl.Tcd;

            rnFid.Text = AntiControl.Fid;
            rnFid.Name = AntiControl.Fid;

            rnAux.Text = AntiControl.Aux;
            rnAux.Name = AntiControl.Aux;

            rnEcd.Text = AntiControl.Ecd;
            rnEcd.Name = AntiControl.Ecd;

            rnFpd.Text = AntiControl.Fpd;
            rnFpd.Name = AntiControl.Fpd;

            //親ノードをTreeViewに追加
            tvAntiControl.Nodes.Add(rnNetworkBoard);
            tvAntiControl.Nodes.Add(rnHeatingSource);
            tvAntiControl.Nodes.Add(rnSampleEntry);
            tvAntiControl.Nodes.Add(rnTcd);
            tvAntiControl.Nodes.Add(rnFid);
            tvAntiControl.Nodes.Add(rnAux);
            tvAntiControl.Nodes.Add(rnEcd);
            tvAntiControl.Nodes.Add(rnFpd);

            //全展開する
            tvAntiControl.ExpandAll();

            //チェックボックスを表示しない
            tvAntiControl.CheckBoxes = false;

            // 根ノードを選択
            tvAntiControl.SelectedNode = rnNetworkBoard;

        }

        /// <summary>
        /// パネルを初期
        /// </summary>
        private void InitPanel()
        {

            //パネルのロケーションを設定する
            Point pt = new Point(100, 10);
            this._viewNetworkBoard.Location = pt;
            this._viewHeatingSource.Location = pt;
            this._viewInject.Location = pt;
            this._viewTcd.Location = pt;
            this._viewFid.Location = pt;
            this._viewAux.Location = pt;
            this._viewEcd.Location = pt;
            this._viewFpd.Location = pt;

            Size sz = new Size(460, 240);
            this._viewNetworkBoard.Size = sz;
            this._viewHeatingSource.Size = sz;
            this._viewInject.Size = sz;
            this._viewTcd.Size = sz;
            this._viewFid.Size = sz;
            this._viewAux.Size = sz;
            this._viewEcd.Size = sz;
            this._viewFpd.Size = sz;

            this._viewNetworkBoard.BringToFront();
            this._viewHeatingSource.BringToFront();
            this._viewInject.BringToFront();
            this._viewTcd.BringToFront();
            this._viewFid.BringToFront();
            this._viewAux.BringToFront();
            this._viewEcd.BringToFront();
            this._viewFpd.BringToFront();
        }

        /// <summary>
        /// 全てパネルを表示しない
        /// </summary>
        private void UnVisibleAllPanels()
        {
            this._viewNetworkBoard.Visible = false;
            this._viewHeatingSource.Visible = false;
            this._viewInject.Visible = false;
            this._viewTcd.Visible = false;
            this._viewFid.Visible = false;
            this._viewAux.Visible = false;
            this._viewEcd.Visible = false;
            this._viewFpd.Visible = false;
        }

        #endregion


        #region 树的表示

        /// <summary>
        /// 选中时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvAntiControl_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (null == this.tvAntiControl.SelectedNode)
            {
                return;
            }

            switch (this.tvAntiControl.SelectedNode.Name)
            {
                // Root
                case AntiControl.NetworkBoard:
                    break;
                // LineIn
                case AntiControl.Inject:
                    break;
             }

            foreach (TreeNode Node in this.tvAntiControl.Nodes)
            {
                Node.BackColor = Color.White;
                Node.ForeColor = Color.Black;
            }

        }

        /// <summary>
        /// 选中之后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvAntiControl_AfterSelect(object sender, TreeViewEventArgs e)
        {

            this.UnVisibleAllPanels();

            e.Node.ForeColor = Color.FromArgb(255, 255, 192);
            e.Node.BackColor = Color.Black;


            switch (e.Node.Name)
            {

                case AntiControl.NetworkBoard:
                    this._viewNetworkBoard.Visible = true;
                    break;

                case AntiControl.HeatingSource:
                    this._viewHeatingSource.Visible = true;
                    break;

                case AntiControl.Inject:
                    this._viewInject.Visible = true;
                    break;

                case AntiControl.Tcd:
                    this._viewTcd.Visible = true;
                    break;

                case AntiControl.Fid:
                    this._viewFid.Visible = true;
                    break;

                case AntiControl.Aux:
                    this._viewAux.Visible = true;
                    break;

                case AntiControl.Ecd:
                    this._viewEcd.Visible = true;
                    break;

                case AntiControl.Fpd:
                    this._viewFpd.Visible = true;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 描绘节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvAntiControl_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;
        }

        #endregion


        #region 方法

        /// <summary>
        /// 复位，清除标志，用户选择的反控方法改变
        /// </summary>
        public void Reset(int antiMethodID)
        {
            this.LoadView(antiMethodID);
            this._isFirst = false;
        }

        /// <summary>
        /// 显示反控方法的详细信息
        /// </summary>
        /// <param name="dto"></param>
        public void LoadUi(SolutionDto dto)
        {
            this._dto = dto;
            this.gbAntiControl.Enabled = (null == this._dto) ? false : true;
            if (null == this._dto)
            {
                return;
            }

            switch (this._accessM)
            {
                case AccessMethod.View:
                    this.LoadView(dto.AntiMethodID);
                    break;

                case AccessMethod.New:
                    if (this._isFirst)
                    {
                        this.LoadNew();
                        this._isFirst = false;
                    }
                    break;

                case AccessMethod.Edit:
                    if (this._isFirst)
                    {
                        this.LoadEdit();
                        this._isFirst = false;
                    }
                    break;

                case AccessMethod.SaveAs:
                    if (this._isFirst)
                    {
                        this.LoadView(dto.AntiMethodID);
                        this._isFirst = false;
                    }
                    break;
            }
        }

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        private void LoadView(int antiControlID)
        {

            this._dtoAntiControl.AntiControlID = antiControlID;

            //第一次装载需要从数据库查询反控方法的具体内容
            this._bizAntiControl.GetMethodByID(this._dtoAntiControl);

            this.txtAntiControlName.Text = this._dtoAntiControl.AntiControlName;
            this.LoadControlStyle(true);

            this._viewNetworkBoard.LoadView(antiControlID);
            this._viewHeatingSource.LoadView(antiControlID);
            this._viewInject.LoadView(antiControlID);
            this._viewAux.LoadView(antiControlID);
            this._viewFid.LoadView(antiControlID);
            this._viewTcd.LoadView(antiControlID);
            this._viewEcd.LoadView(antiControlID);
            this._viewFpd.LoadView(antiControlID);
        }

        /// <summary>
        /// 装载控件的风格
        /// </summary>
        /// <param name="isReadOnly"></param>
        public void LoadControlStyle(bool isReadOnly)
        {
            this.txtAntiControlName.ReadOnly = isReadOnly;
            this.txtAntiControlName.BackColor = isReadOnly ? Color.Beige : Color.White;
        }

        /// <summary>
        /// 新建立反控的信息
        /// </summary>
        private void LoadNew()
        {

            this.LoadControlStyle(false);

            this.txtAntiControlName.Text = "新建立反控方法";
            this._dtoAntiControl.AntiControlName = this.txtAntiControlName.Text;

            this._viewNetworkBoard.LoadNew();
            this._viewHeatingSource.LoadNew();
            this._viewInject.LoadNew();
            this._viewAux.LoadNew();
            this._viewFid.LoadNew();
            this._viewTcd.LoadNew();
            this._viewEcd.LoadNew();
            this._viewFpd.LoadNew();
        }

        /// <summary>
        /// 编辑当前反控的信息
        /// </summary>
        private void LoadEdit()
        {

            this._dtoAntiControl.AntiControlID = this._dto.AntiMethodID;

            //查询反控方法的具体内容
            this._bizAntiControl.GetMethodByID(this._dtoAntiControl);

            this.txtAntiControlName.Text = this._dtoAntiControl.AntiControlName;
            this.LoadControlStyle(false);

            this._viewNetworkBoard.LoadEdit();
            this._viewHeatingSource.LoadEdit();
            this._viewInject.LoadEdit();
            this._viewAux.LoadEdit();
            this._viewFid.LoadEdit();
            this._viewTcd.LoadEdit();
            this._viewEcd.LoadEdit();
            this._viewFpd.LoadEdit();
        }

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        private void LoadSaveAs()
        {

            this._dtoAntiControl.AntiControlID = this._dto.AntiMethodID;

            //查询反控方法的具体内容
            this._bizAntiControl.GetMethodByID(this._dtoAntiControl);

            this.txtAntiControlName.Text = this._dtoAntiControl.AntiControlName + DateTime.Now.ToString("_yyyyMMdd");
            this.LoadControlStyle(true);

            this._viewNetworkBoard.LoadSaveAs();
            this._viewHeatingSource.LoadSaveAs();
            this._viewInject.LoadSaveAs();
            this._viewAux.LoadSaveAs();
            this._viewFid.LoadSaveAs();
            this._viewTcd.LoadSaveAs();
            this._viewEcd.LoadSaveAs();
            this._viewFpd.LoadSaveAs();
        }

        /// <summary>
        /// 插入反控方法
        /// </summary>
        public void SaveNew(SolutionDto dto)
        {
            if (0 == dto.AntiMethodID)
            {
                this._bizAntiControl.InsertMethod(this._dtoAntiControl);
                dto.AntiMethodID = this._dtoAntiControl.AntiControlID;
            }
        }

        /// <summary>
        /// 更新反控方法
        /// </summary>
        public void SaveEdit()
        {
            this._bizAntiControl.UpdateMethod(this._dtoAntiControl);
        }

        #endregion


        #region 事件

        /// <summary>
        /// 反控方法名焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAntiControlName_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtAntiControlName.Text))
            {
                MessageBox.Show("反控方法名不能为空！", "反控方法名");
                this.txtAntiControlName.Focus();
                return;
            }
 
            this._dtoAntiControl.AntiControlName = this.txtAntiControlName.Text;
        }

        /// <summary>
        /// 写入反控数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btWrite_Click(object sender, EventArgs e)
        {
            String para = null;
            switch (this.tvAntiControl.SelectedNode.Name)
            {
                case AntiControl.NetworkBoard:
                    para = _makeCommand.setAllNetworkData();
                    ChromatoBll.serialCom.CommPort.Instance.Send(para.ToString(), true);
                    System.Threading.Thread.Sleep(1000);  //1秒
                    this._viewNetworkBoard.LoadSaveAs();
                    break;
                case AntiControl.HeatingSource:
                    para = _makeCommand.setAllCOLData();
                    ChromatoBll.serialCom.CommPort.Instance.Send(para.ToString(), true);
                    System.Threading.Thread.Sleep(1000);  //1秒
                    this._viewHeatingSource.LoadSaveAs();
                    break;
                case AntiControl.Inject:
                    para = _makeCommand.setAllINJData();
                    ChromatoBll.serialCom.CommPort.Instance.Send(para.ToString(), true);
                    System.Threading.Thread.Sleep(1000);  //1秒
                    this._viewInject.LoadSaveAs();
                    break;
                case AntiControl.Aux:
                    para = _makeCommand.setAUXAllData();
                    ChromatoBll.serialCom.CommPort.Instance.Send(para.ToString(), true);
                    System.Threading.Thread.Sleep(1000);  //1秒
                    this._viewAux.LoadSaveAs();
                    break;
                case AntiControl.Fid:
                    para = _makeCommand.setFIDAllData();
                    ChromatoBll.serialCom.CommPort.Instance.Send(para.ToString(), true);
                    System.Threading.Thread.Sleep(1000);  //1秒
                    this._viewFid.LoadSaveAs();
                    break;
                case AntiControl.Tcd:
                    para = _makeCommand.setTCDAllData();
                    ChromatoBll.serialCom.CommPort.Instance.Send(para.ToString(), true);
                    System.Threading.Thread.Sleep(1000);  //1秒
                    this._viewTcd.LoadSaveAs();
                    break;
                case AntiControl.Ecd:
                    para = _makeCommand.setECDAllData();
                    ChromatoBll.serialCom.CommPort.Instance.Send(para.ToString(), true);
                    System.Threading.Thread.Sleep(1000);  //1秒
                    this._viewEcd.LoadSaveAs();
                    break;
                case AntiControl.Fpd:
                    para = _makeCommand.setFPDZero();
                    ChromatoBll.serialCom.CommPort.Instance.Send(para.ToString(), true);
                    System.Threading.Thread.Sleep(1000);  //1秒
                    this._viewFpd.LoadSaveAs();
                    break;
            }
        }

        /// <summary>
        /// 刷新反控信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btRefresh_Click(object sender, EventArgs e)
        {
            String para = null;
            switch (this.tvAntiControl.SelectedNode.Name)
            {
                case AntiControl.NetworkBoard:
                    para = _makeCommand.getAllNetworkData();
                    ChromatoBll.serialCom.CommPort.Instance.Send(para.ToString(), true);
                    System.Threading.Thread.Sleep(1000);  //1秒
                    this._viewNetworkBoard.LoadSaveAs();
                    break;
                case AntiControl.HeatingSource:
                    para = _makeCommand.getAllCOLData();
                    ChromatoBll.serialCom.CommPort.Instance.Send(para.ToString(), true);
                    System.Threading.Thread.Sleep(1000);  //1秒
                    this._viewHeatingSource.LoadSaveAs();
                    break;
                case AntiControl.Inject:
                    para = _makeCommand.getAllINJData();
                    ChromatoBll.serialCom.CommPort.Instance.Send(para.ToString(), true);
                    System.Threading.Thread.Sleep(1000);  //1秒
                    this._viewInject.LoadSaveAs();
                    break;
                case AntiControl.Aux:
                    para = _makeCommand.getAUXAllData();
                    ChromatoBll.serialCom.CommPort.Instance.Send(para.ToString(), true);
                    System.Threading.Thread.Sleep(1000);  //1秒
                    this._viewAux.LoadSaveAs();
                    break;
                case AntiControl.Fid:
                    para = _makeCommand.getFIDAllData();
                    ChromatoBll.serialCom.CommPort.Instance.Send(para.ToString(), true);
                    System.Threading.Thread.Sleep(1000);  //1秒
                    this._viewFid.LoadSaveAs();
                    break;
                case AntiControl.Tcd:
                    para = _makeCommand.getTCDAllData();
                    ChromatoBll.serialCom.CommPort.Instance.Send(para.ToString(), true);
                    System.Threading.Thread.Sleep(1000);  //1秒
                    this._viewTcd.LoadSaveAs();
                    break;
                case AntiControl.Ecd:
                    para = _makeCommand.getECDAllData();
                    ChromatoBll.serialCom.CommPort.Instance.Send(para.ToString(), true);
                    System.Threading.Thread.Sleep(1000);  //1秒
                    this._viewEcd.LoadSaveAs();
                    break;
                case AntiControl.Fpd:
                    para = _makeCommand.setFPDZero();
                    ChromatoBll.serialCom.CommPort.Instance.Send(para.ToString(), true);
                    System.Threading.Thread.Sleep(1000);  //1秒
                    this._viewFpd.LoadSaveAs();
                    break;

            }
        }

        #endregion
    }
}
