
using EksamenSem2.Services.Interfaces;
namespace EksamenSem2.Models;
public partial class Rolle : IHasId
{

    public Rolle(){}

    public Rolle(string navn, string rettigheder)
    {   
        Navn = navn;
        Rettigheder = rettigheder;
    }
    
    //public int Id { get; set; }
}

