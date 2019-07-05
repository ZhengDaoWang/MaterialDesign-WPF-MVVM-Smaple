using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library.Helper.FileHelper;

namespace ZFS.Library
{
    /// <summary>
    /// 配置消息参数
    /// </summary>
    public class Configuration
    {
        public const string ADD_MSG = "添加完成";

        public const string UPDATE_MSG = "更新完成";

        public const string DELETE_MSG = "删除完成";

        public const string USER_ADD_TITLE = "创建新用户";

        public const string USER_EDIT_TITLE = "编辑用户信息";

        public const string USER_DELETE_TITLE = "确认删除用户：{0}?";

        public const string GROUP_ADD_TITLE = "新建用户组";

        public const string GROUP_EDIT_TITLE = "编辑组信息";

        public const string GROUP_DELETE_TITLE = "确认删除组：{0}?";

        public const string DIC_ADD_TITLE = "创建字典";

        public const string DIC_EDIT_TITLE = "编辑字典";

        public const string DIC_DELETE_TITLE = "确认删除字典：{0}?";

        public const string MENU_ADD_TITLE = "导入菜单";
    }

    /// <summary>
    /// 
    /// </summary>
    public class SerivceFiguration
    {
        /// <summary>
        /// 配置文件
        /// </summary>
        public const string INI_CFG = "config\\user.ini";

        /// <summary>
        /// 获取本地样式参数
        /// </summary>
        /// <returns></returns>
        public static string GetSkin()
        {
            string cfgINI = AppDomain.CurrentDomain.BaseDirectory + INI_CFG;
            if (File.Exists(cfgINI))
            {
                IniFile ini = new IniFile(cfgINI);
                string SkinName = ini.IniReadValue("Skin", "Skin");
                return SkinName;
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="SkinName"></param>
        public static void SetKin(string SkinName)
        {
            string cfgINI = AppDomain.CurrentDomain.BaseDirectory + INI_CFG;
            IniFile ini = new IniFile(cfgINI);
            ini.IniWriteValue("Skin", "Skin", SkinName);
        }
    }
}
