using System;
using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoTool.ini;
using ChromatoTool.util;

namespace ChromatoCore.solu.AntiCon
{
    public partial class NetworkBoardUser : UserControl
    {
        #region 变量

        /// <summary>
        /// 分析方法dto
        /// </summary>
        private AntiControlDto _dtoAntiControl = null;

        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public NetworkBoardUser(AntiControlDto dto)
        {
            InitializeComponent();
            this._dtoAntiControl = dto;
        }

        #region 方法

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        public void LoadView(int antiControlID)
        {
            this.LoadViewOrSaveAs();
            //this.LoadControlStyle(true);
        }

        // <summary>
        /// 从缓冲区导入
        /// </summary>
        private void LoadViewOrSaveAs()
        {
            if (null == this._dtoAntiControl.dtoNetworkBoard)
            {
                return;
            }
            this.tbGateIP.Text = this._dtoAntiControl.dtoNetworkBoard.GateIP;
            this.tbSourceIP.Text = this._dtoAntiControl.dtoNetworkBoard.SourceIP;
            this.tbMAC.Text = this._dtoAntiControl.dtoNetworkBoard.MAC;
            this.tbMask.Text = this._dtoAntiControl.dtoNetworkBoard.Mask;

            this.tbSocket0Address.Text = this._dtoAntiControl.dtoNetworkBoard.Socket0Address;
            this.tbSocket0AimIP.Text = this._dtoAntiControl.dtoNetworkBoard.Socket0AimIP;
            this.tbSocket0AimAddress.Text = this._dtoAntiControl.dtoNetworkBoard.Socket0AimAddress;
            this.cbSocket0WorkMode.SelectedIndex = Convert.ToInt32(this._dtoAntiControl.dtoNetworkBoard.Socket0WorkMode);

            this.tbSocket1Address.Text = this._dtoAntiControl.dtoNetworkBoard.Socket1Address;
            this.tbSocket1AimIP.Text = this._dtoAntiControl.dtoNetworkBoard.Socket1AimIP;
            this.tbSocket1AimAddress.Text = this._dtoAntiControl.dtoNetworkBoard.Socket1AimAddress;
            this.cbSocket1WorkMode.SelectedIndex = Convert.ToInt32(this._dtoAntiControl.dtoNetworkBoard.Socket1WorkMode);

            this.tbSocket2Address.Text = this._dtoAntiControl.dtoNetworkBoard.Socket2Address;
            this.tbSocket2AimIP.Text = this._dtoAntiControl.dtoNetworkBoard.Socket2AimIP;
            this.tbSocket2AimAddress.Text = this._dtoAntiControl.dtoNetworkBoard.Socket2AimAddress;
            this.cbSocket2WorkMode.SelectedIndex = Convert.ToInt32(this._dtoAntiControl.dtoNetworkBoard.Socket2WorkMode);

            this.tbSocket3Address.Text = this._dtoAntiControl.dtoNetworkBoard.Socket3Address;
            this.tbSocket3AimIP.Text = this._dtoAntiControl.dtoNetworkBoard.Socket3AimIP;
            this.tbSocket3AimAddress.Text = this._dtoAntiControl.dtoNetworkBoard.Socket3AimAddress;
            this.cbSocket3WorkMode.SelectedIndex = Convert.ToInt32(this._dtoAntiControl.dtoNetworkBoard.Socket3WorkMode);
        }

       /* /// <summary>
        /// 装载控件的风格
        /// </summary>
        /// <param name="isReadOnly"></param>
        private void LoadControlStyle(bool isReadOnly)
        {
            this.txtBalanceTime.ReadOnly = isReadOnly;
            this.txtInitTemp.ReadOnly = isReadOnly;
            this.txtMaintainTime.ReadOnly = isReadOnly;
            this.txtAlertTemp.ReadOnly = isReadOnly;
            this.txtColumnCount.ReadOnly = isReadOnly;

            this.txtRateCol1.ReadOnly = isReadOnly;
            this.txtRateCol2.ReadOnly = isReadOnly;
            this.txtRateCol3.ReadOnly = isReadOnly;
            this.txtRateCol4.ReadOnly = isReadOnly;
            this.txtRateCol5.ReadOnly = isReadOnly;

            this.txtTempCol1.ReadOnly = isReadOnly;
            this.txtTempCol2.ReadOnly = isReadOnly;
            this.txtTempCol3.ReadOnly = isReadOnly;
            this.txtTempCol4.ReadOnly = isReadOnly;
            this.txtTempCol5.ReadOnly = isReadOnly;

            this.txtTempTimeCol1.ReadOnly = isReadOnly;
            this.txtTempTimeCol2.ReadOnly = isReadOnly;
            this.txtTempTimeCol3.ReadOnly = isReadOnly;
            this.txtTempTimeCol4.ReadOnly = isReadOnly;
            this.txtTempTimeCol5.ReadOnly = isReadOnly;

            this.txtBalanceTime.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtInitTemp.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtMaintainTime.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtAlertTemp.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtColumnCount.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.txtRateCol1.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtRateCol2.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtRateCol3.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtRateCol4.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtRateCol5.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.txtTempCol1.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTempCol2.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTempCol3.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTempCol4.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTempCol5.BackColor = isReadOnly ? Color.Beige : Color.White;

            this.txtTempTimeCol1.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTempTimeCol2.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTempTimeCol3.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTempTimeCol4.BackColor = isReadOnly ? Color.Beige : Color.White;
            this.txtTempTimeCol5.BackColor = isReadOnly ? Color.Beige : Color.White;
        }*/

        /// <summary>
        /// 导入缺省数据到缓冲区
        /// </summary>
        public void LoadNew()
        {
            if (null == this._dtoAntiControl.dtoNetworkBoard)
            {
                this._dtoAntiControl.dtoNetworkBoard = new NetworkBoardDto();
            }
            this._dtoAntiControl.dtoNetworkBoard.GateIP=DefaultNetworkBoard.GateIP;
            this._dtoAntiControl.dtoNetworkBoard.SourceIP=DefaultNetworkBoard.SourceIP;
            this._dtoAntiControl.dtoNetworkBoard.MAC=DefaultNetworkBoard.MAC;
            this._dtoAntiControl.dtoNetworkBoard.Mask=DefaultNetworkBoard.Mask;

            this._dtoAntiControl.dtoNetworkBoard.Socket0Address=DefaultNetworkBoard.Socket0Address;
            this._dtoAntiControl.dtoNetworkBoard.Socket0AimIP=DefaultNetworkBoard.Socket0AimIP;
            this._dtoAntiControl.dtoNetworkBoard.Socket0AimAddress=DefaultNetworkBoard.Socket0AimAddress;
            Convert.ToInt32(this._dtoAntiControl.dtoNetworkBoard.Socket0WorkMode);

            this._dtoAntiControl.dtoNetworkBoard.Socket1Address = DefaultNetworkBoard.Socket1Address;
            this._dtoAntiControl.dtoNetworkBoard.Socket1AimIP = DefaultNetworkBoard.Socket1AimIP;
            this._dtoAntiControl.dtoNetworkBoard.Socket1AimAddress = DefaultNetworkBoard.Socket1AimAddress;
            Convert.ToInt32(this._dtoAntiControl.dtoNetworkBoard.Socket1WorkMode);

            this._dtoAntiControl.dtoNetworkBoard.Socket2Address = DefaultNetworkBoard.Socket2Address;
            this._dtoAntiControl.dtoNetworkBoard.Socket2AimIP = DefaultNetworkBoard.Socket2AimIP;
            this._dtoAntiControl.dtoNetworkBoard.Socket2AimAddress = DefaultNetworkBoard.Socket2AimAddress;
            Convert.ToInt32(this._dtoAntiControl.dtoNetworkBoard.Socket2WorkMode);

            this._dtoAntiControl.dtoNetworkBoard.Socket3Address = DefaultNetworkBoard.Socket3Address;
            this._dtoAntiControl.dtoNetworkBoard.Socket3AimIP = DefaultNetworkBoard.Socket3AimIP;
            this._dtoAntiControl.dtoNetworkBoard.Socket3AimAddress = DefaultNetworkBoard.Socket3AimAddress;
            Convert.ToInt32(this._dtoAntiControl.dtoNetworkBoard.Socket3WorkMode);
        }

        /// <summary>
        /// 编辑当前反控的信息
        /// </summary>
        public void LoadEdit()
        {
            this.LoadViewOrSaveAs();
            //this.LoadControlStyle(false);
        }

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        public void LoadSaveAs()
        {
            this.LoadViewOrSaveAs();
            //this.LoadControlStyle(true);
        }

        /// <summary>
        /// 导出到缓冲区
        /// </summary>
        public void Export()
        {
            this._dtoAntiControl.dtoNetworkBoard.GateIP = this.tbGateIP.Text;
            this._dtoAntiControl.dtoNetworkBoard.SourceIP = this.tbSourceIP.Text;
            this._dtoAntiControl.dtoNetworkBoard.MAC = this.tbMAC.Text;
            this._dtoAntiControl.dtoNetworkBoard.Mask = this.tbMask.Text;

            this._dtoAntiControl.dtoNetworkBoard.Socket0Address = this.tbSocket0Address.Text;
            this._dtoAntiControl.dtoNetworkBoard.Socket0AimIP = this.tbSocket0AimIP.Text;
            this._dtoAntiControl.dtoNetworkBoard.Socket0AimAddress = this.tbSocket0AimAddress.Text;
            this._dtoAntiControl.dtoNetworkBoard.Socket0WorkMode = this.cbSocket0WorkMode.SelectedIndex;

            this._dtoAntiControl.dtoNetworkBoard.Socket1Address = this.tbSocket1Address.Text;
            this._dtoAntiControl.dtoNetworkBoard.Socket1AimIP = this.tbSocket1AimIP.Text;
            this._dtoAntiControl.dtoNetworkBoard.Socket1AimAddress = this.tbSocket1AimAddress.Text;
            this._dtoAntiControl.dtoNetworkBoard.Socket1WorkMode = this.cbSocket1WorkMode.SelectedIndex;

            this._dtoAntiControl.dtoNetworkBoard.Socket2Address = this.tbSocket2Address.Text;
            this._dtoAntiControl.dtoNetworkBoard.Socket2AimIP = this.tbSocket2AimIP.Text;
            this._dtoAntiControl.dtoNetworkBoard.Socket2AimAddress = this.tbSocket2AimAddress.Text;
            this._dtoAntiControl.dtoNetworkBoard.Socket2WorkMode = this.cbSocket2WorkMode.SelectedIndex;

            this._dtoAntiControl.dtoNetworkBoard.Socket3Address = this.tbSocket3Address.Text;
            this._dtoAntiControl.dtoNetworkBoard.Socket3AimIP = this.tbSocket3AimIP.Text;
            this._dtoAntiControl.dtoNetworkBoard.Socket3AimAddress = this.tbSocket3AimAddress.Text;
            this._dtoAntiControl.dtoNetworkBoard.Socket3WorkMode = this.cbSocket3WorkMode.SelectedIndex;
        }

        #endregion

        #region 合法性检测，存入Dto中转

        /// <summary>
        /// GateIP合法性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbGateIP_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbGateIP.Text))
            {
                MessageBox.Show("输入不能为空！");
                this.tbGateIP.Focus();
                return;
            }

            this._dtoAntiControl.dtoNetworkBoard.GateIP = this.tbGateIP.Text;
        }

        /// <summary>
        /// SourceIP合法性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSourceIP_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbSourceIP.Text))
            {
                MessageBox.Show("输入不能为空！");
                this.tbSourceIP.Focus();
                return;
            }

            this._dtoAntiControl.dtoNetworkBoard.SourceIP = this.tbSourceIP.Text;
        }

        /// <summary>
        /// MAC合法性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbMAC_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbMAC.Text))
            {
                MessageBox.Show("输入不能为空！");
                this.tbMAC.Focus();
                return;
            }

            this._dtoAntiControl.dtoNetworkBoard.MAC = this.tbMAC.Text;
        }

        /// <summary>
        /// Mask合法性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbMask_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbMask.Text))
            {
                MessageBox.Show("输入不能为空！");
                this.tbMask.Focus();
                return;
            }
            this._dtoAntiControl.dtoNetworkBoard.Mask = this.tbMask.Text;
        }

        /// <summary>
        /// Socket0Address合法性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSocket0Address_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbSocket0Address.Text))
            {
                MessageBox.Show("输入不能为空！");
                this.tbSocket0Address.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.tbSocket0Address.Text))
            {
                MessageBox.Show("输入不是数值！");
                this.tbSocket0Address.Focus();
                return;
            }
            this._dtoAntiControl.dtoNetworkBoard.Socket0Address = this.tbSocket0Address.Text;
        }

        /// <summary>
        /// Socket0AimIP合法性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSocket0AimIP_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbSocket0AimIP.Text))
            {
                MessageBox.Show("输入不能为空！");
                this.tbSocket0AimIP.Focus();
                return;
            }
            this._dtoAntiControl.dtoNetworkBoard.Socket0AimIP = this.tbSocket0AimIP.Text;
        }

        /// <summary>
        /// Socket0AimAddress合法性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSocket0AimAddress_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbSocket0AimAddress.Text))
            {
                MessageBox.Show("输入不能为空！");
                this.tbSocket0AimAddress.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.tbSocket0AimAddress.Text))
            {
                MessageBox.Show("输入不是数值！");
                this.tbSocket0AimAddress.Focus();
                return;
            }
            this._dtoAntiControl.dtoNetworkBoard.Socket0AimAddress = this.tbSocket0AimAddress.Text;
        }

        /// <summary>
        /// Socket1Address合法性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSocket1Address_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbSocket1Address.Text))
            {
                MessageBox.Show("输入不能为空！");
                this.tbSocket1Address.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.tbSocket1Address.Text))
            {
                MessageBox.Show("输入不是数值！");
                this.tbSocket1Address.Focus();
                return;
            }
            this._dtoAntiControl.dtoNetworkBoard.Socket1Address = this.tbSocket1Address.Text;
        }

        /// <summary>
        /// Socket1AimIP合法性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSocket1AimIP_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbSocket1AimIP.Text))
            {
                MessageBox.Show("输入不能为空！");
                this.tbSocket1AimIP.Focus();
                return;
            }
            this._dtoAntiControl.dtoNetworkBoard.Socket1AimIP = this.tbSocket1AimIP.Text;
        }

        /// <summary>
        /// Socket1AimAddress合法性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSocket1AimAddress_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbSocket1AimAddress.Text))
            {
                MessageBox.Show("输入不能为空！");
                this.tbSocket1AimAddress.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.tbSocket1AimAddress.Text))
            {
                MessageBox.Show("输入不是数值！");
                this.tbSocket1AimAddress.Focus();
                return;
            }
            this._dtoAntiControl.dtoNetworkBoard.Socket1AimAddress = this.tbSocket1AimAddress.Text;
        }

        /// <summary>
        /// Socket2Address合法性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSocket2Address_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbSocket2Address.Text))
            {
                MessageBox.Show("输入不能为空！");
                this.tbSocket2Address.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.tbSocket2Address.Text))
            {
                MessageBox.Show("输入不是数值！");
                this.tbSocket2Address.Focus();
                return;
            }
            this._dtoAntiControl.dtoNetworkBoard.Socket2Address = this.tbSocket2Address.Text;
        }

        /// <summary>
        /// Socket2AimIP合法性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSocket2AimIP_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbSocket2AimIP.Text))
            {
                MessageBox.Show("输入不能为空！");
                this.tbSocket2AimIP.Focus();
                return;
            }
            this._dtoAntiControl.dtoNetworkBoard.Socket2AimIP = this.tbSocket2AimIP.Text;
        }

        /// <summary>
        /// Socket2AimAddress合法性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSocket2AimAddress_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbSocket2AimAddress.Text))
            {
                MessageBox.Show("输入不能为空！");
                this.tbSocket2AimAddress.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.tbSocket2AimAddress.Text))
            {
                MessageBox.Show("输入不是数值！");
                this.tbSocket2AimAddress.Focus();
                return;
            }
            this._dtoAntiControl.dtoNetworkBoard.Socket2AimAddress = this.tbSocket2AimAddress.Text;
        }

        /// <summary>
        /// Socket3Address合法性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSocket3Address_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbSocket3Address.Text))
            {
                MessageBox.Show("输入不能为空！");
                this.tbSocket3Address.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.tbSocket3Address.Text))
            {
                MessageBox.Show("输入不是数值！");
                this.tbSocket3Address.Focus();
                return;
            }
            this._dtoAntiControl.dtoNetworkBoard.Socket3Address = this.tbSocket3Address.Text;
        }

        /// <summary>
        /// Socket3AimIP合法性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSocket3AimIP_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbSocket3AimIP.Text))
            {
                MessageBox.Show("输入不能为空！");
                this.tbSocket3AimIP.Focus();
                return;
            }
            this._dtoAntiControl.dtoNetworkBoard.Socket3AimIP = this.tbSocket3AimIP.Text;
        }

        /// <summary>
        /// Socket3AimAddress合法性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSocket3AimAddress_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbSocket3AimAddress.Text))
            {
                MessageBox.Show("输入不能为空！");
                this.tbSocket3AimAddress.Focus();
                return;
            }
            if (!CastString.IsNumeric(this.tbSocket3AimAddress.Text))
            {
                MessageBox.Show("输入不是数值！");
                this.tbSocket3AimAddress.Focus();
                return;
            }
            this._dtoAntiControl.dtoNetworkBoard.Socket3AimAddress = this.tbSocket3AimAddress.Text;
        }

        #endregion
    }
}
