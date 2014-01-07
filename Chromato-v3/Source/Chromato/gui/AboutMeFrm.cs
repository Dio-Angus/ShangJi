/*-----------------------------------------------------------------------------
//  FILE NAME       : AboutMeFrm.cs
//  FUNCTION        : 关于窗口类
//  AUTHOR          : 李锋(2009/07/09)
//  CHANGE LOG      :
//  FLAG               DATE        WHO      DESCRIPTION
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using ChromatoTool.util;
using ChromatoTool.ini;

namespace Chromato.gui
{
    /// <summary>
    /// 关于窗口
    /// </summary>
    public partial class AboutMeFrm : Form
    {

        #region 变量

        /// <summary>
        /// 待发送的列表框排序对象
        /// </summary>
        private ListViewColumnSorter lvwColumnSorter = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造函数
        /// </summary>
        public AboutMeFrm()
        {
            InitializeComponent();
            this.LoadUi();
            this.LoadEvent();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.lnkHomePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHomePage_LinkClicked);
            this.lnkAuthorEmail.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lnkAuthorEmail_LinkClicked);
        }

        /// <summary>
        /// 装载窗口控件
        /// </summary>
        private void LoadUi()
        {
            this.LoadRichText();
            this.LoadAllModule();
            //this.LoadReferenceModule();
            this.LoadOtherUi();
        }

        /// <summary>
        /// 装载其它控件
        /// </summary>
        private void LoadOtherUi()
        {
            // Set up web links
            this.lnkHomePage.Links.Add(6, 200, "http://www.sict.stc.sh.cn/product/cgpdt/cgpdt01.htm");

            // 装载电子邮件链接
            this.lnkAuthorEmail.Links[0].LinkData = "mailto:" + "zhangjunzhi@xcast-info.com"
               + ";" + "caihaiying@xcast-info.com"
               + "?Subject=" + Application.ProductName;


            // Get assembly information not available from the application object
            Assembly asm = Assembly.GetEntryAssembly();
            AssemblyDescriptionAttribute aDescr = (AssemblyDescriptionAttribute)
                AssemblyDescriptionAttribute.GetCustomAttribute(asm,
                typeof(AssemblyDescriptionAttribute));
            AssemblyCopyrightAttribute aCopyright = (AssemblyCopyrightAttribute)
                AssemblyCopyrightAttribute.GetCustomAttribute(asm,
                typeof(AssemblyCopyrightAttribute));

            this.Text = "About " + Application.ProductName;
            this.lblName.Text = Application.ProductName;
            this.lblVersion.Text = "Version: " + Application.ProductVersion;

            this.lblDescription.Text = aDescr.Description;
            this.lblCopyright.Text = aCopyright.Copyright;

        }

        /// <summary>
        /// 装载图片文本
        /// </summary>
        private void LoadRichText()
        {
            // Read RTF file from manifest resource stream and display it in the
            // RichTextBox.  NOTE: Edit the About.RTF with WordPad or Word.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("Chromato.gui.About.rtf");
            if (null != stream)
            {
                this.rtbHelp.LoadFile(stream, RichTextBoxStreamType.RichText);
            }
        }

        /// <summary>
        /// 装载模块列表
        /// </summary>
        private void LoadAllModule()
        {

            // 创建一个ListView排序类的对象，并设置listView1的排序器
            lvwColumnSorter = new ListViewColumnSorter();
            this.assembliesListView.ListViewItemSorter = lvwColumnSorter;


            // Fill in loaded modules / version number info list view.
            try
            {
                // Get all modules
                ArrayList ndocItems = new ArrayList();
                foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = module.ModuleName;

                    // Get version info
                    FileVersionInfo verInfo = module.FileVersionInfo;
                    string versionStr = String.Format("{0}.{1}.{2}.{3}",
                                                      verInfo.FileMajorPart,
                                                      verInfo.FileMinorPart,
                                                      verInfo.FileBuildPart,
                                                      verInfo.FilePrivatePart);
                    item.SubItems.Add(versionStr);

                    // Get file date info
                    DateTime lastWriteDate = File.GetLastWriteTime(module.FileName);
                    string dateStr = lastWriteDate.ToString("g");
                    item.SubItems.Add(dateStr);

                    // Get module CompanyName
                    item.SubItems.Add(verInfo.CompanyName);

                    // Get module FileDescription
                    item.SubItems.Add(verInfo.FileDescription);

                    assembliesListView.Items.Add(item);

                    // Stash ndoc related list view items for later
                    if (module.ModuleName.ToLower().StartsWith("Chromato"))
                    {
                        ndocItems.Add(item);
                    }
                }

                // Extract the NDoc related modules and move them to the top
                for (int i = ndocItems.Count; i > 0; i--)
                {
                    ListViewItem ndocItem = (ListViewItem)ndocItems[i - 1];
                    assembliesListView.Items.Remove(ndocItem);
                    assembliesListView.Items.Insert(0, ndocItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 装载模块列表
        /// </summary>
        private void LoadReferenceModule()
        {
            // Display components used by this assembly sorted by name
            AssemblyName[] anComponents = Assembly.GetEntryAssembly().GetReferencedAssemblies();

            foreach (AssemblyName an in anComponents)
            {
                ListViewItem lvi = this.assembliesListView.Items.Add(an.Name);
                lvi.SubItems.Add(an.Version.ToString());
            }
        }

        #endregion


        #region 事件

        /// <summary>
        /// 主页按钮按下的处理
        /// </summary>
        /// <param name="sender">发送对象</param>
        /// <param name="e">事件参数</param>
        private void lnkHomePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkHomePage.Links[lnkHomePage.Links.IndexOf(e.Link)].Visited = true;
            string url = e.Link.LinkData.ToString();
            Process.Start(url);
        }

        /// <summary>
        /// 组件列表视图的排序
        /// </summary>
        /// <param name="sender">发送对象</param>
        /// <param name="e">事件参数</param>
        private void assembliesListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // 检查点击的列是不是现在的排序列.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // 重新设置此列的排序方法.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // 设置排序列，默认为正向排序
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // 用新的排序方法对ListView排序
            this.assembliesListView.Sort();
        }


        /// <summary>
        /// Open the target of the clicked link
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void lnkAuthorEmail_LinkClicked(object sender,LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Launch the e-mail URL, this will fail if user does not
                // have an association for e-mail URLs.
                System.Diagnostics.Process.Start((string)e.Link.LinkData);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                MessageBox.Show("Unable to launch link target.  " +
                    "Reason: " + ex.Message, DefaultItem.SoftName,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

    }
}