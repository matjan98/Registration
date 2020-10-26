using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiServer.Repositories
{
    public static class HelperMethodsRepository
    {
        public const int VisitTime = 15;
        internal static bool DoctorIsFree(int doctorID, DateTime dateTime, Database.Context db)
        {
            return !db.Requests.Where(s => s.FK_ID_doctor == doctorID)
                .Any(s => s.datetime_appointment.AddMinutes(-VisitTime) < dateTime && s.datetime_appointment.AddMinutes(VisitTime) > dateTime);
        }
    }
}
