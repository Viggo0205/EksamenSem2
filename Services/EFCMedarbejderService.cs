using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;

namespace EksamenSem2.Services
{
    public class EFCMedarbejderService : EFCoreDataServiceBase<Medarbejder>, IMedabejderDataService
    {
        public Medarbejder? VerifyUser(string providedEmail, string providedPassword)
        {
            Medarbejder? medarbejder = GetAll().FirstOrDefault(u => u.Email == providedEmail);

            // Check if the email exists in the database and if the password matches
            if (medarbejder == null || medarbejder.Password != providedPassword)
                return null;

            return medarbejder;
        }
    }
}
