using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZFS.Library.Helper.MQTT;
using ZFS.MqttClient.Common;

namespace ZFS.MqttClientTest
{
    class Program
    {
        static ZFS.MqttClient.MqttClient mqttClient;

        static void Main(string[] args)
        {
            try
            {
                //127.0.0.1
                mqttClient = new MqttClient.MqttClient("39.108.11.3", 1883);
                mqttClient.ApplicationMessageReceived += MqttClient_ApplicationMessageReceived;
                mqttClient.ConnectServer("admin" + new Random().Next(1, 9999), "123456");//暂时不做账号密码校验
                while (true)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("(连接成功/-结束)测试服务器通讯:" +
                        "1.测试群发消息" +
                        "2.测试独立消息" +
                        "3.测试账号下线" +
                        "4.测试通知消息(管理员)" +
                        ",请输入测试编号：");
                    string Message = Console.ReadLine();
                    if (Message.Equals("-")) break;
                    MSG_MQTT_MessageStruct mSG_MQTT_Message = null;
                    switch (Message)
                    {
                        case "1":
                            mSG_MQTT_Message = new MSG_MQTT_MessageStruct()
                            {
                                ENUM_MqttMsgType = ENUM_MqttMsgType.GroupMessage,
                                ClientId = Computer.Instance().MacAddress,
                                UserName = "admin",
                                Message = "测试群发",
                                MessageDate = DateTime.Now
                            };
                            break;
                        case "2":
                            mSG_MQTT_Message = new MSG_MQTT_MessageStruct()
                            {
                                ENUM_MqttMsgType = ENUM_MqttMsgType.Message,
                                ClientId = Computer.Instance().MacAddress,
                                UserName = "admin",
                                Message = "独立消息",
                                MessageDate = DateTime.Now
                            };
                            break;
                        case "3":
                            mSG_MQTT_Message = new MSG_MQTT_MessageStruct()
                            {
                                ENUM_MqttMsgType = ENUM_MqttMsgType.DownLine,
                                ClientId = Computer.Instance().MacAddress,
                                UserName = "admin",
                                Message = "账号下线",
                                MessageDate = DateTime.Now
                            };
                            break;
                        case "4":
                            mSG_MQTT_Message = new MSG_MQTT_MessageStruct()
                            {
                                ENUM_MqttMsgType = ENUM_MqttMsgType.Notice,
                                ClientId = Computer.Instance().MacAddress,
                                UserName = "admin",
                                Message = "通知消息",
                                MessageDate = DateTime.Now
                            };
                            break;
                        default:
                            Console.WriteLine("输入有误,请重新输入！");
                            break;
                    }
                    if (mSG_MQTT_Message != null)
                    {
                        string json = JsonConvert.SerializeObject(mSG_MQTT_Message);
                        mqttClient.SendMessage(json);
                    }
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Server Message
        /// </summary>
        /// <param name="message"></param>
        private static void MqttClient_ApplicationMessageReceived(string message)
        {
            MSG_MQTT_MessageStruct mSG = JsonConvert.DeserializeObject<MSG_MQTT_MessageStruct>(message);
            switch (mSG.ENUM_MqttMsgType)
            {
                case ENUM_MqttMsgType.Notice:
                    Console.WriteLine("通知:" + mSG.Message);
                    break;
                case ENUM_MqttMsgType.DownLine:
                    Console.WriteLine("你的账户号在其他地方登录!");
                    break;
                case ENUM_MqttMsgType.GroupMessage:
                    Console.WriteLine("群消息:" + mSG.Message);
                    break;
                case ENUM_MqttMsgType.Message:
                    Console.WriteLine("{0} {1}:{2}",
                        mSG.UserName, mSG.MessageDate,
                        mSG.Message);
                    break;
            }
        }
    }
}
