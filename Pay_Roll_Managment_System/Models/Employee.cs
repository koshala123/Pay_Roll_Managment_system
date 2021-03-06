﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Id auto-generated by the database
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public string ContactInfo { get; set; }
        [Required]
        public string Gender { get; set; } // 1 == male , 0 == female
        [Required]
        public string RegistrationNo { get; set; }
        
        //[Required]
        public string ImgUrl { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }

        [ForeignKey("PoistionId")]
        public Position Position { get; set; }
        public int PoistionId { get; set; }

    }
}
