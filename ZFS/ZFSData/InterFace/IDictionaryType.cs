using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Model;

namespace ZFSData.InterFace
{
    /// <summary>
    /// 字典类型
    /// </summary>
    public interface IDictionaryType : IBaseDal<tb_DictionaryType>
    {
        Task<ServiceResponse> GetDictionaryTypes();
    }
}
