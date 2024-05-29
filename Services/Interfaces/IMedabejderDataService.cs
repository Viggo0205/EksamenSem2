// Victor og Oliver
using EksamenSem2.Models;

namespace EksamenSem2.Services.Interfaces
{
    public interface IMedabejderDataService : IDataService<Medarbejder>
    {
        Medarbejder? VerifyUser(string providedEmail, string providedPassword);
        void UpdateInfoForMedarbejder(int id, string navn, string password, int? tlfNr);
        void ForgotPassword(int id, string password);
        List<Medarbejder?> ReadByName(string navn);
    }
}
