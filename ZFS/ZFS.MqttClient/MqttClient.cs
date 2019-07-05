using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.MqttClient.Common;

namespace ZFS.MqttClient
{
    public class MqttClient
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Ip">IP地址</param>
        /// <param name="Port">端口号</param>
        public MqttClient(string Ip, int Port)
        {
            ip = Ip;
            port = Port;
        }

        #region 属性

        private string ip;
        private int port;
        public delegate void DlgMessageReceived(string message);
        public event DlgMessageReceived ApplicationMessageReceived;

        /// <summary>
        ///  MQTT客户端对象
        /// </summary>
        public IMqttClient mqttClient;

        #endregion

        /// <summary>
        /// 连接MQTT服务器
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public async void ConnectServer(string UserName, string PassWord)
        {
            try
            {
                var options = new MqttClientOptionsBuilder()
                    .WithClientId(Computer.Instance().MacAddress)
                    .WithTcpServer(ip, port).
                        WithCredentials(UserName, PassWord).WithCleanSession().Build();
                mqttClient = new MqttFactory().CreateMqttClient();
                //mqttClient.Connected += MqttClient_Connected;
                mqttClient.Disconnected += MqttClient_Disconnected;
                mqttClient.ApplicationMessageReceived += MqttClient_ApplicationMessageReceived;
                await mqttClient.ConnectAsync(options);
                await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic(Computer.Instance().MacAddress).Build());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Disconnected()
        {
            if (mqttClient.IsConnected)
                mqttClient.DisconnectAsync();
        }

        /// <summary>
        /// 接受消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MqttClient_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            ApplicationMessageReceived?.Invoke(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
        }

        /// <summary>
        /// 短线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MqttClient_Disconnected(object sender, MqttClientDisconnectedEventArgs e)
        {
            ApplicationMessageReceived?.Invoke("你掉线了!");
        }


        /// <summary>
        /// 客户端推送信息
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            mqttClient.PublishAsync(new MqttApplicationMessage
            {
                QualityOfServiceLevel = MqttQualityOfServiceLevel.AtLeastOnce,
                Retain = false,
                Payload = Encoding.UTF8.GetBytes(message),
            });
        }

    }
}
