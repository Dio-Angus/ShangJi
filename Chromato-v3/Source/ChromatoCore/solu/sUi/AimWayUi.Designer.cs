namespace ChromatoCore.solu.sUi
{
    partial class AimWayUi
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
            this.gbReserveTime = new System.Windows.Forms.GroupBox();
            this.rbRelative = new System.Windows.Forms.RadioButton();
            this.rbAbsolute = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbReserveTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbReserveTime
            // 
            this.gbReserveTime.Controls.Add(this.rbRelative);
            this.gbReserveTime.Controls.Add(this.rbAbsolute);
            this.gbReserveTime.Location = new System.Drawing.Point(12, 12);
            this.gbReserveTime.Name = "gbReserveTime";
            this.gbReserveTime.Size = new System.Drawing.Size(170, 54);
            this.gbReserveTime.TabIndex = 35;
            this.gbReserveTime.TabStop = false;
            this.gbReserveTime.Text = "保留时间";
            // 
            // rbRelative
            // 
            this.rbRelative.AutoSize = true;
            this.rbRelative.Location = new System.Drawing.Point(86, 20);
            this.rbRelative.Name = "rbRelative";
            this.rbRelative.Size = new System.Drawing.Size(47, 16);
            this.rbRelative.TabIndex = 1;
            this.rbRelative.TabStop = true;
            this.rbRelative.Text = "相对";
            this.rbRelative.UseVisualStyleBackColor = true;
            // 
            // rbAbsolute
            // 
            this.rbAbsolute.AutoSize = true;
            this.rbAbsolute.Location = new System.Drawing.Point(8, 20);
            this.rbAbsolute.Name = "rbAbsolute";
            this.rbAbsolute.Size = new System.Drawing.Size(47, 16);
            this.rbAbsolute.TabIndex = 0;
            this.rbAbsolute.TabStop = true;
            this.rbAbsolute.Text = "绝对";
            this.rbAbsolute.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(223, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 25);
            this.btnOK.TabIndex = 36;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // AimWayUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 89);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbReserveTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AimWayUi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更改对准方法";
            this.gbReserveTime.ResumeLayout(false);
            this.gbReserveTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbReserveTime;
        private System.Windows.Forms.RadioButton rbRelative;
        private System.Windows.Forms.RadioButton rbAbsolute;
        private System.Windows.Forms.Button btnOK;
    }
}