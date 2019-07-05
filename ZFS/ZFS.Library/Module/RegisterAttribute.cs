using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Library.Module
{
    /// <summary>
    /// 注册IOC类型
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterAttribute : Attribute
    {
        public RegisterAttribute(bool IsNotRegister)
        {
            _IsNotRegister = IsNotRegister;
        }

        private bool _IsNotRegister;

        public bool IsNotRegister
        {
            get { return _IsNotRegister; }
        }

    }
}
