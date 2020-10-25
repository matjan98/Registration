using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiServer.Models;
using WebApiServer.Services;
namespace WebApiServer.Repositories
{
    public static class TargetDeveloperRepository
    {
        public static DataResult DateParser(long? dateTicks)
        {
            if (dateTicks == null)
            {
                return new DataResult
                {
                    Data = "Add 'dateTicks' to parameters!",
                    Status = RequestStatus.WrongData
                };
            }
            try
            {
                return new DataResult
                {
                    Data = new DateTime(dateTicks.Value).ToString("dddd, dd MMMM yyyy"),
                    Status = RequestStatus.Success
                };
            }
            catch
            {
                return new DataResult
                {
                    Data = "Bad 'dateTicks' parameter! (maybe too big?)",
                    Status = RequestStatus.WrongData
                };
            }
        }

        internal static object TimeSpanParser(long? timeTicks)
        {
            if (timeTicks == null)
            {
                return new DataResult
                {
                    Data = "Add 'timeTicks' to parameters!",
                    Status = RequestStatus.WrongData
                };
            }
            try
            {
                return new DataResult
                {
                    Data = new TimeSpan(timeTicks.Value).ToString("hh\\:mm"),
                    Status = RequestStatus.Success
                };
            }
            catch
            {
                return new DataResult
                {
                    Data = "Bad 'timeTicks' parameter! (maybe too big?)",
                    Status = RequestStatus.WrongData
                };
            }
        }

        public static DataResult TestApi()
        {
            return new DataResult
            {
                Data = "Everyhing works fine",
                Status = RequestStatus.Success
            };
        }
    }
}
