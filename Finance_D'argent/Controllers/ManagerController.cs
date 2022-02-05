using Microsoft.AspNetCore.Mvc;

namespace Finance_D_argent.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
