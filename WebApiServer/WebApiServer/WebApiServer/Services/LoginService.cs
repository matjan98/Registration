using Database.Tables;
using MlkPwgen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiServer.Models;

namespace WebApiServer.Services
{
    public static class LoginService
    {
        private static List<LoggedUser> loggedUsers = new List<LoggedUser>();

        public static string LogIn(int userID, AccountType accountType, string username, string password)
        {
            var userAlreadyLogged = loggedUsers.Where(s => s.username == username).FirstOrDefault();
            if (userAlreadyLogged != null)
            {
                loggedUsers.Remove(userAlreadyLogged);
            }
            var token = PasswordGenerator.Generate(length: 15, allowed: Sets.Alphanumerics);
            loggedUsers.Add(new LoggedUser
            {
                userID = userID,
                password = password,
                username = username,
                token = token,
                accountType = accountType
            });
            return token;
        }

        public static void LogOut(int userID)
        {
            var userAlreadyLogged = loggedUsers.Where(s => s.userID == userID).FirstOrDefault();
            if (userAlreadyLogged != null)
            {
                loggedUsers.Remove(userAlreadyLogged);
            }
        }

        public static void LogOut(string username)
        {
            var userAlreadyLogged = loggedUsers.Where(s => s.username == username).FirstOrDefault();
            if (userAlreadyLogged != null)
            {
                loggedUsers.Remove(userAlreadyLogged);
            }
        }

        public static bool Logged(int userID)
        {
            var userAlreadyLogged = loggedUsers.Where(s => s.userID == userID).FirstOrDefault();
            return userAlreadyLogged != null;
        }

        public static bool Logged(string username)
        {
            var userAlreadyLogged = loggedUsers.Where(s => s.username == username).FirstOrDefault();
            return userAlreadyLogged != null;
        }

        public static TokenCheckResult CheckToken(string token)
        {
            var userAlreadyLogged = loggedUsers.Where(s => s.token == token).FirstOrDefault();
            if(userAlreadyLogged == null)
            {
                return new TokenCheckResult
                {
                    Logged = false,
                    AccountType = AccountType.Patient
                };
            }
            else
            {
                return new TokenCheckResult
                {
                    Logged = true,
                    AccountType = userAlreadyLogged.accountType
                };
            }
        }
    }

    internal class LoggedUser
    {
        public int userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string passwordHash { get => HasherService.HashPassword(this.password); }
        public string token { get; set; }
        public AccountType accountType { get; set; }
    }
}
