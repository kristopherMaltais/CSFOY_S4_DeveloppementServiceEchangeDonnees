// CONSOMMATEUR

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft.Json;
using M06_CasUtilisation_Clients;
using M06_CasUtilisation_Clients;
using M06_DAL_Clients_SQLServeur;
using Microsoft.EntityFrameworkCore;

ManualResetEvent waitHandle = new ManualResetEvent(false);
ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };


IDepotClients depotClient = new DepotClientSQLServeur(DbContextGeneration.ObtenirApplicationDBContext());
ManipulationClient manipulerClient = new ManipulationClient(depotClient);

Client clientDeserialise = null;

using (IConnection connection = factory.CreateConnection())
{
    using (IModel channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "m06-clients", durable: false, exclusive: false, autoDelete: false, arguments: null);

        EventingBasicConsumer consommateur = new EventingBasicConsumer(channel);
        consommateur.Received += (model, ea) =>
        {
            byte[] donnees = ea.Body.ToArray();
            string message = Encoding.UTF8.GetString(donnees);


            // setting pour la deserialisation
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            // Deserialiser le client
            clientDeserialise = JsonConvert.DeserializeObject<Client>(message, settings);
            clientDeserialise.Identifiant = Guid.NewGuid();
            manipulerClient.Creer(clientDeserialise);
            channel.BasicAck(ea.DeliveryTag, false);
        };
 
        channel.BasicConsume(queue: "m06-clients", autoAck: false, consumer: consommateur);
        waitHandle.WaitOne();
    }

}


