/*-----------------------------------------------------------------------------
//  FILE NAME       : CastPipe.cs
//  FUNCTION        : 管道处理类
//  AUTHOR          : 李锋(2009/02/23)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;

namespace ChromatoTool.pipe
{
    /// <summary>
    /// 管道处理类
    /// </summary>
    public class CastPipe
    {
        
        # region 常数
        
        public const string PipeName = "robinTest";
        public const string ServeName = ".";
        public const string _fullPipeName = "\\\\" + ServeName + "\\pipe\\" + PipeName;//管道全名
        
        #endregion


        # region 变量

        /// <summary>
        /// 管道名全称
        /// </summary>
        public string _pipeFullName { get; set; }

        /// <summary>
        /// 管道句柄
        /// </summary>
        public IntPtr _hPipe { get; set; }

        #endregion


        # region 构造

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public CastPipe()
        {
            _hPipe = (IntPtr)NamedPipeNative.INVALID_HANDLE_VALUE;
            _pipeFullName = "\\\\.\\pipe\\Graphocx";
        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="name"></param>
        public CastPipe(string name)
        {

            _hPipe = (IntPtr)NamedPipeNative.INVALID_HANDLE_VALUE;
            _pipeFullName = "\\\\.\\" + "pipe" + "\\" + name;
        }
        
        #endregion


        # region 析构

        /// <summary>
        /// 析构函数
        /// </summary>
        ~CastPipe()
        {

            this.Dispose();
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            //lock (this)
            //{
                if (_hPipe != (IntPtr)NamedPipeNative.INVALID_HANDLE_VALUE)
                {
                    NamedPipeNative.DisconnectNamedPipe(this._hPipe);
                    NamedPipeNative.CloseHandle(_hPipe);
                    this._hPipe = (IntPtr)NamedPipeNative.INVALID_HANDLE_VALUE;

                    Console.Out.WriteLine(
                        String.Format("close named handle, name:{0}, handle:{1}",this._pipeFullName,this._hPipe));
                }
            //}
        }

        #endregion


        #region 管道操作

        /// <summary>
        /// 创建管道 
        /// </summary>
        public void CreatePipe()
        {
            //_hPipe = NTKernel.CreateNamedPipe(PipeUri, (uint)FileAccess.PIPE_ACCESS_DUPLEX,
            //                    (uint)PipeMode.PIPE_READMODE_MESSAGE | (uint)PipeMode.PIPE_TYPE_MESSAGE | (uint)PipeMode.PIPE_WAIT,
            //                    NTKernel.PIPE_UNLIMITED_INSTANCES,
            //                    m_BufferSize,
            //                    m_BufferSize,
            //                    NMPWAIT_USE_DEFAULT_WAIT,
            //                    new SecurityAttributes());

            _hPipe = NamedPipeNative.CreateNamedPipe(_pipeFullName,
                            NamedPipeNative.PIPE_ACCESS_DUPLEX,         // 数据双工通信
                            NamedPipeNative.PIPE_TYPE_MESSAGE | NamedPipeNative.PIPE_WAIT,
                            100,                         // 最大实例个数
                            128,                           // 流出数据缓冲大小
                            128,                           // 流入数据缓冲大小
                            150,                         // 超时，毫秒
                            IntPtr.Zero                  // 安全信息
                            );

            if (_hPipe.ToInt32() == NamedPipeNative.INVALID_HANDLE_VALUE)
            {
                Console.Out.WriteLine(String.Format("CreatePipe name:{0} handle:{1} 失败", _pipeFullName, _hPipe));
                return;
            }

            Console.Out.WriteLine(String.Format("CreatePipe name:{0} handle:{1} 成功", _pipeFullName, _hPipe));
        }

        /// <summary>
        /// 写字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool WriteString(string str)
        {
            byte[] Val = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] dwBytesWrite = new byte[4];
            int len = Val.Length;
            byte[] lenBytes = System.BitConverter.GetBytes(len);

            if (NamedPipeNative.WriteFile(_hPipe, lenBytes, 4, dwBytesWrite, 0))
            {
                return (NamedPipeNative.WriteFile(_hPipe, Val, (uint)len, dwBytesWrite, 0));
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 写整数
        /// </summary>
        /// <param name="iValueCount"></param>
        public void WriteInt(int iValueCount)
        {
            byte[] dwBytesWrite = new byte[4];
            byte[] val = System.BitConverter.GetBytes(iValueCount);
            bool ret = NamedPipeNative.WriteFile(_hPipe, val, 4, dwBytesWrite, 0);
        }

        /// <summary>
        /// 写浮点数
        /// </summary>
        /// <param name="p"></param>
        public void WriteFloat(float p)
        {
            byte[] dwBytesWrite = new byte[4];
            byte[] val = System.BitConverter.GetBytes(p);
            bool ret = NamedPipeNative.WriteFile(_hPipe, val, 4, dwBytesWrite, 0);
        }

        #endregion


        #region 未使用

        /// <summary>
        /// 读取曲线数据
        /// </summary>
        public void ReadCurveData()
        {

            //int nCurvesToRead = 0;
            //nCurvesToRead = ReadInt(this._hPipe);//先读取需要读取的曲线条数,如
            //this._curveDataList.Clear();

            //for (int j = 1; j <= nCurvesToRead; j++)
            //{
            //    Single ftime = this.ReadFloat(this._hPipe);
            //    PointInfoDto dtoPointInfo = new PointInfoDto();
            //    dtoPointInfo.time = ftime;
            //    dtoPointInfo.value = readData;


            //    int nCount = 0;
            //    nCount = ReadInt(this._hPipe);//读取该曲线的数据总数（数组大小）
            //    Single[] readData = new Single[nCount];

            //    for (int i = 0; i < nCount; i++)
            //    {
            //        readData[i] = ReadFloat(this._hPipe);//顺序读取曲线的数据
            //    }


            //    this._curveDataList.Add(dtoPointInfo);
            //}
        }

        /// <summary>
        /// 读取文本信息
        /// </summary>
        public void ReadTextInfo()
        {
            //读取该曲线名称
            string textInfo = ReadString(this._hPipe);
            Console.Out.WriteLine(textInfo + Environment.NewLine);
            Console.Out.WriteLine(Environment.NewLine);
        }

        /// <summary>
        /// 读数据
        /// </summary>
        public void ReadData()
        {

            //read data

            int flag = -1;
            flag = ReadInt(this._hPipe);//获取当前要读取的数据的信息

            if (flag == 0)//flag==0表示读取曲线数据
            {
                ReadCurveData();
            }

            else if (flag == 1)//flag==1表示读取文本信息
            {
                ReadTextInfo();
            }
        }

        /// <summary>
        /// 读字符串
        /// </summary>
        /// <param name="HPipe"></param>
        /// <returns></returns>
        public string ReadString(IntPtr HPipe)
        {
            string Val = "";
            byte[] bytes = ReadBytes(HPipe);
            if (bytes != null)
            {
                Val = System.Text.Encoding.UTF8.GetString(bytes);
            }
            return Val;
        }

        /// <summary>
        /// 读字节数组
        /// </summary>
        /// <param name="HPipe"></param>
        /// <returns></returns>
        public byte[] ReadBytes(IntPtr HPipe)
        {

            //传字节流

            byte[] szMsg = null;

            byte[] dwBytesRead = new byte[4];

            byte[] lenBytes = new byte[4];

            int len;

            if (NamedPipeNative.ReadFile(HPipe, lenBytes, 4, dwBytesRead, 0))//先读大小
            {

                len = System.BitConverter.ToInt32(lenBytes, 0);

                szMsg = new byte[len];

                if (!NamedPipeNative.ReadFile(HPipe, szMsg, (uint)len, dwBytesRead, 0))
                {

                    //Console.Out.WriteLine("读取数据失败");
                    return null;
                }
            }

            return szMsg;
        }

        /// <summary>
        /// 读单精度小数
        /// </summary>
        /// <param name="HPipe"></param>
        /// <returns></returns>
        public float ReadFloat(IntPtr HPipe)
        {

            float Val = 0;
            byte[] bytes = new byte[4]; //单精度需4个字节存储
            byte[] dwBytesRead = new byte[4];

            if (!NamedPipeNative.ReadFile(HPipe, bytes, 4, dwBytesRead, 0))
            {

                Console.Out.WriteLine("读取数据失败");
                return 0;
            }

            Val = System.BitConverter.ToSingle(bytes, 0);

            return Val;

        }

        /// <summary>
        /// 读双精度小数
        /// </summary>
        /// <param name="HPipe"></param>
        /// <returns></returns>
        public double ReadDouble(IntPtr HPipe)
        {

            double Val = 0;
            byte[] bytes = new byte[8]; //双精度需8个字节存储
            byte[] dwBytesRead = new byte[4];


            if (!NamedPipeNative.ReadFile(HPipe, bytes, 8, dwBytesRead, 0))
            {

                Console.Out.WriteLine("读取数据失败");
                return 0;
            }

            Val = System.BitConverter.ToDouble(bytes, 0);

            return Val;

        }

        /// <summary>
        /// 读整数
        /// </summary>
        /// <param name="HPipe"></param>
        /// <returns></returns>
        public int ReadInt(IntPtr HPipe)
        {

            int Val = 0;
            byte[] bytes = new byte[4]; //整型需4个字节存储
            byte[] dwBytesRead = new byte[4];


            if (!NamedPipeNative.ReadFile(HPipe, bytes, 4, dwBytesRead, 0))
            {

                Console.Out.WriteLine("读取数据失败");

                return 0;

            }

            Val = System.BitConverter.ToInt32(bytes, 0);

            return Val;

        }
        
        #endregion


    }
}
