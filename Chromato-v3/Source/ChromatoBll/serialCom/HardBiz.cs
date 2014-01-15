/*-----------------------------------------------------------------------------
//  FILE NAME       : HardBiz.cs
//  FUNCTION        : 下位机数据发送逻辑类
//  AUTHOR          : 李锋(2009/07/06)
//  VERSION         : V1.0
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

    /// <summary>
    /// 模块地址
    /// </summary>
    public class ModuleAddress
    {
        /// <summary>
        /// 温度控制
        /// </summary>
        public const string TempControl = "21";

        /// <summary>
        /// FID1
        /// </summary>
        public const string FID1 = "41";

        /// <summary>
        /// FID2
        /// </summary>
        public const string FID2 = "42";

        /// <summary>
        /// TCD1
        /// </summary>
        public const string TCD1 = "51";

        /// <summary>
        /// TCD2
        /// </summary>
        public const string TCD2 = "52";

        /// <summary>
        /// FLOW
        /// </summary>
        public const string FLOW = "61";

        /// <summary>
        /// 控制板
        /// </summary>
        public const string ControlBoard = "01";

        /// <summary>
        /// RS232
        /// </summary>
        public const string RS232 = "02";

    }

    /// <summary>
    /// 命令
    /// </summary>
    public class PcCommand
    {
        /// <summary>
        /// FID1命令
        /// </summary>
        public const string FID1 = "F1";

        /// <summary>
        /// FID2命令
        /// </summary>
        public const string FID2 = "F2";

        /// <summary>
        /// TCD1命令
        /// </summary>
        public const string TCD1 = "F3";

        /// <summary>
        /// TCD2命令
        /// </summary>
        public const string TCD2 = "F4";

        /// <summary>
        /// AUX命令
        /// </summary>
        public const string AUX = "F5";

        /// <summary>
        /// INJ1命令
        /// </summary>
        public const string INJ1 = "F6";

        /// <summary>
        /// INJ2命令
        /// </summary>
        public const string INJ2 = "F7";

        /// <summary>
        /// INJ3命令
        /// </summary>
        public const string INJ3 = "F8";

        /// <summary>
        /// 柱箱命令
        /// </summary>
        public const string ColumnTemp = "F0";

        /// <summary>
        /// 使能状态
        /// </summary>
        public const string EnableStatus = "02";

        /// <summary>
        /// 加热状态
        /// </summary>
        public const string HeatStatus = "01";

        /// <summary>
        /// 联机命令
        /// </summary>
        public const string Link = "80";

    }
    
    /// <summary>
    /// 桢特征
    /// </summary>
    public class Version3010
    {
        /// <summary>
        /// 数据开始字符
        /// </summary>
        public const string DataStart = "23";

        /// <summary>
        /// 桢结束字符
        /// </summary>
        public const string FrameEnd = "0D";

        /// <summary>
        /// 桢最小长度
        /// </summary>
        public const Int32 MinLength = 8;

        /// <summary>
        /// FID
        /// </summary>
        public const string FID = "A0";

        /// <summary>
        /// TCD
        /// </summary>
        public const string TCD = "A1";

        /// <summary>
        /// 小数点的ASCII
        /// </summary>
        public const string PointHex = "2E";

        /// <summary>
        /// 小数点
        /// </summary>
        public const string Point = ".";

        /// <summary>
        /// 负号的ASCII
        /// </summary>
        public const string NegativeHex = "2D";

        /// <summary>
        /// 负号的ASCII
        /// </summary>
        public const string Negative = "-";

        /// <summary>
        /// 空格的ASCII
        /// </summary>
        public const string Space = "20";
    }

    /// <summary>
    /// 2000型 桢特征
    /// </summary>
    public class Version2000
    {

        /// <summary>
        /// 桢开始字符
        /// </summary>
        public const string StartChar = "23";

        /// <summary>
        /// 桢结束字符
        /// </summary>
        public const string EndChar = "21";

        /// <summary>
        /// 桢长度 23 A1 A2 A3 A4 A5 A6 MM 21
        /// </summary>
        public const Int32 FrameLength = 9 * 2;

        /// <summary>
        /// 通道1的开始命令
        /// </summary>
        public const string StartCmdA = "25AAD79D8945BFA3409092A3C2134BA729DD21";

        /// <summary>
        /// 通道2的开始命令
        /// </summary>
        public const string StartCmdB = "25BBD79D8945BFA3409092A3C2134BA729DD21";
    }

    /// <summary>
    /// 下位命令
    /// </summary>
    public class GcCommand
    {
        /// <summary>
        /// Col状态
        /// </summary>
        public const string ColStatus = "DD";

        /// <summary>
        /// Col目标温度
        /// </summary>
        public const string ColTargetTemp = "83";

        /// <summary>
        /// 柱箱温度
        /// </summary>
        public const string ColTemp = "91";

        /// <summary>
        /// TCD温度
        /// </summary>
        public const string TcdTemp = "92";

        /// <summary>
        /// FID温度
        /// </summary>
        public const string FidTemp = "93";

        /// <summary>
        /// Inj温度
        /// </summary>
        public const string InjTemp = "94";

        /// <summary>
        /// Aux1温度
        /// </summary>
        public const string Aux1Temp = "95";

        /// <summary>
        /// Aux2温度
        /// </summary>
        public const string Aux2Temp = "96";

        /// <summary>
        /// 柱箱温度状态
        /// </summary>
        public const string ColTempStatus = "81";

        /// <summary>
        /// LED准备灯闪烁
        /// </summary>
        public const string PrepareLed = "82";

        /// <summary>
        /// FID1信号值
        /// </summary>
        public const string Fid1Signal = "A0";

        /// <summary>
        /// FID2信号值
        /// </summary>
        public const string Fid2Signal = "A1";

        /// <summary>
        /// TCD1信号值
        /// </summary>
        public const string Tcd1Signal = "A2";

        /// <summary>
        /// TCD2信号值
        /// </summary>
        public const string Tcd2Signal = "A3";

        /// <summary>
        /// 联机返回命令
        /// </summary>
        public const string LinkResponse = "C0";

        /// <summary>
        /// GC启动命令
        /// </summary>
        public const string GcStart = "05";

        /// <summary>
        /// GC停止命令
        /// </summary>
        public const string GcStop = "06";

    }

    /// <summary>
    /// 下位机数据发送逻辑类
    /// </summary>
    public class HardBiz
    {


        #region 变量

        /// <summary>
        /// 连接GC标志
        /// </summary>
        public LinkGcStatus LinkGc  { get; set; }

        #endregion


        #region 初期

        /// <summary>
        /// 实例名
        /// </summary>
        static readonly HardBiz instance = new HardBiz();

        /// <summary>
        /// 唯一实例
        /// </summary>
        public static HardBiz Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// 构造
        /// </summary>
        public HardBiz()
        {
        }
        
        #endregion


        #region 方法

        /// <summary>
        /// 下载反控方法到下位机
        /// </summary>
        /// <param name="dtoAnti"></param>
        /// <param name="type"></param>
        public void DownloadAntiMethod(AntiControlDto dtoAnti, AntiControlType type)
        {
            if (!this.OpenCommPort())
            {
                return;
            }

            switch (type)
            {/*
                case AntiControlType.Fid1:
                    this.DownloadFid1(dtoAnti);
                    break;
                case AntiControlType.Fid2:
                    this.DownloadFid2(dtoAnti);
                    break;
                case AntiControlType.Tcd1:
                    this.DownloadTcd1(dtoAnti);
                    break;
                case AntiControlType.Tcd2:
                    this.DownloadTcd2(dtoAnti);
                    break;
                case AntiControlType.Aux:
                    this.DownloadAux(dtoAnti);
                    break;
                case AntiControlType.Injecter1:
                    this.DownloadInj1(dtoAnti);
                    break;
                case AntiControlType.Injecter2:
                    this.DownloadInj2(dtoAnti);
                    break;
                case AntiControlType.Injecter3:
                    this.DownloadInj3(dtoAnti);
                    break;
                case AntiControlType.HeatingSource:
                    this.DownloadColumn(dtoAnti);
                    break;*/
            }
        }

        /// <summary>
        /// 下载Fid1反控方法到下位机
        /// </summary>
        /// <param name="dtoAnti"></param>
        private void DownloadFid1(AntiControlDto dtoAnti)
        {
            StringBuilder para = null;

            para = this.GetFID1Para(dtoAnti);
            CommPort.Instance.Send(para.ToString(), true);
        }

        /// <summary>
        /// 下载Fid2反控方法到下位机
        /// </summary>
        /// <param name="dtoAnti"></param>
        private void DownloadFid2(AntiControlDto dtoAnti)
        {
            StringBuilder para = null;

            para = this.GetFID2Para(dtoAnti);
            CommPort.Instance.Send(para.ToString(), true);
        }

        /// <summary>
        /// 下载Tcd1反控方法到下位机
        /// </summary>
        /// <param name="dtoAnti"></param>
        private void DownloadTcd1(AntiControlDto dtoAnti)
        {
            StringBuilder para = null;
            para = this.GetTCD1Para(dtoAnti);
            CommPort.Instance.Send(para.ToString(), true);
        }

        /// <summary>
        /// 下载Tcd2反控方法到下位机
        /// </summary>
        /// <param name="dtoAnti"></param>
        private void DownloadTcd2(AntiControlDto dtoAnti)
        {
            StringBuilder para = null;
            para = this.GetTCD2Para(dtoAnti);
            CommPort.Instance.Send(para.ToString(), true);
        }

        /// <summary>
        /// 下载Aux反控方法到下位机
        /// </summary>
        /// <param name="dtoAnti"></param>
        private void DownloadAux(AntiControlDto dtoAnti)
        {
            StringBuilder para = null;
            para = this.GetAUXPara(dtoAnti);
            CommPort.Instance.Send(para.ToString(), true);
        }

        /// <summary>
        /// 下载Inj1反控方法到下位机
        /// </summary>
        /// <param name="dtoAnti"></param>
        private void DownloadInj1(AntiControlDto dtoAnti)
        {
            StringBuilder para = null;
            para = this.GetInject1Para(dtoAnti);
            CommPort.Instance.Send(para.ToString(), true);
        }

        /// <summary>
        /// 下载Inj2反控方法到下位机
        /// </summary>
        /// <param name="dtoAnti"></param>
        private void DownloadInj2(AntiControlDto dtoAnti)
        {
            StringBuilder para = null;
            para = this.GetInject2Para(dtoAnti);
            CommPort.Instance.Send(para.ToString(), true);
        }

        /// <summary>
        /// 下载Inj3反控方法到下位机
        /// </summary>
        /// <param name="dtoAnti"></param>
        private void DownloadInj3(AntiControlDto dtoAnti)
        {
            StringBuilder para = null;
            para = this.GetInject3Para(dtoAnti);
            CommPort.Instance.Send(para.ToString(), true);
        }

        /// <summary>
        /// 下载柱箱反控方法到下位机
        /// </summary>
        /// <param name="dtoAnti"></param>
        private void DownloadColumn(AntiControlDto dtoAnti)
        {
            StringBuilder para = null;
            para = this.GetHeatingSource(dtoAnti);
        }

        /// <summary>
        /// 打开CommPort成功或者失败
        /// </summary>
        /// <returns></returns>
        private bool OpenCommPort()
        {
            String ret = "";
            if (!CommPort.Instance.IsOpen)
            {
                ret = CommPort.Instance.Open();

                if (!String.IsNullOrEmpty(ret))
                {
                    MessageBox.Show(String.Format("打开串口{0} ,{1} ！", Port.SictPort, ret), "打开串口失败");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 取得FID1参数
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private StringBuilder GetFID1Para(AntiControlDto dto)
        {
            StringBuilder para = new StringBuilder();
            String temp = dto.dtoFid.PolarityOne ? "01" : "00";
            //初温
            para.Append(Version3010.DataStart + ModuleAddress.FID1 + PcCommand.FID1 + "01" + this.ConvertToBcd(dto.dtoFid.InitTemp.ToString()) + Version3010.FrameEnd);
            //报警温度
            para.Append(Version3010.DataStart + ModuleAddress.FID1 + PcCommand.FID1 + "02" + this.ConvertToBcd(dto.dtoFid.AlertTemp.ToString()) + Version3010.FrameEnd);
            //极性
            para.Append(Version3010.DataStart + ModuleAddress.FID1 + PcCommand.FID1 + "03" + temp + Version3010.FrameEnd);
            //放大倍数
            para.Append(Version3010.DataStart + ModuleAddress.FID1 + PcCommand.FID1 + "04" + String.Format("{0:D2}", dto.dtoFid.MagnifyFactorOne) + Version3010.FrameEnd);

            return para;
        }

        /// <summary>
        /// 取得FID2参数
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private StringBuilder GetFID2Para(AntiControlDto dto)
        {
            StringBuilder para = new StringBuilder();
            String temp = dto.dtoFid.PolarityTwo ? "01" : "00";
            para.Append(Version3010.DataStart + ModuleAddress.FID2 + PcCommand.FID2 + "01" + this.ConvertToBcd(dto.dtoFid.InitTemp.ToString()) + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.FID2 + PcCommand.FID2 + "02" + this.ConvertToBcd(dto.dtoFid.AlertTemp.ToString()) + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.FID2 + PcCommand.FID2 + "03" + temp + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.FID2 + PcCommand.FID2 + "04" + String.Format("{0:D2}", dto.dtoFid.MagnifyFactorTwo) + Version3010.FrameEnd);

            return para;
        }

        /// <summary>
        /// 取得TCD1参数
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private StringBuilder GetTCD1Para(AntiControlDto dto)
        {
            StringBuilder para = new StringBuilder();
            String temp = dto.dtoTcd.PolarityOne ? "01" : "00";

            para.Append(Version3010.DataStart + ModuleAddress.TCD1 + PcCommand.TCD1 + "01" + this.ConvertToBcd(dto.dtoTcd.InitTemp1.ToString()) + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.TCD1 + PcCommand.TCD1 + "02" + this.ConvertToBcd(dto.dtoTcd.AlertTemp1.ToString()) + Version3010.FrameEnd);

            para.Append(Version3010.DataStart + ModuleAddress.TCD1 + PcCommand.TCD1 + "03" + temp + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.TCD1 + PcCommand.TCD1 + "04" + this.ConvertToBcd(dto.dtoTcd.CurrentOne.ToString()) + Version3010.FrameEnd);

            //temp = dto.dtoTcd.OnOffOne ? "01" : "00";
            //para.Append(FrameTrans.DataStart + ModuleAddress.TCD1 + "0F" + "00" + temp + FrameTrans.FrameEnd);
            //para.Append(FrameTrans.DataStart + ModuleAddress.TCD1 + "10" + "00" + dto.dtoTcd.AlertOne.ToString() + FrameTrans.FrameEnd);

            return para;
        }

        /// <summary>
        /// 取得TCD2参数
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private StringBuilder GetTCD2Para(AntiControlDto dto)
        {
            StringBuilder para = new StringBuilder();
            String temp = dto.dtoTcd.PolarityTwo ? "01" : "00";

            para.Append(Version3010.DataStart + ModuleAddress.TCD2 + PcCommand.TCD2 + "01" + this.ConvertToBcd(dto.dtoTcd.InitTemp2.ToString()) + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.TCD2 + PcCommand.TCD2 + "02" + this.ConvertToBcd(dto.dtoTcd.AlertTemp2.ToString()) + Version3010.FrameEnd);

            para.Append(Version3010.DataStart + ModuleAddress.TCD2 + PcCommand.TCD2 + "03" + temp + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.TCD2 + PcCommand.TCD2 + "04" + this.ConvertToBcd(dto.dtoTcd.CurrentTwo.ToString()) + Version3010.FrameEnd);

            //temp = dto.dtoTcd.OnOffTwo ? "01" : "00";
            //para.Append(FrameTrans.DataStart + ModuleAddress.TCD2 + "0F" + "00" + temp + FrameTrans.FrameEnd);
            //para.Append(FrameTrans.DataStart + ModuleAddress.TCD2 + "10" + "00" + dto.dtoTcd.AlertTwo.ToString() + FrameTrans.FrameEnd);

            return para;
        }

        /// <summary>
        /// 取得AUX1,AUX2参数
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private StringBuilder GetAUXPara(AntiControlDto dto)
        {
            StringBuilder para = new StringBuilder();
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.AUX + "01" + this.ConvertToBcd(dto.dtoAux.InitTempAux1.ToString()) + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.AUX + "02" + this.ConvertToBcd(dto.dtoAux.AlertTempAux1.ToString()) + Version3010.FrameEnd);

            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.AUX + "03" + this.ConvertToBcd(dto.dtoAux.InitTempAux2.ToString()) + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.AUX + "04" + this.ConvertToBcd(dto.dtoAux.AlertTempAux2.ToString()) + Version3010.FrameEnd);
            return para;
        }

        /// <summary>
        /// 取得进样口1参数
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private StringBuilder GetInject1Para(AntiControlDto dto)
        {
            StringBuilder para = new StringBuilder();
            //初温
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.INJ1 + "01" + this.ConvertToBcd(dto.dtoInject.InitTemp.ToString()) + Version3010.FrameEnd);
            //报警温度
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.INJ1 + "02" + this.ConvertToBcd(dto.dtoInject.AlertTemp.ToString()) + Version3010.FrameEnd);
            //柱类型
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.INJ1 + "03" + String.Format("{0:D2}", (int)dto.dtoInject.ColumnType1) + Version3010.FrameEnd);
            //进样时间
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.INJ1 + "04" + this.ConvertToBcd(dto.dtoInject.InjectTime1.ToString()) + Version3010.FrameEnd);
            //进样模式
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.INJ1 + "00" + String.Format("{0:D2}", (int)dto.dtoInject.InjectMode1) + Version3010.FrameEnd);

            return para;
        }

        /// <summary>
        /// 取得进样口2参数
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private StringBuilder GetInject2Para(AntiControlDto dto)
        {
            StringBuilder para = new StringBuilder();
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.INJ2 + "01" + this.ConvertToBcd(dto.dtoInject.InitTemp.ToString()) + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.INJ2 + "02" + this.ConvertToBcd(dto.dtoInject.AlertTemp.ToString()) + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.INJ2 + "03" + String.Format("{0:D2}", (int)dto.dtoInject.ColumnType2) + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.INJ2 + "04" + this.ConvertToBcd(dto.dtoInject.InjectTime2.ToString()) + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.INJ2 + "00" + String.Format("{0:D2}", (int)dto.dtoInject.InjectMode2) + Version3010.FrameEnd);

            return para;
        }
        
        /// <summary>
        /// 取得进样口3参数
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private StringBuilder GetInject3Para(AntiControlDto dto)
        {
            StringBuilder para = new StringBuilder();
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.INJ3 + "01" + this.ConvertToBcd(dto.dtoInject.InitTemp.ToString()) + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.INJ3 + "02" + this.ConvertToBcd(dto.dtoInject.AlertTemp.ToString()) + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.INJ3 + "03" + String.Format("{0:D2}", (int)dto.dtoInject.ColumnType3) + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.INJ3 + "04" + this.ConvertToBcd(dto.dtoInject.InjectTime3.ToString()) + Version3010.FrameEnd);
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.INJ3 + "00" + String.Format("{0:D2}", (int)dto.dtoInject.InjectMode3) + Version3010.FrameEnd);

            return para;
        }

        /// <summary>
        /// 取得加热源参数
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private StringBuilder GetHeatingSource(AntiControlDto dto)
        {
            StringBuilder para = new StringBuilder();
            //初温
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "01" + this.ConvertToBcd(dto.dtoHeatingSource .InitTemp.ToString()) + Version3010.FrameEnd);
            //报警温度
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "02" + this.ConvertToBcd(dto.dtoHeatingSource .AlertTemp.ToString()) + Version3010.FrameEnd);
            //初温维持时间
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "03" + this.ConvertToBcd(dto.dtoHeatingSource .MaintainTime.ToString()) + Version3010.FrameEnd);
            //平衡时间
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "04" + this.ConvertToBcd(dto.dtoHeatingSource .BalanceTime.ToString()) + Version3010.FrameEnd);
            //程升阶数
            para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "05" + this.ConvertToBcd(dto.dtoHeatingSource .ColumnCount.ToString()) + Version3010.FrameEnd);

            if (0 < dto.dtoHeatingSource .ColumnCount)
            {
                para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "16" + this.ConvertToBcd(dto.dtoHeatingSource .RateCol1.ToString()) + Version3010.FrameEnd);
                para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "17" + this.ConvertToBcd(dto.dtoHeatingSource .TempCol1.ToString()) + Version3010.FrameEnd);
                para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "18" + this.ConvertToBcd(dto.dtoHeatingSource .TempTimeCol1.ToString()) + Version3010.FrameEnd);
                CommPort.Instance.Send(para.ToString(), true);
            }
            if (1 < dto.dtoHeatingSource .ColumnCount)
            {
                para.Remove(0, para.Length);
                para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "19" + this.ConvertToBcd(dto.dtoHeatingSource .RateCol2.ToString()) + Version3010.FrameEnd);
                para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "1A" + this.ConvertToBcd(dto.dtoHeatingSource .TempCol2.ToString()) + Version3010.FrameEnd);
                para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "1B" + this.ConvertToBcd(dto.dtoHeatingSource .TempTimeCol2.ToString()) + Version3010.FrameEnd);
                CommPort.Instance.Send(para.ToString(), true);
            }
            if (2 < dto.dtoHeatingSource .ColumnCount)
            {
                para.Remove(0, para.Length);
                para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "1C" + this.ConvertToBcd(dto.dtoHeatingSource .RateCol3.ToString()) + Version3010.FrameEnd);
                para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "1D" + this.ConvertToBcd(dto.dtoHeatingSource .TempCol3.ToString()) + Version3010.FrameEnd);
                para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "1E" + this.ConvertToBcd(dto.dtoHeatingSource .TempTimeCol3.ToString()) + Version3010.FrameEnd);
                CommPort.Instance.Send(para.ToString(), true);
            }
            if (3 < dto.dtoHeatingSource .ColumnCount)
            {
                para.Remove(0, para.Length);
                para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "1F" + this.ConvertToBcd(dto.dtoHeatingSource .RateCol4.ToString()) + Version3010.FrameEnd);
                para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "20" + this.ConvertToBcd(dto.dtoHeatingSource .TempCol4.ToString()) + Version3010.FrameEnd);
                para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "21" + this.ConvertToBcd(dto.dtoHeatingSource .TempTimeCol4.ToString()) + Version3010.FrameEnd);
                CommPort.Instance.Send(para.ToString(), true);
            }
            if (4 < dto.dtoHeatingSource .ColumnCount)
            {
                para.Remove(0, para.Length);
                para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "22" + this.ConvertToBcd(dto.dtoHeatingSource .RateCol5.ToString()) + Version3010.FrameEnd);
                para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "23" + this.ConvertToBcd(dto.dtoHeatingSource .TempCol5.ToString()) + Version3010.FrameEnd);
                para.Append(Version3010.DataStart + ModuleAddress.TempControl + PcCommand.ColumnTemp + "24" + this.ConvertToBcd(dto.dtoHeatingSource .TempTimeCol5.ToString()) + Version3010.FrameEnd);
                CommPort.Instance.Send(para.ToString(), true);
            }

            return para;
        }

        /// <summary>
        /// 联机命令
        /// </summary>
        public void LinkToGc()
        {
            this.OfflineToGc();

            if (!this.OpenCommPort())
            {
                return;
            }
            CommPort.Instance.OpenLoop();

            StringBuilder para = new StringBuilder();
            para.Append(Version3010.DataStart + ModuleAddress.RS232 + PcCommand.Link + "00" + "01" + Version3010.FrameEnd);
            CommPort.Instance.Send(para.ToString(),true);
        }

        /// <summary>
        /// 脱机命令
        /// </summary>
        public void OfflineToGc()
        {
            if (!this.OpenCommPort())
            {
                return;
            }

            StringBuilder para = new StringBuilder();
            para.Append(Version3010.DataStart + ModuleAddress.RS232 + PcCommand.Link + "00" + "02" + Version3010.FrameEnd);
            CommPort.Instance.Send(para.ToString(), true);
            this.LinkGc = LinkGcStatus.Off;

            CommPort.Instance.CloseLoop();
        }

        /// <summary>
        /// GC启动命令
        /// </summary>
        public void StartGc()
        {
            if (!this.OpenCommPort())
            {
                return;
            }

            StringBuilder para = new StringBuilder();
            para.Append(Version3010.DataStart + ModuleAddress.RS232 + "05" + Version3010.FrameEnd);
            CommPort.Instance.Send(para.ToString(), true);
        }

        /// <summary>
        /// GC停止命令
        /// </summary>
        public void StopGc()
        {
            if (!this.OpenCommPort())
            {
                return;
            }

            StringBuilder para = new StringBuilder();
            para.Append(Version3010.DataStart + ModuleAddress.RS232 + "06" + Version3010.FrameEnd);
            CommPort.Instance.Send(para.ToString(), true);
        }

        /// <summary>
        /// 把10进制数据转化为BCD码
        /// </summary>
        /// <param name="inVal"></param>
        /// <returns></returns>
        private String ConvertToBcd(String inVal)
        {
            String strOut = "";
            if(!CastString.IsNumeric(inVal))
            {
                return strOut;
            }
            String temp = "";
            for (int i = 0; i < inVal.Length; i++)
            {
                temp = inVal.Substring(i,1);
                if (Version3010.Point.Equals(temp))
                {
                    strOut += Version3010.PointHex;
                }
                else
                {
                    strOut += "3" + temp;
                }
            }
            
            return strOut;
        }

        #endregion


    }

}
