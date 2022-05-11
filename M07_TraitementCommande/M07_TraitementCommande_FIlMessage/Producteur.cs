using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace M07_TraitementCommande_producteur
{
    public class Producteur
    {
        // ** Champs ** //
        private ConnectionFactory m_connectionFactory;
        private IConnection m_connection;
        private IModel m_model;
        private GenerateurCommande m_generateurCommande;
        private string m_echange;

        // ** Propriétés ** //

        // ** Constructeurs ** //
        public Producteur(string p_echange)
        {
            this.m_echange = p_echange;
            this.m_generateurCommande = new GenerateurCommande();
            this.m_connectionFactory = new ConnectionFactory() { HostName = "localhost" };
            this.m_connection = this.m_connectionFactory.CreateConnection();
            this.m_model = m_connection.CreateModel();
        }

        // ** Méthodes ** //
        public void PousserMessage()
        {

            using (this.m_connection)
            {
                using (this.m_model)
                {
                    this.m_model.ExchangeDeclare(
                        exchange: this.m_echange,
                        type: "topic",
                        durable: true,
                        autoDelete: false
                    );

                    
                    while(true)
                    {
                        Console.ReadLine();
                        Commande commande = this.m_generateurCommande.GenererCommande();
                        Console.WriteLine(commande.ToString());

                        string message = JsonConvert.SerializeObject(commande);
                        string sujet = $"commande.placee.{this.m_generateurCommande.GenererTypeCompte}";

                        var body = Encoding.UTF8.GetBytes(message);

                        this.m_model.BasicPublish(exchange: this.m_echange, routingKey: sujet, basicProperties: null, body: body);
                    }
                }
            }
            
        }
    }
}

