//jonas
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EksamenSem2.Pages.Kalender
{
    public class GodeKendeOverArbejdeModel : PageModel
    {
        private readonly IVagtPlanDataService _vagtPlanDataService;

        public GodeKendeOverArbejdeModel(IVagtPlanDataService vagtPlanDataService)
        {
            _vagtPlanDataService = vagtPlanDataService;
        }

        public List<VagtPlan> VagtPlans { get; set; }

        public void OnGet()
        {
            VagtPlans = _vagtPlanDataService.GetAll().Where(vp => vp.Overtid != null).ToList();
        }

        public IActionResult OnPostApprove(int vagtPlanId)
        {
            _vagtPlanDataService.GodeKendeOverArbejde(vagtPlanId);
            return RedirectToPage();
        }
        public IActionResult OnPostDisapprove(int vagtPlanId)
        {
            _vagtPlanDataService.ForKasteOverArbejde(vagtPlanId);
            return RedirectToPage();
        }
    }
}
