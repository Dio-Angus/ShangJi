/*-----------------------------------------------------------------------------
//  FILE NAME       : OffConfigViewer.cs
//  FUNCTION        : 配置视图
//  AUTHOR          : 李锋(2009/06/19)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


using System;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoBll.bll;
using ChromatoTool.ini;
using ChromatoTool.util;
using System.Collections;

namespace ChromatoCore.Off
{
    /// <summary>
    /// 配置视图
    /// </summary>
    public partial class OffConfigViewer : UserControl
    {


        #region 变量

        /// <summary>
        /// 参数dto
        /// </summary>
        public ParaDto _dtoPara = null;

        /// <summary>
        /// 方案逻辑
        /// </summary>
        private SolutionBiz _bizSolu = null;

        /// <summary>
        /// 扣除基线控件
        /// </summary>
        private OffDeductedBase _bizDeductedBase = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OffConfigViewer()
        {
            InitializeComponent();
            this.LoadUi();
            this.LoadEvent();
        }

        /// <summary>
        /// 装载画面
        /// </summary>
        private void LoadUi()
        {
            this._bizSolu = new SolutionBiz();
            this.UpdateGb();
            this.cbxAutoScale.Checked = Offline.AutoScale;
            this.txtShowMaxY.Text = Offline.ShowMaxY.ToString();
            this.txtShowMinY.Text = Offline.ShowMinY.ToString();
            this.txtShowMaxX.Text = Offline.ShowMaxX.ToString();
            this.txtShowMinX.Text = Offline.ShowMinX.ToString();

            this.cbxShowMarker.Checked = Offline.ShowMarker;
            this._bizDeductedBase = new OffDeductedBase();
            this._bizDeductedBase.Location = new System.Drawing.Point(300, 15);
            this.gbConfig.Controls.Add(this._bizDeductedBase);
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.txtShowMaxY.TextChanged += new System.EventHandler(this.txtShowMaxY_TextChanged);
            this.txtShowMinY.TextChanged += new System.EventHandler(this.txtShowMinY_TextChanged);
            this.txtShowMaxX.TextChanged += new System.EventHandler(this.txtShowMaxX_TextChanged);
            this.txtShowMinX.TextChanged += new System.EventHandler(this.txtShowMinX_TextChanged);
        }

        #endregion


        #region 方法

        /// <summary>
        /// 显示样品信息
        /// </summary>
        /// <param name="dto"></param>
        public void LoadView(ParaDto dto)
        {
            this._dtoPara = dto;

            this.BorderStyle = BorderStyle.FixedSingle;
            this.txtSampleName.ReadOnly = true;
            this.txtSampleName.Text = this._dtoPara.SampleName;

            //查询名
            this.cmbSolution.Items.Clear();

            RelationDto dtoRela = new RelationDto();
            dtoRela.SampleID = dto.SampleID;
            dtoRela.RegisterTime = dto.RegisterTime;

            String temp = this._bizSolu.GetSolutionNameBySampleID(dtoRela);
            if (!String.IsNullOrEmpty(temp))
            {
                this.cmbSolution.Items.Add(temp);
                this.cmbSolution.SelectedIndex = 0;
            }

            this.txtStatus.Text = this._dtoPara.SampleStatus;
        }

        /// <summary>
        /// 更新GroupBox
        /// </summary>
        private void UpdateGb()
        {
            if (this.cbxIsMoveBlank.Checked)
            {
                this.gbConfig.Size = new System.Drawing.Size(920, 220);
            }
            else
            {
                this.gbConfig.Size = new System.Drawing.Size(300, 220);
            }
        }

        /// <summary>
        /// 取得扣除基线的原始数据
        /// </summary>
        public ArrayList LoadOriForDeducted()
        {
            if(!this.cbxIsMoveBlank.Checked)
            {
                return null;
            }

            return this._bizDeductedBase.LoadOriForDeducted();
        }

        #endregion


        #region 事件

        /// <summary>
        /// 是否显示扣空白
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxIsMoveBlank_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateGb();
        }

        /// <summary>
        /// 自动坐标选择框改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxAutoScale_CheckedChanged(object sender, EventArgs e)
        {
            Offline.AutoScale = this.cbxAutoScale.Checked;
        }

        /// <summary>
        /// 是否显示峰的趋势选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxShowMarker_CheckedChanged(object sender, EventArgs e)
        {
            Offline.ShowMarker = this.cbxShowMarker.Checked;
        }

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

            Single temp = Convert.ToSingle(this.txtShowMaxY.Text);
            if (Offline.ShowMinY >= temp)
            {
                MessageBox.Show("显示上限不能小于下限！", "显示上限");
                this.txtShowMaxY.Focus();
                return;
            }

            Offline.ShowMaxY = temp;
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
            Single temp = Convert.ToSingle(this.txtShowMinY.Text);
            if (Offline.ShowMaxY <= temp)
            {
                MessageBox.Show("显示下限不能大于上限！", "显示下限");
                this.txtShowMinY.Focus();
                return;
            }
            Offline.ShowMinY = temp;
        }

        /// <summary>
        /// 左限焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtShowMaxX_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtShowMaxX.Text))
            {
                MessageBox.Show("显示左限不能为空！", "显示左限");
                this.txtShowMaxX.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtShowMaxX.Text))
            {
                MessageBox.Show("显示左限不是数值！", "显示左限");
                this.txtShowMaxX.Focus();
                return;
            }

            Single temp = Convert.ToSingle(this.txtShowMaxX.Text);
            if (Offline.ShowMinX >= temp)
            {
                MessageBox.Show("显示左限不能大于右限！", "显示左限");
                this.txtShowMaxX.Focus();
                return;
            }
            Offline.ShowMaxX = temp;
        }

        /// <summary>
        /// 右限焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtShowMinX_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtShowMinX.Text))
            {
                MessageBox.Show("显示右限不能为空！", "显示右限");
                this.txtShowMinX.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.txtShowMinX.Text))
            {
                MessageBox.Show("显示右限不是数值！", "显示右限");
                this.txtShowMinX.Focus();
                return;
            }

            Single temp = Convert.ToSingle(this.txtShowMinX.Text);
            if (Offline.ShowMaxX <= temp)
            {
                MessageBox.Show("显示右限不能小于左限！", "显示右限");
                this.txtShowMinX.Focus();
                return;
            }
            Offline.ShowMinX = Convert.ToSingle(this.txtShowMinX.Text);
        }

        #endregion

    }
}
