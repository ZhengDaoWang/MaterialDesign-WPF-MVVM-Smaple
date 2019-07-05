using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.ILayer
{
    /// <summary>
    ///权限操作接口
    /// </summary>
    public interface IPermission
    {
        /// <summary>
        /// 获取按钮权限
        /// </summary>
        /// <param name="authValue"></param>
        /// <returns></returns>
        bool GetButtonAuth(int authValue);

        /// <summary>
        /// 设置按钮权限
        /// </summary>
        void SetButtonAuth();

        /// <summary>
        /// 权限值
        /// </summary>
        int? AuthValue { get; set; }
        
    }
}
