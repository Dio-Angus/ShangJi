/*-----------------------------------------------------------------------------
//  FILE NAME       : CommConst.cs
//  FUNCTION        : 串口常数类
//  AUTHOR          : 李锋(2010/06/14)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;

namespace ChromatoBll.serialCom
{
    /// <summary>
    /// 串口常数类
    /// </summary>
    class CommConst
    {
        #region 常数

        /// <summary>
        /// AI允许读取次数
        /// </summary>
        public const int AI_ALLOW_COUNT = 2;

        /// <summary>
        /// 清除允许读取次数
        /// </summary>
        public const int AI_CLEAN_COUNT = 10;

        /// <summary>
        /// 实时通道数
        /// </summary>
        public const int REAL_CHANNEL_COUNT = 4;

        #endregion
    }
}
