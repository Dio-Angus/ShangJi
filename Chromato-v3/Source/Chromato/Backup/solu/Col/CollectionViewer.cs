/*-----------------------------------------------------------------------------
//  FILE NAME       : CollectionViewer.cs
//  FUNCTION        : 采集方法视图
//  AUTHOR          : 李锋(2009/06/12)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.ini;
using ChromatoTool.dto;
using ChromatoBll.bll;
using ChromatoTool.util;

namespace ChromatoCore.solu.Col
{
    /// <summary>
    /// 采集方法视图
    /// </summary>
    public partial class CollectionViewer : UserControl
    {


        #region 变量

        /// <summary>
        /// 访问方法
        /// </summary>
        public AccessMethod _accessM = AccessMethod.New;

        /// <summary>
        /// 方案dto
        /// </summary>
        private SolutionDto _dto = null;

        /// <summary>
        /// 采集方法逻辑
        /// </summary>
        private CollectionBiz _bizCollection = null;

        /// <summary>
        /// 采集方法dto
        /// </summary>
        private CollectionDto _dtoCollection = null;

        /// <summary>
        /// 是否第一次装载
        /// </summary>
        private bool _isFirst = true;

        /// <summary>
        /// 编辑状态下是否改变了数据
        /// </summary>
        private bool _isEdit = false;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public CollectionViewer(AccessMethod am)
        {
            InitializeComponent();
            this._accessM = am;
            this._bizCollection = new CollectionBiz();
            this._dtoCollection = new CollectionDto();

            this.LoadEvent();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.txtShowMaxY.TextChanged += new System.EventHandler(this.txtShowMaxY_TextChanged);
            this.txtShowMinY.TextChanged += new System.EventHandler(this.txtShowMinY_TextChanged);
            this.txtCollectionName.TextChanged += new System.EventHandler(this.txtCollectionName_TextChanged);

            this.numUDPeakWide.TextChanged += new System.EventHandler(this.numUDPeakWide_TextChanged);
            this.numUDPeakWide.Leave += new System.EventHandler(this.numUDPeakWide_Leave);

            this.numUDSlope.TextChanged += new System.EventHandler(this.numUDSlope_TextChanged);
            this.numUDSlope.Leave += new System.EventHandler(this.numUDSlope_Leave);

            this.numUDStopTime.TextChanged += new System.EventHandler(this.numUDStopTime_TextChanged);
            this.numUDStopTime.Leave += new System.EventHandler(this.numUDStopTime_Leave);

            this.numUDFullScreenTime.TextChanged += new System.EventHandler(this.numUDFullScreenTime_TextChanged);
            this.numUDFullScreenTime.Leave += new System.EventHandler(this.numUDFullScreenTime_Leave);

            this.lblBkColor.Click += new System.EventHandler(this.lblBkColor_Click);
            this.lblForeColor.Click += new System.EventHandler(this.lblForeColor_Click);

        }

        #endregion


        #region 方法
        
        /// <summary>
        /// 复位，清除标志，用户选择的采集方法改变
        /// </summary>
        public void Reset(int collectionID)
        {
            this.LoadView(collectionID);
            this._isFirst = false;
        }

        /// <summary>
        /// 显示采集方法的详细信息
        /// </summary>
        /// <param name="dto"></param>
        public void LoadUi(SolutionDto dto)
        {
            this._dto = dto;
            this.gbCollection.Enabled = (null == this._dto) ? false : true;
            if (null == this._dto)
            {
                return;
            }

            switch (this._accessM)
            {
                case AccessMethod.View:
                    this.LoadView(dto.CollectionID);
                    break;

                case AccessMethod.New:
                    if (this._isFirst)
                    {
                        this.LoadNew();
                        this._isFirst = false;
                    }
                    break;

                case AccessMethod.Edit:
                    if (this._isFirst)
                    {
                        this.LoadEdit();
                        this._isFirst = false;
                    }
                    break;

                case AccessMethod.SaveAs:
                    if (this._isFirst)
                    {
                        this.LoadView(dto.CollectionID);
                        this._isFirst = false;
                    }
                    break;
            }
        }

        /// <summary>
        /// 显示方案的信息
        /// </summary>
        private void LoadView(int collectionID)
        {

            this._dtoCollection.CollectionID = collectionID;

            //第一次装载需要从数据库查询采集方法的具体内容
            this._bizCollection.GetMethodByID(this._dtoCollection);
           
            this.txtCollectionName.Text = this._dtoCollection.CollectionName;
            this.LoadViewOrSaveAs();
        }

        /// <summary>
        /// 查看或者复制
        /// </summary>
        private void LoadViewOrSaveAs()
        {
            this.cbxAutoSlope.Checked = this._dtoCollection.AutoSlope;

            this.txtShowMaxY.Text = this._dtoCollection.ShowMaxY.ToString();
            this.txtShowMinY.Text = this._dtoCollection.ShowMinY.ToString();

            this.numUDPeakWide.Maximum = Convert.ToInt32(this._dtoCollection.PeakWide);
            this.numUDPeakWide.Minimum = this.numUDPeakWide.Maximum;
            this.numUDPeakWide.Value = this.numUDPeakWide.Maximum;

            this.numUDSlope.Maximum = Convert.ToInt32(this._dtoCollection.Slope);
            this.numUDSlope.Minimum = Convert.ToInt32(this._dtoCollection.Slope);
            this.numUDSlope.Value = Convert.ToInt32(this._dtoCollection.Slope);

            this.numUDStopTime.Maximum = Convert.ToInt32(this._dtoCollection.StopTime);
            this.numUDStopTime.Minimum = Convert.ToInt32(this._dtoCollection.StopTime);
            this.numUDStopTime.Value = Convert.ToInt32(this._dtoCollection.StopTime);

            this.numUDFullScreenTime.Maximum = Convert.ToInt32(this._dtoCollection.FullScreenTime);
            this.numUDFullScreenTime.Minimum = Convert.ToInt32(this._dtoCollection.FullScreenTime);
            this.numUDFullScreenTime.Value = Convert.ToInt32(this._dtoCollection.FullScreenTime);

            this.lblBkColor.BackColor = Color.FromArgb(this._dtoCollection.BackColor);
            this.lblForeColor.BackColor = Color.FromArgb(this._dtoCollection.ForeColor);

            this.LoadControlStyle(true);
        }

        /// <summary>
        /// 装载控件的风格
        /// </summary>
        /// <param name="isReadOnly"></param>
        private void LoadControlStyle(bool isReadOnly)
        {
            this.txtCollectionName.ReadOnly = isReadOnly;
            this.txtShowMaxY.ReadOnly = isReadOnly;
            this.txtShowMinY.ReadOnly = isReadOnly;

            this.numUDPeakWide.ReadOnly = isReadOnly;
            this.numUDSlope.ReadOnly = isReadOnly;
            this.numUDStopTime.ReadOnly = isReadOnly;
            this.numUDFullScreenTime.ReadOnly = isReadOnly;

            this.numUDPeakWide.InterceptArrowKeys = !isReadOnly;
            this.numUDSlope.InterceptArrowKeys = !isReadOnly;
            this.numUDStopTime.InterceptArrowKeys = !isReadOnly;
            this.numUDFullScreenTime.InterceptArrowKeys = !isReadOnly;

            this.txtCollectionName.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtShowMaxY.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtShowMinY.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.numUDPeakWide.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.numUDSlope.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.numUDStopTime.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.numUDFullScreenTime.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.cbxAutoSlope.Enabled = isReadOnly ? false : true;
            this.lblBkColor.Enabled = isReadOnly ? false : true;
            this.lblForeColor.Enabled = isReadOnly ? false : true;
        }

        /// <summary>
        /// 新建立方案的信息
        /// </summary>
        private void LoadNew()
        {

            this.LoadControlStyle(false);

            this.txtCollectionName.Text = "新建立采集方法";
            this.cbxAutoSlope.Checked = DefaultCollection.AutoSlope;
            this.txtShowMaxY.Text = DefaultCollection.ShowMaxY.ToString();
            this.txtShowMinY.Text = DefaultCollection.ShowMinY.ToString();

            this.numUDPeakWide.Value = DefaultCollection.PeakWide;
            this.numUDSlope.Value = DefaultCollection.Slope;
            this.numUDStopTime.Value = Convert.ToInt32(DefaultCollection.StopTime);
            this.numUDFullScreenTime.Value = Convert.ToInt32(DefaultCollection.FullScreenTime);

            this.lblBkColor.BackColor = Color.FromArgb(DefaultCollection.BackColor);
            this.lblForeColor.BackColor = Color.FromArgb(DefaultCollection.ForeColor);

            this._dtoCollection.CollectionName = this.txtCollectionName.Text;
            this._dtoCollection.FullScreenTime = Convert.ToInt32(this.numUDFullScreenTime.Value);
            this._dtoCollection.PeakWide = Convert.ToInt32(this.numUDPeakWide.Value);
            this._dtoCollection.ShowMaxY = Convert.ToSingle(this.txtShowMaxY.Text);
            this._dtoCollection.ShowMinY = Convert.ToSingle(this.txtShowMinY.Text);
            this._dtoCollection.Slope = Convert.ToInt32(this.numUDSlope.Value);
            this._dtoCollection.StopTime = Convert.ToInt32(this.numUDStopTime.Value);

            this._dtoCollection.BackColor = this.lblBkColor.BackColor.ToArgb();
            this._dtoCollection.ForeColor = this.lblForeColor.BackColor.ToArgb();
        }

        /// <summary>
        /// 编辑当前方案的信息
        /// </summary>
        private void LoadEdit()
        {

            this._dtoCollection.CollectionID = this._dto.CollectionID;

            //查询采集方法的具体内容
            this._bizCollection.GetMethodByID(this._dtoCollection);

            this.txtCollectionName.Text = this._dtoCollection.CollectionName;
            this.cbxAutoSlope.Checked = this._dtoCollection.AutoSlope;
            this.txtShowMaxY.Text = this._dtoCollection.ShowMaxY.ToString();
            this.txtShowMinY.Text = this._dtoCollection.ShowMinY.ToString();

            this.numUDPeakWide.Value = Convert.ToInt32(this._dtoCollection.PeakWide);
            this.numUDSlope.Value = Convert.ToInt32(this._dtoCollection.Slope);
            this.numUDStopTime.Value = Convert.ToInt32(this._dtoCollection.StopTime);
            this.numUDFullScreenTime.Value = Convert.ToInt32(this._dtoCollection.FullScreenTime);

            this.lblBkColor.BackColor = Color.FromArgb(this._dtoCollection.BackColor);
            this.lblForeColor.BackColor = Color.FromArgb(this._dtoCollection.ForeColor);

            this.LoadControlStyle(false);
        }

        /// <summary>
        /// 显示方案的信息
        /// </summary>
        private void LoadSaveAs()
        {

            this._dtoCollection.CollectionID = this._dto.CollectionID;

            //第一次装载需要从数据库查询采集方法的具体内容
            this._bizCollection.GetMethodByID(this._dtoCollection);

            this.txtCollectionName.Text = this._dtoCollection.CollectionName + DateTime.Now.ToString("_yyyyMMdd");
            this.LoadViewOrSaveAs();
        }

        /// <summary>
        /// 插入采集方法
        /// </summary>
        public void SaveNew(SolutionDto dto)
        {
            if (0 == dto.CollectionID)
            {
                this._bizCollection.InsertMethod(this._dtoCollection);
                dto.CollectionID = this._dtoCollection.CollectionID;
            }
        }

        /// <summary>
        /// 更新采集方法
        /// </summary>
        public void SaveEdit()
        {
            //如果用户编辑过了，那么更新数据库
            if (this._isEdit)
            {
                this._bizCollection.UpdateMethod(this._dtoCollection);
            }
        }

        #endregion


        #region 事件

        /// <summary>
        /// 上限焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtShowMaxY_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtShowMaxY.Text))
            {
                MessageBox.Show("显示上限不能为空！", "显示上限");
                this.txtShowMaxY.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtShowMaxY.Text))
            {
                MessageBox.Show("显示上限不是数值！", "显示上限");
                this.txtShowMaxY.Focus();
                return;
            }
            this._dtoCollection.ShowMaxY = Convert.ToSingle(this.txtShowMaxY.Text);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 下限焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtShowMinY_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtShowMinY.Text))
            {
                MessageBox.Show("显示下限不能为空！", "显示下限");
                this.txtShowMinY.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtShowMinY.Text))
            {
                MessageBox.Show("显示下限不是数值！", "显示下限");
                this.txtShowMinY.Focus();
                return;
            }
            this._dtoCollection.ShowMinY = Convert.ToSingle(this.txtShowMinY.Text);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 采集方法名称焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCollectionName_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtCollectionName.Text))
            {
                MessageBox.Show("采集方法名称不能为空！", "采集方法名称");
                this.txtCollectionName.Focus();
                return;
            }
            this._dtoCollection.CollectionName = this.txtCollectionName.Text;

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 峰宽文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDPeakWide_TextChanged(object sender, EventArgs e)
        {

            Int32 v = Convert.ToInt32(this.numUDPeakWide.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 100 < v)
            {
                MessageBox.Show("峰宽范围不正确！", "峰宽");
                this.numUDPeakWide.Focus();
                return;
            }
            this._dtoCollection.PeakWide = Convert.ToInt32(this.numUDPeakWide.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 峰宽焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDPeakWide_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUDPeakWide.Value.ToString()))
            {
                MessageBox.Show("峰宽范围不正确！", "峰宽");
                this.numUDPeakWide.Focus();
                return;
            }
            this._dtoCollection.PeakWide = Convert.ToInt32(this.numUDPeakWide.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 斜率文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDSlope_TextChanged(object sender, EventArgs e)
        {
            Int32 v = Convert.ToInt32(this.numUDSlope.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 100000 < v)
            {
                MessageBox.Show("斜率范围不正确！", "斜率");
                this.numUDSlope.Focus();
                return;
            }
            this._dtoCollection.Slope = Convert.ToInt32(this.numUDSlope.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        ///  斜率焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDSlope_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUDSlope.Value.ToString()))
            {
                MessageBox.Show("斜率范围不正确！", "斜率");
                this.numUDSlope.Focus();
                return;
            }
            this._dtoCollection.Slope = Convert.ToInt32(this.numUDSlope.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 停止时间改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDStopTime_TextChanged(object sender, EventArgs e)
        {
            Int32 v = Convert.ToInt32(this.numUDStopTime.Value);
            Console.Out.WriteLine(v);
            if (0 > v || 10000 < v)
            {
                MessageBox.Show("停止时间范围不正确！", "停止时间");
                this.numUDStopTime.Focus();
                return;
            }
            this._dtoCollection.StopTime = Convert.ToInt32(this.numUDStopTime.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        ///  停止时间焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDStopTime_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUDStopTime.Value.ToString()))
            {
                MessageBox.Show("停止时间范围不正确！", "停止时间");
                this.numUDStopTime.Focus();
                return;
            }
            this._dtoCollection.StopTime = Convert.ToInt32(this.numUDStopTime.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 满屏时间文字改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDFullScreenTime_TextChanged(object sender, EventArgs e)
        {

            Int32 v = Convert.ToInt32(this.numUDFullScreenTime.Value);
            Console.Out.WriteLine(v);
            if (1 > v || 1000 < v)
            {
                MessageBox.Show("满屏时间范围不正确！", "满屏时间");
                this.numUDFullScreenTime.Focus();
                return;
            }
            this._dtoCollection.FullScreenTime = Convert.ToInt32(this.numUDFullScreenTime.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 满屏时间焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDFullScreenTime_Leave(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.numUDFullScreenTime.Value.ToString()))
            {
                MessageBox.Show("满屏时间范围不正确！", "满屏时间");
                this.numUDFullScreenTime.Focus();
                return;
            }
            this._dtoCollection.FullScreenTime = Convert.ToInt32(this.numUDFullScreenTime.Value);

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 自动斜率选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxAutoSlope_CheckedChanged(object sender, EventArgs e)
        {
            this._dtoCollection.AutoSlope = this.cbxAutoSlope.Checked;

            //更新变更标志
            this._isEdit = true;
        }

        /// <summary>
        /// 控件背景色更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblBkColor_Click(object sender, EventArgs e)
        {
            this.colorDlg.Color = this.lblBkColor.BackColor;
            if (DialogResult.OK == this.colorDlg.ShowDialog())
            {
                this.lblBkColor.BackColor = this.colorDlg.Color;
                this._dtoCollection.BackColor = this.lblBkColor.BackColor.ToArgb();
            }
        }

        /// <summary>
        /// 曲线颜色更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblForeColor_Click(object sender, EventArgs e)
        {
            this.colorDlg.Color = this.lblForeColor.BackColor;
            if (DialogResult.OK == this.colorDlg.ShowDialog())
            {
                this.lblForeColor.BackColor = this.colorDlg.Color;
                this._dtoCollection.ForeColor = this.lblForeColor.BackColor.ToArgb();
            }
        }

        #endregion 


    

    }
}
