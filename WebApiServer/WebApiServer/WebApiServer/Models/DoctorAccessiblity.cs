using System;
using System.Collections.Generic;

namespace WebApiServer.Models
{
    internal class DoctorAccessiblity
    {
        public List<DateTime> Visits { get; set; }
        public int VisitTimeInMinutes { get; set; }
        public TimeSpan WorkingTimeFrom { get; set; }
        public TimeSpan WorkingTimeTo { get; set; }
    }
}