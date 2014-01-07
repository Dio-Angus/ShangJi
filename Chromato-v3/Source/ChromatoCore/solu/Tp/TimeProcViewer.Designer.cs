namespace ChromatoCore.solu.Tp
{
    partial class TimeProcViewer
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
            this.dgvTimeProc = new System.Windows.Forms.DataGridView();
            this.TPid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCmd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TpValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpTPSetting = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxMaxStopTime = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTimeProc = new System.Windows.Forms.ComboBox();
            this.grpOrderValue = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbStatusOff = new System.Windows.Forms.RadioButton();
            this.txtCmdValue = new System.Windows.Forms.TextBox();
            this.rbStatusOn = new System.Windows.Forms.RadioButton();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtStopTime = new System.Windows.Forms.TextBox();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gbTimeProc = new System.Windows.Forms.GroupBox();
            this.txtTpName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeProc)).BeginInit();
            this.grpTPSetting.SuspendLayout();
            this.grpOrderValue.SuspendLayout();
            this.gbTimeProc.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTimeProc
            // 
            this.dgvTimeProc.AllowUserToAddRows = false;
            this.dgvTimeProc.AllowUserToDeleteRows = false;
            this.dgvTimeProc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTimeProc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeProc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TPid,
            this.TPName,
            this.SerialID,
            this.ActionName,
            this.StartTime,
            this.StopTime,
            this.IsCmd,
            this.TpValue});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTimeProc.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTimeProc.Location = new System.Drawing.Point(6, 20);
            this.dgvTimeProc.MultiSelect = false;
            this.dgvTimeProc.Name = "dgvTimeProc";
            this.dgvTimeProc.ReadOnly = true;
            this.dgvTimeProc.RowHeadersVisible = false;
            this.dgvTimeProc.RowTemplate.Height = 23;
            this.dgvTimeProc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimeProc.Size = new System.Drawing.Size(546, 121);
            this.dgvTimeProc.TabIndex = 12;
            // 
            // TPid
            // 
            this.TPid.DataPropertyName = "TPid";
            this.TPid.HeaderText = "TPid";
            this.TPid.Name = "TPid";
            this.TPid.ReadOnly = true;
            this.TPid.Visible = false;
            this.TPid.Width = 35;
            // 
            // TPName
            // 
            this.TPName.DataPropertyName = "TPName";
            this.TPName.HeaderText = "时间程序名";
            this.TPName.Name = "TPName";
            this.TPName.ReadOnly = true;
            this.TPName.Visible = false;
            this.TPName.Width = 71;
            // 
            // SerialID
            // 
            this.SerialID.DataPropertyName = "SerialID";
            this.SerialID.HeaderText = "序列号";
            this.SerialID.Name = "SerialID";
            this.SerialID.ReadOnly = true;
            this.SerialID.Width = 66;
            // 
            // ActionName
            // 
            this.ActionName.DataPropertyName = "ActionName";
            this.ActionName.HeaderText = "动作名";
            this.ActionName.Name = "ActionName";
            this.ActionName.ReadOnly = true;
            this.ActionName.Width = 66;
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "开始时间";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.Width = 78;
            // 
            // StopTime
            // 
            this.StopTime.DataPropertyName = "StopTime";
            this.StopTime.HeaderText = "结束时间";
            this.StopTime.Name = "StopTime";
            this.StopTime.ReadOnly = true;
            this.StopTime.Width = 78;
            // 
            // IsCmd
            // 
            this.IsCmd.DataPropertyName = "IsCmd";
            this.IsCmd.HeaderText = "是否命令";
            this.IsCmd.Name = "IsCmd";
            this.IsCmd.ReadOnly = true;
            this.IsCmd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsCmd.Visible = false;
            this.IsCmd.Width = 78;
            // 
            // TpValue
            // 
            this.TpValue.DataPropertyName = "TpValue";
            this.TpValue.HeaderText = "命令值";
            this.TpValue.Name = "TpValue";
            this.TpValue.ReadOnly = true;
            this.TpValue.Width = 66;
            // 
            // grpTPSetting
            // 
            this.grpTPSetting.Controls.Add(this.label6);
            this.grpTPSetting.Controls.Add(this.cbxMaxStopTime);
            this.grpTPSetting.Controls.Add(this.label5);
            this.grpTPSetting.Controls.Add(this.cmbTimeProc);
            this.grpTPSetting.Controls.Add(this.grpOrderValue);
            this.grpTPSetting.Controls.Add(this.txtStopTime);
            this.grpTPSetting.Controls.Add(this.txtStartTime);
            this.grpTPSetting.Controls.Add(this.label2);
            this.grpTPSetting.Controls.Add(this.label3);
            this.grpTPSetting.Controls.Add(this.label1);
            this.grpTPSetting.Location = new System.Drawing.Point(6, 147);
            this.grpTPSetting.Name = "grpTPSetting";
            this.grpTPSetting.Size = new System.Drawing.Size(465, 98);
            this.grpTPSetting.TabIndex = 2;
            this.grpTPSetting.TabStop = false;
            this.grpTPSetting.Text = "时间程序设置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "(0-999)分";
            // 
            // cbxMaxStopTime
            // 
            this.cbxMaxStopTime.AutoSize = true;
            this.cbxMaxStopTime.Location = new System.Drawing.Point(227, 51);
            this.cbxMaxStopTime.Name = "cbxMaxStopTime";
            this.cbxMaxStopTime.Size = new System.Drawing.Size(48, 16);
            this.cbxMaxStopTime.TabIndex = 3;
            this.cbxMaxStopTime.Text = "最大";
            this.cbxMaxStopTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxMaxStopTime.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "(0-999)分";
            // 
            // cmbTimeProc
            // 
            this.cmbTimeProc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeProc.FormattingEnabled = true;
            this.cmbTimeProc.Location = new System.Drawing.Point(91, 73);
            this.cmbTimeProc.Name = "cmbTimeProc";
            this.cmbTimeProc.Size = new System.Drawing.Size(132, 20);
            this.cmbTimeProc.TabIndex = 4;
            this.cmbTimeProc.SelectedIndexChanged += new System.EventHandler(this.cmbTimeProc_SelectedIndexChanged);
            // 
            // grpOrderValue
            // 
            this.grpOrderValue.Controls.Add(this.label4);
            this.grpOrderValue.Controls.Add(this.rbStatusOff);
            this.grpOrderValue.Controls.Add(this.txtCmdValue);
            this.grpOrderValue.Controls.Add(this.rbStatusOn);
            this.grpOrderValue.Controls.Add(this.lblValue);
            this.grpOrderValue.Location = new System.Drawing.Point(291, 17);
            this.grpOrderValue.Name = "grpOrderValue";
            this.grpOrderValue.Size = new System.Drawing.Size(168, 76);
            this.grpOrderValue.TabIndex = 3;
            this.grpOrderValue.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "(0-999)";
            // 
            // rbStatusOff
            // 
            this.rbStatusOff.AutoSize = true;
            this.rbStatusOff.Location = new System.Drawing.Point(64, 50);
            this.rbStatusOff.Name = "rbStatusOff";
            this.rbStatusOff.Size = new System.Drawing.Size(35, 16);
            this.rbStatusOff.TabIndex = 7;
            this.rbStatusOff.TabStop = true;
            this.rbStatusOff.Text = "关";
            this.rbStatusOff.UseVisualStyleBackColor = true;
            // 
            // txtCmdValue
            // 
            this.txtCmdValue.Location = new System.Drawing.Point(63, 20);
            this.txtCmdValue.Name = "txtCmdValue";
            this.txtCmdValue.Size = new System.Drawing.Size(50, 19);
            this.txtCmdValue.TabIndex = 5;
            // 
            // rbStatusOn
            // 
            this.rbStatusOn.AutoSize = true;
            this.rbStatusOn.Location = new System.Drawing.Point(10, 50);
            this.rbStatusOn.Name = "rbStatusOn";
            this.rbStatusOn.Size = new System.Drawing.Size(35, 16);
            this.rbStatusOn.TabIndex = 6;
            this.rbStatusOn.TabStop = true;
            this.rbStatusOn.Text = "开";
            this.rbStatusOn.UseVisualStyleBackColor = true;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(7, 24);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(47, 12);
            this.lblValue.TabIndex = 0;
            this.lblValue.Text = "命令值：";
            // 
            // txtStopTime
            // 
            this.txtStopTime.Location = new System.Drawing.Point(91, 49);
            this.txtStopTime.Name = "txtStopTime";
            this.txtStopTime.Size = new System.Drawing.Size(69, 19);
            this.txtStopTime.TabIndex = 2;
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(91, 25);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(69, 19);
            this.txtStartTime.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "结束时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "事件动作名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始时间：";
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(477, 154);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModify
            // 
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Location = new System.Drawing.Point(477, 183);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 10;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(477, 212);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gbTimeProc
            // 
            this.gbTimeProc.Controls.Add(this.txtTpName);
            this.gbTimeProc.Controls.Add(this.label7);
            this.gbTimeProc.Controls.Add(this.btnDelete);
            this.gbTimeProc.Controls.Add(this.dgvTimeProc);
            this.gbTimeProc.Controls.Add(this.btnModify);
            this.gbTimeProc.Controls.Add(this.btnAdd);
            this.gbTimeProc.Controls.Add(this.grpTPSetting);
            this.gbTimeProc.Location = new System.Drawing.Point(2, 3);
            this.gbTimeProc.Name = "gbTimeProc";
            this.gbTimeProc.Size = new System.Drawing.Size(564, 279);
            this.gbTimeProc.TabIndex = 4;
            this.gbTimeProc.TabStop = false;
            this.gbTimeProc.Text = "时间程序";
            // 
            // txtTpName
            // 
            this.txtTpName.Location = new System.Drawing.Point(97, 250);
            this.txtTpName.Name = "txtTpName";
            this.txtTpName.Size = new System.Drawing.Size(374, 19);
            this.txtTpName.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "时间程序名：";
            // 
            // TimeProcViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.gbTimeProc);
            this.Name = "TimeProcViewer";
            this.Size = new System.Drawing.Size(570, 286);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeProc)).EndInit();
            this.grpTPSetting.ResumeLayout(false);
            this.grpTPSetting.PerformLayout();
            this.grpOrderValue.ResumeLayout(false);
            this.grpOrderValue.PerformLayout();
            this.gbTimeProc.ResumeLayout(false);
            this.gbTimeProc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimeProc;
        private System.Windows.Forms.GroupBox grpTPSetting;
        private System.Windows.Forms.TextBox txtStopTime;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbStatusOff;
        private System.Windows.Forms.RadioButton rbStatusOn;
        private System.Windows.Forms.GroupBox grpOrderValue;
        private System.Windows.Forms.TextBox txtCmdValue;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gbTimeProc;
        private System.Windows.Forms.ComboBox cmbTimeProc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTpName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn TPid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TPName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StopTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsCmd;
        private System.Windows.Forms.DataGridViewTextBoxColumn TpValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbxMaxStopTime;
    }
}
