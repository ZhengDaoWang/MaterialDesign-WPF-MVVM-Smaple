using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Library.Helper
{
    /// <summary>
    /// 模块信息
    /// </summary>
    public class ModuleInfo
    {
        private Assembly _ModuleAssembly = null;
        private string _ModuleName = string.Empty;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="asm">模块的程序集</param>
        /// <param name="name">模块名称</param>
        public ModuleInfo(Assembly asm,  string name)
        {
            _ModuleAssembly = asm;
            _ModuleName = name;
        }

        /// <summary>
        /// 加载DLL文件后存储程序集的对象引用
        /// </summary>
        public Assembly ModuleAssembly
        {
            get { return _ModuleAssembly; }
            set { _ModuleAssembly = value; }
        }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName
        {
            get { return _ModuleName; }
            set { _ModuleName = value; }
        }
    }
}
