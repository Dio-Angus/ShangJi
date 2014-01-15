/*-----------------------------------------------------------------------------
//  FILE NAME       : DefaultItem.cs
//  FUNCTION        : 工程缺省常数
//  AUTHOR          : 李锋(2009/02/23)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoTool.util;

namespace ChromatoTool.ini
{
    /// <summary>
    /// 缺省常数
    /// </summary>
    public class DefaultItem
    {
        /// <summary>
        /// PIE
        /// </summary>
        public const double PIE = 3.141592654;

        /// <summary>
        /// 项目名称
        /// </summary>
        public const String Project_Name = "色谱数据分析管理软件 V1.0";

        /// <summary>
        /// 1分钟折合多少秒
        /// </summary>
        public const Single SecondsPerMin = 60;

        /// <summary>
        /// 1毫伏mv折合多少微伏
        /// </summary>
        public const Single uVol = 1000;

        /// <summary>
        /// 主数据库名
        /// </summary>
        public const String SQLite_DBMain = "chromato.db3";

        /// <summary>
        /// 从数据库名
        /// </summary>
        public const String SQLite_DBName = "Sample.db3";

        /// <summary>
        /// 扩展名
        /// </summary>
        public const String Db_Extention = ".db3";

        /// <summary>
        /// 软件名称
        /// </summary>
        public const String SoftName = "色谱数据分析管理软件";

        /// <summary>
        /// 管理员用户名
        /// </summary>
        public const String UserID = "Admin";

    }

    /// <summary>
    /// 窗口大小改变中的边界参数
    /// </summary>
    public class ResizePara
    {
        public const double FONT_HOZ_SIZE_FACTOR = 0.65;//グラフ脇の空白幅係数
        public const double FONT_VER_SIZE_FACTOR = 0.75;//グラフ脇の空白幅係数
        public const int TOP_SPACE = 10;				//グラフ上の空白幅
        public const int BOTTOM_SPACE = 25;			//グラフ下の空白幅
        public const int LEFT_SPACE = 25;			//グラフ左側の空白幅
        public const int RIGHT_SPACE = 10;			//グラフ右側の空白幅
    }

    /// <summary>
    /// 曲线属性
    /// </summary>
    public enum PlotProperty : int
    {
        Area = 1,
        DataCount = 2,
        dataline_Style = 3,
        dataline_Width = 4,
        dataline_Color = 5,
        Show = 6,
        ShowMarker = 7,
        StartXValue = 8,
        StartYValue = 9,
        EndXValue = 10,
        EndYValue = 11,
        marker_Bordercolor = 12,
        marker_Borderwidth = 13,
        marker_Fillcolor = 14,
        marker_Size = 15,
        marker_Style = 16,
        marker_Transparent = 17,
        Zorder = 18,
        RemoveAllDataLabels = 19,
        add = 20,
        Remove = 21,
        Setdata = 22,
        marker_state = 23

    }

    /// <summary>
    /// 坐标轴属性
    /// </summary>
    public enum AxisProperty : int
    {
        AxisLine_Color = 1,
        AxisLine_Style = 2,
        AxisLine_Width = 3,
        Align = 4,
        Show = 5,
        Direction = 6,
        StartValue = 7,
        EndValue = 8,
        FloatFigure = 9,
        X = 10,
        Y = 11,
        Length = 12,
        OffsetX = 13,
        OffsetY = 14,
        ScaleCount = 15,
        ScaleLine_Color = 16,
        ScaleLine_Style = 17,
        ScaleLine_Width = 18,
        ValueColor = 19,
        lablefont_Bold = 20,
        lablefont_Italic = 21,
        lablefont_Name = 220,
        lablefont_Size = 23,
        lablefont_Underline = 24,
        add = 25,
        Remove = 26,
        Zorder = 27,
        UnitAndName = 28

    }

    /// <summary>
    /// Y2軸編集モード
    /// </summary>
    public enum AxisMoveStatus : int
    {
        /// <summary>
        /// 通常
        /// </summary>
        normal = 1,

        /// <summary>
        /// 移動待ち
        /// </summary>
        moveWait = 2,

        /// <summary>
        /// 移動
        /// </summary>
        moving = 3,

        //Attributeモード
        ATTRI_NORM = 4,	//通常
        ATTRI_MOVE_WAIT = 5,	//移動待ち
        ATTRI_MOVE = 6,	//移動
    }

    /// <summary>
    /// 用户类型
    /// </summary>
    public enum UserType
    {
        osc,
        mnt,
        anl,
        flt,
        wave,
        group,
        upPeak,
        shift,
        relativeGr,
        absoluteGr,
        downPeak,
        toyota
    }

    /// <summary>
    /// 轴标签停靠方向
    /// </summary>
    public enum AxisScale
    {
        yUpLeft = 0,
        yDownLeft = 1,
        xLeft = 2,
        xCenter = 3,
        xRight = 4,
        yUpRight = 5,
        yDownRight = 6

    }

    /// <summary>
    ///  缩放的状態について
    /// </summary>
    public enum ZoomStatus
    {
        normal = 1,
        transveral = 2,
        longitudianl = 3,
        square = 4,

        editSendUp = 5,	//Edit for Send Up       Edit By Cast 20040915 V260
        editTurnDown = 6,   //Edit for Turn Down     Edit By Cast 20040915 V260
        editGearDown = 7,   //Edit for GearDown      2004/11/15 add by yangfan for EditMenu

    }

    /// <summary>
    /// 通道命令
    /// </summary>
    public enum ChannelCmd
    {
        /// <summary>
        /// 待机
        /// </summary>
        Ready = 0,
        /// <summary>
        /// 启动Tcd11
        /// </summary>
        StartTcd1 = 1,
        /// <summary>
        /// 启动Tcd2
        /// </summary>
        StartTcd2 = 2,
        /// <summary>
        /// 停止Tcd1
        /// </summary>
        StopTcd1 = 3,
        /// <summary>
        /// 停止Tcd2
        /// </summary>
        StopTcd2 = 4,
        /// <summary>
        /// 启动Fid1
        /// </summary>
        StartFid1 = 5,
        /// <summary>
        /// 启动Fid2
        /// </summary>
        StartFid2 = 6,
        /// <summary>
        /// 停止Fid1
        /// </summary>
        StopFid1 = 7,
        /// <summary>
        /// 停止FId2
        /// </summary>
        StopFid2 = 8,
        /// <summary>
        /// 走基线Tcd1
        /// </summary>
        RunBaseTcd1 = 9,
        /// <summary>
        /// 走基线Tcd2
        /// </summary>
        RunBaseTcd2 = 10,
        /// <summary>
        /// 走基线Fid1
        /// </summary>
        RunBaseFid1 = 11,
        /// <summary>
        /// 走基线Fid2
        /// </summary>
        RunBaseFid2 = 12,
        /// <summary>
        /// 走基线停止Tcd1
        /// </summary>
        StopBaseTcd1 = 13,
        /// <summary>
        /// 走基线停止Tcd2
        /// </summary>
        StopBaseTcd2 = 14,
        /// <summary>
        /// 走基线停止Fid1
        /// </summary>
        StopBaseFid1 = 15,
        /// <summary>
        /// 走基线停止Fid2
        /// </summary>
        StopBaseFid2 = 16,
    }

    /// <summary>
    /// 实时采集状态
    /// </summary>
    public enum RealStatus
    {
        /// <summary>
        /// 待机
        /// </summary>
        Ready = 1,
        /// <summary>
        /// 启动
        /// </summary>
        RealCollecting = 2,
        /// <summary>
        /// 模拟数据
        /// </summary>
        SimuCollecting = 3,
        /// <summary>
        /// 手动启动中
        /// </summary>
        ManulStart = 4,
        /// <summary>
        /// 手动停止中
        /// </summary>
        ManulStop = 5,
        /// <summary>
        /// 走基线
        /// </summary>
        RunBase = 6,
        /// <summary>
        /// 基线停止中
        /// </summary>
        StopBase = 7,
    }

    /// <summary>
    /// 曲线模拟类型
    /// </summary>
    public enum SimuType
    {
        /// <summary>
        /// 正弦波
        /// </summary>
        Sin = 1,

        /// <summary>
        /// 随机波
        /// </summary>
        Random = 2,

        /// <summary>
        /// 正弦随机波
        /// </summary>
        SinRandom = 3,
    }

    /// <summary>
    /// 浓度计算方法
    /// </summary>
    public enum Arithmatic
    {
        /// <summary>
        /// 归一法
        /// </summary>
        [EnumDescription("归一法")]
        Normalize = 0,

        /// <summary>
        /// 修正归一法
        /// </summary>
        [EnumDescription("修正归一法")]
        FixNormalize = 1,

        /// <summary>
        /// 带比例修正归一法
        /// </summary>
        [EnumDescription("带比例修正归一法")]
        FixNormalizeWithRate = 2,

        /// <summary>
        /// 外标法
        /// </summary>
        [EnumDescription("外标法")]
        Outer = 3,

        /// <summary>
        /// 内标法
        /// </summary>
        [EnumDescription("内标法")]
        Inner = 4,

        /// <summary>
        /// 指数法
        /// </summary>
        [EnumDescription("指数法")]
        Exponent = 5,
    }

    /// <summary>
    /// 对准参数
    /// </summary>
    public enum AimPara
    {
        /// <summary>
        /// 时间窗
        /// </summary>
        [EnumDescription("时间窗")]
        TimeWindow = 0,

        /// <summary>
        /// 时间带
        /// </summary>
        [EnumDescription("时间带")]
        TimeBand = 1,
    }

    /// <summary>
    /// 对准方法
    /// </summary>
    [EnumDescription("对准方法")]
    public enum AimWay
    {
        /// <summary>
        /// 绝对
        /// </summary>
        [EnumDescription("绝对")]
        Absolute = 0,

        /// <summary>
        /// 相对
        /// </summary>
        [EnumDescription("相对")]
        Relative = 1,
    }

    /// <summary>
    /// 计算参数
    /// </summary>
    [EnumDescription("计算参数")]
    public enum ArithmaticParameter
    {
        /// <summary>
        /// 面积
        /// </summary>
        [EnumDescription("面积")]
        Area = 0,

        /// <summary>
        /// 高度
        /// </summary>
        [EnumDescription("高度")]
        Height = 1,
    }

    /// <summary>
    /// 样品类型
    /// </summary>
    public enum TypeSample
    {
        /// <summary>
        /// 标样
        /// </summary>
        [EnumDescription("标样")]
        Standard = 0,

        /// <summary>
        /// 待测
        /// </summary>
        [EnumDescription("待测")]
        UnKnown = 1,
    }

    /// <summary>
    /// 方法参数
    /// </summary>
    public enum ArithPara
    {
        /// <summary>
        /// 样品百分比
        /// </summary>
        SamPercent = 0,

        /// <summary>
        /// 内标百分比
        /// </summary>
        InnerPercent = 1,
    }

    /// <summary>
    /// 方法访问
    /// </summary>
    public enum AccessMethod
    {
        /// <summary>
        /// 查看
        /// </summary>
        New = 0,

        /// <summary>
        /// 编辑
        /// </summary>
        Edit = 1,

        /// <summary>
        /// 查看
        /// </summary>
        View = 2,

        /// <summary>
        /// 另存为
        /// </summary>
        SaveAs = 3,

    }

    /// <summary>
    /// 通道动作
    /// </summary>
    public enum ChannelAction
    {
        /// <summary>
        /// 启动
        /// </summary>
        [EnumDescription("启动")]
        Start = 0,

        /// <summary>
        /// 停止
        /// </summary>
        [EnumDescription("停止")]
        Stop = 1,

        /// <summary>
        /// 走基线
        /// </summary>
        [EnumDescription("走基线")]
        RunBase = 2,
    }
    
    /// <summary>
    /// 样品状态
    /// </summary>
    public class StatusSample
    {
        /// <summary>
        /// 已注册
        /// </summary>
        public const String Registered = "已注册";

        /// <summary>
        /// 已采集
        /// </summary>
        public const String Collected = "已采集";

        /// <summary>
        /// 已分析
        /// </summary>
        public const String Analyzed = "已分析";

        /// <summary>
        /// 正在采集
        /// </summary>
        public const String Collecting = "正在采集";

        /// <summary>
        /// 全部
        /// </summary>
        public const String All = "全部";

        /// <summary>
        /// 已删除
        /// </summary>
        public const String Deleted = "已删除";
    }

    /// <summary>
    /// 查询选项
    /// </summary>
    public enum QueryChoise
    {


        /// <summary>
        /// 指定日
        /// </summary>
        [EnumDescription("指定日")]
        CustomDay = 0,
        
        /// <summary>
        /// 指定开始日
        /// </summary>
        [EnumDescription("指定开始日")]
        CustomStartDay = 1,
        
        /// <summary>
        /// 最近两周
        /// </summary>
        [EnumDescription("最近两周")]
        RecentTwoWeeks = 2,

        /// <summary>
        /// 全部
        /// </summary>
        [EnumDescription("全部")]
        All = 3,

    }

    /// <summary>
    /// 标签显示方向
    /// </summary>
    public enum LabelDirection
    {
        /// <summary>
        /// 水平方向
        /// </summary>
        [EnumDescription("水平方向")]
        X = 0,

        /// <summary>
        /// 竖直方向
        /// </summary>
        [EnumDescription("竖直方向")]
        Y = 1,
    }

    /// <summary>
    /// 停靠
    /// </summary>
    public enum Alignment
    {
        /// <summary>
        /// 水平居中
        /// </summary>
        [EnumDescription("水平居中")]
        X_Center = 3,

        /// <summary>
        /// 竖直左上
        /// </summary>
        [EnumDescription("竖直左上")]
        Y_Left = 1,

        /// <summary>
        /// 竖直右下
        /// </summary>
        [EnumDescription("竖直右下")]
        Y_Right = 6,

    }

    /// <summary>
    /// 方案项目
    /// </summary>
    public enum SolutionItem
    {
        /// <summary>
        /// 方法选择
        /// </summary>
        [EnumDescription("方法选择")]
        Infomation = 0,

        /// <summary>
        /// 采集方法
        /// </summary>
        [EnumDescription("采集方法")]
        Collection = 1,

        /// <summary>
        /// 分析方法
        /// </summary>
        [EnumDescription("分析方法")]
        Analysis = 2,

        /// <summary>
        /// ID表
        /// </summary>
        [EnumDescription("ID表")]
        IdTable = 3,

        /// <summary>
        /// 时间程序
        /// </summary>
        [EnumDescription("时间程序")]
        TimeProc = 4,

        /// <summary>
        /// 反控方法
        /// </summary>
        [EnumDescription("反控方法")]
        AntiControl = 5,

    }

    /// <summary>
    /// 时间程序某种类命令的状态
    /// </summary>
    public enum TpStatus
    {
        /// <summary>
        /// 打开
        /// </summary>
        [EnumDescription("打开")]
        Open = 100,

        /// <summary>
        /// 关闭
        /// </summary>
        [EnumDescription("关闭")]
        Stop = 101,
    }

    /// <summary>
    /// 成份和含量区分标志
    /// </summary>
    public enum IdTable
    {
        /// <summary>
        /// 含量
        /// </summary>
        [EnumDescription("含量")]
        Calibrate = 100,

        /// <summary>
        /// 成份
        /// </summary>
        [EnumDescription("成份")]
        Ingredient = 101,
    }

    /// <summary>
    /// 放大倍数->FID
    /// </summary>
    public enum Magnify
    {
        /// <summary>
        /// 
        /// </summary>
        [EnumDescription("0-->10^7")]
        Zero = 0,

        [EnumDescription("1-->10^8")]
        One = 1,

        [EnumDescription("2-->10^9")]
        Two = 2,

        [EnumDescription("3-->10^10")]
        Three = 3,
    }

    /// <summary>
    /// 柱箱温度状态
    /// </summary>
    public enum ColumnTempStatus
    {
        /// <summary>
        /// 升温
        /// </summary>
        [EnumDescription("升温")]
        Raise = 0x40,

        /// <summary>
        /// 冷却
        /// </summary>
        [EnumDescription("冷却")]
        Cool = 0x10,

        /// <summary>
        /// 停止
        /// </summary>
        [EnumDescription("停止")]
        Stop = 0x08,

        /// <summary>
        /// 初温
        /// </summary>
        [EnumDescription("初温")]
        Init = 0x04,

        /// <summary>
        /// 准备
        /// </summary>
        [EnumDescription("准备")]
        Ready = 0x02,

        /// <summary>
        /// 后温
        /// </summary>
        [EnumDescription("后温")]
        After = 0x01,
    }

    /// <summary>
    /// 导出文件类型
    /// </summary>
    public enum ExportType
    {
        /// <summary>
        /// xls文件"
        /// </summary>
        [EnumDescription("xls文件")]
        Excel = 0,

        /// <summary>
        /// csv文件
        /// </summary>
        [EnumDescription("csv文件")]
        Csv = 1,

        /// <summary>
        /// AIA文件
        /// </summary>
        [EnumDescription("AIA文件")]
        AIA = 2,
    }

    /// <summary>
    /// 联接下位机标志
    /// </summary>
    public enum LinkGcStatus
    {
        /// <summary>
        /// 脱机"
        /// </summary>
        [EnumDescription("脱机")]
        Off = 0,

        /// <summary>
        /// 联机
        /// </summary>
        [EnumDescription("联机")]
        On = 1,

    }

    /// <summary>
    /// 手动画图标志
    /// </summary>
    public enum ManualGraph
    {
        /// <summary>
        /// 无
        /// </summary>
        [EnumDescription("无")]
        NoManual = 0,

        /// <summary>
        /// 手动基线
        /// </summary>
        [EnumDescription("手动基线")]
        Baseline = 1,

        /// <summary>
        /// 垂直切割
        /// </summary>
        [EnumDescription("垂直切割")]
        VerticalLine = 2,

        /// <summary>
        /// 脱机
        /// </summary>
        [EnumDescription("脱尾处理")]
        Tail = 3,

        /// <summary>
        /// 删除峰
        /// </summary>
        [EnumDescription("删除峰")]
        DeletePeak = 4,

        /// <summary>
        /// 负峰翻转
        /// </summary>
        [EnumDescription("负峰翻转")]
        ReserveNegetive = 5,
    }

    /// <summary>
    /// 点的特征
    /// </summary>
    public enum PointAttribute
    {
        /// <summary>
        /// 无特征"
        /// </summary>
        [EnumDescription("无特征")]
        Norm = 0,

        /// <summary>
        /// 上升点"
        /// </summary>
        [EnumDescription("上升点")]
        Up = 1,

        /// <summary>
        /// 下降点
        /// </summary>
        [EnumDescription("下降点")]
        Down = 2,

        /// <summary>
        /// 上升开始点"
        /// </summary>
        [EnumDescription("上升开始点")]
        UpStt = 3,

        /// <summary>
        /// 上升结束点
        /// </summary>
        [EnumDescription("上升结束点")]
        UpEnd = 4,

        /// <summary>
        /// 下降开始点"
        /// </summary>
        [EnumDescription("下降开始点")]
        DnStt = 5,

        /// <summary>
        /// 下降结束点
        /// </summary>
        [EnumDescription("下降结束点")]
        DnEnd = 6,

        /// <summary>
        /// 最高点
        /// </summary>
        [EnumDescription("最高点")]
        Top = 7,
        
    }

    /// <summary>
    /// 打开数据文件结果
    /// </summary>
    public enum OpenDbResult
    {
        /// <summary>
        /// 路径不正确
        /// </summary>
        [EnumDescription("路径不正确")]
        NoPath = 0,

        /// <summary>
        /// 显示引擎为创建
        /// </summary>
        [EnumDescription("显示引擎为创建")]
        NoLayer = 1,

        /// <summary>
        /// 文件不存在
        /// </summary>
        [EnumDescription("文件不存在")]
        NotExist = 2,

        /// <summary>
        /// 已经打开
        /// </summary>
        [EnumDescription("已经打开")]
        AlreadyOpened = 3,

        /// <summary>
        /// 无数据
        /// </summary>
        [EnumDescription("无数据")]
        NoData = 4,

        /// <summary>
        /// 成功
        /// </summary>
        [EnumDescription("成功")]
        Succeed = 5,

    }

    /// <summary>
    /// 点的状态
    /// </summary>
    public enum PointStatus
    {
        /// <summary>
        /// 上升"
        /// </summary>
        [EnumDescription("上升")]
        Up = 1,

        /// <summary>
        /// 下降
        /// </summary>
        [EnumDescription("下降")]
        Down = 2,

        /// <summary>
        /// 平坦
        /// </summary>
        [EnumDescription("平坦")]
        Flat = 3,
    }

    /// <summary>
    /// 平均斜率的状态
    /// </summary>
    public enum AverageSlopeStatus
    {
        /// <summary>
        /// 上升"
        /// </summary>
        [EnumDescription("上升")]
        Up = 1,

        /// <summary>
        /// 下降
        /// </summary>
        [EnumDescription("下降")]
        Down = 2,

        /// <summary>
        /// 平坦
        /// </summary>
        [EnumDescription("平坦")]
        Flat = 3,
    }

    /// <summary>
    /// 峰的趋势,与图形控件的marker type匹配
    /// </summary>
    public enum PeakTrend
    {
        /// <summary>
        /// 平坦
        /// </summary>
        [EnumDescription("平坦")]
        Flat = 4,

        /// <summary>
        /// 上升"
        /// </summary>
        [EnumDescription("上升")]
        Up = 5,

        /// <summary>
        /// 下降
        /// </summary>
        [EnumDescription("下降")]
        Down = 6,

    }

    /// <summary>
    /// 扫描的状态
    /// </summary>
    public enum ScanStatus
    {
        Start = 0,

        UpUp = 1,
        UpFlat = 2,
        UpDown = 3,
        FlatFlat = 4,

        DownDown = 10,
        DownUp = 11,
        FlatUp = 12,
        DownFlat = 13,
        FlatDown = 14,
    }

    /// <summary>
    /// 拐点特征
    /// </summary>
    public enum YieldingAttri
    {
        Top = 1,
        StartEnd = 2,
    }

    /// <summary>
    /// 某个峰的识别步骤
    /// </summary>
    public enum IdentifyStep
    {
        
        /// <summary>
        /// 找开始点
        /// </summary>
        Start = 1,

        /// <summary>
        /// 找顶点
        /// </summary>
        Top = 2,

        /// <summary>
        /// 找终点
        /// </summary>
        End = 3,
    }

    /// <summary>
    /// 峰的分组步骤
    /// </summary>
    public enum GroupStep
    {

        /// <summary>
        /// 找第一个峰
        /// </summary>
        Start = 1,

        /// <summary>
        /// 找中间峰
        /// </summary>
        Mid = 2,


    }

    /// <summary>
    /// 时间程序动作类型
    /// </summary>
    public enum TimeProcType
    {

        /// <summary>
        /// 峰宽
        /// </summary>
        [EnumDescription("峰宽")]
        PeakWide = 0,

        /// <summary>
        /// 斜率
        /// </summary>
        [EnumDescription("斜率")]
        Slope = 1,

        /// <summary>
        /// 漂移
        /// </summary>
        [EnumDescription("漂移")]
        Drift = 2,

        /// <summary>
        /// 最小面积
        /// </summary>
        [EnumDescription("最小面积")]
        MinSize = 3,

        /// <summary>
        /// 变参时间
        /// </summary>
        [EnumDescription("变参时间")]
        ChangeParaTime = 4,

        /// <summary>
        /// 无需峰消除
        /// </summary>
        [EnumDescription("无需峰消除")]
        TimeLock = 5,

        /// <summary>
        /// 基线锁定
        /// </summary>
        [EnumDescription("基线锁定")]
        LockBaseline = 6,

        /// <summary>
        /// 负峰翻转
        /// </summary>
        [EnumDescription("负峰翻转")]
        RevertPeak = 7,

        /// <summary>
        /// 水平基线
        /// </summary>
        [EnumDescription("水平基线")]
        HoriBaseline = 8,

        /// <summary>
        /// 拖尾峰处理
        /// </summary>
        [EnumDescription("拖尾峰处理")]
        DealTailPeak = 9,


    }

    /// <summary>
    /// 需要打印项目
    /// </summary>
    public enum PrintItem
    {

        /// <summary>
        /// ID
        /// </summary>
        Id = 0,

        /// <summary>
        /// 组分名
        /// </summary>
        Name = 1,

        /// <summary>
        /// 保留时间
        /// </summary>
        ReserveTime = 2,

        /// <summary>
        /// 峰高
        /// </summary>
        Height = 3,

        /// <summary>
        /// 面积
        /// </summary>
        AreaSize = 4,

        /// <summary>
        /// 浓度
        /// </summary>
        Density = 5,

        /// <summary>
        /// 类型
        /// </summary>
        PeakType = 6,

    }

    /// <summary>
    /// 显示上下边界
    /// </summary>
    public enum UpDownFlag
    {
        /// <summary>
        /// 上边界增加
        /// </summary>
        MaxUp = 0,

        /// <summary>
        /// 上边界减少
        /// </summary>
        MaxDown = 1,

        /// <summary>
        /// 下边界增加
        /// </summary>
        MinUp = 2,

        /// <summary>
        /// 下边界减少
        /// </summary>
        MinDown = 3,
    }

    /// <summary>
    /// ID表校正方法
    /// </summary>
    public enum FixCurveWay
    {
        /// <summary>
        /// 折线法
        /// </summary>
        [EnumDescription("折线法")]
        PolyLine = 0,

        /// <summary>
        /// 拟和直线法
        /// </summary>
        [EnumDescription("拟和直线法")]
        SimuLine = 1,
    }

    /// <summary>
    /// 电压或者时间轴的标志
    /// </summary>
    public enum VolTimeFlag
    {
        /// <summary>
        /// 上边界增加
        /// </summary>
        Voltage = 0,

        /// <summary>
        /// 上边界减少
        /// </summary>
        Time = 1,

    }
    
    /// <summary>
    /// 柱类型
    /// </summary>
    public enum TypeColumn
    {
        /// <summary>
        /// 填充柱
        /// </summary>
        [EnumDescription("填充柱")]
        Fill = 0,

        /// <summary>
        /// 毛细管
        /// </summary>
        [EnumDescription("毛细管")]
        Capillary = 1,
    }

    /// <summary>
    /// 进样模式
    /// </summary>
    public enum ModeInject
    {
        /// <summary>
        /// 无分流
        /// </summary>
        [EnumDescription("无分流")]
        NoTributary = 0,
 
        /// <summary>
        /// 不分流/分流
        /// </summary>
        [EnumDescription("不分流/分流")]
        UnTributary = 1,

        /// <summary>
        /// 分流
        /// </summary>
        [EnumDescription("分流")]
        Tributary = 2,
    }

    /// <summary>
    /// 反控方法下载类型
    /// </summary>
    public enum AntiControlType
    {
        NetworkBoard = 0,
        HeatingSource = 1,
        SampleEntry = 2,
        AUX = 4,
        FID = 5,
        TCD = 6,
        ECD = 7,
        FPD = 8,

        /*
        Fid1 = 0,
        Fid2 = 1,
        Tcd1 = 2,
        Tcd2 = 3,
        Aux = 4,
        Injecter1 = 5,
        Injecter2 = 6,
        Injecter3 = 7,
        HeatingSource = 8,
        */

    }

    /// <summary>
    /// 升温状态
    /// </summary>
    public enum StepType
    {
        /// <summary>
        /// 初温
        /// </summary>
        [EnumDescription("初温")]
        Init = 0,

        /// <summary>
        /// 初温维持
        /// </summary>
        [EnumDescription("初温维持")]
        InitKeep = 1,

        /// <summary>
        /// 1阶升温
        /// </summary>
        [EnumDescription("1阶升温")]
        UpOne = 2,

        /// <summary>
        /// 1阶恒温
        /// </summary>
        [EnumDescription("1阶恒温")]
        KeepOne = 3,

        /// <summary>
        /// 2阶升温
        /// </summary>
        [EnumDescription("2阶升温")]
        UpTwo = 4,

        /// <summary>
        /// 2阶恒温
        /// </summary>
        [EnumDescription("2阶恒温")]
        KeepTwo = 5,

        /// <summary>
        /// 3阶升温
        /// </summary>
        [EnumDescription("3阶升温")]
        UpThree = 6,

        /// <summary>
        /// 3阶恒温
        /// </summary>
        [EnumDescription("3阶恒温")]
        KeepThree = 7,

        /// <summary>
        /// 4阶升温
        /// </summary>
        [EnumDescription("4阶升温")]
        UpFour = 8,

        /// <summary>
        /// 4阶恒温
        /// </summary>
        [EnumDescription("4阶恒温")]
        KeepFour = 9,

        /// <summary>
        /// 5阶升温
        /// </summary>
        [EnumDescription("5阶升温")]
        UpFive = 10,

        /// <summary>
        /// 5阶恒温
        /// </summary>
        [EnumDescription("5阶恒温")]
        KeepFive = 11,

        /// <summary>
        /// 待机
        /// </summary>
        [EnumDescription("待机")]
        Ready = 15,
    }

    /// <summary>
    /// 用户登陆信息
    /// </summary>
    public enum UserInfo
    {
        /// <summary>
        /// 通过
        /// </summary>
        [EnumDescription("通过")]
        Pass = 0,

        /// <summary>
        /// 用户名不存在
        /// </summary>
        [EnumDescription("用户名不存在")]
        InvalidUser = 1,

        /// <summary>
        /// 密码不正确
        /// </summary>
        [EnumDescription("密码不正确")]
        InvalidPwd = 2,
    }


    /// <summary>
    /// 找峰的方法
    /// </summary>
    public enum PeakSolution
    {
        /// <summary>
        /// 状态机
        /// </summary>
        [EnumDescription("状态机")]
        StatusMachine = 0,
        /// <summary>
        /// 凯斯特
        /// </summary>
        [EnumDescription("凯斯特")]
        XCast = 1,
    }

    /// <summary>
    /// 扫描周期
    /// </summary>
    public enum PeriodScan
    {
        /// <summary>
        /// 100
        /// </summary>
        [EnumDescription("100")]
        OneHundred = 0,
        /// <summary>
        /// 凯斯特
        /// </summary>
        [EnumDescription("200")]
        TwoHundred = 1,
        /// <summary>
        /// 状态机
        /// </summary>
        [EnumDescription("400")]
        FourHundred = 2,
        /// <summary>
        /// 凯斯特
        /// </summary>
        [EnumDescription("800")]
        EightHundred = 3,
        /// <summary>
        /// 凯斯特
        /// </summary>
        [EnumDescription("1000")]
        OneThousand = 4,
    }

    /// <summary>
    /// 停止采集原因
    /// </summary>
    public enum StopSampleReason
    {
        /// <summary>
        /// 切换串口
        /// </summary>
        [EnumDescription("切换串口")]
        SwitchPort = 0,
        /// <summary>
        /// 关闭进程
        /// </summary>
        [EnumDescription("关闭进程")]
        ShutDown = 1,
        /// <summary>
        /// IP变化
        /// </summary>
        [EnumDescription("关闭进程")]
        IPChange = 2,   
    }

    /// <summary>
    /// 通道序号
    /// </summary>
    public enum ChannelID
    {
        /// <summary>
        /// A
        /// </summary>
        [EnumDescription("A")]
        A = 0,

        /// <summary>
        /// B
        /// </summary>
        [EnumDescription("B")]
        B = 1,

        /// <summary>
        /// C
        /// </summary>
        [EnumDescription("C")]
        C = 2,

        /// <summary>
        /// D
        /// </summary>
        [EnumDescription("D")]
        D = 3,

        /// <summary>
        /// 离线
        /// </summary>
        [EnumDescription("离线")]
        off = 5,

        /// <summary>
        /// 样品
        /// </summary>
        [EnumDescription("样品")]
        sample = 6,

        /// <summary>
        /// 校正
        /// </summary>
        [EnumDescription("校正")]
        correct = 7,

        /// <summary>
        /// 比较
        /// </summary>
        [EnumDescription("比较")]
        compare = 8,
    }


    /// <summary>
    /// 比较画面选择曲线的移动方向
    /// </summary>
    public enum MoveDirection
    {
        /// <summary>
        /// 上
        /// </summary>
        Up = 0,

        /// <summary>
        /// 下
        /// </summary>
        Down = 1,

        /// <summary>
        /// 左
        /// </summary>
        Left = 2,

        /// <summary>
        /// 右
        /// </summary>
        Right = 3,
    }

    /// <summary>
    /// 请求类型
    /// </summary>
    public enum RequestType
    {
        /// <summary>
        /// 注册
        /// </summary>
        Regist = 0,

        /// <summary>
        /// 起动
        /// </summary>
        Start = 1,

        /// <summary>
        /// 结果
        /// </summary>
        Result = 2,

    }

    /// <summary>
    /// 请求状态
    /// </summary>
    public enum PutStatus
    {
        /// <summary>
        /// 开始放
        /// </summary>
        Start = 0,

        /// <summary>
        /// 已经放完
        /// </summary>
        Finished = 1,

    }
}
