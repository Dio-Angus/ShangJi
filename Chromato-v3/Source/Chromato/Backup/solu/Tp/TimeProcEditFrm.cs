/*-----------------------------------------------------------------------------
//  FILE NAME       : TimeProcEditFrm.cs
//  FUNCTION        : 时间程序编辑
//  AUTHOR          : 李锋(2009/05/20)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoTool.ini;
using ChromatoTool.util;

namespace ChromatoCore.solu.Tp
{
    /// <summary>
    /// 时间程序编辑
    /// </summary>
    public partial class TimeProcEditFrm : Form
    {

        #region 变量

        /// <summary>
        /// 时间程序dto
        /// </summary>
        TimeProcDto dtoTimeProc = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="dto"></param>
        public TimeProcEditFrm(TimeProcDto dto)
        {
            InitializeComponent();
            this.dtoTimeProc = dto;

            LoadUi();
            LoadEvent();
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
            this.cmbTimeProc.SelectedIndexChanged += new System.EventHandler(this.cmbTimeProc_SelectedIndexChanged);
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            this.txtStartTime.TextChanged += new System.EventHandler(this.txtStartTime_TextChanged);
            this.txtStopTime.TextChanged += new System.EventHandler(this.txtStopTime_TextChanged);
        }

        /// <summary>
        /// 装载界面
        /// </summary>
        private void LoadUi()
        {
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.PeakWide));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.Slope));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.Drift));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.MinSize));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.ChangeParaTime));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.TimeLock));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.LockBaseline));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.RevertPeak));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.HoriBaseline));
            this.cmbTimeProc.Items.Add(EnumDescription.GetFieldText(TimeProcType.DealTailPeak));

            this.cmbTimeProc.Text = this.dtoTimeProc.ActionName;
            this.txtValue.Text = this.dtoTimeProc.TpValue.ToString();
            this.txtStartTime.Text = this.dtoTimeProc.StartTime.ToString();
            this.txtStopTime.Text = this.dtoTimeProc.StopTime.ToString();
        }

        #endregion


        #region 事件

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTimeProc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dtoTimeProc.ActionName = this.cmbTimeProc.SelectedItem.ToString();
        }

        /// <summary>
        /// 取值焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (!CastString.IsNumber(this.txtValue.Text))
            {
                MessageBox.Show("命令值不是整数！", "取值");
                this.txtValue.Focus();
                return;
            }
            this.dtoTimeProc.TpValue = Convert.ToInt32(this.txtValue.Text);
        }

        /// <summary>
        /// 开始时间焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStartTime_TextChanged(object sender, EventArgs e)
        {
            if (!CastString.IsNumeric(this.txtStartTime.Text))
            {
                MessageBox.Show("开始时间不是数值！", "开始时间");
                this.txtStartTime.Focus();
                return;
            }
            this.dtoTimeProc.StartTime = Convert.ToSingle(this.txtStartTime.Text);
        }

        /// <summary>
        /// 结束时间焦点离开事件，合法性检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStopTime_TextChanged(object sender, EventArgs e)
        {
            if (!CastString.IsNumeric(this.txtStopTime.Text))
            {
                MessageBox.Show("结束时间不是数值！", "结束时间");
                this.txtStopTime.Focus();
                return;
            }
            this.dtoTimeProc.StopTime = Convert.ToSingle(this.txtStopTime.Text);
        }


        #endregion



    }
}
