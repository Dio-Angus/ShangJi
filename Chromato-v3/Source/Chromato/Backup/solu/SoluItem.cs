/*-----------------------------------------------------------------------------
//  FILE NAME       : SoluItem.cs
//  FUNCTION        : 方案项目
//  AUTHOR          : 李锋(2009/05/22)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoCore.solu.Ana;
using ChromatoTool.ini;
using ChromatoCore.solu.IdT;
using ChromatoCore.solu.Tp;
using ChromatoCore.solu.Info;
using ChromatoTool.dto;
using ChromatoCore.solu.Remark;
using ChromatoCore.solu.Col;
using ChromatoCore.solu.AntiCon;
using System.Drawing;

namespace ChromatoCore.solu
{
    /// <summary>
    /// 方法项目
    /// </summary>
    public partial class SoluItem : UserControl
    {

        #region 变量

        /// <summary>
        /// 信息面板
        /// </summary>
        private SoluInfoViewer _viewSoluInfo = null;

        /// <summary>
        /// 采样参数
        /// </summary>
        private CollectionViewer _viewCollection = null;

        /// <summary>
        /// 分析参数面板
        /// </summary>
        private AnalyViewer _viewAnalyPara = null;

        /// <summary>
        /// 时间程序面板
        /// </summary>
        private TimeProcViewer _viewTimeProc = null;

        /// <summary>
        /// ID表面板
        /// </summary>
        private IdTableViewer _viewIdTable = null;

        /// <summary>
        /// 反控方法面板
        /// </summary>
        private AntiControlViewer _viewAntiCon = null;

        /// <summary>
        /// 备注面板
        /// </summary>
        private SoluRemarkViewer _viewRemark = null;

        /// <summary>
        /// 方案dto
        /// </summary>
        private SolutionDto _dtoSolution = null;

        /// <summary>
        /// 访问方法
        /// </summary>
        private AccessMethod _accessM = AccessMethod.New;

        /// <summary>
        /// 按钮按下事件
        /// </summary>
        public event EventHandler<PageChangeArgs> TabPageChanged;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public SoluItem(AccessMethod am, SolutionDto dto)
        {
            InitializeComponent();
            this._dtoSolution = dto;
            this._accessM = am;
            this.LoadUi(am);
        }

        /// <summary>
        /// 装载画面
        /// </summary>
        private void LoadUi(AccessMethod am)
        {
            this._viewSoluInfo = new SoluInfoViewer(am);
            this.Controls.Add(this._viewSoluInfo);

            this._viewCollection = new CollectionViewer(am);
            this.Controls.Add(this._viewCollection);

            this._viewAnalyPara = new AnalyViewer(am);
            this.Controls.Add(this._viewAnalyPara);

            this._viewIdTable = new IdTableViewer(am);
            this.Controls.Add(this._viewIdTable); 

            this._viewTimeProc = new TimeProcViewer(am);
            this.Controls.Add(this._viewTimeProc);

            this._viewAntiCon = new AntiControlViewer(am);
            this.Controls.Add(this._viewAntiCon);

            this._viewRemark = new SoluRemarkViewer(am);
            this.Controls.Add(this._viewRemark);
            
            this.tbMain.SelectedIndexChanged += new System.EventHandler(this.tbMain_SelectedIndexChanged);

            //方案项目选择改变事件
            this._viewSoluInfo.ItemChanged += new EventHandler<SolutionItemChangeArgs>(viewSolu_ItemChanged);

            this.tbMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tbMain.DrawItem += new DrawItemEventHandler(this.tbMain_DrawItem);

            //分析方法参数变更,导致ID表重新计算校正因子事件
            this._viewAnalyPara.ParaChanged += new EventHandler<AnalyParaChangeArgs>(this._viewIdTable.AnalyParaChanged);

        }

        #endregion


        #region 方法

        /// <summary>
        /// 设置各个页的大小
        /// </summary>
        public void LoadPage()
        {
            this._viewSoluInfo.Width = this.Width;
            this._viewSoluInfo.Top = this.tbMain.Height;
            this._viewSoluInfo.Height = this.Height - this.tbMain.Height;

            this._viewCollection.Width = this.Width;
            this._viewCollection.Top = this.tbMain.Height;
            this._viewCollection.Height = this.Height - this.tbMain.Height;

            this._viewAnalyPara.Width = this.Width;
            this._viewAnalyPara.Top = this.tbMain.Height;
            this._viewAnalyPara.Height = this.Height - this.tbMain.Height;

            this._viewIdTable.Width = this.Width;
            this._viewIdTable.Top = this.tbMain.Height;
            this._viewIdTable.Height = this.Height - this.tbMain.Height;

            this._viewTimeProc.Width = this.Width;
            this._viewTimeProc.Top = this.tbMain.Height;
            this._viewTimeProc.Height = this.Height - this.tbMain.Height;

            this._viewRemark.Width = this.Width;
            this._viewRemark.Top = this.tbMain.Height;
            this._viewRemark.Height = this.Height - this.tbMain.Height;

            this._viewAntiCon.Width = this.Width;
            this._viewAntiCon.Top = this.tbMain.Height;
            this._viewAntiCon.Height = this.Height - this.tbMain.Height;

        }

        /// <summary>
        /// 装载数据流
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="tabtag"></param>
        public void LoadItem(SolutionDto dto, String tabtag)
        {
            this._dtoSolution = dto;

            if(!String.IsNullOrEmpty(tabtag))
            {
                this.ChangeSelectedTab(tabtag);
            }
            this.LoadUi();
            this.LoadViewer(tbMain.SelectedTab.Tag.ToString());
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this._viewSoluInfo.LoadUi(this._dtoSolution);
            this._viewCollection.LoadUi(this._dtoSolution);
            this._viewAnalyPara.LoadUi(this._dtoSolution);
            this._viewTimeProc.LoadUi(this._dtoSolution);
            this._viewIdTable.LoadUi(this._dtoSolution);
            this._viewAntiCon.LoadUi(this._dtoSolution);
            this._viewRemark.LoadUi(this._dtoSolution);
        }

        /// <summary>
        /// 装载当前显示视图
        /// </summary>
        private void LoadViewer(String selectTag)
        {

            this.UnvisiableAllUser();
            
            switch (selectTag)
            {
                case SolutionTab.Info:
                    this._viewSoluInfo.Visible = true;
                    break;

                case SolutionTab.SamplePara:
                    this._viewCollection.Visible = true;
                    break;

                case SolutionTab.AnalyPara:
                    this._viewAnalyPara.Visible = true;
                    break;

                case SolutionTab.TimeProc:
                    this._viewTimeProc.Visible = true;
                    break;

                case SolutionTab.IdTable:
                    this._viewIdTable.Visible = true;
                    break;

                case SolutionTab.AntiMethod:
                    this._viewAntiCon.Visible = true;
                    break;

                case SolutionTab.Remark:
                    this._viewRemark.Visible = true;
                    break;

            }
        }

        /// <summary>
        /// 隐藏所有面板
        /// </summary>
        private void UnvisiableAllUser()
        {
            this._viewAnalyPara.Visible = false;
            this._viewIdTable.Visible = false;
            this._viewTimeProc.Visible = false;
            this._viewRemark.Visible = false;
            this._viewSoluInfo.Visible = false;
            this._viewCollection.Visible = false;
            this._viewAntiCon.Visible = false;
        }

        /// <summary>
        /// 注册保存按钮按下的处理
        /// </summary>
        public bool SaveUi()
        {
            switch (this._accessM)
            {
                case AccessMethod.View:
                    break;

                case AccessMethod.New:
                    if (!this._viewSoluInfo.IsSolutionNameRepetited())
                    {
                        MessageBox.Show("方案名重复","错误");
                        return false;
                    }
                    this._viewTimeProc.SaveNew(this._dtoSolution);
                    this._viewCollection.SaveNew(this._dtoSolution);
                    this._viewAnalyPara.SaveNew(this._dtoSolution);
                    this._viewIdTable.SaveNew(this._dtoSolution);
                    this._viewAntiCon.SaveNew(this._dtoSolution);
                    this._viewSoluInfo.SaveNew();
                    break;

                case AccessMethod.Edit:
                    if (!this._viewSoluInfo.IsSolutionNameRepetited(this._dtoSolution.SolutionID.ToString()))
                    {
                        MessageBox.Show("方案名重复", "错误");
                        return false;
                    }

                    if (0 != this._dtoSolution.SolutionID)
                    {
                        this._viewSoluInfo.SaveEdit();
                    }
                    if (0 != this._dtoSolution.CollectionID)
                    {
                        this._viewCollection.SaveEdit();
                    }
                    if (0 != this._dtoSolution.AnalyParaID)
                    {
                        this._viewAnalyPara.SaveEdit();
                    }
                    if (0 != this._dtoSolution.IDTableID)
                    {
                        this._viewIdTable.SaveEdit();
                    }
                    if (0 != this._dtoSolution.TimeProcID)
                    {
                        this._viewTimeProc.SaveEdit();
                    }
                    if (0 != this._dtoSolution.AntiMethodID)
                    {
                        this._viewAntiCon.SaveEdit();
                    }
                    break;

                case AccessMethod.SaveAs:
                    if (!this._viewSoluInfo.IsSolutionNameRepetited())
                    {
                        MessageBox.Show("方案名重复", "错误");
                        return false;
                    }
                    this._viewSoluInfo.SaveAsUi(this._dtoSolution);
                    break;
            }

            return true;
        }

        /// <summary>
        /// 改变当前显示的Tab页
        /// </summary>
        /// <param name="tabTag"></param>
        private void ChangeSelectedTab(String tabTag)
        {
            foreach( TabPage tp in this.tbMain.TabPages)
            {
                if(tp.Tag.Equals(tabTag))
                {
                    this.tbMain.SelectedTab = tp;
                    break;
                }
            }
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
            this.LoadViewer(tbMain.SelectedTab.Tag.ToString());

            // 发送事件到外部容器
            PageChangeArgs eve = new PageChangeArgs(this.tbMain.SelectedTab.Tag.ToString());
            if (TabPageChanged != null)
            {
                this.TabPageChanged(this, eve);
            }
        }

        /// <summary>
        /// 用户改变了方案中的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewSolu_ItemChanged(object sender, SolutionItemChangeArgs e)
        {
            switch (e._item)
            {
                case SolutionItem.Collection:
                    this._viewCollection.Reset(e._id);
                    break;
                case SolutionItem.Analysis:
                    this._viewAnalyPara.Reset(e._id);
                    break;
                case SolutionItem.IdTable:
                    this._viewIdTable.Reset(e._id);
                    break;
                case SolutionItem.TimeProc:
                    this._viewTimeProc.Reset(e._id);
                    break;
                case SolutionItem.AntiControl:
                    this._viewAntiCon.Reset(e._id);
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
