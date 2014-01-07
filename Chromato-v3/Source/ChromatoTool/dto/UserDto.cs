/*-----------------------------------------------------------------------------
//  FILE NAME       : UserDto.cs
//  FUNCTION        : 用户表
//  AUTHOR          : 李锋(2009/04/30)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.dto
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserDto
    {

        /// <summary>
        /// 用户名
        /// </summary>
        public String UserID { get; set; }
        
        /// <summary>
        /// 中文名
        /// </summary>
        public String ChineseName { get; set; }
        
        /// <summary>
        /// 密码
        /// </summary>
        public String Password { get; set; }

    }
}
