using Database;
using Database.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiServer.Models;
using WebApiServer.Services;

namespace WebApiServer.Repositories
{
    public class TargetAdministratorRepository
    {
        internal static DataResult CreateReservation(int doctorID, int patientID, long? datetime)
        {
            if (!ValidateService.ValidateDateTime(datetime))
            {
                return ValidateService.BadTicksValue;
            }
            using (var db = new Context())
            {
                if (!HelperMethodsRepository.DoctorIsFree(doctorID, new DateTime(datetime.Value)))
                {
                    return new DataResult
                    {
                        Data = "Doctor is not avaible at this time",
                        Status = RequestStatus.Fail
                    };
                }
                db.Requests.Add(new Request
                {
                    datetime_appointment = new DateTime(datetime.Value),
                    datetime_created = DateTime.Now,
                    FK_ID_doctor = doctorID,
                    FK_ID_patient = patientID,
                });
                db.SaveChanges();
                return new DataResult
                {
                    Data = "An appointment successfully booked",
                    Status = RequestStatus.Success
                };
            }
        }

        internal static DataResult AddUser(string first_name, string last_name, string username, string password, AccountType accountType)
        {

            if (string.IsNullOrWhiteSpace(first_name))
            {
                return new DataResult
                {
                    Data = "first_name is empty",
                    Status = RequestStatus.WrongData
                };
            }

            if (string.IsNullOrWhiteSpace(last_name))
            {
                return new DataResult
                {
                    Data = "last_name is empty",
                    Status = RequestStatus.WrongData
                };
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                return new DataResult
                {
                    Data = "username is empty",
                    Status = RequestStatus.WrongData
                };
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return new DataResult
                {
                    Data = "password is empty",
                    Status = RequestStatus.WrongData
                };
            }

            using (var db = new Context())
            {
                if (db.User.Where(s => s.user_name == username).FirstOrDefault() != null)
                {
                    return new DataResult
                    {
                        Data = "Username already exists in database",
                        Status = RequestStatus.Fail
                    };
                }
                db.User.Add(new Database.Tables.User
                {
                    account_type = accountType,
                    first_name = first_name,
                    last_name = last_name,
                    password_hash = HasherService.HashPassword(password),
                    user_name = username
                });
                db.SaveChanges();
            }

            return new DataResult
            {
                Data = "User " + username + " added to database succesfuly",
                Status = RequestStatus.Success
            };
        }

        internal static DataResult CancelReservation(int reservationID)
        {
            using (var db = new Context())
            {
                var requestToDelete = db.Requests.Where(s => s.ID_request == reservationID).FirstOrDefault();
                if (requestToDelete == null)
                {
                    return new DataResult
                    {
                        Data = "There is no reserwation " + reservationID.ToString(),
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

        internal static DataResult RemoveUser(int userID)
        {
            using (var db = new Context())
            {
                var user = db.User.Where(s => s.ID == userID).FirstOrDefault();
                if(user == null)
                {
                    return new DataResult
                    {
                        Data = "there is no user with ID " + userID.ToString() + " in database",
                        Status = RequestStatus.Fail
                    };
                }
                else
                {
                    db.User.Remove(user);
                    db.SaveChanges();
                    return new DataResult
                    {
                        Data = "User with ID " + userID.ToString() + " removed from database",
                        Status = RequestStatus.Success
                    };
                }
            }
        }

        internal static DataResult SetPermisions(int userID, AccountType accountType)
        {
            using (var db = new Context())
            {
                var user = db.User.Where(s => s.ID == userID).FirstOrDefault();
                if(user == null)
                {
                    return new DataResult
                    {
                        Data = "there is no user with ID " + userID.ToString() + " in database",
                        Status = RequestStatus.Fail
                    };
                }
                user.account_type = accountType;
                db.SaveChanges();
                return new DataResult
                {
                    Data = "User with ID " + userID.ToString() + " has new permissions",
                    Status = RequestStatus.Success
                };
            }
        }

        internal static DataResult ListAllUsers()
        {
            using (var db = new Context())
            {
                return new DataResult
                {
                    Data = db.User.Select(s => new UserModel
                    {
                        AccountType = s.account_type,
                        FirstName = s.first_name,
                        ID = s.ID,
                        LastLogged = s.last_logged,
                        LastName = s.last_name
                    }),
                    Status = RequestStatus.Success
                };
            }
        }
    }
}
