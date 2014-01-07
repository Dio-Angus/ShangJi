namespace ChromatoCore.solu.sUi
{
    partial class AnalyParaUi
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvAnalyPara = new System.Windows.Forms.DataGridView();
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
            // dgvAnalyPara
            // 
            this.dgvAnalyPara.AllowUserToAddRows = false;
            this.dgvAnalyPara.AllowUserToDeleteRows = false;
            this.dgvAnalyPara.AllowUserToResizeRows = false;
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
            this.dgvAnalyPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnalyPara.Location = new System.Drawing.Point(0, 0);
            this.dgvAnalyPara.MultiSelect = false;
            this.dgvAnalyPara.Name = "dgvAnalyPara";
            this.dgvAnalyPara.ReadOnly = true;
            this.dgvAnalyPara.RowHeadersVisible = false;
            this.dgvAnalyPara.RowTemplate.Height = 23;
            this.dgvAnalyPara.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnalyPara.Size = new System.Drawing.Size(447, 224);
            this.dgvAnalyPara.TabIndex = 37;
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
            this.AnalyName.HeaderText = "分析名";
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
            // MethodUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 224);
            this.ControlBox = false;
            this.Controls.Add(this.dgvAnalyPara);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MethodUi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更改物质方法";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalyPara)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAnalyPara;
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