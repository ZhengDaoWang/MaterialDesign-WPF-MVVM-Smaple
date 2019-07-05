using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFSData.InterFace;
using ZFSData.InterFace.User;
using ZFSInterface.User;

namespace ZFSBridge
{
    public abstract class BridgeManager
    {
        /// <summary>
        /// 获取用户操作接口
        /// </summary>
        /// <returns></returns>
        public abstract IUser GetUserManager();

        /// <summary>
        /// 获取用户组操作接口
        /// </summary>
        /// <returns></returns>
        public abstract IGroup GetGroupManager();

        /// <summary>
        /// 获取菜单操作接口
        /// </summary>
        /// <returns></returns>
        public abstract IMenu GetMenuManager();

        /// <summary>
        /// 获取字典操作接口
        /// </summary>
        /// <returns></returns>
        public abstract IDictionary GetDictionaryManager();

        /// <summary>
        /// 获取字典类型操作接口
        /// </summary>
        /// <returns></returns>
        public abstract IDictionaryType GetDictionaryTypeManager();

        /// <summary>
        /// 获取代码生成接口
        /// </summary>
        /// <returns></returns>
        public abstract IGenerator GetGeneratorManager();
    }
}
