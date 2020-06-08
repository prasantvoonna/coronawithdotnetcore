using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaDataManagement.Model
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Required]
        public String DoctorName { get; set; }

        public String DoctorStatus { get; set; }
    }
}
