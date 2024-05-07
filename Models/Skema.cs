namespace EksamenSem2.Models
{
    public class Skema
    {
        public int MedarbejderID { get; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
