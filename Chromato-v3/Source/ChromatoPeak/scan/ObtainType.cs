/*-----------------------------------------------------------------------------
//  FILE NAME       : ObtainType.cs
//  FUNCTION        : 判断峰的类型
//  AUTHOR          : 蔡海鹰(2009/08/24)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Collections;
using ChromatoTool.dto;
using ChromatoTool.ini;

namespace ChromatoPeak.scan
{
    /// <summary>
    /// 判断峰的类型
    /// </summary>
    class ObtainType
    {

        #region 常量

        /// <summary>
        /// 峰高最大值(mv)
        /// </summary>
        private const Int32 MaxPeakHeight = 1200;

        /// <summary>
        /// 峰高最小值(mv)
        /// </summary>
        private const Int32 MinPeakHeight = -5;

        /// <summary>
        /// 主峰最小的峰高倍数
        /// </summary>
        private const Single MinHeightTimes = 10;

        /// <summary>
        /// 主峰最大的峰高倍数
        /// </summary>
        private const Single MaxHeightTimes = 100;

        #endregion


        #region 变量

        /// <summary>
        ///  平均 AvgPointDto 集合体
        /// </summary>
        private ArrayList _arrAvg { get; set; }

        /// <summary>
        /// 峰外层分组列表，结果 PeakDto 集合体，ArrayList嵌套
        /// </summary>
        private ArrayList _arrGroup { get; set; }

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public ObtainType(ArrayList avg, ArrayList group)
        {
            this._arrAvg = avg;
            this._arrGroup = group;
        }
        
        #endregion


        #region 方法

        /// <summary>
        /// 获取峰类型
        /// </summary>
        public void Obtain()
        {

            foreach (ArrayList arr in this._arrGroup)
            {
                foreach (PeakDto dto in arr)
                {
                    //设置缺省积分开始,结束索引
                    dto.StartPointCloseIndex = dto.StartPointIndex;
                    dto.EndPointCloseIndex = dto.EndPointIndex;
                }
                this.IsTail(arr);
            }
        }

        /// <summary>
        /// 判断是否为脱尾峰
        /// </summary>
        /// <param name="arr"></param>
        private void IsTail(ArrayList arr)
        {
            PeakDto peakMain = (PeakDto)arr[0];
            peakMain.PeakType = TypeOfPeak.Main;

            int currentIndex = 0;
            PeakDto peakBefore = peakMain;
            PeakDto peakCurrent = null;


            while (currentIndex < (arr.Count - 1))
            {
                //当前峰
                currentIndex++;
                peakCurrent = (PeakDto)arr[currentIndex];

                //如果手动脱尾
                if (peakCurrent.IsManualTail)
                {
                    peakCurrent.PeakType = TypeOfPeak.Tail;
                    peakBefore.EndPointCloseIndex = peakCurrent.EndPointIndex;
                    continue;
                }

                //自动确定脱尾
                if (!this.IsAttachTail(peakBefore, peakCurrent))
                {
                    //不是拖尾，前峰增加
                    peakBefore = (PeakDto)arr[currentIndex];
                }
            }
        }

        /// <summary>
        /// 是否是拖尾峰
        /// </summary>
        /// <param name="peakMain"></param>
        /// <param name="peakCurrent"></param>
        /// <returns></returns>
        private bool IsAttachTail(PeakDto peakMain, PeakDto peakCurrent)
        {
            AvgPointDto dtoMainStart = null;
            AvgPointDto dtoMainTop = null;
            AvgPointDto dtoMainEnd = null;
            AvgPointDto dtoAttatchTop = null;

            bool bCon1 = false;
            bool bCon2 = false;
            bool bCon3 = false;
            bool bRet = false;

            dtoMainStart = (AvgPointDto)this._arrAvg[peakMain.StartPointIndex];
            dtoMainTop = (AvgPointDto)this._arrAvg[peakMain.TopPointIndex];
            dtoMainEnd = (AvgPointDto)this._arrAvg[peakMain.EndPointIndex];
            dtoAttatchTop = (AvgPointDto)this._arrAvg[peakCurrent.TopPointIndex];

            //峰的间隔
            bool bPeakDistance = (1 < (peakCurrent.PeakID - peakMain.PeakID)) ? false : true;

            //条件1
            bCon1 = (dtoMainTop.Voltage - dtoMainStart.Voltage) >
                ((dtoMainEnd.Voltage - dtoMainStart.Voltage) * MinHeightTimes) ? true : false;

            //条件2
            bCon2 = (dtoAttatchTop.Voltage - dtoMainStart.Voltage) <
                ((dtoMainEnd.Voltage - dtoMainStart.Voltage) * MaxHeightTimes) ? true : false;

            //条件3
            bCon3 = (dtoMainEnd.Moment - dtoMainTop.Moment) >
                ((dtoAttatchTop.Moment - dtoMainEnd.Moment) * 3.0) ? true : false;

            if (bPeakDistance)
            {
                if (bCon1 && bCon2 && bCon3)
                {
                    //三个条件成立，为拖尾峰
                    peakCurrent.PeakType = TypeOfPeak.Tail;
                    peakMain.EndPointCloseIndex = peakCurrent.EndPointIndex;

                    bRet = true;
                }
                else
                {
                    //三个条件不全成立，为重叠峰
                    peakCurrent.PeakType = TypeOfPeak.Overlap;

                    bRet = false;
                }
            }
            else
            {
                if (bCon1)
                {
                    //第一个条件成立，即为拖尾峰
                    peakCurrent.PeakType = TypeOfPeak.Tail;
                    peakMain.EndPointCloseIndex = peakCurrent.EndPointIndex;

                    bRet = true;
                }
                else
                {
                    //否则，为重叠峰
                    peakCurrent.PeakType = TypeOfPeak.Overlap;

                    bRet = false;
                }
            }

            return bRet;
        }

        #endregion

    }
}
