//// PRODUCTEUR

using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };

using (IConnection connection = factory.CreateConnection())
{
    using (IModel channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "m06-clients", durable: false, exclusive: false, autoDelete: false, arguments: null);

        string message = "test2";
        byte[] body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: "", routingKey: "m06-clients", body: body);
    }
}
