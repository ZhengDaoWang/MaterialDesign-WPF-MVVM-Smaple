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
    public class MenuManager : BaseDal<tb_Menu>, IMenu
    {
        public async Task<ServiceResponse> ExistEntity(tb_Menu entity)
        {
            return await base.ExistEntity(ExpressionHelper.GenerateQueryExp(entity));
        }

        public async Task<ServiceResponse> GetMenuTrees()
        {
            try
            {
                using (var db = new ZFSConfig())
                {
                    var task = await Task.Run(() =>
                     {
                         return db.Database.SqlQuery<View_MenuTree>(
                         "SELECT a.isid, a.MenuName, a.MenuCaption, a.ParentName, b.AuthorityName, b.AuthorityValue, a.MenuCode" +
                         "  FROM " +
                         "dbo.tb_Menu AS a " +
                         "LEFT OUTER JOIN dbo.tb_AuthorityItem AS b ON b.AuthorityValue & " +
                         "a.MenuAuthorities = b.AuthorityValue").ToList();
                     });
                    return new ServiceResponse() { Success = true, Results = task };
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("获取菜单列表", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }

        }

        public async Task<ServiceResponse> GetModels(tb_Menu search)
        {
            return await base.GetModels(ExpressionHelper.GenerateQueryExp(search));
        }

        public async Task<ServiceResponse> GetPagingModels(int pageIndex, int pageSize, tb_Menu search, bool Asc = false)
        {
            Expression<Func<tb_Menu, int>> orderexp = x => x.isid;
            return await base.GetPagingModels(pageIndex, pageSize, ExpressionHelper.GenerateQueryExp(search), orderexp, Asc);
        }

        /// <summary>
        /// 新增更新模块信息
        /// </summary>
        /// <param name="tb_Menus"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> UpdateMenus(List<tb_Menu> tb_Menus)
        {
            try
            {
                using (var db = new ZFSConfig())
                {
                    tb_Menus.ForEach(q =>
                    {
                        var row = db.tb_Menu.FirstOrDefault(x => x.MenuCode.Equals(q.MenuCode));
                        if (row != null)
                        {
                            row.MenuName = q.MenuName; ;
                            row.MenuNameSpace = q.MenuNameSpace;
                            row.MenuCaption = q.MenuCaption;
                            row.MenuAuthorities = q.MenuAuthorities;
                            DbEntityEntry dbEntity = db.Entry<tb_Menu>(row);
                            dbEntity.State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            db.Set<tb_Menu>().Add(q);
                        }
                    });
                    var task = await db.SaveChangesAsync();
                    bool result = task > 0 ? true : false;
                    return new ServiceResponse() { Success = result };
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("批量更新", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }
        }
    }
}
