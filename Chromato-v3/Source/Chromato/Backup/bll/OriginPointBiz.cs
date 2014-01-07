/*-----------------------------------------------------------------------------
//  FILE NAME       : OriginPointBiz.cs
//  FUNCTION        : 原始数据表的逻辑
//  AUTHOR          : 李锋(2009/07/14)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoBll.dao;
using ChromatoTool.ini;
using System.Windows.Forms;
using ChromatoTool.log;
using System.Collections;
using System.Data;
using System.IO;
using ChromatoTool.dto;

namespace ChromatoBll.bll
{

    /// <summary>
    /// 原始数据表的逻辑
    /// </summary>
    public class OriginPointBiz
    {

        
        #region 变量

        /// <summary>
        /// 参数Dao
        /// </summary>
        private OriginPointDao _daoOriPoint = null;

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
        public OriginPointBiz()
        {
            this._daoOriPoint = new OriginPointDao();
        }

        #endregion

        
        #region 访问数据库

        /// <summary>
        /// 加载数据文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool OpenDataDb(String path, ArrayList arr)
        {
            //内存已经存在该文件
            if (null != _dbRelativePath && _dbRelativePath.Equals(path))
            {
                return false;
            }

            this._dbRelativePath = path;

            String temp = null;
            int lastindex = Application.ExecutablePath.LastIndexOf('\\');

            //绝对路径 = @"g:\first.s3db";
            this._dbAbsolutPath = Application.ExecutablePath.Substring(0, lastindex + 1) + path;

            if (!File.Exists(this._dbAbsolutPath))
            {
                temp = String.Format("文件不存在:{0}", this._dbAbsolutPath);
                MessageBox.Show(temp, "打开文件");
                CastLog.Logger("ParaBiz", "打开文件", temp);
                arr.Clear();
                return false;
            }

            OriginPointDao daoOriPoint = new OriginPointDao();
            daoOriPoint.LoadOriginalData(path, arr);

            return true;
        }

        /// <summary>
        /// 加载数据文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public OpenDbResult OpenDb(String path, ArrayList arr)
        {
            //内存已经存在该文件
            if (null != _dbRelativePath && _dbRelativePath.Equals(path))
            {
                ;// return OpenDbResult.AlreadyOpened;
            }

            this._dbRelativePath = path;

            String temp = null;
            int lastindex = Application.ExecutablePath.LastIndexOf('\\');

            //绝对路径 = @"g:\first.s3db";
            this._dbAbsolutPath = Application.ExecutablePath.Substring(0, lastindex + 1) + path;

            if (!File.Exists(this._dbAbsolutPath))
            {
                temp = String.Format("文件不存在:{0}", this._dbAbsolutPath);
                MessageBox.Show(temp, "打开文件");
                CastLog.Logger("ParaBiz", "打开文件", temp);
                arr.Clear();
                return OpenDbResult.NotExist;
            }

            OriginPointDao daoOriPoint = new OriginPointDao();
            DataSet ds = daoOriPoint.LoadOriData(path, arr);

            if (0 == arr.Count)
            {
                return OpenDbResult.NoData;
            }
            return OpenDbResult.Succeed;
        }

        /// <summary>
        /// 扣除基线处理
        /// </summary>
        /// <param name="arrOri"></param>
        /// <param name="arrDeducted"></param>
        public void DealDeducted(ArrayList arrOri, ArrayList arrDeducted)
        {
            OriginPointDto dtoOri = null;
            OriginPointDto dtoDeducted = null;

            if (null == arrOri || 0 == arrOri.Count)
            {
                return;
            }
            if (null == arrDeducted || 0 == arrDeducted.Count)
            {
                return;
            }

            //做减法
            for (int i = 0; i < arrOri.Count; i++)
            {
                dtoOri = (OriginPointDto)arrOri[i];
                if (i >= arrDeducted.Count)
                {
                    break;
                }
                dtoDeducted = (OriginPointDto)arrDeducted[i];
                dtoOri.Voltage -= dtoDeducted.Voltage;
            }
        }

        #endregion



    }
}
