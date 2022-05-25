using M08_Application.Controllers.DTO;
using M08_Application.Entite;
using M08_BL_ServiceStatistiqueClientele;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M08_Application.Controllers
{
    [Route("api/appels")]
    [ApiController]
    public class AppelController : Controller
    {
        // ** Champs ** //
        private ManipulerDepotAppel m_manipulerDepotAppel;

        // ** Propriétés ** //

        // ** Constructeurs ** //
        public AppelController(ManipulerDepotAppel p_manipulerDepotAppel)
        {
            this.m_manipulerDepotAppel = p_manipulerDepotAppel;
        }

        // ** Méthodes ** //
            // POST: api/appels
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody] AppelAPIDTO p_appel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Appel nouvelAppel = p_appel.VersIdentite();
            this.m_manipulerDepotAppel.CreerAppel(nouvelAppel);
            
            return NoContent();
            //return CreatedAtAction(nameof(Get), new { id = p_appel.IdentifiantAgent }, p_appel);
        }

            // PUT: api/appels
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult PUT(Guid id, [FromBody] AppelAPIDTO p_compteBancaire)
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

            return NoContent();
        }

    }
}
