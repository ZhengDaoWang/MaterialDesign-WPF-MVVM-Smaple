/*
   绑定视图：MenuViewDialog.xaml
   文件说明：菜单管理(新增/编辑)业务层
*/

using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Model;
using ZFSBridge;
using ZFSData;
using ZFSDomain.Common.CoreLib;
using ZFSDomain.SysModule;

namespace ZFSDomain.ViewModel.Menu
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class MenuDialogViewModel : BaseHostDialogOperation
    {
        public MenuDialogViewModel()
        {
            MenusModelList = new ObservableCollection<tb_Menu>();
        }

        #region 相关属性

        private string _info;

        /// <summary>
        /// 检索信息
        /// </summary>
        public string Info
        {
            get { return _info; }
            set { _info = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<tb_Menu> _MenusModelList;

        /// <summary>
        /// 在线检索模块
        /// </summary>
        public ObservableCollection<tb_Menu> MenusModelList
        {
            get
            {
                return _MenusModelList;
            }
            set
            {
                _MenusModelList = value; RaisePropertyChanged();
            }
        }

        #endregion
        
        #region 绑定命令

        private RelayCommand _searchCommand;

        public RelayCommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new RelayCommand(() => Import());
                }
                return _searchCommand;
            }
            set { _searchCommand = value; }
        }

        #endregion

        /// <summary>
        /// 导入菜单
        /// </summary>
        public void Import()
        {
            var ass = System.Reflection.Assembly.GetExecutingAssembly();
            var modlist = ass.DefinedTypes.Where(q => q.Name.Contains("View")).ToList();

            modlist.ForEach(t =>
            {
                object[] attr = t.GetCustomAttributes(false);
                for (int i = 0; i < attr.Length; i++)
                {
                    var ar = attr[i] as ModuleAttribute;
                    if (ar != null)
                    {
                        var mod = MenusModelList.FirstOrDefault(x => x.MenuCode.Equals(ar.Code));
                        if (mod == null)
                        {
                            MenusModelList.Add(new tb_Menu()
                            {
                                MenuCode = ar.Code,
                                MenuName = ar.Name,
                                MenuCaption = ar.Remark,
                                MenuNameSpace = t.Namespace,
                                MenuAuthorities = ar.Autority
                            });
                        }
                    }
                }
            });
            Info = string.Format("本次搜索可用模块共{0}个", MenusModelList.Count);
        }
        
    }
}
