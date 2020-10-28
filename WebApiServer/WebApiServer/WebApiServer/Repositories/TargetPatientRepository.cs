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
    public class TargetPatientRepository
    {
        internal static DataResult BookAnAppointmentWithDoctor(User user, int doctorID, long? dateTime)
        {
            if (!ValidateService.ValidateDateTime(dateTime))
            {
                return ValidateService.BadTicksValue;
            }
            using (var db = new Context())
            {
                if (!HelperMethodsRepository.DoctorIsFree(doctorID, new DateTime(dateTime.Value), db))
                {
                    return new DataResult
                    {
                        Data = "Doctor is not avaible at this time",
                        Status = RequestStatus.Fail
                    };
                }
                db.Requests.Add(new Request
                {
                    datetime_appointment = new DateTime(dateTime.Value),
                    datetime_created = DateTime.Now,
                    FK_ID_doctor = doctorID,
                    FK_ID_patient = user.ID,
                });
                db.SaveChanges();
                return new DataResult
                {
                    Data = "An appointment successfully booked",
                    Status = RequestStatus.Success
                };
            }
        }

        internal static DataResult CancelAnAppointmentWithDoctor(User user, int reservationID)
        {
            using (var db = new Context())
            {
                var requestToDelete = db.Requests.Where(s => s.FK_ID_patient == user.ID && s.ID_request == reservationID).FirstOrDefault();
                if(requestToDelete == null)
                {
                    return new DataResult
                    {
                        Data = "There is no reserwation " + reservationID.ToString() + " related with user " + user.user_name,
                        Status = RequestStatus.Fail
                    };
                }
                db.Requests.Remove(requestToDelete);
                db.SaveChanges();
                return new DataResult
                {
                    Data = "Reserwation " + reservationID.ToString() + " cancelled",
                    Status = RequestStatus.Success
                };
            }
        }

        internal static DataResult ListBookedAppointments(User user)
        {
            using (var db = new Context())
            {
                var appointments = db.Requests
                    .Include(s => s.Doctor).ThenInclude(s => s.Specialization)
                    .Where(s => s.FK_ID_patient == user.ID).Select(s => new BookedAppointment
                    {
                        DateTime = s.datetime_appointment,
                        DoctorFirstName = s.Doctor.first_name,
                        DoctorID = s.FK_ID_doctor,
                        DoctorLastName = s.Doctor.last_name,
                        DoctorSpecializaion = s.Doctor.Specialization.specialization
                    }).ToList();
                return new DataResult
                {
                    Data = appointments,
                    Status = RequestStatus.Success
                };
            }
            throw new NotImplementedException();
        }

        internal static DataResult ListDoctorAccesibility(int doctorID, long? dateTimeFrom, long? dateTimeTo)
        {
            if (!ValidateService.ValidateDateTime(dateTimeFrom) || !ValidateService.ValidateDateTime(dateTimeTo))
            {
                return ValidateService.BadTicksValue;
            }
            using (var db = new Context())
            {
                var doctorWorkingTime = db.DoctorWorkingTime.Where(s => s.FK_ID_User == doctorID).FirstOrDefault();
                return new DataResult
                {
                    Data = new DoctorAccessiblity
                    {
                        Visits = db.Requests.Where(s => s.FK_ID_doctor == doctorID &&
                            s.datetime_appointment < new DateTime(dateTimeTo.Value) &&
                            s.datetime_appointment > new DateTime(dateTimeFrom.Value))
                            .Select(s => s.datetime_appointment).ToList(),
                        VisitTimeInMinutes = HelperMethodsRepository.VisitTime,
                        WorkingTimeFrom = doctorWorkingTime?.time_from ?? new TimeSpan(),
                        WorkingTimeTo = doctorWorkingTime?.time_to ?? new TimeSpan(),
                    },
                    Status = RequestStatus.Success
                };
            }
        }

        internal static DataResult ListDoctors()
        {
            using (var db = new Context())
            {
                return new DataResult
                {
                    Data = db.User
                    .Include(s => s.Specialization)
                    .Where(s => s.account_type == AccountType.Doctor).Select(s => new DoctorModel
                    {
                        FirstName = s.first_name,
                        ID = s.ID,
                        LastLogged = s.last_logged,
                        LastName = s.last_name,
                        Specialization = s.Specialization.specialization
                    }).ToList(),
                    Status = RequestStatus.Success
                };
            }
            throw new NotImplementedException();
        }
    }
}
