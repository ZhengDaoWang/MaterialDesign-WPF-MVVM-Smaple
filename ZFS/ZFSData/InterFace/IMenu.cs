using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Model;

namespace ZFSData.InterFace.User
{
    /// <summary>
    /// 菜单接口
    /// </summary>
    public interface IMenu: IBaseDal<tb_Menu>
    {
        /// <summary>
        /// 获取菜单树
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse> GetMenuTrees();

        /// <summary>
        /// 新增更新模块
        /// </summary>
        /// <param name="tb_Menus"></param>
        /// <returns></returns>
        Task<ServiceResponse> UpdateMenus(List<tb_Menu> tb_Menus);

    }
}
