/*-----------------------------------------------------------------------------
//  FILE NAME       : TimeProcBiz.cs
//  FUNCTION        : 时间程序的逻辑
//  AUTHOR          : 李锋(2009/05/20)
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
    /// 时间程序的逻辑
    /// </summary>
    public class TimeProcBiz
    {

        #region 变量

        /// <summary>
        /// 参数Dao
        /// </summary>
        private TimeProcDao daoTimeProc = null;

        /// <summary>
        /// 编辑和新建时需要保存的时间程序dto
        /// </summary>
        private ArrayList _arr = null;

        #endregion


        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public TimeProcBiz()
        {
            this.daoTimeProc = new TimeProcDao();
            this._arr = new ArrayList();
        }

        #endregion


        #region 访问DAO

        /// <summary>
        /// 选择全部时间程序
        /// </summary>
        /// <returns></returns>
        public ArrayList LoadTimeProc()
        {
            TimeProcDao dao = new TimeProcDao();
            DataSet ds = daoTimeProc.LoadTimeProc();

            if (null == ds || null == ds.Tables[0])
            {
                return null;
            }

            ArrayList arr = new ArrayList();
            TimeProcDto dto = null;

            //追加到列表
            if (null != ds && 0 < ds.Tables[0].Rows.Count)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dto = new TimeProcDto();
                    dto.TPid = Convert.ToInt32(ds.Tables[0].Rows[i]["TPid"].ToString());
                    dto.TPName = ds.Tables[0].Rows[i]["TPName"].ToString();
                    arr.Add(dto);
                }
            }
            return arr;
        }

        /// <summary>
        /// 选择全部时间程序
        /// </summary>
        /// <returns></returns>
        public DataSet LoadMethodName()
        {
            return this.daoTimeProc.LoadTimeProc();
        }
        
        /// <summary>
        /// 选择全部时间程序
        /// </summary>
        /// <returns></returns>
        public DataSet LoadTimeProcByID(TimeProcDto dto)
        {

            DataSet ds = this.daoTimeProc.LoadTimeProcByID(dto);

            if (null == ds || null == ds.Tables[0])
            {
                return null;
            }

            TimeProcDto dtoTp = null;

            //追加到列表
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dtoTp = new TimeProcDto();
                dtoTp.TPid = Convert.ToInt32(ds.Tables[0].Rows[i]["TPid"].ToString());
                dtoTp.TPName = ds.Tables[0].Rows[i]["TPName"].ToString();
                dtoTp.SerialID = Convert.ToInt32(ds.Tables[0].Rows[i]["SerialID"].ToString());
                dtoTp.ActionName = ds.Tables[0].Rows[i]["ActionName"].ToString();
                dtoTp.StartTime = Convert.ToSingle(ds.Tables[0].Rows[i]["StartTime"].ToString());
                dtoTp.StopTime = Convert.ToSingle(ds.Tables[0].Rows[i]["StopTime"].ToString());
                dtoTp.IsCmd = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsCmd"].ToString());
                dtoTp.TpValue = Convert.ToInt32(ds.Tables[0].Rows[i]["TpValue"].ToString());
                this._arr.Add(dtoTp);
            }

            return ds;
        }

        /// <summary>
        /// 取得新的时间程序ID
        /// </summary>
        /// <returns></returns>
        public int GetNewTimeProcID()
        {
            return this.daoTimeProc.GetNewTimeProcID();
        }

        /// <summary>
        /// 取得新的序列号ID
        /// </summary>
        /// <returns></returns>
        public int GetNewSerialID(TimeProcDto dto)
        {
            return this.daoTimeProc.GetNewSerialID(dto);
        }

        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="dto"></param>
        public void DeleteSerial(TimeProcDto dto)
        {
            this.daoTimeProc.DeleteSerial(dto);
        }

        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="dto"></param>
        public void DeleteTimeProc(TimeProcDto dto)
        {
            this.daoTimeProc.DeleteTimeProc(dto);
        }

        /// <summary>
        /// 更新时间程序到对应的数据库
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateTimeProc(TimeProcDto dto)
        {
            this.daoTimeProc.UpdateTimeProc(dto);
        }

        /// <summary>
        /// 插入时间程序信息
        /// </summary>
        /// <returns></returns>
        public void InsertMethod(TimeProcDto dto)
        {
            dto.TPid = this.daoTimeProc.GetNewTimeProcID();
            this.daoTimeProc.InsertTimeProc(dto);
        }

        /// <summary>
        /// 更新时间程序名到对应的数据库
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateTPName(TimeProcDto dto)
        {
            this.daoTimeProc.UpdateTPName(dto);
        }

        /// <summary>
        /// 更新方法
        /// </summary>
        /// <param name="dtoTimeProc"></param>
        public void UpdateMethod(TimeProcDto dtoTimeProc)
        {
            //先删除
            this.DeleteTimeProc(dtoTimeProc);

            //再插入
            this.InsertArray();
        }

        /// <summary>
        /// 插入队列中的方法
        /// </summary>
        public void InsertArray()
        {
            TimeProcDto dto = null;
            for (int i = 0; i < this._arr.Count; i++)
            {
                dto = (TimeProcDto)this._arr[i];
                this.daoTimeProc.InsertTimeProc(dto);
            }
        }
        
        #endregion


        #region 内存访问逻辑

        /// <summary>
        /// 更新列表
        /// </summary>
        /// <param name="dtoTimeProc"></param>
        public void UpdateArray(TimeProcDto dtoTimeProc)
        {
            TimeProcDto dto = null;
            for (int i = 0; i < this._arr.Count; i++)
            {
                dto = (TimeProcDto)this._arr[i];

                //更新时间程序名称
                dto.TPName = dtoTimeProc.TPName;

                if (dto.TPid == dtoTimeProc.TPid && dto.SerialID == dtoTimeProc.SerialID)
                {
                    dto.ActionName = dtoTimeProc.ActionName;
                    dto.IsCmd = dtoTimeProc.IsCmd;
                    dto.StartTime = dtoTimeProc.StartTime;
                    dto.StopTime = dtoTimeProc.StopTime;
                    dto.TPName = dtoTimeProc.TPName;
                    dto.TpValue = dtoTimeProc.TpValue;
                }
            }
        }

        /// <summary>
        /// 在列表中计算新的ID
        /// </summary>
        public int GetNewSerialIdInArray(TimeProcDto dtoTimeProc)
        {
            TimeProcDto dto = null;

            //计算ID
            int serialID = 0;
            for (int i = 0; i < this._arr.Count; i++)
            {
                dto = (TimeProcDto)this._arr[i];

                //更新时间程序名称
                dto.TPName = dtoTimeProc.TPName;

                if (serialID <= dto.SerialID)
                {
                    serialID = dto.SerialID;
                }
            }
            serialID++;
            return serialID;
        }
   
        /// <summary>
        /// 插入列表
        /// </summary>
        /// <param name="dto"></param>
        public void InsertToArray(TimeProcDto dto)
        {
            TimeProcDto newDto = new TimeProcDto();
            newDto.TPid = dto.TPid;
            newDto.TPName = dto.TPName;
            newDto.SerialID = dto.SerialID;
            newDto.ActionName = dto.ActionName;
            newDto.IsCmd = dto.IsCmd;
            newDto.StartTime = dto.StartTime;
            newDto.StopTime = dto.StopTime;
            newDto.TpValue = dto.TpValue;
            this._arr.Add(newDto);
        }

        /// <summary>
        /// 删除列表中dto
        /// </summary>
        /// <param name="dtoTimeProc"></param>
        public void RemoveSerial(TimeProcDto dtoTimeProc)
        {
            TimeProcDto dto = null;
            for (int i = 0; i < this._arr.Count; i++)
            {
                dto = (TimeProcDto)this._arr[i];
                if (dto.TPid == dtoTimeProc.TPid && dto.SerialID == dtoTimeProc.SerialID)
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
        public ArrayList GetTpArray()
        {
            return this._arr;
        }

        #endregion




    }
}
