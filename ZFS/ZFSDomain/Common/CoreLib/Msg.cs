using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.ILayer.Base;
using ZFS.Library.Helper;
using ZFSDomain.Common.CoreLib.Helper;
using ZFSDomain.Service;
using ZFSDomain.ViewModel.Step;

namespace ZFSDomain.Common.CoreLib
{
    public enum Notify
    {
        /// <summary>
        /// 错误
        /// </summary>
        [Description("错误")]
        Error,
        /// <summary>
        /// 警告
        /// </summary>
        [Description("警告")]
        Warning,
        /// <summary>
        /// 提示信息
        /// </summary>
        [Description("提示信息")]
        Info,
        /// <summary>
        /// 询问信息
        /// </summary>
        [Description("询问信息")]
        Question,
    }

    /// <summary>
    /// 消息类
    /// </summary>
    public class Msg
    {

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="msg"></param>
        public static async void Error(string ex, bool Host = true)
        {
            await Show(Notify.Error, ex, Host);
        }

        /// <summary>
        /// 信息提示
        /// </summary>
        /// <param name="msg"></param>
        public static async void Info(string ex, bool Host = true)
        {
            await Show(Notify.Info, ex, Host);
        }

        /// <summary>
        /// 真香警告
        /// </summary>
        /// <param name="msg"></param>
        public static async void Warning(string ex, bool Host = true)
        {
            await Show(Notify.Warning, ex, Host);
        }

        /// <summary>
        /// 真香询问
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static async Task<bool> Question(string ex, bool Host = true)
        {
            return await Show(Notify.Question, ex, Host);
        }

        /// <summary>
        /// 弹出窗口
        /// </summary>
        /// <param name="notify">类型</param>
        /// <param name="msg">文本信息</param>
        /// <returns></returns>
        private static async Task<bool> Show(Notify notify, string msg, bool Host = true)
        {
            string Icon = string.Empty;
            string Color = string.Empty;
            bool Hide = true;
            switch (notify)
            {
                case Notify.Error:
                    Icon = "CommentRemoveOutline";
                    Color = "#FF4500";
                    break;
                case Notify.Warning:
                    Icon = "CommentWarning";
                    Color = "#FF8247";
                    break;
                case Notify.Info:
                    Icon = "CommentProcessingOutline";
                    Color = "#1C86EE";
                    break;
                case Notify.Question:
                    Icon = "CommentQuestionOutline";
                    Color = "#20B2AA";
                    Hide = false;
                    break;
            }

            if (Host)
            {
                MsgHostBoxViewModel msgBox = new MsgHostBoxViewModel();
                var dialog = ServiceProvider.Instance.Get<IModelDialog>("MsgHostBoxViewDlg");
                dialog.BindViewModel(new MsgHostBoxViewModel() { Msg = msg, Icon = Icon, Color = Color, BtnHide = Hide });
                var TaskResult = await dialog.ShowDialog(null,msgBox.ExtendedClosingEventHandler);
                if (TaskResult)
                {
                    return true;
                }
                return false;
            }
            else
            {
                MsgBoxViewModel msgBox = new MsgBoxViewModel();
                var dialog = ServiceProvider.Instance.Get<IModelDialog>("MsgBoxViewDlg");
                dialog.BindViewModel(new MsgBoxViewModel() { Msg = msg, Icon = Icon, Color = Color, BtnHide = Hide });
                var TaskResult = await dialog.ShowDialog();
                if (TaskResult)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 全局异常处理
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="notify"></param>
        /// <returns></returns>
        public static void Error(Exception ex, Notify notify = Notify.Error)
        {
            string Icon = string.Empty;
            string Color = string.Empty;
            bool Hide = true;
            switch (notify)
            {
                case Notify.Error:
                    Icon = "\xe676";
                    Color = "#FF4500";
                    break;
                case Notify.Warning:
                    Icon = "\xe623";
                    Color = "#FF8247";
                    break;
                case Notify.Info:
                    Icon = "\xe764";
                    Color = "#1C86EE";
                    break;
                default:
                    Icon = "\xe676";
                    Color = "#FF4500";
                    break;
            }
            MsgHostBoxViewModel msgBox = new MsgHostBoxViewModel();
            var dialog = ServiceProvider.Instance.Get<IModelDialog>("MsgHostBoxViewDlg");
            string msg = ExceptionLibrary.GetErrorMsgByExpId(ex);
            dialog.BindViewModel(new MsgHostBoxViewModel()
            {
                Msg = msg,
                Icon = Icon,
                Color = Color,
                BtnHide = Hide
            });
            dialog.ShowDialog(null,msgBox.ExtendedClosingEventHandler);
        }
    }


}
