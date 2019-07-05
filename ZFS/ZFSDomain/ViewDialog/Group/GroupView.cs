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

namespace ZFSDomain.ViewDialog.Group
{

    /// <summary>
    /// 用户组
    /// </summary>
    [Module(ModuleType.System, "GroupView", "权限管理", "管理用户组权限", "ZFSDomain.ViewDialog.Group.GroupView", 7, "\xe609")]
    public class GroupView : BaseView<View.Group.GroupView, ViewModel.Group.GroupViewModel, tb_Group>, IModel
    {
    }
}
