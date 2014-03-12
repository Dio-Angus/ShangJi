using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ChromatoTool.dto;

namespace ChromatoCore.solu.AntiCon
{
    public partial class TemUser : UserControl
    {
        /// <summary>
        /// 分析方法dto
        /// </summary>
        private AntiControlDto _dtoAntiControl = null;

        public TemUser(AntiControlDto dtoAntiControl)
        {
            InitializeComponent();
            this._dtoAntiControl = dtoAntiControl;
        }

        /// <summary>
        /// 编辑当前反控的信息
        /// </summary>
        public void LoadEdit()
        {
            this.LoadViewOrSaveAs();
            //this.LoadControlStyle(false);
        }

        /// <summary>
        /// 显示反控的信息
        /// </summary>
        public void LoadSaveAs()
        {
            this.LoadViewOrSaveAs();
            //this.LoadControlStyle(true);
        }

        private void LoadViewOrSaveAs()
        {
            this.lbCOLState.Text = this._dtoAntiControl.dtoHeatingSource.COLState;
            this.lbFIDState.Text = this._dtoAntiControl.dtoHeatingSource.FIDState;
            this.lbINJState.Text = this._dtoAntiControl.dtoHeatingSource.INJState;
            this.lbTCD1State.Text = this._dtoAntiControl.dtoHeatingSource.TCD1State;
            this.lbAUX1State.Text = this._dtoAntiControl.dtoHeatingSource.AUX1State;
            this.lbCOLState.Text = this._dtoAntiControl.dtoHeatingSource.COLState;

            this.lbCOLAvailableState.Text = this._dtoAntiControl.dtoHeatingSource.COLAvailableState;
            this.lbFIDAvailableState.Text = this._dtoAntiControl.dtoHeatingSource.FIDAvailableState;
            this.lbINJAvailableState.Text = this._dtoAntiControl.dtoHeatingSource.INJAvailableState;
            this.lbTCD1AvailableState.Text = this._dtoAntiControl.dtoHeatingSource.TCD1AvailableState;
            this.lbAUX1AvailableState.Text = this._dtoAntiControl.dtoHeatingSource.AUX1AvailableState;
            this.lbCOLAvailableState.Text = this._dtoAntiControl.dtoHeatingSource.COLAvailableState;

            this.textBox1.Text = this._dtoAntiControl.dtoNetworkBoard.logText;
            this.textBox1.SelectionStart = this.textBox1.Text.Length;
            this.textBox1.ScrollToCaret();
        }
    }
}
