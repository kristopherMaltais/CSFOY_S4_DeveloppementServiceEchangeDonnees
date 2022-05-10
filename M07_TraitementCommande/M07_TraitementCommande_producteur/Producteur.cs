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

        // ** Propriétés ** //

        // ** Constructeurs ** //
        public Producteur()
        {
            this.m_generateurCommande = new GenerateurCommande();
            this.m_connectionFactory = new ConnectionFactory() { HostName = "localhost" };
            this.m_connection = this.m_connectionFactory.CreateConnection();
            this.m_model = m_connection.CreateModel();

            using (this.m_connection)
            {
                using (this.m_model)
                {
                    this.m_model.ExchangeDeclare(
                        exchange: "texteici",
                        type: "topic",
                        durable: true,
                        autoDelete: false
                    );
                }
            }
        }

        // ** Méthodes ** //
        public void PousserMessage()
        {
            Commande commande = this.m_generateurCommande.GenererCommande();

            string message = JsonConvert.SerializeObject(commande);
            string sujet = $"commande.placee.{this.m_generateurCommande.GenererTypeCompte}";

            var body = Encoding.UTF8.GetBytes(message);

            this.m_model.BasicPublish(
                    exchange: "m07-commandes",
                    routingKey: sujet,
                    basicProperties: null,
                    body: body
                );
        }
    }
}

