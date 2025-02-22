﻿using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        public int RegistrationNo { get; set; } 

        [Required]
        public string PatientName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }  

        [Required]
        public string Address { get; set; } 

        [Required]
        public string PhoneNumber { get; set; }     
    }
}
