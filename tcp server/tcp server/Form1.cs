using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace tcp_server
{
    public partial class Form1 : Form
    {
        private const int portNum = 13;
        private static IPAddress ipAddress = IPAddress.Any;
        private TcpListener listener=new TcpListener(ipAddress,portNum);
        private TcpClient client;
        private NetworkStream ns;
        private byte[] bytes=new byte[1024];
        public Form1()
        {
            InitializeComponent();   
            listener.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            bytes = Encoding.ASCII.GetBytes(textBox1.Text);
            try
            {
                ns.Write(bytes, 0, bytes.Length);
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                ns.Close();
                client.Close();
            }
            catch
            { 
            }
            base.OnFormClosing(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {     
            client = listener.AcceptTcpClient();
            ns = client.GetStream();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {            
                int bytesRead=ns.Read(bytes,0,8);
                textBox1.Text = Encoding.ASCII.GetString(bytes, 0, bytesRead);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
