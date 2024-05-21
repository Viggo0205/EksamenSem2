using EksamenSem2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EksamenSem2.ModelsCustom
{
    public partial class PlanDatum
    {
        public DateTime? Dato { get; set; }

        public TimeSpan? StartTid { get; set; }

        public TimeSpan? SlutTid { get; set; }

        public double? Overtid { get; set; }

        [Column(TypeName = "text")]
        public string Beskrivelse { get; set; }

        public int? TotalTimer { get; set; }

        [InverseProperty("Plan")]
        public virtual ICollection<VagtPlan> VagtPlans { get; set; } = new List<VagtPlan>();
    }
}
