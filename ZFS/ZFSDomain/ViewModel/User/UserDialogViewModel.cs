/*
   绑定视图：UserViewDialog.xaml
   文件说明：控制用户管理 (新增/编辑)业务层
*/
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Model;
using ZFSData;
using ZFSDomain.SysModule;

namespace ZFSDomain.ViewModel.User
{
    /// <summary>
    /// 用户编辑
    /// </summary>
    public class UserDialogViewModel : BaseHostDialogOperation
    {
        public UserDialogViewModel()
        {
            User = new tb_User();
        }

        private tb_User user;

        /// <summary>
        /// 编辑用户
        /// </summary>
        public tb_User User
        {
            get { return user; }
            set { user = value; RaisePropertyChanged(); }
        }

        public override void ExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == false) return;
            if (string.IsNullOrWhiteSpace(User.Account) ||
                string.IsNullOrWhiteSpace(User.UserName) ||
                string.IsNullOrWhiteSpace(User.Password) ||
                string.IsNullOrWhiteSpace(User.Tel)
                )
                eventArgs.Cancel();
        }
    }
}
