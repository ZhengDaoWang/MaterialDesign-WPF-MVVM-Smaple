using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Library.Helper
{
    /// <summary>
    /// 异常字典
    /// </summary>
    public class ExceptionInfo
    {
        public ExceptionInfo(int expid, string msg, string msgexp)
        {
            _ExpId = expid;
            _Msg = msg;
            _MsgExp = msgexp;
        }

        private int _ExpId;
        private string _Msg;
        private string _MsgExp;

        public int ExpId { get { return _ExpId; } }

        public string Msg { get { return _Msg; } }

        public string MsgExp { get { return _MsgExp; } }

    }
}
