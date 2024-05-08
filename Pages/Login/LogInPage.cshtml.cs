using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace EksamenSem2.Pages.Login
{

    public class LogInPageModel : PageModel
    {
        private IMedabejderDataService _medarbejderDataService;

        public static Medarbejder LoggedInMedarbejder { get; set; }

        [BindProperty]
        public string Email { get; set; }


        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }

        public LogInPageModel(IMedabejderDataService medarbejderDataService)
        {
            _medarbejderDataService = medarbejderDataService;
        }

        public IMedabejderDataService Get_medarbejderDataService()
        {
            return _medarbejderDataService;
        }

        public async Task<IActionResult> OnPost(IMedabejderDataService _medarbejderDataService)
        {
            LoggedInMedarbejder = _medarbejderDataService.VerifyUser(Email, Password);

            if (LoggedInMedarbejder == null)
            {
                Message = "Invalid attempt";
                return Page();
            }

            // Log in with identity
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                BuildClaimsPrincipal(LoggedInMedarbejder));

            return RedirectToPage("/Index");
        }
        private ClaimsPrincipal BuildClaimsPrincipal(Medarbejder medarbejder)
        {
            // Build Claims
            List<Claim> claims = new List<Claim> {
          new Claim(ClaimTypes.Name, medarbejder.Email)
      };

            if (medarbejder.Email == "admin")
                claims.Add(new Claim(ClaimTypes.Role, "admin"));

            // Create claims-based identity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            // Create and return principal
            return new ClaimsPrincipal(claimsIdentity);
        }


    }
}

