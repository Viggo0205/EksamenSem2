using EksamenSem2.Models;
using EksamenSem2.Pages.Login;
using EksamenSem2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenSem2.Pages.Kalender
{
    public class UpdateVagtplanModel : PageModel
    {
        [BindProperty]
        public  PlanDatum PlanDatum {  get; set; }
        [BindProperty]
        public TimeSpan StartTid { get; set; }
        [BindProperty]
        public TimeSpan SlutTid { get; set; }


        IVagtPlanDataService _vagtPlanDataService;

        public UpdateVagtplanModel(IVagtPlanDataService vagtPlanDataService)
        {
            _vagtPlanDataService = vagtPlanDataService;
        }

        public void OnGet(int id)
        {
            using auden_dk_db_eksamenContext context = new auden_dk_db_eksamenContext();

            PlanDatum = context.PlanData.Find(id);
            
        }

        public IActionResult OnPost()
        {
            _vagtPlanDataService.UpdateInfoForVagtPlan(PlanDatum.PlanId,StartTid,SlutTid);
            return RedirectToPage("VagtPlan");
        }

    }
}
