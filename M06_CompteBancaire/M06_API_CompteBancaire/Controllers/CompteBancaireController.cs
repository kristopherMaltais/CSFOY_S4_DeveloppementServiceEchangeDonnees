using M06_API_CompteBancaire.Controllers.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace M06_API_CompteBancaire.Controllers
{
    //[ApiKey()]
    [Route("api/comptesBancaires")]
    [ApiController]
    public class CompteBancaireController : Controller
    {
        // ** Champs ** //

        // ** Propriétés ** //

        // ** Constructeurs ** //

        // ** Méthodes ** //

            // GET: api/comptesBancaires
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<CompteBancaireAPIDTO>> Get()
        {
            throw new NotImplementedException();
        }


            // GET: api/comptesBancaires/id
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<CompteBancaireAPIDTO> Get(int id)
        {
            throw new NotImplementedException();
        }


            // POST: api/comptesBancaires
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody] CompteBancaireAPIDTO p_compteBancaire)
        {
            throw new NotImplementedException();
        }


            // PUT: api/comptesBancaires
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult PUT(int id, [FromBody] CompteBancaireAPIDTO p_compteBancaire)
        {
            throw new NotImplementedException();
        }


            // DELETE: api/comptesBancaires/id 
        public ActionResult Delete(int id)
        {
            
        }

            // POST: CompteBancaireController/Edit/5
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

            // GET: CompteBancaireController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

            // POST: CompteBancaireController/Delete/5
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
