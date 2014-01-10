namespace OrangeDiaryDivider
{
    partial class FrmDivider
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btBrowse1 = new System.Windows.Forms.Button();
            this.tbSourcePath = new System.Windows.Forms.TextBox();
            this.btBrowse2 = new System.Windows.Forms.Button();
            this.tbObjectivePath = new System.Windows.Forms.TextBox();
            this.btExcute = new System.Windows.Forms.Button();
            this.tbKeyWord = new System.Windows.Forms.TextBox();
            this.btOption = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btBrowse1
            // 
            this.btBrowse1.Location = new System.Drawing.Point(305, 45);
            this.btBrowse1.Name = "btBrowse1";
            this.btBrowse1.Size = new System.Drawing.Size(75, 23);
            this.btBrowse1.TabIndex = 0;
            this.btBrowse1.Text = "Browse";
            this.btBrowse1.UseVisualStyleBackColor = true;
            this.btBrowse1.Click += new System.EventHandler(this.btBrowse1_Click);
            // 
            // tbSourcePath
            // 
            this.tbSourcePath.Location = new System.Drawing.Point(52, 45);
            this.tbSourcePath.Name = "tbSourcePath";
            this.tbSourcePath.Size = new System.Drawing.Size(218, 21);
            this.tbSourcePath.TabIndex = 1;
            // 
            // btBrowse2
            // 
            this.btBrowse2.Location = new System.Drawing.Point(305, 94);
            this.btBrowse2.Name = "btBrowse2";
            this.btBrowse2.Size = new System.Drawing.Size(75, 23);
            this.btBrowse2.TabIndex = 0;
            this.btBrowse2.Text = "Browse";
            this.btBrowse2.UseVisualStyleBackColor = true;
            this.btBrowse2.Click += new System.EventHandler(this.btBrowse2_Click);
            // 
            // tbObjectivePath
            // 
            this.tbObjectivePath.Location = new System.Drawing.Point(52, 94);
            this.tbObjectivePath.Name = "tbObjectivePath";
            this.tbObjectivePath.Size = new System.Drawing.Size(218, 21);
            this.tbObjectivePath.TabIndex = 1;
            // 
            // btExcute
            // 
            this.btExcute.Location = new System.Drawing.Point(245, 149);
            this.btExcute.Name = "btExcute";
            this.btExcute.Size = new System.Drawing.Size(75, 23);
            this.btExcute.TabIndex = 0;
            this.btExcute.Text = "Excute";
            this.btExcute.UseVisualStyleBackColor = true;
            this.btExcute.Click += new System.EventHandler(this.btExcute_Click);
            // 
            // tbKeyWord
            // 
            this.tbKeyWord.Location = new System.Drawing.Point(52, 149);
            this.tbKeyWord.Name = "tbKeyWord";
            this.tbKeyWord.Size = new System.Drawing.Size(131, 21);
            this.tbKeyWord.TabIndex = 1;
            // 
            // btOption
            // 
            this.btOption.Location = new System.Drawing.Point(335, 149);
            this.btOption.Name = "btOption";
            this.btOption.Size = new System.Drawing.Size(75, 23);
            this.btOption.TabIndex = 0;
            this.btOption.Text = "Option";
            this.btOption.UseVisualStyleBackColor = true;
            this.btOption.Click += new System.EventHandler(this.btOption_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "SourcePath";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "ObjectivePath";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "KeyWord";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(0, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "By Dio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 12);
            this.label5.TabIndex = 4;
            // 
            // FrmDivider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 215);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbKeyWord);
            this.Controls.Add(this.tbObjectivePath);
            this.Controls.Add(this.tbSourcePath);
            this.Controls.Add(this.btOption);
            this.Controls.Add(this.btExcute);
            this.Controls.Add(this.btBrowse2);
            this.Controls.Add(this.btBrowse1);
            this.Location = new System.Drawing.Point(500, 300);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDivider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "OrangeDiaryDivider";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btBrowse1;
        private System.Windows.Forms.TextBox tbSourcePath;
        private System.Windows.Forms.Button btBrowse2;
        private System.Windows.Forms.TextBox tbObjectivePath;
        private System.Windows.Forms.Button btExcute;
        private System.Windows.Forms.TextBox tbKeyWord;
        private System.Windows.Forms.Button btOption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

