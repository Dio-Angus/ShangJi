namespace ChromatoCore.uiConf
{
    partial class PlotUser
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
            this.txtValue_Plot = new System.Windows.Forms.TextBox();
            this.btnChangePlot = new System.Windows.Forms.Button();
            this.cmbItemID_Plot = new System.Windows.Forms.ComboBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblProperty = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnAddPlot = new System.Windows.Forms.Button();
            this.numUDPlotCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRestDataTo1000 = new System.Windows.Forms.Button();
            this.lsbPlot = new System.Windows.Forms.ListBox();
            this.rbSin = new System.Windows.Forms.RadioButton();
            this.gbPlotType = new System.Windows.Forms.GroupBox();
            this.rbSinRandom = new System.Windows.Forms.RadioButton();
            this.rbRandom = new System.Windows.Forms.RadioButton();
            this.btnInsertDb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUDPlotCount)).BeginInit();
            this.gbPlotType.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtValue_Plot
            // 
            this.txtValue_Plot.Location = new System.Drawing.Point(178, 56);
            this.txtValue_Plot.Name = "txtValue_Plot";
            this.txtValue_Plot.Size = new System.Drawing.Size(81, 21);
            this.txtValue_Plot.TabIndex = 51;
            // 
            // btnChangePlot
            // 
            this.btnChangePlot.Location = new System.Drawing.Point(178, 81);
            this.btnChangePlot.Name = "btnChangePlot";
            this.btnChangePlot.Size = new System.Drawing.Size(81, 47);
            this.btnChangePlot.TabIndex = 50;
            this.btnChangePlot.Text = "Change";
            this.btnChangePlot.UseVisualStyleBackColor = true;
            this.btnChangePlot.Click += new System.EventHandler(this.btnChangePlot_Click);
            // 
            // cmbItemID_Plot
            // 
            this.cmbItemID_Plot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemID_Plot.FormattingEnabled = true;
            this.cmbItemID_Plot.Location = new System.Drawing.Point(72, 13);
            this.cmbItemID_Plot.Name = "cmbItemID_Plot";
            this.cmbItemID_Plot.Size = new System.Drawing.Size(104, 20);
            this.cmbItemID_Plot.TabIndex = 48;
            this.cmbItemID_Plot.SelectedIndexChanged += new System.EventHandler(this.cmbItemID_Plot_SelectedIndexChanged);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(176, 41);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(35, 12);
            this.lblValue.TabIndex = 54;
            this.lblValue.Text = "Value";
            // 
            // lblProperty
            // 
            this.lblProperty.AutoSize = true;
            this.lblProperty.Location = new System.Drawing.Point(12, 39);
            this.lblProperty.Name = "lblProperty";
            this.lblProperty.Size = new System.Drawing.Size(53, 12);
            this.lblProperty.TabIndex = 53;
            this.lblProperty.Text = "Property";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 16);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(41, 12);
            this.lblID.TabIndex = 52;
            this.lblID.Text = "ItemID";
            // 
            // btnAddPlot
            // 
            this.btnAddPlot.Location = new System.Drawing.Point(268, 83);
            this.btnAddPlot.Name = "btnAddPlot";
            this.btnAddPlot.Size = new System.Drawing.Size(81, 47);
            this.btnAddPlot.TabIndex = 66;
            this.btnAddPlot.Text = "AddPlot";
            this.btnAddPlot.UseVisualStyleBackColor = true;
            this.btnAddPlot.Click += new System.EventHandler(this.btnAddPlot_Click);
            // 
            // numUDPlotCount
            // 
            this.numUDPlotCount.Location = new System.Drawing.Point(101, 265);
            this.numUDPlotCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numUDPlotCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDPlotCount.Name = "numUDPlotCount";
            this.numUDPlotCount.Size = new System.Drawing.Size(73, 21);
            this.numUDPlotCount.TabIndex = 65;
            this.numUDPlotCount.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numUDPlotCount.ValueChanged += new System.EventHandler(this.nemUDPlotCount_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 64;
            this.label6.Text = "当前曲线点数:";
            // 
            // btnRestDataTo1000
            // 
            this.btnRestDataTo1000.Location = new System.Drawing.Point(180, 262);
            this.btnRestDataTo1000.Name = "btnRestDataTo1000";
            this.btnRestDataTo1000.Size = new System.Drawing.Size(101, 23);
            this.btnRestDataTo1000.TabIndex = 63;
            this.btnRestDataTo1000.Text = "ResetPlotData";
            this.btnRestDataTo1000.UseVisualStyleBackColor = true;
            this.btnRestDataTo1000.Click += new System.EventHandler(this.btnRestDataTo1000_Click);
            // 
            // lsbPlot
            // 
            this.lsbPlot.FormattingEnabled = true;
            this.lsbPlot.ItemHeight = 12;
            this.lsbPlot.Location = new System.Drawing.Point(12, 56);
            this.lsbPlot.Name = "lsbPlot";
            this.lsbPlot.Size = new System.Drawing.Size(162, 196);
            this.lsbPlot.TabIndex = 67;
            this.lsbPlot.SelectedIndexChanged += new System.EventHandler(this.lsbPlot_SelectedIndexChanged);
            // 
            // rbSin
            // 
            this.rbSin.AutoSize = true;
            this.rbSin.Location = new System.Drawing.Point(8, 29);
            this.rbSin.Name = "rbSin";
            this.rbSin.Size = new System.Drawing.Size(59, 16);
            this.rbSin.TabIndex = 68;
            this.rbSin.TabStop = true;
            this.rbSin.Text = "正弦波";
            this.rbSin.UseVisualStyleBackColor = true;
            this.rbSin.CheckedChanged += new System.EventHandler(this.rbSin_CheckedChanged);
            // 
            // gbPlotType
            // 
            this.gbPlotType.Controls.Add(this.rbSinRandom);
            this.gbPlotType.Controls.Add(this.rbRandom);
            this.gbPlotType.Controls.Add(this.rbSin);
            this.gbPlotType.Location = new System.Drawing.Point(178, 152);
            this.gbPlotType.Name = "gbPlotType";
            this.gbPlotType.Size = new System.Drawing.Size(168, 100);
            this.gbPlotType.TabIndex = 69;
            this.gbPlotType.TabStop = false;
            this.gbPlotType.Text = "曲线类型";
            // 
            // rbSinRandom
            // 
            this.rbSinRandom.AutoSize = true;
            this.rbSinRandom.Location = new System.Drawing.Point(8, 73);
            this.rbSinRandom.Name = "rbSinRandom";
            this.rbSinRandom.Size = new System.Drawing.Size(83, 16);
            this.rbSinRandom.TabIndex = 70;
            this.rbSinRandom.TabStop = true;
            this.rbSinRandom.Text = "正弦随机波";
            this.rbSinRandom.UseVisualStyleBackColor = true;
            this.rbSinRandom.CheckedChanged += new System.EventHandler(this.rbSinRandom_CheckedChanged);
            // 
            // rbRandom
            // 
            this.rbRandom.AutoSize = true;
            this.rbRandom.Location = new System.Drawing.Point(8, 51);
            this.rbRandom.Name = "rbRandom";
            this.rbRandom.Size = new System.Drawing.Size(59, 16);
            this.rbRandom.TabIndex = 69;
            this.rbRandom.TabStop = true;
            this.rbRandom.Text = "随机数";
            this.rbRandom.UseVisualStyleBackColor = true;
            this.rbRandom.CheckedChanged += new System.EventHandler(this.rbRandom_CheckedChanged);
            // 
            // btnInsertDb
            // 
            this.btnInsertDb.Location = new System.Drawing.Point(287, 262);
            this.btnInsertDb.Name = "btnInsertDb";
            this.btnInsertDb.Size = new System.Drawing.Size(75, 23);
            this.btnInsertDb.TabIndex = 70;
            this.btnInsertDb.Text = "InsertToDb";
            this.btnInsertDb.UseVisualStyleBackColor = true;
            this.btnInsertDb.Click += new System.EventHandler(this.btnInsertDb_Click);
            // 
            // PanelPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnInsertDb);
            this.Controls.Add(this.lsbPlot);
            this.Controls.Add(this.btnAddPlot);
            this.Controls.Add(this.numUDPlotCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnRestDataTo1000);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblProperty);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtValue_Plot);
            this.Controls.Add(this.btnChangePlot);
            this.Controls.Add(this.cmbItemID_Plot);
            this.Controls.Add(this.gbPlotType);
            this.Name = "PanelPlot";
            this.Size = new System.Drawing.Size(377, 297);
            ((System.ComponentModel.ISupportInitialize)(this.numUDPlotCount)).EndInit();
            this.gbPlotType.ResumeLayout(false);
            this.gbPlotType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValue_Plot;
        private System.Windows.Forms.Button btnChangePlot;
        private System.Windows.Forms.ComboBox cmbItemID_Plot;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnAddPlot;
        private System.Windows.Forms.NumericUpDown numUDPlotCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRestDataTo1000;
        private System.Windows.Forms.ListBox lsbPlot;
        private System.Windows.Forms.RadioButton rbSin;
        private System.Windows.Forms.GroupBox gbPlotType;
        private System.Windows.Forms.RadioButton rbRandom;
        private System.Windows.Forms.RadioButton rbSinRandom;
        private System.Windows.Forms.Button btnInsertDb;
    }
}
