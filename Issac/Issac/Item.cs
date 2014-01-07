using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace issac
{
    class Item
    {
        protected string _name;
        protected Image _image;
        protected string _description;
        protected int _tag;//0为主动，1为被动，2为携带，3为消耗

        #region 成员变量相应属性
        public string Name
        {
            get
            {
                return _name;
            }
            set 
            {
                _name = value;
            }
        }
        public Image Ima
        {
            get 
            {
                return _image;
            }
            set 
            {
                _image = value;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public int tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        }
        #endregion   
    }
}
