/*-----------------------------------------------------------------------------
//  FILE NAME       : CommandMaker.cs
//  FUNCTION        : 反控通信指令
//  AUTHOR          : 邢小璐(2014/01/014)
//  VERSION         : V2.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Text;
using ChromatoTool.dto;
using System.Windows.Forms;
using ChromatoTool.ini;
using ChromatoTool.util;

namespace ChromatoBll.serialCom
{
    public class CommandMaker
    {
        #region 变量

        /// <summary>
        /// 连接GC标志
        /// </summary>
        public LinkGcStatus LinkGc { get; set; }

        #endregion

        #region 初期

        /*// <summary>
        /// 实例名
        /// </summary>
        static readonly CommandMaker instance = new CommandMaker();

        /// <summary>
        /// 唯一实例
        /// </summary>
        public static CommandMaker Instance
        {
            get
            {
                return instance;
            }
        }*/

        private AntiControlDto _antiControlDto = null;

        /// <summary>
        /// 构造
        /// </summary>
        public CommandMaker(AntiControlDto antiControlDto)
        {
            _antiControlDto = antiControlDto;
        }

        #endregion

        #region 网络板方法

        /// <summary>
        /// 1.1 读取所有网络参数
        /// </summary>
        /// <returns></returns>
        public string getAllNetworkData()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "14";
            return para;
        }

        /// <summary>
        /// 1.2 设置所有网络参数
        /// </summary>
        /// <returns></returns>
        public string setAllNetworkData(string data)
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "38" + addressCommand.NetworkBoard
                + "54" + data;//54字节的data
            return para;
        }

        /// <summary>
        /// 1.3 设置网络板重启
        /// </summary>
        /// <returns></returns>
        public string restartNetworkBoard()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "A0";
            return para;
        }

        /// <summary>
        /// 1.4 读取所有仪器参数
        /// </summary>
        /// <returns></returns>
        public string getAllInstrumentData()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "60";
            return para;
        }

        /// <summary>
        /// 1.5 停止读取所有仪器参数
        /// </summary>
        /// <returns></returns>
        public string stopGetAllNetworkData()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "61";
            return para;
        }

        /// <summary>
        /// 1.6 联机命令
        /// </summary>
        /// <returns></returns>
        public string toConnect()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "80";
            return para;
        }

        /// <summary>
        /// 1.7 脱机命令
        /// </summary>
        /// <returns></returns>
        public string toDisconnect()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "81";
            return para;
        }

        /// <summary>
        /// 1.8 GC启动命令
        /// </summary>
        /// <returns></returns>
        public string GCStart()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "82";
            return para;
        }

        /// <summary>
        /// 1.9 GC停止命令
        /// </summary>
        /// <returns></returns>
        public string GCStop()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "83";
            return para;
        }

        /// <summary>
        /// 1.10 读取网关IP地址
        /// </summary>
        /// <returns></returns>
        public string getGateway()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "00";
            return para;
        }

        /// <summary>
        /// 1.11 读取子网掩码
        /// </summary>
        /// <returns></returns>
        public string getSubnetMask()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "01";
            return para;
        }

        /// <summary>
        /// 1.12 读取MAC地址
        /// </summary>
        /// <returns></returns>
        public string getMAC()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "02";
            return para;
        }

        /// <summary>
        /// 1.13 读取源IP地址
        /// </summary>
        /// <returns></returns>
        public string getIP()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "03";
            return para;
        }

        /// <summary>
        /// 1.14 读取Socket0端口地址
        /// </summary>
        /// <returns></returns>
        public string getSocket0Address()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "04";
            return para;
        }

        /// <summary>
        /// 1.15 读取Socket0目的IP地址
        /// </summary>
        /// <returns></returns>
        public string getSocket0AimIP()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "05";
            return para;
        }

        /// <summary>
        /// 1.16 读取Socket0目的端口地址
        /// </summary>
        /// <returns></returns>
        public string getSocket0AimAddress()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "06";
            return para;
        }

        /// <summary>
        /// 1.17 读取Socket0工作模式
        /// </summary>
        /// <returns></returns>
        public string getSocket0()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "07";
            return para;
        }

        /// <summary>
        /// 1.18 读取Socket1端口地址
        /// </summary>
        /// <returns></returns>
        public string getSocket1Address()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "08";
            return para;
        }

        /// <summary>
        /// 1.19 读取Socket1目的IP地址
        /// </summary>
        /// <returns></returns>
        public string getSocket1AimIP()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "09";
            return para;
        }

        /// <summary>
        /// 1.20 读取Socket1目的端口地址
        /// </summary>
        /// <returns></returns>
        public string getSocket1AimAddress()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "0A";
            return para;
        }

        /// <summary>
        /// 1.21 读取Socket1工作模式
        /// </summary>
        /// <returns></returns>
        public string getSocket1()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "0B";
            return para;
        }


        /// <summary>
        /// 1.22 读取Socket2端口地址
        /// </summary>
        /// <returns></returns>
        public string getSocket2Address()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "0C";
            return para;
        }

        /// <summary>
        /// 1.23 读取Socket2目的IP地址
        /// </summary>
        /// <returns></returns>
        public string getSocket2AimIP()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "0D";
            return para;
        }

        /// <summary>
        /// 1.24 读取Socket2目的端口地址
        /// </summary>
        /// <returns></returns>
        public string getSocket2AimAddress()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "0E";
            return para;
        }

        /// <summary>
        /// 1.25 读取Socket2工作模式
        /// </summary>
        /// <returns></returns>
        public string getSocket2()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "0F";
            return para;
        }

        /// <summary>
        /// 1.26 读取Socket3端口地址
        /// </summary>
        /// <returns></returns>
        public string getSocket3Address()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "10";
            return para;
        }

        /// <summary>
        /// 1.27 读取Socket3目的IP地址
        /// </summary>
        /// <returns></returns>
        public string getSocket3AimIP()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "11";
            return para;
        }

        /// <summary>
        /// 1.28 读取Socket3目的端口地址
        /// </summary>
        /// <returns></returns>
        public string getSocket3AimAddress()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "12";
            return para;
        }

        /// <summary>
        /// 1.29 读取Socket3工作模式
        /// </summary>
        /// <returns></returns>
        public string getSocket3()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.NetworkBoard
                + "13";
            return para;
        }

        /// <summary>
        /// 1.30 设置网关IP地址
        /// </summary>
        /// <returns></returns>
        public string setGateway()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "06" + addressCommand.NetworkBoard
                + "40";//4个字节  more
            return para;
        }

        /// <summary>
        /// 1.31 设置子网掩码
        /// </summary>
        /// <returns></returns>
        public string setSubnetMask()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "06" + addressCommand.NetworkBoard
                + "41";//4个字节 more
            return para;
        }

        /// <summary>
        /// 1.32 设置MAC地址
        /// </summary>
        /// <returns></returns>
        public string setMAC()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "08" + addressCommand.NetworkBoard
                + "42";//more
            return para;
        }

        /// <summary>
        /// 1.33 设置源IP地址
        /// </summary>
        /// <returns></returns>
        public string setIP()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "06" + addressCommand.NetworkBoard
                + "43";//more
            return para;
        }

        /// <summary>
        /// 1.34 设置Socket0端口地址
        /// </summary>
        /// <returns></returns>
        public string setSocket0Address()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "04" + addressCommand.NetworkBoard
                + "44";//more
            return para;
        }

        /// <summary>
        /// 1.35 设置Socket0目的IP地址
        /// </summary>
        /// <returns></returns>
        public string setSocket0AimIP()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "06" + addressCommand.NetworkBoard
                + "45";//more
            return para;
        }

        /// <summary>
        /// 1.36 设置Socket0目的端口地址
        /// </summary>
        /// <returns></returns>
        public string setSocket0AimAddress()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "04" + addressCommand.NetworkBoard
                + "46";//more
            return para;
        }

        /// <summary>
        /// 1.37 设置Socket0工作模式
        /// </summary>
        /// <returns></returns>
        public string setSocket0()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.NetworkBoard
                + "47";//more
            return para;
        }

        /// <summary>
        /// 1.38 设置Socket1端口地址
        /// </summary>
        /// <returns></returns>
        public string setSocket1Address()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "04" + addressCommand.NetworkBoard
                + "48";//more
            return para;
        }

        /// <summary>
        /// 1.39 设置Socket1目的IP地址
        /// </summary>
        /// <returns></returns>
        public string setSocket1AimIP()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "06" + addressCommand.NetworkBoard
                + "49";//more
            return para;
        }

        /// <summary>
        /// 1.40 设置Socket1目的端口地址
        /// </summary>
        /// <returns></returns>
        public string setSocket1AimAddress()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "04" + addressCommand.NetworkBoard
                + "4A";//more
            return para;
        }

        /// <summary>
        /// 1.41 设置Socket1工作模式
        /// </summary>
        /// <returns></returns>
        public string setSocket1()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.NetworkBoard
                + "4B";//more
            return para;
        }


        /// <summary>
        /// 1.42 设置Socket2端口地址
        /// </summary>
        /// <returns></returns>
        public string setSocket2Address()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "04" + addressCommand.NetworkBoard
                + "4C";//more
            return para;
        }

        /// <summary>
        /// 1.43 设置Socket2目的IP地址
        /// </summary>
        /// <returns></returns>
        public string setSocket2AimIP()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "06" + addressCommand.NetworkBoard
                + "4D";//more
            return para;
        }

        /// <summary>
        /// 1.44 设置Socket2目的端口地址
        /// </summary>
        /// <returns></returns>
        public string setSocket2AimAddress()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "04" + addressCommand.NetworkBoard
                + "4E";//more
            return para;
        }

        /// <summary>
        /// 1.45 设置Socket2工作模式
        /// </summary>
        /// <returns></returns>
        public string setSocket2()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.NetworkBoard
                + "4F";//more
            return para;
        }

        /// <summary>
        /// 1.46 设置Socket3端口地址
        /// </summary>
        /// <returns></returns>
        public string setSocket3Address()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "04" + addressCommand.NetworkBoard
                + "50";//more
            return para;
        }

        /// <summary>
        /// 1.47 设置Socket3目的IP地址
        /// </summary>
        /// <returns></returns>
        public string setSocket3AimIP()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "06" + addressCommand.NetworkBoard
                + "51";//more
            return para;
        }

        /// <summary>
        /// 1.48 设置Socket3目的端口地址
        /// </summary>
        /// <returns></returns>
        public string setSocket3AimAddress()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "04" + addressCommand.NetworkBoard
                + "52";//more
            return para;
        }

        /// <summary>
        /// 1.49 设置Socket3工作模式
        /// </summary>
        /// <returns></returns>
        public string setSocket3()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.NetworkBoard
                + "53";//more
            return para;
        }

        #endregion

        #region 加热源方法

        /// <summary>
        /// 2.1 COL读取所有参数
        /// </summary>
        /// <returns></returns>
        public string getAllCOLData()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.HeatControl
                + "00";
            return para;
        }

        /// <summary>
        /// 2.2 COL设置所有参数
        /// </summary>
        /// <returns></returns>
        public string setAllCOLData(string data)
        {
            string length;
            switch (_antiControlDto.dtoHeatingSource.ColumnCount.ToString("X2"))
            {
                case "00":
                    length = "11";
                    break;
                case "01":
                    length = "1B";
                    break;
                case "02":
                    length = "25";
                    break;
                case "03":
                    length = "2F";
                    break;
                case "04":
                    length = "39";
                    break;
                case "05":
                    length = "43";
                    break;
                default:
                    length = "11";
                    break;
            }

            string para = baseCommand.head_1 + baseCommand.head_2 + length + addressCommand.HeatControl
                + "40" +data ;//根据程升阶数不同，字节数不同
            return para;
        }


        /// <summary>
        /// 2.3 GC加热源加热状态
        /// </summary>
        /// <returns></returns>
        public string setHeatingSourceStatus()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.HeatControl
                + "01";//加热状态字more
            return para;
        }


        /// <summary>
        /// 2.4 GC加热源加热使能状态 
        /// </summary>
        /// <returns></returns>
        public string setAllcolData()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.HeatControl
                + "02";//加热使能状态字more
            return para;
        }

        /// <summary>
        /// 2.5 COL初温
        /// </summary>
        /// <returns></returns>
        public string setCOLInitialTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "16";//三个字节more
            return para;
        }

        /// <summary>
        /// 2.6 COL报警温度
        /// </summary>
        /// <returns></returns>
        public string setCOLAlarmTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "17";//3个字节more
            return para;
        }

        /// <summary>
        /// 2.7 COL初温维持时间
        /// </summary>
        /// <returns></returns>
        public string setCOLInitialTemLastTime()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "18";//3个字节more
            return para;
        }

        /// <summary>
        /// 2.8 COL平衡时间
        /// </summary>
        /// <returns></returns>
        public string setCOLBalanceTime()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "19";//3个字节more
            return para;
        }

        /// <summary>
        /// 2.9 COL程升阶数
        /// </summary>
        /// <returns></returns>
        public string setCOLRise()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.HeatControl
                + "1A";//1个字节more
            return para;
        }

        /// <summary>
        /// 2.10 COL-1程升速率
        /// </summary>
        /// <returns></returns>
        public string setCOL1Velocity()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "06" + addressCommand.HeatControl
                + "1B";//4个字节more
            return para;
        }

        /// <summary>
        /// 2.11 COL-1程升恒温
        /// </summary>
        /// <returns></returns>
        public string setCOL1ConstantTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "1C";//3个字节more
            return para;
        }

        /// <summary>
        /// 2.12 COL-1程恒温时间
        /// </summary>
        /// <returns></returns>
        public string setCOL1ConstantTemLastTime()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "1D";//3个字节more
            return para;
        }

        /// <summary>
        /// 2.13 COL-2程升速率
        /// </summary>
        /// <returns></returns>
        public string setCOL2Velocity()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "06" + addressCommand.HeatControl
                + "1E";//4个字节more
            return para;
        }

        /// <summary>
        /// 2.14 COL-2程升恒温
        /// </summary>
        /// <returns></returns>
        public string setCOL2ConstantTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "1F";//3个字节more
            return para;
        }

        /// <summary>
        /// 2.15 COL-2程恒温时间
        /// </summary>
        /// <returns></returns>
        public string setCOL2ConstantTemLastTime()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "20";//3个字节more
            return para;
        }

        /// <summary>
        /// 2.16 COL-3程升速率
        /// </summary>
        /// <returns></returns>
        public string setCOL3Velocity()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "06" + addressCommand.HeatControl
                + "21";//4个字节more
            return para;
        }

        /// <summary>
        /// 2.17 COL-3程升恒温
        /// </summary>
        /// <returns></returns>
        public string setCOL3ConstantTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "22";//3个字节more
            return para;
        }

        /// <summary>
        /// 2.18 COL-3程恒温时间
        /// </summary>
        /// <returns></returns>
        public string setCOL3ConstantTemLastTime()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "23";//3个字节more
            return para;
        }

        /// <summary>
        /// 2.19 COL-4程升速率
        /// </summary>
        /// <returns></returns>
        public string setCOL4Velocity()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "06" + addressCommand.HeatControl
                + "24";//4个字节more
            return para;
        }

        /// <summary>
        /// 2.20 COL-4程升恒温
        /// </summary>
        /// <returns></returns>
        public string setCOL4ConstantTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "25";//3个字节more
            return para;
        }

        /// <summary>
        /// 2.21 COL-4程恒温时间
        /// </summary>
        /// <returns></returns>
        public string setCOL4ConstantTemLastTime()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "26";//3个字节more
            return para;
        }

        /// <summary>
        /// 2.22 COL-5程升速率
        /// </summary>
        /// <returns></returns>
        public string setCOL5Velocity()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "06" + addressCommand.HeatControl
                + "27";//4个字节more
            return para;
        }

        /// <summary>
        /// 2.23 COL-5程升恒温
        /// </summary>
        /// <returns></returns>
        public string setCOL5ConstantTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "28";//3个字节more
            return para;
        }

        /// <summary>
        /// 2.24 COL-5程恒温时间
        /// </summary>
        /// <returns></returns>
        public string setCOL5ConstantTemLastTime()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "29";//3个字节more
            return para;
        }

        #endregion

        #region 进样口方法

        /// <summary>
        /// 3.1 进样口读取所有参数
        /// </summary>
        /// <returns></returns>
        public string getAllINJData()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.HeatControl
                + "80";
            return para;
        }

        /// <summary>
        /// 3.2 进样口设置所有参数
        /// </summary>
        /// <returns></returns>
        public string setAllINJData(string data)
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "23" + addressCommand.HeatControl
                + "C0" + data;//33个字节的data
            return para;
        }

        /// <summary>
        /// 3.3 INJ1初温
        /// </summary>
        /// <returns></returns>
        public string setINJ1InitialTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "07";//加3个字节more
            return para;
        }

        /// <summary>
        /// 3.4 INJ1报警温度
        /// </summary>
        /// <returns></returns>
        public string setINJ1AlarmTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "08";//3个字节more
            return para;
        }

        /// <summary>
        /// 3.5 INJ1柱类型
        /// </summary>
        /// <returns></returns>
        public string setINJ1ColumnType()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.HeatControl
                + "09";//1个字节more
            return para;
        }

        /// <summary>
        /// 3.6 INJ1进样时间
        /// </summary>
        /// <returns></returns>
        public string setINJ1Time()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "0A";//3个字节more
            return para;
        }

        /// <summary>
        /// 3.7 INJ1进样模式
        /// </summary>
        /// <returns></returns>
        public string setINJ1Type()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.HeatControl
                + "0B";//1个字节more
            return para;
        }

        /// <summary>
        /// 3.8 INJ2初温
        /// </summary>
        /// <returns></returns>
        public string setINJ2InitialTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "0C";//加33个字节more
            return para;
        }

        /// <summary>
        /// 3.9 INJ2报警温度
        /// </summary>
        /// <returns></returns>
        public string setINJ2AlarmTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "0D";//3个字节more
            return para;
        }

        /// <summary>
        /// 3.10 INJ2柱类型
        /// </summary>
        /// <returns></returns>
        public string setINJ2ColumnType()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.HeatControl
                + "0E";//1个字节more
            return para;
        }

        /// <summary>
        /// 3.11 INJ2进样时间
        /// </summary>
        /// <returns></returns>
        public string setINJ2Time()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "0F";//3个字节more
            return para;
        }

        /// <summary>
        /// 3.12 INJ2进样模式
        /// </summary>
        /// <returns></returns>
        public string setINJ2Type()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.HeatControl
                + "10";//1个字节more
            return para;
        }

        /// <summary>
        /// 3.13 INJ3初温
        /// </summary>
        /// <returns></returns>
        public string setINJ3InitialTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "11";//加33个字节more
            return para;
        }

        /// <summary>
        /// 3.14 INJ3报警温度
        /// </summary>
        /// <returns></returns>
        public string setINJ3AlarmTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "12";//3个字节more
            return para;
        }

        /// <summary>
        /// 3.15 INJ3柱类型
        /// </summary>
        /// <returns></returns>
        public string setINJ3ColumnType()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.HeatControl
                + "13";//3个字节more
            return para;
        }

        /// <summary>
        /// 3.16 INJ3进样时间
        /// </summary>
        /// <returns></returns>
        public string setINJ3Time()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "14";//3个字节more
            return para;
        }

        /// <summary>
        /// 3.17 INJ3进样模式
        /// </summary>
        /// <returns></returns>
        public string setINJType()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.HeatControl
                + "15";//3个字节more
            return para;
        }

        #endregion

        #region AUX

        /// <summary>
        /// 4.1 AUX读取所有参数
        /// </summary>
        /// <returns></returns>
        public string getAUXAllData()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.HeatControl
                + "A0";
            return para;
        }

        /// <summary>
        /// 4.2 AUX设置所有参数
        /// </summary>
        /// <returns></returns>
        public string setAUXAllData(string data)
        {
            string length = "10";
            switch (_antiControlDto.dtoAux.UserIndex)
            {
                case 0:
                    length = "10";
                    break;
                case 1:
                    length = "09";
                    break;
                    length = "09";
                case 2:
                    break;
            }
            string para = baseCommand.head_1 + baseCommand.head_2 + length + addressCommand.HeatControl
                + "E0" + data;//data字节数跟开启的AUX有关
            return para;
        }

        /// <summary>
        /// 4.3 AUX1初温
        /// </summary>
        /// <returns></returns>
        public string setAUX1InitialTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "03";//加3个字节more
            return para;
        }

        /// <summary>
        /// 4.4 AUX1报警温度
        /// </summary>
        /// <returns></returns>
        public string setAUX1AlarmTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "04";//3个字节more
            return para;
        }

        /// <summary>
        /// 4.5 AUX2初温
        /// </summary>
        /// <returns></returns>
        public string setAUX2InitialTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "05";//加3个字节more
            return para;
        }

        /// <summary>
        /// 4.6 AUX2报警温度
        /// </summary>
        /// <returns></returns>
        public string setAUX2AlarmTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.HeatControl
                + "06";//3个字节more
            return para;
        }

        #endregion

        #region FID

        /// <summary>
        /// 5.1 FID读取所有参数
        /// </summary>
        /// <returns></returns>
        public string getFIDAllData()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.FIDShare
                + "00";
            return para;
        }

        /// <summary>
        /// 5.2 FID设置所有参数
        /// </summary>
        /// <returns></returns>
        public string setFIDAllData(string data)
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "XX" + addressCommand.FIDShare
                + "40";//data的字节数和开启的FID有关
            return para;
        }

        /// <summary>
        /// 5.3 FID1调零命令
        /// </summary>
        /// <returns></returns>
        public string setFID1Zero()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.FID1
                + "01";
            return para;
        }

        /// <summary>
        /// 5.4 FID1回零命令
        /// </summary>
        /// <returns></returns>
        public string resetFID1Zero()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.FID1
                + "02";
            return para;
        }

        /// <summary>
        /// 5.5 FID2调零命令
        /// </summary>
        /// <returns></returns>
        public string setFID2Zero()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.FID2
                + "01";
            return para;
        }

        /// <summary>
        /// 5.6 FID2回零命令
        /// </summary>
        /// <returns></returns>
        public string resetFID2Zero()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.FID2
                + "02";
            return para;
        }

        /// <summary>
        /// 5.7 FID1初温
        /// </summary>
        /// <returns></returns>
        public string setFID1InitialTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.FID1
                + "03";//加3个字节more
            return para;
        }

        /// <summary>
        /// 5.8 FID1报警温度
        /// </summary>
        /// <returns></returns>
        public string setFID1AlarmTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.FID1
                + "04";//3个字节more
            return para;
        }

        /// <summary>
        /// 5.9 FID1极性
        /// </summary>
        /// <returns></returns>
        public string setFID1Polarity()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.FID1
                + "05";//1个字节more
            return para;
        }

        /// <summary>
        /// 5.10 FID1放大倍数
        /// </summary>
        /// <returns></returns>
        public string setFID1Ap()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.FID1
                + "06";//1个字节more
            return para;
        }

        /// <summary>
        /// 5.11 FID2初温
        /// </summary>
        /// <returns></returns>
        public string setFID2InitialTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.FID2
                + "03";//加3个字节more
            return para;
        }

        /// <summary>
        /// 5.12 FID2报警温度
        /// </summary>
        /// <returns></returns>
        public string setFID2AlarmTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.FID2
                + "04";//3个字节more
            return para;
        }

        /// <summary>
        /// 5.13 FID2极性
        /// </summary>
        /// <returns></returns>
        public string setFID2Polarity()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.FID2
                + "05";//1个字节more
            return para;
        }

        /// <summary>
        /// 5.14 FID2放大倍数
        /// </summary>
        /// <returns></returns>
        public string setFID2Ap()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.FID2
                + "06";//1个字节more
            return para;
        }

        #endregion

        #region TCD

        /// <summary>
        /// 6.1 TCD读取所有参数
        /// </summary>
        /// <returns></returns>
        public string getTCDAllData()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.TCDShare
                + "00";
            return para;
        }

        /// <summary>
        /// 6.2 TCD设置所有参数
        /// </summary>
        /// <returns></returns>
        public string setTCDAllData(string data)
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "0C" + addressCommand.TCDShare
                + "40" + data;//10个字节data
            return para;
        }

        /// <summary>
        /// 6.3 TCD1调零命令
        /// </summary>
        /// <returns></returns>
        public string setTCD1Zero()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.TCD1
                + "01";
            return para;
        }

        /// <summary>
        /// 6.4 TCD1回零命令
        /// </summary>
        /// <returns></returns>
        public string resetTCD1Zero()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.TCD1
                + "02";
            return para;
        }

        /// <summary>
        /// 6.5 TCD1电流开启命令
        /// </summary>
        /// <returns></returns>
        public string TCD1Open()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.TCD1
                + "03";
            return para;
        }

        /// <summary>
        /// 6.6 TCD2调零命令
        /// </summary>
        /// <returns></returns>
        public string setTCD2Zero()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.TCD2
                + "01";
            return para;
        }

        /// <summary>
        /// 6.7 TCD2回零命令
        /// </summary>
        /// <returns></returns>
        public string resetTCD2Zero()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.TCD2
                + "02";
            return para;
        }

        /// <summary>
        /// 6.8 TCD2电流开启命令
        /// </summary>
        /// <returns></returns>
        public string TCD2Open()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.TCD2
                + "03";
            return para;
        }

        /// <summary>
        /// 6.9 TCD1初温
        /// </summary>
        /// <returns></returns>
        public string setTCD1InitialTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.TCD1
                + "04";//加3个字节more
            return para;
        }

        /// <summary>
        /// 6.10 TCD1报警温度
        /// </summary>
        /// <returns></returns>
        public string setTCD1AlarmTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.TCD1
                + "05";//3个字节more
            return para;
        }

        /// <summary>
        /// 6.11 TCD1极性
        /// </summary>
        /// <returns></returns>
        public string setTCD1Polarity()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.TCD1
                + "06";//加1个字节more
            return para;
        }

        /// <summary>
        /// 6.12 TCD1电流
        /// </summary>
        /// <returns></returns>
        public string setTCD1Electricity()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.TCD1
                + "07";//3个字节more
            return para;
        }

        /// <summary>
        /// 6.13 TCD2初温
        /// </summary>
        /// <returns></returns>
        public string setTCD2InitialTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.TCD2
                + "04";//加3个字节more
            return para;
        }

        /// <summary>
        /// 6.14 TCD2报警温度
        /// </summary>
        /// <returns></returns>
        public string setTCD2AlarmTem()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.TCD2
                + "05";//3个字节more
            return para;
        }

        /// <summary>
        /// 6.15 TCD2极性
        /// </summary>
        /// <returns></returns>
        public string setTCD2Polarity()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "03" + addressCommand.TCD2
                + "06";//加1个字节more
            return para;
        }

        /// <summary>
        /// 6.16 TCD2电流
        /// </summary>
        /// <returns></returns>
        public string setTCD2Electricity()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "0A" + addressCommand.TCD2
                + "07";//8个字节more
            return para;
        }

        #endregion

        #region ECD

        /// <summary>
        /// 7.1 ECD读取所有参数
        /// </summary>
        /// <returns></returns>
        public string getECDAllData()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.ECD
                + "00";
            return para;
        }

        /// <summary>
        /// 7.2 ECD设置所有参数
        /// </summary>
        /// <returns></returns>
        public string setECDAllData(string data)
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "08" + addressCommand.ECD
                + "40" + data;//6个字节data
            return para;
        }

        /// <summary>
        /// 7.3 ECD调零命令
        /// </summary>
        /// <returns></returns>
        public string setECDZero()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.ECD
                + "01";
            return para;
        }

        /// <summary>
        /// 7.4 ECD回零命令
        /// </summary>
        /// <returns></returns>
        public string resetECDZero()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.ECD
                + "02";
            return para;
        }

        /// <summary>
        /// 7.5 ECD电流命令
        /// </summary>
        /// <returns></returns>
        public string setECDElectricity()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.ECD
                + "03";//3个字节more
            return para;
        }

        /// <summary>
        /// 7.6 ECD量程命令
        /// </summary>
        /// <returns></returns>
        public string setECDRange()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "05" + addressCommand.ECD
                + "04";//3个字节more
            return para;
        }

        #endregion

        #region FPD


        /// <summary>
        /// 8.1 FPD调零命令
        /// </summary>
        /// <returns></returns>
        public string setFPDZero()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.FPD
                + "01";
            return para;
        }

        /// <summary>
        /// 8.2 FPD回零命令
        /// </summary>
        /// <returns></returns>
        public string resetFPDZero()
        {
            string para = baseCommand.head_1 + baseCommand.head_2 + "02" + addressCommand.FPD
                + "02";
            return para;
        }

        #endregion
    }
}

