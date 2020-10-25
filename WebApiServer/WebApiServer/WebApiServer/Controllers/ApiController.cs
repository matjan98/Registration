using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
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
        public ActionResult BookAnAppointmentWithDoctor()
        {
            if(!ValidateRolesService.ValidatePermission(Request, Database.Tables.AccountType.Patient))
            {
                return Ok(ValidateRolesService.PatientPermissionRequired);
            }
            return Ok("This method is not implemented");
        }

        [HttpGet]
        public ActionResult CancelAnAppointmentWithDoctor()
        {
            return Ok("This method is not implemented");
        }

        [HttpGet]
        public ActionResult ListBookedAppointments()
        {
            return Ok("This method is not implemented");
        }

        [HttpGet]
        public ActionResult ListDoctorAccesibility()
        {
            return Ok("This method is not implemented");
        }

        [HttpGet]
        public ActionResult ListDoctors()
        {
            return Ok("This method is not implemented");
        }

        #endregion

        #region TargetDoctor

        [HttpGet]
        public ActionResult SeeAllRequests()
        {
            return Ok("This method is not implemented");
        }

        [HttpGet]
        public ActionResult SetSpecialization()
        {
            return Ok("This method is not implemented");
        }

        [HttpGet]
        public ActionResult SetWorkingTime()
        {
            return Ok("This method is not implemented");
        }

        #endregion

        #region TargetAdministrator

        [HttpGet]
        public ActionResult CreateReservation()
        {
            return Ok("This method is not implemented");
        }

        [HttpGet]
        public ActionResult SetPerrmisions()
        {
            return Ok("This method is not implemented");
        }

        [HttpGet]
        public ActionResult RemoveUser()
        {
            return Ok("This method is not implemented");
        }

        [HttpGet]
        public ActionResult CancelReservation()
        {
            return Ok("This method is not implemented");
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return Ok("This method is not implemented");
        }

        [HttpGet]
        public ActionResult ListAllUsers()
        {
            return Ok("This method is not implemented");
        }

        #endregion

    }
}
