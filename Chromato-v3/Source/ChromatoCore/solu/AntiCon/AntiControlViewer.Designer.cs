﻿namespace ChromatoCore.solu.AntiCon
{
    partial class AntiControlViewer
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
            this.gbAntiControl = new System.Windows.Forms.GroupBox();
            this.txtAntiControlName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tvAntiControl = new System.Windows.Forms.TreeView();
            this.btWrite = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.gbAntiControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAntiControl
            // 
            this.gbAntiControl.Controls.Add(this.btRefresh);
            this.gbAntiControl.Controls.Add(this.btWrite);
            this.gbAntiControl.Controls.Add(this.txtAntiControlName);
            this.gbAntiControl.Controls.Add(this.label1);
            this.gbAntiControl.Controls.Add(this.tvAntiControl);
            this.gbAntiControl.Location = new System.Drawing.Point(3, 2);
            this.gbAntiControl.Name = "gbAntiControl";
            this.gbAntiControl.Size = new System.Drawing.Size(565, 277);
            this.gbAntiControl.TabIndex = 0;
            this.gbAntiControl.TabStop = false;
            this.gbAntiControl.Text = "反控方法";
            // 
            // txtAntiControlName
            // 
            this.txtAntiControlName.Location = new System.Drawing.Point(186, 251);
            this.txtAntiControlName.Name = "txtAntiControlName";
            this.txtAntiControlName.Size = new System.Drawing.Size(195, 21);
            this.txtAntiControlName.TabIndex = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 71;
            this.label1.Text = "反控方法名：";
            // 
            // tvAntiControl
            // 
            this.tvAntiControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvAntiControl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvAntiControl.Location = new System.Drawing.Point(6, 16);
            this.tvAntiControl.Name = "tvAntiControl";
            this.tvAntiControl.Size = new System.Drawing.Size(87, 251);
            this.tvAntiControl.TabIndex = 1;
            // 
            // btWrite
            // 
            this.btWrite.Location = new System.Drawing.Point(484, 249);
            this.btWrite.Name = "btWrite";
            this.btWrite.Size = new System.Drawing.Size(75, 23);
            this.btWrite.TabIndex = 101;
            this.btWrite.Text = "修改";
            this.btWrite.UseVisualStyleBackColor = true;
            this.btWrite.Click += new System.EventHandler(this.btWrite_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(403, 249);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 101;
            this.btRefresh.Text = "更新";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // AntiControlViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.gbAntiControl);
            this.Name = "AntiControlViewer";
            this.Size = new System.Drawing.Size(572, 284);
            this.gbAntiControl.ResumeLayout(false);
            this.gbAntiControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAntiControl;
        private System.Windows.Forms.TreeView tvAntiControl;
        private System.Windows.Forms.TextBox txtAntiControlName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Button btWrite;
    }
}
