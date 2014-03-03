using System;
using System.Collections.Generic;
using System.Text;

namespace ChromatoTool.dto
{
    public class FpdDto
    {
        /// <summary>
        /// FPD放大倍数
        /// </summary>
        public Int32 MagnifyFactor { get; set; }
        /// <summary>
        /// FPD极性
        /// </summary>
        public bool Polarity { get; set; }
    }
}
