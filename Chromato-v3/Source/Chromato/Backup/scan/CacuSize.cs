/*-----------------------------------------------------------------------------
//  FILE NAME       : CacuSize.cs
//  FUNCTION        : 计算峰的面积,高度
//  AUTHOR          : 谢玲(2009/07/06)
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
    /// 计算峰的面积,高度
    /// </summary>
    class CacuSize
    {


        #region 变量

        /// <summary>
        /// 数据集合 AvgPointDto 集合体
        /// 结果 PeakDto 集合体
        /// </summary>
        private ArrayList _arrPeak { get; set; }

        /// <summary>
        ///  平均 AvgPointDto 集合体
        /// </summary>
        private ArrayList _arr { get; set; }

        /// <summary>
        /// 峰值分组列表
        /// 结果 PeakDto 集合体
        /// 双重ArrayList嵌套
        /// </summary>
        private ArrayList _arrGroup { get; set; }

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public CacuSize(ArrayList avg, ArrayList arrGroup, ArrayList result)
        {
            this._arr = avg;
            this._arrGroup = arrGroup;
            this._arrPeak = result;
            //this.getAreaOfTW();

        }
       
        #endregion


        #region 计算面积,峰高

        /// <summary>
        /// 计算各个峰的面积，有拖尾的情况下减去拖尾峰的面积
        /// </summary>
        /// <param name="isAdd">是否重新向队列追加</param>
        public void Cacu(bool isAdd)
        {
            int nCount = 1;

            //取出各个组
            foreach (ArrayList arr in this._arrGroup)
            {
                foreach (PeakDto dto in arr)
                {
                    dto.PeakID = nCount++;
                }
                this.CacuHeight(arr);
                this.CacuArea(arr);
            }

            //新追加
            if (isAdd)
            {
                this._arrPeak.Clear();
                foreach (ArrayList arr in this._arrGroup)
                {
                    foreach (PeakDto dto in arr)
                    {
                        this._arrPeak.Add(dto);
                    }
                }
            }
        }

        /// <summary>
        /// 计算某个分组内的各个峰高
        /// </summary>
        /// <param name="arr"></param>
        private void CacuHeight(ArrayList arr)
        {
            AvgPointDto dtoAvgTop = null;
            
            //截距
            Single b = 0;
            //斜率
            Single k = 0;
            //保留时间对应于闭合线上的高度
            Single reserveTimeY = 0;

            foreach (PeakDto dto in arr)
            {
                // 封闭线斜率
                k = (dto.EndVoltage - dto.StartVoltage) / (dto.EndMoment - dto.StartMoment);
                
                // y = k * x + b => b = y - k * x
                b = dto.StartVoltage - k * dto.StartMoment;

                //最高点
                dtoAvgTop = (AvgPointDto)_arr[dto.TopPointIndex];
                reserveTimeY = k * dto.ReserveTime + b;

                //峰高 = 顶点的电压 - 闭合线高度 , 保留4位小数
                dto.PeakHeight = Convert.ToSingle(Math.Round(Math.Abs(dtoAvgTop.Voltage - reserveTimeY) * 1000, 1));
            }
        }

        /// <summary>
        /// 计算某个分组内的各个峰面积
        /// </summary>
        /// <param name="arr"></param>
        private void CacuArea(ArrayList arr)
        {
            //截距
            Single b = 0;
            //斜率
            Single k = 0;
            //面积
            Single sumArea = 0;
            //某点电压
            Single y = 0;
            //某点
            AvgPointDto dtoAvg = null;
            //某点
            AvgPointDto dtoAvg1 = null;

            foreach (PeakDto dto in arr)
            {

                //封闭线斜率
                k = (dto.EndVoltage - dto.StartVoltage) / (dto.EndMoment - dto.StartMoment);
                //封闭线截距
                b = dto.StartVoltage - k * dto.StartMoment;
                //面积
                sumArea = 0;

                for (int i = dto.StartPointCloseIndex; i < dto.EndPointCloseIndex; i++)
                {
                    dtoAvg1 = (AvgPointDto)_arr[i];

                    //根据开始点的下一点获得此点的其他信息
                    dtoAvg = (AvgPointDto)_arr[i + 1];

                    //封闭线起点的下一点
                    y = k * dtoAvg.Moment + b;

                    //各个矩形面积之和
                    sumArea += Convert.ToSingle((Math.Abs(y - dtoAvg.Voltage) * (dtoAvg.Moment - dtoAvg1.Moment)));
                }
                dto.AreaSize = sumArea * DefaultItem.uVol * DefaultItem.SecondsPerMin;
            }

            //存在拖尾峰
            PeakDto dtoCurrent = null;

            int currentIndex = 0;
            while( currentIndex < arr.Count )
            {
                dtoCurrent = (PeakDto)arr[currentIndex];

                //拖尾峰
                if (TypeOfPeak.Tail.Equals(dtoCurrent.PeakType))
                {
                    this.SubstractTail(ref currentIndex, arr);
                }
                currentIndex++;
            }
        }

        /// <summary>
        /// 拖尾峰依赖的主峰或者重叠峰面积修正
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <param name="arr"></param>
        private void SubstractTail(ref int currentIndex, ArrayList arr)
        {
            PeakDto dtoBefore = (PeakDto)arr[currentIndex - 1];
            PeakDto dtoCurrent = null;

            while (currentIndex < arr.Count)
            {
                dtoCurrent = (PeakDto)arr[currentIndex];
                if (TypeOfPeak.Tail.Equals(dtoCurrent.PeakType))
                {
                    dtoBefore.AreaSize -= dtoCurrent.AreaSize;
                    currentIndex++;
                }
                else
                {
                    break;
                }
            }
        }

        #endregion 

    }
}
