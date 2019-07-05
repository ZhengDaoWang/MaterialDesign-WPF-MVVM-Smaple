/*
   绑定视图：SearchUserWindow.xaml
   文件说明：选择用户业务层
*/
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Model;
using ZFSData;
using ZFSDomain.Common.CoreLib;
using ZFSDomain.SysModule;
using ZFSInterface.User;

namespace ZFSDomain.ViewModel.User
{
    /// <summary>
    /// 选择用户ViewModel层
    /// </summary>
    public class SearchUserViewModel : BaseDialogOperation
    {
        public SearchUserViewModel()
        {
            this.InitViewModel();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void InitViewModel()
        {
            UserModelList = new ObservableCollection<UserModel>();
            this.Query();
        }

        #region 属性


        private ObservableCollection<UserModel> userModelList;

        /// <summary>
        /// 用户数据集
        /// </summary>
        public ObservableCollection<UserModel> UserModelList
        {
            get { return userModelList; }
            set { userModelList = value; RaisePropertyChanged(); }
        }
        
        #endregion
        
        /// <summary>
        /// 查询
        /// </summary>
        public async void Query()
        {
            try
            {
                IUser user = ZFSBridge.BridgeFactory.BridgeManager.GetUserManager();
                var req =await user.GetModels(new tb_User() { Account = "" });
                UserModelList.Clear();
                var UserList = req.Results as List<tb_User>;
                UserList.ForEach((arg) =>
                {
                    UserModelList.Add(new UserModel()
                    {
                        User = arg
                    });
                });
            }
            catch (Exception ex)
            {
                Msg.Error(ex.Message, false);
            }
        }
    }

    /// <summary>
    ///  选择用户数据
    /// </summary>
    public class UserModel : ViewModelBase
    {
        private bool _IsChecked;
        private tb_User _User;

        /// <summary>
        /// 选中
        /// </summary>
        public bool IsChecked
        {
            get { return _IsChecked; }
            set { _IsChecked = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 用户
        /// </summary>
        public tb_User User
        {
            get { return _User; }
            set { _User = value; RaisePropertyChanged(); }
        }

    }
}
