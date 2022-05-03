using M06_BL_CompteBancaire;
using M06_DAL_CompteBancaire;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace M06_TraitementCreationsModifications
{
    public class TraitementFilMessage
    {
        // ** champs ** //
        private IDepot m_depotClient;
        private ConnectionFactory m_factory;
        private ManipulerCompteBancaire m_manipulerCompteBancaire;
        private ManualResetEvent m_waitHandle;

        // ** propriétés ** //

        // ** constructeurs ** //
        public TraitementFilMessage()
        {
            this.m_depotClient = new DepotCompteBancaire(DbContextGeneration.ObtenirApplicationDBContext());
            this.m_factory = new ConnectionFactory() { HostName = "localhost" };
            this.m_manipulerCompteBancaire = new ManipulerCompteBancaire(this.m_depotClient);
            this.m_waitHandle = new ManualResetEvent(false);
        }

        // ** méthodes ** //
        public void EcouterFilMessage()
        {
            using (IConnection connection = this.m_factory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "compteBancaire", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    EventingBasicConsumer consommateur = new EventingBasicConsumer(channel);
                    consommateur.Received += (model, ea) =>
                    {
                        byte[] donnees = ea.Body.ToArray();
                        string message = Encoding.UTF8.GetString(donnees);
                        
                        this.ReagirMessage(message);

                        channel.BasicAck(ea.DeliveryTag, false);
                    };

                    channel.BasicConsume(queue: "compteBancaire", autoAck: false, consumer: consommateur);
                    this.m_waitHandle.WaitOne();
                }
            }
        }
        private Enveloppe DeserialierJson(string p_message)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            Enveloppe enveloppe = JsonConvert.DeserializeObject<Enveloppe>(p_message, settings);
            return enveloppe;
        }
        private void ReagirMessage(String p_message)
        {
            Enveloppe enveloppe = this.DeserialierJson(p_message);

            if (enveloppe is not null)
            {
                if (enveloppe.Contenu == "compte")
                {
                    if (enveloppe.Action == "creation")
                    {
                        this.m_manipulerCompteBancaire.CreerCompte(enveloppe.Compte);
                    }

                    if (enveloppe.Action == "modification")
                    {
                        this.m_manipulerCompteBancaire.ModifierCompte(enveloppe.Compte);
                    }
                }

                if (enveloppe.Contenu == "transaction")
                {
                    if (enveloppe.Action == "creation")
                    {
                        this.m_manipulerCompteBancaire.CreerTransaction(enveloppe.Transaction);
                    }
                }
            }
        }
    }
}
