using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiServer.Models
{
    public class DataResult
    {
        public RequestStatus Status { get; set; }
        public object Data { get; set; }
    }

    public enum RequestStatus
    {
        Success,
        Fail,
        Forbidden,
        WrongData
    }
}
