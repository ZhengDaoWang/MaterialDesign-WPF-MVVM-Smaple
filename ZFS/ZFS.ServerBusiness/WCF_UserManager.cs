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
using ZFSInterface.User;

namespace ZFS.ServerBusiness
{
    public class WCF_UserManager : WCF_BaseManager<WCF_UserManager>, IUser
    {
        public async Task<ServiceResponse> AddEntity(tb_User entity)
        {
            var result = await Server.AddEntityByUserAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(result) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> DeleteEntity(tb_User entity)
        {
            var result = await Server.DeleteEntityByUserAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(result) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> ExistEntity(tb_User entity)
        {
            byte[] result = await Server.ExistEntityByUserAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(result) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetAuthority(string account)
        {
            var bytes = await Server.GetAuthorityAsync(account);
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetModelByAccount(string account)
        {
            var bytes = await Server.GetModelByAccountAsync(account);
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetModels(tb_User search)
        {
            var bytes = await Server.GetModelsByUserAsync(ZipTools.CompressionObject(search));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetPagingModels(int pageIndex, int pageSize, tb_User search, bool Asc = false)
        {
            var bytes = await Server.GetPagingModelsByUserAsync(pageIndex, pageSize, ZipTools.CompressionObject(search), Asc);
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        /// <summary>
        /// 登录系统
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public async Task<ServiceResponse> Login(string account, string password)
        {
            byte[] bytes = await Server.LoginAsync(account, password);
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> Logout(string account)
        {
            await Server.LogoutAsync(account);
            return null;
        }

        public async Task<ServiceResponse> UpdateEntity(tb_User entity)
        {
            byte[] bytes =await Server.UpdateEntityByUserAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }
    }
}
