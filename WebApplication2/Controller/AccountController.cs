using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controller
{
    public class AccountController : ControllerBase
    {


        public IActionResult Index()
        {
            return View();
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }
    }
}


