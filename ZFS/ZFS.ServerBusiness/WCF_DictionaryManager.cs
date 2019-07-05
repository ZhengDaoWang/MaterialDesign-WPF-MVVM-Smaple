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
using ZFSData.InterFace;

namespace ZFS.ServerBusiness
{
    public class WCF_DictionaryManager : WCF_BaseManager<WCF_DictionaryManager>, IDictionary
    {
        public async Task<ServiceResponse> AddEntity(tb_Dictionary entity)
        {
            var bytes =await Server.AddEntityByDicAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> DeleteEntity(tb_Dictionary entity)
        {
            var bytes =await Server.DeleteEntityByDicAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> ExistEntity(tb_Dictionary entity)
        {
            var bytes =await Server.ExistEntityByDicAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetDictionarys()
        {
            var bytes =await Server.GetDictionarysAsync();
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetModels(tb_Dictionary search)
        {
            var bytes =await Server.GetModelsByDicAsync(ZipTools.CompressionObject(search));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetPagingModels(int pageIndex, int pageSize, tb_Dictionary search, bool Asc = false)
        {
            var bytes =await Server.GetPagingModelsByDicAsync(pageIndex, pageSize, ZipTools.CompressionObject(search), Asc);
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> UpdateEntity(tb_Dictionary entity)
        {
            byte[] bytes=await Server.UpdateEntityByDicAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }
    }
}
