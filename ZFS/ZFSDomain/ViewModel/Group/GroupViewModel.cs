/*
   绑定视图：GroupView.xaml
   文件说明：控制用户权限
*/

using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.ILayer.Base;
using ZFS.Library;
using ZFS.Library.Helper;
using ZFS.Model;
using ZFSData;
using ZFSData.InterFace.User;
using ZFSDomain.Common.CoreLib;
using ZFSDomain.Common.CoreLib.Helper;
using ZFSDomain.Service;
using ZFSDomain.SysModule;

namespace ZFSDomain.ViewModel.Group
{

    public class GroupViewModel : BaseOperation<tb_Group>
    {
        #region 相关属性

        /// <summary>
        /// 模块管理器
        /// </summary>
        private MenuManager _MenuManager;

        public MenuManager MenuManager
        {
            get { return _MenuManager; }
        }

        #endregion

        public override async void InitViewModel()
        {
            try
            {
                _MenuManager = new MenuManager();
                await _MenuManager.IntiModuleGroups();
                await _MenuManager.LoadModules();
                base.InitViewModel();
            }
            catch (Exception ex)
            {
                Msg.Error(ex.Message, false);
            }
        }

        public override async void Add<TModel>(TModel model)
        {
            try
            {
                GroupDialogViewModel view = new GroupDialogViewModel();
                view.Title = Configuration.GROUP_ADD_TITLE;
                view.IsReadOnly = false;
                view.Group = new tb_Group();
                view.MenuGroupModels = MenuManager.ModuleGroups;
                //var funcList = ZFSBridge.BridgeFactory.GetGroupBridge().
                //    GetGroupFuncs(view.Group.GroupCode); //获取组权限数据
                view.CaCheUser = new List<View_GroupUser>();
                var dialog = ServiceProvider.Instance.Get<IModelDialog>("GroupViewDlg");
                dialog.BindViewModel(view);
                var taskResult = await dialog.ShowDialog(
                null,
                view.ExtendedClosingEventHandler);
                if (taskResult)
                {
                    List<tb_GroupFunc> FuncList = new List<tb_GroupFunc>();
                    view.MenuGroupModels.ForEach(t =>
                    {
                        var node = t.Nodes.Where(q => q.IsChecked.Equals(true)).ToList();
                        if (node.Count > 0)
                        {
                            node.ForEach(s =>
                            {
                                FuncList.Add(new tb_GroupFunc()
                                {
                                    GroupCode = view.Group.GroupCode,
                                    MenuCode = s.MenuCode,
                                    Authorities = s.Nodes.Where(q => q.IsChecked.Equals(true)).Sum(w => w.AuthValue)
                                });
                            });
                        }
                    });
                    IGroup groupSerivce = ZFSBridge.BridgeFactory.BridgeManager.GetGroupManager();
                    var reqUpdate = await groupSerivce.UpdateGroupFunc(view.Group, view.CaCheUser, FuncList);
                    if (reqUpdate.Success)
                    {
                        GridModelList.Add(view.Group);
                    }
                    view.Reset(view.MenuGroupModels);
                }
            }
            catch (Exception ex)
            {
                Msg.Error(ex.Message, false);
            }
        }

        public override async void Edit<TModel>(TModel CurrentGroup)
        {
            if (!this.GetButtonAuth(Authority.EDIT)) return;

            if (CurrentGroup != null)
            {
                try
                {
                    GroupDialogViewModel view = new GroupDialogViewModel();
                    view.Title = Configuration.GROUP_EDIT_TITLE;
                    view.IsReadOnly = true;
                    view.Group = ClassOperation.CopyByReflect(CurrentGroup as tb_Group);
                    view.MenuGroupModels = new List<MenuGroupModel>(MenuManager.ModuleGroups.ToArray());

                    var req = await ZFSBridge.BridgeFactory.BridgeManager.GetGroupManager().GetGroupFuncs(view.Group.GroupCode);
                    if (req.Success)
                    {
                        var funcList = req.Results as List<tb_GroupFunc>;
                        funcList.ForEach(t =>
                        {
                            view.MenuGroupModels.ForEach(q =>
                            {
                                q.Nodes.ForEach(w =>
                                {
                                    if (w.MenuCode.Equals(t.MenuCode))
                                    {
                                        w.IsChecked = true;
                                        w.Nodes.ForEach(s =>
                                        {
                                            if ((t.Authorities & s.AuthValue) == s.AuthValue)
                                                s.IsChecked = true;
                                        });
                                    }
                                });
                                if (q.Nodes.Where(x => x.IsChecked.Equals(true)).Count() == q.Nodes.Count)
                                {
                                    q.IsChecked = true;
                                }
                            });
                        });
                    }

                    var req_userGroup = await ZFSBridge.BridgeFactory.BridgeManager.GetGroupManager().GetGroupUsers(view.Group.GroupCode); //获取用户组
                    if (req_userGroup.Success)
                    {
                        view.CaCheUser = req_userGroup.Results as List<View_GroupUser>;
                    }
                    var dialog = ServiceProvider.Instance.Get<IModelDialog>("GroupViewDlg");
                    dialog.BindViewModel(view);
                    var taskResult = await dialog.ShowDialog(null, view.ExtendedClosingEventHandler);
                    if (taskResult)
                    {
                        List<tb_GroupFunc> FuncList = new List<tb_GroupFunc>();
                        view.MenuGroupModels.ForEach(t =>
                        {
                            var node = t.Nodes.Where(q => q.IsChecked.Equals(true)).ToList();
                            if (node.Count > 0)
                            {
                                node.ForEach(s =>
                                {
                                    FuncList.Add(new tb_GroupFunc()
                                    {
                                        GroupCode = view.Group.GroupCode,
                                        MenuCode = s.MenuCode,
                                        Authorities = s.Nodes.Where(q => q.IsChecked.Equals(true)).Sum(w => w.AuthValue)
                                    });
                                });
                            }
                        });
                        IGroup groupSerivce = ZFSBridge.BridgeFactory.BridgeManager.GetGroupManager();
                        var reqUpdate = await groupSerivce.UpdateGroupFunc(view.Group, view.CaCheUser, FuncList);
                        if (reqUpdate.Success)
                        {
                            var EditGroup = GridModelList.FirstOrDefault(t => t.isid.Equals(view.Group.isid));
                            EditGroup.GroupName = view.Group.GroupName;
                        }
                        Msg.Info(Configuration.UPDATE_MSG);
                    }
                    view.Reset(view.MenuGroupModels);
                }
                catch (Exception ex)
                {
                    Msg.Error(ex.Message, false);
                }
            }
        }

        public override async void Del<TModel>(TModel CurrentGroup)
        {
            if (!this.GetButtonAuth(Authority.DELETE)) return;

            if (CurrentGroup != null)
            {
                try
                {
                    tb_Group group = CurrentGroup as tb_Group;
                    if (await Msg.Question(string.Format(Configuration.GROUP_DELETE_TITLE, group.GroupName)))
                    {
                        var req = await ZFSBridge.BridgeFactory.BridgeManager.GetGroupManager().Remove(group.isid);
                        if (req.Success)
                        {
                            var gp = GridModelList.FirstOrDefault(t => t.isid.Equals(group.isid));
                            GridModelList.Remove(gp);
                            Msg.Info(Configuration.DELETE_MSG);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Msg.Error(ex.Message, false);
                }
            }
        }

        /// <param name="pageIndex"></param>
        public override async void GetPageData(int pageIndex)
        {
            try
            {
                var response = await ZFSBridge.BridgeFactory.BridgeManager.GetGroupManager().GetGroups(SearchText);
                GridModelList.Clear();
                var GroupList = response.Results as List<tb_Group>;
                GroupList.ForEach((arg) => GridModelList.Add(arg));
            }
            catch (Exception ex)
            {
                Msg.Error(ex.Message, false);
            }
        }
    }
}
