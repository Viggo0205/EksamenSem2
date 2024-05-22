using EksamenSem2.Pages.Login;
using EksamenSem2.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace EksamenSem2.Pages
{
    public class GetAllMedarbejdererModel : PageModel
    {
        public List<Models.Medarbejder>? Medarbejder { get; private set; }

        [BindProperty]
        public string SearchString { get; set; }



        private IMedabejderDataService _medarbejderService;

        public GetAllMedarbejdererModel(IMedabejderDataService medabejderDataService )
        {
            _medarbejderService = medabejderDataService;
        }

        public IActionResult OnPostNameSearch()
        {
           
       

            return Page();
        }


        public void OnGet()
        {
            Medarbejder = _medarbejderService.GetAll();
            if (LogInPageModel.LoggedInMedarbejder == null) // Force Signout on startup
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }
    }
}
