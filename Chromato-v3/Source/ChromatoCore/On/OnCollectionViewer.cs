/*-----------------------------------------------------------------------------
//  FILE NAME       : OnCollectionViewer.cs
//  FUNCTION        : 某样品采集方法设置视图
//  AUTHOR          : 李锋(2009/06/26)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoBll.bll;
using ChromatoTool.dto;
using ChromatoTool.util;
using ChromatoBll.serialCom;

namespace ChromatoCore.On
{
    /// <summary>
    /// 某样品采集方法设置视图
    /// </summary>
    public partial class OnCollectionViewer : UserControl
    {


        #region 变量

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
        /// 跨线程控件代理
        /// </summary> 
        private delegate void CrossThreadOperationControl();

        /// <summary>
        /// 更新按钮对象
        /// </summary>
        public Button _btnUpdate = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OnCollectionViewer()
        {
            InitializeComponent();
            this._bizCollection = new CollectionBiz();
            this._dtoCollection = new CollectionDto();
            this.LoadEvent();

            this._btnUpdate = this.btnUpdate;
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

            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);

            this.lblBkColor.Click += new System.EventHandler(this.lblBkColor_Click);
            this.lblForeColor.Click += new System.EventHandler(this.lblForeColor_Click);

        }

        #endregion


        #region 方法

        /// <summary>
        /// 编辑当前方案的信息
        /// </summary>
        /// <param name="dtoPara"></param>
        /// <returns></returns>
        public String LoadEdit(ParaDto dtoPara)
        {
            this._dto = new SolutionDto();
            SolutionBiz bizSolu = new SolutionBiz();
            RelationDto dtoRela = new RelationDto();
            dtoRela.SampleID = dtoPara.SampleID;
            dtoRela.RegisterTime = dtoPara.RegisterTime;

            this._dto.SolutionID = Convert.ToInt32(bizSolu.GetSolutionID(dtoRela));
            bizSolu.QuerySolu(this._dto);

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

            return this._dto.SolutionName;
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

        }

        /// <summary>
        /// 设置自动斜率信息
        /// </summary>
        /// <param name="info"></param>
        public void SetAutoSlopeText(string info)
        {

            // 匿名代理
            CrossThreadOperationControl CrossUpdateNumSlope = delegate()
            {
                UpdateNumSlope(info);
            };
            if (this.numUDSlope.InvokeRequired)
            {
                this.numUDSlope.Invoke(CrossUpdateNumSlope);
            }
        }

        /// <summary>
        /// 更新显示的自动斜率信息
        /// </summary>
        /// <param name="info"></param>
        private void UpdateNumSlope(string info)
        {
            Int32 val = Convert.ToInt32(info);
            if (val > this.numUDSlope.Maximum || val < this.numUDSlope.Minimum)
            {
                return;
            }
            if (this._dtoCollection.AutoSlope)
            {
                this.numUDSlope.Value = val;
                this._dtoCollection.Slope = val;
            }
        }

        /// <summary>
        /// 合法性检验
        /// </summary>
        /// <returns></returns>
        private bool CheckValid()
        {
            if (String.IsNullOrEmpty(this.txtShowMaxY.Text))
            {
                MessageBox.Show("显示上限不能为空！", "显示上限");
                this.txtShowMaxY.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(this.txtShowMaxY.Text))
            {
                MessageBox.Show("显示上限不能为空！", "显示上限");
                this.txtShowMaxY.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(this.txtCollectionName.Text))
            {
                MessageBox.Show("采集方法名称不能为空！", "采集方法名称");
                this.txtCollectionName.Focus();
                return false;
            }

            return true;
        }

        #endregion


        #region 事件

        /// <summary>
        /// 上限文字改变事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtShowMaxY_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtShowMaxY.Text))
            {
                //MessageBox.Show("显示上限不能为空！", "显示上限");
                this.txtShowMaxY.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtShowMaxY.Text))
            {
                MessageBox.Show("显示上限不是数值！", "显示上限");
                this.txtShowMaxY.Focus();
                return;
            }
            if (Version3010.Negative.Equals(this.txtShowMaxY.Text.Trim()))
            {
                this.txtShowMaxY.Focus();
                return;
            }
            Single temp = Convert.ToSingle(this.txtShowMaxY.Text);
            if (this._dtoCollection.ShowMinY >= temp)
            {
                MessageBox.Show("显示上限不能小于上限！", "显示上限");
                this.txtShowMaxY.Focus();
                return;
            }
            this._dtoCollection.ShowMaxY = temp;
        }

        /// <summary>
        /// 下限文字改变事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtShowMinY_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtShowMinY.Text))
            {
                //MessageBox.Show("显示下限不能为空！", "显示下限");
                this.txtShowMinY.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtShowMinY.Text))
            {
                MessageBox.Show("显示下限不是数值！", "显示下限");
                this.txtShowMinY.Focus();
                return;
            }
            if (Version3010.Negative.Equals(this.txtShowMinY.Text.Trim()))
            {
                this.txtShowMinY.Focus();
                return;
            }
            Single temp = Convert.ToSingle(this.txtShowMinY.Text);
            if (this._dtoCollection.ShowMaxY <= temp)
            {
                MessageBox.Show("显示下限不能大于上限！", "显示下限");
                this.txtShowMinY.Focus();
                return;
            }
            this._dtoCollection.ShowMinY = temp;
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
                //MessageBox.Show("采集方法名称不能为空！", "采集方法名称");
                this.txtCollectionName.Focus();
                return;
            }
            this._dtoCollection.CollectionName = this.txtCollectionName.Text;
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
            if (1 > v || 10000 < v)
            {
                MessageBox.Show("满屏时间范围不正确！", "满屏时间");
                this.numUDFullScreenTime.Focus();
                return;
            }
            this._dtoCollection.FullScreenTime = Convert.ToInt32(this.numUDFullScreenTime.Value);
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
        }

        /// <summary>
        /// 更新采集方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(this.CheckValid())
            {
                this._bizCollection.UpdateMethod(this._dtoCollection);
            }
        }

        /// <summary>
        /// 自动斜率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxAutoSlope_CheckedChanged(object sender, EventArgs e)
        {
            this._dtoCollection.AutoSlope = this.cbxAutoSlope.Checked;
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
