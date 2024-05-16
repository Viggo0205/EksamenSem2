using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenSem2.Pages
{
    public class FjernMedarbejderModel : PageModel
    {
        [BindProperty]
        public Medarbejder Medarbejder { get; set; }
        public string ErrorMessage { get; set; }

        private IMedabejderDataService _medarbejderDataService;

        public FjernMedarbejderModel(IMedabejderDataService medabejderDataService)
        {
            _medarbejderDataService = medabejderDataService;
        }


        public void OnGet(int id)
        {
            Medarbejder = _medarbejderDataService.Read(id);
        }

        public IActionResult Onpost()
        {
            _medarbejderDataService.Delete(Medarbejder.Id);
            return RedirectToPage("/GetAllMedarbejderer");
        }

    }
}
