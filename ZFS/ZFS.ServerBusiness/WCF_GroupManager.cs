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
using ZFSData.InterFace.User;

namespace ZFS.ServerBusiness
{
    public class WCF_GroupManager : WCF_BaseManager<WCF_GroupManager>, IGroup
    {
        public async Task<ServiceResponse> AddEntity(tb_Group entity)
        {
            var bytes =await Server.AddEntityByGroupAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> DeleteEntity(tb_Group entity)
        {
            byte[] bytes =await Server.DeleteEntityByGroupAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> ExistEntity(tb_Group entity)
        {
            var bytes =await Server.ExistEntityByGroupAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetGroupFuncs(string groupCode)
        {
            var bytes =await Server.GetGroupFuncsAsync(groupCode);
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetGroups(string search)
        {
            var bytes =await Server.GetGroupsAsync(search);
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetGroupUsers(string groupID)
        {
            var bytes =await Server.GetGroupUsersAsync(groupID);
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetModels(tb_Group search)
        {
            var bytes =await Server.GetModelsByGroupAsync(ZipTools.CompressionObject(search));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetPagingModels(int pageIndex, int pageSize, tb_Group search, bool Asc = false)
        {
            var bytes =await Server.GetPagingModelsByUserAsync(pageIndex, pageSize, ZipTools.CompressionObject(search), Asc);
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> Remove(int id)
        {
            var bytes =await Server.RemovebyGroupAsync(id);
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> UpdateEntity(tb_Group entity)
        {
            var bytes =await Server.UpdateEntityByGroupAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> UpdateGroupFunc(tb_Group group, List<View_GroupUser> userList, List<tb_GroupFunc> funcList)
        {
            byte[] Group = ZipTools.CompressionObject(group);
            byte[] UserList = ZipTools.CompressionObject(userList);
            byte[] FuncList = ZipTools.CompressionObject(funcList);

            byte[] bytes =await Server.UpdateGroupFuncAsync(Group, UserList, FuncList);
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }
    }
}
