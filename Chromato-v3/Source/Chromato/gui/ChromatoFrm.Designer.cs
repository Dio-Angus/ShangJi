using ChromatoCore.control;
namespace Chromato.gui
{
    partial class ChromatoFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChromatoFrm));
            this.menuChromato = new System.Windows.Forms.MenuStrip();
            this.tsView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsViewSample = new System.Windows.Forms.ToolStripMenuItem();
            this.tsViewSolution = new System.Windows.Forms.ToolStripMenuItem();
            this.tsViewCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsViewAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.tsViewCompare = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTool = new System.Windows.Forms.ToolStripMenuItem();
            this.tsToolOption = new System.Windows.Forms.ToolStripMenuItem();
            this.tsStatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDatabaseExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDatabaseImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHelpExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.tsBtnConnect = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDisConnect = new System.Windows.Forms.ToolStripButton();
            this.tsButtonOption = new System.Windows.Forms.ToolStripButton();
            this.tsButtonAnaly = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButtonHelp = new System.Windows.Forms.ToolStripButton();
            this.lbTrace = new System.Windows.Forms.ListBox();
            this.splitterMain = new System.Windows.Forms.Splitter();
            this.tvCategory = new System.Windows.Forms.TreeView();
            this.splitterTree = new System.Windows.Forms.Splitter();
            this.gbMain = new ChromatoCore.control.HeaderGroupBox();
            this.tsUpdatePwd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChromato.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuChromato
            // 
            this.menuChromato.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsView,
            this.tsTool,
            this.tsDatabase,
            this.tsHelp});
            this.menuChromato.Location = new System.Drawing.Point(0, 0);
            this.menuChromato.Name = "menuChromato";
            this.menuChromato.Size = new System.Drawing.Size(558, 24);
            this.menuChromato.TabIndex = 3;
            this.menuChromato.Text = "menuStrip1";
            // 
            // tsView
            // 
            this.tsView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsViewSample,
            this.tsViewSolution,
            this.tsViewCollection,
            this.tsViewAnalysis,
            this.tsViewCompare});
            this.tsView.Name = "tsView";
            this.tsView.Size = new System.Drawing.Size(41, 20);
            this.tsView.Text = "查看";
            // 
            // tsViewSample
            // 
            this.tsViewSample.Name = "tsViewSample";
            this.tsViewSample.Size = new System.Drawing.Size(94, 22);
            this.tsViewSample.Text = "样品";
            // 
            // tsViewSolution
            // 
            this.tsViewSolution.Name = "tsViewSolution";
            this.tsViewSolution.Size = new System.Drawing.Size(94, 22);
            this.tsViewSolution.Text = "方案";
            // 
            // tsViewCollection
            // 
            this.tsViewCollection.Name = "tsViewCollection";
            this.tsViewCollection.Size = new System.Drawing.Size(94, 22);
            this.tsViewCollection.Text = "采集";
            // 
            // tsViewAnalysis
            // 
            this.tsViewAnalysis.Name = "tsViewAnalysis";
            this.tsViewAnalysis.Size = new System.Drawing.Size(94, 22);
            this.tsViewAnalysis.Text = "分析";
            // 
            // tsViewCompare
            // 
            this.tsViewCompare.Name = "tsViewCompare";
            this.tsViewCompare.Size = new System.Drawing.Size(94, 22);
            this.tsViewCompare.Text = "比较";
            // 
            // tsTool
            // 
            this.tsTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsToolOption,
            this.tsStatusBar,
            this.tsUser,
            this.tsUpdatePwd});
            this.tsTool.Name = "tsTool";
            this.tsTool.Size = new System.Drawing.Size(41, 20);
            this.tsTool.Text = "工具";
            // 
            // tsToolOption
            // 
            this.tsToolOption.Image = global::Chromato.Properties.Resources.option;
            this.tsToolOption.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsToolOption.Name = "tsToolOption";
            this.tsToolOption.Size = new System.Drawing.Size(152, 22);
            this.tsToolOption.Text = "配置";
            // 
            // tsStatusBar
            // 
            this.tsStatusBar.Checked = true;
            this.tsStatusBar.CheckOnClick = true;
            this.tsStatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsStatusBar.Name = "tsStatusBar";
            this.tsStatusBar.Size = new System.Drawing.Size(152, 22);
            this.tsStatusBar.Text = "状态栏";
            // 
            // tsUser
            // 
            this.tsUser.Name = "tsUser";
            this.tsUser.Size = new System.Drawing.Size(152, 22);
            this.tsUser.Text = "用户管理";
            // 
            // tsDatabase
            // 
            this.tsDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDatabaseExport,
            this.tsDatabaseImport});
            this.tsDatabase.Name = "tsDatabase";
            this.tsDatabase.Size = new System.Drawing.Size(53, 20);
            this.tsDatabase.Text = "数据库";
            this.tsDatabase.Visible = false;
            // 
            // tsDatabaseExport
            // 
            this.tsDatabaseExport.Name = "tsDatabaseExport";
            this.tsDatabaseExport.Size = new System.Drawing.Size(94, 22);
            this.tsDatabaseExport.Text = "导出";
            // 
            // tsDatabaseImport
            // 
            this.tsDatabaseImport.Name = "tsDatabaseImport";
            this.tsDatabaseImport.Size = new System.Drawing.Size(94, 22);
            this.tsDatabaseImport.Text = "导入";
            // 
            // tsHelp
            // 
            this.tsHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsHelpAbout,
            this.tsHelpExit});
            this.tsHelp.Name = "tsHelp";
            this.tsHelp.Size = new System.Drawing.Size(41, 20);
            this.tsHelp.Text = "帮助";
            // 
            // tsHelpAbout
            // 
            this.tsHelpAbout.Image = global::Chromato.Properties.Resources.About;
            this.tsHelpAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsHelpAbout.Name = "tsHelpAbout";
            this.tsHelpAbout.Size = new System.Drawing.Size(94, 22);
            this.tsHelpAbout.Text = "关于";
            // 
            // tsHelpExit
            // 
            this.tsHelpExit.Name = "tsHelpExit";
            this.tsHelpExit.Size = new System.Drawing.Size(94, 22);
            this.tsHelpExit.Text = "退出";
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnConnect,
            this.tsBtnDisConnect,
            this.tsButtonOption,
            this.tsButtonAnaly,
            this.toolStripSeparator1,
            this.tsButtonHelp});
            this.toolStripMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(558, 25);
            this.toolStripMain.TabIndex = 31;
            this.toolStripMain.Text = "toolStripMain";
            // 
            // tsBtnConnect
            // 
            this.tsBtnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnConnect.Image = global::Chromato.Properties.Resources.connect;
            this.tsBtnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnConnect.Name = "tsBtnConnect";
            this.tsBtnConnect.Size = new System.Drawing.Size(23, 22);
            this.tsBtnConnect.Text = "联机";
            // 
            // tsBtnDisConnect
            // 
            this.tsBtnDisConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDisConnect.Image = global::Chromato.Properties.Resources.disconnect;
            this.tsBtnDisConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDisConnect.Name = "tsBtnDisConnect";
            this.tsBtnDisConnect.Size = new System.Drawing.Size(23, 22);
            this.tsBtnDisConnect.Text = "脱机";
            // 
            // tsButtonOption
            // 
            this.tsButtonOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonOption.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonOption.Image")));
            this.tsButtonOption.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonOption.Name = "tsButtonOption";
            this.tsButtonOption.Size = new System.Drawing.Size(23, 22);
            this.tsButtonOption.Text = "Option";
            this.tsButtonOption.Click += new System.EventHandler(this.tsButtonOption_Click);
            // 
            // tsButtonAnaly
            // 
            this.tsButtonAnaly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonAnaly.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonAnaly.Image")));
            this.tsButtonAnaly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonAnaly.Name = "tsButtonAnaly";
            this.tsButtonAnaly.Size = new System.Drawing.Size(23, 22);
            this.tsButtonAnaly.Text = "tsButtonAnaly";
            this.tsButtonAnaly.Click += new System.EventHandler(this.tsButtonAnaly_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButtonHelp
            // 
            this.tsButtonHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonHelp.Image")));
            this.tsButtonHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonHelp.Name = "tsButtonHelp";
            this.tsButtonHelp.Size = new System.Drawing.Size(23, 22);
            this.tsButtonHelp.Text = "About PtpSms";
            this.tsButtonHelp.Click += new System.EventHandler(this.tsButtonHelp_Click);
            // 
            // lbTrace
            // 
            this.lbTrace.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbTrace.FormattingEnabled = true;
            this.lbTrace.ItemHeight = 12;
            this.lbTrace.Location = new System.Drawing.Point(0, 263);
            this.lbTrace.Name = "lbTrace";
            this.lbTrace.Size = new System.Drawing.Size(558, 40);
            this.lbTrace.TabIndex = 19;
            // 
            // splitterMain
            // 
            this.splitterMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterMain.Location = new System.Drawing.Point(0, 260);
            this.splitterMain.Name = "splitterMain";
            this.splitterMain.Size = new System.Drawing.Size(558, 3);
            this.splitterMain.TabIndex = 20;
            this.splitterMain.TabStop = false;
            this.splitterMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitterMain_SplitterMoved);
            // 
            // tvCategory
            // 
            this.tvCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tvCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvCategory.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvCategory.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvCategory.Location = new System.Drawing.Point(0, 49);
            this.tvCategory.Name = "tvCategory";
            this.tvCategory.ShowLines = false;
            this.tvCategory.ShowPlusMinus = false;
            this.tvCategory.ShowRootLines = false;
            this.tvCategory.Size = new System.Drawing.Size(49, 211);
            this.tvCategory.TabIndex = 35;
            // 
            // splitterTree
            // 
            this.splitterTree.Location = new System.Drawing.Point(49, 49);
            this.splitterTree.Name = "splitterTree";
            this.splitterTree.Size = new System.Drawing.Size(6, 211);
            this.splitterTree.TabIndex = 36;
            this.splitterTree.TabStop = false;
            this.splitterTree.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitterTree_SplitterMoved);
            // 
            // gbMain
            // 
            this.gbMain._Padding = 0;
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(55, 49);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(503, 211);
            this.gbMain.TabIndex = 37;
            this.gbMain.TabStop = false;
            this.gbMain.Text = "Graph";
            // 
            // tsUpdatePwd
            // 
            this.tsUpdatePwd.Name = "tsUpdatePwd";
            this.tsUpdatePwd.Size = new System.Drawing.Size(152, 22);
            this.tsUpdatePwd.Text = "密码更新";
            // 
            // ChromatoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 303);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.splitterTree);
            this.Controls.Add(this.tvCategory);
            this.Controls.Add(this.splitterMain);
            this.Controls.Add(this.lbTrace);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuChromato);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuChromato;
            this.MinimumSize = new System.Drawing.Size(200, 330);
            this.Name = "ChromatoFrm";
            this.Text = "Chromato V1.0";
            this.Load += new System.EventHandler(this.ChromatoFrm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChromatoFrm_FormClosing);
            this.Resize += new System.EventHandler(this.GraphDemoFrm_Resize);
            this.menuChromato.ResumeLayout(false);
            this.menuChromato.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuChromato;
        private System.Windows.Forms.ListBox lbTrace;
        private System.Windows.Forms.Splitter splitterMain;
        private System.Windows.Forms.ToolStripMenuItem tsView;
        private System.Windows.Forms.ToolStripMenuItem tsTool;
        private System.Windows.Forms.ToolStripMenuItem tsToolOption;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton tsBtnConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsButtonOption;
        private System.Windows.Forms.ToolStripButton tsButtonHelp;
        private HeaderGroupBox gbMain;
        private System.Windows.Forms.Splitter splitterTree;
        private System.Windows.Forms.TreeView tvCategory;
        private System.Windows.Forms.ToolStripButton tsButtonAnaly;
        private System.Windows.Forms.ToolStripMenuItem tsViewSample;
        private System.Windows.Forms.ToolStripMenuItem tsViewSolution;
        private System.Windows.Forms.ToolStripMenuItem tsViewCollection;
        private System.Windows.Forms.ToolStripMenuItem tsViewAnalysis;
        private System.Windows.Forms.ToolStripMenuItem tsHelp;
        private System.Windows.Forms.ToolStripMenuItem tsHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem tsHelpExit;
        private System.Windows.Forms.ToolStripMenuItem tsDatabase;
        private System.Windows.Forms.ToolStripMenuItem tsDatabaseExport;
        private System.Windows.Forms.ToolStripMenuItem tsDatabaseImport;
        private System.Windows.Forms.ToolStripMenuItem tsStatusBar;
        private System.Windows.Forms.ToolStripMenuItem tsViewCompare;
        private System.Windows.Forms.ToolStripButton tsBtnDisConnect;
        private System.Windows.Forms.ToolStripMenuItem tsUser;
        private System.Windows.Forms.ToolStripMenuItem tsUpdatePwd;




    }
}

