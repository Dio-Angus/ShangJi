/*-----------------------------------------------------------------------------
//  FILE NAME       : AttriDto.cs
//  FUNCTION        : 属性
//  AUTHOR          : 李锋(2009/03//03)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/


namespace ChromatoTool.dto
{
    /// <summary>
    /// 属性Dto
    /// </summary>
    public class AttriDto
    {
        public short id { get; set; }
        public int startX { get; set; }	    //begin X position of Attri
        public int startY { get; set; }        //begin Y position of Attri
        public int startRight { get; set; }	//begin X right of Attri
        public int startBottom { get; set; }   //begin Y Bottom of Attri
        public int mouseX { get; set; }	    //begin mouse X position of Attri
        public int mouseY { get; set; }	    //begin mouse Y position of Attri
    }
}
