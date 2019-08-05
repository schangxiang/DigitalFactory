using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using WIP_Models;
using RabbitMQ.Client;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;

namespace WIP_common
{
    /// <summary>
    /// 发送邮件
    /// </summary>
    public class RabbitClient
    {
        //小车实时位置 消息主题名称
        private static readonly string topicName = "";// BLLHelpler.GetConfigValue("RabbitMQ_AgvRealTimeLocation");//订阅名称

        //定义连接工厂
        ConnectionFactory factory = new ConnectionFactory();

        public RabbitClient()
        {
            //指定要连接的RabbitMQ服务地址
            factory.HostName = "localhost";
        }

        public void Send(List<RequestMessage> msgList)
        {

            //创建一个 AMQP 连接
            using (IConnection connection = factory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    //在MQ上定义一个队列
                    channel.QueueDeclare("esbtest.rmq.consoleserver", false, false, false, null);

                    //序列化消息对象，RabbitMQ并不支持复杂对象的序列化，所以对于自定义的类型需要自己序列化
                    XmlSerializer xs = new XmlSerializer(typeof(List<RequestMessage>));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        xs.Serialize(ms, msgList);
                        byte[] bytes = ms.ToArray();
                        //指定发送的路由，通过默认的exchange直接发送到指定的队列中。
                        channel.BasicPublish(topicName, "esbtest.rmq.consoleserver", null, bytes);
                    }
                }
            }
        }


        public void SendByJsonSerializer(List<RequestMessage> msgList)
        {

            //创建一个 AMQP 连接
            using (IConnection connection = factory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    //在MQ上定义一个队列
                    channel.QueueDeclare("esbtest.rmq.consoleserver", false, false, false, null);

                    //序列化消息对象，RabbitMQ并不支持复杂对象的序列化，所以对于自定义的类型需要自己序列化
                    DataContractJsonSerializer jsonSerialize = new DataContractJsonSerializer(typeof(List<RequestMessage>));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        jsonSerialize.WriteObject(ms, msgList);
                        byte[] bytes = ms.ToArray();
                        //指定发送的路由，通过默认的exchange直接发送到指定的队列中。
                        channel.BasicPublish(topicName, "esbtest.rmq.consoleserver", null, bytes);
                    }
                }
            }
        }

    }
}
