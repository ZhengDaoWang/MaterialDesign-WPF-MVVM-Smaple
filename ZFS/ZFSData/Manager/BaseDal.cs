using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZFSData.InterFace;
using System.Data;
using System.Data.Entity.Infrastructure;
using ZFS.Model;
using ZFS.Library;

namespace ZFSData.Manager
{
    /// <summary>
    /// 基类实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDal<T> where T : class, new()
    {
        ZFSConfig Db = new ZFSConfig();

        /// <summary>
        /// 查询过滤
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            try
            {
                var Task = Db.Set<T>().Where<T>(whereLambda).ToListAsync();
                var List = await Task;
                return new ServiceResponse() { Success = true, Results = List };
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("查询数据", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderbyLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> GetPagingModels(int pageIndex, int pageSize,
            Expression<Func<T, bool>> whereLambda,
            Expression<Func<T, int>> orderLambda,
            bool Asc = true)
        {
            try
            {
                var temp = Db.Set<T>().Where<T>(whereLambda).OrderBy(orderLambda)
                .Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize).ToListAsync();
                var tempTask = await temp;
                int totalCount = Db.Set<T>().Where<T>(whereLambda).Count();
                return new ServiceResponse() { Success = true, Results = tempTask, TotalCount = totalCount };
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("查询数据-分页", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> DeleteEntity(T entity)
        {
            try
            {
                Db.Entry<T>(entity).State = EntityState.Deleted;
                var task = await Db.SaveChangesAsync();
                bool result = task > 0 ? true : false;
                return new ServiceResponse() { Success = result };
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("删除", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> UpdateEntity(T entity)
        {
            try
            {
                DbEntityEntry entry = Db.Entry<T>(entity);
                entry.State = EntityState.Modified;
                var task = await Db.SaveChangesAsync();
                bool result = task > 0 ? true : false;
                return new ServiceResponse() { Success = result };
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("新增", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }
        }


        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> AddEntity(T entity)
        {
            try
            {
                Db.Set<T>().Add(entity);
                var task = await Db.SaveChangesAsync();
                bool result = task > 0 ? true : false;
                return new ServiceResponse() { Success = result };
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("添加", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> ExistEntity(Expression<Func<T, bool>> whereLambda)
        {
            try
            {
                var task = await Db.Set<T>().Where<T>(whereLambda).CountAsync();
                bool result = task > 0 ? true : false;
                return new ServiceResponse() { Success = result };
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("验证是否存在", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }
        }
    }
}
