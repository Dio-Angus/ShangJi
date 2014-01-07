/*-----------------------------------------------------------------------------
//  FILE NAME       : PeakBiz.cs
//  FUNCTION        : 峰的结果逻辑
//  AUTHOR          : 李锋(2009/04/17)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Data;
using ChromatoBll.dao;
using System.Collections;
using ChromatoTool.dto;
using System.IO;
using ChromatoTool.log;
using System.Windows.Forms;
using ChromatoTool.ini;

namespace ChromatoBll.bll
{
    /// <summary>
    /// 峰的结果逻辑
    /// </summary>
    public class PeakBiz
    {

        #region 变量

        /// <summary>
        /// 数据库相对路径
        /// </summary>
        public String _dbRelativePath { get; set; }

        /// <summary>
        /// 数据库绝对路径
        /// </summary>
        private String _dbAbsolutPath { get; set; }

        #endregion


        #region 构造
        
        /// <summary>
        /// 构造
        /// </summary>
        public PeakBiz()
        {

        }

        #endregion


        #region 方法

        /// <summary>
        /// 计算峰
        /// </summary>
        public void CacuPeak()
        {
        }

        /// <summary>
        /// 装载结果
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public DataSet LoadResult(string path)
        {
            PeakDao daoPeak = new PeakDao();
            return daoPeak.LoadPeakResult(path);
        }

        /// <summary>
        /// 根据路径装载结果
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public DataSet LoadPrintPeakResult(string path)
        {
            PeakDao daoPeak = new PeakDao();
            return daoPeak.LoadPrintPeakResult(path);
        }

        /// <summary>
        /// 根据路径装载结果
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public DataSet LoadPrintPeakResultWithSum(string path)
        {
            PeakDao daoPeak = new PeakDao();
            DataSet ds = daoPeak.LoadPrintPeakResult(path);

            if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
            {
                return ds;
            }

            // 浓度 总和
            Single sum = 0;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sum += Convert.ToSingle(dr[(int)PrintItem.Density].ToString());
            }

            DataRow drNew = ds.Tables[0].NewRow();
            drNew["浓度"] = sum.ToString();
            ds.Tables[0].Rows.Add(drNew);

            return ds;

        }

        /// <summary>
        /// 删除一条峰的结果
        /// </summary>
        /// <param name="path"></param>
        /// <param name="peakID"></param>
        public bool DeletePeak(string path, int peakID)
        {
            PeakDao daoPeak = new PeakDao();
            return daoPeak.DeletePeak(path,peakID);
        }

        /// <summary>
        /// 结果表中追加一个峰
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddPeak(string path, PeakDto dto)
        {
            PeakDao daoPeak = new PeakDao();
            return daoPeak.AddPeak(path, dto);
        }

        /// <summary>
        /// 结果表中更新一个峰
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdatePeak(string path, PeakDto dto)
        {
            PeakDao daoPeak = new PeakDao();
            return daoPeak.UpdatePeak(path, dto);
        }


        /// <summary>
        /// 把输入的样品列表转化为成分集合
        /// </summary>
        /// <param name="arr">样品列表</param>
        /// <param name="dtoIngre">ID表ID等信息</param>
        /// <param name="dsIngre">成分集合</param>
        /// <param name="arrResult">结果列表</param>
        /// <returns></returns>
        public bool ConvertToIngre(ArrayList arr, IngredientDto dtoIngre, ref DataSet dsIngre, ArrayList arrResult)
        {

            DataSet ds = null;
            arrResult.Clear();

            //根据路径取出每个样品的结果，放入列表
            if (0 == arr.Count)
            {
                return true;
            }

            foreach (ParaDto dtoPara in arr)
            {
                ds = this.LoadResult(dtoPara.PathData);

                if (null == ds || null == ds.Tables[0] || 0 == ds.Tables[0].Rows.Count)
                {
                    MessageBox.Show(String.Format("样品：{0} 通道{1}，没有计算出成分！", 
                        dtoPara.SampleName,dtoPara.ChannelID), "警告");
                    return false;
                }

                ds.Tables[0].Columns.Add("SampleWeight");
                foreach (DataRow dRow in ds.Tables[0].Rows)
                {
                    dRow["SampleWeight"] = dtoPara.SampleWeight;
                }
                arrResult.Add(ds.Tables[0]);
            }

            //检查各个样品的结果，检查峰的个数是否相同
            int peakCount = ((DataTable)arrResult[0]).Rows.Count;
            for( int i = 1; i < arrResult.Count; i++ )
            {
                if (peakCount != ((DataTable)arrResult[i]).Rows.Count)
                {
                    MessageBox.Show("峰的个数不同！", "警告");
                    return false;
                }
            }

            //从集合中取出所有的峰，放入成分列表
            DataRow dr = null;
            int count = dsIngre.Tables[0].Rows.Count;
            int peakId = count;
            foreach (DataRow drPeak in ((DataTable)arrResult[0]).Rows) 
            {
                peakId++;
                dr = dsIngre.Tables[0].NewRow();

                dr["IDTableID"] = dtoIngre.IDTableID;
                dr["IDTableName"] = dtoIngre.IDTableName;
                dr["IngredientID"] = peakId.ToString();
                dr["IngredientName"] = drPeak["PeakName"].ToString();
                dr["TimeBand"] = DefaultIdTable.TimeBand;
                dr["IsInnerPeak"] = false;
                dr["ReserveTime"] = this.GetAvgReserveTime(arrResult, (peakId - count));

                dsIngre.Tables[0].Rows.Add(dr);
            }

            return true;
        }

        /// <summary>
        /// 根据多点校准结果，计算保留时间的平均值
        /// </summary>
        /// <param name="arrResult"></param>
        /// <param name="peakId"></param>
        /// <returns></returns>
        private Single GetAvgReserveTime(ArrayList arrResult, int peakId)
        {
            DataRow drPeak = null;
            Single reserveTime = 0;
 
            foreach (DataTable dt in arrResult)
            {
                drPeak = dt.Rows[peakId - 1];
                reserveTime += Convert.ToSingle(String.Format("{0:F4}", drPeak["ReserveTime"].ToString()));
            }

            reserveTime /= arrResult.Count;
            return reserveTime;
        }

        /// <summary>
        /// 把输入的结果列表转化成含量列表
        /// </summary>
        /// <param name="arrResult">结果列表</param>
        /// <param name="dtoIngre">ID表ID等信息</param>
        /// <param name="arrCali">含量列表</param>
        /// <param name="startPeakCount"></param>
        /// <returns></returns>
        public bool ConvertToCali(ArrayList arrResult, IngredientDto dtoIngre, ArrayList arrCali, int startPeakCount)
        {
            CalibrateDto dtoCali = null;
            String temp = "";
            int caliCount = 0;
            int peakCount = startPeakCount;

            foreach (DataTable dt in arrResult)
            {
                caliCount++;
                peakCount = startPeakCount;
                foreach (DataRow drPeak in dt.Rows)
                {
                    peakCount++;
                    dtoCali = new CalibrateDto();

                    //取得ID表ID
                    dtoCali.IDTableID = dtoIngre.IDTableID;

                    //取得成分ID
                    dtoCali.IngredientID = peakCount;

                    //取得含量ID
                    dtoCali.CalibrateID = caliCount;

                    //取得浓度
                    temp = drPeak["Density"].ToString();
                    if (!String.IsNullOrEmpty(temp))
                    {
                        dtoCali.Density = Convert.ToSingle(temp);
                    }

                    //取得高度
                    temp = drPeak["PeakHeight"].ToString();
                    if (!String.IsNullOrEmpty(temp))
                    {
                        dtoCali.PeakHeight = Convert.ToSingle(temp);
                    }

                    //取得面积
                    temp = drPeak["AreaSize"].ToString();
                    if (!String.IsNullOrEmpty(temp))
                    {
                        dtoCali.PeakSize = Convert.ToSingle(temp);
                    }

                    //取得样品量
                    temp = drPeak["SampleWeight"].ToString();
                    if (!String.IsNullOrEmpty(temp))
                    {
                        dtoCali.SampleWeight = Convert.ToInt32(temp);
                    }

                    dtoCali.FactorOne = Convert.ToSingle(1);
                    dtoCali.FactorTwo = Convert.ToSingle(0);
                    arrCali.Add(dtoCali);
                }

            }

            return true;
        }

        /// <summary>
        /// 插入数据到数据文件,真实数据用
        /// </summary>
        public bool AppendToDb(string path, ArrayList arr, int count)
        {

            this._dbRelativePath = path;

            String temp = null;
            int lastindex = System.Windows.Forms.Application.ExecutablePath.LastIndexOf('\\');

            //绝对路径 = @"g:\first.s3db";
            this._dbAbsolutPath = System.Windows.Forms.Application.ExecutablePath.Substring(0, lastindex + 1) + path;
            if (!File.Exists(this._dbAbsolutPath))
            {
                temp = String.Format("文件不存在:{0}", this._dbAbsolutPath);
                MessageBox.Show(temp, "打开文件");
                CastLog.Logger("ParaBiz", "打开文件", temp);
                arr.Clear();
                return false;
            }

            PeakDao daoPeak = new PeakDao();
            daoPeak.AppendToDb(path, arr, count);
            return true;
        }

        #endregion


    }
}
