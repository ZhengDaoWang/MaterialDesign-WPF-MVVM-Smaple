using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Library.Generator;

namespace ZFSData.InterFace
{
    public interface IGenerator
    {
        /// <summary>
        /// 获取数据库表
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse> GetUvs();

        /// <summary>
        /// 获取表结构
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="nameSpace">命名空间</param>
        /// <param name="desc">注释</param>
        /// <returns></returns>
        Task<ServiceResponse> GetTableStructs(string tableName,string nameSpace,string desc);

    }
}
