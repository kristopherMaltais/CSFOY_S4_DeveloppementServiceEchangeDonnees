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
            this.m_producteur = p_producteur;
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
                        byte[] donnees = ea.Body.ToArray();
                        try
                        {
                            this.ReagirMessage(donnees);
                            channel.BasicAck(ea.DeliveryTag, false);
                        }
                        catch
                        {
                            if(this.m_producteur is not null)
                            {
                                this.m_producteur.PousserFil(donnees);
                            }
                        }

                    };
                    
                    channel.BasicConsume(queue: this.m_nomFil, autoAck: false, consumer: consommateur);
                    this.m_waitHandle.WaitOne();
                }
            }
        }
        private void ReagirMessage(Byte[] p_message)
        {
            this.m_actionMessage.Executer(p_message);
        }
    }
}