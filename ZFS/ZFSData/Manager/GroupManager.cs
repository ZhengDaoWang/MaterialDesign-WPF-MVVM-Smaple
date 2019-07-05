using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Model;
using ZFSData.InterFace.User;

namespace ZFSData.Manager
{

    /// <summary>
    /// 组管理 
    /// </summary>
    public class GroupManager : BaseDal<tb_Group>, IGroup
    {
        public async Task<ServiceResponse> ExistEntity(tb_Group entity)
        {
            return await base.ExistEntity(ExpressionHelper.GenerateQueryExp(entity));
        }

        /// <summary>
        /// 获取指定组权限
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> GetGroupFuncs(string groupCode)
        {
            try
            {
                using (var db = new ZFSConfig())
                {
                    var task = await Task.Run(() =>
                     {
                         return db.tb_GroupFunc.Where(q => q.GroupCode.Equals(groupCode)).ToList();
                     });
                    return new ServiceResponse() { Success = true, Results = task };
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("获取指定组所含权限", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }

        }

        /// <summary>
        /// 获取用户组
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> GetGroups(string search)
        {
            try
            {
                using (var db = new ZFSConfig())
                {
                    var task = await Task.Run(() =>
                     {
                         return db.tb_Group.Where(q => q.GroupName.Contains(search) || q.GroupCode.Contains(search)).ToList();
                     });
                    return new ServiceResponse() { Success = true, Results = task };
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("获取用户组集合", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }
        }

        /// <summary>
        /// 获取指定组用户
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> GetGroupUsers(string groupCode)
        {
            try
            {
                using (var db = new ZFSConfig())
                {
                    var task = await Task.Run(() =>
                      {
                          return db.View_GroupUser.Where(q => q.GroupCode.Equals(groupCode)).ToList();
                      });
                    return new ServiceResponse() { Success = true, Results = task };
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("获取指定组用户", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }
        }

        public async Task<ServiceResponse> GetModels(tb_Group search)
        {
            return await base.GetModels(ExpressionHelper.GenerateQueryExp(search));
        }

        public async Task<ServiceResponse> GetPagingModels(int pageIndex, int pageSize, tb_Group search, bool Asc = false)
        {
            Expression<Func<tb_Group, int>> orderexp = x => x.isid;
            return await base.GetPagingModels(pageIndex, pageSize, ExpressionHelper.GenerateQueryExp(search), orderexp, Asc);
        }

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> Remove(int id)
        {
            try
            {
                using (var db = new ZFSConfig())
                {
                    var group = db.tb_Group.FirstOrDefault(q => q.isid.Equals(id));
                    db.tb_Group.Remove(group);
                    var users = db.tb_GroupUser.Where(q => q.GroupCode.Equals(group.GroupCode)).ToList();
                    users.ForEach(t => db.tb_GroupUser.Remove(t));
                    var funcs = db.tb_GroupFunc.Where(q => q.GroupCode.Equals(group.GroupCode)).ToList();
                    funcs.ForEach(t => db.tb_GroupFunc.Remove(t));
                    var task = await db.SaveChangesAsync();
                    bool result = task > 0 ? true : false;
                    return new ServiceResponse() { Success = result };
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("删除组", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }

        }

        /// <summary>
        /// 更新组用户权限
        /// </summary>
        /// <param name="funcList"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> UpdateGroupFunc(tb_Group group, List<View_GroupUser> userList, List<tb_GroupFunc> funcList)
        {
            try
            {
                using (var db = new ZFSConfig())
                {

                    if (group.isid.Equals(0))
                    {
                        db.tb_Group.Add(group);
                    }
                    else
                    {
                        var Group = db.tb_Group.FirstOrDefault(t => t.isid.Equals(group.isid));
                        Group.GroupName = group.GroupName;
                        DbEntityEntry dbEntity = db.Entry<tb_Group>(Group);
                        dbEntity.State = System.Data.Entity.EntityState.Modified;
                    }
                    //2.更新组用户
                    var GroupUsers = db.tb_GroupUser.Where(t => t.GroupCode.Equals(group.GroupCode)).ToList();
                    foreach (var item in GroupUsers)
                    {
                        db.tb_GroupUser.Remove(item);
                    }
                    userList.ForEach(t =>
                    {
                        db.tb_GroupUser.Add(new tb_GroupUser()
                        {
                            Account = t.Account,
                            GroupCode = group.GroupCode //组编号
                        });
                    });
                    //3.更新组权限
                    var groupList = db.tb_GroupFunc.Where(t => t.GroupCode.Equals(group.GroupCode)).ToList();

                    foreach (var item in groupList)
                    {
                        db.tb_GroupFunc.Remove(item);
                    }
                    funcList.ForEach(t =>
                    {
                        db.tb_GroupFunc.Add(t);
                    });
                    var task = await db.SaveChangesAsync();
                    bool result = task > 0 ? true : false;
                    return new ServiceResponse() { Success = result };
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("更新用户组权限", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }

        }
    }
}
