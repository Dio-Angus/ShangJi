namespace ChromatoCore.Off
{
    partial class OffDeductedBase
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbQuery = new System.Windows.Forms.GroupBox();
            this.dtPickerQuery = new System.Windows.Forms.DateTimePicker();
            this.dtPickerQueryEndDay = new System.Windows.Forms.DateTimePicker();
            this.lblChoose = new System.Windows.Forms.Label();
            this.cbxQuery = new System.Windows.Forms.ComboBox();
            this.dgvSampleInfo = new System.Windows.Forms.DataGridView();
            this.IsPickup = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SampleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisterTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollectTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowMaxY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowMinY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InnerWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsSample = new System.Windows.Forms.ToolStrip();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gbQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSampleInfo)).BeginInit();
            this.tsSample.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbQuery
            // 
            this.gbQuery.Controls.Add(this.dtPickerQuery);
            this.gbQuery.Controls.Add(this.dtPickerQueryEndDay);
            this.gbQuery.Controls.Add(this.lblChoose);
            this.gbQuery.Controls.Add(this.cbxQuery);
            this.gbQuery.Location = new System.Drawing.Point(3, -5);
            this.gbQuery.Name = "gbQuery";
            this.gbQuery.Size = new System.Drawing.Size(417, 44);
            this.gbQuery.TabIndex = 26;
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
            // lblChoose
            // 
            this.lblChoose.AutoSize = true;
            this.lblChoose.Location = new System.Drawing.Point(6, 16);
            this.lblChoose.Name = "lblChoose";
            this.lblChoose.Size = new System.Drawing.Size(59, 12);
            this.lblChoose.TabIndex = 1;
            this.lblChoose.Text = "样品查询:";
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
            this.IsPickup,
            this.SampleID,
            this.SampleName,
            this.SampleStatus,
            this.ChannelID,
            this.PathData,
            this.RegisterTime,
            this.CollectTime,
            this.StopTime,
            this.ShowMaxY,
            this.ShowMinY,
            this.UserID,
            this.SampleType,
            this.SampleWeight,
            this.Remark,
            this.InnerWeight});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSampleInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSampleInfo.Location = new System.Drawing.Point(2, 45);
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
            this.dgvSampleInfo.Size = new System.Drawing.Size(586, 140);
            this.dgvSampleInfo.TabIndex = 25;
            // 
            // IsPickup
            // 
            this.IsPickup.DataPropertyName = "IsPickup";
            this.IsPickup.FillWeight = 50F;
            this.IsPickup.HeaderText = "选中";
            this.IsPickup.Name = "IsPickup";
            this.IsPickup.Width = 50;
            // 
            // SampleID
            // 
            this.SampleID.DataPropertyName = "SampleID";
            this.SampleID.HeaderText = "样品ID";
            this.SampleID.Name = "SampleID";
            this.SampleID.ReadOnly = true;
            this.SampleID.Visible = false;
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
            // RegisterTime
            // 
            this.RegisterTime.DataPropertyName = "RegisterTime";
            this.RegisterTime.HeaderText = "注册时间";
            this.RegisterTime.Name = "RegisterTime";
            // 
            // CollectTime
            // 
            this.CollectTime.DataPropertyName = "CollectTime";
            this.CollectTime.HeaderText = "采集时间";
            this.CollectTime.Name = "CollectTime";
            // 
            // StopTime
            // 
            this.StopTime.DataPropertyName = "StopTime";
            this.StopTime.HeaderText = "停止时间";
            this.StopTime.Name = "StopTime";
            this.StopTime.Visible = false;
            // 
            // ShowMaxY
            // 
            this.ShowMaxY.DataPropertyName = "ShowMaxY";
            this.ShowMaxY.HeaderText = "显示上限";
            this.ShowMaxY.Name = "ShowMaxY";
            this.ShowMaxY.Visible = false;
            // 
            // ShowMinY
            // 
            this.ShowMinY.DataPropertyName = "ShowMinY";
            this.ShowMinY.HeaderText = "显示下限";
            this.ShowMinY.Name = "ShowMinY";
            this.ShowMinY.Visible = false;
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "用户ID";
            this.UserID.Name = "UserID";
            this.UserID.Visible = false;
            // 
            // SampleType
            // 
            this.SampleType.DataPropertyName = "SampleType";
            this.SampleType.HeaderText = "样品类型";
            this.SampleType.Name = "SampleType";
            this.SampleType.Visible = false;
            // 
            // SampleWeight
            // 
            this.SampleWeight.DataPropertyName = "SampleWeight";
            this.SampleWeight.HeaderText = "样品量";
            this.SampleWeight.Name = "SampleWeight";
            this.SampleWeight.Visible = false;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.Visible = false;
            // 
            // InnerWeight
            // 
            this.InnerWeight.DataPropertyName = "InnerWeight";
            this.InnerWeight.HeaderText = "内标量";
            this.InnerWeight.Name = "InnerWeight";
            this.InnerWeight.Visible = false;
            // 
            // tsSample
            // 
            this.tsSample.BackColor = System.Drawing.SystemColors.Info;
            this.tsSample.Dock = System.Windows.Forms.DockStyle.None;
            this.tsSample.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsSample.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnRefresh,
            this.toolStripSeparator1});
            this.tsSample.Location = new System.Drawing.Point(425, 2);
            this.tsSample.Name = "tsSample";
            this.tsSample.Size = new System.Drawing.Size(52, 39);
            this.tsSample.TabIndex = 24;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // OffRemoveSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbQuery);
            this.Controls.Add(this.dgvSampleInfo);
            this.Controls.Add(this.tsSample);
            this.Name = "OffRemoveSample";
            this.Size = new System.Drawing.Size(591, 193);
            this.gbQuery.ResumeLayout(false);
            this.gbQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSampleInfo)).EndInit();
            this.tsSample.ResumeLayout(false);
            this.tsSample.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbQuery;
        private System.Windows.Forms.DateTimePicker dtPickerQuery;
        private System.Windows.Forms.DateTimePicker dtPickerQueryEndDay;
        private System.Windows.Forms.Label lblChoose;
        private System.Windows.Forms.ComboBox cbxQuery;
        private System.Windows.Forms.DataGridView dgvSampleInfo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsPickup;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathData;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollectTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StopTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShowMaxY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShowMinY;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn InnerWeight;
        private System.Windows.Forms.ToolStrip tsSample;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
