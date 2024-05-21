using EksamenSem2.Models;
//using EksamenSem2.ModelsCustom;
using EksamenSem2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class EFCoreVagtPlanDataService : EFCoreDataServiceBase<VagtPlan>, IVagtPlanDataService
{


    protected override IQueryable<VagtPlan> GetAllWithIncludes(auden_dk_db_eksamenContext context)
    {
        // Include related entities as needed
        return context.Set<VagtPlan>()
            .Include(vp => vp.Medarbejder)
            .Include(vp => vp.Plan);
    }

    public List<PlanDatum> GetPlanDataWithIncludes()
    {
        using var context = new auden_dk_db_eksamenContext();
        return context.PlanData
            .Include(pd => pd.VagtPlans)
            .ThenInclude(vp => vp.Medarbejder)
            .ToList();
    }

    public void AddPlanData(PlanDatum planData)
    {
        using var context = new auden_dk_db_eksamenContext();
        context.PlanData.Add(planData);
        context.SaveChanges();
    }

    public VagtPlan RegisterOverTime(VagtPlan vagtPlan, double time, string description)
    {
        vagtPlan.Overtid = time;
        vagtPlan.Beskrivelse = description;
        return vagtPlan;
    }

    public void UpdateInfoForVagtPlan(int id, TimeSpan startTid, TimeSpan slutTid)
    {
        using auden_dk_db_eksamenContext context = new auden_dk_db_eksamenContext();

        PlanDatum planDatum = context.PlanData.Find(id);
        planDatum.StartTid = startTid;
        planDatum.SlutTid = slutTid;
        context.PlanData.Update(planDatum);
        context.SaveChanges();
    }
}

