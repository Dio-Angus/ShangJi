/*-----------------------------------------------------------------------------
//  FILE NAME       : RangeDto.cs
//  FUNCTION        : 放大缩小的坐标范围
//  AUTHOR          : 李锋(2009/02/17)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


namespace ChromatoTool.dto
{
    /// <summary>
    /// 放大缩小的坐标范围
    /// </summary>
    public class RangeDto
    {
        /// <summary>
        /// 起点X方向值
        /// </summary>
        public double StartValX { get; set; }
        
        /// <summary>
        /// 起点Y方向值
        /// </summary>
        public double StartValY { get; set; }

        /// <summary>
        /// 终点X方向值
        /// </summary>
        public double EndValX { get; set; }

        /// <summary>
        /// 终点Y方向值
        /// </summary>
        public double EndValY { get; set; }

        /// <summary>
        /// 起点X方向坐标
        /// </summary>
        public int StartPosX { get; set; }

        /// <summary>
        /// 起点Y方向坐标
        /// </summary>
        public int StartPosY { get; set; }

        /// <summary>
        /// 终点X方向坐标
        /// </summary>
        public int EndPosX { get; set; }

        /// <summary>
        /// 终点Y方向坐标
        /// </summary>
        public int EndPosY { get; set; }
    }
}
