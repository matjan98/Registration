using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Tables
{
    public class DoctorSpecialization
    {
        [Key]
        public int FK_ID_User { get; set; }
        public string specialization { get; set; }


        [ForeignKey("FK_ID_User")]
        public virtual User User{ get; set; }
    }
}
