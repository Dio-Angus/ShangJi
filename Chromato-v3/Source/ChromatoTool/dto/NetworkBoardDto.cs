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
        /// <summary>
        /// 网关IP地址
        /// </summary>
        public static String GateIP;
        /// <summary>
        /// 源IP地址
        /// </summary>
        public static String SourceIP;
        /// <summary>
        /// 本机物理地址
        /// </summary>
        public static String MAC;
        /// <summary>
        /// 子网掩码
        /// </summary>
        public static String Mask;

        /// <summary>
        /// Socket0端口地址
        /// </summary>
        public static String Socket0Address;
        /// <summary>
        /// Socket0目的IP地址
        /// </summary>
        public static String Socket0AimIP;
        /// <summary>
        /// Socket0目的端口地址
        /// </summary>
        public static String Socket0AimAddress;
        /// <summary>
        /// Socket0工作模式
        /// </summary>
        public static Single Socket0WorkMode;

        /// <summary>
        /// Socket1端口地址
        /// </summary>
        public static String Socket1Address;
        /// <summary>
        /// Socket1目的IP地址
        /// </summary>
        public static String Socket1AimIP;
        /// <summary>
        /// Socket1目的端口地址
        /// </summary>
        public static String Socket1AimAddress;
        /// <summary>
        /// Socket1工作模式
        /// </summary>
        public static Single Socket1WorkMode;
        
        /// <summary>
        /// Socket2端口地址
        /// </summary>
        public static String Socket2Address;
        /// <summary>
        /// Socket2目的IP地址
        /// </summary>
        public static String Socket2AimIP;
        /// <summary>
        /// Socket2目的端口地址
        /// </summary>
        public static String Socket2AimAddress;
        /// <summary>
        /// Socket2工作模式
        /// </summary>
        public static Single Socket2WorkMode;

        /// <summary>
        /// Socket3端口地址
        /// </summary>
        public static String Socket3Address;
        /// <summary>
        /// Socket3目的IP地址
        /// </summary>
        public static String Socket3AimIP;
        /// <summary>
        /// Socket3目的端口地址
        /// </summary>
        public static String Socket3AimAddress;
        /// <summary>
        /// Socket3工作模式
        /// </summary>
        public static Single Socket3WorkMode;
    }
}
