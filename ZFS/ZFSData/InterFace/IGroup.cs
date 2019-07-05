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
    /// 用户组接口
    /// </summary>
    public interface IGroup: IBaseDal<tb_Group>
    {
        /// <summary>
        /// 获取用户组集合
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ServiceResponse> GetGroups(string search);

        /// <summary>
        /// 获取指定组用户
        /// </summary>
        /// <param name="groupCode">组代码</param>
        /// <returns></returns>
        Task<ServiceResponse> GetGroupUsers(string groupID);

        /// <summary>
        /// 获取指定组所含权限
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        Task<ServiceResponse> GetGroupFuncs(string groupCode);

        /// <summary>
        ///  更新用户组权限
        /// </summary>
        /// <param name="group"></param>
        /// <param name="userList"></param>
        /// <param name="funcList"></param>
        /// <returns></returns>
        Task<ServiceResponse> UpdateGroupFunc(tb_Group group, List<View_GroupUser> userList, List<tb_GroupFunc> funcList);

        /// <summary>
        /// 删除组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse> Remove(int id);
    }
}
