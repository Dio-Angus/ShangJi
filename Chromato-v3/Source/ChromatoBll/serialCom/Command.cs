using System;
using System.Collections.Generic;
using System.Text;

namespace ChromatoBll.serialCom
{
    class Command
    {
    }
    #region 指令

    /// <summary>
    /// 基础指令
    /// </summary>
    public class baseCommand
    {
        /// <summary>
        /// 数据包头1
        /// </summary>
        public const string head_1 = "aa";

        /// <summary>
        /// 数据包头2
        /// </summary>
        public const string head_2 = "55";

        /// <summary>
        /// 数据包尺寸
        /// </summary>
        public string length;
    }

    /// <summary>
    /// 类别指令
    /// </summary>
    public class addressCommand
    {
        /// <summary>
        /// PC地址
        /// </summary>
        public const string PC = "ff";

        /// <summary>
        /// 温控地址
        /// </summary>
        public const string HeatControl = "21";

        /// <summary>
        /// FID1地址
        /// </summary>
        public const string FID1 = "41";

        /// <summary>
        /// FID2地址
        /// </summary>
        public const string FID2 = "42";

        /// <summary>
        /// TCD1地址
        /// </summary>
        public const string TCD1 = "51";

        /// <summary>
        /// TCD2地址
        /// </summary>
        public const string TCD2 = "52";

        /// <summary>
        /// FLOW地址
        /// </summary>
        public const string FLOW = "61";

        /// <summary>
        /// 控制板地址
        /// </summary>
        public const string ControlBoard = "01";

        /// <summary>
        /// RS232地址
        /// </summary>
        public const string RS232 = "02";

        /// <summary>
        /// 网络板地址
        /// </summary>
        public const string NetworkBoard = "03";

        /// <summary>
        /// FID公共地址
        /// </summary>
        public const string FIDShare = "40";

        /// <summary>
        /// TCD公共地址
        /// </summary>
        public const string TCDShare = "50";

        /// <summary>
        /// COL地址
        /// </summary>
        public const string COL = "22";

        /// <summary>
        /// AUX1地址
        /// </summary>
        public const string AUX1 = "23";

        /// <summary>
        /// AUX2地址
        /// </summary>
        public const string AUX2 = "24";

        /// <summary>
        /// INJ1地址
        /// </summary>
        public const string INJ1 = "25";

        /// <summary>
        /// INJ2地址
        /// </summary>
        public const string INJ2 = "26";

        /// <summary>
        /// INJ3地址
        /// </summary>
        public const string INJ3 = "27";

        /// <summary>
        /// INJ公共地址
        /// </summary>
        public const string INJShare = "28";

        /// <summary>
        /// FPD地址
        /// </summary>
        public const string FPD = "71";

        /// <summary>
        /// ECD地址
        /// </summary>
        public const string ECD = "72";
    }
}

    #endregion

