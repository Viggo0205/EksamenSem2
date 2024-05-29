// Victor og Jonas
using EksamenSem2.Models;
using System.Collections.Generic;

namespace EksamenSem2.Services.Interfaces
{
    public interface IVagtPlanDataService : IDataService<VagtPlan>
    {
        List<PlanDatum> GetPlanDataWithIncludes();
        void AddPlanData(PlanDatum planData);
        VagtPlan GetById(int id);
        VagtPlan RegisterOverTime(VagtPlan vagtPlan, double time, string description);
        VagtPlan GodeKendeOverArbejde(int vagtPlanId);
        VagtPlan ForKasteOverArbejde(int vagtPlanId);
        
        void UpdateInfoForVagtPlan(int id, TimeSpan startTime, TimeSpan endTime);
    }
}
