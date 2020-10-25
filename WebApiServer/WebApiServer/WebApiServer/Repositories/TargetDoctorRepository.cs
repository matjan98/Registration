using Database.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiServer.Repositories
{
    public class TargetDoctorRepository
    {
        internal static object SeeAllRequests(User user, long? dateTimeFrom, long? dateTimeTo)
        {
            throw new NotImplementedException();
        }

        internal static object SetSpecialization(User user, string specialization)
        {
            throw new NotImplementedException();
        }

        internal static object SetWorkingTime(User user, long? timeSpanFrom, long? timeSpanTo)
        {
            throw new NotImplementedException();
        }
    }
}
