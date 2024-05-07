using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;
using EksamenSem2.Models;

namespace EksamenSem2.Models;
public partial class Medarbejder
{
    /// <summary>
    /// This constructor should be used when creatng new object to be managed by EF Core, 
    /// since it does NOT set the navigation properties, but rather sets the corresponding identifiers.
    /// </summary>
    /// 
    public Medarbejder() {}

    public Medarbejder(string navn, string email, int tlfNr, int rolleId, string password)
    {
        Navn = navn;
        Email = email;
        TlfNr = tlfNr;
        RolleId = rolleId;
        Password = password;
    }

    
}