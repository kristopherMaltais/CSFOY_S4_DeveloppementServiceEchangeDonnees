//// PRODUCTEUR

using M06_Clients_Producteur_UI;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

MessageClient clientTest = new MessageClient("kristopher", "maltais", "test@ulaval.ca", "418-720-3363");
string output = JsonConvert.SerializeObject(clientTest);


ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
using (IConnection connection = factory.CreateConnection())
{
    using (IModel channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "m06-clients", durable: false, exclusive: false, autoDelete: false, arguments: null);

        byte[] body = Encoding.UTF8.GetBytes(output);

        channel.BasicPublish(exchange: "", routingKey: "m06-clients", body: body);
    }
}
