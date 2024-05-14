using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class ContactModel : PageModel
    {
        public string username = "";
        public string Password = "";
        public bool hasdata = false;
        public void OnGet()
        {
        }
        public void OnPost()
        {
            hasdata = true;
            username = Request.Form["username"];
            Password = Request.Form["Password"];


        }
    }
}
