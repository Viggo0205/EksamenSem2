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
            // tjekker om user inputtet at den ikke er null eller tom
            if (!string.IsNullOrEmpty(SearchString)) 
            {
                Medarbejder = _medarbejderService.ReadByName(SearchString);  // anvender metoden fra service klassen
            }
               else
            {
                Medarbejder = _medarbejderService.GetAll();
            }

            return Page();
        }


        public void OnGet()
        {
            Medarbejder = _medarbejderService.GetAll();
            if (LogInPageModel.LoggedInMedarbejder == null) // tvinges Signout når man starter up
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }
    }
}
