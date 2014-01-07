/*-----------------------------------------------------------------------------
//  FILE NAME       : IngredientBiz.cs
//  FUNCTION        : 成分表的逻辑
//  AUTHOR          : 李锋(2009/05/15)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoBll.dao;
using System.Data;
using ChromatoTool.dto;
using System.Collections;

namespace ChromatoBll.bll
{
    /// <summary>
    /// 成分表的逻辑
    /// </summary>
    public class IngredientBiz
    {

        #region 变量

        /// <summary>
        /// 参数Dao
        /// </summary>
        private IngredientDao daoIngredient = null;

        /// <summary>
        /// 编辑和新建时需要保存的成分表dto
        /// </summary>
        private ArrayList _arr = null;

        #endregion

        
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public IngredientBiz()
        {
            this.daoIngredient = new IngredientDao();
            this._arr = new ArrayList();
        }

        #endregion


        #region 访问DAO

        /// <summary>
        /// 查询成分表
        /// </summary>
        /// <returns></returns>
        public ArrayList LoadIdentity()
        {
            IngredientDao dao = new IngredientDao();
            DataSet ds = daoIngredient.LoadIdentity();

            if (null == ds || null == ds.Tables[0])
            {
                return null;
            }

            ArrayList arr = new ArrayList();
            IngredientDto dto = null;

            //追加到列表
            if (null != ds && 0 < ds.Tables[0].Rows.Count)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dto = new IngredientDto();
                    dto.IDTableID = Convert.ToInt32(ds.Tables[0].Rows[i]["IDTableID"].ToString());
                    dto.IDTableName = ds.Tables[0].Rows[i]["IDTableName"].ToString();
                    arr.Add(dto);
                }
            }
            return arr;
        }

        /// <summary>
        /// 查询成分表
        /// </summary>
        /// <returns></returns>
        public DataSet LoadMethodName()
        {
            return this.daoIngredient.LoadIdentity();
        }

        /// <summary>
        /// 通过ID表ID查询该成分的详细
        /// </summary>
        /// <param name="idTableID"></param>
        /// <returns></returns>
        public DataSet LoadIngredientByID(int idTableID)
        {
            DataSet ds = this.daoIngredient.LoadIngredientByIdTableID( idTableID );
            this.ResetArray(ds);
            return ds;
        }

        /// <summary>
        /// 取得新的ID表ID
        /// </summary>
        /// <returns></returns>
        public int GetNewIdentityID()
        {
            return this.daoIngredient.GetNewIdentityID();
        }

        /// <summary>
        /// 删除ID表
        /// </summary>
        /// <param name="dto"></param>
        public void DeleteIngredient(IngredientDto dto)
        {
            this.daoIngredient.DeleteIdentity(dto);
        }

        /// <summary>
        /// 更新ID表方法
        /// </summary>
        /// <param name="dtoIngre"></param>
        public void UpdateMethod(IngredientDto dtoIngre)
        {
            //先删除
            this.DeleteIngredient(dtoIngre);

            //再插入
            this.InsertArray();
        }

        /// <summary>
        /// 插入新方法到数据库
        /// </summary>
        public void InsertArray()
        {
            IngredientDto dto = null;
            for (int i = 0; i < this._arr.Count; i++)
            {
                dto = (IngredientDto)this._arr[i];
                this.daoIngredient.InsertIngredient(dto);
            }
        }

        #endregion


        #region 内存访问逻辑

        /// <summary>
        /// 清空队列
        /// </summary>
        public void ResetArray(DataSet ds)
        {
            this._arr.Clear();

            IngredientDto dtoIngre = null;

            //追加到列表
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dtoIngre = new IngredientDto();
                dtoIngre.IDTableID = Convert.ToInt32(ds.Tables[0].Rows[i]["IDTableID"].ToString());
                dtoIngre.IDTableName = ds.Tables[0].Rows[i]["IDTableName"].ToString();
                dtoIngre.IngredientID = Convert.ToInt32(ds.Tables[0].Rows[i]["IngredientID"].ToString());
                dtoIngre.IngredientName = ds.Tables[0].Rows[i]["IngredientName"].ToString();
                dtoIngre.IsInnerPeak = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsInnerPeak"].ToString());
                dtoIngre.ReserveTime = Convert.ToSingle(ds.Tables[0].Rows[i]["ReserveTime"].ToString());
                dtoIngre.TimeBand = Convert.ToSingle(ds.Tables[0].Rows[i]["TimeBand"].ToString());
                this._arr.Add(dtoIngre);
            }
        }

        /// <summary>
        /// 更新列表
        /// </summary>
        /// <param name="dtoIngre"></param>
        public void UpdateArray(IngredientDto dtoIngre)
        {
            IngredientDto dto = null;
            for (int i = 0; i < this._arr.Count; i++)
            {
                dto = (IngredientDto)this._arr[i];

                //更新ID表名称
                dto.IDTableName = dtoIngre.IDTableName;

                if (dto.IDTableID == dtoIngre.IDTableID && dto.IngredientID == dtoIngre.IngredientID)
                {
                    dto.IngredientName = dtoIngre.IngredientName;
                    dto.IsInnerPeak = dtoIngre.IsInnerPeak;
                    dto.ReserveTime = dtoIngre.ReserveTime;
                    dto.TimeBand = dtoIngre.TimeBand;
                    dto.IDTableName = dtoIngre.IDTableName;
                }
            }
        }

        /// <summary>
        /// 在列表中计算新的ID
        /// </summary>
        /// <param name="dtoIngredient"></param>
        /// <returns></returns>
        public int GetNewIngredientIdInArray(IngredientDto dtoIngredient)
        {
            IngredientDto dto = null;

            //计算ID
            int ingreID = 0;
            for (int i = 0; i < this._arr.Count; i++)
            {
                dto = (IngredientDto)this._arr[i];

                //更新ID表名称
                dto.IDTableName = dtoIngredient.IDTableName;

                if (ingreID <= dto.IngredientID)
                {
                    ingreID = dto.IngredientID;
                }
            }
            ingreID++;
            return ingreID;
        }

        /// <summary>
        /// 插入列表
        /// </summary>
        /// <param name="dto"></param>
        public void InsertToArray(IngredientDto dto)
        {
            IngredientDto newDto = new IngredientDto();
            newDto.IDTableID = dto.IDTableID;
            newDto.IngredientID = dto.IngredientID;
            newDto.IngredientName = dto.IngredientName;
            newDto.IsInnerPeak = dto.IsInnerPeak;
            newDto.ReserveTime = dto.ReserveTime;
            newDto.TimeBand = dto.TimeBand;
            newDto.IDTableName = dto.IDTableName;
            this._arr.Add(newDto);
        }

        /// <summary>
        /// 删除列表中dto
        /// </summary>
        /// <param name="dtoIngredient"></param>
        public void RemoveInArray(IngredientDto dtoIngredient)
        {
            IngredientDto dto = null;
            for (int i = 0; i < this._arr.Count; i++)
            {
                dto = (IngredientDto)this._arr[i];
                if (dto.IDTableID == dtoIngredient.IDTableID &&
                    dto.IngredientID == dtoIngredient.IngredientID)
                {
                    this._arr.Remove(dto);
                    break;
                }
            }
        }

        /// <summary>
        /// 取得列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetIngreArry()
        {
            return this._arr;
        }

        /// <summary>
        /// 清空列表
        /// </summary>
        public void ClearArray()
        {
            this._arr.Clear();
        }

        #endregion




    }
}
