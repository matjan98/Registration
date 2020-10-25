using Database.Tables;
using System;

namespace WebApiServer.Models
{
    internal class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public AccountType AccountType { get; set; }
        public DateTime LastLogged { get; set; }
    }
}