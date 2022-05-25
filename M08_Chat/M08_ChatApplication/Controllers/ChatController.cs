using Microsoft.AspNetCore.Mvc;

namespace M08_ChatApplication.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
