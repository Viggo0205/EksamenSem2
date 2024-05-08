
using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;

public class EFCoreMedarbejderDataService : EFCoreDataServiceBase<Medarbejder>, IMedabejderDataService
{



    public Medarbejder? ReadByName(string name)
    {
        using auden_dk_db_eksamenContext context = new auden_dk_db_eksamenContext();

        return GetAllWithIncludes(context).FirstOrDefault(x => x.Navn == name);
    }

}

