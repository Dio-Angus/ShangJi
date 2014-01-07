/*-----------------------------------------------------------------------------
//  FILE NAME       : AutoGroup.cs
//  FUNCTION        : 对峰进行自动分组
//  AUTHOR          : 蔡海鹰(2009/08/21)
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
    /// 对峰进行自动分组
    /// </summary>
    class AutoGroup
    {

        #region 常量

        /// <summary>
        /// 漂移等于0时的组间隔（峰宽的倍数）
        /// </summary>
        private const double GroupDistance = 1.5;

        /// <summary>
        /// 漂移不等于0时的组间隔（峰宽的倍数）
        /// </summary>
        private const Single GroupDistanceWithDrift = 3;

        #endregion


        #region 变量

        /// <summary>
        ///  平均 AvgPointDto 集合体
        /// </summary>
        private ArrayList _arrAvg { get; set; }

        /// <summary>
        ///  结果 PeakDto 集合体,输入列表
        /// </summary>
        private ArrayList _arrPeak { get; set; }

        /// <summary>
        /// 峰外层分组列表，结果 PeakDto 集合体，ArrayList嵌套
        /// </summary>
        public ArrayList _arrGroup { get; set; }

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public AutoGroup(ArrayList avg, ArrayList result)
        {
            this._arrAvg = avg;
            this._arrPeak = result;
            this._arrGroup = new ArrayList();
        }
        
        #endregion


        #region 方法

        /// <summary>
        /// 分割组
        /// </summary>
        /// <returns></returns>
        public bool Divide()
        {
            //峰分组步骤
            GroupStep step = GroupStep.Start;
            ArrayList arr = new ArrayList();

            foreach (PeakDto dto in this._arrPeak)
            {
                switch (step)
                {
                    case GroupStep.Start:
                        dto.GroupID = this._arrGroup.Count + 1;
                        arr.Add(dto);
                        step = GroupStep.Mid;
                        break;

                    case GroupStep.Mid:

                        //属于该组
                        if (this.IsInnerGroup((PeakDto)arr[arr.Count - 1], dto,(PeakDto)arr[0]))
                        {
                            dto.GroupID = this._arrGroup.Count + 1;
                            arr.Add(dto);
                        }
                        else
                        {
                            //不属于该组
                            this._arrGroup.Add(arr);
                            arr = new ArrayList();
                            arr.Add(dto);
                            dto.GroupID = this._arrGroup.Count + 1;
                            step = GroupStep.Mid;
                        }
                        break;

                }
            }

            //把没有找到组结束的峰加入到最后一组
            if (0 < arr.Count)
            {
                this._arrGroup.Add(arr);
            }

            return true;
        }

        /// <summary>
        /// 该峰是否属于这组,true属于该组
        /// </summary>
        /// <param name="dtoBefore"></param>
        /// <param name="dtoAfter"></param>
        /// <param name="dtoFirst"></param>
        /// <returns></returns>
        private bool IsInnerGroup(PeakDto dto1, PeakDto dto2, PeakDto dtoFirst)
        {

            bool bRet = true;
            Single k = 0;
            AvgPointDto dtoLastEnd = (AvgPointDto)this._arrAvg[dto1.EndPointIndex];
            AvgPointDto dtoCurrentStart = (AvgPointDto)this._arrAvg[dto2.StartPointIndex];

            AvgPointDto dtoFirstStart = (AvgPointDto)this._arrAvg[dtoFirst.StartPointIndex];
            AvgPointDto dtoCurrentEnd = (AvgPointDto)this._arrAvg[dto2.EndPointIndex];

            //漂移等于0
            if (0 == dtoLastEnd.Drift)
            {
                //1.5倍峰宽
                if (GroupDistance * dtoLastEnd.PeakWide <= (dtoCurrentStart.Index - dtoLastEnd.Index))
                {
                    bRet = false;
                }
            }
            //漂移大于0
            else if (0 < dtoLastEnd.Drift)
            {
                //取得斜率
                k = GeneralCacu.GetSlope(dtoFirstStart, dtoCurrentEnd);

                //大于开始点漂移
                bRet = (k > dtoFirstStart.Drift) ? true : false;

                //3倍峰宽
                if (GroupDistanceWithDrift * dtoLastEnd.PeakWide <= (dtoCurrentStart.Index - dtoLastEnd.Index))
                {
                    bRet = false;
                }
            }
            return bRet;
        }

        #endregion


    }
}
