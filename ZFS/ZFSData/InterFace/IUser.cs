using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Model;
using ZFSData;
using ZFSData.InterFace;

namespace ZFSInterface.User
{

    /// <summary>
    /// 用户数据操作接口
    /// </summary>
    public interface IUser : IBaseDal<tb_User>
    {
        /// <summary>
        /// 根据账户获取账户信息
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns>结果</returns>
        Task<ServiceResponse> GetModelByAccount(string account);

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="account">账号</param>
        Task<ServiceResponse> Logout(string account);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns>用户信息</returns>
        Task<ServiceResponse> Login(string account, string password);

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Task<ServiceResponse> GetAuthority(string account);
    }
}
