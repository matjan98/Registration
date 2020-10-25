using System;

namespace WebApiServer.Models
{
    internal class BookedAppointment
    {
        public DateTime DateTime { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorSpecializaion { get; set; }
        public int DoctorID { get; set; }
    }
}