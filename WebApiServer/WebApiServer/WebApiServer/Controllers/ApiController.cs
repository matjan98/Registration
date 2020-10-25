using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Database.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using WebApiServer.Models;
using WebApiServer.Repositories;
using WebApiServer.Services;

namespace WebApiServer.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]")]
    [Produces("application/json")]
    public class ApiController : ControllerBase
    {

        public ApiController()
        {
        }

        #region TagetDeveloper

        [HttpGet]
        public ActionResult DateParser(long? dateTicks)
        {
            return Ok(TargetDeveloperRepository.DateParser(dateTicks));
        }


        [HttpGet]
        public ActionResult TimeSpanParser(long? timeTicks)
        {
            return Ok(TargetDeveloperRepository.TimeSpanParser(timeTicks));
        }

        [HttpGet]
        public ActionResult TestApi()
        {
            return Ok(TargetDeveloperRepository.TestApi());
        }

        #endregion

        #region TagetUser

        [HttpGet]
        public ActionResult LogIn(string username, string password)
        {
            return Ok(TargetUserRepository.LogIn(username, password));
        }

        [HttpGet]
        public ActionResult Register(string first_name, string last_name, string username, string password, bool doctor)
        {
            return Ok(TargetUserRepository.Register(first_name, last_name, username, password, doctor));
        }

        #endregion

        #region TagetPatient

        [HttpGet]
        public ActionResult BookAnAppointmentWithDoctor(int doctorID, long? dateTime)
        {
            if(!ValidateService.ValidatePermission(Request, Database.Tables.AccountType.Patient))
            {
                return Ok(ValidateService.PatientPermissionRequired);
            }
            return Ok(TargetPatientRepository.BookAnAppointmentWithDoctor(ValidateService.GetUser(Request), doctorID, dateTime));
        }

        [HttpGet]
        public ActionResult CancelAnAppointmentWithDoctor(int reserwationID)
        {
            if (!ValidateService.ValidatePermission(Request, Database.Tables.AccountType.Patient))
            {
                return Ok(ValidateService.PatientPermissionRequired);
            }
            return Ok(TargetPatientRepository.CancelAnAppointmentWithDoctor(ValidateService.GetUser(Request), reserwationID));
        }

        [HttpGet]
        public ActionResult ListBookedAppointments()
        {
            if (!ValidateService.ValidatePermission(Request, Database.Tables.AccountType.Patient))
            {
                return Ok(ValidateService.PatientPermissionRequired);
            }
            return Ok(TargetPatientRepository.ListBookedAppointments(ValidateService.GetUser(Request)));
        }

        [HttpGet]
        public ActionResult ListDoctorAccesibility(int doctorID, long? dateTimeFrom, long? dateTimeTo)
        {
            if (!ValidateService.ValidatePermission(Request, Database.Tables.AccountType.Patient))
            {
                return Ok(ValidateService.PatientPermissionRequired);
            }
            return Ok(TargetPatientRepository.ListDoctorAccesibility(doctorID, dateTimeFrom, dateTimeTo));
        }

        [HttpGet]
        public ActionResult ListDoctors()
        {
            if (!ValidateService.ValidatePermission(Request, Database.Tables.AccountType.Patient))
            {
                return Ok(ValidateService.PatientPermissionRequired);
            }
            return Ok(TargetPatientRepository.ListDoctors());
        }

        #endregion

        #region TargetDoctor

        [HttpGet]
        public ActionResult SeeAllRequests(long? dateTimeFrom, long? dateTimeTo)
        {
            if (!ValidateService.ValidatePermission(Request, Database.Tables.AccountType.Doctor))
            {
                return Ok(ValidateService.DoctorPermissionRequired);
            }
            return Ok(TargetDoctorRepository.SeeAllRequests(ValidateService.GetUser(Request), dateTimeFrom, dateTimeTo));
        }

        [HttpGet]
        public ActionResult SetSpecialization(string specialization)
        {
            if (!ValidateService.ValidatePermission(Request, Database.Tables.AccountType.Doctor))
            {
                return Ok(ValidateService.DoctorPermissionRequired);
            }
            return Ok(TargetDoctorRepository.SetSpecialization(ValidateService.GetUser(Request), specialization));
        }

        [HttpGet]
        public ActionResult SetWorkingTime(long? timeSpanFrom, long? timeSpanTo)
        {
            if (!ValidateService.ValidatePermission(Request, Database.Tables.AccountType.Doctor))
            {
                return Ok(ValidateService.DoctorPermissionRequired);
            }
            return Ok(TargetDoctorRepository.SetWorkingTime(ValidateService.GetUser(Request), timeSpanFrom, timeSpanTo));
        }

        #endregion

        #region TargetAdministrator

        [HttpGet]
        public ActionResult CreateReservation(int doctorID, int patientID, long? datetime)
        {
            if (!ValidateService.ValidatePermission(Request, Database.Tables.AccountType.Admin))
            {
                return Ok(ValidateService.AdminPermissionRequired);
            }
            return Ok(TargetAdministratorRepository.CreateReservation(doctorID, patientID, datetime));
        }

        [HttpGet]
        public ActionResult SetPerrmisions(int userID, AccountType accountType)
        {
            if (!ValidateService.ValidatePermission(Request, Database.Tables.AccountType.Admin))
            {
                return Ok(ValidateService.AdminPermissionRequired);
            }
            return Ok(TargetAdministratorRepository.SetPerrmisions(userID, accountType));
        }

        [HttpGet]
        public ActionResult RemoveUser(int userID)
        {
            if (!ValidateService.ValidatePermission(Request, Database.Tables.AccountType.Admin))
            {
                return Ok(ValidateService.AdminPermissionRequired);
            }
            return Ok(TargetAdministratorRepository.RemoveUser(userID));
        }

        [HttpGet]
        public ActionResult CancelReservation(int reservationID)
        {
            if (!ValidateService.ValidatePermission(Request, Database.Tables.AccountType.Admin))
            {
                return Ok(ValidateService.AdminPermissionRequired);
            }
            return Ok(TargetAdministratorRepository.CancelReservation(reservationID));
        }

        [HttpGet]
        public ActionResult AddUser(string first_name, string last_name, string username, string password, AccountType accountType)
        {
            if (!ValidateService.ValidatePermission(Request, Database.Tables.AccountType.Admin))
            {
                return Ok(ValidateService.AdminPermissionRequired);
            }
            return Ok(TargetAdministratorRepository.AddUser(first_name, last_name, username, password, accountType));
        }

        [HttpGet]
        public ActionResult ListAllUsers()
        {
            if (!ValidateService.ValidatePermission(Request, Database.Tables.AccountType.Admin))
            {
                return Ok(ValidateService.AdminPermissionRequired);
            }
            return Ok(TargetAdministratorRepository.ListAllUsers());
        }

        #endregion

    }
}
