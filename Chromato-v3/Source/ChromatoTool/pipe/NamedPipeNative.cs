/*-----------------------------------------------------------------------------
//  FILE NAME       : NamedPipeNative.cs
//  FUNCTION        : 命名管道
//  AUTHOR          : 李锋(2009/02/23)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Security.Permissions;



namespace ChromatoTool.pipe
{
    /// <summary>
    /// 命名管道API封装类
    /// </summary>
    public class NamedPipeNative
    {

        #region 常量

        /// <summary>
        /// 无效句柄
        /// </summary>
        public const int INVALID_HANDLE_VALUE = -1;

        /// <summary>
        /// 数据双工通信
        /// </summary>
        public const uint PIPE_ACCESS_DUPLEX = 0x00000003;
        /// <summary>
        /// 接收数据
        /// </summary>
        public const uint PIPE_ACCESS_INBOUND = 0x00000001;
        /// <summary>
        /// 发送数据
        /// </summary>
        public const uint PIPE_ACCESS_OUTBOUND = 0x00000002;

        /// <summary>
        /// 字节类型
        /// </summary>
        public const uint PIPE_TYPE_BYTE = 0x00000000;
        /// <summary>
        /// 消息类型
        /// </summary>
        public const uint PIPE_TYPE_MESSAGE = 0x00000004;

        /// <summary>
        /// 等待
        /// </summary>
        public const uint PIPE_WAIT = 0x00000000;
        /// <summary>
        /// 不等待
        /// </summary>
        public const uint PIPE_NOWAIT = 0x00000001;

        /// <summary>
        /// 连接超时错误代码
        /// </summary>
        public const uint ERROR_PIPE_CONNECTED = 200;

        /// <summary>
        /// 无数据错误代码
        /// </summary>
        public const uint ERROR_NO_DATA = 300;
        
        #endregion


        #region 引入声明

        /// <summary>
        /// 创建命名管道
        /// </summary>
        /// <param name="lpName"></param>
        /// <param name="dwOpenMode"></param>
        /// <param name="dwPipeMode"></param>
        /// <param name="nMaxInstances"></param>
        /// <param name="nOutBufferSize"></param>
        /// <param name="nInBufferSize"></param>
        /// <param name="nDefaultTimeOut"></param>
        /// <param name="pipeSecurityDescriptor"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern IntPtr CreateNamedPipe
        (

            String lpName,                                          // pipe name
            uint dwOpenMode,                                   // pipe open mode
            uint dwPipeMode,                                   // pipe-specific modes
            uint nMaxInstances,                                // maximum number of instances
            uint nOutBufferSize,                           // output buffer size
            uint nInBufferSize,                                // input buffer size
            uint nDefaultTimeOut,                          // time-out interval
            IntPtr pipeSecurityDescriptor        // SD
        );

 
        /// <summary>
        /// 连接命名管道
        /// </summary>
        /// <param name="hHandle"></param>
        /// <param name="lpOverlapped"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern bool ConnectNamedPipe
        (

            IntPtr hHandle,                                         // handle to named pipe
            Overlapped lpOverlapped                   // overlapped structure
        );

         
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <param name="dwDesiredAccess"></param>
        /// <param name="dwShareMode"></param>
        /// <param name="attr"></param>
        /// <param name="dwCreationDisposition"></param>
        /// <param name="dwFlagsAndAttributes"></param>
        /// <param name="hTemplateFile"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern IntPtr CreateFile
        (
            String lpFileName,                          // file name
            uint dwDesiredAccess,                       // access mode
            uint dwShareMode,                                  // share mode
            SecurityAttribute attr,                  // SD
            uint dwCreationDisposition,          // how to create
            uint dwFlagsAndAttributes,           // file attributes
            uint hTemplateFile                      // handle to template file
        );
 
        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="hHandle"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="nNumberOfBytesToRead"></param>
        /// <param name="lpNumberOfBytesRead"></param>
        /// <param name="lpOverlapped"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern bool ReadFile
        (
            IntPtr hHandle,    // handle to file
            byte[] lpBuffer,// data buffer字节流
            uint nNumberOfBytesToRead,// number of bytes to read
            byte[] lpNumberOfBytesRead,// number of bytes read
            uint lpOverlapped// overlapped buffer
        );

 
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="hHandle"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="nNumberOfBytesToWrite"></param>
        /// <param name="lpNumberOfBytesWritten"></param>
        /// <param name="lpOverlapped"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern bool WriteFile
        (

            IntPtr hHandle,    // handle to file
            byte[] lpBuffer,// data buffer字节流
            uint nNumberOfBytesToWrite, // number of bytes to write
            byte[] lpNumberOfBytesWritten,   // number of bytes written
            uint lpOverlapped // overlapped buffer
        );

        /// <summary>
        /// 断开命名管道
        /// </summary>
        /// <param name="hHandle"></param>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void DisconnectNamedPipe
        (
            IntPtr hHandle
        );

        /// <summary>
        /// 关闭句柄
        /// </summary>
        /// <param name="hHandle"></param>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void CloseHandle(IntPtr hHandle);

        /// <summary>
        /// 获取错误代码
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();


        #endregion

    }
}


