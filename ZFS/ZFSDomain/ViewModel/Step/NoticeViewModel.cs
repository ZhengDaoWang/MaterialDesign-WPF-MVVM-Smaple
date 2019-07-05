/*
   绑定视图：MainNotice.xaml
   文件说明：通知消息
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFSDomain.Common.UserControls;
using ZFSDomain.Common.UserControls.Common;
using ZFSDomain.Service;
using ZFSDomain.SysModule;

namespace ZFSDomain.ViewModel.Step
{
    /// <summary>
    /// 通知栏
    /// </summary>
    public class NoticeViewModel : BaseHostDialogOperation
    {
        public NoticeViewModel()
        {
            _NoticeModels = new ObservableCollection<NoticeModel>();
            _NoticeModels.Add(new NoticeModel() { IconName = "Minus", ApplyCommand = MinCommand });
            _NoticeModels.Add(new NoticeModel() { IconName = "WindowMaximize", ApplyCommand = MaxCommand });
            _NoticeModels.Add(new NoticeModel() { IconName = "Close", ApplyCommand = ExitCommand });
        }

        private ObservableCollection<NoticeModel> _NoticeModels;
        
        public ObservableCollection<NoticeModel> NoticeModels
        {
            get { return _NoticeModels; }
        }

        #region ICommand

        public RelayCommand ExitCommand { get; } = new RelayCommand(() => Exit());
    
        public RelayCommand MinCommand { get; } = new RelayCommand(() => Min());

        public RelayCommand MaxCommand { get; } = new RelayCommand(() => Max());

        #endregion

        #region Command 

        public static bool Mask = true;

        public static void Max()
        {
            if (Mask)
                Mask = false;
            else
                Mask = true;
            Messenger.Default.Send(Mask, "MaxWindow");
        }

        public static void Min()
        {
            Messenger.Default.Send("", "MinWindow");
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        private static void Exit()
        {
            Messenger.Default.Send("确认退出系统?", "MainExit");
        }

        #endregion
    }

    /// <summary>
    /// 通知窗口类型
    /// </summary>
    public class NoticeModel : ViewModelBase
    {
        private string _IconName;
        private string _Count;

        /// <summary>
        /// 字体代码[显示LOGO]
        /// </summary>
        public string IconName
        {
            get { return _IconName; }
            set { _IconName = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 功能名称
        /// </summary>
        public string Count
        {
            get { return _Count; }
            set
            {
                _Count = value; RaisePropertyChanged();
            }
        }

        public RelayCommand ApplyCommand { get; set; }
    }
}
