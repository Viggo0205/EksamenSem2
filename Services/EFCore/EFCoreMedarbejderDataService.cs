
using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;

public class EFCoreMedarbejderDataService : EFCoreDataServiceBase<Medarbejder>, IMedabejderDataService
{



    public Medarbejder? ReadByName(string name)
    {
        using auden_dk_db_eksamenContext context = new auden_dk_db_eksamenContext();

        return GetAllWithIncludes(context).FirstOrDefault(x => x.Navn == name);
    }

    //public Medarbejder? RemoveById(int id)
    //{
    //    using auden_dk_db_eksamenContext context = new auden_dk_db_eksamenContext();

    //    Medarbejder? ansat = context.Set<Medarbejder>().Find(x => x.Id == id);
    //    if (ansat = null)
    //        return false;   

    //    context.Set<Medarbejder>().Remove(ansat);
    //    return (context.SaveChanges() > 0);
    //}


        public Medarbejder? VerifyUser(string providedUserName, string providedPassword)
        {
            Medarbejder? medarbejder = GetAll().FirstOrDefault(u => u.Email == providedUserName);

            if (medarbejder == null || medarbejder.Password != providedPassword)
                return null;

            return medarbejder;
        }

    public Medarbejder? VerifyUser()
    {
        throw new NotImplementedException();
    }

     public override bool Delete(int id)
    {
        using auden_dk_db_eksamenContext context = new auden_dk_db_eksamenContext();

        foreach (MedarbejderKompetence mk in context.MedarbejderKompetences)
        {
            if (mk.MedarbejderId == id)
            {
                context.MedarbejderKompetences.Remove(mk);
            }
        }

        foreach (VagtPlan mk in context.VagtPlans)
        {
            if (mk.MedarbejderId == id)
            {
                context.VagtPlans.Remove(mk);
            }
        }
        context.SaveChanges();

        return base.Delete(id);
    }
        
}

