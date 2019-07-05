/*
   绑定视图：GroupViewDialog.xaml
   文件说明：控制用户权限(新增/编辑功能)
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.ILayer.Base;
using ZFS.Model;
using ZFSData;
using ZFSData.InterFace.User;
using ZFSDomain.Common.CoreLib;
using ZFSDomain.Common.UserControls;
using ZFSDomain.Service;
using ZFSDomain.SysModule;
using ZFSDomain.ViewModel.User;

namespace ZFSDomain.ViewModel.Group
{

    /// <summary>
    /// 组编辑
    /// </summary>
    public class GroupDialogViewModel : BaseHostDialogOperation
    {
        #region  相关属性

        private tb_Group group;

        /// <summary>
        ///  编辑组
        /// </summary>
        public tb_Group Group
        {
            get { return group; }
            set { group = value; RaisePropertyChanged(); }
        }

        private List<View_GroupUser> _CaCheUsers;

        /// <summary>
        /// 组用户
        /// </summary>
        public List<View_GroupUser> GroupUsers
        {
            get { return _CaCheUsers.Where(t => t.Account.Contains(SearchText)).ToList(); }
            set { RaisePropertyChanged(); }
        }

        public List<View_GroupUser> CaCheUser
        {
            get { return _CaCheUsers; }
            set
            {
                _CaCheUsers = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 功能树
        /// </summary>
        public List<MenuGroupModel> MenuGroupModels { get; set; }

        /// <summary>
        /// 搜索用户名
        /// </summary>
        public string SearchText { get; set; } = string.Empty;

        /// <summary>
        /// 是否编辑模式
        /// </summary>
        public bool IsReadOnly { get; set; } = false;

        #endregion

        #region  绑定命令

        private RelayCommand<string> _QueryCommand;

        /// <summary>
        /// 查询命令
        /// </summary>
        public RelayCommand<string> QueryCommand
        {
            get
            {
                if (_QueryCommand == null)
                {
                    _QueryCommand = new RelayCommand<string>((t) => Query(t));
                }
                return _QueryCommand;
            }
            set
            {
                _QueryCommand = value; RaisePropertyChanged();
            }
        }

        private RelayCommand _AddCommand;

        /// <summary>
        /// 查询命令
        /// </summary>
        public RelayCommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new RelayCommand(() => Add());
                }
                return _AddCommand;
            }
            set
            {
                _AddCommand = value; RaisePropertyChanged();
            }
        }

        private RelayCommand<MenuGroupModel> _ExcuteCommand;

        /// <summary>
        /// 查询命令
        /// </summary>
        public RelayCommand<MenuGroupModel> ExcuteCommand
        {
            get
            {
                if (_ExcuteCommand == null)
                {
                    _ExcuteCommand = new RelayCommand<MenuGroupModel>((t) => Excute(t));
                }
                return _ExcuteCommand;
            }
            set
            {
                _ExcuteCommand = value; RaisePropertyChanged();
            }
        }

        private RelayCommand<View_GroupUser> _RemoveUserCommand;

        /// <summary>
        /// 移除用户
        /// </summary>
        public RelayCommand<View_GroupUser> RemoveUserCommand
        {
            get
            {
                if (_RemoveUserCommand == null)
                {
                    _RemoveUserCommand = new RelayCommand<View_GroupUser>((t) => Remove(t));
                }
                return _RemoveUserCommand;
            }
            set
            {
                _RemoveUserCommand = value; RaisePropertyChanged();
            }
        }

        #endregion

        #region 命令实现

        /// <summary>
        /// 搜索用户
        /// </summary>
        public void Query(string search)
        {
            this.SearchText = search;
            GroupUsers = _CaCheUsers.Where(t => t.Account.Contains(SearchText)).ToList();
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        public async void Add()
        {
            SearchUserViewModel model = new SearchUserViewModel();
            var dialog = ServiceProvider.Instance.Get<IModelDialog>("SearchUserDlg");
            dialog.BindViewModel(model);
            var taskResult = await dialog.ShowDialog();
            if (taskResult)
            {
                var modelList = model.UserModelList.Where(q => q.IsChecked.Equals(true)).ToList();

                if (modelList != null)
                    modelList.ForEach(q =>
                    {
                        if (CaCheUser.FirstOrDefault(t => t.Account.Equals(q.User.Account)) == null)
                            CaCheUser.Add(new View_GroupUser()
                            {
                                Account = q.User.Account,
                                GroupCode = Group.GroupCode,
                                UserName = q.User.UserName
                            });
                    });
                this.Query(this.SearchText);
            }
        }

        /// <summary>
        /// 选择
        /// </summary>
        /// <param name="model"></param>
        public void Excute(MenuGroupModel model)
        {
            if (model.ParentId.Equals(0))
            {
                var groups = model.Nodes.Where(t => t.ParentId.Equals(model.ID)).ToList();
                groups.ForEach(t => t.IsChecked = model.IsChecked);
            }
        }

        /// <summary>
        /// 移除用户
        /// </summary>
        /// <param name="user"></param>
        public async void Remove(View_GroupUser user)
        {
            if (await Msg.Question(string.Format("确认删除用户:{0}?", user.UserName), false))
            {
                CaCheUser.Remove(user);
                this.Query(this.SearchText);
            }
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="models"></param>
        public void Reset(List<MenuGroupModel> models)
        {
            models.ForEach(p =>
            {
                p.IsChecked = false;
                if (p.Nodes.Count > 0) { Reset(p.Nodes); }
            });
        }

        #endregion

        /// <summary>
        /// 关闭前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public override void ExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == false) return;

            if (string.IsNullOrEmpty(Group.GroupCode) || string.IsNullOrEmpty(Group.GroupName)) eventArgs.Cancel();

        }
    }

}
