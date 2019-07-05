using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library.Enums;

namespace ZFSDomain.Common.CoreLib
{
    /// <summary>
    /// 右键模块结构
    /// </summary>
    public class ContextMenuModel : ViewModelBase
    {
        private string _FontIcon;
        private ContextMenuType _MenuHeader;
        private RelayCommand _ExucteCommand;

        /// <summary>
        /// ICO
        /// </summary>
        public string FontIcon
        {
            get { return _FontIcon; }
            set { _FontIcon = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public ContextMenuType MenuHeader
        {
            get { return _MenuHeader; }
            set { _MenuHeader = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 命令
        /// </summary>
        public RelayCommand ExcuteCommand
        {
            get { return _ExucteCommand; }
            set { _ExucteCommand = value; }
        }
    }
}
