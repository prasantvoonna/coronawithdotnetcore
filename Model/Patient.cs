using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaDataManagement.Model
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        public String PatientName { get; set; }

        public String PatientStatus { get; set; }
    }
}
