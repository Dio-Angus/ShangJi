using System;
using System.Drawing;
using System.Threading;
using System.Timers;

namespace Tetris
{
    class Palette
    {
        private int _width = 15;//画板宽度
        private int _height = 25;//画板高度
        private Color[,] coorArr;//固定砖块数组
        private Color disapperColor;//背景色
        private Graphics gpPalette;//砖块活动画板
        private Graphics gpReady;//下一个砖块样式画板
        private BlockGroup bGroup;//砖块生产机
        private Block runBlock;//正在活动的砖块
        private Block readyBlock;//下一个砖块
        private int rectPix;//单元格像素
        private System.Timers.Timer timerBlock;//定时器
        private int timeSpan = 800;//定时器的时间间隔
        public Palette(int x, int y, int pix, Color dColor, Graphics gp, Graphics gr)
        {
            _width = x;
            _height = y;
            coorArr = new Color[_width, _height];
            disapperColor = dColor;
            gpPalette = gp;
            gpReady = gr;
            rectPix = pix;
        }
        public void Start()//游戏开始
        {
            bGroup = new BlockGroup();//新建砖块生产机
            runBlock = bGroup.GetABlock();//取一个砖块
            runBlock.XPos = _width / 2;//水平位置
            int y = 0;//垂直位置 
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (runBlock[i].Y > y)
                {
                    y = runBlock[i].Y;
                }
            }
            runBlock.YPos = y;
            gpPalette.Clear(disapperColor); 
            runBlock.Paint(gpPalette);
            Thread.Sleep(20);
            readyBlock = bGroup.GetABlock();//取另一个砖块赋给readyBlock
            readyBlock.XPos = 2;//5*5的中心点为2
            readyBlock.YPos = 2;
            gpReady.Clear(disapperColor); 
            readyBlock.Paint(gpReady);
            //初始话并启动定时器
            timerBlock = new System.Timers.Timer(timeSpan);
            timerBlock.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            timerBlock.AutoReset = true;
            timerBlock.Start();
        }
        private void OnTimedEvent(object source,ElapsedEventArgs e)
        {
            CheckAndOverBlock();
            Down();
        }

        public bool Down()//砖块下移一个单元格
        {
            int xPos = runBlock.XPos;
            int yPos = runBlock.YPos + 1;
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (yPos - runBlock[i].Y > _height - 1)//如果超出下界就失败
                    return false;
                if (!coorArr[xPos + runBlock[i].X, yPos - runBlock[i].Y].IsEmpty)//如果下面有东西挡住就失败
                    return false;
            }
            runBlock.erase(gpPalette);
            runBlock.YPos++;
            runBlock.Paint(gpPalette);
            return true;
        }
        public void Drop()//丢下砖块
        {
            timerBlock.Stop();
            while (Down()) ;
            timerBlock.Start();
        }
        public void MoveLeft()//左移一个单元格
        {
            int xPos = runBlock.XPos - 1;
            int yPos = runBlock.YPos;
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (xPos + runBlock[i].X < 0)//如果超出左边界就失败
                    return;
                if (!coorArr[xPos + runBlock[i].X, yPos - runBlock[i].Y].IsEmpty)//左边有东西挡则失败
                    return;
            }
            runBlock.erase(gpPalette);
            runBlock.XPos--;
            runBlock.Paint(gpPalette);
        }
        public void MoveRight()//右移一个单元格
        {
            int xPos = runBlock.XPos + 1;
            int yPos = runBlock.YPos;
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (xPos + runBlock[i].X > _width-1)//如果超出右边界就失败
                    return;
                if (!coorArr[xPos + runBlock[i].X, yPos - runBlock[i].Y].IsEmpty)//右边有东西挡则失败
                    return;
            }
            runBlock.erase(gpPalette);
            runBlock.XPos++;
            runBlock.Paint(gpPalette);
        }
        public void DeasilRotate()//顺时针旋转
        {
            for (int i = 0; i < runBlock.Length; i++)
            {
                int x = runBlock.XPos + runBlock[i].Y;
                int y = runBlock.YPos + runBlock[i].X;
                if (x < 0 || x > _width - 1)//如果超出左右边界，则旋转失败
                    return;
                if (y < 0 || y > _height - 1)//如果超出上下边界，则选择失败
                    return;
                if (!coorArr[x, y].IsEmpty)//如果旋转后的位置有砖块则旋转失败
                    return;
            }
            runBlock.erase(gpPalette);
            runBlock.DeasilRotate();
            runBlock.Paint(gpPalette);
        }
        public void ContraRotate()//逆时针旋转
        {
            for (int i = 0; i < runBlock.Length; i++)
            {
                int x = runBlock.XPos - runBlock[i].Y;
                int y = runBlock.YPos + runBlock[i].X;
                if (x < 0 || x > _width - 1)//如果超出左右边界，则旋转失败
                    return;
                if (y < 0 || y > _height - 1)//如果超出上下边界，则选择失败
                    return;
                if (!coorArr[x, y].IsEmpty)//如果旋转后的位置有砖块则旋转失败
                    return;
            }
            runBlock.erase(gpPalette);
            runBlock.DeasilRotate();
            runBlock.Paint(gpPalette);
        }
        private void PaintBackground(Graphics gp)
        {
            gp.Clear(Color.Black);//清空画板    
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (!coorArr[j, i].IsEmpty)//coorArr要么为空，不处理；要么为颜色值，填充颜色
                    {
                        SolidBrush sb = new SolidBrush(coorArr[j, i]);
                        gp.FillRectangle(sb, j * rectPix + 1, i * rectPix + 1, rectPix - 2, rectPix - 2);
                    }
                }
            }
        }
        public void PaintPalette(Graphics gp)//重画整个画板
        {
            PaintBackground(gp);//先画背景
            if (runBlock != null)//再画活动的砖块
            {
                runBlock.Paint(gp);
            }
        }
        public void PaintReady(Graphics gp)//重画下一个砖块
        {
            if (readyBlock != null)
            {
                readyBlock.Paint(gp);
            }
        }
        public void CheckAndOverBlock()//检查砖块是否到底，如果到底就把它变成固定砖块
        {
            bool over = false;//设置一个当前运行砖块是否到底的标志
            for (int i = 0; i < runBlock.Length; i++)//遍历当前运行砖块的所有小方块
            {
                int x = runBlock.XPos + runBlock[i].X;
                int y = runBlock.YPos - runBlock[i].Y;
                if (y == _height - 1)//如果到达下边界，则当前砖块结束
                {
                    over = true;
                    break;
                }
                if (!coorArr[x, y + 1].IsEmpty)//如果下面有其它砖块，则当前砖块结束
                {
                    over = true;
                    break;
                }
            }
            if (over)//如果确定当前砖块已结束
            {
                for (int i = 0; i < runBlock.Length; i++)//把当前砖块归入coordinateArr
                {
                    coorArr[runBlock.XPos + runBlock[i].X, runBlock.YPos - runBlock[i].Y] = runBlock.BlockColor;
                }
                //检查是否有满行清空，如果有，则执行
                CheckAndDelFullRow();
                //产生新的砖块
                runBlock = readyBlock;//新的砖块为准备好的砖块
                runBlock.XPos = _width / 2;//确定当前运行砖块的出生位置
                int y = 0;//确定砖块的Ypos，确保刚出生的砖块顶上没有空行
                for (int i = 0; i < runBlock.Length; i++)
                {
                    if (runBlock[i].Y > y)
                    {
                        y = runBlock[i].Y;
                    }
                }
                runBlock.YPos = y;
                //检查新产生的砖块所占用的地方是否已经有砖块，如果有，则游戏结束
                for (int i = 0; i < runBlock.Length; i++)
                {
                    //游戏结束
                    if (!coorArr[runBlock.XPos + runBlock[i].X, runBlock.YPos - runBlock[i].Y].IsEmpty)
                    {
                        StringFormat drawFormat = new StringFormat();
                        drawFormat.Alignment = StringAlignment.Center;
                        gpPalette.DrawString("GAME OVER",
                            new Font("Arial Black", 25f),
                            new SolidBrush(Color.White),
                            new RectangleF(0, _height * rectPix / 2 - 100, _width * rectPix, 100),
                            drawFormat);
                        timerBlock.Stop();
                        return;
                    }
                }
                runBlock.Paint(gpPalette);
                //获取新的准备砖块
                readyBlock = bGroup.GetABlock();
                readyBlock.XPos = 2;
                readyBlock.YPos = 2;
                gpReady.Clear(Color.Black);
                readyBlock.Paint(gpReady);
            }
        }
        private void CheckAndDelFullRow()//检查并删除满行
        { 
            //找出当前砖块所在行范围
            int lowRow = runBlock.YPos - runBlock[0].Y;//lowRow代表当前砖块的y轴的最小值
            int highRow = lowRow;//highRow代表当前砖块的y轴的最大值
            for (int i = 1; i < runBlock.Length; i++)//找出当前砖块所占行的范围，放入low,high变量内
            {
                int y = runBlock.YPos - runBlock[i].Y;
                if (y < lowRow)
                {
                    lowRow = y;
                }
                if (y > highRow)
                {
                    highRow = y;
                }
            }
            bool repaint = false;//判断是否重画标志
            for (int i = lowRow; i <= highRow; i++)//检查满行，如果有，则删除这一行
            {
                bool rowFull = true;
                for (int j = 0; j < _width; j++)//判断是否满行
                {
                    if (coorArr[j, i].IsEmpty)
                    {
                        rowFull = false;
                        break;
                    }
                }
                if (rowFull)//如果满行，则删除这一行
                {
                    repaint = true;//如果有要删除的行，则需要重画
                    for (int k = i; k > 0; k--)
                    {
                        for (int j = 0; j < _width; j++)
                        {
                            coorArr[j, k] = coorArr[j, k - 1];
                        }
                    }
                    for (int j = 0; j < _width; j++)//清空第0行
                    {
                        coorArr[j, 0] = Color.Empty;
                    }
                }
            }
            if (repaint)//重画
            {
                PaintBackground(gpPalette);
            }
        }
        public void Pause()//暂停
        {
            if (timerBlock.Enabled == true)
            {
                timerBlock.Enabled = false;
            }
        }
        public void Endpause()//结束暂停
        {
            if (timerBlock.Enabled == false)
            {
                timerBlock.Enabled = true;
            }
        }
        public void Close()//关闭
        {
            timerBlock.Close();//关闭定时器
            gpPalette.Dispose();//释放画布
            gpReady.Dispose();
        }
    }
}
