using Database;
using Database.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiServer.Models;
using WebApiServer.Services;

namespace WebApiServer.Repositories
{
    public class TargetDoctorRepository
    {
        internal static DataResult SeeAllRequests(User user, long? dateTimeFrom, long? dateTimeTo)
        {
            if (!ValidateService.ValidateDateTime(dateTimeFrom) || !ValidateService.ValidateDateTime(dateTimeTo))
            {
                return ValidateService.BadTicksValue;
            }
            using (var db = new Context())
            {
                return new DataResult()
                {
                    Data = db.Requests.Where(s => s.datetime_created < new DateTime(dateTimeTo.Value) &&
                    s.datetime_created > new DateTime(dateTimeFrom.Value) &&
                    s.FK_ID_doctor == user.ID).Select(s => new RequestModel
                    {
                        DateTime = s.datetime_appointment,
                        PatientFirstName = s.Patient.first_name,
                        PatientLastName = s.Patient.last_name,
                        PatientID = s.Patient.ID
                    }).ToList(),
                    Status = RequestStatus.Success
                };
            }
        }

        internal static DataResult SetSpecialization(User user, string specialization)
        {
            using (var db = new Context())
            {
                var doctor = db.User
                    .Include(s => s.Specialization)
                    .Where(s => s.ID == user.ID).FirstOrDefault();
                if (doctor.Specialization != null)
                {
                    doctor.Specialization.specialization = specialization;
                }
                else
                {
                    doctor.Specialization = new DoctorSpecialization
                    {
                        specialization = specialization
                    };
                }
                db.SaveChanges();
                return new DataResult()
                {
                    Data = "Specialization changed to " + specialization,
                    Status = RequestStatus.Success
                };
            }
        }

        internal static DataResult SetWorkingTime(User user, long? timeSpanFrom, long? timeSpanTo)
        {
            if (!ValidateService.ValidateTimeSpan(timeSpanFrom) || !ValidateService.ValidateTimeSpan(timeSpanTo))
            {
                return ValidateService.BadTicksValue;
            }
            using (var db = new Context())
            {
                var doctor = db.User
                  .Include(s => s.DoctorWorkingTime)
                  .Where(s => s.ID == user.ID).FirstOrDefault();
                if (doctor.DoctorWorkingTime != null)
                {
                    doctor.DoctorWorkingTime.time_from = new TimeSpan(timeSpanFrom.Value);
                    doctor.DoctorWorkingTime.time_to = new TimeSpan(timeSpanTo.Value);
                }
                else
                {
                    doctor.DoctorWorkingTime = new DoctorWorkingTime
                    {
                        time_from = new TimeSpan(timeSpanFrom.Value),
                        time_to = new TimeSpan(timeSpanTo.Value)
                    };
                }
                db.SaveChanges();
                return new DataResult()
                {
                    Data = "Working time changed from " + new TimeSpan(timeSpanFrom.Value).ToString("hh\\:mm") + 
                    " to " + new TimeSpan(timeSpanTo.Value).ToString("hh\\:mm"),
                    Status = RequestStatus.Success
                };
            }
            throw new NotImplementedException();
        }
    }
}
