using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFSDomain.Interface.Base;

namespace ZFSDomain.Interface.User
{
    /// <summary>
    /// 用户弹窗接口
    /// </summary>
    public interface IUserDialog : IModelDialog { }

    /// <summary>
    /// 数据字典弹窗接口
    /// </summary>
    public interface IDictionaryDialog : IModelDialog { }

    /// <summary>
    /// 用户组弹窗接口
    /// </summary>
    public interface IGroupDialog : IModelDialog { }

    /// <summary>
    /// 导入菜单弹窗接口
    /// </summary>
    public interface IMenuDialog : IModelDialog { }

    /// <summary>
    /// 首页窗口接口
    /// </summary>
    public interface IMainViewDialog : IModelDialog { }

    /// <summary>
    /// 登录接口
    /// </summary>
    public interface ILoginDialog : IModelDialog { }

    /// <summary>
    /// 皮肤设置接口
    /// </summary>
    public interface ISkinDialog : IModelDialog { }

    /// <summary>
    ///  信息提示通知接口-host
    /// </summary>
    public interface IMsgHostBoxDialog : IModelDialog { }

    /// <summary>
    ///  信息提示通知接口-window
    /// </summary>
    public interface IMsgBoxDialog : IModelDialog { }

    /// <summary>
    /// 选择用户接口
    /// </summary>
    public interface ISelectUserDialog : IModelDialog { }

    /// <summary>
    /// 通知消息接口
    /// </summary>
    public interface INoticeDialog : IModelDialog { }

    /// <summary>
    /// 即时消息接口
    /// </summary>
    public interface IMessagesBoxDialog : IModelDialog { }

}
