/*-----------------------------------------------------------------------------
//  FILE NAME       : OnLineConfig.cs
//  FUNCTION        : 在线配置
//  AUTHOR          : 李锋(2009/03/13)
//  CHANGE LOG      : 
//  VERSION         : V1.0
//  ---------------------------------------------------------------------------
//---------------------------------------------------------------------------*/

using System;
using System.Windows.Forms;
using ChromatoTool.util;
using ChromatoTool.ini;
using ChromatoTool.dto;

namespace ChromatoCore.On
{
    /// <summary>
    /// 在线配置
    /// </summary>
    public partial class OnConfigViewer : UserControl
    {


        #region 变量

        /// <summary>
        /// 样品Dto
        /// </summary>
        private ParaDto _dtoPara = null;

        /// <summary>
        /// 通道1,2标志
        /// </summary>
        private ChannelID _lf { get; set; }

        /// <summary>
        /// 更新采集方法事件的代理
        /// </summary>
        public OnCollectionViewer _viewer = null;

        #endregion


        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public OnConfigViewer()
        {
            this.InitializeComponent();
            this.LoadDefault();
            this.LoadEvent();
        }

        /// <summary>
        /// 装载缺省参数
        /// </summary>
        public void LoadDefault()
        {
           
            this.lblSampleID.Text = "";
            this.lblSampleName.Text = "";
            this.lblSampleType.Text = "";
            this.lblSampleWeight.Text = "";
            this.lblCollectTime.Text = "";
            this.lblPathData.Text = "";
            this.lblSolutionName.Text = "";

            this._viewer = this.onColViewer;
        }

        /// <summary>
        /// 装载事件
        /// </summary>
        private void LoadEvent()
        {
        }
        
        #endregion


        #region 方法

        /// <summary>
        /// 装载参数
        /// </summary>
        public void LoadPara(ParaDto dto)
        {
            this._dtoPara = dto;

            this.lblSampleID.Text = this._dtoPara.SampleID;
            this.lblSampleName.Text = this._dtoPara.SampleName;
            this.lblSampleType.Text = EnumDescription.GetFieldText(this._dtoPara.SampleType);
            this.lblSampleWeight.Text = this._dtoPara.SampleWeight.ToString();
            this.lblCollectTime.Text = this._dtoPara.CollectTime;
            this.lblPathData.Text = this._dtoPara.PathData;

            //根据样品ID装载采集方法
            this.lblSolutionName.Text = this.onColViewer.LoadEdit(dto);
        }

        /// <summary>
        /// 自动斜率
        /// </summary>
        /// <param name="idChannel"></param>
        /// <param name="info"></param>
        public void SetAutoSlopeText(String idChannel, string info)
        {
            if(idChannel.Equals(this._dtoPara.ChannelID))
            {
                this.onColViewer.SetAutoSlopeText(info);
            }
        }

        #endregion



    }
}
