using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.ILayer
{
    /// <summary>
    /// 数据操作接口 - CURD
    /// </summary>
    public interface IDataOperation
    {
        /// <summary>
        /// 新增
        /// </summary>
        void Add<TModel>(TModel model);

        /// <summary>
        /// 编辑
        /// </summary>
        void Edit<TModel>(TModel model);

        /// <summary>
        /// 删除
        /// </summary>
        void Del<TModel>(TModel model);

        /// <summary>
        /// 查询
        /// </summary>
        void Query();

        /// <summary>
        /// 重置
        /// </summary>
        void Reset();

    }
}
