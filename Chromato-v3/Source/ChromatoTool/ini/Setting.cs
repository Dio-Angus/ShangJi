/*-----------------------------------------------------------------------------
//  FILE NAME       : Setting.cs
//  FUNCTION        : 程序参数
//  AUTHOR          : 李锋(2009/03/12)
//  CHANGE LOG      : 李锋(2009/04/14)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using System.IO.Ports;


namespace ChromatoTool.ini
{

    /// <summary>
    /// 程序配置信息读写类
    /// </summary>
    public class Setting
    {
        public static DefaultColor ColorDefault = new DefaultColor();

        /// <summary>
        /// 从配置文件载入信息
        /// </summary>
        public static void Read()
        {
            int index = Application.ExecutablePath.LastIndexOf(".");

            IniFile ini = new IniFile(Application.ExecutablePath.Substring(0,index + 1) + "ini");

            General.Frequent = ini.ReadValue("General", "Frequent", General.Frequent);
            General.MoveUnit = ini.ReadValue("General", "MoveUnit", General.MoveUnit);
            General.ArrowColor = ini.ReadValue("General", "ArrowColor", General.ArrowColor);
            General.ObjectLink = (General.LinkObject)Enum.Parse(typeof(General.LinkObject), ini.ReadValue("General", "ObjectLink", General.ObjectLink.ToString()));
            General.TraceLog = Convert.ToBoolean(ini.ReadValue("General", "TraceLog", General.TraceLog.ToString()));
            General.ArrowStyle = (General.StyleArrow)Enum.Parse(typeof(General.StyleArrow), ini.ReadValue("General", "ArrowStyle", General.ArrowStyle.ToString()));
            General.OpenArrow = Convert.ToBoolean(ini.ReadValue("General", "OpenArrow", General.OpenArrow.ToString()));
            General.PlotType = (SimuType)Enum.Parse(typeof(SimuType), ini.ReadValue("General", "PlotType", General.PlotType.ToString()));
            General.SolutionPeak = (PeakSolution)Enum.Parse(typeof(PeakSolution), ini.ReadValue("General", "SolutionPeak", General.SolutionPeak.ToString()));
            General.DgvBackColor = ini.ReadValue("General", "DefaultColor", General.DgvBackColor);
            General.AutoName = bool.Parse(ini.ReadValue("General", "AutoName", General.AutoName.ToString()));
            General.NeedLogin = bool.Parse(ini.ReadValue("General", "NeedLogin", General.NeedLogin.ToString()));
            General.UserID = ini.ReadValue("General", "UserID", General.UserID);
            General.StatusBar = bool.Parse(ini.ReadValue("General", "StatusBar", General.StatusBar.ToString()));
            General.ShowDebugPage = bool.Parse(ini.ReadValue("General", "ShowDebugPage", General.ShowDebugPage.ToString()));
            General.ScanPeriod = (PeriodScan)Enum.Parse(typeof(PeriodScan), ini.ReadValue("General", "ScanPeriod", General.ScanPeriod.ToString()));

            ShowChannel.A = bool.Parse(ini.ReadValue("ShowChannel", "A", ShowChannel.A.ToString()));
            ShowChannel.B = bool.Parse(ini.ReadValue("ShowChannel", "B", ShowChannel.B.ToString()));
            ShowChannel.C = bool.Parse(ini.ReadValue("ShowChannel", "C", ShowChannel.C.ToString()));
            ShowChannel.D = bool.Parse(ini.ReadValue("ShowChannel", "D", ShowChannel.D.ToString()));
            ShowChannel.Syn = bool.Parse(ini.ReadValue("ShowChannel", "Syn", ShowChannel.Syn.ToString()));

            DbConfig.name = ini.ReadValue("db", "mainName", DefaultItem.SQLite_DBMain);

            Port.SictPort = ini.ReadValue("Port", "SictPort", Port.SictPort);
            Port.BaudRate = ini.ReadValue("Port", "BaudRate", Port.BaudRate);
            Port.DataBits = ini.ReadValue("Port", "DataBits", Port.DataBits);
            Port.Parity = (Parity)Enum.Parse(typeof(Parity), ini.ReadValue("Port", "Parity", Port.Parity.ToString()));
            Port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ini.ReadValue("Port", "StopBits", Port.StopBits.ToString()));
            Port.Handshake = (Handshake)Enum.Parse(typeof(Handshake), ini.ReadValue("Port", "Handshake", Port.Handshake.ToString()));

            SerialOption.AppendToSend = (SerialOption.AppendType)Enum.Parse(typeof(SerialOption.AppendType), ini.ReadValue("Option", "AppendToSend", SerialOption.AppendToSend.ToString()));
            SerialOption.HexSend = bool.Parse(ini.ReadValue("Option", "HexSend", SerialOption.HexSend.ToString()));
            SerialOption.HexReceive = bool.Parse(ini.ReadValue("Option", "HexReceive", SerialOption.HexReceive.ToString()));
            SerialOption.MonoFont = bool.Parse(ini.ReadValue("Option", "MonoFont", SerialOption.MonoFont.ToString()));
            SerialOption.LocalEcho = bool.Parse(ini.ReadValue("Option", "LocalEcho", SerialOption.LocalEcho.ToString()));
            SerialOption.StayOnTop = bool.Parse(ini.ReadValue("Option", "StayOnTop", SerialOption.StayOnTop.ToString()));
            SerialOption.FilterUseCase = bool.Parse(ini.ReadValue("Option", "FilterUseCase", SerialOption.FilterUseCase.ToString()));
            SerialOption.TimerInterval = ini.ReadValue("Option", "TimerInterval", SerialOption.TimerInterval);

            DefaultCollection.AutoSlope = bool.Parse(ini.ReadValue("DefaultCollection", "AutoSlope", DefaultCollection.AutoSlope.ToString()));
            DefaultCollection.PeakWide = ini.ReadValue("DefaultCollection", "PeakWide", DefaultCollection.PeakWide);
            DefaultCollection.Slope = ini.ReadValue("DefaultCollection", "Slope", DefaultCollection.Slope);
            DefaultCollection.StopTime = ini.ReadValue("DefaultCollection", "StopTime", DefaultCollection.StopTime);
            DefaultCollection.ShowMaxY = Convert.ToSingle(ini.ReadValue("DefaultCollection", "ShowMaxY", DefaultCollection.ShowMaxY.ToString()));
            DefaultCollection.ShowMinY = Convert.ToSingle(ini.ReadValue("DefaultCollection", "ShowMinY", DefaultCollection.ShowMinY.ToString()));
            DefaultCollection.FullScreenTime = ini.ReadValue("DefaultCollection", "FullScreenTime", DefaultCollection.FullScreenTime);
            DefaultCollection.BackColor = ini.ReadValue("DefaultCollection", "BackColor", DefaultCollection.BackColor);
            DefaultCollection.ForeColor = ini.ReadValue("DefaultCollection", "ForeColor", DefaultCollection.ForeColor);

            DefaultAnaly.ColumuModel = ini.ReadValue("DefaultAnaly", "ColumuModel", DefaultAnaly.ColumuModel);
            DefaultAnaly.Description = ini.ReadValue("DefaultAnaly", "Description", DefaultAnaly.Description);
            DefaultAnaly.PeakWide = ini.ReadValue("DefaultAnaly", "PeakWide", DefaultAnaly.PeakWide);
            DefaultAnaly.Slope = ini.ReadValue("DefaultAnaly", "Slope", DefaultAnaly.Slope);
            DefaultAnaly.Drift = ini.ReadValue("DefaultAnaly", "Drift", DefaultAnaly.Drift);
            DefaultAnaly.MinAreaSize =  Convert.ToSingle(ini.ReadValue("DefaultAnaly", "MinAreaSize", DefaultAnaly.MinAreaSize.ToString()));
            DefaultAnaly.ParaChangeTime = ini.ReadValue("DefaultAnaly", "ParaChangeTime", DefaultAnaly.ParaChangeTime);
            DefaultAnaly.Ratio =  Convert.ToSingle(ini.ReadValue("DefaultAnaly", "Ratio", DefaultAnaly.Ratio.ToString()));
            DefaultAnaly.AimPara = (AimPara)Enum.Parse(typeof(AimPara), ini.ReadValue("DefaultAnaly", "AimPara", DefaultAnaly.AimPara.ToString()));
            DefaultAnaly.AimWay = (AimWay)Enum.Parse(typeof(AimWay), ini.ReadValue("DefaultAnaly", "AimWay", DefaultAnaly.AimWay.ToString()));
            DefaultAnaly.ArithmaticParameter = (ArithmaticParameter)Enum.Parse(typeof(ArithmaticParameter), ini.ReadValue("DefaultAnaly", "ArithmaticParameter", DefaultAnaly.ArithmaticParameter.ToString()));
            DefaultAnaly.Arithmatic = (Arithmatic)Enum.Parse(typeof(Arithmatic), ini.ReadValue("DefaultAnaly", "Arithmatic", DefaultAnaly.Arithmatic.ToString()));
            DefaultAnaly.TimeWindow = ini.ReadValue("DefaultAnaly", "TimeWindow", DefaultAnaly.TimeWindow);
            DefaultAnaly.FixWay = (FixCurveWay)Enum.Parse(typeof(FixCurveWay), ini.ReadValue("DefaultAnaly", "FixWay", DefaultAnaly.FixWay.ToString()));

            DefaultIdTable.Density = Convert.ToSingle(ini.ReadValue("DefaultIdTable", "Density", DefaultIdTable.Density.ToString()));
            DefaultIdTable.TimeBand = Convert.ToSingle(ini.ReadValue("DefaultIdTable", "TimeBand", DefaultIdTable.TimeBand.ToString()));
            DefaultIdTable.SampleWeight = ini.ReadValue("DefaultIdTable", "SampleWeight", DefaultIdTable.SampleWeight);
            DefaultIdTable.PeakHeight = Convert.ToSingle(ini.ReadValue("DefaultIdTable", "PeakHeight", DefaultIdTable.PeakHeight.ToString()));
            DefaultIdTable.PeakSize = Convert.ToSingle(ini.ReadValue("DefaultIdTable", "PeakSize", DefaultIdTable.PeakSize.ToString()));
            DefaultIdTable.FactorOne = Convert.ToSingle(ini.ReadValue("DefaultIdTable", "FactorOne", DefaultIdTable.FactorOne.ToString()));
            DefaultIdTable.FactorTwo = Convert.ToSingle(ini.ReadValue("DefaultIdTable", "FactorTwo", DefaultIdTable.FactorTwo.ToString()));
            DefaultIdTable.ReserveTime = Convert.ToSingle(ini.ReadValue("DefaultIdTable", "ReserveTime", DefaultIdTable.ReserveTime.ToString()));
            DefaultIdTable.IngredientName = ini.ReadValue("DefaultIdTable", "IngredientName", DefaultIdTable.IngredientName);

            DefaultHeatingSource.BalanceTime = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "BalanceTime", DefaultHeatingSource.BalanceTime.ToString()));
            DefaultHeatingSource.InitTemp = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "InitTemp", DefaultHeatingSource.InitTemp.ToString()));
            DefaultHeatingSource.MaintainTime = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "MaintainTime", DefaultHeatingSource.MaintainTime.ToString()));
            DefaultHeatingSource.AlertTemp = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "AlertTemp", DefaultHeatingSource.AlertTemp.ToString()));
            DefaultHeatingSource.ColumnCount = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "ColumnCount", DefaultHeatingSource.ColumnCount.ToString()));

            DefaultHeatingSource.RateCol1 = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "RateCol1", DefaultHeatingSource.RateCol1.ToString()));
            DefaultHeatingSource.RateCol2 = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "RateCol2", DefaultHeatingSource.RateCol2.ToString()));
            DefaultHeatingSource.RateCol3 = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "RateCol3", DefaultHeatingSource.RateCol3.ToString()));
            DefaultHeatingSource.RateCol4 = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "RateCol4", DefaultHeatingSource.RateCol4.ToString()));
            DefaultHeatingSource.RateCol5 = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "RateCol5", DefaultHeatingSource.RateCol5.ToString()));

            DefaultHeatingSource.TempCol1 = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "TempCol1", DefaultHeatingSource.TempCol1.ToString()));
            DefaultHeatingSource.TempCol2 = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "TempCol2", DefaultHeatingSource.TempCol2.ToString()));
            DefaultHeatingSource.TempCol3 = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "TempCol3", DefaultHeatingSource.TempCol3.ToString()));
            DefaultHeatingSource.TempCol4 = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "TempCol4", DefaultHeatingSource.TempCol4.ToString()));
            DefaultHeatingSource.TempCol5 = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "TempCol5", DefaultHeatingSource.TempCol5.ToString()));

            DefaultHeatingSource.TempTimeCol1 = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "TempTimeCol1", DefaultHeatingSource.TempTimeCol1.ToString()));
            DefaultHeatingSource.TempTimeCol2 = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "TempTimeCol2", DefaultHeatingSource.TempTimeCol2.ToString()));
            DefaultHeatingSource.TempTimeCol3 = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "TempTimeCol3", DefaultHeatingSource.TempTimeCol3.ToString()));
            DefaultHeatingSource.TempTimeCol4 = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "TempTimeCol4", DefaultHeatingSource.TempTimeCol4.ToString()));
            DefaultHeatingSource.TempTimeCol5 = Convert.ToSingle(ini.ReadValue("DefaultColumnPara", "TempTimeCol5", DefaultHeatingSource.TempTimeCol5.ToString()));

            DefaultInject.AlertTemp = Convert.ToSingle(ini.ReadValue("DefaultInject", "AlertTemp", DefaultInject.AlertTemp.ToString()));
            DefaultInject.InitTemp = Convert.ToSingle(ini.ReadValue("DefaultInject", "InitTemp", DefaultInject.InitTemp.ToString()));
            DefaultInject.InjectTime = Convert.ToInt32(ini.ReadValue("DefaultInject", "InjectTime", DefaultInject.InjectTime.ToString()));
            DefaultInject.ColumnType = (TypeColumn)Enum.Parse(typeof(TypeColumn), ini.ReadValue("DefaultInject", "ColumnType", DefaultInject.ColumnType.ToString()));
            DefaultInject.InjectMode = (ModeInject)Enum.Parse(typeof(ModeInject), ini.ReadValue("DefaultInject", "InjectMode", DefaultInject.InjectMode.ToString()));

            DefaultAux.AlertTempAux1 = Convert.ToSingle(ini.ReadValue("DefaultAux", "AlertTempAux1", DefaultAux.AlertTempAux1.ToString()));
            DefaultAux.AlertTempAux2 = Convert.ToSingle(ini.ReadValue("DefaultAux", "AlertTempAux2", DefaultAux.AlertTempAux2.ToString()));
            DefaultAux.InitTempAux1 = Convert.ToSingle(ini.ReadValue("DefaultAux", "InitTempAux1", DefaultAux.InitTempAux1.ToString()));
            DefaultAux.InitTempAux2 = Convert.ToSingle(ini.ReadValue("DefaultAux", "InitTempAux2", DefaultAux.InitTempAux2.ToString()));

            DefaultFid.InitTemp1= Convert.ToSingle(ini.ReadValue("DefaultFid", "InitTemp1", DefaultFid.InitTemp1.ToString()));
            DefaultFid.AlertTemp1 = Convert.ToSingle(ini.ReadValue("DefaultFid", "AlertTemp1", DefaultFid.AlertTemp1.ToString()));
            DefaultFid.InitTemp2 = Convert.ToSingle(ini.ReadValue("DefaultFid", "InitTemp2", DefaultFid.InitTemp2.ToString()));
            DefaultFid.AlertTemp2 = Convert.ToSingle(ini.ReadValue("DefaultFid", "AlertTemp2", DefaultFid.AlertTemp2.ToString()));
            DefaultFid.MagnifyFactor1 = Convert.ToInt32(ini.ReadValue("DefaultFid", "MagnifyFactorOne", DefaultFid.MagnifyFactor1.ToString()));
            DefaultFid.MagnifyFactor2 = Convert.ToInt32(ini.ReadValue("DefaultFid", "MagnifyFactorTwo", DefaultFid.MagnifyFactor2.ToString()));
            DefaultFid.Polarity1 = Convert.ToBoolean(ini.ReadValue("DefaultFid", "PolarityOne", DefaultFid.Polarity1.ToString()));
            DefaultFid.Polarity2 = Convert.ToBoolean(ini.ReadValue("DefaultFid", "PolarityTwo", DefaultFid.Polarity2.ToString()));

            DefaultTcd.InitTemp1 = Convert.ToSingle(ini.ReadValue("DefaultTcd", "InitTemp1", DefaultTcd.InitTemp1.ToString()));
            DefaultTcd.AlertTemp1 = Convert.ToSingle(ini.ReadValue("DefaultTcd", "AlertTemp1", DefaultTcd.AlertTemp1.ToString()));
            DefaultTcd.InitTemp2 = Convert.ToSingle(ini.ReadValue("DefaultTcd", "InitTemp2", DefaultTcd.InitTemp2.ToString()));
            DefaultTcd.AlertTemp2 = Convert.ToSingle(ini.ReadValue("DefaultTcd", "AlertTemp2", DefaultTcd.AlertTemp2.ToString()));
            DefaultTcd.CurrentOne = Convert.ToSingle(ini.ReadValue("DefaultTcd", "CurrentOne", DefaultTcd.CurrentOne.ToString()));
            DefaultTcd.CurrentTwo = Convert.ToSingle(ini.ReadValue("DefaultTcd", "CurrentTwo", DefaultTcd.CurrentTwo.ToString()));
            DefaultTcd.PolarityOne = Convert.ToBoolean(ini.ReadValue("DefaultTcd", "PolarityOne", DefaultTcd.PolarityOne.ToString()));
            DefaultTcd.PolarityTwo = Convert.ToBoolean(ini.ReadValue("DefaultTcd", "PolarityTwo", DefaultTcd.PolarityTwo.ToString()));
            DefaultTcd.AlertOne = Convert.ToSingle(ini.ReadValue("DefaultTcd", "AlertOne", DefaultTcd.AlertOne.ToString()));
            DefaultTcd.AlertTwo = Convert.ToSingle(ini.ReadValue("DefaultTcd", "AlertTwo", DefaultTcd.AlertTwo.ToString()));
            DefaultTcd.OnOffOne = Convert.ToBoolean(ini.ReadValue("DefaultTcd", "OnOffOne", DefaultTcd.OnOffOne.ToString()));
            DefaultTcd.OnOffTwo = Convert.ToBoolean(ini.ReadValue("DefaultTcd", "OnOffTwo", DefaultTcd.OnOffTwo.ToString()));

            DefaultSampleInfo.SampleWeight = ini.ReadValue("DefaultSampleInfo", "SampleWeight", DefaultSampleInfo.SampleWeight);
            DefaultSampleInfo.InnerWeight = ini.ReadValue("DefaultSampleInfo", "InnerWeight", DefaultSampleInfo.InnerWeight);

            Offline.AutoScale = bool.Parse(ini.ReadValue("Offline", "AutoScale", Offline.AutoScale.ToString()));
            Offline.ShowMaxY = Convert.ToSingle(ini.ReadValue("Offline", "ShowMaxY", Offline.ShowMaxY.ToString()));
            Offline.ShowMinY = Convert.ToSingle(ini.ReadValue("Offline", "ShowMinY", Offline.ShowMinY.ToString()));
            Offline.ShowMaxX = Convert.ToSingle(ini.ReadValue("Offline", "ShowMaxX", Offline.ShowMaxX.ToString()));
            Offline.ShowMinX = Convert.ToSingle(ini.ReadValue("Offline", "ShowMinX", Offline.ShowMinX.ToString()));
            Offline.ShowMarker = bool.Parse(ini.ReadValue("Offline", "ShowMarker", Offline.ShowMarker.ToString()));

            CompareConfig.ShowMaxY = Convert.ToSingle(ini.ReadValue("CompareConfig", "ShowMaxY", CompareConfig.ShowMaxY.ToString()));
            CompareConfig.ShowMinY = Convert.ToSingle(ini.ReadValue("CompareConfig", "ShowMinY", CompareConfig.ShowMinY.ToString()));
            CompareConfig.ShowMaxX = Convert.ToSingle(ini.ReadValue("CompareConfig", "ShowMaxX", CompareConfig.ShowMaxX.ToString()));
            CompareConfig.ShowMinX = Convert.ToSingle(ini.ReadValue("CompareConfig", "ShowMinX", CompareConfig.ShowMinX.ToString()));

            GcChannel.Tcd2 = bool.Parse(ini.ReadValue("GcChannel", "Tcd2", GcChannel.Tcd2.ToString()));
            GcChannel.Tcd1 = bool.Parse(ini.ReadValue("GcChannel", "Tcd1", GcChannel.Tcd1.ToString()));
            GcChannel.Fid2 = bool.Parse(ini.ReadValue("GcChannel", "Fid2", GcChannel.Fid2.ToString()));
            GcChannel.Fid1 = bool.Parse(ini.ReadValue("GcChannel", "Fid1", GcChannel.Fid1.ToString()));

        }

        /// <summary>
        /// 写入配置文件
        /// </summary>
        public static void Write()
        {
            IniFile ini = new IniFile(Application.StartupPath + "\\Chromato.ini");

            // 配置写入
            ini.WriteValue("General", "Frequent", General.Frequent);
            ini.WriteValue("General", "MoveUnit", General.MoveUnit);
            ini.WriteValue("General", "ArrowColor", General.ArrowColor);
            ini.WriteValue("General", "ObjectLink", (int)General.ObjectLink);
            ini.WriteValue("General", "TraceLog", General.TraceLog.ToString());
            ini.WriteValue("General", "ArrowStyle", (Int32)General.ArrowStyle);
            ini.WriteValue("General", "OpenArrow", General.OpenArrow.ToString());
            ini.WriteValue("General", "PlotType", (Int32)General.PlotType);
            ini.WriteValue("General", "SolutionPeak", (Int32)General.SolutionPeak);
            ini.WriteValue("General", "DefaultColor", General.DgvBackColor);
            ini.WriteValue("General", "AutoName", General.AutoName.ToString());
            ini.WriteValue("General", "NeedLogin", General.NeedLogin.ToString());
            ini.WriteValue("General", "UserID", General.UserID);
            ini.WriteValue("General", "StatusBar", General.StatusBar.ToString());
            ini.WriteValue("General", "ShowDebugPage", General.ShowDebugPage.ToString());
            ini.WriteValue("General", "ScanPeriod", (int)General.ScanPeriod);

            // 图形显示写入
            ini.WriteValue("ShowChannel", "A", ShowChannel.A.ToString());
            ini.WriteValue("ShowChannel", "B", ShowChannel.B.ToString());
            ini.WriteValue("ShowChannel", "C", ShowChannel.C.ToString());
            ini.WriteValue("ShowChannel", "D", ShowChannel.D.ToString());
            ini.WriteValue("ShowChannel", "Syn", ShowChannel.Syn.ToString());

            // 实时通道参数写入
            ini.WriteValue("DefaultCollection", "AutoSlope", DefaultCollection.AutoSlope.ToString());
            ini.WriteValue("DefaultCollection", "PeakWide", DefaultCollection.PeakWide);
            ini.WriteValue("DefaultCollection", "Slope", DefaultCollection.Slope);
            ini.WriteValue("DefaultCollection", "StopTime", DefaultCollection.StopTime);
            ini.WriteValue("DefaultCollection", "ShowMaxY", DefaultCollection.ShowMaxY.ToString());
            ini.WriteValue("DefaultCollection", "ShowMinY", DefaultCollection.ShowMinY.ToString());
            ini.WriteValue("DefaultCollection", "FullScreenTime", DefaultCollection.FullScreenTime);
            ini.WriteValue("DefaultCollection", "BackColor", DefaultCollection.BackColor);
            ini.WriteValue("DefaultCollection", "ForeColor", DefaultCollection.ForeColor);

             // 端口配置写入
            ini.WriteValue("Port", "SictPort", Port.SictPort);
            ini.WriteValue("Port", "BaudRate", Port.BaudRate);
            ini.WriteValue("Port", "DataBits", Port.DataBits);
            ini.WriteValue("Port", "Parity", Port.Parity.ToString());
            ini.WriteValue("Port", "StopBits", Port.StopBits.ToString());
            ini.WriteValue("Port", "Handshake", Port.Handshake.ToString());

            // 选项配置写入
            ini.WriteValue("Option", "AppendToSend", SerialOption.AppendToSend.ToString());
            ini.WriteValue("Option", "HexSend", SerialOption.HexSend.ToString());
            ini.WriteValue("Option", "HexReceive", SerialOption.HexReceive.ToString());
            ini.WriteValue("Option", "MonoFont", SerialOption.MonoFont.ToString());
            ini.WriteValue("Option", "LocalEcho", SerialOption.LocalEcho.ToString());
            ini.WriteValue("Option", "StayOnTop", SerialOption.StayOnTop.ToString());
            ini.WriteValue("Option", "FilterUseCase", SerialOption.FilterUseCase.ToString());
            ini.WriteValue("Option", "TimerInterval", SerialOption.TimerInterval);

            // 离线参数写入
            ini.WriteValue("Offline", "PlotType", (Int32)Offline.PlotType);
            ini.WriteValue("Offline", "FullScreenTime", Offline.FullScreenTime);
            ini.WriteValue("Offline", "AutoScale", Offline.AutoScale.ToString());
            ini.WriteValue("Offline", "ShowMaxY", Offline.ShowMaxY.ToString());
            ini.WriteValue("Offline", "ShowMinY", Offline.ShowMinY.ToString());
            ini.WriteValue("Offline", "ShowMaxX", Offline.ShowMaxX.ToString());
            ini.WriteValue("Offline", "ShowMinX", Offline.ShowMinX.ToString());
            ini.WriteValue("Offline", "ShowMarker", Offline.ShowMarker.ToString());

            // 比较图形参数写入
            ini.WriteValue("CompareConfig", "ShowMaxY", CompareConfig.ShowMaxY.ToString());
            ini.WriteValue("CompareConfig", "ShowMinY", CompareConfig.ShowMinY.ToString());
            ini.WriteValue("CompareConfig", "ShowMaxX", CompareConfig.ShowMaxX.ToString());
            ini.WriteValue("CompareConfig", "ShowMinX", CompareConfig.ShowMinX.ToString());

            // 缺省分析方法写入
            ini.WriteValue("DefaultAnaly", "ColumuModel", DefaultAnaly.ColumuModel);
            ini.WriteValue("DefaultAnaly", "Description", DefaultAnaly.Description);
            ini.WriteValue("DefaultAnaly", "PeakWide", DefaultAnaly.PeakWide);
            ini.WriteValue("DefaultAnaly", "Slope", DefaultAnaly.Slope);
            ini.WriteValue("DefaultAnaly", "Drift", DefaultAnaly.Drift);
            ini.WriteValue("DefaultAnaly", "MinAreaSize", DefaultAnaly.MinAreaSize.ToString());
            ini.WriteValue("DefaultAnaly", "ParaChangeTime", DefaultAnaly.ParaChangeTime);
            ini.WriteValue("DefaultAnaly", "Ratio", DefaultAnaly.Ratio.ToString());
            ini.WriteValue("DefaultAnaly", "AimPara", (Int32)DefaultAnaly.AimPara);
            ini.WriteValue("DefaultAnaly", "AimWay", (Int32)DefaultAnaly.AimWay);
            ini.WriteValue("DefaultAnaly", "ArithmaticParameter", (Int32)DefaultAnaly.ArithmaticParameter);
            ini.WriteValue("DefaultAnaly", "Arithmatic", (Int32)DefaultAnaly.Arithmatic);
            ini.WriteValue("DefaultAnaly", "TimeWindow", DefaultAnaly.TimeWindow);
            ini.WriteValue("DefaultAnaly", "FixWay", (Int32)DefaultAnaly.FixWay);

            // 缺省ID表写入
            ini.WriteValue("DefaultIdTable", "TimeBand", DefaultIdTable.TimeBand.ToString());
            ini.WriteValue("DefaultIdTable", "SampleWeight", DefaultIdTable.SampleWeight);
            ini.WriteValue("DefaultIdTable", "Density", DefaultIdTable.Density.ToString());
            ini.WriteValue("DefaultIdTable", "PeakHeight", DefaultIdTable.PeakHeight.ToString());
            ini.WriteValue("DefaultIdTable", "PeakSize", DefaultIdTable.PeakSize.ToString());
            ini.WriteValue("DefaultIdTable", "FactorOne", DefaultIdTable.FactorOne.ToString());
            ini.WriteValue("DefaultIdTable", "FactorTwo", DefaultIdTable.FactorTwo.ToString());
            ini.WriteValue("DefaultIdTable", "ReserveTime", DefaultIdTable.ReserveTime.ToString());
            ini.WriteValue("DefaultIdTable", "IngredientName", DefaultIdTable.IngredientName);

            // 缺省反控方法写入
            ini.WriteValue("DefaultColumnPara", "BalanceTime", DefaultHeatingSource.BalanceTime.ToString());
            ini.WriteValue("DefaultColumnPara", "InitTemp", DefaultHeatingSource.InitTemp.ToString());
            ini.WriteValue("DefaultColumnPara", "MaintainTime", DefaultHeatingSource.MaintainTime.ToString());
            ini.WriteValue("DefaultColumnPara", "AlertTemp", DefaultHeatingSource.AlertTemp.ToString());
            ini.WriteValue("DefaultColumnPara", "ColumnCount", DefaultHeatingSource.ColumnCount.ToString());

            ini.WriteValue("DefaultColumnPara", "RateCol1", DefaultHeatingSource.RateCol1.ToString());
            ini.WriteValue("DefaultColumnPara", "RateCol2", DefaultHeatingSource.RateCol2.ToString());
            ini.WriteValue("DefaultColumnPara", "RateCol3", DefaultHeatingSource.RateCol3.ToString());
            ini.WriteValue("DefaultColumnPara", "RateCol4", DefaultHeatingSource.RateCol4.ToString());
            ini.WriteValue("DefaultColumnPara", "RateCol5", DefaultHeatingSource.RateCol5.ToString());

            ini.WriteValue("DefaultColumnPara", "TempCol1", DefaultHeatingSource.TempCol1.ToString());
            ini.WriteValue("DefaultColumnPara", "TempCol2", DefaultHeatingSource.TempCol2.ToString());
            ini.WriteValue("DefaultColumnPara", "TempCol3", DefaultHeatingSource.TempCol3.ToString());
            ini.WriteValue("DefaultColumnPara", "TempCol4", DefaultHeatingSource.TempCol4.ToString());
            ini.WriteValue("DefaultColumnPara", "TempCol5", DefaultHeatingSource.TempCol5.ToString());

            ini.WriteValue("DefaultColumnPara", "TempTimeCol1", DefaultHeatingSource.TempTimeCol1.ToString());
            ini.WriteValue("DefaultColumnPara", "TempTimeCol2", DefaultHeatingSource.TempTimeCol2.ToString());
            ini.WriteValue("DefaultColumnPara", "TempTimeCol3", DefaultHeatingSource.TempTimeCol3.ToString());
            ini.WriteValue("DefaultColumnPara", "TempTimeCol4", DefaultHeatingSource.TempTimeCol4.ToString());
            ini.WriteValue("DefaultColumnPara", "TempTimeCol5", DefaultHeatingSource.TempTimeCol5.ToString());

            ini.WriteValue("DefaultInject", "AlertTemp", DefaultInject.AlertTemp.ToString());
            ini.WriteValue("DefaultInject", "InitTemp", DefaultInject.InitTemp.ToString());
            ini.WriteValue("DefaultInject", "InjectTime", DefaultInject.InjectTime.ToString());
            ini.WriteValue("DefaultInject", "ColumnType", (Int32)DefaultInject.ColumnType);
            ini.WriteValue("DefaultInject", "InjectMode", (Int32)DefaultInject.InjectMode);

            ini.WriteValue("DefaultAux", "AlertTempAux1", DefaultAux.AlertTempAux1.ToString());
            ini.WriteValue("DefaultAux", "AlertTempAux2", DefaultAux.AlertTempAux2.ToString());
            ini.WriteValue("DefaultAux", "InitTempAux1", DefaultAux.InitTempAux1.ToString());
            ini.WriteValue("DefaultAux", "InitTempAux2", DefaultAux.InitTempAux2.ToString());

            ini.WriteValue("DefaultFid", "AlertTemp1", DefaultFid.AlertTemp1.ToString());
            ini.WriteValue("DefaultFid", "InitTemp1", DefaultFid.InitTemp1.ToString());
            ini.WriteValue("DefaultFid", "AlertTemp2", DefaultFid.AlertTemp2.ToString());
            ini.WriteValue("DefaultFid", "InitTemp2", DefaultFid.InitTemp2.ToString());
            ini.WriteValue("DefaultFid", "MagnifyFactor1", DefaultFid.MagnifyFactor1.ToString());
            ini.WriteValue("DefaultFid", "MagnifyFactor2", DefaultFid.MagnifyFactor2.ToString());
            ini.WriteValue("DefaultFid", "Polarity1", DefaultFid.Polarity1.ToString());
            ini.WriteValue("DefaultFid", "Polarity2", DefaultFid.Polarity2.ToString());

            ini.WriteValue("DefaultTcd", "AlertTemp1", DefaultTcd.AlertTemp1.ToString());
            ini.WriteValue("DefaultTcd", "InitTemp1", DefaultTcd.InitTemp1.ToString());
            ini.WriteValue("DefaultTcd", "AlertTemp2", DefaultTcd.AlertTemp2.ToString());
            ini.WriteValue("DefaultTcd", "InitTemp2", DefaultTcd.InitTemp2.ToString());
            ini.WriteValue("DefaultTcd", "CurrentOne", DefaultTcd.CurrentOne.ToString());
            ini.WriteValue("DefaultTcd", "CurrentTwo", DefaultTcd.CurrentTwo.ToString());
            ini.WriteValue("DefaultTcd", "PolarityOne", DefaultTcd.PolarityOne.ToString());
            ini.WriteValue("DefaultTcd", "PolarityTwo", DefaultTcd.PolarityTwo.ToString());
            ini.WriteValue("DefaultTcd", "AlertOne", DefaultTcd.AlertOne.ToString());
            ini.WriteValue("DefaultTcd", "AlertTwo", DefaultTcd.AlertTwo.ToString());
            ini.WriteValue("DefaultTcd", "OnOffOne", DefaultTcd.OnOffOne.ToString());
            ini.WriteValue("DefaultTcd", "OnOffTwo", DefaultTcd.OnOffTwo.ToString());

            // 缺省样品信息写入
            ini.WriteValue("DefaultSampleInfo", "SampleWeight", DefaultSampleInfo.SampleWeight.ToString());
            ini.WriteValue("DefaultSampleInfo", "InnerWeight", DefaultSampleInfo.InnerWeight.ToString());

            // 板卡安装状态
            ini.WriteValue("GcChannel", "Tcd2", GcChannel.Tcd2.ToString());
            ini.WriteValue("GcChannel", "Tcd1", GcChannel.Tcd1.ToString());
            ini.WriteValue("GcChannel", "Fid2", GcChannel.Fid2.ToString());
            ini.WriteValue("GcChannel", "Fid1", GcChannel.Fid1.ToString());

        }

    }


}
