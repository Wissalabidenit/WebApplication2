using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Pages
{
    public class loginModel : PageModel
    {

        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool isAuthenticated = CheckAuthentication(Username, Password);

                if (isAuthenticated)
                {
                    return RedirectToPage("/Archive");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                }
            }

            return Page();
        }

        private bool CheckAuthentication(string username, string password)
        {
            
            string connectionString = @"Data Source=WISSAL\WINCC;Initial Catalog=database;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}



