using M06_BL_CompteBancaire;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_FilMessages
{
    public class Producteur
    {
        // ** champs ** //
        private ConnectionFactory m_factory;
        private ManualResetEvent m_waitHandle;
        private string m_nomFil;

        // ** propriétés ** //

        // ** constructeurs ** //
        public Producteur(string p_nomFil)
        {
            this.m_factory = new ConnectionFactory() { HostName = "localhost" };
            this.m_waitHandle = new ManualResetEvent(false);
            this.m_nomFil = p_nomFil;
        }

        // ** méthodes ** //
        private string SerialierJson(Enveloppe p_message)
        {
            return JsonConvert.SerializeObject(p_message);
        }
        public void PousserFilMessage(Enveloppe p_message)
        {
            string message = this.SerialierJson(p_message);

            using (IConnection connection = m_factory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: this.m_nomFil, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    byte[] body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: this.m_nomFil, body: body);
                }
            }
        }
    }
}
