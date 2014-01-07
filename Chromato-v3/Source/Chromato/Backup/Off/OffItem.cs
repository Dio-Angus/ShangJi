/*-----------------------------------------------------------------------------
//  FILE NAME       : OffItem.cs
//  FUNCTION        : 重分析小项目组合
//  AUTHOR          : 李锋(2009/05/25)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoTool.ini;
using System.Drawing;

namespace ChromatoCore.Off
{
    /// <summary>
    /// 重分析小项目组合
    /// </summary>
    public partial class OffItem : UserControl
    {


        #region 变量

        /// <summary>
        /// 参数面板
        /// </summary>
        public OffResultViewer _resultViewer = null;

        /// <summary>
        /// 导出面板
        /// </summary>
        public OffExportViewer _exportViewer = null;

        /// <summary>
        /// 配置面板
        /// </summary>
        public OffConfigViewer _configViewer = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OffItem()
        {
            InitializeComponent();
            LoadEvent();
            LoadUi();
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {

            this._resultViewer = new OffResultViewer();
            this.Controls.Add(this._resultViewer);

            this._exportViewer = new OffExportViewer();
            this.Controls.Add(this._exportViewer);

            this._configViewer = new OffConfigViewer();
            this.Controls.Add(this._configViewer);
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.tbMain.SelectedIndexChanged += new System.EventHandler(this.tbMain_SelectedIndexChanged);
            this.tbMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tbMain.DrawItem += new DrawItemEventHandler(this.tbMain_DrawItem);
        }

        #endregion


        #region 方法

        /// <summary>
        /// 隐藏所有面板
        /// </summary>
        private void UnvisiableAllPanel()
        {
            this._resultViewer.Visible = false;
            this._exportViewer.Visible = false;
            this._configViewer.Visible = false;
        }

        /// <summary>
        /// 改变大小
        /// </summary>
        internal void UserResize()
        {
            this._resultViewer.Width = this.Width;
            this._resultViewer.Top = this.tbMain.Bottom;
            this._resultViewer.Height = this.Height - this.tbMain.Bottom;

            this._exportViewer.Width = this.Width;
            this._exportViewer.Top = this.tbMain.Bottom;
            this._exportViewer.Height = this.Height - this.tbMain.Bottom;

            this._configViewer.Width = this.Width;
            this._configViewer.Top = this.tbMain.Bottom;
            this._configViewer.Height = this.Height - this.tbMain.Bottom;
        }

        #endregion


        #region 事件

        /// <summary>
        /// 索引改变后显示TAB切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UnvisiableAllPanel();

            switch (this.tbMain.SelectedTab.Tag.ToString())
            {
                case OffProcessTab.Config:
                    this._configViewer.Visible = true;
                    break;
                case OffProcessTab.Export:
                    this._exportViewer.Visible = true;
                    break;
                case OffProcessTab.Result:
                    this._resultViewer.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// 描画Tab项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbMain_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Font fontPage;
            Brush brushBkColor;
            Brush brushForeColor;

            Graphics g = e.Graphics;
            String txtPageName = this.tbMain.TabPages[e.Index].Text;
            Rectangle rectPage = e.Bounds;

            if (e.Index == this.tbMain.SelectedIndex)
            {
                fontPage = e.Font;
                brushForeColor = Brushes.Black;
                brushBkColor = Brushes.Ivory;

                rectPage = new Rectangle(this.tbMain.Bounds.X, e.Bounds.Bottom + 4, this.tbMain.Bounds.Width, this.tbMain.Height - e.Bounds.Height - 4);
                //g.FillRectangle(brushBkColor, rectPage);
                //g.DrawRectangle(Pens.Black, rectPage);
            }
            else
            {
                fontPage = e.Font;
                brushForeColor = Brushes.Black;
                brushBkColor = new SolidBrush(SystemColors.Control);
            }

            StringFormat formatText = new StringFormat();
            g.FillRectangle(brushBkColor, e.Bounds);

            rectPage = new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width + 2, e.Bounds.Height - 2);
            g.DrawString(txtPageName, fontPage, brushForeColor, rectPage, formatText);

        }
        
        #endregion

    }
}
