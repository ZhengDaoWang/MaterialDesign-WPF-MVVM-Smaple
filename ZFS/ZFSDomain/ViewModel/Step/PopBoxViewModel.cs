/*
   绑定视图：MainPopupBox.xaml
   文件说明：自定义工具栏业务层
*/
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZFS.ILayer.Base;
using ZFSDomain.Common.UserControls;
using ZFSDomain.Common.UserControls.Common;
using ZFSDomain.Service;

namespace ZFSDomain.ViewModel.Step
{
    /// <summary>
    /// 辅助窗口
    /// </summary>
    public class PopBoxViewModel : ViewModelBase
    {
        public PopBoxViewModel()
        {
            pupBoxModelsl = new ObservableCollection<PupBoxModel>();
            this.GetBoxModels();
        }

        #region 功能集合


        /// <summary>
        /// 获取默认定义
        /// </summary>
        private void GetBoxModels()
        {
            pupBoxModelsl.Add(new PupBoxModel() { KindName = "Palette", Name = "个性化", ApplyCommand = this.SkinCommand });
            pupBoxModelsl.Add(new PupBoxModel() { KindName = "Settings", Name = "系统设置", ApplyCommand = this.StepCommand });
            pupBoxModelsl.Add(new PupBoxModel() { KindName = "TelevisionGuide", Name = "系统公告", ApplyCommand = this.MessageCommand });
            pupBoxModelsl.Add(new PupBoxModel() { KindName = "CommentMultipleOutline", Name = "消息通知", ApplyCommand = this.NoticeCommand });
            pupBoxModelsl.Add(new PupBoxModel() { KindName = "NearMe", Name = "关于作者", ApplyCommand = this.AboutCommand });
        }

        private ObservableCollection<PupBoxModel> pupBoxModelsl;

        public ObservableCollection<PupBoxModel> PupBoxModels
        {
            get { return pupBoxModelsl; }
        }

        #endregion

        #region ICommand

        public RelayCommand SkinCommand { get; } = new RelayCommand(async () => await Skin());

        public RelayCommand StepCommand { get; } = new RelayCommand(() => Step());

        public RelayCommand AboutCommand { get; } = new RelayCommand(() => About());

        public RelayCommand NoticeCommand { get; } = new RelayCommand(() => OpenNotice());

        public RelayCommand MessageCommand { get; } = new RelayCommand(() => OpenMessage());
        

        #endregion

        #region ICommand 实现

        public static void Min()
        {
            Messenger.Default.Send("", "MinWindow");
        }


        /// <summary>
        /// 皮肤设置
        /// </summary>
        private async static Task Skin()
        {
            SkinViewModel model = new SkinViewModel();
            var dialog = ServiceProvider.Instance.Get<IModelDialog>("SkinViewDlg");
            dialog.BindViewModel(model);
            await DialogHost.Show(dialog.GetDialog(), "RootDialog");
        }

        /// <summary>
        /// 系统设置
        /// </summary>
        private static void Step()
        {

        }

        /// <summary>
        /// 关于作者
        /// </summary>
        private static void About()
        {
            About about = new About();
            about.ShowDialog();
        }
        
        /// <summary>
        /// 通知中心
        /// </summary>
        public static void OpenNotice()
        {
            NoticeViewModel view = new NoticeViewModel();
            var Dialog = ServiceProvider.Instance.Get<IModelDialog>("NoticeViewDlg");
            Dialog.BindViewModel(view);
            Dialog.ShowDialog(null, view.ExtendedClosingEventHandler);
        }

        /// <summary>
        /// 消息中心
        /// </summary>
        public static void OpenMessage()
        {
            MessagesBoxViewModel view = new MessagesBoxViewModel();
            var Dialog = ServiceProvider.Instance.Get<IModelDialog>("MessagesBoxViewDlg");
            Dialog.BindViewModel(view);
            Dialog.ShowDialog(null, view.ExtendedClosingEventHandler);
        }

        #endregion
    }

    /// <summary>
    /// 首页辅助弹出窗口功能定义
    /// </summary>
    public class PupBoxModel : ViewModelBase
    {
        private string kindName;
        private string name;

        /// <summary>
        /// 字体代码[显示LOGO]
        /// </summary>
        public string KindName
        {
            get { return kindName; }
            set { kindName = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 功能名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                name = value; RaisePropertyChanged();
            }
        }

        public RelayCommand ApplyCommand { get; set; }

    }
}
