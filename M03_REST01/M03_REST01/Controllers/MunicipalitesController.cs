using M03_REST01.Filter;
using M03_REST01.SERVICE_Municipalite;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M03_REST01.Controllers
{
    [ApiKey()]
    [Route("api/municipalites")]
    [ApiController]
    public class MunicipalitesController : Controller
    {
        // ** Champs ** //
        private ManipulationMunicipalites m_manipulationMunicipalites;

        // ** Propriétés ** //

        // ** Constructeur ** //
        public MunicipalitesController(ManipulationMunicipalites p_manipulationMunicipalite)
        {
            this.m_manipulationMunicipalites = p_manipulationMunicipalite;
        }

        // ** Méthodes ** //

            // GET: MunicipalitesController
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<MunicipaliteModel>> Get()
        {
            IEnumerable<Municipalite> municipalitesExistantes = this.m_manipulationMunicipalites.ListerMunicipalites();
            return Ok(municipalitesExistantes.Select(municipalite => new MunicipaliteModel(municipalite)));
        }

            // GET: MunicipalitesController/Details/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<MunicipaliteModel> Get(int id)
        {
            Municipalite municipaliteTrouvee =  this.m_manipulationMunicipalites.ObtenirMunicipalite(id);

            if(municipaliteTrouvee is not null)
            {
                return Ok(new MunicipaliteModel(municipaliteTrouvee));
            }

            return NotFound();
        }

            // GET: MunicipalitesController/Create
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody] MunicipaliteModel p_municipalite)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            int dernierIndex = this.m_manipulationMunicipalites.ListerMunicipalites().OrderByDescending(municipalite => municipalite.CodeGeographique).FirstOrDefault()?.CodeGeographique ?? 0;
            p_municipalite.MunicipaliteId = dernierIndex + 1;

            this.m_manipulationMunicipalites.AjouterMunicipalite(p_municipalite.VersIdentite());
            return CreatedAtAction(nameof(Get), new { id = p_municipalite.MunicipaliteId }, p_municipalite);
        }

        // GET: MunicipalitesController/Edit/5
        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult put(int id, [FromBody] MunicipaliteModel p_municipaliteModel)
        {
            if(!ModelState.IsValid || id != p_municipaliteModel.MunicipaliteId)
            {
                return BadRequest();
            }

            if(!this.m_manipulationMunicipalites.ListerMunicipalites().Any(municipalite => municipalite.CodeGeographique == id))
            {
                return NotFound();
            }

            this.m_manipulationMunicipalites.MAJMunicipalite(p_municipaliteModel.VersIdentite());

            return NoContent();
        }

        // GET: MunicipalitesController/Delete/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult Delete(int id)
        {
            if (!this.m_manipulationMunicipalites.ListerMunicipalites().Any(municipalite => municipalite.CodeGeographique == id))
            {
                return NotFound();
            }

            this.m_manipulationMunicipalites.SupprimerMunicipalite(id);

            return NoContent();
        }
    }
}
