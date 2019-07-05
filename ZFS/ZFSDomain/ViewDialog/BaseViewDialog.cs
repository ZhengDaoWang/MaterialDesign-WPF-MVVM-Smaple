using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ZFS.ILayer.Base;
using ZFSDomain.SysModule;

namespace ZFSDomain.ViewDialog
{
    public class BaseViewDialog<T> : IModelDialog where T : new()
    {
        public T TView;

        /// <summary>
        /// 绑定数据上下文(主动)
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="viewModel"></param>
        public virtual void BindViewModel<TViewModel>(TViewModel viewModel)
        {
            var dialog = GetDialog();
            (dialog as UserControl).DataContext = viewModel;
        }

        /// <summary>
        /// 获取视图页
        /// </summary>
        /// <returns></returns>
        public virtual object GetDialog()
        {
            if (TView == null)
            {
                TView = new T();
                this.RegisterDefaultEvent();
            }
            return TView;
        }

        /// <summary>
        /// 弹出窗口
        /// </summary>
        /// <param name="openedEventHandler"></param>
        /// <param name="closingEventHandler"></param>
        /// <returns></returns>
        public async virtual Task<bool> ShowDialog(DialogOpenedEventHandler openedEventHandler = null, DialogClosingEventHandler closingEventHandler = null)
        {
            var dialog = GetDialog();
            object taskResult = await DialogHost.Show(dialog, "RootDialog", openedEventHandler, closingEventHandler); //位于顶级窗口
            return (bool)taskResult;
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        public virtual void Close() { }

        /// <summary>
        /// 注册窗口默认事件
        /// </summary>
        public virtual void RegisterDefaultEvent()
        {

        }
    }
}
