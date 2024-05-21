using EksamenSem2.Models;

namespace EksamenSem2.Services.Interfaces
{
    public interface IMedabejderDataService : IDataService<Medarbejder>
    {
        /// <summary>
        /// Verifies that a provided user name and password matches a known user profile.
        /// </summary>
        /// <returns>User matching the provided information, otherwise null.</returns>
        /// 
        Medarbejder? VerifyUser(string providedEmail, string providedPassword);
        void UpdateInfoForMedarbejder(int id, string navn, string password);
    }
}
