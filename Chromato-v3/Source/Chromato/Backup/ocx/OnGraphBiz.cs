/*-----------------------------------------------------------------------------
//  FILE NAME       : OnGraphBiz.cs
//  FUNCTION        : 用于采集的图形逻辑
//  AUTHOR          : 李锋(2009/05/19)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using ChromatoTool.dto;
using AxGRAPHOCXLib;
using ChromatoTool.ini;
using ChromatoTool.pipe;
using ChromatoBll.ocx.biz;
using System;
using ChromatoBll.bll;
using ChromatoBll.serialCom;
using ChromatoBll.bto;

namespace ChromatoBll.ocx
{
    /// <summary>
    /// 用于采集的图形逻辑
    /// </summary>
    public class OnGraphBiz
    {


        #region 常量

        /// <summary>
        /// 缩放整个长度的倍数
        /// </summary>
        private const Single ZoomTimes = 10;

        #endregion


        #region 变量

        /// <summary>
        /// A,B,C,D通道显示层
        /// </summary>
        private LayerBto[] _dtoRealLayer = new LayerBto[CommConst.REAL_CHANNEL_COUNT];

        /// <summary>
        /// A,B,C,D通道实时采集样品参数dto
        /// </summary>
        private ParaDto[] _dtoPara = new ParaDto[CommConst.REAL_CHANNEL_COUNT];

        /// <summary>
        /// A,B,C,D通道采集参数dto
        /// </summary>
        private CollectionDto[] _dtoCollection = new CollectionDto[CommConst.REAL_CHANNEL_COUNT];

        /// <summary>
        /// 采集逻辑
        /// </summary>
        private CollectionBiz _bizCol = null;

        #endregion


        #region A,B,C,D通道属性

        /// <summary>
        /// 模拟传输逻辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TransSimuBiz _bizTransSimu(ChannelID id)
        {
            return (TransSimuBiz)_dtoRealLayer[(int)id]._bizTransSimu;
        }

        /// <summary>
        /// 实时传输逻辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private TransRealBiz _bizTransReal(ChannelID id)
        {
            return (TransRealBiz)_dtoRealLayer[(int)id]._bizTrans;
        }

        /// <summary>
        /// 控件大小改变逻辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResizeBiz _bizResize(ChannelID id)
        {
            return _dtoRealLayer[(int)id]._bizResize;
        }

        /// <summary>
        /// 图形放大缩小逻辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ZoomPlotBiz _bizZoom(ChannelID id)
        {
            return _dtoRealLayer[(int)id]._bizZoom;
        }

        /// <summary>
        /// 十字光标逻辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ArrowLineBiz _bizArrow(ChannelID id)
        {
            return _dtoRealLayer[(int)id]._bizArrow;
        }

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OnGraphBiz()
        {
            for (int i = 0; i < CommConst.REAL_CHANNEL_COUNT; i++)
            {
                this._dtoCollection[i] = new CollectionDto();
            }

            this._bizCol = new CollectionBiz();
        }

        #endregion


        #region 方法

        /// <summary>
        /// 创建显示层
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <param name="ocx"></param>
        /// <param name="pipe"></param>
        public void CreateLayer(ChannelID id, UserType user, AxGraphOcx ocx, CastPipe pipe)
        {
            this._dtoRealLayer[(int)id] = new LayerBto(id, user, ocx, pipe);
            CommPort.Instance.SetTransBiz(id, this._bizTransReal(id));
            this._bizTransReal(id)._idChannel = id;
        }

        /// <summary>
        /// 启动采集模拟数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dtoPara"></param>
        public void StartSimu(ChannelID id, ParaDto dtoPara)
        {

            this._dtoRealLayer[(int)id]._plot.DataCount = 0;
            this._bizArrow(id).UnvisibleArrow();

            this.InitPara(ref this._dtoPara[(int)id], dtoPara);
            this._bizTransSimu(id).CreateDb(this._dtoPara[(int)id]);

            this.GetCollection(ChannelID.A);
            this._bizResize(id).UpdateMinY(this._dtoCollection[(int)id].ShowMinY);
            this._bizResize(id).UpdateMaxY(this._dtoCollection[(int)id].ShowMaxY);
            this._bizTransSimu(id)._isSaveToDb = true;
            this._bizTransSimu(id).CloseSimuThread();

            this._bizTransSimu(id)._idChannel = id;
            this._bizTransSimu(id).StartSimuThread(this._dtoCollection[(int)id]);
            this._dtoPara[(int)id].SampleStatus = StatusSample.Collecting;
            CommPort.Instance.SetRealStatus(id, RealStatus.SimuCollecting);

        }

        /// <summary>
        /// 停止采集模拟数据
        /// </summary>
        /// <param name="id"></param>
        public void StopSimu(ChannelID id)
        {
            CommPort.Instance.SetRealStatus(id, RealStatus.ManulStop);
            this._bizTransSimu(id).CloseSimuThread();
            this._bizTransSimu(id).UpdatePara(this._dtoPara[(int)id]);
            CommPort.Instance.SetRealStatus(id, RealStatus.Ready);
        }

        /// <summary>
        /// 走基线
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dtoPara"></param>
        public void RunBaseSimu(ChannelID id, ParaDto dtoPara)
        {
            if (RealStatus.Ready == CommPort.Instance.GetRealStatus(id))
            {
                this._dtoRealLayer[(int)id]._plot.DataCount = 0;
                this._bizArrow(id).UnvisibleArrow();

                this._dtoPara[(int)id] = dtoPara;
                this.GetCollection(id);
                this._bizResize(id).UpdateMinY(this._dtoCollection[(int)id].ShowMinY);
                this._bizResize(id).UpdateMaxY(this._dtoCollection[(int)id].ShowMaxY);

                this._bizTransSimu(id)._isSaveToDb = false;
                this._bizTransSimu(id)._idChannel = id;
                this._bizTransSimu(id).StartSimuThread(this._dtoCollection[(int)id]);
                CommPort.Instance.SetRealStatus(id, RealStatus.RunBase);
            } 
        }

        /// <summary>
        /// 启动采集真实数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dtoPara"></param>
        public void StartReal(ChannelID id, ParaDto dtoPara)
        {

            if (CommPort.Instance.OpenLoop())
            {
                this.InitPara(ref this._dtoPara[(int)id], dtoPara);
                CommPort.Instance.SetRealStatus(id, RealStatus.ManulStart);

                this.GetCollection(id);
                this._bizResize(id).UpdateMinY(this._dtoCollection[(int)id].ShowMinY);
                this._bizResize(id).UpdateMaxY(this._dtoCollection[(int)id].ShowMaxY);

                //记忆放大缩小初期范围
                this._bizZoom(id).SetFullGObj();
                
                //清空数据
                this._bizTransReal(id).Reset(this._dtoPara[(int)id], this._dtoCollection[(int)id]);
                CommPort.Instance.SetRealStatus(id, RealStatus.RealCollecting);

                //发送启动指令
                switch (General.ObjectLink)
                {
                    case General.LinkObject.BigBoard:
                        HardBiz.Instance.StartGc();
                        break;
                }
            }
        }

        /// <summary>
        /// 把界面层传递来的样品信息保存为本地成员
        /// </summary>
        /// <param name="dtoLocal"></param>
        /// <param name="dtoOri"></param>
        private void InitPara(ref ParaDto dtoLocal, ParaDto dtoOri)
        {
            dtoLocal = new ParaDto();
            dtoLocal.ChannelID = dtoOri.ChannelID;
            dtoLocal.CollectTime = dtoOri.CollectTime;
            dtoLocal.InnerWeight = dtoOri.InnerWeight;
            dtoLocal.PathData = dtoOri.PathData;
            dtoLocal.RegisterTime = dtoOri.RegisterTime;
            dtoLocal.Remark = dtoOri.Remark;
            dtoLocal.SampleID = dtoOri.SampleID;
            dtoLocal.SampleName = dtoOri.SampleName;
            dtoLocal.SampleStatus = dtoOri.SampleStatus;
            dtoLocal.SampleType = dtoOri.SampleType;
            dtoLocal.SampleWeight = dtoOri.SampleWeight;
            dtoLocal.StopTime = dtoOri.StopTime;

        }

        /// <summary>
        /// 停止采集真实数据
        /// </summary>
        /// <param name="id"></param>
        public void StopReal(ChannelID id)
        {
            CommPort.Instance.SetRealStatus(id, RealStatus.ManulStop);
            this._bizTransReal(id).UpdatePara(this._dtoPara[(int)id]);

            //发送停止指令
            switch (General.ObjectLink)
            {
                case General.LinkObject.BigBoard:
                    HardBiz.Instance.StopGc();
                    break;
            }
        }

        /// <summary>
        /// 停止走基线
        /// </summary>
        /// <param name="id"></param>
        public void StopBase(ChannelID id)
        {
            CommPort.Instance.SetRealStatus(id, RealStatus.StopBase);
        }

        /// <summary>
        /// 走基线
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dtoPara"></param>
        public void RunBaseReal(ChannelID id, ParaDto dtoPara)
        {
            if (CommPort.Instance.OpenLoop())
            {
                this.InitPara(ref this._dtoPara[(int)id], dtoPara);
                this.GetCollection(id);

                this._bizResize(id).UpdateMinY(this._dtoCollection[(int)id].ShowMinY);
                this._bizResize(id).UpdateMaxY(this._dtoCollection[(int)id].ShowMaxY);

                //记忆放大缩小初期范围
                this._bizZoom(id).SetFullGObj();

                //清空数据
                this._bizTransReal(id).Reset(this._dtoCollection[(int)id]);
                CommPort.Instance.SetRealStatus(id, RealStatus.RunBase);
            }
        }

        /// <summary>
        /// 程序关闭,停止采集
        /// </summary>
        public void StopSample()
        {
            this.StopSample(ChannelID.A);
            this.StopSample(ChannelID.B);
            this.StopSample(ChannelID.C);
            this.StopSample(ChannelID.D);

            CommPort.Instance.CloseLoop();
        }

        /// <summary>
        /// 停止某个通道的采集
        /// </summary>
        /// <param name="id"></param>
        private void StopSample(ChannelID id)
        {
            switch (CommPort.Instance.GetRealStatus(id))
            {
                case RealStatus.Ready:
                    break;

                case RealStatus.SimuCollecting:
                    this._dtoRealLayer[(int)id]._bizTransSimu.CloseSimuThread();
                    this._dtoRealLayer[(int)id]._bizTransSimu.UpdatePara(this._dtoPara[(int)id]);
                    break;

                case RealStatus.RealCollecting:
                    this.StopReal(id);
                    break;

                case RealStatus.ManulStop:
                case RealStatus.StopBase:
                    break;

                case RealStatus.ManulStart:
                    break;

                case RealStatus.RunBase:
                    CommPort.Instance.SetRealStatus(id, RealStatus.Ready);
                    break;
            }
        }

        /// <summary>
        /// 从数据库查询当前的采集方法
        /// </summary>
        /// <param name="id"></param>
        private void GetCollection(ChannelID id)
        {
            SolutionDto dto = new SolutionDto();
            SolutionBiz bizSolu = new SolutionBiz();
            RelationDto dtoRelation = new RelationDto();

            if (null == this._dtoPara[(int)id])
            {
                return;
            }
            dtoRelation.SampleID = this._dtoPara[(int)id].SampleID;
            dtoRelation.RegisterTime = this._dtoPara[(int)id].RegisterTime;
            dto.SolutionID = Convert.ToInt32(bizSolu.GetSolutionID(dtoRelation));
            bizSolu.QuerySolu(dto);

            this._dtoCollection[(int)id].CollectionID = dto.CollectionID;

            //查询采集方法的具体内容
            this._bizCol.GetMethodByID(this._dtoCollection[(int)id]);

        }

        /// <summary>
        /// 更新图形的Y轴显示范围
        /// </summary>
        /// <param name="id"></param>
        public void UpdateCollection(ChannelID id)
        {
            this.GetCollection(id);
            if (null != this._dtoCollection[(int)id])
            {
                this._bizResize(id).UpdateMinY(this._dtoCollection[(int)id].ShowMinY);
                this._bizResize(id).UpdateMaxY(this._dtoCollection[(int)id].ShowMaxY);
            }
        }

        /// <summary>
        /// 更新图形A,B,C,D的Y轴显示范围
        /// </summary>
        /// <param name="ud"></param>
        /// <param name="id"></param>
        public void UpdateAxisY(UpDownFlag ud, ChannelID id)
        {
            //this.GetCollection(id);
            this._bizResize(id).UpdateY(ud);


            //switch (ud)
            //{
            //    case UpDownFlag.MaxUp:
            //        if (null != this._dtoCollection[(int)id] && 0 < this._dtoCollection[(int)id].CollectionID)
            //        {
            //            this._dtoCollection[(int)id].ShowMaxY += (this._dtoCollection[(int)id].ShowMaxY - this._dtoCollection[(int)id].ShowMinY) / ZoomTimes;
            //            this._bizResize(id).UpdateMaxY(this._dtoCollection[(int)id].ShowMaxY);
            //            this._bizCol.UpdateMethod(this._dtoCollection[(int)id]);
            //        }
            //        break;

            //    case UpDownFlag.MaxDown:
            //        if (null != this._dtoCollection[(int)id] && 0 < this._dtoCollection[(int)id].CollectionID)
            //        {
            //            this._dtoCollection[(int)id].ShowMaxY -= (this._dtoCollection[(int)id].ShowMaxY - this._dtoCollection[(int)id].ShowMinY) / ZoomTimes;
            //            this._bizResize(id).UpdateMaxY(this._dtoCollection[(int)id].ShowMaxY);
            //            this._bizCol.UpdateMethod(this._dtoCollection[(int)id]);
            //        }
            //        break;

            //    case UpDownFlag.MinUp:
            //        if (null != this._dtoCollection[(int)id] && 0 < this._dtoCollection[(int)id].CollectionID)
            //        {
            //            this._dtoCollection[(int)id].ShowMinY += (this._dtoCollection[(int)id].ShowMaxY - this._dtoCollection[(int)id].ShowMinY) / ZoomTimes;
            //            this._bizResize(id).UpdateMinY(this._dtoCollection[(int)id].ShowMinY);
            //            this._bizCol.UpdateMethod(this._dtoCollection[(int)id]);
            //        }
            //        break;

            //    case UpDownFlag.MinDown:
            //        if (null != this._dtoCollection[(int)id] && 0 < this._dtoCollection[(int)id].CollectionID)
            //        {
            //            this._dtoCollection[(int)id].ShowMinY -= (this._dtoCollection[(int)id].ShowMaxY - this._dtoCollection[(int)id].ShowMinY) / ZoomTimes;
            //            this._bizResize(id).UpdateMinY(this._dtoCollection[(int)id].ShowMinY);
            //            this._bizCol.UpdateMethod(this._dtoCollection[(int)id]);
            //        }
            //        break;
            //}
        }

        /// <summary>
        /// 更新通道显示内存中的采集方法
        /// </summary>
        /// <param name="id"></param>
        public void UpdateTransCollection(ChannelID id)
        {
            this.GetCollection(id);
            if (null != this._dtoCollection[(int)id])
            {
                this._bizTransReal(id).UpdateTransCollection(this._dtoCollection[(int)id]);
            }
        }

        #endregion

    }
}
