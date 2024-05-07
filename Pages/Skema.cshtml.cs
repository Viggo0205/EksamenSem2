using EksamenSem2.Models;
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
            // Load existing work schedules from database
        }

        public void OnPost()
        {
            // Save new work schedule to database
        }
    }
}
