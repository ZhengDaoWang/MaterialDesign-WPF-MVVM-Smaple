using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Library.Helper;
using ZFS.Model;
using ZFSData.InterFace;

namespace ZFS.ServerBusiness
{
    public class WCF_DictionTypeManager : WCF_BaseManager<WCF_DictionTypeManager>, IDictionaryType
    {
        public async Task<ServiceResponse> AddEntity(tb_DictionaryType entity)
        {
            var bytes =await Server.AddEntityByDicAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> DeleteEntity(tb_DictionaryType entity)
        {
            var bytes =await Server.DeleteEntityByDicAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> ExistEntity(tb_DictionaryType entity)
        {
            var bytes =await Server.ExistEntityByDicAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetDictionaryTypes()
        {
            var bytes =await Server.GetDictionarysAsync();
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetModels(tb_DictionaryType search)
        {
            var bytes =await Server.GetModelsByDicAsync(ZipTools.CompressionObject(search));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> GetPagingModels(int pageIndex, int pageSize, tb_DictionaryType search, bool Asc = false)
        {
            var bytes =await Server.GetPagingModelsByDicAsync(pageIndex, pageSize, ZipTools.CompressionObject(search), Asc);
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }

        public async Task<ServiceResponse> UpdateEntity(tb_DictionaryType entity)
        {
            byte[] bytes =await Server.UpdateEntityByDicAsync(ZipTools.CompressionObject(entity));
            ServiceResponse response = ZipTools.DecompressionObject(bytes) as ServiceResponse;
            return response;
        }
    }
}
