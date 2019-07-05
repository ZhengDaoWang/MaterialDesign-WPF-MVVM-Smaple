using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using ZFS.ILayer.Base;
using ZFS.Library;
using ZFS.Model;

namespace ZFSDomain.ViewDialog.User
{

    /// <summary>
    /// 用户主窗口
    /// </summary>
    [Module(ModuleType.System, "UserView", "用户管理", "管理用户信息", "ZFSDomain.ViewDialog.User.UserView", 7, "\xe6ac")]
    public class UserView : BaseView<View.User.UserView, ViewModel.User.UserViewModel, tb_User>, IModel
    {
    }
}
