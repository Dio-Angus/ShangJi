/*-----------------------------------------------------------------------------
//  FILE NAME       : IdTableView.cs
//  FUNCTION        : ID表浏览
//  AUTHOR          : 李锋(2009/05/13)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using ChromatoBll.bll;
using System.Collections;
using ChromatoTool.dto;

namespace ChromatoCore.solu.IdT
{
    /// <summary>
    /// ID表浏览
    /// </summary>
    public partial class IdTableMng : UserControl
    {

        #region 变量

        /// <summary>
        /// 参数Dao
        /// </summary>
        private IngredientBiz bizIngredient = null;

        /// <summary>
        /// 树节点
        /// </summary>
        private ArrayList _arrIdentity = null;

        /// <summary>
        /// 成分数据集合
        /// </summary>
        private DataSet _dsIdentity = null;

        #endregion


        #region 构造
        
        /// <summary>
        /// 构造
        /// </summary>
        public IdTableMng()
        {
            InitializeComponent();
            LoadEvent();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.dgvIdTable.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvIdTable_CellDoubleClick);
        }

        #endregion


        #region 装载树


        /// <summary>
        /// 装载树
        /// </summary>
        public void LoadTree()
        {

            bizIngredient = new IngredientBiz();
            this._arrIdentity = bizIngredient.LoadIdentity();
            if (null == _arrIdentity || 0 == _arrIdentity.Count)
            {
                return;
            }

            TreeNode rnItem = null;
            IngredientDto dto = null;
            this.tvIdentity.Nodes.Clear();

            for (int i = 0; i < _arrIdentity.Count; i++)
            {
                dto = (IngredientDto)_arrIdentity[i];
                if (null == this.FindNode(dto.IDTableID.ToString()))
                {
                    rnItem = new TreeNode();
                    rnItem.Text = dto.IDTableName;
                    rnItem.Name = dto.IDTableID.ToString();
                    this.tvIdentity.Nodes.Insert(0, rnItem);
                }
            }

            this.tvIdentity.SelectedNode = rnItem;
        }

        /// <summary>
        /// 查询树中节点
        /// </summary>
        private TreeNode FindNode(String nodeName)
        {
            TreeNode tnRet = null;
            foreach (TreeNode tn in this.tvIdentity.Nodes)
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
                //if (tnParent.Parent != null &&
                //    tnParent.Parent.Parent != null &&
                //    tnParent.Parent.Parent.Text.Equals("結果"))
                //{
                //    return tnParent;
                //}

            }

            TreeNode tnRet = null;

            foreach (TreeNode tn in tnParent.Nodes)
            {
                tnRet = FindNode(tn, strValue);

                if (tnRet != null) break;
            }
            return tnRet;
        }

        /// <summary>
        /// 选中树中节点
        /// </summary>
        private void SelectNodeToFocus(String nodeName)
        {
            TreeNode tnRet = null;
            foreach (TreeNode tn in this.tvIdentity.Nodes)
            {
                tnRet = this.FindNode(tn, nodeName);
                if (tnRet != null)
                {
                    this.tvIdentity.SelectedNode = tnRet;
                    break;
                }
            }
        }

        /// <summary>
        /// 节点选中后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvIdentity_AfterSelect(object sender, TreeViewEventArgs e)
        {

            e.Node.ForeColor = Color.White;
            e.Node.BackColor = Color.Black;

            IngredientDto dto = null;

            for(int i = 0; i< this._arrIdentity.Count; i++)
            {
                dto = (IngredientDto)_arrIdentity[i];
                if(e.Node.Name.Equals(dto.IDTableID.ToString()) )
                {
                    this._dsIdentity = this.bizIngredient.LoadIngredientByID(dto.IDTableID);
                    this.dgvIdTable.DataSource = this._dsIdentity.Tables[0];
                }
            }

        }

        /// <summary>
        /// 节点选中前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvIdentity_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (null == this.tvIdentity.SelectedNode)
            {
                return;
            }
            this.tvIdentity.SelectedNode.ForeColor = Color.Black;
            this.tvIdentity.SelectedNode.BackColor = Color.White;

        }

        #endregion


        #region 方法

        /// <summary>
        /// 改变大小
        /// </summary>
        public void CtrlResize()
        {
            this.dgvIdTable.Left = this.tvIdentity.Right + 2;
            this.dgvIdTable.Width = this.Width - this.btnNew.Width -this.tvIdentity.Width - 8;
            this.dgvIdTable.Height = this.tvIdentity.Height;
            this.btnNew.Left = this.dgvIdTable.Right + 2;
            this.btnRefresh.Left = this.dgvIdTable.Right + 2;
            this.btnDelete.Left = this.dgvIdTable.Right + 2;
        }

        /// <summary>
        /// 分割条移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitterTreeID_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.CtrlResize();
        }

        /// <summary>
        /// 刷新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadTree();
        }

        /// <summary>
        /// 双击单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIdTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex)
            {
                return;
            }

            this.ShowEditDlg();
        }

        /// <summary>
        /// 显示编辑窗口
        /// </summary>
        private void ShowEditDlg()
        {
            int ingreID = 0;
            IngredientDto dto = new IngredientDto();

            dto.IngredientID = 
                Convert.ToInt32(this.dgvIdTable.CurrentRow.Cells["IngredientID"].Value.ToString());

            for (int i = 0; i < this._dsIdentity.Tables[0].Rows.Count; i++)
            {
                ingreID =  Convert.ToInt32(this._dsIdentity.Tables[0].Rows[i]["IngredientID"].ToString());
                if ( ingreID.Equals( dto.IngredientID) )
                {
                    DataTable dt = this._dsIdentity.Tables[0];

                    dto.IDTableID = Convert.ToInt32(dt.Rows[i]["IDTableID"].ToString());
                    dto.IDTableName = dt.Rows[i]["IDTableName"].ToString();
                    dto.IngredientName = dt.Rows[i]["IngredientName"].ToString();
                    dto.ReserveTime = Convert.ToSingle(dt.Rows[i]["ReserveTime"].ToString());
                    dto.TimeBand = Convert.ToSingle(dt.Rows[i]["TimeBand"].ToString());
                    dto.IsInnerPeak = Convert.ToBoolean(dt.Rows[i]["IsInnerPeak"].ToString());
                }
            }

            IngredientFrm frmEdit = new IngredientFrm(dto);
            frmEdit.ShowDialog();

            // 刷新grid
            this._dsIdentity = this.bizIngredient.LoadIngredientByID(dto.IDTableID);
            this.dgvIdTable.DataSource = this._dsIdentity.Tables[0];

        }

        #endregion


    }
}
