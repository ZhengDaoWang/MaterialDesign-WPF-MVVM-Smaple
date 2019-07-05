using MQTTnet;
using MQTTnet.Protocol;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZFS.Library.Helper.MQTT;

namespace ZFS.MqttServer
{
    class Program
    {
        static IMqttServer mqttServer;

        static List<ClientInstance> ClientInsTances = new List<ClientInstance>();

        static void Main(string[] args)
        {
            mqttServer = new MqttFactory().CreateMqttServer();
            var options = new MqttServerOptions();
            options.ConnectionValidator = c =>
            {
                try
                {
                    Console.WriteLine(string.Format("用户尝试登录:用户ID：{0}\t用户信息：{1}\t用户密码：{2}", c.ClientId, c.Username, c.Password));
                    if (!string.IsNullOrEmpty(c.Username) && !string.IsNullOrEmpty(c.Password))
                    {
                        var user = ClientInsTances.FirstOrDefault(t => t.UserName.Equals(c.Username));
                        if (user == null)
                        {
                            ClientInsTances.Add(new ClientInstance()
                            {
                                ClientID = c.ClientId,
                                UserName = c.Username,
                                PassWord = c.Password
                            });
                            c.ReturnCode = MqttConnectReturnCode.ConnectionAccepted;
                            Console.WriteLine(c.ClientId + " 登录成功");
                            return;
                        }
                        else
                        {
                            c.ReturnCode = MqttConnectReturnCode.ConnectionAccepted;
                            return;
                        }
                    }
                    else
                    {
                        c.ReturnCode = MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("登录失败:" + ex.Message);
                    c.ReturnCode = MqttConnectReturnCode.ConnectionRefusedIdentifierRejected;
                    return;
                }
            };
            options.SubscriptionInterceptor = context =>
           {
               try
               {
                   Console.WriteLine(string.Format("用户{0}订阅", context.ClientId));
                   var client = ClientInsTances.FirstOrDefault(t => t.ClientID.Equals(context.ClientId));

                   if (client != null)
                   {
                       MSG_MQTT_MessageStruct mSG_MQTT_Message = new MSG_MQTT_MessageStruct()
                       {
                           ENUM_MqttMsgType = ENUM_MqttMsgType.Notice,
                           Message = string.Format("你的好友{0}上线了!", client.UserName),
                           MessageDate = DateTime.Now
                       };
                       string json = JsonConvert.SerializeObject(mSG_MQTT_Message);

                       foreach (var C in ClientInsTances)
                       {
                           if (C.ClientID == context.ClientId) continue;
                           PublishAsync(C.ClientID, json);
                       }
                   }
               }
               catch (Exception ex)
               {
                   Console.WriteLine("订阅失败:" + ex.Message);
                   context.AcceptSubscription = false;
               }
           };
            mqttServer.ClientDisconnected += ClientDisconnected;
            mqttServer.ClientConnected += MqttServer_ClientConnected;
            mqttServer.ApplicationMessageReceived += MqttServer_ApplicationMessageReceived;
            mqttServer.Started += MqttServer_Started;
            mqttServer.StartAsync(options);
            Console.ReadKey();
        }

        private static void MqttServer_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            if (e.ClientId == null) return;
            string msg = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            MSG_MQTT_MessageStruct mSG = JsonConvert.DeserializeObject<MSG_MQTT_MessageStruct>(msg);
            switch (mSG.ENUM_MqttMsgType)
            {
                case ENUM_MqttMsgType.Notice:
                    PublishAsync(e.ClientId, msg);
                    break;
                case ENUM_MqttMsgType.Message:
                    PublishAsync(e.ClientId, msg);
                    break;
                case ENUM_MqttMsgType.GroupMessage:
                    foreach (var C in ClientInsTances)
                        PublishAsync(C.ClientID, msg);
                    break;
                case ENUM_MqttMsgType.DownLine:
                    PublishAsync(e.ClientId, msg);
                    break;
            }
        }

        public static void PublishAsync(string topic, string msg)
        {
            mqttServer.PublishAsync(new MqttApplicationMessage
            {
                Topic = topic,
                QualityOfServiceLevel = MqttQualityOfServiceLevel.ExactlyOnce,
                Retain = false,
                Payload = Encoding.UTF8.GetBytes(msg),
            });
        }

        private static void MqttServer_Started(object sender, EventArgs e)
        {
            Console.WriteLine("消息服务启动成功：任意键退出");
        }

        private static void MqttServer_ClientConnected(object sender, MqttClientConnectedEventArgs e)
        {
            Console.WriteLine(e.ClientId + " 连接");
        }

        private static void ClientDisconnected(object sender, MqttClientDisconnectedEventArgs e)
        {
            var client = ClientInsTances.FirstOrDefault(t => t.ClientID.Equals(e.ClientId));
            if (client != null)
            {
                MSG_MQTT_MessageStruct mSG_MQTT_Message = new MSG_MQTT_MessageStruct()
                {
                    ENUM_MqttMsgType = ENUM_MqttMsgType.Notice,
                    Message = string.Format("你的好友{0}下线了!", client.UserName),
                    MessageDate = DateTime.Now
                };
                string json = JsonConvert.SerializeObject(mSG_MQTT_Message);
                ClientInsTances.Remove(client);
                Console.WriteLine(e.ClientId + " 断开");
                foreach (var C in ClientInsTances)
                {
                    PublishAsync(C.ClientID, json);
                }
            }
        }

    }

    /// <summary>
    /// 登陆者信息
    /// </summary>
    public class ClientInstance
    {
        /// <summary>
        /// 识别ID
        /// </summary>
        public string ClientID { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
    }
}
