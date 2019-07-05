using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Model;
using ZFSData;

namespace ZFSDomain.Common.CoreLib
{
    /// <summary>
    /// 登录用户信息
    /// </summary>
    public class Loginer : ViewModelBase
    {
        private Loginer() { }
        private static Loginer _Loginer = new Loginer(); //饿汉式单例

        /// <summary>
        /// 当前用户
        /// </summary>
        public static Loginer LoginerUser
        {
            get { return _Loginer; }
        }

        private string _Account = string.Empty;
        private string _UserName = string.Empty;
        private string _Email = string.Empty;
        private bool _Admin = false;
        private List<View_UserAuthority> _UserAuthority;

        /// <summary>
        /// 用户权限
        /// </summary>
        public List<View_UserAuthority> UserAuthority
        {
            get { return _UserAuthority; }
            set { _UserAuthority = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 登录名
        /// </summary>
        public string Account
        {
            get { return _Account; }
            set { _Account = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set { _UserName = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 是否属于管理员
        /// </summary>
        public bool IsAdmin
        {
            get { return _Admin; }
            set { _Admin = value; RaisePropertyChanged(); }
        }


    }
}
