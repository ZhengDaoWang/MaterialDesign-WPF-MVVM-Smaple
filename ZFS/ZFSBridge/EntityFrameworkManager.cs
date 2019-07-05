using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFSData.InterFace;
using ZFSData.InterFace.User;
using ZFSData.Manager;
using ZFSInterface.User;

namespace ZFSBridge
{
    /// <summary>
    /// EF管理器
    /// </summary>
    public class EntityFrameworkManager : BridgeManager
    {
        /// <summary>
        /// 用户操作接口
        /// </summary>
        /// <returns></returns>
        public override IUser GetUserManager()
        {
            return new UserManager();
        }

        /// <summary>
        /// 用户组操作接口
        /// </summary>
        /// <returns></returns>
        public override IGroup GetGroupManager()
        {
            return new GroupManager();
        }

        /// <summary>
        /// 菜单操作接口
        /// </summary>
        /// <returns></returns>
        public override IMenu GetMenuManager()
        {
            return new MenuManager();
        }

        /// <summary>
        /// 字典接口
        /// </summary>
        /// <returns></returns>
        public override IDictionary GetDictionaryManager()
        {
            return new DictionaryManager();
        }

        /// <summary>
        /// 代码操作接口
        /// </summary>
        /// <returns></returns>
        public override IGenerator GetGeneratorManager()
        {
            return new GeneratorManager();
        }

        /// <summary>
        /// 字典类型接口
        /// </summary>
        /// <returns></returns>
        public override IDictionaryType GetDictionaryTypeManager()
        {
            return new DictionaryTypeManager();
        }


    }
}
