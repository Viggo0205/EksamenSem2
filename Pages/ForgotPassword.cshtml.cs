using EksamenSem2.Pages.Login;
using EksamenSem2.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EksamenSem2.Pages
{
    public class ForgotPasswordModel : PageModel
    {
		public List<Models.Medarbejder>? Medarbejder { get; private set; }
        [BindProperty]
		public string Email {  get; set; }
        [BindProperty]
        public string Password { get; set; }

        IMedabejderDataService _medarbejderDataService;

        public ForgotPasswordModel(IMedabejderDataService medabejderDataService)
        {
            _medarbejderDataService = medabejderDataService;
        }

        public void OnGet()
        {
        }

		public IActionResult OnPost()
		{
           
            Medarbejder = _medarbejderDataService.GetAll();
			int id = 0;
            for(int i = 0; i < Medarbejder.Count; i++)
            {
                if (Medarbejder[i].Email == Email)
                {
                    id = Medarbejder[i].Id;
                }
            }
            _medarbejderDataService.ForgotPassword(id, Password);

			return RedirectToPage("/Index");
		}
	}
}
