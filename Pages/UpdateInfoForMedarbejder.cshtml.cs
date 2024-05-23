using EksamenSem2.Models;
using EksamenSem2.Pages.Login;
using EksamenSem2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenSem2.Pages
{
    public class UpdateInfoForMedarbejderModel : PageModel
    {

        [BindProperty]
        public string Navn { get; set; }
        [BindProperty]
        public string Password {  get; set; }
        [BindProperty]
        public int? TlfNr { get; set;}

        private IMedabejderDataService _medarbejderDataService;


        public UpdateInfoForMedarbejderModel(IMedabejderDataService medabejderDataService)
        {
                _medarbejderDataService= medabejderDataService;
        }
        public void OnGet()
        {
            Medarbejder m = _medarbejderDataService.Read(LogInPageModel.LoggedInMedarbejder.Id);
            Navn = m.Navn;
            Password = m.Password;
            TlfNr = m.TlfNr;

        }

        public IActionResult OnPost()
        {
            _medarbejderDataService.UpdateInfoForMedarbejder(LogInPageModel.LoggedInMedarbejder.Id, Navn, Password, TlfNr);
            return RedirectToPage("/Index");
        }

    }
}
