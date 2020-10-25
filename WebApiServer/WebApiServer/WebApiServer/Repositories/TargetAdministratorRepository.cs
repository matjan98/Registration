using Database.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiServer.Repositories
{
    public class TargetAdministratorRepository
    {
        internal static object CreateReservation(int doctorID, int patientID, long? datetime)
        {
            throw new NotImplementedException();
        }

        internal static object AddUser(string first_name, string last_name, string username, string password, AccountType accountType)
        {
            throw new NotImplementedException();
        }

        internal static object CancelReservation(int reservationID)
        {
            throw new NotImplementedException();
        }

        internal static object RemoveUser(int userID)
        {
            throw new NotImplementedException();
        }

        internal static object SetPerrmisions(int userID, AccountType accountType)
        {
            throw new NotImplementedException();
        }

        internal static object ListAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
