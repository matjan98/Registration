using Database.Tables;
using System;

namespace WebApiServer.Models
{
    internal class DoctorModel
    {
        public string FirstName { get; set; }
        public int ID { get; set; }
        public DateTime LastLogged { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
    }
}