//// PRODUCTEUR

using M06_Clients_Producteur_UI;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;


// Créer le client (simulation d'interface)
MessageClient clientTest = new MessageClient("kristopher", "maltais", "test@ulaval.ca", "418-720-3363");


// Serialiser l'objet MessageClient pour prépartion envoie dans la fil
string clientSerialise = JsonConvert.SerializeObject(clientTest);


ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };

using (IConnection connection = factory.CreateConnection())
{
    using (IModel channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "m06-clients", durable: false, exclusive: false, autoDelete: false, arguments: null);

        // encoder la string JSON en tableau de byte pour envoyer
        byte[] body = Encoding.UTF8.GetBytes(clientSerialise);

        // envoyer le client dans la fil
        channel.BasicPublish(exchange: "", routingKey: "m06-clients", body: body);
    }
}
