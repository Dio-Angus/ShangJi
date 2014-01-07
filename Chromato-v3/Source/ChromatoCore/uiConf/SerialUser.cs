/*-----------------------------------------------------------------------------
//  FILE NAME       : SerialUser.cs
//  FUNCTION        : SerialPortを設定
//  AUTHOR          : 李锋(2008/12/01)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

using System.Windows.Forms;
using System.IO.Ports;
using ChromatoBll.serialCom;
using ChromatoTool.ini;
using ChromatoCore.tabCtrl;


namespace ChromatoCore.uiConf
{
    /// <summary>
    /// SerialPortを設定
    /// </summary>
    public partial class SerialUser : UserControl
    {

        #region 构造
        /// <summary>
        /// 构造函数
        /// </summary>
        public SerialUser()
        {
            InitializeComponent();
            InitUserControl();
        }
        #endregion


        #region 画面の処理

        /// <summary>
        /// 設定の初期
        /// </summary>
        private void InitUserControl()
        {
            int found = -1;
            string[] portList = CommPort.Instance.GetAvailablePorts();
            for (int i = 0; i < portList.Length; ++i)
            {
                string name = portList[i];
                cmbSictPort.Items.Add(name);
                if (name == Port.SictPort)
                {
                    found = i;
                }
            }

            cmbSictPort.SelectedIndex = found;

            
            Int32[] baudRates = {
                100,300,600,1200,2400,4800,9600,14400,19200,
                38400,56000,57600,115200,128000,256000,0
            };
            found = -1;
            for (int i = 0; baudRates[i] != 0; ++i)
            {
                cmbRate.Items.Add(baudRates[i].ToString());
                if (baudRates[i] == Port.BaudRate)
                    found = i;
            }
            cmbRate.SelectedIndex = found;

            cmbDatabits.Items.Add("5");
            cmbDatabits.Items.Add("6");
            cmbDatabits.Items.Add("7");
            cmbDatabits.Items.Add("8");
            cmbDatabits.SelectedIndex = Port.DataBits - 5;

            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                cmbParity.Items.Add(s);
            }
            cmbParity.SelectedIndex = (int)Port.Parity;

            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                cmbStopbits.Items.Add(s);
            }
            cmbStopbits.SelectedIndex = (int)Port.StopBits;

            foreach (string s in Enum.GetNames(typeof(Handshake)))
            {
                comboHandshaking.Items.Add(s);
            }
            comboHandshaking.SelectedIndex = (int)Port.Handshake;

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

            String port = Port.SictPort;
            if (!port.Equals(cmbSictPort.Text))
            {
                if (userOnline.IsSampling())
                {
                    MessageBox.Show("请停止采集，再切换串口！", "提示");
                }
                else
                {
                    userOnline.StopSample(StopSampleReason.SwitchPort);

                    Port.SictPort = cmbSictPort.Text;
                }
            }

            Port.BaudRate = Int32.Parse(cmbRate.Text);
            Port.DataBits = cmbDatabits.SelectedIndex + 5;
            Port.Parity = (Parity)cmbParity.SelectedIndex;
            Port.StopBits = (StopBits)cmbStopbits.SelectedIndex;
            Port.Handshake = (Handshake)comboHandshaking.SelectedIndex;

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


        /// <summary>
        /// iniファイルを保存する
        /// </summary>
        public void UpdateSetting()
        {

            String port = Port.SictPort;
            if (!port.Equals(cmbSictPort.Text))
            {
                //if (userOnline.IsSampling())
                //{
                //    MessageBox.Show("请停止采集，再切换串口！", "提示");
                //}
                //else
                //{
                    //userOnline.StopSample(StopSampleReason.SwitchPort);

                    Port.SictPort = cmbSictPort.Text;
                //}
            }

            Port.BaudRate = Int32.Parse(cmbRate.Text);
            Port.DataBits = cmbDatabits.SelectedIndex + 5;
            Port.Parity = (Parity)cmbParity.SelectedIndex;
            Port.StopBits = (StopBits)cmbStopbits.SelectedIndex;
            Port.Handshake = (Handshake)comboHandshaking.SelectedIndex;

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
        #endregion


    }
}
