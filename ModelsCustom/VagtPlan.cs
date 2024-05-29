// Jonas
using EksamenSem2.Services.Interfaces;

namespace EksamenSem2.Models
{
    public partial class VagtPlan : IHasId
    {
        public VagtPlan() { }

        public VagtPlan(int MedarbejderId, int planId) 
        {
            Id = MedarbejderId; 
            PlanId = planId;
        }
    }
}
