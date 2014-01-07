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
        /// 色谱柱参数
        /// </summary>
        private ColumnParaUser _viewColumnPara = null;

        /// <summary>
        /// 进样口参数
        /// </summary>
        private InjectUser _viewSampleEntry = null;

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
        /// 分析方法逻辑
        /// </summary>
        private AntiControlBiz _bizAntiControl = null;

        /// <summary>
        /// 分析方法dto
        /// </summary>
        private AntiControlDto _dtoAntiControl = null;


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
            this._viewColumnPara = new ColumnParaUser(this._dtoAntiControl);
            this._viewSampleEntry = new InjectUser(this._dtoAntiControl);
            this._viewTcd = new TcdUser(this._dtoAntiControl);
            this._viewFid = new FidUser(this._dtoAntiControl);
            this._viewAux = new AuxUser(this._dtoAntiControl);

            this.Controls.Add(this._viewColumnPara);
            this.Controls.Add(this._viewSampleEntry);
            this.Controls.Add(this._viewTcd);
            this.Controls.Add(this._viewFid);
            this.Controls.Add(this._viewAux);

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
            TreeNode rnColumnPara = new TreeNode();
            TreeNode rnSampleEntry = new TreeNode();
            TreeNode rnTcd = new TreeNode();
            TreeNode rnFid = new TreeNode();
            TreeNode rnAux = new TreeNode();

            //親ノードのテキストを作成 
            rnColumnPara.Text = AntiControl.ColumnPara;
            rnColumnPara.Name = AntiControl.ColumnPara;

            rnSampleEntry.Text = AntiControl.SampleEntry;
            rnSampleEntry.Name = AntiControl.SampleEntry;

            rnTcd.Text = AntiControl.Tcd;
            rnTcd.Name = AntiControl.Tcd;

            rnFid.Text = AntiControl.Fid;
            rnFid.Name = AntiControl.Fid;

            rnAux.Text = AntiControl.Aux;
            rnAux.Name = AntiControl.Aux;

            //親ノードをTreeViewに追加
            tvAntiControl.Nodes.Add(rnColumnPara);
            tvAntiControl.Nodes.Add(rnSampleEntry);
            tvAntiControl.Nodes.Add(rnTcd);
            tvAntiControl.Nodes.Add(rnFid);
            tvAntiControl.Nodes.Add(rnAux);

            //全展開する
            tvAntiControl.ExpandAll();

            //チェックボックスを表示しない
            tvAntiControl.CheckBoxes = false;

            // 根ノードを選択
            tvAntiControl.SelectedNode = rnColumnPara;

        }

        /// <summary>
        /// パネルを初期
        /// </summary>
        private void InitPanel()
        {

            //パネルのロケーションを設定する
            Point pt = new Point(100, 10);
            this._viewColumnPara.Location = pt;
            this._viewSampleEntry.Location = pt;
            this._viewTcd.Location = pt;
            this._viewFid.Location = pt;
            this._viewAux.Location = pt;

            Size sz = new Size(460, 240);
            this._viewColumnPara.Size = sz;
            this._viewSampleEntry.Size = sz;
            this._viewTcd.Size = sz;
            this._viewFid.Size = sz;
            this._viewAux.Size = sz;

            this._viewColumnPara.BringToFront();
            this._viewSampleEntry.BringToFront();
            this._viewTcd.BringToFront();
            this._viewFid.BringToFront();
            this._viewAux.BringToFront();
        }

        /// <summary>
        /// 全てパネルを表示しない
        /// </summary>
        private void UnVisibleAllPanels()
        {
            this._viewColumnPara.Visible = false;
            this._viewSampleEntry.Visible = false;
            this._viewTcd.Visible = false;
            this._viewFid.Visible = false;
            this._viewAux.Visible = false;
        }

        #endregion


        #region 树的表示

        /// <summary>
        /// 選択まえに
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
                case AntiControl.ColumnPara:
                    break;
                // LineIn
                case AntiControl.SampleEntry:
                    break;
             }

            this.tvAntiControl.SelectedNode.BackColor = Color.FromArgb(255, 255, 192);
            this.tvAntiControl.SelectedNode.ForeColor = Color.Black;

        }

        /// <summary>
        /// ツリーのノードを選択
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

                case AntiControl.ColumnPara:
                    this._viewColumnPara.Visible = true;
                    break;

                case AntiControl.SampleEntry:
                    this._viewSampleEntry.Visible = true;
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

            this._viewColumnPara.LoadView(antiControlID);
            this._viewSampleEntry.LoadView(antiControlID);
            this._viewAux.LoadView(antiControlID);
            this._viewFid.LoadView(antiControlID);
            this._viewTcd.LoadView(antiControlID);
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

            this._viewColumnPara.LoadNew();
            this._viewSampleEntry.LoadNew();
            this._viewAux.LoadNew();
            this._viewFid.LoadNew();
            this._viewTcd.LoadNew();

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

            this._viewColumnPara.LoadEdit();
            this._viewSampleEntry.LoadEdit();
            this._viewAux.LoadEdit();
            this._viewFid.LoadEdit();
            this._viewTcd.LoadEdit();
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

            this._viewColumnPara.LoadSaveAs();
            this._viewSampleEntry.LoadSaveAs();
            this._viewAux.LoadSaveAs();
            this._viewFid.LoadSaveAs();
            this._viewTcd.LoadSaveAs();
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

        #endregion

    }
}
