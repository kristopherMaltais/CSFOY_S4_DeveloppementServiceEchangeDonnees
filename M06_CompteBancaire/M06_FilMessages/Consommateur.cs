using M06_BL_CompteBancaire;
using M06_DAL_CompteBancaire;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace M06_FilMessages
{
    public class Consommateur
    {
        // ** champs ** //
        private ConnectionFactory m_factory;
        private ManualResetEvent m_waitHandle;
        private string m_nomFil;
        private Producteur m_producteur;
        private IActionMessage m_actionMessage;

        // ** propriétés ** //

        // ** constructeurs ** //
        public Consommateur(string p_nomFil, IActionMessage p_actionMessage, Producteur p_producteur = null)
        {
            this.m_factory = new ConnectionFactory() { HostName = "localhost" };
            this.m_waitHandle = new ManualResetEvent(false);
            this.m_nomFil = p_nomFil;
            this.m_actionMessage = p_actionMessage;
        }

        // ** méthodes ** //
        public void TirerFilMessage()
        {
            using (IConnection connection = this.m_factory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: this.m_nomFil, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    EventingBasicConsumer consommateur = new EventingBasicConsumer(channel);
                    consommateur.Received += (model, ea) =>
                    {
                        //string message = null;
                        //try
                        //{
                            byte[] donnees = ea.Body.ToArray();
                            string message = Encoding.UTF8.GetString(donnees);
                            this.ReagirMessage(this.DeserialierJson(message));
                            channel.BasicAck(ea.DeliveryTag, false);
                        //}
                        //catch
                        //{
                        //    this.m_producteur.PousserFilMessage(this.DeserialierJson(message));
                        //}
                       
                    };
                    
                    channel.BasicConsume(queue: this.m_nomFil, autoAck: false, consumer: consommateur);
                   
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
        private void ReagirMessage(Enveloppe p_enveloppe)
        {
            this.m_actionMessage.Executer(p_enveloppe);
        }
        private ManipulerCompteBancaire CreerContexteDAL()
        {
            IDepot debotCompteBancaire = new DepotCompteBancaire(DbContextGeneration.ObtenirApplicationDBContext());
            return new ManipulerCompteBancaire(debotCompteBancaire);
        }
    }
}