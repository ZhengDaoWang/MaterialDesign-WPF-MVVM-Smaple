using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using MaterialDesignThemes.Wpf;
using ZFS.ILayer.Base;
using ZFSDomain.SysModule;
using ZFSDomain.View.User;
using ZFSDomain.ViewModel.User;

namespace ZFSDomain.ViewDialog
{
    /// <summary>
    /// 用户编辑弹窗
    /// </summary>
    public class UserViewDlg : BaseViewDialog<UserViewDialog>, IModelDialog
    {
    }
}
