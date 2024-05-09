using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenSem2.Pages.Login
{
    public class LogOutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            LogInPageModel.LoggedInMedarbejder = null;

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage("/Index");
        }
    }
}
