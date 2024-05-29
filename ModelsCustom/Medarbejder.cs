// victor og tobias
using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EksamenSem2.Models;
public partial class Medarbejder : IHasId
{
    public Medarbejder() {}

    public Medarbejder(string navn, string email, int tlfNr, int rolleId, string password, MedarbejderKompetence kompetences, double timeløn)
    {
        Navn = navn;
        Email = email;
        TlfNr = tlfNr;
        RolleId = rolleId;
        Password = password;
        MedarbejderKompetences = (ICollection<MedarbejderKompetence>)kompetences;
        Timeløn = timeløn;

}
   

}