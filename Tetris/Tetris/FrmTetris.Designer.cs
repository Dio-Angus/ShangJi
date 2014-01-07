﻿namespace Tetris
{
    partial class FrmTetris
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
            this.pbRun = new System.Windows.Forms.PictureBox();
            this.lblReady = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbRun)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbRun
            // 
            this.pbRun.BackColor = System.Drawing.Color.Black;
            this.pbRun.Location = new System.Drawing.Point(9, 11);
            this.pbRun.Name = "pbRun";
            this.pbRun.Size = new System.Drawing.Size(315, 508);
            this.pbRun.TabIndex = 0;
            this.pbRun.TabStop = false;
            this.pbRun.Paint += new System.Windows.Forms.PaintEventHandler(this.pbRun_Paint);
            // 
            // lblReady
            // 
            this.lblReady.BackColor = System.Drawing.Color.Black;
            this.lblReady.Location = new System.Drawing.Point(8, 11);
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(100, 100);
            this.lblReady.TabIndex = 1;
            this.lblReady.Paint += new System.Windows.Forms.PaintEventHandler(this.lblReady_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfig);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.lblReady);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(339, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 531);
            this.panel1.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(22, 128);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(22, 171);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfig.Location = new System.Drawing.Point(22, 214);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 23);
            this.btnConfig.TabIndex = 4;
            this.btnConfig.Text = "设置";
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // FrmTetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 531);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbRun);
            this.KeyPreview = true;
            this.Name = "FrmTetris";
            this.Text = "俄罗斯方块";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTetris_FormClosing);
            this.Load += new System.EventHandler(this.FrmTetris_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTetris_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbRun)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRun;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnConfig;
    }
}