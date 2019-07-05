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
    /// 字典接口
    /// </summary>
    public interface IDictionary : IBaseDal<tb_Dictionary>
    {
        Task<ServiceResponse> GetDictionarys();


    }
}
