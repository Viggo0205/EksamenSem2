
using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;

public class EFCoreMedarbejderDataService : EFCoreDataServiceBase<Medarbejder>, IMedabejderDataService
{



    public List<Medarbejder?> ReadByName(string navn)
    {
        using auden_dk_db_eksamenContext context = new auden_dk_db_eksamenContext();

        return GetAllWithIncludes(context).Where(x => x.Navn.Contains(navn)).ToList();
    }


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

    public void UpdateInfoForMedarbejder(int id, string navn, string password)
    {
        using auden_dk_db_eksamenContext context = new auden_dk_db_eksamenContext();

        Medarbejder medarbejder = Read(id);
        medarbejder.Navn = navn;
        medarbejder.Password = password;
        context.Set<Medarbejder>().Update(medarbejder);
        context.SaveChanges();
    }

	public void ForgotPassword(int id, string password)
	{
		using auden_dk_db_eksamenContext context = new auden_dk_db_eksamenContext();

		Medarbejder medarbejder = Read(id);
		medarbejder.Password = password;
		context.Set<Medarbejder>().Update(medarbejder);
		context.SaveChanges();
	}
}

