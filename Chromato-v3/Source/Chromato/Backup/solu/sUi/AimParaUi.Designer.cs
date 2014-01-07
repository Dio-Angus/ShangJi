namespace ChromatoCore.solu.sUi
{
    partial class AimParaUi
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
            this.btnOK = new System.Windows.Forms.Button();
            this.gbReserveTime = new System.Windows.Forms.GroupBox();
            this.rbTimeBand = new System.Windows.Forms.RadioButton();
            this.rbTimeWindow = new System.Windows.Forms.RadioButton();
            this.gbReserveTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(221, 14);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 25);
            this.btnOK.TabIndex = 38;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // gbReserveTime
            // 
            this.gbReserveTime.Controls.Add(this.rbTimeBand);
            this.gbReserveTime.Controls.Add(this.rbTimeWindow);
            this.gbReserveTime.Location = new System.Drawing.Point(10, 14);
            this.gbReserveTime.Name = "gbReserveTime";
            this.gbReserveTime.Size = new System.Drawing.Size(170, 54);
            this.gbReserveTime.TabIndex = 37;
            this.gbReserveTime.TabStop = false;
            this.gbReserveTime.Text = "对准参数";
            // 
            // rbTimeBand
            // 
            this.rbTimeBand.AutoSize = true;
            this.rbTimeBand.Location = new System.Drawing.Point(86, 20);
            this.rbTimeBand.Name = "rbTimeBand";
            this.rbTimeBand.Size = new System.Drawing.Size(59, 16);
            this.rbTimeBand.TabIndex = 1;
            this.rbTimeBand.TabStop = true;
            this.rbTimeBand.Text = "时间带";
            this.rbTimeBand.UseVisualStyleBackColor = true;
            // 
            // rbTimeWindow
            // 
            this.rbTimeWindow.AutoSize = true;
            this.rbTimeWindow.Location = new System.Drawing.Point(8, 20);
            this.rbTimeWindow.Name = "rbTimeWindow";
            this.rbTimeWindow.Size = new System.Drawing.Size(59, 16);
            this.rbTimeWindow.TabIndex = 0;
            this.rbTimeWindow.TabStop = true;
            this.rbTimeWindow.Text = "时间窗";
            this.rbTimeWindow.UseVisualStyleBackColor = true;
            // 
            // AimParaUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 83);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbReserveTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AimParaUi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更改对准参数";
            this.gbReserveTime.ResumeLayout(false);
            this.gbReserveTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gbReserveTime;
        private System.Windows.Forms.RadioButton rbTimeBand;
        private System.Windows.Forms.RadioButton rbTimeWindow;
    }
}