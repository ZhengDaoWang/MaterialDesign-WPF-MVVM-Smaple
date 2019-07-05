using Lierda.WPFHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ZFS.ILayer.Base;
using ZFSDomain.Service;
using ZFSDomain.ViewModel;
using ZFSDomain.ViewModel.Sign;
using ZFSDomain.ViewModel.Step;

namespace ZFSDomain
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        LierdaCracker cracker = new LierdaCracker();

        protected override void OnStartup(StartupEventArgs e)
        {
            cracker.Cracker();

            base.OnStartup(e);

            //IOC接口注册
            BootStrapper.Initialize(); 
            
            LoginViewModel view = new LoginViewModel();
            view.ReadConfigInfo(); //读写配置参数
            new SkinViewModel().ApplyDefault(view.SkinName); // 样式
            var Dialog = ServiceProvider.Instance.Get<IModelDialog>("LoginViewDlg");
            Dialog.BindViewModel(view);
            Dialog.ShowDialog(null,view.ExtendedClosingEventHandler);
        }

    }
}
