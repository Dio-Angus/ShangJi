/*-----------------------------------------------------------------------------
//  FILE NAME       : AvgPointBiz.cs
//  FUNCTION        : 数据平均后表的逻辑
//  AUTHOR          : 李锋(2009/07/14)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using ChromatoBll.dao;
using System.Collections;
using ChromatoTool.log;
using System.IO;
using System.Windows.Forms;
using ChromatoTool.ini;
using System.Data;

namespace ChromatoBll.bll
{
    /// <summary>
    /// 数据平均后表的逻辑
    /// </summary>
    public class AvgPointBiz
    {

        #region 变量

        /// <summary>
        /// 参数Dao
        /// </summary>
        private AvgPointDao daoAvgPoint = null;

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
        public AvgPointBiz()
        {
            this.daoAvgPoint = new AvgPointDao();
        }

        #endregion


        #region 访问数据库

        /// <summary>
        /// 加载数据文件
        /// </summary>
        /// <param name="path">数据库路径</param>
        /// <param name="arr">数据队列</param>
        /// <param name="ds">数据集合</param>
        /// <returns>成功失败</returns>
        public OpenDbResult OpenDataDb(String path, ArrayList arr, ref DataSet ds)
        {
            //内存已经存在该文件
            if (null != _dbRelativePath && _dbRelativePath.Equals(path))
            {
                return OpenDbResult.AlreadyOpened;
            }

            this._dbRelativePath = path;

            String temp = null;
            int lastindex = System.Windows.Forms.Application.ExecutablePath.LastIndexOf('\\');

            //绝对路径 = @"g:\first.s3db";
            this._dbAbsolutPath = System.Windows.Forms.Application.ExecutablePath.Substring(0, lastindex + 1) + path;

            if (!File.Exists(this._dbAbsolutPath))
            {
                temp = String.Format("文件不存在:{0}", this._dbAbsolutPath);
                //MessageBox.Show(temp, "打开文件");
                CastLog.Logger("ParaBiz", "打开文件", temp);
                arr.Clear();
                return OpenDbResult.NotExist;
            }

            AvgPointDao daoAvgPoint = new AvgPointDao();
            ds = daoAvgPoint.LoadAvgData(path, arr);

            if (0 == arr.Count)
            {
                return OpenDbResult.NoData;
            }
            return OpenDbResult.Succeed;
        }

        /// <summary>
        /// 插入数据到数据文件,真实数据用
        /// </summary>
        /// <param name="path">数据库路径</param>
        /// <param name="arr">数据队列</param>
        /// <param name="count">数据总数</param>
        /// <returns>成功失败</returns>
        public bool AppendToDb(string path, ArrayList arr, int count)
        {
            //内存已经存在该文件
            if (null != _dbRelativePath && _dbRelativePath.Equals(path))
            {
                ;// return false;
            }

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

            AvgPointDao daoAvg = new AvgPointDao();
            daoAvg.AppendToDb(path, arr, count);
            return true;
        }

        /// <summary>
        /// 加载数据文件
        /// </summary>
        /// <param name="path">数据库路径</param>
        /// <param name="arr">数据队列</param>
        /// <returns>成功失败</returns>
        public OpenDbResult OpenDataDb(String path, ArrayList arr)
        {

            this._dbRelativePath = path;

            String temp = null;
            int lastindex = System.Windows.Forms.Application.ExecutablePath.LastIndexOf('\\');

            //绝对路径 = @"g:\first.s3db";
            this._dbAbsolutPath = System.Windows.Forms.Application.ExecutablePath.Substring(0, lastindex + 1) + path;

            if (!File.Exists(this._dbAbsolutPath))
            {
                temp = String.Format("文件不存在:{0}", this._dbAbsolutPath);
                //MessageBox.Show(temp, "打开文件");
                CastLog.Logger("ParaBiz", "打开文件", temp);
                arr.Clear();
                return OpenDbResult.NotExist;
            }

            AvgPointDao daoAvgPoint = new AvgPointDao();
            daoAvgPoint.LoadAvgData(path, arr);

            if (0 == arr.Count)
            {
                return OpenDbResult.NoData;
            }
            return OpenDbResult.Succeed;
        }

        /// <summary>
        /// 加载数据文件
        /// </summary>
        /// <param name="path">数据库路径</param>
        /// <param name="arr">数据队列</param>
        /// <returns>成功失败</returns>
        public OpenDbResult LoadAvgForExport(String path, ArrayList arr)
        {
            String temp = null;
            int lastindex = System.Windows.Forms.Application.ExecutablePath.LastIndexOf('\\');

            //绝对路径 = @"g:\first.s3db";
            this._dbAbsolutPath = System.Windows.Forms.Application.ExecutablePath.Substring(0, lastindex + 1) + path;

            if (!File.Exists(this._dbAbsolutPath))
            {
                temp = String.Format("文件不存在:{0}", this._dbAbsolutPath);
                //MessageBox.Show(temp, "打开文件");
                CastLog.Logger("ParaBiz", "打开文件", temp);
                arr.Clear();
                return OpenDbResult.NotExist;
            }

            AvgPointDao daoAvgPoint = new AvgPointDao();
            DataSet ds = daoAvgPoint.LoadAvgForExport(path, arr);

            if (0 == arr.Count)
            {
                return OpenDbResult.NoData;
            }
            return OpenDbResult.Succeed;
        }

        #endregion

    }
}
