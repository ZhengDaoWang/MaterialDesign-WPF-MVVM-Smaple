using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;

namespace ZFS.Library.Helper
{
    /// <summary>
    /// 模块组
    /// </summary>
    public class ModuleGroup : ViewModelBase
    {
        private int groupid;
        private string _groupIcon= "BlockHelper";
        private string groupName;
        private ModuleType _moduleType;
        private ObservableCollection<Module> modules;

        /// <summary>
        /// 模块ICO
        /// </summary>
        public string GroupIcon
        {
            get { return _groupIcon; }
            set { _groupIcon = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 模块类型
        /// </summary>
        public ModuleType ModuleType
        {
            get { return _moduleType; }
            set { _moduleType = value; RaisePropertyChanged(); }
        }
        
        /// <summary>
        /// 父模块ID
        /// </summary>
        public int GroupId
        {
            get { return groupid; }
            set { groupid = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 父模块名称
        /// </summary>
        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 子模块集合
        /// </summary>
        public ObservableCollection<Module> Modules
        {
            get { return modules; }
            set { modules = value; RaisePropertyChanged(); }
        }
    }

    /// <summary>
    /// 模块类
    /// </summary>
    public class Module
    {
        public Module(string Name,string Desc,int? Auth,string NameSpace,string Icon)
        {
            _Name = Name;
            _Desc = Desc;
            _Authorities = Auth;
            _ModNameSpcae= NameSpace;
            _Icon = Icon;
        }

        private string _Name;
        private string _Desc;
        private int? _Authorities;
        private string _ModNameSpcae;
        private string _Icon;


        /// <summary>
        /// 图标-IconFont
        /// </summary>
        public string ICON
        {
            get { return _Icon; }
        }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
        }
        
        /// <summary>
        /// ICON
        /// </summary>
        public string Desc
        {
            get { return _Desc; }
        }

        /// <summary>
        /// 模块命名空间
        /// </summary>
        public string ModNameSpcae
        {
            get { return _ModNameSpcae; }
        }
        
        /// <summary>
        /// 权限值
        /// </summary>
        public int? Authorities
        {
            get { return _Authorities; }
        }

    }
}
