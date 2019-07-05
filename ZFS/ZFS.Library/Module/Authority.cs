using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Library.Helper
{
    /// <summary>
    /// 权限值定义
    /// </summary>
    public class Authority
    {
        /// <summary>
        /// 新增
        /// </summary>
        public const int ADD = 1;

        /// <summary>
        /// 编辑
        /// </summary>
        public const int EDIT = 2;

        /// <summary>
        /// 删除
        /// </summary>
        public const int DELETE = 4;

        /// <summary>
        /// 导入
        /// </summary>
        public const int IMPORT = 8;
    }
}
