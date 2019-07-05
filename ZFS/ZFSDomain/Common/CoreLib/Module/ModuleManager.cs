using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Library.Helper;
using ZFSDomain.Common.CoreLib.Helper;

namespace ZFSDomain.Common.CoreLib
{

    /// <summary>
    /// 模块组
    /// </summary>
    public class ModuleManager : ViewModelBase
    {
        public ModuleManager()
        {
            IntiModuleGroups();
        }

        private ObservableCollection<Module> _Modules = new ObservableCollection<Module>();
        private ObservableCollection<ModuleGroup> _ModuleGroups = new ObservableCollection<ModuleGroup>();

        /// <summary>
        /// 已加载模块
        /// </summary>
        public ObservableCollection<Module> Modules
        {
            get { return _Modules; }
        }

        /// <summary>
        /// 已加载模块<含分组>
        /// </summary>
        public ObservableCollection<ModuleGroup> ModuleGroups
        {
            get { return _ModuleGroups; }
        }

        private IList<ModuleAttribute> _IModule = null;

        /// <summary>
        /// 初始化模块组
        /// </summary>
        private void IntiModuleGroups()
        {
            Array array = System.Enum.GetValues(typeof(ModuleType));

            foreach (var m in array)
            {
                ModuleType t = (ModuleType)m;
                if (t != ModuleType.None)
                {
                    var attr = GetEnumAttrbute.GetDescription(t);
                    if (attr != null)
                        _ModuleGroups.Add(new ModuleGroup() { ModuleType = t, GroupName = attr.ModuleName, GroupIcon = attr.ModuleIcon });
                }

            }
        }

        /// <summary>
        /// 加载模块-根据权限
        /// </summary>
        public async void LoadModules()
        {
            try
            {
                ModuleComponent loader = new ModuleComponent();
                _IModule = await Task.Run(() => loader.GetModules());
                if (_IModule == null) return;
                foreach (var m in _IModule)
                {
                    if (!loader.ModuleVerify(m)) continue;

                    var mg = ModuleGroups.FirstOrDefault(t => t.ModuleType.Equals(m.ModuleType)); //寻找模块对应的组
                    if (mg != null)
                    {
                        if (mg.Modules == null) mg.Modules = new ObservableCollection<Module>();
                        int? auth = Loginer.LoginerUser.IsAdmin == true ? m.Autority : loader.UserAuthority.Authorities;
                        Module md = new Module(m.Name, m.Remark, auth, m.ModuleNameSpace, m.ICON);
                        mg.Modules.Add(md);
                        Modules.Add(md);
                    }
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
