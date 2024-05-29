// Matti, Victor og Jonas
using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class EFCoreVagtPlanDataService : EFCoreDataServiceBase<VagtPlan>, IVagtPlanDataService
{


    protected override IQueryable<VagtPlan> GetAllWithIncludes(auden_dk_db_eksamenContext context)
    {
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

    public VagtPlan GetById(int id)
    {
        using var context = new auden_dk_db_eksamenContext();
        return context.VagtPlans.Find(id);
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
    public override bool Delete(int id)
    {
        using auden_dk_db_eksamenContext context = new auden_dk_db_eksamenContext();
        var vagtPlan = context.VagtPlans.FirstOrDefault(vp => vp.Id == id);
        var planDataToRemove = context.PlanData.Where(pd => pd.PlanId == vagtPlan.PlanId).ToList();
        foreach (var pd in planDataToRemove)
        {
            context.PlanData.Remove(pd);
        }
        context.SaveChanges();
        return base.Delete(id);
    }
    public VagtPlan RegisterOverTime(VagtPlan vagtPlan, double time, string description)
    {
        using var context = new auden_dk_db_eksamenContext();
        var vagtPlanToUpdate = context.VagtPlans.Find(vagtPlan.Id);
        if (vagtPlanToUpdate != null)
        {
            vagtPlanToUpdate.Overtid = time;
            vagtPlanToUpdate.Beskrivelse = description;
            vagtPlanToUpdate.Godekente = false;
            context.SaveChanges();
        }
        return vagtPlanToUpdate;
    }
    public VagtPlan GodeKendeOverArbejde(int vagtPlanId)
    {
        using var context = new auden_dk_db_eksamenContext();
        var vagtPlanToUpdate = context.VagtPlans.Find(vagtPlanId);
        if (vagtPlanToUpdate != null)
        {
            vagtPlanToUpdate.Godekente = true;
            context.SaveChanges();
        }
        return vagtPlanToUpdate;
    }
    public VagtPlan ForKasteOverArbejde(int id)
    {
        using var context = new auden_dk_db_eksamenContext();
        var vagtPlan = context.VagtPlans.Find(id);
        if (vagtPlan != null)
        {
            vagtPlan.Overtid = null;
            vagtPlan.Beskrivelse = null;
            vagtPlan.Godekente = false;
            context.SaveChanges();
        }
        return vagtPlan;
    }
}

