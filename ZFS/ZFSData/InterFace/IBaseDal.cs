using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;

namespace ZFSData.InterFace
{
    /// <summary>
    /// 基层DAL层
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseDal<T> where T : class, new()
    {
        /// <summary>
        /// 条件查询数据
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ServiceResponse> GetModels(T search);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ServiceResponse> GetPagingModels(int pageIndex, int pageSize, T search, bool Asc = false);

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ServiceResponse> DeleteEntity(T entity);

        /// <summary>
        /// 更新模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ServiceResponse> UpdateEntity(T entity);

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ServiceResponse> AddEntity(T entity);

        /// <summary>
        /// 检查模型是否存在
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ServiceResponse> ExistEntity(T entity);
    }
}
