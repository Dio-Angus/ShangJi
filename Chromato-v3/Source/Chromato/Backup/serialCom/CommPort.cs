/*-----------------------------------------------------------------------------
//  FILE NAME       : CommPort.cs
//  FUNCTION        : 串口封装类
//  AUTHOR          : 李锋(2009/03/20)
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using ChromatoTool.ini;


namespace ChromatoBll.serialCom
{

    /// <summary>
    /// 串口封装类 
    /// </summary>
    public sealed class CommPort
    {

        #region 变量

        /// <summary>
        /// 串口通讯对象
        /// </summary>
        private CommBase _Comm = null;

        #endregion


        #region 初期

        /// <summary>
        /// 实例名
        /// </summary>
        private static readonly CommPort instance = new CommPort();

        /// <summary>
        /// 唯一实例
        /// </summary>
        public static CommBase Instance
        {
            get
            {
                return instance._Comm;
            }
        }

        /// <summary>
        /// 构造
        /// </summary>
        public CommPort()
        {
            switch (General.ObjectLink)
            {
                case General.LinkObject.SmallBoard:
                case General.LinkObject.SimuGc:
                    this._Comm = (CommBase)new Comm2000();
                    break;
                case General.LinkObject.BigBoard:
                    this._Comm = (CommBase)new Comm3010();
                    break;
                case General.LinkObject.ChannelGas:
                case General.LinkObject.AutoChromatoGas:
                    this._Comm = (CommBase)new CommGas();
                    break;
                    //this._Comm = (CommBase)new CommGasAuto();
                    //break;
            }
        }

        #endregion
    }
}