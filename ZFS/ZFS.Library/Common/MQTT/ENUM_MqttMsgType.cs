using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Library.Helper.MQTT
{
    /// <summary>
    /// MQTT消息类型
    /// </summary>
    public enum ENUM_MqttMsgType
    {
        Notice,
        Message,
        GroupMessage,
        DownLine,
    }
}
