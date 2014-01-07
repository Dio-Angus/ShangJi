/*-----------------------------------------------------------------------------
//  FILE NAME       : CompareBiz.cs
//  FUNCTION        : 图比较的逻辑
//  AUTHOR          : 李锋(2009/07/28)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoBll.dao;
using System.Data;
using System.Collections;
using ChromatoTool.dto;
using ChromatoTool.ini;

namespace ChromatoBll.bll
{
    /// <summary>
    /// 图比较的逻辑
    /// </summary>
    public class CompareBiz
    {
        
        #region 变量

        /// <summary>
        /// 参数Dao
        /// </summary>
        private CompareDao _daoCompare = null;

        /// <summary>
        /// 编辑和新建时需要保存的比较表dto
        /// </summary>
        private ArrayList _arr = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public CompareBiz()
        {
            this._daoCompare = new CompareDao();
            this._arr = new ArrayList();
        }

        #endregion


        #region 访问DAO

        /// <summary>
        /// 选择比较表
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCompare()
        {
            DataSet ds = this._daoCompare.LoadCompare();

            if (null == ds || null == ds.Tables[0])
            {
                return null;
            }

            this._arr = new ArrayList();
            CompareDto dto = null;

            //追加到列表
            if (null != ds && 0 < ds.Tables[0].Rows.Count)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dto = new CompareDto();
                    dto.SampleID = ds.Tables[0].Rows[i]["SampleID"].ToString();
                    dto.ForeColor = Convert.ToInt32(ds.Tables[0].Rows[i]["ForeColor"].ToString());
                    dto.SampleName = ds.Tables[0].Rows[i]["SampleName"].ToString();
                    dto.PathData = ds.Tables[0].Rows[i]["PathData"].ToString();
                    dto.CollectTime = ds.Tables[0].Rows[i]["CollectTime"].ToString(); 
                    dto.IsShow = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsShow"].ToString());
                    this._arr.Add(dto);
                }
            }
            return ds;
        }

        /// <summary>
        /// 更新比较表
        /// </summary>
        public void UpdateCompare(CompareDto dto)
        {
            this._daoCompare.UpdateCompare(dto);
            foreach (CompareDto dtoCompare in this._arr)
            {
                if (dtoCompare.SampleID.Equals(dto.SampleID) && dtoCompare.CollectTime.Equals(dto.CollectTime))
                {
                    dtoCompare.ForeColor = dto.ForeColor;
                    dto.id = dtoCompare.id;
                    dto.PathData = dtoCompare.PathData;
                    dto.SampleName = dtoCompare.SampleName;
                    dto.IsShow = dtoCompare.IsShow;
                    break;
                }
            }
        }

        /// <summary>
        /// 更新比较表
        /// </summary>
        public void UpdateShow(CompareDto dto)
        {
            foreach (CompareDto dtoCompare in this._arr)
            {
                if (dtoCompare.SampleID.Equals(dto.SampleID) && dtoCompare.CollectTime.Equals(dto.CollectTime))
                {
                    dtoCompare.IsShow = !dtoCompare.IsShow;
                    dto.id = dtoCompare.id;
                    dto.IsShow = dtoCompare.IsShow;
                    this.UpdateCompare(dto);
                    break;
                }
            }
        }

        /// <summary>
        /// 删除比较表中数据
        /// </summary>
        /// <param name="dto"></param>
        public void DeleteCompare(CompareDto dto)
        {
            this._daoCompare.DeleteCompare(dto);
            foreach (CompareDto dtoCompare in this._arr)
            {
                if (dtoCompare.SampleID.Equals(dto.SampleID) && dtoCompare.CollectTime.Equals(dto.CollectTime))
                {
                    dto.id = dtoCompare.id;
                    dto.PathData = dtoCompare.PathData;
                    dto.SampleName = dtoCompare.SampleName;
                    this._arr.Remove(dtoCompare);
                    break;
                }
            }
        }

        /// <summary>
        /// 追加一条到比较表
        /// </summary>
        public bool InsertToArr(CompareDto dto)
        {
            int result = 0;
            Math.DivRem(this._arr.Count, DefaultColor.MaxColor, out result);
            dto.ForeColor = Setting.ColorDefault.ForeColor[result];
            foreach (CompareDto dtoCompare in this._arr)
            {
                if (dtoCompare.SampleID.Equals(dto.SampleID) && dtoCompare.CollectTime.Equals(dto.CollectTime))
                {
                    return false;
                }
            }
            this._arr.Add(dto);
            this._daoCompare.InsertCompare(dto);
            return true;
        }

        /// <summary>
        /// 取得列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetCompareArr()
        {
            return this._arr;
        }

        #endregion

    }
}
