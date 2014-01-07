/*-----------------------------------------------------------------------------
//  FILE NAME       : ZoomDto.cs
//  FUNCTION        : ZoomDto
//  AUTHOR          : 李锋(2009/03/12)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


namespace ChromatoTool.dto
{
    /// <summary>
    /// 区域原始Dto
    /// </summary>
    public class ZoomDto
    {

        //グラフ拡大後に戻す時に必要
        public double fLeftVX { get; set; }	    //FullScraleの枠
        public double fRightVX { get; set; }    //FullScraleの枠
        public double fTopVY { get; set; }      //FullScraleの枠
        public double fBottomVY { get; set; }   //FullScraleの枠

        public double fEndVX { get; set; }	    //FullScraleの枠
        public double fStartVX { get; set; }	//FullScraleの枠
    }
}
