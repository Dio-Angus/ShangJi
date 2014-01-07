namespace ChromatoCore.On
{
    partial class OnList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSampleInfo = new System.Windows.Forms.DataGridView();
            this.SampleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisterTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollectTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InnerWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tsSample = new System.Windows.Forms.ToolStrip();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsBtnStart = new System.Windows.Forms.ToolStripButton();
            this.tsBtnStop = new System.Windows.Forms.ToolStripButton();
            this.tsBtnBaseline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDownload = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsFid1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFid2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTcd1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTcd2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAux = new System.Windows.Forms.ToolStripMenuItem();
            this.tsInj1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsInj2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsInj3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsColumnPara = new System.Windows.Forms.ToolStripMenuItem();
            this.viewConfig = new ChromatoCore.On.OnConfigViewer();
            this.splitterGraph = new System.Windows.Forms.Splitter();
            this.gbQuery = new System.Windows.Forms.GroupBox();
            this.dtPickerQuery = new System.Windows.Forms.DateTimePicker();
            this.dtPickerQueryEndDay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxQuery = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSampleInfo)).BeginInit();
            this.ctxMenu.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tsSample.SuspendLayout();
            this.gbQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSampleInfo
            // 
            this.dgvSampleInfo.AllowUserToAddRows = false;
            this.dgvSampleInfo.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            this.dgvSampleInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            this.SampleID,
            this.SampleName,
            this.SampleStatus,
            this.ChannelID,
            this.RegisterTime,
            this.CollectTime,
            this.PathData,
            this.StopTime,
            this.UserID,
            this.SampleType,
            this.SampleWeight,
            this.Remark,
            this.InnerWeight});
            this.dgvSampleInfo.ContextMenuStrip = this.ctxMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSampleInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSampleInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvSampleInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvSampleInfo.MultiSelect = false;
            this.dgvSampleInfo.Name = "dgvSampleInfo";
            this.dgvSampleInfo.ReadOnly = true;
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
            this.dgvSampleInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSampleInfo.ShowCellToolTips = false;
            this.dgvSampleInfo.ShowEditingIcon = false;
            this.dgvSampleInfo.Size = new System.Drawing.Size(445, 160);
            this.dgvSampleInfo.TabIndex = 5;
            this.dgvSampleInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvSampleInfo_MouseDown);
            // 
            // SampleID
            // 
            this.SampleID.DataPropertyName = "SampleID";
            this.SampleID.FillWeight = 80F;
            this.SampleID.HeaderText = "样品ID";
            this.SampleID.Name = "SampleID";
            this.SampleID.ReadOnly = true;
            this.SampleID.Visible = false;
            this.SampleID.Width = 80;
            // 
            // SampleName
            // 
            this.SampleName.DataPropertyName = "SampleName";
            this.SampleName.FillWeight = 200F;
            this.SampleName.HeaderText = "样品名";
            this.SampleName.Name = "SampleName";
            this.SampleName.ReadOnly = true;
            this.SampleName.Width = 200;
            // 
            // SampleStatus
            // 
            this.SampleStatus.DataPropertyName = "SampleStatus";
            this.SampleStatus.FillWeight = 70F;
            this.SampleStatus.HeaderText = "状态";
            this.SampleStatus.Name = "SampleStatus";
            this.SampleStatus.ReadOnly = true;
            this.SampleStatus.Width = 70;
            // 
            // ChannelID
            // 
            this.ChannelID.DataPropertyName = "ChannelID";
            this.ChannelID.FillWeight = 60F;
            this.ChannelID.HeaderText = "通道";
            this.ChannelID.Name = "ChannelID";
            this.ChannelID.ReadOnly = true;
            this.ChannelID.Width = 60;
            // 
            // RegisterTime
            // 
            this.RegisterTime.DataPropertyName = "RegisterTime";
            this.RegisterTime.HeaderText = "注册时间";
            this.RegisterTime.Name = "RegisterTime";
            this.RegisterTime.ReadOnly = true;
            // 
            // CollectTime
            // 
            this.CollectTime.DataPropertyName = "CollectTime";
            this.CollectTime.HeaderText = "采集时间";
            this.CollectTime.Name = "CollectTime";
            this.CollectTime.ReadOnly = true;
            // 
            // PathData
            // 
            this.PathData.DataPropertyName = "PathData";
            this.PathData.FillWeight = 150F;
            this.PathData.HeaderText = "路径";
            this.PathData.Name = "PathData";
            this.PathData.ReadOnly = true;
            this.PathData.Visible = false;
            this.PathData.Width = 150;
            // 
            // StopTime
            // 
            this.StopTime.DataPropertyName = "StopTime";
            this.StopTime.HeaderText = "停止时间";
            this.StopTime.Name = "StopTime";
            this.StopTime.ReadOnly = true;
            this.StopTime.Visible = false;
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "用户ID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Visible = false;
            // 
            // SampleType
            // 
            this.SampleType.DataPropertyName = "SampleType";
            this.SampleType.HeaderText = "样品类型";
            this.SampleType.Name = "SampleType";
            this.SampleType.ReadOnly = true;
            this.SampleType.Visible = false;
            // 
            // SampleWeight
            // 
            this.SampleWeight.DataPropertyName = "SampleWeight";
            this.SampleWeight.HeaderText = "样品量";
            this.SampleWeight.Name = "SampleWeight";
            this.SampleWeight.ReadOnly = true;
            this.SampleWeight.Visible = false;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Visible = false;
            // 
            // InnerWeight
            // 
            this.InnerWeight.DataPropertyName = "InnerWeight";
            this.InnerWeight.HeaderText = "内标量";
            this.InnerWeight.Name = "InnerWeight";
            this.InnerWeight.ReadOnly = true;
            this.InnerWeight.Visible = false;
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRefresh});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(95, 26);
            // 
            // tsRefresh
            // 
            this.tsRefresh.Name = "tsRefresh";
            this.tsRefresh.Size = new System.Drawing.Size(94, 22);
            this.tsRefresh.Text = "刷新";
            this.tsRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
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
            this.splitContainerMain.Panel1.Controls.Add(this.tsSample);
            this.splitContainerMain.Panel1MinSize = 50;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.viewConfig);
            this.splitContainerMain.Panel2.Controls.Add(this.splitterGraph);
            this.splitContainerMain.Panel2.Controls.Add(this.dgvSampleInfo);
            this.splitContainerMain.Panel2MinSize = 50;
            this.splitContainerMain.Size = new System.Drawing.Size(900, 214);
            this.splitContainerMain.TabIndex = 7;
            // 
            // tsSample
            // 
            this.tsSample.BackColor = System.Drawing.SystemColors.Info;
            this.tsSample.Dock = System.Windows.Forms.DockStyle.None;
            this.tsSample.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsSample.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnRefresh,
            this.tsBtnStart,
            this.tsBtnStop,
            this.tsBtnBaseline,
            this.toolStripSeparator1,
            this.tsDownload});
            this.tsSample.Location = new System.Drawing.Point(423, 5);
            this.tsSample.Name = "tsSample";
            this.tsSample.Size = new System.Drawing.Size(205, 39);
            this.tsSample.TabIndex = 6;
            this.tsSample.Text = "toolStrip1";
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
            // tsBtnStart
            // 
            this.tsBtnStart.BackColor = System.Drawing.SystemColors.Info;
            this.tsBtnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnStart.Image = global::ChromatoCore.Properties.Resources.Start;
            this.tsBtnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnStart.Name = "tsBtnStart";
            this.tsBtnStart.Size = new System.Drawing.Size(36, 36);
            this.tsBtnStart.Text = "启动";
            // 
            // tsBtnStop
            // 
            this.tsBtnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnStop.Image = global::ChromatoCore.Properties.Resources.Stop;
            this.tsBtnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnStop.Name = "tsBtnStop";
            this.tsBtnStop.Size = new System.Drawing.Size(36, 36);
            this.tsBtnStop.Text = "停止";
            // 
            // tsBtnBaseline
            // 
            this.tsBtnBaseline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnBaseline.Image = global::ChromatoCore.Properties.Resources.watchBaseline;
            this.tsBtnBaseline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnBaseline.Name = "tsBtnBaseline";
            this.tsBtnBaseline.Size = new System.Drawing.Size(36, 36);
            this.tsBtnBaseline.Text = "观察基线";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsDownload
            // 
            this.tsDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDownload.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFid1,
            this.tsFid2,
            this.tsTcd1,
            this.tsTcd2,
            this.tsAux,
            this.tsInj1,
            this.tsInj2,
            this.tsInj3,
            this.tsColumnPara});
            this.tsDownload.Image = global::ChromatoCore.Properties.Resources.download;
            this.tsDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDownload.Name = "tsDownload";
            this.tsDownload.Size = new System.Drawing.Size(45, 36);
            this.tsDownload.Text = "反控方法下载";
            // 
            // tsFid1
            // 
            this.tsFid1.Name = "tsFid1";
            this.tsFid1.Size = new System.Drawing.Size(130, 22);
            this.tsFid1.Text = "Fid检测器1";
            // 
            // tsFid2
            // 
            this.tsFid2.Name = "tsFid2";
            this.tsFid2.Size = new System.Drawing.Size(130, 22);
            this.tsFid2.Text = "Fid检测器2";
            // 
            // tsTcd1
            // 
            this.tsTcd1.Name = "tsTcd1";
            this.tsTcd1.Size = new System.Drawing.Size(130, 22);
            this.tsTcd1.Text = "Tcd检测器1";
            // 
            // tsTcd2
            // 
            this.tsTcd2.Name = "tsTcd2";
            this.tsTcd2.Size = new System.Drawing.Size(130, 22);
            this.tsTcd2.Text = "Tcd检测器2";
            // 
            // tsAux
            // 
            this.tsAux.Name = "tsAux";
            this.tsAux.Size = new System.Drawing.Size(130, 22);
            this.tsAux.Text = "辅助";
            // 
            // tsInj1
            // 
            this.tsInj1.Name = "tsInj1";
            this.tsInj1.Size = new System.Drawing.Size(130, 22);
            this.tsInj1.Text = "进样口1";
            // 
            // tsInj2
            // 
            this.tsInj2.Name = "tsInj2";
            this.tsInj2.Size = new System.Drawing.Size(130, 22);
            this.tsInj2.Text = "进样口2";
            // 
            // tsInj3
            // 
            this.tsInj3.Name = "tsInj3";
            this.tsInj3.Size = new System.Drawing.Size(130, 22);
            this.tsInj3.Text = "进样口3";
            // 
            // tsColumnPara
            // 
            this.tsColumnPara.Name = "tsColumnPara";
            this.tsColumnPara.Size = new System.Drawing.Size(130, 22);
            this.tsColumnPara.Text = "柱箱";
            // 
            // viewConfig
            // 
            this.viewConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewConfig.Location = new System.Drawing.Point(450, 0);
            this.viewConfig.Name = "viewConfig";
            this.viewConfig.Size = new System.Drawing.Size(450, 160);
            this.viewConfig.TabIndex = 0;
            // 
            // splitterGraph
            // 
            this.splitterGraph.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitterGraph.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.splitterGraph.Location = new System.Drawing.Point(445, 0);
            this.splitterGraph.MinExtra = 15;
            this.splitterGraph.MinSize = 15;
            this.splitterGraph.Name = "splitterGraph";
            this.splitterGraph.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitterGraph.Size = new System.Drawing.Size(5, 160);
            this.splitterGraph.TabIndex = 31;
            this.splitterGraph.TabStop = false;
            // 
            // gbQuery
            // 
            this.gbQuery.Controls.Add(this.dtPickerQuery);
            this.gbQuery.Controls.Add(this.dtPickerQueryEndDay);
            this.gbQuery.Controls.Add(this.label2);
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
            this.dtPickerQuery.Size = new System.Drawing.Size(119, 21);
            this.dtPickerQuery.TabIndex = 6;
            // 
            // dtPickerQueryEndDay
            // 
            this.dtPickerQueryEndDay.Location = new System.Drawing.Point(294, 12);
            this.dtPickerQueryEndDay.Name = "dtPickerQueryEndDay";
            this.dtPickerQueryEndDay.Size = new System.Drawing.Size(119, 21);
            this.dtPickerQueryEndDay.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "样品查询:";
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
            // OnList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainerMain);
            this.DoubleBuffered = true;
            this.Name = "OnList";
            this.Size = new System.Drawing.Size(900, 214);
            this.Load += new System.EventHandler(this.OnList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSampleInfo)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.tsSample.ResumeLayout(false);
            this.tsSample.PerformLayout();
            this.gbQuery.ResumeLayout(false);
            this.gbQuery.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSampleInfo;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem tsRefresh;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.ToolStrip tsSample;
        private System.Windows.Forms.ToolStripButton tsBtnStart;
        private System.Windows.Forms.ToolStripButton tsBtnStop;
        private System.Windows.Forms.ToolStripButton tsBtnBaseline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private System.Windows.Forms.Splitter splitterGraph;
        private System.Windows.Forms.ToolStripDropDownButton tsDownload;
        private System.Windows.Forms.ToolStripMenuItem tsFid1;
        private System.Windows.Forms.ToolStripMenuItem tsFid2;
        private System.Windows.Forms.ToolStripMenuItem tsTcd1;
        private System.Windows.Forms.ToolStripMenuItem tsTcd2;
        private System.Windows.Forms.ToolStripMenuItem tsAux;
        private System.Windows.Forms.ToolStripMenuItem tsInj1;
        private System.Windows.Forms.ToolStripMenuItem tsInj2;
        private System.Windows.Forms.ToolStripMenuItem tsInj3;
        private System.Windows.Forms.ToolStripMenuItem tsColumnPara;
        private OnConfigViewer viewConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollectTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathData;
        private System.Windows.Forms.DataGridViewTextBoxColumn StopTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn InnerWeight;
        private System.Windows.Forms.GroupBox gbQuery;
        private System.Windows.Forms.DateTimePicker dtPickerQuery;
        private System.Windows.Forms.DateTimePicker dtPickerQueryEndDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxQuery;
    }
}
