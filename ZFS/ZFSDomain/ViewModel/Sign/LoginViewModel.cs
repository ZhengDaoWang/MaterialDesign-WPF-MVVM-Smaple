/*
   绑定视图：Login.xaml
   文件说明：用于控制用户登录/退出
*/
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZFS.ILayer.Base;
using ZFS.Library;
using ZFS.Library.Helper;
using ZFS.Library.Helper.FileHelper;
using ZFS.Library.Helper.MD5Poxy;
using ZFS.Model;
using ZFSDomain.Common.CoreLib;
using ZFSDomain.Common.CoreLib.Helper;
using ZFSDomain.Service;
using ZFSDomain.SysModule;
using ZFSInterface.User;

namespace ZFSDomain.ViewModel.Sign
{
    /// <summary>
    /// 登录逻辑处理
    /// </summary>
    public class LoginViewModel : BaseHostDialogOperation
    {

        #region 用户名/密码

        private string _Report;
        private string userName = string.Empty;
        private string passWord = string.Empty;
        private bool _IsCancel = true;
        private bool _UserChecked;
        private string _SkinName;

        /// <summary>
        /// 皮肤样式
        /// </summary>
        public string SkinName
        {
            get { return _SkinName; }
        }

        /// <summary>
        /// 进度报告
        /// </summary>
        public string Report
        {
            get { return _Report; }
            set { _Report = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 记住密码
        /// </summary>
        public bool UserChecked
        {
            get { return _UserChecked; }
            set { _UserChecked = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return passWord; }
            set { passWord = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 禁用按钮
        /// </summary>
        public bool IsCancel
        {
            get { return _IsCancel; }
            set { _IsCancel = value; RaisePropertyChanged(); }
        }

        #endregion

        #region 命令(Binding Command)

        private RelayCommand _signCommand;

        public RelayCommand SignCommand
        {
            get
            {
                if (_signCommand == null)
                {
                    _signCommand = new RelayCommand(() => Login());
                }
                return _signCommand;
            }
        }

        private RelayCommand _exitCommand;

        public RelayCommand ExitCommand
        {
            get
            {
                if (_exitCommand == null)
                {
                    _exitCommand = new RelayCommand(() => ApplicationShutdown());
                }
                return _exitCommand;
            }
        }

        #endregion

        #region Login/Exit

        /// <summary>
        /// 登陆系统
        /// </summary>
        public async void Login()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password))
                {
                    this.IsCancel = false;
                    IUser user = ZFSBridge.BridgeFactory.BridgeManager.GetUserManager();
                    this.Report = "正在验证登录 . . .";
                    var LoginTask = user.Login(UserName, CEncoder.Encode(Password));
                    var timeouttask = Task.Delay(3000);
                    var completedTask = await Task.WhenAny(LoginTask, timeouttask);
                    if (completedTask == timeouttask)
                    {
                        this.Report = "系统连接超时,请联系管理员!";
                    }
                    else
                    {
                        var task = await LoginTask;
                        if (task.Success)
                        {
                            if (UserChecked) SaveLoginInfo();

                            #region 设置用户基础信息
                            var req = task.Results as tb_User;
                            Loginer.LoginerUser.Account = req.Account;
                            Loginer.LoginerUser.UserName = req.UserName;
                            Loginer.LoginerUser.IsAdmin = req.FlagAdmin == "1" ? true : false;
                            Loginer.LoginerUser.Email = req.Email;
                            #endregion

                            #region 加载用户资料
                            this.Report = "加载用户信息 . . .";
                            var response = await ZFSBridge.BridgeFactory.BridgeManager.GetUserManager().GetAuthority(Loginer.LoginerUser.Account);
                            Loginer.LoginerUser.UserAuthority = response.Results;

                            #endregion

                            #region 初始化首页
                            this.Report = "初始化首页 . . .";
                            MainViewModel model = new MainViewModel();
                            model.InitDefaultView();
                            var dialog = ServiceProvider.Instance.Get<IModelDialog>("MainViewDlg");
                            dialog.BindViewModel(model);
                            Messenger.Default.Send(string.Empty, "ApplicationHiding");
                            bool taskResult = await dialog.ShowDialog(null, model.ExtendedClosingEventHandler);
                            this.ApplicationShutdown();
                            #endregion
                        }
                        else
                            this.Report = task.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Report = ExceptionLibrary.GetErrorMsgByExpId(ex);
            }
            finally
            {
                this.IsCancel = true;
            }
        }

        /// <summary>
        /// 关闭系统
        /// </summary>
        public void ApplicationShutdown()
        {
            Messenger.Default.Send("", "ApplicationShutdown");
        }

        #endregion

        #region 记住密码

        /// <summary>
        /// 读取本地配置信息
        /// </summary>
        public void ReadConfigInfo()
        {
            string cfgINI = AppDomain.CurrentDomain.BaseDirectory + SerivceFiguration.INI_CFG;
            if (File.Exists(cfgINI))
            {
                IniFile ini = new IniFile(cfgINI);
                UserName = ini.IniReadValue("Login", "User");
                Password = CEncoder.Decode(ini.IniReadValue("Login", "Password"));
                UserChecked = ini.IniReadValue("Login", "SaveInfo") == "Y";
                _SkinName = ini.IniReadValue("Skin", "Skin");
            }
        }

        /// <summary>
        /// 保存登录信息
        /// </summary>
        private void SaveLoginInfo()
        {
            string cfgINI = AppDomain.CurrentDomain.BaseDirectory + SerivceFiguration.INI_CFG;
            IniFile ini = new IniFile(cfgINI);
            ini.IniWriteValue("Login", "User", UserName);
            ini.IniWriteValue("Login", "Password", CEncoder.Encode(Password));
            ini.IniWriteValue("Login", "SaveInfo", UserChecked ? "Y" : "N");
        }

        #endregion
    }
}
