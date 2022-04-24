// CONSOMMATEUR

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft.Json;
using M06_CasUtilisation_Clients;

ManualResetEvent waitHandle = new ManualResetEvent(false);
ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
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

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            Client clientDeserialized = JsonConvert.DeserializeObject<Client>(message, settings);
            clientDeserialized.Identifiant = Guid.NewGuid();
            Console.WriteLine(clientDeserialized.ToString());
            channel.BasicAck(ea.DeliveryTag, false);
        };

        channel.BasicConsume(queue: "m06-clients", autoAck: false, consumer: consommateur);
        waitHandle.WaitOne();
    }

}



//using M06_CasUtilisation_Clients;
//using M06_DAL_Clients_SQLServeur;
//using Microsoft.EntityFrameworkCore;
//IDepotClients test = new DepotClientSQLServeur(DbContextGeneration.ObtenirApplicationDBContext());
//ManipulationClient manipulationTest = new ManipulationClient(test);
//Client clientTest = new Client(Guid.NewGuid(), "Kristopher", "Maltais", "test@test.com", "418-720-3363");
//test.CreerClient(clientTest);


