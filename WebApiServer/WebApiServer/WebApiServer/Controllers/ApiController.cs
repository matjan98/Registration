using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            if(dateTicks == null)
            {
                return Ok("Add 'dateTicks' to parameters!");
            }
            try
            {
                return Ok(new DateTime(dateTicks.Value).ToString("dddd, dd MMMM yyyy"));
            }
            catch
            {
                return Ok("Bad 'dateTicks' parameter! (maybe too big?)");
            }
        }

        [HttpGet]
        public ActionResult TestApi()
        {
            return Ok("Everyhing works fine");
        }

        #endregion

        #region TagetUser

        [HttpGet]
        public ActionResult LogIn()
        {
            return Ok("This method is not implemented");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return Ok("This method is not implemented");
        }

        #endregion

        #region TagetPatient

        [HttpGet]
        public ActionResult BookAnAppointmentWithDoctor()
        {
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
