// See https://aka.ms/new-console-template for more information


using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ManualResetEvent waitHandle = new ManualResetEvent(false);
ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };


using (IConnection connection = factory.CreateConnection())
{
    using (IModel channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "test", durable: false, exclusive: false, autoDelete: false, arguments: null);

        EventingBasicConsumer consommateur = new EventingBasicConsumer(channel);
        consommateur.Received += (model, ea) =>
        {
            byte[] donnees = ea.Body.ToArray();
            string message = Encoding.UTF8.GetString(donnees);
            Console.Out.WriteLine(message);
            channel.BasicAck(ea.DeliveryTag, false);
        };

        channel.BasicConsume(queue: "test", autoAck: false, consumer: consommateur);
        waitHandle.WaitOne();
    }

}
