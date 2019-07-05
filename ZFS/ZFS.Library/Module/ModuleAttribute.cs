using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Library
{
    /// <summary>
    /// 模块类型
    /// </summary>
    public enum ModuleType
    {
        [Desc("未定义")]
        None = 0,

        [Desc("基础模块")]
        System = 1,

        [Desc("亚马逊Amazon")]
        Amazon = 2,

        [Desc("沃尔玛Walmart")]
        Walmart = 3,

        [Desc("百思买BestBuy")]
        BestBuy = 4,

        [Desc("易趣网eBay")]
        eBay = 5,

        [Desc("下载中心")]
        Download = 6,

    }

    /// <summary>
    /// 模块特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ModuleAttribute : Attribute
    {
        /// <summary>
        /// 模块构造函数
        /// </summary>
        /// <param name="code">模块编码</param>
        /// <param name="name">模块名称</param>
        /// <param name="remark">模块说明</param>
        /// <param name="authority">模块包含权限值(SUM)</param>
        public ModuleAttribute(ModuleType type, string code,
            string name, string remark, string Namespace, int authority, string icon)
        {
            _Code = code;
            _Name = name;
            _Remark = remark;
            _Authority = authority;
            _ModuleType = type;
            _ModuleNameSpace = Namespace;
            _ICON = icon;
        }

        #region private

        private string _Code;
        private string _Name;
        private int _Authority;
        private string _ModuleNameSpace;
        private string _Remark;
        private ModuleType _ModuleType;
        private string _ICON;

        #endregion

        #region 只读属性

        /// <summary>
        /// 图标
        /// </summary>
        public string ICON
        {
            get { return _ICON; }
        }

        /// <summary>
        /// Dlg中间层命名空间
        /// </summary>
        public string ModuleNameSpace
        {
            get { return _ModuleNameSpace; }
        }

        /// <summary>
        /// 菜单类
        /// </summary>
        public string Code
        {
            get { return _Code; }
        }

        /// <summary>
        /// 菜单名
        /// </summary>
        public string Name
        {
            get { return _Name; }
        }

        /// <summary>
        /// 功能权限值
        /// </summary>
        public int Autority
        {
            get { return _Authority; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
        }

        /// <summary>
        /// 模块类型
        /// </summary>
        public ModuleType ModuleType
        {
            get { return _ModuleType; }
        }

        #endregion
    }


    /// <summary>
    /// 模块类型特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class DescAttribute : Attribute
    {
        protected string _ModuleName = string.Empty;
        protected string _ModuleIcon = string.Empty;

        public string ModuleName { get { return _ModuleName; } }
        public string ModuleIcon { get { return _ModuleIcon; } }

        public DescAttribute(string caption, string ico = "BorderAll")
        {
            this._ModuleName = caption;
            this._ModuleIcon = ico;
        }

    }
}
