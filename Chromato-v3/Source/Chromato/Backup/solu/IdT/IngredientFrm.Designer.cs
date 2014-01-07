namespace ChromatoCore.solu.IdT
{
    partial class IngredientFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngredientFrm));
            this.btnChangeTimeWindow = new System.Windows.Forms.Button();
            this.btnChangeTimeBand = new System.Windows.Forms.Button();
            this.btnChangeReserveTime = new System.Windows.Forms.Button();
            this.btnChangeIngredientName = new System.Windows.Forms.Button();
            this.lblTimeWindow = new System.Windows.Forms.Label();
            this.lblTimeBand = new System.Windows.Forms.Label();
            this.lblReserveTime = new System.Windows.Forms.Label();
            this.lblIngredientName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvIdTable = new System.Windows.Forms.DataGridView();
            this.cbxInnerPeak = new System.Windows.Forms.CheckBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeakSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeakHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Density = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactorOne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactorTwo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdTable)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChangeTimeWindow
            // 
            this.btnChangeTimeWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeTimeWindow.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChangeTimeWindow.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeTimeWindow.Image")));
            this.btnChangeTimeWindow.Location = new System.Drawing.Point(250, 14);
            this.btnChangeTimeWindow.Name = "btnChangeTimeWindow";
            this.btnChangeTimeWindow.Size = new System.Drawing.Size(46, 21);
            this.btnChangeTimeWindow.TabIndex = 114;
            this.btnChangeTimeWindow.UseVisualStyleBackColor = true;
            // 
            // btnChangeTimeBand
            // 
            this.btnChangeTimeBand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeTimeBand.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChangeTimeBand.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeTimeBand.Image")));
            this.btnChangeTimeBand.Location = new System.Drawing.Point(250, 37);
            this.btnChangeTimeBand.Name = "btnChangeTimeBand";
            this.btnChangeTimeBand.Size = new System.Drawing.Size(46, 21);
            this.btnChangeTimeBand.TabIndex = 113;
            this.btnChangeTimeBand.UseVisualStyleBackColor = true;
            this.btnChangeTimeBand.Click += new System.EventHandler(this.btnChangeReserveTime_Click);
            // 
            // btnChangeReserveTime
            // 
            this.btnChangeReserveTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeReserveTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChangeReserveTime.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeReserveTime.Image")));
            this.btnChangeReserveTime.Location = new System.Drawing.Point(72, 13);
            this.btnChangeReserveTime.Name = "btnChangeReserveTime";
            this.btnChangeReserveTime.Size = new System.Drawing.Size(46, 21);
            this.btnChangeReserveTime.TabIndex = 112;
            this.btnChangeReserveTime.UseVisualStyleBackColor = true;
            // 
            // btnChangeIngredientName
            // 
            this.btnChangeIngredientName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeIngredientName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChangeIngredientName.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeIngredientName.Image")));
            this.btnChangeIngredientName.Location = new System.Drawing.Point(72, 36);
            this.btnChangeIngredientName.Name = "btnChangeIngredientName";
            this.btnChangeIngredientName.Size = new System.Drawing.Size(46, 21);
            this.btnChangeIngredientName.TabIndex = 111;
            this.btnChangeIngredientName.UseVisualStyleBackColor = true;
            // 
            // lblTimeWindow
            // 
            this.lblTimeWindow.AutoSize = true;
            this.lblTimeWindow.Location = new System.Drawing.Point(303, 18);
            this.lblTimeWindow.Name = "lblTimeWindow";
            this.lblTimeWindow.Size = new System.Drawing.Size(11, 12);
            this.lblTimeWindow.TabIndex = 108;
            this.lblTimeWindow.Text = "5";
            // 
            // lblTimeBand
            // 
            this.lblTimeBand.AutoSize = true;
            this.lblTimeBand.Location = new System.Drawing.Point(303, 42);
            this.lblTimeBand.Name = "lblTimeBand";
            this.lblTimeBand.Size = new System.Drawing.Size(17, 12);
            this.lblTimeBand.TabIndex = 107;
            this.lblTimeBand.Text = "5%";
            // 
            // lblReserveTime
            // 
            this.lblReserveTime.AutoSize = true;
            this.lblReserveTime.Location = new System.Drawing.Point(125, 18);
            this.lblReserveTime.Name = "lblReserveTime";
            this.lblReserveTime.Size = new System.Drawing.Size(53, 12);
            this.lblReserveTime.TabIndex = 106;
            this.lblReserveTime.Text = "0.5 分钟";
            // 
            // lblIngredientName
            // 
            this.lblIngredientName.AutoSize = true;
            this.lblIngredientName.Location = new System.Drawing.Point(125, 42);
            this.lblIngredientName.Name = "lblIngredientName";
            this.lblIngredientName.Size = new System.Drawing.Size(41, 12);
            this.lblIngredientName.TabIndex = 105;
            this.lblIngredientName.Text = "新成分";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 102;
            this.label6.Text = "时间窗：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 101;
            this.label5.Text = "时间带：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 100;
            this.label3.Text = "保留时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 99;
            this.label2.Text = "成分名：";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(473, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 23);
            this.btnSave.TabIndex = 119;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvIdTable
            // 
            this.dgvIdTable.AllowUserToAddRows = false;
            this.dgvIdTable.AllowUserToDeleteRows = false;
            this.dgvIdTable.AllowUserToResizeRows = false;
            this.dgvIdTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIdTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.IngredientID,
            this.SampleID,
            this.PeakSize,
            this.PeakHeight,
            this.Density,
            this.FactorOne,
            this.FactorTwo});
            this.dgvIdTable.Location = new System.Drawing.Point(3, 66);
            this.dgvIdTable.MultiSelect = false;
            this.dgvIdTable.Name = "dgvIdTable";
            this.dgvIdTable.RowHeadersVisible = false;
            this.dgvIdTable.RowTemplate.Height = 23;
            this.dgvIdTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIdTable.Size = new System.Drawing.Size(554, 242);
            this.dgvIdTable.TabIndex = 120;
            // 
            // cbxInnerPeak
            // 
            this.cbxInnerPeak.AutoSize = true;
            this.cbxInnerPeak.Location = new System.Drawing.Point(339, 17);
            this.cbxInnerPeak.Name = "cbxInnerPeak";
            this.cbxInnerPeak.Size = new System.Drawing.Size(84, 16);
            this.cbxInnerPeak.TabIndex = 121;
            this.cbxInnerPeak.Text = "是否内标峰";
            this.cbxInnerPeak.UseVisualStyleBackColor = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // IngredientID
            // 
            this.IngredientID.DataPropertyName = "IngredientID";
            this.IngredientID.HeaderText = "IngredientID";
            this.IngredientID.Name = "IngredientID";
            this.IngredientID.Visible = false;
            // 
            // SampleID
            // 
            this.SampleID.DataPropertyName = "SampleID";
            this.SampleID.FillWeight = 80F;
            this.SampleID.HeaderText = "样品ID";
            this.SampleID.Name = "SampleID";
            this.SampleID.ReadOnly = true;
            this.SampleID.Width = 80;
            // 
            // PeakSize
            // 
            this.PeakSize.DataPropertyName = "PeakSize";
            this.PeakSize.HeaderText = "峰面积";
            this.PeakSize.Name = "PeakSize";
            // 
            // PeakHeight
            // 
            this.PeakHeight.DataPropertyName = "PeakHeight";
            this.PeakHeight.HeaderText = "峰高度";
            this.PeakHeight.Name = "PeakHeight";
            // 
            // Density
            // 
            this.Density.DataPropertyName = "Density";
            this.Density.HeaderText = "浓度";
            this.Density.Name = "Density";
            // 
            // FactorOne
            // 
            this.FactorOne.DataPropertyName = "FactorOne";
            this.FactorOne.HeaderText = "响应因子1";
            this.FactorOne.Name = "FactorOne";
            // 
            // FactorTwo
            // 
            this.FactorTwo.DataPropertyName = "FactorTwo";
            this.FactorTwo.HeaderText = "响应因子2";
            this.FactorTwo.Name = "FactorTwo";
            // 
            // IngredientFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 311);
            this.Controls.Add(this.cbxInnerPeak);
            this.Controls.Add(this.dgvIdTable);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnChangeTimeWindow);
            this.Controls.Add(this.btnChangeTimeBand);
            this.Controls.Add(this.btnChangeReserveTime);
            this.Controls.Add(this.btnChangeIngredientName);
            this.Controls.Add(this.lblTimeWindow);
            this.Controls.Add(this.lblTimeBand);
            this.Controls.Add(this.lblReserveTime);
            this.Controls.Add(this.lblIngredientName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IngredientFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑成分";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChangeTimeWindow;
        private System.Windows.Forms.Button btnChangeTimeBand;
        private System.Windows.Forms.Button btnChangeReserveTime;
        private System.Windows.Forms.Button btnChangeIngredientName;
        private System.Windows.Forms.Label lblTimeWindow;
        private System.Windows.Forms.Label lblTimeBand;
        private System.Windows.Forms.Label lblReserveTime;
        private System.Windows.Forms.Label lblIngredientName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvIdTable;
        private System.Windows.Forms.CheckBox cbxInnerPeak;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeakSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeakHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Density;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactorOne;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactorTwo;
    }
}