using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ZFSDomain.Common.CoreLib;
using ZFSDomain.Common.UserControls;
using ZFSDomain.View.User;
using ZFSDomain.ViewModel;
using ZFSDomain.ViewModel.Step;
using ZFSDomain.ViewModel.User;

namespace ZFSDomain
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Zone.MouseDoubleClick += (sender, e) => { Max(); };
            Messenger.Default.Register<bool>(this, "PackUp", PackUp);
        }

        #region Messenger

        /// <summary>
        /// 收起面板
        /// </summary>
        /// <param name="ischecked"></param>
        public void PackUp(bool ischecked)
        {
            MenuToggleButton.IsChecked = ischecked;
        }

        /// <summary>
        /// 最大化
        /// </summary>
        /// <param name="msg"></param>
        public void Max(bool Mask = false)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        #endregion
        
    }
}
