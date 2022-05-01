using M06_API_CompteBancaire.Controllers.DTO;
using M06_BL_CompteBancaire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace M06_API_CompteBancaire.Controllers
{
    //[ApiKey()]
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : Controller
    {
        // ** Champs ** //
        private ManipulerCompteBancaire m_manipulationCompteBancaire;

        // ** Propriétés ** //

        // ** Constructeurs ** //
        public TransactionController(ManipulerCompteBancaire p_manipulationCompteBancaire)
        {
            this.m_manipulationCompteBancaire = p_manipulationCompteBancaire;
        }

        // ** Méthodes ** //
        // GET: api/comptesBancaires
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<TransactionAPIDTO>> Get()
        {
            IEnumerable<Transaction> transactions = this.m_manipulationCompteBancaire.ObtenirTransactions();
            return Ok(transactions.Select(transaction => new TransactionAPIDTO(transaction)));
        }

        //GET: api/comptesBancaires/id
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<TransactionAPIDTO> Get(Guid id)
        {
            Transaction transactionTrouvee = this.m_manipulationCompteBancaire.ObtenirTransaction(id);

            if (transactionTrouvee is not null)
            {
                return Ok(new TransactionAPIDTO(transactionTrouvee));
            }

            return NotFound();
        }

        // POST: api/comptesBancaires
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody] TransactionAPIDTO p_transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            p_transaction.TransactionID = Guid.NewGuid();

            // RABBIT MQ
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            string message = JsonConvert.SerializeObject(p_transaction);
            using (IConnection connection = factory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "transaction", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    byte[] body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "transaction", body: body);
                }
            }
            // FIN RABBIT MQ

            return CreatedAtAction(nameof(Get), new { id = p_transaction.TransactionID }, p_transaction);
        }

        
        // PUT
        // DELETE
    }
}
