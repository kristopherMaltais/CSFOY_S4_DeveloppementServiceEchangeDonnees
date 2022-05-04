using M06_API_CompteBancaire.Controllers.DTO;
using M06_BL_CompteBancaire;
using M06_FilMessages;
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
        private Producteur m_producteur;

        // ** Propriétés ** //

        // ** Constructeurs ** //
        public TransactionController(ManipulerCompteBancaire p_manipulationCompteBancaire, Producteur p_producteur)
        {
            this.m_manipulationCompteBancaire = p_manipulationCompteBancaire;
            this.m_producteur = p_producteur;
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

            List<Transaction> transactionsExistantes = this.m_manipulationCompteBancaire.ObtenirTransactions().ToList();
            List<Compte> comptesExistants = this.m_manipulationCompteBancaire.ObtenirComptes().ToList();
            bool compteExistant = comptesExistants.Any(compte => compte.CompteID.ToString() == p_transaction.CompteID.ToString());
            bool transactionExiste = transactionsExistantes.Any(transaction => transaction.TransactionID.ToString() == p_transaction.TransactionID.ToString());
            if (transactionExiste || !compteExistant)
            {
                return BadRequest();
            }


            EnveloppeDTO enveloppeAEnvoyer = new EnveloppeDTO(p_transaction, "creation");
            this.m_producteur.PousserFilMessage(enveloppeAEnvoyer.VersEntite());

            return CreatedAtAction(nameof(Get), new { id = p_transaction.TransactionID }, p_transaction);
        }
    }
}
