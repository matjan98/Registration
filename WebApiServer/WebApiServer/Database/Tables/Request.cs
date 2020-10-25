using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Tables
{
    public class Request
    {
        [Key]
        public int ID_request { get; set; }
        public DateTime datetime_created { get; set; }
        public DateTime datetime_appointment { get; set; }
        public int FK_ID_doctor { get; set; }
        public int FK_ID_patient { get; set; }

        [ForeignKey("FK_ID_doctor")]
        public virtual User Doctor { get; set; }

        [ForeignKey("FK_ID_patient")]
        public virtual User Patient { get; set; }

    }
}
