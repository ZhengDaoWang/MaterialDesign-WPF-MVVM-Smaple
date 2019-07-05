/*
   绑定视图：UserView.xaml
   文件说明：控制用户管理业务层
*/
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ZFS.ILayer.Base;
using ZFS.Library;
using ZFS.Library.Helper;
using ZFS.Library.Helper.MD5Poxy;
using ZFS.Model;
using ZFSData;
using ZFSDomain.Common.CoreLib;
using ZFSDomain.Common.CoreLib.Helper;
using ZFSDomain.Service;
using ZFSDomain.SysModule;
using ZFSInterface.User;

namespace ZFSDomain.ViewModel.User
{

    public class UserViewModel : BaseOperation<tb_User>
    {
        public override async void GetPageData(int pageIndex)
        {
            try
            {
                IUser user = ZFSBridge.BridgeFactory.BridgeManager.GetUserManager();

                var req = await user.GetPagingModels(pageIndex,
                    PageSize,
                    new tb_User() { Account = SearchText, UserName = SearchText });
                TotalCount = req.TotalCount;
                GridModelList.Clear();
                var userList = req.Results as List<tb_User>;
                userList.ForEach((arg) => GridModelList.Add(arg));
                base.SetPageCount();

            }
            catch (Exception ex)
            {
                Msg.Error(ex.Message, false);
            }
        }

        public override async void Add<T>(T obj)
        {
            UserDialogViewModel viewModel = new UserDialogViewModel();
            viewModel.Title = Configuration.USER_ADD_TITLE;
            var dialog = ServiceProvider.Instance.Get<IModelDialog>("UserViewDlg");
            dialog.BindViewModel(viewModel);
            var taskResult = await dialog.ShowDialog(
                null,
                viewModel.ExtendedClosingEventHandler);
            if (taskResult)
            {
                try
                {
                    ZFSInterface.User.IUser userSerivce = ZFSBridge.BridgeFactory.BridgeManager.GetUserManager();
                    viewModel.User.Password = CEncoder.Encode(viewModel.User.Password);/*加密*/
                    viewModel.User.IsLocked = 0;
                    viewModel.User.FlagAdmin = "0";
                    viewModel.User.FlagOnline = "0";
                    viewModel.User.LoginCounter = 0;
                    viewModel.User.CreateTime = DateTime.Now;

                    var req = await userSerivce.AddEntity(viewModel.User);
                    if (req.Success)
                    {
                        GridModelList.Add(viewModel.User);
                        Msg.Info(Configuration.ADD_MSG);
                    }
                }
                catch (Exception ex)
                {
                    Msg.Error(ex.Message, false);
                }
            }
        }

        public override async void Edit<T>(T CurrentUser)
        {
            if (!this.GetButtonAuth(Authority.EDIT)) return;

            if (CurrentUser != null)
            {
                try
                {
                    UserDialogViewModel view = new UserDialogViewModel();
                    view.Title = Configuration.USER_EDIT_TITLE;
                    var request = await ZFSBridge.BridgeFactory.BridgeManager.GetUserManager().GetModelByAccount((CurrentUser as tb_User).Account);
                    view.User = request.Results;
                    view.User.Password= CEncoder.Decode(view.User.Password);/*解密*/
                    var dialog = ServiceProvider.Instance.Get<IModelDialog>("UserViewDlg");
                    dialog.BindViewModel(view);
                    var taskResult = await dialog.ShowDialog(
               null,
               view.ExtendedClosingEventHandler);
                    if (taskResult)
                    {
                        ZFSInterface.User.IUser userSerivce = await Task.Run(() => ZFSBridge.BridgeFactory.BridgeManager.GetUserManager());
                        view.User.Password = CEncoder.Encode(view.User.Password);/*加密*/
                        var req = await userSerivce.UpdateEntity(view.User);
                        if (req.Success)
                        {
                            var mod = GridModelList.FirstOrDefault(t => t.isid.Equals(view.User.isid));
                            GridModelList.Remove(mod);
                            GridModelList.Add(view.User);
                            Msg.Info(Configuration.ADD_MSG);
                        }
                    }
                }
                catch (Exception ex)
                { Msg.Error(ex.Message, false); }
            }
        }

        public override async void Del<TModel>(TModel CurrentUser)
        {
            if (!this.GetButtonAuth(Authority.DELETE)) return;

            if (CurrentUser != null)
            {
                var model = CurrentUser as tb_User;

                bool result = await Msg.Question(string.Format(Configuration.USER_DELETE_TITLE, model.UserName));

                try
                {
                    if (result)
                    {
                        ZFSInterface.User.IUser userSerivce = ZFSBridge.BridgeFactory.BridgeManager.GetUserManager();
                        var req = await userSerivce.DeleteEntity(model);
                        if (req.Success)
                        {
                            var mod = GridModelList.FirstOrDefault(t => t.isid.Equals(model.isid));
                            GridModelList.Remove(mod);
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
    }
}
