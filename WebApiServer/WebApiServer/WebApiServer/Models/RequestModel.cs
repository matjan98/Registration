using System;

namespace WebApiServer.Models
{
    internal class RequestModel
    {
        public DateTime DateTime { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public int PatientID { get; set; }
    }
}