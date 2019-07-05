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
        /// 获取用户组集合
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<byte[]> GetGroups(string search)
        {
            var GroupList = await new GroupManager().GetGroups(search);
            byte[] bytes = ZipTools.CompressionObject(GroupList);
            return bytes;
        }

        /// <summary>
        /// 获取指定组用户
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public async Task<byte[]> GetGroupUsers(string groupID)
        {
            var userViewList = await new GroupManager().GetGroupUsers(groupID);
            byte[] bytes = ZipTools.CompressionObject(userViewList);
            return bytes;
        }

        /// <summary>
        /// 获取指定组所含权限
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        public async Task<byte[]> GetGroupFuncs(string groupCode)
        {
            var gpFuncList = await new GroupManager().GetGroupFuncs(groupCode);
            byte[] bytes = ZipTools.CompressionObject(gpFuncList);
            return bytes;
        }

        /// <summary>
        /// 更新用户组权限
        /// </summary>
        /// <param name="group"></param>
        /// <param name="userList"></param>
        /// <param name="funcList"></param>
        /// <returns></returns>
        public async Task<byte[]> UpdateGroupFunc(byte[] group, byte[] userList, byte[] funcList)
        {
            var Group = ZipTools.DecompressionObject(group) as tb_Group;
            var Userlist = ZipTools.DecompressionObject(userList) as List<View_GroupUser>;
            var FuncList = ZipTools.DecompressionObject(funcList) as List<tb_GroupFunc>;
            var result = await new GroupManager().UpdateGroupFunc(Group, Userlist, FuncList);
            return ZipTools.CompressionObject(result);
        }

        /// <summary>
        /// 删除组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<byte[]> RemovebyGroup(int id)
        {
            var result = await new GroupManager().Remove(id);
            return ZipTools.CompressionObject(result);
        }

        /// <summary>
        /// 条件查询数据
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<byte[]> GetModelsByGroup(byte[] search)
        {
            var Group = ZipTools.DecompressionObject(search) as tb_Group;
            var gpFuncList = await new GroupManager().GetModels(Group);
            byte[] bytes = ZipTools.CompressionObject(gpFuncList);
            return bytes;
        }

        /// <summary>
        /// 获取组-分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="search"></param>
        /// <param name="Asc"></param>
        /// <returns></returns>
        public async Task<byte[]> GetPagingModelsByGroup(int pageIndex, int pageSize,
            byte[] search,
            bool Asc = false)
        {
            var Group = ZipTools.DecompressionObject(search) as tb_Group;
            var gpFuncList = await new GroupManager().GetPagingModels(pageIndex, pageSize, Group, Asc);
            byte[] bytes = ZipTools.CompressionObject(gpFuncList);
            return bytes;
        }

        /// <summary>
        /// 删除组
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<byte[]> DeleteEntityByGroup(byte[] entity)
        {
            var Group = ZipTools.DecompressionObject(entity) as tb_Group;
            var result = await new GroupManager().DeleteEntity(Group);
            return ZipTools.CompressionObject(result);
        }

        /// <summary>
        /// 更新组
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<byte[]> UpdateEntityByGroup(byte[] entity)
        {
            var Group = ZipTools.DecompressionObject(entity) as tb_Group;
            var result = await new GroupManager().UpdateEntity(Group);
            return ZipTools.CompressionObject(result);
        }

        /// <summary>
        /// 新增组
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<byte[]> AddEntityByGroup(byte[] entity)
        {
            var Group = ZipTools.DecompressionObject(entity) as tb_Group;
            var result = await new GroupManager().AddEntity(Group);
            byte[] bytes = ZipTools.CompressionObject(result);
            return bytes;
        }

        /// <summary>
        /// 检查组是否存在
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<byte[]> ExistEntityByGroup(byte[] search)
        {
            var Group = ZipTools.DecompressionObject(search) as tb_Group;
            var result = await new GroupManager().ExistEntity(Group);
            return ZipTools.CompressionObject(result);
        }
    }
}
