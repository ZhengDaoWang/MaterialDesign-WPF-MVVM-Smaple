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

namespace ZFSDomain.ViewDialog.Menu
{
    /// <summary>
    /// 菜单
    /// </summary>
    [Module(ModuleType.System, "MenuView", "菜单管理", "管理菜单数据", "ZFSDomain.ViewDialog.Menu.MenuView", 7, "\xe669")]
    public class MenuView : BaseView<View.Menu.MenuView, ViewModel.Menu.MenuViewModel, tb_Menu>, IModel
    {

    }
}
