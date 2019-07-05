using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Model;
using ZFSInterface.User;

namespace ZFSData.Manager
{

    /// <summary>
    /// 用户管理器 
    /// </summary>
    public class UserManager : BaseDal<tb_User>, IUser
    {
        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="account"></param>
        public async Task<ServiceResponse> Logout(string account)
        {
            try
            {
                using (var db = new ZFSConfig())
                {
                    var model = db.tb_User.FirstOrDefault(t => t.Account.Equals(account));
                    model.FlagOnline = "0";
                    DbEntityEntry dbEntity = db.Entry<tb_User>(model);
                    dbEntity.State = System.Data.Entity.EntityState.Modified;
                    var task = await db.SaveChangesAsync();
                    bool result = task > 0 ? true : false;
                    return new ServiceResponse() { Success = result };
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("登出", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }
        }

        /// <summary>
        /// 登录系统
        /// </summary>
        /// <param name="Account">账号</param>
        /// <param name="Password">密码</param>
        /// <returns>信息</returns>
        public async Task<ServiceResponse> Login(string Account, string Password)
        {
            try
            {
                using (var db = new ZFSConfig())
                {
                    var task = await Task.Run(() =>
                    {
                        return db.tb_User.FirstOrDefault(
                            q => q.Account.Equals(Account) &&
                            q.Password.Equals(Password));
                    });
                    bool result = task != null ? true : false;
                    if (result)
                        return new ServiceResponse() { Success = result, Results = task };
                    else
                        return new ServiceResponse() { Success = result, Message = "账号或密码错误,请确认!" };
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("登录错误", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }
        }

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> GetAuthority(string account)
        {
            try
            {
                using (var db = new ZFSConfig())
                {
                    var task = await Task.Run(() =>
                      {
                          return db.View_UserAuthority.Where(t => t.Account.Equals(account)).ToList();
                      });
                    return new ServiceResponse() { Success = true, Results = task };
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("获取用户权限", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }
        }

        public async Task<ServiceResponse> GetModelByAccount(string account)
        {
            try
            {
                using (var db = new ZFSConfig())
                {
                    var task = await Task.Run(() =>
                    {
                        return db.tb_User.AsNoTracking().FirstOrDefault(q => q.Account.Equals(account));
                    });
                    return new ServiceResponse() { Success = true, Results = task };
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("账户获取账户信息", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }
        }

        public async Task<ServiceResponse> GetModels(tb_User search)
        {
            return await base.GetModels(ExpressionHelper.GenerateQueryExp(search));
        }

        public async Task<ServiceResponse> GetPagingModels(int pageIndex, int pageSize, tb_User search, bool Asc = false)
        {
            Expression<Func<tb_User, int>> orderexp = x => x.isid;
            return await base.GetPagingModels(pageIndex, pageSize, ExpressionHelper.GenerateQueryExp(search), orderexp, Asc);
        }

        public async Task<ServiceResponse> ExistEntity(tb_User entity)
        {
            return await base.ExistEntity(ExpressionHelper.GenerateQueryExp(entity));
        }
    }
}
