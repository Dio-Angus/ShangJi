/*-----------------------------------------------------------------------------
//  FILE NAME       : TestGasFrm.cs
//  FUNCTION        : 自动色谱测试视图
//  AUTHOR          : 李锋(2010/11/15)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.ini;

namespace TestGas
{
    /// <summary>
    /// 自动色谱测试视图
    /// </summary>
    public partial class TestGasFrm : Form
    {


        #region 变量

        private RegUser userReg = null;
        private StartUser userStart = null;
        private ResultUser userResult = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public TestGasFrm()
        {
            InitializeComponent();
            AddPanel();
            this.Load += new System.EventHandler(this.frmTestGas_Load);
            this.tvOption.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOption_AfterSelect);
            this.tvOption.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvOption_BeforeSelect);

        }

        /// <summary>
        /// パネルを追加
        /// </summary>
        private void AddPanel()
        {
            this.userReg = new RegUser();
            this.userStart = new StartUser();
            this.userResult = new ResultUser();

            //add all panel to Main Control
            this.Controls.Add(this.userReg);
            this.Controls.Add(this.userStart);
            this.Controls.Add(this.userResult);
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTestGas_Load(object sender, EventArgs e)
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
            TreeNode rnReg = new TreeNode();
            TreeNode rnStart = new TreeNode();
            TreeNode rnResult = new TreeNode();

            //親ノードのテキストを作成 
            //first level 
            rnMain.Text = AutoChromatoTreeName.Main;
            rnMain.Name = AutoChromatoTreeName.Main;

            // second level
            rnReg.Text = AutoChromatoTreeName.Reg;
            rnReg.Name = AutoChromatoTreeName.Reg;

            rnStart.Text = AutoChromatoTreeName.Start;
            rnStart.Name = AutoChromatoTreeName.Start;

            rnResult.Text = AutoChromatoTreeName.Result;
            rnResult.Name = AutoChromatoTreeName.Result;

            rnMain.Nodes.Add(rnReg);
            rnMain.Nodes.Add(rnStart);
            rnMain.Nodes.Add(rnResult);

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
            this.userReg.Location = pt;
            this.userStart.Location = pt;
            this.userResult.Location = pt;

            Size sz = new Size(400, 285);
            this.userReg.Size = sz;
            this.userStart.Size = sz;
            this.userResult.Size = sz;
        }


        /// <summary>
        /// 全てパネルを表示しない
        /// </summary>
        private void UnVisibleAllPanels()
        {
            this.userReg.Visible = false;
            this.userStart.Visible = false;
            this.userResult.Visible = false;
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
                case AutoChromatoTreeName.Main:
                case AutoChromatoTreeName.Reg:
                    break;
                // LineIn
                case AutoChromatoTreeName.Start:
                    break;
                // Area
                case AutoChromatoTreeName.Result:
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

            switch (e.Node.Name)
            {

                case AutoChromatoTreeName.Main:
                case AutoChromatoTreeName.Reg:
                    this.userReg.Visible = true;
                    break;

                case AutoChromatoTreeName.Start:
                    this.userStart.Visible = true;
                    break;

                case AutoChromatoTreeName.Result:
                    this.userResult.Visible = true;
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

    }
}
