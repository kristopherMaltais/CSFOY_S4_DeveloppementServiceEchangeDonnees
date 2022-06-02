using M08_Application.Controllers.DTO;
using M08_Application.Entite;
using M08_Application.Hubs;
using M08_BL_ServiceStatistiqueClientele;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace M08_Application.Controllers
{
    [Route("api/appels")]
    [ApiController]
    public class AppelController : Controller
    {
        // ** Champs ** //
        private ManipulerDepotAppel m_manipulerDepotAppel;
        private readonly IHubContext<AppelHub> m_hubContext;

        // ** Propriétés ** //

        // ** Constructeurs ** //
        public AppelController(ManipulerDepotAppel p_manipulerDepotAppel, IHubContext<AppelHub> p_contexte)
        {
            this.m_manipulerDepotAppel = p_manipulerDepotAppel;
            this.m_hubContext = p_contexte;
        }

        // ** Méthodes ** //
            
            // Afficher page HTML
        public async Task<IActionResult> Index()
        {
            return View();
        }


        // POST: api/appels
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async  Task<ActionResult> Post([FromBody] AppelAPIDTO p_appel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            Appel nouvelAppel = p_appel.VersIdentite();
            this.m_manipulerDepotAppel.CreerAppel(nouvelAppel);

            await m_hubContext.Clients.All.SendAsync("afficherStatistique", this.m_manipulerDepotAppel.ObtenirStatistiques());

            return NoContent();
            
        }

            // PUT: api/appels
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> PUT(Guid id, [FromBody] AppelAPIDTO p_compteBancaire)
        {
            if (!ModelState.IsValid || id != p_compteBancaire.IdentifiantAppel)
            {
                return BadRequest();
            }

            if (!this.m_manipulerDepotAppel.ObtenirAppels().Any(appel => appel.IdentifiantAppel == p_compteBancaire.IdentifiantAppel))
            {
                return NotFound();
            }

            this.m_manipulerDepotAppel.MAJAppel(p_compteBancaire.IdentifiantAppel);
            
            await m_hubContext.Clients.All.SendAsync("afficherStatistique", this.m_manipulerDepotAppel.ObtenirStatistiques());

            return NoContent();
        }

    }
}
