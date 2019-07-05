using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Library.Generator
{
    public interface IGeneratorToClass
    {
        /// <summary>
        /// 生成实体数据模型
        /// </summary>
        /// <param name="nameSpace">命名空间</param>
        /// <param name="desc">类说明</param>
        /// <param name="className">类说明</param>
        /// <param name="body">类主体</param>
        /// <returns>实体模型</returns>
        string Create(string nameSpace, string desc, string className, string body);

    }
}
