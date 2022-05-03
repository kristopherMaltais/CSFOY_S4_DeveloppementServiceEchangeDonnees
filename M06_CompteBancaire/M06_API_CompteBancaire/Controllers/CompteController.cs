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
    [Route("api/comptesBancaires")]
    [ApiController]
    public class CompteController : Controller
    {
        // ** Champs ** //
        private ManipulerCompteBancaire m_manipulationCompteBancaire;

        // ** Propriétés ** //

        // ** Constructeurs ** //
        public CompteController(ManipulerCompteBancaire p_manipulationCompteBancaire)
        {
            this.m_manipulationCompteBancaire = p_manipulationCompteBancaire;
        }

        // ** Méthodes ** //
        // GET: api/comptesBancaires
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<CompteAPIDTO>> Get()
        {
            IEnumerable<Compte> comptes = this.m_manipulationCompteBancaire.ObtenirComptes();
            return Ok(comptes.Select(compte => new CompteAPIDTO(compte)));
        }

        //GET: api/comptesBancaires/id
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<CompteAPIDTO> Get(Guid id)
        {
            Compte compteTrouve = this.m_manipulationCompteBancaire.ObtenirCompte(id);

            if (compteTrouve is not null)
            {
                return Ok(new CompteAPIDTO(compteTrouve));
            }

            return NotFound();
        }

            // POST: api/comptesBancaires
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody] CompteAPIDTO p_compteBancaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            p_compteBancaire.CompteID = Guid.NewGuid();
            EnveloppeDTO enveloppeAEnvoyer = new EnveloppeDTO(p_compteBancaire, "creation");

            // RABBIT MQ
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            string message = JsonConvert.SerializeObject(enveloppeAEnvoyer);
            using (IConnection connection = factory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "compteBancaire", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    byte[] body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "compteBancaire", body: body);
                }
            }
            // FIN RABBIT MQ

            return CreatedAtAction(nameof(Get), new { id = p_compteBancaire.CompteID}, p_compteBancaire);
        }

            // PUT: api/comptesBancaires
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult PUT(Guid id, [FromBody] CompteAPIDTO p_compteBancaire)
        {
            if (!ModelState.IsValid || id != p_compteBancaire.CompteID)
            {
                return BadRequest();
            }

            if (!this.m_manipulationCompteBancaire.ObtenirComptes().Any(compte => compte.CompteID == id))
            {
                return NotFound();
            }

            EnveloppeDTO enveloppeAEnvoyer = new EnveloppeDTO(p_compteBancaire, "modification");

            // RABBIT MQ
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            string message = JsonConvert.SerializeObject(enveloppeAEnvoyer);
            using (IConnection connection = factory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "compteBancaire", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    byte[] body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "compteBancaire", body: body);
                }
            }
            // FIN RABBIT MQ

            return NoContent();
        }

            // DELETE: api/comptesBancaires/id 
        ////public ActionResult Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
