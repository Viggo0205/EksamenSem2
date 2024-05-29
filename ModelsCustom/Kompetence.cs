// victor
using EksamenSem2.Services.Interfaces;

namespace EksamenSem2.Models;
public partial class Kompetence : IHasId
{
    public Kompetence(){}
    public Kompetence(string navn, string beskrivelse)
    {
        Navn = navn;
        Beskrivelse = beskrivelse;
    }

}

