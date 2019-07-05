using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Library.Helper;
using ZFS.Model;
using ZFSData;
using ZFSData.Manager;

namespace ZFS.ServerLibrary
{
    public partial class BaseService : IBaseService
    {

        /// <summary>
        /// 获取菜单树
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> GetMenuTrees()
        {
            var MenuList = await new MenuManager().GetMenuTrees();
            return ZipTools.CompressionObject(MenuList);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="MenusBytes"></param>
        /// <returns></returns>
        public async Task<byte[]> UpdateMenus(byte[] MenusBytes)
        {
            var MenuList = ZipTools.DecompressionObject(MenusBytes) as List<tb_Menu>;
            var result = await new MenuManager().UpdateMenus(MenuList);
            return ZipTools.CompressionObject(result);
        }

        /// <summary>
        /// 查询菜单列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<byte[]> GetModelsByMenu(byte[] search)
        {
            var MenuSearch = ZipTools.DecompressionObject(search) as tb_Menu;
            var MenuList = await new MenuManager().GetModels(MenuSearch);
            byte[] bytes = ZipTools.CompressionObject(MenuList);
            return bytes;
        }

        /// <summary>
        /// 查询菜单列表-分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="search"></param>
        /// <param name="Asc"></param>
        /// <returns></returns>
        public async Task<byte[]> GetPagingModelsByMenu(int pageIndex, int pageSize, byte[] search,
            bool Asc = false)
        {
            var MenuSearch = ZipTools.DecompressionObject(search) as tb_Menu;
            var MenuList = await new MenuManager().GetPagingModels(pageIndex, pageSize, MenuSearch, Asc);
            byte[] bytes = ZipTools.CompressionObject(MenuList);
            return bytes;
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<byte[]> DeleteEntityByMenu(byte[] entity)
        {
            var Menu = ZipTools.DecompressionObject(entity) as tb_Menu;
            var result = await new MenuManager().DeleteEntity(Menu);
            return ZipTools.CompressionObject(result);
        }

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<byte[]> UpdateEntityByMenu(byte[] entity)
        {
            var Menu = ZipTools.DecompressionObject(entity) as tb_Menu;
            var result = await new MenuManager().UpdateEntity(Menu);
            return ZipTools.CompressionObject(result);
        }

        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<byte[]> AddEntityByMenu(byte[] entity)
        {
            var Menu = ZipTools.DecompressionObject(entity) as tb_Menu;
            var NewMenu = await new MenuManager().UpdateEntity(Menu);
            return ZipTools.CompressionObject(NewMenu);
        }

        /// <summary>
        /// 检查菜单是否存在
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<byte[]> ExistEntityByMenu(byte[] entity)
        {
            var Menu = ZipTools.DecompressionObject(entity) as tb_Menu;
            var result = await new MenuManager().ExistEntity(Menu);
            return ZipTools.CompressionObject(result);
        }
    }
}
