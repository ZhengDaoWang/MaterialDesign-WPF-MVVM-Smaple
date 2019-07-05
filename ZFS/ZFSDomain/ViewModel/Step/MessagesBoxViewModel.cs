/*
   绑定视图：MessagesBox.xaml
   文件说明：即时通讯页
*/
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFSDomain.SysModule;

namespace ZFSDomain.ViewModel.Step
{
    /// <summary>
    /// 聊天窗口
    /// </summary>
    public class MessagesBoxViewModel : BaseHostDialogOperation
    {
        public MessagesBoxViewModel()
        {
            _MsgInfoModelList = new ObservableCollection<MsgInfo>();
            _UserInfoModelList = new ObservableCollection<Userinfo>();
        }

        private ObservableCollection<MsgInfo> _MsgInfoModelList;
        private ObservableCollection<Userinfo> _UserInfoModelList;

        /// <summary>
        /// 对话列表
        /// </summary>
        public ObservableCollection<MsgInfo> MsgInfoModelList
        {
            get { return _MsgInfoModelList; }
            set { _MsgInfoModelList = value;RaisePropertyChanged(); }
        }
        
        /// <summary>
        /// 在线用户列表
        /// </summary>
        public ObservableCollection<Userinfo> UserInfoModelList
        {
            get { return _UserInfoModelList; }
            set { _UserInfoModelList = value; RaisePropertyChanged(); }
        }
    }

    /// <summary>
    /// 消息结构
    /// </summary>
    public class MsgInfo : ViewModelBase
    {
        public string _Icon;
        public string _Title;
        public string _TopMsg;

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon
        {
            get { return _Icon; }
            set { _Icon = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 聊天标题
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { _Title = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 最新的聊天消息
        /// </summary>
        public string TopMsg
        {
            get { return _TopMsg; }
            set { _TopMsg = value; RaisePropertyChanged(); }
        }
    }

    /// <summary>
    /// 用于在线列表绑定用户数据
    /// </summary>
    public class Userinfo : ViewModelBase
    {
        private string _Icon;
        private string _UserName;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 默认头像
        /// </summary>
        public string Icon
        {
            get { return _Icon; }
            set { _Icon = value; RaisePropertyChanged(); }
        }
    }
}
