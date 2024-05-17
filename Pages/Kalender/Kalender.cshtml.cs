using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using EksamenSem2.Pages.Helpers;

namespace EksamenSem2.Pages.Kalender
{
    public class KalenderModel : PageModel
    {
        private readonly IVagtPlanDataService _vagtPlanDataService;

        public KalenderModel(IVagtPlanDataService vagtPlanDataService)
        {
            _vagtPlanDataService = vagtPlanDataService;
        }

        [BindProperty]
        public DateTime StartOfWeek { get; set; }

        public List<PlanDatum> WeeklyPlanData { get; set; }

        public void OnGet(DateTime? startOfWeek)
        {
            StartOfWeek = startOfWeek ?? DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
            LoadWeeklyPlanData();
        }

        public IActionResult OnPostPreviousWeek()
        {
            StartOfWeek = StartOfWeek.AddDays(-7);
            LoadWeeklyPlanData();
            return Page();
        }

        public IActionResult OnPostNextWeek()
        {
            StartOfWeek = StartOfWeek.AddDays(7);
            LoadWeeklyPlanData();
            return Page();
        }

        private void LoadWeeklyPlanData()
        {
            DateTime endOfWeek = StartOfWeek.AddDays(7);
            WeeklyPlanData = _vagtPlanDataService.GetPlanDataWithIncludes()
                .Where(p => p.Dato >= StartOfWeek && p.Dato < endOfWeek)
                .ToList();
        }
    }
}
