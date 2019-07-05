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
using ZFSDomain.Common.UserControls.Common;
using ZFSDomain.SysModule;
using ZFSDomain.ViewModel.Step;

namespace ZFSDomain.ViewDialog.Step
{
    /// <summary>
    /// 消息处理-HOST
    /// </summary>
    public class MsgHostBoxViewDlg : BaseViewDialog<MsgHostBox>, IModelDialog
    {
    }

    /// <summary>
    /// 消息处理-Window
    /// </summary>
    public class MsgBoxViewDlg : BaseViewDialog<MsgBox>, IModelDialog
    {

        public override void BindViewModel<TViewModel>(TViewModel viewModel)
        {
            GetDialogWindow().DataContext = viewModel;
        }

        public override Task<bool> ShowDialog(DialogOpenedEventHandler openedEventHandler = null, DialogClosingEventHandler closingEventHandler = null)
        {
            var dialog = GetDialogWindow();
            dialog.ShowDialog();
            return Task.FromResult((dialog.DataContext as BaseDialogOperation).Result);
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
