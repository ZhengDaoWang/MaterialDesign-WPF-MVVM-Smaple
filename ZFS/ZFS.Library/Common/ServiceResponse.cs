using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Library
{
    /// <summary>
    /// 服务返回报文
    /// </summary>
    [Serializable]
    public class ServiceResponse
    {
        private bool success = false;
        private string errorCode="";

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 操作成功与否
        /// </summary>
        public bool Success { get { return success; } set { success = value; } }

        /// <summary>
        /// 返回码
        /// </summary>
        public string ErrorCode { get { return errorCode; } set { errorCode = value; } }
        
        /// <summary>
        /// 返回的列表结果
        /// </summary>
        public dynamic Results { get; set; }

        /// <summary>
        /// 结果总行数
        /// </summary>
        public int TotalCount { get; set; }
    }
}
