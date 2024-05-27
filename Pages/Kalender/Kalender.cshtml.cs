using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using EksamenSem2.Pages.Helpers;
using EksamenSem2.Pages.Login;
using System.Runtime.CompilerServices;

namespace EksamenSem2.Pages.Kalender
{
    public class KalenderModel : PageModel
    {
        private readonly IVagtPlanDataService _vagtPlanDataService;
        public static DateTime ThisWeek {  get; set; } = DateTime.Now;
        [TempData]
        public DateTime StartOfWeek
        {
            get { return ThisWeek; }
            set { ThisWeek = value; }
        }


        public List<PlanDatum> WeeklyPlanData { get; set; }

        [BindProperty]
        public int VagtPlanId { get; set; }

        [BindProperty]
        public double Overtid { get; set; }

        [BindProperty]
        public string Beskrivelse { get; set; }

        public double TotalTimeWithOvertid { get; private set; }
        public double TotalOvertid { get; private set; }

        public KalenderModel(IVagtPlanDataService vagtPlanDataService)
        {
            _vagtPlanDataService = vagtPlanDataService;
        }

        public void OnGet(DateTime? startOfWeek)
        {
            StartOfWeek = startOfWeek ?? (TempData["StartOfWeek"] as DateTime?) ?? DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
            LoadWeeklyPlanData();
        }

        public IActionResult OnPostPreviousWeek()
        {
            StartOfWeek = StartOfWeek.AddDays(-7);
            TempData["StartOfWeek"] = StartOfWeek;
            LoadWeeklyPlanData();
            return Page();
        }

        public IActionResult OnPostNextWeek()
        {
            StartOfWeek = StartOfWeek.AddDays(7);
            TempData["StartOfWeek"] = StartOfWeek;
            LoadWeeklyPlanData();
            return Page();
        }

        public IActionResult OnPostCurrentWeek()
        {
            StartOfWeek = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
            TempData["StartOfWeek"] = StartOfWeek;
            LoadWeeklyPlanData();
            return Page();
        }

        public IActionResult OnPostEditVagt()
        {
            var vagtPlan = _vagtPlanDataService.GetById(VagtPlanId);
            if (vagtPlan != null)
            {
                _vagtPlanDataService.RegisterOverTime(vagtPlan, Overtid, Beskrivelse);
                
            }
            LoadWeeklyPlanData();   
            return Page();
        }

        private void LoadWeeklyPlanData()
        {
            DateTime endOfWeek = StartOfWeek.AddDays(7);
            WeeklyPlanData = _vagtPlanDataService.GetPlanDataWithIncludes()
                .Where(p => p.StartDato >= StartOfWeek && p.SlutDato < endOfWeek && p.VagtPlans.Select(vp => vp.MedarbejderId).Contains(LogInPageModel.LoggedInMedarbejder.Id))
                .ToList();

            CalculateTotalTimes();
        }

        private void CalculateTotalTimes()
        {
            TotalTimeWithOvertid = 0;
            TotalOvertid = 0;

            foreach (var plan in WeeklyPlanData)
            {
                foreach (var vagtPlan in plan.VagtPlans)
                {
                    // Sum up approved overtime
                    if (vagtPlan.Godekente == true)
                    {
                        TotalOvertid += vagtPlan.Overtid ?? 0;
                    }

                    // Calculate the total planned time in hours considering multi-day spans
                    var startTime = vagtPlan.Plan.StartTid.Value;
                    var endTime = vagtPlan.Plan.SlutTid.Value;

                    double plannedTime;
                    if (endTime > startTime)
                    {
                        plannedTime = (endTime - startTime).TotalHours;
                    }
                    else
                    {
                        // If endTime is on the next day
                        plannedTime = (endTime - startTime).TotalHours + 24;
                    }
                    plannedTime = Math.Round(plannedTime);
                    // Sum up total time including approved overtime
                    TotalTimeWithOvertid += plannedTime + (vagtPlan.Godekente == true ? vagtPlan.Overtid ?? 0 : 0);
                }
            }
        }
    }
}
