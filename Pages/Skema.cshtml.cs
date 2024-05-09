using EksamenSem2.Models;
using EksamenSem2.Pages.Login;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenSem2.Pages
{
    public class SkemaModel : PageModel
    {
        [BindProperty]
        public Skema Skema{ get; set; }

        public void OnGet()
        {


        }

        public void OnPost()
        {
            // Save new work schedule to database
        }
    }
}
