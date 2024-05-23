using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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
            var today = DateTime.Today;
            StartTime = today;
            EndTime = today;
            PlanDatas = _vagtPlanDataService.GetPlanDataWithIncludes();
        }

        public IActionResult OnPost()
        {
            if (StartTime < DateTime.Today)
            {
                ModelState.AddModelError("StartTime", "Start tid can ikke v�re tidliger end idag.");
            }

            if (EndTime < StartTime)
            {
                ModelState.AddModelError("EndTime", "slut tid can ikke v�re f�r start tid");
            }
            if (EndTime == StartTime)
            {
                ModelState.AddModelError("EndTime", "slut tid can ikke v�re det samme som start tid");
            }
            if (EndTime > DateTime.Today.AddDays(2))
            {
                ModelState.AddModelError("EndTime", "en arbejds dage kan ikke v�re lenger end 1 dages tid");
            }

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
            PlanDatas = _vagtPlanDataService.GetPlanDataWithIncludes(); // Ensure PlanDatas is reloaded if ModelState is invalid
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            using var context = new auden_dk_db_eksamenContext();

            foreach (var vp in context.VagtPlans)
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
