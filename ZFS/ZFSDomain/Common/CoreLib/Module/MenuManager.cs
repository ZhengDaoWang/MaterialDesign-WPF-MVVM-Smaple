using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Model;
using ZFSData;
using ZFSDomain.Common.CoreLib.Helper;

namespace ZFSDomain.Common.CoreLib
{
    public class MenuManager
    {
        /// <summary>
        /// 已加载模块
        /// </summary>
        private List<MenuGroupModel> _ModuleGroups = new List<MenuGroupModel>();

        /// <summary>
        /// 已加载模块
        /// </summary>
        public List<MenuGroupModel> ModuleGroups
        {
            get { return _ModuleGroups; }
        }

        private IList<ModuleAttribute> _IModule = null;

        /// <summary>
        /// 菜单对应的功能按钮集合
        /// </summary>
        private List<View_MenuTree> _TreeList;

        /// <summary>
        /// 初始化菜单组
        /// </summary>
        public async Task IntiModuleGroups()
        {
            Array array = System.Enum.GetValues(typeof(ModuleType));

            foreach (var m in array)
            {
                ModuleType t = (ModuleType)m;
                if (t != ModuleType.None)
                {
                    var attr = GetEnumAttrbute.GetDescription(t);
                    if (attr != null)
                        _ModuleGroups.Add(new MenuGroupModel() { MenuType = t, MenuName = attr.ModuleName });
                }
            }

            var req = await ZFSBridge.BridgeFactory.BridgeManager.GetMenuManager().GetMenuTrees();

            if (req.Success) _TreeList = req.Results as List<View_MenuTree>;
        }


        /// <summary>
        /// 加载菜单
        /// </summary>
        public async Task LoadModules()
        {
            try
            {
                ModuleComponent loader = new ModuleComponent();
                _IModule = await loader.GetModules();
                foreach (var m in _IModule)
                {
                    //寻找模块对应的组
                    var mg = ModuleGroups.FirstOrDefault(t => t.MenuType.Equals(m.ModuleType));
                    if (mg != null)
                    {
                        MenuGroupModel groupModel = new MenuGroupModel();
                        groupModel.MenuCode = m.Code;
                        groupModel.MenuName = m.Name;
                        groupModel.MenuType = m.ModuleType;
                        groupModel.AuthValue = m.Autority;
                        mg.Nodes.Add(groupModel);
                        #region 添加功能按钮

                        var authItemList = _TreeList.Where(t => t.MenuCode.Equals(m.Code)).ToList();

                        foreach (var a in authItemList)
                        {
                            groupModel.Nodes.Add(new MenuGroupModel()
                            {
                                MenuName = a.AuthorityName,
                                MenuCode = a.MenuCode,
                                AuthValue = a.AuthorityValue,
                            });
                        }

                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
