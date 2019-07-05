using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Model;
using ZFSData.InterFace;

namespace ZFSData.Manager
{
    public class DictionaryTypeManager : BaseDal<tb_DictionaryType>, IDictionaryType
    {
        public async Task<ServiceResponse> ExistEntity(tb_DictionaryType entity)
        {
            return await base.ExistEntity(ExpressionHelper.GenerateQueryExp(entity));
        }

        public async Task<ServiceResponse> GetDictionaryTypes()
        {
            try
            {
                using (var db = new ZFSConfig())
                {
                    var task = await Task.Run(() => db.tb_DictionaryType.ToList());
                    return new ServiceResponse() { Success = true, Results = task };
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("获取字典类型", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }
        }

        public async Task<ServiceResponse> GetModels(tb_DictionaryType search)
        {
            return await base.GetModels(ExpressionHelper.GenerateQueryExp(search));
        }

        public async Task<ServiceResponse> GetPagingModels(int pageIndex, int pageSize, tb_DictionaryType search, bool Asc = false)
        {
            Expression<Func<tb_DictionaryType, int>> orderexp = x => x.isid;
            return await base.GetPagingModels(pageIndex, pageSize, ExpressionHelper.GenerateQueryExp(search), orderexp, Asc);
        }
    }
}
