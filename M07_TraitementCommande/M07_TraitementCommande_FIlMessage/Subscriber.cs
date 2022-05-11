using M07_TraitementCommande_producteur;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;

namespace M07_TraitementCommande_FIlMessage
{
    public class Subscriber
    {
        // ** Champs ** //
        private ConnectionFactory m_connectionFactory;
        private IConnection m_connection;
        private IModel m_model;
        private string m_echange;
        private string m_file;
        private string m_requeteSujet;
        private IAction m_action;

        // ** Propriétés ** //

        // ** Constructeurs ** //
        public Subscriber(string p_file, string p_echange, string p_requeteSujet, IAction p_action)
        {
            this.m_file = p_file;
            this.m_action = p_action;
            this.m_requeteSujet = p_requeteSujet;
            this.m_echange = p_echange;
            this.m_connectionFactory = new ConnectionFactory() { HostName = "localhost" };
            this.m_connection = this.m_connectionFactory.CreateConnection();
            this.m_model = m_connection.CreateModel();
        }

        // ** Méthodes ** //
        public void TirerMessage()
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

                    this.m_model.QueueDeclare(
                            this.m_file,
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null
                        );

                    this.m_model.QueueBind(queue: this.m_file, exchange: this.m_echange, routingKey: this.m_requeteSujet);
                    ManualResetEvent waitHandle = new ManualResetEvent(false);

                    EventingBasicConsumer consommateur = new EventingBasicConsumer(this.m_model);
                    consommateur.Received += (model, ea) =>
                    {
                        byte[] body = ea.Body.ToArray();
                        this.ReagirMessage(body);
                    };

                    this.m_model.BasicConsume(queue: this.m_file, autoAck: true, consumer: consommateur);

                    waitHandle.WaitOne();

                }
            }
        }
        private void ReagirMessage(Byte[] p_message)
        {
            string message = Encoding.UTF8.GetString(p_message);
            Commande commandeATraiter = JsonConvert.DeserializeObject<Commande>(message);
            this.m_action.Executer(commandeATraiter);
        }
    }
}