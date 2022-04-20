// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };

using (IConnection connection = factory.CreateConnection())
{
    using (IModel channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "test", durable: false, exclusive: false, autoDelete: false, arguments: null);

        string message = "test";
        byte[] body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: "", routingKey: "test", body: body);
    }
}