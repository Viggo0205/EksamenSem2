using EksamenSem2.Models;
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

    public override bool Delete(int id)
    {
        using auden_dk_db_eksamenContext context = new auden_dk_db_eksamenContext();

        foreach (PlanDatum pd in context.PlanData) //Sletter data for en vagtplan
        {
            if (pd.PlanId == id)
            {
                context.PlanData.Remove(pd);
            }
        }

        context.SaveChanges();

        return base.Delete(id);
    }

}

