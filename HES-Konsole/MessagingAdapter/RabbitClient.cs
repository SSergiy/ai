using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace MessagingAdapter
{
    public class RabbitClient : IMessagingAdapter
    {
        protected IModel InModel;
        protected IModel OutModel;

        protected IConnection Connection;
        protected readonly string InQueue;
        protected readonly string OutQueue;

        protected int clientId = new Random().Next();
        protected string HostIp;
        protected QueueingBasicConsumer consumer;
        protected UTF8Encoding encoder = new System.Text.UTF8Encoding();

        public RabbitClient(string inQueue, string outQueue, string hostName, string hostIp)
        {
            InQueue = inQueue;
            OutQueue = outQueue;
            HostIp = hostIp;
            
            var connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = hostName;
            Connection = connectionFactory.CreateConnection();
            bool durable = true;

            // in
            InModel = Connection.CreateModel();
            InModel.BasicQos(0, 1, false);
            InModel.QueueDeclare(InQueue, durable, false, false, null);

            consumer = new QueueingBasicConsumer(InModel);

            // out
            OutModel = Connection.CreateModel();
            OutModel.BasicQos(0, 1, false);
            OutModel.QueueDeclare(OutQueue, durable, false, false, null);
        }

        public UTF8Encoding Encoder()
        {
            return encoder;
        }

        public byte[] ReceiveMessage()
        {
            try
            {
                bool autoAck = true;
                String consumerTag = InModel.BasicConsume(InQueue, autoAck, consumer);

                RabbitMQ.Client.Events.BasicDeliverEventArgs e = (RabbitMQ.Client.Events.BasicDeliverEventArgs)consumer.Queue.Dequeue();
                IBasicProperties props = e.BasicProperties;
                byte[] body = e.Body;

                //InModel.BasicAck(e.DeliveryTag, false);

                return body;
            }
            catch (OperationInterruptedException ex)
            {
                // The consumer was removed, either through
                // channel or connection closure, or through the
                // action of IModel.BasicCancel().
                Console.WriteLine(ex.Message);
                return new byte[0];
            }
        }

        public void SendMessage(byte[] message)
        {
            IBasicProperties basicProperties = OutModel.CreateBasicProperties();
            basicProperties.SetPersistent(true);
            OutModel.BasicPublish("", OutQueue, basicProperties, message);
        }

        public void Dispose()
        {
            if (Connection != null)
                Connection.Close();
            if (InModel != null)
                InModel.Abort();
            if (OutModel != null)
                OutModel.Abort();
        }
    }
}
