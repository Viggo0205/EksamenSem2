using EksamenSem2.Models;
using EksamenSem2.Pages.Login;
using EksamenSem2.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


public class TilføjMedarbejderModel : PageModel
{
    [BindProperty]
    public Medarbejder Medarbejder { get; set; }

    public string ErrorMessage { get; set; }

    [BindProperty]
    public int[] SelectedKompetence {  get; set; }
    public SelectList Kompetencer { get; set; }

    public List<Skema> Vagtplan { get; set; }
    public string Password { get; set; }
    public int RolleId { get; set; }
    public Rolle Rolle { get; set; }

    private IMedabejderDataService _medarbejderDataService;
    private IKompetenceDataService _kompetenceDataService;


    public TilføjMedarbejderModel(IMedabejderDataService medabejderDataService, IKompetenceDataService kompetenceDataService)
    {
        _medarbejderDataService = medabejderDataService;
        _kompetenceDataService = kompetenceDataService;


        var komList = _kompetenceDataService.GetAll();
        Kompetencer = new SelectList(komList, nameof(Kompetence.Id), nameof(Kompetence.Navn));
    }


    public void OnGet()
    {
    }

        public IActionResult Onpost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Medarbejder.MedarbejderKompetences = new List<MedarbejderKompetence>();

            foreach (int id in SelectedKompetence)
            {
                Medarbejder.MedarbejderKompetences.Add(new MedarbejderKompetence() { KompetenceId = id });
            }

            _medarbejderDataService.Create(Medarbejder);
            return RedirectToPage("/GetAllMedarbejderer");
        }

}
   
