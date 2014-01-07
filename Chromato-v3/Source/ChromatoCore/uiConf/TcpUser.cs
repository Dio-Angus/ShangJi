using System;
using System.IO.Ports;
using ChromatoBll.serialCom;
using ChromatoTool.ini;
using ChromatoCore.tabCtrl;
using System.Windows.Forms;

namespace ChromatoCore.uiConf
{
    public partial class TcpUser : UserControl
    {
        public TcpUser()
        {
            InitializeComponent();
            InitUserControl();
        }


        #region 画面の処理

        /// <summary>
        /// 設定の初期
        /// </summary>
        private void InitUserControl()
        {
            cmbTimerInterval.Items.Add("50");
            cmbTimerInterval.Items.Add("100");
            cmbTimerInterval.Items.Add("150");
            cmbTimerInterval.Items.Add("200");
            cmbTimerInterval.Text = SerialOption.TimerInterval.ToString();


            switch (SerialOption.AppendToSend)
            {
                case SerialOption.AppendType.AppendNothing:
                    rbAppendNothing.Checked = true;
                    break;
                case SerialOption.AppendType.AppendCR:
                    rbAppendCR.Checked = true;
                    break;
                case SerialOption.AppendType.AppendLF:
                    rbAppendLF.Checked = true;
                    break;
                case SerialOption.AppendType.AppendCRLF:
                    rbAppendCRLF.Checked = true;
                    break;
            }

            if (Port.tag == 1) checkBox1.Checked = true;
            else if (Port.tag == 0) checkBox1.Checked = false;

            cbHexSend.Checked = SerialOption.HexSend;
            cbHexReceive.Checked = SerialOption.HexReceive;
            cbMonospacedFont.Checked = SerialOption.MonoFont;
            cbLocalEcho.Checked = SerialOption.LocalEcho;
            cbStayOnTop.Checked = SerialOption.StayOnTop;
            cbFilterCase.Checked = SerialOption.FilterUseCase;

        }

        /// <summary>
        /// iniファイルを保存する
        /// </summary>
        public void UpdateSetting(OnlineUser userOnline)
        {

            String port = Port.Ip;
            if (!port.Equals(textBox1.Text))
            {
                if (userOnline.IsSampling())
                {
                    MessageBox.Show("请停止采集，再切换串口！", "提示");
                }
                else
                {
                    userOnline.StopSample(StopSampleReason.SwitchPort);

                    Port.Ip = textBox1.Text;
                }
            }

            Port.PortNum = Int32.Parse(textBox2.Text);
            if (checkBox1.Checked) Port.tag = 1;
            else Port.tag = 0;

            if (rbAppendCR.Checked)
                SerialOption.AppendToSend = SerialOption.AppendType.AppendCR;
            else if (rbAppendLF.Checked)
                SerialOption.AppendToSend = SerialOption.AppendType.AppendLF;
            else if (rbAppendCRLF.Checked)
                SerialOption.AppendToSend = SerialOption.AppendType.AppendCRLF;
            else
                SerialOption.AppendToSend = SerialOption.AppendType.AppendNothing;

            SerialOption.HexSend = cbHexSend.Checked;
            SerialOption.HexReceive = cbHexReceive.Checked;
            SerialOption.MonoFont = cbMonospacedFont.Checked;
            SerialOption.LocalEcho = cbLocalEcho.Checked;
            SerialOption.StayOnTop = cbStayOnTop.Checked;
            SerialOption.FilterUseCase = cbFilterCase.Checked;
            SerialOption.TimerInterval = Convert.ToInt32(cmbTimerInterval.Text);


        }


        /// <summary>
        /// 変更をクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, EventArgs e)
        {
            //SerialOption.LogFileName = "";

            //SaveFileDialog fileDialog1 = new SaveFileDialog();

            //fileDialog1.Title = "Save Log As";
            //fileDialog1.Filter = "Log files (*.log)|*.log|All files (*.*)|*.*";
            //fileDialog1.FilterIndex = 2;
            //fileDialog1.RestoreDirectory = true;
            //fileDialog1.FileName = SerialOption.LogFileName;

            //if (fileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    txtLog.Text = fileDialog1.FileName;
            //    if (File.Exists(txtLog.Text))
            //        File.Delete(txtLog.Text);
            //}
            //else
            //{
            //    txtLog.Text = "";
            //}
        }
        #endregion
    }
}
