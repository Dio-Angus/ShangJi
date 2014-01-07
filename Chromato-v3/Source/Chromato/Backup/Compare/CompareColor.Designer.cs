namespace ChromatoCore.Compare
{
    partial class CompareColor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.colorDlgBK = new System.Windows.Forms.ColorDialog();
            this.tsGraphMain = new System.Windows.Forms.ToolStrip();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsBtnChooseColor = new System.Windows.Forms.ToolStripButton();
            this.dgvSampleInfo = new System.Windows.Forms.DataGridView();
            this.IsShow = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SampleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colForeColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollectTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsGraphMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSampleInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // tsGraphMain
            // 
            this.tsGraphMain.BackColor = System.Drawing.SystemColors.Control;
            this.tsGraphMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsGraphMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnDelete,
            this.tsBtnChooseColor});
            this.tsGraphMain.Location = new System.Drawing.Point(0, 0);
            this.tsGraphMain.Name = "tsGraphMain";
            this.tsGraphMain.Size = new System.Drawing.Size(335, 39);
            this.tsGraphMain.TabIndex = 9;
            this.tsGraphMain.Text = "toolStrip1";
            // 
            // tsBtnDelete
            // 
            this.tsBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDelete.Image = global::ChromatoCore.Properties.Resources.waste;
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Size = new System.Drawing.Size(36, 36);
            this.tsBtnDelete.Text = "移走";
            // 
            // tsBtnChooseColor
            // 
            this.tsBtnChooseColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnChooseColor.Image = global::ChromatoCore.Properties.Resources.chooseColor;
            this.tsBtnChooseColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnChooseColor.Name = "tsBtnChooseColor";
            this.tsBtnChooseColor.Size = new System.Drawing.Size(36, 36);
            this.tsBtnChooseColor.Text = "改变颜色";
            // 
            // dgvSampleInfo
            // 
            this.dgvSampleInfo.AllowUserToAddRows = false;
            this.dgvSampleInfo.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            this.dgvSampleInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSampleInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSampleInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSampleInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsShow,
            this.SampleName,
            this.PathData,
            this.SampleID,
            this.colForeColor,
            this.CollectTime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSampleInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSampleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSampleInfo.Location = new System.Drawing.Point(0, 39);
            this.dgvSampleInfo.MultiSelect = false;
            this.dgvSampleInfo.Name = "dgvSampleInfo";
            this.dgvSampleInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSampleInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSampleInfo.RowHeadersVisible = false;
            this.dgvSampleInfo.RowHeadersWidth = 15;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvSampleInfo.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSampleInfo.RowTemplate.Height = 23;
            this.dgvSampleInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSampleInfo.ShowCellToolTips = false;
            this.dgvSampleInfo.ShowEditingIcon = false;
            this.dgvSampleInfo.Size = new System.Drawing.Size(335, 130);
            this.dgvSampleInfo.TabIndex = 10;
            // 
            // IsShow
            // 
            this.IsShow.DataPropertyName = "IsShow";
            this.IsShow.FillWeight = 40F;
            this.IsShow.HeaderText = "显示";
            this.IsShow.Name = "IsShow";
            this.IsShow.Width = 40;
            // 
            // SampleName
            // 
            this.SampleName.DataPropertyName = "SampleName";
            this.SampleName.FillWeight = 80F;
            this.SampleName.HeaderText = "样品名";
            this.SampleName.Name = "SampleName";
            this.SampleName.ReadOnly = true;
            this.SampleName.Width = 80;
            // 
            // PathData
            // 
            this.PathData.DataPropertyName = "PathData";
            this.PathData.HeaderText = "路径";
            this.PathData.Name = "PathData";
            this.PathData.ReadOnly = true;
            this.PathData.Visible = false;
            // 
            // SampleID
            // 
            this.SampleID.DataPropertyName = "SampleID";
            this.SampleID.FillWeight = 130F;
            this.SampleID.HeaderText = "样品ID";
            this.SampleID.Name = "SampleID";
            this.SampleID.ReadOnly = true;
            this.SampleID.Visible = false;
            this.SampleID.Width = 130;
            // 
            // colForeColor
            // 
            this.colForeColor.DataPropertyName = "ForeColor";
            this.colForeColor.FillWeight = 60F;
            this.colForeColor.HeaderText = "颜色";
            this.colForeColor.Name = "colForeColor";
            this.colForeColor.ReadOnly = true;
            this.colForeColor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colForeColor.Width = 60;
            // 
            // CollectTime
            // 
            this.CollectTime.DataPropertyName = "CollectTime";
            this.CollectTime.HeaderText = "采集时间";
            this.CollectTime.Name = "CollectTime";
            // 
            // CompareColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSampleInfo);
            this.Controls.Add(this.tsGraphMain);
            this.Name = "CompareColor";
            this.Size = new System.Drawing.Size(335, 169);
            this.tsGraphMain.ResumeLayout(false);
            this.tsGraphMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSampleInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDlgBK;
        private System.Windows.Forms.ToolStrip tsGraphMain;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.DataGridView dgvSampleInfo;
        private System.Windows.Forms.ToolStripButton tsBtnChooseColor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathData;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colForeColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollectTime;
    }
}
