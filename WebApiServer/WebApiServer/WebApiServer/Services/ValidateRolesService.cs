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
    public static class ValidateRolesService
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

    }
}
