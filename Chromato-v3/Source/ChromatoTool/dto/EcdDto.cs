﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChromatoTool.dto
{
    public class EcdDto
    {
        /// <summary>
        /// 放大倍数
        /// </summary>
        public Int32 MagnifyFactor { get; set; }
        /// <summary>
        /// 极性
        /// </summary>
        public bool Polarity { get; set; }
        /// <summary>
        /// 电流
        /// </summary>
        public Single Current { get; set; }

        /// <summary>
        ///量程 
        /// </summary>
        public Single Capacity { get; set; }
    }
}
