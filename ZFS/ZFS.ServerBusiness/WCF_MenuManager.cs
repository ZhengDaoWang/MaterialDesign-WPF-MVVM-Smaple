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
    public class WCF_MenuManager : WCF_BaseManager<WCF_MenuManager>, IMenu
    {
        public async Task<ServiceResponse> AddEntity(tb_Menu entity)
        {
            var bytes =await Server.AddEntityByMenuAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> DeleteEntity(tb_Menu entity)
        {
            var bytes =await Server.DeleteEntityByMenuAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> ExistEntity(tb_Menu entity)
        {
            var bytes =await Server.ExistEntityByMenuAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetMenuTrees()
        {
            var bytes =await Server.GetMenuTreesAsync();
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetModels(tb_Menu search)
        {
            var bytes =await Server.GetModelsByMenuAsync(ZipTools.CompressionObject(search));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetPagingModels(int pageIndex, int pageSize, tb_Menu search, bool Asc = false)
        {
            var bytes =await Server.GetPagingModelsByMenuAsync(pageIndex,pageSize,ZipTools.CompressionObject(search),Asc);
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> UpdateEntity(tb_Menu entity)
        {
            byte[] bytes =await Server.UpdateEntityByMenuAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> UpdateMenus(List<tb_Menu> tb_Menus)
        {
            byte[] bytes =await Server.UpdateMenusAsync(ZipTools.CompressionObject(tb_Menus));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }
    }
}
