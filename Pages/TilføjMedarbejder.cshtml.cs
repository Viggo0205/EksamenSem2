//Victor og tobias
using EksamenSem2.Models;
using EksamenSem2.Pages.Login;
using EksamenSem2.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;


public class TilføjMedarbejderModel : PageModel
{
    [BindProperty]
    public Medarbejder Medarbejder { get; set; }

    public string ErrorMessage { get; set; }

    [BindProperty]
    public int[] SelectedKompetence {  get; set; }
    public SelectList Kompetencer { get; set; }    
    public string Password { get; set; }
    public SelectList SelectedRolle { get; set; }
    [BindProperty]
    public int RolleId {  get; set; }
   

    private IMedabejderDataService _medarbejderDataService;
    private IKompetenceDataService _kompetenceDataService;
    private IRolleDataService _RolleDataService;

   
    public TilføjMedarbejderModel(IMedabejderDataService medabejderDataService, IKompetenceDataService kompetenceDataService, IRolleDataService RolleDataSerivce)
    {
        _medarbejderDataService = medabejderDataService;
        _kompetenceDataService = kompetenceDataService;
        _RolleDataService = RolleDataSerivce;

        var komList = _kompetenceDataService.GetAll();
        Kompetencer = new SelectList(komList, nameof(Kompetence.Id), nameof(Kompetence.Navn));
        SelectedRolle = new SelectList(_RolleDataService.GetAll(), nameof(Rolle.Id), nameof(Rolle.Navn));
    }


    public void OnGet()
    {
    }

        public IActionResult OnPost()
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

        Medarbejder.RolleId = RolleId;

        _medarbejderDataService.Create(Medarbejder);
            return RedirectToPage("/GetAllMedarbejderer");
        }

}
   
