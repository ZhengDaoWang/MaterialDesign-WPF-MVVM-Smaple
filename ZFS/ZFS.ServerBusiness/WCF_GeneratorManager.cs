using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Library.Generator;
using ZFS.Library.Helper;
using ZFSData.InterFace;

namespace ZFS.ServerBusiness
{
    public class WCF_GeneratorManager : WCF_BaseManager<WCF_GeneratorManager>, IGenerator
    {
        public async Task<ServiceResponse> GetTableStructs(string tableName, string nameSpace, string desc)
        {
            var result =await Server.GetTableStatusAsync(tableName, nameSpace, desc);
            ServiceResponse response = ZipTools.DecompressionObject(result) as ServiceResponse;
            return response;
        }

        /// <summary>
        /// 获取表列表
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse> GetUvs()
        {
            var result =await Server.GetUvsAsync();
            ServiceResponse response = ZipTools.DecompressionObject(result) as ServiceResponse;
            return response;
        }
    }
}
