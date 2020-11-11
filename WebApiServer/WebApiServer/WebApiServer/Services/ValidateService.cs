using Database;
using Database.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiServer.Models;

namespace WebApiServer.Services
{
    public static class ValidateService
    {
        public static bool ValidatePermission(HttpRequest request, AccountType accountType)
        {
            Microsoft.Extensions.Primitives.StringValues accessToken = request.Headers[HeaderNames.Authorization];
            var token = accessToken.ToString().Replace("Bearer ", "");
            var tokenCheckResult = LoginService.CheckToken(token);
            if (tokenCheckResult.Logged)
            {
                return tokenCheckResult.AccountType >= accountType;
            }
            else
            {
                return false;
            }
        }

        internal static DataResult Whoami(HttpRequest request)
        {
            Microsoft.Extensions.Primitives.StringValues accessToken = request.Headers[HeaderNames.Authorization];
            var token = accessToken.ToString().Replace("Bearer ", "");
            var tokenCheckResult = LoginService.CheckToken(token);
            if (tokenCheckResult.Logged)
            {
                var dbUser = GetUser(request);
                return new DataResult
                {
                    Status = RequestStatus.Success,
                    Data = new UserModel
                    {
                        AccountType = dbUser.account_type,
                        FirstName = dbUser.first_name,
                        ID = dbUser.ID,
                        LastLogged = dbUser.last_logged,
                        LastName = dbUser.last_name,
                    }
                };
            }
            else
            {
                return new DataResult
                {
                    Data = "You are not logged in",
                    Status = RequestStatus.Fail
                };
            }
        }

        public static User GetUser(HttpRequest request)
        {
            Microsoft.Extensions.Primitives.StringValues accessToken = request.Headers[HeaderNames.Authorization];
            var token = accessToken.ToString().Replace("Bearer ", "");
            var tokenCheckResult = LoginService.CheckToken(token);
            using (var db = new Context())
            {
                return db.User.Where(s => s.ID == tokenCheckResult.userID).FirstOrDefault();
            }
        }

        public static DataResult PatientPermissionRequired 
        { 
            get => new DataResult
            {
                Data = "This requires patient permission",
                Status = RequestStatus.Forbidden
            };
        }

        public static DataResult DoctorPermissionRequired
        {
            get => new DataResult
            {
                Data = "This requires doctor permission",
                Status = RequestStatus.Forbidden
            };
        }

        public static DataResult AdminPermissionRequired
        {
            get => new DataResult
            {
                Data = "This requires administrator permission",
                Status = RequestStatus.Forbidden
            };
        }

        public static DataResult BadTicksValue
        {
            get => new DataResult
            {
                Data = "Bad ticks value",
                Status = RequestStatus.WrongData
            };
        }

        public static bool ValidateDateTime(long? ticks)
        {
            if (ticks == null)
            {
                return false;
            }
            try
            {
                var Data = new DateTime(ticks.Value).ToString("dddd, dd MMMM yyyy");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidateTimeSpan(long? ticks)
        {
            if (ticks == null)
            {
                return false;
            }
            try
            {
                var Data = new TimeSpan(ticks.Value).ToString("hh\\:mm");
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
