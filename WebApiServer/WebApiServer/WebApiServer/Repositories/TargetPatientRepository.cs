using Database.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiServer.Repositories
{
    public class TargetPatientRepository
    {
        internal static object BookAnAppointmentWithDoctor(Database.Tables.User user, int doctorID, long? dateTime)
        {
            throw new NotImplementedException();
        }

        internal static object CancelAnAppointmentWithDoctor(User user, int reserwationID)
        {
            throw new NotImplementedException();
        }

        internal static object ListBookedAppointments(User user)
        {
            throw new NotImplementedException();
        }

        internal static object ListDoctorAccesibility(int doctorID, long? dateTimeFrom, long? dateTimeTo)
        {
            throw new NotImplementedException();
        }

        internal static object ListDoctors()
        {
            throw new NotImplementedException();
        }
    }
}
