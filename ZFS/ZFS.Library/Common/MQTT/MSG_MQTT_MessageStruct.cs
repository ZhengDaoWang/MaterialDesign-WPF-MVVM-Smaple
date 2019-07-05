using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Library.Helper.MQTT
{
    /// <summary>
    /// MQTT消息
    /// </summary>
    [Serializable]
    public class MSG_MQTT_MessageStruct
    {
        /// <summary>
        /// 注册ID
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public ENUM_MqttMsgType ENUM_MqttMsgType { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 消息时间
        /// </summary>
        public DateTime MessageDate { get; set; }
    }
}
