namespace ChromatoCore.solu.IdT
{
    partial class IdTableMng
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvIdTable = new System.Windows.Forms.DataGridView();
            this.IDTableID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReserveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeBand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeWindow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsInnerPeak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tvIdentity = new System.Windows.Forms.TreeView();
            this.splitterTreeID = new System.Windows.Forms.Splitter();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdTable)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(452, 53);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(70, 23);
            this.btnRefresh.TabIndex = 41;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNew
            // 
            this.btnNew.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(452, 1);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(70, 23);
            this.btnNew.TabIndex = 40;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // dgvIdTable
            // 
            this.dgvIdTable.AllowUserToAddRows = false;
            this.dgvIdTable.AllowUserToDeleteRows = false;
            this.dgvIdTable.AllowUserToResizeRows = false;
            this.dgvIdTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvIdTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIdTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDTableID,
            this.IDTableName,
            this.IngredientID,
            this.ReserveTime,
            this.IngredientName,
            this.TimeBand,
            this.TimeWindow,
            this.IsInnerPeak});
            this.dgvIdTable.Location = new System.Drawing.Point(80, 0);
            this.dgvIdTable.MultiSelect = false;
            this.dgvIdTable.Name = "dgvIdTable";
            this.dgvIdTable.ReadOnly = true;
            this.dgvIdTable.RowHeadersVisible = false;
            this.dgvIdTable.RowTemplate.Height = 23;
            this.dgvIdTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIdTable.Size = new System.Drawing.Size(366, 317);
            this.dgvIdTable.TabIndex = 39;
            // 
            // IDTableID
            // 
            this.IDTableID.DataPropertyName = "IDTableID";
            this.IDTableID.HeaderText = "ID表ID";
            this.IDTableID.Name = "IDTableID";
            this.IDTableID.ReadOnly = true;
            this.IDTableID.Visible = false;
            // 
            // IDTableName
            // 
            this.IDTableName.DataPropertyName = "IDTableName";
            this.IDTableName.HeaderText = "ID表名";
            this.IDTableName.Name = "IDTableName";
            this.IDTableName.ReadOnly = true;
            this.IDTableName.Visible = false;
            // 
            // IngredientID
            // 
            this.IngredientID.DataPropertyName = "IngredientID";
            this.IngredientID.FillWeight = 120F;
            this.IngredientID.HeaderText = "成分ID";
            this.IngredientID.Name = "IngredientID";
            this.IngredientID.ReadOnly = true;
            this.IngredientID.Width = 120;
            // 
            // ReserveTime
            // 
            this.ReserveTime.DataPropertyName = "ReserveTime";
            this.ReserveTime.HeaderText = "保留时间";
            this.ReserveTime.Name = "ReserveTime";
            this.ReserveTime.ReadOnly = true;
            // 
            // IngredientName
            // 
            this.IngredientName.DataPropertyName = "IngredientName";
            this.IngredientName.FillWeight = 200F;
            this.IngredientName.HeaderText = "组分名";
            this.IngredientName.Name = "IngredientName";
            this.IngredientName.ReadOnly = true;
            this.IngredientName.Width = 200;
            // 
            // TimeBand
            // 
            this.TimeBand.DataPropertyName = "TimeBand";
            this.TimeBand.HeaderText = "时间带";
            this.TimeBand.Name = "TimeBand";
            this.TimeBand.ReadOnly = true;
            // 
            // TimeWindow
            // 
            this.TimeWindow.DataPropertyName = "TimeWindow";
            this.TimeWindow.HeaderText = "时间窗";
            this.TimeWindow.Name = "TimeWindow";
            this.TimeWindow.ReadOnly = true;
            // 
            // IsInnerPeak
            // 
            this.IsInnerPeak.DataPropertyName = "IsInnerPeak";
            this.IsInnerPeak.HeaderText = "是否内标峰";
            this.IsInnerPeak.Name = "IsInnerPeak";
            this.IsInnerPeak.ReadOnly = true;
            this.IsInnerPeak.Visible = false;
            // 
            // tvIdentity
            // 
            this.tvIdentity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvIdentity.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvIdentity.Location = new System.Drawing.Point(0, 0);
            this.tvIdentity.Name = "tvIdentity";
            this.tvIdentity.Size = new System.Drawing.Size(74, 315);
            this.tvIdentity.TabIndex = 42;
            this.tvIdentity.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvIdentity_AfterSelect);
            this.tvIdentity.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvIdentity_BeforeSelect);
            // 
            // splitterTreeID
            // 
            this.splitterTreeID.Location = new System.Drawing.Point(74, 0);
            this.splitterTreeID.Name = "splitterTreeID";
            this.splitterTreeID.Size = new System.Drawing.Size(3, 315);
            this.splitterTreeID.TabIndex = 43;
            this.splitterTreeID.TabStop = false;
            this.splitterTreeID.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitterTreeID_SplitterMoved);
            // 
            // btnDelete
            // 
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(452, 26);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 23);
            this.btnDelete.TabIndex = 44;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // IdTableViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.splitterTreeID);
            this.Controls.Add(this.tvIdentity);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvIdTable);
            this.Name = "IdTableViewer";
            this.Size = new System.Drawing.Size(523, 315);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgvIdTable;
        private System.Windows.Forms.TreeView tvIdentity;
        private System.Windows.Forms.Splitter splitterTreeID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDTableID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReserveTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeBand;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeWindow;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsInnerPeak;
    }
}
