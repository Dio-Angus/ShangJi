/*-----------------------------------------------------------------------------
//  FILE NAME       : ProConst.cs
//  FUNCTION        : 程序参数
//  AUTHOR          : 李锋(2009/04/14)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.IO.Ports;
using ChromatoTool.util;
using System.Drawing;

namespace ChromatoTool.ini
{
    /// <summary>
    /// 缺省曲线颜色
    /// </summary>
    public class DefaultColor
    {
        /// <summary>
        /// 最大数量
        /// </summary>
        public const Int32 MaxColor = 16;

        /// <summary>
        /// 前景色
        /// </summary>
        public Int32[] ForeColor = null;

        /// <summary>
        /// 构造
        /// </summary>
        public DefaultColor()
        {
            this.ForeColor = new Int32[MaxColor];
            this.ForeColor[0] = Color.Purple.ToArgb();
            this.ForeColor[1] = Color.LawnGreen.ToArgb();
            this.ForeColor[2] = Color.Tomato.ToArgb();
            this.ForeColor[3] = Color.Black.ToArgb();
            this.ForeColor[4] = Color.BlueViolet.ToArgb();
            this.ForeColor[5] = Color.BurlyWood.ToArgb();
            this.ForeColor[6] = Color.Chartreuse.ToArgb();
            this.ForeColor[7] = Color.Crimson.ToArgb();
            this.ForeColor[8] = Color.DarkCyan.ToArgb();
            this.ForeColor[9] = Color.DarkGreen.ToArgb();
            this.ForeColor[10] = Color.DarkOliveGreen.ToArgb();
            this.ForeColor[11] = Color.DeepPink.ToArgb();
            this.ForeColor[12] = Color.Firebrick.ToArgb();
            this.ForeColor[13] = Color.Gainsboro.ToArgb();
            this.ForeColor[14] = Color.Goldenrod.ToArgb();
            this.ForeColor[15] = Color.Honeydew.ToArgb();
        }
    }

    /// <summary>
    /// 主树节点显示名称
    /// </summary>
    public class MainTreeText
    {
        /// <summary>
        /// 样品
        /// </summary>
        public const String Sample = "样品";
        /// <summary>
        /// 方案
        /// </summary>
        public const String Solution = "方案";
        /// <summary>
        /// 采集
        /// </summary>
        public const String Online = "采集";
        /// <summary>
        /// 分析
        /// </summary>
        public const String Offline = "分析";
        /// <summary>
        /// 比较
        /// </summary>
        public const String Compare = "比较";
    }

    /// <summary>
    /// 主树节点内部名称
    /// </summary>
    public class MainTreeName
    {
        /// <summary>
        /// 样品
        /// </summary>
        public const String Sample = "样品";
        /// <summary>
        /// 方案
        /// </summary>
        public const String Solution = "方案";
        /// <summary>
        /// 采集
        /// </summary>
        public const String Online = "采集";
        /// <summary>
        /// 分析
        /// </summary>
        public const String Offline = "分析";
        /// <summary>
        /// 比较
        /// </summary>
        public const String Compare = "比较";
    }

    /// <summary>
    /// 配置树名称
    /// </summary>
    public class ConfigTreeName
    {
        public const String Main = "配置";
        public const String General = "常规";
        public const String Serial = "串口";
        public const String Tcp = "Tcp/Ip";
        public const String Area = "区域";
        public const String Grid = "网格";
        public const String Label = "标签";
        public const String Line = "直线";
        public const String Plot = "曲线";
        public const String Shape = "矩形";
        public const String AxsX = "X轴";
        public const String AxsY = "Y轴";
    }

    /// <summary>
    /// 测试树名称
    /// </summary>
    public class AutoChromatoTreeName
    {
        public const String Main = "自动色谱";
        public const String Reg = "注册请求";
        public const String Start = "启动请求";
        public const String Result = "结果请求";
    }

    /// <summary>
    /// 样品Tab显示名称
    /// </summary>
    public class SampleTab
    {
        public const String Info = "Info";
        public const String Result = "Result";
        public const String Report = "Report";
        public const String Remark = "Remark";
    }

    /// <summary>
    /// 方案Tab显示名称
    /// </summary>
    public class SolutionTab
    {
        public const String Info = "Info";
        public const String SamplePara = "SamplePara";
        public const String AnalyPara = "AnalyPara";
        public const String TimeProc = "TimeProc";
        public const String IdTable = "IdTable";
        public const String AntiMethod = "AntiMethod";
        public const String Remark = "Remark";
    }

    /// <summary>
    /// 采集Tab显示名称
    /// </summary>
    public class CollectionTab
    {
        public const String HardStatus = "HardStatus";
        public const String RealPlot = "RealPlot";
    }

    /// <summary>
    /// 分析Tab显示名称
    /// </summary>
    public class OffProcessTab
    {
        public const String Config = "Config";
        public const String Export = "Export";
        public const String Result = "Result";
    }

    /// <summary>
    /// 通道号
    /// </summary>
    public class IdChannel
    {

        /// <summary>
        /// Blank
        /// </summary>
        public const String Blank = "Blank";

        /// <summary>
        /// 通道Tcd1
        /// </summary>
        public const String Tcd1 = "Tcd1";

        /// <summary>
        /// 通道Tcd2
        /// </summary>
        public const String Tcd2 = "Tcd2";

        /// <summary>
        /// 通道Fid1
        /// </summary>
        public const String Fid1 = "Fid1";

        /// <summary>
        /// 通道Fid2
        /// </summary>
        public const String Fid2 = "Fid2";

    }

    /// <summary>
    /// 离线参数
    /// </summary>
    public class Offline
    {
         /// <summary>
        /// 曲线类型
        /// </summary>
        public static SimuType PlotType = SimuType.Sin;

        /// <summary>
        /// 满屏时间
        /// </summary>
        public static int FullScreenTime = 5; //minute

        /// <summary>
        /// 是否自动坐标范围
        /// </summary>
        public static bool AutoScale = true;

        /// <summary>
        /// Y轴显示最大值
        /// </summary>
        public static Single ShowMaxY = 10;

        /// <summary>
        /// Y轴显示最小值
        /// </summary>
        public static Single ShowMinY = 0;

        /// <summary>
        /// X轴显示最大值
        /// </summary>
        public static Single ShowMaxX = 5;

        /// <summary>
        /// X轴显示最小值
        /// </summary>
        public static Single ShowMinX = 0;

        /// <summary>
        /// 是否显示marker
        /// </summary>
        public static bool ShowMarker = false;
    }

    /// <summary>
    /// 离线参数
    /// </summary>
    public class CompareConfig
    {
        /// <summary>
        /// 曲线类型
        /// </summary>
        public static SimuType PlotType = SimuType.Sin;

        /// <summary>
        /// 满屏时间
        /// </summary>
        public static int FullScreenTime = 5; //minute

        /// <summary>
        /// 是否自动坐标范围
        /// </summary>
        public static bool AutoScale = true;

        /// <summary>
        /// Y轴显示最大值
        /// </summary>
        public static Single ShowMaxY = 10;

        /// <summary>
        /// Y轴显示最小值
        /// </summary>
        public static Single ShowMinY = 0;

        /// <summary>
        /// X轴显示最大值
        /// </summary>
        public static Single ShowMaxX = 5;

        /// <summary>
        /// X轴显示最小值
        /// </summary>
        public static Single ShowMinX = 0;
    }

    /// <summary>
    /// 常规参数
    /// </summary>
    public class General
    {
        /// <summary>
        /// 频率,每秒钟产生的点数
        /// </summary>
        public static Int32 Frequent = 10;

        /// <summary>
        /// 水平移动单位,1像素,n像素
        /// </summary>
        public static Int32 MoveUnit = 1;

        /// <summary>
        ///十字光标颜色
        /// </summary>
        public static Int32 ArrowColor = CastColor.GetCustomColor(Color.White);

        /// <summary>
        /// 数据库是否加密
        /// </summary>
        public static bool PackDb = false;

        /// <summary>
        /// 缓冲区到达最大值，进行保存释放
        /// </summary>
        public static int SaveMaxCount = 1000;

        /// <summary>
        /// 下位机对象
        /// </summary>
        public enum LinkObject
        {
            /// <summary>
            /// 模拟GC
            /// </summary>
            SimuGc = 0,
            /// <summary>
            /// 小板卡
            /// </summary>
            SmallBoard = 1,
            /// <summary>
            /// 大板卡
            /// </summary>
            BigBoard = 2,
            /// <summary>
            /// 通道气板卡
            /// </summary>
            ChannelGas = 3,
            /// <summary>
            /// 自动分析通道气板卡
            /// </summary>
            AutoChromatoGas = 4,
        }

        /// <summary>
        /// 是否是模拟数据
        /// </summary>
        public static LinkObject ObjectLink = General.LinkObject.SimuGc;

        /// <summary>
        /// 是否显示日志
        /// </summary>
        public static bool TraceLog = true;

        /// <summary>
        /// 是否自动载入完成后文件
        /// </summary>
        public static bool AutoLoad = true;

        /// <summary>
        /// 显示点数
        /// </summary>
        public static Int32 ShowCount = 500;

        /// <summary>
        /// 光标类型
        /// </summary>
        public enum StyleArrow
        {
            /// <summary>
            /// 小
            /// </summary>
            Small = 0,
            /// <summary>
            /// 大
            /// </summary>
            Big = 1,
        }

        /// <summary>
        /// 十字光标类型
        /// </summary>
        public static StyleArrow ArrowStyle = StyleArrow.Small;

        /// <summary>
        /// 开启十字光标标志
        /// </summary>
        public static bool OpenArrow = false;

        /// <summary>
        /// 模拟曲线类型
        /// </summary>
        public static SimuType PlotType = SimuType.Sin;

        /// <summary>
        /// 使用状态机
        /// </summary>
        public static PeakSolution SolutionPeak = PeakSolution.XCast;

        /// <summary>
        /// DataGridView背景色
        /// </summary>
        public static Int32 DgvBackColor = Color.Chocolate.ToArgb();

        /// <summary>
        /// 采集文件自动命名
        /// </summary>
        public static bool AutoName = true;

        /// <summary>
        /// 是否需要登陆
        /// </summary>
        public static bool NeedLogin = true;
        
        /// <summary>
        ///用户名
        /// </summary>
        public static string UserID = "Admin";

        /// <summary>
        /// 是否显示状态条
        /// </summary>
        public static bool StatusBar = true;

        /// <summary>
        /// 是否显示调试画面
        /// </summary>
        public static bool ShowDebugPage = false;

        /// <summary>
        /// 刷新频率
        /// </summary>
        public static PeriodScan ScanPeriod = PeriodScan.TwoHundred;
    }


    /// <summary>
    /// 显示通道
    /// </summary>
    public class ShowChannel
    {
        /// <summary>
        /// 是否实时显示Tcd1
        /// </summary>
        public static bool A = false;

        /// <summary>
        /// 是否实时显示B
        /// </summary>
        public static bool B = false;

        /// <summary>
        /// 是否实时显示C
        /// </summary>
        public static bool C = false;

        /// <summary>
        /// 是否实时显示D
        /// </summary>
        public static bool D = false;

        /// <summary>
        /// 是否同步
        /// </summary>
        public static bool Syn = false;
    }

    /// <summary>
    /// 端口设定
    /// </summary>
    public class Port
    {
        /// <summary>
        /// 信息传输方式，0为COM，1为TCP
        /// </summary>
        public static int tag = 0;
        /// <summary>
        /// Ai模块串口
        /// </summary>
        public static string SictPort = "COM4";

        /// <summary>
        /// 传输波特率
        /// </summary>
        public static int BaudRate = 9600;

        /// <summary>
        /// IP
        /// </summary>
        public static string Ip ="192.168.1.80" ;

        /// <summary>
        /// 端口
        /// </summary>
        public static int PortNum = 5000;

        /// <summary>
        /// 传输数据位
        /// </summary>
        public static int DataBits = 8;

        /// <summary>
        /// 传输奇偶校验
        /// </summary>
        public static Parity Parity = System.IO.Ports.Parity.None;

        /// <summary>
        /// 传输停止位
        /// </summary>
        public static StopBits StopBits = System.IO.Ports.StopBits.One;

        /// <summary>
        /// 握手
        /// </summary>
        public static Handshake Handshake = System.IO.Ports.Handshake.None;

    }

    /// <summary>
    /// 串口选项
    /// </summary>
    public class SerialOption
    {
        /// <summary>
        /// 追加类型
        /// </summary>
        public enum AppendType
        {
            /// <summary>
            /// 不追加
            /// </summary>
            AppendNothing,
            /// <summary>
            /// 追加回车
            /// </summary>
            AppendCR,
            /// <summary>
            /// 追加换行
            /// </summary>
            AppendLF,
            /// <summary>
            /// 追加回车换行
            /// </summary>
            AppendCRLF
        }

        /// <summary>
        /// 传送末尾追加数据
        /// </summary>
        public static AppendType AppendToSend = AppendType.AppendNothing;
        /// <summary>
        /// 16进制发送
        /// </summary>
        public static bool HexSend = true;
        /// <summary>
        /// 16进制接收
        /// </summary>
        public static bool HexReceive = true;
        /// <summary>
        /// 单色
        /// </summary>
        public static bool MonoFont = true;
        /// <summary>
        /// 本地回显
        /// </summary>
        public static bool LocalEcho = true;
        /// <summary>
        /// 停靠在上部
        /// </summary>
        public static bool StayOnTop = false;
        /// <summary>
        /// 大小写过滤
        /// </summary>
        public static bool FilterUseCase = false;
        /// <summary>
        /// 日志文件名
        /// </summary>
        public static string LogFileName = "";
        /// <summary>
        /// 读写超时间隔
        /// </summary>
        public static Int32 TimerInterval = 50;
    }

    /// <summary>
    /// 缺省分析方法
    /// </summary>
    public class DefaultAnaly
    {
        /// <summary>
        /// 色谱柱型号
        /// </summary>
        public static String ColumuModel = "色谱0101";

        /// <summary>
        /// 描述
        /// </summary>
        public static String Description = "国内色谱柱";

        /// <summary>
        /// 峰宽
        /// </summary>
        public static int PeakWide = 5;

        /// <summary>
        /// 斜率
        /// </summary>
        public static int Slope = 70;

        /// <summary>
        /// 漂移
        /// </summary>
        public static int Drift = 5;

        /// <summary>
        /// 最小面积
        /// </summary>
        public static Single MinAreaSize = 100;

        /// <summary>
        /// 变参时间
        /// </summary>
        public static Int32 ParaChangeTime = 100;

        /// <summary>
        /// 比率
        /// </summary>
        public static Single Ratio = 100;
        
        /// <summary>
        /// 对准参数
        /// </summary>
        public static AimPara AimPara = AimPara.TimeWindow;

        /// <summary>
        /// 对准参数
        /// </summary>
        public static AimWay AimWay = AimWay.Absolute;

        /// <summary>
        /// 对准参数
        /// </summary>
        public static ArithmaticParameter ArithmaticParameter = ArithmaticParameter.Area;

        /// <summary>
        /// 对准参数
        /// </summary>
        public static Arithmatic Arithmatic = Arithmatic.Normalize;

        /// <summary>
        /// 时间窗(1 - 100)
        /// </summary>
        public static Int32 TimeWindow = 5;

        /// <summary>
        /// 校正方法
        /// </summary>
        public static FixCurveWay FixWay = FixCurveWay.PolyLine;
    }

    /// <summary>
    /// 缺省采集方法
    /// </summary>
    public class DefaultCollection
    {

        /// <summary>
        /// 峰宽
        /// </summary>
        public static Int32 PeakWide = 5;

        /// <summary>
        /// 斜率
        /// </summary>
        public static Int32 Slope = 70;

        /// <summary>
        /// 停止时间
        /// </summary>
        public static Int32 StopTime = 30;

        /// <summary>
        /// 显示上限
        /// </summary>
        public static Single ShowMaxY = 10;

        /// <summary>
        /// 显示下限
        /// </summary>
        public static Single ShowMinY = 0;

        /// <summary>
        /// 满屏时间
        /// </summary>
        public static Int32 FullScreenTime = 5; //minute

        /// <summary>
        /// 自动斜率
        /// </summary>
        public static bool AutoSlope = false;

        /// <summary>
        /// 背景颜色
        /// </summary>
        public static Int32 BackColor = Color.White.ToArgb();

        /// <summary>
        /// 曲线颜色
        /// </summary>
        public static Int32 ForeColor = Color.Blue.ToArgb();

    }

    /// <summary>
    /// 缺省的ID表参数
    /// </summary>
    public class DefaultIdTable
    {
        /// <summary>
        /// 时间带(min)
        /// </summary>
        public static Single TimeBand = Convert.ToSingle( 0.003 );

        /// <summary>
        /// 样品量
        /// </summary>
        public static Int32 SampleWeight = 100;

        /// <summary>
        /// 浓度
        /// </summary>
        public static Single Density = Convert.ToSingle(2.0);

        /// <summary>
        /// 高度
        /// </summary>
        public static Single PeakHeight = 30;

        /// <summary>
        /// 面积
        /// </summary>
        public static Single PeakSize = 50;

        /// <summary>
        /// 因子1
        /// </summary>
        public static Single FactorOne = Convert.ToSingle(0.3);

        /// <summary>
        /// 因子2
        /// </summary>
        public static Single FactorTwo = Convert.ToSingle(0.5);

        /// <summary>
        /// 保留时间
        /// </summary>
        public static Single ReserveTime = Convert.ToSingle(1.525);

        /// <summary>
        /// 成分名
        /// </summary>
        public static String IngredientName = "二氧化碳";

        
    }

    /// <summary>
    /// 反控方法树名称
    /// </summary>
    public class AntiControl
    {
        public const String NetworkBoard = "网络板";
        public const String HeatingSource = "加热源";
        public const String Inject = "进样口";
        public const String Tcd = "TCD";
        public const String Fid = "FID";
        public const String Aux = "AUX";
        public const String Ecd = "ECD";
        public const String Fpd = "FPD";
    }

    /// <summary>
    /// 极性正负
    /// </summary>
    public class Polarity
    {

        /// <summary>
        /// 正
        /// </summary>
        public static String Positive = "正";

        /// <summary>
        /// 负
        /// </summary>
        public static String Nagative = "负";
    }

    /// TCD启动关闭
    /// </summary>
    public class TcdOnOff
    {

        /// <summary>
        /// 启动
        /// </summary>
        public static String On = "启动";

        /// <summary>
        /// 关闭
        /// </summary>
        public static String Off = "关闭";
    }

        /// <summary>
    /// 缺省反控方法->网络板
    /// </summary>
    public class DefaultNetworkBoard
    {
        public static String GateIP;
        public static String SourceIP;
        public static String MAC;
        public static String Mask;

        public static String Socket0Address;
        public static String Socket0AimIP;
        public static String Socket0AimAddress;
        public static Single Socket0WorkMode;

        public static String Socket1Address;
        public static String Socket1AimIP;
        public static String Socket1AimAddress;
        public static Single Socket1WorkMode;

        public static String Socket2Address;
        public static String Socket2AimIP;
        public static String Socket2AimAddress;
        public static Single Socket2WorkMode;

        public static String Socket3Address;
        public static String Socket3AimIP;
        public static String Socket3AimAddress;
        public static Single Socket3WorkMode;
    }

    /// <summary>
    /// 缺省反控方法->加热源
    /// </summary>
    public class DefaultHeatingSource
    {
        public static String HeatingState="";
        public static String EnablingState=""; 
        public static Single BalanceTime = 5;
        public static Single InitTemp = 6;
        public static Single MaintainTime = 7;
        public static Single AlertTemp = 8;
        public static Single ColumnCount = 5;

        public static Single RateCol1 = 1;
        public static Single TempCol1 = 1;
        public static Single TempTimeCol1 = 1;

        public static Single RateCol2 = 2;
        public static Single TempCol2 = 2;
        public static Single TempTimeCol2 = 2;

        public static Single RateCol3 = 3;
        public static Single TempCol3 = 3;
        public static Single TempTimeCol3 = 3;

        public static Single RateCol4 = 4;
        public static Single TempCol4 = 4;
        public static Single TempTimeCol4 = 4;

        public static Single RateCol5 = 5;
        public static Single TempCol5 = 5;
        public static Single TempTimeCol5 = 5;

    }

    /// <summary>
    /// 缺省反控方法->进样口参数
    /// </summary>
    public class DefaultInject
    {
        /// <summary>
        /// 初始温度
        /// </summary>
        public static Single InitTemp = 15;

        /// <summary>
        /// 报警温度
        /// </summary>
        public static Single AlertTemp = 25;

        /// <summary>
        /// 进样时间
        /// </summary>
        public static Int32 InjectTime = 5;

        /// <summary>
        /// 柱类型
        /// </summary>
        public static TypeColumn ColumnType = TypeColumn.Fill;

        /// <summary>
        /// 进样模式
        /// </summary>
        public static ModeInject InjectMode = ModeInject.NoTributary;
    }

    /// <summary>
    /// 缺省反控方法->AUX
    /// </summary>
    public class DefaultAux
    {
        /// <summary>
        /// 初始使用情况，0代表两个都用
        /// </summary>
        public static int UserIndex = 0;
        /// <summary>
        /// 初始温度1
        /// </summary>
        public static Single InitTempAux1 = 20;
        /// <summary>
        /// 报警温度1
        /// </summary>
        public static Single AlertTempAux1 = 21;

        /// <summary>
        /// 初始温度2
        /// </summary>
        public static Single InitTempAux2 = 30;
        /// <summary>
        /// 报警温度2
        /// </summary>
        public static Single AlertTempAux2 = 31;
    }

    /// <summary>
    /// 缺省反控方法->FID
    /// </summary>
    public class DefaultFid
    {
        public static bool FID1Used = true;
        public static bool FID2Used = true;
        public static bool FIDK1Used = false;
        public static bool FIDK2Used = false;

        public static Single InitTemp1 = 20;
        public static Single AlertTemp1 = 20;
        public static Int32 MagnifyFactor1 = 1;
        public static bool Polarity1 = true;

        public static Single InitTemp2 = 20;
        public static Single AlertTemp2 = 20;
        public static Int32 MagnifyFactor2 = 2;
        public static bool Polarity2 = true;

        public static Single InitTempK1 = 20;
        public static Single AlertTempK1 = 20;
        public static Int32 MagnifyFactorK1 = 1;
        public static bool PolarityK1 = true;

        public static Single InitTempK2 = 20;
        public static Single AlertTempK2 = 20;
        public static Int32 MagnifyFactorK2 = 2;
        public static bool PolarityK2 = true;
    }

    /// <summary>
    /// 缺省反控方法->TCD
    /// </summary>
    public class DefaultTcd
    {
        public static Single InitTemp1 = 20;
        public static Single AlertTemp1 = 30;

        public static Single InitTemp2 = 20;
        public static Single AlertTemp2 = 30;

        public static Single CurrentOne = 40;
        public static bool PolarityOne = true;

        public static Single CurrentTwo = 41;
        public static bool PolarityTwo = true;

        public static Single AlertOne = 35;
        public static bool OnOffOne = true;

        public static Single AlertTwo = 36;
        public static bool OnOffTwo = true;
    }

    /// <summary>
    /// Dbの配置
    /// </summary>
    public class DbConfig
    {
        public static string path { get; set; }
        public static string name { get; set; }

        public static string pathHistory { get; set; }
        public static string Historypath { get; set; }  //<-------------chencong 090210 11:44
        public static string nameHistory { get; set; }

    }

    /// <summary>
    /// 缺省样品信息
    /// </summary>
    public class DefaultSampleInfo
    {
        public static Int32 SampleWeight = 100;
        public static Int32 InnerWeight = 100;
    }

    /// <summary>
    /// 峰的类型
    /// </summary>
    public class TypeOfPeak
    {

        /// <summary>
        /// 主峰
        /// </summary>
        public const String Main = "主峰";

        /// <summary>
        /// 重叠峰
        /// </summary>
        public const String Overlap = "重叠峰";

        /// <summary>
        /// 拖尾峰
        /// </summary>
        public const String Tail = "拖尾峰";

    }

    /// <summary>
    /// GC通道板卡状态
    /// </summary>
    public class GcChannel
    {

        /// <summary>
        /// 通道Tcd1
        /// </summary>
        [EnumDescription("Tcd1")]
        public static bool Tcd1 = true;

        /// <summary>
        /// 通道Tcd2
        /// </summary>
        [EnumDescription("Tcd2")]
        public static bool Tcd2 = true;

        /// <summary>
        /// 通道Fid1
        /// </summary>
        [EnumDescription("Fid1")]
        public static bool Fid1 = true;

        /// <summary>
        /// 通道Fid2
        /// </summary>
        [EnumDescription("Fid2")]
        public static bool Fid2 = true;

    }

    /// <summary>
    /// 通道气的通道类型
    /// </summary>
    public class GasChannel
    {

        /// <summary>
        /// 通道A
        /// </summary>
        [EnumDescription("A")]
        public const String A = "A";

        /// <summary>
        /// 通道B
        /// </summary>
        [EnumDescription("B")]
        public const String B = "B";

        /// <summary>
        /// 通道C
        /// </summary>
        [EnumDescription("C")]
        public const String C = "C";

        /// <summary>
        /// 通道D
        /// </summary>
        [EnumDescription("D")]
        public const String D = "D";

        /// <summary>
        /// 通道E
        /// </summary>
        [EnumDescription("E")]
        public const String E = "E";

        /// <summary>
        /// 通道F
        /// </summary>
        [EnumDescription("F")]
        public const String F = "F";
    }


    /// <summary>
    /// 导出内容
    /// </summary>
    public class ExportFlag
    {
        /// <summary>
        /// 使用方案
        /// </summary>
        [EnumDescription("使用方案")]
        public static bool Solution = false;

        /// <summary>
        /// 分析结果
        /// </summary>
        [EnumDescription("分析结果")]
        public static bool Result = false;

        /// <summary>
        /// 原始数据"
        /// </summary>
        [EnumDescription("原始数据")]
        public static bool Data = true;

    }


}
