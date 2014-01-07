﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;

namespace Tetris
{
    class BlockGroup
    {
        private InfoArr info;//存放所有砖块样式信息
        private Color disapperColor;//背景色
        private int rectPix;//单元格像素
        public BlockGroup()//构造函数
        {
            Config config = new Config();
            config.LoadFromXmlFile();
            info = new InfoArr();
            info = config.Info;
            disapperColor = config.BackColor;
            rectPix = config.RectPix;
        }
        public Block GetABlock()//从砖块组中随机抽取一个砖块样式并返回
        {
            Random rd = new Random();//声明一个产生随机数的类
            int keyOrder = rd.Next(0, info.Length);//产生一个随机数，最大值不包括在内
            BitArray ba = info[keyOrder].ID;//把抽取出的砖块的样式赋给BitArray类对象
            int struNum = 0;//确定这个砖块样式中被填充方块的个数
            foreach (bool b in ba)//即需要确定Point数组的长度
            {
                if (b)
                {
                    struNum++;
                }
            }
            Point[] structArr = new Point[struNum];//新建一个Point数组，并确定其长度，以创建新的Block
            int k = 0;
            for (int j = 0; j < ba.Length; j++)//用循环给Point数组structArr赋坐标值
            {
                if (ba[j])
                {
                    structArr[k].X = j / 5 - 2;
                    structArr[k].Y = 2 - j % 5;
                    k++;
                }
            }
            return new Block(structArr, info[keyOrder].BColor, disapperColor, rectPix);
        }
    }
}
