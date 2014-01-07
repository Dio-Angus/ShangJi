namespace ChromatoCore.sample
{
    partial class SampleResultViewer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.PeakID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartPointIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndPointIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopPointIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeakName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReserveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeakHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Density = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeakType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsStartDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsEndDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartVoltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndVoltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartMoment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndMoment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartPointCloseIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndPointCloseIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeakStep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvResult.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PeakID,
            this.StartPointIndex,
            this.EndPointIndex,
            this.TopPointIndex,
            this.PeakName,
            this.ReserveTime,
            this.PeakHeight,
            this.AreaSize,
            this.Density,
            this.PeakType,
            this.BaseK,
            this.BaseB,
            this.GroupID,
            this.IsStartDown,
            this.IsEndDown,
            this.StartVoltage,
            this.EndVoltage,
            this.StartMoment,
            this.EndMoment,
            this.StartPointCloseIndex,
            this.EndPointCloseIndex,
            this.PeakStep});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResult.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(0, 0);
            this.dgvResult.MultiSelect = false;
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.RowHeadersWidth = 20;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvResult.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(616, 176);
            this.dgvResult.TabIndex = 31;
            // 
            // PeakID
            // 
            this.PeakID.DataPropertyName = "PeakID";
            this.PeakID.FillWeight = 60F;
            this.PeakID.HeaderText = "峰ID";
            this.PeakID.Name = "PeakID";
            this.PeakID.ReadOnly = true;
            this.PeakID.Width = 60;
            // 
            // StartPointIndex
            // 
            this.StartPointIndex.DataPropertyName = "StartPointIndex";
            this.StartPointIndex.FillWeight = 70F;
            this.StartPointIndex.HeaderText = "开始点";
            this.StartPointIndex.Name = "StartPointIndex";
            this.StartPointIndex.ReadOnly = true;
            this.StartPointIndex.Visible = false;
            this.StartPointIndex.Width = 70;
            // 
            // EndPointIndex
            // 
            this.EndPointIndex.DataPropertyName = "EndPointIndex";
            this.EndPointIndex.FillWeight = 70F;
            this.EndPointIndex.HeaderText = "结束点";
            this.EndPointIndex.Name = "EndPointIndex";
            this.EndPointIndex.ReadOnly = true;
            this.EndPointIndex.Visible = false;
            this.EndPointIndex.Width = 70;
            // 
            // TopPointIndex
            // 
            this.TopPointIndex.DataPropertyName = "TopPointIndex";
            this.TopPointIndex.FillWeight = 70F;
            this.TopPointIndex.HeaderText = "最高点";
            this.TopPointIndex.Name = "TopPointIndex";
            this.TopPointIndex.ReadOnly = true;
            this.TopPointIndex.Visible = false;
            this.TopPointIndex.Width = 70;
            // 
            // PeakName
            // 
            this.PeakName.DataPropertyName = "PeakName";
            this.PeakName.FillWeight = 80F;
            this.PeakName.HeaderText = "组分名";
            this.PeakName.Name = "PeakName";
            this.PeakName.ReadOnly = true;
            this.PeakName.Width = 80;
            // 
            // ReserveTime
            // 
            this.ReserveTime.DataPropertyName = "ReserveTime";
            dataGridViewCellStyle1.Format = "N4";
            dataGridViewCellStyle1.NullValue = null;
            this.ReserveTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.ReserveTime.FillWeight = 120F;
            this.ReserveTime.HeaderText = "保留时间(min)";
            this.ReserveTime.Name = "ReserveTime";
            this.ReserveTime.ReadOnly = true;
            this.ReserveTime.Width = 120;
            // 
            // PeakHeight
            // 
            this.PeakHeight.DataPropertyName = "PeakHeight";
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.PeakHeight.DefaultCellStyle = dataGridViewCellStyle2;
            this.PeakHeight.FillWeight = 80F;
            this.PeakHeight.HeaderText = "峰高(uv)";
            this.PeakHeight.Name = "PeakHeight";
            this.PeakHeight.ReadOnly = true;
            this.PeakHeight.Width = 80;
            // 
            // AreaSize
            // 
            this.AreaSize.DataPropertyName = "AreaSize";
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.AreaSize.DefaultCellStyle = dataGridViewCellStyle3;
            this.AreaSize.FillWeight = 120F;
            this.AreaSize.HeaderText = "峰面积(uv*s)";
            this.AreaSize.Name = "AreaSize";
            this.AreaSize.ReadOnly = true;
            this.AreaSize.Width = 120;
            // 
            // Density
            // 
            this.Density.DataPropertyName = "Density";
            dataGridViewCellStyle4.Format = "N4";
            dataGridViewCellStyle4.NullValue = null;
            this.Density.DefaultCellStyle = dataGridViewCellStyle4;
            this.Density.FillWeight = 80F;
            this.Density.HeaderText = "浓度(%)";
            this.Density.Name = "Density";
            this.Density.ReadOnly = true;
            this.Density.Width = 80;
            // 
            // PeakType
            // 
            this.PeakType.DataPropertyName = "PeakType";
            this.PeakType.HeaderText = "峰型号";
            this.PeakType.Name = "PeakType";
            this.PeakType.ReadOnly = true;
            // 
            // BaseK
            // 
            this.BaseK.DataPropertyName = "BaseK";
            dataGridViewCellStyle5.Format = "N4";
            dataGridViewCellStyle5.NullValue = null;
            this.BaseK.DefaultCellStyle = dataGridViewCellStyle5;
            this.BaseK.FillWeight = 150F;
            this.BaseK.HeaderText = "响应因子斜率";
            this.BaseK.Name = "BaseK";
            this.BaseK.ReadOnly = true;
            this.BaseK.Width = 150;
            // 
            // BaseB
            // 
            this.BaseB.DataPropertyName = "BaseB";
            dataGridViewCellStyle6.Format = "N4";
            dataGridViewCellStyle6.NullValue = null;
            this.BaseB.DefaultCellStyle = dataGridViewCellStyle6;
            this.BaseB.FillWeight = 150F;
            this.BaseB.HeaderText = "响应因子截距";
            this.BaseB.Name = "BaseB";
            this.BaseB.ReadOnly = true;
            this.BaseB.Width = 150;
            // 
            // GroupID
            // 
            this.GroupID.DataPropertyName = "GroupID";
            this.GroupID.FillWeight = 70F;
            this.GroupID.HeaderText = "组号";
            this.GroupID.Name = "GroupID";
            this.GroupID.ReadOnly = true;
            this.GroupID.Width = 70;
            // 
            // IsStartDown
            // 
            this.IsStartDown.DataPropertyName = "IsStartDown";
            this.IsStartDown.HeaderText = "IsStartDown";
            this.IsStartDown.Name = "IsStartDown";
            this.IsStartDown.ReadOnly = true;
            this.IsStartDown.Visible = false;
            // 
            // IsEndDown
            // 
            this.IsEndDown.DataPropertyName = "IsEndDown";
            this.IsEndDown.HeaderText = "IsEndDown";
            this.IsEndDown.Name = "IsEndDown";
            this.IsEndDown.ReadOnly = true;
            this.IsEndDown.Visible = false;
            // 
            // StartVoltage
            // 
            this.StartVoltage.DataPropertyName = "StartVoltage";
            this.StartVoltage.HeaderText = "StartVoltage";
            this.StartVoltage.Name = "StartVoltage";
            this.StartVoltage.ReadOnly = true;
            this.StartVoltage.Visible = false;
            // 
            // EndVoltage
            // 
            this.EndVoltage.DataPropertyName = "EndVoltage";
            this.EndVoltage.HeaderText = "EndVoltage";
            this.EndVoltage.Name = "EndVoltage";
            this.EndVoltage.ReadOnly = true;
            this.EndVoltage.Visible = false;
            // 
            // StartMoment
            // 
            this.StartMoment.DataPropertyName = "StartMoment";
            this.StartMoment.HeaderText = "StartMoment";
            this.StartMoment.Name = "StartMoment";
            this.StartMoment.ReadOnly = true;
            this.StartMoment.Visible = false;
            // 
            // EndMoment
            // 
            this.EndMoment.DataPropertyName = "EndMoment";
            this.EndMoment.HeaderText = "EndMoment";
            this.EndMoment.Name = "EndMoment";
            this.EndMoment.ReadOnly = true;
            this.EndMoment.Visible = false;
            // 
            // StartPointCloseIndex
            // 
            this.StartPointCloseIndex.DataPropertyName = "StartPointCloseIndex";
            this.StartPointCloseIndex.HeaderText = "StartPointCloseIndex";
            this.StartPointCloseIndex.Name = "StartPointCloseIndex";
            this.StartPointCloseIndex.ReadOnly = true;
            this.StartPointCloseIndex.Visible = false;
            // 
            // EndPointCloseIndex
            // 
            this.EndPointCloseIndex.DataPropertyName = "EndPointCloseIndex";
            this.EndPointCloseIndex.HeaderText = "EndPointCloseIndex";
            this.EndPointCloseIndex.Name = "EndPointCloseIndex";
            this.EndPointCloseIndex.ReadOnly = true;
            this.EndPointCloseIndex.Visible = false;
            // 
            // PeakStep
            // 
            this.PeakStep.DataPropertyName = "PeakStep";
            this.PeakStep.HeaderText = "PeakStep";
            this.PeakStep.Name = "PeakStep";
            this.PeakStep.ReadOnly = true;
            this.PeakStep.Visible = false;
            // 
            // SampleResultViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.dgvResult);
            this.Name = "SampleResultViewer";
            this.Size = new System.Drawing.Size(616, 176);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeakID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartPointIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndPointIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopPointIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeakName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReserveTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeakHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Density;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeakType;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaseK;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaseB;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsStartDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsEndDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartVoltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndVoltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartMoment;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndMoment;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartPointCloseIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndPointCloseIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeakStep;

    }
}
