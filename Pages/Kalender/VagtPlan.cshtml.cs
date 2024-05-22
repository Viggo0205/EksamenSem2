using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EksamenSem2.Pages.Kalender
{
    public class VagtPlanModel : PageModel
    {
        private readonly IVagtPlanDataService _vagtPlanDataService;


        [BindProperty]
        public VagtPlan VagtPlan { get; set; }
        [BindProperty]
        public DateTime StartTime { get; set; }
        [BindProperty]
        public DateTime EndTime { get; set; }
        public List<PlanDatum> PlanDatas { get; set; }


        public SelectList Emails { get; set; }
        public VagtPlanModel(IMedabejderDataService service, IVagtPlanDataService vagtPlanDataService)
        {
            _vagtPlanDataService = vagtPlanDataService;
            Emails = new SelectList(service.GetAll(), nameof(Medarbejder.Id), nameof(Medarbejder.Email));
        }
        public void OnGet()
        {

            PlanDatas = _vagtPlanDataService.GetPlanDataWithIncludes();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var planData = new PlanDatum
                {
                    Dato = StartTime.Date,
                    StartTid = StartTime.TimeOfDay,
                    SlutTid = EndTime.TimeOfDay,
                    //Beskrivelse = "Scheduled shift"
                };

                _vagtPlanDataService.AddPlanData(planData);

                var vagtPlan = new VagtPlan
                {
                    MedarbejderId = VagtPlan.MedarbejderId,
                    PlanId = planData.PlanId
                };

                _vagtPlanDataService.Create(vagtPlan);

                return RedirectToPage();
            }

            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            using auden_dk_db_eksamenContext context = new auden_dk_db_eksamenContext();

            foreach (VagtPlan vp in context.VagtPlans) //Sletter VagtPlan før selve dataen
            {
                if (vp.PlanId == id)
                {
                    context.VagtPlans.Remove(vp);
                }
            }
            context.SaveChanges();
            _vagtPlanDataService.Delete(VagtPlan.Id);
            return RedirectToPage();
        }
    }
}
