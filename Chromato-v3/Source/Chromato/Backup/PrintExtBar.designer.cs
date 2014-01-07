namespace ChromatoPrint
{
    partial class PrintExtBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintExtBar));
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbPrintProperties = new System.Windows.Forms.ToolStripButton();
            this.tscmbZoom = new System.Windows.Forms.ToolStripComboBox();
            this.tstZoom = new System.Windows.Forms.ToolStripLabel();
            this.tslblPage = new System.Windows.Forms.ToolStripLabel();
            this.tsbFirstPage = new System.Windows.Forms.ToolStripButton();
            this.tsbPrevPage = new System.Windows.Forms.ToolStripButton();
            this.tstxtPageNo = new System.Windows.Forms.ToolStripTextBox();
            this.tsbNextPage = new System.Windows.Forms.ToolStripButton();
            this.tsbLastPage = new System.Windows.Forms.ToolStripButton();
            this.tsbSinglePage = new System.Windows.Forms.ToolStripButton();
            this.tsbTwoPages = new System.Windows.Forms.ToolStripButton();
            this.tsbMultiplePages = new System.Windows.Forms.ToolStripButton();
            this.tstSpacer = new System.Windows.Forms.ToolStripLabel();
            this.SuspendLayout();
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(23, 22);
            this.tsbPrint.Text = "Print";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // tsbPrintProperties
            // 
            this.tsbPrintProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrintProperties.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrintProperties.Image")));
            this.tsbPrintProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrintProperties.Name = "tsbPrintProperties";
            this.tsbPrintProperties.Size = new System.Drawing.Size(23, 22);
            this.tsbPrintProperties.Text = "Print Properties";
            this.tsbPrintProperties.Click += new System.EventHandler(this.tsbPrintProperties_Click);
            // 
            // tscmbZoom
            // 
            this.tscmbZoom.Items.AddRange(new object[] {
            "500%",
            "250%",
            "200%",
            "150%",
            "100%",
            "75%",
            "50%",
            "33%",
            "25%",
            "10%",
            "Fit"});
            this.tscmbZoom.Name = "tscmbZoom";
            this.tscmbZoom.Size = new System.Drawing.Size(75, 25);
            this.tscmbZoom.SelectedIndexChanged += new System.EventHandler(this.tscmbZoom_SelectedIndexChanged);
            this.tscmbZoom.TextUpdate += new System.EventHandler(this.tscmbZoom_TextUpdate);
            this.tscmbZoom.Leave += new System.EventHandler(this.tscmbZoom_Leave);
            this.tscmbZoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.number_KeyPress);
            // 
            // tstZoom
            // 
            this.tstZoom.Name = "tstZoom";
            this.tstZoom.Size = new System.Drawing.Size(29, 22);
            this.tstZoom.Text = "Zoom";
            // 
            // tslblPage
            // 
            this.tslblPage.Name = "tslblPage";
            this.tslblPage.Size = new System.Drawing.Size(29, 22);
            this.tslblPage.Text = "Page";
            // 
            // tsbFirstPage
            // 
            this.tsbFirstPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFirstPage.Image = ((System.Drawing.Image)(resources.GetObject("tsbFirstPage.Image")));
            this.tsbFirstPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFirstPage.Margin = new System.Windows.Forms.Padding(0);
            this.tsbFirstPage.Name = "tsbFirstPage";
            this.tsbFirstPage.Size = new System.Drawing.Size(23, 25);
            this.tsbFirstPage.Text = "First Page";
            this.tsbFirstPage.Click += new System.EventHandler(this.tsbFirstPage_Click);
            // 
            // tsbPrevPage
            // 
            this.tsbPrevPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrevPage.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrevPage.Image")));
            this.tsbPrevPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrevPage.Margin = new System.Windows.Forms.Padding(0);
            this.tsbPrevPage.Name = "tsbPrevPage";
            this.tsbPrevPage.Size = new System.Drawing.Size(23, 25);
            this.tsbPrevPage.Text = "Previous Page";
            this.tsbPrevPage.Click += new System.EventHandler(this.tsbPrevPage_Click);
            // 
            // tstxtPageNo
            // 
            this.tstxtPageNo.Name = "tstxtPageNo";
            this.tstxtPageNo.Size = new System.Drawing.Size(30, 25);
            this.tstxtPageNo.Text = "1";
            this.tstxtPageNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.number_KeyPress);
            this.tstxtPageNo.TextChanged += new System.EventHandler(this.tstxtPageNo_TextChanged);
            // 
            // tsbNextPage
            // 
            this.tsbNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNextPage.Image = ((System.Drawing.Image)(resources.GetObject("tsbNextPage.Image")));
            this.tsbNextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNextPage.Margin = new System.Windows.Forms.Padding(0);
            this.tsbNextPage.Name = "tsbNextPage";
            this.tsbNextPage.Size = new System.Drawing.Size(23, 25);
            this.tsbNextPage.Text = "Next Page";
            this.tsbNextPage.Click += new System.EventHandler(this.tsbNextPage_Click);
            // 
            // tsbLastPage
            // 
            this.tsbLastPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLastPage.Image = ((System.Drawing.Image)(resources.GetObject("tsbLastPage.Image")));
            this.tsbLastPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLastPage.Margin = new System.Windows.Forms.Padding(0);
            this.tsbLastPage.Name = "tsbLastPage";
            this.tsbLastPage.Size = new System.Drawing.Size(23, 25);
            this.tsbLastPage.Text = "Last Page";
            this.tsbLastPage.Click += new System.EventHandler(this.tsbLastPage_Click);
            // 
            // tsbSinglePage
            // 
            this.tsbSinglePage.Checked = true;
            this.tsbSinglePage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbSinglePage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSinglePage.Image = ((System.Drawing.Image)(resources.GetObject("tsbSinglePage.Image")));
            this.tsbSinglePage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSinglePage.Name = "tsbSinglePage";
            this.tsbSinglePage.Size = new System.Drawing.Size(23, 22);
            this.tsbSinglePage.Text = "One Page";
            this.tsbSinglePage.Click += new System.EventHandler(this.tsbSinglePage_Click);
            // 
            // tsbTwoPages
            // 
            this.tsbTwoPages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTwoPages.Image = ((System.Drawing.Image)(resources.GetObject("tsbTwoPages.Image")));
            this.tsbTwoPages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTwoPages.Name = "tsbTwoPages";
            this.tsbTwoPages.Size = new System.Drawing.Size(23, 22);
            this.tsbTwoPages.Text = "Two Pages";
            this.tsbTwoPages.Click += new System.EventHandler(this.tsbTwoPages_Click);
            // 
            // tsbMultiplePages
            // 
            this.tsbMultiplePages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMultiplePages.Image = ((System.Drawing.Image)(resources.GetObject("tsbMultiplePages.Image")));
            this.tsbMultiplePages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMultiplePages.Name = "tsbMultiplePages";
            this.tsbMultiplePages.Size = new System.Drawing.Size(23, 22);
            this.tsbMultiplePages.Text = "Multiple Pages";
            this.tsbMultiplePages.Click += new System.EventHandler(this.tsbMultiplePages_Click);
            // 
            // tstSpacer
            // 
            this.tstSpacer.Name = "tstSpacer";
            this.tstSpacer.Size = new System.Drawing.Size(23, 22);
            this.tstSpacer.Text = "   ";
            // 
            // ucPrintBar
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrint,
            this.tsbPrintProperties,
            this.tstZoom,
            this.tscmbZoom,
            this.tsbSinglePage,
            this.tsbTwoPages,
            this.tsbMultiplePages,
            this.tstSpacer,
            this.tslblPage,
            this.tsbFirstPage,
            this.tsbPrevPage,
            this.tstxtPageNo,
            this.tsbNextPage,
            this.tsbLastPage});
            this.Size = new System.Drawing.Size(666, 25);
            this.Text = "ucPrintBar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbPrintProperties;
        private System.Windows.Forms.ToolStripLabel tstZoom;
        private System.Windows.Forms.ToolStripComboBox tscmbZoom;
        private System.Windows.Forms.ToolStripButton tsbSinglePage;
        private System.Windows.Forms.ToolStripButton tsbTwoPages;
        private System.Windows.Forms.ToolStripButton tsbMultiplePages;
        private System.Windows.Forms.ToolStripLabel tstSpacer;
        private System.Windows.Forms.ToolStripLabel tslblPage;
        private System.Windows.Forms.ToolStripButton tsbFirstPage;
        private System.Windows.Forms.ToolStripButton tsbPrevPage;
        private System.Windows.Forms.ToolStripTextBox tstxtPageNo;
        private System.Windows.Forms.ToolStripButton tsbNextPage;
        private System.Windows.Forms.ToolStripButton tsbLastPage;
    
    }
}
