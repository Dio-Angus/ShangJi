namespace ChromatoCore.solu.Tp
{
    partial class TimeProcMng
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvTimeProc = new System.Windows.Forms.DataGridView();
            this.TPid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TpValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tvTimeProc = new System.Windows.Forms.TreeView();
            this.ctxMenuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRename = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.splitterTreeID = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeProc)).BeginInit();
            this.ctxMenuTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(425, 29);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 23);
            this.btnDelete.TabIndex = 43;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(425, 56);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(70, 23);
            this.btnRefresh.TabIndex = 42;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(425, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(70, 23);
            this.btnNew.TabIndex = 41;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // dgvTimeProc
            // 
            this.dgvTimeProc.AllowUserToAddRows = false;
            this.dgvTimeProc.AllowUserToDeleteRows = false;
            this.dgvTimeProc.AllowUserToResizeRows = false;
            this.dgvTimeProc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTimeProc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeProc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TPid,
            this.TPName,
            this.SerialID,
            this.ActionName,
            this.TpValue,
            this.StartTime,
            this.StopTime});
            this.dgvTimeProc.Location = new System.Drawing.Point(80, 0);
            this.dgvTimeProc.MultiSelect = false;
            this.dgvTimeProc.Name = "dgvTimeProc";
            this.dgvTimeProc.ReadOnly = true;
            this.dgvTimeProc.RowHeadersVisible = false;
            this.dgvTimeProc.RowHeadersWidth = 35;
            this.dgvTimeProc.RowTemplate.Height = 23;
            this.dgvTimeProc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimeProc.Size = new System.Drawing.Size(339, 248);
            this.dgvTimeProc.TabIndex = 40;
            // 
            // TPid
            // 
            this.TPid.DataPropertyName = "TPid";
            this.TPid.HeaderText = "时间程序ID";
            this.TPid.Name = "TPid";
            this.TPid.ReadOnly = true;
            this.TPid.Visible = false;
            // 
            // TPName
            // 
            this.TPName.DataPropertyName = "TPName";
            this.TPName.HeaderText = "时间程序名";
            this.TPName.Name = "TPName";
            this.TPName.ReadOnly = true;
            this.TPName.Visible = false;
            // 
            // SerialID
            // 
            this.SerialID.DataPropertyName = "SerialID";
            this.SerialID.FillWeight = 80F;
            this.SerialID.HeaderText = "序列号ID";
            this.SerialID.Name = "SerialID";
            this.SerialID.ReadOnly = true;
            this.SerialID.Width = 80;
            // 
            // ActionName
            // 
            this.ActionName.DataPropertyName = "ActionName";
            this.ActionName.HeaderText = "动作名";
            this.ActionName.Name = "ActionName";
            this.ActionName.ReadOnly = true;
            // 
            // TpValue
            // 
            this.TpValue.DataPropertyName = "TpValue";
            this.TpValue.HeaderText = "动作值";
            this.TpValue.Name = "TpValue";
            this.TpValue.ReadOnly = true;
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "开始时间";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // StopTime
            // 
            this.StopTime.DataPropertyName = "StopTime";
            this.StopTime.HeaderText = "结束时间";
            this.StopTime.Name = "StopTime";
            this.StopTime.ReadOnly = true;
            // 
            // tvTimeProc
            // 
            this.tvTimeProc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvTimeProc.ContextMenuStrip = this.ctxMenuTree;
            this.tvTimeProc.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvTimeProc.Location = new System.Drawing.Point(0, 0);
            this.tvTimeProc.Name = "tvTimeProc";
            this.tvTimeProc.Size = new System.Drawing.Size(74, 246);
            this.tvTimeProc.TabIndex = 44;
            this.tvTimeProc.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvTimeProc_AfterLabelEdit);
            this.tvTimeProc.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTimeProc_AfterSelect);
            this.tvTimeProc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvTimeProc_MouseDown);
            this.tvTimeProc.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvTimeProc_BeforeSelect);
            // 
            // ctxMenuTree
            // 
            this.ctxMenuTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNew,
            this.tsRename,
            this.tsDelete});
            this.ctxMenuTree.Name = "ctxMenuTree";
            this.ctxMenuTree.Size = new System.Drawing.Size(107, 70);
            // 
            // tsNew
            // 
            this.tsNew.Name = "tsNew";
            this.tsNew.Size = new System.Drawing.Size(106, 22);
            this.tsNew.Text = "新建";
            this.tsNew.Click += new System.EventHandler(this.tsNew_Click);
            // 
            // tsRename
            // 
            this.tsRename.Name = "tsRename";
            this.tsRename.Size = new System.Drawing.Size(106, 22);
            this.tsRename.Text = "重命名";
            this.tsRename.Click += new System.EventHandler(this.tsRename_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(106, 22);
            this.tsDelete.Text = "删除";
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // splitterTreeID
            // 
            this.splitterTreeID.Location = new System.Drawing.Point(74, 0);
            this.splitterTreeID.Name = "splitterTreeID";
            this.splitterTreeID.Size = new System.Drawing.Size(3, 246);
            this.splitterTreeID.TabIndex = 45;
            this.splitterTreeID.TabStop = false;
            // 
            // TimeProcViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitterTreeID);
            this.Controls.Add(this.tvTimeProc);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvTimeProc);
            this.Name = "TimeProcViewer";
            this.Size = new System.Drawing.Size(499, 246);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeProc)).EndInit();
            this.ctxMenuTree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgvTimeProc;
        private System.Windows.Forms.TreeView tvTimeProc;
        private System.Windows.Forms.Splitter splitterTreeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TPid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TPName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TpValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StopTime;
        private System.Windows.Forms.ContextMenuStrip ctxMenuTree;
        private System.Windows.Forms.ToolStripMenuItem tsNew;
        private System.Windows.Forms.ToolStripMenuItem tsRename;
        private System.Windows.Forms.ToolStripMenuItem tsDelete;
    }
}
