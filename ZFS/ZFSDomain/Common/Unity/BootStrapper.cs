using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFSDomain.ViewDialog;
using ZFSDomain.ViewDialog.Dictionary;
using ZFSDomain.ViewDialog.Group;
using ZFSDomain.ViewDialog.Menu;
using ZFSDomain.ViewDialog.Sign;
using ZFSDomain.ViewDialog.Step;
using ZFSDomain.ViewDialog.User;

namespace ZFSDomain.Service
{
    /// <summary>
    /// Unity接口类
    /// </summary>
    class BootStrapper
    {
        /// <summary>
        /// 注册方法
        /// </summary>
        public static void Initialize()
        {
            ServiceProvider.RegisterServiceLocator(new UnityServiceLocator());
            ServiceProvider.Instance.Register();
            //ServiceProvider.Instance.Register<ILoginDialog, LoginViewDlg>();//用户登录接口
            //ServiceProvider.Instance.Register<IUserDialog, UserViewDlg>();//用户弹窗接口
            //ServiceProvider.Instance.Register<IGroupDialog, GroupViewDlg>();//用户组弹窗接口
            //ServiceProvider.Instance.Register<IDictionaryDialog, DictionaryViewDlg>();//数据字典弹窗接口
            //ServiceProvider.Instance.Register<IMenuDialog, MenuViewDlg>();//菜单导入弹窗接口
            //ServiceProvider.Instance.Register<ISelectUserDialog, SearchUserDlg>();//公共用户选择弹窗接口
            //ServiceProvider.Instance.Register<IMainViewDialog, MainViewDlg>();//首页窗口
            //ServiceProvider.Instance.Register<ISkinDialog, SkinViewDlg>();//皮肤弹窗接口
            //ServiceProvider.Instance.Register<IMsgHostBoxDialog, MsgHostBoxViewDlg>();//消息提示接口
            //ServiceProvider.Instance.Register<IMsgBoxDialog, MsgBoxViewDlg>();//消息提示接口-Window
            //ServiceProvider.Instance.Register<INoticeDialog, NoticeViewDlg>();//消息通知接口
            //ServiceProvider.Instance.Register<IMessagesBoxDialog, MessagesBoxViewDlg>();//即时通知接口
        }
    }
}
