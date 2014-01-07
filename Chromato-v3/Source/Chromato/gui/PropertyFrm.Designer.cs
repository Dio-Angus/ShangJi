namespace Chromato.gui
{
    partial class PropertyFrm
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
            this.lblPlotData = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.cmbItemID_Plot = new System.Windows.Forms.ComboBox();
            this.cmbProperty_Plot = new System.Windows.Forms.ComboBox();
            this.lblProperty = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.btnChangePlot = new System.Windows.Forms.Button();
            this.btnChangeXAxis = new System.Windows.Forms.Button();
            this.cmbProperty_XAxis = new System.Windows.Forms.ComboBox();
            this.cmbItemID_XAxis = new System.Windows.Forms.ComboBox();
            this.lblXAxis = new System.Windows.Forms.Label();
            this.btnChangeYAxis = new System.Windows.Forms.Button();
            this.cmbProperty_YAxis = new System.Windows.Forms.ComboBox();
            this.cmbItemID_YAxis = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeArea = new System.Windows.Forms.Button();
            this.cmbProperty_Area = new System.Windows.Forms.ComboBox();
            this.cmbItemID_Area = new System.Windows.Forms.ComboBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.btnChangeGrid = new System.Windows.Forms.Button();
            this.cmbProperty_Grid = new System.Windows.Forms.ComboBox();
            this.cmbItemID_Grid = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChangeLine = new System.Windows.Forms.Button();
            this.cmbProperty_Line = new System.Windows.Forms.ComboBox();
            this.cmbItemID_Line = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChangeShape = new System.Windows.Forms.Button();
            this.cmbProperty_Shape = new System.Windows.Forms.ComboBox();
            this.cmbItemID_Shape = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChangeLabel = new System.Windows.Forms.Button();
            this.cmbProperty_Label = new System.Windows.Forms.ComboBox();
            this.cmbItemID_Label = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValue_Plot = new System.Windows.Forms.TextBox();
            this.txtValue_XAxis = new System.Windows.Forms.TextBox();
            this.txtValue_YAxis = new System.Windows.Forms.TextBox();
            this.txtValue_Line = new System.Windows.Forms.TextBox();
            this.txtValue_Grid = new System.Windows.Forms.TextBox();
            this.txtValue_Area = new System.Windows.Forms.TextBox();
            this.txtValue_Label = new System.Windows.Forms.TextBox();
            this.txtValue_Shape = new System.Windows.Forms.TextBox();
            this.lblBkColor = new System.Windows.Forms.Label();
            this.colorDlgBK = new System.Windows.Forms.ColorDialog();
            this.btnRestDataTo1000 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.nemUDPlotCount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nemUDPlotCount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlotData
            // 
            this.lblPlotData.AutoSize = true;
            this.lblPlotData.Location = new System.Drawing.Point(1, 36);
            this.lblPlotData.Name = "lblPlotData";
            this.lblPlotData.Size = new System.Drawing.Size(59, 12);
            this.lblPlotData.TabIndex = 0;
            this.lblPlotData.Text = "PlotData:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(80, 11);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(41, 12);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ItemID";
            // 
            // cmbItemID_Plot
            // 
            this.cmbItemID_Plot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemID_Plot.FormattingEnabled = true;
            this.cmbItemID_Plot.Location = new System.Drawing.Point(71, 33);
            this.cmbItemID_Plot.Name = "cmbItemID_Plot";
            this.cmbItemID_Plot.Size = new System.Drawing.Size(92, 20);
            this.cmbItemID_Plot.TabIndex = 2;
            // 
            // cmbProperty_Plot
            // 
            this.cmbProperty_Plot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProperty_Plot.FormattingEnabled = true;
            this.cmbProperty_Plot.Location = new System.Drawing.Point(164, 33);
            this.cmbProperty_Plot.Name = "cmbProperty_Plot";
            this.cmbProperty_Plot.Size = new System.Drawing.Size(146, 20);
            this.cmbProperty_Plot.TabIndex = 4;
            this.cmbProperty_Plot.SelectedIndexChanged += new System.EventHandler(this.cmbProperty_Plot_SelectedIndexChanged);
            // 
            // lblProperty
            // 
            this.lblProperty.AutoSize = true;
            this.lblProperty.Location = new System.Drawing.Point(171, 11);
            this.lblProperty.Name = "lblProperty";
            this.lblProperty.Size = new System.Drawing.Size(53, 12);
            this.lblProperty.TabIndex = 3;
            this.lblProperty.Text = "Property";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(321, 9);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(35, 12);
            this.lblValue.TabIndex = 5;
            this.lblValue.Text = "Value";
            // 
            // btnChangePlot
            // 
            this.btnChangePlot.Location = new System.Drawing.Point(399, 31);
            this.btnChangePlot.Name = "btnChangePlot";
            this.btnChangePlot.Size = new System.Drawing.Size(61, 23);
            this.btnChangePlot.TabIndex = 7;
            this.btnChangePlot.Text = "Change";
            this.btnChangePlot.UseVisualStyleBackColor = true;
            this.btnChangePlot.Click += new System.EventHandler(this.btnChangePlot_Click);
            // 
            // btnChangeXAxis
            // 
            this.btnChangeXAxis.Location = new System.Drawing.Point(399, 56);
            this.btnChangeXAxis.Name = "btnChangeXAxis";
            this.btnChangeXAxis.Size = new System.Drawing.Size(61, 23);
            this.btnChangeXAxis.TabIndex = 12;
            this.btnChangeXAxis.Text = "Change";
            this.btnChangeXAxis.UseVisualStyleBackColor = true;
            this.btnChangeXAxis.Click += new System.EventHandler(this.btnChangeXAxis_Click);
            // 
            // cmbProperty_XAxis
            // 
            this.cmbProperty_XAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProperty_XAxis.FormattingEnabled = true;
            this.cmbProperty_XAxis.Location = new System.Drawing.Point(164, 58);
            this.cmbProperty_XAxis.Name = "cmbProperty_XAxis";
            this.cmbProperty_XAxis.Size = new System.Drawing.Size(146, 20);
            this.cmbProperty_XAxis.TabIndex = 10;
            this.cmbProperty_XAxis.SelectedIndexChanged += new System.EventHandler(this.cmbProperty_XAxis_SelectedIndexChanged);
            // 
            // cmbItemID_XAxis
            // 
            this.cmbItemID_XAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemID_XAxis.FormattingEnabled = true;
            this.cmbItemID_XAxis.Location = new System.Drawing.Point(71, 58);
            this.cmbItemID_XAxis.Name = "cmbItemID_XAxis";
            this.cmbItemID_XAxis.Size = new System.Drawing.Size(92, 20);
            this.cmbItemID_XAxis.TabIndex = 9;
            // 
            // lblXAxis
            // 
            this.lblXAxis.AutoSize = true;
            this.lblXAxis.Location = new System.Drawing.Point(1, 61);
            this.lblXAxis.Name = "lblXAxis";
            this.lblXAxis.Size = new System.Drawing.Size(47, 12);
            this.lblXAxis.TabIndex = 8;
            this.lblXAxis.Text = "X_Axis:";
            // 
            // btnChangeYAxis
            // 
            this.btnChangeYAxis.Location = new System.Drawing.Point(399, 81);
            this.btnChangeYAxis.Name = "btnChangeYAxis";
            this.btnChangeYAxis.Size = new System.Drawing.Size(61, 23);
            this.btnChangeYAxis.TabIndex = 17;
            this.btnChangeYAxis.Text = "Change";
            this.btnChangeYAxis.UseVisualStyleBackColor = true;
            this.btnChangeYAxis.Click += new System.EventHandler(this.btnChangeYAxis_Click);
            // 
            // cmbProperty_YAxis
            // 
            this.cmbProperty_YAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProperty_YAxis.FormattingEnabled = true;
            this.cmbProperty_YAxis.Location = new System.Drawing.Point(164, 83);
            this.cmbProperty_YAxis.Name = "cmbProperty_YAxis";
            this.cmbProperty_YAxis.Size = new System.Drawing.Size(146, 20);
            this.cmbProperty_YAxis.TabIndex = 15;
            this.cmbProperty_YAxis.SelectedIndexChanged += new System.EventHandler(this.cmbProperty_YAxis_SelectedIndexChanged);
            // 
            // cmbItemID_YAxis
            // 
            this.cmbItemID_YAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemID_YAxis.FormattingEnabled = true;
            this.cmbItemID_YAxis.Location = new System.Drawing.Point(71, 83);
            this.cmbItemID_YAxis.Name = "cmbItemID_YAxis";
            this.cmbItemID_YAxis.Size = new System.Drawing.Size(92, 20);
            this.cmbItemID_YAxis.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "Y_Axis:";
            // 
            // btnChangeArea
            // 
            this.btnChangeArea.Location = new System.Drawing.Point(399, 105);
            this.btnChangeArea.Name = "btnChangeArea";
            this.btnChangeArea.Size = new System.Drawing.Size(61, 23);
            this.btnChangeArea.TabIndex = 22;
            this.btnChangeArea.Text = "Change";
            this.btnChangeArea.UseVisualStyleBackColor = true;
            this.btnChangeArea.Click += new System.EventHandler(this.btnChangeArea_Click);
            // 
            // cmbProperty_Area
            // 
            this.cmbProperty_Area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProperty_Area.FormattingEnabled = true;
            this.cmbProperty_Area.Location = new System.Drawing.Point(164, 107);
            this.cmbProperty_Area.Name = "cmbProperty_Area";
            this.cmbProperty_Area.Size = new System.Drawing.Size(146, 20);
            this.cmbProperty_Area.TabIndex = 20;
            this.cmbProperty_Area.SelectedIndexChanged += new System.EventHandler(this.cmbProperty_Area_SelectedIndexChanged);
            // 
            // cmbItemID_Area
            // 
            this.cmbItemID_Area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemID_Area.FormattingEnabled = true;
            this.cmbItemID_Area.Location = new System.Drawing.Point(71, 107);
            this.cmbItemID_Area.Name = "cmbItemID_Area";
            this.cmbItemID_Area.Size = new System.Drawing.Size(92, 20);
            this.cmbItemID_Area.TabIndex = 19;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(1, 110);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(35, 12);
            this.lblArea.TabIndex = 18;
            this.lblArea.Text = "Area:";
            // 
            // btnChangeGrid
            // 
            this.btnChangeGrid.Location = new System.Drawing.Point(399, 129);
            this.btnChangeGrid.Name = "btnChangeGrid";
            this.btnChangeGrid.Size = new System.Drawing.Size(61, 23);
            this.btnChangeGrid.TabIndex = 27;
            this.btnChangeGrid.Text = "Change";
            this.btnChangeGrid.UseVisualStyleBackColor = true;
            this.btnChangeGrid.Click += new System.EventHandler(this.btnChangeGrid_Click);
            // 
            // cmbProperty_Grid
            // 
            this.cmbProperty_Grid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProperty_Grid.FormattingEnabled = true;
            this.cmbProperty_Grid.Location = new System.Drawing.Point(164, 131);
            this.cmbProperty_Grid.Name = "cmbProperty_Grid";
            this.cmbProperty_Grid.Size = new System.Drawing.Size(146, 20);
            this.cmbProperty_Grid.TabIndex = 25;
            this.cmbProperty_Grid.SelectedIndexChanged += new System.EventHandler(this.cmbProperty_Grid_SelectedIndexChanged);
            // 
            // cmbItemID_Grid
            // 
            this.cmbItemID_Grid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemID_Grid.FormattingEnabled = true;
            this.cmbItemID_Grid.Location = new System.Drawing.Point(71, 131);
            this.cmbItemID_Grid.Name = "cmbItemID_Grid";
            this.cmbItemID_Grid.Size = new System.Drawing.Size(92, 20);
            this.cmbItemID_Grid.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "Grid:";
            // 
            // btnChangeLine
            // 
            this.btnChangeLine.Location = new System.Drawing.Point(399, 153);
            this.btnChangeLine.Name = "btnChangeLine";
            this.btnChangeLine.Size = new System.Drawing.Size(61, 23);
            this.btnChangeLine.TabIndex = 32;
            this.btnChangeLine.Text = "Change";
            this.btnChangeLine.UseVisualStyleBackColor = true;
            this.btnChangeLine.Click += new System.EventHandler(this.btnChangeLine_Click);
            // 
            // cmbProperty_Line
            // 
            this.cmbProperty_Line.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProperty_Line.FormattingEnabled = true;
            this.cmbProperty_Line.Location = new System.Drawing.Point(164, 155);
            this.cmbProperty_Line.Name = "cmbProperty_Line";
            this.cmbProperty_Line.Size = new System.Drawing.Size(146, 20);
            this.cmbProperty_Line.TabIndex = 30;
            this.cmbProperty_Line.SelectedIndexChanged += new System.EventHandler(this.cmbProperty_Line_SelectedIndexChanged);
            // 
            // cmbItemID_Line
            // 
            this.cmbItemID_Line.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemID_Line.FormattingEnabled = true;
            this.cmbItemID_Line.Location = new System.Drawing.Point(71, 155);
            this.cmbItemID_Line.Name = "cmbItemID_Line";
            this.cmbItemID_Line.Size = new System.Drawing.Size(92, 20);
            this.cmbItemID_Line.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "Line:";
            // 
            // btnChangeShape
            // 
            this.btnChangeShape.Location = new System.Drawing.Point(399, 177);
            this.btnChangeShape.Name = "btnChangeShape";
            this.btnChangeShape.Size = new System.Drawing.Size(61, 23);
            this.btnChangeShape.TabIndex = 37;
            this.btnChangeShape.Text = "Change";
            this.btnChangeShape.UseVisualStyleBackColor = true;
            this.btnChangeShape.Click += new System.EventHandler(this.btnChangeShape_Click);
            // 
            // cmbProperty_Shape
            // 
            this.cmbProperty_Shape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProperty_Shape.FormattingEnabled = true;
            this.cmbProperty_Shape.Location = new System.Drawing.Point(164, 179);
            this.cmbProperty_Shape.Name = "cmbProperty_Shape";
            this.cmbProperty_Shape.Size = new System.Drawing.Size(146, 20);
            this.cmbProperty_Shape.TabIndex = 35;
            this.cmbProperty_Shape.SelectedIndexChanged += new System.EventHandler(this.cmbProperty_Shape_SelectedIndexChanged);
            // 
            // cmbItemID_Shape
            // 
            this.cmbItemID_Shape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemID_Shape.FormattingEnabled = true;
            this.cmbItemID_Shape.Location = new System.Drawing.Point(71, 179);
            this.cmbItemID_Shape.Name = "cmbItemID_Shape";
            this.cmbItemID_Shape.Size = new System.Drawing.Size(92, 20);
            this.cmbItemID_Shape.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = "Shape:";
            // 
            // btnChangeLabel
            // 
            this.btnChangeLabel.Location = new System.Drawing.Point(399, 202);
            this.btnChangeLabel.Name = "btnChangeLabel";
            this.btnChangeLabel.Size = new System.Drawing.Size(61, 23);
            this.btnChangeLabel.TabIndex = 42;
            this.btnChangeLabel.Text = "Change";
            this.btnChangeLabel.UseVisualStyleBackColor = true;
            this.btnChangeLabel.Click += new System.EventHandler(this.btnChangeLabel_Click);
            // 
            // cmbProperty_Label
            // 
            this.cmbProperty_Label.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProperty_Label.FormattingEnabled = true;
            this.cmbProperty_Label.Location = new System.Drawing.Point(164, 204);
            this.cmbProperty_Label.Name = "cmbProperty_Label";
            this.cmbProperty_Label.Size = new System.Drawing.Size(146, 20);
            this.cmbProperty_Label.TabIndex = 40;
            this.cmbProperty_Label.SelectedIndexChanged += new System.EventHandler(this.cmbProperty_Label_SelectedIndexChanged);
            // 
            // cmbItemID_Label
            // 
            this.cmbItemID_Label.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemID_Label.FormattingEnabled = true;
            this.cmbItemID_Label.Location = new System.Drawing.Point(71, 204);
            this.cmbItemID_Label.Name = "cmbItemID_Label";
            this.cmbItemID_Label.Size = new System.Drawing.Size(92, 20);
            this.cmbItemID_Label.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 38;
            this.label5.Text = "Label:";
            // 
            // txtValue_Plot
            // 
            this.txtValue_Plot.Location = new System.Drawing.Point(312, 32);
            this.txtValue_Plot.Name = "txtValue_Plot";
            this.txtValue_Plot.Size = new System.Drawing.Size(81, 21);
            this.txtValue_Plot.TabIndex = 47;
            // 
            // txtValue_XAxis
            // 
            this.txtValue_XAxis.Location = new System.Drawing.Point(312, 58);
            this.txtValue_XAxis.Name = "txtValue_XAxis";
            this.txtValue_XAxis.Size = new System.Drawing.Size(81, 21);
            this.txtValue_XAxis.TabIndex = 48;
            // 
            // txtValue_YAxis
            // 
            this.txtValue_YAxis.Location = new System.Drawing.Point(312, 84);
            this.txtValue_YAxis.Name = "txtValue_YAxis";
            this.txtValue_YAxis.Size = new System.Drawing.Size(81, 21);
            this.txtValue_YAxis.TabIndex = 49;
            // 
            // txtValue_Line
            // 
            this.txtValue_Line.Location = new System.Drawing.Point(312, 156);
            this.txtValue_Line.Name = "txtValue_Line";
            this.txtValue_Line.Size = new System.Drawing.Size(81, 21);
            this.txtValue_Line.TabIndex = 52;
            // 
            // txtValue_Grid
            // 
            this.txtValue_Grid.Location = new System.Drawing.Point(312, 132);
            this.txtValue_Grid.Name = "txtValue_Grid";
            this.txtValue_Grid.Size = new System.Drawing.Size(81, 21);
            this.txtValue_Grid.TabIndex = 51;
            // 
            // txtValue_Area
            // 
            this.txtValue_Area.Location = new System.Drawing.Point(312, 108);
            this.txtValue_Area.Name = "txtValue_Area";
            this.txtValue_Area.Size = new System.Drawing.Size(81, 21);
            this.txtValue_Area.TabIndex = 50;
            // 
            // txtValue_Label
            // 
            this.txtValue_Label.Location = new System.Drawing.Point(312, 203);
            this.txtValue_Label.Name = "txtValue_Label";
            this.txtValue_Label.Size = new System.Drawing.Size(81, 21);
            this.txtValue_Label.TabIndex = 54;
            // 
            // txtValue_Shape
            // 
            this.txtValue_Shape.Location = new System.Drawing.Point(312, 179);
            this.txtValue_Shape.Name = "txtValue_Shape";
            this.txtValue_Shape.Size = new System.Drawing.Size(81, 21);
            this.txtValue_Shape.TabIndex = 53;
            // 
            // lblBkColor
            // 
            this.lblBkColor.AutoSize = true;
            this.lblBkColor.Location = new System.Drawing.Point(1, 235);
            this.lblBkColor.Name = "lblBkColor";
            this.lblBkColor.Size = new System.Drawing.Size(101, 12);
            this.lblBkColor.TabIndex = 55;
            this.lblBkColor.Text = "ChangeBackColor:";
            this.lblBkColor.Click += new System.EventHandler(this.lblBkColor_Click);
            // 
            // btnRestDataTo1000
            // 
            this.btnRestDataTo1000.Location = new System.Drawing.Point(169, 257);
            this.btnRestDataTo1000.Name = "btnRestDataTo1000";
            this.btnRestDataTo1000.Size = new System.Drawing.Size(160, 23);
            this.btnRestDataTo1000.TabIndex = 58;
            this.btnRestDataTo1000.Text = "ResetSetSelectedPlotData:";
            this.btnRestDataTo1000.UseVisualStyleBackColor = true;
            this.btnRestDataTo1000.Click += new System.EventHandler(this.btnRestDataTo1000_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 60;
            this.label6.Text = "当前曲线点数:";
            // 
            // nemUDPlotCount
            // 
            this.nemUDPlotCount.Location = new System.Drawing.Point(90, 257);
            this.nemUDPlotCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nemUDPlotCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nemUDPlotCount.Name = "nemUDPlotCount";
            this.nemUDPlotCount.Size = new System.Drawing.Size(73, 21);
            this.nemUDPlotCount.TabIndex = 61;
            this.nemUDPlotCount.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // PropertyFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 293);
            this.Controls.Add(this.nemUDPlotCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnRestDataTo1000);
            this.Controls.Add(this.lblBkColor);
            this.Controls.Add(this.txtValue_Label);
            this.Controls.Add(this.txtValue_Shape);
            this.Controls.Add(this.txtValue_Line);
            this.Controls.Add(this.txtValue_Grid);
            this.Controls.Add(this.txtValue_Area);
            this.Controls.Add(this.txtValue_YAxis);
            this.Controls.Add(this.txtValue_XAxis);
            this.Controls.Add(this.txtValue_Plot);
            this.Controls.Add(this.btnChangeLabel);
            this.Controls.Add(this.cmbProperty_Label);
            this.Controls.Add(this.cmbItemID_Label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnChangeShape);
            this.Controls.Add(this.cmbProperty_Shape);
            this.Controls.Add(this.cmbItemID_Shape);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnChangeLine);
            this.Controls.Add(this.cmbProperty_Line);
            this.Controls.Add(this.cmbItemID_Line);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnChangeGrid);
            this.Controls.Add(this.cmbProperty_Grid);
            this.Controls.Add(this.cmbItemID_Grid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChangeArea);
            this.Controls.Add(this.cmbProperty_Area);
            this.Controls.Add(this.cmbItemID_Area);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.btnChangeYAxis);
            this.Controls.Add(this.cmbProperty_YAxis);
            this.Controls.Add(this.cmbItemID_YAxis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChangeXAxis);
            this.Controls.Add(this.cmbProperty_XAxis);
            this.Controls.Add(this.cmbItemID_XAxis);
            this.Controls.Add(this.lblXAxis);
            this.Controls.Add(this.btnChangePlot);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.cmbProperty_Plot);
            this.Controls.Add(this.lblProperty);
            this.Controls.Add(this.cmbItemID_Plot);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblPlotData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertyFrm";
            this.Text = "PropertyFrm";
            this.Load += new System.EventHandler(this.PropertyFrm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PropertyFrm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nemUDPlotCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlotData;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ComboBox cmbItemID_Plot;
        private System.Windows.Forms.ComboBox cmbProperty_Plot;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Button btnChangePlot;
        private System.Windows.Forms.Button btnChangeXAxis;
        private System.Windows.Forms.ComboBox cmbProperty_XAxis;
        private System.Windows.Forms.ComboBox cmbItemID_XAxis;
        private System.Windows.Forms.Label lblXAxis;
        private System.Windows.Forms.Button btnChangeYAxis;
        private System.Windows.Forms.ComboBox cmbProperty_YAxis;
        private System.Windows.Forms.ComboBox cmbItemID_YAxis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeArea;
        private System.Windows.Forms.ComboBox cmbProperty_Area;
        private System.Windows.Forms.ComboBox cmbItemID_Area;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Button btnChangeGrid;
        private System.Windows.Forms.ComboBox cmbProperty_Grid;
        private System.Windows.Forms.ComboBox cmbItemID_Grid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChangeLine;
        private System.Windows.Forms.ComboBox cmbProperty_Line;
        private System.Windows.Forms.ComboBox cmbItemID_Line;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChangeShape;
        private System.Windows.Forms.ComboBox cmbProperty_Shape;
        private System.Windows.Forms.ComboBox cmbItemID_Shape;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnChangeLabel;
        private System.Windows.Forms.ComboBox cmbProperty_Label;
        private System.Windows.Forms.ComboBox cmbItemID_Label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValue_Plot;
        private System.Windows.Forms.TextBox txtValue_XAxis;
        private System.Windows.Forms.TextBox txtValue_YAxis;
        private System.Windows.Forms.TextBox txtValue_Line;
        private System.Windows.Forms.TextBox txtValue_Grid;
        private System.Windows.Forms.TextBox txtValue_Area;
        private System.Windows.Forms.TextBox txtValue_Label;
        private System.Windows.Forms.TextBox txtValue_Shape;
        private System.Windows.Forms.Label lblBkColor;
        private System.Windows.Forms.ColorDialog colorDlgBK;
        private System.Windows.Forms.Button btnRestDataTo1000;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nemUDPlotCount;
    }
}