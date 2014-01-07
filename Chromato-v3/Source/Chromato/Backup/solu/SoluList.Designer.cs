namespace ChromatoCore.solu
{
    partial class SoluList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSolution = new System.Windows.Forms.DataGridView();
            this.SolutionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisterTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SolutionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnalyParaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AntiMethodID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDTableID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeProcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsUseTimeProc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.gbQuery = new System.Windows.Forms.GroupBox();
            this.dtPickerQuery = new System.Windows.Forms.DateTimePicker();
            this.dtPickerQueryEndDay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxQuery = new System.Windows.Forms.ComboBox();
            this.tsSolution = new System.Windows.Forms.ToolStrip();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRegNew = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolution)).BeginInit();
            this.ctxMenu.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.gbQuery.SuspendLayout();
            this.tsSolution.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSolution
            // 
            this.dgvSolution.AllowUserToAddRows = false;
            this.dgvSolution.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvSolution.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            this.dgvSolution.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSolution.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSolution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolution.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SolutionID,
            this.RegisterTime,
            this.SolutionName,
            this.AnalyParaID,
            this.AntiMethodID,
            this.IDTableID,
            this.TimeProcID,
            this.CollectionID,
            this.IsUseTimeProc,
            this.Remark});
            this.dgvSolution.ContextMenuStrip = this.ctxMenu;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSolution.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSolution.Location = new System.Drawing.Point(0, 0);
            this.dgvSolution.MultiSelect = false;
            this.dgvSolution.Name = "dgvSolution";
            this.dgvSolution.ReadOnly = true;
            this.dgvSolution.RowHeadersVisible = false;
            this.dgvSolution.RowHeadersWidth = 15;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvSolution.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSolution.RowTemplate.Height = 23;
            this.dgvSolution.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSolution.Size = new System.Drawing.Size(683, 160);
            this.dgvSolution.TabIndex = 3;
            // 
            // SolutionID
            // 
            this.SolutionID.DataPropertyName = "SolutionID";
            this.SolutionID.FillWeight = 80F;
            this.SolutionID.HeaderText = "方案ID";
            this.SolutionID.Name = "SolutionID";
            this.SolutionID.ReadOnly = true;
            this.SolutionID.Width = 80;
            // 
            // RegisterTime
            // 
            this.RegisterTime.DataPropertyName = "RegisterTime";
            this.RegisterTime.HeaderText = "注册时间";
            this.RegisterTime.Name = "RegisterTime";
            this.RegisterTime.ReadOnly = true;
            // 
            // SolutionName
            // 
            this.SolutionName.DataPropertyName = "SolutionName";
            this.SolutionName.FillWeight = 200F;
            this.SolutionName.HeaderText = "方案名";
            this.SolutionName.Name = "SolutionName";
            this.SolutionName.ReadOnly = true;
            this.SolutionName.Width = 200;
            // 
            // AnalyParaID
            // 
            this.AnalyParaID.DataPropertyName = "AnalyParaID";
            this.AnalyParaID.HeaderText = "分析方法ID";
            this.AnalyParaID.Name = "AnalyParaID";
            this.AnalyParaID.ReadOnly = true;
            this.AnalyParaID.Visible = false;
            // 
            // AntiMethodID
            // 
            this.AntiMethodID.DataPropertyName = "AntiMethodID";
            this.AntiMethodID.HeaderText = "反控方法ID";
            this.AntiMethodID.Name = "AntiMethodID";
            this.AntiMethodID.ReadOnly = true;
            this.AntiMethodID.Visible = false;
            // 
            // IDTableID
            // 
            this.IDTableID.DataPropertyName = "IDTableID";
            this.IDTableID.HeaderText = "ID表ID";
            this.IDTableID.Name = "IDTableID";
            this.IDTableID.ReadOnly = true;
            this.IDTableID.Visible = false;
            // 
            // TimeProcID
            // 
            this.TimeProcID.DataPropertyName = "TimeProcID";
            this.TimeProcID.HeaderText = "时间程序ID";
            this.TimeProcID.Name = "TimeProcID";
            this.TimeProcID.ReadOnly = true;
            this.TimeProcID.Visible = false;
            // 
            // CollectionID
            // 
            this.CollectionID.DataPropertyName = "CollectionID";
            this.CollectionID.HeaderText = "采集方法ID";
            this.CollectionID.Name = "CollectionID";
            this.CollectionID.ReadOnly = true;
            this.CollectionID.Visible = false;
            // 
            // IsUseTimeProc
            // 
            this.IsUseTimeProc.DataPropertyName = "IsUseTimeProc";
            this.IsUseTimeProc.HeaderText = "使用时间程序";
            this.IsUseTimeProc.Name = "IsUseTimeProc";
            this.IsUseTimeProc.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Visible = false;
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRefresh,
            this.tsDelete});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(95, 48);
            // 
            // tsRefresh
            // 
            this.tsRefresh.Name = "tsRefresh";
            this.tsRefresh.Size = new System.Drawing.Size(94, 22);
            this.tsRefresh.Text = "刷新";
            this.tsRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(94, 22);
            this.tsDelete.Text = "删除";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.gbQuery);
            this.splitContainerMain.Panel1.Controls.Add(this.tsSolution);
            this.splitContainerMain.Panel1MinSize = 50;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.dgvSolution);
            this.splitContainerMain.Panel2MinSize = 50;
            this.splitContainerMain.Size = new System.Drawing.Size(683, 214);
            this.splitContainerMain.TabIndex = 7;
            // 
            // gbQuery
            // 
            this.gbQuery.Controls.Add(this.dtPickerQuery);
            this.gbQuery.Controls.Add(this.dtPickerQueryEndDay);
            this.gbQuery.Controls.Add(this.label1);
            this.gbQuery.Controls.Add(this.cbxQuery);
            this.gbQuery.Location = new System.Drawing.Point(3, 0);
            this.gbQuery.Name = "gbQuery";
            this.gbQuery.Size = new System.Drawing.Size(417, 44);
            this.gbQuery.TabIndex = 8;
            this.gbQuery.TabStop = false;
            // 
            // dtPickerQuery
            // 
            this.dtPickerQuery.Location = new System.Drawing.Point(171, 12);
            this.dtPickerQuery.Name = "dtPickerQuery";
            this.dtPickerQuery.Size = new System.Drawing.Size(119, 19);
            this.dtPickerQuery.TabIndex = 6;
            // 
            // dtPickerQueryEndDay
            // 
            this.dtPickerQueryEndDay.Location = new System.Drawing.Point(294, 12);
            this.dtPickerQueryEndDay.Name = "dtPickerQueryEndDay";
            this.dtPickerQueryEndDay.Size = new System.Drawing.Size(119, 19);
            this.dtPickerQueryEndDay.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "方案查询:";
            // 
            // cbxQuery
            // 
            this.cbxQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQuery.FormattingEnabled = true;
            this.cbxQuery.Items.AddRange(new object[] {
            "指定日",
            "指定开始日",
            "最近两周",
            "全部"});
            this.cbxQuery.Location = new System.Drawing.Point(71, 13);
            this.cbxQuery.Name = "cbxQuery";
            this.cbxQuery.Size = new System.Drawing.Size(96, 20);
            this.cbxQuery.TabIndex = 0;
            // 
            // tsSolution
            // 
            this.tsSolution.BackColor = System.Drawing.SystemColors.Info;
            this.tsSolution.Dock = System.Windows.Forms.DockStyle.None;
            this.tsSolution.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsSolution.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnRefresh,
            this.tsBtnRegNew,
            this.tsBtnEdit,
            this.tsBtnSaveAs,
            this.tsBtnDelete,
            this.toolStripSeparator1});
            this.tsSolution.Location = new System.Drawing.Point(423, 5);
            this.tsSolution.Name = "tsSolution";
            this.tsSolution.Size = new System.Drawing.Size(229, 39);
            this.tsSolution.TabIndex = 7;
            this.tsSolution.Text = "toolStrip1";
            // 
            // tsBtnRefresh
            // 
            this.tsBtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnRefresh.Image = global::ChromatoCore.Properties.Resources.refresh;
            this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefresh.Name = "tsBtnRefresh";
            this.tsBtnRefresh.Size = new System.Drawing.Size(36, 36);
            this.tsBtnRefresh.Text = "刷新";
            // 
            // tsBtnRegNew
            // 
            this.tsBtnRegNew.BackColor = System.Drawing.SystemColors.Info;
            this.tsBtnRegNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnRegNew.Image = global::ChromatoCore.Properties.Resources.regnew;
            this.tsBtnRegNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRegNew.Name = "tsBtnRegNew";
            this.tsBtnRegNew.Size = new System.Drawing.Size(36, 36);
            this.tsBtnRegNew.Text = "注册";
            // 
            // tsBtnEdit
            // 
            this.tsBtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnEdit.Image = global::ChromatoCore.Properties.Resources.edit;
            this.tsBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEdit.Name = "tsBtnEdit";
            this.tsBtnEdit.Size = new System.Drawing.Size(36, 36);
            this.tsBtnEdit.Text = "编辑";
            // 
            // tsBtnSaveAs
            // 
            this.tsBtnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSaveAs.Image = global::ChromatoCore.Properties.Resources.saveas;
            this.tsBtnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSaveAs.Name = "tsBtnSaveAs";
            this.tsBtnSaveAs.Size = new System.Drawing.Size(36, 36);
            this.tsBtnSaveAs.Text = "复制";
            // 
            // tsBtnDelete
            // 
            this.tsBtnDelete.BackColor = System.Drawing.SystemColors.Info;
            this.tsBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDelete.Image = global::ChromatoCore.Properties.Resources.waste;
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Size = new System.Drawing.Size(36, 36);
            this.tsBtnDelete.Text = "删除";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // SoluList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainerMain);
            this.Name = "SoluList";
            this.Size = new System.Drawing.Size(683, 214);
            this.Load += new System.EventHandler(this.SoluList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolution)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.gbQuery.ResumeLayout(false);
            this.gbQuery.PerformLayout();
            this.tsSolution.ResumeLayout(false);
            this.tsSolution.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSolution;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem tsRefresh;
        private System.Windows.Forms.ToolStripMenuItem tsDelete;
        private System.Windows.Forms.ToolStrip tsSolution;
        private System.Windows.Forms.ToolStripButton tsBtnRegNew;
        private System.Windows.Forms.ToolStripButton tsBtnEdit;
        private System.Windows.Forms.ToolStripButton tsBtnSaveAs;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn SolutionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn SolutionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnalyParaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AntiMethodID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDTableID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeProcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollectionID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsUseTimeProc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.GroupBox gbQuery;
        private System.Windows.Forms.DateTimePicker dtPickerQuery;
        private System.Windows.Forms.DateTimePicker dtPickerQueryEndDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxQuery;
    }
}
