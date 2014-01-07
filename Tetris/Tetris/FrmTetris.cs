using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tetris
{
    public partial class FrmTetris : Form
    {
        private Palette p;
        private Keys downKey;//向下键
        private Keys dropKey;//丢下键
        private Keys moveLeftKey;//左移键
        private Keys moveRightKey;//右移键
        private Keys deasilRotateKey;//顺时针旋转键
        private Keys contraRotateKey;//逆时针旋转健
        private int paletteWidth;//画板宽度
        private int paletteHeight;//画板高度
        private int rectPix;//每单元格像素
        private Color paletteColor;//背景色
        public FrmTetris()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (p != null)
            {
                p.Close();
            }
            p = new Palette(paletteWidth,paletteHeight,rectPix,paletteColor,
                Graphics.FromHwnd(pbRun.Handle),
                Graphics.FromHwnd(lblReady.Handle));
            p.Start();
        }        

        private void pbRun_Paint(object sender, PaintEventArgs e)
        {
            if (p != null)
            {
                p.PaintPalette(e.Graphics);
            }
        }

        private void lblReady_Paint(object sender, PaintEventArgs e)
        {
            if (p != null)
            {
                p.PaintReady(e.Graphics);
            }
        }

        private void FrmTetris_Load(object sender, EventArgs e)
        {
            Config config = new Config();
            config.LoadFromXmlFile();
            downKey = config.DownKey;
            dropKey = config.DropKey;
            moveLeftKey = config.MoveLeftKey;
            moveRightKey = config.MoveRightKey;
            deasilRotateKey = config.DeasilRotateKey;
            contraRotateKey = config.ContraRotateKey;
            paletteWidth = config.CoorWidth;
            paletteHeight = config.CoorHeight;
            paletteColor = config.BackColor;
            rectPix = config.RectPix;
            this.Width = paletteWidth * rectPix + 140;
            this.Height = paletteHeight * rectPix + 58;
            pbRun.Width = paletteWidth * rectPix;
            pbRun.Height = paletteHeight * rectPix;
        }

        private void FrmTetris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 32)//屏蔽回车键
            {
                e.Handled = true;
            }
            if (e.KeyCode == downKey)
            {
                p.Down();
            }
            else if (e.KeyCode == dropKey)
            {
                p.Drop();
            }
            else if (e.KeyCode == moveLeftKey)
            {
                p.MoveLeft();
            }
            else if (e.KeyCode == moveRightKey)
            {
                p.MoveRight();
            }
            else if (e.KeyCode == deasilRotateKey)
            {
                p.DeasilRotate();
            }
            else if (e.KeyCode == contraRotateKey)
            {
                p.ContraRotate();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (p == null)
            {
                return;
            }
            if (btnPause.Text == "暂停")
            {
                p.Pause();
                btnPause.Text = "继续";
            }
            else 
            {
                p.Endpause();
                btnPause.Text = "暂停";
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (btnPause.Text == "暂停")
            {
                btnPause.PerformClick();
            }
            using (FrmConfig frmConfig = new FrmConfig())
            {
                frmConfig.ShowDialog();
            }
        }

        private void FrmTetris_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (p != null)
            {
                p.Close();
            }
        }        
    }
}
