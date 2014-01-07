namespace ChromatoCore.solu.Ana
{
    partial class AnalyMng
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
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvAnalyPara = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.AnalyParaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnalyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumuModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArithmaticID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArithmaticPara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AimWay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AimPara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeakWide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slope = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Drift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinAreaSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParaChangeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ratio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalyPara)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(423, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(70, 23);
            this.btnNew.TabIndex = 37;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // dgvAnalyPara
            // 
            this.dgvAnalyPara.AllowUserToAddRows = false;
            this.dgvAnalyPara.AllowUserToDeleteRows = false;
            this.dgvAnalyPara.AllowUserToResizeRows = false;
            this.dgvAnalyPara.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAnalyPara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnalyPara.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AnalyParaID,
            this.AnalyName,
            this.Description,
            this.ColumuModel,
            this.ArithmaticID,
            this.ArithmaticPara,
            this.AimWay,
            this.AimPara,
            this.PeakWide,
            this.Slope,
            this.Drift,
            this.MinAreaSize,
            this.ParaChangeTime,
            this.Ratio});
            this.dgvAnalyPara.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvAnalyPara.Location = new System.Drawing.Point(0, 0);
            this.dgvAnalyPara.MultiSelect = false;
            this.dgvAnalyPara.Name = "dgvAnalyPara";
            this.dgvAnalyPara.ReadOnly = true;
            this.dgvAnalyPara.RowHeadersVisible = false;
            this.dgvAnalyPara.RowTemplate.Height = 23;
            this.dgvAnalyPara.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnalyPara.Size = new System.Drawing.Size(419, 243);
            this.dgvAnalyPara.TabIndex = 36;
            this.dgvAnalyPara.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMethod_ColumnHeaderMouseClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(423, 60);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(70, 23);
            this.btnRefresh.TabIndex = 38;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(423, 32);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 23);
            this.btnDelete.TabIndex = 39;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // AnalyParaID
            // 
            this.AnalyParaID.DataPropertyName = "AnalyParaID";
            this.AnalyParaID.FillWeight = 80F;
            this.AnalyParaID.HeaderText = "分析ID";
            this.AnalyParaID.Name = "AnalyParaID";
            this.AnalyParaID.ReadOnly = true;
            this.AnalyParaID.Width = 80;
            // 
            // AnalyName
            // 
            this.AnalyName.DataPropertyName = "AnalyName";
            this.AnalyName.FillWeight = 120F;
            this.AnalyName.HeaderText = "分析方法名";
            this.AnalyName.Name = "AnalyName";
            this.AnalyName.ReadOnly = true;
            this.AnalyName.Width = 120;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.FillWeight = 300F;
            this.Description.HeaderText = "描述";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 300;
            // 
            // ColumuModel
            // 
            this.ColumuModel.DataPropertyName = "ColumuModel";
            this.ColumuModel.FillWeight = 80F;
            this.ColumuModel.HeaderText = "色谱柱";
            this.ColumuModel.Name = "ColumuModel";
            this.ColumuModel.ReadOnly = true;
            this.ColumuModel.Width = 80;
            // 
            // ArithmaticID
            // 
            this.ArithmaticID.DataPropertyName = "ArithmaticID";
            this.ArithmaticID.HeaderText = "定量方法ID";
            this.ArithmaticID.Name = "ArithmaticID";
            this.ArithmaticID.ReadOnly = true;
            this.ArithmaticID.Visible = false;
            // 
            // ArithmaticPara
            // 
            this.ArithmaticPara.DataPropertyName = "ArithmaticPara";
            this.ArithmaticPara.HeaderText = "定量方法参数";
            this.ArithmaticPara.Name = "ArithmaticPara";
            this.ArithmaticPara.ReadOnly = true;
            this.ArithmaticPara.Visible = false;
            // 
            // AimWay
            // 
            this.AimWay.DataPropertyName = "AimWay";
            this.AimWay.HeaderText = "对准方法";
            this.AimWay.Name = "AimWay";
            this.AimWay.ReadOnly = true;
            this.AimWay.Visible = false;
            // 
            // AimPara
            // 
            this.AimPara.DataPropertyName = "AimPara";
            this.AimPara.HeaderText = "对准参数";
            this.AimPara.Name = "AimPara";
            this.AimPara.ReadOnly = true;
            this.AimPara.Visible = false;
            // 
            // PeakWide
            // 
            this.PeakWide.DataPropertyName = "PeakWide";
            this.PeakWide.HeaderText = "峰宽";
            this.PeakWide.Name = "PeakWide";
            this.PeakWide.ReadOnly = true;
            this.PeakWide.Visible = false;
            // 
            // Slope
            // 
            this.Slope.DataPropertyName = "Slope";
            this.Slope.HeaderText = "斜率";
            this.Slope.Name = "Slope";
            this.Slope.ReadOnly = true;
            this.Slope.Visible = false;
            // 
            // Drift
            // 
            this.Drift.DataPropertyName = "Drift";
            this.Drift.HeaderText = "漂移";
            this.Drift.Name = "Drift";
            this.Drift.ReadOnly = true;
            this.Drift.Visible = false;
            // 
            // MinAreaSize
            // 
            this.MinAreaSize.DataPropertyName = "MinAreaSize";
            this.MinAreaSize.HeaderText = "最小面积";
            this.MinAreaSize.Name = "MinAreaSize";
            this.MinAreaSize.ReadOnly = true;
            this.MinAreaSize.Visible = false;
            // 
            // ParaChangeTime
            // 
            this.ParaChangeTime.DataPropertyName = "ParaChangeTime";
            this.ParaChangeTime.HeaderText = "变参时间";
            this.ParaChangeTime.Name = "ParaChangeTime";
            this.ParaChangeTime.ReadOnly = true;
            this.ParaChangeTime.Visible = false;
            // 
            // Ratio
            // 
            this.Ratio.DataPropertyName = "Ratio";
            this.Ratio.HeaderText = "比例系数";
            this.Ratio.Name = "Ratio";
            this.Ratio.ReadOnly = true;
            this.Ratio.Visible = false;
            // 
            // AnalyParaViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvAnalyPara);
            this.Name = "AnalyParaViewer";
            this.Size = new System.Drawing.Size(494, 243);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalyPara)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgvAnalyPara;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnalyParaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnalyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumuModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArithmaticID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArithmaticPara;
        private System.Windows.Forms.DataGridViewTextBoxColumn AimWay;
        private System.Windows.Forms.DataGridViewTextBoxColumn AimPara;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeakWide;
        private System.Windows.Forms.DataGridViewTextBoxColumn Slope;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drift;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinAreaSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParaChangeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ratio;
    }
}
