using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.ServerBusiness;
using ZFSData.InterFace;
using ZFSData.InterFace.User;
using ZFSInterface.User;

namespace ZFSBridge
{
    /// <summary>
    /// WCF管理器
    /// </summary>
    public class WcfFrameworkManager : BridgeManager
    {
        /// <summary>
        /// 用户操作接口
        /// </summary>
        /// <returns></returns>
        public override IUser GetUserManager()
        {
            return new WCF_UserManager();
        }

        /// <summary>
        /// 用户组操作接口
        /// </summary>
        /// <returns></returns>
        public override IGroup GetGroupManager()
        {
            return new WCF_GroupManager();
        }

        /// <summary>
        /// 菜单操作接口
        /// </summary>
        /// <returns></returns>
        public override IMenu GetMenuManager()
        {
            return new WCF_MenuManager();
        }

        /// <summary>
        /// 字典接口
        /// </summary>
        /// <returns></returns>
        public override IDictionary GetDictionaryManager()
        {
            return new WCF_DictionaryManager();
        }

        /// <summary>
        /// 代码操作接口
        /// </summary>
        /// <returns></returns>
        public override IGenerator GetGeneratorManager()
        {
            return new WCF_GeneratorManager();
        }

        /// <summary>
        /// 字典类型接口
        /// </summary>
        /// <returns></returns>
        public override IDictionaryType GetDictionaryTypeManager()
        {
            return new WCF_DictionTypeManager();
        }
    }
}
