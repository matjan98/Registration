using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Tables
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string user_name { get; set; }
        public string password_hash { get; set; }
        public DateTime last_logged { get; set; }
        public AccountType account_type { get; set; }

        public virtual DoctorSpecialization Specialization{ get; set; }
    }

    public enum AccountType
    {
        Patient,
        Doctor,
        Admin
    }
}
