/*-----------------------------------------------------------------------------
//  FILE NAME       : NetworkBoardDto.cs
//  FUNCTION        : 网络板参数表
//  AUTHOR          : Dio(2014/01/10)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System.Drawing;
using System.Windows.Forms;
using ChromatoTool.dto;
using ChromatoTool.ini;
using System;
using ChromatoTool.util;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 反控方法→网络板
    /// </summary>
    public class NetworkBoardDto
    {
        //设备状态字
        public bool HeatingSourceUsed { get; set; }
        public bool FlowUsed { get; set; }
        public bool TCD2Used { get; set; }
        public bool TCD1Used { get; set; }
        public bool FID2Used { get; set; }
        public bool FID1Used { get; set; }
        public bool FPDUsed { get; set; }
        public bool ECDUsed { get; set; }

        public bool FIDK2Used { get; set; }
        public bool FIDK1Used { get; set; }

        //设备实际温度
        public Single ColCurrentTem { get; set; }
        public Single FID1CurrentTem { get; set; }
        public Single FID2CurrentTem { get; set; }
        public Single FIDK1CurrentTem { get; set; }
        public Single FIDK2CurrentTem { get; set; }
        public Single INJCurrentTem { get; set; }
        public Single AUX1CurrentTem { get; set; }
        public Single AUX2CurrentTem { get; set; }
        public Single TCD1CurrentTem { get; set; }
        public Single TCD2CurrentTem { get; set; }
        public Single ECDCurrentTem { get; set; }
        public Single FPDCurrentTem { get; set; }


        /// <summary>
        /// 网关IP地址
        /// </summary>
        public  String GateIP{ get; set; }
        /// <summary>
        /// 源IP地址
        /// </summary>
        public  String SourceIP{ get; set; }
        /// <summary>
        /// 本机物理地址
        /// </summary>
        public  String MAC{ get; set; }
        /// <summary>
        /// 子网掩码
        /// </summary>
        public  String Mask{ get; set; }

        /// <summary>
        /// Socket0端口地址
        /// </summary>
        public  String Socket0Address{ get; set; }
        /// <summary>
        /// Socket0目的IP地址
        /// </summary>
        public  String Socket0AimIP{ get; set; }
        /// <summary>
        /// Socket0目的端口地址
        /// </summary>
        public  String Socket0AimAddress{ get; set; }
        /// <summary>
        /// Socket0工作模式
        /// </summary>
        public  Single Socket0WorkMode{ get; set; }

        /// <summary>
        /// Socket1端口地址
        /// </summary>
        public  String Socket1Address{ get; set; }
        /// <summary>
        /// Socket1目的IP地址
        /// </summary>
        public  String Socket1AimIP{ get; set; }
        /// <summary>
        /// Socket1目的端口地址
        /// </summary>
        public  String Socket1AimAddress{ get; set; }
        /// <summary>
        /// Socket1工作模式
        /// </summary>
        public  Single Socket1WorkMode{ get; set; }
        
        /// <summary>
        /// Socket2端口地址
        /// </summary>
        public  String Socket2Address{ get; set; }
        /// <summary>
        /// Socket2目的IP地址
        /// </summary>
        public  String Socket2AimIP{ get; set; }
        /// <summary>
        /// Socket2目的端口地址
        /// </summary>
        public  String Socket2AimAddress{ get; set; }
        /// <summary>
        /// Socket2工作模式
        /// </summary>
        public  Single Socket2WorkMode{ get; set; }

        /// <summary>
        /// Socket3端口地址
        /// </summary>
        public  String Socket3Address{ get; set; }
        /// <summary>
        /// Socket3目的IP地址
        /// </summary>
        public  String Socket3AimIP{ get; set; }
        /// <summary>
        /// Socket3目的端口地址
        /// </summary>
        public  String Socket3AimAddress{ get; set; }
        /// <summary>
        /// Socket3工作模式
        /// </summary>
        public  Single Socket3WorkMode{ get; set; }
    }
}
