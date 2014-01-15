/*-----------------------------------------------------------------------------
//  FILE NAME       : SettingFrm.cs
//  FUNCTION        : プロジェクトの設定画面
//  AUTHOR          : 李锋(2009/03/08)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoCore.tabCtrl;
using ChromatoCore.uiConf;
using ChromatoTool.ini;



namespace Chromato.gui
{
    /// <summary>
    /// 配置画面
    /// </summary>
    public partial class SettingFrm : Form
    {

        #region へんりょう

        private SerialUser userSerial = null;
        private TcpUser userTcp = null;
        private AreaUser areaPanel = null;
        private GeneralUser generalPanel = null;
        private GridUser gridPanel = null;
        private LabelUser lablePanel = null;
        private LineUser linePanel = null;
        private PlotUser plotPanel = null;
        private ShapeUser shapePanel = null;
        private XaxsUser axsXPanel = null;
        private YaxsUser axsYPanel = null;

        private OnlineUser _tabOnline = null;

        #endregion


        #region 初期

        /// <summary>
        /// 构造
        /// </summary>
        public SettingFrm(OnlineUser userOnline)
        {
            InitializeComponent();
            AddPanel();
            this._tabOnline = userOnline;

        }


        /// <summary>
        /// パネルを追加
        /// </summary>
        private void AddPanel()
        {
            this.areaPanel = new AreaUser();
            this.generalPanel = new GeneralUser();
            this.gridPanel = new GridUser();
            this.lablePanel = new LabelUser();
            this.linePanel = new LineUser();
            this.plotPanel = new PlotUser();
            this.shapePanel = new ShapeUser();
            this.axsXPanel = new XaxsUser();
            this.axsYPanel = new YaxsUser();
            this.userSerial = new SerialUser();
            this.userTcp = new TcpUser();

            //add all panel to Main Control
            this.Controls.Add(this.userSerial);
            this.Controls.Add(this.userTcp);
            this.Controls.Add(this.areaPanel);
            this.Controls.Add(this.generalPanel);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.lablePanel);
            this.Controls.Add(this.linePanel);
            this.Controls.Add(this.plotPanel);
            this.Controls.Add(this.shapePanel);
            this.Controls.Add(this.axsXPanel);
            this.Controls.Add(this.axsYPanel);
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSetting_Load(object sender, EventArgs e)
        {
            InitTreeCategory();
            InitPanel();
        }

        /// <summary>
        /// ツリーを初期
        /// </summary>
        private void InitTreeCategory()
        {
            tvOption.CheckBoxes = true;
            // treeView1.ShowLines = false;
            tvOption.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            tvOption.DrawNode += new DrawTreeNodeEventHandler(this.tvOption_DrawNode);

            // first level
            TreeNode rnMain = new TreeNode();

            // second level
            TreeNode rnGeneral = new TreeNode();
            TreeNode rnSerial = new TreeNode();
            TreeNode rnTcp = new TreeNode();
            TreeNode rnArea = new TreeNode();
            TreeNode rnGrid = new TreeNode();
            TreeNode rnLabel = new TreeNode();
            TreeNode rnLine = new TreeNode();
            TreeNode rnPlot = new TreeNode();
            TreeNode rnShape = new TreeNode();
            TreeNode rnAxsX = new TreeNode();
            TreeNode rnAxsY = new TreeNode();


            //親ノードのテキストを作成 
            //first level 
            rnMain.Text = ConfigTreeName.Main;
            rnMain.Name = ConfigTreeName.Main;

            // second level
            rnGeneral.Text = ConfigTreeName.General;
            rnGeneral.Name = ConfigTreeName.General;

            rnSerial.Text = ConfigTreeName.Serial;
            rnSerial.Name = ConfigTreeName.Serial;

            rnTcp.Text = ConfigTreeName.Tcp;
            rnTcp.Name = ConfigTreeName.Tcp;
            
            rnArea.Text = ConfigTreeName.Area;
            rnArea.Name = ConfigTreeName.Area;

            rnGrid.Text = ConfigTreeName.Grid;
            rnGrid.Name = ConfigTreeName.Grid;

            rnLabel.Text = ConfigTreeName.Label;
            rnLabel.Name = ConfigTreeName.Label;

            rnLine.Text = ConfigTreeName.Line;
            rnLine.Name = ConfigTreeName.Line;

            rnPlot.Text = ConfigTreeName.Plot;
            rnPlot.Name = ConfigTreeName.Plot;

            rnShape.Text = ConfigTreeName.Shape;
            rnShape.Name = ConfigTreeName.Shape;

            rnAxsX.Text = ConfigTreeName.AxsX;
            rnAxsX.Name = ConfigTreeName.AxsX;

            rnAxsY.Text = ConfigTreeName.AxsY;
            rnAxsY.Name = ConfigTreeName.AxsY;


            rnMain.Nodes.Add(rnGeneral);
            rnMain.Nodes.Add(rnSerial);
            rnMain.Nodes.Add(rnTcp);

            if (General.ShowDebugPage)
            {
                rnMain.Nodes.Add(rnArea);
                rnMain.Nodes.Add(rnGrid);
                rnMain.Nodes.Add(rnLabel);
                rnMain.Nodes.Add(rnLine);
                rnMain.Nodes.Add(rnPlot);
                rnMain.Nodes.Add(rnShape);
                rnMain.Nodes.Add(rnAxsX);
                rnMain.Nodes.Add(rnAxsY);
            }

            //親ノードをTreeViewに追加
            tvOption.Nodes.Add(rnMain);

            //全展開する
            //tvCategory.ExpandAll();

            //チェックボックスを表示しない
            tvOption.CheckBoxes = false;

            //level two 展開する
            rnMain.Expand();

            // 根ノードを選択
            tvOption.SelectedNode = rnMain;

        }

        /// <summary>
        /// パネルを初期
        /// </summary>
        private void InitPanel()
        {

            //パネルのロケーションを設定する
            Point pt = new Point(140, 0);
            this.generalPanel.Location = pt;
            this.userSerial.Location = pt;
            this.userTcp.Location = pt;
            this.areaPanel.Location = pt;
            this.gridPanel.Location = pt;
            this.lablePanel.Location = pt;
            this.linePanel.Location = pt; 
            this.plotPanel.Location = pt;
            this.shapePanel.Location = pt;
            this.axsXPanel.Location = pt;
            this.axsYPanel.Location = pt;

            Size sz = new Size(400, 360);
            this.generalPanel.Size = sz;
            this.userSerial.Size = sz;
            this.userTcp.Size = sz;
            this.areaPanel.Size = sz;
            this.gridPanel.Size = sz;
            this.lablePanel.Size = sz;
            this.linePanel.Size = sz; 
            this.plotPanel.Size = sz;
            this.shapePanel.Size = sz;
            this.axsXPanel.Size = sz;
            this.axsYPanel.Size = sz;        
        }


        /// <summary>
        /// 全てパネルを表示しない
        /// </summary>
        private void UnVisibleAllPanels()
        {
            this.generalPanel.Visible = false;
            this.userSerial.Visible = false;
            this.userTcp.Visible = false;
            this.areaPanel.Visible = false;
            this.gridPanel.Visible = false;
            this.lablePanel.Visible = false;
            this.linePanel.Visible = false;
            this.plotPanel.Visible = false;
            this.shapePanel.Visible = false;
            this.axsXPanel.Visible = false;
            this.axsYPanel.Visible = false;
         
        }
        #endregion


        #region 表示

        /// <summary>
        /// 選択まえに
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvOption_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (null == this.tvOption.SelectedNode)
            {
                return;
            }


            switch (this.tvOption.SelectedNode.Name)
            {
                // Root
                case ConfigTreeName.Main:
                case ConfigTreeName.General:
                    break;
                // LineIn
                case ConfigTreeName.Serial:
                    break;
                case ConfigTreeName.Tcp:
                    break;
                // Area
                case ConfigTreeName.Area:
                    break;
                // Grid
                case ConfigTreeName.Grid:
                    break;
                // Label
                case ConfigTreeName.Label:
                    break;
                // Line
                case ConfigTreeName.Line:
                    break;
                // Plot
                case ConfigTreeName.Plot:
                    //if (!this.gridPanel.CheckValid())
                    //{
                    //    e.Cancel = true;
                    //}
                    break;
                // Shape
                case ConfigTreeName.Shape:
                    break;
                // AxsX
                case ConfigTreeName.AxsX:
                    break;
                // AxsY
                case ConfigTreeName.AxsY:
                    break;
            }
        }

        /// <summary>
        /// ツリーのノードを選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvOption_AfterSelect(object sender, TreeViewEventArgs e)
        {

            this.UnVisibleAllPanels();
            //if (panel_Config.IsLoadNew)
            //{
            //    this.LoadAllControl();
            //    panel_Config.IsLoadNew = false;
            //}


            //this.lblTitle.Text = "カテゴリー";
            switch (e.Node.Name)
            {

                case ConfigTreeName.Main:
                case ConfigTreeName.General:
                    this.generalPanel.Visible = true;
                    break;

                case ConfigTreeName.Serial:
                    this.userSerial = new SerialUser();
                    this.Controls.Add(this.userSerial);
                    this.userSerial.Location= new Point(140, 0);
                    this.userSerial.Size = new Size(400, 360);
                    this.userSerial.Visible = true;
                    break;

                case ConfigTreeName.Tcp:
                    this.userTcp = new TcpUser();
                    this.Controls.Add(this.userTcp);
                    this.userTcp.Location = new Point(140, 0);
                    this.userTcp.Size = new Size(400, 360);
                    this.userTcp.Visible = true;
                    break;

                case ConfigTreeName.Area:
                    this.areaPanel.Visible = true;
                    break;

                case ConfigTreeName.Grid:
                    this.gridPanel.Visible = true;
                    break;

                case ConfigTreeName.Label:
                    this.lablePanel.Visible = true;
                    break;

                case ConfigTreeName.Line:
                    this.linePanel.Visible = true;
                    break;

                case ConfigTreeName.Plot:
                    this.plotPanel.Visible = true;
                    break;

                case ConfigTreeName.Shape:
                    this.shapePanel.Visible = true;
                    break;

                case ConfigTreeName.AxsX:
                    this.axsXPanel.Visible = true;
                    break;

                case ConfigTreeName.AxsY:
                    this.axsYPanel.Visible = true;
                    break;

                default:
                    break;
            }
        }

        private void tvOption_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (IsFirstNode(e.Node) || IsSecondNode(e.Node))
            {
                Color backColor, foreColor;
                if ((e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected)
                {
                    backColor = SystemColors.Highlight;
                    foreColor = SystemColors.HighlightText;
                }
                else if ((e.State & TreeNodeStates.Hot) == TreeNodeStates.Hot)
                {
                    backColor = SystemColors.HotTrack;
                    foreColor = SystemColors.HighlightText;
                }
                else
                {
                    backColor = e.Node.BackColor;
                    foreColor = e.Node.ForeColor;
                }

                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(brush, e.Node.Bounds);
                }

                TextRenderer.DrawText(e.Graphics, e.Node.Text, this.tvOption.Font, e.Node.Bounds, foreColor, backColor);
                e.DrawDefault = false;
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private static bool IsFirstNode(TreeNode node)
        {
            return false;
        }

        private static bool IsSecondNode(TreeNode node)
        {
            return false;
        }
        
        #endregion


        #region ボタンをクリック

        /// <summary>
        /// OK事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {

            // 更新UI数据到数据库和配置文件
            if (tvOption.SelectedNode.Name == ConfigTreeName.Serial)
            {
                this.userSerial.UpdateSetting(this._tabOnline);
            }
            else if (tvOption.SelectedNode.Name == ConfigTreeName.Tcp)
            {
                this.userSerial.UpdateSetting(this._tabOnline);
                this.userTcp.UpdateSetting(this._tabOnline);
            }
            Setting.Write();

            this.Close();

        }

        /// <summary>
        /// Cancel事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.SuppressFinalize(this);
            GC.Collect();
        }


        #endregion


    }
}
