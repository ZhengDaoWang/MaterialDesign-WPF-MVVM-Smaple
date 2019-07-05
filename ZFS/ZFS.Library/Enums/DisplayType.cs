using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;

namespace ZFS.Library.Enums
{
    /// <summary>
    /// 菜单类型
    /// </summary>
    public enum ContextMenuType
    {
        [Desc("列表模式")]
        ListMode,
        
        [Desc("磁贴模式")]
        MetroMode,

        //...

    }
    
}
