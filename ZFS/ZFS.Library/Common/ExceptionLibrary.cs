using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Library.Helper
{
    public class ExceptionLibrary
    {
        static ExceptionLibrary()
        {
            InitDictionarys(); //初始化异常字典
        }

        static List<ExceptionInfo> ExDictionarys = new List<ExceptionInfo>();

        /// <summary>
        /// 获取异常信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetErrorMsgByExpId(Exception ex)
        {
            var expMode = ExDictionarys.FirstOrDefault(t => t.ExpId.Equals(ex.HResult));
            if (expMode == null) return ex.Message;
            else
                return expMode.Msg;
        }

        private static void InitDictionarys()
        {
            //异常代码-用户异常提示-内部异常提示
            ExDictionarys.Add(new ExceptionInfo(-2146233087, "未能连接至远程服务器,请联系管理员!", "WCF服务未开启"));
            ExDictionarys.Add(new ExceptionInfo(-2147467261, "数据操作异常!", "未将对象引用到实例"));
            ExDictionarys.Add(new ExceptionInfo(-2146233088, "未能连接至远程服务器,请联系管理员!", "数据库服务未启动"));
        }

    }

}
