using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiServer.Models;
using WebApiServer.Services;

namespace WebApiServer.Repositories
{
    public class TargetUserRepository
    {
        public static DataResult Register(string first_name, string last_name, string username, string password, bool doctor)
        {
            if (string.IsNullOrWhiteSpace(first_name))
            {
                return new DataResult
                {
                    Data = "first_name is empty",
                    Status = RequestStatus.WrongData
                };
            }

            if (string.IsNullOrWhiteSpace(last_name))
            {
                return new DataResult
                {
                    Data = "last_name is empty",
                    Status = RequestStatus.WrongData
                };
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                return new DataResult
                {
                    Data = "username is empty",
                    Status = RequestStatus.WrongData
                };
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return new DataResult
                {
                    Data = "password is empty",
                    Status = RequestStatus.WrongData
                };
            }

            using (var db = new Context())
            {
                if (db.User.Where(s => s.user_name == username).FirstOrDefault() != null)
                {
                    return new DataResult
                    {
                        Data = "Username already exists in database",
                        Status = RequestStatus.Fail
                    };
                }
                db.User.Add(new Database.Tables.User
                {
                    account_type = doctor ? Database.Tables.AccountType.Doctor : Database.Tables.AccountType.Patient,
                    first_name = first_name,
                    last_name = last_name,
                    password_hash = HasherService.HashPassword(password),
                    user_name = username
                });
                db.SaveChanges();
            }
            return new DataResult
            {
                Data = "User " + username + " added to database succesfuly",
                Status = RequestStatus.WrongData
            };
        }


        public static DataResult LogIn(string username, string password)
        {
            using (var db = new Context())
            {
                var user = db.User.Where(s => s.user_name == username).FirstOrDefault();
                if (user != null)
                {
                    if(user.password_hash == HasherService.HashPassword(password))
                    {
                        var token = LoginService.LogIn(user.ID, user.account_type, username, password);
                        return new DataResult
                        {
                            Data = token,
                            Status = RequestStatus.Success
                        };
                    }
                    else
                    {
                        return new DataResult
                        {
                            Data = "Wrong username or password",
                            Status = RequestStatus.Fail
                        };
                    }
                }
                else
                {
                    return new DataResult
                    {
                        Data = "Wrong username or password",
                        Status = RequestStatus.Fail
                    };
                }
            }
        }
    }
}
