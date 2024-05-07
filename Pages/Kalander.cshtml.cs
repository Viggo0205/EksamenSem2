using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenSem2.Pages
{
    public class KalanderModel : PageModel
    {
        public Dictionary<DayOfWeek, Dictionary<TimeSpan, string>> WeeklyEvents { get; set; }

        public void OnGet()
        {
            WeeklyEvents = new Dictionary<DayOfWeek, Dictionary<TimeSpan, string>>();

            var times = Enumerable.Range(7, 17).Select(i => TimeSpan.FromHours(i)).ToList();

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                if (day != DayOfWeek.Sunday && day != DayOfWeek.Saturday)
                {
                    var dailyEvents = new Dictionary<TimeSpan, string>();

                    foreach (var time in times)
                    {
                        dailyEvents[time] = ""; // starter den uden at have nogen events 
                    }

                    WeeklyEvents[day] = dailyEvents;
                }
            }

            // Hardcoded events
            WeeklyEvents[DayOfWeek.Monday][new TimeSpan(7, 0, 0)] = "ny vagt";
            WeeklyEvents[DayOfWeek.Tuesday][new TimeSpan(7, 0, 0)] = "Vagt slut";
        }
    }
}
