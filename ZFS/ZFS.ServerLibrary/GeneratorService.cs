using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Library.Generator;
using ZFS.Library.Helper;
using ZFSData.Manager;

namespace ZFS.ServerLibrary
{
    partial class BaseService : IBaseService
    {
        /// <summary>
        /// 获取表OR视图
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> GetUvs()
        {
            var result = await new GeneratorManager().GetUvs();
            byte[] bytes = ZipTools.CompressionObject(result);
            return bytes;
        }

        /// <summary>
        /// 获取表结构
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public async Task<byte[]> GetTableStatus(string tableName, string nameSpace, string desc)
        {
            var result = await new GeneratorManager().GetTableStructs(tableName, nameSpace, desc);
            byte[] bytes = ZipTools.CompressionObject(result);
            return bytes;
        }
    }
}
