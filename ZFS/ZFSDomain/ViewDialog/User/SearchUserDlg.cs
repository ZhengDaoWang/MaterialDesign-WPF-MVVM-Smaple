using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using ZFS.ILayer.Base;
using ZFSDomain.Common.UserControls;
using ZFSDomain.SysModule;

namespace ZFSDomain.ViewDialog.User
{
    /// <summary>
    /// 添加用户
    /// </summary>
    public class SearchUserDlg : BaseViewDialog<SearchUserWindow>, IModelDialog
    {
        public override void BindViewModel<TViewModel>(TViewModel viewModel)
        {
            GetDialogWindow().DataContext = viewModel;
        }

        public override Task<bool> ShowDialog(DialogOpenedEventHandler openedEventHandler, DialogClosingEventHandler closingEventHandler)
        {
            var dialog = GetDialogWindow();
            dialog.ShowDialog();
            var r = (dialog.DataContext as BaseDialogOperation).Result;
            return Task.FromResult(r);
        }

        public override void RegisterDefaultEvent()
        {
            Messenger.Default.Register<string>(GetDialogWindow(), "DialogClose", new Action<string>((msg) =>
           {
               GetDialogWindow().Close();
           }));
        }

        private Window GetDialogWindow()
        {
            return GetDialog() as Window;
        }

    }
}
