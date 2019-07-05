/*
   绑定视图：MsgBox.xaml
   文件说明：用于消息询问/异常提示等
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFSDomain.SysModule;

namespace ZFSDomain.ViewModel.Step
{
    /// <summary>
    /// 信息提示窗口
    /// </summary>
    public class MsgHostBoxViewModel : BaseHostDialogOperation
    {
        #region 属性

        private string msg;
        private string icon;
        private string color;
        private bool visibility;

        /// <summary>
        /// 字体
        /// </summary>
        public string Icon
        {
            get { return icon; }
            set { icon = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 信息
        /// </summary>
        public string Msg
        {
            get { return msg; }
            set { msg = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 颜色
        /// </summary>
        public string Color
        {
            get { return color; }
            set { color = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool BtnHide
        {
            get { return visibility; }
            set { visibility = value; RaisePropertyChanged(); }
        }

        #endregion
    }

    /// <summary>
    /// 信息提示窗口-Window
    /// </summary>
    public class MsgBoxViewModel : BaseDialogOperation
    {
        #region 属性

        private string msg;
        private string icon;
        private string color;
        private bool visibility;

        /// <summary>
        /// 字体
        /// </summary>
        public string Icon
        {
            get { return icon; }
            set { icon = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 信息
        /// </summary>
        public string Msg
        {
            get { return msg; }
            set { msg = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 颜色
        /// </summary>
        public string Color
        {
            get { return color; }
            set { color = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool BtnHide
        {
            get { return visibility; }
            set { visibility = value; RaisePropertyChanged(); }
        }

        #endregion
    }
}
