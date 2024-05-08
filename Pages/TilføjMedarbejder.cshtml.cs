using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EksamenSem2.Pages
{
    public class TilføjMedarbejderModel : PageModel
    {
        public Medarbejder Medarbejder { get; set; }

        public string ErrorMessage {  get; set; }

        public SelectList Kompetencer { get; set; }

        [BindProperty]
        public string Navn { get; set; }
        [BindProperty]
        public string Email {  get; set; }
        [BindProperty]
        public int TlfNr {  get; set; }
        public List<Skema> Vagtplan {  get; set; }
        public string Password { get; set; }
        public int RolleId { get; set; }
        public Rolle Rolle { get; set; }

        private IMedabejderDataService _medarbejderDataService;


        public TilføjMedarbejderModel(IMedabejderDataService medabejderDataService)
        {
          _medarbejderDataService = medabejderDataService;
        }



        public void OnGet()
        {
        }

        //public IActionResult OnPost()
        //{
        //}

    }
}
