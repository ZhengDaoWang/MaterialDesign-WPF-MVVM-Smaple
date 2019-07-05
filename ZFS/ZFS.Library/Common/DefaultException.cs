using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Library.Helper
{
    public class DefaultException : Exception
    {
        public DefaultException() : base("未知错误")
        {
        }

        public DefaultException(string message)//指定错误消息
            : base(message)
        {
        }

        public DefaultException(string messgae, Exception exp) : base(messgae, exp)
        {
        }
    }
}
