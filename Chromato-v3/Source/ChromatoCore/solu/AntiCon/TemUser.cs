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
            
        }
    }
}
