using M03_REST01.SERVICE_Municipalite;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M03_REST01.Controllers
{
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
        public ActionResult Create()
        {
            return View();
        }

            // POST: MunicipalitesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

            // GET: MunicipalitesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

            // POST: MunicipalitesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

            // GET: MunicipalitesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

            // POST: MunicipalitesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
