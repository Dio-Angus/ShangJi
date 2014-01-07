/*-----------------------------------------------------------------------------
//  FILE NAME       : TimeProcView.cs
//  FUNCTION        : 时间程序浏览
//  AUTHOR          : 李锋(2009/05/20)
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
using System.Collections;
using ChromatoTool.ini;
using ChromatoTool.util;

namespace ChromatoCore.solu.Tp
{
    /// <summary>
    /// 时间程序浏览
    /// </summary>
    public partial class TimeProcMng : UserControl
    {

        #region 变量

        /// <summary>
        /// 参数Dao
        /// </summary>
        private TimeProcBiz bizTimeProc = null;

        /// <summary>
        /// 树节点
        /// </summary>
        private ArrayList _arrTimeProc = null;

        /// <summary>
        /// 时间程序数据集合
        /// </summary>
        private DataSet _dsTimeProc = null;

        /// <summary>
        /// 当前选中的dto
        /// </summary>
        private TimeProcDto dto = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public TimeProcMng()
        {
            InitializeComponent();
            LoadEvent();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.dgvTimeProc.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvTimeProc_CellDoubleClick);
            this.dgvTimeProc.CellClick += new DataGridViewCellEventHandler(this.dgvTimeProc_CellClick);
            this.splitterTreeID.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitterTreeID_SplitterMoved);
            this.dgvTimeProc.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvTimeProc_ColumnHeaderMouseClick);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
        }
        
        #endregion


        #region 装载树


        /// <summary>
        /// 装载树
        /// </summary>
        public void LoadTree()
        {

            bizTimeProc = new TimeProcBiz();
            this.dto = new TimeProcDto();
            this.tvTimeProc.Nodes.Clear();

            this._arrTimeProc = bizTimeProc.LoadTimeProc();
            if (null == _arrTimeProc || 0 == _arrTimeProc.Count)
            {
                this._dsTimeProc = this.bizTimeProc.LoadTimeProcByID(dto);
                this.dgvTimeProc.DataSource = this._dsTimeProc.Tables[0];
                return;
            }

            TreeNode rnItem = null;

            for (int i = 0; i < _arrTimeProc.Count; i++)
            {
                dto = (TimeProcDto)_arrTimeProc[i];
                //if (null == this.FindNode(dto.TPid.ToString()))
                //{
                    rnItem = new TreeNode();
                    rnItem.Text = dto.TPName;
                    rnItem.Name = dto.TPid.ToString();
                    this.tvTimeProc.Nodes.Add(rnItem);
                //}
            }

            this.tvTimeProc.SelectedNode = rnItem;
        }

        /// <summary>
        /// 查询树中节点
        /// </summary>
        private TreeNode FindNode(String nodeName)
        {
            TreeNode tnRet = null;
            foreach (TreeNode tn in this.tvTimeProc.Nodes)
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

        /// <summary>
        /// 选中树中节点
        /// </summary>
        private void SelectNodeToFocus(String nodeName)
        {
            TreeNode tnRet = null;
            foreach (TreeNode tn in this.tvTimeProc.Nodes)
            {
                tnRet = this.FindNode(tn, nodeName);
                if (tnRet != null)
                {
                    this.tvTimeProc.SelectedNode = tnRet;
                    break;
                }
            }
        }

        /// <summary>
        /// 节点选中后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvTimeProc_AfterSelect(object sender, TreeViewEventArgs e)
        {

            e.Node.ForeColor = Color.White;
            e.Node.BackColor = Color.Black;

            this.FreshDgv(e.Node.Name);
        }

        /// <summary>
        /// 更新datagrid
        /// </summary>
        private void FreshDgv(String tpID)
        {
            for (int i = 0; i < this._arrTimeProc.Count; i++)
            {
                dto = (TimeProcDto)_arrTimeProc[i];
                if (tpID.Equals(dto.TPid.ToString()))
                {
                    this._dsTimeProc = this.bizTimeProc.LoadTimeProcByID(dto);
                    this.dgvTimeProc.DataSource = this._dsTimeProc.Tables[0];
                    this.dto.SerialID = Convert.ToInt32(
                        this._dsTimeProc.Tables[0].Rows[0]["SerialID"].ToString());
                    break;
                }
            }
        }

        /// <summary>
        /// 节点选中前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvTimeProc_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (null == this.tvTimeProc.SelectedNode)
            {
                return;
            }
            this.tvTimeProc.SelectedNode.ForeColor = Color.Black;
            this.tvTimeProc.SelectedNode.BackColor = Color.White;
        }

        #endregion


        #region 方法

        /// <summary>
        /// 改变大小
        /// </summary>
        public void CtrlResize()
        {
            this.dgvTimeProc.Left = this.tvTimeProc.Right + 2;
            this.dgvTimeProc.Width = this.Width - this.btnNew.Width - this.tvTimeProc.Width - 8;
            this.dgvTimeProc.Height = this.tvTimeProc.Height;
            this.btnNew.Left = this.dgvTimeProc.Right + 2;
            this.btnRefresh.Left = this.dgvTimeProc.Right + 2;
            this.btnDelete.Left = this.dgvTimeProc.Right + 2;
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
        private void dgvTimeProc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex)
            {
                return;
            }

            this.ShowEditDlg();
        }

        /// <summary>
        /// 单击单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTimeProc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex)
            {
                return;
            }

            this.dto.SerialID = Convert.ToInt32(
                this.dgvTimeProc.CurrentRow.Cells["SerialID"].Value.ToString());
        }

        /// <summary>
        /// 显示编辑窗口
        /// </summary>
        private void ShowEditDlg()
        {
            String serialID = "";

            dto.TPid = Convert.ToInt32(this.tvTimeProc.SelectedNode.Name);
            dto.TPName = this.tvTimeProc.SelectedNode.Text;

            dto.SerialID =
                Convert.ToInt32(this.dgvTimeProc.CurrentRow.Cells["SerialID"].Value.ToString());

            for (int i = 0; i < this._dsTimeProc.Tables[0].Rows.Count; i++)
            {
                serialID = this._dsTimeProc.Tables[0].Rows[i]["SerialID"].ToString();
                if (serialID.Equals(dto.SerialID.ToString()))
                {
                    DataTable dt = this._dsTimeProc.Tables[0];

                    dto.ActionName = dt.Rows[i]["ActionName"].ToString();
                    dto.TpValue = Convert.ToInt32(dt.Rows[i]["TpValue"].ToString());
                    dto.StartTime = Convert.ToSingle(dt.Rows[i]["StartTime"].ToString());
                    dto.StopTime = Convert.ToSingle(dt.Rows[i]["StopTime"].ToString());
                }
            }

            TimeProcEditFrm frmEdit = new TimeProcEditFrm(dto);
            if (DialogResult.OK == frmEdit.ShowDialog())
            {
                this.bizTimeProc.UpdateTimeProc(dto);
                // 刷新grid
                this._dsTimeProc = this.bizTimeProc.LoadTimeProcByID(dto);
                this.dgvTimeProc.DataSource = this._dsTimeProc.Tables[0];
                this.UpdateSelectedRow();
            }

        }

        /// <summary>
        /// 更新选中行
        /// </summary>
        private void UpdateSelectedRow()
        {
            if (null == this.dgvTimeProc.CurrentRow)
            {
                MessageBox.Show("没有选中时间程序！", "警告");
                return;
            }

            int serialID = 0;
            for (int i = 0; i < this._dsTimeProc.Tables[0].Rows.Count; i++)
            {
                serialID = Convert.ToInt32(this.dgvTimeProc["SerialID", i].Value.ToString());
                if (serialID == this.dto.SerialID)
                {
                    // clear datagridview selection
                    this.dgvTimeProc.ClearSelection();
                    // select new row
                    this.dgvTimeProc["SerialID", i].Selected = true;
                    break;
                }
            }
        }

        /// <summary>
        /// 标题栏按下的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTimeProc_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.UpdateSelectedRow();
        }

        /// <summary>
        /// 时间程序删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (null == this.dgvTimeProc.CurrentRow)
            {
                MessageBox.Show("没有时间程序！", "警告");
                return;
            }
            if (DialogResult.OK == MessageBox.Show("确认删除该时间程序吗？", "警告", MessageBoxButtons.OKCancel))
            {
                this.dto.TPid = Convert.ToInt32(this.tvTimeProc.SelectedNode.Name);
                this.dto.SerialID = Convert.ToInt32(
                    this.dgvTimeProc.CurrentRow.Cells["SerialID"].Value.ToString());
                this.bizTimeProc.DeleteSerial(this.dto);
                this.btnRefresh_Click(null, null);
            }
        }

        /// <summary>
        /// 新建时间程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (null == this.tvTimeProc.SelectedNode)
            {
                MessageBox.Show("没有时间程序节点！", "警告");
                return;
            }

            TimeProcDto newDto = new TimeProcDto();
            newDto.ActionName = EnumDescription.GetFieldText(TimeProcType.PeakWide);
            newDto.TpValue = 1;
            newDto.StartTime = Convert.ToSingle(1.5);
            newDto.StopTime = Convert.ToSingle(2.0);
            newDto.TPName = this.tvTimeProc.SelectedNode.Text;
            newDto.TPid = Convert.ToInt32(this.tvTimeProc.SelectedNode.Name);

            //TimeProcNewFrm frmNew = new TimeProcNewFrm(newDto);

            //if (DialogResult.OK == frmNew.ShowDialog())
            //{
            //    newDto.SerialID = this.bizTimeProc.GetNewSerialID(newDto);
            //    this.bizTimeProc.InsertMethod(newDto);
            //    this.FreshDgv(this.tvTimeProc.SelectedNode.Name);
            //    this.dto = newDto;
            //    this.UpdateSelectedRow();

            //}
        }

        #endregion


        #region 右键菜单

        /// <summary>
        /// 新建节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsNew_Click(object sender, EventArgs e)
        {
            TimeProcDto newDto = new TimeProcDto();
            newDto.ActionName = EnumDescription.GetFieldText(TimeProcType.PeakWide);
            newDto.TpValue = 1;
            newDto.StartTime = Convert.ToSingle( 1.5 );
            newDto.StopTime =  Convert.ToSingle( 2.0 );
            newDto.TPName = "新建" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //TimeProcNewFrm frmNew = new TimeProcNewFrm(newDto);

            //if (DialogResult.OK == frmNew.ShowDialog())
            //{
            //    newDto.TPid = this.bizTimeProc.GetNewTimeProcID();
            //    newDto.SerialID = this.bizTimeProc.GetNewSerialID(newDto);
            //    this.bizTimeProc.InsertMethod(newDto);
            //    this.LoadTree();
            //}
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDelete_Click(object sender, EventArgs e)
        {
            if (null == this.tvTimeProc.SelectedNode)
            {
                MessageBox.Show("没有时间程序节点！", "警告");
                return;
            }
            if (DialogResult.OK == MessageBox.Show("确认删除该时间程序吗？", "警告", MessageBoxButtons.OKCancel))
            {
                this.dto.TPid = Convert.ToInt32(this.tvTimeProc.SelectedNode.Name);
                this.bizTimeProc.DeleteTimeProc(this.dto);
                this.LoadTree();
            }
        }

        /// <summary>
        /// 菜单项目是否使用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvTimeProc_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }
            if (null == this.tvTimeProc.SelectedNode)
            {
                this.tsDelete.Enabled = false;
                this.tsRename.Enabled = false;
            }
            else
            {
                this.tsDelete.Enabled = true;
                this.tsRename.Enabled = true;
            }
        }

        /// <summary>
        /// 重新命名节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsRename_Click(object sender, EventArgs e)
        {
            this.tvTimeProc.LabelEdit = true;
            if (!this.tvTimeProc.SelectedNode.IsEditing)
            {
                this.tvTimeProc.SelectedNode.BeginEdit();
            }
        }

        /// <summary>
        /// 提取重新命名内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvTimeProc_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null)
            {
                return;
            }

            if (e.Label.Length > 0)
            {
                if (e.Label.IndexOfAny(new char[] { '@', '.', ',', '!' }) == -1)
                {
                    if (e.Label.Length > 30)
                    {
                        /* Cancel the label edit action, inform the user, and 
                           place the node in edit mode again. */
                        e.CancelEdit = true;
                        MessageBox.Show("名字太长.\n" +
                           "名字不能超过30",
                           "编辑名");
                        e.Node.BeginEdit();
                    }
                    else
                    {
                        // Stop editing without canceling the label change.
                        e.Node.EndEdit(false);

                        this.dto.TPid = Convert.ToInt32(this.tvTimeProc.SelectedNode.Name);
                        this.dto.TPName = e.Label;
                        this.bizTimeProc.UpdateTPName(this.dto);
                        this.FreshDgv(this.tvTimeProc.SelectedNode.Name);

                    }
                }
                else
                {
                    /* Cancel the label edit action, inform the user, and 
                       place the node in edit mode again. */
                    e.CancelEdit = true;
                    MessageBox.Show("非法节点名.\n" +
                       "非法字符: '@','.', ',', '!'",
                       "编辑名");
                    e.Node.BeginEdit();
                }
            }
            else
            {
                /* Cancel the label edit action, inform the user, and 
                   place the node in edit mode again. */
                e.CancelEdit = true;
                MessageBox.Show("非法节点名.\n名字不能为空",
                   "编辑名");
                e.Node.BeginEdit();
            }
            this.tvTimeProc.LabelEdit = false;

        }
        #endregion








    }
}
