using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZFS.Generator.ViewModel
{
    /// <summary>
    ///  加载模块管理器
    /// </summary>
    public class SplashManager : ViewModelBase
    {
        private bool _MainIsEnable = true;
        private bool _PaneliSHide = true;
        private string _WaitInfo = string.Empty;

        /// <summary>
        /// 首页禁用
        /// </summary>
        public bool MainIsEnable
        {
            get { return _MainIsEnable; }
            set { _MainIsEnable = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 等待面板是否显示
        /// </summary>
        public bool PaneliSHide
        {
            get { return _PaneliSHide; }
            set { _PaneliSHide = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 加载信息
        /// </summary>
        public string WaitInfo
        {
            get { return _WaitInfo; }
            set { _WaitInfo = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 等待
        /// </summary>
        /// <param name="info"></param>
        public void Show(string info = "正在加载,请稍候...")
        {
            WaitInfo = info;
            PaneliSHide = false;
            MainIsEnable = false;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            MainIsEnable = true;
            PaneliSHide = true;
        }

        public void ShowDefault(string info)
        {
            Task.Run(() =>
            {
                this.Show(info);
                Thread.Sleep(500);
                this.Close();
            });
        }
    }
}
