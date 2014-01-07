/*-----------------------------------------------------------------------------
//  FILE NAME       : PrintExtBar.cs
//  FUNCTION        : 打印扩展工具条
//  AUTHOR          : 蔡海鹰(2009/06/09)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

/// <summary>
/// 打印属性改变代理
/// </summary>
public delegate void printPropertiesChanged();

namespace ChromatoPrint
{
    /// <summary>
    /// 打印扩展工具条
    /// </summary>
    [ToolboxBitmap(typeof(PrintExtBar), "PrintBar.PrintBar.bmp")]
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class PrintExtBar : ToolStrip
    {


        #region 变量

        /// <summary>
        /// 属性改变事件
        /// </summary>
        public event printPropertiesChanged PrintPropertiesChanged;

        /// <summary>
        /// 打印的文档
        /// </summary>
        private PrintDocument pDoc;

        /// <summary>
        /// 打印预览控件
        /// </summary>
        private PrintPreviewControl prvControl;

        /// <summary>
        /// 标志
        /// </summary>
        private bool isDesign = true;

        /// <summary>
        /// 打印管理的用户控件
        /// </summary>
        private PrintMngUser usPrint = null;

        /// <summary>
        /// 页号
        /// </summary>
        private int noOfPages = 0;

        /// <summary>
        /// 系统变化的标志
        /// </summary>
        private bool systemChange = false;

        /// <summary>
        /// 是否横向打印的标志
        /// </summary>
        private bool isLandscape = false;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public PrintExtBar()
        {
            InitializeComponent();

            this.tscmbZoom.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        #endregion


        #region 方法

        /// <summary>
        /// 水平放大
        /// </summary>
        public bool IsLandscape
        {
            get
            {
                return this.isLandscape;
            }
        }

        /// <summary>
        /// 打印预览控件
        /// </summary>
        public PrintPreviewControl PreviewControl
        {
            get
            {
                return this.prvControl;
            }
            set
            {
                this.prvControl = value;
                this.CheckButtons();
                if (this.prvControl != null)
                {
                    double zoom = this.prvControl.Zoom * 100;
                    this.tscmbZoom.Text = zoom + "%";
                }
            }
        }

        /// <summary>
        /// 初期化工具条里面的按钮
        /// </summary>
        private void CheckButtons()
        {
            bool nullDoc = (this.pDoc == null);
            this.tsbPrint.Enabled = !nullDoc;
            this.tsbPrintProperties.Enabled = !nullDoc;
            bool nullCtl = (this.prvControl == null);
            this.tscmbZoom.Enabled = !nullCtl;
            if (this.prvControl != null)
            {
                if (this.prvControl.StartPage == 0)
                {
                    this.tsbFirstPage.Enabled = false;
                    this.tsbPrevPage.Enabled = false;
                }
                else
                {
                    this.tsbFirstPage.Enabled = true;
                    this.tsbPrevPage.Enabled = true;
                }
                if (this.prvControl.StartPage == (this.noOfPages - 1))
                {
                    this.tsbNextPage.Enabled = false;
                    this.tsbLastPage.Enabled = false;
                }
                else
                {
                    this.tsbNextPage.Enabled = true;
                    this.tsbLastPage.Enabled = true;
                }
            }
            else
            {
                this.tsbFirstPage.Enabled = false;
                this.tsbPrevPage.Enabled = false;
                this.tsbNextPage.Enabled = false;
                this.tsbLastPage.Enabled = false;
            }
        }

        /// <summary>
        /// 关联文档
        /// </summary>
        public PrintDocument Document
        {
            get
            {
                return this.pDoc;
            }
            set
            {
                this.pDoc = value;
                this.CheckButtons();
                if (this.pDoc != null)
                {
                    this.pDoc.BeginPrint += new PrintEventHandler(document_BeginPrint);
                    this.pDoc.PrintPage += new PrintPageEventHandler(document_PrintPage);
                    this.pDoc.EndPrint += new PrintEventHandler(document_EndPrint);
                }
            }
        }

        /// <summary>
        /// 放大倍数
        /// </summary>
        public double Zoom
        {
            get
            {
                if (this.prvControl != null)
                {
                    return this.prvControl.Zoom;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.tscmbZoom.Text = Convert.ToString(value * 100);
                this.SetZoom();
            }
        }

        /// <summary>
        /// 打印管理对象
        /// </summary>
        public PrintMngUser PrintMngUser
        {
            get
            {
                return this.usPrint;
            }
            set
            {
                this.usPrint = value;
            }
        }

        /// <summary>
        /// 设置放大倍数
        /// </summary>
        private void SetZoom()
        {
            
            string zoomText = this.tscmbZoom.Text;
            double zoom = 1;

            if ("".Equals(zoomText))
            {
                return;
            }

            if (null == this.prvControl)
            {
                return;
            }

            switch (zoomText)
            {
                case ZoomConst.Fit:
                    this.prvControl.AutoZoom = true;
                    if (this.usPrint != null)
                    {
                        this.usPrint.AddExtra("ZoomFit", true);
                    }
                    break;
                case ZoomConst.Blank:
                case ZoomConst.Point:
                case ZoomConst.Zero:
                    break;
                default:
                    this.prvControl.AutoZoom = false;
                    if (zoomText.EndsWith("%"))
                    {
                        zoomText = zoomText.Substring(0, zoomText.Length - 1);
                    }
                    zoom = Convert.ToDouble(zoomText) / 100;
                    this.prvControl.Zoom = zoom;
                    if (this.usPrint != null)
                    {
                        this.usPrint.AddExtra("ZoomFit", false);
                        this.usPrint.AddExtra("Zoom", zoom);
                    }
                    break;

            }
        }

        /// <summary>
        /// 装载缺省的设置
        /// </summary>
        public void LoadDefaults()
        {
            if (this.usPrint == null)
            {
                throw new Exception("No form management user control set.");
            }
            if (this.pDoc == null)
            {
                throw new Exception("No pribt document set.");
            }
            int leftMargin = 50;
            int rightMargin = 50;
            int topMargin = 50;
            int bottomMargin = 50;
            this.isLandscape = false;
            if (this.usPrint.Extras != null)
            {
                if (this.usPrint.Extras.ContainsKey("LeftMargin"))
                {
                    leftMargin = Convert.ToInt32(this.usPrint.Extras["LeftMargin"]);
                }
                if (this.usPrint.Extras.ContainsKey("RightMargin"))
                {
                    rightMargin = Convert.ToInt32(this.usPrint.Extras["RightMargin"]);
                }
                if (this.usPrint.Extras.ContainsKey("TopMargin"))
                {
                    topMargin = Convert.ToInt32(this.usPrint.Extras["TopMargin"]);
                }
                if (this.usPrint.Extras.ContainsKey("BottomMargin"))
                {
                    bottomMargin = Convert.ToInt32(this.usPrint.Extras["BottomMargin"]);
                }
                if (this.usPrint.Extras.ContainsKey("IsLandscape"))
                {
                    this.isLandscape = Convert.ToBoolean(this.usPrint.Extras["IsLandscape"]);
                }
                bool fit = false;
                double zoom = 100;
                if (this.usPrint.Extras.ContainsKey("ZoomFit"))
                {
                    fit = Convert.ToBoolean(this.usPrint.Extras["ZoomFit"]);
                }
                if (fit)
                {
                    this.tscmbZoom.Text = "Fit";
                }
                else if (this.usPrint.Extras.ContainsKey("Zoom"))
                {
                    zoom = Convert.ToDouble(this.usPrint.Extras["Zoom"]) * 100;
                    this.tscmbZoom.Text = zoom.ToString("0.##") + "%";
                }
                Margins margins = new Margins(leftMargin, rightMargin, topMargin, bottomMargin);
                this.pDoc.DefaultPageSettings.Margins = margins;
                this.pDoc.DefaultPageSettings.Landscape = this.isLandscape;
            }
        }

        #endregion


        #region 事件

        /// <summary>
        /// 结束打印的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void document_EndPrint(object sender, PrintEventArgs e)
        {
            if (this.prvControl == null)
            {
                throw new Exception("PrintBar does not have a reference to the preview control");
            }
            this.prvControl.StartPage = 0;
            this.tstxtPageNo.Text = "1";
            this.SetZoom();
            this.CheckButtons();
        }

        /// <summary>
        /// 打印当前页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            this.noOfPages++;
        }

        /// <summary>
        /// 开始打印的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void document_BeginPrint(object sender, PrintEventArgs e)
        {
            this.noOfPages = 0;
        }

        /// <summary>
        /// 点中打印按钮，调用关联文档对象来打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.pDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not print document\n" + ex.Message);
            }
        }

        /// <summary>
        /// 点中打印属性按钮，显示属性窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbPrintProperties_Click(object sender, EventArgs e)
        {
            //Shouldn't reach here unless the document is set (see checkButtons)
            PageSetupDialog setup = new PageSetupDialog();
            setup.Document = this.pDoc;
            setup.EnableMetric = true;
            if (setup.ShowDialog() == DialogResult.OK)
                {
                if (this.usPrint != null)
                {
                    this.usPrint.AddExtra("LeftMargin", this.pDoc.DefaultPageSettings.Margins.Left);
                    this.usPrint.AddExtra("RightMargin", this.pDoc.DefaultPageSettings.Margins.Right);
                    this.usPrint.AddExtra("TopMargin", this.pDoc.DefaultPageSettings.Margins.Top);
                    this.usPrint.AddExtra("BottomMargin", this.pDoc.DefaultPageSettings.Margins.Bottom);
                    this.usPrint.AddExtra("IsLandscape", this.pDoc.DefaultPageSettings.Landscape);
                }
                if (this.PrintPropertiesChanged != null)
                {
                    this.PrintPropertiesChanged();
                }
            }
        }

        /// <summary>
        /// 改变放大倍数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscmbZoom_TextUpdate(object sender, EventArgs e)
        {
            if (!this.systemChange)
            {
                this.SetZoom();
            }
        }
        
        /// <summary>
        /// 数字键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void number_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.isDesign = (this.Parent != null) && (this.Parent.ToString().Equals("System.Windows.Forms.Design.DesignerFrame+OverlayControl", StringComparison.OrdinalIgnoreCase));
            if (this.isDesign)
            {
                e.Handled = true;
                return;
            }
            string key = new string(e.KeyChar, 1);
            bool validKey = (e.KeyChar >= 48 && e.KeyChar <= 57)
                || (e.KeyChar == 8);
            if (!validKey)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 放大倍数选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscmbZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.systemChange)
            {
                this.SetZoom();
            }
        }

        /// <summary>
        /// 放大倍数选项焦点离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscmbZoom_Leave(object sender, EventArgs e)
        {
            string zoomText = this.tscmbZoom.Text;
            if ((zoomText.ToLower() != "fit") && (!zoomText.EndsWith("%")))
            {
                this.systemChange = true;
                this.tscmbZoom.Text += "%";
                this.systemChange = false;
            }
        }

        /// <summary>
        /// 点中第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbFirstPage_Click(object sender, EventArgs e)
        {
            if (null == this.prvControl)
            {
                return;
            }

            this.tstxtPageNo.Text = "1";
            this.CheckButtons();
        }

        /// <summary>
        /// 点中最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbLastPage_Click(object sender, EventArgs e)
        {
            if (null == this.prvControl)
            {
                return;
            }

            this.tstxtPageNo.Text = this.noOfPages.ToString();
            this.CheckButtons();
        }

        /// <summary>
        /// 点中下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbNextPage_Click(object sender, EventArgs e)
        {
            if (null == this.prvControl)
            {
                return;
            }

            int pageNo = Convert.ToInt32(this.tstxtPageNo.Text);
            pageNo++;
            this.tstxtPageNo.Text = pageNo.ToString();
            this.CheckButtons();
        }

        /// <summary>
        /// 点中上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbPrevPage_Click(object sender, EventArgs e)
        {
            if (null == this.prvControl)
            {
                return;
            }

            int pageNo = Convert.ToInt32(this.tstxtPageNo.Text);
            pageNo--;
            this.tstxtPageNo.Text = pageNo.ToString();
            this.CheckButtons();
        }

        /// <summary>
        /// 页码改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tstxtPageNo_TextChanged(object sender, EventArgs e)
        {
            if (null == this.prvControl)
            {
                return;
            }

            if (!this.systemChange)
            {
                this.systemChange = true;
                int pageNo = Convert.ToInt32(this.tstxtPageNo.Text);
                if (pageNo > this.noOfPages)
                {
                    pageNo = this.noOfPages;
                }
                if (pageNo < 1)
                {
                    pageNo = 1;
                }
                this.tstxtPageNo.Text = pageNo.ToString();
                this.systemChange = false;
                this.prvControl.StartPage = pageNo - 1;
                this.CheckButtons();
            }
        }

        /// <summary>
        /// 点中显示单页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSinglePage_Click(object sender, EventArgs e)
        {
            if (null == this.prvControl)
            {
                return;
            }
            
            this.tsbSinglePage.Checked = true;
            this.tsbTwoPages.Checked = false;
            this.tsbMultiplePages.Checked = false;
            this.prvControl.Rows = 1;
            this.prvControl.Columns = 1;
            this.CheckButtons();
        }

        /// <summary>
        /// 点中显示双页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbTwoPages_Click(object sender, EventArgs e)
        {
            if (null == this.prvControl)
            {
                return;
            }
            this.tsbSinglePage.Checked = false;
            this.tsbTwoPages.Checked = true;
            this.tsbMultiplePages.Checked = false;
            this.prvControl.Rows = 1;
            this.prvControl.Columns = 2;
            this.CheckButtons();
        }

        /// <summary>
        /// 点中显示多页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbMultiplePages_Click(object sender, EventArgs e)
        {
            if (null == this.prvControl)
            {
                return;
            }

            this.tsbSinglePage.Checked = false;
            this.tsbTwoPages.Checked = false;
            this.tsbMultiplePages.Checked = true;
            this.prvControl.Rows = 2;
            this.prvControl.Columns = 2;
            this.CheckButtons();
        }

        #endregion

    }
}
