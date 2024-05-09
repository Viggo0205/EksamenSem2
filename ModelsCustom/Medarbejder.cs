using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EksamenSem2.Models;
public partial class Medarbejder : IHasId
{
    /// <summary>
    /// This constructor should be used when creatng new object to be managed by EF Core, 
    /// since it does NOT set the navigation properties, but rather sets the corresponding identifiers.
    /// </summary>
    /// 
    public Medarbejder() {}

    public Medarbejder(string navn, string email, int tlfNr, int rolleId, string password, Kompetence kompetences, double timeløn)
    {
        Id = 0;
        Navn = navn;
        Email = email;
        TlfNr = tlfNr;
        RolleId = rolleId;
        Password = password;
        Kompetences = (ICollection<Kompetence>)kompetences;
        Timeløn = timeløn;
    }
}